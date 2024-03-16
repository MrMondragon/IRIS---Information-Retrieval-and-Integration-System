namespace WindowsApplication1
{
  partial class Form2
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
      Dundas.Gauges.WinControl.CircularGauge circularGauge4 = new Dundas.Gauges.WinControl.CircularGauge();
      Dundas.Gauges.WinControl.CircularPointer circularPointer4 = new Dundas.Gauges.WinControl.CircularPointer();
      Dundas.Gauges.WinControl.CircularRange circularRange2 = new Dundas.Gauges.WinControl.CircularRange();
      Dundas.Gauges.WinControl.CircularScale circularScale4 = new Dundas.Gauges.WinControl.CircularScale();
      Dundas.Gauges.WinControl.CircularGauge circularGauge5 = new Dundas.Gauges.WinControl.CircularGauge();
      Dundas.Gauges.WinControl.CircularPointer circularPointer5 = new Dundas.Gauges.WinControl.CircularPointer();
      Dundas.Gauges.WinControl.CircularScale circularScale5 = new Dundas.Gauges.WinControl.CircularScale();
      Dundas.Gauges.WinControl.CircularGauge circularGauge6 = new Dundas.Gauges.WinControl.CircularGauge();
      Dundas.Gauges.WinControl.CircularPointer circularPointer6 = new Dundas.Gauges.WinControl.CircularPointer();
      Dundas.Gauges.WinControl.CircularScale circularScale6 = new Dundas.Gauges.WinControl.CircularScale();
      Dundas.Gauges.WinControl.GaugeLabel gaugeLabel2 = new Dundas.Gauges.WinControl.GaugeLabel();
      Dundas.Gauges.WinControl.InputValue inputValue2 = new Dundas.Gauges.WinControl.InputValue();
      this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
      this.button1 = new System.Windows.Forms.Button();
      this.gaugeContainer1 = new Dundas.Gauges.WinControl.GaugeContainer();
      this.button2 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.gaugeContainer1)).BeginInit();
      this.SuspendLayout();
      // 
      // propertyGrid1
      // 
      this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
      this.propertyGrid1.Location = new System.Drawing.Point(270, 0);
      this.propertyGrid1.Name = "propertyGrid1";
      this.propertyGrid1.Size = new System.Drawing.Size(212, 276);
      this.propertyGrid1.TabIndex = 2;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button1.Location = new System.Drawing.Point(12, 241);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // gaugeContainer1
      // 
      this.gaugeContainer1.AutoLayout = false;
      this.gaugeContainer1.BackFrame.BackColor = System.Drawing.Color.DarkGray;
      this.gaugeContainer1.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
      this.gaugeContainer1.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.TopBottom;
      this.gaugeContainer1.BackFrame.BorderWidth = 30;
      this.gaugeContainer1.BackFrame.FrameColor = System.Drawing.Color.Gray;
      this.gaugeContainer1.BackFrame.FrameGradientEndColor = System.Drawing.Color.Black;
      this.gaugeContainer1.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
      this.gaugeContainer1.BackFrame.FrameWidth = 5F;
      this.gaugeContainer1.BackFrame.GlassEffect = Dundas.Gauges.WinControl.GlassEffect.Simple;
      this.gaugeContainer1.BackFrame.Shape = Dundas.Gauges.WinControl.BackFrameShape.AutoShape;
      this.gaugeContainer1.BackFrame.Style = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
      circularGauge4.BackFrame.BackColor = System.Drawing.Color.Black;
      circularGauge4.BackFrame.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
      circularGauge4.BackFrame.BackGradientType = Dundas.Gauges.WinControl.GradientType.TopBottom;
      circularGauge4.BackFrame.FrameColor = System.Drawing.Color.Gray;
      circularGauge4.BackFrame.FrameGradientEndColor = System.Drawing.Color.Black;
      circularGauge4.BackFrame.FrameGradientType = Dundas.Gauges.WinControl.GradientType.None;
      circularGauge4.BackFrame.FrameWidth = 10F;
      circularGauge4.BackFrame.GlassEffect = Dundas.Gauges.WinControl.GlassEffect.Simple;
      circularGauge4.BackFrame.Shape = Dundas.Gauges.WinControl.BackFrameShape.AutoShape;
      circularGauge4.BackFrame.Style = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
      circularGauge4.Location.X = 33.33332F;
      circularGauge4.Location.Y = -25.21368F;
      circularGauge4.Name = "Default";
      circularGauge4.PivotPoint.X = 50F;
      circularGauge4.PivotPoint.Y = 50F;
      circularPointer4.CapReflection = true;
      circularPointer4.CapWidth = 30F;
      circularPointer4.FillColor = System.Drawing.Color.Red;
      circularPointer4.FillGradientEndColor = System.Drawing.Color.White;
      circularPointer4.Name = "Default";
      circularPointer4.NeedleStyle = Dundas.Gauges.WinControl.NeedleStyle.NeedleStyle11;
      circularGauge4.Pointers.Add(circularPointer4);
      circularRange2.FillColor = System.Drawing.Color.Red;
      circularRange2.FillGradientType = Dundas.Gauges.WinControl.RangeGradientType.None;
      circularRange2.Name = "Range1";
      circularGauge4.Ranges.Add(circularRange2);
      circularScale4.BorderWidth = 1;
      circularScale4.FillColor = System.Drawing.Color.Transparent;
      circularScale4.FillGradientEndColor = System.Drawing.Color.Black;
      circularScale4.FillGradientType = Dundas.Gauges.WinControl.GradientType.TopBottom;
      circularScale4.LabelStyle.TextColor = System.Drawing.Color.White;
      circularScale4.MajorTickMark.Shape = Dundas.Gauges.WinControl.MarkerStyle.Rectangle;
      circularScale4.MajorTickMark.Width = 4F;
      circularScale4.Name = "Default";
      circularScale4.StartAngle = 90F;
      circularScale4.SweepAngle = 180F;
      circularScale4.Width = 0F;
      circularGauge4.Scales.Add(circularScale4);
      circularGauge4.Size.Height = 100F;
      circularGauge4.Size.Width = 33.33333F;
      circularGauge5.BackFrame.GlassEffect = Dundas.Gauges.WinControl.GlassEffect.Simple;
      circularGauge5.BackFrame.Shape = Dundas.Gauges.WinControl.BackFrameShape.AutoShape;
      circularGauge5.BackFrame.Style = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
      circularGauge5.Location.X = 23.13725F;
      circularGauge5.Location.Y = -8.11966F;
      circularGauge5.Name = "Gauge1";
      circularGauge5.PivotPoint.X = 50F;
      circularGauge5.PivotPoint.Y = 50F;
      circularPointer5.Name = "Default";
      circularGauge5.Pointers.Add(circularPointer5);
      circularScale5.Name = "Default";
      circularScale5.StartAngle = 325F;
      circularScale5.SweepAngle = 185F;
      circularGauge5.Scales.Add(circularScale5);
      circularGauge5.Size.Height = 100F;
      circularGauge5.Size.Width = 33.33333F;
      circularGauge6.BackFrame.GlassEffect = Dundas.Gauges.WinControl.GlassEffect.Simple;
      circularGauge6.BackFrame.Shape = Dundas.Gauges.WinControl.BackFrameShape.AutoShape;
      circularGauge6.BackFrame.Style = Dundas.Gauges.WinControl.BackFrameStyle.Edged;
      circularGauge6.Location.X = 41.96078F;
      circularGauge6.Location.Y = -8.119658F;
      circularGauge6.Name = "Gauge2";
      circularGauge6.PivotPoint.X = 50F;
      circularGauge6.PivotPoint.Y = 50F;
      circularPointer6.Name = "Default";
      circularGauge6.Pointers.Add(circularPointer6);
      circularScale6.Name = "Default";
      circularScale6.StartAngle = 210F;
      circularScale6.SweepAngle = 180F;
      circularGauge6.Scales.Add(circularScale6);
      circularGauge6.Size.Height = 100F;
      circularGauge6.Size.Width = 33.33333F;
      this.gaugeContainer1.CircularGauges.Add(circularGauge4);
      this.gaugeContainer1.CircularGauges.Add(circularGauge5);
      this.gaugeContainer1.CircularGauges.Add(circularGauge6);
      this.gaugeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      gaugeLabel2.BackColor = System.Drawing.Color.Empty;
      gaugeLabel2.BackGradientEndColor = System.Drawing.Color.Empty;
      gaugeLabel2.Location.X = 26F;
      gaugeLabel2.Location.Y = 47F;
      gaugeLabel2.Name = "Label1";
      gaugeLabel2.Parent = "CircularGauges.Default";
      gaugeLabel2.Size.Height = 6F;
      gaugeLabel2.Size.Width = 12F;
      this.gaugeContainer1.Labels.Add(gaugeLabel2);
      this.gaugeContainer1.Location = new System.Drawing.Point(0, 0);
      this.gaugeContainer1.Name = "gaugeContainer1";
      this.gaugeContainer1.Size = new System.Drawing.Size(270, 276);
      this.gaugeContainer1.TabIndex = 0;
      inputValue2.Name = "Default";
      this.gaugeContainer1.Values.Add(inputValue2);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(93, 241);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 3;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(482, 276);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.gaugeContainer1);
      this.Controls.Add(this.propertyGrid1);
      this.Name = "Form2";
      this.Text = "Form2";
      ((System.ComponentModel.ISupportInitialize)(this.gaugeContainer1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PropertyGrid propertyGrid1;
    private System.Windows.Forms.Button button1;
    private Dundas.Gauges.WinControl.GaugeContainer gaugeContainer1;
    private System.Windows.Forms.Button button2;
  }
}