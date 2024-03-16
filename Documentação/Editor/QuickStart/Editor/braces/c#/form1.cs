using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace Braces
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.CheckBox chbUseRoundRect;
		private System.Windows.Forms.CheckBox chbHighlightBraces;
		private System.Windows.Forms.CheckBox chbTempHighlightBraces;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chbHighlightBounds;
		private System.Windows.Forms.Label laBracesColor;
		private QWhale.Common.ColorBox cbBracesColor;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.Label laFontStyle;
		private System.Windows.Forms.ComboBox cbFontStyle;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pnSettings = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbFontStyle = new System.Windows.Forms.ComboBox();
			this.laFontStyle = new System.Windows.Forms.Label();
			this.cbBracesColor = new QWhale.Common.ColorBox(this.components);
			this.laBracesColor = new System.Windows.Forms.Label();
			this.chbHighlightBounds = new System.Windows.Forms.CheckBox();
			this.chbTempHighlightBraces = new System.Windows.Forms.CheckBox();
			this.chbHighlightBraces = new System.Windows.Forms.CheckBox();
			this.chbUseRoundRect = new System.Windows.Forms.CheckBox();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.pnSettings.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.groupBox1);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 104);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbFontStyle);
			this.groupBox1.Controls.Add(this.laFontStyle);
			this.groupBox1.Controls.Add(this.cbBracesColor);
			this.groupBox1.Controls.Add(this.laBracesColor);
			this.groupBox1.Controls.Add(this.chbHighlightBounds);
			this.groupBox1.Controls.Add(this.chbTempHighlightBraces);
			this.groupBox1.Controls.Add(this.chbHighlightBraces);
			this.groupBox1.Controls.Add(this.chbUseRoundRect);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 80);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Braces";
			// 
			// cbFontStyle
			// 
			this.cbFontStyle.Location = new System.Drawing.Point(344, 18);
			this.cbFontStyle.Name = "cbFontStyle";
			this.cbFontStyle.Size = new System.Drawing.Size(121, 21);
			this.cbFontStyle.TabIndex = 15;
			this.cbFontStyle.Text = "Regular";
			this.cbFontStyle.SelectedIndexChanged += new System.EventHandler(this.cbFontStyle_SelectedIndexChanged);
			// 
			// laFontStyle
			// 
			this.laFontStyle.AutoSize = true;
			this.laFontStyle.Location = new System.Drawing.Point(272, 21);
			this.laFontStyle.Name = "laFontStyle";
			this.laFontStyle.Size = new System.Drawing.Size(55, 16);
			this.laFontStyle.TabIndex = 13;
			this.laFontStyle.Text = "Font Style";
			// 
			// cbBracesColor
			// 
			this.cbBracesColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbBracesColor.Location = new System.Drawing.Point(344, 42);
			this.cbBracesColor.Name = "cbBracesColor";
			this.cbBracesColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbBracesColor.Size = new System.Drawing.Size(121, 21);
			this.cbBracesColor.TabIndex = 16;
			this.cbBracesColor.SelectedIndexChanged += new System.EventHandler(this.cbBracesColor_SelectedIndexChanged);
			// 
			// laBracesColor
			// 
			this.laBracesColor.AutoSize = true;
			this.laBracesColor.Location = new System.Drawing.Point(272, 45);
			this.laBracesColor.Name = "laBracesColor";
			this.laBracesColor.Size = new System.Drawing.Size(70, 16);
			this.laBracesColor.TabIndex = 14;
			this.laBracesColor.Text = "Braces Color";
			// 
			// chbHighlightBounds
			// 
			this.chbHighlightBounds.Location = new System.Drawing.Point(16, 40);
			this.chbHighlightBounds.Name = "chbHighlightBounds";
			this.chbHighlightBounds.Size = new System.Drawing.Size(112, 24);
			this.chbHighlightBounds.TabIndex = 10;
			this.chbHighlightBounds.Text = "Highlight Bounds";
			this.chbHighlightBounds.CheckedChanged += new System.EventHandler(this.chbHighlightBounds_CheckedChanged);
			// 
			// chbTempHighlightBraces
			// 
			this.chbTempHighlightBraces.Location = new System.Drawing.Point(144, 16);
			this.chbTempHighlightBraces.Name = "chbTempHighlightBraces";
			this.chbTempHighlightBraces.Size = new System.Drawing.Size(112, 24);
			this.chbTempHighlightBraces.TabIndex = 11;
			this.chbTempHighlightBraces.Text = "Temp Hightlight";
			this.chbTempHighlightBraces.CheckedChanged += new System.EventHandler(this.cbTempHighlightBraces_CheckedChanged);
			// 
			// chbHighlightBraces
			// 
			this.chbHighlightBraces.Checked = true;
			this.chbHighlightBraces.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbHighlightBraces.Location = new System.Drawing.Point(16, 16);
			this.chbHighlightBraces.Name = "chbHighlightBraces";
			this.chbHighlightBraces.Size = new System.Drawing.Size(112, 24);
			this.chbHighlightBraces.TabIndex = 9;
			this.chbHighlightBraces.Text = "Highlight Braces";
			this.chbHighlightBraces.CheckedChanged += new System.EventHandler(this.chbHighlightBraces_CheckedChanged);
			// 
			// chbUseRoundRect
			// 
			this.chbUseRoundRect.Location = new System.Drawing.Point(144, 40);
			this.chbUseRoundRect.Name = "chbUseRoundRect";
			this.chbUseRoundRect.Size = new System.Drawing.Size(112, 24);
			this.chbUseRoundRect.TabIndex = 12;
			this.chbUseRoundRect.Text = "Use Round Rect";
			this.chbUseRoundRect.CheckedChanged += new System.EventHandler(this.chbUseRoundRect_CheckedChanged);
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(568, 24);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 24);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows ways of highlighting matching braces within edit control\'s conten" +
				"t.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Braces.BackColor = System.Drawing.Color.Yellow;
			this.syntaxEdit1.Braces.BracesOptions = QWhale.Editor.BracesOptions.Highlight;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 104);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 214);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
			// 
			// csParser1
			// 
			this.csParser1.DefaultState = 0;
			this.csParser1.Options = ((QWhale.Syntax.SyntaxOptions)((((QWhale.Syntax.SyntaxOptions.Outline | QWhale.Syntax.SyntaxOptions.SmartIndent) 
				| QWhale.Syntax.SyntaxOptions.CodeCompletion) 
				| QWhale.Syntax.SyntaxOptions.SyntaxErrors)));
			this.csParser1.XmlScheme = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<LexScheme xmlns:xsd=\"http://www.w3.org/" +
				"2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Autho" +
				"r>Quantum Whale LLC.</Author>\r\n  <Name />\r\n  <Desc />\r\n  <Copyright>Copyright (c" +
				") 2004, 2005 Quantum Whale LLC.</Copyright>\r\n  <FileExtension />\r\n  <FileType />" +
				"\r\n  <Version>1.1</Version>\r\n  <Styles>\r\n    <Style>\r\n      <Name>idents</Name>\r\n" +
				"      <ForeColor>ControlText</ForeColor>\r\n      <Index>0</Index>\r\n    </Style>\r\n" +
				"    <Style>\r\n      <Name>numbers</Name>\r\n      <ForeColor>Green</ForeColor>\r\n   " +
				"   <Index>1</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>reswords</Name>\r\n   " +
				"   <ForeColor>Blue</ForeColor>\r\n      <Index>2</Index>\r\n    </Style>\r\n    <Style" +
				">\r\n      <Name>comments</Name>\r\n      <ForeColor>Green</ForeColor>\r\n      <Index" +
				">3</Index>\r\n      <PlainText>true</PlainText>\r\n    </Style>\r\n    <Style>\r\n      " +
				"<Name>xmlcomments</Name>\r\n      <ForeColor>Gray</ForeColor>\r\n      <Index>4</Ind" +
				"ex>\r\n    </Style>\r\n    <Style>\r\n      <Name>symbols</Name>\r\n      <ForeColor>Gra" +
				"y</ForeColor>\r\n      <Index>5</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>wh" +
				"itespace</Name>\r\n      <ForeColor>WindowText</ForeColor>\r\n      <Index>6</Index>" +
				"\r\n    </Style>\r\n    <Style>\r\n      <Name>strings</Name>\r\n      <ForeColor>Maroon" +
				"</ForeColor>\r\n      <Index>7</Index>\r\n      <PlainText>true</PlainText>\r\n    </S" +
				"tyle>\r\n    <Style>\r\n      <Name>directives</Name>\r\n      <ForeColor>Blue</ForeCo" +
				"lor>\r\n      <Index>8</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>syntaxerror" +
				"s</Name>\r\n      <ForeColor>Red</ForeColor>\r\n      <Index>9</Index>\r\n    </Style>" +
				"\r\n  </Styles>\r\n  <States />\r\n</LexScheme>";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 318);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.pnDescription.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			chbHighlightBraces.Checked = (BracesOptions.Highlight & syntaxEdit1.Braces.BracesOptions) != 0;
			chbUseRoundRect.Checked = syntaxEdit1.Braces.UseRoundRect;
			chbTempHighlightBraces.Checked = (BracesOptions.TempHighlight & syntaxEdit1.Braces.BracesOptions) != 0;
			chbHighlightBounds.Checked = (BracesOptions.HighlightBounds & syntaxEdit1.Braces.BracesOptions) != 0;
			cbBracesColor.SelectedColor = syntaxEdit1.Braces.BackColor;
			cbFontStyle.Items.Add(FontStyle.Regular);
			cbFontStyle.Items.Add(FontStyle.Bold);
			cbFontStyle.SelectedIndex = cbFontStyle.Items.IndexOf(syntaxEdit1.Braces.Style);
		}

		private void chbHighlightBraces_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Braces.BracesOptions = (chbHighlightBraces.Checked ? syntaxEdit1.Braces.BracesOptions
				| BracesOptions.Highlight: syntaxEdit1.Braces.BracesOptions ^ BracesOptions.Highlight);
		}

		private void chbUseRoundRect_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Braces.UseRoundRect = chbUseRoundRect.Checked;
			syntaxEdit1.Braces.ForeColor = chbUseRoundRect.Checked? Color.Gray: Color.Black;
		}

		private void cbTempHighlightBraces_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Braces.BracesOptions = (chbTempHighlightBraces.Checked ? syntaxEdit1.Braces.BracesOptions
				| BracesOptions.TempHighlight: syntaxEdit1.Braces.BracesOptions ^ BracesOptions.TempHighlight);
		}

		private void chbHighlightBounds_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Braces.BracesOptions = (chbHighlightBounds.Checked ? syntaxEdit1.Braces.BracesOptions
				| BracesOptions.HighlightBounds: syntaxEdit1.Braces.BracesOptions ^ BracesOptions.HighlightBounds);
		}

		private void cbBracesColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Braces.BackColor = cbBracesColor.SelectedColor;
		}

		private void cbFontStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			object obj = Enum.Parse(typeof(FontStyle), cbFontStyle.Text);
			if ((obj != null) && (obj is FontStyle))
				syntaxEdit1.Braces.Style = (FontStyle)obj;
		}

	}
}
