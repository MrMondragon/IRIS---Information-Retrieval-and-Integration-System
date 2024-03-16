using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iris.PropertyEditors.Dialogs
{
  public partial class AssemblyListEditorDialog : BaseDialog
  {
    public AssemblyListEditorDialog()
    {
      InitializeComponent();
    }

    public AssemblyListEditorDialog(Dictionary<string, string> _assmblies)
      : this()
    {
      assemblyListEditorControl1.SetAssemblies(_assmblies);
    }

    public Dictionary<string, string> GetAssemblies()
    {
      return assemblyListEditorControl1.GetAssemblies();
    }
  }
}