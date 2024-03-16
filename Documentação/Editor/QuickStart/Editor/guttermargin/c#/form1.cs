using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace GutterMargin
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.CheckBox chbShowGutter;
		private System.Windows.Forms.Label laGutterWidth;
		private System.Windows.Forms.NumericUpDown nudGutterWidth;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.CheckBox chbGradientGutter;
		private QWhale.Common.ColorBox cbGutterColor;
		private System.Windows.Forms.Label laGutterColor;
		private QWhale.Common.ColorBox cbGradientEndColor;
		private QWhale.Common.ColorBox cbPenColor;
		private System.Windows.Forms.Label laPenColor;
		private System.Windows.Forms.Label laGradientBeginColor;
		private System.Windows.Forms.Label laGradientEndColor;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label laMarginPos;
		private System.Windows.Forms.CheckBox chbShowMargin;
		private System.Windows.Forms.NumericUpDown nudMarginPos;
		private System.Windows.Forms.Label laMarginColor;
		private QWhale.Common.ColorBox cbGradientBeginColor;
		private QWhale.Common.ColorBox cbMarginColor;
		private System.Windows.Forms.Label laColumnPenColor;
		private QWhale.Common.ColorBox cbColumnsPenColor;
		private System.Windows.Forms.CheckBox chbColumnsVisible;
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
			this.laGradientEndColor = new System.Windows.Forms.Label();
			this.laGradientBeginColor = new System.Windows.Forms.Label();
			this.laPenColor = new System.Windows.Forms.Label();
			this.cbGradientBeginColor = new QWhale.Common.ColorBox(this.components);
			this.cbPenColor = new QWhale.Common.ColorBox(this.components);
			this.cbGradientEndColor = new QWhale.Common.ColorBox(this.components);
			this.chbGradientGutter = new System.Windows.Forms.CheckBox();
			this.nudGutterWidth = new System.Windows.Forms.NumericUpDown();
			this.chbShowGutter = new System.Windows.Forms.CheckBox();
			this.laGutterWidth = new System.Windows.Forms.Label();
			this.cbGutterColor = new QWhale.Common.ColorBox(this.components);
			this.laGutterColor = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chbColumnsVisible = new System.Windows.Forms.CheckBox();
			this.laColumnPenColor = new System.Windows.Forms.Label();
			this.cbColumnsPenColor = new QWhale.Common.ColorBox(this.components);
			this.laMarginColor = new System.Windows.Forms.Label();
			this.cbMarginColor = new QWhale.Common.ColorBox(this.components);
			this.laMarginPos = new System.Windows.Forms.Label();
			this.chbShowMargin = new System.Windows.Forms.CheckBox();
			this.nudMarginPos = new System.Windows.Forms.NumericUpDown();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.pnSettings.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudGutterWidth)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMarginPos)).BeginInit();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.groupBox1);
			this.pnSettings.Controls.Add(this.groupBox2);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(592, 144);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.laGradientEndColor);
			this.groupBox1.Controls.Add(this.laGradientBeginColor);
			this.groupBox1.Controls.Add(this.laPenColor);
			this.groupBox1.Controls.Add(this.cbGradientBeginColor);
			this.groupBox1.Controls.Add(this.cbPenColor);
			this.groupBox1.Controls.Add(this.cbGradientEndColor);
			this.groupBox1.Controls.Add(this.chbGradientGutter);
			this.groupBox1.Controls.Add(this.nudGutterWidth);
			this.groupBox1.Controls.Add(this.chbShowGutter);
			this.groupBox1.Controls.Add(this.laGutterWidth);
			this.groupBox1.Controls.Add(this.cbGutterColor);
			this.groupBox1.Controls.Add(this.laGutterColor);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(368, 120);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Gutter";
			// 
			// laGradientEndColor
			// 
			this.laGradientEndColor.AutoSize = true;
			this.laGradientEndColor.Location = new System.Drawing.Point(232, 56);
			this.laGradientEndColor.Name = "laGradientEndColor";
			this.laGradientEndColor.Size = new System.Drawing.Size(95, 16);
			this.laGradientEndColor.TabIndex = 24;
			this.laGradientEndColor.Text = "Gradient End Color";
			// 
			// laGradientBeginColor
			// 
			this.laGradientBeginColor.AutoSize = true;
			this.laGradientBeginColor.Location = new System.Drawing.Point(232, 16);
			this.laGradientBeginColor.Name = "laGradientBeginColor";
			this.laGradientBeginColor.Size = new System.Drawing.Size(104, 16);
			this.laGradientBeginColor.TabIndex = 23;
			this.laGradientBeginColor.Text = "Gradient Begin Color";
			// 
			// laPenColor
			// 
			this.laPenColor.AutoSize = true;
			this.laPenColor.Location = new System.Drawing.Point(104, 56);
			this.laPenColor.Name = "laPenColor";
			this.laPenColor.Size = new System.Drawing.Size(50, 16);
			this.laPenColor.TabIndex = 22;
			this.laPenColor.Text = "Pen Color";
			// 
			// cbGradientBeginColor
			// 
			this.cbGradientBeginColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbGradientBeginColor.Location = new System.Drawing.Point(232, 32);
			this.cbGradientBeginColor.Name = "cbGradientBeginColor";
			this.cbGradientBeginColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbGradientBeginColor.Size = new System.Drawing.Size(121, 21);
			this.cbGradientBeginColor.TabIndex = 21;
			this.cbGradientBeginColor.SelectedIndexChanged += new System.EventHandler(this.cbGradientBeginColor_SelectedIndexChanged);
			// 
			// cbPenColor
			// 
			this.cbPenColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbPenColor.Location = new System.Drawing.Point(104, 72);
			this.cbPenColor.Name = "cbPenColor";
			this.cbPenColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbPenColor.Size = new System.Drawing.Size(121, 21);
			this.cbPenColor.TabIndex = 20;
			this.cbPenColor.SelectedIndexChanged += new System.EventHandler(this.cbPenColor_SelectedIndexChanged);
			// 
			// cbGradientEndColor
			// 
			this.cbGradientEndColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbGradientEndColor.Location = new System.Drawing.Point(232, 72);
			this.cbGradientEndColor.Name = "cbGradientEndColor";
			this.cbGradientEndColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbGradientEndColor.Size = new System.Drawing.Size(121, 21);
			this.cbGradientEndColor.TabIndex = 19;
			this.cbGradientEndColor.SelectedIndexChanged += new System.EventHandler(this.cbGradientEndColor_SelectedIndexChanged);
			// 
			// chbGradientGutter
			// 
			this.chbGradientGutter.Location = new System.Drawing.Point(8, 32);
			this.chbGradientGutter.Name = "chbGradientGutter";
			this.chbGradientGutter.Size = new System.Drawing.Size(88, 24);
			this.chbGradientGutter.TabIndex = 11;
			this.chbGradientGutter.Text = "Use gradient";
			this.chbGradientGutter.CheckedChanged += new System.EventHandler(this.chbGradientGutter_CheckedChanged);
			// 
			// nudGutterWidth
			// 
			this.nudGutterWidth.Location = new System.Drawing.Point(8, 72);
			this.nudGutterWidth.Name = "nudGutterWidth";
			this.nudGutterWidth.Size = new System.Drawing.Size(64, 20);
			this.nudGutterWidth.TabIndex = 14;
			this.nudGutterWidth.ValueChanged += new System.EventHandler(this.nudGutterWidth_ValueChanged);
			// 
			// chbShowGutter
			// 
			this.chbShowGutter.Location = new System.Drawing.Point(8, 16);
			this.chbShowGutter.Name = "chbShowGutter";
			this.chbShowGutter.Size = new System.Drawing.Size(96, 16);
			this.chbShowGutter.TabIndex = 9;
			this.chbShowGutter.Text = "Show Gutter";
			this.chbShowGutter.CheckedChanged += new System.EventHandler(this.chbShowGutter_CheckedChanged);
			// 
			// laGutterWidth
			// 
			this.laGutterWidth.AutoSize = true;
			this.laGutterWidth.Location = new System.Drawing.Point(8, 56);
			this.laGutterWidth.Name = "laGutterWidth";
			this.laGutterWidth.Size = new System.Drawing.Size(66, 16);
			this.laGutterWidth.TabIndex = 12;
			this.laGutterWidth.Text = "Gutter Width";
			// 
			// cbGutterColor
			// 
			this.cbGutterColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbGutterColor.Location = new System.Drawing.Point(104, 32);
			this.cbGutterColor.Name = "cbGutterColor";
			this.cbGutterColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbGutterColor.Size = new System.Drawing.Size(121, 21);
			this.cbGutterColor.TabIndex = 18;
			this.cbGutterColor.SelectedIndexChanged += new System.EventHandler(this.cbGutterColor_SelectedIndexChanged);
			// 
			// laGutterColor
			// 
			this.laGutterColor.AutoSize = true;
			this.laGutterColor.Location = new System.Drawing.Point(104, 16);
			this.laGutterColor.Name = "laGutterColor";
			this.laGutterColor.Size = new System.Drawing.Size(63, 16);
			this.laGutterColor.TabIndex = 17;
			this.laGutterColor.Text = "Gutter Color";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chbColumnsVisible);
			this.groupBox2.Controls.Add(this.laColumnPenColor);
			this.groupBox2.Controls.Add(this.cbColumnsPenColor);
			this.groupBox2.Controls.Add(this.laMarginColor);
			this.groupBox2.Controls.Add(this.cbMarginColor);
			this.groupBox2.Controls.Add(this.laMarginPos);
			this.groupBox2.Controls.Add(this.chbShowMargin);
			this.groupBox2.Controls.Add(this.nudMarginPos);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
			this.groupBox2.Location = new System.Drawing.Point(368, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(224, 120);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Margin";
			// 
			// chbColumnsVisible
			// 
			this.chbColumnsVisible.Location = new System.Drawing.Point(96, 16);
			this.chbColumnsVisible.Name = "chbColumnsVisible";
			this.chbColumnsVisible.Size = new System.Drawing.Size(104, 16);
			this.chbColumnsVisible.TabIndex = 17;
			this.chbColumnsVisible.Text = "Columns Visible";
			this.chbColumnsVisible.CheckedChanged += new System.EventHandler(this.chbColumnsVisible_CheckedChanged);
			// 
			// laColumnPenColor
			// 
			this.laColumnPenColor.AutoSize = true;
			this.laColumnPenColor.Location = new System.Drawing.Point(8, 88);
			this.laColumnPenColor.Name = "laColumnPenColor";
			this.laColumnPenColor.Size = new System.Drawing.Size(69, 16);
			this.laColumnPenColor.TabIndex = 27;
			this.laColumnPenColor.Text = "Column Color";
			// 
			// cbColumnsPenColor
			// 
			this.cbColumnsPenColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbColumnsPenColor.Location = new System.Drawing.Point(96, 88);
			this.cbColumnsPenColor.Name = "cbColumnsPenColor";
			this.cbColumnsPenColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbColumnsPenColor.Size = new System.Drawing.Size(104, 21);
			this.cbColumnsPenColor.TabIndex = 26;
			this.cbColumnsPenColor.SelectedIndexChanged += new System.EventHandler(this.cbColumnsPenColor_SelectedIndexChanged);
			// 
			// laMarginColor
			// 
			this.laMarginColor.AutoSize = true;
			this.laMarginColor.Location = new System.Drawing.Point(8, 64);
			this.laMarginColor.Name = "laMarginColor";
			this.laMarginColor.Size = new System.Drawing.Size(65, 16);
			this.laMarginColor.TabIndex = 25;
			this.laMarginColor.Text = "Margin Color";
			// 
			// cbMarginColor
			// 
			this.cbMarginColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbMarginColor.Location = new System.Drawing.Point(96, 64);
			this.cbMarginColor.Name = "cbMarginColor";
			this.cbMarginColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbMarginColor.Size = new System.Drawing.Size(104, 21);
			this.cbMarginColor.TabIndex = 24;
			this.cbMarginColor.SelectedIndexChanged += new System.EventHandler(this.cbMarginColor_SelectedIndexChanged);
			// 
			// laMarginPos
			// 
			this.laMarginPos.AutoSize = true;
			this.laMarginPos.Location = new System.Drawing.Point(8, 40);
			this.laMarginPos.Name = "laMarginPos";
			this.laMarginPos.Size = new System.Drawing.Size(78, 16);
			this.laMarginPos.TabIndex = 17;
			this.laMarginPos.Text = "Margin position";
			// 
			// chbShowMargin
			// 
			this.chbShowMargin.Location = new System.Drawing.Point(8, 16);
			this.chbShowMargin.Name = "chbShowMargin";
			this.chbShowMargin.Size = new System.Drawing.Size(96, 16);
			this.chbShowMargin.TabIndex = 16;
			this.chbShowMargin.Text = "Show Margin";
			this.chbShowMargin.CheckedChanged += new System.EventHandler(this.chbShowMargin_CheckedChanged);
			// 
			// nudMarginPos
			// 
			this.nudMarginPos.Location = new System.Drawing.Point(96, 40);
			this.nudMarginPos.Name = "nudMarginPos";
			this.nudMarginPos.Size = new System.Drawing.Size(64, 20);
			this.nudMarginPos.TabIndex = 18;
			this.nudMarginPos.ValueChanged += new System.EventHandler(this.nudMarginPos_ValueChanged);
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(592, 24);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(592, 24);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows how to customize appearance of the gutter and margin.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.EditMargin.ColumnPenColor = System.Drawing.Color.DimGray;
			this.syntaxEdit1.EditMargin.ColumnPositions = new int[] {
																		16,
																		48};
			this.syntaxEdit1.EditMargin.ColumnsVisible = true;
			this.syntaxEdit1.EditMargin.Position = 60;
			this.syntaxEdit1.EditMargin.Visible = true;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Gutter.Options = ((QWhale.Editor.GutterOptions)(((QWhale.Editor.GutterOptions.PaintLineNumbers | QWhale.Editor.GutterOptions.PaintLinesOnGutter) 
				| QWhale.Editor.GutterOptions.PaintBookMarks)));
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 144);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(592, 253);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
			this.syntaxEdit1.PaintBackground += new System.Windows.Forms.PaintEventHandler(this.syntaxEdit1_PaintBackground);
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
				"ts</Name>\r\n      <ForeColor>ControlText</ForeColor>\r\n      <ForeColorEnabled>tru" +
				"e</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n      <Bo" +
				"ldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n      <" +
				"UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <Name" +
				">numbers</Name>\r\n      <ForeColor>Green</ForeColor>\r\n      <ForeColorEnabled>tru" +
				"e</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n      <Bo" +
				"ldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n      <" +
				"UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <Name" +
				">reswords</Name>\r\n      <ForeColor>Blue</ForeColor>\r\n      <ForeColorEnabled>tru" +
				"e</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n      <Bo" +
				"ldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n      <" +
				"UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <Name" +
				">comments</Name>\r\n      <ForeColor>Green</ForeColor>\r\n      <PlainText>true</Pla" +
				"inText>\r\n      <ForeColorEnabled>true</ForeColorEnabled>\r\n      <BackColorEnable" +
				"d>true</BackColorEnabled>\r\n      <BoldEnabled>true</BoldEnabled>\r\n      <ItalicE" +
				"nabled>true</ItalicEnabled>\r\n      <UnderlineEnabled>true</UnderlineEnabled>\r\n  " +
				"  </Style>\r\n    <Style>\r\n      <Name>xmlcomments</Name>\r\n      <ForeColor>Gray</" +
				"ForeColor>\r\n      <ForeColorEnabled>true</ForeColorEnabled>\r\n      <BackColorEna" +
				"bled>true</BackColorEnabled>\r\n      <BoldEnabled>true</BoldEnabled>\r\n      <Ital" +
				"icEnabled>true</ItalicEnabled>\r\n      <UnderlineEnabled>true</UnderlineEnabled>\r" +
				"\n    </Style>\r\n    <Style>\r\n      <Name>symbols</Name>\r\n      <ForeColor>Gray</F" +
				"oreColor>\r\n      <ForeColorEnabled>true</ForeColorEnabled>\r\n      <BackColorEnab" +
				"led>true</BackColorEnabled>\r\n      <BoldEnabled>true</BoldEnabled>\r\n      <Itali" +
				"cEnabled>true</ItalicEnabled>\r\n      <UnderlineEnabled>true</UnderlineEnabled>\r\n" +
				"    </Style>\r\n    <Style>\r\n      <Name>whitespace</Name>\r\n      <ForeColor>Windo" +
				"wText</ForeColor>\r\n      <ForeColorEnabled>true</ForeColorEnabled>\r\n      <BackC" +
				"olorEnabled>true</BackColorEnabled>\r\n      <BoldEnabled>true</BoldEnabled>\r\n    " +
				"  <ItalicEnabled>true</ItalicEnabled>\r\n      <UnderlineEnabled>true</UnderlineEn" +
				"abled>\r\n    </Style>\r\n    <Style>\r\n      <Name>strings</Name>\r\n      <ForeColor>" +
				"Maroon</ForeColor>\r\n      <PlainText>true</PlainText>\r\n      <ForeColorEnabled>t" +
				"rue</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n      <" +
				"BoldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n     " +
				" <UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <Na" +
				"me>directives</Name>\r\n      <ForeColor>Blue</ForeColor>\r\n      <ForeColorEnabled" +
				">true</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n     " +
				" <BoldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n   " +
				"   <UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <" +
				"Name>syntaxerrors</Name>\r\n      <ForeColor>Red</ForeColor>\r\n      <ForeColorEnab" +
				"led>true</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n  " +
				"    <BoldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n" +
				"      <UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n  </Styles>\r\n  <S" +
				"tates />\r\n</LexScheme>";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 397);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudGutterWidth)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudMarginPos)).EndInit();
			this.pnDescription.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private Color gradientBeginColor = Color.Blue;
		private Color gradientEndColor = Color.White;

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
			chbShowGutter.Checked = syntaxEdit1.Gutter.Visible;
			chbShowMargin.Checked = syntaxEdit1.EditMargin.Visible;
			nudGutterWidth.Maximum = syntaxEdit1.Width;
			nudGutterWidth.Value = syntaxEdit1.Gutter.Width;
			nudMarginPos.Maximum = 1000;
			nudMarginPos.Value = syntaxEdit1.EditMargin.Position;
			cbGutterColor.SelectedColor = syntaxEdit1.Gutter.BrushColor;
			cbPenColor.SelectedColor = syntaxEdit1.Gutter.PenColor;
			cbMarginColor.SelectedColor = syntaxEdit1.EditMargin.PenColor;
			cbGradientBeginColor.SelectedColor = gradientBeginColor;
			cbGradientEndColor.SelectedColor = gradientEndColor;
			chbColumnsVisible.Checked = syntaxEdit1.EditMargin.ColumnsVisible;
			cbColumnsPenColor.SelectedColor = syntaxEdit1.EditMargin.ColumnPenColor;
		}

		private void chbShowGutter_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.Visible = chbShowGutter.Checked;
		}

		private void chbShowMargin_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.EditMargin.Visible = chbShowMargin.Checked;
		}

		private void nudGutterWidth_ValueChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.Width = (int)nudGutterWidth.Value;
		}

		private void nudMarginPos_ValueChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.EditMargin.Position = (int)nudMarginPos.Value;
		}
		private void chbGradientGutter_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Transparent = chbGradientGutter.Checked;
			syntaxEdit1.Invalidate();
		}
		private void cbGutterColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.BrushColor = cbGutterColor.SelectedColor;
		}
		private void cbPenColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.PenColor = cbPenColor.SelectedColor;
		}
		private void cbGradientBeginColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			gradientBeginColor = cbGradientBeginColor.SelectedColor;
			if (chbGradientGutter.Checked)
				syntaxEdit1.Invalidate();
		}
		private void cbGradientEndColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			gradientEndColor = cbGradientEndColor.SelectedColor;
			if (chbGradientGutter.Checked)
				syntaxEdit1.Invalidate();
		}

		private void cbMarginColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.EditMargin.PenColor = cbMarginColor.SelectedColor;
			syntaxEdit1.Invalidate();
		}
		private void syntaxEdit1_PaintBackground(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (syntaxEdit1.Transparent && syntaxEdit1.Gutter.Visible)
			{
				Rectangle r = syntaxEdit1.Gutter.Rect;
				e.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(r.Location, new Point(r.Right, r.Bottom), gradientBeginColor, gradientEndColor), r);
			}
		}

		private void chbColumnsVisible_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.EditMargin.ColumnsVisible = chbColumnsVisible.Checked;
		}

		private void cbColumnsPenColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.EditMargin.ColumnPenColor = cbColumnsPenColor.SelectedColor;
			syntaxEdit1.Invalidate();
		}
	}
}
