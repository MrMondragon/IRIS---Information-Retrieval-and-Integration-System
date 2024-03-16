using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Databridge.Licence;
using Databridge.Engine.Criptography;
using System.IO;

namespace LicencingBase
{
  public partial class PluginRegistrator : Form
  {
    public PluginRegistrator()
    {
      InitializeComponent();
      manager = new Manager();
      certificate = manager.GetCertificate();

      GetRegisteredPlugins();
    }

    private Manager manager;
    private Cube certificate;

    private void GetRegisteredPlugins()
    {
      List<string> list = manager.LoadRegisteredPlugins();

      foreach (string item in list)
      {
        checkedListBox1.Items.Add(item);
      }

    }


    private void SavePlugins()
    {
      StringBuilder sb = new StringBuilder();
      foreach (object item in checkedListBox1.Items)
      {
        sb.AppendFormat("{0};", item);
      }

      string plugs = sb.ToString().TrimEnd(';');
      manager.SaveValue(plugs, "Plugins");
      this.Close();
    }

    private void btnAddPluginAsm_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        string pluginName = "p|" + Path.GetFileName(openFileDialog.FileName);
        checkedListBox1.Items.Add(pluginName);
      }
    }

    private void btnAddDepAsm_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        string pluginName = "d|" + Path.GetFileName(openFileDialog.FileName);
        checkedListBox1.Items.Add(pluginName);
      }
    }

    private void btnRemoveAsm_Click(object sender, EventArgs e)
    {
      for (int i = checkedListBox1.CheckedIndices.Count - 1; i >= 0; i--)
      {
        checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[i]);
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      SavePlugins();
    }


  }
}
