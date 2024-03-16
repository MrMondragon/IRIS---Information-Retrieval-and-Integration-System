using System;
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
using Databridge.Engine.Extensions;
using Iris.Runtime.Model.Entities.Schemas;

namespace Iris.Runtime.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Load From Simple File")]
  public class ReadGenericTextFile : Operation
  {
    public ReadGenericTextFile(Structure aStructure, string aName) : base(aStructure, aName)
    {
      Separador = ";";
      SetOutputs("Saída");
      SetInputs("Filename");
      FirstLineContainsHeaders = true;
    }

    public string Separador { get; set; }
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    public string FileName { get; set; }
    public string Quote { get; set; }


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

    public bool FirstLineContainsHeaders { get; set; }
    public bool Append { get; set; }

    protected override IEntity doExecute()
    {
      ResultSet resultset = (ResultSet)GetOutput("Saída").EntityValue;

      if ((!Append)|| (resultset.Table == null))
      {
        resultset.Clear();
        resultset.Table = new DataTable(resultset.Name);
      }

      DataTable table = resultset.Table;

      int ct = 0;

      if (GetInput("Filename") != null)
      {
        FileName = Convert.ToString(GetInput("Filename").Value);
      }

      using (StreamReader sr = new StreamReader(FileName, Encoding))
      {
        string line = "";
        while ((line = sr.ReadLine()) != null)
        {

          string[] lineParts = SplitLine(line);
          if ((ct == 0) && ((!Append) || (table.Columns.Count == 0)))
          {
            if (FirstLineContainsHeaders)
            {
              for (int i = 0; i < lineParts.Length; i++)
              {
                string columnName = lineParts[i];
                if (!string.IsNullOrWhiteSpace(columnName))
                {
                  while (table.Columns.Contains(columnName))
                  {
                    columnName = columnName + "1";
                  }

                  table.Columns.Add(columnName);
                }
              }
              table.BeginLoadData();
            }
            else
            {
              for (int i = 0; i < lineParts.Length; i++)
              {
                table.Columns.Add($"Col{i}");
              }
              LoadRow(table, lineParts, ct, line);
            }
            ct++;
          }
          else
          {
            LoadRow(table, lineParts, ct, line);
            ct++;
          }
        }
        table.EndLoadData();
      }

      Structure.AddToLog($"{table.Rows.Count} registros carregados", this);
      return null;
    }

    private string[] SplitLine(string line)
    {
      if (string.IsNullOrWhiteSpace(Quote))
      {
        char[] separators = Separador.ToCharArray();
        return line.Split(separators);
      }
      else
      {
        line = line.Trim(Quote.ToCharArray());
        List<string> list = new List<string>();
        string separator = $"{Quote}{Separador}{Quote}";
        while (line.Contains(separator))
        {
          string value = line.Remove(separator);
          line = line.Substring(separator, true);
          list.Add(value);
        }
        list.Add(line.Trim(separator.ToCharArray()));
        return list.ToArray();
      }
    }

    private void LoadRow(DataTable table, string[] lineParts, int lineIndex, string line)
    {
      try
      {
        DataRow row = table.NewRow();
        for (int i = 0; i < table.Columns.Count; i++)
        {
          row[i] = lineParts[i];
        }
        table.LoadDataRow(row.ItemArray, true);
      }
      catch (Exception ex)
      {
        Structure.AddToErrorLog($"Erro na carga da linha {lineIndex}. Mensagem original: {ex.Message}", this);
        Structure.AddToErrorLog($"[{line}]", this);
        if (!IgnoreFailure)
        {
          throw;
        }

      }
    }
  }
}
