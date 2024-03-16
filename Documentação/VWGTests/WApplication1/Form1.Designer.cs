namespace WApplication1
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
      this.flowChartControl1 = new IrisWebControls.FlowChartControl();
      this.flowChartControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // flowChartControl1
      // 
      this.flowChartControl1.Location = new System.Drawing.Point(12, 12);
      this.flowChartControl1.Name = "flowChartControl1";
      this.flowChartControl1.Size = new System.Drawing.Size(395, 399);
      this.flowChartControl1.TabIndex = 0;
      this.flowChartControl1.Text = "FlowChartControl";
      // 
      // Form1
      // 
      this.Controls.Add(this.flowChartControl1);
      this.Size = new System.Drawing.Size(419, 466);
      this.Text = "Form1";
      this.flowChartControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private IrisWebControls.FlowChartControl flowChartControl1;


  }
}