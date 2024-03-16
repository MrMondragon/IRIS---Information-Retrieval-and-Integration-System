using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Iris.Runtime.Core;
using System.ComponentModel;
using Iris.Runtime.Model.Entities.Txt;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;

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
      dataSet = Schema.Structure.Dataset;
      if (table != null)
        table.Clear();

      if (dataSet.Tables.Contains(tName))
      {
        DataTable oldTable = dataSet.Tables[tName];
        oldTable.Clear();

        foreach (DataColumn col in oldTable.Columns)
        {
          if (!string.IsNullOrEmpty(col.Expression))
            col.Expression = "";
        }

        oldTable.ParentRelations.Clear();
        oldTable.ChildRelations.Clear();

        dataSet.Tables.Remove(tName);
        oldTable.Dispose();
      }
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
      if (lineNumber > IgnoreFirst)
      {
        if (Validate(line, lineNumber))
        {
          DataRow row = Table.NewRow();
          if (LineType == LineType.Fixo)
          {
            for (int i = 0; i < Fields.Count; i++)
            {
              TextField field = Fields[i];
              string value = line.Substring(field.PosInicio, field.Size);
              try
              {
                row[field.Name] = field.ConvertToType(value);
              }
              catch (Exception ex)
              {
                LogReadError(lineNumber, field, value, ex);
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
                LogReadError(lineNumber, field, values[i], ex);
              }
            }
          }
          return row;
        }
      }
      return null;
    }

    private void LogReadError(int lineNumber, TextField field, string value, Exception ex)
    {
      schema.Structure.AddToErrorLog(string.Format("Erro de leitura: Linha <{0}> -Col <{1}> -> Valor: \"{2}\".", lineNumber, field.Name, value), schema);
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

    private XEvalParser parser
    {
      get { return Schema.Structure.XevalPrarser; }
    }

    internal bool Validate(string value, int lineNumber)
    {
      if (!string.IsNullOrEmpty(ValidationXpression))
      {
        Dictionary<string, object> args = new Dictionary<string, object>();
        args["line"] = value;
        args["lineNumber"] = lineNumber;
        bool validLine = Convert.ToBoolean(parser.Parse(ValidationXpression, args));
        return validLine;
      }
      else
        throw new Exception("A linha [" + Name + "] não possui expressão de validação");
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
