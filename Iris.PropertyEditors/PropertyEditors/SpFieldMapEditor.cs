using System.Data;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Iris.Runtime.Model.Operations.ResultSetOperations;
using Databridge.Interfaces.BaseEditors;
using Iris.Runtime.ResultSetOperations;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class SpFieldMapEditor : BaseDialogEditor<ISpTransport>
  {
    protected override object GetValue(ISpTransport instance)
    {
      if (instance.Entrada == null)
        MessageBox.Show("Não existe ResultSet atribuído.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      else
      {
        DataTable master = instance.Entrada.Table;
        if (master == null)
          master = new DataTable(instance.Entrada.Name);


        DataTable detail = new DataTable(string.Format("{0} Parametros", instance.SpName));
        for (int i = 0; i < instance.ParamNames.Count; i++)
        {
          detail.Columns.Add(instance.ParamNames[i]);
        }

        FieldMapEditorDialog dlg = new FieldMapEditorDialog(master, detail, instance.Corresp);
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          instance.Corresp = dlg.GetFieldMap();
        }
      }

      return instance.Corresp;
    }
  }
}
