using MindFusion.Diagramming.WinForms;
using Iris.PropertyEditors.PropertyEditors.Controls;
namespace Iris.Designer
{
  partial class StructureDesigner
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StructureDesigner));
      this.tbMain = new System.Windows.Forms.ToolStrip();
      this.btnSave = new System.Windows.Forms.ToolStripButton();
      this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
      this.btnSaveSnapshot = new System.Windows.Forms.ToolStripButton();
      this.btnToggleSnapshot = new System.Windows.Forms.ToolStripButton();
      this.btnLoad = new System.Windows.Forms.ToolStripButton();
      this.btnNewProj = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.btnRun = new System.Windows.Forms.ToolStripButton();
      this.btnStep = new System.Windows.Forms.ToolStripButton();
      this.btnReRun = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.btnRunToSelection = new System.Windows.Forms.ToolStripButton();
      this.btnSetRunningPoint = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.btnResetOperation = new System.Windows.Forms.ToolStripButton();
      this.btnRestart = new System.Windows.Forms.ToolStripButton();
      this.btnStop = new System.Windows.Forms.ToolStripButton();
      this.btnBreakPoint = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnHideTools = new System.Windows.Forms.ToolStripButton();
      this.btnHideVars = new System.Windows.Forms.ToolStripButton();
      this.btnHideOut = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
      this.cbxZoom = new System.Windows.Forms.ToolStripComboBox();
      this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
      this.btnZoomActual = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.btnSearch = new System.Windows.Forms.ToolStripButton();
      this.pnlBackGround = new System.Windows.Forms.Panel();
      this.surface = new MindFusion.Diagramming.WinForms.FlowChart();
      this.splitter2 = new System.Windows.Forms.Splitter();
      this.tbcOutput = new System.Windows.Forms.TabControl();
      this.tabOutput = new System.Windows.Forms.TabPage();
      this.lvwLog = new System.Windows.Forms.ListView();
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.imlListViewIcons = new System.Windows.Forms.ImageList(this.components);
      this.toolStrip2 = new System.Windows.Forms.ToolStrip();
      this.btnClearLog = new System.Windows.Forms.ToolStripButton();
      this.btnSaveLog = new System.Windows.Forms.ToolStripButton();
      this.tabBreakPoints = new System.Windows.Forms.TabPage();
      this.lvwBreakPoints = new System.Windows.Forms.ListView();
      this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel5 = new System.Windows.Forms.Panel();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.btnClearBreakpoints = new System.Windows.Forms.ToolStripButton();
      this.btnDeleteBreakPoint = new System.Windows.Forms.ToolStripButton();
      this.tabNotes = new System.Windows.Forms.TabPage();
      this.txtNotes = new System.Windows.Forms.TextBox();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.tbcTools = new System.Windows.Forms.TabControl();
      this.tabOperations = new System.Windows.Forms.TabPage();
      this.tsOperations = new System.Windows.Forms.ToolStrip();
      this.cbxCategories = new System.Windows.Forms.ComboBox();
      this.tabProperties = new System.Windows.Forms.TabPage();
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.imlVars = new System.Windows.Forms.ImageList(this.components);
      this.tbcVars = new System.Windows.Forms.TabControl();
      this.tabVars = new System.Windows.Forms.TabPage();
      this.lvwVars = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnKillVar = new System.Windows.Forms.Button();
      this.btnNewVar = new System.Windows.Forms.Button();
      this.tabResultsets = new System.Windows.Forms.TabPage();
      this.lvwResultSets = new System.Windows.Forms.ListView();
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnKillResultSet = new System.Windows.Forms.Button();
      this.btnNewResultSet = new System.Windows.Forms.Button();
      this.tabSchemas = new System.Windows.Forms.TabPage();
      this.lvwSchemas = new System.Windows.Forms.ListView();
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel4 = new System.Windows.Forms.Panel();
      this.btnCreateAll = new System.Windows.Forms.Button();
      this.btnLoadSchemas = new System.Windows.Forms.Button();
      this.btnSaveSchemas = new System.Windows.Forms.Button();
      this.btnCreateLineType = new System.Windows.Forms.Button();
      this.btnCreateSchemaRS = new System.Windows.Forms.Button();
      this.btnNewXMLSchema = new System.Windows.Forms.Button();
      this.btnKillSchema = new System.Windows.Forms.Button();
      this.btnNewTxtSchema = new System.Windows.Forms.Button();
      this.tabConnections = new System.Windows.Forms.TabPage();
      this.lvwConnections = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel3 = new System.Windows.Forms.Panel();
      this.btnEnableAll = new System.Windows.Forms.Button();
      this.btnDisableAll = new System.Windows.Forms.Button();
      this.btnEditConnection = new System.Windows.Forms.Button();
      this.btnTestConnection = new System.Windows.Forms.Button();
      this.btnCreateResultsets = new System.Windows.Forms.Button();
      this.btnKillConnection = new System.Windows.Forms.Button();
      this.btnNovaConexão = new System.Windows.Forms.Button();
      this.splitter3 = new System.Windows.Forms.Splitter();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.bkpTimer = new System.Windows.Forms.Timer(this.components);
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.stlLastLog = new System.Windows.Forms.ToolStripStatusLabel();
      this.saveSchemaFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.openSchemaFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveLogDialog = new System.Windows.Forms.SaveFileDialog();
      this.tabMRU = new System.Windows.Forms.TabPage();
      this.tsMRU = new System.Windows.Forms.ToolStrip();
      this.tbMain.SuspendLayout();
      this.pnlBackGround.SuspendLayout();
      this.tbcOutput.SuspendLayout();
      this.tabOutput.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.tabBreakPoints.SuspendLayout();
      this.panel5.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.tabNotes.SuspendLayout();
      this.tbcTools.SuspendLayout();
      this.tabOperations.SuspendLayout();
      this.tabProperties.SuspendLayout();
      this.tbcVars.SuspendLayout();
      this.tabVars.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tabResultsets.SuspendLayout();
      this.panel2.SuspendLayout();
      this.tabSchemas.SuspendLayout();
      this.panel4.SuspendLayout();
      this.tabConnections.SuspendLayout();
      this.panel3.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.tabMRU.SuspendLayout();
      this.SuspendLayout();
      // 
      // tbMain
      // 
      this.tbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnSaveAs,
            this.btnSaveSnapshot,
            this.btnToggleSnapshot,
            this.btnLoad,
            this.btnNewProj,
            this.toolStripSeparator2,
            this.btnRun,
            this.btnStep,
            this.btnReRun,
            this.toolStripSeparator6,
            this.btnRunToSelection,
            this.btnSetRunningPoint,
            this.toolStripSeparator4,
            this.btnResetOperation,
            this.btnRestart,
            this.btnStop,
            this.btnBreakPoint,
            this.toolStripSeparator1,
            this.btnHideTools,
            this.btnHideVars,
            this.btnHideOut,
            this.toolStripSeparator3,
            this.btnZoomOut,
            this.cbxZoom,
            this.btnZoomIn,
            this.btnZoomActual,
            this.toolStripSeparator7,
            this.btnSearch});
      this.tbMain.Location = new System.Drawing.Point(0, 0);
      this.tbMain.Name = "tbMain";
      this.tbMain.Size = new System.Drawing.Size(848, 25);
      this.tbMain.TabIndex = 1;
      // 
      // btnSave
      // 
      this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSave.Image = global::Iris.Designer.Properties.Resources.saveHS;
      this.btnSave.ImageTransparentColor = System.Drawing.Color.Black;
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(23, 22);
      this.btnSave.Text = "Save (Ctrl+S)";
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnSaveAs
      // 
      this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSaveAs.Image = global::Iris.Designer.Properties.Resources.save_As;
      this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSaveAs.Name = "btnSaveAs";
      this.btnSaveAs.Size = new System.Drawing.Size(23, 22);
      this.btnSaveAs.Text = "Save As...";
      this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
      // 
      // btnSaveSnapshot
      // 
      this.btnSaveSnapshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSaveSnapshot.Image = global::Iris.Designer.Properties.Resources.saveSnapShot;
      this.btnSaveSnapshot.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSaveSnapshot.Name = "btnSaveSnapshot";
      this.btnSaveSnapshot.Size = new System.Drawing.Size(23, 22);
      this.btnSaveSnapshot.Text = "Save SnapShot (Ctrl+Shift+S)";
      this.btnSaveSnapshot.Click += new System.EventHandler(this.btnSaveSnapshot_Click);
      // 
      // btnToggleSnapshot
      // 
      this.btnToggleSnapshot.CheckOnClick = true;
      this.btnToggleSnapshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnToggleSnapshot.Image = global::Iris.Designer.Properties.Resources.ToggleSnapshotOn;
      this.btnToggleSnapshot.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnToggleSnapshot.Name = "btnToggleSnapshot";
      this.btnToggleSnapshot.Size = new System.Drawing.Size(23, 22);
      this.btnToggleSnapshot.Text = "Toggle Auto Backup";
      this.btnToggleSnapshot.Click += new System.EventHandler(this.btnToggleSnapshot_Click);
      // 
      // btnLoad
      // 
      this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnLoad.ForeColor = System.Drawing.Color.Transparent;
      this.btnLoad.Image = global::Iris.Designer.Properties.Resources.OpenSelectedItemHS;
      this.btnLoad.ImageTransparentColor = System.Drawing.Color.Black;
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(23, 22);
      this.btnLoad.Text = "Load";
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // btnNewProj
      // 
      this.btnNewProj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnNewProj.Image = global::Iris.Designer.Properties.Resources.NewDocumentHS;
      this.btnNewProj.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNewProj.Name = "btnNewProj";
      this.btnNewProj.Size = new System.Drawing.Size(23, 22);
      this.btnNewProj.Text = "Novo Projeto";
      this.btnNewProj.Click += new System.EventHandler(this.btnNewProj_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // btnRun
      // 
      this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRun.Image = global::Iris.Designer.Properties.Resources.FormRunHS;
      this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(23, 22);
      this.btnRun.Text = "Run (F5)";
      this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
      // 
      // btnStep
      // 
      this.btnStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnStep.Image = global::Iris.Designer.Properties.Resources.Step;
      this.btnStep.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnStep.Name = "btnStep";
      this.btnStep.Size = new System.Drawing.Size(23, 22);
      this.btnStep.Text = "Step (F10)";
      this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
      // 
      // btnReRun
      // 
      this.btnReRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnReRun.Image = global::Iris.Designer.Properties.Resources.ReRun;
      this.btnReRun.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnReRun.Name = "btnReRun";
      this.btnReRun.Size = new System.Drawing.Size(23, 22);
      this.btnReRun.Text = "Re-Run (F2)";
      this.btnReRun.Click += new System.EventHandler(this.btnReRun_Click);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
      // 
      // btnRunToSelection
      // 
      this.btnRunToSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRunToSelection.Image = ((System.Drawing.Image)(resources.GetObject("btnRunToSelection.Image")));
      this.btnRunToSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRunToSelection.Name = "btnRunToSelection";
      this.btnRunToSelection.Size = new System.Drawing.Size(23, 22);
      this.btnRunToSelection.Text = "Run To Selection (F11)";
      this.btnRunToSelection.Click += new System.EventHandler(this.btnRunToSelection_Click);
      // 
      // btnSetRunningPoint
      // 
      this.btnSetRunningPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSetRunningPoint.Image = ((System.Drawing.Image)(resources.GetObject("btnSetRunningPoint.Image")));
      this.btnSetRunningPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSetRunningPoint.Name = "btnSetRunningPoint";
      this.btnSetRunningPoint.Size = new System.Drawing.Size(23, 22);
      this.btnSetRunningPoint.Text = "Set Running Point (F7)";
      this.btnSetRunningPoint.Click += new System.EventHandler(this.btnSetRunningPoint_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // btnResetOperation
      // 
      this.btnResetOperation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnResetOperation.Image = ((System.Drawing.Image)(resources.GetObject("btnResetOperation.Image")));
      this.btnResetOperation.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnResetOperation.Name = "btnResetOperation";
      this.btnResetOperation.Size = new System.Drawing.Size(23, 22);
      this.btnResetOperation.Text = "Reset Operation (F6)";
      this.btnResetOperation.Click += new System.EventHandler(this.btnResetOperation_Click);
      // 
      // btnRestart
      // 
      this.btnRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRestart.Image = global::Iris.Designer.Properties.Resources.RestartHS;
      this.btnRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRestart.Name = "btnRestart";
      this.btnRestart.Size = new System.Drawing.Size(23, 22);
      this.btnRestart.Text = "Restart (F3)";
      this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
      // 
      // btnStop
      // 
      this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnStop.Image = global::Iris.Designer.Properties.Resources.Stop;
      this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(23, 22);
      this.btnStop.Text = "Stop (Pause)";
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // btnBreakPoint
      // 
      this.btnBreakPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnBreakPoint.Image = global::Iris.Designer.Properties.Resources.BreakPoint;
      this.btnBreakPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnBreakPoint.Name = "btnBreakPoint";
      this.btnBreakPoint.Size = new System.Drawing.Size(23, 22);
      this.btnBreakPoint.Text = "BreakPoint (F9)";
      this.btnBreakPoint.Click += new System.EventHandler(this.btnBreakPoint_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnHideTools
      // 
      this.btnHideTools.Checked = true;
      this.btnHideTools.CheckOnClick = true;
      this.btnHideTools.CheckState = System.Windows.Forms.CheckState.Checked;
      this.btnHideTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnHideTools.Image = global::Iris.Designer.Properties.Resources.HideTools;
      this.btnHideTools.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnHideTools.Name = "btnHideTools";
      this.btnHideTools.Size = new System.Drawing.Size(23, 22);
      this.btnHideTools.Text = "Hide Tools (F4)";
      this.btnHideTools.Click += new System.EventHandler(this.btnHideTools_Click);
      // 
      // btnHideVars
      // 
      this.btnHideVars.Checked = true;
      this.btnHideVars.CheckOnClick = true;
      this.btnHideVars.CheckState = System.Windows.Forms.CheckState.Checked;
      this.btnHideVars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnHideVars.Image = global::Iris.Designer.Properties.Resources.HideVars;
      this.btnHideVars.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnHideVars.Name = "btnHideVars";
      this.btnHideVars.Size = new System.Drawing.Size(23, 22);
      this.btnHideVars.Text = "Hide Vars (F8)";
      this.btnHideVars.Click += new System.EventHandler(this.btnHideVars_Click);
      // 
      // btnHideOut
      // 
      this.btnHideOut.Checked = true;
      this.btnHideOut.CheckOnClick = true;
      this.btnHideOut.CheckState = System.Windows.Forms.CheckState.Checked;
      this.btnHideOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnHideOut.Image = global::Iris.Designer.Properties.Resources.HideOutput;
      this.btnHideOut.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnHideOut.Name = "btnHideOut";
      this.btnHideOut.Size = new System.Drawing.Size(23, 22);
      this.btnHideOut.Text = "Hide Output";
      this.btnHideOut.Click += new System.EventHandler(this.btnHideOut_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // btnZoomOut
      // 
      this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
      this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnZoomOut.Name = "btnZoomOut";
      this.btnZoomOut.Size = new System.Drawing.Size(23, 22);
      this.btnZoomOut.Text = "Zoom Out";
      this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
      // 
      // cbxZoom
      // 
      this.cbxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxZoom.Items.AddRange(new object[] {
            "200%",
            "150%",
            "125%",
            "100%",
            "75%",
            "50%",
            "25%",
            "10%",
            "5%"});
      this.cbxZoom.Name = "cbxZoom";
      this.cbxZoom.Size = new System.Drawing.Size(75, 25);
      this.cbxZoom.SelectedIndexChanged += new System.EventHandler(this.cbxZoom_SelectedIndexChanged);
      // 
      // btnZoomIn
      // 
      this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
      this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnZoomIn.Name = "btnZoomIn";
      this.btnZoomIn.Size = new System.Drawing.Size(23, 22);
      this.btnZoomIn.Text = "Zoom In";
      this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
      // 
      // btnZoomActual
      // 
      this.btnZoomActual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnZoomActual.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomActual.Image")));
      this.btnZoomActual.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnZoomActual.Name = "btnZoomActual";
      this.btnZoomActual.Size = new System.Drawing.Size(23, 22);
      this.btnZoomActual.Text = "Zoom 100%";
      this.btnZoomActual.Click += new System.EventHandler(this.btnZoomActual_Click);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
      // 
      // btnSearch
      // 
      this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSearch.Image = global::Iris.Designer.Properties.Resources.Find;
      this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(23, 22);
      this.btnSearch.Text = "Find (Ctrl+F)";
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // pnlBackGround
      // 
      this.pnlBackGround.Controls.Add(this.surface);
      this.pnlBackGround.Controls.Add(this.splitter2);
      this.pnlBackGround.Controls.Add(this.tbcOutput);
      this.pnlBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlBackGround.Location = new System.Drawing.Point(203, 25);
      this.pnlBackGround.Name = "pnlBackGround";
      this.pnlBackGround.Size = new System.Drawing.Size(425, 511);
      this.pnlBackGround.TabIndex = 3;
      // 
      // surface
      // 
      this.surface.AllowRefLinks = false;
      this.surface.AllowSplitArrows = true;
      this.surface.AllowUnanchoredArrows = false;
      this.surface.AntiAlias = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      this.surface.ArrowBaseSize = 16F;
      this.surface.ArrowCascadeOrientation = MindFusion.Diagramming.WinForms.Orientation.Horizontal;
      this.surface.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.surface.ArrowCrossings = MindFusion.Diagramming.WinForms.ArrowCrossings.Arcs;
      this.surface.ArrowEndsMovable = false;
      this.surface.ArrowHead = MindFusion.Diagramming.WinForms.ArrowHead.BowArrow;
      this.surface.ArrowHeadSize = 16F;
      this.surface.ArrowIntermSize = 16F;
      this.surface.ArrowSegments = ((short)(3));
      this.surface.ArrowStyle = MindFusion.Diagramming.WinForms.ArrowStyle.Cascading;
      this.surface.Behavior = MindFusion.Diagramming.WinForms.BehaviorType.CreateArrow;
      this.surface.CrossingRadius = 4F;
      this.surface.DisabledMnpColor = System.Drawing.Color.Gray;
      this.surface.DocExtents = ((System.Drawing.RectangleF)(resources.GetObject("surface.DocExtents")));
      this.surface.Dock = System.Windows.Forms.DockStyle.Fill;
      this.surface.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.surface.GridSizeX = 6F;
      this.surface.GridSizeY = 6F;
      this.surface.GridStyle = MindFusion.Diagramming.WinForms.GridStyle.Lines;
      this.surface.InplaceEditFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.surface.Location = new System.Drawing.Point(0, 0);
      this.surface.MeasureUnit = System.Drawing.GraphicsUnit.Pixel;
      this.surface.MiddleButtonActions = MindFusion.Diagramming.WinForms.MouseButtonActions.Cancel;
      this.surface.Name = "surface";
      this.surface.RightButtonActions = MindFusion.Diagramming.WinForms.MouseButtonActions.Pan;
      this.surface.RoutingOptions.GridSize = 16F;
      this.surface.RoutingOptions.NodeVicinitySize = 48F;
      this.surface.SelHandleSize = 8F;
      this.surface.ShowGrid = true;
      this.surface.Size = new System.Drawing.Size(425, 368);
      this.surface.TabIndex = 2;
      this.surface.TableCaptionHeight = 23F;
      this.surface.TableColWidth = 30F;
      this.surface.TableRowCount = 0;
      this.surface.TableRowHeight = 17F;
      this.surface.ArrowCreated += new MindFusion.Diagramming.WinForms.ArrowEvent(this.Surface_ArrowCreated);
      this.surface.ArrowCreating += new MindFusion.Diagramming.WinForms.AttachConfirmation(this.Surface_ArrowCreating);
      this.surface.ArrowDeleting += new MindFusion.Diagramming.WinForms.ArrowConfirmation(this.Surface_ArrowDeleting);
      this.surface.DocClicked += new MindFusion.Diagramming.WinForms.DocMouseEvent(this.Surface_DocClicked);
      this.surface.SelectionMoved += new MindFusion.Diagramming.WinForms.SelectionEvent(this.surface_SelectionMoved);
      this.surface.SelectionChanged += new MindFusion.Diagramming.WinForms.SelectionEvent(this.surface_SelectionChanged);
      this.surface.TableCreated += new MindFusion.Diagramming.WinForms.TableEvent(this.surface_TableCreated);
      this.surface.TableDeleted += new MindFusion.Diagramming.WinForms.TableEvent(this.Surface_TableDeleted);
      this.surface.TableModified += new MindFusion.Diagramming.WinForms.TableMouseEvent(this.surface_TableModified);
      this.surface.TableDeleting += new MindFusion.Diagramming.WinForms.TableConfirmation(this.Surface_TableDeleting);
      this.surface.TableClicked += new MindFusion.Diagramming.WinForms.TableMouseEvent(this.Surface_TableClicked);
      this.surface.MouseDown += new System.Windows.Forms.MouseEventHandler(this.surface_MouseDown);
      // 
      // splitter2
      // 
      this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter2.Location = new System.Drawing.Point(0, 368);
      this.splitter2.Name = "splitter2";
      this.splitter2.Size = new System.Drawing.Size(425, 3);
      this.splitter2.TabIndex = 1;
      this.splitter2.TabStop = false;
      // 
      // tbcOutput
      // 
      this.tbcOutput.Controls.Add(this.tabOutput);
      this.tbcOutput.Controls.Add(this.tabBreakPoints);
      this.tbcOutput.Controls.Add(this.tabNotes);
      this.tbcOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tbcOutput.Location = new System.Drawing.Point(0, 371);
      this.tbcOutput.Name = "tbcOutput";
      this.tbcOutput.SelectedIndex = 0;
      this.tbcOutput.Size = new System.Drawing.Size(425, 140);
      this.tbcOutput.TabIndex = 0;
      // 
      // tabOutput
      // 
      this.tabOutput.Controls.Add(this.lvwLog);
      this.tabOutput.Controls.Add(this.toolStrip2);
      this.tabOutput.Location = new System.Drawing.Point(4, 22);
      this.tabOutput.Name = "tabOutput";
      this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
      this.tabOutput.Size = new System.Drawing.Size(417, 114);
      this.tabOutput.TabIndex = 1;
      this.tabOutput.Text = "Output";
      this.tabOutput.UseVisualStyleBackColor = true;
      // 
      // lvwLog
      // 
      this.lvwLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
      this.lvwLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvwLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.lvwLog.Location = new System.Drawing.Point(27, 3);
      this.lvwLog.MultiSelect = false;
      this.lvwLog.Name = "lvwLog";
      this.lvwLog.Size = new System.Drawing.Size(387, 108);
      this.lvwLog.SmallImageList = this.imlListViewIcons;
      this.lvwLog.TabIndex = 6;
      this.lvwLog.UseCompatibleStateImageBehavior = false;
      this.lvwLog.View = System.Windows.Forms.View.Details;
      this.lvwLog.DoubleClick += new System.EventHandler(this.lvwLog_DoubleClick);
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "";
      this.columnHeader5.Width = 800;
      // 
      // imlListViewIcons
      // 
      this.imlListViewIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlListViewIcons.ImageStream")));
      this.imlListViewIcons.TransparentColor = System.Drawing.Color.Transparent;
      this.imlListViewIcons.Images.SetKeyName(0, "RunOk.png");
      this.imlListViewIcons.Images.SetKeyName(1, "RunNotOk.png");
      this.imlListViewIcons.Images.SetKeyName(2, "BreakPoint.png");
      this.imlListViewIcons.Images.SetKeyName(3, "FindItem.png");
      // 
      // toolStrip2
      // 
      this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
      this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearLog,
            this.btnSaveLog});
      this.toolStrip2.Location = new System.Drawing.Point(3, 3);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.toolStrip2.Size = new System.Drawing.Size(24, 108);
      this.toolStrip2.TabIndex = 12;
      this.toolStrip2.Text = "toolStrip2";
      // 
      // btnClearLog
      // 
      this.btnClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnClearLog.Image = global::Iris.Designer.Properties.Resources.ClearLog;
      this.btnClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnClearLog.Name = "btnClearLog";
      this.btnClearLog.Size = new System.Drawing.Size(21, 20);
      this.btnClearLog.Text = "Clear Log";
      this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
      // 
      // btnSaveLog
      // 
      this.btnSaveLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSaveLog.Image = global::Iris.Designer.Properties.Resources.saveHS;
      this.btnSaveLog.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSaveLog.Name = "btnSaveLog";
      this.btnSaveLog.Size = new System.Drawing.Size(21, 20);
      this.btnSaveLog.Text = "Save Log";
      this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
      // 
      // tabBreakPoints
      // 
      this.tabBreakPoints.Controls.Add(this.lvwBreakPoints);
      this.tabBreakPoints.Controls.Add(this.panel5);
      this.tabBreakPoints.Location = new System.Drawing.Point(4, 22);
      this.tabBreakPoints.Name = "tabBreakPoints";
      this.tabBreakPoints.Padding = new System.Windows.Forms.Padding(3);
      this.tabBreakPoints.Size = new System.Drawing.Size(417, 114);
      this.tabBreakPoints.TabIndex = 2;
      this.tabBreakPoints.Text = "Breakpoints";
      this.tabBreakPoints.UseVisualStyleBackColor = true;
      // 
      // lvwBreakPoints
      // 
      this.lvwBreakPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
      this.lvwBreakPoints.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvwBreakPoints.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.lvwBreakPoints.Location = new System.Drawing.Point(25, 3);
      this.lvwBreakPoints.MultiSelect = false;
      this.lvwBreakPoints.Name = "lvwBreakPoints";
      this.lvwBreakPoints.Size = new System.Drawing.Size(389, 108);
      this.lvwBreakPoints.SmallImageList = this.imlListViewIcons;
      this.lvwBreakPoints.TabIndex = 7;
      this.lvwBreakPoints.UseCompatibleStateImageBehavior = false;
      this.lvwBreakPoints.View = System.Windows.Forms.View.Details;
      this.lvwBreakPoints.DoubleClick += new System.EventHandler(this.lvwLog_DoubleClick);
      // 
      // columnHeader6
      // 
      this.columnHeader6.Text = "";
      this.columnHeader6.Width = 800;
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.toolStrip);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel5.Location = new System.Drawing.Point(3, 3);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(22, 108);
      this.panel5.TabIndex = 0;
      // 
      // toolStrip
      // 
      this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearBreakpoints,
            this.btnDeleteBreakPoint});
      this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.toolStrip.Size = new System.Drawing.Size(22, 108);
      this.toolStrip.TabIndex = 0;
      this.toolStrip.Text = "toolStrip1";
      // 
      // btnClearBreakpoints
      // 
      this.btnClearBreakpoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnClearBreakpoints.Image = global::Iris.Designer.Properties.Resources.DeleteBreakPoints;
      this.btnClearBreakpoints.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnClearBreakpoints.Name = "btnClearBreakpoints";
      this.btnClearBreakpoints.Size = new System.Drawing.Size(20, 20);
      this.btnClearBreakpoints.Text = "Exclui todos os breakpoints do projeto";
      this.btnClearBreakpoints.Click += new System.EventHandler(this.btnClearBreakpoints_Click);
      // 
      // btnDeleteBreakPoint
      // 
      this.btnDeleteBreakPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnDeleteBreakPoint.Image = global::Iris.Designer.Properties.Resources.Delete;
      this.btnDeleteBreakPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnDeleteBreakPoint.Name = "btnDeleteBreakPoint";
      this.btnDeleteBreakPoint.Size = new System.Drawing.Size(20, 20);
      this.btnDeleteBreakPoint.Text = "Exclui o breakpoint ativo";
      this.btnDeleteBreakPoint.Click += new System.EventHandler(this.btnDeleteBreakPoint_Click);
      // 
      // tabNotes
      // 
      this.tabNotes.Controls.Add(this.txtNotes);
      this.tabNotes.Location = new System.Drawing.Point(4, 22);
      this.tabNotes.Name = "tabNotes";
      this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
      this.tabNotes.Size = new System.Drawing.Size(417, 114);
      this.tabNotes.TabIndex = 3;
      this.tabNotes.Text = "Notas";
      this.tabNotes.UseVisualStyleBackColor = true;
      // 
      // txtNotes
      // 
      this.txtNotes.AcceptsReturn = true;
      this.txtNotes.AcceptsTab = true;
      this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtNotes.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtNotes.Location = new System.Drawing.Point(3, 3);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtNotes.Size = new System.Drawing.Size(411, 108);
      this.txtNotes.TabIndex = 0;
      this.txtNotes.Validated += new System.EventHandler(this.txtNotes_Validated);
      // 
      // splitter1
      // 
      this.splitter1.Location = new System.Drawing.Point(200, 25);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(3, 511);
      this.splitter1.TabIndex = 4;
      this.splitter1.TabStop = false;
      // 
      // tbcTools
      // 
      this.tbcTools.Controls.Add(this.tabOperations);
      this.tbcTools.Controls.Add(this.tabProperties);
      this.tbcTools.Controls.Add(this.tabMRU);
      this.tbcTools.Dock = System.Windows.Forms.DockStyle.Left;
      this.tbcTools.ImageList = this.imlVars;
      this.tbcTools.Location = new System.Drawing.Point(0, 25);
      this.tbcTools.Name = "tbcTools";
      this.tbcTools.SelectedIndex = 0;
      this.tbcTools.Size = new System.Drawing.Size(200, 511);
      this.tbcTools.TabIndex = 0;
      // 
      // tabOperations
      // 
      this.tabOperations.Controls.Add(this.tsOperations);
      this.tabOperations.Controls.Add(this.cbxCategories);
      this.tabOperations.ImageIndex = 2;
      this.tabOperations.Location = new System.Drawing.Point(4, 23);
      this.tabOperations.Name = "tabOperations";
      this.tabOperations.Padding = new System.Windows.Forms.Padding(3);
      this.tabOperations.Size = new System.Drawing.Size(192, 484);
      this.tabOperations.TabIndex = 0;
      this.tabOperations.UseVisualStyleBackColor = true;
      // 
      // tsOperations
      // 
      this.tsOperations.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tsOperations.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsOperations.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
      this.tsOperations.Location = new System.Drawing.Point(3, 24);
      this.tsOperations.Name = "tsOperations";
      this.tsOperations.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.tsOperations.Size = new System.Drawing.Size(186, 457);
      this.tsOperations.TabIndex = 0;
      this.tsOperations.Text = "toolStrip1";
      // 
      // cbxCategories
      // 
      this.cbxCategories.Dock = System.Windows.Forms.DockStyle.Top;
      this.cbxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxCategories.FormattingEnabled = true;
      this.cbxCategories.Location = new System.Drawing.Point(3, 3);
      this.cbxCategories.MaxDropDownItems = 30;
      this.cbxCategories.Name = "cbxCategories";
      this.cbxCategories.Size = new System.Drawing.Size(186, 21);
      this.cbxCategories.TabIndex = 1;
      this.cbxCategories.SelectedIndexChanged += new System.EventHandler(this.cbxCategories_SelectedIndexChanged);
      // 
      // tabProperties
      // 
      this.tabProperties.Controls.Add(this.propertyGrid);
      this.tabProperties.ImageIndex = 3;
      this.tabProperties.Location = new System.Drawing.Point(4, 23);
      this.tabProperties.Name = "tabProperties";
      this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
      this.tabProperties.Size = new System.Drawing.Size(192, 484);
      this.tabProperties.TabIndex = 1;
      this.tabProperties.UseVisualStyleBackColor = true;
      // 
      // propertyGrid
      // 
      this.propertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
      this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid.Location = new System.Drawing.Point(3, 3);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.Size = new System.Drawing.Size(186, 478);
      this.propertyGrid.TabIndex = 0;
      this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
      this.propertyGrid.SelectedObjectsChanged += new System.EventHandler(this.propertyGrid_SelectedObjectsChanged);
      // 
      // imlVars
      // 
      this.imlVars.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlVars.ImageStream")));
      this.imlVars.TransparentColor = System.Drawing.Color.Magenta;
      this.imlVars.Images.SetKeyName(0, "GlobalVar.png");
      this.imlVars.Images.SetKeyName(1, "Connections.png");
      this.imlVars.Images.SetKeyName(2, "Ops.png");
      this.imlVars.Images.SetKeyName(3, "Props.png");
      this.imlVars.Images.SetKeyName(4, "Tools.png");
      this.imlVars.Images.SetKeyName(5, "ResultSet.png");
      this.imlVars.Images.SetKeyName(6, "FileEntity.png");
      this.imlVars.Images.SetKeyName(7, "TextFile.png");
      this.imlVars.Images.SetKeyName(8, "XMLFile.png");
      // 
      // tbcVars
      // 
      this.tbcVars.Controls.Add(this.tabVars);
      this.tbcVars.Controls.Add(this.tabResultsets);
      this.tbcVars.Controls.Add(this.tabSchemas);
      this.tbcVars.Controls.Add(this.tabConnections);
      this.tbcVars.Dock = System.Windows.Forms.DockStyle.Right;
      this.tbcVars.ImageList = this.imlVars;
      this.tbcVars.Location = new System.Drawing.Point(628, 25);
      this.tbcVars.Name = "tbcVars";
      this.tbcVars.SelectedIndex = 0;
      this.tbcVars.Size = new System.Drawing.Size(220, 511);
      this.tbcVars.TabIndex = 3;
      // 
      // tabVars
      // 
      this.tabVars.Controls.Add(this.lvwVars);
      this.tabVars.Controls.Add(this.panel1);
      this.tabVars.ImageIndex = 0;
      this.tabVars.Location = new System.Drawing.Point(4, 23);
      this.tabVars.Name = "tabVars";
      this.tabVars.Padding = new System.Windows.Forms.Padding(3);
      this.tabVars.Size = new System.Drawing.Size(212, 484);
      this.tabVars.TabIndex = 0;
      this.tabVars.UseVisualStyleBackColor = true;
      // 
      // lvwVars
      // 
      this.lvwVars.CheckBoxes = true;
      this.lvwVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.lvwVars.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvwVars.Location = new System.Drawing.Point(3, 33);
      this.lvwVars.MultiSelect = false;
      this.lvwVars.Name = "lvwVars";
      this.lvwVars.Size = new System.Drawing.Size(206, 448);
      this.lvwVars.SmallImageList = this.imlVars;
      this.lvwVars.TabIndex = 2;
      this.lvwVars.UseCompatibleStateImageBehavior = false;
      this.lvwVars.View = System.Windows.Forms.View.Details;
      this.lvwVars.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwResultSets_ItemCheck);
      this.lvwVars.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwVars_ItemChecked);
      this.lvwVars.SelectedIndexChanged += new System.EventHandler(this.lvwVars_SelectedIndexChanged);
      this.lvwVars.Click += new System.EventHandler(this.lvwVars_SelectedIndexChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Variáveis";
      this.columnHeader1.Width = 181;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnKillVar);
      this.panel1.Controls.Add(this.btnNewVar);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(206, 30);
      this.panel1.TabIndex = 3;
      // 
      // btnKillVar
      // 
      this.btnKillVar.Location = new System.Drawing.Point(107, 3);
      this.btnKillVar.Name = "btnKillVar";
      this.btnKillVar.Size = new System.Drawing.Size(96, 23);
      this.btnKillVar.TabIndex = 2;
      this.btnKillVar.Text = "Excluir";
      this.btnKillVar.UseVisualStyleBackColor = true;
      this.btnKillVar.Click += new System.EventHandler(this.btnKillVar_Click);
      // 
      // btnNewVar
      // 
      this.btnNewVar.Location = new System.Drawing.Point(5, 3);
      this.btnNewVar.Name = "btnNewVar";
      this.btnNewVar.Size = new System.Drawing.Size(96, 23);
      this.btnNewVar.TabIndex = 1;
      this.btnNewVar.Text = "Nova...";
      this.btnNewVar.UseVisualStyleBackColor = true;
      this.btnNewVar.Click += new System.EventHandler(this.btnNewVar_Click);
      // 
      // tabResultsets
      // 
      this.tabResultsets.Controls.Add(this.lvwResultSets);
      this.tabResultsets.Controls.Add(this.panel2);
      this.tabResultsets.ImageIndex = 5;
      this.tabResultsets.Location = new System.Drawing.Point(4, 23);
      this.tabResultsets.Name = "tabResultsets";
      this.tabResultsets.Padding = new System.Windows.Forms.Padding(3);
      this.tabResultsets.Size = new System.Drawing.Size(212, 484);
      this.tabResultsets.TabIndex = 1;
      this.tabResultsets.UseVisualStyleBackColor = true;
      // 
      // lvwResultSets
      // 
      this.lvwResultSets.CheckBoxes = true;
      this.lvwResultSets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
      this.lvwResultSets.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvwResultSets.Location = new System.Drawing.Point(3, 33);
      this.lvwResultSets.MultiSelect = false;
      this.lvwResultSets.Name = "lvwResultSets";
      this.lvwResultSets.Size = new System.Drawing.Size(206, 448);
      this.lvwResultSets.SmallImageList = this.imlVars;
      this.lvwResultSets.TabIndex = 4;
      this.lvwResultSets.UseCompatibleStateImageBehavior = false;
      this.lvwResultSets.View = System.Windows.Forms.View.Details;
      this.lvwResultSets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwResultSets_ItemCheck);
      this.lvwResultSets.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwVars_ItemChecked);
      this.lvwResultSets.SelectedIndexChanged += new System.EventHandler(this.lvwVars_SelectedIndexChanged);
      this.lvwResultSets.Click += new System.EventHandler(this.lvwVars_SelectedIndexChanged);
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Resultsets";
      this.columnHeader2.Width = 181;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnKillResultSet);
      this.panel2.Controls.Add(this.btnNewResultSet);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(206, 30);
      this.panel2.TabIndex = 5;
      // 
      // btnKillResultSet
      // 
      this.btnKillResultSet.Location = new System.Drawing.Point(105, 3);
      this.btnKillResultSet.Name = "btnKillResultSet";
      this.btnKillResultSet.Size = new System.Drawing.Size(96, 23);
      this.btnKillResultSet.TabIndex = 2;
      this.btnKillResultSet.Text = "Excluir";
      this.btnKillResultSet.UseVisualStyleBackColor = true;
      this.btnKillResultSet.Click += new System.EventHandler(this.btnKillResultSet_Click);
      // 
      // btnNewResultSet
      // 
      this.btnNewResultSet.Location = new System.Drawing.Point(5, 3);
      this.btnNewResultSet.Name = "btnNewResultSet";
      this.btnNewResultSet.Size = new System.Drawing.Size(96, 23);
      this.btnNewResultSet.TabIndex = 3;
      this.btnNewResultSet.Text = "Novo...";
      this.btnNewResultSet.UseVisualStyleBackColor = true;
      this.btnNewResultSet.Click += new System.EventHandler(this.btnNewResultSet_Click);
      // 
      // tabSchemas
      // 
      this.tabSchemas.Controls.Add(this.lvwSchemas);
      this.tabSchemas.Controls.Add(this.panel4);
      this.tabSchemas.ImageIndex = 6;
      this.tabSchemas.Location = new System.Drawing.Point(4, 23);
      this.tabSchemas.Name = "tabSchemas";
      this.tabSchemas.Padding = new System.Windows.Forms.Padding(3);
      this.tabSchemas.Size = new System.Drawing.Size(212, 484);
      this.tabSchemas.TabIndex = 3;
      this.tabSchemas.UseVisualStyleBackColor = true;
      // 
      // lvwSchemas
      // 
      this.lvwSchemas.CheckBoxes = true;
      this.lvwSchemas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
      this.lvwSchemas.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvwSchemas.Location = new System.Drawing.Point(3, 151);
      this.lvwSchemas.MultiSelect = false;
      this.lvwSchemas.Name = "lvwSchemas";
      this.lvwSchemas.Size = new System.Drawing.Size(206, 330);
      this.lvwSchemas.SmallImageList = this.imlVars;
      this.lvwSchemas.TabIndex = 8;
      this.lvwSchemas.UseCompatibleStateImageBehavior = false;
      this.lvwSchemas.View = System.Windows.Forms.View.Details;
      this.lvwSchemas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwResultSets_ItemCheck);
      this.lvwSchemas.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwVars_ItemChecked);
      this.lvwSchemas.SelectedIndexChanged += new System.EventHandler(this.lvwVars_SelectedIndexChanged);
      this.lvwSchemas.Click += new System.EventHandler(this.lvwVars_SelectedIndexChanged);
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Schemas";
      this.columnHeader4.Width = 181;
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.btnCreateAll);
      this.panel4.Controls.Add(this.btnLoadSchemas);
      this.panel4.Controls.Add(this.btnSaveSchemas);
      this.panel4.Controls.Add(this.btnCreateLineType);
      this.panel4.Controls.Add(this.btnCreateSchemaRS);
      this.panel4.Controls.Add(this.btnNewXMLSchema);
      this.panel4.Controls.Add(this.btnKillSchema);
      this.panel4.Controls.Add(this.btnNewTxtSchema);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel4.Location = new System.Drawing.Point(3, 3);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(206, 148);
      this.panel4.TabIndex = 7;
      // 
      // btnCreateAll
      // 
      this.btnCreateAll.Location = new System.Drawing.Point(107, 32);
      this.btnCreateAll.Name = "btnCreateAll";
      this.btnCreateAll.Size = new System.Drawing.Size(96, 23);
      this.btnCreateAll.TabIndex = 9;
      this.btnCreateAll.Text = "Criar Todos";
      this.btnCreateAll.UseVisualStyleBackColor = true;
      this.btnCreateAll.Click += new System.EventHandler(this.btnCreateAll_Click);
      // 
      // btnLoadSchemas
      // 
      this.btnLoadSchemas.Location = new System.Drawing.Point(107, 119);
      this.btnLoadSchemas.Name = "btnLoadSchemas";
      this.btnLoadSchemas.Size = new System.Drawing.Size(96, 23);
      this.btnLoadSchemas.TabIndex = 8;
      this.btnLoadSchemas.Text = "Load...";
      this.btnLoadSchemas.UseVisualStyleBackColor = true;
      this.btnLoadSchemas.Click += new System.EventHandler(this.btnLoadSchemas_Click);
      // 
      // btnSaveSchemas
      // 
      this.btnSaveSchemas.Location = new System.Drawing.Point(5, 119);
      this.btnSaveSchemas.Name = "btnSaveSchemas";
      this.btnSaveSchemas.Size = new System.Drawing.Size(96, 23);
      this.btnSaveSchemas.TabIndex = 7;
      this.btnSaveSchemas.Text = "Save...";
      this.btnSaveSchemas.UseVisualStyleBackColor = true;
      this.btnSaveSchemas.Click += new System.EventHandler(this.btnSaveSchemas_Click);
      // 
      // btnCreateLineType
      // 
      this.btnCreateLineType.Location = new System.Drawing.Point(5, 61);
      this.btnCreateLineType.Name = "btnCreateLineType";
      this.btnCreateLineType.Size = new System.Drawing.Size(198, 23);
      this.btnCreateLineType.TabIndex = 6;
      this.btnCreateLineType.Text = "Criar Linha a partir de Tabelas";
      this.btnCreateLineType.UseVisualStyleBackColor = true;
      this.btnCreateLineType.Click += new System.EventHandler(this.btnCreateLineType_Click);
      // 
      // btnCreateSchemaRS
      // 
      this.btnCreateSchemaRS.Location = new System.Drawing.Point(5, 32);
      this.btnCreateSchemaRS.Name = "btnCreateSchemaRS";
      this.btnCreateSchemaRS.Size = new System.Drawing.Size(96, 23);
      this.btnCreateSchemaRS.TabIndex = 5;
      this.btnCreateSchemaRS.Text = "Criar Resultsets";
      this.btnCreateSchemaRS.UseVisualStyleBackColor = true;
      this.btnCreateSchemaRS.Click += new System.EventHandler(this.btnCreateSchemaRS_Click);
      // 
      // btnNewXMLSchema
      // 
      this.btnNewXMLSchema.Location = new System.Drawing.Point(107, 3);
      this.btnNewXMLSchema.Name = "btnNewXMLSchema";
      this.btnNewXMLSchema.Size = new System.Drawing.Size(96, 23);
      this.btnNewXMLSchema.TabIndex = 4;
      this.btnNewXMLSchema.Text = "Novo XML...";
      this.btnNewXMLSchema.UseVisualStyleBackColor = true;
      this.btnNewXMLSchema.Click += new System.EventHandler(this.btnNewXMLSchema_Click);
      // 
      // btnKillSchema
      // 
      this.btnKillSchema.Location = new System.Drawing.Point(5, 90);
      this.btnKillSchema.Name = "btnKillSchema";
      this.btnKillSchema.Size = new System.Drawing.Size(196, 23);
      this.btnKillSchema.TabIndex = 2;
      this.btnKillSchema.Text = "Excluir";
      this.btnKillSchema.UseVisualStyleBackColor = true;
      this.btnKillSchema.Click += new System.EventHandler(this.btnKillSchema_Click);
      // 
      // btnNewTxtSchema
      // 
      this.btnNewTxtSchema.Location = new System.Drawing.Point(5, 3);
      this.btnNewTxtSchema.Name = "btnNewTxtSchema";
      this.btnNewTxtSchema.Size = new System.Drawing.Size(96, 23);
      this.btnNewTxtSchema.TabIndex = 3;
      this.btnNewTxtSchema.Text = "Novo TXT...";
      this.btnNewTxtSchema.UseVisualStyleBackColor = true;
      this.btnNewTxtSchema.Click += new System.EventHandler(this.btnNewTxtSchema_Click);
      // 
      // tabConnections
      // 
      this.tabConnections.Controls.Add(this.lvwConnections);
      this.tabConnections.Controls.Add(this.panel3);
      this.tabConnections.ImageIndex = 1;
      this.tabConnections.Location = new System.Drawing.Point(4, 23);
      this.tabConnections.Name = "tabConnections";
      this.tabConnections.Padding = new System.Windows.Forms.Padding(3);
      this.tabConnections.Size = new System.Drawing.Size(212, 484);
      this.tabConnections.TabIndex = 2;
      this.tabConnections.UseVisualStyleBackColor = true;
      // 
      // lvwConnections
      // 
      this.lvwConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
      this.lvwConnections.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvwConnections.Location = new System.Drawing.Point(3, 135);
      this.lvwConnections.MultiSelect = false;
      this.lvwConnections.Name = "lvwConnections";
      this.lvwConnections.Size = new System.Drawing.Size(206, 346);
      this.lvwConnections.SmallImageList = this.imlVars;
      this.lvwConnections.TabIndex = 4;
      this.lvwConnections.UseCompatibleStateImageBehavior = false;
      this.lvwConnections.View = System.Windows.Forms.View.Details;
      this.lvwConnections.SelectedIndexChanged += new System.EventHandler(this.lvwVars_SelectedIndexChanged);
      this.lvwConnections.Click += new System.EventHandler(this.lvwVars_SelectedIndexChanged);
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Conexões";
      this.columnHeader3.Width = 181;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btnEnableAll);
      this.panel3.Controls.Add(this.btnDisableAll);
      this.panel3.Controls.Add(this.btnEditConnection);
      this.panel3.Controls.Add(this.btnTestConnection);
      this.panel3.Controls.Add(this.btnCreateResultsets);
      this.panel3.Controls.Add(this.btnKillConnection);
      this.panel3.Controls.Add(this.btnNovaConexão);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(3, 3);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(206, 132);
      this.panel3.TabIndex = 6;
      // 
      // btnEnableAll
      // 
      this.btnEnableAll.Location = new System.Drawing.Point(107, 91);
      this.btnEnableAll.Name = "btnEnableAll";
      this.btnEnableAll.Size = new System.Drawing.Size(94, 23);
      this.btnEnableAll.TabIndex = 11;
      this.btnEnableAll.Text = "Habilitar Todas";
      this.btnEnableAll.UseVisualStyleBackColor = true;
      this.btnEnableAll.Click += new System.EventHandler(this.btnEnableAll_Click);
      // 
      // btnDisableAll
      // 
      this.btnDisableAll.Location = new System.Drawing.Point(5, 91);
      this.btnDisableAll.Name = "btnDisableAll";
      this.btnDisableAll.Size = new System.Drawing.Size(96, 23);
      this.btnDisableAll.TabIndex = 10;
      this.btnDisableAll.Text = "Desab. Todas";
      this.btnDisableAll.UseVisualStyleBackColor = true;
      this.btnDisableAll.Click += new System.EventHandler(this.btnDisableAll_Click);
      // 
      // btnEditConnection
      // 
      this.btnEditConnection.Location = new System.Drawing.Point(107, 61);
      this.btnEditConnection.Name = "btnEditConnection";
      this.btnEditConnection.Size = new System.Drawing.Size(94, 23);
      this.btnEditConnection.TabIndex = 9;
      this.btnEditConnection.Text = "Editar";
      this.btnEditConnection.UseVisualStyleBackColor = true;
      this.btnEditConnection.Click += new System.EventHandler(this.btnEditConnection_Click);
      // 
      // btnTestConnection
      // 
      this.btnTestConnection.Location = new System.Drawing.Point(5, 61);
      this.btnTestConnection.Name = "btnTestConnection";
      this.btnTestConnection.Size = new System.Drawing.Size(96, 23);
      this.btnTestConnection.TabIndex = 8;
      this.btnTestConnection.Text = "Testar";
      this.btnTestConnection.UseVisualStyleBackColor = true;
      this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
      // 
      // btnCreateResultsets
      // 
      this.btnCreateResultsets.Location = new System.Drawing.Point(5, 32);
      this.btnCreateResultsets.Name = "btnCreateResultsets";
      this.btnCreateResultsets.Size = new System.Drawing.Size(198, 23);
      this.btnCreateResultsets.TabIndex = 5;
      this.btnCreateResultsets.Text = "Criar Resultsets";
      this.btnCreateResultsets.UseVisualStyleBackColor = true;
      this.btnCreateResultsets.Click += new System.EventHandler(this.btnCreateResultsets_Click);
      // 
      // btnKillConnection
      // 
      this.btnKillConnection.Location = new System.Drawing.Point(107, 3);
      this.btnKillConnection.Name = "btnKillConnection";
      this.btnKillConnection.Size = new System.Drawing.Size(96, 23);
      this.btnKillConnection.TabIndex = 2;
      this.btnKillConnection.Text = "Excluir";
      this.btnKillConnection.UseVisualStyleBackColor = true;
      this.btnKillConnection.Click += new System.EventHandler(this.btnKillConnection_Click);
      // 
      // btnNovaConexão
      // 
      this.btnNovaConexão.Location = new System.Drawing.Point(5, 3);
      this.btnNovaConexão.Name = "btnNovaConexão";
      this.btnNovaConexão.Size = new System.Drawing.Size(96, 23);
      this.btnNovaConexão.TabIndex = 3;
      this.btnNovaConexão.Text = "Nova...";
      this.btnNovaConexão.UseVisualStyleBackColor = true;
      this.btnNovaConexão.Click += new System.EventHandler(this.btnNovaConexão_Click);
      // 
      // splitter3
      // 
      this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
      this.splitter3.Location = new System.Drawing.Point(625, 25);
      this.splitter3.Name = "splitter3";
      this.splitter3.Size = new System.Drawing.Size(3, 511);
      this.splitter3.TabIndex = 3;
      this.splitter3.TabStop = false;
      // 
      // openFileDialog
      // 
      this.openFileDialog.DefaultExt = "Iris";
      this.openFileDialog.Filter = "Iris Models|*.Iris";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.DefaultExt = "Iris";
      this.saveFileDialog.Filter = "Iris Models|*.Iris";
      // 
      // bkpTimer
      // 
      this.bkpTimer.Interval = 600000;
      this.bkpTimer.Tick += new System.EventHandler(this.bkpTimer_Tick);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlLastLog});
      this.statusStrip.Location = new System.Drawing.Point(0, 536);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(848, 22);
      this.statusStrip.TabIndex = 5;
      this.statusStrip.Text = "statusStrip1";
      this.statusStrip.Click += new System.EventHandler(this.statusStrip1_Click);
      // 
      // stlLastLog
      // 
      this.stlLastLog.Name = "stlLastLog";
      this.stlLastLog.Size = new System.Drawing.Size(0, 17);
      // 
      // saveSchemaFileDialog
      // 
      this.saveSchemaFileDialog.DefaultExt = "Isch";
      this.saveSchemaFileDialog.Filter = "Iris Schemas | *.isch";
      // 
      // openSchemaFileDialog
      // 
      this.openSchemaFileDialog.DefaultExt = "Isch";
      this.openSchemaFileDialog.Filter = "Iris Schemas | *.isch";
      // 
      // saveLogDialog
      // 
      this.saveLogDialog.DefaultExt = "log";
      this.saveLogDialog.Filter = "LogFiles(.log)|*.log";
      // 
      // tabMRU
      // 
      this.tabMRU.Controls.Add(this.tsMRU);
      this.tabMRU.Location = new System.Drawing.Point(4, 23);
      this.tabMRU.Name = "tabMRU";
      this.tabMRU.Padding = new System.Windows.Forms.Padding(3);
      this.tabMRU.Size = new System.Drawing.Size(192, 484);
      this.tabMRU.TabIndex = 2;
      this.tabMRU.Text = "MRU";
      this.tabMRU.UseVisualStyleBackColor = true;
      // 
      // tsMRU
      // 
      this.tsMRU.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tsMRU.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsMRU.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
      this.tsMRU.Location = new System.Drawing.Point(3, 3);
      this.tsMRU.Name = "tsMRU";
      this.tsMRU.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.tsMRU.Size = new System.Drawing.Size(186, 478);
      this.tsMRU.TabIndex = 1;
      this.tsMRU.Text = "toolStrip1";
      // 
      // StructureDesigner
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(848, 558);
      this.Controls.Add(this.splitter3);
      this.Controls.Add(this.pnlBackGround);
      this.Controls.Add(this.tbcVars);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.tbcTools);
      this.Controls.Add(this.tbMain);
      this.Controls.Add(this.statusStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "StructureDesigner";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "IRIS - Information  Retrieval and Integration System";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StructureDesigner_FormClosing);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StructureDesigner_KeyUp);
      this.tbMain.ResumeLayout(false);
      this.tbMain.PerformLayout();
      this.pnlBackGround.ResumeLayout(false);
      this.tbcOutput.ResumeLayout(false);
      this.tabOutput.ResumeLayout(false);
      this.tabOutput.PerformLayout();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.tabBreakPoints.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.tabNotes.ResumeLayout(false);
      this.tabNotes.PerformLayout();
      this.tbcTools.ResumeLayout(false);
      this.tabOperations.ResumeLayout(false);
      this.tabOperations.PerformLayout();
      this.tabProperties.ResumeLayout(false);
      this.tbcVars.ResumeLayout(false);
      this.tabVars.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.tabResultsets.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.tabSchemas.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.tabConnections.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.tabMRU.ResumeLayout(false);
      this.tabMRU.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel pnlBackGround;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.TabControl tbcTools;
    private System.Windows.Forms.TabPage tabOperations;
    private System.Windows.Forms.Splitter splitter2;
    private System.Windows.Forms.TabControl tbcOutput;
    private System.Windows.Forms.TabPage tabOutput;
    private System.Windows.Forms.TabPage tabProperties;
    private System.Windows.Forms.ToolStrip tsOperations;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private System.Windows.Forms.ToolStripButton btnHideTools;
    private System.Windows.Forms.ToolStripButton btnHideVars;
    private System.Windows.Forms.ToolStripButton btnHideOut;
    private System.Windows.Forms.TabControl tbcVars;
    private System.Windows.Forms.TabPage tabVars;
    private System.Windows.Forms.TabPage tabResultsets;
    private System.Windows.Forms.TabPage tabConnections;
    private System.Windows.Forms.Button btnNewVar;
    private System.Windows.Forms.Button btnNewResultSet;
    private System.Windows.Forms.Button btnNovaConexão;
    private System.Windows.Forms.Splitter splitter3;
    private System.Windows.Forms.ListView lvwVars;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ImageList imlVars;
    private System.Windows.Forms.ListView lvwResultSets;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ListView lvwConnections;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnKillVar;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnKillResultSet;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btnKillConnection;
    private System.Windows.Forms.ComboBox cbxCategories;
    private System.Windows.Forms.ToolStripButton btnSave;
    private System.Windows.Forms.ToolStripButton btnLoad;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.ToolStripButton btnRun;
    private System.Windows.Forms.ToolStripButton btnNewProj;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton btnRestart;
    private System.Windows.Forms.ToolStripButton btnStep;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton btnResetOperation;
    private System.Windows.Forms.ToolStripButton btnSetRunningPoint;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripComboBox cbxZoom;
    private System.Windows.Forms.ToolStripButton btnZoomOut;
    private System.Windows.Forms.ToolStripButton btnZoomIn;
    private System.Windows.Forms.ToolStripButton btnZoomActual;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton btnRunToSelection;
    private System.Windows.Forms.ToolStripButton btnReRun;
    private System.Windows.Forms.TabPage tabSchemas;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Button btnKillSchema;
    private System.Windows.Forms.Button btnNewTxtSchema;
    private System.Windows.Forms.ListView lvwSchemas;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.Button btnCreateSchemaRS;
    private System.Windows.Forms.Button btnNewXMLSchema;
    private System.Windows.Forms.ListView lvwLog;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ImageList imlListViewIcons;
    private System.Windows.Forms.Button btnTestConnection;
    private System.Windows.Forms.Button btnCreateResultsets;
    private System.Windows.Forms.TabPage tabBreakPoints;
    private System.Windows.Forms.ListView lvwBreakPoints;
    private System.Windows.Forms.ColumnHeader columnHeader6;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton btnClearBreakpoints;
    private System.Windows.Forms.ToolStripButton btnDeleteBreakPoint;
    private System.Windows.Forms.ToolStripButton btnSearch;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripButton btnSaveAs;
    private System.Windows.Forms.Timer bkpTimer;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel stlLastLog;
    private System.Windows.Forms.ToolStrip toolStrip2;
    private System.Windows.Forms.ToolStripButton btnClearLog;
    internal FlowChart surface;
    internal System.Windows.Forms.ToolStrip tbMain;
    private System.Windows.Forms.Button btnCreateLineType;
    private System.Windows.Forms.Button btnLoadSchemas;
    private System.Windows.Forms.Button btnSaveSchemas;
    private System.Windows.Forms.SaveFileDialog saveSchemaFileDialog;
    private System.Windows.Forms.OpenFileDialog openSchemaFileDialog;
    private System.Windows.Forms.Button btnCreateAll;
    private System.Windows.Forms.ToolStripButton btnSaveSnapshot;
    private System.Windows.Forms.ToolStripButton btnBreakPoint;
    private System.Windows.Forms.ToolStripButton btnToggleSnapshot;
    private System.Windows.Forms.Button btnEnableAll;
    private System.Windows.Forms.Button btnDisableAll;
    private System.Windows.Forms.Button btnEditConnection;
    private System.Windows.Forms.TabPage tabNotes;
    private System.Windows.Forms.TextBox txtNotes;
    private System.Windows.Forms.ToolStripButton btnSaveLog;
    private System.Windows.Forms.SaveFileDialog saveLogDialog;
    private System.Windows.Forms.ToolStripButton btnStop;
    private System.Windows.Forms.TabPage tabMRU;
    private System.Windows.Forms.ToolStrip tsMRU;
  }
}