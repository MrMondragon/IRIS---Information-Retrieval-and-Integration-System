using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Databridge.Interfaces.BaseEditors;
using Iris.PropertyEditors.PropertyEditors.Controls;

namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  public partial class StringListEditorDialog : BaseDialog
  {
    public StringListEditorDialog()
    {
      InitializeComponent();
    }

    public List<String> GetStringList()
    {
      return control.GetStringList();
    }

    public void SetStringList(List<String> stringList)
    {
      control.SetStringList(stringList);
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (tabControl1.SelectedIndex == 0)
      {
        control.List.Clear();
        control.SetStringList(txtText.Text.Split('\r').Where(x=> !string.IsNullOrEmpty(x.Trim())).Select(x => x.Trim()).ToList());
      }
      else
      {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < control.List.Count; i++)
        {
          if (!string.IsNullOrEmpty(control.List[i].Val))
            builder.AppendLine(control.List[i].Val);
        }
        txtText.Text = builder.ToString();
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (tabControl1.SelectedIndex != 0)
        tabControl1.SelectedIndex = 0;
    }
  }
}