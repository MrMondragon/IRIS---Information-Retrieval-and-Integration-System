namespace ClientObjects.WinFormsExe
{
  partial class BaseJobForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseJobForm));
      this.tryIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiStart = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiStop = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControl = new System.Windows.Forms.TabPage();
      this.gbxProcessos = new System.Windows.Forms.GroupBox();
      this.gbxStatus = new System.Windows.Forms.GroupBox();
      this.lbNextRun = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.btnRunNow = new System.Windows.Forms.Button();
      this.lbLastRun = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.btnAlteraSenha = new System.Windows.Forms.Button();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      this.lbStatusChanged = new System.Windows.Forms.Label();
      this.btnStop = new System.Windows.Forms.Button();
      this.lbOnOff = new System.Windows.Forms.Label();
      this.btnStart = new System.Windows.Forms.Button();
      this.pbxOnOff = new System.Windows.Forms.PictureBox();
      this.tbcMain = new System.Windows.Forms.TabControl();
      this.tabParams = new System.Windows.Forms.TabPage();
      this.ppgParams = new System.Windows.Forms.PropertyGrid();
      this.tabConfigs = new System.Windows.Forms.TabPage();
      this.ppgConfigs = new System.Windows.Forms.PropertyGrid();
      this.tabAssemblies = new System.Windows.Forms.TabPage();
      this.assemblyListEditorControl1 = new Databridge.Interfaces.BaseEditors.Controls.AssemblyListEditorControl();
      this.tabLog = new System.Windows.Forms.TabPage();
      this.lvwLog = new System.Windows.Forms.ListView();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.imlListViewIcons = new System.Windows.Forms.ImageList(this.components);
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.lvwProcessos = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.trayMenu.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.gbxStatus.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxOnOff)).BeginInit();
      this.tbcMain.SuspendLayout();
      this.tabParams.SuspendLayout();
      this.tabConfigs.SuspendLayout();
      this.tabAssemblies.SuspendLayout();
      this.tabLog.SuspendLayout();
      this.SuspendLayout();
      // 
      // tryIcon
      // 
      this.tryIcon.ContextMenuStrip = this.trayMenu;
      this.tryIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("tryIcon.Icon")));
      this.tryIcon.Text = "Configurações";
      this.tryIcon.Visible = true;
      this.tryIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // trayMenu
      // 
      this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClose,
            this.tsmiShow,
            this.tsmiStart,
            this.tsmiStop});
      this.trayMenu.Name = "trayMenu";
      this.trayMenu.Size = new System.Drawing.Size(112, 92);
      // 
      // tsmiClose
      // 
      this.tsmiClose.Name = "tsmiClose";
      this.tsmiClose.Size = new System.Drawing.Size(111, 22);
      this.tsmiClose.Text = "Close";
      this.tsmiClose.ToolTipText = "Encerra a execução do aplicativo";
      this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
      // 
      // tsmiShow
      // 
      this.tsmiShow.Name = "tsmiShow";
      this.tsmiShow.Size = new System.Drawing.Size(111, 22);
      this.tsmiShow.Text = "Show";
      this.tsmiShow.ToolTipText = "Exibe a janela de configuração do aplicativo";
      this.tsmiShow.Click += new System.EventHandler(this.tsmiShow_Click);
      // 
      // tsmiStart
      // 
      this.tsmiStart.Name = "tsmiStart";
      this.tsmiStart.Size = new System.Drawing.Size(111, 22);
      this.tsmiStart.Text = "Start";
      this.tsmiStart.ToolTipText = "Inicia o processo";
      this.tsmiStart.Click += new System.EventHandler(this.tsmiStart_Click);
      // 
      // tsmiStop
      // 
      this.tsmiStop.Name = "tsmiStop";
      this.tsmiStop.Size = new System.Drawing.Size(111, 22);
      this.tsmiStop.Text = "Stop";
      this.tsmiStop.ToolTipText = "Para o processo";
      this.tsmiStop.Click += new System.EventHandler(this.tsmiStop_Click);
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.gbxProcessos);
      this.tabControl.Controls.Add(this.gbxStatus);
      this.tabControl.Location = new System.Drawing.Point(4, 22);
      this.tabControl.Name = "tabControl";
      this.tabControl.Padding = new System.Windows.Forms.Padding(3);
      this.tabControl.Size = new System.Drawing.Size(464, 365);
      this.tabControl.TabIndex = 0;
      this.tabControl.Text = "Controle";
      this.tabControl.UseVisualStyleBackColor = true;
      // 
      // gbxProcessos
      // 
      this.gbxProcessos.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gbxProcessos.Location = new System.Drawing.Point(3, 3);
      this.gbxProcessos.Name = "gbxProcessos";
      this.gbxProcessos.Size = new System.Drawing.Size(183, 359);
      this.gbxProcessos.TabIndex = 13;
      this.gbxProcessos.TabStop = false;
      this.gbxProcessos.Text = "Processos";
      // 
      // gbxStatus
      // 
      this.gbxStatus.Controls.Add(this.lbNextRun);
      this.gbxStatus.Controls.Add(this.label4);
      this.gbxStatus.Controls.Add(this.btnRunNow);
      this.gbxStatus.Controls.Add(this.lbLastRun);
      this.gbxStatus.Controls.Add(this.label1);
      this.gbxStatus.Controls.Add(this.btnAlteraSenha);
      this.gbxStatus.Controls.Add(this.tbPassword);
      this.gbxStatus.Controls.Add(this.label5);
      this.gbxStatus.Controls.Add(this.btnSave);
      this.gbxStatus.Controls.Add(this.lbStatusChanged);
      this.gbxStatus.Controls.Add(this.btnStop);
      this.gbxStatus.Controls.Add(this.lbOnOff);
      this.gbxStatus.Controls.Add(this.btnStart);
      this.gbxStatus.Controls.Add(this.pbxOnOff);
      this.gbxStatus.Dock = System.Windows.Forms.DockStyle.Right;
      this.gbxStatus.Location = new System.Drawing.Point(186, 3);
      this.gbxStatus.Name = "gbxStatus";
      this.gbxStatus.Size = new System.Drawing.Size(275, 359);
      this.gbxStatus.TabIndex = 12;
      this.gbxStatus.TabStop = false;
      this.gbxStatus.Text = "Execução Agendada";
      // 
      // lbNextRun
      // 
      this.lbNextRun.AutoSize = true;
      this.lbNextRun.Location = new System.Drawing.Point(140, 73);
      this.lbNextRun.Name = "lbNextRun";
      this.lbNextRun.Size = new System.Drawing.Size(124, 13);
      this.lbNextRun.TabIndex = 14;
      this.lbNextRun.Text = "00/00/0000 às 00:00:00";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(38, 73);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(98, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Próxima Execução:";
      // 
      // btnRunNow
      // 
      this.btnRunNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnRunNow.Location = new System.Drawing.Point(28, 315);
      this.btnRunNow.Name = "btnRunNow";
      this.btnRunNow.Size = new System.Drawing.Size(100, 23);
      this.btnRunNow.TabIndex = 12;
      this.btnRunNow.Text = "Executar Agora";
      this.btnRunNow.UseVisualStyleBackColor = true;
      this.btnRunNow.Click += new System.EventHandler(this.btnRunNow_Click);
      // 
      // lbLastRun
      // 
      this.lbLastRun.AutoSize = true;
      this.lbLastRun.Location = new System.Drawing.Point(140, 53);
      this.lbLastRun.Name = "lbLastRun";
      this.lbLastRun.Size = new System.Drawing.Size(124, 13);
      this.lbLastRun.TabIndex = 6;
      this.lbLastRun.Text = "00/00/0000 às 00:00:00";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(140, 302);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Senha";
      // 
      // btnAlteraSenha
      // 
      this.btnAlteraSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAlteraSenha.Location = new System.Drawing.Point(143, 276);
      this.btnAlteraSenha.Name = "btnAlteraSenha";
      this.btnAlteraSenha.Size = new System.Drawing.Size(100, 23);
      this.btnAlteraSenha.TabIndex = 11;
      this.btnAlteraSenha.Text = "Alterar Senha";
      this.btnAlteraSenha.UseVisualStyleBackColor = true;
      this.btnAlteraSenha.Click += new System.EventHandler(this.btnAlteraSenha_Click);
      // 
      // tbPassword
      // 
      this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.tbPassword.Location = new System.Drawing.Point(143, 318);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.PasswordChar = '*';
      this.tbPassword.Size = new System.Drawing.Size(100, 20);
      this.tbPassword.TabIndex = 9;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(38, 53);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(90, 13);
      this.label5.TabIndex = 5;
      this.label5.Text = "Última Execução:";
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnSave.Location = new System.Drawing.Point(28, 276);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(100, 23);
      this.btnSave.TabIndex = 8;
      this.btnSave.Text = "Gravar Configs";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // lbStatusChanged
      // 
      this.lbStatusChanged.AutoSize = true;
      this.lbStatusChanged.Location = new System.Drawing.Point(140, 31);
      this.lbStatusChanged.Name = "lbStatusChanged";
      this.lbStatusChanged.Size = new System.Drawing.Size(124, 13);
      this.lbStatusChanged.TabIndex = 2;
      this.lbStatusChanged.Text = "00/00/0000 às 00:00:00";
      // 
      // btnStop
      // 
      this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnStop.Location = new System.Drawing.Point(143, 237);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(100, 23);
      this.btnStop.TabIndex = 7;
      this.btnStop.Text = "Parar";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // lbOnOff
      // 
      this.lbOnOff.AutoSize = true;
      this.lbOnOff.Location = new System.Drawing.Point(38, 31);
      this.lbOnOff.Name = "lbOnOff";
      this.lbOnOff.Size = new System.Drawing.Size(54, 13);
      this.lbOnOff.TabIndex = 1;
      this.lbOnOff.Text = "Desligado";
      // 
      // btnStart
      // 
      this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnStart.Location = new System.Drawing.Point(28, 237);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(100, 23);
      this.btnStart.TabIndex = 6;
      this.btnStart.Text = "Iniciar";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // pbxOnOff
      // 
      this.pbxOnOff.Image = global::Iris.Runtime.Model.Properties.Resources.RedLight;
      this.pbxOnOff.Location = new System.Drawing.Point(16, 28);
      this.pbxOnOff.Name = "pbxOnOff";
      this.pbxOnOff.Size = new System.Drawing.Size(16, 16);
      this.pbxOnOff.TabIndex = 0;
      this.pbxOnOff.TabStop = false;
      // 
      // tbcMain
      // 
      this.tbcMain.Controls.Add(this.tabControl);
      this.tbcMain.Controls.Add(this.tabParams);
      this.tbcMain.Controls.Add(this.tabConfigs);
      this.tbcMain.Controls.Add(this.tabAssemblies);
      this.tbcMain.Controls.Add(this.tabLog);
      this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbcMain.Location = new System.Drawing.Point(0, 0);
      this.tbcMain.Name = "tbcMain";
      this.tbcMain.SelectedIndex = 0;
      this.tbcMain.Size = new System.Drawing.Size(472, 391);
      this.tbcMain.TabIndex = 0;
      this.tbcMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbcMain_Selecting);
      this.tbcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcMain_Selected);
      // 
      // tabParams
      // 
      this.tabParams.Controls.Add(this.ppgParams);
      this.tabParams.Location = new System.Drawing.Point(4, 22);
      this.tabParams.Name = "tabParams";
      this.tabParams.Padding = new System.Windows.Forms.Padding(3);
      this.tabParams.Size = new System.Drawing.Size(464, 365);
      this.tabParams.TabIndex = 1;
      this.tabParams.Text = "Parâmetros";
      this.tabParams.UseVisualStyleBackColor = true;
      // 
      // ppgParams
      // 
      this.ppgParams.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ppgParams.Location = new System.Drawing.Point(3, 3);
      this.ppgParams.Name = "ppgParams";
      this.ppgParams.Size = new System.Drawing.Size(458, 359);
      this.ppgParams.TabIndex = 0;
      // 
      // tabConfigs
      // 
      this.tabConfigs.Controls.Add(this.ppgConfigs);
      this.tabConfigs.Location = new System.Drawing.Point(4, 22);
      this.tabConfigs.Name = "tabConfigs";
      this.tabConfigs.Padding = new System.Windows.Forms.Padding(3);
      this.tabConfigs.Size = new System.Drawing.Size(464, 365);
      this.tabConfigs.TabIndex = 3;
      this.tabConfigs.Text = "Configurações";
      this.tabConfigs.UseVisualStyleBackColor = true;
      // 
      // ppgConfigs
      // 
      this.ppgConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ppgConfigs.Location = new System.Drawing.Point(3, 3);
      this.ppgConfigs.Name = "ppgConfigs";
      this.ppgConfigs.Size = new System.Drawing.Size(458, 359);
      this.ppgConfigs.TabIndex = 0;
      // 
      // tabAssemblies
      // 
      this.tabAssemblies.Controls.Add(this.assemblyListEditorControl1);
      this.tabAssemblies.Location = new System.Drawing.Point(4, 22);
      this.tabAssemblies.Name = "tabAssemblies";
      this.tabAssemblies.Padding = new System.Windows.Forms.Padding(3);
      this.tabAssemblies.Size = new System.Drawing.Size(464, 365);
      this.tabAssemblies.TabIndex = 4;
      this.tabAssemblies.Text = "Assemblies";
      this.tabAssemblies.UseVisualStyleBackColor = true;
      // 
      // assemblyListEditorControl1
      // 
      this.assemblyListEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.assemblyListEditorControl1.Location = new System.Drawing.Point(3, 3);
      this.assemblyListEditorControl1.Name = "assemblyListEditorControl1";
      this.assemblyListEditorControl1.Size = new System.Drawing.Size(458, 359);
      this.assemblyListEditorControl1.TabIndex = 0;
      this.assemblyListEditorControl1.PropertyChanged += new System.EventHandler(this.assemblyListEditorControl1_PropertyChanged);
      // 
      // tabLog
      // 
      this.tabLog.Controls.Add(this.lvwLog);
      this.tabLog.Controls.Add(this.splitter1);
      this.tabLog.Controls.Add(this.lvwProcessos);
      this.tabLog.Location = new System.Drawing.Point(4, 22);
      this.tabLog.Name = "tabLog";
      this.tabLog.Padding = new System.Windows.Forms.Padding(3);
      this.tabLog.Size = new System.Drawing.Size(464, 365);
      this.tabLog.TabIndex = 2;
      this.tabLog.Text = "Log";
      this.tabLog.UseVisualStyleBackColor = true;
      // 
      // lvwLog
      // 
      this.lvwLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
      this.lvwLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvwLog.Location = new System.Drawing.Point(3, 128);
      this.lvwLog.MultiSelect = false;
      this.lvwLog.Name = "lvwLog";
      this.lvwLog.Size = new System.Drawing.Size(458, 234);
      this.lvwLog.SmallImageList = this.imlListViewIcons;
      this.lvwLog.TabIndex = 5;
      this.lvwLog.UseCompatibleStateImageBehavior = false;
      this.lvwLog.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Log";
      this.columnHeader2.Width = 800;
      // 
      // imlListViewIcons
      // 
      this.imlListViewIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlListViewIcons.ImageStream")));
      this.imlListViewIcons.TransparentColor = System.Drawing.Color.Transparent;
      this.imlListViewIcons.Images.SetKeyName(0, "RunOk.png");
      this.imlListViewIcons.Images.SetKeyName(1, "RunNotOk.png");
      // 
      // splitter1
      // 
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter1.Location = new System.Drawing.Point(3, 125);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(458, 3);
      this.splitter1.TabIndex = 2;
      this.splitter1.TabStop = false;
      // 
      // lvwProcessos
      // 
      this.lvwProcessos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.lvwProcessos.Dock = System.Windows.Forms.DockStyle.Top;
      this.lvwProcessos.Location = new System.Drawing.Point(3, 3);
      this.lvwProcessos.MultiSelect = false;
      this.lvwProcessos.Name = "lvwProcessos";
      this.lvwProcessos.Size = new System.Drawing.Size(458, 122);
      this.lvwProcessos.SmallImageList = this.imlListViewIcons;
      this.lvwProcessos.TabIndex = 4;
      this.lvwProcessos.UseCompatibleStateImageBehavior = false;
      this.lvwProcessos.View = System.Windows.Forms.View.Details;
      this.lvwProcessos.SelectedIndexChanged += new System.EventHandler(this.lvwProcessos_SelectedIndexChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Processos";
      this.columnHeader1.Width = 800;
      // 
      // timer
      // 
      this.timer.Interval = 3000;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // BaseJobForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(472, 391);
      this.Controls.Add(this.tbcMain);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(445, 279);
      this.Name = "BaseJobForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Configurações";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseJobForm_FormClosing);
      this.trayMenu.ResumeLayout(false);
      this.tabControl.ResumeLayout(false);
      this.gbxStatus.ResumeLayout(false);
      this.gbxStatus.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxOnOff)).EndInit();
      this.tbcMain.ResumeLayout(false);
      this.tabParams.ResumeLayout(false);
      this.tabConfigs.ResumeLayout(false);
      this.tabAssemblies.ResumeLayout(false);
      this.tabLog.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabPage tabControl;
    private System.Windows.Forms.Label lbLastRun;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lbStatusChanged;
    private System.Windows.Forms.Label lbOnOff;
    private System.Windows.Forms.PictureBox pbxOnOff;
    private System.Windows.Forms.Button btnAlteraSenha;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbPassword;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.TabControl tbcMain;
    private System.Windows.Forms.TabPage tabParams;
    protected System.Windows.Forms.GroupBox gbxStatus;
    protected System.Windows.Forms.GroupBox gbxProcessos;
    protected System.Windows.Forms.PropertyGrid ppgParams;
    protected System.Windows.Forms.NotifyIcon tryIcon;
    private System.Windows.Forms.TabPage tabLog;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.TabPage tabConfigs;
    private System.Windows.Forms.PropertyGrid ppgConfigs;
    private System.Windows.Forms.ContextMenuStrip trayMenu;
    private System.Windows.Forms.ToolStripMenuItem tsmiClose;
    private System.Windows.Forms.ToolStripMenuItem tsmiShow;
    private System.Windows.Forms.ToolStripMenuItem tsmiStart;
    private System.Windows.Forms.ToolStripMenuItem tsmiStop;
    private System.Windows.Forms.Button btnRunNow;
    private System.Windows.Forms.Label lbNextRun;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.ListView lvwLog;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ListView lvwProcessos;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ImageList imlListViewIcons;
    private System.Windows.Forms.TabPage tabAssemblies;
    private Databridge.Interfaces.BaseEditors.Controls.AssemblyListEditorControl assemblyListEditorControl1;

  }
}

