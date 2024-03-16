namespace Iris.PropertyEditors.Dialogs
{
  partial class ConnectionEditorDialog
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
      this.connectionEditorControl = new Iris.PropertyEditors.Controls.ConnectionEditorControl();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(65, 4);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(146, 4);
      // 
      // connectionEditorControl
      // 
      this.connectionEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.connectionEditorControl.Location = new System.Drawing.Point(0, 0);
      this.connectionEditorControl.MinimumSize = new System.Drawing.Size(223, 174);
      this.connectionEditorControl.Name = "connectionEditorControl";
      this.connectionEditorControl.Size = new System.Drawing.Size(226, 174);
      this.connectionEditorControl.TabIndex = 2;
      // 
      // ConnectionEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(226, 204);
      this.Controls.Add(this.connectionEditorControl);
      this.Name = "ConnectionEditorDialog";
      this.Text = "Conexão";
      this.Controls.SetChildIndex(this.connectionEditorControl, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private Iris.PropertyEditors.Controls.ConnectionEditorControl connectionEditorControl;
  }
}
