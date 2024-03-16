using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using Iris.Interfaces;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using Iris.Runtime.Model.Entities;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Operações de Objeto", "Registro para Registro")]
  public class RowToRow : BaseVarOperation, IVarToRow, IRowToVar
  {
    public RowToRow(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Reg. In", "Reg. Out");
    }

    private int inRowNumber;
    [Browsable(true), Category("Entrada"), DisplayName("Registro"), Description("Numero do registro de entrada")]
    public int InRowNumber
    {
      get { return inRowNumber; }
      set { inRowNumber = value; }
    }

    private int outRowNumber;
    [Browsable(true), Category("Saída"), DisplayName("Registro"), Description("Numero do registro de saída")]
    public int OutRowNumber
    {
      get { return outRowNumber; }
      set { outRowNumber = value; }
    }

    private string outFieldName;
    [Browsable(true), Category("Saída"), DisplayName("Campo"), Description("Nome do campo de saída")]
    [Editor(typeof(VarToRowFieldEditor), typeof(UITypeEditor))]
    public string OutFieldName
    {
      get { return outFieldName; }
      set { outFieldName = value; }
    }

    private string inFieldName;
    [Browsable(true), Category("Entrada"), DisplayName("Campo"), Description("Nome do campo de entrada")]
    [Editor(typeof(RowToVarFieldEditor), typeof(UITypeEditor))]
    public string InFieldName
    {
      get { return inFieldName; }
      set { inFieldName = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    IResultSet IVarToRow.Saida
    {
      get
      {
        return GetOutput(0) as IResultSet;
      }
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
      ResultSet saida = null;
      if (GetOutput(0) != null)
        saida = GetOutput(0).EntityValue as ResultSet;
      
      ResultSet entrada = null;
      if (GetInput(0) != null)
        entrada = GetInput(0).EntityValue as ResultSet;

      if (entrada == null)
        throw new Exception("Entrada inválida");

      if (saida == null)
        throw new Exception("Saída inválida");

      ScalarVar registroIn = null;
      if (GetInput(1) != null)
        registroIn = GetInput(1).EntityValue as ScalarVar;

      int rowIdxIn;

      if (registroIn == null)
        rowIdxIn = InRowNumber;
      else
        rowIdxIn = Convert.ToInt32(registroIn.RawValue);


      ScalarVar registroOut = null;
      if (GetOutput(1) != null)
        registroOut = GetOutput(1).EntityValue as ScalarVar;

      int rowIdxOut;

      if (registroOut == null)
        rowIdxOut = OutRowNumber;
      else
        rowIdxOut = Convert.ToInt32(registroOut.RawValue);


      saida.Table.Rows[rowIdxIn][OutFieldName] = entrada.Table.Rows[rowIdxOut][OutFieldName];

      return saida;
    }


  }
}
