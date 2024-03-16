namespace ExemploGetVolumeInformation
{
  partial class Form1
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
      this.log = new System.Windows.Forms.TextBox();
      this.recupera = new System.Windows.Forms.Button();
      this.drives = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // log
      // 
      this.log.Location = new System.Drawing.Point(12, 43);
      this.log.Multiline = true;
      this.log.Name = "log";
      this.log.Size = new System.Drawing.Size(453, 217);
      this.log.TabIndex = 0;
      // 
      // recupera
      // 
      this.recupera.Location = new System.Drawing.Point(112, 12);
      this.recupera.Name = "recupera";
      this.recupera.Size = new System.Drawing.Size(135, 23);
      this.recupera.TabIndex = 1;
      this.recupera.Text = "Recupera informações";
      this.recupera.UseVisualStyleBackColor = true;
      this.recupera.Click += new System.EventHandler(this.button1_Click);
      // 
      // drives
      // 
      this.drives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.drives.FormattingEnabled = true;
      this.drives.Location = new System.Drawing.Point(12, 12);
      this.drives.Name = "drives";
      this.drives.Size = new System.Drawing.Size(94, 21);
      this.drives.TabIndex = 2;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(477, 272);
      this.Controls.Add(this.drives);
      this.Controls.Add(this.recupera);
      this.Controls.Add(this.log);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox log;
    private System.Windows.Forms.Button recupera;
    private System.Windows.Forms.ComboBox drives;
  }
}

