using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Designer.Loader
{
  public class Category: IComparable<Category>
  {
    public Category(string aName)
    {
      Name = aName;
      types = new List<Type>();
    }

    public override string ToString()
    {
      return Name;
    }

    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    private List<Type> types;

    public List<Type> Types
    {
      get { return types; }
    }

    #region IComparable<Category> Members

    public int CompareTo(Category other)
    {
      return String.Compare(other.Name, this.Name);
    }

    #endregion
  }

  public class CompTypes : Comparer<Type>
  {

    public override int Compare(Type x, Type y)
    {
      string xName = OperationLoader.GetAttribute(x).Name;
      string yName = OperationLoader.GetAttribute(y).Name;

      return String.Compare(yName, xName);
    }
  }
}
