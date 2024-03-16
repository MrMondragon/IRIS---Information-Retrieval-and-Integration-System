using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors;
using System.Data;

namespace Iris.Runtime.Core
{
  [Serializable]
  public class DataRelationManager
  {

    public DataRelationManager(string _name, DataTable _sourceTable, DataTable _lookupTable)
    {
      name = _name;
      sourceTable = _sourceTable;
      lookupTable = _lookupTable;
    }

    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    private List<KeyValuePair<string, string>> fieldMap;
    public List<KeyValuePair<string, string>> FieldMap
    {
      get
      {
        return fieldMap;
      }
      set
      {
        fieldMap = value;
      }
    }

    [NonSerialized]
    private DataRelation relation;

    public DataRelation Relation
    {
      get { return relation; }
      set { relation = value; }
    }

    public string RefreshRelation(DataTable lookupTable, DataTable table)
    {
      this.sourceTable = table;
      this.lookupTable = lookupTable;

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
      try
      {
        if ((Relation == null) || (Relation.DataSet == null) || (Relation.DataSet != table.DataSet))
        {
          Relation = table.DataSet.Relations[rName];
        }
      }
      catch(InvalidOperationException ioe)
      {
        Relation = table.DataSet.Relations[rName];
      }
      catch
      {
        Relation = null;
      }


      bool recreateRelation = (Relation == null);
      if (!recreateRelation)
      {
        try
        {
          recreateRelation |= (Relation.RelationName != rName);
          recreateRelation |= (Relation.ParentColumns.Length != masterFields.Length);
          recreateRelation |= (Relation.ChildColumns.Length != detailFields.Length);
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
          recreateRelation |= masterFields[i].ColumnName != Relation.ParentColumns[i].ColumnName;
          recreateRelation |= detailFields[i].ColumnName != Relation.ChildColumns[i].ColumnName;
          if (recreateRelation)
            break;
        }
      }

      if (recreateRelation)
      {
        RemoveRelation();

        Relation = new DataRelation(rName, masterFields, detailFields, false);
        SourceTable.DataSet.Relations.AddRange(new DataRelation[] { Relation });
      }
      return rName;
    }

    public string GetRelationName(DataTable _lookupTable, DataTable _sourceTable)
    {
      string rName = "rel_";
      rName = ValidadeName(_lookupTable.TableName, rName);
      foreach (KeyValuePair<string, string> item in FieldMap)
      {
        rName += item.Key;
      }

      rName += "_";
      rName = ValidadeName(_sourceTable.TableName, rName);
      foreach (KeyValuePair<string, string> item in FieldMap)
      {
        rName += item.Value;
      }
      return rName;
    }

    [NonSerialized]
    private DataTable sourceTable;

    public DataTable SourceTable
    {
      get { return sourceTable; }
      set { sourceTable = value; }
    }

    [NonSerialized]
    private DataTable lookupTable;

    public DataTable LookupTable
    {
      get { return lookupTable; }
      set { lookupTable = value; }
    }

    public void RemoveRelation()
    {
      if (SourceTable != null)
      {
        for (int i = 0; i < SourceTable.Columns.Count; i++)
        {
          if (SourceTable.Columns[i].ExtendedProperties.ContainsKey("Operation"))
          {
            if (SourceTable.Columns[i].ExtendedProperties["Operation"].ToString() == this.Name)
              SourceTable.Columns[i].Expression = "";
          }
        }


        string rName;
        try
        {
          if (Relation == null)
            rName = GetRelationName(LookupTable, SourceTable);
          else 
            rName = Relation.RelationName;
        }
        catch
        {
          rName = GetRelationName(LookupTable, SourceTable);
        }

        if ((Relation != null) && (SourceTable.ParentRelations.Contains(rName)))
          SourceTable.ParentRelations.Remove(rName);
      }
    }

    public string ValidadeName(string tableName, string rName)
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

  }
}
