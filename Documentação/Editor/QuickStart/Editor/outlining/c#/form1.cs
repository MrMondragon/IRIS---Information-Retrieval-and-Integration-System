using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace Outlining
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.GroupBox gbOutlining;
		private System.Windows.Forms.CheckBox chbAllowOutlining;
		private System.Windows.Forms.CheckBox chbDrawButtons;
		private System.Windows.Forms.CheckBox chbDrawLines;
		private System.Windows.Forms.CheckBox chbDrawOnGutter;
		private System.Windows.Forms.CheckBox chbShowHints;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private QWhale.Editor.TextSource textSource1;
		private QWhale.Editor.TextSource textSource2;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.ComboBox cbAutomatic;
		private QWhale.Syntax.Parser parser1;
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
			this.gbOutlining = new System.Windows.Forms.GroupBox();
			this.cbAutomatic = new System.Windows.Forms.ComboBox();
			this.chbAllowOutlining = new System.Windows.Forms.CheckBox();
			this.chbDrawButtons = new System.Windows.Forms.CheckBox();
			this.chbDrawLines = new System.Windows.Forms.CheckBox();
			this.chbDrawOnGutter = new System.Windows.Forms.CheckBox();
			this.chbShowHints = new System.Windows.Forms.CheckBox();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.textSource1 = new QWhale.Editor.TextSource(this.components);
			this.textSource2 = new QWhale.Editor.TextSource(this.components);
			this.parser1 = new QWhale.Syntax.Parser();
			this.pnSettings.SuspendLayout();
			this.gbOutlining.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.gbOutlining);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 104);
			this.pnSettings.TabIndex = 1;
			// 
			// gbOutlining
			// 
			this.gbOutlining.BackColor = System.Drawing.SystemColors.Control;
			this.gbOutlining.Controls.Add(this.cbAutomatic);
			this.gbOutlining.Controls.Add(this.chbAllowOutlining);
			this.gbOutlining.Controls.Add(this.chbDrawButtons);
			this.gbOutlining.Controls.Add(this.chbDrawLines);
			this.gbOutlining.Controls.Add(this.chbDrawOnGutter);
			this.gbOutlining.Controls.Add(this.chbShowHints);
			this.gbOutlining.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbOutlining.Location = new System.Drawing.Point(0, 28);
			this.gbOutlining.Name = "gbOutlining";
			this.gbOutlining.Size = new System.Drawing.Size(568, 76);
			this.gbOutlining.TabIndex = 10;
			this.gbOutlining.TabStop = false;
			this.gbOutlining.Text = "Outlining";
			// 
			// cbAutomatic
			// 
			this.cbAutomatic.Items.AddRange(new object[] {
															 "Automatic",
															 "Manual"});
			this.cbAutomatic.Location = new System.Drawing.Point(8, 16);
			this.cbAutomatic.Name = "cbAutomatic";
			this.cbAutomatic.Size = new System.Drawing.Size(96, 21);
			this.cbAutomatic.TabIndex = 0;
			this.cbAutomatic.Text = "Automatic";
			this.cbAutomatic.SelectedIndexChanged += new System.EventHandler(this.cbAutomatic_SelectedIndexChanged);
			// 
			// chbAllowOutlining
			// 
			this.chbAllowOutlining.BackColor = System.Drawing.SystemColors.Control;
			this.chbAllowOutlining.Location = new System.Drawing.Point(8, 40);
			this.chbAllowOutlining.Name = "chbAllowOutlining";
			this.chbAllowOutlining.TabIndex = 1;
			this.chbAllowOutlining.Text = "Allow Outlining";
			this.chbAllowOutlining.CheckedChanged += new System.EventHandler(this.chbAllowOutlining_CheckedChanged);
			// 
			// chbDrawButtons
			// 
			this.chbDrawButtons.BackColor = System.Drawing.SystemColors.Control;
			this.chbDrawButtons.Location = new System.Drawing.Point(240, 16);
			this.chbDrawButtons.Name = "chbDrawButtons";
			this.chbDrawButtons.TabIndex = 4;
			this.chbDrawButtons.Text = "Draw Buttons";
			this.chbDrawButtons.CheckedChanged += new System.EventHandler(this.chbDrawButtons_CheckedChanged);
			// 
			// chbDrawLines
			// 
			this.chbDrawLines.BackColor = System.Drawing.SystemColors.Control;
			this.chbDrawLines.Location = new System.Drawing.Point(128, 40);
			this.chbDrawLines.Name = "chbDrawLines";
			this.chbDrawLines.TabIndex = 3;
			this.chbDrawLines.Text = "Draw Lines";
			this.chbDrawLines.CheckedChanged += new System.EventHandler(this.chbDrawLines_CheckedChanged);
			// 
			// chbDrawOnGutter
			// 
			this.chbDrawOnGutter.BackColor = System.Drawing.SystemColors.Control;
			this.chbDrawOnGutter.Location = new System.Drawing.Point(128, 16);
			this.chbDrawOnGutter.Name = "chbDrawOnGutter";
			this.chbDrawOnGutter.TabIndex = 2;
			this.chbDrawOnGutter.Text = "Draw on Gutter";
			this.chbDrawOnGutter.CheckedChanged += new System.EventHandler(this.chbDrawOnGutter_CheckedChanged);
			// 
			// chbShowHints
			// 
			this.chbShowHints.BackColor = System.Drawing.SystemColors.Control;
			this.chbShowHints.Location = new System.Drawing.Point(240, 40);
			this.chbShowHints.Name = "chbShowHints";
			this.chbShowHints.TabIndex = 5;
			this.chbShowHints.Text = "Show Hints";
			this.chbShowHints.CheckedChanged += new System.EventHandler(this.chbShowHints_CheckedChanged);
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(568, 28);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 28);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows how to use automatic and manual outlining for text fragments with" +
				"in edit conttrol\'s content.";
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
			this.syntaxEdit1.Outlining.AllowOutlining = true;
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 214);
			this.syntaxEdit1.Source = this.textSource1;
			this.syntaxEdit1.TabIndex = 2;
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
			// textSource1
			// 
			this.textSource1.Lexer = this.csParser1;
			this.textSource1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
			// 
			// textSource2
			// 
			this.textSource2.Lexer = this.parser1;
			this.textSource2.Text = @"[connect default]
;If we want to disable unknown connect values, we set Access to NoAccess
Access=NoAccess

[sql default]
;If we want to disable unknown sql values, we set Sql to an invalid query.
Sql="" ""

[connect CustomerDatabase]
Access=ReadWrite
Connect=""DSN=AdvWorks""

[sql CustomerById]
Sql=""SELECT * FROM Customers WHERE CustomerID = ?""

[connect AuthorDatabase]
Access=ReadOnly
Connect=""DSN=MyLibraryInfo;UID=MyUserID;PWD=MyPassword""

[userlist AuthorDatabase]
Administrator=ReadWrite

[sql AuthorById]
Sql=""SELECT * FROM Authors WHERE au_id = ?""";
			// 
			// parser1
			// 
			this.parser1.DefaultState = 0;
			this.parser1.XmlScheme = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<LexScheme xmlns:xsd=\"http://www.w3.org/" +
				"2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Autho" +
				"r>Quantum Whale</Author>\r\n  <Name>Ini files</Name>\r\n  <Desc>Syntax Scheme for In" +
				"i files</Desc>\r\n  <Copyright>Copyright Quantum Whale, 2003</Copyright>\r\n  <FileE" +
				"xtension>.ini</FileExtension>\r\n  <FileType>ini</FileType>\r\n  <Version>1.1</Versi" +
				"on>\r\n  <Styles>\r\n    <Style>\r\n      <Name>idents</Name>\r\n      <ForeColor>Contro" +
				"lText</ForeColor>\r\n      <Index>0</Index>\r\n    </Style>\r\n    <Style>\r\n      <Nam" +
				"e>comments</Name>\r\n      <ForeColor>Gray</ForeColor>\r\n      <FontStyle>Bold</Fon" +
				"tStyle>\r\n      <Index>1</Index>\r\n      <PlainText>true</PlainText>\r\n    </Style>" +
				"\r\n    <Style>\r\n      <Name>whitespace</Name>\r\n      <ForeColor>WindowText</ForeC" +
				"olor>\r\n      <Index>2</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>strings</N" +
				"ame>\r\n      <ForeColor>Maroon</ForeColor>\r\n      <Index>3</Index>\r\n    </Style>\r" +
				"\n  </Styles>\r\n  <States>\r\n    <State>\r\n      <Name>normal</Name>\r\n      <CaseSen" +
				"sitive>false</CaseSensitive>\r\n      <SyntaxBlocks>\r\n        <SyntaxBlock>\r\n     " +
				"     <Name>comments</Name>\r\n          <LexStyle>1</LexStyle>\r\n          <LeaveSt" +
				"ate>0</LeaveState>\r\n          <Expressions>\r\n            <string>\\;.*</string>\r\n" +
				"          </Expressions>\r\n          <Index>0</Index>\r\n        </SyntaxBlock>\r\n  " +
				"      <SyntaxBlock>\r\n          <Name>idents</Name>\r\n          <LexStyle>0</LexSt" +
				"yle>\r\n          <LeaveState>0</LeaveState>\r\n          <Expressions>\r\n           " +
				" <string>[a-zA-Z_][a-zA-Z0-9_]*</string>\r\n          </Expressions>\r\n          <I" +
				"ndex>1</Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>s" +
				"trings</Name>\r\n          <LexStyle>3</LexStyle>\r\n          <LeaveState>0</LeaveS" +
				"tate>\r\n          <Expressions>\r\n            <string>(\\[\\])|\\[(([^\\]]*\\])|([^\\]]*" +
				"))</string>\r\n            <string>(\"\")|\"(([^\"]*\")|([^\"]*))</string>\r\n          </" +
				"Expressions>\r\n          <Index>2</Index>\r\n        </SyntaxBlock>\r\n        <Synta" +
				"xBlock>\r\n          <Name>whitespace</Name>\r\n          <LexStyle>2</LexStyle>\r\n  " +
				"        <LeaveState>0</LeaveState>\r\n          <Expressions>\r\n            <string" +
				">(\\s)+</string>\r\n          </Expressions>\r\n          <Index>3</Index>\r\n        <" +
				"/SyntaxBlock>\r\n      </SyntaxBlocks>\r\n      <Index>0</Index>\r\n    </State>\r\n  </" +
				"States>\r\n</LexScheme>";
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
			this.gbOutlining.ResumeLayout(false);
			this.pnDescription.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private Timer timer = null;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void DoTimer(object sender, System.EventArgs e)
		{
			DoCustomOutlining();
			timer.Stop();
		}
		private Point PrevPosition(Point position)
		{
			Point pos = position;
			if (pos.Y > 0)
			{
				pos.Y--;
				pos.X = Math.Max(0, syntaxEdit1.Strings[pos.Y].Length - 1);
			}
			else
				pos.X--;
			return pos;
		}
		private void DoCustomOutlining()
		{
			Point oldPos = syntaxEdit1.Position;
			syntaxEdit1.Source.BeginUpdate();
			try
			{
				if (syntaxEdit1.Find(@"\[.*\]", SearchOptions.EntireScope | SearchOptions.RegularExpressions, new System.Text.RegularExpressions.Regex(@"\[.*\]", System.Text.RegularExpressions.RegexOptions.Singleline)))
				{
					ArrayList ranges = new ArrayList();
					Point start = syntaxEdit1.Position;
					while (syntaxEdit1.FindNext())
					{
						ranges.Add(new OutlineRange(start, PrevPosition(syntaxEdit1.Position), 0, "..."));
						start = syntaxEdit1.Position;
					}
					ranges.Add(new OutlineRange(start, new Point(syntaxEdit1.Lines[syntaxEdit1.Lines.Count - 1].Length, syntaxEdit1.Lines.Count - 1), 0, "..."));
					syntaxEdit1.Outlining.SetOutlineRanges(ranges);
				}	
				syntaxEdit1.Selection.Clear();
			}
			finally
			{
				syntaxEdit1.MoveTo(oldPos);
				syntaxEdit1.Source.EndUpdate();
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			timer = new Timer();
			timer.Interval = 500;
			timer.Tick += new EventHandler(DoTimer);
			chbAllowOutlining.Checked = syntaxEdit1.Outlining.AllowOutlining;
			chbDrawOnGutter.Checked = (OutlineOptions.DrawOnGutter & syntaxEdit1.Outlining.OutlineOptions) != 0;
			chbDrawLines.Checked = (OutlineOptions.DrawLines & syntaxEdit1.Outlining.OutlineOptions) != 0;
			chbDrawButtons.Checked = (OutlineOptions.DrawButtons & syntaxEdit1.Outlining.OutlineOptions) != 0;
			chbShowHints.Checked = (OutlineOptions.ShowHints & syntaxEdit1.Outlining.OutlineOptions) != 0;
		}

		private void chbAllowOutlining_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Outlining.AllowOutlining = chbAllowOutlining.Checked;
			if ((chbAllowOutlining.Checked) && (cbAutomatic.SelectedIndex != 0))
				DoCustomOutlining();
		}

		private void chbDrawOnGutter_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Outlining.OutlineOptions = (chbDrawOnGutter.Checked ? syntaxEdit1.Outlining.OutlineOptions 
				| OutlineOptions.DrawOnGutter : syntaxEdit1.Outlining.OutlineOptions ^ OutlineOptions.DrawOnGutter);
		}

		private void chbDrawLines_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Outlining.OutlineOptions = (chbDrawLines.Checked ? syntaxEdit1.Outlining.OutlineOptions 
				| OutlineOptions.DrawLines : syntaxEdit1.Outlining.OutlineOptions ^ OutlineOptions.DrawLines);
		}

		private void chbDrawButtons_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Outlining.OutlineOptions = (chbDrawButtons.Checked ? syntaxEdit1.Outlining.OutlineOptions 
				| OutlineOptions.DrawButtons: syntaxEdit1.Outlining.OutlineOptions ^ OutlineOptions.DrawButtons);
		}

		private void chbShowHints_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Outlining.OutlineOptions = (chbShowHints.Checked ? syntaxEdit1.Outlining.OutlineOptions 
				| OutlineOptions.ShowHints: syntaxEdit1.Outlining.OutlineOptions ^ OutlineOptions.ShowHints);
		}

		private void UpdateOutlining(bool automatic)
		{
			syntaxEdit1.Source = (automatic) ? textSource1 : textSource2;
			if (!automatic)
				DoCustomOutlining();
		}

		private void syntaxEdit1_SourceStateChanged(object sender, QWhale.Editor.NotifyEventArgs e)
		{
			if (syntaxEdit1.Source.Equals(textSource2))
			{
				if ((e.State & NotifyState.Edit) != 0)
					timer.Start();
			}
		}

		private void cbAutomatic_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateOutlining(cbAutomatic.SelectedIndex == 0);
		}
	}
}
