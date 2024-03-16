using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.ComponentModel;
using System.Data;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Opera��es de ResultSet", "Clear Table")]
  public class ClearTable : ResultSetOperation
  {
    public ClearTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    [Description("Altera o comportamento da opera��o para aplicar uma exclus�o l�gica, ao inv�s de limpar fisicamente a tabela.")]
    public bool WorkAsDelte { get; set; }
    [Description("S� funciona se WorkAsDelete for igual a true. Filtra quais os dados que devem ser exclu�dos.")]
    public string Filter { get; set; }

    protected override IEntity doExecute()
    {

      if (WorkAsDelte)
      {
        DataTable table = Entrada.Table;

        DataRow[] rows;
        if (!string.IsNullOrEmpty(Filter))
          rows = table.Select(Filter);
        else
          rows = table.Select();


        if (rows.Length != 0)
        {
          for (int i = 0; i < rows.Length; i++)
          {
            rows[i].Delete();
          }
          Structure.AddToLog(string.Format("{0} registros exclu�dos", rows.Length), this);
        }
      }
      else
      {
        Entrada.Clear();

        if (Structure.CollectOnClear)
          GC.Collect();
      }
      return (IEntity)Entrada;
    }
  }
}
