using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Adapters.DesignSupport
{
  
  [AttributeUsage(System.AttributeTargets.Class)]
  public class DashAtributes : Attribute  
  {
    private string category;
    /// <summary>
    /// Nome de exibição para combo-boxes
    /// </summary>
    public string Category
    {
      get { return category; }
      set { category = value; }
    }

    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public DashAtributes(string aCategory, string aName)
    {
      Category = aCategory;
      Name = aName;
    }
  }
}
