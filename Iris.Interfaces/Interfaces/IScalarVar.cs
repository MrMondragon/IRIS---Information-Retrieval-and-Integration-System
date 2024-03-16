using System;
using System.Collections.Generic;
namespace Iris.Interfaces
{
  public interface IScalarVar: IEntity
  {
    object RawValue { get; set; }
    Type DataType { get; set; }
    List<string> ValidValues{ get; set; }
  }
}
