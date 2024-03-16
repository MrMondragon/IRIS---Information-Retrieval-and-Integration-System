namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  partial class ParameterMappingEditorDialog
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterMappingEditorDialog));
      this.tvwMapping = new System.Windows.Forms.TreeView();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtParametro = new System.Windows.Forms.TextBox();
      this.txtTipo = new System.Windows.Forms.TextBox();
      this.cbxFields = new System.Windows.Forms.ComboBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 333);
      this.panel1.Size = new System.Drawing.Size(559, 30);
      // 
      // tvwMapping
      // 
      this.tvwMapping.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvwMapping.ImageIndex = 0;
      this.tvwMapping.ImageList = this.imageList;
      this.tvwMapping.Location = new System.Drawing.Point(3, 16);
      this.tvwMapping.Name = "tvwMapping";
      this.tvwMapping.SelectedImageIndex = 0;
      this.tvwMapping.Size = new System.Drawing.Size(302, 314);
      this.tvwMapping.TabIndex = 2;
      this.tvwMapping.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwMapping_AfterSelect);
      // 
      // imageList
      // 
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList.Images.SetKeyName(0, "Param.png");
      this.imageList.Images.SetKeyName(1, "Class.png");
      this.imageList.Images.SetKeyName(2, "Field.png");
      this.imageList.Images.SetKeyName(3, "Property.png");
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.tvwMapping);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(308, 333);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Parâmetros";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.cbxFields);
      this.groupBox3.Controls.Add(this.txtTipo);
      this.groupBox3.Controls.Add(this.txtParametro);
      this.groupBox3.Controls.Add(this.label3);
      this.groupBox3.Controls.Add(this.label2);
      this.groupBox3.Controls.Add(this.label1);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
      this.groupBox3.Location = new System.Drawing.Point(308, 0);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(251, 333);
      this.groupBox3.TabIndex = 5;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Mapeamento";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 50);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Parâmetro:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 144);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(31, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Tipo:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 238);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(94, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Campo de Origem:";
      // 
      // txtParametro
      // 
      this.txtParametro.BackColor = System.Drawing.SystemColors.Control;
      this.txtParametro.Enabled = false;
      this.txtParametro.Location = new System.Drawing.Point(9, 66);
      this.txtParametro.Name = "txtParametro";
      this.txtParametro.ReadOnly = true;
      this.txtParametro.Size = new System.Drawing.Size(239, 20);
      this.txtParametro.TabIndex = 3;
      // 
      // txtTipo
      // 
      this.txtTipo.BackColor = System.Drawing.SystemColors.Control;
      this.txtTipo.Enabled = false;
      this.txtTipo.Location = new System.Drawing.Point(9, 160);
      this.txtTipo.Name = "txtTipo";
      this.txtTipo.ReadOnly = true;
      this.txtTipo.Size = new System.Drawing.Size(239, 20);
      this.txtTipo.TabIndex = 4;
      // 
      // cbxFields
      // 
      this.cbxFields.FormattingEnabled = true;
      this.cbxFields.Location = new System.Drawing.Point(9, 254);
      this.cbxFields.Name = "cbxFields";
      this.cbxFields.Size = new System.Drawing.Size(239, 21);
      this.cbxFields.TabIndex = 5;
      this.cbxFields.SelectedIndexChanged += new System.EventHandler(this.cbxFields_SelectedIndexChanged);
      // 
      // ParameterMappingEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(559, 363);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.groupBox3);
      this.Name = "ParameterMappingEditorDialog";
      this.Text = "ParameterMappingEditorDialog";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.groupBox3, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView tvwMapping;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.ComboBox cbxFields;
    private System.Windows.Forms.TextBox txtTipo;
    private System.Windows.Forms.TextBox txtParametro;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}