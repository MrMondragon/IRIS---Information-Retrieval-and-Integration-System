using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors;

namespace ImpDialogs
{
  public partial class RelationEditorDialog : BaseDialog
  {
    public RelationEditorDialog()
    {
      InitializeComponent();
    }

    private DialogResult doExecute()
    {
      DialogResult result = this.ShowDialog();
      while ((result == DialogResult.OK) && (grdCorrespondencias.Rows.Count < 2))
      {
        MessageBox.Show("Favor selecionar pelo menos um par de campos campo, ou cancelar a operação");
        result = doExecute();
      }

      return result;
    }

    public DialogResult CreateRelation(string masterTable, List<string> masterFields, string detailTable,
      List<string> detailFields, ref Dictionary<string,string> relation)
    {
      grdCorrespondencias.Columns[0].HeaderText = "Campos Mestre (" + masterTable + ")";
      grdCorrespondencias.Columns[1].HeaderText = "Campos Detalhe (" + detailTable + ")";

      foreach (string campo in masterFields)
      {
        ((DataGridViewComboBoxColumn)grdCorrespondencias.Columns[0]).Items.Add(campo);
      }

      foreach (string campo in detailFields)
        ((DataGridViewComboBoxColumn)grdCorrespondencias.Columns[1]).Items.Add(campo);

      foreach (KeyValuePair<string,string> link in relation)
      {
        grdCorrespondencias.Rows.Add(new object[] { link.Value, link.Key });
      }


      DialogResult result = doExecute();

      if (result == DialogResult.OK)
      {
        foreach (DataGridViewRow row in grdCorrespondencias.Rows)
        {
          if (!row.IsNewRow)
          {
            if ((string.IsNullOrEmpty(row.Cells[0].Value.ToString())) || (string.IsNullOrEmpty(row.Cells[1].Value.ToString())))
            {
              MessageBox.Show("Todos os campos devem ser preenchidos");
              return CreateRelation(masterTable, masterFields, detailTable, detailFields, ref relation);
            }
          }
        }

        relation.Clear();
        
        foreach (DataGridViewRow row in grdCorrespondencias.Rows)
        {
          if (!row.IsNewRow)
          {
            relation[row.Cells[1].Value.ToString()] = row.Cells[0].Value.ToString();
          }
        }

      }
      
      return result;
    }
  }
}