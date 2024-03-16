using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Syntax.Parsers;
using QWhale.Editor;

namespace CodeSnippets
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
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbCSharpSnippets;
		private System.Windows.Forms.RadioButton rbVBSnippets;
		private QWhale.Editor.TextSource textSource1;
		private QWhale.Editor.TextSource textSource2;
		private QWhale.Syntax.Parsers.VbParser vbParser1;
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
			this.rbVBSnippets = new System.Windows.Forms.RadioButton();
			this.rbCSharpSnippets = new System.Windows.Forms.RadioButton();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.textSource1 = new QWhale.Editor.TextSource(this.components);
			this.textSource2 = new QWhale.Editor.TextSource(this.components);
			this.vbParser1 = new QWhale.Syntax.Parsers.VbParser();
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
			this.groupBox1.Controls.Add(this.rbVBSnippets);
			this.groupBox1.Controls.Add(this.rbCSharpSnippets);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 64);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Snippets";
			// 
			// rbVBSnippets
			// 
			this.rbVBSnippets.Location = new System.Drawing.Point(8, 36);
			this.rbVBSnippets.Name = "rbVBSnippets";
			this.rbVBSnippets.TabIndex = 1;
			this.rbVBSnippets.Text = "VB snippets";
			this.rbVBSnippets.CheckedChanged += new System.EventHandler(this.rbCSharpSnippets_CheckedChanged);
			// 
			// rbCSharpSnippets
			// 
			this.rbCSharpSnippets.Checked = true;
			this.rbCSharpSnippets.Location = new System.Drawing.Point(8, 16);
			this.rbCSharpSnippets.Name = "rbCSharpSnippets";
			this.rbCSharpSnippets.TabIndex = 0;
			this.rbCSharpSnippets.TabStop = true;
			this.rbCSharpSnippets.Text = "C# snippets";
			this.rbCSharpSnippets.CheckedChanged += new System.EventHandler(this.rbCSharpSnippets_CheckedChanged);
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(568, 40);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 40);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows how to use code snippets to complete content. Press \"Ctrl + K + X" +
				"\" to see snippets.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.BorderColor = System.Drawing.Color.Empty;
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
			this.syntaxEdit1.Source = this.textSource1;
			this.syntaxEdit1.TabIndex = 2;
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
			// textSource1
			// 
			this.textSource1.Lexer = this.csParser1;
			this.textSource1.Text = "using System;\r\nusing System.Drawing;\r\nusing System.Collections;\r\nusing System.Com" +
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
			// textSource2
			// 
			this.textSource2.Text = "Public Class Form1\r\n    Inherits System.Windows.Forms.Form\r\n\r\n#Region \" Windows F" +
				"orm Designer generated code \"\r\n\r\n    Public Sub New()\r\n        MyBase.New()\r\n\r\n " +
				"     \'This call is required by the Windows Form Designer.\r\n        InitializeCom" +
				"ponent()\r\n\r\n        \'Add any initialization after the InitializeComponent() call" +
				"\r\n\r\n    End Sub\r\n\r\n    \'Form overrides dispose to clean up the component list.\r\n" +
				"    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)\r\n If d" +
				"isposing Then\r\n            If Not (components Is Nothing) Then\r\n         compone" +
				"nts.Dispose()\r\n            End If\r\n        End If\r\n        MyBase.Dispose(dispos" +
				"ing)\r\n    End Sub\r\n\r\n    \'Required by the Windows Form Designer\r\n    Private com" +
				"ponents As System.ComponentModel.IContainer\r\n\r\n    \'NOTE: The following procedur" +
				"e is required by the Windows Form Designer\r\n    \'It can be modified using the Wi" +
				"ndows Form Designer.  \r\n    \'Do not modify it using the code editor.\r\n    Friend" +
				" WithEvents pnManage As System.Windows.Forms.Panel\r\n    Friend WithEvents Syntax" +
				"Edit1 As QWhale.Editor.SyntaxEdit\r\n    Friend WithEvents pnDescription As System" +
				".Windows.Forms.Panel\r\n    Friend WithEvents laDescription As System.Windows.Form" +
				"s.Label\r\n    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeCo" +
				"mponent()\r\n        Me.components = New System.ComponentModel.Container\r\n     Me." +
				"pnManage = New System.Windows.Forms.Panel\r\n        Me.SyntaxEdit1 = New QWhale.E" +
				"ditor.SyntaxEdit(Me.components)\r\n        Me.pnDescription = New System.Windows.F" +
				"orms.Panel\r\n        Me.laDescription = New System.Windows.Forms.Label\r\n       Me" +
				".pnManage.SuspendLayout()\r\n        Me.pnDescription.SuspendLayout()\r\n      Me.Su" +
				"spendLayout()\r\n        \'\r\n        \'pnManage\r\n        \'\r\n      Me.pnManage.Contro" +
				"ls.Add(Me.pnDescription)\r\n        Me.pnManage.Dock = System.Windows.Forms.DockSt" +
				"yle.Top\r\n        Me.pnManage.Location = New System.Drawing.Point(0, 0)\r\n        " +
				"Me.pnManage.Name = \"pnManage\"\r\n        Me.pnManage.Size = New System.Drawing.Siz" +
				"e(568, 88)\r\n        Me.pnManage.TabIndex = 2\r\n        \'\r\n        \'SyntaxEdit1\r\n " +
				"       \'\r\n        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window\r" +
				"\n        Me.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam\r\n        Me." +
				"SyntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill\r\n        Me.SyntaxEdit1.F" +
				"ont = New System.Drawing.Font(\"Courier New\", 10.0!)\r\n     Me.SyntaxEdit1.Locatio" +
				"n = New System.Drawing.Point(0, 88)\r\n        Me.SyntaxEdit1.Name = \"SyntaxEdit1\"" +
				"\r\n        Me.SyntaxEdit1.Size = New System.Drawing.Size(568, 230)\r\n      Me.Synt" +
				"axEdit1.TabIndex = 3\r\n        Me.SyntaxEdit1.Text = \"\"\r\n        \'\r\n        \'pnDe" +
				"scription\r\n        \'\r\n        Me.pnDescription.Controls.Add(Me.laDescription)\r\n " +
				"       Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top\r\n        Me.pn" +
				"Description.Location = New System.Drawing.Point(0, 0)\r\n        Me.pnDescription." +
				"Name = \"pnDescription\"\r\n        Me.pnDescription.Size = New System.Drawing.Size(" +
				"568, 40)\r\n        Me.pnDescription.TabIndex = 8\r\n      \'\r\n        \'laDescription" +
				"\r\n        \'\r\n        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill" +
				"\r\n        Me.laDescription.Location = New System.Drawing.Point(0, 0)\r\n        Me" +
				".laDescription.Name = \"laDescription\"\r\n        Me.laDescription.Size = New Syste" +
				"m.Drawing.Size(568, 40)\r\n        Me.laDescription.TabIndex = 1\r\n     Me.laDescri" +
				"ption.Text = \"Label1\"\r\n        Me.laDescription.TextAlign = System.Drawing.Conte" +
				"ntAlignment.TopCenter\r\n        \'\r\n        \'Form1\r\n        \'\r\n     Me.AutoScaleBa" +
				"seSize = New System.Drawing.Size(5, 13)\r\n      Me.ClientSize = New System.Drawin" +
				"g.Size(568, 318)\r\n        Me.Controls.Add(Me.SyntaxEdit1)\r\n      Me.Controls.Add" +
				"(Me.pnManage)\r\n        Me.Name = \"Form1\"\r\n        Me.Text = \"Form1\"\r\n        Me." +
				"pnManage.ResumeLayout(False)\r\n        Me.pnDescription.ResumeLayout(False)\r\n    " +
				"    Me.ResumeLayout(False)\r\n\r\n    End Sub\r\n\r\n#End Region\r\n\r\nEnd Class";
			// 
			// vbParser1
			// 
			this.vbParser1.DefaultState = 0;
			this.vbParser1.Options = ((QWhale.Syntax.SyntaxOptions)((((QWhale.Syntax.SyntaxOptions.Outline | QWhale.Syntax.SyntaxOptions.SmartIndent) 
				| QWhale.Syntax.SyntaxOptions.CodeCompletion) 
				| QWhale.Syntax.SyntaxOptions.SyntaxErrors)));
			this.vbParser1.XmlScheme = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<LexScheme xmlns:xsd=\"http://www.w3.org/" +
				"2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Autho" +
				"r>Quantum Whale LLC.</Author>\r\n  <Name />\r\n  <Desc />\r\n  <Copyright>Copyright (c" +
				") 2004, 2005 Quantum Whale LLC.</Copyright>\r\n  <FileExtension />\r\n  <FileType>vb" +
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
				"   </Style>\r\n    <Style>\r\n      <Name>codesnippets</Name>\r\n      <ForeColor>Blac" +
				"k</ForeColor>\r\n      <BackColor>255:180:228:180</BackColor>\r\n      <Index>10</In" +
				"dex>\r\n    </Style>\r\n  </Styles>\r\n  <States />\r\n</LexScheme>";
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

		private void UpdateSnippets()
		{
			if (rbCSharpSnippets.Checked)
			{
				syntaxEdit1.Source = textSource1;
				syntaxEdit1.Lexer = csParser1;
			}
			else
			{
				syntaxEdit1.Source = textSource2;
				syntaxEdit1.Lexer = vbParser1;
			}
		}

		private string dir = Application.StartupPath;
		private void rbCSharpSnippets_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSnippets();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			UpdateSnippets();
			vbParser1.CodeSnippets.LoadFile(dir + @"\VB.xml");
		}
	}
}
