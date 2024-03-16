using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Designer
{
  public partial class FieldsDialog : BaseDialog
  {
    public FieldsDialog()
    {
      InitializeComponent();
    }


    public DialogResult Execute(DataTable fields, List<string> checkedFields, bool schemaTable)
    {
      cbxFields.Items.Clear();
      if (schemaTable)
      {
        foreach (DataRow dr in fields.Rows)
        {
          string fieldName = dr["Column_Name"].ToString();
          int idx = cbxFields.Items.Add(fieldName);
          if (checkedFields.Contains(fieldName))
            cbxFields.SetItemChecked(idx, true);
        }
      }
      else
      {
        foreach (DataColumn col in fields.Columns)
        {
          string fieldName = col.ColumnName;
          int idx = cbxFields.Items.Add(fieldName);
          if (checkedFields.Contains(fieldName))
            cbxFields.SetItemChecked(idx, true);
        }
      }

      CamposSelecionados = new List<string>();

      DialogResult result = this.ShowDialog();
      while ((result == DialogResult.OK) && (camposSelecionados.Count == 0))
      {
        MessageBox.Show("Favor selecionar pelo menos um campo, ou cancelar a operação");
        result = this.Execute(fields, checkedFields, schemaTable);
      }
      return result;
    }



    private List<string> camposSelecionados;
    public List<string> CamposSelecionados
    {
      get { return camposSelecionados; }
      set { camposSelecionados = value; }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      CamposSelecionados.Clear();

      foreach (object itemChecked in cbxFields.CheckedItems)
      {
        CamposSelecionados.Add(itemChecked.ToString());
      }
    }

    private void btnTodos_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < cbxFields.Items.Count; i++)
      {
        cbxFields.SetItemChecked(i, true);        
      }
    }

    private void btnNenhum_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < cbxFields.Items.Count; i++)
      {
        cbxFields.SetItemChecked(i, false);
      }
    }

    private void btnInvert_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < cbxFields.Items.Count; i++)
      {
        cbxFields.SetItemChecked(i, !cbxFields.GetItemChecked(i));
      }
    }

  }
}