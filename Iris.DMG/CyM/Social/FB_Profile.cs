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
  public class FB_Profile : BaseFBOperation
  {
    public FB_Profile(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Entrada", "CredentialList");
      SetOutputs("Saída", "Friends", "Details");
    }

    protected override void CreateColumns(DataTable table)
    {
      table.Columns.Add("Profile_URL");
      table.Columns.Add("Profile_Name");
      table.Columns.Add("Profile_FriendsURL");
      table.Columns.Add("Profile_DetailsURL");
      table.Columns.Add("Profile_FriendCount", typeof(int));

      if (GetOutput("Friends") != null)
      {
        ResultSet rs = (ResultSet)GetOutput("Friends").EntityValue;
        lock (rs)
        {
          if (rs.Table != null)
          {
            rs.Table.Clear();
            rs.Table = null;
          }

          DataTable friends = new DataTable(rs.Name);

          friends.Columns.Add("Profile_URL");
          friends.Columns.Add("Friend_URL");
          friends.Columns.Add("Friend_Name");
          rs.Table = friends;
        }
      }

      if (GetOutput("Details") != null)
      {
        ResultSet rs = (ResultSet)GetOutput("Details").EntityValue;
        lock (rs)
        {
          if (rs.Table != null)
          {
            rs.Table.Clear();
            rs.Table = null;
          }

          DataTable details = new DataTable(rs.Name);

          details.Columns.Add("Profile_URL");
          details.Columns.Add("Detail_Category");
          details.Columns.Add("Detail_Key");
          details.Columns.Add("Detail_Value");
          rs.Table = details;
        }
      }
    }



    protected override void ProcessPage(string html, string url)
    {
      ContentExtractor extractor = new ContentExtractor(html, true);

      string profileUrl = url.RemoveBefore("§");
      string localUrl = url.RemoveAfter("§");
      HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
      doc.LoadHtml(html);
      List<HtmlNode> nodes = doc.FlattenDocument();
      List<HtmlNode> links = nodes.Where(x => x.Name.ToLower() == "a").ToList();


      if (url.Contains("/about?"))
      {
        ResultSet rs = (ResultSet)GetOutput("Details").EntityValue;
        DataTable table = rs.Table;

        HtmlNode eduWorkNode = nodes.FirstOrDefault(x => x.Attributes.Contains("class") &&
          x.Attributes["class"].Value == "mTimelineAboutEduwork/root");
        if (eduWorkNode != null)
        {

          List<HtmlNode> expNodes = HtmlAgilityPack.HtmlDocument.FlattenNode(eduWorkNode).
            Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "ib cc experience").ToList();
          foreach (HtmlNode node in expNodes)
          {
            List<HtmlNode> innerNodes = HtmlAgilityPack.HtmlDocument.FlattenNode(node);
            List<string> spanTexts = innerNodes.Where(x => x.Name == "span").Select(x => x.InnerText).ToList();
            DataRow row = table.NewRow();
            row["Profile_URL"] = profileUrl;
            row["Detail_Category"] = "Experiência";
            row["Detail_Key"] = spanTexts[0];
            if (spanTexts.Count > 1)
              row["Detail_Value"] = spanTexts[1];

            table.LoadDataRow(row);
          }
        }

        HtmlNode livingNode = nodes.FirstOrDefault(x => x.Attributes.Contains("class") &&
          x.Attributes["class"].Value == "living");
        if (livingNode != null)
        {
          List<HtmlNode> livingNodes = livingNode.FirstChild.NextSibling.ChildNodes.ToList();

          foreach (HtmlNode node in livingNodes)
          {
            List<HtmlNode> innerNodes = HtmlAgilityPack.HtmlDocument.FlattenNode(node);
            List<string> spanTexts = innerNodes.Where(x => x.Name == "h4").Select(x => x.InnerText).ToList();

            DataRow row = table.NewRow();
            row["Profile_URL"] = profileUrl;
            row["Detail_Category"] = "Locais";
            row["Detail_Key"] = spanTexts[0];
            if (spanTexts.Count > 1)
              row["Detail_Value"] = spanTexts[1];

            table.LoadDataRow(row);
          }
        }

        HtmlNode infoNode = nodes.FirstOrDefault(x => x.Attributes.Contains("class") &&
          x.Attributes["class"].Value == "basic-info");
        if (infoNode != null)
        {
          List<HtmlNode> infoNodes = infoNode.FirstChild.NextSibling.ChildNodes.ToList();



          DataRow row = table.NewRow();
          row["Profile_URL"] = profileUrl;
          row["Detail_Category"] = "Locais";
          row["Detail_Key"] = "";
            row["Detail_Value"] = "";

          table.LoadDataRow(row);
        }



      }
      else if (url.Contains("/friends?"))
      {

      }
      else
      {
        if (GetOutput("Saída") != null)
        {
          ResultSet rs = (ResultSet)GetOutput("Saída").EntityValue;
          DataTable table = rs.Table;

          DataRow row = table.NewRow();
          row["Profile_URL"] = profileUrl;
          string name = extractor.Extract("{flat}.div<id='cover-name-root'>.h3<>[1](Text)");
          row["Profile_Name"] = name;

          string friends = html.MatchSingle(@"(\d+\.)?\d+ amigos");
          if (!string.IsNullOrEmpty(friends))
          {
            friends = friends.Extract(".").MatchSingle(@"\d+");
            row["Profile_FriendCount"] = friends;

            HtmlNode friendLinkNode = links.FirstOrDefault(x => x.Attributes["href"].Value.Contains("/friends?"));
            if (friendLinkNode != null)
            {
              string freindsUrl = friendLinkNode.Attributes["href"].Value;
              row["Profile_FriendsURL"] = freindsUrl;
              //  linkStack.Push($"{freindsUrl}§{profileUrl}");
            }
          }
          HtmlNode detailsLinkNode = links.FirstOrDefault(x => x.Attributes["href"].Value.Contains("/about?"));
          if (detailsLinkNode != null)
          {
            string detailsUrl = detailsLinkNode.Attributes["href"].Value;
            row["Profile_DetailsURL"] = detailsUrl;
            linkStack.Push($"{detailsUrl}§{profileUrl}");
          }

          table.LoadDataRow(row);
        }

      }


    }

  }
}

