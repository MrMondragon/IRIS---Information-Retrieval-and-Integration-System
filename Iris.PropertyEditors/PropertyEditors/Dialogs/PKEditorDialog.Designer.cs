namespace Iris.PropertyEditors.Dialogs
{
  partial class PKEditorDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PKEditorDialog));
      this.imlCommands = new System.Windows.Forms.ImageList(this.components);
      this.cbxColumns = new System.Windows.Forms.CheckedListBox();
      this.SuspendLayout();
      // 
      // imlCommands
      // 
      this.imlCommands.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCommands.ImageStream")));
      this.imlCommands.TransparentColor = System.Drawing.Color.Fuchsia;
      this.imlCommands.Images.SetKeyName(0, "BuilderDialog_delete.bmp");
      this.imlCommands.Images.SetKeyName(1, "New.bmp");
      // 
      // cbxColumns
      // 
      this.cbxColumns.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbxColumns.FormattingEnabled = true;
      this.cbxColumns.Location = new System.Drawing.Point(0, 0);
      this.cbxColumns.Name = "cbxColumns";
      this.cbxColumns.Size = new System.Drawing.Size(215, 289);
      this.cbxColumns.TabIndex = 2;
      // 
      // PKEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(215, 327);
      this.Controls.Add(this.cbxColumns);
      this.Name = "PKEditorDialog";
      this.Text = "Chave Primária";
      this.Controls.SetChildIndex(this.cbxColumns, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList imlCommands;
    private System.Windows.Forms.CheckedListBox cbxColumns;
  }
}
