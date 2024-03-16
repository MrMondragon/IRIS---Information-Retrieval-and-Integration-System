using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.ResultSetOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Operations.ConnectionOperations;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.ComponentModel;

namespace Iris.Runtime.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Create Table")]
  public class CreateSQLTable : ConnectionOperation
  {
    public CreateSQLTable(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }



    [Category("Schema")]
    public string TableName { get; set; }

    protected override IEntity doExecute()
    {
      ResultSet rs = GetInput("Entrada") as ResultSet;
      if (rs == null)
        throw new Exception("Resultset de entrada não atribuído");

      DataTable table = rs.Table;

      if (table == null)
        throw new Exception("Tabela de entrada não atribuída");

      StringBuilder sb = new StringBuilder();
      if (!string.IsNullOrWhiteSpace(TableName))
        sb.AppendLine($"CREATE TABLE {TableName}");
      else
        sb.AppendLine($"CREATE TABLE {table.TableName}");
      sb.AppendLine("(");

      foreach (DataColumn column in table.Columns)
      {
        string dataType = GetSqlType(column.DataType, column.MaxLength);
        string nullable = column.AllowDBNull ? "NULL" : "NOT NULL";

        string columnName = column.ColumnName;

        if (column.ColumnName.Contains(" "))
        {
          string[] columnNameParts = column.ColumnName.Split(' ');

          columnName = string.Join("_", columnNameParts.Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()));
        }

        sb.AppendLine($"{columnName} {dataType} {nullable},");
      }

      if ((table.PrimaryKey != null) && (table.PrimaryKey.Length != 0))
      {
        sb.AppendLine($" CONSTRAINT [PK_{table}_key] PRIMARY KEY CLUSTERED");
        sb.AppendLine("(");
        StringBuilder pkSb = new StringBuilder();
        foreach (DataColumn pkCol in table.PrimaryKey)
        {
          pkSb.AppendLine($"[{pkCol.ColumnName}] ASC,");
        }
        sb.AppendLine(pkSb.ToString().Trim().TrimEnd(','));

        sb.AppendLine(")");
      }

      sb.AppendLine(")");

      Connection.ExecuteNonQuery(sb.ToString(), Structure.GetContext());

      return null;
    }

    private string GetSqlType(Type dataType, int size)
    {
      if (dataType == typeof(Int64))
        return "BigInt";
      else if (dataType == typeof(Boolean))
        return "Bit";
      else if (dataType == typeof(String))
      {
        if (size > 0)
          return $"char({size})";
        else
          return "NVarchar(Max)";
      }
      else if (dataType == typeof(DateTime))
        return "DateTime";
      else if (dataType == typeof(Int32))
        return "Int";
      else if (dataType == typeof(Decimal))
        return "Decimal";
      else if (dataType == typeof(Guid))
        return "uniqueidentifier";
      else if (dataType == typeof(Byte))
        return "tinyint";
      else if (dataType == typeof(Byte[]))
        return "Binary";
      else if( (dataType == typeof(Single))||(dataType == typeof(Double)))
        return "float";
      else
        return "NVarchar(Max)";


    }
  }
}
