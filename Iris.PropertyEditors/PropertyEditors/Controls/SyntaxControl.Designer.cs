namespace Iris.PropertyEditors.PropertyEditors.Controls
{
  partial class SyntaxControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyntaxControl));
      this.synCodeEditor = new QWhale.Editor.SyntaxEdit(this.components);
      this.imlCodeCompSQL = new System.Windows.Forms.ImageList(this.components);
      this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
      this.sqlParser1 = new QWhale.Syntax.Parsers.SqlParser();
      this.SuspendLayout();
      // 
      // synCodeEditor
      // 
      this.synCodeEditor.BackColor = System.Drawing.SystemColors.Window;
      this.synCodeEditor.BorderStyle = QWhale.Common.EditBorderStyle.Fixed3D;
      this.synCodeEditor.Braces.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.synCodeEditor.Braces.BracesOptions = ((QWhale.Editor.BracesOptions)((QWhale.Editor.BracesOptions.Highlight | QWhale.Editor.BracesOptions.HighlightBounds)));
      this.synCodeEditor.Braces.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
      this.synCodeEditor.Braces.UseRoundRect = true;
      this.synCodeEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.synCodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.synCodeEditor.EditMargin.ColumnPositions = new int[0];
      this.synCodeEditor.Font = new System.Drawing.Font("Courier New", 10F);
      this.synCodeEditor.Gutter.LineNumbersAlignment = System.Drawing.StringAlignment.Near;
      this.synCodeEditor.Gutter.Options = ((QWhale.Editor.GutterOptions)(((QWhale.Editor.GutterOptions.PaintLineNumbers | QWhale.Editor.GutterOptions.PaintBookMarks)
                  | QWhale.Editor.GutterOptions.PaintLineModificators)));
      this.synCodeEditor.IndentOptions = ((QWhale.Editor.IndentOptions)(((QWhale.Editor.IndentOptions.AutoIndent | QWhale.Editor.IndentOptions.SmartIndent)
                  | QWhale.Editor.IndentOptions.UsePrevIndent)));
      this.synCodeEditor.LineSeparator.Options = QWhale.Editor.SeparatorOptions.None;
      this.synCodeEditor.Location = new System.Drawing.Point(0, 0);
      this.synCodeEditor.Name = "synCodeEditor";
      this.synCodeEditor.Outlining.AllowOutlining = true;
      this.synCodeEditor.Pages.DefaultPage.PageKind = System.Drawing.Printing.PaperKind.Custom;
      this.synCodeEditor.Pages.DefaultPage.PageSize = new System.Drawing.Size(850, 1100);
      this.synCodeEditor.Pages.PageKind = System.Drawing.Printing.PaperKind.Custom;
      this.synCodeEditor.Pages.PageType = QWhale.Editor.PageType.Normal;
      this.synCodeEditor.Pages.RulerBackColor = System.Drawing.SystemColors.Control;
      this.synCodeEditor.Pages.Rulers = QWhale.Editor.EditRulers.Horizonal;
      this.synCodeEditor.Pages.RulerUnits = QWhale.Editor.RulerUnits.Characters;
      this.synCodeEditor.Scroll.Options = ((QWhale.Editor.ScrollingOptions)((((QWhale.Editor.ScrollingOptions.ShowScrollHint | QWhale.Editor.ScrollingOptions.UseScrollDelta)
                  | QWhale.Editor.ScrollingOptions.AllowSplitHorz)
                  | QWhale.Editor.ScrollingOptions.AllowSplitVert)));
      this.synCodeEditor.Scroll.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
      this.synCodeEditor.Size = new System.Drawing.Size(522, 221);
      this.synCodeEditor.TabIndex = 0;
      this.synCodeEditor.Text = "";
      this.synCodeEditor.NeedCodeCompletion += new QWhale.Editor.CodeCompletionEvent(this.synCodeEditor_NeedCodeCompletion);
      // 
      // imlCodeCompSQL
      // 
      this.imlCodeCompSQL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCodeCompSQL.ImageStream")));
      this.imlCodeCompSQL.TransparentColor = System.Drawing.Color.Transparent;
      this.imlCodeCompSQL.Images.SetKeyName(0, "KeyWord.png");
      this.imlCodeCompSQL.Images.SetKeyName(1, "Table.png");
      this.imlCodeCompSQL.Images.SetKeyName(2, "Field.png");
      // 
      // csParser1
      // 
      this.csParser1.DefaultState = 0;
      this.csParser1.Options = ((QWhale.Syntax.SyntaxOptions)((((((QWhale.Syntax.SyntaxOptions.Outline | QWhale.Syntax.SyntaxOptions.SmartIndent)
                  | QWhale.Syntax.SyntaxOptions.CodeCompletion)
                  | QWhale.Syntax.SyntaxOptions.ReparseOnLineChange)
                  | QWhale.Syntax.SyntaxOptions.QuickInfoTips)
                  | QWhale.Syntax.SyntaxOptions.AutoComplete)));
      this.csParser1.XmlScheme = resources.GetString("csParser1.XmlScheme");
      // 
      // sqlParser1
      // 
      this.sqlParser1.CodeCompletionChars = new char[] {
        '.',
        ','};
      this.sqlParser1.DefaultState = 0;
      this.sqlParser1.Options = ((QWhale.Syntax.SyntaxOptions)((((((QWhale.Syntax.SyntaxOptions.Outline | QWhale.Syntax.SyntaxOptions.SmartIndent)
                  | QWhale.Syntax.SyntaxOptions.CodeCompletion)
                  | QWhale.Syntax.SyntaxOptions.ReparseOnLineChange)
                  | QWhale.Syntax.SyntaxOptions.QuickInfoTips)
                  | QWhale.Syntax.SyntaxOptions.AutoComplete)));
      this.sqlParser1.XmlScheme = resources.GetString("sqlParser1.XmlScheme");
      // 
      // SyntaxControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.synCodeEditor);
      this.Name = "SyntaxControl";
      this.Size = new System.Drawing.Size(522, 221);
      this.ResumeLayout(false);

    }

    #endregion

    private QWhale.Editor.SyntaxEdit synCodeEditor;
    private System.Windows.Forms.ImageList imlCodeCompSQL;
    private QWhale.Syntax.Parsers.CsParser csParser1;
    private QWhale.Syntax.Parsers.SqlParser sqlParser1;

  }
}
