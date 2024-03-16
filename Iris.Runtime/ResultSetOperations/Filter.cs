using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Operations.ResultSetOperations;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;

namespace Iris.DataOperations.ResultSetOperations
{
  
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Filter")]
  public class Filter : ResultSetOperation
  {
    public Filter(Structure aStructure, string aName)
      : base(aStructure,aName)
    {
    }

    private string rowFilter;

    public string RowFilter
    {
      get { return rowFilter; }
      set { rowFilter = value; }
    }

    protected override IEntity doExecute()
    {
      ResultSet rs = (ResultSet)Entrada;      
      rs.View.RowFilter = RowFilter;
      return rs;      
    }
  }
}




