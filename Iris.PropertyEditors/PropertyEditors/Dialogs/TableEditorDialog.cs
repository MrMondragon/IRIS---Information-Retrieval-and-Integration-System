using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors.Dialogs
{
  public partial class TableEditorDialog : BaseDialog
  {
    public TableEditorDialog()
    {
      InitializeComponent();
      dataGridView1.AutoGenerateColumns = true;
      dataGridView1.DataError += dataGridView1_DataError;
      btnCancel.Click += btnOk_Click;
    }


    private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      DataColumn col = table.Columns[e.ColumnIndex];
      if ((col.DataType == (typeof(byte[]))) &&
        (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText)))
      {


        byte[] bytes = (byte[])table.Rows[e.RowIndex][col];
        string str = "";

        for (int i = 0; i < bytes.Length; i++)
        {
          str += bytes[i].ToString() + ".";
        }

        str = str.TrimEnd('.');
        str = "{" + str + "}";

        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = str + "  " + e.Exception.Message;
      }

      e.ThrowException = false;


    }

    public object DataSource
    {
      get
      {
        return bindingSource.DataSource;
      }
      set
      {
        bindingSource.DataSource = value;

        enforceConstraints = false;

        if (value is DataTable)
          table = ((DataTable)value);
        else
        {
          if (value != null)
            table = ((DataView)value).Table;
          else
            table = null;
        }

        this.Text = "Dados: " + table.TableName;
        if (table.DataSet != null)
          enforceConstraints = table.DataSet.EnforceConstraints;

        RefreshErrorIndexes();
      }
    }

    private void RefreshErrorIndexes()
    {
      errorIndexes = new List<int>();
      for (int i = 0; i < bindingSource.Count; i++)
      {
        DataRow row = ((DataRowView)bindingSource[i]).Row;
        if (row.HasErrors)
        {
          errorIndexes.Add(i);
        }
      }
    }

    /// <summary>
    /// variável interna que mantém o estado original da verificação de constraints do dataset
    /// no caso de alguma alteração nos dados, as constraints serão desligadas e só serão re-ligadas
    /// caso este valor seja verdadeiro, i.e., caso o dataset estivesse com as contstraints ligadas 
    /// antes da ativação deste diálogo
    /// </summary>
    private bool enforceConstraints;

    /// <summary>
    /// variável interna que armazena a tabela sobre a qual o datasource esta baseado, independente 
    /// de o mesmo tratar de um dataview ou de uma tabela propriamente dita
    /// </summary>
    private DataTable table;

    /// <summary>
    /// Liga ou desliga as constraints do dataset, verificando antes se o mesmo existe e 
    /// se elas devem ou não ser ligadas, em função da variável enforceConstraints
    /// </summary>
    /// <param name="value"></param>
    private void SetConstraints(bool value)
    {
      if ((table != null) && (table.DataSet != null) && enforceConstraints)
      {
        table.DataSet.EnforceConstraints = value;
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      table.Clear();
    }

    private List<int> errorIndexes;

    private void FindNextError()
    {
      if ((errorIndexes != null) && (errorIndexes.Count > 0))
      {
        int idx = bindingSource.Position;
        int errIdx = -1;
        for (int i = 0; i < errorIndexes.Count; i++)
        {
          if (errorIndexes[i] > idx)
          {
            errIdx = errorIndexes[i];
            break;
          }
        }
        if (errIdx > -1)
          bindingSource.Position = errIdx;
      }
    }

    private void FindPrevError()
    {
      if ((errorIndexes != null) && (errorIndexes.Count > 0))
      {
        int idx = bindingSource.Position;
        int errIdx = -1;
        for (int i = errorIndexes.Count - 1; i >= 0; i--)
        {
          if (errorIndexes[i] < idx)
          {
            errIdx = errorIndexes[i];
            break;
          }
        }
        if (errIdx > -1)
          bindingSource.Position = errIdx;
      }
    }


    private void btnFindNextError_Click(object sender, EventArgs e)
    {
      FindNextError();
    }

    private void btnFindPrevError_Click(object sender, EventArgs e)
    {
      FindPrevError();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      try
      {
        bindingSource.EndEdit();
        SetConstraints(true);
        this.Close();
      }
      catch (Exception ex)
      {
        string msg = string.Format(@"Foram encontrados os seguintes erros nos dados:

{0}

Pressione OK para manter as alterações e Cancel para retornar à edição", ex.Message);

        DialogResult result = MessageBox.Show(msg, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        if (result == DialogResult.Cancel)
        {
          RefreshErrorIndexes();
          this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
      }
    }

    private void bindingSource_CurrentItemChanged(object sender, EventArgs e)
    {
      SetConstraints(false);
    }

    private void btnAutoSize_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewColumn column in dataGridView1.Columns)
      {
        if (column.AutoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
          column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        else
          column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
      }
    }

    private void btnShowDiff_Click(object sender, EventArgs e)
    {
      showDiff = !showDiff;
      dataGridView1.Invalidate();
      Application.DoEvents();
    }


    private bool showDiff;

    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (showDiff)
      {
        if ((e.RowIndex != -1) && (e.ColumnIndex != -1) && (e.RowIndex < bindingSource.Count))
        {
          int rowIndex = e.RowIndex;
          string fieldName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

          DataRow row = ((DataRowView)bindingSource[rowIndex]).Row;

          if (row.RowState == DataRowState.Added)
          {
            e.CellStyle.BackColor = Color.Aqua;
          }
          else if (row.RowState == DataRowState.Modified)
          {
            if (!Convert.IsDBNull(row[fieldName]) && row[fieldName].Equals(row[fieldName, DataRowVersion.Original]))
            {
              e.CellStyle.BackColor = Color.Beige;
            }
            else
              e.CellStyle.BackColor = Color.Salmon;
          }
        }
      }

    }

    private void tsCbxRowState_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (DataSource is DataTable)
        DataSource = new DataView((DataTable)DataSource);

      if (tsCbxRowState.SelectedIndex == 0)
        ((DataView)DataSource).RowStateFilter = DataViewRowState.CurrentRows;
      if (tsCbxRowState.SelectedIndex == 1)
        ((DataView)DataSource).RowStateFilter = DataViewRowState.Added;
      if (tsCbxRowState.SelectedIndex == 2)
        ((DataView)DataSource).RowStateFilter = DataViewRowState.ModifiedCurrent;

    }

  }
}