namespace LicencingBase
{
  partial class PluginRegistrator
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
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.btnAddPluginAsm = new System.Windows.Forms.Button();
      this.btnAddDepAsm = new System.Windows.Forms.Button();
      this.btnRemoveAsm = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.btnSave = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(260, 289);
      this.checkedListBox1.TabIndex = 0;
      // 
      // btnAddPluginAsm
      // 
      this.btnAddPluginAsm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAddPluginAsm.Location = new System.Drawing.Point(12, 313);
      this.btnAddPluginAsm.Name = "btnAddPluginAsm";
      this.btnAddPluginAsm.Size = new System.Drawing.Size(260, 23);
      this.btnAddPluginAsm.TabIndex = 2;
      this.btnAddPluginAsm.Text = "Registrar Assembly de Plugin";
      this.btnAddPluginAsm.UseVisualStyleBackColor = true;
      this.btnAddPluginAsm.Click += new System.EventHandler(this.btnAddPluginAsm_Click);
      // 
      // btnAddDepAsm
      // 
      this.btnAddDepAsm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAddDepAsm.Location = new System.Drawing.Point(12, 342);
      this.btnAddDepAsm.Name = "btnAddDepAsm";
      this.btnAddDepAsm.Size = new System.Drawing.Size(260, 23);
      this.btnAddDepAsm.TabIndex = 2;
      this.btnAddDepAsm.Text = "Registrar Assembly de Dependência";
      this.btnAddDepAsm.UseVisualStyleBackColor = true;
      this.btnAddDepAsm.Click += new System.EventHandler(this.btnAddDepAsm_Click);
      // 
      // btnRemoveAsm
      // 
      this.btnRemoveAsm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnRemoveAsm.Location = new System.Drawing.Point(12, 371);
      this.btnRemoveAsm.Name = "btnRemoveAsm";
      this.btnRemoveAsm.Size = new System.Drawing.Size(260, 23);
      this.btnRemoveAsm.TabIndex = 2;
      this.btnRemoveAsm.Text = "Remover Assembly";
      this.btnRemoveAsm.UseVisualStyleBackColor = true;
      this.btnRemoveAsm.Click += new System.EventHandler(this.btnRemoveAsm_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.Filter = "Assemblies|*.dll";
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnSave.Location = new System.Drawing.Point(12, 400);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(260, 23);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Gravar";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // PluginRegistrator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 431);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.btnRemoveAsm);
      this.Controls.Add(this.btnAddDepAsm);
      this.Controls.Add(this.btnAddPluginAsm);
      this.Controls.Add(this.checkedListBox1);
      this.Name = "PluginRegistrator";
      this.Text = "PluginRegistrator";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.Button btnAddPluginAsm;
    private System.Windows.Forms.Button btnAddDepAsm;
    private System.Windows.Forms.Button btnRemoveAsm;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button btnSave;
  }
}