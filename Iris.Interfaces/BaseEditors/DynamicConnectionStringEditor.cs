using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using System.Windows.Forms.Design;
using Iris.Runtime.Core.Conexao;
using Iris.PropertyEditors.Dialogs;
using System.Windows.Forms;

namespace Iris.Interfaces
{
  public class DynamicConnectionStringEditor : BaseDialogEditor<IIrisRunnable>
  {
    protected override object GetValue(IIrisRunnable Instance)
    {
      return null;
    }

    public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if (context != null && context.Instance != null && provider != null)
      {
        IWindowsFormsEditorService edsvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
        if (edsvc != null)
        {
          IStructure structure = ((IIrisRunnable)context.Instance).Structure;
          string conName = context.PropertyDescriptor.Name;
          IDynConnection connection = structure.GetConnection(conName);



          if (String.IsNullOrEmpty(connection.InternalProvider))
            throw new Exception("O provedor de acesso deve ser atribuído antes da criação da string de conexão");

          //cria o diálogo
          ConnectionStringDialog csd = new ConnectionStringDialog(connection);
          //dispara o diálogo
          if (csd.ShowDialog() == DialogResult.OK)
          {
            value = csd.ConnectionString;
            connection.ConnectionString = csd.ConnectionString;
          }

          return connection.ConnectionString;
        }
      }
      return value;
    }
  }
}
