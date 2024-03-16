using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Iris.Runtime.Model;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Designer.Dialogs
{
  public partial class SelectSchemasDialog : BaseDialog
  {
    public SelectSchemasDialog()
    {
      InitializeComponent();
    }

    public List<SchemaEntity> SelectSchemas(List<SchemaEntity> list)
    {
      for (int i = 0; i < list.Count; i++)
      {
        TreeNode node = new TreeNode(list[i].Name);
        node.Tag = list[i];
        tvwSchemas.Nodes.Add(node);
      }

      List<SchemaEntity> result = new List<SchemaEntity>();

      if (this.ShowDialog() == DialogResult.OK)
      {
        for (int i = 0; i < tvwSchemas.Nodes.Count; i++)
        {
          if (tvwSchemas.Nodes[i].Checked)
          {
            result.Add((SchemaEntity)tvwSchemas.Nodes[i].Tag);
          }
        }
      }
      return result;
    }

    public List<TextLine> SelectLines(List<SchemaEntity> list)
    {
      for (int i = 0; i < list.Count; i++)
      {
        if (list[i] is TextSchema)
        {
          TextSchema schema = (TextSchema)list[i];
          LoadLineNodes(schema.LineTypes, tvwSchemas.Nodes);
        }
      }

      List<TextLine> result = new List<TextLine>();
      if (this.ShowDialog() == DialogResult.OK)
      {
        for (int i = 0; i < tvwSchemas.Nodes.Count; i++)
        {
          AddCheckedNodes(result, tvwSchemas.Nodes);
        }
      }

      return result;
    }

    private void AddCheckedNodes(List<TextLine> result, TreeNodeCollection nodes)
    {
      for (int i = 0; i < nodes.Count; i++)
      {
        if ((nodes[i].Checked) && (!result.Contains((TextLine)nodes[i].Tag)))
          result.Add(nodes[i].Tag as TextLine);
        AddCheckedNodes(result, nodes[i].Nodes);
      }
    }

    private void LoadLineNodes(List<TextLine> list, TreeNodeCollection nodes)
    {
      for (int i = 0; i < list.Count; i++)
      {
        TreeNode lineNode = new TreeNode(list[i].Name);
        lineNode.Tag = list[i];
        nodes.Add(lineNode);
        LoadLineNodes(list[i].Details, lineNode.Nodes);
      }
    }

    private void btnTodos_Click(object sender, EventArgs e)
    {
      foreach (TreeNode node in tvwSchemas.Nodes)
      {
        CheckNodes(node, true);
      }
    }

    private void CheckNodes(TreeNode node, bool state)
    {
      node.Checked = state;
      foreach (TreeNode childNode in node.Nodes)
      {
        CheckNodes(childNode, state);
      }      
    }

    private void btnNenhum_Click(object sender, EventArgs e)
    {
      foreach (TreeNode node in tvwSchemas.Nodes)
      {
        CheckNodes(node, false);
      }
    }

    private void btnInvert_Click(object sender, EventArgs e)
    {
      foreach (TreeNode node in tvwSchemas.Nodes)
      {
        InvertNodes(node);
      }
    }

    private void InvertNodes(TreeNode node)
    {
      node.Checked = !node.Checked;
      foreach (TreeNode childNode in node.Nodes)
      {
        InvertNodes(childNode);
      }   
    }

  }
}