namespace Iris.Runtime.Core.PropertyEditors.Controls
{
  partial class GenericListEditorControl<T>
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.pnlButtons = new System.Windows.Forms.Panel();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnMoveDown = new System.Windows.Forms.Button();
      this.btnMoveUp = new System.Windows.Forms.Button();
      this.btnNew = new System.Windows.Forms.Button();
      this.lbxItems = new System.Windows.Forms.ListBox();
      this.pnlButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // propertyGrid1
      // 
      this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid1.Location = new System.Drawing.Point(210, 0);
      this.propertyGrid1.Name = "propertyGrid1";
      this.propertyGrid1.Size = new System.Drawing.Size(221, 347);
      this.propertyGrid1.TabIndex = 8;
      this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
      // 
      // splitter1
      // 
      this.splitter1.Location = new System.Drawing.Point(207, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(3, 347);
      this.splitter1.TabIndex = 7;
      this.splitter1.TabStop = false;
      // 
      // pnlButtons
      // 
      this.pnlButtons.Controls.Add(this.btnClear);
      this.pnlButtons.Controls.Add(this.btnDelete);
      this.pnlButtons.Controls.Add(this.btnMoveDown);
      this.pnlButtons.Controls.Add(this.btnMoveUp);
      this.pnlButtons.Controls.Add(this.btnNew);
      this.pnlButtons.Controls.Add(this.lbxItems);
      this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlButtons.Location = new System.Drawing.Point(0, 0);
      this.pnlButtons.Name = "pnlButtons";
      this.pnlButtons.Size = new System.Drawing.Size(207, 347);
      this.pnlButtons.TabIndex = 6;
      // 
      // btnClear
      // 
      this.btnClear.BackColor = System.Drawing.Color.WhiteSmoke;
      this.btnClear.Location = new System.Drawing.Point(161, 144);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(43, 23);
      this.btnClear.TabIndex = 17;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = false;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
      this.btnDelete.BackgroundImage = global::Iris.PropertyEditors.Properties.Resources.Delete;
      this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.btnDelete.ImageIndex = 3;
      this.btnDelete.Location = new System.Drawing.Point(161, 115);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(43, 23);
      this.btnDelete.TabIndex = 13;
      this.btnDelete.UseVisualStyleBackColor = false;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnMoveDown
      // 
      this.btnMoveDown.BackColor = System.Drawing.Color.WhiteSmoke;
      this.btnMoveDown.BackgroundImage = global::Iris.PropertyEditors.Properties.Resources.Down;
      this.btnMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.btnMoveDown.ImageIndex = 4;
      this.btnMoveDown.Location = new System.Drawing.Point(161, 202);
      this.btnMoveDown.Name = "btnMoveDown";
      this.btnMoveDown.Size = new System.Drawing.Size(43, 23);
      this.btnMoveDown.TabIndex = 11;
      this.btnMoveDown.UseVisualStyleBackColor = false;
      this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
      // 
      // btnMoveUp
      // 
      this.btnMoveUp.BackColor = System.Drawing.Color.WhiteSmoke;
      this.btnMoveUp.BackgroundImage = global::Iris.PropertyEditors.Properties.Resources.Up;
      this.btnMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.btnMoveUp.ImageIndex = 5;
      this.btnMoveUp.Location = new System.Drawing.Point(161, 173);
      this.btnMoveUp.Name = "btnMoveUp";
      this.btnMoveUp.Size = new System.Drawing.Size(43, 23);
      this.btnMoveUp.TabIndex = 10;
      this.btnMoveUp.UseVisualStyleBackColor = false;
      this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
      // 
      // btnNew
      // 
      this.btnNew.BackColor = System.Drawing.Color.WhiteSmoke;
      this.btnNew.BackgroundImage = global::Iris.PropertyEditors.Properties.Resources.New;
      this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.btnNew.Location = new System.Drawing.Point(161, 86);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(43, 23);
      this.btnNew.TabIndex = 9;
      this.btnNew.UseVisualStyleBackColor = false;
      this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
      // 
      // lbxItems
      // 
      this.lbxItems.Dock = System.Windows.Forms.DockStyle.Left;
      this.lbxItems.FormattingEnabled = true;
      this.lbxItems.Location = new System.Drawing.Point(0, 0);
      this.lbxItems.Name = "lbxItems";
      this.lbxItems.Size = new System.Drawing.Size(159, 347);
      this.lbxItems.TabIndex = 2;
      this.lbxItems.SelectedIndexChanged += new System.EventHandler(this.lbxItems_SelectedIndexChanged);
      // 
      // GenericListEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.propertyGrid1);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.pnlButtons);
      this.Name = "GenericListEditorControl";
      this.Size = new System.Drawing.Size(431, 347);
      this.pnlButtons.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.PropertyGrid propertyGrid1;
    protected System.Windows.Forms.Splitter splitter1;
    protected System.Windows.Forms.Panel pnlButtons;
    protected System.Windows.Forms.ListBox lbxItems;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnMoveDown;
    private System.Windows.Forms.Button btnMoveUp;
    private System.Windows.Forms.Button btnNew;
  }
}
