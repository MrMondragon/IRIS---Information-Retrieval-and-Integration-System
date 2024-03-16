using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  public partial class ChoiceEditorDialog :BaseDialog
  {
    public ChoiceEditorDialog()
    {
      InitializeComponent();
    }

    public Dictionary<string, string> Execute(Dictionary<string, string> alternatives)
    {
      choiceEditorControl1.SetList(alternatives);
      if (this.ShowDialog() == DialogResult.OK)
        alternatives = choiceEditorControl1.GetDictionary();

      return alternatives;
    }
  }
}

