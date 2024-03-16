using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Core.PropertyEditors.Controls
{
  public class ListEventArgs<T>: EventArgs
  {
    public ListEventArgs(List<T> _lista, T _item, T _oldItem)
    {
      List = _lista;
      Item = _item;
      OldItem = _oldItem;
    }

    private List<T> list;

    public List<T> List
    {
      get { return list; }
      set { list = value; }
    }

    private T item;

    public T Item
    {
      get { return item; }
      set { item = value; }
    }

    private T oldItem;

    public T OldItem
    {
      get { return oldItem; }
      set { oldItem = value; }
    }

  }
}
