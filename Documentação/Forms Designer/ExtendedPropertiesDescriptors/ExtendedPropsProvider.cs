using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace WindowsFormsApplication4
{
  public class ExtendedPropsProvider : TypeDescriptionProvider
  {
    public static void AddProvider(object instance, string extendedPropsName)
    {
      Dictionary<string, CustomPropsDescriptor> properties = GetCustomProperties(instance, extendedPropsName);
      AddProvider(instance.GetType(), extendedPropsName, properties);
    }

    public static void AddProvider(Type type, string extendedPropsName, Dictionary<string, CustomPropsDescriptor> properties)
    {
      ExtendedPropsProvider provider = new ExtendedPropsProvider(TypeDescriptor.GetProvider(type), extendedPropsName, properties);
      TypeDescriptor.AddProvider(provider, type);
      TypeDescriptor.Refresh(type);
    }

    public static Dictionary<string, CustomPropsDescriptor> GetCustomProperties(object instance, string extendedPropsName)
    {

      PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(instance);
      PropertyDescriptor pd = pdc[extendedPropsName];
      IDictionary dictionary = pd.GetValue(instance) as IDictionary;

      Dictionary<string, CustomPropsDescriptor> customProps = new Dictionary<string, CustomPropsDescriptor>();
      foreach (DictionaryEntry de in dictionary)
      {
        if (de.Key != null)
        {
          customProps[de.Key.ToString()] = new CustomPropsDescriptor(Convert.ToString(de.Key));
        }
      }
      return customProps;
    }

    private ExtendedPropsProvider(TypeDescriptionProvider parent, string extendedPropsName, Dictionary<string, CustomPropsDescriptor> properties)
      : base(parent)
    {
      this.extendedPropsName = extendedPropsName;
      this.properties = properties;
    }

    private string extendedPropsName;
    private Dictionary<string, CustomPropsDescriptor> properties;

    public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
    {
      ExtendedPropsTypeDescriptor descriptor = new ExtendedPropsTypeDescriptor(base.GetTypeDescriptor(objectType, instance), extendedPropsName, properties);
      return descriptor;
    }
  }
}
