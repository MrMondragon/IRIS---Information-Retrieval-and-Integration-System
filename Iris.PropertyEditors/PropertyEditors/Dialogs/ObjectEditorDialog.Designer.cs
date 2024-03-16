namespace Iris.PropertyEditors.Dialogs
{
  partial class ObjectEditorDialog
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
      this.objectEditorControl1 = new Iris.PropertyEditors.Controls.ObjectEditorControl();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 108);
      this.panel1.Size = new System.Drawing.Size(245, 30);
      // 
      // objectEditorControl1
      // 
      this.objectEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectEditorControl1.Location = new System.Drawing.Point(0, 0);
      this.objectEditorControl1.Name = "objectEditorControl1";
      this.objectEditorControl1.Size = new System.Drawing.Size(245, 108);
      this.objectEditorControl1.TabIndex = 0;
      this.objectEditorControl1.Value = "";
      // 
      // ObjectEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(245, 138);
      this.Controls.Add(this.objectEditorControl1);
      this.Name = "ObjectEditorDialog";
      this.Text = "Selecione o Valor";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.objectEditorControl1, 0);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Iris.PropertyEditors.Controls.ObjectEditorControl objectEditorControl1;
  }
}