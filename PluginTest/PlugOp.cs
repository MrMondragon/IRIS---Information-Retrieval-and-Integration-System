using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;
using System.Drawing;
using PluginTest.Properties;

namespace PluginTest
{
  [Serializable]
  [OperationCategory("Operações de Plug", "Plug")]
  public class PlugOp: Operation
  {
    public PlugOp(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    public static Bitmap GetIcon()
    {
      return Resources.BackupDatabase;
    }

    protected override IEntity doExecute()
    {
      throw new Exception("The method or operation is not implemented.");
    }
  }
}
