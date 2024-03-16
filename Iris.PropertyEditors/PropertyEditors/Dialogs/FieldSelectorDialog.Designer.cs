namespace Iris.Runtime.Model.PropertyEditors.Dialogs
{
  partial class FieldSelectorDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldSelectorDialog));
      this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.pnlButtons = new System.Windows.Forms.Panel();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.imlCommands = new System.Windows.Forms.ImageList(this.components);
      this.btnNew = new System.Windows.Forms.Button();
      this.lbxFields = new System.Windows.Forms.ListBox();
      this.panel1.SuspendLayout();
      this.pnlButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 374);
      this.panel1.Size = new System.Drawing.Size(443, 30);
      // 
      // propertyGrid1
      // 
      this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid1.Location = new System.Drawing.Point(210, 0);
      this.propertyGrid1.Name = "propertyGrid1";
      this.propertyGrid1.Size = new System.Drawing.Size(233, 374);
      this.propertyGrid1.TabIndex = 8;
      this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
      // 
      // splitter1
      // 
      this.splitter1.Location = new System.Drawing.Point(207, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(3, 374);
      this.splitter1.TabIndex = 7;
      this.splitter1.TabStop = false;
      // 
      // pnlButtons
      // 
      this.pnlButtons.Controls.Add(this.btnClear);
      this.pnlButtons.Controls.Add(this.btnDelete);
      this.pnlButtons.Controls.Add(this.btnNew);
      this.pnlButtons.Controls.Add(this.lbxFields);
      this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlButtons.Location = new System.Drawing.Point(0, 0);
      this.pnlButtons.Name = "pnlButtons";
      this.pnlButtons.Size = new System.Drawing.Size(207, 374);
      this.pnlButtons.TabIndex = 6;
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.Location = new System.Drawing.Point(161, 179);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(43, 23);
      this.btnClear.TabIndex = 21;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.ImageIndex = 0;
      this.btnDelete.ImageList = this.imlCommands;
      this.btnDelete.Location = new System.Drawing.Point(161, 150);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(43, 23);
      this.btnDelete.TabIndex = 20;
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // imlCommands
      // 
      this.imlCommands.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCommands.ImageStream")));
      this.imlCommands.TransparentColor = System.Drawing.Color.Fuchsia;
      this.imlCommands.Images.SetKeyName(0, "BuilderDialog_delete.bmp");
      this.imlCommands.Images.SetKeyName(1, "New.bmp");
      // 
      // btnNew
      // 
      this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnNew.ImageIndex = 1;
      this.btnNew.ImageList = this.imlCommands;
      this.btnNew.Location = new System.Drawing.Point(161, 121);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(43, 23);
      this.btnNew.TabIndex = 19;
      this.btnNew.UseVisualStyleBackColor = true;
      this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
      // 
      // lbxFields
      // 
      this.lbxFields.Dock = System.Windows.Forms.DockStyle.Left;
      this.lbxFields.FormattingEnabled = true;
      this.lbxFields.Location = new System.Drawing.Point(0, 0);
      this.lbxFields.Name = "lbxFields";
      this.lbxFields.Size = new System.Drawing.Size(159, 374);
      this.lbxFields.TabIndex = 2;
      this.lbxFields.SelectedIndexChanged += new System.EventHandler(this.lbxFields_SelectedIndexChanged);
      // 
      // FieldSelectorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(443, 404);
      this.Controls.Add(this.propertyGrid1);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.pnlButtons);
      this.Name = "FieldSelectorDialog";
      this.Text = "Seleção de Campos";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.pnlButtons, 0);
      this.Controls.SetChildIndex(this.splitter1, 0);
      this.Controls.SetChildIndex(this.propertyGrid1, 0);
      this.panel1.ResumeLayout(false);
      this.pnlButtons.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.PropertyGrid propertyGrid1;
    protected System.Windows.Forms.Splitter splitter1;
    protected System.Windows.Forms.Panel pnlButtons;
    protected System.Windows.Forms.Button btnClear;
    protected System.Windows.Forms.Button btnDelete;
    protected System.Windows.Forms.Button btnNew;
    protected System.Windows.Forms.ListBox lbxFields;
    private System.Windows.Forms.ImageList imlCommands;
  }
}
