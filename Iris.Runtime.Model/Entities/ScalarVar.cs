using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Core.Connections;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors;
using Iris.Interfaces;
using Iris.Runtime.Model.PropertyEditors;
using Iris.PropertyEditors.PropertyEditors;
using System.Reflection;

namespace Iris.Runtime.Model.Entities
{
  [Serializable]
  public class ScalarVar : Entity, IScalarVar
  {
    public ScalarVar(string aName, Structure aStructure)
      : base(aName, aStructure)
    {
      if (aStructure != null)
        aStructure.ScalarVars.Add(this);

      scope = BindingScope.None;
      persistValue = false;
    }

    private bool persistValue;
    [DisplayName("Persistir"), Category("Variável"), Description("Indica se o valor da variável deve ser gravado junto com o projeto, ou se ele deve ser limpo quando o projeto for gravado/resetado")]
    public bool PersistValue
    {
      get { return persistValue; }
      set { persistValue = value; }
    }

    public override void Reset()
    {
      base.Reset();
      if (!PersistValue)
      {
        rawValue = null;
      }
    }

    protected Object rawValue;
    [Editor(typeof(ScalarVarValueEditor), typeof(UITypeEditor))]
    [DisplayName("Valor"), Category("Variável"), Description("Valor da Variável")]
    public virtual Object RawValue
    {
      get { return this.rawValue; }
      set
      {
        if (rawValue != value)
        {
          if (!ValidateValue(value))
            throw new Exception("Valor Inválido");
          else
          {
            this.rawValue = value;
            if ((value != null) && (value.GetType() != DataType))
              DataType = value.GetType();
          }
        }
      }
    }

    private bool ValidateValue(object value)
    {
      bool valid = true;
      if (ValidValues.Count > 0)
      {
        valid = false;
        string stValue = Convert.ToString(value);
        for (int i = 0; i < ValidValues.Count; i++)
        {
          string stValid = ValidValues[i];
          if (stValue == stValid)
          {
            valid = true;
            break;
          }
        }
      }

      return valid;
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

    private List<string> validValues;
    [Editor(typeof(ScalarValidValuesEditor), typeof(UITypeEditor))]
    [DisplayName("Valores Válidos"), Category("Variável"), Description("Lista de valores válidos para a variável")]
    public List<string> ValidValues
    {
      get
      {
        if (validValues == null)
          validValues = new List<string>();

        return validValues;
      }
      set
      {
        validValues = value;
        RawValue = null;
      }
    }

    protected override IEntity doExecute()
    {
      return this;
    }

    [Browsable(false)]
    public override OperationType OperationType
    {
      get
      {
        operationType = OperationType.ScalarVar;
        return OperationType.ScalarVar;
      }
    }

    private BindingScope scope;
    [Category("Binding")]
    public BindingScope BindingScope
    {
      get
      {
        return scope;
      }
      set
      {
        if (value == BindingScope.None)
        {
          BindingTarget = "";
          BindingProperty = "";
        }

        scope = value;
      }
    }
    [Category("Binding"), DisplayName("Target")]
    public string BindingTarget { get; set; }

    [Category("Binding"), DisplayName("Property")]
    public string BindingProperty { get; set; }

    public void ApplyBindings()
    {
      try
      {
        IEnumerable<IOperation> operations = null;
        switch (BindingScope)
        {
          case BindingScope.None:
            break;
          case BindingScope.Class:
            {
              operations = Structure.Operations.Cast<IOperation>().Where(x => TestBaseClassName(x, BindingTarget)).Union(
                Structure.ResultSets.Cast<IOperation>().Where(x => TestBaseClassName(x, BindingTarget))).Union(
                Structure.Schemas.Cast<IOperation>().Where(x => TestBaseClassName(x, BindingTarget)));              
            }
            break;
          case BindingScope.Object:
            {
              operations = Structure.Operations.Cast<IOperation>().Where(x => x.Name == BindingTarget).Union(
                Structure.ResultSets.Cast<IOperation>().Where(x => x.Name == BindingTarget)).Union(
                Structure.Schemas.Cast<IOperation>().Where(x => x.Name == BindingTarget)); 
            }
            break;
        }

        if (operations != null)
        {
          foreach (IOperation oper in operations)
          {
            PropertyInfo pi = oper.GetType().GetProperty(BindingProperty);
            if (pi != null)
            {
              pi.SetValue(oper, Convert.ChangeType(this.RawValue, pi.PropertyType), null);
              Structure.AddToLog(String.Format("Binding => Valor da propriedade {0} da variável {1} setado para {2} ({3})",
                BindingProperty, oper.Name, RawValue, pi.PropertyType), this);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Structure.AddToLog(this.Name, ex, this);
      }

    }


    private bool TestBaseClassName(IOperation oper, string baseClassName)
    {
      Type type = oper.GetType();

      while(type.Name != "Object")
      {
        if (type.Name == baseClassName)
          return true;
        else
          type = type.BaseType;
      }

      return false;


    }
  }

  public enum BindingScope
  {
    None,
    Class,
    Object
  }
}
