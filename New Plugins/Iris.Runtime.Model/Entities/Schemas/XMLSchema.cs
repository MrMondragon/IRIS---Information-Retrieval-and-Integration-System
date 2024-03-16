using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;

namespace Iris.Runtime.Model
{
  [Serializable]
  public class XMLSchema : SchemaEntity
  {
    public XMLSchema(string aName, Structure aStructure)
      : base(aName, aStructure)
    {
    }

    public override void CreateResultSets()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public override void ReadToTables(IrisList<ResultSet> resultsets)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public override void WriteFromTables(IrisList<ResultSet> resultsets)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public override List<string> GetTableNames()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public override void ClearTables()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public override void RefreshResultSets()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public override void RefreshResultSets(ResultSet resultSet)
    {
      throw new Exception("The method or operation is not implemented.");
    }
  }
}
