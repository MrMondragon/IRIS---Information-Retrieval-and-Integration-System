using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.Expressions;

namespace Iris.Engine.QueryObjects.DeclareItems
{
  public class VariableDeclaration: StatementPart
  {
    public string TypeName
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public int? Size
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public int? Precision
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public string VarName
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public EngineExpression DefaultValue
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }
  
    public override string GetText()
    {
      throw new NotImplementedException();
    }
  }
}
