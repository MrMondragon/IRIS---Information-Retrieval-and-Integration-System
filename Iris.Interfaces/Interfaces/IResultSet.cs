using System;
using System.Data;
using System.Collections.Generic;
using Iris.Interfaces;
using Iris.Runtime.Core.Expressions;
using Iris.Runtime.Core.ParserEngine.ParserObjects;
using Iris.Runtime.Core;
using Databridge.Interfaces;
namespace Iris.Interfaces
{
  public interface IResultSet: IConnectedObject
  {
    void Fill();
    bool GenDelete { get; set; }
    bool GenInsert { get; set; }
    bool GenUpdate { get; set; }
    string InsertCommand { get; set; }
    string DeleteCommand { get; set; }
    string UpdateCommand { get; set; }
    List<DataColumn> PrimaryKey { get; set; }
    DataTable Table { get; set;}
    string Sql { get; set; }
    void Apply(DataRow[] rows);
    void Clear();
    IStructure Structure { get; }
    bool InMemory { get; set;}
    DataView View { get; set;}
    string Name { get; set;}
    bool HasView();
    string GetTableName();
  }
}
