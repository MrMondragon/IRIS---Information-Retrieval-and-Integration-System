using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System;
using System.ComponentModel;

namespace Iris.DMG.CyM.Social
{
  [Serializable]
  public abstract class BaseSocialOperation : ColumnBasedOperation
  {
    public BaseSocialOperation(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Entrada", "Data Início", "Data Fim");

      Interval = 10000;

    }

    public int Interval { get; set; }
    public DateTime DataLimite { get; set; }


    [DisplayName("Coluna de Links")]
    public override string Column
    {
      get
      {
        return base.Column;
      }
      set
      {
        base.Column = value;
      }
    }

    [Browsable(false)]
    public override string ColumnName
    {
      get
      {
        return base.ColumnName;
      }
      set
      {
        base.ColumnName = value;
      }
    }


  }
}
