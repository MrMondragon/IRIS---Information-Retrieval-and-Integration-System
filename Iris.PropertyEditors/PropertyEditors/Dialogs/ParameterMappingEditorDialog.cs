using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;
using Iris.Runtime.NetworkOperations;
using Iris.Interfaces;

namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  public partial class ParameterMappingEditorDialog : BaseDialog
  {
    public ParameterMappingEditorDialog()
    {
      InitializeComponent();
    }

    public List<IParameterMapping> ParameterMappings
    {
      set
      {
        foreach (IParameterMapping mapping in value)
        {
          tvwMapping.Nodes.Add(CreateNode(mapping));          
        }
      }
      get
      {
        return tvwMapping.Nodes.Cast<TreeNode>().Select(x => x.Tag).Cast<IParameterMapping>().ToList();
      }
    }

    public void InitializeFields(DataTable table)
    {
      cbxFields.Items.Clear();
      foreach (DataColumn column in table.Columns)
      {
        cbxFields.Items.Add(column.ColumnName);
      }
    }


    private TreeNode CreateNode(IParameterMapping mapping)
    {
      int imgIndex;
      if (mapping.ParamType.IsPrimitiveType())
        imgIndex = 0;
      else
        imgIndex = 1;

      TreeNode node = new TreeNode(mapping.ToString(), imgIndex, imgIndex);
      node.Tag = mapping;

      if (mapping.ChildMappings.Count > 0)
      {
        foreach (IParameterMapping childMap in mapping.ChildMappings)
        {
          node.Nodes.Add(CreateNode(childMap));
        }
      }

      return node;
    }



    private bool updating;
    private IParameterMapping activeMapping;
    private TreeNode activeNode;

    private void SetMappingControls(IParameterMapping param)
    {
      activeMapping = param;
      updating = true;
      txtParametro.Text = param.ParamName;
      txtTipo.Text = param.ParamType.ToString();
      cbxFields.SelectedItem = param.SourceField;
      updating = false;        
    }

    private void tvwMapping_AfterSelect(object sender, TreeViewEventArgs e)
    {
      activeNode = e.Node;
      SetMappingControls((IParameterMapping)e.Node.Tag);
    }

    private void cbxFields_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (cbxFields.Text != activeMapping.SourceField)
      {
        activeMapping.SourceField = cbxFields.Text;
        activeNode.Text = activeMapping.ToString();
      }
    }


  }
}
