using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Databridge.Engine.Criptography;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.ComponentModel;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.SchemaOperations;
using Iris.Runtime.Model;


namespace Iris.DMG
{
  [OperationCategory("DMG", "SKR2IML")]
  [Serializable]
  public class SKR2IML : BaseSchemaOperation
  {
    public SKR2IML(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Schema", "Filename", "Text", "Example", "Entrada");

    }

    [DisplayName("Mapa de SKR"), Category("Schema"), Description("Formato: coluna>tabe;coluna>tabela")]
    public string SKR_Map { get; set; }
    public bool ClearFile { get; set; }

    protected override Interfaces.IEntity doExecute()
    {
      string[] pairs = SKR_Map.Split(';');
      Dictionary<string, Dictionary<string, string>> skr = new Dictionary<string, Dictionary<string, string>>();

      for (int i = 0; i < pairs.Length; i++)
      {
        string[] members = pairs[i].Split('>');
        ResultSet rs = Structure.ResultSets.FindByName(members[1]);
        if (rs != null)
        {
          skr[members[0]] = new Dictionary<string, string>();
          for (int j = 0; j < rs.Table.Rows.Count; j++)
          {
            string key = Convert.ToString(rs.Table.Rows[j]["NaturalKey"]);
            string value = Convert.ToString(rs.Table.Rows[j]["SurrogateKey"]);
            skr[members[0]][key] = value;
          }
        }
      }

      string outputFileName = FileName.Replace(".psv", ".iml");
      Encoding encoding = ((TextSchema)Schema).Encoding;
      TextLine line = ((TextSchema)Schema).LineTypes[0];

      if(!File.Exists(outputFileName))
      {
        string header = line.GetHeader();
        header = header.Replace(line.Delimiter.ToString(), ",");

        using (StreamWriter sw = new StreamWriter(outputFileName, false, encoding))
        {
          sw.WriteLine(header);
        }
      }

      using (StreamReader sr = new StreamReader(FileName, encoding))
      {
        using (StreamWriter sw = new StreamWriter(outputFileName, true, encoding))
        {
          string txtLine = "";
          int lineNumnber = 0;
          while ((txtLine = sr.ReadLine()) != null)
          {
            DataRow row = line.LineToRow(txtLine, lineNumnber);
            if ((row != null)&&((lineNumnber > line.IgnoreFirst) ||(line.IgnoreFirst == 0)))
            {
              foreach (DataColumn col in row.Table.Columns)
              {
                if (skr.ContainsKey(col.ColumnName))
                {
                  string key = Convert.ToString(row[col]);
                  if (skr[col.ColumnName].ContainsKey(key))
                    row[col] = skr[col.ColumnName][key];
                  else
                    row[col] = "NULL";
                }
              }

              string saveLine = line.RowToLine(row);
              saveLine = saveLine.Replace(line.Delimiter.ToString(), ",").TrimEnd().TrimEnd(',');
              sw.WriteLine(saveLine);
            }

         
            lineNumnber++;
          }
        }
      }
      return null;
    }

    protected override void doRefreshIO()
    {
    }
  }
}
