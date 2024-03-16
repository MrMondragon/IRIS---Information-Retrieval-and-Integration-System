using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors.Dialogs
{
  public partial class FieldSelectorDialog : BaseDialog
  {
    public FieldSelectorDialog()
    {
      InitializeComponent();
    }

    private DataTable table;

    public List<string> Execute(DataTable table, List<string> lookupFields)
    {
      List<string> result = null;
      this.table = table;
      if (lookupFields != null)
      {
        foreach (string fieldName in lookupFields)
        {
          FieldSelectionItem item = new FieldSelectionItem(table, fieldName);
          lbxFields.Items.Add(item);
        }
      }

      if (ShowDialog() == DialogResult.OK)
      {
        result = new List<string>();
        for (int i = 0; i < lbxFields.Items.Count; i++)
        {
          string field = Convert.ToString(lbxFields.Items[i]);
          if (field != "(Não Atribuído)")
            result.Add(field);
        }
        return result;
      }
      else
        return null;

    }

    private void btnNew_Click(object sender, EventArgs e)
    {
      FieldSelectionItem item = new FieldSelectionItem(table, "");
      lbxFields.Items.Add(item);
      lbxFields.SelectedIndex = lbxFields.Items.Count - 1;
      propertyGrid1.SelectedObject = item;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (lbxFields.SelectedIndex != -1)
        lbxFields.Items.RemoveAt(lbxFields.SelectedIndex);
      else
        lbxFields.Items.RemoveAt(0);
      propertyGrid1.SelectedObject = null;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lbxFields.Items.Clear();
    }

    private void lbxFields_SelectedIndexChanged(object sender, EventArgs e)
    {
      propertyGrid1.SelectedObject = lbxFields.SelectedItem;
    }

    private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      RefreshList();
    }

    private void RefreshList()
    {
      int idx = lbxFields.SelectedIndex;
      List<FieldSelectionItem> list = new List<FieldSelectionItem>();

      while (lbxFields.Items.Count > 0)
      {
        list.Add((FieldSelectionItem)lbxFields.Items[0]);
        lbxFields.Items.RemoveAt(0);
      }
      for (int i = 0; i < list.Count; i++)
      {
        lbxFields.Items.Add(list[i]);
      }
      lbxFields.SelectedIndex = idx;
    }
  }

  public class FieldSelectionItem
  {
    internal DataTable table;

    public FieldSelectionItem(DataTable _table, string fieldName)
    {
      table = _table;

      if (fieldName.Contains("|"))
      {
        Alias = fieldName.Substring(fieldName.IndexOf('|') + 1);
        field = fieldName.Remove(fieldName.IndexOf('|'));
      }
      else
        field = fieldName;
    }

    private string field;
    [Editor(typeof(FieldSelectorEditor), typeof(UITypeEditor))]
    public string Field
    {
      get
      {
        if (!string.IsNullOrEmpty(field))
          return field;
        else
          return "(Não Atribuído)";
      }
      set 
      { 
        field = value;
        if (string.IsNullOrEmpty(Alias))
          Alias = field;
      }
    }

    private string alias;

    public string Alias
    {
      get 
      {
        if (!string.IsNullOrEmpty(alias))
          return alias.Trim();
        else
          return string.Empty;
      }
      set { alias = value; }
    }

    public override string ToString()
    {
      if (!string.IsNullOrEmpty(Alias))
        return string.Format("{0}|{1}", Field, Alias);
      else
        return Field;
    }
  }
}

