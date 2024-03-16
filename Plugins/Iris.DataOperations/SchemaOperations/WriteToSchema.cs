using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.IO;

namespace Iris.Runtime.Model.Operations.SchemaOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Gravação de Schema")]
  public class WriteToSchema : BaseSchemaOperation
  {
    public WriteToSchema(Structure aStructure, string aName)
      : base(aStructure, aName)
    { 
    }

    protected override void doRefreshIO()
    {
      Dictionary<string, IOperation> oldInputs = new Dictionary<string, IOperation>();
      for (int i = 0; i < InputCount; i++)
      {
        oldInputs[GetInputName(i)] = GetInput(i);
      }

      SetInputs(GetIOList(true));

      for (int i = 0; i < InputCount; i++)
      {
        string inputName = GetInputName(i);
        if (oldInputs.ContainsKey(inputName))
          SetInput(inputName, oldInputs[inputName]);
      }
    }

    protected override IEntity doExecute()
    {
      base.doExecute();
      
      IrisList<ResultSet> list = GetRSList(true, 3);
      IEntity schema = GetInput("Schema").EntityValue;
      if (!(schema is SchemaEntity))
        throw new Exception("Operação inválida na entrada de Schema");
      ((SchemaEntity)schema).WriteFromTables(list);

      AfterExecute();
      
      return schema;
    }

    protected override void ConfigOperationLog(out string action, out IrisList<ResultSet> list)
    {
      action = "Arquivo gravado em: ";
      list = GetRSList(true, 3);
    }
  }
}
