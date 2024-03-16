using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using System.Data;
using Databridge.Engine.Extensions;
using Databridge.Engine.Web;
using HtmlAgilityPack;
using System.Net;

namespace Iris.DMG.CyM.Social
{
  [Serializable]
  [OperationCategory("Facebook", "Extrator de Comentários")]
  public class FB_Comments : Operation
  {
    public FB_Comments(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetOutputs("Saída");
      SetInputs("WorkPath");
    }

    private string workPath;

    public string WorkPath
    {
      get
      {
        if (GetInput("WorkPath") != null)
        {
          ScalarVar pathVar = GetInput("WorkPath") as ScalarVar;
          if (pathVar != null)
          {
            return Convert.ToString(pathVar.Value);
          }
        }

        return workPath;
      }
      set { workPath = value; }
    }

    protected override IEntity doExecute()
    {
      ResultSet resultset = (ResultSet)GetOutput("Saída").EntityValue;
      resultset.Clear();
      DataTable table = new DataTable(resultset.Name);
      table.Columns.Add("Post_URL");
      table.Columns.Add("Post_Author");
      table.Columns.Add("Post_AuthorURL");
      table.Columns.Add("Comment_Text");
      table.Columns.Add("Comment_Id");
      table.Columns.Add("Comment_Author");
      table.Columns.Add("Comment_Author_URL");
      table.Columns.Add("Comment_Date", typeof(DateTime));
      table.Columns.Add("Comment_ReactionCount", typeof(int));
      table.Columns.Add("Comment_ReactionLink");
      table.Columns.Add("Comment_DateStr");

      resultset.Table = table;

      string[] fileNames = Directory.GetFiles(WorkPath, "*.html");

      foreach (string file in fileNames)
      {
        string html = File.ReadAllText(file);

        string[] fileNameParts = Path.GetFileNameWithoutExtension(file).Split('-');

        string url = $"https://m.facebook.com/story.php?story_fbid={fileNameParts[0]}&id={fileNameParts[1]}";
        ProcessPage(html, url);
      }

      return null;
    }


    private void ProcessPage(string html, string url)
    {
      if( (string.IsNullOrWhiteSpace(html))|| html.Contains("Conteúdo não encontrado"))
        return;
      try
      {
        ContentExtractor extractor = new ContentExtractor(html, true);
        string postUrl = url;

        if (GetOutput("Saída") != null)
        {
          ResultSet rs = (ResultSet)GetOutput("Saída").EntityValue;
          DataTable table = rs.Table;
          HtmlDocument doc = new HtmlDocument();
          doc.LoadHtml(html);

          List<HtmlNode> nodes = doc.FlattenDocument();

          HtmlNode header = nodes.FirstOrDefault(x => x.Name.ToLower() == "header");
          string post_Author = "";
          string post_AuthorUrl = "";
          if (header != null)
          {
            List<HtmlNode> headerNodes = HtmlDocument.FlattenNode(header);
            HtmlNode headerH3 = headerNodes.FirstOrDefault(x => x.Name.ToLower() == "h3");
            post_Author = headerH3.InnerText.DtbClean().Replace("§", " ").Replace("|", ",");
            post_AuthorUrl = $"https://m.facebook.com" + HtmlDocument.FlattenNode(headerH3).FirstOrDefault(x => x.Name == "a").Attributes["href"].Value;
          }
          else
          {
            HtmlNode actorNode = nodes.First(x => x.Attributes.Contains("class") && (x.Attributes["class"].Value == "actor-link"));
            post_Author = actorNode.InnerText.DtbClean().Replace("§", " ").Replace("|", ",");
            post_AuthorUrl = $"https://m.facebook.com" + actorNode.Attributes["href"].Value;
          }

          nodes = nodes.Where(x => x.Name.ToLower() == "h3").ToList();

          nodes = nodes.Where(x => (x.ParentNode != null) && (x.ParentNode.Name == "div")).ToList();
          nodes = nodes.Where(x => (x.ParentNode.ParentNode != null) && (x.ParentNode.ParentNode.Name == "div")).ToList();

          nodes = nodes.Select(x => x.ParentNode.ParentNode).ToList();

          int recCount = table.Rows.Count;

          table.BeginLoadData();
          foreach (HtmlNode node in nodes)
          {
            if (node.Attributes.Contains("id"))
            {
              DataRow row = table.NewRow();

              row["Post_Author"] = post_Author;
              row["Post_AuthorURL"] = post_AuthorUrl;

              row["Post_URL"] = postUrl;

              string id = node.Attributes["id"].Value;
              row["Comment_Id"] = id;

              List<HtmlNode> children = HtmlDocument.FlattenNode(node);

              HtmlNode abbr = children.FirstOrDefault(x => x.Name.ToLower() == "abbr");
              row["Comment_Date"] = BaseFBOperation.DateFromAbbr(abbr.InnerText);
              row["Comment_DateStr"] = abbr.InnerText.Extract("\r\n");

              HtmlNode h3 = children.First(x => x.Name.ToLower() == "h3");

              HtmlNode contentDiv = h3.NextSibling.NextSibling;
              row["Comment_Text"] = contentDiv.InnerText.DtbClean().Replace("|", ",");

              children = HtmlDocument.FlattenNode(h3);

              HtmlNode a = children.First(x => x.Name.ToLower() == "a");
              row["Comment_Author_URL"] = $"https://m.facebook.com{WebUtility.HtmlDecode(a.Attributes["href"].Value)}";

              string author = a.InnerText.DtbClean().Replace("§", " ");

              row["Comment_Author"] = author;

              string localHtml = node.InnerHtml;

              string reactions = localHtml.DtbClean().Replace("§", " ").MatchSingle(@"\d+ reaç(ão|ões), incluindo");

              string reactionCount = reactions.MatchSingle(@"\d+");
              if (!String.IsNullOrWhiteSpace(reactionCount))
              {
                row["Comment_ReactionCount"] = Convert.ToInt32(reactions.MatchSingle(@"\d+"));
                string tempHtm = BaseFBOperation.GetReactionsLink(html, reactions);
                row["Comment_ReactionLink"] = tempHtm;
              }
              else
              {
                row["Comment_ReactionCount"] = "0";
              }

              foreach (DataColumn column in table.Columns)
              {
                row[column] = Convert.ToString(row[column]).DtbClean();
              }

              table.LoadDataRow(row);
            }
          }
          table.EndLoadData();
        }
      }
      catch(Exception ex)
      {
        Structure.AddToErrorLog(ex.Message, this);
        
      }
    }

  }
}
