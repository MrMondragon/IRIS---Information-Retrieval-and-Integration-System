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
  [OperationCategory("Facebook", "Gravador de Arquivos")]
  public class FBFeedHtmlSaver : Operation
  {
    public FBFeedHtmlSaver(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Entrada");
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
      ResultSet resultset = (ResultSet)GetInput("Entrada").EntityValue;
      DataTable table = resultset.Table;

      foreach (DataRow row in table.Rows)
      {
        string url = Convert.ToString(row["Post_URL"]);
        string[] numbers = url.MatchAll(@"\d+").ToArray();

        string fileName;
        if(numbers.Length == 2)
          fileName = $"{numbers[0]}-{numbers[1]}.html";
        else
        {
          fileName = url.Substring(".com/");
          fileName = fileName.Substring("/", true);
          fileName = fileName.Remove("/");
          fileName = $"{fileName}-{numbers[0]}.html";

        }
        fileName = Path.Combine(WorkPath, fileName);

        string html = WebUtility.HtmlDecode(Convert.ToString(row["Post_HTML"]));

        File.WriteAllText(fileName, html);
      }

      return null;
    }
  }
}
