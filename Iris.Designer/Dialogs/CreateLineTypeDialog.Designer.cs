namespace Iris.Designer
{
  partial class CreateLineTypeDialog
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
      this.gbxConex�es = new System.Windows.Forms.GroupBox();
      this.cbxConnections = new System.Windows.Forms.ComboBox();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.gbxConex�es.SuspendLayout();
      this.SuspendLayout();
      // 
      // treeView
      // 
      this.treeView.LineColor = System.Drawing.Color.Black;
      this.treeView.Location = new System.Drawing.Point(0, 137);
      this.treeView.Size = new System.Drawing.Size(298, 312);
      // 
      // panel2
      // 
      this.panel2.Location = new System.Drawing.Point(0, 48);
      this.panel2.Size = new System.Drawing.Size(298, 89);
      // 
      // lbPrefix
      // 
      this.lbPrefix.Size = new System.Drawing.Size(38, 13);
      this.lbPrefix.Text = "Nome:";
      this.lbPrefix.Visible = false;
      // 
      // btnEditFields
      // 
      this.btnEditFields.Location = new System.Drawing.Point(202, 3);
      this.btnEditFields.Size = new System.Drawing.Size(87, 23);
      // 
      // txtPrefix
      // 
      this.txtPrefix.Size = new System.Drawing.Size(145, 20);
      this.txtPrefix.Visible = false;
      // 
      // btnInvert
      // 
      this.btnInvert.Size = new System.Drawing.Size(87, 23);
      // 
      // txtBusca
      // 
      this.txtBusca.Size = new System.Drawing.Size(145, 20);
      // 
      // btnSearch
      // 
      this.btnSearch.Location = new System.Drawing.Point(202, 30);
      this.btnSearch.Size = new System.Drawing.Size(87, 23);
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 449);
      this.panel1.Size = new System.Drawing.Size(298, 30);
      // 
      // gbxConex�es
      // 
      this.gbxConex�es.Controls.Add(this.cbxConnections);
      this.gbxConex�es.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxConex�es.Location = new System.Drawing.Point(0, 0);
      this.gbxConex�es.Name = "gbxConex�es";
      this.gbxConex�es.Size = new System.Drawing.Size(298, 48);
      this.gbxConex�es.TabIndex = 4;
      this.gbxConex�es.TabStop = false;
      this.gbxConex�es.Text = "Conex�es";
      // 
      // cbxConnections
      // 
      this.cbxConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxConnections.FormattingEnabled = true;
      this.cbxConnections.Location = new System.Drawing.Point(6, 19);
      this.cbxConnections.Name = "cbxConnections";
      this.cbxConnections.Size = new System.Drawing.Size(283, 21);
      this.cbxConnections.TabIndex = 0;
      // 
      // CreateLineTypeDialog
      // 
      this.AcceptButton = null;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(298, 479);
      this.Controls.Add(this.gbxConex�es);
      this.Name = "CreateLineTypeDialog";
      this.Controls.SetChildIndex(this.gbxConex�es, 0);
      this.Controls.SetChildIndex(this.panel2, 0);
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.treeView, 0);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.gbxConex�es.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox gbxConex�es;
    private System.Windows.Forms.ComboBox cbxConnections;
  }
}
