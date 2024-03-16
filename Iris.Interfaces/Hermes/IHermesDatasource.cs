using System;
using System.Collections.Generic;
using System.Data;

namespace Iris.Interfaces.Hermes
{
  public interface IHermesDatasource
  {
    DataTable GetData(string tableName);

    string Name { get; set; }
    /// <summary>
    /// Retorna um objeto DataTable com todos os campos de uma tabela.
    /// Colunas: "Table_Name".
    /// </summary>
    /// <returns></returns>
    DataTable GetSchema();
    /// <summary>
    /// Retorna um objeto DataTable com todos os campos de uma tabela.
    /// Colunas: "Column_Name"
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    /// <summary>
    /// Retorna um objeto DataTable com todos os campos de uma tabela.
    /// Colunas: "Column_Name"
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    DataTable GetFields(string tableName);

    DataTable GetTableSchema(string tableName);

    void InvalidateSchema();
  }
}
