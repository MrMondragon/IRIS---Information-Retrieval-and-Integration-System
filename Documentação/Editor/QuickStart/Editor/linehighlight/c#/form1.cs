using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace LineHighlight
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
		private System.Windows.Forms.CheckBox chbHighlightCurrentLine;
		private System.Windows.Forms.CheckBox chbSeparateLines;
		private QWhale.Common.ColorBox cbHighlightBackColor;
		private QWhale.Common.ColorBox cbHighlightForeColor;
		private System.Windows.Forms.Label laHighlightBackColor;
		private System.Windows.Forms.Label laHighlightForeColor;
		private System.Windows.Forms.Label laLineColor;
		private QWhale.Common.ColorBox cbLineColor;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
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
			this.chbSeparateLines = new System.Windows.Forms.CheckBox();
			this.chbHighlightCurrentLine = new System.Windows.Forms.CheckBox();
			this.laLineColor = new System.Windows.Forms.Label();
			this.laHighlightBackColor = new System.Windows.Forms.Label();
			this.cbLineColor = new QWhale.Common.ColorBox(this.components);
			this.laHighlightForeColor = new System.Windows.Forms.Label();
			this.cbHighlightForeColor = new QWhale.Common.ColorBox(this.components);
			this.cbHighlightBackColor = new QWhale.Common.ColorBox(this.components);
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
			this.pnSettings.Size = new System.Drawing.Size(568, 128);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chbSeparateLines);
			this.groupBox1.Controls.Add(this.chbHighlightCurrentLine);
			this.groupBox1.Controls.Add(this.laLineColor);
			this.groupBox1.Controls.Add(this.laHighlightBackColor);
			this.groupBox1.Controls.Add(this.cbLineColor);
			this.groupBox1.Controls.Add(this.laHighlightForeColor);
			this.groupBox1.Controls.Add(this.cbHighlightForeColor);
			this.groupBox1.Controls.Add(this.cbHighlightBackColor);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 104);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Line highlight";
			// 
			// chbSeparateLines
			// 
			this.chbSeparateLines.Location = new System.Drawing.Point(8, 40);
			this.chbSeparateLines.Name = "chbSeparateLines";
			this.chbSeparateLines.Size = new System.Drawing.Size(136, 24);
			this.chbSeparateLines.TabIndex = 10;
			this.chbSeparateLines.Text = "Separate Lines";
			this.chbSeparateLines.CheckedChanged += new System.EventHandler(this.chbSeparateLines_CheckedChanged);
			// 
			// chbHighlightCurrentLine
			// 
			this.chbHighlightCurrentLine.Checked = true;
			this.chbHighlightCurrentLine.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbHighlightCurrentLine.Location = new System.Drawing.Point(8, 16);
			this.chbHighlightCurrentLine.Name = "chbHighlightCurrentLine";
			this.chbHighlightCurrentLine.Size = new System.Drawing.Size(136, 24);
			this.chbHighlightCurrentLine.TabIndex = 9;
			this.chbHighlightCurrentLine.Text = "Highlight Current Line";
			this.chbHighlightCurrentLine.CheckedChanged += new System.EventHandler(this.chbHighlightCurrentLine_CheckedChanged);
			// 
			// laLineColor
			// 
			this.laLineColor.AutoSize = true;
			this.laLineColor.Location = new System.Drawing.Point(152, 69);
			this.laLineColor.Name = "laLineColor";
			this.laLineColor.Size = new System.Drawing.Size(56, 16);
			this.laLineColor.TabIndex = 16;
			this.laLineColor.Text = "Line Color";
			// 
			// laHighlightBackColor
			// 
			this.laHighlightBackColor.AutoSize = true;
			this.laHighlightBackColor.Location = new System.Drawing.Point(152, 21);
			this.laHighlightBackColor.Name = "laHighlightBackColor";
			this.laHighlightBackColor.Size = new System.Drawing.Size(107, 16);
			this.laHighlightBackColor.TabIndex = 13;
			this.laHighlightBackColor.Text = "Highlight Back Color";
			// 
			// cbLineColor
			// 
			this.cbLineColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbLineColor.Location = new System.Drawing.Point(272, 66);
			this.cbLineColor.Name = "cbLineColor";
			this.cbLineColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbLineColor.Size = new System.Drawing.Size(121, 21);
			this.cbLineColor.TabIndex = 15;
			this.cbLineColor.SelectedIndexChanged += new System.EventHandler(this.cbLineColor_SelectedIndexChanged);
			// 
			// laHighlightForeColor
			// 
			this.laHighlightForeColor.AutoSize = true;
			this.laHighlightForeColor.Location = new System.Drawing.Point(152, 45);
			this.laHighlightForeColor.Name = "laHighlightForeColor";
			this.laHighlightForeColor.Size = new System.Drawing.Size(105, 16);
			this.laHighlightForeColor.TabIndex = 14;
			this.laHighlightForeColor.Text = "Highlight Fore Color";
			// 
			// cbHighlightForeColor
			// 
			this.cbHighlightForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbHighlightForeColor.Location = new System.Drawing.Point(272, 42);
			this.cbHighlightForeColor.Name = "cbHighlightForeColor";
			this.cbHighlightForeColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbHighlightForeColor.Size = new System.Drawing.Size(121, 21);
			this.cbHighlightForeColor.TabIndex = 12;
			this.cbHighlightForeColor.SelectedIndexChanged += new System.EventHandler(this.cbHighlightForeColor_SelectedIndexChanged);
			// 
			// cbHighlightBackColor
			// 
			this.cbHighlightBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbHighlightBackColor.Location = new System.Drawing.Point(272, 18);
			this.cbHighlightBackColor.Name = "cbHighlightBackColor";
			this.cbHighlightBackColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbHighlightBackColor.Size = new System.Drawing.Size(121, 21);
			this.cbHighlightBackColor.TabIndex = 11;
			this.cbHighlightBackColor.SelectedIndexChanged += new System.EventHandler(this.cbHighlightBackColor_SelectedIndexChanged);
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
			this.laDescription.Text = "This demo shows how to visually separate lines in the edit control, and highlight" +
				" current line.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.LineSeparator.Options = QWhale.Editor.SeparatorOptions.HighlightCurrentLine;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 128);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 190);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "using System;\r\nusing System.Drawing;\r\nusing System.Collections;\r\nusing System.Com" +
				"ponentModel;\r\nusing System.Windows.Forms;\r\nusing System.Data;\r\n\r\nnamespace Templ" +
				"ate\r\n{\r\n\t/// <summary>\r\n\t/// Summary description for Form1.\r\n\t/// </summary>\r\n\tp" +
				"ublic class Form1 : System.Windows.Forms.Form\r\n\t{\r\n\t\tprivate QWhale.Editor.Synta" +
				"xEdit syntaxEdit1;\r\n\t\tprivate System.Windows.Forms.Panel pnManage;\r\n\t\tprivate Sy" +
				"stem.Windows.Forms.Panel pnDescription;\r\n\t\tprivate System.Windows.Forms.Label la" +
				"Description;\r\n\t\tprivate System.ComponentModel.IContainer components;\r\n\r\n\t\tpublic" +
				" Form1()\r\n\t\t{\r\n\t\t\t//\r\n\t\t\t// Required for Windows Form Designer support\r\n\t\t\t//\r\n\t" +
				"\t\tInitializeComponent();\r\n\r\n\t\t\t//\r\n\t\t\t// TODO: Add any constructor code after In" +
				"itializeComponent call\r\n\t\t\t//\r\n\t\t}\r\n\r\n\t\t/// <summary>\r\n\t\t/// Clean up any resour" +
				"ces being used.\r\n\t\t/// </summary>\r\n\t\tprotected override void Dispose( bool dispo" +
				"sing )\r\n\t\t{\r\n\t\t\tif( disposing )\r\n\t\t\t{\r\n\t\t\t\tif (components != null) \r\n\t\t\t\t{\r\n\t\t\t\t" +
				"\tcomponents.Dispose();\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\tbase.Dispose( disposing );\r\n\t\t}\r\n\r\n\t\t#re" +
				"gion Windows Form Designer generated code\r\n\t\t/// <summary>\r\n\t\t/// Required metho" +
				"d for Designer support - do not modify\r\n\t\t/// the contents of this method with t" +
				"he code editor.\r\n\t\t/// </summary>\r\n\t\tprivate void InitializeComponent()\r\n\t\t{\r\n\t\t" +
				"\tthis.components = new System.ComponentModel.Container();\r\n\t\t\tthis.pnManage = ne" +
				"w System.Windows.Forms.Panel();\r\n\t\t\tthis.syntaxEdit1 = new QWhale.Editor.SyntaxE" +
				"dit(this.components);\r\n\t\t\tthis.pnDescription = new System.Windows.Forms.Panel();" +
				"\r\n\t\t\tthis.laDescription = new System.Windows.Forms.Label();\r\n\t\t\tthis.pnManage.Su" +
				"spendLayout();\r\n\t\t\tthis.pnDescription.SuspendLayout();\r\n\t\t\tthis.SuspendLayout();" +
				"\r\n\t\t\t// \r\n\t\t\t// pnManage\r\n\t\t\t// \r\n\t\t\tthis.pnManage.Controls.Add(this.pnDescripti" +
				"on);\r\n\t\t\tthis.pnManage.Dock = System.Windows.Forms.DockStyle.Top;\r\n\t\t\tthis.pnMan" +
				"age.Location = new System.Drawing.Point(0, 0);\r\n\t\t\tthis.pnManage.Name = \"pnManag" +
				"e\";\r\n\t\t\tthis.pnManage.Size = new System.Drawing.Size(568, 88);\r\n\t\t\tthis.pnManage" +
				".TabIndex = 1;\r\n\t\t\t// \r\n\t\t\t// syntaxEdit1\r\n\t\t\t// \r\n\t\t\tthis.syntaxEdit1.BackColor" +
				" = System.Drawing.SystemColors.Window;\r\n\t\t\tthis.syntaxEdit1.Cursor = System.Wind" +
				"ows.Forms.Cursors.IBeam;\r\n\t\t\tthis.syntaxEdit1.Dock = System.Windows.Forms.DockSt" +
				"yle.Fill;\r\n\t\t\tthis.syntaxEdit1.Font = new System.Drawing.Font(\"Courier New\", 10F" +
				");\r\n\t\t\tthis.syntaxEdit1.Location = new System.Drawing.Point(0, 88);\r\n\t\t\tthis.syn" +
				"taxEdit1.Name = \"syntaxEdit1\";\r\n\t\t\tthis.syntaxEdit1.Size = new System.Drawing.Si" +
				"ze(568, 230);\r\n\t\t\tthis.syntaxEdit1.TabIndex = 2;\r\n\t\t\tthis.syntaxEdit1.Text = \"\";" +
				"\r\n\t\t\t// \r\n\t\t\t// pnDescription\r\n\t\t\t// \r\n\t\t\tthis.pnDescription.Controls.Add(this.l" +
				"aDescription);\r\n\t\t\tthis.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;" +
				"\r\n\t\t\tthis.pnDescription.Location = new System.Drawing.Point(0, 0);\r\n\t\t\tthis.pnDe" +
				"scription.Name = \"pnDescription\";\r\n\t\t\tthis.pnDescription.Size = new System.Drawi" +
				"ng.Size(568, 40);\r\n\t\t\tthis.pnDescription.TabIndex = 8;\r\n\t\t\t// \r\n\t\t\t// laDescript" +
				"ion\r\n\t\t\t// \r\n\t\t\tthis.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;\r\n" +
				"\t\t\tthis.laDescription.Location = new System.Drawing.Point(0, 0);\r\n\t\t\tthis.laDesc" +
				"ription.Name = \"laDescription\";\r\n\t\t\tthis.laDescription.Size = new System.Drawing" +
				".Size(568, 40);\r\n\t\t\tthis.laDescription.TabIndex = 1;\r\n\t\t\tthis.laDescription.Text" +
				" = \"Label1\";\r\n\t\t\tthis.laDescription.TextAlign = System.Drawing.ContentAlignment." +
				"TopCenter;\r\n\t\t\t// \r\n\t\t\t// Form1\r\n\t\t\t// \r\n\t\t\tthis.AutoScaleBaseSize = new System." +
				"Drawing.Size(5, 13);\r\n\t\t\tthis.ClientSize = new System.Drawing.Size(568, 318);\r\n\t" +
				"\t\tthis.Controls.Add(this.syntaxEdit1);\r\n\t\t\tthis.Controls.Add(this.pnManage);\r\n\t\t" +
				"\tthis.Name = \"Form1\";\r\n\t\t\tthis.Text = \"Form1\";\r\n\t\t\tthis.pnManage.ResumeLayout(fa" +
				"lse);\r\n\t\t\tthis.pnDescription.ResumeLayout(false);\r\n\t\t\tthis.ResumeLayout(false);\r" +
				"\n\r\n\t\t}\r\n\t\t#endregion\r\n\r\n\t\t/// <summary>\r\n\t\t/// The main entry point for the appl" +
				"ication.\r\n\t\t/// </summary>\r\n\t\t[STAThread]\r\n\t\tstatic void Main() \r\n\t\t{\r\n\t\t\tApplic" +
				"ation.Run(new Form1());\r\n\t\t}\r\n\t}\r\n}";
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
			chbHighlightCurrentLine.Checked = (SeparatorOptions.HighlightCurrentLine & syntaxEdit1.LineSeparator.Options) != 0;
			chbSeparateLines.Checked = (SeparatorOptions.SeparateLines & syntaxEdit1.LineSeparator.Options) != 0;
			cbHighlightBackColor.SelectedColor = syntaxEdit1.LineSeparator.HighlightBackColor;
			cbHighlightForeColor.SelectedColor = syntaxEdit1.LineSeparator.HighlightForeColor;
			cbLineColor.SelectedColor = syntaxEdit1.LineSeparator.LineColor;
		}

		private void chbHighlightCurrentLine_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.LineSeparator.Options = (chbHighlightCurrentLine.Checked ? syntaxEdit1.LineSeparator.Options 
				| SeparatorOptions.HighlightCurrentLine : syntaxEdit1.LineSeparator.Options ^ SeparatorOptions.HighlightCurrentLine);
		}

		private void chbSeparateLines_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.LineSeparator.Options = (chbSeparateLines.Checked ? syntaxEdit1.LineSeparator.Options 
				| SeparatorOptions.SeparateLines : syntaxEdit1.LineSeparator.Options ^ SeparatorOptions.SeparateLines);
		}

		private void cbHighlightBackColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.LineSeparator.HighlightBackColor = cbHighlightBackColor.SelectedColor;
		}

		private void cbHighlightForeColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.LineSeparator.HighlightForeColor = cbHighlightForeColor.SelectedColor;
		}

		private void cbLineColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.LineSeparator.LineColor = cbLineColor.SelectedColor;
		}
	}
}
