using System;
using System.Text.RegularExpressions;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using System.Net.Mail;
using Iris.Runtime.Model.Operations.NetworkOperations;
using Databridge.Interfaces;
using System.ComponentModel;
using Iris.PropertyEditors;
using System.Drawing.Design;
using Databridge.Engine.Parsers;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Interfaces;
using Iris.Runtime.Model.PropertyEditors;
using Databridge.Engine;
using System.Data;
using System.Net;
using System.Windows.Forms;

namespace Iris.Runtime.NetworkOperations
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Envio de E-Mail")]
  public class SendMail : NetworkOperation, IColumnBasedOperation
  {
    public SendMail(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Template");
    }

    private int port;
    [Category("Server")]
    public int Port
    {
      get { return port; }
      set { port = value; }
    }

    private string toField;
    [Editor(typeof(CBOColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("To"), Category("Fields")]
    public string ToField
    {
      get { return toField; }
      set { toField = value; }
    }

    private string from;
    [DisplayName("From"), Category("Fields")]
    public string From
    {
      get { return from; }
      set { from = value; }
    }

    private string subjectField;
    [Editor(typeof(CBOColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Subject"), Category("Fields")]
    public string SubjectField
    {
      get { return subjectField; }
      set { subjectField = value; }
    }

    private string bodyField;
    [Editor(typeof(CBOColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Body"), Category("Fields")]
    public string BodyField
    {
      get { return bodyField; }
      set { bodyField = value; }
    }

    private string smtp;
    [Category("Server")]
    public string Smtp
    {
      get { return smtp; }
      set { smtp = value; }
    }


    /*message.From = new System.Net.Mail.MailAddress("From@online.microsoft.com");
message.Body = "This is the message body";
System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("yoursmtphost");
smtp.Send(message);*/

    private bool useDefaulCredentials;
    [Category("Server")]
    public bool UseDefaulCredentials
    {
      get { return useDefaulCredentials; }
      set { useDefaulCredentials = value; }
    }

    [Category("Server")]
    public override NetworkCredential WebCredentials
    {
      get
      {
        return base.WebCredentials;
      }

      set
      {
        base.WebCredentials = value;
      }
    }
    protected override Interfaces.IEntity doExecute()
    {

      DataTable table = ((IColumnBasedOperation)this).Entrada.Table;
      int i = 0;
      int ct = table.Rows.Count;
      foreach (DataRow row in table.Rows)
      {

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(From);

        string mailPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        string to = Convert.ToString(row[ToField]).ToLower();
        Regex rx = new Regex(mailPattern);
        Match match = rx.Match(to);
        if (match.Success)
        {

          msg.To.Add(match.Value);

          msg.Subject = Convert.ToString(row[SubjectField]);

          string body = Convert.ToString(row[BodyField]);

          msg.Body = MergeText(body, GetParameters(row));
          msg.IsBodyHtml = HtmlBody;
          SmtpClient client = new SmtpClient(Smtp, Port);

          client.UseDefaultCredentials = UseDefaulCredentials;
          if (!UseDefaulCredentials)
            client.Credentials = WebCredentials;
          i++;

          try
          {
            client.Send(msg);

            Structure.AddToLog($"Mensagem {i} de {ct} enviada para {match.Value}", this);

          }
          catch (Exception ex)
          {
            Structure.AddToLog($"Falha no envio da mensagem {i} de {ct} para {match.Value}. Mensagem Original: {ex.Message}" , ex, this);

          }
          Application.DoEvents();
        }
      }
      return null;
    }

    [Category("Server")]
    public bool HtmlBody { get; set; }

    private string MergeText(string text, Dictionary<string, string> parameters)
    {
      string pattern = @"\{\&\w+(_\w+)?\}";
      Regex rx = new Regex(pattern);

      MatchCollection matches = rx.Matches(text);

      foreach (Match match in matches)
      {
        string key = match.Value.Trim('{', '}', '&');
        string value = "";
        if (parameters.ContainsKey(key))
          value = parameters[key];

        text = text.Replace(match.Value, value);

      }

      return text;
    }

    private Dictionary<string, string> GetParameters(DataRow row)
    {
      Dictionary<string, string> parameters = new Dictionary<string, string>();
      foreach (DataColumn col in row.Table.Columns)
      {
        parameters[col.ColumnName] = Convert.ToString(row[col]);
      }
      return parameters;
    }


    
    [Browsable(false)]
    public string Language
    {
      get { return "Text"; }
    }



    string IColumnBasedOperation.Column
    {
      get
      {
        return "";
      }

      set
      {
      }
    }

    string IColumnBasedOperation.ColumnName
    {
      get
      {
        return "";
      }

      set
      {

      }
    }

    IEntity IColumnBasedOperation.EntityValue
    {
      get
      {
        return null;
      }
    }

    IResultSet IColumnBasedOperation.Entrada
    {
      get
      {
        if (GetInput("Entrada") != null)
        {
          IResultSet input = GetInput("Entrada").EntityValue as IResultSet;
          return input;
        }
        else
          return null;
      }
    }

    string IColumnBasedOperation.Name
    {
      get
      {
        return Name;
      }

      set
      {
        Name = value;
      }
    }


  }
}
