namespace Iris.PropertyEditors.Dialogs
{
  partial class NameEditorDialog
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
      this.tbNome = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(53, 4);
      this.btnOk.TabIndex = 1;
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(134, 4);
      this.btnCancel.TabIndex = 2;
      // 
      // tbNome
      // 
      this.tbNome.Location = new System.Drawing.Point(12, 42);
      this.tbNome.Name = "tbNome";
      this.tbNome.Size = new System.Drawing.Size(188, 20);
      this.tbNome.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Nome";
      // 
      // NameEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(212, 126);
      this.Controls.Add(this.tbNome);
      this.Controls.Add(this.label1);
      this.Name = "NameEditorDialog";
      this.Text = "Selecione o Nome do Objeto";
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.tbNome, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbNome;
    private System.Windows.Forms.Label label1;
  }
}