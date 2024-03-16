using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace CodeCompletion
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
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbAutomatic;
		private System.Windows.Forms.RadioButton rbManual;
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
			this.rbManual = new System.Windows.Forms.RadioButton();
			this.rbAutomatic = new System.Windows.Forms.RadioButton();
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
			this.pnSettings.Size = new System.Drawing.Size(640, 112);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbManual);
			this.groupBox1.Controls.Add(this.rbAutomatic);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(640, 72);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Code Completion";
			// 
			// rbManual
			// 
			this.rbManual.Location = new System.Drawing.Point(16, 40);
			this.rbManual.Name = "rbManual";
			this.rbManual.TabIndex = 1;
			this.rbManual.Text = "Manual";
			// 
			// rbAutomatic
			// 
			this.rbAutomatic.Checked = true;
			this.rbAutomatic.Location = new System.Drawing.Point(16, 16);
			this.rbAutomatic.Name = "rbAutomatic";
			this.rbAutomatic.TabIndex = 0;
			this.rbAutomatic.TabStop = true;
			this.rbAutomatic.Text = "Automatic";
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(640, 40);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(640, 40);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "The demo project shows ability to display intellisense listboxes and hints. Type " +
				"Ctrl + Space somewhere in the code, or type \".\" or \"(\" after identifier.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.ColumnsIndentForeColor = System.Drawing.SystemColors.Desktop;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.DrawColumnsIndent = true;
			this.syntaxEdit1.EditMargin.ColumnPositions = new int[] {
																		16};
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 112);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Outlining.AllowOutlining = true;
			this.syntaxEdit1.Size = new System.Drawing.Size(640, 342);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = @"using System;

public class MainClass 
{
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	static void Main() 
	{
		this.TestMethod( //<- Press CTRL+SHIFT+Space after ""("" to display the tooltip containing method description.
	}
	/// <summary>
	/// This is public method with two parameters.
	/// </summary>
	/// <param name=""index"">Integer parameter.</param>
	/// <param name=""ignore"">Boolean parameter.</param>
	public void TestMethod(int index, bool ignore)
	{
		this. //<- Press CTRL+Space to display the intellisense list box.
	}
}";
			this.syntaxEdit1.NeedCodeCompletion += new QWhale.Editor.CodeCompletionEvent(this.syntaxEdit1_NeedCodeCompletion);
			// 
			// csParser1
			// 
			this.csParser1.DefaultState = 0;
			this.csParser1.Options = ((QWhale.Syntax.SyntaxOptions)(((((QWhale.Syntax.SyntaxOptions.Outline | QWhale.Syntax.SyntaxOptions.SmartIndent) 
				| QWhale.Syntax.SyntaxOptions.CodeCompletion) 
				| QWhale.Syntax.SyntaxOptions.SyntaxErrors) 
				| QWhale.Syntax.SyntaxOptions.QuickInfoTips)));
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
			this.ClientSize = new System.Drawing.Size(640, 454);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void syntaxEdit1_NeedCodeCompletion(object sender, QWhale.Syntax.CodeCompletionArgs e)
		{
			if (rbAutomatic.Checked)
				return;
			e.Provider = null;
			if ((e.CompletionType == CodeCompletionType.ListMembers) || (e.CompletionType == CodeCompletionType.CompleteWord) ||
				((e.CompletionType == CodeCompletionType.None) && (e.KeyChar == '.')))
			{
				IListMembers p = new ListMembers();
				p.ShowDescriptions = true;
				p.ShowResults = false;
				p.ShowQualifiers = false;

				IListMember m = p.AddMember();
				m.Name = "<b>print</b>";
				m.DataType = "void";
				m.Qualifier = "public";
				m.ImageIndex = 1;
				m.Description = "<font color = \"#FF0000\">void print(ref string line)</font>";

				m = p.AddMember();
				m.Name = "<b>evaluate</b>";
				m.DataType = "double";
				m.Qualifier = "protected";
				m.ImageIndex = 2;
				m.Description = @"<font color = ""#00FF00"">double evaluate(string expression)</font>";
				e.NeedShow = true;
				e.Provider = p;
				e.ToolTip = false;
			}
		}
	}
}
