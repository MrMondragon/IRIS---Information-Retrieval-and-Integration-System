using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace WindowsFormsApplication4
{
  public class ExtendedPropsDescriptor: PropertyDescriptor
  {
    public ExtendedPropsDescriptor(string propName, string extendedPropsName, Type type, params Attribute[] attributes)
      : base(propName, attributes)
    {
      this.propName = propName;
      this.extendedPropsName = extendedPropsName;
      this.type = type;
    }

    private string propName;
    private string extendedPropsName;
    private Type type;

    protected IDictionary GetPropsDictionary(object instance)
    {
      return TypeDescriptor.GetProperties(instance)[extendedPropsName].GetValue(instance) as IDictionary;
    }

    public override bool CanResetValue(object component)
    {
      return true;
    }

    public override Type ComponentType
    {
      get { return type; }
    }

    public override object GetValue(object component)
    {
      IDictionary dictionary = GetPropsDictionary(component);
      
      if (!dictionary.Contains(propName))
        dictionary[propName] = null;

      return dictionary[propName];
    }

    public override bool IsReadOnly
    {
      get { return false; }
    }

    public override Type PropertyType
    {
      get { return typeof(string); }
    }

    public override void ResetValue(object component)
    { 
      SetValue(component, null );
    }

    public override void SetValue(object component, object value)
    {
      GetPropsDictionary(component)[propName] = value;
    }

    public override bool ShouldSerializeValue(object component)
    {
      return false;
    }
  }
}
