namespace Iris.PropertyEditors.Dialogs
{
  partial class AssemblyListEditorDialog
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
      this.assemblyListEditorControl1 = new Iris.PropertyEditors.Controls.AssemblyListEditorControl();
      this.SuspendLayout();
      // 
      // assemblyListEditorControl1
      // 
      this.assemblyListEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.assemblyListEditorControl1.Location = new System.Drawing.Point(0, 0);
      this.assemblyListEditorControl1.Name = "assemblyListEditorControl1";
      this.assemblyListEditorControl1.Size = new System.Drawing.Size(415, 405);
      this.assemblyListEditorControl1.TabIndex = 2;
      // 
      // AssemblyListEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(415, 405);
      this.Controls.Add(this.assemblyListEditorControl1);
      this.Name = "AssemblyListEditorDialog";
      this.Text = "Referências de Assemblies ";
      this.Controls.SetChildIndex(this.assemblyListEditorControl1, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private Iris.PropertyEditors.Controls.AssemblyListEditorControl assemblyListEditorControl1;
  }
}