using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Iris.Runtime.Core.Connections;
using System.Data.Odbc;
using System.Data.Common;
using Iris.Runtime.Core.Expressions;
using Iris.Runtime.Core;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors;
using Iris.Interfaces;
using Iris.Runtime.Model.PropertyEditors;
using Iris.Runtime.Core.ParserEngine.ParserObjects;
using System.ComponentModel.Design;
using Databridge.Engine.Data;
using Databridge.Interfaces;

namespace Iris.Runtime.Model.Entities
{
  [Serializable]
  public class ResultSet : BaseResultSet, IResultSet, IScriptedObject, IEntity, IOperation
  {
    public ResultSet(string name, Structure structure, DynConnection connection, String sql)
      : this(name, structure)
    {
      Sql = sql;
      this.Connection = connection;
    }

    public ResultSet(string name, Structure structure)
    {
      this.Structure = structure;
      this.Name = name;
      Structure.ResultSets.Add(this);
    }


    [DisplayName("Select"), Category("SQL")]
    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    public override string Sql
    {
      get
      {
        return base.Sql;
      }
      set
      {
        base.Sql = value;
      }
    }


    [DisplayName("Nome"), Category("Design")]
    public override string Name
    {
      get { return name; }
      set
      {
        if (name != value)
        {
          base.OnBeforeNameChange();
          name = Structure.GetValidName(value);
          base.OnAfterNameChange();
        }
      }
    }



    [ReadOnly(true), Editor(typeof(TableEditor), typeof(UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override DataTable Table
    {
      get
      {
        if ((base.Table == null) && (this.Schema != null))
          this.Schema.RefreshResultSets(this);

        return base.Table;
      }
      set
      {
        if (base.Table != null)
        {
          while (base.Table.ParentRelations.Count > 0)
          {
            base.Table.ParentRelations.RemoveAt(0);
          }

          while (base.Table.ChildRelations.Count > 0)
          {
            base.Table.ChildRelations.RemoveAt(0);
          }

          base.Table.PrimaryKey = null;
          base.Table.Clear();
          base.Table.Columns.Clear();
          if (Structure.Dataset.Tables.Contains(base.Table.TableName))
            Structure.Dataset.Tables.Remove(base.Table.TableName);
        }

        base.Table = value;
        if((this.PrimaryKey != null) && (this.PrimaryKey.Count != 0))
        {
          List<DataColumn> pk = new List<DataColumn>();
          foreach (DataColumn column in this.PrimaryKey)
          {
            if((base.Table != null) && (column != null) &&(base.Table.Columns.Contains(column.ColumnName)))
            {
              pk.Add(base.Table.Columns[column.ColumnName]);
            }
          }

          this.PrimaryKey = pk;
          base.Table.PrimaryKey = pk.ToArray();
        }

        if (base.Table != null)
        {
          string tableName = base.Table.TableName;
          if (Structure.Dataset.Tables.Contains(tableName))
            Structure.Dataset.Tables.Remove(tableName);

          if (!Structure.Dataset.Tables.Contains(tableName))
            Structure.Dataset.Tables.Add(base.Table);

        }


      }
    }



    /// <summary>
    /// Gets the connection.
    /// </summary>
    /// <value>The connection.</value>
    [Editor(typeof(ConnectionSelectorEditor), typeof(UITypeEditor))]
    public new DynConnection Connection
    {
      get
      {
        return (DynConnection)base.Connection;
      }
      set
      {
        base.Connection = value;
      }
    }


    [DisplayName("SQL Insert"), Category("SQL")]
    [Editor(typeof(ResultSetInsertEditor), typeof(UITypeEditor))]
    public override string InsertCommand
    {
      get
      {
        return base.InsertCommand;
      }
      set
      {
        base.InsertCommand = value;
      }
    }

    /// <value>The insert command.</value>
    [DisplayName("SQL Delete"), Category("SQL")]
    [Editor(typeof(ResultSetDeleteEditor), typeof(UITypeEditor))]
    public override string DeleteCommand
    {
      get
      {
        return base.DeleteCommand;
      }
      set
      {
        base.DeleteCommand = value;
      }
    }



    [DisplayName("SQL Update"), Category("SQL")]
    [Editor(typeof(ResultSetUpdateEditor), typeof(UITypeEditor))]
    public override string UpdateCommand
    {
      get
      {
        return base.UpdateCommand;
      }
      set
      {
        base.UpdateCommand = value;
      }
    }





    [Editor(typeof(PKEditor), typeof(UITypeEditor))]
    [DisplayName("Chave Primária")]
    public override List<DataColumn> PrimaryKey
    {
      get
      {
        return base.PrimaryKey;
      }
      set
      {
        base.PrimaryKey = value;
      }
    }

    [DisplayName("Relações Mestre"), Category("Relations")]
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public DataRelationCollection ParentRelations
    {
      get
      {
        if (Table != null)
          return Table.ParentRelations;
        else
          return null;
      }
    }

    [DisplayName("Relações Detalhe"), Category("Relations")]
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public DataRelationCollection ChildRelations
    {
      get
      {
        if (Table != null)
          return Table.ChildRelations;
        else
          return null;
      }
    }

    private bool externalParam;
    [Browsable(true), DisplayName("RS Externo"), Category("Design")]
    public bool ExternalParam
    {
      get
      {
        return externalParam;
      }
      set
      {
        externalParam = value;
      }
    }

    private SchemaEntity schema;
    [Browsable(false)]
    internal SchemaEntity Schema
    {
      get { return schema; }
      set { schema = value; }
    }

    [Browsable(false)]
    public Structure Structure { get; set; }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Databridge.Engine.ExecutionContext Context
    {
      get
      {
        return Structure.GetContext();
      }
      set
      {
      }
    }

    [DisplayName("Descrição"), Category("Design")]
    public string Description
    {
      get;
      set;
    }

    private string displayText;
    [DisplayName("Texto de Apresentação"), Category("Design")]
    public virtual string DisplayText
    {
      get
      {
        if (string.IsNullOrEmpty(displayText))
          return name;
        else
          return displayText;
      }
      set { displayText = value; }
    }


    [Category("View"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Sort
    {
      get
      {
        if (View != null)
          return View.Sort;
        else
          return "";
      }
      set
      {
        if (View != null)
          View.Sort = value;
      }
    }
    [Category("View"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Filter
    {
      get
      {
        if (View != null)
          return View.RowFilter;
        else
          return "";
      }
      set
      {
        if (View != null)
          View.RowFilter = value;
      }
    }

    #region IResultSet Members


    IStructure IResultSet.Structure
    {
      get
      {
        return Structure;
      }
    }

    #endregion

    #region IScriptedObject Members

    [Browsable(false)]
    public string Script
    {
      get
      {
        return Sql;
      }
      set
      {
        Sql = value;
      }
    }

    [Browsable(false)]
    public string Language
    {
      get { return "SQL"; }
    }



    #endregion



    #region IConnectedObject Members

    [Browsable(false)]
    IDataConnection IConnectedObject.Connection
    {
      get
      {
        return Connection;
      }
      set
      {
        Connection = (DynConnection)value;
      }
    }

    #endregion

    #region IOperation Members



    void IOperation.Execute()
    {
      this.Fill();
    }

    [Browsable(false)]
    bool IOperation.IgnoreFailure
    {
      get
      {
        return true;
      }
      set
      {
      }
    }


    [Browsable(false)]
    IOperation IOperation.OnFailure
    {
      get
      {
        return null;
      }
      set
      {
      }
    }

    [Browsable(false)]
    IOperation IOperation.OnSuccess
    {
      get
      {
        return null;
      }
      set
      {
      }
    }

    [Browsable(false)]
    IEntity IOperation.Result
    {
      get
      {
        return this;
      }
      set
      {
      }
    }

    string IOperation.ToString()
    {
      return this.Name;
    }

    [Browsable(false)]
    object IOperation.Value
    {
      get { return View; }
    }

    [Browsable(false)]
    IEntity IOperation.EntityValue
    {
      get { return this; }
    }


    [Browsable(false)]
    IStructure IOperation.Structure
    {
      get
      {
        return Structure;
      }
      set
      {
        Structure = (Structure)value;
      }
    }

    [Browsable(false)]
    IExecutionContext IScriptedObject.Context
    {
      get { return Structure.GetContext(); }
    }
    #endregion

    [Browsable(false)]
    public string Notes { get; set; }

    #region IOperation Members
    [Browsable(false)]
    public virtual bool LargeObject
    {
      get
      {
        return false;
      }
    }

    protected OperationType operationType;
    [Browsable(false)]
    public OperationType OperationType
    {
      get
      {
        operationType = OperationType.ResultSet;
        return OperationType.ResultSet;
      }
    }
    #endregion
  }
}
