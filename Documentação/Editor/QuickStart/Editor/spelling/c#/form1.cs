using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace Spelling
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.CheckBox chbCheckSpelling;
		private System.Windows.Forms.Label laSpellColor;
		private System.Windows.Forms.Splitter splitter1;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private QWhale.Editor.SyntaxEdit syntaxEdit2;
		private QWhale.Common.ColorBox cbSpellColor;
		private System.Windows.Forms.Panel pnSettings;
		private QWhale.Syntax.Parsers.CsParser csParser1;
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
			this.cbSpellColor = new QWhale.Common.ColorBox(this.components);
			this.laSpellColor = new System.Windows.Forms.Label();
			this.chbCheckSpelling = new System.Windows.Forms.CheckBox();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.syntaxEdit2 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.pnSettings.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.cbSpellColor);
			this.pnSettings.Controls.Add(this.laSpellColor);
			this.pnSettings.Controls.Add(this.chbCheckSpelling);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 88);
			this.pnSettings.TabIndex = 1;
			// 
			// cbSpellColor
			// 
			this.cbSpellColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbSpellColor.Location = new System.Drawing.Point(192, 52);
			this.cbSpellColor.Name = "cbSpellColor";
			this.cbSpellColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbSpellColor.Size = new System.Drawing.Size(121, 21);
			this.cbSpellColor.TabIndex = 12;
			this.cbSpellColor.SelectedIndexChanged += new System.EventHandler(this.cbSpellColor_SelectedIndexChanged);
			// 
			// laSpellColor
			// 
			this.laSpellColor.AutoSize = true;
			this.laSpellColor.Location = new System.Drawing.Point(120, 54);
			this.laSpellColor.Name = "laSpellColor";
			this.laSpellColor.Size = new System.Drawing.Size(63, 16);
			this.laSpellColor.TabIndex = 11;
			this.laSpellColor.Text = "Spell Color:";
			// 
			// chbCheckSpelling
			// 
			this.chbCheckSpelling.Location = new System.Drawing.Point(8, 48);
			this.chbCheckSpelling.Name = "chbCheckSpelling";
			this.chbCheckSpelling.TabIndex = 9;
			this.chbCheckSpelling.Text = "Check Spelling";
			this.chbCheckSpelling.CheckedChanged += new System.EventHandler(this.chbCheckSpelling_CheckedChanged);
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(568, 40);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 40);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows ability to visually highlight misspelled words in the edit contro" +
				"l\'s content.  Note that Editor only provides a way to higlight misspelled words," +
				" actual spell checking should be done by external tool or component.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Top;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 88);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 128);
			this.syntaxEdit1.Spelling.CheckSpelling = true;
			this.syntaxEdit1.TabIndex = 3;
			this.syntaxEdit1.Text = @"using System;

/// <summary>
/// 
/// </summary>
public class Person
{
   public int age;
   public string name;
}

public class MainClass 
{
   static void Main() 
   {
      Person p = new Person(); 

      Console.Write(""Name: {0}, Age: {1}"",p.name, p.age);
   }
}";
			this.syntaxEdit1.WordSpell += new QWhale.Editor.WordSpellEvent(this.syntaxEdit1_WordSpell);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 216);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(568, 5);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// syntaxEdit2
			// 
			this.syntaxEdit2.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit2.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit2.Location = new System.Drawing.Point(0, 221);
			this.syntaxEdit2.Name = "syntaxEdit2";
			this.syntaxEdit2.Size = new System.Drawing.Size(568, 97);
			this.syntaxEdit2.Spelling.CheckSpelling = true;
			this.syntaxEdit2.TabIndex = 5;
			this.syntaxEdit2.Text = @"The SyntaxEdit supports the spell-as-you-type spellchecker integration. To enable spelling for the editor, set its Spelling.CheckSpelling property to true and assign the WordSpell event handler.
Incorrect words are displayed with the wiggly underline (the default color is red, but it can be changed using the Spelling.SpellColor property). In the real life you would need to use some third-party software to really check the text. Another alternative would be using some word-list file, many of them, including Public Domain or free ones, can be found on the Internet.";
			this.syntaxEdit2.WordWrap = true;
			this.syntaxEdit2.WordSpell += new QWhale.Editor.WordSpellEvent(this.syntaxEdit2_WordSpell);
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
			this.Controls.Add(this.syntaxEdit2);
			this.Controls.Add(this.splitter1);
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
			chbCheckSpelling.Checked = syntaxEdit2.Spelling.CheckSpelling;
			cbSpellColor.SelectedColor = syntaxEdit2.Spelling.SpellColor;
		}

		private void chbCheckSpelling_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Spelling.CheckSpelling = chbCheckSpelling.Checked;
			syntaxEdit2.Spelling.CheckSpelling = chbCheckSpelling.Checked;
		}

		private void cbSpellColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Spelling.SpellColor = cbSpellColor.SelectedColor;
			syntaxEdit2.Spelling.SpellColor = cbSpellColor.SelectedColor;
		}
		private void syntaxEdit2_WordSpell(object sender, QWhale.Editor.WordSpellEventArgs e)
		{
			e.Correct = e.Text.Length > 3;
		}

		private void syntaxEdit1_WordSpell(object sender, QWhale.Editor.WordSpellEventArgs e)
		{
			LexToken tok = (LexToken)(e.ColorStyle - 1);
			if ((tok == LexToken.String) || (tok == LexToken.Comment) || (tok == LexToken.XmlComment))
				if (e.Text.ToLower().StartsWith("s"))
					e.Correct = false;
		}
	}
}
