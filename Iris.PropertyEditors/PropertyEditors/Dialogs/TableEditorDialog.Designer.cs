namespace Iris.Runtime.Model.PropertyEditors.Dialogs
{
  partial class TableEditorDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableEditorDialog));
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
      this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
      this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.btnClear = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnFindNextError = new System.Windows.Forms.ToolStripButton();
      this.btnFindPrevError = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.btnAutoSize = new System.Windows.Forms.ToolStripButton();
      this.btnShowDiff = new System.Windows.Forms.ToolStripButton();
      this.tsCbxRowState = new System.Windows.Forms.ToolStripComboBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
      this.bindingNavigator.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 273);
      this.panel1.Size = new System.Drawing.Size(557, 30);
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.DataSource = this.bindingSource;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 25);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(557, 248);
      this.dataGridView1.TabIndex = 2;
      this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
      // 
      // bindingSource
      // 
      this.bindingSource.CurrentItemChanged += new System.EventHandler(this.bindingSource_CurrentItemChanged);
      // 
      // bindingNavigator
      // 
      this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
      this.bindingNavigator.BindingSource = this.bindingSource;
      this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
      this.bindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
      this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.btnClear,
            this.toolStripSeparator1,
            this.btnFindNextError,
            this.btnFindPrevError,
            this.toolStripSeparator2,
            this.btnAutoSize,
            this.btnShowDiff,
            this.tsCbxRowState});
      this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
      this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
      this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
      this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
      this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
      this.bindingNavigator.Name = "bindingNavigator";
      this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
      this.bindingNavigator.Size = new System.Drawing.Size(557, 25);
      this.bindingNavigator.TabIndex = 3;
      this.bindingNavigator.Text = "bindingNavigator1";
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
      // bindingNavigatorCountItem
      // 
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
      this.bindingNavigatorCountItem.Text = "of {0}";
      this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
      // bindingNavigatorSeparator2
      // 
      this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
      this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // btnClear
      // 
      this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
      this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(23, 22);
      this.btnClear.Text = "Clear";
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnFindNextError
      // 
      this.btnFindNextError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnFindNextError.Image = global::Iris.PropertyEditors.Properties.Resources.FindNextError;
      this.btnFindNextError.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnFindNextError.Name = "btnFindNextError";
      this.btnFindNextError.Size = new System.Drawing.Size(23, 22);
      this.btnFindNextError.Text = "Próximo Erro";
      this.btnFindNextError.Click += new System.EventHandler(this.btnFindNextError_Click);
      // 
      // btnFindPrevError
      // 
      this.btnFindPrevError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnFindPrevError.Image = global::Iris.PropertyEditors.Properties.Resources.FindPrevError;
      this.btnFindPrevError.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnFindPrevError.Name = "btnFindPrevError";
      this.btnFindPrevError.Size = new System.Drawing.Size(23, 22);
      this.btnFindPrevError.Text = "Erro Anterior";
      this.btnFindPrevError.Click += new System.EventHandler(this.btnFindPrevError_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // btnAutoSize
      // 
      this.btnAutoSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnAutoSize.Image = global::Iris.PropertyEditors.Properties.Resources.AutoSize;
      this.btnAutoSize.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAutoSize.Name = "btnAutoSize";
      this.btnAutoSize.Size = new System.Drawing.Size(23, 22);
      this.btnAutoSize.Text = "Auto Size";
      this.btnAutoSize.Click += new System.EventHandler(this.btnAutoSize_Click);
      // 
      // btnShowDiff
      // 
      this.btnShowDiff.CheckOnClick = true;
      this.btnShowDiff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnShowDiff.Image = global::Iris.PropertyEditors.Properties.Resources.Diff;
      this.btnShowDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnShowDiff.Name = "btnShowDiff";
      this.btnShowDiff.Size = new System.Drawing.Size(23, 22);
      this.btnShowDiff.Text = "Mostrar alterações";
      this.btnShowDiff.Click += new System.EventHandler(this.btnShowDiff_Click);
      // 
      // tsCbxRowState
      // 
      this.tsCbxRowState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.tsCbxRowState.Items.AddRange(new object[] {
            "Todos",
            "Incluídos",
            "Alterados"});
      this.tsCbxRowState.Name = "tsCbxRowState";
      this.tsCbxRowState.Size = new System.Drawing.Size(121, 25);
      this.tsCbxRowState.SelectedIndexChanged += new System.EventHandler(this.tsCbxRowState_SelectedIndexChanged);
      // 
      // TableEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(557, 303);
      this.ControlBox = true;
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.bindingNavigator);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Name = "TableEditorDialog";
      this.Text = "Dados";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.bindingNavigator, 0);
      this.Controls.SetChildIndex(this.dataGridView1, 0);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
      this.bindingNavigator.ResumeLayout(false);
      this.bindingNavigator.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.BindingSource bindingSource;
    private System.Windows.Forms.BindingNavigator bindingNavigator;
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
    private System.Windows.Forms.ToolStripButton btnClear;
    private System.Windows.Forms.ToolStripButton btnFindNextError;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnFindPrevError;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton btnAutoSize;
    private System.Windows.Forms.ToolStripButton btnShowDiff;
    private System.Windows.Forms.ToolStripComboBox tsCbxRowState;
  }
}