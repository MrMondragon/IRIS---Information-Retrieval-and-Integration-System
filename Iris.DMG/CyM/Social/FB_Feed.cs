using System;
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
using System.IO;
using System.ComponentModel;

namespace Iris.DMG.CyM.Social
{
  [Serializable]
  [OperationCategory("Facebook", "Extrator de Feed")]
  public class FB_Feed : BaseFBOperation
  {
    public FB_Feed(Structure aStructure, string aName) : base(aStructure, aName)
    {

    }



    protected override void CreateColumns(DataTable table)
    {
      table.Columns.Add("Post_URL");
      table.Columns.Add("Post_Text");
      table.Columns.Add("Post_Date", typeof(DateTime));
      table.Columns.Add("Post_ReactionCount", typeof(int));
      table.Columns.Add("Post_ReactionLink");
      table.Columns.Add("Post_HTML");
      table.Columns.Add("Post_Author");
      table.Columns.Add("Post_ShareCount");
      table.Columns.Add("Post_ShareLink");
    }

    public string FeedFileName { get; set; }
    public string CommentsFileName { get; set; }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private int feedCount;
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private List<string> urls;
    protected override IEntity doExecute()
    {
      feedCount = 0;
      urls = new List<string>();

      if(File.Exists(FeedFileName))
      {
        urls = File.ReadAllLines(FeedFileName).Select(x => x.Remove("|")).ToList();
      }

      return base.doExecute();
    }

    protected override string[] InitExecute()
    {
      string[] list = base.InitExecute().Where(x=> !urls.Contains(x)).ToArray();

      return list;
    }


    protected override void ProcessPage(string html, string url)
    {
 
        
      feedCount += 1;
      Structure.AddToLog($"Link {feedCount}", this);

      ContentExtractor extractor = new ContentExtractor(html, true);


      string text = extractor.Extract("{flat}.p<>[0](Text)");

      text = text.DtbClean();
      string post_Text = text.Replace("§", " ").Replace("|", " ");

      string post_URL = url;
      string post_Date = extractor.Extract("{flat}.abbr<>[1](Text)");
      post_Date = DateFromAbbr(post_Date).ToString();
      string post_Author = extractor.Extract("{flat}.strong<>[1](Text)").Extract('\r', '\n').DtbClean();

      string shareLink = html.Substring("browse/shares?id");


      string post_ReactionCount = "";
      string post_ReactionLink = "";

      string reactionsTag = html.MatchSingle(@"\d+ deixaram rea&#xe7;&#xf5;es,");
      if (string.IsNullOrEmpty(reactionsTag))
        reactionsTag = html.MatchSingle(@"\d+ deixaram reações,");

      if (!string.IsNullOrEmpty(reactionsTag))
      {
        post_ReactionCount = Convert.ToInt32(reactionsTag.MatchSingle(@"\d+")).ToString();
        string tempHtm = GetReactionsLink(html, reactionsTag);
        post_ReactionLink = tempHtm;
      }


      //

      string line = $"{post_URL}|{post_Text}|{post_Date}|{post_ReactionCount}|{post_ReactionLink}|{post_Author}";

      using (StreamWriter sw = new StreamWriter(FeedFileName, true, System.Text.Encoding.UTF8))
      {
        sw.WriteLine(line);
      }

      Sleep();

      //Comments
      HtmlDocument doc = new HtmlDocument();
      doc.LoadHtml(html);
      List<HtmlNode> nodes = doc.FlattenDocument();

      HtmlNode header = nodes.FirstOrDefault(x => x.Name.ToLower() == "header");
      string post_AuthorUrl = "";
      if (header != null)
      {
        List<HtmlNode> headerNodes = HtmlDocument.FlattenNode(header);
        HtmlNode headerH3 = headerNodes.FirstOrDefault(x => x.Name.ToLower() == "h3");
        if (headerH3 != null)
          post_AuthorUrl = $"https://m.facebook.com" + HtmlDocument.FlattenNode(headerH3).FirstOrDefault(x => x.Name == "a").Attributes["href"].Value;
        else
          post_AuthorUrl = "N/A";
      }
      else
      {
        HtmlNode actorNode = nodes.FirstOrDefault(x => x.Attributes.Contains("class") && (x.Attributes["class"].Value == "actor-link"));
        if (actorNode != null)
          post_AuthorUrl = $"https://m.facebook.com" + actorNode.Attributes["href"].Value;
        else
          post_AuthorUrl = "N/A";
      }

      nodes = nodes.Where(x => x.Name.ToLower() == "h3").ToList();

      nodes = nodes.Where(x => (x.ParentNode != null) && (x.ParentNode.Name == "div")).ToList();
      nodes = nodes.Where(x => (x.ParentNode.ParentNode != null) && (x.ParentNode.ParentNode.Name == "div")).ToList();

      nodes = nodes.Select(x => x.ParentNode.ParentNode).ToList();

      foreach (HtmlNode node in nodes)
      {
        if (node.Attributes.Contains("id"))
        {


          string id = node.Attributes["id"].Value;

          List<HtmlNode> children = HtmlDocument.FlattenNode(node);

          HtmlNode abbr = children.FirstOrDefault(x => x.Name.ToLower() == "abbr");
          string comment_Date = BaseFBOperation.DateFromAbbr(abbr.InnerText).ToString();
          string comment_DateStr = abbr.InnerText.Extract("\r\n");

          HtmlNode h3 = children.First(x => x.Name.ToLower() == "h3");

          HtmlNode contentDiv = h3.NextSibling.NextSibling;
          string comment_Text = contentDiv.InnerText.DtbClean().Replace("|", ",");

          children = HtmlDocument.FlattenNode(h3);

          HtmlNode a = children.First(x => x.Name.ToLower() == "a");
          string comment_Author_URL = $"https://m.facebook.com{WebUtility.HtmlDecode(a.Attributes["href"].Value)}";

          string author = a.InnerText.DtbClean().Replace("§", " ");

          string comment_Author = author;

          string localHtml = node.InnerHtml;

          string reactions = localHtml.DtbClean().Replace("§", " ").MatchSingle(@"\d+ reaç(ão|ões), incluindo");

          string comment_ReactionCount = reactions.MatchSingle(@"\d+");
          string comment_ReactionLink = "";

          if (!String.IsNullOrWhiteSpace(comment_ReactionCount))
          {
            string tempHtm = BaseFBOperation.GetReactionsLink(html, reactions);
            comment_ReactionLink = tempHtm;
          }
          else
          {
            comment_ReactionCount = "0";
          }

          line = $"{post_URL}|{post_Author}|{post_AuthorUrl}|{comment_Text}|{id}|{comment_Author}|{comment_Author_URL}|{comment_Date}|{comment_ReactionCount}|{comment_ReactionLink}|{comment_DateStr}";

          using (StreamWriter sw = new StreamWriter(CommentsFileName, true, System.Text.Encoding.UTF8))
          {
            sw.WriteLine(line);
          }
        }
      }

      DeStackLink();
    }
  }
}
