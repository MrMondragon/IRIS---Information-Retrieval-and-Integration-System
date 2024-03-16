using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Core.Expressions;

namespace Iris.Runtime.Core.Iris.ExpressionEditor
{
  public class XNode: TreeNode
  {
    public XNode(Operation aOperation, LogicOperator aOperator, bool not)
    {
      opertn = aOperation;
      oprtr = aOperator;
      RefreshText();
    }

    private bool negate;

    public bool Negate
    {
      get { return negate; }
      set { negate = value; }
    }

    private LogicOperator oprtr;

    public LogicOperator Oprtr
    {
      get { return oprtr; }
      set { oprtr = value; }
    }

    public void RefreshText()
    {
      if(Opertn != null)
        this.Text = Opertn.ToString();
    }

    private Operation opertn;

    public Operation Opertn
    {
      get { return opertn; }
      set { opertn = value; }
    }

  }
}
