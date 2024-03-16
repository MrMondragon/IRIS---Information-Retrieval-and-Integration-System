using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace SyntaxParsing
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private QWhale.Syntax.Parser parser1;
		private System.Windows.Forms.Button btLoadScheme;
		private System.Windows.Forms.Button btSaveScheme;
		private System.Windows.Forms.Button btEditScheme;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
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
			this.btEditScheme = new System.Windows.Forms.Button();
			this.btSaveScheme = new System.Windows.Forms.Button();
			this.btLoadScheme = new System.Windows.Forms.Button();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.parser1 = new QWhale.Syntax.Parser();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
			this.pnSettings.Size = new System.Drawing.Size(568, 88);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btEditScheme);
			this.groupBox1.Controls.Add(this.btSaveScheme);
			this.groupBox1.Controls.Add(this.btLoadScheme);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 64);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Syntax Parsing";
			// 
			// btEditScheme
			// 
			this.btEditScheme.Location = new System.Drawing.Point(200, 24);
			this.btEditScheme.Name = "btEditScheme";
			this.btEditScheme.Size = new System.Drawing.Size(88, 23);
			this.btEditScheme.TabIndex = 11;
			this.btEditScheme.Text = "Edit Scheme";
			this.btEditScheme.Click += new System.EventHandler(this.btEditScheme_Click);
			// 
			// btSaveScheme
			// 
			this.btSaveScheme.Location = new System.Drawing.Point(104, 24);
			this.btSaveScheme.Name = "btSaveScheme";
			this.btSaveScheme.Size = new System.Drawing.Size(88, 23);
			this.btSaveScheme.TabIndex = 10;
			this.btSaveScheme.Text = "Save Scheme";
			this.btSaveScheme.Click += new System.EventHandler(this.btSaveScheme_Click);
			// 
			// btLoadScheme
			// 
			this.btLoadScheme.Location = new System.Drawing.Point(8, 24);
			this.btLoadScheme.Name = "btLoadScheme";
			this.btLoadScheme.Size = new System.Drawing.Size(88, 23);
			this.btLoadScheme.TabIndex = 9;
			this.btLoadScheme.Text = "Load Scheme";
			this.btLoadScheme.Click += new System.EventHandler(this.btLoadScheme_Click);
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
			this.laDescription.Text = "This demo shows how to apply different syntax schemes to highlight  edit control\'" +
				"s content.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.parser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 88);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 230);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = @"; for 16-bit app support
[fonts]
[extensions]
[mci extensions]
[files]
[Mail]
MAPI=1
[MCI Extensions.BAK]
aif=MPEGVideo
aifc=MPEGVideo
aiff=MPEGVideo
asf=MPEGVideo2
asx=MPEGVideo2
au=MPEGVideo
ivf=MPEGVideo2
m1v=MPEGVideo
m3u=MPEGVideo2
mp2=MPEGVideo
mp2v=MPEGVideo
mp3=MPEGVideo2
mpa=MPEGVideo
mpe=MPEGVideo
mpeg=MPEGVideo
mpg=MPEGVideo
mpv2=MPEGVideo
snd=MPEGVideo
wax=MPEGVideo2
wm=MPEGVideo2
wma=MPEGVideo2
wmp=MPEGVideo2
wmv=MPEGVideo2
wmx=MPEGVideo2
wvx=MPEGVideo2
[Dictionaries]
UserIndex=5e27ed35";
			// 
			// parser1
			// 
			this.parser1.DefaultState = 0;
			this.parser1.XmlScheme = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<LexScheme xmlns:xsd=\"http://www.w3.org/" +
				"2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Autho" +
				"r>Quantum Whale</Author>\r\n  <Name>Ini</Name>\r\n  <Desc>Syntax Scheme for Ini file" +
				"s</Desc>\r\n  <Copyright>Copyright Quantum Whale, 2003</Copyright>\r\n  <FileExtensi" +
				"on />\r\n  <FileType />\r\n  <Version>1.0</Version>\r\n  <Styles>\r\n    <Style>\r\n      " +
				"<Name>idents</Name>\r\n      <ForeColor>ControlText</ForeColor>\r\n      <Index>0</I" +
				"ndex>\r\n    </Style>\r\n    <Style>\r\n      <Name>comments</Name>\r\n      <ForeColor>" +
				"Gray</ForeColor>\r\n      <FontStyle>Bold</FontStyle>\r\n      <Index>1</Index>\r\n   " +
				"   <PlainText>true</PlainText>\r\n    </Style>\r\n    <Style>\r\n      <Name>whitespac" +
				"e</Name>\r\n      <ForeColor>WindowText</ForeColor>\r\n      <Index>2</Index>\r\n    <" +
				"/Style>\r\n    <Style>\r\n      <Name>strings</Name>\r\n      <ForeColor>Maroon</ForeC" +
				"olor>\r\n      <Index>3</Index>\r\n    </Style>\r\n  </Styles>\r\n  <States>\r\n    <State" +
				">\r\n      <Name>normal</Name>\r\n      <CaseSensitive>false</CaseSensitive>\r\n      " +
				"<SyntaxBlocks>\r\n        <SyntaxBlock>\r\n          <Name>comments</Name>\r\n        " +
				"  <LexStyle>1</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n          <Expre" +
				"ssions>\r\n            <string>\\;.*</string>\r\n          </Expressions>\r\n          " +
				"<Index>0</Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name" +
				">idents</Name>\r\n          <LexStyle>0</LexStyle>\r\n          <LeaveState>0</Leave" +
				"State>\r\n          <Expressions>\r\n            <string>[a-zA-Z_][a-zA-Z0-9_]*</str" +
				"ing>\r\n          </Expressions>\r\n          <Index>1</Index>\r\n        </SyntaxBloc" +
				"k>\r\n        <SyntaxBlock>\r\n          <Name>strings</Name>\r\n          <LexStyle>3" +
				"</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n          <Expressions>\r\n    " +
				"        <string>(\\[\\])|\\[(([^\\]]*\\])|([^\\]]*))</string>\r\n            <string>(\"\"" +
				")|\"(([^\"]*\")|([^\"]*))</string>\r\n          </Expressions>\r\n          <Index>2</In" +
				"dex>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>whitespace<" +
				"/Name>\r\n          <LexStyle>2</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n" +
				"          <Expressions>\r\n            <string>(\\s)+</string>\r\n          </Express" +
				"ions>\r\n          <Index>3</Index>\r\n        </SyntaxBlock>\r\n      </SyntaxBlocks>" +
				"\r\n      <Index>0</Index>\r\n    </State>\r\n  </States>\r\n</LexScheme>";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Xml files (*.xml)|*.xml";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Xml files (*.xml)|*.xml";
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

		private void btLoadScheme_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
				parser1.LoadScheme(this.openFileDialog1.FileName);
		}

		private void btSaveScheme_Click(object sender, System.EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				parser1.SaveScheme(saveFileDialog1.FileName);
		}

		private void btEditScheme_Click(object sender, System.EventArgs e)
		{
			QWhale.Design.Dialogs.DlgSyntaxBuilder dlg = new QWhale.Design.Dialogs.DlgSyntaxBuilder();
			dlg.Scheme = (LexScheme)parser1.Scheme;
			if (dlg.ShowDialog() == DialogResult.OK)
				parser1.Scheme = dlg.Scheme;
		}

		private string Dir = Application.StartupPath + @"\..\..\..\..\..\..\";

		private void Form1_Load(object sender, System.EventArgs e)
		{
			openFileDialog1.InitialDirectory = Dir + @"schemes\";
			saveFileDialog1.InitialDirectory = Dir + @"schemes\";
		}
	}
}
