using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Core.Connections;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors;
using Iris.Interfaces;
using Iris.Runtime.Model.PropertyEditors;

namespace Iris.Runtime.Model.Entities
{
  [Serializable]
  public class ScalarVar : Entity, IScalarVar
  {
    public ScalarVar(string aName, Structure aStructure)
      : base(aName, aStructure)
    {
      aStructure.ScalarVars.Add(this);
    }

    [NonSerialized]
    protected Object rawValue;
    [Editor(typeof(ScalarVarValueEditor), typeof(UITypeEditor))]
    [DisplayName("Valor"), Category("Variável"), Description("Valor da Variável")]
    public virtual Object RawValue
    {
      get { return this.rawValue; }
      set 
      { 
        this.rawValue = value;
        if ((value != null)&&(value.GetType() != DataType))
          DataType = value.GetType();
      }
    }

    [Browsable(false)]
    public override object Value
    {
      get { return RawValue; }
    }

    [Browsable(true), Description("Tipo de dado do valor da Variável")]
    public override Type DataType
    {
      get
      {
        return base.DataType;
      }
      set
      {
        base.DataType = value;
      }
    }

    [Browsable(true), DisplayName("Parâmetro"), Category("Design")]
    public override bool ExternalParam
    {
      get
      {
        return base.ExternalParam;
      }
      set
      {
        base.ExternalParam = value;
      }
    }

    protected override IEntity doExecute()
    {
      return this;
    }

  }
}
