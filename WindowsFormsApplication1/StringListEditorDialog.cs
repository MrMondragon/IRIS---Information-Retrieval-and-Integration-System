using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Databridge.Interfaces.BaseEditors;
using Databridge.PropertyEditors.PropertyEditors.Controls;

namespace Databridge.PropertyEditors.PropertyEditors.Dialogs
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
        control.List.AddRange(txtText.Text.Split('\r').Select(x => new StringListItem(x.Trim())));
      }
      else
      {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < control.List.Count; i++)
        {
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