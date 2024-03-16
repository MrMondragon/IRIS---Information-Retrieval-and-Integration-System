using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Iris.Runtime.Model.PropertyEditors.Interfaces;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Core.Networking;
using System.Reflection;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.DisignSuport;
using System.Drawing.Design;
using Iris.PropertyEditors.PropertyEditors;
using System.Net;
using System.Data;
using System.Collections;
using Databridge.Engine;

namespace Iris.Runtime.Model.Operations.NetworkOperations
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Web Service")]
  public class InvokeWebService : Iris.WebOperations.BaseWebServiceOperation, IDynamicIOOperation, IInvokeWebService, ICredentialOperation
  {

    public InvokeWebService(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída");
    }

    public void RefreshIO()
    {
      if (AfterRefreshIO != null)
        AfterRefreshIO(this, new EventArgs());
    }

    protected override IEntity doExecute()
    {
      SetupConfigs();

      int paramCount = 0;

      if (ParamInfos != null)
      {
        paramCount = ParamInfos.Length;
      }

      //prepara parâmetros
      object[] paramValues = new object[paramCount];
      for (int i = 0; i < paramCount; i++)
      {
        IOperation input = GetInput(i);
        if (input != null)
          paramValues[i] = Proxy.ConvertParameterDataType(input.EntityValue.Value, ParamInfos[i]);
        else
          paramValues[i] = null;
      }

      Object returnValue = Proxy.Invoke(Method.Name, paramValues);

      IOperation output = GetOutput(0);

      if ((output != null) && (output is ScalarVar))
      {
        ((ScalarVar)output).RawValue = returnValue;
      }
      else if ((returnValue is DataTable) && (output != null) && (output is ResultSet))
      {
        ((ResultSet)output).Table = (DataTable)returnValue;
      }
      else if ((output != null) && (output is ResultSet))
      {

        IEnumerable<object> objList;
        if (returnValue is IEnumerable)
          objList = (returnValue as IEnumerable).Cast<object>();
        else
        {
          objList = new List<object>();
          ((List<object>)objList).Add(returnValue);
        }
        DataObjectManipulator.ObjListToResultset(objList, ((ResultSet)output));
      }

      return (IEntity)output;
    }


    public override MethodInfo Method
    {
      get
      {
        return base.Method;
      }
      set
      {
        if (base.Method != value)
        {
          if (BeforeRefreshIO != null)
            BeforeRefreshIO(this, new EventArgs());

          base.Method = value;

          if (Method != null)
          {
            string[] paramInputs = new string[ParamInfos.Length];

            for (int i = 0; i < ParamInfos.Length; i++)
            {
              paramInputs[i] = ParamInfos[i].Name;
            }

            List<string> list = new List<string>(paramInputs);
            list.Add("Configs");

            SetInputs(list.ToArray());
          }
          else
          {
            SetInputs("Configs");
          }


          RefreshIO();
        }
      }
    }



    #region IDynamicIOOperation Members
    [field: NonSerialized()]
    public event EventHandler BeforeRefreshIO;
    [field: NonSerialized()]
    public event EventHandler AfterRefreshIO;
    #endregion
  }
}
