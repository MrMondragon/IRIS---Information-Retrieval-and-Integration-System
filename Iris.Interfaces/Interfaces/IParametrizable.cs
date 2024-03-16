using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Interfaces
{
  public interface IParametrizable
  {
    void Parametrize(IDynamicParams param);
  }
}
