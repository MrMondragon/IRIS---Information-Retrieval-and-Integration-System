using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;

namespace Iris.Runtime.Model.Operations.SchemaOperations
{
  [Serializable]
  [OperationCategory("Opera��es de ResultSet", "Leitura de Schema")]
  public class ReadFromSchema : BaseSchemaOperation
  {
    public ReadFromSchema(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      End = -1;
      SetInputs("Schema", "Filename", "Text","In�cio", "T�rmino");
    }

    protected override void doRefreshIO()
    {
      List<string> list = new List<string>();
      list.AddRange(GetIOList(false));
      list.Add("Conclu�do");    
      SetOutputs(list.ToArray());
    }

    protected override IEntity doExecute()
    {
      base.doExecute();

      if (GetInput("In�cio") != null)
        Start = Convert.ToInt32(GetValue("In�cio"));
      if (GetInput("T�rmino") != null)
        End = Convert.ToInt32(GetValue("T�rmino"));

      IrisList<ResultSet> list = GetRSList(false, 0);

      IEntity schema = GetInput("Schema").EntityValue;
      if ((!(schema is SchemaEntity)) || (schema == null))
        throw new Exception("Opera��o inv�lida na entrada de Schema");

      ((SchemaEntity)schema).ReadToTables(list, Start, End);

      SetValue("Conclu�do", ((SchemaEntity)schema).PassedTheEnd);

      AfterExecute();

      return schema;
    }

    [DisplayName("In�cio"), Description("Primeira linha a ser lida do arquivo. 0 para ler a partir do in�cio")]
    public int Start { get; set; }
    [DisplayName("T�rmino"), Description("�ltima linha a ser lida do arquivo. -1 para ler o arquivo inteiro")]
    public int End { get; set; }

    protected override void ConfigOperationLog(out string action, out IrisList<ResultSet> list)
    {
      action = "Arquivo lido de: ";
      list = GetRSList(false, 0);
    }
  }
}
