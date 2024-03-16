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
using Databridge.Engine.Extensions;
using System.Globalization;
using System.Threading.Tasks;

namespace Iris.Runtime.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Load Simple Fixed File")]
  public class ReadGenericFixedFile : Operation
  {
    public ReadGenericFixedFile(Structure aStructure, string aName) : base(aStructure, aName)
    {
      Separador = "\t";
      Split = false;
      SetOutputs("Parcial", "Saída");
      SetInputs("Filename");
      counter = 0;
      max = 0;
      lockObject = new object();
    }

    public override void Reset()
    {
      counter = BatchSize * Skip;
      max = 0;
      lockObject = new object();
      base.Reset();
    }

    [NonSerialized]
    private int counter;
    private int max;

    [NonSerialized]
    private object lockObject;

    public bool MultiThread { get; set; }


    public string Separador { get; set; }
    private string fileName;
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    public string FileName
    {
      get
      {
        if (GetInput("Filename") != null)
        {
          ScalarVar fileVar = GetInput("Filename").EntityValue as ScalarVar;
          if (fileVar == null)
            throw new Exception("Entrada inválida");

          return Convert.ToString(fileVar.RawValue);
        }
        else
          return fileName;
      }
      set { fileName = value; }
    }


    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    public string SchemaName { get; set; }

    [Description("Quantidade de lotes a serem saltados")]
    public int Skip { get; set; }

    public bool Split { get; set; }
    public int BatchSize { get; set; }

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
    public bool ReuseSchema { get; set; }
    public bool FirstLineContainsHeaders { get; set; }
    protected override IEntity doExecute()
    {
      ResultSet resultset = (ResultSet)GetOutput("Saída").EntityValue;
      DataTable table;


      List<string> schemaLines = File.ReadAllLines(SchemaName).ToList();
      List<string[]> schemaLineParts = schemaLines.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Split(Separador.ToCharArray())).ToList();
      //FORMATO: NOME DA COLUNA\tTAMANHO INTEIRO\tTAMANHO DECIMAL\tTIPO (N ou Outros)
      //RETIRADO DO ARQUIVO DE LAYOUT DO IBGE, exceto as colunas de início e fim, que são redundantes!

      List<string> columnNames = schemaLineParts.Select(x => x[0].Trim()).ToList();

      List<int> columnSizes = schemaLineParts.Select(x => Convert.ToInt32(x[1].Trim()) +
        (string.IsNullOrWhiteSpace(x[2]) ? 0 : Convert.ToInt32(x[2]))).ToList();

      List<Type> columnTypes = schemaLineParts.Select(x => (x[3] == "N" ? typeof(double) : typeof(string))).ToList();
      lockObject = new object();

      if ((!ReuseSchema) || (resultset.Table == null))
      {
        resultset.Clear();
        table = new DataTable(resultset.Name);

        for (int i = 0; i < columnNames.Count; i++)
        {
          DataColumn col = table.Columns.Add(columnNames[i], columnTypes[i]);
          if (columnTypes[i] == typeof(string))
            col.MaxLength = columnSizes[i];
        }
        resultset.Table = table;

      }

      table = resultset.Table;

      IEnumerable<string> eLines = File.ReadLines(FileName, Encoding);

      if (max == 0)
        max = eLines.Count();

      if (FirstLineContainsHeaders)
        eLines = eLines.Skip(1);

      if (Split)
      {
        eLines = eLines.Skip(counter);
        if (BatchSize > 0)
        {
          eLines = eLines.Take(BatchSize);
          counter += BatchSize;
        }
      }

      List<string> lines = eLines.ToList();

      if (lines.Count > 0)
      {

        table.BeginLoadData();

        if (MultiThread)
        {
          Parallel.ForEach(lines, line =>
          {
            LoadRow(table, line, columnSizes, schemaLineParts);
          });
        }
        else
        {
          foreach (string line in lines)
          {
            LoadRow(table, line, columnSizes, schemaLineParts);
          }
        }

        table.EndLoadData();


        if (Split)
        {
          int batches = max / BatchSize;
          int ct = counter / BatchSize;

          Structure.AddToLog($"Lote {ct} de {batches}", this);

          IOperation nextOpper = GetOutput("Parcial");
          if (nextOpper != null)
            this.ExecuteObj(nextOpper);
        }
      }
      return null;
    }

    private void LoadRow(DataTable table, string line, List<int> columnSizes, List<string[]> schemaLineParts)
    {
      List<string> lineParts = new List<string>();
      for (int i = 0; i < columnSizes.Count; i++)
      {
        if (i > 0)
          line = line.Substring(columnSizes[i - 1]);

        string value = line.Substring(0, columnSizes[i]);

        if (!string.IsNullOrWhiteSpace(schemaLineParts[i][2]))
        {
          int cut = Convert.ToInt32(schemaLineParts[i][1]);

          string intPart = value.Remove(cut);
          string decPart = value.Substring(cut);

          if (string.IsNullOrWhiteSpace(intPart) && string.IsNullOrWhiteSpace(decPart))
            value = "0";
          else
            value = intPart + "." + decPart;
        }

        lineParts.Add(value);
      }

      DataRow row = table.NewRow();

      for (int i = 0; i < lineParts.Count; i++)
      {
        if ((table.Columns[i].DataType != typeof(string)) && (string.IsNullOrWhiteSpace(lineParts[i].Trim().Trim('.'))))
          row[i] = 0;
        else
        {
          if (table.Columns[i].DataType != typeof(string))
          {
            double value = Convert.ToDouble(lineParts[i], CultureInfo.InvariantCulture);
            row[i] = value;
          }
          else
            row[i] = lineParts[i];
        }
      }

      lock (lockObject)
      {
        table.LoadDataRow(row.ItemArray, false);
      }
    }
  }
}
