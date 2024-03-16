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
  [OperationCategory("Facebook", "Processador de Páginas")]
  public class FBHtmlFeedProcessor : Operation
  {
    public FBHtmlFeedProcessor(Structure aStructure, string aName) : base(aStructure, aName)
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
      table.Columns.Add("Url");
      resultset.Table = table;

      string[] files = Directory.GetFiles(WorkPath, "*.html");
      List<string> links = new List<string>();
      foreach (string filename in files)
      {
        string html = WebUtility.HtmlDecode(File.ReadAllText(filename));
        links.AddRange(html.MatchAll(@"/story.php\?story_fbid=\w+(&id|&amp;id)=\d+").Distinct());
      }

      table.BeginLoadData();

      foreach (string link in links)
      {
        table.LoadDataRow(new object[] { "https://m.facebook.com" + link }, LoadOption.Upsert);
      }

      table.EndLoadData();

      Structure.AddToLog($"{table.Rows.Count} links carregados", this);

      return null;
    }
  }
}
