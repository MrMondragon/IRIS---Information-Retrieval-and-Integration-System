namespace Iris.Designer
{
  partial class CreateTableDialog
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
      this.treeView = new System.Windows.Forms.TreeView();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnSearch = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.txtBusca = new System.Windows.Forms.TextBox();
      this.txtPrefix = new System.Windows.Forms.TextBox();
      this.lbPrefix = new System.Windows.Forms.Label();
      this.btnAll = new System.Windows.Forms.Button();
      this.btnInvert = new System.Windows.Forms.Button();
      this.btnEditFields = new System.Windows.Forms.Button();
      this.btnNone = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 382);
      this.panel1.Size = new System.Drawing.Size(289, 30);
      // 
      // treeView
      // 
      this.treeView.CheckBoxes = true;
      this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeView.Location = new System.Drawing.Point(0, 89);
      this.treeView.Name = "treeView";
      this.treeView.Size = new System.Drawing.Size(289, 293);
      this.treeView.TabIndex = 2;
      this.treeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyUp);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnSearch);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.txtBusca);
      this.panel2.Controls.Add(this.txtPrefix);
      this.panel2.Controls.Add(this.lbPrefix);
      this.panel2.Controls.Add(this.btnAll);
      this.panel2.Controls.Add(this.btnInvert);
      this.panel2.Controls.Add(this.btnEditFields);
      this.panel2.Controls.Add(this.btnNone);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(289, 89);
      this.panel2.TabIndex = 3;
      // 
      // btnSearch
      // 
      this.btnSearch.Location = new System.Drawing.Point(202, 31);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(75, 23);
      this.btnSearch.TabIndex = 8;
      this.btnSearch.Text = "Buscar";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(5, 35);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(40, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Busca:";
      // 
      // txtBusca
      // 
      this.txtBusca.Location = new System.Drawing.Point(51, 32);
      this.txtBusca.Name = "txtBusca";
      this.txtBusca.Size = new System.Drawing.Size(147, 20);
      this.txtBusca.TabIndex = 6;
      this.txtBusca.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyUp);
      // 
      // txtPrefix
      // 
      this.txtPrefix.Location = new System.Drawing.Point(51, 6);
      this.txtPrefix.Name = "txtPrefix";
      this.txtPrefix.Size = new System.Drawing.Size(57, 20);
      this.txtPrefix.TabIndex = 1;
      // 
      // lbPrefix
      // 
      this.lbPrefix.AutoSize = true;
      this.lbPrefix.Location = new System.Drawing.Point(3, 9);
      this.lbPrefix.Name = "lbPrefix";
      this.lbPrefix.Size = new System.Drawing.Size(42, 13);
      this.lbPrefix.TabIndex = 0;
      this.lbPrefix.Text = "Prefixo:";
      // 
      // btnAll
      // 
      this.btnAll.Location = new System.Drawing.Point(114, 58);
      this.btnAll.Name = "btnAll";
      this.btnAll.Size = new System.Drawing.Size(84, 23);
      this.btnAll.TabIndex = 3;
      this.btnAll.Text = "Marcar Todas";
      this.btnAll.UseVisualStyleBackColor = true;
      this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
      // 
      // btnInvert
      // 
      this.btnInvert.Location = new System.Drawing.Point(202, 58);
      this.btnInvert.Name = "btnInvert";
      this.btnInvert.Size = new System.Drawing.Size(75, 23);
      this.btnInvert.TabIndex = 5;
      this.btnInvert.Text = "Inverter";
      this.btnInvert.UseVisualStyleBackColor = true;
      this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
      // 
      // btnEditFields
      // 
      this.btnEditFields.Location = new System.Drawing.Point(114, 4);
      this.btnEditFields.Name = "btnEditFields";
      this.btnEditFields.Size = new System.Drawing.Size(163, 23);
      this.btnEditFields.TabIndex = 2;
      this.btnEditFields.Text = "Editar Campos";
      this.btnEditFields.UseVisualStyleBackColor = true;
      this.btnEditFields.Click += new System.EventHandler(this.btnEditFields_Click);
      // 
      // btnNone
      // 
      this.btnNone.Location = new System.Drawing.Point(8, 59);
      this.btnNone.Name = "btnNone";
      this.btnNone.Size = new System.Drawing.Size(100, 23);
      this.btnNone.TabIndex = 4;
      this.btnNone.Text = "Desmarcar Todas";
      this.btnNone.UseVisualStyleBackColor = true;
      this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
      // 
      // CreateTableDialog
      // 
      this.AcceptButton = null;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(289, 412);
      this.Controls.Add(this.treeView);
      this.Controls.Add(this.panel2);
      this.Name = "CreateTableDialog";
      this.Text = "Criar Tabelas";
      this.Controls.SetChildIndex(this.panel2, 0);
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.treeView, 0);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label2;
    protected System.Windows.Forms.TreeView treeView;
    public System.Windows.Forms.Panel panel2;
    public System.Windows.Forms.Label lbPrefix;
    public System.Windows.Forms.Button btnEditFields;
    public System.Windows.Forms.TextBox txtPrefix;
    public System.Windows.Forms.Button btnAll;
    public System.Windows.Forms.Button btnInvert;
    public System.Windows.Forms.Button btnNone;
    public System.Windows.Forms.TextBox txtBusca;
    public System.Windows.Forms.Button btnSearch;
  }
}