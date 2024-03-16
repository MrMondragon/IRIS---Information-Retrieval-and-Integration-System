using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Iris.PropertyEditors.Dialogs;

namespace Iris.PropertyEditors
{
  public class AssemblyListEditor : BaseDialogEditor<IAssemblyUser>
  {
    protected override object GetValue(IAssemblyUser Instance)
    {
      AssemblyListEditorDialog dlg = new AssemblyListEditorDialog(Instance.Assemblies);
      if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        Instance.Assemblies = dlg.GetAssemblies();
      }
      return Instance.Assemblies;
    }
  }
}
