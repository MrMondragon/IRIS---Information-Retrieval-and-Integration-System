using System;
using Iris.Interfaces;
namespace Iris.Runtime.Core.Expressions
{
  public interface IExpression
  {
    string GetEvalText(IStructure structure);
    bool Parenthesis { get; set; }
  }
}
