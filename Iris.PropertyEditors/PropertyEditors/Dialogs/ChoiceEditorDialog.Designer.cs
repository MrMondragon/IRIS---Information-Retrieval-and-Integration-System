namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  partial class ChoiceEditorDialog
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
      this.choiceEditorControl1 = new Iris.PropertyEditors.PropertyEditors.Controls.ChoiceEditorControl();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 324);
      this.panel1.Size = new System.Drawing.Size(418, 30);
      // 
      // choiceEditorControl1
      // 
      this.choiceEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.choiceEditorControl1.Location = new System.Drawing.Point(0, 0);
      this.choiceEditorControl1.Name = "choiceEditorControl1";
      this.choiceEditorControl1.Size = new System.Drawing.Size(418, 354);
      this.choiceEditorControl1.TabIndex = 2;
      // 
      // ChoiceEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(418, 354);
      this.Controls.Add(this.choiceEditorControl1);
      this.Name = "ChoiceEditorDialog";
      this.Text = "Alternativas";
      this.Controls.SetChildIndex(this.choiceEditorControl1, 0);
      this.Controls.SetChildIndex(this.panel1, 0);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Iris.PropertyEditors.PropertyEditors.Controls.ChoiceEditorControl choiceEditorControl1;


    
  }
}
