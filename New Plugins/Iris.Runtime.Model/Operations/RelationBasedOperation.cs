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

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  public abstract class RelationBasedOperation : ColumnBasedOperation, IRelationBasedOperation
  {
    public RelationBasedOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
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

    private List<KeyValuePair<string, string>> _fieldMap;
    [Editor(typeof(RBOFieldMapEditor), typeof(UITypeEditor))]
    [DisplayName("Link"), Category("Expressão")]
    public List<KeyValuePair<string, string>> FieldMap
    {
      get
      {
        return _fieldMap;
      }
      set
      {
        _fieldMap = value;
      }
    }

    [NonSerialized]
    protected DataRelation relation;

    protected string RefreshRelation(DataTable lookupTable, DataTable table)
    {
      if (FieldMap == null)
        throw new Exception("Lookup Link não atribuído");

      int fieldCount = FieldMap.Count;
      DataColumn[] masterFields = new DataColumn[fieldCount];
      DataColumn[] detailFields = new DataColumn[fieldCount];
      for (int i = 0; i < fieldCount; i++)
      {
        masterFields[i] = lookupTable.Columns[FieldMap[i].Key];
        detailFields[i] = table.Columns[FieldMap[i].Value];
      }

      string rName = GetRelationName(lookupTable, table);

      bool recreateRelation = (relation == null);
      if(!recreateRelation)
      {
        try
        {
          recreateRelation |= (relation.RelationName != rName);
          recreateRelation |= (relation.ParentColumns.Length != masterFields.Length);
          recreateRelation |= (relation.ChildColumns.Length != detailFields.Length);
        }
        catch
        {
          recreateRelation = true;
        }
      }
      recreateRelation |= (!table.ParentRelations.Contains(rName));
      if (!recreateRelation)
      {
        for (int i = 0; i < masterFields.Length; i++)
        {
          recreateRelation |= masterFields[i].ColumnName != relation.ParentColumns[i].ColumnName;
          recreateRelation |= detailFields[i].ColumnName != relation.ChildColumns[i].ColumnName;
          if (recreateRelation)
            break;
        }
      }

      if (recreateRelation)
      {
        RemoveRelation();

        relation = new DataRelation(rName, masterFields, detailFields, false);
        Structure.Dataset.Relations.AddRange(new DataRelation[] { relation });
      }
      return rName;
    }

    private static string GetRelationName(DataTable lookupTable, DataTable table)
    {
      string rName = "rel_";
      rName = ValidadeName(lookupTable.TableName, rName);
      rName += "_";
      rName = ValidadeName(table.TableName, rName);
      return rName;
    }

    protected void RemoveRelation()
    {
      Operation input = GetInput("Entrada");

      if (input != null)
      {
        DataTable table = Entrada.Table;
        for (int i = 0; i < table.Columns.Count; i++)
        {
          if (table.Columns[i].ExtendedProperties.ContainsKey("Operation"))
          {
            if (table.Columns[i].ExtendedProperties["Operation"].ToString() == this.Name)
              table.Columns[i].Expression = "";
          }
        }

        string rName;
        try
        {
          rName = relation.RelationName;
        }
        catch
        {
          rName = GetRelationName(MasterRS.Table, table);
        }

        if ((relation != null) && (table.ParentRelations.Contains(rName)))
          table.ParentRelations.Remove(rName);
      }
    }

    protected static string ValidadeName(string tableName, string rName)
    {
      string invalidChars = "~()#\\/= ><+-*%&|^'\"[]";

      for (int i = 0; i < tableName.Length; i++)
      {
        string charToAdd = tableName[i].ToString();
        charToAdd = charToAdd.Trim();

        if ((!string.IsNullOrEmpty(charToAdd)) && (!invalidChars.Contains(charToAdd)))
        {
          rName += charToAdd;
        }
      }
      return rName;
    }

    public override void Delete()
    {
      base.Delete();
      RemoveRelation();
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IResultSet MasterRS
    {
      get
      {
        Operation input = GetInput(1);
        if (input == null)
          throw new Exception("Resultset mestre não atribuído");
        else if (input is IResultSet)
          return (IResultSet)input;
        else
          return (IResultSet)input.EntityValue;
      }
    }
  }
}
