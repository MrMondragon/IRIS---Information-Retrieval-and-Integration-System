using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Core.Expressions;

namespace Iris.Runtime.Core.Iris.ExpressionEditor
{
  public partial class ExpressionEditorControl : UserControl
  {
    public ExpressionEditorControl()
    {
      InitializeComponent();
      int idx = 1;
      CreateNode(idx);
      parser = new ExprTreeParser();
      sqlParser = new SqlParser();
    }

    ExprTreeParser parser;
    SqlParser sqlParser;

    #region Node Manipulation

    private void CreateNode(int nodeType)
    {
      Operation op = new Operation(null, null, null, Operator.Nenhum);
      XNode baseNode = new XNode(op, LogicOperator.AND, false);
      SetNodeType(nodeType, baseNode);
      tvExpressions.Nodes.Add(baseNode);
      tvExpressions.SelectedNode = baseNode;
    }

    private static void SetNodeType(int nodeType, TreeNode baseNode)
    {
      baseNode.ImageIndex = nodeType;
      baseNode.SelectedImageIndex = nodeType;
    }

    private void tvExpressions_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (e.Node != null)
      {
        if(e.Node is XNode)
          ppgExpressions.SelectedObject = ((XNode)e.Node).Opertn;
        
        int idx = e.Node.ImageIndex;

        switch (e.Node.ImageIndex)
        {
          case 0:
            {
              rbAnd.Checked = false;
              rbOr.Checked = false;
              rbNot.Checked = false;
            }
            break;
          case 1:
            //AND
            rbAnd.Checked = true;
            break;
          case 2:
            //OR
            rbOr.Checked = true;
            break;
          case 3:
            //Not
            rbNot.Checked = true;
            break;
        }

        SetNodeType(idx, e.Node);
      }
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
      CreateNode(1);
      RefreshBaseNodes(tvExpressions.Nodes);
      SetText();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      tvExpressions.Nodes.Remove(tvExpressions.SelectedNode);
      RefreshBaseNodes(tvExpressions.Nodes);
      SetText();
    }

    private void btnMoveDown_Click(object sender, EventArgs e)
    {
      MoveNodeUpDown(1);
      SetText();
    }

    private void btnMoveUp_Click(object sender, EventArgs e)
    {
      MoveNodeUpDown(-1);
      SetText();
    }

    private void MoveNodeUpDown(int direction)
    {
      TreeNode node = tvExpressions.SelectedNode;

      TreeNodeCollection nodes;
      if (node.Parent == null)
        nodes = tvExpressions.Nodes;
      else
        nodes = node.Parent.Nodes;

      int idx = nodes.IndexOf(node);
      if (((idx > 0) && (direction == -1)) || ((idx < (nodes.Count - 1)) && (direction == 1)))
      {
        TreeNode node2 = nodes[idx + direction];
        nodes.Remove(node);
        nodes.Remove(node2);
        nodes.Insert(idx + direction, node2);
        nodes.Insert(idx + direction, node);
        tvExpressions.SelectedNode = node;
        RefreshBaseNodes(tvExpressions.Nodes);
      }
    }

    private void btnIndent_Click(object sender, EventArgs e)
    {
      TreeNode node = tvExpressions.SelectedNode;

      TreeNodeCollection nodes;
      if (node.Parent == null)
        nodes = tvExpressions.Nodes;
      else
        nodes = node.Parent.Nodes;

      int idx = nodes.IndexOf(node) - 1;
      if (idx != -1)
      {
        TreeNode newParent = nodes[idx];
        nodes.Remove(node);
        newParent.Nodes.Add(node);
        newParent.Expand();
        tvExpressions.SelectedNode = node;
        RefreshBaseNodes(tvExpressions.Nodes);
      }
      SetText();
    }

    private void btnOutDent_Click(object sender, EventArgs e)
    {
      TreeNode node = tvExpressions.SelectedNode;

      if (node.Parent != null)
      {
        TreeNode parent = node.Parent;

        TreeNodeCollection nodes;
        if (parent.Parent == null)
          nodes = tvExpressions.Nodes;
        else
          nodes = parent.Parent.Nodes;

        int idx = nodes.IndexOf(parent) + 1;
        nodes.Remove(node);

        if (idx >= nodes.Count)
          nodes.Add(node);
        else
          nodes.Insert(idx, node);
        tvExpressions.SelectedNode = node;
        RefreshBaseNodes(tvExpressions.Nodes);
      }
      SetText();
    }

    private void rbAnd_CheckedChanged(object sender, EventArgs e)
    {
      SetNodeType(1, tvExpressions.SelectedNode);
      ((XNode)tvExpressions.SelectedNode).Oprtr = LogicOperator.AND;
      ((XNode)tvExpressions.SelectedNode).Negate = false;
    }

    private void rbOr_CheckedChanged(object sender, EventArgs e)
    {
      SetNodeType(2, tvExpressions.SelectedNode);
      ((XNode)tvExpressions.SelectedNode).Oprtr = LogicOperator.OR;
      ((XNode)tvExpressions.SelectedNode).Negate = false;
    }

    private void rbNot_CheckedChanged(object sender, EventArgs e)
    {
      SetNodeType(3, tvExpressions.SelectedNode);
      ((XNode)tvExpressions.SelectedNode).Negate = true;
    }

    #endregion

    private void ppgExpressions_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      tvExpressions.SelectedNode.Text = ((XNode)tvExpressions.SelectedNode).Opertn.GetText();
      SetText();
    }

    #region Criação de Expressões
    public LogicExpression CreateExpression(TreeNodeCollection nodes)
    {
      List<LogicExpression> list = new List<LogicExpression>();
      List<LogicOperator> opList = new List<LogicOperator>();

      for (int i = 0; i < nodes.Count; i++)
      {
        list.Add(CreateExpression(nodes[i]));
        opList.Add(GetOperatorFromNode(nodes[i]));
      }

      LogicExpression X = list[0];
      list.RemoveAt(0);
      opList.RemoveAt(0);
      while (list.Count > 0)
      {
        LogicExpression x1 = list[0];
        LogicOperator op1 = opList[0];
        list.RemoveAt(0);
        opList.RemoveAt(0);
        X = new LogicExpression(X, x1, op1, false,false);
      }
      return X;
    }

    public LogicExpression CreateExpression(TreeNode node)
    {
      XNode xNode = (XNode)node;
      Operation operation = xNode.Opertn;
      operation.Parenthesis = false;
      LogicOperator oper = LogicOperator.None;
      LogicExpression exp = null;
      LogicExpression result = new LogicExpression(operation, exp, oper, false, false);
      result.Negate = xNode.Negate;
      if (node.Nodes.Count > 0)
      {
        exp = CreateExpression(node.Nodes);
        if ((!string.IsNullOrEmpty(result.GetText())) &&(result.GetText().ToUpper().Trim() != "NOT"))
        {
          XNode x2 = (XNode)node.Nodes[0];
          oper = x2.Oprtr;
          result = new LogicExpression(result, exp, oper, false, true);
        }
        else result = new LogicExpression(exp, null, oper, result.Negate, false);
      }

      return result;
    }

    private static LogicOperator GetOperatorFromNode(TreeNode node)
    {
      return ((XNode)node).Oprtr;
    }

    #endregion

    public Expression Expression
    {
      get
      {
        return (Expression)sqlParser.Parse(tbExpression.Text);
      }
      set
      {
        if (value != null)
        {
          tbExpression.Text = value.GetText();
        }
        else
        {
          tbExpression.Text = "";
        }
        SetTree();
      }
    }

    private void btnTree_Click(object sender, EventArgs e)
    {
      SetTree();
    }

    private void SetTree()
    {
      tvExpressions.Nodes.Clear();
      if (!string.IsNullOrEmpty(tbExpression.Text))
      {
        Expression X = null;
        try
        {
          X = (Expression)parser.Parse(tbExpression.Text, tvExpressions.Nodes);
        }
        catch (ParserException ex)
        {
          tbExpression.Focus();
          tbExpression.Select(ex.Token.Location.Position, ex.Token.Text.Length);
          MessageBox.Show(ex.Message);
        }
        if (tvExpressions.Nodes.Count > 0)
          tvExpressions.Nodes[0].ExpandAll();
        RefreshBaseNodes(tvExpressions.Nodes);
      }
    }

    private void btnText_Click(object sender, EventArgs e)
    {
      SetText();
    }

    private void SetText()
    {
      tbExpression.Text = CreateExpression(tvExpressions.Nodes).GetText();
    }


    private void btnClear_Click(object sender, EventArgs e)
    {
      tvExpressions.Nodes.Clear();
      tbExpression.Text = "";
    }


    private int GetIndexFromOperator(LogicOperator oper)
    {
      switch (oper)
      {
        case LogicOperator.AND:
          return 1;
        case LogicOperator.OR:
          return 2;
        default:
          return 0;
      }
    }
    private void RefreshBaseNodes(TreeNodeCollection nodes)
    {
      foreach (TreeNode node in nodes)
      {
        if (((XNode)node).Negate)
          SetNodeType(3, node);
        else
        {
          SetNodeType(GetIndexFromOperator(((XNode)node).Oprtr), node);

          if (node.Index == 0)
            SetNodeType(0, node);
        }
        RefreshBaseNodes(node.Nodes);           
      }
    }

    private void tbExpression_Validated(object sender, EventArgs e)
    {
      SetTree();
    }


  }
}
