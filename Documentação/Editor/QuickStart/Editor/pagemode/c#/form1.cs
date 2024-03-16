using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace PageMode
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
		private System.Windows.Forms.GroupBox gbRulers;
		private System.Windows.Forms.CheckBox chbVertRuler;
		private System.Windows.Forms.CheckBox chbHorzRuler;
		private System.Windows.Forms.ComboBox cbRulerUnits;
		private System.Windows.Forms.Label laRulerUnits;
		private System.Windows.Forms.CheckBox chbRulerDisplayDragLines;
		private System.Windows.Forms.CheckBox chbRulerDiscrete;
		private System.Windows.Forms.CheckBox chbRulerAllowDrag;
		private System.Windows.Forms.GroupBox gbPages;
		private System.Windows.Forms.ComboBox cbPageSize;
		private System.Windows.Forms.Label laPageSize;
		private System.Windows.Forms.ComboBox cbPageLayout;
		private System.Windows.Forms.Label laPageLayout;
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
			this.gbRulers = new System.Windows.Forms.GroupBox();
			this.chbVertRuler = new System.Windows.Forms.CheckBox();
			this.chbHorzRuler = new System.Windows.Forms.CheckBox();
			this.cbRulerUnits = new System.Windows.Forms.ComboBox();
			this.laRulerUnits = new System.Windows.Forms.Label();
			this.chbRulerDisplayDragLines = new System.Windows.Forms.CheckBox();
			this.chbRulerDiscrete = new System.Windows.Forms.CheckBox();
			this.chbRulerAllowDrag = new System.Windows.Forms.CheckBox();
			this.gbPages = new System.Windows.Forms.GroupBox();
			this.cbPageSize = new System.Windows.Forms.ComboBox();
			this.laPageSize = new System.Windows.Forms.Label();
			this.cbPageLayout = new System.Windows.Forms.ComboBox();
			this.laPageLayout = new System.Windows.Forms.Label();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.pnSettings.SuspendLayout();
			this.gbRulers.SuspendLayout();
			this.gbPages.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.gbRulers);
			this.pnSettings.Controls.Add(this.gbPages);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 136);
			this.pnSettings.TabIndex = 1;
			// 
			// gbRulers
			// 
			this.gbRulers.Controls.Add(this.chbVertRuler);
			this.gbRulers.Controls.Add(this.chbHorzRuler);
			this.gbRulers.Controls.Add(this.cbRulerUnits);
			this.gbRulers.Controls.Add(this.laRulerUnits);
			this.gbRulers.Controls.Add(this.chbRulerDisplayDragLines);
			this.gbRulers.Controls.Add(this.chbRulerDiscrete);
			this.gbRulers.Controls.Add(this.chbRulerAllowDrag);
			this.gbRulers.Location = new System.Drawing.Point(208, 32);
			this.gbRulers.Name = "gbRulers";
			this.gbRulers.Size = new System.Drawing.Size(352, 96);
			this.gbRulers.TabIndex = 16;
			this.gbRulers.TabStop = false;
			this.gbRulers.Text = "Rulers";
			// 
			// chbVertRuler
			// 
			this.chbVertRuler.Location = new System.Drawing.Point(16, 40);
			this.chbVertRuler.Name = "chbVertRuler";
			this.chbVertRuler.Size = new System.Drawing.Size(104, 16);
			this.chbVertRuler.TabIndex = 2;
			this.chbVertRuler.Text = "Vert Ruler";
			this.chbVertRuler.CheckedChanged += new System.EventHandler(this.chbVertRuler_CheckedChanged);
			// 
			// chbHorzRuler
			// 
			this.chbHorzRuler.Location = new System.Drawing.Point(16, 16);
			this.chbHorzRuler.Name = "chbHorzRuler";
			this.chbHorzRuler.Size = new System.Drawing.Size(104, 16);
			this.chbHorzRuler.TabIndex = 1;
			this.chbHorzRuler.Text = "Horz Ruler";
			this.chbHorzRuler.CheckedChanged += new System.EventHandler(this.chbHorzRuler_CheckedChanged);
			// 
			// cbRulerUnits
			// 
			this.cbRulerUnits.Location = new System.Drawing.Point(72, 64);
			this.cbRulerUnits.Name = "cbRulerUnits";
			this.cbRulerUnits.Size = new System.Drawing.Size(96, 21);
			this.cbRulerUnits.TabIndex = 4;
			this.cbRulerUnits.SelectedIndexChanged += new System.EventHandler(this.cbRulerUnits_SelectedIndexChanged);
			// 
			// laRulerUnits
			// 
			this.laRulerUnits.AutoSize = true;
			this.laRulerUnits.Location = new System.Drawing.Point(12, 67);
			this.laRulerUnits.Name = "laRulerUnits";
			this.laRulerUnits.Size = new System.Drawing.Size(60, 16);
			this.laRulerUnits.TabIndex = 3;
			this.laRulerUnits.Text = "Ruler Units";
			// 
			// chbRulerDisplayDragLines
			// 
			this.chbRulerDisplayDragLines.Location = new System.Drawing.Point(176, 64);
			this.chbRulerDisplayDragLines.Name = "chbRulerDisplayDragLines";
			this.chbRulerDisplayDragLines.Size = new System.Drawing.Size(118, 16);
			this.chbRulerDisplayDragLines.TabIndex = 7;
			this.chbRulerDisplayDragLines.Text = "Display Drag Lines";
			this.chbRulerDisplayDragLines.CheckedChanged += new System.EventHandler(this.chbRulerDisplayDragLines_CheckedChanged);
			// 
			// chbRulerDiscrete
			// 
			this.chbRulerDiscrete.Location = new System.Drawing.Point(176, 40);
			this.chbRulerDiscrete.Name = "chbRulerDiscrete";
			this.chbRulerDiscrete.Size = new System.Drawing.Size(104, 16);
			this.chbRulerDiscrete.TabIndex = 6;
			this.chbRulerDiscrete.Text = "Discrete";
			this.chbRulerDiscrete.CheckedChanged += new System.EventHandler(this.chbRulerDiscrete_CheckedChanged);
			// 
			// chbRulerAllowDrag
			// 
			this.chbRulerAllowDrag.Location = new System.Drawing.Point(176, 16);
			this.chbRulerAllowDrag.Name = "chbRulerAllowDrag";
			this.chbRulerAllowDrag.Size = new System.Drawing.Size(104, 16);
			this.chbRulerAllowDrag.TabIndex = 5;
			this.chbRulerAllowDrag.Text = "Allow Drag";
			this.chbRulerAllowDrag.CheckedChanged += new System.EventHandler(this.chbRulerAllowDrag_CheckedChanged);
			// 
			// gbPages
			// 
			this.gbPages.Controls.Add(this.cbPageSize);
			this.gbPages.Controls.Add(this.laPageSize);
			this.gbPages.Controls.Add(this.cbPageLayout);
			this.gbPages.Controls.Add(this.laPageLayout);
			this.gbPages.Location = new System.Drawing.Point(8, 32);
			this.gbPages.Name = "gbPages";
			this.gbPages.Size = new System.Drawing.Size(184, 96);
			this.gbPages.TabIndex = 15;
			this.gbPages.TabStop = false;
			this.gbPages.Text = "Pages";
			// 
			// cbPageSize
			// 
			this.cbPageSize.Location = new System.Drawing.Point(80, 48);
			this.cbPageSize.Name = "cbPageSize";
			this.cbPageSize.Size = new System.Drawing.Size(96, 21);
			this.cbPageSize.TabIndex = 4;
			this.cbPageSize.SelectedIndexChanged += new System.EventHandler(this.cbPageSize_SelectedIndexChanged);
			// 
			// laPageSize
			// 
			this.laPageSize.AutoSize = true;
			this.laPageSize.Location = new System.Drawing.Point(8, 51);
			this.laPageSize.Name = "laPageSize";
			this.laPageSize.Size = new System.Drawing.Size(56, 16);
			this.laPageSize.TabIndex = 3;
			this.laPageSize.Text = "Page Size";
			// 
			// cbPageLayout
			// 
			this.cbPageLayout.Location = new System.Drawing.Point(80, 24);
			this.cbPageLayout.Name = "cbPageLayout";
			this.cbPageLayout.Size = new System.Drawing.Size(96, 21);
			this.cbPageLayout.TabIndex = 2;
			this.cbPageLayout.SelectedIndexChanged += new System.EventHandler(this.cbPageLayout_SelectedIndexChanged);
			// 
			// laPageLayout
			// 
			this.laPageLayout.AutoSize = true;
			this.laPageLayout.Location = new System.Drawing.Point(8, 27);
			this.laPageLayout.Name = "laPageLayout";
			this.laPageLayout.Size = new System.Drawing.Size(68, 16);
			this.laPageLayout.TabIndex = 1;
			this.laPageLayout.Text = "Page Layout";
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
			this.laDescription.Text = "This demo shows how to use different page layout modes of the edit control text.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Gutter.Visible = false;
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 136);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Pages.PageType = QWhale.Editor.PageType.PageLayout;
			this.syntaxEdit1.Pages.Rulers = ((QWhale.Editor.EditRulers)((QWhale.Editor.EditRulers.Horizonal | QWhale.Editor.EditRulers.Vertical)));
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 246);
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
			this.ClientSize = new System.Drawing.Size(568, 382);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.gbRulers.ResumeLayout(false);
			this.gbPages.ResumeLayout(false);
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
			string [] s = Enum.GetNames(typeof(PageType));
			cbPageLayout.Items.AddRange(s);
			cbPageLayout.SelectedIndex = (int)syntaxEdit1.Pages.PageType;
			foreach(PaperSize psize in syntaxEdit1.Printing.PrinterSettings.PaperSizes)
			{
				if (!cbPageSize.Items.Contains(psize.Kind))
					cbPageSize.Items.Add(psize.Kind);
			}
			if (cbPageSize.Items.Count > 0)
			{
				cbPageSize.SelectedIndex = Math.Max(cbPageSize.Items.IndexOf(syntaxEdit1.Pages.DefaultPage.PageKind), 0);
				cbPageSize.Enabled = true;
			}
			else
				cbPageSize.Enabled = false;

			s = Enum.GetNames(typeof(RulerUnits));
			cbRulerUnits.Items.AddRange(s);
			cbRulerUnits.SelectedIndex = (int)syntaxEdit1.Pages.RulerUnits;
			chbRulerAllowDrag.Checked = (RulerOptions.AllowDrag & syntaxEdit1.Pages.RulerOptions) != 0;
			chbRulerDiscrete.Checked = (RulerOptions.Discrete & syntaxEdit1.Pages.RulerOptions) != 0;
			chbRulerDisplayDragLines.Checked = (RulerOptions.DisplayDragLine & syntaxEdit1.Pages.RulerOptions) != 0;
			chbHorzRuler.Checked = (EditRulers.Horizonal & syntaxEdit1.Pages.Rulers) != 0;
			chbVertRuler.Checked = (EditRulers.Vertical & syntaxEdit1.Pages.Rulers) != 0;
		}

		private void cbPageLayout_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Pages.PageType = (PageType)cbPageLayout.SelectedIndex;
		}

		private void cbPageSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			object obj = Enum.Parse(typeof(PaperKind), cbPageSize.Text);
			if (obj is PaperKind)
				for (int i = syntaxEdit1.Pages.Count - 1; i >= 0; i--)
					syntaxEdit1.Pages[i].PageKind = (PaperKind)obj;
		}
		private void cbRulerUnits_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Pages.RulerUnits = (RulerUnits)cbRulerUnits.SelectedIndex;
		}

		private void chbHorzRuler_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Pages.Rulers = (chbHorzRuler.Checked ? syntaxEdit1.Pages.Rulers
				| EditRulers.Horizonal: syntaxEdit1.Pages.Rulers ^ EditRulers.Horizonal);
		}

		private void chbVertRuler_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Pages.Rulers = (chbVertRuler.Checked ? syntaxEdit1.Pages.Rulers
				| EditRulers.Vertical: syntaxEdit1.Pages.Rulers ^ EditRulers.Vertical);
		}

		private void chbRulerAllowDrag_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Pages.RulerOptions = (chbRulerAllowDrag.Checked ? syntaxEdit1.Pages.RulerOptions
				| RulerOptions.AllowDrag: syntaxEdit1.Pages.RulerOptions ^ RulerOptions.AllowDrag);
		}

		private void chbRulerDiscrete_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Pages.RulerOptions = (chbRulerDiscrete.Checked ? syntaxEdit1.Pages.RulerOptions
				| RulerOptions.Discrete: syntaxEdit1.Pages.RulerOptions ^ RulerOptions.Discrete);
		}

		private void chbRulerDisplayDragLines_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Pages.RulerOptions = (chbRulerDisplayDragLines.Checked ? syntaxEdit1.Pages.RulerOptions
				| RulerOptions.DisplayDragLine: syntaxEdit1.Pages.RulerOptions ^ RulerOptions.DisplayDragLine);
		}
	}
}
