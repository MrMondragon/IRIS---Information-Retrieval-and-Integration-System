namespace WindowsApplication1
{
  partial class Form4
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
      this.layoutPanel1 = new LayoutControl.LayoutPanel();
      this.SuspendLayout();
      // 
      // layoutPanel1
      // 
      this.layoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.layoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.layoutPanel1.Name = "layoutPanel1";
      this.layoutPanel1.SelectedColor = System.Drawing.Color.LightSteelBlue;
      this.layoutPanel1.Size = new System.Drawing.Size(371, 392);
      this.layoutPanel1.TabIndex = 0;
      this.layoutPanel1.UnselectedColor = System.Drawing.Color.White;
      // 
      // Form4
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(371, 392);
      this.Controls.Add(this.layoutPanel1);
      this.Name = "Form4";
      this.Text = "Form4";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.ResumeLayout(false);

    }

    #endregion

    private LayoutControl.LayoutPanel layoutPanel1;
  }
}