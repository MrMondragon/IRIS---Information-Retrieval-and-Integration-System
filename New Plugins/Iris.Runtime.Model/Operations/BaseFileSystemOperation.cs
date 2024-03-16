using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;

namespace Iris.Runtime.Model.Operations.FileSystemOperations
{
  [Serializable]
  public abstract class BaseFileSystemOperation : Operation
  {
    public BaseFileSystemOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Filename 1", "Filename 2");
    }

    private string filename1;

    public virtual string Filename1
    {
      get 
      { 
        Operation oper = GetInput(0);
        if(oper != null)
        {
          ScalarVar var = oper.EntityValue as ScalarVar;
          if (var != null)
            return Convert.ToString(var.RawValue);
          else
            return string.Empty; 
        }
        else
          return filename1; 
      }
      set { filename1 = value; }
    }

    private string filename2;

    public virtual string Filename2
    {
      get
      {
        if (InputCount > 1)
        {
          Operation oper = GetInput(1);
          if (oper != null)
          {
            ScalarVar var = oper.EntityValue as ScalarVar;
            if (var != null)
              return Convert.ToString(var.RawValue);
            else
              return string.Empty;
          }
        }

        return filename2;
      }
      set { filename2 = value; }
    }


  }
}
