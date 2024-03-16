using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Model.BaseObjects
{
  [Serializable]
  public class IrisList<T> : List<T>
  {
    private Predicate<T> ByName(string nome)
    {
      return delegate(T item)
        {
          return item.ToString() == nome;
        };
    }

    public T FindByName(string nome)
    {
      return this.Find(this.ByName(nome));
    }

    private string name;

    public string Name
    {
      get { return name; }
    }

    public IrisList(string aName)
    {
      name = aName;
    }
  }
}
