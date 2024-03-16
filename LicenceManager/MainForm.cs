using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Databridge.Engine.Criptography;
using Databridge.Licence;
using LicencingBase;

namespace LicenceManager
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();

      manager = new Manager();
    }

    private Manager manager;

    private void btnAuthorize_Click(object sender, EventArgs e)
    {
      Cube defaultCube = Cube.GetDefaultLongCube();

      string macAddress = defaultCube.RComp(Manager.GetMacAddress());
      string org = defaultCube.RComp(txtOrganization.Text);
      //DateTime dt = DateTime.Now;

      //string token1 = manager.GetToken(dt);
      //string token2 = manager.GetToken(dt);
      //string token3 = manager.GetToken(dt);

      Cube certificate = new Cube(macAddress+"|"+ org);

      //certificate = service.GetCertificate(macAddress, org, token1, token2, token3);

      manager.InstallCertificate(certificate, txtOrganization.Text);
      MessageBox.Show("Máquina autorizada com sucesso");
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      DialogResult dr = MessageBox.Show("Confirma a desativação da licença associada a esta máquina?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
      if (dr == DialogResult.Yes)
      {

        Cube defaultCube = Cube.GetDefaultLongCube();

        string macAddress = defaultCube.RComp(Manager.GetMacAddress());
        string org = defaultCube.RComp(txtOrganization.Text);
        DateTime dt = DateTime.Now;

        string token1 = manager.GetToken(dt);
        string token2 = manager.GetToken(dt);
        string token3 = manager.GetToken(dt);

        //if(service.RemoveLicence(macAddress, org, token1, token2, token3)){
        manager.UnInstallCertificate();
        MessageBox.Show("Licença removida com sucesso");
        //}
      }
    }

    private void btnRegPlugn_Click(object sender, EventArgs e)
    {
      PluginRegistrator plugDlg = new PluginRegistrator();
      plugDlg.ShowDialog();
      plugDlg.Dispose();
    }


  }
}
