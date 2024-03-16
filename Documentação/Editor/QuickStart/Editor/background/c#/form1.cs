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

namespace Background
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chbTransparent;
		private System.Windows.Forms.ComboBox cbBackgroundStyle;
		private System.Windows.Forms.Label laBackgroundStyle;
		private System.Windows.Forms.Label laGradientBeginColor;
		private System.Windows.Forms.Label laGradientEndColor;
		private QWhale.Common.ColorBox cbGradientBeginColor;
		private QWhale.Common.ColorBox cbGradientEndColor;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.pnSettings = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbGradientEndColor = new QWhale.Common.ColorBox(this.components);
			this.cbGradientBeginColor = new QWhale.Common.ColorBox(this.components);
			this.laGradientEndColor = new System.Windows.Forms.Label();
			this.laGradientBeginColor = new System.Windows.Forms.Label();
			this.laBackgroundStyle = new System.Windows.Forms.Label();
			this.cbBackgroundStyle = new System.Windows.Forms.ComboBox();
			this.chbTransparent = new System.Windows.Forms.CheckBox();
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
			this.pnSettings.Size = new System.Drawing.Size(568, 112);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbGradientEndColor);
			this.groupBox1.Controls.Add(this.cbGradientBeginColor);
			this.groupBox1.Controls.Add(this.laGradientEndColor);
			this.groupBox1.Controls.Add(this.laGradientBeginColor);
			this.groupBox1.Controls.Add(this.laBackgroundStyle);
			this.groupBox1.Controls.Add(this.cbBackgroundStyle);
			this.groupBox1.Controls.Add(this.chbTransparent);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 88);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Background";
			// 
			// cbGradientEndColor
			// 
			this.cbGradientEndColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbGradientEndColor.Location = new System.Drawing.Point(376, 56);
			this.cbGradientEndColor.Name = "cbGradientEndColor";
			this.cbGradientEndColor.SelectedColor = System.Drawing.Color.White;
			this.cbGradientEndColor.Size = new System.Drawing.Size(121, 21);
			this.cbGradientEndColor.TabIndex = 13;
			this.cbGradientEndColor.SelectedIndexChanged += new System.EventHandler(this.cbBackgroundStyle_SelectedIndexChanged);
			// 
			// cbGradientBeginColor
			// 
			this.cbGradientBeginColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbGradientBeginColor.Location = new System.Drawing.Point(376, 24);
			this.cbGradientBeginColor.Name = "cbGradientBeginColor";
			this.cbGradientBeginColor.SelectedColor = System.Drawing.Color.Blue;
			this.cbGradientBeginColor.Size = new System.Drawing.Size(121, 21);
			this.cbGradientBeginColor.TabIndex = 12;
			this.cbGradientBeginColor.SelectedIndexChanged += new System.EventHandler(this.cbBackgroundStyle_SelectedIndexChanged);
			// 
			// laGradientEndColor
			// 
			this.laGradientEndColor.AutoSize = true;
			this.laGradientEndColor.Location = new System.Drawing.Point(256, 56);
			this.laGradientEndColor.Name = "laGradientEndColor";
			this.laGradientEndColor.Size = new System.Drawing.Size(101, 16);
			this.laGradientEndColor.TabIndex = 11;
			this.laGradientEndColor.Text = "Gradient End Color";
			// 
			// laGradientBeginColor
			// 
			this.laGradientBeginColor.AutoSize = true;
			this.laGradientBeginColor.Location = new System.Drawing.Point(256, 24);
			this.laGradientBeginColor.Name = "laGradientBeginColor";
			this.laGradientBeginColor.Size = new System.Drawing.Size(110, 16);
			this.laGradientBeginColor.TabIndex = 10;
			this.laGradientBeginColor.Text = "Gradient Begin Color";
			// 
			// laBackgroundStyle
			// 
			this.laBackgroundStyle.AutoSize = true;
			this.laBackgroundStyle.Location = new System.Drawing.Point(16, 59);
			this.laBackgroundStyle.Name = "laBackgroundStyle";
			this.laBackgroundStyle.Size = new System.Drawing.Size(93, 16);
			this.laBackgroundStyle.TabIndex = 9;
			this.laBackgroundStyle.Text = "Background Style";
			// 
			// cbBackgroundStyle
			// 
			this.cbBackgroundStyle.Items.AddRange(new object[] {
																   "Background Image",
																   "Gradient",
																   "Theme Background"});
			this.cbBackgroundStyle.Location = new System.Drawing.Point(120, 56);
			this.cbBackgroundStyle.Name = "cbBackgroundStyle";
			this.cbBackgroundStyle.Size = new System.Drawing.Size(121, 21);
			this.cbBackgroundStyle.TabIndex = 8;
			this.cbBackgroundStyle.Text = "Background Image";
			this.cbBackgroundStyle.SelectedIndexChanged += new System.EventHandler(this.cbBackgroundStyle_SelectedIndexChanged);
			// 
			// chbTransparent
			// 
			this.chbTransparent.Checked = true;
			this.chbTransparent.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbTransparent.Location = new System.Drawing.Point(16, 28);
			this.chbTransparent.Name = "chbTransparent";
			this.chbTransparent.Size = new System.Drawing.Size(112, 16);
			this.chbTransparent.TabIndex = 7;
			this.chbTransparent.Text = "Transparent";
			this.chbTransparent.CheckedChanged += new System.EventHandler(this.chbTransparent_CheckedChanged);
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(568, 24);
			this.pnDescription.TabIndex = 7;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 24);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows how to paint edit control\'s background.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("syntaxEdit1.BackgroundImage")));
			this.syntaxEdit1.BorderStyle = QWhale.Common.EditBorderStyle.System;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 112);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 206);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
			this.syntaxEdit1.Transparent = true;
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
			this.Text = "Background";
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

		private void chbTransparent_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Transparent = chbTransparent.Checked;
		}
		private void syntaxEdit1_PaintBackground(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			switch (cbBackgroundStyle.SelectedIndex)
			{
				case 0 :
				{
					// do nothing, painting background image specified by BackgroundImage property
					break;
				}
				case 1 :
				{
					// painting gradient using linear gradient brush
					Rectangle r = syntaxEdit1.ClientRect;
					e.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(r.Location, new Point(r.Right, r.Bottom), cbGradientBeginColor.SelectedColor, cbGradientEndColor.SelectedColor), r); 
					break;
				}
				case 2 :
				{
					// painthing theme background
					IPainter painter = new GdiPainter();
					painter.BeginPaint(e.Graphics);
					try
					{
						Rectangle r = syntaxEdit1.ClientRect;
						XPThemes.DrawBackground(painter, r, cbGradientBeginColor.SelectedColor, cbGradientEndColor.SelectedColor);
					}
					finally
					{
						painter.EndPaint();
					}
					break;
				}
			}
		}
		private void cbBackgroundStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Invalidate();
		}
	}
}
