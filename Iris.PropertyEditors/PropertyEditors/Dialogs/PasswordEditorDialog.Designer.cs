namespace Iris.PropertyEditors.Dialogs
{
  partial class PasswordEditorDialog
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
      this.tbAtual = new System.Windows.Forms.TextBox();
      this.lbSenhaAtual = new System.Windows.Forms.Label();
      this.tbNova = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbConfirm = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // tbAtual
      // 
      this.tbAtual.Location = new System.Drawing.Point(12, 29);
      this.tbAtual.Name = "tbAtual";
      this.tbAtual.PasswordChar = '*';
      this.tbAtual.Size = new System.Drawing.Size(147, 20);
      this.tbAtual.TabIndex = 2;
      // 
      // lbSenhaAtual
      // 
      this.lbSenhaAtual.AutoSize = true;
      this.lbSenhaAtual.Location = new System.Drawing.Point(12, 13);
      this.lbSenhaAtual.Name = "lbSenhaAtual";
      this.lbSenhaAtual.Size = new System.Drawing.Size(65, 13);
      this.lbSenhaAtual.TabIndex = 3;
      this.lbSenhaAtual.Text = "Senha Atual";
      // 
      // tbNova
      // 
      this.tbNova.Location = new System.Drawing.Point(12, 68);
      this.tbNova.Name = "tbNova";
      this.tbNova.PasswordChar = '*';
      this.tbNova.Size = new System.Drawing.Size(147, 20);
      this.tbNova.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 52);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Nova Senha";
      // 
      // tbConfirm
      // 
      this.tbConfirm.Location = new System.Drawing.Point(12, 107);
      this.tbConfirm.Name = "tbConfirm";
      this.tbConfirm.PasswordChar = '*';
      this.tbConfirm.Size = new System.Drawing.Size(147, 20);
      this.tbConfirm.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 91);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(66, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Confirmação";
      // 
      // PasswordEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(173, 205);
      this.Controls.Add(this.tbConfirm);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.tbNova);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbAtual);
      this.Controls.Add(this.lbSenhaAtual);
      this.Name = "PasswordEditorDialog";
      this.Text = "Alteração de Senha";
      this.Controls.SetChildIndex(this.lbSenhaAtual, 0);
      this.Controls.SetChildIndex(this.tbAtual, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.tbNova, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.tbConfirm, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbAtual;
    private System.Windows.Forms.Label lbSenhaAtual;
    private System.Windows.Forms.TextBox tbNova;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbConfirm;
    private System.Windows.Forms.Label label3;
  }
}