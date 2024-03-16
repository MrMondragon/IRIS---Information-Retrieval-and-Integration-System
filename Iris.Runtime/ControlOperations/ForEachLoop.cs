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
  public class ForEachLoop : Loop
  {
    public ForEachLoop(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      SetOutputs("Loop", "Saída");
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataTable Table
    {
      get
      {
        if (GetInput("Entrada") != null)
        {
          ResultSet rs = GetInput("Entrada").EntityValue as ResultSet;
          if (rs != null)
          {
            return rs.Table;
          }
        }
        throw new Exception("Entrada inválida");
      }
    }


    protected override IEntity doExecute()
    {

      IOperation opSource = GetInput("Entrada");
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

        ScalarVar var = GetOutput("Saída") as ScalarVar;
        if (row.ItemArray.Length == 1)
          var.RawValue = row[0];
        else
          var.RawValue = row;

        base.doExecute();
      }

      return null;
    }

  }
}
