using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Model.DisignSuport
{
  [AttributeUsage(System.AttributeTargets.Class)]
  public class OperationCategory: Attribute
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

    public OperationCategory(string aCategory, string aName)
    {
      Category = aCategory;
      Name = aName;
    }

  }
}
