namespace Iris.PropertyEditors.Controls
{
  partial class ConnectionEditorControl
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
      this.cbbProviders = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tbConnectionString = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnEditConnectionString = new System.Windows.Forms.Button();
      this.btnTest = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cbbProviders
      // 
      this.cbbProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.cbbProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbProviders.FormattingEnabled = true;
      this.cbbProviders.Location = new System.Drawing.Point(12, 38);
      this.cbbProviders.Name = "cbbProviders";
      this.cbbProviders.Size = new System.Drawing.Size(197, 21);
      this.cbbProviders.TabIndex = 0;
      this.cbbProviders.Validated += new System.EventHandler(this.cbbProviders_Validated);
      this.cbbProviders.SelectedIndexChanged += new System.EventHandler(this.cbbProviders_SelectedIndexChanged);
      this.cbbProviders.TextChanged += new System.EventHandler(this.cbbProviders_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Provider";
      // 
      // tbConnectionString
      // 
      this.tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.tbConnectionString.Location = new System.Drawing.Point(15, 94);
      this.tbConnectionString.Name = "tbConnectionString";
      this.tbConnectionString.Size = new System.Drawing.Size(172, 20);
      this.tbConnectionString.TabIndex = 2;
      this.tbConnectionString.Validated += new System.EventHandler(this.cbbProviders_Validated);
      this.tbConnectionString.Validating += new System.ComponentModel.CancelEventHandler(this.tbConnectionString_Validating);
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 78);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(94, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "String de Conexão";
      // 
      // btnEditConnectionString
      // 
      this.btnEditConnectionString.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.btnEditConnectionString.Location = new System.Drawing.Point(187, 94);
      this.btnEditConnectionString.Name = "btnEditConnectionString";
      this.btnEditConnectionString.Size = new System.Drawing.Size(24, 20);
      this.btnEditConnectionString.TabIndex = 4;
      this.btnEditConnectionString.Text = "...";
      this.btnEditConnectionString.UseVisualStyleBackColor = true;
      this.btnEditConnectionString.Click += new System.EventHandler(this.btnEditConnectionString_Click);
      // 
      // btnTest
      // 
      this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTest.Location = new System.Drawing.Point(140, 139);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(75, 23);
      this.btnTest.TabIndex = 5;
      this.btnTest.Text = "Teste";
      this.btnTest.UseVisualStyleBackColor = true;
      this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // ConnectionEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnTest);
      this.Controls.Add(this.btnEditConnectionString);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbConnectionString);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbbProviders);
      this.MinimumSize = new System.Drawing.Size(223, 177);
      this.Name = "ConnectionEditorControl";
      this.Size = new System.Drawing.Size(223, 177);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cbbProviders;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbConnectionString;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnEditConnectionString;
    private System.Windows.Forms.Button btnTest;
  }
}
