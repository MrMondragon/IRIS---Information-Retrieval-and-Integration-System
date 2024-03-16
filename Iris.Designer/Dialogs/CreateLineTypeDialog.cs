using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model;

namespace Iris.Designer
{
  public partial class CreateLineTypeDialog : Iris.Designer.CreateTableDialog
  {
    public CreateLineTypeDialog()
    {
      InitializeComponent();
    }

    public DialogResult Execute(Structure _structure, TextSchema schema)
    {
      structure = _structure;
      cbxConnections.SelectedIndexChanged += cbxConections_SelectedIndexChanged;
      txtBusca.Select();

      foreach (DynConnection connection in _structure.Connections)
      {
        cbxConnections.Items.Add(connection.Name);
      }


      cbxConnections.SelectedIndex = 0;

      DialogResult result = this.ShowDialog();

      if (result == DialogResult.OK)
      {
        CreateTable(schema);
      }

      return result;
    }

    private void CreateTable(TextSchema schema)
    {
      List<string> fields = new List<string>();
      List<string> tables = new List<string>();
      PrepareLists(fields, tables);

      if((fields.Count > 0) && (tables.Count > 0))
      {
        string select = "";
        for (int i = 0; i < fields.Count; i++)
        {
          select += fields[i] + ", ";
        }
        select = select.Trim(',', ' ');

        string from = "";
        for (int i = 0; i < tables.Count; i++)
        {
          from += tables[i] + ", ";
        }
        from = from.Trim(',', ' ');

        string sql = string.Format("SELECT {0} FROM {1} WHERE 1 = 2", select, from);
        DataTable table = connection.ExecQuery(sql, null);

        TextLine lineType = new TextLine(schema);
        lineType.Name = table.TableName;
        foreach (DataColumn column in table.Columns)
        {
          TextField field = new TextField(lineType);
          field.Name = column.ColumnName;
          field.DataType = column.DataType;
          field.Required = !column.AllowDBNull;
          field.AutoInc = column.AutoIncrement;
          if (!field.AutoInc)
          {
            field.DefaultValue = column.DefaultValue;
          }

          if(column.MaxLength != -1)
            field.Size = column.MaxLength;
        }
      }
    }

    private void PrepareLists(List<string> fields, List<string> tables)
    {
      for (int i = 0; i < treeView.Nodes.Count; i++)
      {
        TreeNode tableNode = treeView.Nodes[i];
        if (tableNode.Checked)
        {
          tables.Add(tableNode.Text);
          foreach (TreeNode fieldNode in tableNode.Nodes)
          {
            if (fieldNode.Checked)
            {
              if (fieldNode.Text == "*")
                AddAllFields(tableNode.Text, fields);
              else
                fields.Add(tableNode.Text + "." + fieldNode.Text);
            }
          }
        }
      }
    }

    private void AddAllFields(string tableName, List<string> fields)
    {
      DataTable table = connection.GetFields(tableName);
      for (int i = 0; i < table.Rows.Count; i++)
      {
        fields.Add(Convert.ToString(tableName+"."+table.Rows[i]["Column_Name"]));
      }
    }


    private void cbxConections_SelectedIndexChanged(object sender, EventArgs e)
    {
      DynConnection connection = structure.GetConnection(Convert.ToString(cbxConnections.SelectedItem));
      SetupTables(connection);
    }



  }
}

