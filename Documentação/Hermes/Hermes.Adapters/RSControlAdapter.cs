using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Hermes.Adapters
{
  public class RSControlAdapter<T> : BaseDataControlAdapter<T>
  {
    private Iris.Interfaces.IResultSet resultSet;
    private Iris.Runtime.Core.Expressions.IExpression filter;

    public Iris.Runtime.Core.Expressions.IExpression Filter
    {
      get { return filter; }
      set { filter = value; }
    }

    public Iris.Interfaces.IResultSet ResultSet
    {
      get { return resultSet; }
      set { resultSet = value; }
    }
  
    public RSControlAdapter(BoardView _view)
      : base(_view)
    {
    }

    public DataTable GetData()
    {
      throw new System.NotImplementedException();
    }
  }
}
