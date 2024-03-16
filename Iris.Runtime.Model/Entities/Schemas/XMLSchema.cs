using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Data;
using System.IO;
using System.Xml;

namespace Iris.Runtime.Model
{
  [Serializable]
  public class XMLSchema : SchemaEntity
  {
    public XMLSchema(string aName, Structure aStructure)
      : base(aName, aStructure)
    {
      ParseDTD = true;
      BypassReader = true;
    }

    public bool BypassReader { get; set; }

    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("File Name"), Category("Arquivo"), Description("Arquivo de dados que será lido/gravado")]
    public override string FileName
    {
      get
      {
        return base.FileName;
      }
      set
      {
        if (string.IsNullOrEmpty(XsdFile) || (XsdFile == base.FileName))
          xsdFile = value;

        base.FileName = value;          
      }
    }

    private string xsdFile;
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("XSD/XML File Name"), Category("Arquivo"), Description("Arquivo que serivrá de schema/exemplo para a estrutura de dados.")]
    public string XsdFile
    {
      get { return xsdFile; }
      set 
      { 
        xsdFile = value; 
      }
    }
   
    [NonSerialized]
    private DataSet internalDataset;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private DataSet InternalDataset
    {
      get
      {
        if (internalDataset == null)
        {
          if (string.IsNullOrEmpty(XsdFile) || (!File.Exists(XsdFile)))
            throw new Exception("XML/XSD não atribuído ou inválido");
          else
          {
            internalDataset = new DataSet();
            if ((!string.IsNullOrEmpty(XsdFile)) && (File.Exists(XsdFile)))
            {
              string extension = Path.GetExtension(XsdFile).ToLower().Trim('.');

              if (extension == "xsd")
              {
                internalDataset.ReadXmlSchema(XsdFile);
              }
              else
              {
                if (BypassReader)
                  internalDataset.ReadXml(XsdFile);
                else
                {
                  XmlReader xr = GetDataReader();
                  internalDataset.ReadXml(xr);
                }                
                internalDataset.Clear();
              }
            }
          }
        }
        return internalDataset;
      }

    }

    public bool ParseDTD { get; set; }

    private void CreateRelations()
    {
      foreach (DataRelation relation in internalDataset.Relations)
      {
        if (Structure.Dataset.Relations.Contains(relation.RelationName))
          Structure.Dataset.Relations.Remove(relation.RelationName);


        string parentTableName = this.TablePrefix + relation.ParentTable.TableName;
        string childTableName = this.TablePrefix + relation.ChildTable.TableName;

        if (Structure.Dataset.Tables.Contains(parentTableName) &&
          Structure.Dataset.Tables.Contains(childTableName))
        {
          string[] parentColumnNames = relation.ParentColumns.Select(x => x.ColumnName).ToArray();
          string[] childColumnNames = relation.ChildColumns.Select(x => x.ColumnName).ToArray();


          DataRelation newRelation = new DataRelation(relation.RelationName,
            parentTableName, childTableName, parentColumnNames, childColumnNames, relation.Nested);

          Structure.Dataset.Relations.Add(newRelation);
        }
      }
    }

    private void RemoveRelations()
    {
      foreach (DataRelation relation in internalDataset.Relations)
      {
        if (Structure.Dataset.Relations.Contains(relation.RelationName))
          Structure.Dataset.Relations.Remove(relation.RelationName);
      }
    }

    public override void CreateResultSets()
    {
      CreateResultSets(true);
    }

    private void CreateResultSets(bool createNew)
    {

      if (InternalDataset.Tables.Count == 0)
        throw new Exception("Arquivo inválido. Nenhuma tabela encontrada.");
      else
      {
        foreach (DataTable table in InternalDataset.Tables)
        {
          CreateResultSet(table, createNew);
        }
      }

    }

    private void CreateResultSet(DataTable table, bool createNew)
    {
      if (table != null)
      {
        string tableName = this.TablePrefix + table.TableName;

        ResultSet rs = (ResultSet)Structure.GetObject(tableName);

        if ((rs == null) && (createNew))
          rs = new ResultSet(tableName, Structure);

        if (rs != null)
        {
          DataTable rsTable = table.Clone();

          foreach (DataColumn column in rsTable.Columns)
          {
            if (column.ColumnMapping == MappingType.Hidden)
              column.ColumnMapping = MappingType.Attribute;
          }

          rsTable.TableName = tableName;
          rs.Table = rsTable;
          rs.Schema = this;
          if (Structure.Dataset.Tables.Contains(tableName))
            Structure.Dataset.Tables.Remove(tableName);

          Structure.Dataset.Tables.Add(rsTable);
        }
      }
    }


    public override void ClearTables()
    {
      if (InternalDataset != null)
      {
        foreach (DataTable internalTable in InternalDataset.Tables)
        {
          string tableName = TablePrefix + internalTable.TableName;

          DataTable table = Structure.Dataset.Tables[tableName];
          DataSet dataset;
          ClearSchemaTable(table, out dataset);
        }
      }
    }

    public override List<string> GetTableNames()
    {
      return InternalDataset.Tables.Cast<DataTable>().Select(x => this.TablePrefix + x.TableName).ToList();
    }

    public override void RefreshResultSets()
    {
      CreateResultSets(false);
    }

    public override void RefreshResultSets(ResultSet resultSet)
    {
      string tableName = GetTableNameFromRS(resultSet);
      DataTable table = InternalDataset.Tables[tableName];
      CreateResultSet(table, false);
    }

    public override void ReadToTables(IrisList<ResultSet> resultsets, int start, int end)
    {
      if (!string.IsNullOrEmpty(FileName))
      {
        RefreshResultSets();

        DataSet workDataset = new DataSet();
        if (BypassReader)
          workDataset.ReadXml(FileName);
        else
        {
          XmlReader xr = GetDataReader();
          workDataset.ReadXml(xr);

        }

        foreach (ResultSet rs in resultsets)
        {
          string tableName = GetTableNameFromRS(rs);
          if (workDataset.Tables.Contains(tableName))
          {
            DataTable workTable = workDataset.Tables[tableName];

            rs.Table.BeginLoadData();
            foreach (DataRow row in workTable.Rows)
            {
              rs.Table.LoadDataRow(row.ItemArray, true);
            }
            rs.Table.EndLoadData();
          }
        }
      }
    }

    private XmlReader GetDataReader()
    {
      XmlReaderSettings xrs = new XmlReaderSettings();
      xrs.DtdProcessing = ParseDTD ? DtdProcessing.Parse : DtdProcessing.Ignore;
      XmlReader xr = XmlReader.Create(XsdFile, xrs);
      return xr;
    }

    public override void WriteFromTables(IrisList<ResultSet> resultsets)
    {
      if (!string.IsNullOrEmpty(FileName))
      {
        DataSet workDataset = InternalDataset.Clone();

        foreach (ResultSet rs in resultsets)
        {
          string tableName = GetTableNameFromRS(rs);
          DataTable rsTable = rs.Table;
          if (workDataset.Tables.Contains(tableName))
          {
            DataTable workTable = workDataset.Tables[tableName];

            workTable.BeginLoadData();
            foreach (DataRow row in rsTable.Rows)
            {
              workTable.LoadDataRow(row.ItemArray, true);
            }
            workTable.EndLoadData();
          }
        }

        workDataset.WriteXml(FileName, XmlWriteMode.IgnoreSchema);
      }
    }


    private string GetTableNameFromRS(ResultSet resultSet)
    {
      string tableName = resultSet.Name;
      if (tableName.StartsWith(TablePrefix))
        tableName = tableName.Substring(TablePrefix.Length);

      return tableName;
    }

  }
}
