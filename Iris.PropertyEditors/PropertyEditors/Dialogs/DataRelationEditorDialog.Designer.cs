namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  partial class DataRelationEditorDialog
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
      this.gbxRelationName = new System.Windows.Forms.GroupBox();
      this.txtRelationName = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.gbxRelationName.SuspendLayout();
      this.SuspendLayout();
      // 
      // gbxRelationName
      // 
      this.gbxRelationName.Controls.Add(this.txtRelationName);
      this.gbxRelationName.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxRelationName.Location = new System.Drawing.Point(0, 0);
      this.gbxRelationName.Name = "gbxRelationName";
      this.gbxRelationName.Size = new System.Drawing.Size(436, 43);
      this.gbxRelationName.TabIndex = 3;
      this.gbxRelationName.TabStop = false;
      this.gbxRelationName.Text = "Relation Name";
      // 
      // txtRelationName
      // 
      this.txtRelationName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtRelationName.Location = new System.Drawing.Point(3, 16);
      this.txtRelationName.Name = "txtRelationName";
      this.txtRelationName.Size = new System.Drawing.Size(430, 20);
      this.txtRelationName.TabIndex = 0;
      // 
      // DataRelationEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(436, 448);
      this.Controls.Add(this.gbxRelationName);
      this.Name = "DataRelationEditorDialog";
      this.Text = "Data Relation";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.gbxRelationName, 0);
      this.panel1.ResumeLayout(false);
      this.gbxRelationName.ResumeLayout(false);
      this.gbxRelationName.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox gbxRelationName;
    private System.Windows.Forms.TextBox txtRelationName;
  }
}