using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Iris.Runtime.Core;
using System.ComponentModel;
using Iris.Runtime.Model.Entities.Txt;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using Databridge.Engine.Parsers;
using Databridge.Engine;
using Databridge.Engine.Extensions;

namespace Iris.Runtime.Model
{
  [Serializable]
  public class TextLine : TextObject, Iris.Runtime.Model.Entities.Txt.ITextLine
  {
    public TextLine(TextSchema _file)
    {
      schema = _file;
      schema.LineTypes.Add(this);
      lineType = LineType.Delimitado;
      delimiter = ';';
      ValidationXpression = "1==1";
      table = null;
    }

    private TextSchema schema;
    [Browsable(false)]
    public TextSchema Schema
    {
      get { return schema; }
      set { schema = value; }
    }

    private LineType lineType;
    [Category("Validação"), DisplayName("Tipo"), Description("Tipo da linha: Fixo/Delimitado")]
    public LineType LineType
    {
      get { return lineType; }
      set { lineType = value; }
    }
    private int ignoreFirst;
    [Category("Validação"), DisplayName("Ignorar Primeiras"), Description("Quantidades de linhas a ser ignorada no início do arquivo")]
    public int IgnoreFirst
    {
      get { return ignoreFirst; }
      set { ignoreFirst = value; }
    }

    private string tableName;
    [Category("Linha"), DisplayName("Nome da Tabela"), Description("Nome que será dado à tabela correspondente a este tipo de linha")]
    public string TableName
    {
      get
      {
        if ((String.IsNullOrEmpty(tableName) || (tableName == schema.Name)) && (!string.IsNullOrEmpty(Name)))
          tableName = this.Schema.TablePrefix + Name;

        return tableName;
      }
      set { tableName = value; }
    }

    private char delimiter;
    [Category("Validação"), DisplayName("Delimitador"), Description("Caractere de delimitação entre os campos da linha")]
    public char Delimiter
    {
      get { return delimiter; }
      set { delimiter = value; }
    }

    [Category("Validação"), DisplayName("Qualificador de texto"), Description("Caractere de delimitação de texto. Este caractere será removido dos valores antes da conversão")]
    public string TextQualifier { get; set; }

    private List<TextField> fields;
    [Browsable(false)]
    public List<TextField> Fields
    {
      get
      {
        if (fields == null)
          fields = new List<TextField>();
        return fields;
      }
      set { fields = value; }
    }

    internal DataTable CreateTable()
    {
      string tName;
      DataSet dataSet;
      ClearLineTable(out tName, out dataSet);

      table = new DataTable(tName);
      List<DataColumn> pk = new List<DataColumn>();
      foreach (TextField field in Fields)
      {
        DataColumn column = field.CreateColumn();
        table.Columns.Add(column);


        if (field.PrimaryKey && Schema.GenerateKey)
          pk.Add(column);
      }

      if ((pk.Count > 0) && Schema.GenerateKey)
        table.PrimaryKey = pk.ToArray();

      dataSet.Tables.Add(table);
      return table;
    }

    internal void ClearLineTable(out string tName, out DataSet dataSet)
    {
      tName = TableName;
      Schema.ClearSchemaTable(table, out dataSet);
    }

    [NonSerialized]
    private DataTable table;
    [Browsable(false)]
    public DataTable Table
    {
      get
      {
        if (table == null)
          CreateTable();
        return table;
      }
      set { table = value; }
    }

    public DataRow LineToRow(string line, int lineNumber)
    {
      if( (lineNumber > IgnoreFirst)||(IgnoreFirst ==0))
      {
        if (!string.IsNullOrWhiteSpace(TextQualifier))
          line = line.Replace(TextQualifier, "");

        if (Validate(line, lineNumber))
        {
          DataRow row = Table.NewRow();
          if (LineType == LineType.Fixo)
          {
            for (int i = 0; i < Fields.Count; i++)
            {
              TextField field = Fields[i];
              string value = line.Substring(field.PosInicio-1, field.Size);
              try
              {
                row[field.Name] = field.ConvertToType(value);
              }
              catch (Exception ex)
              {
                LogReadError(lineNumber, field, value, ex, line);
              }
            }
          }
          else
          {
            string[] values = line.Split(Delimiter);
            for (int i = 0; i < Fields.Count; i++)
            {
              TextField field = Fields[i];
              try
              {
                if (i < values.Length)
                {
                  string value = values[i].Replace("¬¬", Delimiter.ToString());
                  row[field.Name] = field.ConvertToType(value);
                }
                else
                  row[field.Name] = field.ConvertToType("");
              }
              catch (Exception ex)
              {
                LogReadError(lineNumber, field, values[i], ex, line);
              }
            }
          }
          return row;
        }
      }
      return null;
    }

    private void LogReadError(int lineNumber, TextField field, string value, Exception ex, string line)
    {
      schema.Structure.AddToErrorLog(string.Format("Erro de leitura: Linha <{0}> -Col <{1}> -> Valor: \"{2}\".", lineNumber, field.Name, value), schema);
      schema.Structure.AddToErrorLog(line, schema);

      throw new Exception("Mensagem original: " + ex.Message);
    }

    public string RowToLine(DataRow row)
    {
      string line = "";
      for (int i = 0; i < Fields.Count; i++)
      {
        TextField field = Fields[i];
        if (!field.ReadOnly)
          line += field.ConvertToString(row[field.Name]);

        if ((LineType == LineType.Delimitado) && (!field.ReadOnly))
          line += Convert.ToString(Delimiter);
      }
      return line;
    }

    internal XEvalParser parser
    {
      get { return XEvalParser.GetParser(); }
    }

    internal bool Validate(string value, int lineNumber)
    {
      if (!string.IsNullOrEmpty(ValidationXpression))
      {
        Dictionary<string, object> args = new Dictionary<string, object>();
        args["line"] = value;
        args["lineNumber"] = lineNumber;
        ExecutionContext context = GetContext(args);

        bool validLine = Convert.ToBoolean(parser.Parse(ValidationXpression, context));
        return validLine;
      }
      else
        throw new Exception("A linha [" + Name + "] não possui expressão de validação");
    }

    [NonSerialized]
    private ExecutionContext context;
    internal ExecutionContext GetContext(Dictionary<string, object> args)
    {
      if (context == null)
        context = this.Schema.Structure.GetContext();

      context.Parameters = args;
      return context;
    }

    [Browsable(true), Category("Validação"), DisplayName("Expressão de Validação"), Description("Utilize as variáveis &&line para acessar a linha e &&lineNumber para acessar o seu número")]
    public override string ValidationXpression
    {
      get
      {
        return base.ValidationXpression;
      }
      set
      {
        base.ValidationXpression = value;
      }
    }


    private bool includeHeader;

    [Category("Linha"), DisplayName("Inlcuir Cabeçalho")]
    public bool IncludeHeader
    {
      get { return includeHeader; }
      set 
      { 
        if(value)
        {
          if(IgnoreFirst == 0)
          {
            ignoreFirst = 1;
          }
        }
        includeHeader = value; 
      }
    }


    [Category("Linha"), DisplayName("Case do Cabeçalho")]
    public CaseChange HeaderCase { get; set; }


    public string GetHeader()
    {
      StringBuilder headerBuilder = new StringBuilder();
      for (int k = 0; k < Fields.Count; k++)
      {
        TextField tf = Fields[k];
        headerBuilder.Append(tf.Name);
        string delim = "";
        if (LineType == LineType.Delimitado)
          delim = Convert.ToString(Delimiter);
        else
          delim = delim.PadLeft(tf.Size - tf.Name.Length, ' ');

        headerBuilder.Append(delim);

      }

      string header = headerBuilder.ToString();
      if (LineType == LineType.Delimitado)
        header = header.TrimEnd(Delimiter);

      switch (HeaderCase)
      {
        case CaseChange.ToUpper:
          header = header.ToUpper();
          break;
        case CaseChange.ToLower:
          header = header.ToLower();
          break;
      }

      return header;
    }


    private Dictionary<string, string> link;
    [Category("Linha"), DisplayName("Relacionamento"), Description("Campos de relacionamento entre esta linha e sua linha mestre")]
    [Editor(typeof(TxtRelationEditor), typeof(UITypeEditor))]
    public Dictionary<string, string> Link
    {
      get
      {
        if (link == null)
          link = new Dictionary<string, string>();
        return link;
      }
      set
      {
        link = value;
        foreach (TextField field in Fields)
        {
          field.ParentRef = Link.ContainsKey(field.Name);
        }
      }
    }

    private TextLine master;
    [Browsable(false)]
    public TextLine Master
    {
      get { return master; }
      set
      {
        if (master != value)
        {
          if (master != null)
            master.Details.Remove(this);
          else
            Schema.LineTypes.Remove(this);

          if (value != null)
            value.Details.Add(this);
          else
            Schema.LineTypes.Add(this);

          master = value;
        }
      }
    }

    private List<TextLine> details;
    [Browsable(false)]
    public List<TextLine> Details
    {
      get
      {
        if (details == null)
          details = new List<TextLine>();
        return details;
      }
      set { details = value; }
    }

    public DataRow[] GetDetails(TextLine line, DataRow row)
    {
      string filter = "";
      foreach (KeyValuePair<string, string> kvp in line.Link)
      {
        filter += kvp.Value + "=";
        object objValue = row[kvp.Key];
        string value = Convert.ToString(objValue);
        if (objValue is String)
          value = "'" + value + "'";
        else if (objValue is DateTime)
          value = "#" + value + "#";
        filter += value;
      }

      if (string.IsNullOrEmpty(filter))
        throw new Exception("Não foi atribuído um link entre os tipos de linha " + Name + " e " + line.Name);
      else
        return line.Table.Select(filter);
    }

    public override string ToString()
    {
      if (!string.IsNullOrEmpty(Name))
        return Name;
      else
      {
        int i = Schema.LineTypes.IndexOf(this);
        return Schema.Name + "[" + i.ToString() + "]";
      }
    }

    public List<string> GetFieldList()
    {
      List<string> fieldList = new List<string>();
      for (int i = 0; i < Fields.Count; i++)
      {
        fieldList.Add(Fields[i].Name);
      }
      return fieldList;
    }

    ITextLine ITextLine.Master
    {
      get
      {
        return Master;
      }
      set
      {
        Master = (TextLine)value;
      }
    }

  }
}
