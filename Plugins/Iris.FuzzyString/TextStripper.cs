using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FuzzyString;
using Iris.Interfaces;
using Iris.PropertyEditors.PropertyEditors;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Runtime.Model.PropertyEditors;

namespace Iris.FuzzyString
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Text Stripper")]
  public class TextStripper  : ColumnBasedOperation
  {
    public TextStripper(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }


    [DisplayName("Termos"), Category("Expressão")]
    public string Termos { get;  set; }

    protected override IEntity doExecute()
    {
      DataTable table = Entrada.Table;

      if (!table.Columns.Contains(ColumnName))
        table.Columns.Add(ColumnName);

      string[] termos = Termos.Split('|');

      foreach (DataRow row in table.Rows)
      {
        String str = Convert.ToString(row[Column]);

        foreach (String item in termos)
        {
          string localItem = item + " ";
          if (str.StartsWith(localItem))
          {
            str = str.Substring(localItem.Length);
            break;
          }
        }

        row[ColumnName] = str;
      }


      return null;
    }
  }
}
