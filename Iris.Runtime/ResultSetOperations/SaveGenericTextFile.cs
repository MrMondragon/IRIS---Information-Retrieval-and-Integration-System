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
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Iris.Runtime.Model.Entities.Schemas;

namespace Iris.Runtime.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Save to Simple File")]
  public class SaveGenericTextFile : Operation
  {
    public SaveGenericTextFile(Structure aStructure, string aName) : base(aStructure, aName)
    {
      Separador = ";";
      SetInputs("Entrada");
    }

    public bool Split { get; set; }

    public int SplitRecCount { get; set; }

    public string Separador { get; set; }
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    public string FileName { get; set; }

    public override void AssignObject(object value)
    {
      FileName = Convert.ToString(value);
    }

    private TextEncoding? textEncoding;

    public TextEncoding TextEncoding
    {
      get
      {
        if (textEncoding == null)
          return TextEncoding.Default;
        else
          return textEncoding.Value;
      }
      set { textEncoding = value; }
    }

    [Browsable(false)]
    public Encoding Encoding
    {
      get
      {
        switch (TextEncoding)
        {
          case TextEncoding.Default:
            return Encoding.Default;
          case TextEncoding.ASCII:
            return Encoding.ASCII;
          case TextEncoding.BigEndianUnicode:
            return Encoding.BigEndianUnicode;
          case TextEncoding.Unicode:
            return Encoding.Unicode;
          case TextEncoding.UTF32:
            return Encoding.UTF32;
          case TextEncoding.UTF7:
            return Encoding.UTF7;
          case TextEncoding.UTF8:
            return Encoding.UTF8;
          default:
            return Encoding.Default;
        }
      }
    }

    protected override IEntity doExecute()
    {
      ResultSet resultset = (ResultSet)GetInput("Entrada").EntityValue;
      
      List<DataRow> rowSet = resultset.View.Cast<DataRowView>().Select(x => x.Row).ToList();

      if (!Split)
      {
        SaveFile(rowSet, -1);
      }
      else
      {
        int idx = 1;
        while(rowSet.Count > 0)
        {
          int count = SplitRecCount;

          List<DataRow> subset = new List<DataRow>();
          if (count > rowSet.Count)
            count = rowSet.Count;

          subset.AddRange(rowSet.Take(count));
          rowSet.RemoveRange(0, count);
          SaveFile(subset, idx);
          idx++;
        }

      }
      

      return null;
    }

    private void SaveFile(List<DataRow> rows, int idx)
    {
      string fName = FileName;
      if(idx != -1)
      {
        string dir = Path.GetDirectoryName(FileName);
        string name = Path.GetFileNameWithoutExtension(FileName);
        string ext = Path.GetExtension(FileName);

        fName = $@"{dir}\{name}-{idx}{ext}";
      }

      using (StreamWriter sw = new StreamWriter(fName, false, Encoding))
      {
        string[] colNames = rows.First().Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
        string header = string.Join(Separador, colNames);
        sw.WriteLine(header);

        for (int i = 0; i < rows.Count; i++)
        {
          string[] rowValues = rows[i].ItemArray.Select(x => Convert.IsDBNull(x) ? "" : Convert.ToString(x)).ToArray();

          for (int j = 0; j < rowValues.Length; j++)
          {
            if (rowValues[j].Contains(Separador))
            {
              rowValues[j] = rowValues[j].Replace(Separador, " ");
            }
          }

          string line = string.Join(Separador, rowValues);
          sw.WriteLine(line);
        }

      }
    }
  }
}
