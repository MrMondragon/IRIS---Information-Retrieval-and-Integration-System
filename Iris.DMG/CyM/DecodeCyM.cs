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

namespace Iris.DMG.CyM
{
  [Serializable]
  [OperationCategory("CyberMonitor", "Decodificador IBGE")]
  public class DecodeCyM : Operation
  {
    public DecodeCyM(Structure aStructure, string aName) : base(aStructure, aName)
    {
      Separador = "\t";
      SetInputs("Entrada");
    }

    public string Separador { get; set; }


    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("Arquivo de Domínio")]
    public string DomainFile { get; set; }
    protected override IEntity doExecute()
    {
      ResultSet resultset = (ResultSet)GetInput("Entrada").EntityValue;
      DataTable table = resultset.Table;

      List<string> domainLines = File.ReadAllLines(DomainFile).ToList();
      domainLines = domainLines.Select(x => x.Extract('"')).ToList();

      List<string> keys = domainLines.Select(x => x.Remove(Separador).Trim()).Distinct().ToList();

      Dictionary<string, Dictionary<string, string>> domain = new Dictionary<string, Dictionary<string, string>>();

      foreach (string key in keys)
      {
        List<string> keyLines = domainLines.Where(x => x.StartsWith(key)).ToList();
        keyLines = keyLines.Select(x => x.Substring(Separador).TrimStart(Separador.ToCharArray())).ToList();

        List<string[]> keyLineParts = keyLines.Select(x => x.Split(Separador.ToCharArray())).ToList();

        domain[key] = keyLineParts.ToDictionary(x => x[0].Trim(), y => y[1].Trim());
      }

      List<string> columNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).Where(x => !x.EndsWith("x")).ToList();

      foreach (string col in columNames)
      {
        if (!table.Columns.Contains(col + "x"))
          table.Columns.Add(col + "x");
      }

      foreach (DataRow row in table.Rows)
      {
        row.BeginEdit();

        foreach (string vCol in columNames)
        {
          if (domain.ContainsKey(vCol))
          {
            string xCol = vCol + "x";
            string value = Convert.ToString(row[vCol]).Trim();

            if (domain[vCol].ContainsKey(value))
            {
              row[xCol] = domain[vCol][value];
            }
          }
        }


        row.EndEdit();
      }


      return null;

    }
  }
}
