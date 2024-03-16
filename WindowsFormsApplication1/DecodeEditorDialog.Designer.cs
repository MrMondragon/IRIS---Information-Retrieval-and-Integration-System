namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  partial class DecodeEditorDialog
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabData = new System.Windows.Forms.TabPage();
      this.dgItems = new System.Windows.Forms.DataGridView();
      this.colValorOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colValorDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tabText = new System.Windows.Forms.TabPage();
      this.txtText = new QWhale.Editor.SyntaxEdit(this.components);
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabData.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
      this.tabText.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 279);
      this.panel1.Size = new System.Drawing.Size(439, 29);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupBox1.Location = new System.Drawing.Point(0, 233);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(439, 46);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Opção Default";
      // 
      // textBox1
      // 
      this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.textBox1.Location = new System.Drawing.Point(3, 16);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(433, 20);
      this.textBox1.TabIndex = 0;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabData);
      this.tabControl1.Controls.Add(this.tabText);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(439, 233);
      this.tabControl1.TabIndex = 4;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // tabData
      // 
      this.tabData.Controls.Add(this.dgItems);
      this.tabData.Location = new System.Drawing.Point(4, 22);
      this.tabData.Name = "tabData";
      this.tabData.Padding = new System.Windows.Forms.Padding(3);
      this.tabData.Size = new System.Drawing.Size(431, 207);
      this.tabData.TabIndex = 0;
      this.tabData.Text = "Dados";
      this.tabData.UseVisualStyleBackColor = true;
      // 
      // dgItems
      // 
      this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colValorOriginal,
            this.colValorDestino});
      this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgItems.Location = new System.Drawing.Point(3, 3);
      this.dgItems.Name = "dgItems";
      this.dgItems.Size = new System.Drawing.Size(425, 201);
      this.dgItems.TabIndex = 4;
      // 
      // colValorOriginal
      // 
      this.colValorOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.colValorOriginal.HeaderText = "Valor Original";
      this.colValorOriginal.Name = "colValorOriginal";
      // 
      // colValorDestino
      // 
      this.colValorDestino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.colValorDestino.HeaderText = "Valor Destino";
      this.colValorDestino.Name = "colValorDestino";
      // 
      // tabText
      // 
      this.tabText.Controls.Add(this.txtText);
      this.tabText.Location = new System.Drawing.Point(4, 22);
      this.tabText.Name = "tabText";
      this.tabText.Padding = new System.Windows.Forms.Padding(3);
      this.tabText.Size = new System.Drawing.Size(431, 207);
      this.tabText.TabIndex = 1;
      this.tabText.Text = "Text";
      this.tabText.UseVisualStyleBackColor = true;
      // 
      // txtText
      // 
      this.txtText.BackColor = System.Drawing.SystemColors.Window;
      this.txtText.BorderStyle = QWhale.Common.EditBorderStyle.Fixed3D;
      this.txtText.Braces.BracesOptions = QWhale.Editor.BracesOptions.None;
      this.txtText.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtText.Font = new System.Drawing.Font("Courier New", 10F);
      this.txtText.Gutter.LineNumbersAlignment = System.Drawing.StringAlignment.Near;
      this.txtText.LineSeparator.Options = QWhale.Editor.SeparatorOptions.None;
      this.txtText.Location = new System.Drawing.Point(3, 3);
      this.txtText.Name = "txtText";
      this.txtText.Pages.PageType = QWhale.Editor.PageType.Normal;
      this.txtText.Pages.Rulers = QWhale.Editor.EditRulers.None;
      this.txtText.Pages.RulerUnits = QWhale.Editor.RulerUnits.Inches;
      this.txtText.Scroll.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
      this.txtText.Size = new System.Drawing.Size(425, 201);
      this.txtText.TabIndex = 0;
      this.txtText.Text = "";
      // 
      // DecodeEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(439, 308);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.groupBox1);
      this.Name = "DecodeEditorDialog";
      this.Text = "Opções de Decodificação";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.Controls.SetChildIndex(this.tabControl1, 0);
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabData.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
      this.tabText.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabData;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.DataGridViewTextBoxColumn colValorOriginal;
    private System.Windows.Forms.DataGridViewTextBoxColumn colValorDestino;
    private System.Windows.Forms.TabPage tabText;
    private QWhale.Editor.SyntaxEdit txtText;
  }
}