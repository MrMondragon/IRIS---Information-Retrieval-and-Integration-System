using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace LineModificators
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
		private System.Windows.Forms.CheckBox chbLineModificator;
		private System.Windows.Forms.Button btUndo;
		private System.Windows.Forms.Button btRedo;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.ImageList imMenu;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label laChangedColor;
		private System.Windows.Forms.Label laSavedColor;
		private QWhale.Common.ColorBox cbChangedColor;
		private QWhale.Common.ColorBox cbSavedColor;
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
			this.btUndo = new System.Windows.Forms.Button();
			this.imMenu = new System.Windows.Forms.ImageList(this.components);
			this.chbLineModificator = new System.Windows.Forms.CheckBox();
			this.btRedo = new System.Windows.Forms.Button();
			this.btSave = new System.Windows.Forms.Button();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.laChangedColor = new System.Windows.Forms.Label();
			this.laSavedColor = new System.Windows.Forms.Label();
			this.cbChangedColor = new QWhale.Common.ColorBox(this.components);
			this.cbSavedColor = new QWhale.Common.ColorBox(this.components);
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
			this.groupBox1.Controls.Add(this.cbSavedColor);
			this.groupBox1.Controls.Add(this.cbChangedColor);
			this.groupBox1.Controls.Add(this.laSavedColor);
			this.groupBox1.Controls.Add(this.laChangedColor);
			this.groupBox1.Controls.Add(this.btUndo);
			this.groupBox1.Controls.Add(this.chbLineModificator);
			this.groupBox1.Controls.Add(this.btRedo);
			this.groupBox1.Controls.Add(this.btSave);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 80);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Line modificators";
			// 
			// btUndo
			// 
			this.btUndo.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btUndo.ImageIndex = 0;
			this.btUndo.ImageList = this.imMenu;
			this.btUndo.Location = new System.Drawing.Point(8, 48);
			this.btUndo.Name = "btUndo";
			this.btUndo.Size = new System.Drawing.Size(72, 23);
			this.btUndo.TabIndex = 10;
			this.btUndo.Text = "Undo";
			this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
			// 
			// imMenu
			// 
			this.imMenu.ImageSize = new System.Drawing.Size(16, 16);
			this.imMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imMenu.ImageStream")));
			this.imMenu.TransparentColor = System.Drawing.Color.Red;
			// 
			// chbLineModificator
			// 
			this.chbLineModificator.Checked = true;
			this.chbLineModificator.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbLineModificator.Location = new System.Drawing.Point(8, 16);
			this.chbLineModificator.Name = "chbLineModificator";
			this.chbLineModificator.Size = new System.Drawing.Size(112, 24);
			this.chbLineModificator.TabIndex = 9;
			this.chbLineModificator.Text = "Line Modificators";
			this.chbLineModificator.CheckedChanged += new System.EventHandler(this.chbLineModificator_CheckedChanged);
			// 
			// btRedo
			// 
			this.btRedo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btRedo.ImageIndex = 1;
			this.btRedo.ImageList = this.imMenu;
			this.btRedo.Location = new System.Drawing.Point(88, 48);
			this.btRedo.Name = "btRedo";
			this.btRedo.Size = new System.Drawing.Size(72, 23);
			this.btRedo.TabIndex = 11;
			this.btRedo.Text = "Redo";
			this.btRedo.Click += new System.EventHandler(this.btRedo_Click);
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(168, 48);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(72, 23);
			this.btSave.TabIndex = 12;
			this.btSave.Text = "Save";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
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
			this.laDescription.Text = "This demo shows how to visually identify modified lines.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Gutter.Options = ((QWhale.Editor.GutterOptions)((QWhale.Editor.GutterOptions.PaintBookMarks | QWhale.Editor.GutterOptions.PaintLineModificators)));
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 104);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 214);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
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
			// laChangedColor
			// 
			this.laChangedColor.Location = new System.Drawing.Point(288, 16);
			this.laChangedColor.Name = "laChangedColor";
			this.laChangedColor.Size = new System.Drawing.Size(100, 16);
			this.laChangedColor.TabIndex = 13;
			this.laChangedColor.Text = "Changed color";
			// 
			// laSavedColor
			// 
			this.laSavedColor.Location = new System.Drawing.Point(288, 48);
			this.laSavedColor.Name = "laSavedColor";
			this.laSavedColor.Size = new System.Drawing.Size(80, 16);
			this.laSavedColor.TabIndex = 14;
			this.laSavedColor.Text = "Saved Color";
			// 
			// cbChangedColor
			// 
			this.cbChangedColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbChangedColor.Location = new System.Drawing.Point(376, 16);
			this.cbChangedColor.Name = "cbChangedColor";
			this.cbChangedColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbChangedColor.Size = new System.Drawing.Size(121, 21);
			this.cbChangedColor.TabIndex = 15;
			this.cbChangedColor.SelectedIndexChanged += new System.EventHandler(this.cbChangedColor_SelectedIndexChanged);
			// 
			// cbSavedColor
			// 
			this.cbSavedColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbSavedColor.Location = new System.Drawing.Point(376, 48);
			this.cbSavedColor.Name = "cbSavedColor";
			this.cbSavedColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbSavedColor.Size = new System.Drawing.Size(121, 21);
			this.cbSavedColor.TabIndex = 16;
			this.cbSavedColor.SelectedIndexChanged += new System.EventHandler(this.cbSavedColor_SelectedIndexChanged);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			chbLineModificator.Checked = (GutterOptions.PaintLineModificators & syntaxEdit1.Gutter.Options) != 0;
			cbChangedColor.SelectedColor = syntaxEdit1.Gutter.LineModificatorChangedColor;
			cbSavedColor.SelectedColor = syntaxEdit1.Gutter.LineModificatorSavedColor;
			syntaxEdit1.Source.NewLine();
		}
		private void chbLineModificator_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.Options = (chbLineModificator.Checked ? syntaxEdit1.Gutter.Options 
				| GutterOptions.PaintLineModificators : syntaxEdit1.Gutter.Options ^ GutterOptions.PaintLineModificators);
		}

		private void btUndo_Click(object sender, System.EventArgs e)
		{
			if (syntaxEdit1.Source.CanUndo())
				syntaxEdit1.Source.Undo();
		}

		private void btRedo_Click(object sender, System.EventArgs e)
		{
			if (syntaxEdit1.Source.CanRedo())
				syntaxEdit1.Source.Redo();
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.Modified = false;
		}

		private void syntaxEdit1_SourceStateChanged(object sender, QWhale.Editor.NotifyEventArgs e)
		{
			if (((e.State & NotifyState.Modified) != 0) || ((e.State & NotifyState.Undo) != 0) || ((e.State & NotifyState.ModifiedChanged) != 0) || ((e.State & NotifyState.Edit) != 0) || ((e.State & NotifyState.Edit) != 0) || ((e.State & NotifyState.BlockChanged) != 0))
			{
				SyntaxEdit edit = (SyntaxEdit)sender;
				btRedo.Enabled = edit.Source.CanRedo();
				btUndo.Enabled = edit.Source.CanUndo();
				btSave.Enabled = edit.Modified;
			}
		}
		private void cbChangedColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.LineModificatorChangedColor = cbChangedColor.SelectedColor;
		}
		private void cbSavedColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Gutter.LineModificatorSavedColor = cbSavedColor.SelectedColor;
		}
	}
}
