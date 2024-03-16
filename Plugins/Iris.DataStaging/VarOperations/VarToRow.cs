using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors.PropertyEditors;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Opera��es de Vari�vel", "Vari�vel para Registro")]
  public class VarToRow : BaseVarOperation, IVarToRow
  {
    public VarToRow(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      
    }

    private int rowNumber;
    [Browsable(true), Category("Sa�da"), DisplayName("Registro"), Description("Numero do registro de sa�da")]
    public int RowNumber
    {
      get { return rowNumber; }
      set { rowNumber = value; }
    }

    private string fieldName;
    [Browsable(true), Category("Sa�da"), DisplayName("Campo"), Description("Nome do campo de sa�da")]
    [Editor(typeof(VarToRowFieldEditor), typeof(UITypeEditor))]
    public string FieldName
    {
      get { return fieldName; }
      set { fieldName = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    IResultSet IVarToRow.Saida
    {
      get
      {
        return GetOutput(0) as IResultSet;
      }
    }

    protected override IEntity doExecute()
    {
      ScalarVar entrada = GetInput(0) as ScalarVar;
      ResultSet saida = null;
      if (GetOutput(0) != null)
        saida = GetOutput(0).EntityValue as ResultSet;

      if (entrada == null)
        throw new Exception("Entrada inv�lida");

      if (saida == null)
        throw new Exception("Sa�da inv�lida");

      ScalarVar registro = null;
      if (GetInput(1) != null)
        registro = GetInput(1).EntityValue as ScalarVar;

      int rowIdx;

      if (registro == null)
        rowIdx = RowNumber;
      else
        rowIdx = Convert.ToInt32(registro.RawValue);

      saida.Table.Rows[rowIdx][FieldName] = entrada.RawValue;

      return saida;
    }

  }
}
