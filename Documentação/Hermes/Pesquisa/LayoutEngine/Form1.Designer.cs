namespace WindowsApplication1
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
      this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.layoutPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // layoutPanel
      // 
      this.layoutPanel.ColumnCount = 4;
      this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.layoutPanel.Controls.Add(this.button1, 2, 1);
      this.layoutPanel.Controls.Add(this.button2, 1, 2);
      this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.layoutPanel.Location = new System.Drawing.Point(0, 0);
      this.layoutPanel.Name = "layoutPanel";
      this.layoutPanel.RowCount = 4;
      this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.layoutPanel.Size = new System.Drawing.Size(292, 266);
      this.layoutPanel.TabIndex = 0;
      this.layoutPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.layoutPanel_MouseDoubleClick);
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.button1.Location = new System.Drawing.Point(149, 69);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(67, 60);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
      this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
      this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.button2.Location = new System.Drawing.Point(76, 135);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(67, 60);
      this.button2.TabIndex = 1;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
      this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
      this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.layoutPanel);
      this.Name = "Form1";
      this.Text = "Form1";
      this.layoutPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel layoutPanel;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

  }
}

