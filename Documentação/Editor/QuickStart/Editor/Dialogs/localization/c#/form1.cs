using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Threading;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;
using QWhale.Editor.Dialogs;

namespace Localization
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.Button btGoto;
		private System.Windows.Forms.Button btCustomize;
		private System.Windows.Forms.ComboBox cbLanguages;
		private System.Windows.Forms.Label laLanguages;
		private System.Windows.Forms.Button btReplace;
		private System.Windows.Forms.Button btFind;
		private System.Windows.Forms.GroupBox groupBox1;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.Panel pnSettings;
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
			this.cbLanguages = new System.Windows.Forms.ComboBox();
			this.btCustomize = new System.Windows.Forms.Button();
			this.btGoto = new System.Windows.Forms.Button();
			this.btReplace = new System.Windows.Forms.Button();
			this.btFind = new System.Windows.Forms.Button();
			this.laLanguages = new System.Windows.Forms.Label();
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
			this.groupBox1.Controls.Add(this.cbLanguages);
			this.groupBox1.Controls.Add(this.btCustomize);
			this.groupBox1.Controls.Add(this.btGoto);
			this.groupBox1.Controls.Add(this.btReplace);
			this.groupBox1.Controls.Add(this.btFind);
			this.groupBox1.Controls.Add(this.laLanguages);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 80);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Localization";
			// 
			// cbLanguages
			// 
			this.cbLanguages.Items.AddRange(new object[] {
															 "Default",
															 "English",
															 "French",
															 "German",
															 "Spanish",
															 "Russian",
															 "Ukrainian"});
			this.cbLanguages.Location = new System.Drawing.Point(16, 40);
			this.cbLanguages.Name = "cbLanguages";
			this.cbLanguages.Size = new System.Drawing.Size(121, 21);
			this.cbLanguages.TabIndex = 1;
			this.cbLanguages.Text = "Default";
			this.cbLanguages.SelectedIndexChanged += new System.EventHandler(this.cbLanguages_SelectedIndexChanged);
			// 
			// btCustomize
			// 
			this.btCustomize.BackColor = System.Drawing.SystemColors.Control;
			this.btCustomize.Location = new System.Drawing.Point(240, 48);
			this.btCustomize.Name = "btCustomize";
			this.btCustomize.Size = new System.Drawing.Size(80, 23);
			this.btCustomize.TabIndex = 5;
			this.btCustomize.Text = "Customize";
			this.btCustomize.Click += new System.EventHandler(this.btCustomize_Click);
			// 
			// btGoto
			// 
			this.btGoto.BackColor = System.Drawing.SystemColors.Control;
			this.btGoto.Location = new System.Drawing.Point(240, 16);
			this.btGoto.Name = "btGoto";
			this.btGoto.Size = new System.Drawing.Size(80, 23);
			this.btGoto.TabIndex = 4;
			this.btGoto.Text = "Go to Line";
			this.btGoto.Click += new System.EventHandler(this.btGoto_Click);
			// 
			// btReplace
			// 
			this.btReplace.BackColor = System.Drawing.SystemColors.Control;
			this.btReplace.Location = new System.Drawing.Point(152, 48);
			this.btReplace.Name = "btReplace";
			this.btReplace.Size = new System.Drawing.Size(80, 23);
			this.btReplace.TabIndex = 3;
			this.btReplace.Text = "Replace";
			this.btReplace.Click += new System.EventHandler(this.btReplace_Click);
			// 
			// btFind
			// 
			this.btFind.BackColor = System.Drawing.SystemColors.Control;
			this.btFind.Location = new System.Drawing.Point(152, 16);
			this.btFind.Name = "btFind";
			this.btFind.Size = new System.Drawing.Size(80, 23);
			this.btFind.TabIndex = 2;
			this.btFind.Text = "Find";
			this.btFind.Click += new System.EventHandler(this.btFind_Click);
			// 
			// laLanguages
			// 
			this.laLanguages.AutoSize = true;
			this.laLanguages.Location = new System.Drawing.Point(16, 16);
			this.laLanguages.Name = "laLanguages";
			this.laLanguages.Size = new System.Drawing.Size(63, 16);
			this.laLanguages.TabIndex = 0;
			this.laLanguages.Text = "Languages:";
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
			this.laDescription.Text = "This demo is shows how to localize built-in dialogs to foreign languages.";
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

		private void btGoto_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.DisplayGotoLineDialog();
		}

		private void btCustomize_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.DisplayEditorSettingsDialog();
		}

		private void cbLanguages_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (cbLanguages.SelectedIndex)
			{
				case 0:
					StringConsts.Localize(Thread.CurrentThread.CurrentUICulture);
					break;
				case 1:
					StringConsts.Localize(new CultureInfo("en"));
					break;
				case 2:
					StringConsts.Localize(new CultureInfo("fr"));
					break;
				case 3:
					StringConsts.Localize(new CultureInfo("de"));
					break;
				case 4:
					StringConsts.Localize(new CultureInfo("es"));
					break;
				case 5:
					StringConsts.Localize(new CultureInfo("ru"));
					break;
				case 6:
					StringConsts.Localize(new CultureInfo("uk"));
					break;
			}
			syntaxEdit1.SyntaxSettings.Localize();
		}

		private void btFind_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.DisplaySearchDialog();
		}

		private void btReplace_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.DisplayReplaceDialog();
		}

	}
}
