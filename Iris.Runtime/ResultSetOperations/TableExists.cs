using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Data;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Core.Connections;
using Iris.PropertyEditors;
using System.Drawing.Design;

namespace Iris.Runtime.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Table Exists")]
  public class TableExists: ControlOperation
  {

    public TableExists(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída", "True", "False");
    }
    public string TableName { get; set; }

    public override void AssignObject(object value)
    {
      this.TableName = Convert.ToString(value);
    }

    private DynConnection connection;
    [Editor(typeof(ConnectionSelectorEditor), typeof(UITypeEditor))]
    public DynConnection Connection
    {
      get { return connection; }
      set { connection = value; }
    }

    protected override IEntity doExecute()
    {
      bool tableExists = connection.TableExists(TableName);

      IOperation oTrue = GetOutput("True");
      IOperation oFalse = GetOutput("False");

      if ((oTrue != null) || (oFalse != null))
      {
        if(tableExists)
        {
          if (oTrue != null)
            this.ExecuteObj(oTrue);
        }
        else
        {
          if (oFalse != null)
            this.ExecuteObj(oFalse);
        }
      }
      else
      {
        IScalarVar isv = GetOutput("Saída") as IScalarVar;
        if (isv == null)
          throw new Exception("Variável de saída não atribuída ou objeto inválido");

        isv.RawValue = tableExists;
      }
      return null;
    }
  }
}
