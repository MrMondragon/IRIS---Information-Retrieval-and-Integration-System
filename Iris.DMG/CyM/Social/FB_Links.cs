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

namespace Iris.DMG.CyM.Social
{
  [Serializable]
  [OperationCategory("Facebook", "Extrator de Links")]
  public class FB_Links : BaseFBOperation
  {
    public FB_Links(Structure aStructure, string aName) : base(aStructure, aName)
    {
    }

    protected override void CreateColumns(DataTable table)
    {
      table.Columns.Add("PostURL");
    }

    protected override void ProcessPage(string html, string url)
    {
      if (GetOutput("Saída") != null)
      {
        ResultSet rs = (ResultSet)GetOutput("Saída").EntityValue;
        DataTable table = rs.Table;
        List<string> currentLinks = table.Rows.Cast<DataRow>().Select(x => Convert.ToString(x[0])).ToList();

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);

        List<HtmlNode> links = doc.FlattenDocument().Where(x => x.Name == "a").ToList();

        List<string> hrefs = links.Where(x => x.Attributes.Contains("href")).
          Select(x => WebUtility.HtmlDecode(x.Attributes.First(y => y.Name == "href").Value)).ToList();

        List<string> storyLinks = hrefs.Where(x => x.StartsWith("/story.php?")).Distinct().ToList();
        if (storyLinks.Count > 0)
        {
          string linkTexts = string.Join("§", storyLinks);

          storyLinks = linkTexts.MatchAll(@"/story.php\?story_fbid=\d+&id=\d+").Distinct().ToList();
          storyLinks = storyLinks.Select(x => @"https://m.facebook.com" + x).ToList();


          table.BeginLoadData();
          foreach (string link in storyLinks)
          {
            if (!currentLinks.Contains(link))
            {
              DataRow newRow = table.NewRow();
              newRow[0] = link;
              table.LoadDataRow(newRow);
            }
          }
          table.EndLoadData();
        }

        HtmlNode linkNextNode = links.LastOrDefault(x => x.InnerText.Extract('\r', '\n').ToLower().Trim() == "mostrar mais");
        if(linkNextNode == null)
        {
          linkNextNode = links.LastOrDefault(x => x.InnerText.Extract('\r', '\n').ToLower().Trim() == "ver mais stories");
        }

        if (linkNextNode != null)
        {
          string linkNext = linkNextNode.Attributes["href"].Value;
          string decLinkNext = WebUtility.HtmlDecode(linkNext);

          string pattern = decLinkNext.MatchSingle(@"unit_cursor=timeline_unit\:\d+\:\d+");
          string linkDateStr = "";
          if (!string.IsNullOrEmpty(pattern))
          {
            linkDateStr = pattern.MatchSingle(@"00\d+");

            if ($@"https://m.facebook.com{linkNext}" == url)
            {
              long linkDateInt = Convert.ToInt64(linkDateStr);
              linkDateInt -= 620585;
              string tmpDateStr = Convert.ToString(linkDateInt);
              tmpDateStr = tmpDateStr.PadLeft(linkDateStr.Length, '0');
              linkNext = linkNext.Replace(linkDateStr, tmpDateStr);
              linkDateStr = tmpDateStr;
            }
          }
          else 
          {
            pattern = decLinkNext.MatchSingle(@"timeend=\d+\&timestart=\d+");
            if(!string.IsNullOrEmpty(pattern))
            {
              string strTimeEnd = decLinkNext.MatchSingle(@"timeend=\d+").MatchSingle(@"\d+");
              string strTimeStart = decLinkNext.MatchSingle(@"timestart=\d+").MatchSingle(@"\d+");

              int timeEnd = Convert.ToInt32(strTimeEnd);
              int timeStart = Convert.ToInt32(strTimeStart);

              int newTimeStart = timeEnd;
              int newTimeEnd = timeEnd - 620585;
              linkDateStr = timeEnd.ToString();

              string newLink = decLinkNext.Replace(pattern, $"timeend={newTimeEnd}&timestart={newTimeStart}");
              linkNext = WebUtility.UrlEncode(newLink);
            }
          }

 

          DateTime linkDate = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt64(linkDateStr));
;

          if (linkDate > DataLimite)
          {
            linkNext = WebUtility.HtmlDecode(linkNext);
            linkStack.Push($@"https://m.facebook.com{linkNext}");
          }

        }

        DeStackLink();
      }

    }

  }
}
