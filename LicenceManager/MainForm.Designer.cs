namespace LicenceManager
{
  partial class MainForm
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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.btnAuthorize = new System.Windows.Forms.Button();
      this.txtOrganization = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnRegPlugn = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.Location = new System.Drawing.Point(12, 64);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(363, 231);
      this.textBox1.TabIndex = 0;
      // 
      // btnAuthorize
      // 
      this.btnAuthorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAuthorize.Location = new System.Drawing.Point(12, 303);
      this.btnAuthorize.Name = "btnAuthorize";
      this.btnAuthorize.Size = new System.Drawing.Size(116, 23);
      this.btnAuthorize.TabIndex = 1;
      this.btnAuthorize.Text = "Autorizar Máquina";
      this.btnAuthorize.UseVisualStyleBackColor = true;
      this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
      // 
      // txtOrganization
      // 
      this.txtOrganization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOrganization.Location = new System.Drawing.Point(12, 25);
      this.txtOrganization.Name = "txtOrganization";
      this.txtOrganization.Size = new System.Drawing.Size(363, 20);
      this.txtOrganization.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(67, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Organização";
      // 
      // btnRemove
      // 
      this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnRemove.Location = new System.Drawing.Point(134, 303);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(116, 23);
      this.btnRemove.TabIndex = 4;
      this.btnRemove.Text = "Desativar Máquina";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // btnRegPlugn
      // 
      this.btnRegPlugn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnRegPlugn.Location = new System.Drawing.Point(259, 303);
      this.btnRegPlugn.Name = "btnRegPlugn";
      this.btnRegPlugn.Size = new System.Drawing.Size(116, 23);
      this.btnRegPlugn.TabIndex = 5;
      this.btnRegPlugn.Text = "Registrar Plugin";
      this.btnRegPlugn.UseVisualStyleBackColor = true;
      this.btnRegPlugn.Click += new System.EventHandler(this.btnRegPlugn_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(62, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Mensagens";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(387, 336);
      this.Controls.Add(this.btnRegPlugn);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtOrganization);
      this.Controls.Add(this.btnAuthorize);
      this.Controls.Add(this.textBox1);
      this.MinimumSize = new System.Drawing.Size(403, 374);
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button btnAuthorize;
    private System.Windows.Forms.TextBox txtOrganization;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnRegPlugn;
    private System.Windows.Forms.Label label2;
  }
}