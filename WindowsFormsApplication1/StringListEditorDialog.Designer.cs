namespace Databridge.PropertyEditors.PropertyEditors.Dialogs
{
  partial class StringListEditorDialog
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
      this.control = new Databridge.PropertyEditors.PropertyEditors.Controls.StringListEditorControl();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabEditor = new System.Windows.Forms.TabPage();
      this.tabText = new System.Windows.Forms.TabPage();
      this.txtText = new QWhale.Editor.SyntaxEdit(this.components);
      this.panel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabEditor.SuspendLayout();
      this.tabText.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 322);
      this.panel1.Size = new System.Drawing.Size(439, 30);
      // 
      // control
      // 
      this.control.Dock = System.Windows.Forms.DockStyle.Fill;
      this.control.Location = new System.Drawing.Point(3, 3);
      this.control.Name = "control";
      this.control.Size = new System.Drawing.Size(425, 290);
      this.control.TabIndex = 2;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabEditor);
      this.tabControl1.Controls.Add(this.tabText);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(439, 322);
      this.tabControl1.TabIndex = 3;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // tabEditor
      // 
      this.tabEditor.Controls.Add(this.control);
      this.tabEditor.Location = new System.Drawing.Point(4, 22);
      this.tabEditor.Name = "tabEditor";
      this.tabEditor.Padding = new System.Windows.Forms.Padding(3);
      this.tabEditor.Size = new System.Drawing.Size(431, 296);
      this.tabEditor.TabIndex = 0;
      this.tabEditor.Text = "Editor";
      this.tabEditor.UseVisualStyleBackColor = true;
      // 
      // tabText
      // 
      this.tabText.Controls.Add(this.txtText);
      this.tabText.Location = new System.Drawing.Point(4, 22);
      this.tabText.Name = "tabText";
      this.tabText.Padding = new System.Windows.Forms.Padding(3);
      this.tabText.Size = new System.Drawing.Size(431, 296);
      this.tabText.TabIndex = 1;
      this.tabText.Text = "Texto";
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
      this.txtText.Size = new System.Drawing.Size(425, 290);
      this.txtText.TabIndex = 1;
      this.txtText.Text = "";
      // 
      // StringListEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(439, 352);
      this.Controls.Add(this.tabControl1);
      this.Name = "StringListEditorDialog";
      this.Text = "Valores";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.tabControl1, 0);
      this.panel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabEditor.ResumeLayout(false);
      this.tabText.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Databridge.PropertyEditors.PropertyEditors.Controls.StringListEditorControl control;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabEditor;
    private System.Windows.Forms.TabPage tabText;
    private QWhale.Editor.SyntaxEdit txtText;
  }
}