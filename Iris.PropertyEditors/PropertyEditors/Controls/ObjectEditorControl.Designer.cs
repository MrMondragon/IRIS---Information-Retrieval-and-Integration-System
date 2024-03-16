namespace Iris.PropertyEditors.Controls
{
  partial class ObjectEditorControl
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
      this.grpValor = new System.Windows.Forms.GroupBox();
      this.cbxBoolean = new System.Windows.Forms.CheckBox();
      this.tbText = new System.Windows.Forms.TextBox();
      this.nudNumber = new System.Windows.Forms.NumericUpDown();
      this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
      this.cbbType = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.grpValor.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // grpValor
      // 
      this.grpValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.grpValor.Controls.Add(this.cbxBoolean);
      this.grpValor.Controls.Add(this.tbText);
      this.grpValor.Controls.Add(this.nudNumber);
      this.grpValor.Controls.Add(this.dtpDateTime);
      this.grpValor.Location = new System.Drawing.Point(7, 56);
      this.grpValor.Name = "grpValor";
      this.grpValor.Size = new System.Drawing.Size(223, 45);
      this.grpValor.TabIndex = 4;
      this.grpValor.TabStop = false;
      this.grpValor.Text = "Valor";
      // 
      // cbxBoolean
      // 
      this.cbxBoolean.AutoSize = true;
      this.cbxBoolean.Location = new System.Drawing.Point(88, 19);
      this.cbxBoolean.Name = "cbxBoolean";
      this.cbxBoolean.Size = new System.Drawing.Size(50, 17);
      this.cbxBoolean.TabIndex = 1;
      this.cbxBoolean.Text = "Valor";
      this.cbxBoolean.UseVisualStyleBackColor = true;
      this.cbxBoolean.Validated += new System.EventHandler(this.ValueControlsValidated);
      // 
      // tbText
      // 
      this.tbText.Location = new System.Drawing.Point(144, 18);
      this.tbText.Name = "tbText";
      this.tbText.Size = new System.Drawing.Size(31, 20);
      this.tbText.TabIndex = 2;
      this.tbText.Validated += new System.EventHandler(this.ValueControlsValidated);
      // 
      // nudNumber
      // 
      this.nudNumber.Location = new System.Drawing.Point(181, 18);
      this.nudNumber.Name = "nudNumber";
      this.nudNumber.Size = new System.Drawing.Size(42, 20);
      this.nudNumber.TabIndex = 3;
      this.nudNumber.Validated += new System.EventHandler(this.ValueControlsValidated);
      // 
      // dtpDateTime
      // 
      this.dtpDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDateTime.Location = new System.Drawing.Point(6, 19);
      this.dtpDateTime.Name = "dtpDateTime";
      this.dtpDateTime.Size = new System.Drawing.Size(58, 20);
      this.dtpDateTime.TabIndex = 0;
      this.dtpDateTime.Validated += new System.EventHandler(this.ValueControlsValidated);
      // 
      // cbbType
      // 
      this.cbbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbbType.FormattingEnabled = true;
      this.cbbType.Items.AddRange(new object[] {
            "Texto",
            "Data/Hora",
            "Data",
            "Hora",
            "Número Inteiro",
            "Número Fracionário",
            "Sim/Não"});
      this.cbbType.Location = new System.Drawing.Point(3, 16);
      this.cbbType.Name = "cbbType";
      this.cbbType.Size = new System.Drawing.Size(215, 21);
      this.cbbType.TabIndex = 0;
      this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
      this.cbbType.TextChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.cbbType);
      this.groupBox1.Location = new System.Drawing.Point(7, 9);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(223, 45);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Tipo";
      // 
      // ObjectEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.grpValor);
      this.Name = "ObjectEditorControl";
      this.Size = new System.Drawing.Size(242, 115);
      this.grpValor.ResumeLayout(false);
      this.grpValor.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox grpValor;
    private System.Windows.Forms.ComboBox cbbType;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.NumericUpDown nudNumber;
    private System.Windows.Forms.DateTimePicker dtpDateTime;
    private System.Windows.Forms.CheckBox cbxBoolean;
    private System.Windows.Forms.TextBox tbText;

  }
}
