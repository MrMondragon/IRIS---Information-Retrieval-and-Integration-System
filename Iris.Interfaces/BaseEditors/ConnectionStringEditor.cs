  using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Data.Common;
using Iris.PropertyEditors.Dialogs;
using Iris.Runtime.Core.Conexao;

namespace Iris.PropertyEditors
{
  /// <summary>
  /// Editor de propriedades para strings de conexão
  /// </summary>
  public class ConnectionStringEditor : BaseDialogEditor<IDynConnection>
  {
    /// <summary>
    /// Retorna o valor da propriedade
    /// </summary>
    /// <param name="Instance">A instância</param>
    /// <returns>
    /// O valor da propriedade. Null caso o valor seja setado pelo próprio editor
    /// </returns>
    protected override object GetValue(IDynConnection Instance)
    {
      object value = null;
      if (String.IsNullOrEmpty(Instance.InternalProvider))
        throw new Exception("O provedor de acesso deve ser atribuído antes da criação da string de conexão");

      //cria o diálogo
      ConnectionStringDialog csd = new ConnectionStringDialog(Instance);
      //dispara o diálogo
      if (csd.ShowDialog() == DialogResult.OK)
      {
        value = csd.ConnectionString;
        Instance.ConnectionString = csd.ConnectionString;
      }

      return Instance.ConnectionString;
    }
  }
}
