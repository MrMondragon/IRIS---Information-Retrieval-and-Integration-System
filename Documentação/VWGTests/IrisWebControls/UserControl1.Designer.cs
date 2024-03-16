namespace IrisWebControls
{
  partial class UserControl1
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

    #region Visual WebGui UserControl Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.baseHostControl1 = new Gizmox.WebGUI.Forms.Hosts.BaseHostControl();
      this.SuspendLayout();
      // 
      // baseHostControl1
      // 
      this.baseHostControl1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
      this.baseHostControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.baseHostControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
      this.baseHostControl1.Location = new System.Drawing.Point(0, 0);
      this.baseHostControl1.Name = "baseHostControl1";
      this.baseHostControl1.Path = "WebForm2.aspx";
      this.baseHostControl1.Size = new System.Drawing.Size(391, 391);
      this.baseHostControl1.TabIndex = 0;
      this.baseHostControl1.Text = "baseHostControl1";
      // 
      // UserControl1
      // 
      this.Controls.Add(this.baseHostControl1);
      this.Size = new System.Drawing.Size(391, 306);
      this.Text = "UserControl1";
      this.ResumeLayout(false);

    }

    #endregion

    private Gizmox.WebGUI.Forms.Hosts.BaseHostControl baseHostControl1;



  }
}