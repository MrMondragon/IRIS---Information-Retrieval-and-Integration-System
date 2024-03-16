using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Databridge.Interfaces.BaseEditors;
using Iris.Runtime.ColumnBasedOperations;
using Iris.PropertyEditors.PropertyEditors.Dialogs;
using System.Windows.Forms;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class RangeEditor : BaseDialogEditor<IRangeOperation>
  {
    protected override object GetValue(IRangeOperation Instance)
    {
      RangeEditorDialog rde = new RangeEditorDialog();

      if (rde.Edit(Instance.Ranges, Instance.Labels) == DialogResult.OK)
      {
        Instance.Ranges = rde.Ranges;
        Instance.Labels = rde.Labels;
      }

      return Instance.Labels;
    }
  }
}
