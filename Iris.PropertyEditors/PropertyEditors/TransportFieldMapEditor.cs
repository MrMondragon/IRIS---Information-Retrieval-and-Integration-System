using System.Data;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Iris.Runtime.Model.Operations.ResultSetOperations;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors
{
  public class TransportFieldMapEditor : BaseDialogEditor<ITransport>
  {
    protected override object GetValue(ITransport instance)
    {
      if (instance.Entrada == null)
        MessageBox.Show("Não existe ResultSet atribuído.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      else
      {
        DataTable master = instance.Entrada.Table;
        if (master == null)
          master = new DataTable(instance.Entrada.Name);

        if (instance.Saida == null)
        {
          MessageBox.Show("Favor atribuir um ResultSet saída antes de criar as correspondências.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
          DataTable detail = instance.Saida.Table;
          if (detail == null)
            detail = new DataTable(instance.Saida.Name);
          
          FieldMapEditorDialog dlg = new FieldMapEditorDialog(master, detail, instance.Corresp);
          if (dlg.ShowDialog() == DialogResult.OK)
          {
            instance.Corresp = dlg.GetFieldMap();
          }
        }
      }
      return instance.Corresp;
    }
  }
}
