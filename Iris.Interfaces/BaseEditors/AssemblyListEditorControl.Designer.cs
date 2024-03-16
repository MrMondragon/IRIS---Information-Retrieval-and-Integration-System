using Iris.PropertyEditors.Dialogs;
namespace Iris.PropertyEditors.Controls
{
  partial class AssemblyListEditorControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyListEditorControl));
      this.lbxAssemblies = new System.Windows.Forms.ListBox();
      this.imlCommands = new System.Windows.Forms.ImageList(this.components);
      this.pnlButtons = new System.Windows.Forms.Panel();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnNew = new System.Windows.Forms.Button();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
      this.pnlButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // lbxAssemblies
      // 
      this.lbxAssemblies.Dock = System.Windows.Forms.DockStyle.Left;
      this.lbxAssemblies.FormattingEnabled = true;
      this.lbxAssemblies.Location = new System.Drawing.Point(0, 0);
      this.lbxAssemblies.Name = "lbxAssemblies";
      this.lbxAssemblies.Size = new System.Drawing.Size(159, 368);
      this.lbxAssemblies.TabIndex = 2;
      this.lbxAssemblies.SelectedIndexChanged += new System.EventHandler(this.lbxAssemblies_SelectedIndexChanged);
      // 
      // imlCommands
      // 
      this.imlCommands.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCommands.ImageStream")));
      this.imlCommands.TransparentColor = System.Drawing.Color.Fuchsia;
      this.imlCommands.Images.SetKeyName(0, "BuilderDialog_delete.bmp");
      this.imlCommands.Images.SetKeyName(1, "New.bmp");
      // 
      // pnlButtons
      // 
      this.pnlButtons.Controls.Add(this.btnClear);
      this.pnlButtons.Controls.Add(this.btnDelete);
      this.pnlButtons.Controls.Add(this.btnNew);
      this.pnlButtons.Controls.Add(this.lbxAssemblies);
      this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlButtons.Location = new System.Drawing.Point(0, 0);
      this.pnlButtons.Name = "pnlButtons";
      this.pnlButtons.Size = new System.Drawing.Size(207, 370);
      this.pnlButtons.TabIndex = 3;
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
      // splitter1
      // 
      this.splitter1.Location = new System.Drawing.Point(207, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(3, 370);
      this.splitter1.TabIndex = 4;
      this.splitter1.TabStop = false;
      // 
      // propertyGrid1
      // 
      this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid1.Location = new System.Drawing.Point(210, 0);
      this.propertyGrid1.Name = "propertyGrid1";
      this.propertyGrid1.Size = new System.Drawing.Size(212, 370);
      this.propertyGrid1.TabIndex = 5;
      this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
      // 
      // AssemblyListEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Controls.Add(this.propertyGrid1);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.pnlButtons);
      this.Name = "AssemblyListEditorControl";
      this.Size = new System.Drawing.Size(422, 370);
      this.pnlButtons.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList imlCommands;
    protected System.Windows.Forms.Button btnClear;
    protected System.Windows.Forms.Button btnDelete;
    protected System.Windows.Forms.Button btnNew;
    protected System.Windows.Forms.ListBox lbxAssemblies;
    protected System.Windows.Forms.Panel pnlButtons;
    protected System.Windows.Forms.Splitter splitter1;
    protected System.Windows.Forms.PropertyGrid propertyGrid1;
  }
}
