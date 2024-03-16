using System;
using Iris.Interfaces;
namespace Iris.Runtime.Core.Conexao
{
  public interface IDynConnection
  {
    event EventHandler AfterNameChange;
    event EventHandler BeforeNameChange;
    void Close();
    void CommitTransaction();
    System.Data.Common.DbConnection Connection { get; }
    System.Data.ConnectionState ConnectionState { get; }
    string ConnectionString { get; set; }
    void doGetSchema();
    //int ExecuteNonQuery(string Sql, System.Collections.Generic.Dictionary<string, object> parameters);
    //object ExecuteScalar(string Sql, System.Collections.Generic.Dictionary<string, object> parameters);
    System.Data.Common.DbProviderFactory Factory { get; }
    System.Data.DataTable GetFields(string tableName);
    System.Data.DataTable GetSchema();
    string InternalProvider { get; set; }
    void InvalidateSchema();
    bool IsSchemaValid { get; }
    string Name { get; set; }
    void Open();
    string ParameterMarkerFormat { get; }
    int ParameterNameMaxLength { get; }
    string Provider { get; set; }
    void RollbackTransaction();
    void StartTransaction();
    bool SuportsTransactions { get; set; }
    string ToString();
    System.Data.Common.DbTransaction Transaction { get; }
    void ValidateSchema();
  }
}
