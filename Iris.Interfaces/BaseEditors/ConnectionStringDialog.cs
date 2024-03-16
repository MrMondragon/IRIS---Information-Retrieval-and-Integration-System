using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using Iris.Runtime.Core.Conexao;
namespace Iris.PropertyEditors.Dialogs
{
  /// <summary>
  /// Diálogo de edição de propriedades para edição de strings de conexão
  /// </summary>
  public partial class ConnectionStringDialog : Form
  {
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="T:ConnectionStringDialog"/>.
    /// </summary>
    public ConnectionStringDialog()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="T:ConnectionStringDialog"/>.
    /// </summary>
    /// <param name="aConexao">A conexao.</param>
    public ConnectionStringDialog(IDynConnection connection)
    {
      InitializeComponent();
      factory = connection.Factory;
      csBuilder = factory.CreateConnectionStringBuilder();
      csBuilder.ConnectionString = connection.ConnectionString;
      tbConnection.Text = connection.ConnectionString;
      UpdateGrid();
    }

    [NonSerialized]
    private DbConnectionStringBuilder csBuilder;
    [NonSerialized]
    private DbProviderFactory factory;

    /// <summary>
    /// Determina a ConnectionString da instância
    /// </summary>
    /// <value>ConnectionString da instância</value>
    public string ConnectionString
    {
      get
      {
        if (csBuilder != null)
          return csBuilder.ConnectionString;
        else
          return "";
      }
      set
      {
        if (csBuilder != null)
          csBuilder.ConnectionString = value;
      }
    }

    /// <summary>
    /// Atualiza o propertyGrid
    /// </summary>
    private void UpdateGrid()
    {
      prgProps.SelectedObject = csBuilder;
    }

    /// <summary>
    /// Handles the Validating event of the tbConnection control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void tbConnection_Validating(object sender, CancelEventArgs e)
    {
      string OldCS = ConnectionString;
      string Cs = tbConnection.Text;

      try
      {
        ConnectionString = Cs;
      }
      catch
      {
        ConnectionString = OldCS;
        throw;
      }
    }

    /// <summary>
    /// Handles the Validated event of the tbConnection control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void tbConnection_Validated(object sender, EventArgs e)
    {
      UpdateGrid();
    }

    /// <summary>
    /// Handles the PropertyValueChanged event of the prgProps control.
    /// </summary>
    /// <param name="s">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.Windows.Forms.PropertyValueChangedEventArgs"/> instance containing the event data.</param>
    private void prgProps_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      tbConnection.Text = ConnectionString;
    }

    private void btnTestConnection_Click(object sender, EventArgs e)
    {
      DbConnection connection = factory.CreateConnection();
      try
      {
        connection.ConnectionString = ConnectionString;
        connection.Open();
        connection.Close();
        MessageBox.Show("Conexão bem sucedida");
      }
      catch(Exception ex)
      {
        MessageBox.Show(String.Format("Falha na conexão! {0}Mensagem Original:{0}{1}", Environment.NewLine, ex.Message));
      }
      finally
      {
        connection.Dispose();
      }



    }

  }
}