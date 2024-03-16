using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;

namespace Iris.Runtime.Core.PropertyEditors.Interfaces
{
  public interface IScriptedObject
  {
    String Script { get; set;}
    String Language { get;}
    IStructure Structure { get;}
  }
}
