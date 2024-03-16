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
  [OperationCategory("Transformações", "Text Stripper")]
  public class TextStripper  : ColumnBasedOperation
  {
    public TextStripper(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      Recursividade = 1;
      IsolatingSpaces = true;
    }


    [DisplayName("Termos"), Category("Expressão")]
    public string Termos { get;  set; }

    public int Recursividade { get; set; }

    public Position TextPosition { get; set; }

    public bool IsolatingSpaces { get; set; }

    protected override IEntity doExecute()
    {
      DataTable table = Entrada.Table;

      if (!table.Columns.Contains(ColumnName))
        table.Columns.Add(ColumnName);

      string[] termos = Termos.Split('|');

      foreach (DataRow row in table.Rows)
      {
        String str = Convert.ToString(row[Column]);
        for (int i = 0; i < Recursividade; i++)
        {
          str = StripText(termos, str);
        }

        row[ColumnName] = str;
      }


      return null;
    }

    private string StripText(string[] termos, String str)
    {
      foreach (String item in termos)
      {
        string localItem = item;

        switch (TextPosition)
        {
          case Position.Start:
            {
              if(IsolatingSpaces)
                localItem = localItem + " ";
              if (str.StartsWith(localItem))
              {
                str = str.Substring(localItem.Length);
                break;
              }
            }
            break;
          case Position.Middle:
            {
              if (IsolatingSpaces)
                localItem = " " + localItem + " ";
              if (str.Contains(localItem))
              {
                str = str.Replace(localItem, "");
                break;
              }
            }
            break;
          case Position.End:
            {
              if (IsolatingSpaces)
                localItem = " " + localItem;
              if (str.EndsWith(localItem))
              {
                str = str.Remove(str.IndexOf(localItem));
                break;
              }
            }
            break;
        }        
      }
      return str;
    }
  }


  public enum Position
  {
    Start,
    Middle,
    End,
  }

}
