using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace LineStyles
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
		private System.Windows.Forms.Button btStart;
		private System.Windows.Forms.Button btStepOver;
		private System.Windows.Forms.Button btSetBreakpoint;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem cmStart;
		private System.Windows.Forms.MenuItem cmStepOver;
		private System.Windows.Forms.MenuItem cmSetBreakpoint;
		private System.Windows.Forms.Label laLineStyleColor;
		private System.Windows.Forms.CheckBox chbLineStyleBeyondEol;
		private QWhale.Common.ColorBox cbLineStyleColor;
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
			QWhale.Editor.LineStyle lineStyle1 = new QWhale.Editor.LineStyle();
			this.pnSettings = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chbLineStyleBeyondEol = new System.Windows.Forms.CheckBox();
			this.cbLineStyleColor = new QWhale.Common.ColorBox(this.components);
			this.laLineStyleColor = new System.Windows.Forms.Label();
			this.btSetBreakpoint = new System.Windows.Forms.Button();
			this.btStepOver = new System.Windows.Forms.Button();
			this.btStart = new System.Windows.Forms.Button();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.cmStart = new System.Windows.Forms.MenuItem();
			this.cmStepOver = new System.Windows.Forms.MenuItem();
			this.cmSetBreakpoint = new System.Windows.Forms.MenuItem();
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
			this.pnSettings.Size = new System.Drawing.Size(568, 96);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chbLineStyleBeyondEol);
			this.groupBox1.Controls.Add(this.cbLineStyleColor);
			this.groupBox1.Controls.Add(this.laLineStyleColor);
			this.groupBox1.Controls.Add(this.btSetBreakpoint);
			this.groupBox1.Controls.Add(this.btStepOver);
			this.groupBox1.Controls.Add(this.btStart);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 72);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Line Styles";
			// 
			// chbLineStyleBeyondEol
			// 
			this.chbLineStyleBeyondEol.Location = new System.Drawing.Point(296, 16);
			this.chbLineStyleBeyondEol.Name = "chbLineStyleBeyondEol";
			this.chbLineStyleBeyondEol.Size = new System.Drawing.Size(144, 24);
			this.chbLineStyleBeyondEol.TabIndex = 3;
			this.chbLineStyleBeyondEol.Text = "Line Style Beyond Eol";
			this.chbLineStyleBeyondEol.CheckedChanged += new System.EventHandler(this.chbLineStyleBeyondEol_CheckedChanged);
			// 
			// cbLineStyleColor
			// 
			this.cbLineStyleColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbLineStyleColor.Location = new System.Drawing.Point(392, 40);
			this.cbLineStyleColor.Name = "cbLineStyleColor";
			this.cbLineStyleColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbLineStyleColor.Size = new System.Drawing.Size(121, 21);
			this.cbLineStyleColor.TabIndex = 5;
			this.cbLineStyleColor.SelectedIndexChanged += new System.EventHandler(this.cbLineStyleColor_SelectedIndexChanged);
			// 
			// laLineStyleColor
			// 
			this.laLineStyleColor.AutoSize = true;
			this.laLineStyleColor.Location = new System.Drawing.Point(296, 43);
			this.laLineStyleColor.Name = "laLineStyleColor";
			this.laLineStyleColor.Size = new System.Drawing.Size(84, 16);
			this.laLineStyleColor.TabIndex = 4;
			this.laLineStyleColor.Text = "Line Style Color";
			// 
			// btSetBreakpoint
			// 
			this.btSetBreakpoint.Location = new System.Drawing.Point(168, 24);
			this.btSetBreakpoint.Name = "btSetBreakpoint";
			this.btSetBreakpoint.Size = new System.Drawing.Size(96, 23);
			this.btSetBreakpoint.TabIndex = 2;
			this.btSetBreakpoint.Text = "Set Breakpoint";
			this.btSetBreakpoint.Click += new System.EventHandler(this.btSetBreakpoint_Click);
			// 
			// btStepOver
			// 
			this.btStepOver.Enabled = false;
			this.btStepOver.Location = new System.Drawing.Point(88, 24);
			this.btStepOver.Name = "btStepOver";
			this.btStepOver.TabIndex = 1;
			this.btStepOver.Text = "Step Over";
			this.btStepOver.Click += new System.EventHandler(this.btStepOver_Click);
			// 
			// btStart
			// 
			this.btStart.Location = new System.Drawing.Point(8, 24);
			this.btStart.Name = "btStart";
			this.btStart.TabIndex = 0;
			this.btStart.Text = "Start";
			this.btStart.Click += new System.EventHandler(this.btStart_Click);
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
			this.laDescription.Text = "This demo shows how line styles can be applied to individual lines within edit co" +
				"ntrols\'s content.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			lineStyle1.ForeColor = System.Drawing.Color.Maroon;
			lineStyle1.ImageIndex = 12;
			lineStyle1.Name = "";
			this.syntaxEdit1.LinesStyles.AddRange(new QWhale.Editor.LineStyle[] {
																					lineStyle1});
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 96);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 222);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = @"public class Form1 : System.Windows.Forms.Form
{
	private void Form1_Load(object sender, System.EventArgs e)
	{
		chbLineNumbers.Checked = (GutterOptions.PaintLineNumbers & syntaxEdit1.Gutter.Options) != 0;
		chbLinesOnGutter.Checked = (GutterOptions.PaintLinesOnGutter & syntaxEdit1.Gutter.Options) != 0;
		nudLineNumbersStart.Maximum = 10000;
		nudLineNumbersStart.Value = syntaxEdit1.Gutter.LineNumbersStart;
		string [] s = Enum.GetNames(typeof(StringAlignment));
		cbLineNumbersAlign.Items.AddRange(s);
		cbLineNumbersAlign.SelectedIndex = (int)syntaxEdit1.Gutter.LineNumbersAlignment;
	}
}";
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
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.cmStart,
																						 this.cmStepOver,
																						 this.cmSetBreakpoint});
			// 
			// cmStart
			// 
			this.cmStart.Index = 0;
			this.cmStart.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.cmStart.Text = "Start";
			this.cmStart.Click += new System.EventHandler(this.cmStart_Click);
			// 
			// cmStepOver
			// 
			this.cmStepOver.Index = 1;
			this.cmStepOver.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.cmStepOver.Text = "Step Over";
			this.cmStepOver.Click += new System.EventHandler(this.cmStepOver_Click);
			// 
			// cmSetBreakpoint
			// 
			this.cmSetBreakpoint.Index = 2;
			this.cmSetBreakpoint.Shortcut = System.Windows.Forms.Shortcut.F9;
			this.cmSetBreakpoint.Text = "Set Breakpoint";
			this.cmSetBreakpoint.Click += new System.EventHandler(this.cmSetBreakpoint_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 318);
			this.ContextMenu = this.contextMenu1;
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

		private bool startDebug;
		private const int startLine = 3;
		private int endLine = 0;
		private int index;

		private void Debug()
		{
			index = 0;
			btStart.Text = startDebug ? "Start": "Stop";
			btStepOver.Enabled = !startDebug;
		}
		private void btStart_Click(object sender, System.EventArgs e)
		{
			Start();
		}
		private void Start()
		{
			syntaxEdit1.Source.LineStyles.ToggleLineStyle(startLine + index, 0);
			Debug();
			startDebug = !startDebug;
		}
		private void StepOver()
		{
			if (index < (endLine - startLine))
			{
				if (syntaxEdit1.Source.LineStyles.GetLineStyle(startLine + index) >= 0)
					syntaxEdit1.Source.LineStyles.ToggleLineStyle(startLine + index, 0);
				index++;
				syntaxEdit1.Source.LineStyles.ToggleLineStyle(startLine + index, 0);
			}
			else
			{
				syntaxEdit1.Source.LineStyles.ToggleLineStyle(startLine + index, 0);
				Debug();
				startDebug = !startDebug;
			}
		}
		private void SetBreakpoint()
		{
			syntaxEdit1.Source.BookMarks.ClearAllBookMarks();
			syntaxEdit1.Source.BookMarks.SetBookMark(syntaxEdit1.Position, 11);
		}

		private void btStepOver_Click(object sender, System.EventArgs e)
		{
			StepOver();
		}

		private void btSetBreakpoint_Click(object sender, System.EventArgs e)
		{
			SetBreakpoint();
		}

		private void cmStart_Click(object sender, System.EventArgs e)
		{
			Start();
		}

		private void cmStepOver_Click(object sender, System.EventArgs e)
		{
			StepOver();
		}

		private void cmSetBreakpoint_Click(object sender, System.EventArgs e)
		{
			SetBreakpoint();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			if (syntaxEdit1.LineStyles.Count > 0)
			{
				ILineStyle lStyle = syntaxEdit1.LinesStyles.GetLineStyle(0);
				chbLineStyleBeyondEol.Checked = (LineStyleOptions.BeyondEol & lStyle.Options) != 0;
				cbLineStyleColor.SelectedColor = lStyle.ForeColor;
			}
			endLine = syntaxEdit1.Lines.Count - 2;
		}

		private void chbLineStyleBeyondEol_CheckedChanged(object sender, System.EventArgs e)
		{
			if (syntaxEdit1.LineStyles.Count > 0)
			{
				ILineStyle lStyle = syntaxEdit1.LinesStyles.GetLineStyle(0);
				lStyle.Options = (chbLineStyleBeyondEol.Checked) ? lStyle.Options | LineStyleOptions.BeyondEol :
					lStyle.Options ^ LineStyleOptions.BeyondEol;
				syntaxEdit1.Invalidate();
			}		
		}

		private void cbLineStyleColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (syntaxEdit1.LineStyles.Count > 0)
			{
				ILineStyle lStyle = syntaxEdit1.LinesStyles.GetLineStyle(0);
				lStyle.ForeColor = cbLineStyleColor.SelectedColor;
				syntaxEdit1.Invalidate();
			}		
		}

	}
}
