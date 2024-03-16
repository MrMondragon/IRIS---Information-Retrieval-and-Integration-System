using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
#if !LockClient
using Iris.Runtime.Model.ClientObjects;
#endif
using Iris.PropertyEditors.Dialogs;
using Iris.Runtime.Model.Properties;

namespace ClientObjects.WinFormsExe
{
  public partial class BaseJobForm : Form
  {

    public BaseJobForm()
    {
      InitializeComponent();
    }
    #if !LockClient

    public BaseJobForm(IIrisRunnable _dynStructure): this()
    {
      DynStructure = _dynStructure;
    }

    private ClientConfig config;

    #region Inicialização
    private IIrisRunnable dynStructure;
    private Structure structure;
    private string fileName;

    public IIrisRunnable DynStructure
    {
      get { return dynStructure; }
      set
      {
        dynStructure = value;
        ppgParams.SelectedObject = dynStructure;
        structure = (Structure)dynStructure.Structure;
        Text = structure.ClassName + " - " + structure.Description;

        fileName = Application.ExecutablePath;
        fileName = fileName.ToLower().Replace(".exe", ".config");
        config = ClientConfig.CreateConfig(structure, fileName);
        ppgConfigs.SelectedObject = config;
        
        foreach (Operation oper in structure.Operations)
        {
          if (oper.ExternalParam)
          {
            CreateEntryPoint(oper);
          }
        }

        gbxProcessos.Visible = (gbxProcessos.Controls.Count > 0);
      }
    }

    private void CreateEntryPoint(Operation oper)
    {
      Button btn = new Button();
      btn.Text = oper.DisplayText;
      if (string.IsNullOrEmpty(btn.Text))
        btn.Text = oper.Name;
      btn.Tag = oper;
      btn.Width = gbxProcessos.Width - 10;
      btn.Left = 5;
      btn.Top = (gbxProcessos.Controls.Count * (btn.Height + 5)) + 15;
      btn.Click += EntryPointClick;
      gbxProcessos.Controls.Add(btn);
    }

    private void EntryPointClick(object sender, EventArgs e)
    {
      if (VerificaSenha())
      {
        bool running = timer.Enabled;
        if(running)
          Stop();

        structure.RunningOper = (Operation)((Button)sender).Tag;
        structure.Execute(false);
        
        if(running)
          Start();
      }

    }

    private void BaseJobForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ((e.CloseReason != CloseReason.ApplicationExitCall) && (e.CloseReason != CloseReason.WindowsShutDown))
      {
        Hide();
        e.Cancel = true;
      }
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      Show();
    }

    #endregion

    private void btnSave_Click(object sender, EventArgs e)
    {
      config.SaveToFile(fileName);
    }

    private void btnAlteraSenha_Click(object sender, EventArgs e)
    {
      PasswordEditorDialog dlg = new PasswordEditorDialog();
      if (dlg.Execute(config.Password) == DialogResult.OK)
        config.Password = dlg.Senha;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      if (DateTime.Now > config.NextStart)
      {
        Run();
      }

    }

    private bool running;
    private void Run()
    {
      if (!running)
      {
        running = true;
        UpdateStatus();
        try
        {
          bool timerRunning = timer.Enabled;
          if (timerRunning)
            timer.Stop();

          lbLastRun.Text = DateTime.Now.ToString();
          config.Run();
          lbNextRun.Text = config.NextStart.ToString();

          if (timerRunning)
            timer.Start();
        }
        finally
        {
          running = false;
          UpdateStatus();
        }
      }
    }

    private void tbcMain_Selecting(object sender, TabControlCancelEventArgs e)
    {
      e.Cancel = !VerificaSenha();
    }

    private bool VerificaSenha()
    {
      bool falha = ((!String.IsNullOrEmpty(config.Password)) && (tbPassword.Text != config.Password));
      if (falha)
      {
        string msg;
        if (string.IsNullOrEmpty(tbPassword.Text))
          msg = "Favor digitar a senha";
        else
          msg = "Senha de acesso incorreta";
        MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        tbPassword.Focus();
      }
      return !falha;
    }

    private void tbcMain_Selected(object sender, TabControlEventArgs e)
    {
      if (tbcMain.SelectedTab != tabControl)
        Stop();

      if (tbcMain.SelectedTab == tabLog)
      {
        RefreshLog();
      }
      else if (tbcMain.SelectedTab == tabAssemblies)
      {
        assemblyListEditorControl1.SetAssemblies(structure.Assemblies);
      }
    }

    private void RefreshLog()
    {
      lvwProcessos.SelectedIndexChanged -= lvwProcessos_SelectedIndexChanged;
      lvwProcessos.Items.Clear();
      lvwLog.Items.Clear();
      for (int i = 0; i < config.Logs.Count; i++)
			{
        ProccessLog log = config.Logs[i];
        ListViewItem lvi = new ListViewItem(log.ToString());
        if (log.Error)
          lvi.ImageIndex = 1;
        else
          lvi.ImageIndex = 0;

        lvi.Tag = log;
        lvwProcessos.Items.Add(lvi);
      }
      lvwProcessos.SelectedIndexChanged += lvwProcessos_SelectedIndexChanged;
    }

    private void lvwProcessos_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lvwProcessos.SelectedItems.Count > 0)
      {
        ProccessLog log = (ProccessLog)lvwProcessos.SelectedItems[0].Tag;
        lvwLog.Items.Clear();
        for (int i = 0; i < log.Items.Count; i++)
        {
          LogItem item = log.Items[i];
          ListViewItem lvi = new ListViewItem(item.ToString());
          if (item.Error)
            lvi.ImageIndex = 1;
          else
            lvi.ImageIndex = 0;

          lvwLog.Items.Add(lvi);
        }
      }
    }

    private void Stop()
    {
      if (VerificaSenha())
      {
        timer.Stop();
        UpdateStatus();
      }
    }

    private void Start()
    {
      timer.Start();
      UpdateStatus();
    }

    private void UpdateStatus()
    {
      if (timer.Enabled)
      {
        pbxOnOff.Image = Resources.GreenLight;
        lbOnOff.Text = "Ligado";
      }
      else
      {
        if (running)
        {
          pbxOnOff.Image = Resources.YellowLight;
          lbOnOff.Text = "Executando";
        }
        else
        {
          pbxOnOff.Image = Resources.RedLight;
          lbOnOff.Text = "Desligado";
        }
      }

      lbStatusChanged.Text = DateTime.Now.ToString();
      Application.DoEvents();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      Start();
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      Stop();
    }

    private void tsmiStop_Click(object sender, EventArgs e)
    {
      Stop();
    }

    private void tsmiStart_Click(object sender, EventArgs e)
    {
      Start();
    }

    private void tsmiShow_Click(object sender, EventArgs e)
    {
      Show();
    }

    private void tsmiClose_Click(object sender, EventArgs e)
    {
      if (VerificaSenha())
      {
        Application.Exit();
      }
    }

    private void btnRunNow_Click(object sender, EventArgs e)
    {
      if ((!running)&&(VerificaSenha()))
      {
        Run();
      }
    }

    private void assemblyListEditorControl1_PropertyChanged(object sender, EventArgs e)
    {
      structure.Assemblies = assemblyListEditorControl1.GetAssemblies();
    }



#endif


    
  }
}