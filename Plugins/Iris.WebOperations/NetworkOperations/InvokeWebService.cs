using System;
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
      //prepara parâmetros
      object[] paramValues = new object[paramInfos.Length];
      for (int i = 0; i < paramInfos.Length; i++)
      {
        IOperation input = GetInput(i);
        if (input != null)
          paramValues[i] = Proxy.ConvertParameterDataType(Convert.ToString(input.EntityValue.Value), paramInfos[i]);
        else
          paramValues[i] = null;
      }

      Object returnValue = Proxy.Invoke(Method.Name, paramValues);

      IOperation output = GetOutput(0);

      if ((output != null) && (output is ScalarVar))
      {
        ((ScalarVar)output).RawValue = returnValue;
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
            string[] paramInputs = new string[paramInfos.Length];

            for (int i = 0; i < paramInfos.Length; i++)
            {
              paramInputs[i] = paramInfos[i].Name;
            }

            SetInputs(paramInputs);
          }
          else
          {
            SetInputs(new string[0]);
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
