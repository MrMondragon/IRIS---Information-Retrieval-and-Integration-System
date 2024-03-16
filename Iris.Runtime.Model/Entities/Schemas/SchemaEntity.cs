using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.BaseObjects;
using System.Data;
using Iris.Interfaces;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using Iris.PropertyEditors;
using Databridge.Interfaces;

namespace Iris.Runtime.Model
{
  [Serializable]
  public abstract class SchemaEntity : Entity,  ISchemaEntity, IScriptedObject
  {

    public SchemaEntity(string aName, Structure aStructure)
      : base(aName, aStructure)
    {
      Structure.Schemas.Add(this);

      int prefixSize = 3;

      if (Name.Length < 3)
        prefixSize = Name.Length;

      TablePrefix = Name.Substring(0, prefixSize).ToLower();
    }

    private string rawText;

    [Browsable(false)]
    public object RawValue
    {
      get
      {
        return rawText;
      }
      set
      {
        rawText = Convert.ToString(value);
      }
    }

    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    [DisplayName("Texto"), Category("Arquivo"), Description("O texto em mem�ria do schema. N�o � utilizado quando se informa um nome de arquivo.")]
    public string RawText
    {
      get
      {
        return rawText;
      }
      set 
      {
        rawText = value; 
      }
    }
    
    private string fileName;
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("File Name"), Category("Arquivo"), Description("A localiza��o do arquivo em disco")]
    public virtual string FileName
    {
      get
      {
        return fileName;
      }
      set { fileName = value; }
    }


    private string tablePrefix;
    [DisplayName("Prefixo"), Category("Schema"), Description("O prefixo que ser� adicionado ao nome das tabelas associadas a este arquivo")]
    public string TablePrefix
    {
      get { return tablePrefix; }
      set 
      {
        tablePrefix = value; 
      }
    }

    [Browsable(false)]
    public override string DisplayText
    {
      get
      {
        return base.DisplayText;
      }
      set
      {
        base.DisplayText = value;
      }
    }

    protected override IEntity doExecute()
    {
      if (GetOutput(0) is ScalarVar)
      {
        ((ScalarVar)GetOutput(0)).RawValue = RawText;
        return (IEntity)GetOutput(0);
      }
      else
        return this;
    }

    internal void ClearSchemaTable( DataTable table, out DataSet dataSet)
    {
      dataSet = Structure.Dataset;

      if (table != null)
      {
        string tName = table.TableName;

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
    }

    [NonSerialized]
    protected bool passedTheEnd;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
    public bool PassedTheEnd
    {
      get { return passedTheEnd; }
    }

    public abstract void CreateResultSets();
    public abstract void RefreshResultSets();
    public abstract void RefreshResultSets(ResultSet resultSet);
    public abstract void WriteFromTables(IrisList<ResultSet> resultsets);
    public abstract void ReadToTables(IrisList<ResultSet> resultsets, int start, int end);
    public abstract List<string> GetTableNames();
    public abstract void ClearTables();

    #region IScriptedObject Members
    [Browsable(false)]
    public string Script
    {
      get
      {
        return RawText;
      }
      set
      {
        RawText = value;
      }
    }

    [Browsable(false)]
    public string Language
    {
      get { return "None"; }
    }

    IExecutionContext IScriptedObject.Context
    {
      get { return Structure.GetContext(); }
    }

    #endregion

    [Browsable(false)]
    public override OperationType OperationType
    {
      get
      {
        operationType = OperationType.Operation;
        return OperationType.Operation;
      }
    }

  }
}
