using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.PropertyEditors;
using System.Drawing.Design;
using Iris.Interfaces;
using Iris.Runtime.Core;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  public abstract class RelationBasedOperation : ColumnBasedOperation, IRelationBasedOperation
  {
    public RelationBasedOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    
    private DataRelationManager manager;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataRelationManager Manager
    {
      get 
      {
        if ((manager == null) && (Entrada!= null)&&(MasterRS != null))
          manager = new DataRelationManager(this.Name, Entrada.Table, MasterRS.Table);
        return manager; 
      }
      set { manager = value; }
    }

    [Browsable(false)]
    public override string Column
    {
      get
      {
        return base.Column;
      }
      set
      {
        base.Column = value;
      }
    }

    [Browsable(false)]
    public override string ColumnName
    {
      get
      {
        return base.ColumnName;
      }
      set
      {
        base.ColumnName = value;
      }
    }

    [Editor(typeof(RBOFieldMapEditor), typeof(UITypeEditor))]
    [DisplayName("Link"), Category("Expressão")]
    public List<KeyValuePair<string, string>> FieldMap
    {
      get
      {
        if (Manager != null)
          return Manager.FieldMap;
        else
          return null;
      }
      set
      {
        manager.FieldMap = value;
      }
    }

    [NonSerialized]
    protected DataRelation relation;

    protected string RefreshRelation(DataTable lookupTable, DataTable table)
    {
      return manager.RefreshRelation(lookupTable, table);
    }

    private string GetRelationName(DataTable lookupTable, DataTable table)
    {
      return manager.GetRelationName(lookupTable, table);
    }

    protected void RemoveRelation()
    {
      if(manager != null)
        manager.RemoveRelation();
    }

    protected string ValidadeName(string tableName, string rName)
    {
      return manager.ValidadeName(tableName, rName);
    }

    public override void Delete()
    {
      base.Delete();
      RemoveRelation();
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual IResultSet MasterRS
    {
      get
      {
        IOperation input = GetInput(1);
        if (input == null)
          return null; 
        else if (input is IResultSet)
          return (IResultSet)input;
        else
          return (IResultSet)input.EntityValue;
      }
    }
  }
}
