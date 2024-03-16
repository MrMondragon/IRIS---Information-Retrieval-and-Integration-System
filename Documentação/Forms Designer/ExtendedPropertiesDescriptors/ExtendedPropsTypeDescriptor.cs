using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace WindowsFormsApplication4
{
  public class ExtendedPropsTypeDescriptor : CustomTypeDescriptor
  {
    public ExtendedPropsTypeDescriptor(ICustomTypeDescriptor parent, string extendedPropsName, Dictionary<string, CustomPropsDescriptor> properties)
      : base(parent)
    {
      this.extendedPropsName = extendedPropsName;
      this.properties = properties;
    }

    private string extendedPropsName;
    private Dictionary<string, CustomPropsDescriptor> properties;

    public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
      return GetProperties();
    }
    
    public override PropertyDescriptorCollection GetProperties()
    {
      // Enumerate the original set of properties and create our new set with it
      PropertyDescriptorCollection originalProperties = base.GetProperties();
      List<PropertyDescriptor> newProperties = new List<PropertyDescriptor>();
      foreach (PropertyDescriptor pd in originalProperties)
      {
        newProperties.Add(pd);
      }

      if (properties != null)
      {
        foreach (KeyValuePair<string, CustomPropsDescriptor> kvp in properties)
        {
          CustomPropsDescriptor prop = kvp.Value;
          PropertyDescriptor newProperty = new ExtendedPropsDescriptor(prop.Name, extendedPropsName, prop.PropertyType, prop.GetAttributes());
          newProperties.Add(newProperty);
        }
      }

      // Finally return the list
      return new PropertyDescriptorCollection(newProperties.ToArray(), true);
    }
  }
}
