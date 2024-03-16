namespace Iris.Runtime.Core.Iris.ExpressionEditor
{
  partial class ExpressionEditorDialog
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
      this.ExpressionEditorControl = new ExpressionEditorControl();
      this.SuspendLayout();
      // 
      // ExpressionEditorControl
      // 
      this.ExpressionEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ExpressionEditorControl.Location = new System.Drawing.Point(0, 0);
      this.ExpressionEditorControl.Name = "ExpressionEditorControl";
      this.ExpressionEditorControl.Size = new System.Drawing.Size(474, 430);
      this.ExpressionEditorControl.TabIndex = 2;
      // 
      // ExpressionEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(474, 430);
      this.Controls.Add(this.ExpressionEditorControl);
      this.Name = "ExpressionEditorDialog";
      this.Text = "ExpressionEditorDialog";
      this.Controls.SetChildIndex(this.ExpressionEditorControl, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private ExpressionEditorControl ExpressionEditorControl;
  }
}