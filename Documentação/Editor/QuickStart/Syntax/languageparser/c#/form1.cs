using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Syntax.Schemes;
using QWhale.Editor;

namespace LanguageParser
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private QWhale.Syntax.Schemes.LanguageParser languageParser1;
		private System.Windows.Forms.Panel panel1;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListBox lbLanguages;
		private System.Windows.Forms.Label laLanguages;
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
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.languageParser1 = new QWhale.Syntax.Schemes.LanguageParser();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbLanguages = new System.Windows.Forms.ListBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.laLanguages = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.pnSettings.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 24);
			this.pnSettings.TabIndex = 1;
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
			this.laDescription.Text = "This demo shows how to use predefined syntax highlighting schemes for various lan" +
				"guages.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// languageParser1
			// 
			this.languageParser1.DefaultState = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbLanguages);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(136, 294);
			this.panel1.TabIndex = 2;
			// 
			// lbLanguages
			// 
			this.lbLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbLanguages.Location = new System.Drawing.Point(0, 24);
			this.lbLanguages.Name = "lbLanguages";
			this.lbLanguages.Size = new System.Drawing.Size(136, 264);
			this.lbLanguages.TabIndex = 2;
			this.lbLanguages.SelectedIndexChanged += new System.EventHandler(this.lbLanguages_SelectedIndexChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.laLanguages);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(136, 24);
			this.panel2.TabIndex = 1;
			// 
			// laLanguages
			// 
			this.laLanguages.AutoSize = true;
			this.laLanguages.Location = new System.Drawing.Point(4, 4);
			this.laLanguages.Name = "laLanguages";
			this.laLanguages.Size = new System.Drawing.Size(60, 16);
			this.laLanguages.TabIndex = 0;
			this.laLanguages.Text = "Languages";
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.languageParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(136, 24);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(432, 294);
			this.syntaxEdit1.TabIndex = 3;
			this.syntaxEdit1.Text = "using System;\r\nusing System.Drawing;\r\nusing System.Collections;\r\nusing System.Com" +
				"ponentModel;\r\nusing System.Windows.Forms;\r\nusing System.Data;\r\nusing System.IO;\r" +
				"\nusing QWEditor;\r\n\r\nnamespace SyntaxEditor\r\n{\r\n\t/// <summary>\r\n\t/// Summary desc" +
				"ription for Form1.\r\n\t/// </summary>\r\n\tpublic class frmSyntaxEditor : System.Wind" +
				"ows.Forms.Form\r\n\t{\r\n\t\tprivate System.Windows.Forms.MainMenu mainMenu1;\r\n\t\tprivat" +
				"e System.Windows.Forms.MenuItem miFile;\r\n\t\tprivate System.Windows.Forms.MenuItem" +
				" miNew;\r\n\t\tprivate System.Windows.Forms.MenuItem miOpen;\r\n\t\tprivate System.Windo" +
				"ws.Forms.MenuItem miSave;\r\n\t\tprivate System.Windows.Forms.MenuItem miSaveAs;\r\n\t\t" +
				"private System.Windows.Forms.MenuItem miClose;\r\n\t\tprivate System.Windows.Forms.O" +
				"penFileDialog openFileDialog1;\r\n\t\tprivate System.Windows.Forms.MenuItem miWindow" +
				";\r\n\t\tprivate System.ComponentModel.IContainer components;\r\n\t\tFileInfo[] SchemeFi" +
				"les;\r\n\t\tFileInfo[] TextFiles;\r\n\t\t//private string[] mySchemes = {\"c.xml\",\"c#.xml" +
				"\",\"c++builder.xml\",\"delphi.xml\",\"html.xml\",\"java.xml\",\"java_script.xml\",\"ms_dosb" +
				"l.xml\",\"unix_shell.xml\",\"vis_basic.xml\",\"xml.xml\"};\r\n\r\n\t\tpublic frmSyntaxEditor(" +
				")\r\n\t\t{\r\n\t\t\t//\r\n\t\t\t// Required for Windows Form Designer support\r\n\t\t\t//\r\n\t\t\tIniti" +
				"alizeComponent();\r\n\r\n\t\t\t//\r\n\t\t\t// TODO: Add any constructor code after Initializ" +
				"eComponent call\r\n\t\t\t//\r\n\t\t}\r\n\r\n\t\t/// <summary>\r\n\t\t/// Clean up any resources bei" +
				"ng used.\r\n\t\t/// </summary>\r\n\t\tprotected override void Dispose( bool disposing )\r" +
				"\n\t\t{\r\n\t\t\tif( disposing )\r\n\t\t\t{\r\n\t\t\t\tif (components != null) \r\n\t\t\t\t{\r\n\t\t\t\t\tcompon" +
				"ents.Dispose();\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\tbase.Dispose( disposing );\r\n\t\t}\r\n\r\n\t\t#region Wi" +
				"ndows Form Designer generated code\r\n\t\t/// <summary>\r\n\t\t/// Required method for D" +
				"esigner support - do not modify\r\n\t\t/// the contents of this method with the code" +
				" editor.\r\n\t\t/// </summary>\r\n\t\tprivate void InitializeComponent()\r\n\t\t{\r\n\t\t\tthis.m" +
				"ainMenu1 = new System.Windows.Forms.MainMenu();\r\n\t\t\tthis.miFile = new System.Win" +
				"dows.Forms.MenuItem();\r\n\t\t\tthis.miNew = new System.Windows.Forms.MenuItem();\r\n\t\t" +
				"\tthis.miOpen = new System.Windows.Forms.MenuItem();\r\n\t\t\tthis.miSave = new System" +
				".Windows.Forms.MenuItem();\r\n\t\t\tthis.miSaveAs = new System.Windows.Forms.MenuItem" +
				"();\r\n\t\t\tthis.miClose = new System.Windows.Forms.MenuItem();\r\n\t\t\tthis.openFileDia" +
				"log1 = new System.Windows.Forms.OpenFileDialog();\r\n\t\t\tthis.miWindow = new System" +
				".Windows.Forms.MenuItem();\r\n\t\t\t// \r\n\t\t\t// mainMenu1\r\n\t\t\t// \r\n\t\t\tthis.mainMenu1.M" +
				"enuItems.AddRange(new System.Windows.Forms.MenuItem[] {\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  " +
				"this.miFile,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  this.miWindow});\r\n\t\t\t// \r\n\t\t\t// miFile\r\n\t\t\t" +
				"// \r\n\t\t\tthis.miFile.Index = 0;\r\n\t\t\tthis.miFile.MenuItems.AddRange(new System.Win" +
				"dows.Forms.MenuItem[] {\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   this.miNew,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t" +
				"\t   this.miOpen,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   this.miSave,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   th" +
				"is.miSaveAs,\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   this.miClose});\r\n\t\t\tthis.miFile.Text = \"Fil" +
				"e\";\r\n\t\t\t// \r\n\t\t\t// miNew\r\n\t\t\t// \r\n\t\t\tthis.miNew.Index = 0;\r\n\t\t\tthis.miNew.Text =" +
				" \"New\";\r\n\t\t\t// \r\n\t\t\t// miOpen\r\n\t\t\t// \r\n\t\t\tthis.miOpen.Index = 1;\r\n\t\t\tthis.miOpen" +
				".Text = \"Open\";\r\n\t\t\tthis.miOpen.Click += new System.EventHandler(this.miOpen_Cli" +
				"ck);\r\n\t\t\t// \r\n\t\t\t// miSave\r\n\t\t\t// \r\n\t\t\tthis.miSave.Index = 2;\r\n\t\t\tthis.miSave.Te" +
				"xt = \"Save\";\r\n\t\t\tthis.miSave.Click += new System.EventHandler(this.miSave_Click)" +
				";\r\n\t\t\t// \r\n\t\t\t// miSaveAs\r\n\t\t\t// \r\n\t\t\tthis.miSaveAs.Index = 3;\r\n\t\t\tthis.miSaveAs" +
				".Text = \"Save As\";\r\n\t\t\tthis.miSaveAs.Click += new System.EventHandler(this.miSav" +
				"eAs_Click);\r\n\t\t\t// \r\n\t\t\t// miClose\r\n\t\t\t// \r\n\t\t\tthis.miClose.Index = 4;\r\n\t\t\tthis." +
				"miClose.Text = \"Close\";\r\n\t\t\tthis.miClose.Click += new System.EventHandler(this.m" +
				"iClose_Click);\r\n\t\t\t// \r\n\t\t\t// miWindow\r\n\t\t\t// \r\n\t\t\tthis.miWindow.Index = 1;\r\n\t\t\t" +
				"this.miWindow.MdiList = true;\r\n\t\t\tthis.miWindow.Text = \"&Window\";\r\n\t\t\t// \r\n\t\t\t//" +
				" frmSyntaxEditor\r\n\t\t\t// \r\n\t\t\tthis.AutoScaleBaseSize = new System.Drawing.Size(5," +
				" 13);\r\n\t\t\tthis.ClientSize = new System.Drawing.Size(544, 329);\r\n\t\t\tthis.IsMdiCon" +
				"tainer = true;\r\n\t\t\tthis.Menu = this.mainMenu1;\r\n\t\t\tthis.Name = \"frmSyntaxEditor\"" +
				";\r\n\t\t\tthis.Text = \"Syntax Editor\";\r\n\t\t\tthis.Load += new System.EventHandler(this" +
				".frmSyntaxEditor_Load);\r\n\r\n\t\t}\r\n\t\t#endregion\r\n\r\n\t\t/// <summary>\r\n\t\t/// The main " +
				"entry point for the application.\r\n\t\t/// </summary>\r\n\t\t[STAThread]\r\n\t\tstatic void" +
				" Main() \r\n\t\t{\r\n\t\t\tApplication.Run(new frmSyntaxEditor());\r\n\t\t}\r\n\r\n\t\tprivate void" +
				" frmSyntaxEditor_Load(object sender, System.EventArgs e)\r\n\t\t{\r\n\t\t\tDirectoryInfo " +
				"mySchemeInfo = new DirectoryInfo(@\"..\\..\\Schemes\");\r\n\t\t\tDirectoryInfo myTextInfo" +
				" = new DirectoryInfo(@\"..\\..\\Text\");\r\n\t\t\tSchemeFiles = mySchemeInfo.GetFiles();\r" +
				"\n\t\t\tTextFiles = myTextInfo.GetFiles();\r\n\t\t\tfor(int i = 0; i < SchemeFiles.Length" +
				"; i++)\r\n\t\t\t\tmiNew.MenuItems.Add(GetMenuText(i),new EventHandler(NewClick));// ne" +
				"w MenuItem(SchemeFiles[i].ToString()\r\n\t\t}\r\n\r\n\t\tprivate void NewClick(object send" +
				"er, System.EventArgs e)\r\n\t\t{\r\n\t\t\tEditContainer newMDIChild = new EditContainer()" +
				";\r\n\t\t\tnewMDIChild.MdiParent = this;\r\n\t\t\tLexer myLexer = new Lexer();\r\n\t\t\tmyLexer" +
				".Scheme.LoadScheme(GetSchemeName((sender as MenuItem).Index));\r\n\t\t\tnewMDIChild.S" +
				"yntaxEdit.Document.Lexer = myLexer;\r\n\t\t\tnewMDIChild.SyntaxEdit.Document.LoadFile" +
				"(GetDefaultFile((sender as MenuItem).Index));\r\n\t\t\tnewMDIChild.Show();\r\n\t\t}\r\n\t\tpr" +
				"ivate string GetSchemeName(int Index)\r\n\t\t{\r\n\t\t\treturn @\"..\\..\\Schemes\\\" + Scheme" +
				"Files[Index];\r\n\t\t}\r\n\t\tprivate string GetDefaultFile(int Index)\r\n\t\t{\r\n\t\t\treturn @" +
				"\"..\\..\\Text\\\" + TextFiles[Index];\r\n\t\t}\r\n\t\tprivate string GetMenuText(int Index)\r" +
				"\n\t\t{\r\n\t\t\tswitch(Index)\r\n\t\t\t{\r\n\t\t\t\tcase 0:\r\n\t\t\t\t\treturn \"C# Language\";\r\n\t\t\t\tcase " +
				"1:\r\n\t\t\t\t\treturn \"C++ Builder Language\";\r\n\t\t\t\tcase 2:\r\n\t\t\t\t\treturn \"C Language\";\r" +
				"\n\t\t\t\tcase 3:\r\n\t\t\t\t\treturn \"Delphi Language\";\r\n\t\t\t\tcase 4:\r\n\t\t\t\t\treturn \"HTML Lan" +
				"guage\";\r\n\t\t\t\tcase 5:\r\n\t\t\t\t\treturn \"Java Language\";\r\n\t\t\t\tcase 6:\r\n\t\t\t\t\treturn \"Ja" +
				"va Script Language\";\r\n\t\t\t\tcase 7:\r\n\t\t\t\t\treturn \"MS Dos Batch Language\";\r\n\t\t\t\tcas" +
				"e 8:\r\n\t\t\t\t\treturn \"Unix Shell Language\";\r\n\t\t\t\tcase 9:\r\n\t\t\t\t\treturn \"Visual Basic" +
				" Language\";\r\n\t\t\t\tcase 10:\r\n\t\t\t\t\treturn \"XML Language\";\r\n\t\t\t\tdefault:\r\n\t\t\t\t\tretur" +
				"n \"\";\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\tprivate void miOpen_Click(object sender, System.EventArgs " +
				"e)\r\n\t\t{\r\n\t\t\tif (openFileDialog1.ShowDialog() == DialogResult.OK)\r\n\t\t\t{\r\n\t\t\t\tQWEd" +
				"itor.DocumentWindow myEdit  = GetActiveSyntaxEdit();\r\n\t\t\t\tmyEdit.Document.LoadFi" +
				"le(openFileDialog1.FileName);\r\n\t\t\t\tmyEdit.Refresh();\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\tprivate QWE" +
				"ditor.DocumentWindow GetActiveSyntaxEdit()\r\n\t\t{\r\n\t\t\treturn (this.ActiveMdiChild " +
				"as EditContainer).SyntaxEdit;\r\n\t\t}\r\n\t\tprivate void miSave_Click(object sender, S" +
				"ystem.EventArgs e)\r\n\t\t{\r\n\t\t}\r\n\r\n\t\tprivate void miSaveAs_Click(object sender, Sys" +
				"tem.EventArgs e)\r\n\t\t{\t\r\n\t\t}\r\n\r\n\t\tprivate void miClose_Click(object sender, Syste" +
				"m.EventArgs e)\r\n\t\t{\r\n\t\t}\r\n\r\n\t}\r\n}";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 318);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.pnDescription.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private string Dir = Application.StartupPath + @"\..\..\..\";

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private struct LanguageInfo
		{
			public string FileType;
			public string FileExt;
			public string Description;
			public LanguageInfo(string AFileType, string AFileExt, string ADescription)
			{
				FileType = AFileType;
				FileExt = AFileExt;
				Description = ADescription;
			}
		}
		private LanguageInfo[] LangItems =
		{
			new LanguageInfo("c#", "*.cs", "C# Language"),
			new LanguageInfo("assembler", "*.assembler", "Assembler Language"),
			new LanguageInfo("dfm", "*.dfm", "DFM File Language"),
			new LanguageInfo("cbuilder", "*.cbuilder", "C++ Builder Language"),
			new LanguageInfo("c", "*.c", "C Language"),
			new LanguageInfo("delphi", "*.delphi", "Delphi Language"),
			new LanguageInfo("html", "*.html", "HTML Language"),
			new LanguageInfo("htmlscripts", "*.htmlscripts", "ASP, VB, PHP, Java Scripts in HTML Language"),
			new LanguageInfo("js", "*.js", "Java Language"),
			new LanguageInfo("jscript", "*.jscript", "Java Script Language"),
			new LanguageInfo("perl", "*.perl", "Perl Language"),
			new LanguageInfo("php", "*.php", "PHP Language"),
			new LanguageInfo("python", "*.python", "Python Language"),
			new LanguageInfo("sql", "*.sql", "SQL Language"),
			new LanguageInfo("tcltk", "*.tcltk", "TclTk Language"),
			new LanguageInfo("unixshell", "*.unixshell", "Unix Shell Language"),
			new LanguageInfo("vbscript", "*.vbscript", "VB Script Language"),
			new LanguageInfo("vbs_script_html", "*.htm;*.html", "VB Script in HTML Language"),
			new LanguageInfo("vbnet", "*.vbnet", "Visual Basic NET Language"),
			new LanguageInfo("xml", "*.xml", "XML Language"),
			new LanguageInfo("xmlscripts", "*.xmlscripts", "PHP, VB, Java Scripts in XML Language"),
			new LanguageInfo("text", "*.txt", "Text files"),
			new LanguageInfo("batch", "*.batch", "Ms-Dos Batch Language"),
			new LanguageInfo("il", "*.il", "MSIL Language"),
			new LanguageInfo("ini", "*.ini", "Ini files"),
			new LanguageInfo("all", "*.*", "All files")
		};
		private void Form1_Load(object sender, System.EventArgs e)
		{
			string[] s = Enum.GetNames(typeof(Languages));
			lbLanguages.Items.AddRange(s);
			lbLanguages.Items.RemoveAt(lbLanguages.Items.Count - 1);
			languageParser1.Language = Languages.Cs;
			lbLanguages.SelectedIndex = (int)languageParser1.Language;
		}

		private void lbLanguages_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateLanguage(lbLanguages.SelectedIndex);
		}
		private void UpdateLanguage(int index)
		{
			languageParser1.Language = (Languages)index;
			string s = string.Empty;
			if (GetFileByLanguage(languageParser1.Language, out s))
				syntaxEdit1.LoadFile(s);
			else
				syntaxEdit1.Lines.Clear();
		}
		private int FindLangByExt(string ext)
		{
			for(int i = 0; i < LangItems.Length; i++)
				if (LangItems[i].FileExt.Substring(1).ToLower() == ext.ToLower())
					return i;
			return - 1;
		}
		private bool GetFileByLanguage(Languages language, out string fileName)
		{
			fileName = string.Empty;
			DirectoryInfo info = new DirectoryInfo(Dir + "text");
			if (info.Exists)
			{
				if (language == Languages.Custom)
					fileName = Dir + @"text\c#.txt";
				int idx = FindLangByExt('.' + language.ToString());
				if (idx >= 0)
					fileName = info.FullName + @"\" + LangItems[idx].FileType + ".txt";
			}
			return (fileName != string.Empty) && new FileInfo(fileName).Exists;
		}
	}
}
