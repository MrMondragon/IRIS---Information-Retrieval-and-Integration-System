using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Iris.Interfaces;
using Iris.Runtime.Model.Operations.ResultSetOperations;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Runtime.Core;
using Databridge.Interfaces.BaseEditors;


namespace Iris.PropertyEditors
{
  public class RBOFieldMapEditor : BaseDialogEditor<IRelationBasedOperation>
  {
    protected override object GetValue(IRelationBasedOperation Instance)
    {
      if (Instance.Entrada == null)
        MessageBox.Show("Não existe ResultSet atribuído.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      else
      {
        DataTable detail = Instance.Entrada.Table;

        if (Instance.MasterRS == null)
        {
          Instance.FieldMap=null;
          MessageBox.Show("Favor atribuir um ResultSet mestre antes de criar as correspondências.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
          DataTable master = Instance.MasterRS.Table;
          List<IKeyValueItem> IkvList = new List<IKeyValueItem>();
       
          FieldMapEditorDialog dlg = new FieldMapEditorDialog(master, detail, Instance.FieldMap);
          if (dlg.ShowDialog() == DialogResult.OK)
          {
            Instance.FieldMap=dlg.GetFieldMap();
          }
        }
      }
      return Instance.FieldMap;
    }
  }
}
