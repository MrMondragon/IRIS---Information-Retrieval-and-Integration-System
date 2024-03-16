using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace Hypertext
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.CheckBox chbHighlightUrls;
		private QWhale.Common.ColorBox cbUrlColor;
		private System.Windows.Forms.Label laUrlColor;
		private System.Windows.Forms.CheckBox chbCustomHypertext;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.Label laFontStyle;
		private System.Windows.Forms.ComboBox cbFontStyle;
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
			this.laFontStyle = new System.Windows.Forms.Label();
			this.cbFontStyle = new System.Windows.Forms.ComboBox();
			this.chbCustomHypertext = new System.Windows.Forms.CheckBox();
			this.laUrlColor = new System.Windows.Forms.Label();
			this.cbUrlColor = new QWhale.Common.ColorBox(this.components);
			this.chbHighlightUrls = new System.Windows.Forms.CheckBox();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.parser1 = new QWhale.Syntax.Parser();
			this.pnSettings.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.laFontStyle);
			this.pnSettings.Controls.Add(this.cbFontStyle);
			this.pnSettings.Controls.Add(this.chbCustomHypertext);
			this.pnSettings.Controls.Add(this.laUrlColor);
			this.pnSettings.Controls.Add(this.cbUrlColor);
			this.pnSettings.Controls.Add(this.chbHighlightUrls);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 104);
			this.pnSettings.TabIndex = 1;
			// 
			// laFontStyle
			// 
			this.laFontStyle.AutoSize = true;
			this.laFontStyle.Location = new System.Drawing.Point(128, 69);
			this.laFontStyle.Name = "laFontStyle";
			this.laFontStyle.Size = new System.Drawing.Size(55, 16);
			this.laFontStyle.TabIndex = 3;
			this.laFontStyle.Text = "Font Style";
			// 
			// cbFontStyle
			// 
			this.cbFontStyle.Location = new System.Drawing.Point(192, 66);
			this.cbFontStyle.Name = "cbFontStyle";
			this.cbFontStyle.Size = new System.Drawing.Size(121, 21);
			this.cbFontStyle.TabIndex = 5;
			this.cbFontStyle.Text = "Regular";
			this.cbFontStyle.SelectedIndexChanged += new System.EventHandler(this.cbFontStyle_SelectedIndexChanged);
			// 
			// chbCustomHypertext
			// 
			this.chbCustomHypertext.Location = new System.Drawing.Point(8, 64);
			this.chbCustomHypertext.Name = "chbCustomHypertext";
			this.chbCustomHypertext.Size = new System.Drawing.Size(120, 24);
			this.chbCustomHypertext.TabIndex = 1;
			this.chbCustomHypertext.Text = "Custom Hypertext";
			this.chbCustomHypertext.CheckedChanged += new System.EventHandler(this.chbCustomHypertext_CheckedChanged);
			// 
			// laUrlColor
			// 
			this.laUrlColor.AutoSize = true;
			this.laUrlColor.Location = new System.Drawing.Point(128, 45);
			this.laUrlColor.Name = "laUrlColor";
			this.laUrlColor.Size = new System.Drawing.Size(49, 16);
			this.laUrlColor.TabIndex = 2;
			this.laUrlColor.Text = "Url Color";
			// 
			// cbUrlColor
			// 
			this.cbUrlColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbUrlColor.Location = new System.Drawing.Point(192, 42);
			this.cbUrlColor.Name = "cbUrlColor";
			this.cbUrlColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbUrlColor.Size = new System.Drawing.Size(121, 21);
			this.cbUrlColor.TabIndex = 4;
			this.cbUrlColor.SelectedIndexChanged += new System.EventHandler(this.cbUrlColor_SelectedIndexChanged);
			// 
			// chbHighlightUrls
			// 
			this.chbHighlightUrls.Checked = true;
			this.chbHighlightUrls.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbHighlightUrls.Location = new System.Drawing.Point(8, 40);
			this.chbHighlightUrls.Name = "chbHighlightUrls";
			this.chbHighlightUrls.Size = new System.Drawing.Size(96, 24);
			this.chbHighlightUrls.TabIndex = 0;
			this.chbHighlightUrls.Text = "Highlight Urls";
			this.chbHighlightUrls.CheckedChanged += new System.EventHandler(this.chbHighlightUrls_CheckedChanged);
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
			this.laDescription.Text = "This demo shows how to handle hypertext sections inside the Edit control\'s conten" +
				"t.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.HyperText.HighlightUrls = true;
			this.syntaxEdit1.Lexer = this.parser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 104);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 214);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = @"[Common]
Url=""http://www.qwhale.net""
MailTo=""mailto:contact@qwhale.net""
[Contents.Server]
00000001=0
00000002=0
[Server.00000001]
Title=FTP Server
Protocol=TCP
Port=21
InternalPort=21
BuiltIn=1
[Server.00000002]
Title=Telnet Server
Protocol=TCP
Port=23
InternalPort=23
BuiltIn=1
[Server.00000003]
Title=Internet Mail Server (SMTP)
Protocol=TCP
Port=25
InternalPort=25
BuiltIn=1
[Server.00000004]
Title=Post-Office Protocol Version 3 (POP3)
Protocol=TCP
Port=110
InternalPort=110
BuiltIn=1";
			this.syntaxEdit1.CheckHyperText += new QWhale.Editor.HyperTextEvent(this.syntaxEdit1_CheckHyperText);
			this.syntaxEdit1.JumpToUrl += new QWhale.Editor.UrlJumpEvent(this.syntaxEdit1_JumpToUrl);
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
			chbHighlightUrls.Checked = syntaxEdit1.HyperText.HighlightUrls;
			cbUrlColor.SelectedColor = syntaxEdit1.HyperText.UrlColor;
			string [] s = Enum.GetNames(typeof(FontStyle));
			cbFontStyle.Items.AddRange(s);
			cbFontStyle.SelectedItem = syntaxEdit1.HyperText.UrlStyle.ToString();
		}

		private void chbHighlightUrls_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.HyperText.HighlightUrls = chbHighlightUrls.Checked;
		}

		private void chbCustomHypertext_CheckedChanged(object sender, System.EventArgs e)
		{
			Hashtable hs = ((TextSource)syntaxEdit1.Source).UrlTable;
			if (chbCustomHypertext.Checked)
			{
				hs.Add('[', true);
				hs.Add(']', false);
			}
			else
			{
				hs.Remove('[');
				hs.Remove(']');
			}
			syntaxEdit1.Source.Notification(syntaxEdit1.Lexer, EventArgs.Empty);
		}
		private void cbUrlColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.HyperText.UrlColor = cbUrlColor.SelectedColor;
		}
		private void syntaxEdit1_JumpToUrl(object sender, QWhale.Editor.UrlJumpEventArgs e)
		{
			if (chbCustomHypertext.Checked)
			{
				MessageBox.Show(e.Text);
				e.Handled = true;
			}
		}
		private void cbFontStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			object obj = Enum.Parse(typeof(FontStyle), cbFontStyle.Text);
			if ((obj != null) && (obj is FontStyle))
				syntaxEdit1.HyperText.UrlStyle = (FontStyle)obj;
		}
		private void syntaxEdit1_CheckHyperText(object sender, QWhale.Editor.HyperTextEventArgs e)
		{
			if (chbCustomHypertext.Checked)
				e.IsHyperText = e.Text.IndexOf("[") >= 0;
		}
	}
}
