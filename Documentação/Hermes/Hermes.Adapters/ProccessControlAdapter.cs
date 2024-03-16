using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Adapters
{
  public class ProccessControlAdapter<T> : GenericControlAdapter<T>
  {
    private Iris.Interfaces.IOperation operation;

    public Iris.Interfaces.IOperation Operation
    {
      get { return operation; }
      set { operation = value; }
    }

    public ProccessControlAdapter(BoardView _view): base(_view)
    {
    }

    public Object Execute()
    {
      throw new System.NotImplementedException();
    }
  }
}
