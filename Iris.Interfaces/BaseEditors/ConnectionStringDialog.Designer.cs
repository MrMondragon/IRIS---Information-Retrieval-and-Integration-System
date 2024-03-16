namespace Iris.PropertyEditors.Dialogs
{
  partial class ConnectionStringDialog
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.prgProps = new System.Windows.Forms.PropertyGrid();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.tbConnection = new System.Windows.Forms.TextBox();
      this.btnTestConnection = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnTestConnection);
      this.panel1.Controls.Add(this.btnOk);
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 276);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(474, 30);
      this.panel1.TabIndex = 3;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(317, 3);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(396, 3);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // prgProps
      // 
      this.prgProps.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.prgProps.Location = new System.Drawing.Point(0, 52);
      this.prgProps.Name = "prgProps";
      this.prgProps.Size = new System.Drawing.Size(474, 224);
      this.prgProps.TabIndex = 4;
      this.prgProps.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.prgProps_PropertyValueChanged);
      // 
      // splitter1
      // 
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter1.Location = new System.Drawing.Point(0, 49);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(474, 3);
      this.splitter1.TabIndex = 5;
      this.splitter1.TabStop = false;
      // 
      // tbConnection
      // 
      this.tbConnection.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbConnection.Location = new System.Drawing.Point(0, 0);
      this.tbConnection.Multiline = true;
      this.tbConnection.Name = "tbConnection";
      this.tbConnection.Size = new System.Drawing.Size(474, 49);
      this.tbConnection.TabIndex = 6;
      this.tbConnection.Validated += new System.EventHandler(this.tbConnection_Validated);
      this.tbConnection.Validating += new System.ComponentModel.CancelEventHandler(this.tbConnection_Validating);
      // 
      // btnTestConnection
      // 
      this.btnTestConnection.Location = new System.Drawing.Point(3, 3);
      this.btnTestConnection.Name = "btnTestConnection";
      this.btnTestConnection.Size = new System.Drawing.Size(75, 23);
      this.btnTestConnection.TabIndex = 2;
      this.btnTestConnection.Text = "Teste";
      this.btnTestConnection.UseVisualStyleBackColor = true;
      this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
      // 
      // ConnectionStringDialog
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(474, 306);
      this.Controls.Add(this.tbConnection);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.prgProps);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConnectionStringDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "String de Conexão";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    protected System.Windows.Forms.Panel panel1;
    protected System.Windows.Forms.Button btnOk;
    protected System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.PropertyGrid prgProps;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.TextBox tbConnection;
    private System.Windows.Forms.Button btnTestConnection;
  }
}