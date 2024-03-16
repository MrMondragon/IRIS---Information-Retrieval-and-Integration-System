namespace ImpDialogs
{
  partial class RelationEditorDialog
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
      this.grdCorrespondencias = new System.Windows.Forms.DataGridView();
      this.colMestre = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.colDetalhe = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grdCorrespondencias)).BeginInit();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnOk.Location = new System.Drawing.Point(324, 3);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnCancel.Location = new System.Drawing.Point(405, 3);
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 224);
      this.panel1.Size = new System.Drawing.Size(483, 30);
      // 
      // grdCorrespondencias
      // 
      this.grdCorrespondencias.BackgroundColor = System.Drawing.SystemColors.Control;
      this.grdCorrespondencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdCorrespondencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMestre,
            this.colDetalhe});
      this.grdCorrespondencias.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdCorrespondencias.Location = new System.Drawing.Point(0, 0);
      this.grdCorrespondencias.Name = "grdCorrespondencias";
      this.grdCorrespondencias.Size = new System.Drawing.Size(483, 224);
      this.grdCorrespondencias.TabIndex = 7;
      // 
      // colMestre
      // 
      this.colMestre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.colMestre.HeaderText = "Campo Mestre";
      this.colMestre.Name = "colMestre";
      // 
      // colDetalhe
      // 
      this.colDetalhe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.colDetalhe.HeaderText = "Campo Detalhe";
      this.colDetalhe.Name = "colDetalhe";
      // 
      // RelationDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(483, 254);
      this.Controls.Add(this.grdCorrespondencias);
      this.Name = "RelationDialog";
      this.Text = "Relacionamento";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.grdCorrespondencias, 0);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grdCorrespondencias)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView grdCorrespondencias;
    private System.Windows.Forms.DataGridViewComboBoxColumn colMestre;
    private System.Windows.Forms.DataGridViewComboBoxColumn colDetalhe;


  }
}