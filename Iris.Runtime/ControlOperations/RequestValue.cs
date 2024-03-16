using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Runner;
using Iris.Runtime.Core.Connections;
using System.Data;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.DisignSuport;
using Iris.PropertyEditors;
using Iris.Interfaces;
using System.CodeDom.Compiler;
using Databridge.Interfaces;
using Databridge.PropertyEditors.Dialogs;
using System.Windows.Forms;
using Iris.Runtime.ControlOperations.Dialogs;

namespace Iris.Runtime.ControlOperations
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Request Value")]
  public class RequestValue : Operation
  {
    public RequestValue(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetOutputs("Saída");
    }

    public string DialogTitle { get; set; }
    public string DialogLabel { get; set; }

    protected override IEntity doExecute()
    {
      ScalarVar saida = (ScalarVar)GetOutput("Saída");

      RequestValueDialog oed = new RequestValueDialog();
      if(oed.Execute(DialogLabel, DialogTitle, Convert.ToString(saida.RawValue) ) == DialogResult.OK)
      {
        saida.RawValue = oed.Value;
      }
      return null;
    }
  }
}
