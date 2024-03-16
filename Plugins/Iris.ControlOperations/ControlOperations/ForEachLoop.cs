using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.PropertyEditors.Interfaces;
using System.Data;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de Controle", "For Each Loop")]
  public class ForEachLoop : Loop, IDynamicIOOperation, Iris.Runtime.Model.Operations.ControlOperations.IForEachLoop
  {
    public ForEachLoop(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataTable Table
    {
      get
      {
        if (GetInput(0) != null)
        {
          ResultSet rs = GetInput(0).EntityValue as ResultSet;
          if (rs != null)
          {
            return rs.Table;
          }
        }
        throw new Exception("Entrada inválida");
      }
    }

    private List<string> fields;
    [Editor(typeof(ForeachFieldsEditor), typeof(UITypeEditor))]
    public List<string> Fields
    {
      get
      {
        if (fields == null)
          fields = new List<string>();

        return fields;
      }
      set
      {
        fields = value;
        RefreshIO();
      }
    }

    protected override IEntity doExecute()
    {

      IOperation opSource = GetInput(0);
      if (!(opSource.EntityValue is ResultSet))
        throw new Exception("Objeto de entrada não é um ResultSet");
      if (opSource == null)
        throw new Exception("Não existe ResultSet de entrada");
      ResultSet source = (ResultSet)opSource.EntityValue;

      string sort = "";
      string filter = "";
      if (source.HasView())
      {
        sort = source.View.Sort;
        filter = source.View.RowFilter;
      }

      DataRow[] rows = source.Table.Select(filter, sort);

      for (int j = 0; j < rows.Length; j++)
      {
        DataRow row = rows[j];
        for (int i = 0; i < Fields.Count; i++)
        {
          ScalarVar var = GetOutput(Fields[i]) as ScalarVar;
          if (var == null)
            throw new Exception(String.Format("Entrada <{0}> inválida"));

          var.RawValue = row[Fields[i]];
        }

        base.doExecute();
      }

      return null;
    }

    #region IDynamicIOOperation Members
    public override void SetInput(int idx, IOperation input)
    {
      IOperation oldInput = GetInput(idx);

      base.SetInput(idx, input);

      if ((idx == 0) && (oldInput != input))
      {
        Fields = new List<string>();
      }
    }

    protected bool inRefresh;

    public void RefreshIO()
    {
      if (!inRefresh)
      {
        inRefresh = true;
        try
        {
          if (BeforeRefreshIO != null)
            BeforeRefreshIO(this, new EventArgs());

          doRefreshIO();

          if (AfterRefreshIO != null)
            AfterRefreshIO(this, new EventArgs());
        }
        finally
        {
          inRefresh = false;
        }
      }
    }

    protected void doRefreshIO()
    {
      List<string> outputList = new List<string>();
      outputList.Add("Loop");
      outputList.AddRange(Fields);
      SetOutputs(outputList.ToArray());
    }

    [field: NonSerialized()]
    public event EventHandler BeforeRefreshIO;
    [field: NonSerialized()]
    public event EventHandler AfterRefreshIO;
    #endregion
  }
}
