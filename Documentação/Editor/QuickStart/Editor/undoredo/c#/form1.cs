using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace UndoRedo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label laUndoRedo;
		private System.Windows.Forms.Button btReverse;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.ListBox lbUndoOperations;
		private QWhale.Syntax.Parsers.CsParser csParser1;
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
			this.btReverse = new System.Windows.Forms.Button();
			this.laUndoRedo = new System.Windows.Forms.Label();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbUndoOperations = new System.Windows.Forms.ListBox();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.pnSettings.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.btReverse);
			this.pnSettings.Controls.Add(this.laUndoRedo);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 72);
			this.pnSettings.TabIndex = 1;
			// 
			// btReverse
			// 
			this.btReverse.Enabled = false;
			this.btReverse.Location = new System.Drawing.Point(8, 40);
			this.btReverse.Name = "btReverse";
			this.btReverse.Size = new System.Drawing.Size(96, 23);
			this.btReverse.TabIndex = 17;
			this.btReverse.Text = "Reverse undo";
			this.btReverse.Click += new System.EventHandler(this.btReverse_Click);
			// 
			// laUndoRedo
			// 
			this.laUndoRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.laUndoRedo.AutoSize = true;
			this.laUndoRedo.Location = new System.Drawing.Point(368, 48);
			this.laUndoRedo.Name = "laUndoRedo";
			this.laUndoRedo.Size = new System.Drawing.Size(61, 16);
			this.laUndoRedo.TabIndex = 16;
			this.laUndoRedo.Text = "Undo\\Redo";
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
			this.laDescription.Text = "This demo show how to use undo\\redo history.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbUndoOperations);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(360, 72);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(208, 246);
			this.panel1.TabIndex = 16;
			// 
			// lbUndoOperations
			// 
			this.lbUndoOperations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbUndoOperations.Location = new System.Drawing.Point(0, 0);
			this.lbUndoOperations.Name = "lbUndoOperations";
			this.lbUndoOperations.Size = new System.Drawing.Size(208, 238);
			this.lbUndoOperations.TabIndex = 0;
			this.lbUndoOperations.SelectedIndexChanged += new System.EventHandler(this.lbUndoOperations_SelectedIndexChanged);
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 72);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(360, 246);
			this.syntaxEdit1.TabIndex = 17;
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
			this.syntaxEdit1.SourceStateChanged += new QWhale.Editor.NotifyEvent(this.syntaxEdit1_SourceStateChanged);
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
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 318);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.pnSettings.ResumeLayout(false);
			this.pnDescription.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
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

		private int undoListCount;
		
		private void UpdateUndoList()
		{
			undoListCount = syntaxEdit1.Source.UndoList.Count;
			string s = string.Empty;
			lbUndoOperations.BeginUpdate();
			try
			{
				lbUndoOperations.Items.Clear();
				foreach (UndoData uData in syntaxEdit1.Source.UndoList)
				{
					s = s + ((s == string.Empty) ? string.Format("{0}", uData.Operation) : string.Format(",{0}", uData.Operation));
				}
			}
			finally
			{
				lbUndoOperations.Items.AddRange(s.Split(','));
				lbUndoOperations.EndUpdate();
			}
		}
		private UndoData GetUndoData()
		{
			if ((lbUndoOperations.SelectedIndex == -1) || (lbUndoOperations.SelectedIndex > syntaxEdit1.Source.UndoList.Count))
				return null;
			return (UndoData)syntaxEdit1.Source.UndoList[lbUndoOperations.SelectedIndex];
		}
		private void OperateUndo()
		{
			syntaxEdit1.Source.Undo(GetUndoData());
			UpdateUndoList();
		}
		private void syntaxEdit1_SourceStateChanged(object sender, QWhale.Editor.NotifyEventArgs e)
		{
			if (syntaxEdit1.Source.UndoList.Count != undoListCount)
				UpdateUndoList();
		}

		private void btReverse_Click(object sender, System.EventArgs e)
		{
			OperateUndo();
		}

		private void lbUndoOperations_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btReverse.Enabled = lbUndoOperations.SelectedIndex >= -1;
		}
	}
}
