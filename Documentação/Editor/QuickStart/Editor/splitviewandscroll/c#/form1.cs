using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace SplitviewAndScroll
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.CheckBox chbHorzButton;
		private System.Windows.Forms.CheckBox chbVertButton;
		private System.Windows.Forms.CheckBox chbAllowSplitHorz;
		private System.Windows.Forms.CheckBox chbAllowSplitVert;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.CheckBox chbShowScrollHint;
		private System.Windows.Forms.CheckBox chbSmoothScroll;
		private System.Windows.Forms.CheckBox chbSystemScrollBars;
		private System.Windows.Forms.CheckBox chbFlatScrollBars;
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
			QWhale.Editor.ScrollingButton scrollingButton1 = new QWhale.Editor.ScrollingButton();
			QWhale.Editor.ScrollingButton scrollingButton2 = new QWhale.Editor.ScrollingButton();
			QWhale.Editor.ScrollingButton scrollingButton3 = new QWhale.Editor.ScrollingButton();
			QWhale.Editor.ScrollingButton scrollingButton4 = new QWhale.Editor.ScrollingButton();
			QWhale.Editor.ScrollingButton scrollingButton5 = new QWhale.Editor.ScrollingButton();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.pnSettings = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chbVertButton = new System.Windows.Forms.CheckBox();
			this.chbHorzButton = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chbAllowSplitHorz = new System.Windows.Forms.CheckBox();
			this.chbAllowSplitVert = new System.Windows.Forms.CheckBox();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.chbShowScrollHint = new System.Windows.Forms.CheckBox();
			this.chbSmoothScroll = new System.Windows.Forms.CheckBox();
			this.chbSystemScrollBars = new System.Windows.Forms.CheckBox();
			this.chbFlatScrollBars = new System.Windows.Forms.CheckBox();
			this.pnSettings.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList2
			// 
			this.imageList2.ImageSize = new System.Drawing.Size(15, 15);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.groupBox2);
			this.pnSettings.Controls.Add(this.groupBox1);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 104);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chbFlatScrollBars);
			this.groupBox2.Controls.Add(this.chbSystemScrollBars);
			this.groupBox2.Controls.Add(this.chbSmoothScroll);
			this.groupBox2.Controls.Add(this.chbShowScrollHint);
			this.groupBox2.Controls.Add(this.chbVertButton);
			this.groupBox2.Controls.Add(this.chbHorzButton);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(200, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(368, 80);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Scrolling";
			// 
			// chbVertButton
			// 
			this.chbVertButton.Location = new System.Drawing.Point(8, 40);
			this.chbVertButton.Name = "chbVertButton";
			this.chbVertButton.TabIndex = 12;
			this.chbVertButton.Text = "Vert Button";
			this.chbVertButton.CheckedChanged += new System.EventHandler(this.chbVertButton_CheckedChanged);
			// 
			// chbHorzButton
			// 
			this.chbHorzButton.Location = new System.Drawing.Point(8, 16);
			this.chbHorzButton.Name = "chbHorzButton";
			this.chbHorzButton.TabIndex = 11;
			this.chbHorzButton.Text = "Horz Button";
			this.chbHorzButton.CheckedChanged += new System.EventHandler(this.chbHorzButton_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chbAllowSplitHorz);
			this.groupBox1.Controls.Add(this.chbAllowSplitVert);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 80);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Split";
			// 
			// chbAllowSplitHorz
			// 
			this.chbAllowSplitHorz.Location = new System.Drawing.Point(8, 16);
			this.chbAllowSplitHorz.Name = "chbAllowSplitHorz";
			this.chbAllowSplitHorz.Size = new System.Drawing.Size(112, 24);
			this.chbAllowSplitHorz.TabIndex = 9;
			this.chbAllowSplitHorz.Text = "Split Horizontally";
			this.chbAllowSplitHorz.CheckedChanged += new System.EventHandler(this.chbAllowSplitHorz_CheckedChanged);
			// 
			// chbAllowSplitVert
			// 
			this.chbAllowSplitVert.Location = new System.Drawing.Point(8, 40);
			this.chbAllowSplitVert.Name = "chbAllowSplitVert";
			this.chbAllowSplitVert.Size = new System.Drawing.Size(112, 24);
			this.chbAllowSplitVert.TabIndex = 10;
			this.chbAllowSplitVert.Text = "Split Vertically";
			this.chbAllowSplitVert.CheckedChanged += new System.EventHandler(this.chbAllowSplitVert_CheckedChanged);
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
			this.laDescription.Text = "This demo shows ability to visually split edit control to provide different views" +
				" of the same text.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 104);
			this.syntaxEdit1.Name = "syntaxEdit1";
			scrollingButton1.Description = "Page Normal Mode";
			scrollingButton1.ImageIndex = 0;
			scrollingButton1.Images = this.imageList2;
			scrollingButton1.Name = "Normal";
			scrollingButton1.Visible = false;
			scrollingButton2.Description = "Page Layout Mode";
			scrollingButton2.ImageIndex = 1;
			scrollingButton2.Images = this.imageList2;
			scrollingButton2.Name = "PageLayout";
			scrollingButton2.Visible = false;
			scrollingButton3.Description = "Page Breaks Mode";
			scrollingButton3.ImageIndex = 2;
			scrollingButton3.Images = this.imageList2;
			scrollingButton3.Name = "PageBreaks";
			scrollingButton3.Visible = false;
			this.syntaxEdit1.Scroll.HorizontalButtons.AddRange(new QWhale.Editor.ScrollingButton[] {
																									   scrollingButton1,
																									   scrollingButton2,
																									   scrollingButton3});
			this.syntaxEdit1.Scroll.Options = ((QWhale.Editor.ScrollingOptions)((((QWhale.Editor.ScrollingOptions.SmoothScroll | QWhale.Editor.ScrollingOptions.UseScrollDelta) 
				| QWhale.Editor.ScrollingOptions.AllowSplitHorz) 
				| QWhale.Editor.ScrollingOptions.AllowSplitVert)));
			this.syntaxEdit1.Scroll.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
			scrollingButton4.Description = "Page Down";
			scrollingButton4.ImageIndex = 3;
			scrollingButton4.Images = this.imageList2;
			scrollingButton4.Name = "PageDown";
			scrollingButton4.Visible = false;
			scrollingButton5.Description = "Page Up";
			scrollingButton5.ImageIndex = 4;
			scrollingButton5.Images = this.imageList2;
			scrollingButton5.Name = "PageUp";
			scrollingButton5.Visible = false;
			this.syntaxEdit1.Scroll.VerticalButtons.AddRange(new QWhale.Editor.ScrollingButton[] {
																									 scrollingButton4,
																									 scrollingButton5});
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 214);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
			this.syntaxEdit1.ScrollButtonClick += new System.EventHandler(this.syntaxEdit1_ScrollButtonClick);
			// 
			// chbShowScrollHint
			// 
			this.chbShowScrollHint.Location = new System.Drawing.Point(112, 16);
			this.chbShowScrollHint.Name = "chbShowScrollHint";
			this.chbShowScrollHint.Size = new System.Drawing.Size(112, 24);
			this.chbShowScrollHint.TabIndex = 13;
			this.chbShowScrollHint.Text = "Show Scroll Hint";
			this.chbShowScrollHint.CheckedChanged += new System.EventHandler(this.chbShowScrollHint_CheckedChanged);
			// 
			// chbSmoothScroll
			// 
			this.chbSmoothScroll.Location = new System.Drawing.Point(112, 40);
			this.chbSmoothScroll.Name = "chbSmoothScroll";
			this.chbSmoothScroll.TabIndex = 14;
			this.chbSmoothScroll.Text = "Smooth Scroll";
			this.chbSmoothScroll.CheckedChanged += new System.EventHandler(this.chbSmoothScroll_CheckedChanged);
			// 
			// chbSystemScrollBars
			// 
			this.chbSystemScrollBars.Location = new System.Drawing.Point(232, 16);
			this.chbSystemScrollBars.Name = "chbSystemScrollBars";
			this.chbSystemScrollBars.TabIndex = 15;
			this.chbSystemScrollBars.Text = "System Scroll";
			this.chbSystemScrollBars.CheckedChanged += new System.EventHandler(this.chbSystemScrollBars_CheckedChanged);
			// 
			// chbFlatScrollBars
			// 
			this.chbFlatScrollBars.Location = new System.Drawing.Point(232, 40);
			this.chbFlatScrollBars.Name = "chbFlatScrollBars";
			this.chbFlatScrollBars.TabIndex = 16;
			this.chbFlatScrollBars.Text = "Flat Scroll";
			this.chbFlatScrollBars.CheckedChanged += new System.EventHandler(this.chbFlatScrollBars_CheckedChanged);
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
			this.groupBox2.ResumeLayout(false);
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

		private int scrollBoxUpdate;

		private void UpdateScrollBoxes(object sender)
		{
			if (scrollBoxUpdate > 0)
				return;
			scrollBoxUpdate++;
			try
			{
				if (chbAllowSplitHorz != sender)
					chbAllowSplitHorz.Checked = ((ScrollingOptions.AllowSplitHorz & syntaxEdit1.Scrolling.Options) != 0);
				if (chbAllowSplitVert != sender)
					chbAllowSplitVert.Checked = ((ScrollingOptions.AllowSplitVert & syntaxEdit1.Scrolling.Options) != 0);
				if (chbHorzButton != sender)
					chbHorzButton.Checked = ((ScrollingOptions.HorzButtons & syntaxEdit1.Scrolling.Options) != 0);
				if (chbVertButton != sender)
					chbVertButton.Checked = ((ScrollingOptions.VertButtons & syntaxEdit1.Scrolling.Options) != 0);
				if (chbSystemScrollBars != sender)
					chbSystemScrollBars.Checked = (syntaxEdit1.Scrolling.Options & ScrollingOptions.SystemScrollbars) != 0;
				if (chbFlatScrollBars != sender)
					chbFlatScrollBars.Checked = (syntaxEdit1.Scrolling.Options & ScrollingOptions.FlatScrollbars) != 0;
			}
			finally
			{
				scrollBoxUpdate--;
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			chbAllowSplitHorz.Checked = ((ScrollingOptions.AllowSplitHorz & syntaxEdit1.Scrolling.Options) != 0);
			chbAllowSplitVert.Checked = ((ScrollingOptions.AllowSplitVert & syntaxEdit1.Scrolling.Options) != 0);
			chbHorzButton.Checked = ((ScrollingOptions.HorzButtons & syntaxEdit1.Scrolling.Options) != 0);
			chbVertButton.Checked = ((ScrollingOptions.VertButtons & syntaxEdit1.Scrolling.Options) != 0);
			chbShowScrollHint.Checked = (syntaxEdit1.Scrolling.Options & ScrollingOptions.ShowScrollHint) != 0;
			chbSmoothScroll.Checked = (syntaxEdit1.Scrolling.Options & ScrollingOptions.SmoothScroll) != 0;
			chbSystemScrollBars.Checked = (syntaxEdit1.Scrolling.Options & ScrollingOptions.SystemScrollbars) != 0;
			chbFlatScrollBars.Checked = (syntaxEdit1.Scrolling.Options & ScrollingOptions.FlatScrollbars) != 0;
		}

		private void chbAllowSplitHorz_CheckedChanged(object sender, System.EventArgs e)
		{
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit1.Scrolling.Options = (chbAllowSplitHorz.Checked) ? syntaxEdit1.Scrolling.Options
				| ScrollingOptions.AllowSplitHorz : syntaxEdit1.Scrolling.Options ^ ScrollingOptions.AllowSplitHorz;
			UpdateScrollBoxes(chbAllowSplitHorz);
		}

		private void chbAllowSplitVert_CheckedChanged(object sender, System.EventArgs e)
		{
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit1.Scrolling.Options = (chbAllowSplitVert.Checked) ? syntaxEdit1.Scrolling.Options
				| ScrollingOptions.AllowSplitVert : syntaxEdit1.Scrolling.Options ^ ScrollingOptions.AllowSplitVert;
			UpdateScrollBoxes(chbAllowSplitVert);
		}

		private void chbHorzButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit1.Scrolling.Options = (chbHorzButton.Checked) ? syntaxEdit1.Scrolling.Options
				| ScrollingOptions.HorzButtons : syntaxEdit1.Scrolling.Options ^ ScrollingOptions.HorzButtons;
			UpdateScrollBoxes(chbHorzButton);
		}

		private void chbVertButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit1.Scrolling.Options = (chbVertButton.Checked) ? syntaxEdit1.Scrolling.Options
				| ScrollingOptions.VertButtons : syntaxEdit1.Scrolling.Options ^ ScrollingOptions.VertButtons;
			UpdateScrollBoxes(chbVertButton);
		}

		private void syntaxEdit1_ScrollButtonClick(object sender, System.EventArgs e)
		{
			if (sender is IScrollingButton)
			{
				switch (((IScrollingButton)sender).Name)
				{
					case "Normal" :
					{
						syntaxEdit1.Pages.PageType  = PageType.Normal;
						break;
					}
					case "PageLayout" :
					{
						syntaxEdit1.Pages.PageType  = PageType.PageLayout;
						break;
					}
					case "PageBreaks" :
					{
						syntaxEdit1.Pages.PageType  = PageType.PageBreaks;
						break;
					}
					case "PageUp" :
					{
						syntaxEdit1.MovePageUp();
						break;
					}
					case "PageDown" :
					{
						syntaxEdit1.MovePageDown();
						break;
					}
				}
			}		
		}

		private void chbShowScrollHint_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Scrolling.Options = (chbShowScrollHint.Checked ? syntaxEdit1.Scrolling.Options
				| ScrollingOptions.ShowScrollHint : syntaxEdit1.Scrolling.Options ^ ScrollingOptions.ShowScrollHint);
		}

		private void chbSmoothScroll_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Scrolling.Options = (chbSmoothScroll.Checked ? syntaxEdit1.Scrolling.Options
				| ScrollingOptions.SmoothScroll : syntaxEdit1.Scrolling.Options ^ ScrollingOptions.SmoothScroll);
		}

		private void chbSystemScrollBars_CheckedChanged(object sender, System.EventArgs e)
		{
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit1.Scrolling.Options = (chbSystemScrollBars.Checked ? syntaxEdit1.Scrolling.Options
				| ScrollingOptions.SystemScrollbars : syntaxEdit1.Scrolling.Options ^ ScrollingOptions.SystemScrollbars);
			UpdateScrollBoxes(chbSystemScrollBars);		
		}

		private void chbFlatScrollBars_CheckedChanged(object sender, System.EventArgs e)
		{
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit1.Scrolling.Options = (chbFlatScrollBars.Checked ? syntaxEdit1.Scrolling.Options
				| ScrollingOptions.FlatScrollbars : syntaxEdit1.Scrolling.Options ^ ScrollingOptions.FlatScrollbars);
			UpdateScrollBoxes(chbFlatScrollBars);		
		}
	}
}
