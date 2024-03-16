using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;

namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  public partial class DataRelationEditorDialog : FieldMapEditorDialog
  {
    public DataRelationEditorDialog(DataTable _source, DataTable _destination, List<KeyValuePair<string, string>> fieldMap) :
      base(_source, _destination, fieldMap)
    {
      InitializeComponent();
    }

    public DataRelationEditorDialog()
    {
      InitializeComponent();
    }

    public string RelationName
    {
      get
      {
        return txtRelationName.Text;
      }
      set
      {
        txtRelationName.Text = value;
      }
    }
  }
}
