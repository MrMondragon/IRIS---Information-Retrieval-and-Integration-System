using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Expressions;
using System.Drawing.Design;
using System.ComponentModel;
using Iris.PropertyEditors;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Fill")]
  public class Fill: ResultSetOperation
  {
    public Fill(Structure aStructure, string aName)
      : base(aStructure,aName)
    {
    }

    protected override IEntity doExecute()
    {
      IOperation rs = GetInput(0);

      if (rs == null)
        throw new Exception("Objeto de entrada não atribuído");

      if (!(rs.EntityValue is IResultSet))
        throw new Exception("Objeto de entrada não é um ResultSet");

      IResultSet resultset = (IResultSet)rs.EntityValue;
           
      resultset.Fill();
     
      Structure.AddToLog(String.Format("{0} registros carregados", resultset.Table.Rows.Count), this);
      return (IEntity)resultset;
    }


  }
}
