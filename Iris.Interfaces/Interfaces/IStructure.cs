using System;
using System.Collections.Generic;
using Iris.Interfaces;
using System.Data;
using Databridge.Interfaces;
using Iris.Runtime.Model.Entities;
namespace Iris.Interfaces
{
  public interface IStructure
  {
    IDataConnection[] Connections { get; }
    IResultSet[] ResultSets { get; }
    IScalarVar[] ScalarVars { get; }
    IOperation[] Operations { get; }
    ISchemaEntity[] Schemas { get; }
    object this[string objName] { get; set; }
    IDataConnection GetConnection(string conName);
    IResultSet GetResultSet(string rsName);
    IScalarVar GetScalarVar(string varname);
    IOperation GetOperation(string operName);
    IOperation RunningOper { get; set; }
    string Description { get; set; }
    object GetObject(string objName, string objList);
    object GetObject(string objName);
    DataSet Dataset { get; set; }
    void AddToLog(string logEntry, IOperation operation);

    void AddToErrorLog(string logEntry, IOperation operation);

    void AddToLog(string _name, Exception e, IOperation operation);
    IProccessLog Log { get; set; }
    string GetBaseAccessorCode();
    IEntity Execute(bool _debug);
    Dictionary<string, string> Assemblies{ get; set; }
    string ClassName { get; set; }
    void Restart();
    void ClearDataset();
    Dictionary<string, string> TypeLookupTable{get;}

    void EnableConnections();
    void DisableConnections();
  }
}
