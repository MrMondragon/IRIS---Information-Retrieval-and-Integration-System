using Iris.Runtime.Model.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iris.Interfaces;
using AsteriskTestProject.Asterisk;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.DMG.Asterisk
{
  [OperationCategory("DMG", "AsteriskLogLoader")]
  [Serializable]
  public class AsteriskLogLoader : Operation
  {
    public AsteriskLogLoader(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetOutputs("Saída");
      SetInputs("Path");
    }

    public string Path { get; set; }

    protected override IEntity doExecute()
    {
      ResultSet saida = (ResultSet)GetOutput("Saída");

      AsteriskLoader loader = new AsteriskLoader(Path);

      saida.Table = loader.GetEntryTable();

      return saida;

    }
  }
}
