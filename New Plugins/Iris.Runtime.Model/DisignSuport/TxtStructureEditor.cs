using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using Iris.Runtime.Model.DesignuSuport;
using System.Windows.Forms;

namespace Iris.Runtime.Model.DisignSuport
{
  public class TxtStructureEditor: BaseDialogEditor<TextSchema>
  {
    protected override object GetValue(TextSchema Instance)
    {
      TxtStructureDialog dlg = new TxtStructureDialog();
      List<TextLine> tmpLines = new List<TextLine>(Instance.LineTypes);

      if (dlg.Execute(Instance) != DialogResult.OK)
      {
        Instance.LineTypes = tmpLines;
      }

      return Instance.LineTypes;

    }
  }
}
