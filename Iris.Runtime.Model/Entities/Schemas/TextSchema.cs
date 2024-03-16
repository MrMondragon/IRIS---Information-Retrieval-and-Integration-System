using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.BaseObjects;
using System.IO;
using Iris.Runtime.Core;
using System.ComponentModel;
using Iris.Runtime.Model.DisignSuport;
using System.Drawing.Design;
using Databridge.Engine;
using Iris.Runtime.Model.Entities.Schemas;

namespace Iris.Runtime.Model
{
  [Serializable]
  public class TextSchema : SchemaEntity
  {
    //Deve limpar as tabelas (atribuir null) antes de ler o arquivo
    //O controle de autoinc e de referencia mestre/detalhe posicional será feito aqui.
    public TextSchema(string aName, Structure aStructure)
      : base(aName, aStructure)
    {
      autoInc = new Dictionary<string, int>();
      DefaultDateTimeMask = "dd/mm/yyyy hh:nn:ss.ggg";
    }

    [NonSerialized]
    private Dictionary<string, int> autoInc;

    private bool generateKey;
    [DisplayName("Gerar Chave"), Category("Schema"), Description("Indica se o schema deve utilizar as configurações de chave primária ao criar um resultset")]
    public bool GenerateKey
    {
      get { return generateKey; }
      set { generateKey = value; }
    }

    private List<TextLine> lineTypes;

    /// <summary>
    /// Gets or sets the line types.
    /// Lista apenas os tipos que não possuem linha mestre atribuída
    /// </summary>
    /// <value>The line types.</value>
    [DisplayName("Tipos de Linha"), Category("Schema"), Description("Os tipos de linha que compõem o arquivo")]
    [Editor(typeof(TxtStructureEditor), typeof(UITypeEditor))]
    public List<TextLine> LineTypes
    {
      get
      {
        if (lineTypes == null)
          lineTypes = new List<TextLine>();
        return lineTypes;
      }
      set { lineTypes = value; }
    }

    [Category("Schema"), Description("Valores que devem ser convertidos para Null, separados por |")]
    public string NullValues { get; set; }

    private string defaultDateTimeMask;
    [DisplayName("Máscara Default (Data/Hora)"), Category("Schema"), Description("Utilizar 'd' para dia, 'm' para mês, 'y' para ano, 'h' para hora, 'n' para minuto, 's' para segundo e 'g' para milissegundo")]
    public string DefaultDateTimeMask
    {
      get { return defaultDateTimeMask; }
      set
      {
        if (defaultDateTimeMask != value)
        {
          foreach (TextLine line in this.LineTypes)
          {
            foreach (TextField field in line.Fields)
            {
              if (field.Mask == defaultDateTimeMask)
                field.Mask = value;
            }
          }
          defaultDateTimeMask = value;
        }
      }
    }

    private string decimalSeparator;
    [Browsable(true), Category("Schema"), DisplayName("Separador Decimal")]
    public string DecimalSeparator
    {
      get { return decimalSeparator; }
      set { decimalSeparator = value; }
    }

    private string charsToRemove;
    [Browsable(true), Category("Schema"), DisplayName("Caracteres a serem removidos")]
    public string CharsToRemove
    {
      get { return charsToRemove; }
      set { charsToRemove = value; }
    }


    internal int GetAutoInc(string p)
    {
      if (autoInc == null)
        autoInc = new Dictionary<string, int>();

      if (!autoInc.ContainsKey(p))
        autoInc[p] = 0;
      autoInc[p]++;
      return autoInc[p];
    }

    public override void RefreshResultSets(ResultSet resultSet)
    {
      TextLine line = FindLine(resultSet, this.LineTypes);
      CreateResultSet(line, false);
    }

    private TextLine FindLine(ResultSet resultSet, List<TextLine> list)
    {
      TextLine result = null;
      foreach (TextLine line in list)
      {
        if (line.TableName == resultSet.Name)
          result = line;
        else
          result = FindLine(resultSet, line.Details);

        if (result != null)
          break;
      }
      return result;
    }

    public override void CreateResultSets()
    {
      foreach (TextLine line in LineTypes)
      {
        CreateResultSet(line, true);
      }
    }

    public override void RefreshResultSets()
    {
      foreach (TextLine line in LineTypes)
      {
        CreateResultSet(line, false);
      }
    }

    private void CreateResultSet(TextLine line, bool createNew)
    {
      if (line != null)
      {
        line.Table = line.CreateTable();
        DataTable table = line.Table;
        ResultSet rs = (ResultSet)Structure.GetObject(line.TableName, "resultSets");

        if ((rs == null) && createNew)
          rs = new ResultSet(line.TableName, Structure);

        if (rs != null)
        {
          rs.Table = table;
          rs.Schema = this;
          foreach (TextLine detail in line.Details)
          {
            CreateResultSet(detail, createNew);
          }
        }
      }
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


    public override void ReadToTables(IrisList<ResultSet> resultsets, int start, int end)
    {
      RebindLines(resultsets, true);
      passedTheEnd = false;

      String line;
      if (!string.IsNullOrEmpty(FileName))
      {
        StreamReader sr = new StreamReader(FileName, Encoding);
        try
        {
          int lineNumber = 0;
          while ((line = sr.ReadLine()) != null)
          {
            lineNumber++;
            if (((start == 0) || (lineNumber >= start)) && ((end == -1) || (lineNumber <= end)))
              ReadLine(line, lineNumber);

            if ((lineNumber > end) && end != -1)
              break;
          }

          passedTheEnd = (line == null);
        }
        finally
        {
          sr.DiscardBufferedData();
          sr.Close();
          sr.Dispose();
        }
      }
      else if (!string.IsNullOrEmpty(RawText))
      {
        string[] lines = RawText.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
          line = lines[i].Trim('\r');
          ReadLine(line, i + 1);
        }
      }
    }


    private void RebindLines(IrisList<ResultSet> resultsets, bool recreate)
    {
      foreach (TextLine line in LineTypes)
      {
        RebindLine(resultsets, line, recreate);
      }
    }

    public override void ClearTables()
    {
      foreach (TextLine line in lineTypes)
      {
        ClearLineTable(line);
      }
    }

    private void ClearLineTable(TextLine line)
    {
      string tName;
      DataSet dataSet;
      line.ClearLineTable(out tName, out dataSet);
      foreach (TextLine detail in line.Details)
      {
        ClearLineTable(detail);
      }
    }

    private void RebindLine(IrisList<ResultSet> resultsets, TextLine line, bool recreate)
    {
      string tableName = line.TableName;
      ResultSet rs = resultsets.FindByName(tableName);
      if (rs != null)
      {
        if (recreate)
        {
          line.CreateTable();
          rs.Table = line.Table;
        }
        else
        {
          line.Table = rs.Table;
        }
      }
      else
      {
        throw new Exception("Resultset não encontrado: " + tableName);
      }

      foreach (TextLine detail in line.Details)
      {
        RebindLine(resultsets, detail, recreate);
      }
    }

    private void ReadLine(string line, int lineNumber)
    {
      TextLine lType = GetLineTypeFromLine(line, lineNumber);
      if (lType != null)
      {
        DataTable table = lType.Table;
        DataRow row = lType.LineToRow(line, lineNumber);

        foreach (TextLine detail in lType.Details)
        {
          foreach (KeyValuePair<string, string> key in detail.Link)
          {
            SetKey(table.TableName, key.Value, row[key.Value]);
          }
        }

        if (row != null)
          table.Rows.Add(row);
      }
    }

    private TextLine GetLineTypeFromLine(string line, int lineNumber)
    {
      TextLine result = null;
      foreach (TextLine lType in LineTypes)
      {
        result = GetLineType(line, lineNumber, result, lType);
        foreach (TextLine detaiLine in lType.Details)
        {
          result = GetLineType(line, lineNumber, result, detaiLine);
        }
      }
      return result;
    }

    private TextLine GetLineType(string line, int lineNumber, TextLine result, TextLine lType)
    {
      if (lType.Validate(line, lineNumber))
      {
        if (result != null)
          throw new Exception("A linha nº" + lineNumber.ToString() + " pode pertencer a mais de um tipo: " + result.Name + " e " + lType.Name);
        result = lType;
      }
      return result;
    }


    [NonSerialized]
    private Dictionary<string, Dictionary<string, object>> tableKeys;

    internal object GetKey(string tableName, string fieldName)
    {
      Dictionary<string, object> result = tableKeys[tableName];
      if (result == null)
        return null;
      else
        return result[fieldName];
    }

    private void SetKey(string tableName, string fieldName, object value)
    {
      if (tableKeys == null)
        tableKeys = new Dictionary<string, Dictionary<string, object>>();
      if (!tableKeys.ContainsKey(tableName))
        tableKeys[tableName] = new Dictionary<string, object>();

      tableKeys[tableName][fieldName] = value;
    }

    public override void WriteFromTables(IrisList<ResultSet> resultsets)
    {
      RebindLines(resultsets, false);

      StreamWriter writer = null;
      List<string> text = null;
      if (!string.IsNullOrEmpty(FileName))
        writer = new StreamWriter(FileName, false, Encoding);
      else
        text = new List<string>();

      try
      {
        for (int i = 0; i < LineTypes.Count; i++)
        {
          TextLine line = LineTypes[i];
          
          if(line.IncludeHeader)
          {
            string header = line.GetHeader();

            writer.WriteLine(header);

          }
          for (int j = 0; j < line.Table.Rows.Count; j++)
          {
            DataRow row = line.Table.Rows[j];
            string textLine = line.RowToLine(row);
            
            if (line.LineType == LineType.Delimitado)
              textLine = textLine.TrimEnd(line.Delimiter);

            if (writer != null)
              writer.WriteLine(textLine);
            else
              text.Add(textLine);
            
            WriteDetails(line, row, writer, text);
          }
        }
      }
      finally
      {
        if (writer != null)
          writer.Close();
        else
        {
          int lineSize = 0;
          for (int i = 0; i < text.Count; i++)
          {
            int size = text[i].Length;
            if (size > lineSize)
              lineSize = size;
          }

          StringBuilder builder = new StringBuilder(lineSize * text.Count);
          for (int i = 0; i < text.Count; i++)
          {
            builder.Append(text[i]);
          }

          RawText = builder.ToString();
        }
      }
    }


    private void WriteDetails(TextLine line, DataRow row, StreamWriter writer, List<string> text)
    {
      for (int i = 0; i < line.Details.Count; i++)
      {
        TextLine detail = line.Details[i];
        DataRow[] detailRows = line.GetDetails(detail, row);
        for (int j = 0; j < detailRows.Length; j++)
        {
          DataRow detailRow = detailRows[j];
          string textLine = detail.RowToLine(detailRow);


          if (line.LineType == LineType.Delimitado)
            textLine = textLine.TrimEnd(line.Delimiter);

          if (writer != null)
            writer.WriteLine(textLine);
          else
            text.Add(textLine);

          WriteDetails(detail, detailRow, writer, text);
        }
      }
    }

    public void WriteRawText()
    {
      using (StreamWriter writer = new StreamWriter(FileName, false, Encoding.Default))
      {
        string[] lines = RawText.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
          string line = lines[i].Trim('\r');
          writer.WriteLine(line);
        }
      }
    }

    public void ExportSchema(string fileName)
    {
      TextSchema tmpFile = new TextSchema(Name, null);
      PersistenceManager<TextSchema>.SaveToFile(fileName, tmpFile);
    }

    public void ImportSchema(string fileName)
    {
      TextSchema tmpFile = PersistenceManager<TextSchema>.LoadFromFile(fileName, Structure.TypeLookupTable);
      this.DefaultDateTimeMask = tmpFile.DefaultDateTimeMask;
      this.LineTypes = tmpFile.LineTypes;
      foreach (TextLine line in LineTypes)
      {
        SetupLines(line);
      }
    }

    private void SetupLines(TextLine line)
    {
      line.Schema = this;
      foreach (TextLine detail in line.Details)
      {
        SetupLines(detail);
      }
    }

    public override List<string> GetTableNames()
    {
      List<string> result = new List<string>();
      foreach (TextLine line in LineTypes)
      {
        GetTableNames(result, line);
      }
      return result;
    }

    private void GetTableNames(List<string> result, TextLine line)
    {
      result.Add(line.TableName);
      foreach (TextLine detail in line.Details)
      {
        GetTableNames(result, detail);
      }
    }

    [DisplayName("Tabela Principal"), Category("Linhas"), Description("Nome da tabela principal do schema")]
    public string MainTableName
    {
      get
      {
        if (this.LineTypes.Count > 0)
          return this.LineTypes[0].TableName;
        else
          return "<Não Atribuído>";
      }
      set
      {
        if (this.LineTypes.Count > 0)
          this.LineTypes[0].TableName = value;
      }
    }
    [DisplayName("Linha Principal"), Category("Linhas"), Description("Nome do tipo de linha principal do schema")]
    public string MainLineName
    {
      get
      {
        if (this.LineTypes.Count > 0)
          return this.LineTypes[0].Name;
        else
          return "<Não Atribuído>";
      }
      set
      {
        if (this.LineTypes.Count > 0)
          this.LineTypes[0].Name = value;
      }
    }

    public override void Reset()
    {
      base.Reset();
      autoInc = new Dictionary<string, int>();
    }


  }
}
