using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using System.Data;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.Entities.Schemas;
using Databridge.Engine.Extensions;
using System.Windows.Forms.Design;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System.Net;
using Databridge.Engine.Web;
using HtmlAgilityPack;
using System.Threading;
using System.Windows.Forms;

namespace Iris.DMG.CyM.Social
{
  [Serializable]
  public abstract class BaseFBOperation : BaseSocialOperation
  {
    public BaseFBOperation(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Entrada", "Data Início", "Data Fim", "CredentialList");
      SetOutputs("Saída");

    }


    public override void Reset()
    {
      base.Reset();
      if ((openDialogs != null) && (openDialogs.Count != 0))
      {
        foreach (BrowserDialog dlg in openDialogs)
        {
          dlg.Close();
          dlg.Dispose();
        }
        openDialogs.Clear();
      }

      openDialogs = null;
    }

    protected virtual void SetupTable()
    {
      if (GetOutput("Saída") != null)
      {
        ResultSet rs = (ResultSet)GetOutput("Saída").EntityValue;
        lock (rs)
        {
          if (rs.Table != null)
          {
            rs.Table.Clear();
            rs.Table = null;
          }

          DataTable table = new DataTable(rs.Name);
          CreateColumns(table);
          rs.Table = table;
        }
      }
    }

    protected abstract void CreateColumns(DataTable table);

    protected override void doAfterExecute()
    {

    }

    protected bool IsAccountDead(string html)
    {
      if (html.Contains("Insira o código que enviamos por SMS") || html.Contains("Sua conta foi desativada")
        || html.Contains("Enviaremos um SMS com um código para confirmar que o número pertence a")
        || html.Contains("Escolha uma verificação de segurança"))
      {
        return true;
      }

      return false;
    }


    protected void RemoveCurrentAccount()
    {

      if (creds.Rows.Count != 0)
      {
        DataRow removedRow = creds.Rows.Cast<DataRow>().FirstOrDefault(x => Convert.ToString(x[0]) == userName);
        if (removedRow != null)
        {
          removedRow.Delete();

          int idx = userNames.IndexOf(userName);

          userNames.RemoveAt(idx);
          passwords.RemoveAt(idx);
        }
      }

      if ((userNames.Count == 0) || (creds.Rows.Count == 0))
      {
        throw new Exception("Credentials not loaded or expired");
      }

    }



    protected virtual void ProcessLinks(params string[] links)
    {
      foreach (string url in links)
      {
        //§ utilizado em casos de processamento de mais de uma página, como no caso dos perfis
        //vide classe FB_Profile
        if (!string.IsNullOrEmpty(url))
        {
          {
            string html = BrowserDialog.NavigateSync(url.Remove("§"));

            if (IsAccountDead(html))
            {
              RemoveCurrentAccount();
              SwitchToRandomAccount();

              html = BrowserDialog.NavigateSync(url.Remove("§"));

            }
            try
            {
              ProcessPage(html, url);
            }
            catch (Exception ex)
            {
              Structure.AddToErrorLog(ex.Message, this);
            }

          }
        }
      }

    }

    protected abstract void ProcessPage(string html, string url);

    protected void FinishExecution()
    {
      base.doAfterExecute();
    }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private List<BrowserDialog> openDialogs;


    [NonSerialized]
    protected Random rnd;

    protected override IEntity doExecute()
    {
      SetupTable();

      string[] links = InitExecute();

      linkStack = new Stack<string>(links);

      DeStackLink();


      return null;
    }

    protected Stack<string> linkStack;
    protected void DeStackLink()
    {
      if (linkStack.Count == 0)
      {
        FinishExecution();
      }
      else
      {
        string link = linkStack.Pop();
        this.Structure.AddToLog($"{link}", this);

        Sleep();

        ProcessLinks(link);
      }
    }


    protected void Sleep(int factor = 1)
    {
      int localInterval = Interval / factor;

      int halfInterval = localInterval / 2;

      int sleep = rnd.Next(halfInterval, localInterval + halfInterval);
      DateTime dtn = DateTime.Now.AddMilliseconds(sleep);

      this.Structure.AddToLog($"Sleep until {dtn} - {sleep}ms", this);
      Thread.Sleep(sleep);

    }

    private void SwitchToRandomAccount()
    {
      if (userNames.Count > 0)
      {
        if (userNames.Count > 1)
        {
          userName = userNames.Where(x => x != userName).ToList().GetRandomItem();
          int idx = userNames.IndexOf(userName);
          password = passwords[idx];
        }

        bool result = SwitchToNewAccount();

        if (!result)
        {
          RemoveCurrentAccount();
          SwitchToRandomAccount();
        }
      }
    }

    protected virtual string[] InitExecute()
    {
      rnd = new Random();
      ResultSet resultset = (ResultSet)GetInput("Entrada").EntityValue;
      DataTable table = resultset.Table;

      if (GetInput("CredentialList") != null)
      {
        ResultSet credsRS = (ResultSet)GetInput("CredentialList").EntityValue;
        creds = credsRS.Table;
        userNames = creds.Rows.Cast<DataRow>().Select(x => Convert.ToString(x[0])).ToList();
        passwords = creds.Rows.Cast<DataRow>().Select(x => Convert.ToString(x[1])).ToList();

        SwitchToRandomAccount();
      }

      if (GetInput("Data Fim") != null)
        DataLimite = Convert.ToDateTime(GetInput("Data Fim").Value);

      string[] links = table.Rows.Cast<DataRow>().Select(x => Convert.ToString(x[Column])).ToArray();
      openDialogs = new List<BrowserDialog>();

      return links;
    }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private List<string> userNames;
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private List<string> passwords;
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private DataTable creds;

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private string userName;
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private string password;


    protected bool SwitchToNewAccount()
    {


      string html = BrowserDialog.NavigateSync("https://m.facebook.com");

      if (html.Contains("No que você está pensando?"))
        return true;

      string origHtml = html;
      string link = "";

      if (IsAccountDead(html))
      {
        link = html.MatchSingle(@"/checkpoint/\d+/logout");
        link = html.Substring(link);
        link = link.Remove("\"");
        link = "https://m.facebook.com" + link;

        Sleep(10);

        html = BrowserDialog.NavigateSync(link);

        if (html.Contains("Tem certeza de que deseja sair?"))
        {
          string logoutLinkNaTora = "https://m.facebook.com/" + html.Substring("logout.php?").Remove("\"");
          Sleep(10);
          html = BrowserDialog.NavigateSync(logoutLinkNaTora);
        }
      }

      while (html.Contains("/a/nux/wizard/nav.php?"))
      {
        link = html.Substring("/a/nux/wizard/nav.php?");
        if (!link.StartsWith("<!"))
        {
          link = link.Remove(">").TrimEnd('\'', '"');
          link = WebUtility.HtmlDecode(link);
          link = "https://m.facebook.com" + link;

          Sleep(10);

          html = BrowserDialog.NavigateSync(link);
        }
      }

      string origHtml2 = html;
      string link2 = link;

      link = html.Substring("mbasic_logout_button");
      if (!link.StartsWith("<!"))
      {
        link = link.Substring("/logout.php?");
        link = link.Remove(">").TrimEnd('\'', '"');

        if (link.Contains("href="))
        {
          link = link.Substring("=").Trim('\'', '"', '=');
        }

        link = WebUtility.HtmlDecode(link);
        link = "https://m.facebook.com" + link;

        Sleep(10);

        html = BrowserDialog.NavigateSync(link);
      }

      string origHtml3 = html;
      string link3 = link;


      if (html.Contains("Deseja salvar sua senha antes de sair?"))
      {
        BrowserDialog navDlg = new BrowserDialog();
        List<HtmlElement> list = navDlg.webBrowser.Document.GetElementsByTagName("FORM").Cast<HtmlElement>().ToList();
        HtmlElement naoSalvar = list.FirstOrDefault(x => x.InnerHtml.Contains("Não salvar"));
        naoSalvar.InvokeMember("submit");

        navDlg.WaitForPost();


        //string logoutLinkNaTora = "https://m.facebook.com/" + naoSalvar.OuterHtml.Substring("logout.php?").Remove("\"");
        //html = navDlg.NavigateSync(logoutLinkNaTora);
        //html = navDlg.NavigateSync("https://m.facebook.com/");
      }

      link = html.Substring("href=\"/login/?");
      if (string.IsNullOrEmpty(link))
      {
        link = html.Substring("href='/login/?");
      }

      link = link.Substring("/login");
      link = link.Remove(">").TrimEnd('\'', '"');
      link = WebUtility.HtmlDecode(link);
      link = "https://m.facebook.com" + link;

      Sleep(10);



      using (BrowserDialog navDlg = new BrowserDialog())
      {
        html = navDlg.doNavigateSync(link);

        navDlg.webBrowser.Document.GetElementById("m_login_email").SetAttribute("value", userName);
        HtmlElement pass = navDlg.webBrowser.Document.GetElementsByTagName("input").Cast<HtmlElement>().First(x => x.Name == "pass");
        pass.SetAttribute("value", password);
        HtmlElement form = navDlg.webBrowser.Document.GetElementById("login_form");

        Sleep(10);

        form.InvokeMember("submit");

        navDlg.WaitForPost();

        Sleep(10);


        html = navDlg.Html;
        //html = navDlg.NavigateSync("https://m.facebook.com");

        navDlg.Close();
        navDlg.Dispose();
      }
      if (IsAccountDead(html))
      {
        return false;
      }

      return true;
    }


    internal static string GetReactionsLink(string html, string reactions)
    {
      string tempHtm = html.Remove(reactions);
      int anchorIndex = tempHtm.LastIndexOf("href");
      tempHtm = tempHtm.Substring(anchorIndex).Substring("/ufi");
      tempHtm = tempHtm.Remove("\">");
      tempHtm = $"https://m.facebook.com{tempHtm}";
      return tempHtm;
    }

    internal static DateTime? DateFromAbbr(string date)
    {
      DateTime? dt = null;
      if (date.ToLower().Contains("hoj"))
      {
        dt = DateTime.Today;
      }
      date = date.Replace("\r\n", "");
      string mtch = date.MatchSingle(@"\d+ de \w+( de \d+)?");

      if (!string.IsNullOrEmpty(mtch))
      {
        dt = mtch.ToDate();
      }
      else
      {
        mtch = date.MatchSingle(@"\d+ de \w+ às \d+:\d+");
        if (!string.IsNullOrEmpty(mtch))
        {
          string dtPart = mtch.Remove("às") + " de " + DateTime.Today.Year.ToString();
          dt = dtPart.ToDate();
        }
        else
        {

          mtch = date.MatchSingle(@"\w+ às \d\d:\d\d");
          if (!string.IsNullOrEmpty(mtch))
          {
            dt = DateTime.Today;
            mtch = date.MatchSingle(@"\w+").Remove("-").ToLower();

            List<string> days = new List<string> { "domingo", "segunda", "terça", "quarta", "quinta", "sexta", "sábado" };

            int dtIndex = days.IndexOf(mtch);

            int todayIndex = Convert.ToInt32(dt.Value.DayOfWeek);

            if (dtIndex == -1)
            {
              if (mtch == "ontem")
                dt = dt.Value.AddDays(-1);
            }
            else
            {
              dt = dt.Value.AddDays(dtIndex - todayIndex);
              if (dt > DateTime.Today)
                dt = dt.Value.AddDays(-7);
            }

          }
          else
          {
            mtch = date.MatchSingle(@"(há )?\d+ h(\w+)?");
            if (!string.IsNullOrEmpty(mtch))
            {
              dt = DateTime.Today;
              mtch = mtch.MatchSingle(@"\d+");
              dt = dt.Value.AddHours((Convert.ToInt32(mtch) * -1) + DateTime.Now.Hour);
            }
            else
            {
              mtch = date.MatchSingle(@"há? \d+ mi(\w+)?");
              if (!string.IsNullOrEmpty(mtch))
              {
                dt = DateTime.Today;
                mtch = mtch.MatchSingle(@"\d+");
                dt = dt.Value.AddMinutes(Convert.ToInt32(mtch) * -1);
              }
              else
              {
                dt = DateTime.Today;
                mtch = date.MatchSingle(@"há? \d+ an(\w+)?");
                if (!string.IsNullOrEmpty(mtch))
                {
                  dt = DateTime.Today;
                  mtch = mtch.MatchSingle(@"\d+");
                  dt = dt.Value.AddYears(Convert.ToInt32(mtch) * -1);
                }
                else
                {
                  dt = DateTime.Today;
                  mtch = date.MatchSingle(@"há? \d+ m(ê|e)s(\w+)?");
                  if (!string.IsNullOrEmpty(mtch))
                  {
                    dt = DateTime.Today;
                    mtch = mtch.MatchSingle(@"\d+");
                    dt = dt.Value.AddMonths(Convert.ToInt32(mtch) * -1);
                  }
                  mtch = date.MatchSingle(@"\d+ h");
                  if (!string.IsNullOrEmpty(mtch))
                  {
                    dt = DateTime.Today;
                    mtch = mtch.MatchSingle(@"\d+");
                    dt = dt.Value.AddHours(Convert.ToInt32(mtch) * -1);
                  }
                  else
                  {
                    dt = DateTime.Today;
                    mtch = date.MatchSingle(@"\d+ sem");
                    if (!string.IsNullOrEmpty(mtch))
                    {
                      dt = DateTime.Today;
                      mtch = mtch.MatchSingle(@"\d+");
                      dt = dt.Value.AddDays(Convert.ToInt32(mtch) * -7);
                    }

                  }
                }
              }
            }
          }
        }

      }

      string time = date.MatchSingle(@"\d\d:\d\d");
      if (!string.IsNullOrEmpty(time) && (dt != null))
      {
        int hour = Convert.ToInt32(time.Remove(":"));
        int minute = Convert.ToInt32(time.Substring(":").Trim(':'));

        dt = dt.Value.AddHours(hour);
        dt = dt.Value.AddMinutes(minute);
      }


      return dt;
    }
  }
}
