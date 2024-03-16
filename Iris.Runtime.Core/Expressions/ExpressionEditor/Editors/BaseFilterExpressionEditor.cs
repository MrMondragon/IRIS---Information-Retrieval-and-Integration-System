using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Core.Iris.ExpressionEditor;
using System.Windows.Forms;
using Iris.PropertyEditors;
using Iris.Interfaces;
using Iris.Runtime.Core.Expressions;

namespace Iris.ExpressionEditor.Editors
{
  public class BaseFilterExpressionEditor : BaseDialogEditor<IResultSetOperation>
  {
    protected override object GetValue(IResultSetOperation Instance)
    {
      if (Instance.InputFilter != null)
      {
        Instance.Filtro = null;
        MessageBox.Show("Impossível utilizar filtros de expressão em conjunto com filtro de dataset", "Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
      }
      else
      {
        ExpressionEditorDialog dlg = new ExpressionEditorDialog();
        dlg.Expression = (Expression)Instance.Filtro;
        if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          Instance.Filtro = dlg.Expression;
        }
      }
      return Instance.Filtro;
    }

  }
}
