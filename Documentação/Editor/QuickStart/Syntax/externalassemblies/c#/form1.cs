using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Syntax.Parsers;
using QWhale.Editor;

namespace ExternalAssemblies
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.ListBox lbAssemblies;
		private System.Windows.Forms.ContextMenu cmAssemblies;
		private System.Windows.Forms.MenuItem miAddAssembly;
		private System.Windows.Forms.MenuItem miRemoveAssembly;
		private System.Windows.Forms.Splitter splitter1;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.pnSettings = new System.Windows.Forms.Panel();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.lbAssemblies = new System.Windows.Forms.ListBox();
			this.cmAssemblies = new System.Windows.Forms.ContextMenu();
			this.miAddAssembly = new System.Windows.Forms.MenuItem();
			this.miRemoveAssembly = new System.Windows.Forms.MenuItem();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.pnSettings.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 40);
			this.pnSettings.TabIndex = 5;
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
			this.laDescription.Text = "This demo shows how to use external assemblies in code completion.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Assembly files(*.dll)|*.dll|All files (*.*)|*.*";
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
				"   </Style>\r\n    <Style>\r\n      <Name>codesnippets</Name>\r\n      <ForeColor>Blac" +
				"k</ForeColor>\r\n      <BackColor>255:180:228:180</BackColor>\r\n      <Index>10</In" +
				"dex>\r\n    </Style>\r\n  </Styles>\r\n  <States />\r\n</LexScheme>";
			// 
			// lbAssemblies
			// 
			this.lbAssemblies.ContextMenu = this.cmAssemblies;
			this.lbAssemblies.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbAssemblies.Location = new System.Drawing.Point(0, 40);
			this.lbAssemblies.Name = "lbAssemblies";
			this.lbAssemblies.Size = new System.Drawing.Size(120, 277);
			this.lbAssemblies.TabIndex = 6;
			// 
			// cmAssemblies
			// 
			this.cmAssemblies.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.miAddAssembly,
																						 this.miRemoveAssembly});
			this.cmAssemblies.Popup += new System.EventHandler(this.cmAssemblies_Popup);
			// 
			// miAddAssembly
			// 
			this.miAddAssembly.Index = 0;
			this.miAddAssembly.Text = "Add Assembly";
			this.miAddAssembly.Click += new System.EventHandler(this.miAddAssembly_Click);
			// 
			// miRemoveAssembly
			// 
			this.miRemoveAssembly.Index = 1;
			this.miRemoveAssembly.Text = "Remove Assembly";
			this.miRemoveAssembly.Click += new System.EventHandler(this.miRemoveAssembly_Click);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(120, 40);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 279);
			this.splitter1.TabIndex = 7;
			this.splitter1.TabStop = false;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(124, 40);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(444, 279);
			this.syntaxEdit1.TabIndex = 10;
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
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 319);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.lbAssemblies);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
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

		private Hashtable assemblies = new Hashtable();
		private Hashtable namespaces = new Hashtable();

		private void OpenFile()
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
				AddAssembly(openFileDialog1.FileName);
		}
		private ArrayList GetNamespaces(Assembly asm)
		{
			ArrayList result = new ArrayList();
			Type[] types = asm.GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				if (!result.Contains(types[i].Namespace) && (types[i].Namespace != string.Empty) && (types[i].Namespace != null))
					result.Add(types[i].Namespace);
			}
			return result;
		}
		private void AddAssemblies()
		{
			lbAssemblies.Items.Clear();
			foreach (Assembly asm in ((IReflectionRepository)csParser1.CompletionRepository).Assemblies)
				AddAssembly(asm, false);
		}

		private void AddAssembly(string asmName)
		{
			Assembly asm = Assembly.LoadFrom(asmName);
			AddAssembly(asm, true);
		}
		private void AddAssembly(Assembly asm, bool addToParser)
		{
			if (asm != null)
			{
				string asmName = asm.GetName().Name;
				if (!assemblies.Contains(asmName))
				{
					assemblies.Add(asmName, asm);
					if (addToParser)
						csParser1.RegisterAssembly(asm);
					ArrayList nSpaces = GetNamespaces(asm);
					foreach (string nSpace in namespaces)
					{
						ArrayList asmNames = null;
						if (namespaces.Contains(nSpace))
						{
							asmNames = (ArrayList)namespaces[nSpace];
							asmNames.Add(asmName);
						}
						else
						{
							asmNames = new ArrayList();
							asmNames.Add(asm.FullName);
							namespaces.Add(nSpace, asmNames);
						}
						if (addToParser)
							csParser1.RegisterNamespace(nSpace);
						}
					lbAssemblies.Items.Add(asmName);
					lbAssemblies.SelectedIndex = lbAssemblies.Items.Count - 1;
				}
			}
		}
		private void RemoveAssembly(string asmName)
		{
			Assembly asm = (Assembly)assemblies[asmName];
			if (asm != null)
			{
				assemblies.Remove(asmName);
				csParser1.UnregisterAssembly(asm, true);
				ArrayList nSpaces = GetNamespaces(asm);
				foreach (string nSpace in namespaces)
				{
					ArrayList asmNames = (ArrayList)namespaces[nSpace];
					if (asmNames != null)
						asmNames.Remove(asmName);
					if (asmNames.Count == 0)
						csParser1.UnregisterNamespace(nSpace);
				}
				lbAssemblies.Items.Remove(asmName);
			}
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			AddAssemblies();
		}


		private void miAddAssembly_Click(object sender, System.EventArgs e)
		{
			OpenFile();
		}

		private void miRemoveAssembly_Click(object sender, System.EventArgs e)
		{
			string asmName = (lbAssemblies.SelectedItem != null) ? (string)lbAssemblies.SelectedItem : string.Empty;
			if (asmName != string.Empty)
				RemoveAssembly(asmName);
		}

		private void cmAssemblies_Popup(object sender, System.EventArgs e)
		{
			miRemoveAssembly.Enabled = (lbAssemblies.SelectedItem != null);
		}
	}
}
