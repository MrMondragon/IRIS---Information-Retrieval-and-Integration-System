namespace Iris.Designer
{
  partial class QueryWindow
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryWindow));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.cbxConections = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.cbxCommandType = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.tcResults = new System.Windows.Forms.TabControl();
      this.tabResults = new System.Windows.Forms.TabPage();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
      this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
      this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.tabOutput = new System.Windows.Forms.TabPage();
      this.lvwLog = new System.Windows.Forms.ListView();
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.imlListViewIcons = new System.Windows.Forms.ImageList(this.components);
      this.toolStrip2 = new System.Windows.Forms.ToolStrip();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.stlLastLog = new System.Windows.Forms.ToolStripStatusLabel();
      this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
      this.btnFindNextError = new System.Windows.Forms.ToolStripButton();
      this.btnFindPrevError = new System.Windows.Forms.ToolStripButton();
      this.btnAutoSize = new System.Windows.Forms.ToolStripButton();
      this.btnClearLog = new System.Windows.Forms.ToolStripButton();
      this.btnRun = new System.Windows.Forms.ToolStripButton();
      this.syntaxControl1 = new Iris.PropertyEditors.PropertyEditors.Controls.SyntaxControl();
      this.toolStrip1.SuspendLayout();
      this.tcResults.SuspendLayout();
      this.tabResults.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
      this.bindingNavigator1.SuspendLayout();
      this.tabOutput.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbxConections,
            this.toolStripSeparator1,
            this.cbxCommandType,
            this.toolStripSeparator2,
            this.btnRun});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(765, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
      this.toolStripLabel1.Text = "Conexão:";
      // 
      // cbxConections
      // 
      this.cbxConections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxConections.Name = "cbxConections";
      this.cbxConections.Size = new System.Drawing.Size(150, 25);
      this.cbxConections.SelectedIndexChanged += new System.EventHandler(this.cbxConections_SelectedIndexChanged);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // cbxCommandType
      // 
      this.cbxCommandType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxCommandType.Name = "cbxCommandType";
      this.cbxCommandType.Size = new System.Drawing.Size(121, 25);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // splitter1
      // 
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter1.Location = new System.Drawing.Point(0, 246);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(765, 3);
      this.splitter1.TabIndex = 2;
      this.splitter1.TabStop = false;
      // 
      // tcResults
      // 
      this.tcResults.Alignment = System.Windows.Forms.TabAlignment.Bottom;
      this.tcResults.Controls.Add(this.tabResults);
      this.tcResults.Controls.Add(this.tabOutput);
      this.tcResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcResults.Location = new System.Drawing.Point(0, 249);
      this.tcResults.Name = "tcResults";
      this.tcResults.SelectedIndex = 0;
      this.tcResults.Size = new System.Drawing.Size(765, 296);
      this.tcResults.TabIndex = 3;
      // 
      // tabResults
      // 
      this.tabResults.Controls.Add(this.dataGridView1);
      this.tabResults.Controls.Add(this.bindingNavigator1);
      this.tabResults.Location = new System.Drawing.Point(4, 4);
      this.tabResults.Name = "tabResults";
      this.tabResults.Padding = new System.Windows.Forms.Padding(3);
      this.tabResults.Size = new System.Drawing.Size(757, 270);
      this.tabResults.TabIndex = 0;
      this.tabResults.Text = "Grid";
      this.tabResults.UseVisualStyleBackColor = true;
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.DataSource = this.bindingSource;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(3, 28);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(751, 239);
      this.dataGridView1.TabIndex = 3;
      // 
      // bindingNavigator1
      // 
      this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
      this.bindingNavigator1.BindingSource = this.bindingSource;
      this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
      this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
      this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.btnFindNextError,
            this.btnFindPrevError,
            this.toolStripSeparator3,
            this.btnAutoSize});
      this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
      this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
      this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
      this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
      this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
      this.bindingNavigator1.Name = "bindingNavigator1";
      this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
      this.bindingNavigator1.Size = new System.Drawing.Size(751, 25);
      this.bindingNavigator1.TabIndex = 0;
      this.bindingNavigator1.Text = "bindingNavigator1";
      // 
      // bindingNavigatorCountItem
      // 
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
      this.bindingNavigatorCountItem.Text = "of {0}";
      this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
      // 
      // bindingNavigatorSeparator
      // 
      this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
      this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
      // 
      // bindingNavigatorPositionItem
      // 
      this.bindingNavigatorPositionItem.AccessibleName = "Position";
      this.bindingNavigatorPositionItem.AutoSize = false;
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
      this.bindingNavigatorPositionItem.Text = "0";
      this.bindingNavigatorPositionItem.ToolTipText = "Current position";
      // 
      // bindingNavigatorSeparator1
      // 
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // bindingNavigatorSeparator2
      // 
      this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
      this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // tabOutput
      // 
      this.tabOutput.Controls.Add(this.lvwLog);
      this.tabOutput.Controls.Add(this.toolStrip2);
      this.tabOutput.Location = new System.Drawing.Point(4, 4);
      this.tabOutput.Name = "tabOutput";
      this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
      this.tabOutput.Size = new System.Drawing.Size(757, 270);
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
      this.lvwLog.Size = new System.Drawing.Size(727, 264);
      this.lvwLog.SmallImageList = this.imlListViewIcons;
      this.lvwLog.TabIndex = 7;
      this.lvwLog.UseCompatibleStateImageBehavior = false;
      this.lvwLog.View = System.Windows.Forms.View.Details;
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
            this.btnClearLog});
      this.toolStrip2.Location = new System.Drawing.Point(3, 3);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.toolStrip2.Size = new System.Drawing.Size(24, 264);
      this.toolStrip2.TabIndex = 11;
      this.toolStrip2.Text = "toolStrip2";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlLastLog});
      this.statusStrip1.Location = new System.Drawing.Point(0, 545);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(765, 22);
      this.statusStrip1.TabIndex = 4;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // stlLastLog
      // 
      this.stlLastLog.Name = "stlLastLog";
      this.stlLastLog.Size = new System.Drawing.Size(0, 17);
      // 
      // bindingNavigatorAddNewItem
      // 
      this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
      this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
      this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorAddNewItem.Text = "Add new";
      // 
      // bindingNavigatorDeleteItem
      // 
      this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
      this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
      this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorDeleteItem.Text = "Delete";
      // 
      // bindingNavigatorMoveFirstItem
      // 
      this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveFirstItem.Text = "Move first";
      // 
      // bindingNavigatorMovePreviousItem
      // 
      this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMovePreviousItem.Text = "Move previous";
      // 
      // bindingNavigatorMoveNextItem
      // 
      this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveNextItem.Text = "Move next";
      // 
      // bindingNavigatorMoveLastItem
      // 
      this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveLastItem.Text = "Move last";
      // 
      // btnFindNextError
      // 
      this.btnFindNextError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnFindNextError.Image = global::Iris.Plugins.Properties.Resources.FindNextError;
      this.btnFindNextError.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnFindNextError.Name = "btnFindNextError";
      this.btnFindNextError.Size = new System.Drawing.Size(23, 22);
      this.btnFindNextError.Text = "Próximo Erro";
      this.btnFindNextError.Click += new System.EventHandler(this.btnFindNextError_Click);
      // 
      // btnFindPrevError
      // 
      this.btnFindPrevError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnFindPrevError.Image = global::Iris.Plugins.Properties.Resources.FindPrevError;
      this.btnFindPrevError.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnFindPrevError.Name = "btnFindPrevError";
      this.btnFindPrevError.Size = new System.Drawing.Size(23, 22);
      this.btnFindPrevError.Text = "Erro Anterior";
      this.btnFindPrevError.Click += new System.EventHandler(this.btnFindPrevError_Click);
      // 
      // btnAutoSize
      // 
      this.btnAutoSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnAutoSize.Image = global::Iris.Plugins.Properties.Resources.AutoSize;
      this.btnAutoSize.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAutoSize.Name = "btnAutoSize";
      this.btnAutoSize.Size = new System.Drawing.Size(23, 22);
      this.btnAutoSize.Text = "Auto Size";
      this.btnAutoSize.Click += new System.EventHandler(this.btnAutoSize_Click);
      // 
      // btnClearLog
      // 
      this.btnClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnClearLog.Image = global::Iris.Plugins.Properties.Resources.ClearLog;
      this.btnClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnClearLog.Name = "btnClearLog";
      this.btnClearLog.Size = new System.Drawing.Size(21, 20);
      this.btnClearLog.Text = "Clear Log";
      this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
      // 
      // btnRun
      // 
      this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRun.Image = global::Iris.Plugins.Properties.Resources.formrunHS;
      this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(23, 22);
      this.btnRun.Text = "Executar (F5)";
      this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
      // 
      // syntaxControl1
      // 
      this.syntaxControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.syntaxControl1.Language = Iris.PropertyEditors.PropertyEditors.Controls.SyntaxLanguage.CSharp;
      this.syntaxControl1.Location = new System.Drawing.Point(0, 25);
      this.syntaxControl1.Name = "syntaxControl1";
      this.syntaxControl1.SelectedObject = null;
      this.syntaxControl1.Size = new System.Drawing.Size(765, 221);
      this.syntaxControl1.Structure = null;
      this.syntaxControl1.TabIndex = 0;
      // 
      // QueryWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(765, 567);
      this.Controls.Add(this.tcResults);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.syntaxControl1);
      this.Controls.Add(this.toolStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "QueryWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "IRIS - Query Window";
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImediateWindow_KeyUp);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.tcResults.ResumeLayout(false);
      this.tabResults.ResumeLayout(false);
      this.tabResults.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
      this.bindingNavigator1.ResumeLayout(false);
      this.bindingNavigator1.PerformLayout();
      this.tabOutput.ResumeLayout(false);
      this.tabOutput.PerformLayout();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Iris.PropertyEditors.PropertyEditors.Controls.SyntaxControl syntaxControl1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.TabControl tcResults;
    private System.Windows.Forms.TabPage tabResults;
    private System.Windows.Forms.TabPage tabOutput;
    private System.Windows.Forms.BindingSource bindingSource;
    private System.Windows.Forms.BindingNavigator bindingNavigator1;
    private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
    private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
    private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    private System.Windows.Forms.ToolStripComboBox cbxConections;
    private System.Windows.Forms.ListView lvwLog;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.ToolStripButton btnRun;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel stlLastLog;
    private System.Windows.Forms.ToolStrip toolStrip2;
    private System.Windows.Forms.ToolStripButton btnClearLog;
    private System.Windows.Forms.ImageList imlListViewIcons;
    private System.Windows.Forms.ToolStripButton btnFindPrevError;
    private System.Windows.Forms.ToolStripButton btnFindNextError;
    private System.Windows.Forms.ToolStripComboBox cbxCommandType;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton btnAutoSize;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
  }
}