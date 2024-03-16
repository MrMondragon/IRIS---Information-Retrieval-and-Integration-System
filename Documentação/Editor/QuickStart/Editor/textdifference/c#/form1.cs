using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;
using my.utils;

namespace TextDifference
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
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btRefresh;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btOpenLeftFile;
		private System.Windows.Forms.TextBox tbLeftSourceFile;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel panel5;
		private QWhale.Editor.SyntaxEdit syntaxEdit2;
		private System.Windows.Forms.Button btOpenRightFile;
		private System.Windows.Forms.TextBox tbRightSourceFile;
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
			QWhale.Editor.LineStyle lineStyle2 = new QWhale.Editor.LineStyle();
			QWhale.Editor.LineStyle lineStyle3 = new QWhale.Editor.LineStyle();
			QWhale.Editor.LineStyle lineStyle4 = new QWhale.Editor.LineStyle();
			QWhale.Editor.LineStyle lineStyle5 = new QWhale.Editor.LineStyle();
			QWhale.Editor.LineStyle lineStyle6 = new QWhale.Editor.LineStyle();
			this.pnSettings = new System.Windows.Forms.Panel();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btRefresh = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btOpenLeftFile = new System.Windows.Forms.Button();
			this.tbLeftSourceFile = new System.Windows.Forms.TextBox();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.panel5 = new System.Windows.Forms.Panel();
			this.syntaxEdit2 = new QWhale.Editor.SyntaxEdit(this.components);
			this.btOpenRightFile = new System.Windows.Forms.Button();
			this.tbRightSourceFile = new System.Windows.Forms.TextBox();
			this.pnSettings.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.panel3);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(936, 56);
			this.pnSettings.TabIndex = 1;
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(936, 24);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(936, 24);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo project shows how to use syntax editor to highlight differences between" +
				" source codes.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.syntaxEdit1);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 56);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(448, 446);
			this.panel1.TabIndex = 3;
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
			// panel2
			// 
			this.panel2.Controls.Add(this.syntaxEdit2);
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(448, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(488, 446);
			this.panel2.TabIndex = 4;
			// 
			// splitter1
			// 
			this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitter1.Location = new System.Drawing.Point(448, 56);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(5, 446);
			this.splitter1.TabIndex = 5;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.btRefresh);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 24);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(936, 32);
			this.panel3.TabIndex = 9;
			// 
			// btRefresh
			// 
			this.btRefresh.Location = new System.Drawing.Point(8, 4);
			this.btRefresh.Name = "btRefresh";
			this.btRefresh.TabIndex = 0;
			this.btRefresh.Text = "Refresh";
			this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btOpenLeftFile);
			this.panel4.Controls.Add(this.tbLeftSourceFile);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(448, 30);
			this.panel4.TabIndex = 5;
			// 
			// btOpenLeftFile
			// 
			this.btOpenLeftFile.Location = new System.Drawing.Point(416, 4);
			this.btOpenLeftFile.Name = "btOpenLeftFile";
			this.btOpenLeftFile.Size = new System.Drawing.Size(24, 21);
			this.btOpenLeftFile.TabIndex = 6;
			this.btOpenLeftFile.Text = "...";
			this.btOpenLeftFile.Click += new System.EventHandler(this.btOpenLeftFile_Click);
			// 
			// tbLeftSourceFile
			// 
			this.tbLeftSourceFile.Location = new System.Drawing.Point(8, 4);
			this.tbLeftSourceFile.Name = "tbLeftSourceFile";
			this.tbLeftSourceFile.Size = new System.Drawing.Size(408, 20);
			this.tbLeftSourceFile.TabIndex = 5;
			this.tbLeftSourceFile.Text = "";
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			lineStyle1.ForeColor = System.Drawing.Color.Red;
			lineStyle1.Name = "";
			lineStyle1.Options = ((QWhale.Editor.LineStyleOptions)((QWhale.Editor.LineStyleOptions.BeyondEol | QWhale.Editor.LineStyleOptions.InvertColors)));
			lineStyle1.PenColor = System.Drawing.Color.Empty;
			lineStyle2.ForeColor = System.Drawing.Color.Orange;
			lineStyle2.Name = "";
			lineStyle2.Options = ((QWhale.Editor.LineStyleOptions)((QWhale.Editor.LineStyleOptions.BeyondEol | QWhale.Editor.LineStyleOptions.InvertColors)));
			lineStyle2.PenColor = System.Drawing.Color.Empty;
			lineStyle3.ForeColor = System.Drawing.SystemColors.ControlDark;
			lineStyle3.Name = "";
			lineStyle3.Options = ((QWhale.Editor.LineStyleOptions)((QWhale.Editor.LineStyleOptions.BeyondEol | QWhale.Editor.LineStyleOptions.InvertColors)));
			lineStyle3.PenColor = System.Drawing.Color.Empty;
			this.syntaxEdit1.LinesStyles.AddRange(new QWhale.Editor.LineStyle[] {
																					lineStyle1,
																					lineStyle2,
																					lineStyle3});
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 30);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(448, 416);
			this.syntaxEdit1.TabIndex = 6;
			this.syntaxEdit1.Text = @" using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace TextDifference
{
	public class Form1 : System.Windows.Forms.Form
	{
		public Form1()
		{

			InitializeComponent();
		}
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());///
		}
	}
}";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btOpenRightFile);
			this.panel5.Controls.Add(this.tbRightSourceFile);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(488, 30);
			this.panel5.TabIndex = 1;
			// 
			// syntaxEdit2
			// 
			this.syntaxEdit2.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit2.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit2.Lexer = this.csParser1;
			lineStyle4.ForeColor = System.Drawing.Color.Red;
			lineStyle4.Name = "";
			lineStyle4.Options = ((QWhale.Editor.LineStyleOptions)((QWhale.Editor.LineStyleOptions.BeyondEol | QWhale.Editor.LineStyleOptions.InvertColors)));
			lineStyle4.PenColor = System.Drawing.Color.Empty;
			lineStyle5.ForeColor = System.Drawing.Color.Orange;
			lineStyle5.Name = "";
			lineStyle5.Options = ((QWhale.Editor.LineStyleOptions)((QWhale.Editor.LineStyleOptions.BeyondEol | QWhale.Editor.LineStyleOptions.InvertColors)));
			lineStyle5.PenColor = System.Drawing.Color.Empty;
			lineStyle6.ForeColor = System.Drawing.SystemColors.ControlDark;
			lineStyle6.Name = "";
			lineStyle6.Options = ((QWhale.Editor.LineStyleOptions)((QWhale.Editor.LineStyleOptions.BeyondEol | QWhale.Editor.LineStyleOptions.InvertColors)));
			lineStyle6.PenColor = System.Drawing.Color.Empty;
			this.syntaxEdit2.LinesStyles.AddRange(new QWhale.Editor.LineStyle[] {
																					lineStyle4,
																					lineStyle5,
																					lineStyle6});
			this.syntaxEdit2.Location = new System.Drawing.Point(0, 30);
			this.syntaxEdit2.Name = "syntaxEdit2";
			this.syntaxEdit2.Size = new System.Drawing.Size(488, 416);
			this.syntaxEdit2.TabIndex = 2;
			this.syntaxEdit2.Text = @"using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace TextDifference
{
	public class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}";
			// 
			// btOpenRightFile
			// 
			this.btOpenRightFile.Location = new System.Drawing.Point(456, 4);
			this.btOpenRightFile.Name = "btOpenRightFile";
			this.btOpenRightFile.Size = new System.Drawing.Size(24, 21);
			this.btOpenRightFile.TabIndex = 6;
			this.btOpenRightFile.Text = "...";
			this.btOpenRightFile.Click += new System.EventHandler(this.btOpenRightFile_Click);
			// 
			// tbRightSourceFile
			// 
			this.tbRightSourceFile.Location = new System.Drawing.Point(16, 4);
			this.tbRightSourceFile.Name = "tbRightSourceFile";
			this.tbRightSourceFile.Size = new System.Drawing.Size(440, 20);
			this.tbRightSourceFile.TabIndex = 5;
			this.tbRightSourceFile.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(936, 502);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.pnDescription.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
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
			ProcessDifferences();
		}
		private void PrepareLines()
		{
			IStrItem item = null;
			for (int i = syntaxEdit1.Lines.Count - 1; i >= 0; i--)
			{
				item = syntaxEdit1.Lines.GetItem(i);
				if ((item.State & StrItemState.Readonly) != 0)
					syntaxEdit1.Lines.RemoveAt(i);
			}
			for (int i = syntaxEdit2.Lines.Count - 1; i >= 0; i--)
			{
				item = syntaxEdit2.Lines.GetItem(i);
				if ((item.State & StrItemState.Readonly) != 0)
					syntaxEdit2.Lines.RemoveAt(i);
			}
		}
		private void ProcessDifferences()
		{
			syntaxEdit1.Lines.BeginUpdate();
			syntaxEdit2.Lines.BeginUpdate();
			try
			{
				PrepareLines();
				string s1 = syntaxEdit1.Lines.Text;
				string s2 = syntaxEdit2.Lines.Text;
				Diff.Item [] f = Diff.DiffText(s1, s2, true, true, false);

				int n = 0;
				int styleIndex = -1;
				int offsetA = 0;
				int offsetB = 0;
				int readOnlyIndex = -1;
				for (int fdx = 0; fdx < f.Length; fdx++) 
				{
					Diff.Item aItem = f[fdx];
					styleIndex = (aItem.deletedA == aItem.insertedB) ? 0 : 1;

					n = aItem.StartB;

					for (int m = 0; m < aItem.deletedA; m++) 
						syntaxEdit1.Source.LineStyles.SetLineStyle(aItem.StartA + m + offsetA, styleIndex);
					while (n < aItem.StartB + aItem.insertedB) 
					{
						syntaxEdit2.Source.LineStyles.SetLineStyle(n + offsetB, styleIndex);
						n++;
					}

					if (aItem.deletedA > aItem.insertedB)
					{
						readOnlyIndex = aItem.StartB + offsetB;
						for (int m = 0; m < aItem.deletedA - aItem.insertedB; m++) 
						{
							syntaxEdit2.Lines.Insert(readOnlyIndex, string.Empty);
							syntaxEdit2.Source.LineStyles.SetLineStyle(readOnlyIndex, 2);
							syntaxEdit2.Source.SetLineReadonly(readOnlyIndex, true);
							offsetB++;
							readOnlyIndex++;
						}
					}
					if (aItem.insertedB > aItem.deletedA)
					{
						readOnlyIndex = aItem.StartA + offsetA;
						for (int m = 0; m < aItem.insertedB - aItem.deletedA; m++) 
						{
							syntaxEdit1.Lines.Insert(readOnlyIndex, string.Empty);
							syntaxEdit1.Source.LineStyles.SetLineStyle(readOnlyIndex, 2);
							syntaxEdit1.Source.SetLineReadonly(readOnlyIndex, true);
							offsetA++;
							readOnlyIndex++;
						}
					}
				}
			}
			finally
			{
				syntaxEdit1.Lines.EndUpdate();
				syntaxEdit2.Lines.EndUpdate();
			}
		}

		private void btOpenLeftFile_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				tbLeftSourceFile.Text = openFileDialog1.FileName;
				syntaxEdit1.LoadFile(openFileDialog1.FileName);
			}
		}

		private void btOpenRightFile_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				tbRightSourceFile.Text = openFileDialog1.FileName;
				syntaxEdit2.LoadFile(openFileDialog1.FileName);
			}		
		}

		private void btRefresh_Click(object sender, System.EventArgs e)
		{
			ProcessDifferences();
		}
	}
}
