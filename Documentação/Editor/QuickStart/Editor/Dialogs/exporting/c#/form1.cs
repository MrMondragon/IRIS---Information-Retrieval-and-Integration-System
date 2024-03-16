using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace Exporting
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.Button btLoad;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btRTF;
		private System.Windows.Forms.Button btHTML;
		private System.Windows.Forms.Button btXML;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog2;
		private System.Windows.Forms.GroupBox groupBox1;
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
			this.pnSettings = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btXML = new System.Windows.Forms.Button();
			this.btHTML = new System.Windows.Forms.Button();
			this.btRTF = new System.Windows.Forms.Button();
			this.btSave = new System.Windows.Forms.Button();
			this.btLoad = new System.Windows.Forms.Button();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
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
			this.pnSettings.Size = new System.Drawing.Size(568, 104);
			this.pnSettings.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btXML);
			this.groupBox1.Controls.Add(this.btHTML);
			this.groupBox1.Controls.Add(this.btRTF);
			this.groupBox1.Controls.Add(this.btSave);
			this.groupBox1.Controls.Add(this.btLoad);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 80);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Import&&Export";
			// 
			// btXML
			// 
			this.btXML.Location = new System.Drawing.Point(176, 48);
			this.btXML.Name = "btXML";
			this.btXML.TabIndex = 13;
			this.btXML.Text = "XML";
			this.btXML.Click += new System.EventHandler(this.btXML_Click);
			// 
			// btHTML
			// 
			this.btHTML.Location = new System.Drawing.Point(88, 48);
			this.btHTML.Name = "btHTML";
			this.btHTML.TabIndex = 12;
			this.btHTML.Text = "HTML";
			this.btHTML.Click += new System.EventHandler(this.btHTML_Click);
			// 
			// btRTF
			// 
			this.btRTF.Location = new System.Drawing.Point(8, 48);
			this.btRTF.Name = "btRTF";
			this.btRTF.TabIndex = 11;
			this.btRTF.Text = "RTF";
			this.btRTF.Click += new System.EventHandler(this.btRTF_Click);
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(88, 16);
			this.btSave.Name = "btSave";
			this.btSave.TabIndex = 10;
			this.btSave.Text = "Save";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btLoad
			// 
			this.btLoad.Location = new System.Drawing.Point(8, 16);
			this.btLoad.Name = "btLoad";
			this.btLoad.TabIndex = 9;
			this.btLoad.Text = "Load";
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
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
			this.laDescription.Text = "This demo shows how to import/export edit control\'s content to various formats.";
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
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 214);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "public class Person\r\n{\r\n   public int age;\r\n   public string name;\r\n}\r\n\r\npublic c" +
				"lass MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person p = new Person();" +
				" \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r\n   }\r\n}";
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
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|C # files (*.cs)|*.cs|Xml files (*.xml)|*.xml|All files " +
				"(*.*)|*.*";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Text files (*.txt)|*.txt|C # files (*.cs)|*.cs|All files (*.*)|*.*";
			// 
			// saveFileDialog2
			// 
			this.saveFileDialog2.Filter = "Rtf files (*.rtf)|*.rtf|Html files (*.html; *.htm)|*.html;*.htm|Xml files (*.xml)" +
				"|*.xml|All files (*.*)|*.*";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 318);
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

		private void btLoad_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				System.IO.FileInfo fi = new System.IO.FileInfo(openFileDialog1.FileName);
				if (fi.Extension == ".xml")
					syntaxEdit1.LoadFile(openFileDialog1.FileName, ExportFormat.Xml);
				else
					syntaxEdit1.LoadFile(openFileDialog1.FileName);
			}		
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				syntaxEdit1.SaveFile(saveFileDialog1.FileName);
		}

		private void btRTF_Click(object sender, System.EventArgs e)
		{
			saveFileDialog2.FilterIndex = 1;
			if (saveFileDialog2.ShowDialog() == DialogResult.OK)
				syntaxEdit1.SaveFile(saveFileDialog2.FileName, ExportFormat.Rtf);
		}

		private void btHTML_Click(object sender, System.EventArgs e)
		{
			saveFileDialog2.FilterIndex = 2;
			if (saveFileDialog2.ShowDialog() == DialogResult.OK)
				syntaxEdit1.SaveFile(saveFileDialog2.FileName, ExportFormat.Html);
		}

		private void btXML_Click(object sender, System.EventArgs e)
		{
			saveFileDialog2.FilterIndex = 3;
			if (saveFileDialog2.ShowDialog() == DialogResult.OK)
				syntaxEdit1.SaveFile(saveFileDialog2.FileName, ExportFormat.Xml);
		}
	}
}
