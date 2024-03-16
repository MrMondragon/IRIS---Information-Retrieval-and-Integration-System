using System;
using System.Collections.Generic;
using System.Text;
using Hermes.Model;

namespace Hermes.Adapters
{
  public abstract class GenericControlAdapter<T>
  {
    [NonSerialized]
    private T control;
    public GenericControlAdapter(BoardView _view)
    {
      view = _view;
      properties = new ControlProperties();
    }

    private BoardView view;

    public T Control
    {
      get
      {
        if (control == null)
          control = CreateControl();
        return control; 
      }
      set { control = value; }
    }

    protected void StoreProperties()
    {
      doStoreProperties();
      GenerateCode();
    }

    protected abstract void doStoreProperties();
    protected abstract void GenerateCode();

    public abstract void RestoreProperties();

    protected T CreateControl()
    {
      T ctrl = doCreateControl();
      RestoreProperties();
      return ctrl;
    }

    protected abstract T doCreateControl();

    private Hermes.Model.ControlProperties properties;

    public Hermes.Model.ControlProperties Properties
    {
      get 
      {
        StoreProperties();
        return properties; 
      }
      set { properties = value; }
    }
  }
}
