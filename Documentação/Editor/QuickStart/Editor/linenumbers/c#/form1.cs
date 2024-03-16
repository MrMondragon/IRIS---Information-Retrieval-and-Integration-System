using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace LineNumbers
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
		private System.Windows.Forms.CheckBox chbLineNumbers;
		private System.Windows.Forms.CheckBox chbLinesOnGutter;
		private System.Windows.Forms.Label laLineNumbersStart;
		private System.Windows.Forms.Label laLineNumbersAlign;
		private System.Windows.Forms.Label laLineNumbersLeftIndent;
		private System.Windows.Forms.Label laLineNumbersRightIndent;
		private System.Windows.Forms.ComboBox cbLineNumbersAlign;
		private System.Windows.Forms.NumericUpDown nudLineNumbersStart;
		private System.Windows.Forms.NumericUpDown nudLineNumbersLeftIndent;
		private System.Windows.Forms.NumericUpDown nudLineNumbersRightIndent;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label laLineNumbersForeColor;
		private System.Windows.Forms.Label laLineNumbersBackColor;
		private QWhale.Common.ColorBox cbLineNumbersForeColor;
		private QWhale.Common.ColorBox cbLineNumbersBackColor;
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
			this.cbLineNumbersBackColor = new QWhale.Common.ColorBox(this.components);
			this.cbLineNumbersForeColor = new QWhale.Common.ColorBox(this.components);
			this.laLineNumbersBackColor = new System.Windows.Forms.Label();
			this.laLineNumbersForeColor = new System.Windows.Forms.Label();
			this.nudLineNumbersStart = new System.Windows.Forms.NumericUpDown();
			this.nudLineNumbersRightIndent = new System.Windows.Forms.NumericUpDown();
			this.laLineNumbersLeftIndent = new System.Windows.Forms.Label();
			this.nudLineNumbersLeftIndent = new System.Windows.Forms.NumericUpDown();
			this.cbLineNumbersAlign = new System.Windows.Forms.ComboBox();
			this.laLineNumbersRightIndent = new System.Windows.Forms.Label();
			this.laLineNumbersAlign = new System.Windows.Forms.Label();
			this.chbLineNumbers = new System.Windows.Forms.CheckBox();
			this.chbLinesOnGutter = new System.Windows.Forms.CheckBox();
			this.laLineNumbersStart = new System.Windows.Forms.Label();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.pnSettings.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudLineNumbersStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLineNumbersRightIndent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLineNumbersLeftIndent)).BeginInit();
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
			this.pnSettings.Size = new System.Drawing.Size(592, 104);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbLineNumbersBackColor);
			this.groupBox1.Controls.Add(this.cbLineNumbersForeColor);
			this.groupBox1.Controls.Add(this.laLineNumbersBackColor);
			this.groupBox1.Controls.Add(this.laLineNumbersForeColor);
			this.groupBox1.Controls.Add(this.nudLineNumbersStart);
			this.groupBox1.Controls.Add(this.nudLineNumbersRightIndent);
			this.groupBox1.Controls.Add(this.laLineNumbersLeftIndent);
			this.groupBox1.Controls.Add(this.nudLineNumbersLeftIndent);
			this.groupBox1.Controls.Add(this.cbLineNumbersAlign);
			this.groupBox1.Controls.Add(this.laLineNumbersRightIndent);
			this.groupBox1.Controls.Add(this.laLineNumbersAlign);
			this.groupBox1.Controls.Add(this.chbLineNumbers);
			this.groupBox1.Controls.Add(this.chbLinesOnGutter);
			this.groupBox1.Controls.Add(this.laLineNumbersStart);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(592, 80);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Line Numbers";
			// 
			// cbLineNumbersBackColor
			// 
			this.cbLineNumbersBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbLineNumbersBackColor.Location = new System.Drawing.Point(456, 42);
			this.cbLineNumbersBackColor.Name = "cbLineNumbersBackColor";
			this.cbLineNumbersBackColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbLineNumbersBackColor.Size = new System.Drawing.Size(121, 21);
			this.cbLineNumbersBackColor.TabIndex = 22;
			this.cbLineNumbersBackColor.SelectedIndexChanged += new System.EventHandler(this.cbLineNumbersBackColor_SelectedIndexChanged);
			// 
			// cbLineNumbersForeColor
			// 
			this.cbLineNumbersForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbLineNumbersForeColor.Location = new System.Drawing.Point(456, 18);
			this.cbLineNumbersForeColor.Name = "cbLineNumbersForeColor";
			this.cbLineNumbersForeColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbLineNumbersForeColor.Size = new System.Drawing.Size(121, 21);
			this.cbLineNumbersForeColor.TabIndex = 21;
			this.cbLineNumbersForeColor.SelectedIndexChanged += new System.EventHandler(this.cbLineNumbersForeColor_SelectedIndexChanged);
			// 
			// laLineNumbersBackColor
			// 
			this.laLineNumbersBackColor.AutoSize = true;
			this.laLineNumbersBackColor.Location = new System.Drawing.Point(376, 45);
			this.laLineNumbersBackColor.Name = "laLineNumbersBackColor";
			this.laLineNumbersBackColor.Size = new System.Drawing.Size(59, 16);
			this.laLineNumbersBackColor.TabIndex = 20;
			this.laLineNumbersBackColor.Text = "Back Color";
			// 
			// laLineNumbersForeColor
			// 
			this.laLineNumbersForeColor.AutoSize = true;
			this.laLineNumbersForeColor.Location = new System.Drawing.Point(376, 21);
			this.laLineNumbersForeColor.Name = "laLineNumbersForeColor";
			this.laLineNumbersForeColor.Size = new System.Drawing.Size(58, 16);
			this.laLineNumbersForeColor.TabIndex = 19;
			this.laLineNumbersForeColor.Text = "Fore Color";
			// 
			// nudLineNumbersStart
			// 
			this.nudLineNumbersStart.Location = new System.Drawing.Point(156, 18);
			this.nudLineNumbersStart.Name = "nudLineNumbersStart";
			this.nudLineNumbersStart.Size = new System.Drawing.Size(64, 20);
			this.nudLineNumbersStart.TabIndex = 13;
			this.nudLineNumbersStart.ValueChanged += new System.EventHandler(this.nudLineNumbersStart_ValueChanged);
			// 
			// nudLineNumbersRightIndent
			// 
			this.nudLineNumbersRightIndent.Location = new System.Drawing.Point(304, 42);
			this.nudLineNumbersRightIndent.Name = "nudLineNumbersRightIndent";
			this.nudLineNumbersRightIndent.Size = new System.Drawing.Size(64, 20);
			this.nudLineNumbersRightIndent.TabIndex = 18;
			this.nudLineNumbersRightIndent.ValueChanged += new System.EventHandler(this.nudLineNumbersRightIndent_ValueChanged);
			// 
			// laLineNumbersLeftIndent
			// 
			this.laLineNumbersLeftIndent.AutoSize = true;
			this.laLineNumbersLeftIndent.Location = new System.Drawing.Point(232, 21);
			this.laLineNumbersLeftIndent.Name = "laLineNumbersLeftIndent";
			this.laLineNumbersLeftIndent.Size = new System.Drawing.Size(58, 16);
			this.laLineNumbersLeftIndent.TabIndex = 15;
			this.laLineNumbersLeftIndent.Text = "Left Indent";
			// 
			// nudLineNumbersLeftIndent
			// 
			this.nudLineNumbersLeftIndent.Location = new System.Drawing.Point(304, 18);
			this.nudLineNumbersLeftIndent.Name = "nudLineNumbersLeftIndent";
			this.nudLineNumbersLeftIndent.Size = new System.Drawing.Size(64, 20);
			this.nudLineNumbersLeftIndent.TabIndex = 17;
			this.nudLineNumbersLeftIndent.ValueChanged += new System.EventHandler(this.nudLineNumbersLeftIndent_ValueChanged);
			// 
			// cbLineNumbersAlign
			// 
			this.cbLineNumbersAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLineNumbersAlign.ItemHeight = 13;
			this.cbLineNumbersAlign.Location = new System.Drawing.Point(156, 42);
			this.cbLineNumbersAlign.Name = "cbLineNumbersAlign";
			this.cbLineNumbersAlign.Size = new System.Drawing.Size(64, 21);
			this.cbLineNumbersAlign.TabIndex = 14;
			this.cbLineNumbersAlign.SelectedIndexChanged += new System.EventHandler(this.cbLineNumbersAlign_SelectedIndexChanged);
			// 
			// laLineNumbersRightIndent
			// 
			this.laLineNumbersRightIndent.AutoSize = true;
			this.laLineNumbersRightIndent.Location = new System.Drawing.Point(232, 45);
			this.laLineNumbersRightIndent.Name = "laLineNumbersRightIndent";
			this.laLineNumbersRightIndent.Size = new System.Drawing.Size(65, 16);
			this.laLineNumbersRightIndent.TabIndex = 16;
			this.laLineNumbersRightIndent.Text = "Right Indent";
			// 
			// laLineNumbersAlign
			// 
			this.laLineNumbersAlign.AutoSize = true;
			this.laLineNumbersAlign.Location = new System.Drawing.Point(112, 45);
			this.laLineNumbersAlign.Name = "laLineNumbersAlign";
			this.laLineNumbersAlign.Size = new System.Drawing.Size(29, 16);
			this.laLineNumbersAlign.TabIndex = 12;
			this.laLineNumbersAlign.Text = "Align";
			// 
			// chbLineNumbers
			// 
			this.chbLineNumbers.Location = new System.Drawing.Point(8, 16);
			this.chbLineNumbers.Name = "chbLineNumbers";
			this.chbLineNumbers.TabIndex = 9;
			this.chbLineNumbers.Text = "Line Numbers";
			this.chbLineNumbers.CheckedChanged += new System.EventHandler(this.chbLineNumbers_CheckedChanged);
			// 
			// chbLinesOnGutter
			// 
			this.chbLinesOnGutter.Location = new System.Drawing.Point(8, 40);
			this.chbLinesOnGutter.Name = "chbLinesOnGutter";
			this.chbLinesOnGutter.TabIndex = 10;
			this.chbLinesOnGutter.Text = "Lines on Gutter";
			this.chbLinesOnGutter.CheckedChanged += new System.EventHandler(this.chbLinesOnGutter_CheckedChanged);
			// 
			// laLineNumbersStart
			// 
			this.laLineNumbersStart.AutoSize = true;
			this.laLineNumbersStart.Location = new System.Drawing.Point(112, 21);
			this.laLineNumbersStart.Name = "laLineNumbersStart";
			this.laLineNumbersStart.Size = new System.Drawing.Size(28, 16);
			this.laLineNumbersStart.TabIndex = 11;
			this.laLineNumbersStart.Text = "Start";
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
			this.laDescription.Text = "This demo shows how to customize appearance of line numbers.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Gutter.Options = ((QWhale.Editor.GutterOptions)((QWhale.Editor.GutterOptions.PaintLineNumbers | QWhale.Editor.GutterOptions.PaintBookMarks)));
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 104);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(592, 214);
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
			this.ClientSize = new System.Drawing.Size(592, 318);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudLineNumbersStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLineNumbersRightIndent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLineNumbersLeftIndent)).EndInit();
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
			chbLineNumbers.Checked = (GutterOptions.PaintLineNumbers & syntaxEdit1.Gutter.Options) != 0;
			chbLinesOnGutter.Checked = (GutterOptions.PaintLinesOnGutter & syntaxEdit1.Gutter.Options) != 0;
			nudLineNumbersStart.Maximum = 10000;
			nudLineNumbersStart.Value = syntaxEdit1.Gutter.LineNumbersStart;
			string [] s = Enum.GetNames(typeof(StringAlignment));
			cbLineNumbersAlign.Items.AddRange(s);
			cbLineNumbersAlign.SelectedIndex = (int)syntaxEdit1.Gutter.LineNumbersAlignment;
			nudLineNumbersLeftIndent.Maximum = 10000;
			nudLineNumbersLeftIndent.Value = syntaxEdit1.Gutter.LineNumbersLeftIndent;
			nudLineNumbersRightIndent.Maximum = 10000;
			nudLineNumbersRightIndent.Value = syntaxEdit1.Gutter.LineNumbersRightIndent;
			cbLineNumbersForeColor.SelectedColor = syntaxEdit1.Gutter.LineNumbersForeColor;
			cbLineNumbersBackColor.SelectedColor = syntaxEdit1.Gutter.LineNumbersBackColor;
		}

		private void chbLineNumbers_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.Options = (chbLineNumbers.Checked ? syntaxEdit1.Gutter.Options 
				| GutterOptions.PaintLineNumbers : syntaxEdit1.Gutter.Options ^ GutterOptions.PaintLineNumbers);
		}

		private void chbLinesOnGutter_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.Options = (chbLinesOnGutter.Checked ? syntaxEdit1.Gutter.Options 
				| GutterOptions.PaintLinesOnGutter : syntaxEdit1.Gutter.Options ^ GutterOptions.PaintLinesOnGutter);
		}

		private void nudLineNumbersStart_ValueChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.LineNumbersStart = (int)nudLineNumbersStart.Value;
		}

		private void cbLineNumbersAlign_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.LineNumbersAlignment = (StringAlignment)cbLineNumbersAlign.SelectedIndex;
		}

		private void nudLineNumbersLeftIndent_ValueChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.LineNumbersLeftIndent = (int)nudLineNumbersLeftIndent.Value;
		}

		private void nudLineNumbersRightIndent_ValueChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.LineNumbersRightIndent = (int)nudLineNumbersRightIndent.Value;
		}

		private void cbLineNumbersForeColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.LineNumbersForeColor = cbLineNumbersForeColor.SelectedColor;
		}

		private void cbLineNumbersBackColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.LineNumbersBackColor = cbLineNumbersBackColor.SelectedColor;
		}
	}
}
