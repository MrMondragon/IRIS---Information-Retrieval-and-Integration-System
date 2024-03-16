using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.VarOperations;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Reflection;
using Databridge.Engine;

namespace Iris.Runtime.VarOperations
{
  [Serializable]
  [OperationCategory("Operações de Objeto", "Object List to Table")]
  public class ObjListToTable: BaseVarOperation
  {
    public ObjListToTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private IScalarVar Entrada
    {
      get
      {
        return GetInput(0) as IScalarVar;
      }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private IResultSet Saida
    {
      get
      {
        return GetOutput(0) as IResultSet;
      }
    }

    protected override IEntity doExecute()
    {
      if (Entrada == null)
        throw new Exception("Entrada inválida");

      if (Saida == null)
        throw new Exception("Saída inválida");

      DataTable table = new DataTable(Saida.Name);
      Saida.Table = table;

      IEnumerable<object> list = (Entrada.RawValue as IEnumerable).Cast<Object>();
      if (list != null)
      {
        if (list.Count() > 0)
        {
          DataObjectManipulator.ObjListToTable(list, table);
        }

        Structure.AddToLog(String.Format("{0} registros carregados", list.Count()), this);
      }

      return (IEntity) Saida;
    }
  }
}
