using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using Iris.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors.Controls;
using Databridge.Interfaces.BaseEditors;
using Databridge.Interfaces;

namespace Iris.PropertyEditors.Controls
{
  public partial class ConnectionEditorControl : BaseControl
  {
   
  
    public ConnectionEditorControl()
    {
      InitializeComponent();
      cbbProviders.DataSource = DbProviderFactories.GetFactoryClasses();
      cbbProviders.DisplayMember = "Name";
      cbbProviders.ValueMember = "InvariantName";
      cbbProviders.SelectedIndex = 0;
    }

    private IDataConnection connection;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IDataConnection Connection
    {
      get { return connection; }
      set 
      {
        if (value != null)
        {
          connection = value;
          if (!string.IsNullOrEmpty(connection.Provider))
          {
            cbbProviders.Text = connection.Provider;
            tbConnectionString.Text = connection.ConnectionString;
          }
          else
            SetupProvider();
        }
      }
    }

    private void btnEditConnectionString_Click(object sender, EventArgs e)
    {
      ConnectionStringDialog dlg = new ConnectionStringDialog(Connection);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        tbConnectionString.Text = dlg.ConnectionString;
        Connection.ConnectionString = dlg.ConnectionString;
      }
      OnPropertyChanged();
    }



    private void cbbProviders_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetupProvider();
    }

    private void SetupProvider()
    {
      tbConnectionString.Text = "";
      if (Connection != null)
      {
        Connection.InternalProvider = Convert.ToString(cbbProviders.SelectedValue);
        Connection.Provider = cbbProviders.Text;
      }
    }

    private void tbConnectionString_Validating(object sender, CancelEventArgs e)
    {
      if (Connection != null)
      {
        string cs = Connection.ConnectionString;
        try
        {
          Connection.ConnectionString = tbConnectionString.Text;
        }
        catch
        {
          Connection.ConnectionString = cs;
          throw;
        }
      }
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      Connection.Open();
      Connection.Close();
      MessageBox.Show("Conexão bem sucedida");
    }

    private void cbbProviders_Validated(object sender, EventArgs e)
    {
      OnPropertyChanged();
    }
  }
}
