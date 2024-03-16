using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities.Txt;
using ImpDialogs;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class TxtRelationEditor: BaseDialogEditor<ITextLine>
  {
    protected override object GetValue(ITextLine Instance)
    {
      RelationEditorDialog dlg = new RelationEditorDialog();
      Dictionary<string, string> temp = new Dictionary<string, string>(Instance.Link);
      DialogResult result = dlg.CreateRelation(Instance.Master.Name, Instance.Master.GetFieldList(), Instance.Name, Instance.GetFieldList(), ref temp);
      if (result == DialogResult.OK)
        Instance.Link = temp;

      return Instance.Link;
    }
  }
}
