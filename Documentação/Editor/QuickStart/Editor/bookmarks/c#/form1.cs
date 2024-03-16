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

namespace Bookmarks
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
		private System.Windows.Forms.CheckBox chbShowBookmarks;
		private System.Windows.Forms.CheckBox chbLineBookmarks;
		private System.Windows.Forms.Button btSetUnindexedBookmarks;
		private System.Windows.Forms.Button btClearBookmarks;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.Button btSetCustomBookmark;
		private System.Windows.Forms.Button btSetBookmark;
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
			this.pnSettings = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chbShowBookmarks = new System.Windows.Forms.CheckBox();
			this.chbLineBookmarks = new System.Windows.Forms.CheckBox();
			this.btSetBookmark = new System.Windows.Forms.Button();
			this.btClearBookmarks = new System.Windows.Forms.Button();
			this.btSetCustomBookmark = new System.Windows.Forms.Button();
			this.btSetUnindexedBookmarks = new System.Windows.Forms.Button();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
			this.groupBox1.Controls.Add(this.chbShowBookmarks);
			this.groupBox1.Controls.Add(this.chbLineBookmarks);
			this.groupBox1.Controls.Add(this.btSetBookmark);
			this.groupBox1.Controls.Add(this.btClearBookmarks);
			this.groupBox1.Controls.Add(this.btSetCustomBookmark);
			this.groupBox1.Controls.Add(this.btSetUnindexedBookmarks);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 80);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bookmarks";
			// 
			// chbShowBookmarks
			// 
			this.chbShowBookmarks.Location = new System.Drawing.Point(16, 16);
			this.chbShowBookmarks.Name = "chbShowBookmarks";
			this.chbShowBookmarks.Size = new System.Drawing.Size(112, 24);
			this.chbShowBookmarks.TabIndex = 9;
			this.chbShowBookmarks.Text = "Draw Bookmarks";
			this.chbShowBookmarks.CheckedChanged += new System.EventHandler(this.chbShowBookmarks_CheckedChanged);
			// 
			// chbLineBookmarks
			// 
			this.chbLineBookmarks.Location = new System.Drawing.Point(16, 40);
			this.chbLineBookmarks.Name = "chbLineBookmarks";
			this.chbLineBookmarks.Size = new System.Drawing.Size(136, 24);
			this.chbLineBookmarks.TabIndex = 10;
			this.chbLineBookmarks.Text = "Draw Line Bookmarks";
			this.chbLineBookmarks.CheckedChanged += new System.EventHandler(this.chbLineBookmarks_CheckedChanged);
			// 
			// btSetBookmark
			// 
			this.btSetBookmark.Location = new System.Drawing.Point(160, 24);
			this.btSetBookmark.Name = "btSetBookmark";
			this.btSetBookmark.Size = new System.Drawing.Size(152, 23);
			this.btSetBookmark.TabIndex = 12;
			this.btSetBookmark.Text = "Set Bookmark";
			this.btSetBookmark.Click += new System.EventHandler(this.btSetBookmark_Click);
			// 
			// btClearBookmarks
			// 
			this.btClearBookmarks.Location = new System.Drawing.Point(160, 48);
			this.btClearBookmarks.Name = "btClearBookmarks";
			this.btClearBookmarks.Size = new System.Drawing.Size(152, 23);
			this.btClearBookmarks.TabIndex = 14;
			this.btClearBookmarks.Text = "Clear Bookmarks";
			this.btClearBookmarks.Click += new System.EventHandler(this.btClearBookmarks_Click);
			// 
			// btSetCustomBookmark
			// 
			this.btSetCustomBookmark.Location = new System.Drawing.Point(336, 48);
			this.btSetCustomBookmark.Name = "btSetCustomBookmark";
			this.btSetCustomBookmark.Size = new System.Drawing.Size(152, 23);
			this.btSetCustomBookmark.TabIndex = 15;
			this.btSetCustomBookmark.Text = "Set Custom Bookmark";
			this.btSetCustomBookmark.Click += new System.EventHandler(this.btSetNamedBookmark_Click);
			// 
			// btSetUnindexedBookmarks
			// 
			this.btSetUnindexedBookmarks.Location = new System.Drawing.Point(336, 24);
			this.btSetUnindexedBookmarks.Name = "btSetUnindexedBookmarks";
			this.btSetUnindexedBookmarks.Size = new System.Drawing.Size(152, 23);
			this.btSetUnindexedBookmarks.TabIndex = 13;
			this.btSetUnindexedBookmarks.Text = "Set Unindexed Bookmarks";
			this.btSetUnindexedBookmarks.Click += new System.EventHandler(this.btSetUnindexedBookmarks_Click);
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
			this.laDescription.Text = "This demo shows how to use bookmarks within edit control\'s content.";
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
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(15, 15);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
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
			chbShowBookmarks.Checked = (GutterOptions.PaintBookMarks & syntaxEdit1.Gutter.Options) != 0;
			chbLineBookmarks.Checked = syntaxEdit1.Gutter.DrawLineBookmarks;
			for (int i = 0; i < imageList1.Images.Count; i++)
				syntaxEdit1.Gutter.Images.Images.Add(imageList1.Images[i]);
			SetBookmark();
		}
		private void chbShowBookmarks_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.Options = (chbShowBookmarks.Checked ? syntaxEdit1.Gutter.Options 
				| GutterOptions.PaintBookMarks : syntaxEdit1.Gutter.Options ^ GutterOptions.PaintBookMarks);		
		}

		private void chbLineBookmarks_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.DrawLineBookmarks = chbLineBookmarks.Checked;
		}
		private void SetBookmark()
		{
			syntaxEdit1.Source.BookMarks.SetBookMark(syntaxEdit1.Position, syntaxEdit1.Source.BookMarks.NextBookMark());
		}
		private void btSetBookmark_Click(object sender, System.EventArgs e)
		{
			SetBookmark();
		}
		private void btClearBookmarks_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.Source.BookMarks.ClearAllBookMarks();
		}
		private void btSetNamedBookmark_Click(object sender, System.EventArgs e)
		{
			int imgIndex = syntaxEdit1.Gutter.Images.Images.Count - new Random().Next(6) - 1;
			IBookMark urlBookMark = new BookMarkEx(syntaxEdit1.Position.Y, syntaxEdit1.Position.X, imgIndex, "Address", "visit our site", "http://www.qwhale.net");
			syntaxEdit1.Source.BookMarks.SetBookMark(urlBookMark);
		}

		private void btSetUnindexedBookmarks_Click(object sender, System.EventArgs e)
		{
			int imgIndex = int.MaxValue;
			syntaxEdit1.Source.BookMarks.SetBookMark(syntaxEdit1.Position, imgIndex);
		}
	}
}
