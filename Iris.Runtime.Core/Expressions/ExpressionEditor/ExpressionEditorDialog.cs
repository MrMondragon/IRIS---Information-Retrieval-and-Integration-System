using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Core.Expressions;
using Iris.Interfaces;
using Iris.PropertyEditors.Dialogs;

namespace Iris.Runtime.Core.Iris.ExpressionEditor
{
  public partial class ExpressionEditorDialog : BaseDialog
  {
    public ExpressionEditorDialog()
    {
      InitializeComponent();
    }

    public Expression Expression
    {
      get
      {
        return ExpressionEditorControl.Expression;
      }
      set
      {
        ExpressionEditorControl.Expression = (Expression)value;
      }
    }

    public DialogResult Execute(Expression aExpression)
    {
      Expression = (Expression)aExpression;
      return this.ShowDialog();
    }
  }
}