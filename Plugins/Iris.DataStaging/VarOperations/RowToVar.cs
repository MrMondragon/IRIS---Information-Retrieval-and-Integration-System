using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Iris.PropertyEditors.PropertyEditors;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Operações de Variável", "Registro para Variável")]
  public class RowToVar : BaseVarOperation, IRowToVar
  {
    public RowToVar(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      
    }

    private int rowNumber;
    [Browsable(true), Category("Entrada"), DisplayName("Registro"), Description("Numero do registro de entrada")]
    public int RowNumber
    {
      get { return rowNumber; }
      set { rowNumber = value; }
    }

    private string fieldName;
    [Browsable(true), Category("Entrada"), DisplayName("Campo"), Description("Nome do campo de entrada")]
    [Editor(typeof(RowToVarFieldEditor), typeof(UITypeEditor))]
    public string FieldName
    {
      get { return fieldName; }
      set { fieldName = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    IResultSet IRowToVar.Entrada
    {
      get
      {
        return GetInput(0) as IResultSet;
      }
    }

    protected override IEntity doExecute()
    {
      ScalarVar  saida = GetOutput(0) as ScalarVar;
      ResultSet entrada = null;
      if(GetInput(0) != null)
        entrada = GetInput(0).EntityValue as ResultSet;

      if (entrada == null)
        throw new Exception("Entrada inválida");

      if (saida == null)
        throw new Exception("Saída inválida");

      if (string.IsNullOrEmpty(FieldName))
        throw new Exception("Nome do campo não informado");


      ScalarVar registro = null;
      if(GetInput(1) != null)
        registro = GetInput(1).EntityValue as ScalarVar;

      int rowIdx;

      if(registro == null)
        rowIdx = RowNumber;
      else
        rowIdx = Convert.ToInt32(registro.RawValue);


      saida.RawValue = entrada.Table.Rows[rowIdx][FieldName];

      return saida;
    }
  }
}
