namespace Iris.PropertyEditors.Dialogs
{
  partial class ScriptEditorDialog
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
      this.syntaxControl1 = new Iris.PropertyEditors.PropertyEditors.Controls.SyntaxControl();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(136, 4);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(217, 4);
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 247);
      this.panel1.Size = new System.Drawing.Size(297, 30);
      // 
      // syntaxControl1
      // 
      this.syntaxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.syntaxControl1.Language = Iris.PropertyEditors.PropertyEditors.Controls.SyntaxLanguage.CSharp;
      this.syntaxControl1.Location = new System.Drawing.Point(0, 0);
      this.syntaxControl1.Name = "syntaxControl1";
      this.syntaxControl1.SelectedObject = null;
      this.syntaxControl1.Size = new System.Drawing.Size(297, 247);
      this.syntaxControl1.Structure = null;
      this.syntaxControl1.TabIndex = 2;
      // 
      // ScriptEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.CancelButton = null;
      this.ClientSize = new System.Drawing.Size(297, 277);
      this.ControlBox = true;
      this.Controls.Add(this.syntaxControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Name = "ScriptEditorDialog";
      this.Text = "Editor";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.syntaxControl1, 0);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    public Iris.PropertyEditors.PropertyEditors.Controls.SyntaxControl syntaxControl1;

  }
}
