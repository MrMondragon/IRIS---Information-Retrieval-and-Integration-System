using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.BaseObjects;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Designer
{
  public partial class CreateTableDialog : BaseDialog
  {
    public CreateTableDialog()
    {
      InitializeComponent();
    }

    protected Structure structure;
    protected DynConnection connection;

    public DialogResult Execute(DynConnection _connection, Structure _structure)
    {
      structure = _structure;
      SetupTables(_connection);
      txtBusca.Select();
      
      DialogResult result = this.ShowDialog();

      if (result == DialogResult.OK)
      {
        for (int i = 0; i < treeView.Nodes.Count; i++)
        {
          TreeNode node = treeView.Nodes[i];
          if(node.Checked)
            CreateTable(node);
        }
      }

      return result;
    }

    protected void SetupTables(DynConnection _connection)
    {
      connection = _connection;

      treeView.Nodes.Clear();

      int ct = 3;
      if (connection.Name.Length < 3)
        ct = connection.Name.Length;


      txtPrefix.Text = connection.Name.Substring(0, ct).ToLower();

      DataTable tables = _connection.GetSchema();


      DataView view = new DataView(tables);
      string tableNameField = view.Table.Columns.Contains("Table_Name") ? "Table_Name" : "TableName";

      view.Sort = tableNameField;

      for (int i = 0; i < view.Count; i++)
      {
        string tablename = Convert.ToString(view[i][tableNameField]);
        TreeNode node = new TreeNode(tablename);
        TreeNode childNode = new TreeNode("*");
        node.Nodes.Add(childNode);
        treeView.Nodes.Add(node);
        childNode.Checked = true;
      }
    }

    private void CreateTable(TreeNode node)
    {
      string tableName = node.Text;
      string fields = "";
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        TreeNode childNode = node.Nodes[i];
        if (childNode.Checked)
        {
          fields += childNode.Text + ", ";
        }
      }
      if(!string.IsNullOrEmpty(fields))
      {
        fields = fields.TrimEnd(',', ' ');
        string sql = "SELECT " + fields + " FROM " + tableName;
        ResultSet rs = new ResultSet(txtPrefix.Text + tableName, structure, connection, sql);
      }
    }

    private void btnEditFields_Click(object sender, EventArgs e)
    {
      TreeNode node = treeView.SelectedNode;
      if (node != null)
      {
        if (node.Parent != null)
          node = node.Parent;

        DataTable fields = connection.GetFields(node.Text);

        List<string> checkedFields = new List<string>();
        foreach (TreeNode fieldNode in node.Nodes)
        {
          if (fieldNode.Text != "*")
            checkedFields.Add(fieldNode.Text);
        }

        FieldsDialog dlg = new FieldsDialog();
        if (dlg.Execute(fields, checkedFields, true) == DialogResult.OK)
        {
          node.Nodes.Clear();
          for (int i = 0; i < dlg.CamposSelecionados.Count; i++)
          {
            TreeNode fieldNode = new TreeNode(dlg.CamposSelecionados[i]);
            fieldNode.Checked = true;
            node.Nodes.Add(fieldNode);
          }
          node.Checked = true;
          node.Expand();
        }
      }
    }

    private void btnNone_Click(object sender, EventArgs e)
    {
      foreach (TreeNode node in treeView.Nodes)
      {
        node.Checked = false;
      }
    }

    private void btnAll_Click(object sender, EventArgs e)
    {
      foreach (TreeNode node in treeView.Nodes)
      {
        node.Checked = true;
      }
    }

    private void btnInvert_Click(object sender, EventArgs e)
    {
      foreach (TreeNode node in treeView.Nodes)
      {
        node.Checked = !node.Checked;
      }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      Search();
    }

    protected void Search()
    {
      int idx = -1;
      for (int i = 0; i < treeView.Nodes.Count; i++)
      {
        if (treeView.Nodes[i].Text.ToLower().StartsWith(txtBusca.Text.ToLower()))
        {
          idx = i;
          break;
        }
      }

      if (idx != -1)
        treeView.SelectedNode = treeView.Nodes[idx];
      treeView.Focus();
    }

    private void txtBusca_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 13)
        Search();
    }

    private void treeView_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 13)
        this.DialogResult = DialogResult.OK;
    }
  }
}