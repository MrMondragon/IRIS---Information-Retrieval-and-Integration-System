using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace UserMargin
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.CheckBox chbPaintUserMargin;
		private System.Windows.Forms.Label laUserMarginWidth;
		private System.Windows.Forms.NumericUpDown nudUserMarginWidth;
		private System.Windows.Forms.TextBox tbUserMarginText;
		private System.Windows.Forms.Label laUserMarginText;
		private System.Windows.Forms.Label laUserMarginBkColor;
		private System.Windows.Forms.Label laUserMarginForeColor;
		private QWhale.Common.ColorBox cbUserMarginBkColor;
		private QWhale.Common.ColorBox cbUserMarginForeColor;
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
			this.laUserMarginBkColor = new System.Windows.Forms.Label();
			this.cbUserMarginBkColor = new QWhale.Common.ColorBox(this.components);
			this.laUserMarginForeColor = new System.Windows.Forms.Label();
			this.cbUserMarginForeColor = new QWhale.Common.ColorBox(this.components);
			this.laUserMarginText = new System.Windows.Forms.Label();
			this.tbUserMarginText = new System.Windows.Forms.TextBox();
			this.laUserMarginWidth = new System.Windows.Forms.Label();
			this.nudUserMarginWidth = new System.Windows.Forms.NumericUpDown();
			this.chbPaintUserMargin = new System.Windows.Forms.CheckBox();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.pnSettings.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudUserMarginWidth)).BeginInit();
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
			this.groupBox1.Controls.Add(this.laUserMarginBkColor);
			this.groupBox1.Controls.Add(this.cbUserMarginBkColor);
			this.groupBox1.Controls.Add(this.laUserMarginForeColor);
			this.groupBox1.Controls.Add(this.cbUserMarginForeColor);
			this.groupBox1.Controls.Add(this.laUserMarginText);
			this.groupBox1.Controls.Add(this.tbUserMarginText);
			this.groupBox1.Controls.Add(this.laUserMarginWidth);
			this.groupBox1.Controls.Add(this.nudUserMarginWidth);
			this.groupBox1.Controls.Add(this.chbPaintUserMargin);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 80);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User margin";
			// 
			// laUserMarginBkColor
			// 
			this.laUserMarginBkColor.AutoSize = true;
			this.laUserMarginBkColor.Location = new System.Drawing.Point(352, 51);
			this.laUserMarginBkColor.Name = "laUserMarginBkColor";
			this.laUserMarginBkColor.Size = new System.Drawing.Size(59, 16);
			this.laUserMarginBkColor.TabIndex = 38;
			this.laUserMarginBkColor.Text = "Back Color";
			// 
			// cbUserMarginBkColor
			// 
			this.cbUserMarginBkColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbUserMarginBkColor.Location = new System.Drawing.Point(424, 48);
			this.cbUserMarginBkColor.Name = "cbUserMarginBkColor";
			this.cbUserMarginBkColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbUserMarginBkColor.Size = new System.Drawing.Size(104, 21);
			this.cbUserMarginBkColor.TabIndex = 37;
			this.cbUserMarginBkColor.SelectedIndexChanged += new System.EventHandler(this.cbUserMarginBkColor_SelectedIndexChanged);
			// 
			// laUserMarginForeColor
			// 
			this.laUserMarginForeColor.AutoSize = true;
			this.laUserMarginForeColor.Location = new System.Drawing.Point(352, 19);
			this.laUserMarginForeColor.Name = "laUserMarginForeColor";
			this.laUserMarginForeColor.Size = new System.Drawing.Size(58, 16);
			this.laUserMarginForeColor.TabIndex = 36;
			this.laUserMarginForeColor.Text = "Fore Color";
			// 
			// cbUserMarginForeColor
			// 
			this.cbUserMarginForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbUserMarginForeColor.Location = new System.Drawing.Point(424, 16);
			this.cbUserMarginForeColor.Name = "cbUserMarginForeColor";
			this.cbUserMarginForeColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbUserMarginForeColor.Size = new System.Drawing.Size(104, 21);
			this.cbUserMarginForeColor.TabIndex = 35;
			this.cbUserMarginForeColor.SelectedIndexChanged += new System.EventHandler(this.cbUserMarginForeColor_SelectedIndexChanged);
			// 
			// laUserMarginText
			// 
			this.laUserMarginText.AutoSize = true;
			this.laUserMarginText.Location = new System.Drawing.Point(120, 51);
			this.laUserMarginText.Name = "laUserMarginText";
			this.laUserMarginText.Size = new System.Drawing.Size(87, 16);
			this.laUserMarginText.TabIndex = 34;
			this.laUserMarginText.Text = "User margin text";
			// 
			// tbUserMarginText
			// 
			this.tbUserMarginText.Location = new System.Drawing.Point(224, 48);
			this.tbUserMarginText.Name = "tbUserMarginText";
			this.tbUserMarginText.TabIndex = 33;
			this.tbUserMarginText.Text = "";
			this.tbUserMarginText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUserMarginText_KeyDown);
			this.tbUserMarginText.Leave += new System.EventHandler(this.tbUserMarginText_Leave);
			// 
			// laUserMarginWidth
			// 
			this.laUserMarginWidth.AutoSize = true;
			this.laUserMarginWidth.Location = new System.Drawing.Point(120, 19);
			this.laUserMarginWidth.Name = "laUserMarginWidth";
			this.laUserMarginWidth.Size = new System.Drawing.Size(95, 16);
			this.laUserMarginWidth.TabIndex = 31;
			this.laUserMarginWidth.Text = "User margin width";
			// 
			// nudUserMarginWidth
			// 
			this.nudUserMarginWidth.Location = new System.Drawing.Point(224, 16);
			this.nudUserMarginWidth.Name = "nudUserMarginWidth";
			this.nudUserMarginWidth.Size = new System.Drawing.Size(100, 20);
			this.nudUserMarginWidth.TabIndex = 32;
			this.nudUserMarginWidth.ValueChanged += new System.EventHandler(this.nudUserMarginWidth_ValueChanged);
			// 
			// chbPaintUserMargin
			// 
			this.chbPaintUserMargin.Location = new System.Drawing.Point(8, 16);
			this.chbPaintUserMargin.Name = "chbPaintUserMargin";
			this.chbPaintUserMargin.Size = new System.Drawing.Size(112, 24);
			this.chbPaintUserMargin.TabIndex = 30;
			this.chbPaintUserMargin.Text = "Paint user margin";
			this.chbPaintUserMargin.CheckedChanged += new System.EventHandler(this.chbPaintUserMargin_CheckedChanged);
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
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 24);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo show how user margin can be used.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 104);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Pages.RulerBackColor = System.Drawing.Color.LightSteelBlue;
			this.syntaxEdit1.Pages.RulerIndentBackColor = System.Drawing.Color.SteelBlue;
			this.syntaxEdit1.Pages.Transparent = false;
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 214);
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
				") 2004, 2005 Quantum Whale LLC.</Copyright>\r\n  <FileExtension />\r\n  <FileType>c#" +
				"</FileType>\r\n  <Version>1.1</Version>\r\n  <Styles>\r\n    <Style>\r\n      <Name>iden" +
				"ts</Name>\r\n      <ForeColor>ControlText</ForeColor>\r\n      <Index>0</Index>\r\n   " +
				" </Style>\r\n    <Style>\r\n      <Name>numbers</Name>\r\n      <ForeColor>Green</Fore" +
				"Color>\r\n      <Index>1</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>reswords<" +
				"/Name>\r\n      <ForeColor>Blue</ForeColor>\r\n      <Index>2</Index>\r\n    </Style>\r" +
				"\n    <Style>\r\n      <Name>comments</Name>\r\n      <ForeColor>Green</ForeColor>\r\n " +
				"     <Index>3</Index>\r\n      <PlainText>true</PlainText>\r\n    </Style>\r\n    <Sty" +
				"le>\r\n      <Name>xmlcomments</Name>\r\n      <ForeColor>Gray</ForeColor>\r\n      <I" +
				"ndex>4</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>symbols</Name>\r\n      <Fo" +
				"reColor>Gray</ForeColor>\r\n      <Index>5</Index>\r\n    </Style>\r\n    <Style>\r\n   " +
				"   <Name>whitespace</Name>\r\n      <ForeColor>WindowText</ForeColor>\r\n      <Inde" +
				"x>6</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>strings</Name>\r\n      <ForeC" +
				"olor>Maroon</ForeColor>\r\n      <Index>7</Index>\r\n      <PlainText>true</PlainTex" +
				"t>\r\n    </Style>\r\n    <Style>\r\n      <Name>directives</Name>\r\n      <ForeColor>B" +
				"lue</ForeColor>\r\n      <Index>8</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>" +
				"syntaxerrors</Name>\r\n      <ForeColor>Red</ForeColor>\r\n      <Index>9</Index>\r\n " +
				"   </Style>\r\n  </Styles>\r\n  <States />\r\n</LexScheme>";
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
			((System.ComponentModel.ISupportInitialize)(this.nudUserMarginWidth)).EndInit();
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
			chbPaintUserMargin.Checked = (syntaxEdit1.Gutter.Options & GutterOptions.PaintUserMargin) != 0;
			nudUserMarginWidth.Maximum = syntaxEdit1.Width;
			nudUserMarginWidth.Value = syntaxEdit1.Gutter.UserMarginWidth;
			tbUserMarginText.Text = syntaxEdit1.Gutter.UserMarginText;
			cbUserMarginForeColor.SelectedColor = syntaxEdit1.Gutter.UserMarginForeColor;
			cbUserMarginBkColor.SelectedColor = syntaxEdit1.Gutter.UserMarginBackColor;
		}

		private void chbPaintUserMargin_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.Options = (chbPaintUserMargin.Checked ? syntaxEdit1.Gutter.Options
				| GutterOptions.PaintUserMargin : syntaxEdit1.Gutter.Options ^ GutterOptions.PaintUserMargin);
		}

		private void nudUserMarginWidth_ValueChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.UserMarginWidth = (int)nudUserMarginWidth.Value;
		}

		private void tbUserMarginText_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				syntaxEdit1.Gutter.UserMarginText = tbUserMarginText.Text;
		}

		private void tbUserMarginText_Leave(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.UserMarginText = tbUserMarginText.Text;
		}

		private void cbUserMarginForeColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.UserMarginForeColor = cbUserMarginForeColor.SelectedColor;
		}

		private void cbUserMarginBkColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.UserMarginBackColor = cbUserMarginBkColor.SelectedColor;
		}
	}
}
