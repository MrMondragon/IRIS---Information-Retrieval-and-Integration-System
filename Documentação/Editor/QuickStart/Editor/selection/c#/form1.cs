using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace Selection
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.GroupBox gbSelection;
		private System.Windows.Forms.CheckBox chbOverwriteBlocks;
		private System.Windows.Forms.CheckBox chbPersistentBlocks;
		private System.Windows.Forms.CheckBox chbDeselectOnCopy;
		private System.Windows.Forms.CheckBox chbSelectLineOnDblClick;
		private System.Windows.Forms.CheckBox chbHideSelection;
		private System.Windows.Forms.CheckBox chbUseColors;
		private System.Windows.Forms.CheckBox chbSelectBeyondEol;
		private System.Windows.Forms.CheckBox chbDisableDragging;
		private System.Windows.Forms.CheckBox chbDisableSelection;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.Label laSelectionForeColor;
		private System.Windows.Forms.Label laSelectionBackColor;
		private QWhale.Common.ColorBox cbSelectionBackColor;
		private QWhale.Common.ColorBox cbSelectionForeColor;
		private QWhale.Common.ColorBox cbSelectionBorderColor;
		private System.Windows.Forms.Label laSelectionBorderColor;
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
			this.gbSelection = new System.Windows.Forms.GroupBox();
			this.cbSelectionBorderColor = new QWhale.Common.ColorBox(this.components);
			this.laSelectionBorderColor = new System.Windows.Forms.Label();
			this.cbSelectionBackColor = new QWhale.Common.ColorBox(this.components);
			this.cbSelectionForeColor = new QWhale.Common.ColorBox(this.components);
			this.laSelectionBackColor = new System.Windows.Forms.Label();
			this.laSelectionForeColor = new System.Windows.Forms.Label();
			this.chbOverwriteBlocks = new System.Windows.Forms.CheckBox();
			this.chbPersistentBlocks = new System.Windows.Forms.CheckBox();
			this.chbDeselectOnCopy = new System.Windows.Forms.CheckBox();
			this.chbSelectLineOnDblClick = new System.Windows.Forms.CheckBox();
			this.chbHideSelection = new System.Windows.Forms.CheckBox();
			this.chbUseColors = new System.Windows.Forms.CheckBox();
			this.chbSelectBeyondEol = new System.Windows.Forms.CheckBox();
			this.chbDisableDragging = new System.Windows.Forms.CheckBox();
			this.chbDisableSelection = new System.Windows.Forms.CheckBox();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.pnSettings.SuspendLayout();
			this.gbSelection.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.gbSelection);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(624, 136);
			this.pnSettings.TabIndex = 1;
			// 
			// gbSelection
			// 
			this.gbSelection.Controls.Add(this.cbSelectionBorderColor);
			this.gbSelection.Controls.Add(this.laSelectionBorderColor);
			this.gbSelection.Controls.Add(this.cbSelectionBackColor);
			this.gbSelection.Controls.Add(this.cbSelectionForeColor);
			this.gbSelection.Controls.Add(this.laSelectionBackColor);
			this.gbSelection.Controls.Add(this.laSelectionForeColor);
			this.gbSelection.Controls.Add(this.chbOverwriteBlocks);
			this.gbSelection.Controls.Add(this.chbPersistentBlocks);
			this.gbSelection.Controls.Add(this.chbDeselectOnCopy);
			this.gbSelection.Controls.Add(this.chbSelectLineOnDblClick);
			this.gbSelection.Controls.Add(this.chbHideSelection);
			this.gbSelection.Controls.Add(this.chbUseColors);
			this.gbSelection.Controls.Add(this.chbSelectBeyondEol);
			this.gbSelection.Controls.Add(this.chbDisableDragging);
			this.gbSelection.Controls.Add(this.chbDisableSelection);
			this.gbSelection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbSelection.Location = new System.Drawing.Point(0, 36);
			this.gbSelection.Name = "gbSelection";
			this.gbSelection.Size = new System.Drawing.Size(624, 100);
			this.gbSelection.TabIndex = 9;
			this.gbSelection.TabStop = false;
			this.gbSelection.Text = "Selection Options";
			// 
			// cbSelectionBorderColor
			// 
			this.cbSelectionBorderColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbSelectionBorderColor.Location = new System.Drawing.Point(496, 66);
			this.cbSelectionBorderColor.Name = "cbSelectionBorderColor";
			this.cbSelectionBorderColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbSelectionBorderColor.Size = new System.Drawing.Size(121, 21);
			this.cbSelectionBorderColor.TabIndex = 19;
			this.cbSelectionBorderColor.SelectedIndexChanged += new System.EventHandler(this.cbSelectionBorderColor_SelectedIndexChanged);
			// 
			// laSelectionBorderColor
			// 
			this.laSelectionBorderColor.AutoSize = true;
			this.laSelectionBorderColor.Location = new System.Drawing.Point(424, 69);
			this.laSelectionBorderColor.Name = "laSelectionBorderColor";
			this.laSelectionBorderColor.Size = new System.Drawing.Size(68, 16);
			this.laSelectionBorderColor.TabIndex = 18;
			this.laSelectionBorderColor.Text = "Border Color";
			// 
			// cbSelectionBackColor
			// 
			this.cbSelectionBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbSelectionBackColor.Location = new System.Drawing.Point(496, 42);
			this.cbSelectionBackColor.Name = "cbSelectionBackColor";
			this.cbSelectionBackColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbSelectionBackColor.Size = new System.Drawing.Size(121, 21);
			this.cbSelectionBackColor.TabIndex = 17;
			this.cbSelectionBackColor.SelectedIndexChanged += new System.EventHandler(this.cbSelectionBackColor_SelectedIndexChanged);
			// 
			// cbSelectionForeColor
			// 
			this.cbSelectionForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbSelectionForeColor.Location = new System.Drawing.Point(496, 18);
			this.cbSelectionForeColor.Name = "cbSelectionForeColor";
			this.cbSelectionForeColor.SelectedColor = System.Drawing.Color.Empty;
			this.cbSelectionForeColor.Size = new System.Drawing.Size(121, 21);
			this.cbSelectionForeColor.TabIndex = 16;
			this.cbSelectionForeColor.SelectedIndexChanged += new System.EventHandler(this.cbSelectionForeColor_SelectedIndexChanged);
			// 
			// laSelectionBackColor
			// 
			this.laSelectionBackColor.AutoSize = true;
			this.laSelectionBackColor.Location = new System.Drawing.Point(424, 45);
			this.laSelectionBackColor.Name = "laSelectionBackColor";
			this.laSelectionBackColor.Size = new System.Drawing.Size(59, 16);
			this.laSelectionBackColor.TabIndex = 15;
			this.laSelectionBackColor.Text = "Back Color";
			// 
			// laSelectionForeColor
			// 
			this.laSelectionForeColor.AutoSize = true;
			this.laSelectionForeColor.Location = new System.Drawing.Point(424, 21);
			this.laSelectionForeColor.Name = "laSelectionForeColor";
			this.laSelectionForeColor.Size = new System.Drawing.Size(58, 16);
			this.laSelectionForeColor.TabIndex = 14;
			this.laSelectionForeColor.Text = "Fore Color";
			// 
			// chbOverwriteBlocks
			// 
			this.chbOverwriteBlocks.Location = new System.Drawing.Point(296, 64);
			this.chbOverwriteBlocks.Name = "chbOverwriteBlocks";
			this.chbOverwriteBlocks.Size = new System.Drawing.Size(112, 24);
			this.chbOverwriteBlocks.TabIndex = 13;
			this.chbOverwriteBlocks.Text = "Overwrite Blocks";
			this.chbOverwriteBlocks.CheckedChanged += new System.EventHandler(this.chbOverwriteBlocks_CheckedChanged);
			// 
			// chbPersistentBlocks
			// 
			this.chbPersistentBlocks.Location = new System.Drawing.Point(296, 40);
			this.chbPersistentBlocks.Name = "chbPersistentBlocks";
			this.chbPersistentBlocks.Size = new System.Drawing.Size(112, 24);
			this.chbPersistentBlocks.TabIndex = 12;
			this.chbPersistentBlocks.Text = "Persistent Blocks";
			this.chbPersistentBlocks.CheckedChanged += new System.EventHandler(this.chbPersistentBlocks_CheckedChanged);
			// 
			// chbDeselectOnCopy
			// 
			this.chbDeselectOnCopy.Location = new System.Drawing.Point(296, 16);
			this.chbDeselectOnCopy.Name = "chbDeselectOnCopy";
			this.chbDeselectOnCopy.Size = new System.Drawing.Size(112, 24);
			this.chbDeselectOnCopy.TabIndex = 11;
			this.chbDeselectOnCopy.Text = "Deselect on Copy";
			this.chbDeselectOnCopy.CheckedChanged += new System.EventHandler(this.chbDeselectOnCopy_CheckedChanged);
			// 
			// chbSelectLineOnDblClick
			// 
			this.chbSelectLineOnDblClick.Location = new System.Drawing.Point(144, 64);
			this.chbSelectLineOnDblClick.Name = "chbSelectLineOnDblClick";
			this.chbSelectLineOnDblClick.Size = new System.Drawing.Size(140, 24);
			this.chbSelectLineOnDblClick.TabIndex = 10;
			this.chbSelectLineOnDblClick.Text = "Select Line on DblClick";
			this.chbSelectLineOnDblClick.CheckedChanged += new System.EventHandler(this.chbSelectLineOnDblClick_CheckedChanged);
			// 
			// chbHideSelection
			// 
			this.chbHideSelection.Location = new System.Drawing.Point(144, 40);
			this.chbHideSelection.Name = "chbHideSelection";
			this.chbHideSelection.TabIndex = 9;
			this.chbHideSelection.Text = "Hide Selection";
			this.chbHideSelection.CheckedChanged += new System.EventHandler(this.chbHideSelection_CheckedChanged);
			// 
			// chbUseColors
			// 
			this.chbUseColors.Location = new System.Drawing.Point(144, 16);
			this.chbUseColors.Name = "chbUseColors";
			this.chbUseColors.TabIndex = 8;
			this.chbUseColors.Text = "Use Colors";
			this.chbUseColors.CheckedChanged += new System.EventHandler(this.chbUseColors_CheckedChanged);
			// 
			// chbSelectBeyondEol
			// 
			this.chbSelectBeyondEol.Location = new System.Drawing.Point(8, 64);
			this.chbSelectBeyondEol.Name = "chbSelectBeyondEol";
			this.chbSelectBeyondEol.Size = new System.Drawing.Size(122, 24);
			this.chbSelectBeyondEol.TabIndex = 7;
			this.chbSelectBeyondEol.Text = "Select Beyond EOL";
			this.chbSelectBeyondEol.CheckedChanged += new System.EventHandler(this.chbSelectBeyondEol_CheckedChanged);
			// 
			// chbDisableDragging
			// 
			this.chbDisableDragging.Location = new System.Drawing.Point(8, 40);
			this.chbDisableDragging.Name = "chbDisableDragging";
			this.chbDisableDragging.Size = new System.Drawing.Size(112, 24);
			this.chbDisableDragging.TabIndex = 6;
			this.chbDisableDragging.Text = "Disable Dragging";
			this.chbDisableDragging.CheckedChanged += new System.EventHandler(this.chbDisableDragging_CheckedChanged);
			// 
			// chbDisableSelection
			// 
			this.chbDisableSelection.Location = new System.Drawing.Point(8, 16);
			this.chbDisableSelection.Name = "chbDisableSelection";
			this.chbDisableSelection.Size = new System.Drawing.Size(112, 24);
			this.chbDisableSelection.TabIndex = 5;
			this.chbDisableSelection.Text = "Disable Selection";
			this.chbDisableSelection.CheckedChanged += new System.EventHandler(this.chbDisableSelection_CheckedChanged);
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(624, 36);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(624, 36);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows how to customize appearance and behaviour of selected text within" +
				" edit control\'s content.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 136);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Pages.RulerBackColor = System.Drawing.Color.LightSteelBlue;
			this.syntaxEdit1.Pages.RulerIndentBackColor = System.Drawing.Color.SteelBlue;
			this.syntaxEdit1.Selection.Options = ((QWhale.Editor.SelectionOptions)(((((QWhale.Editor.SelectionOptions.SelectBeyondEol | QWhale.Editor.SelectionOptions.HideSelection) 
				| QWhale.Editor.SelectionOptions.OverwriteBlocks) 
				| QWhale.Editor.SelectionOptions.SmartFormat) 
				| QWhale.Editor.SelectionOptions.DrawBorder)));
			this.syntaxEdit1.Size = new System.Drawing.Size(624, 182);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
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
				"   </Style>\r\n  </Styles>\r\n  <States />\r\n</LexScheme>";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 318);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.pnSettings);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.gbSelection.ResumeLayout(false);
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
			chbDisableSelection.Checked = (SelectionOptions.DisableSelection & syntaxEdit1.Selection.Options) != 0;
			chbDisableDragging.Checked = (SelectionOptions.DisableDragging & syntaxEdit1.Selection.Options) != 0;
			chbSelectBeyondEol.Checked = (SelectionOptions.SelectBeyondEol & syntaxEdit1.Selection.Options) != 0;
			chbUseColors.Checked = (SelectionOptions.UseColors & syntaxEdit1.Selection.Options) != 0;
			chbHideSelection.Checked = (SelectionOptions.HideSelection & syntaxEdit1.Selection.Options) != 0;
			chbSelectLineOnDblClick.Checked = (SelectionOptions.SelectLineOnDblClick & syntaxEdit1.Selection.Options) != 0;
			chbDeselectOnCopy.Checked = (SelectionOptions.DeselectOnCopy & syntaxEdit1.Selection.Options) != 0;
			chbPersistentBlocks.Checked = (SelectionOptions.PersistentBlocks & syntaxEdit1.Selection.Options) != 0;
			chbOverwriteBlocks.Checked = (SelectionOptions.OverwriteBlocks & syntaxEdit1.Selection.Options) != 0;
			cbSelectionForeColor.SelectedColor = syntaxEdit1.Selection.ForeColor;
			cbSelectionBackColor.SelectedColor = syntaxEdit1.Selection.BackColor;
			cbSelectionBorderColor.SelectedColor = syntaxEdit1.Selection.BorderColor;
		}

		private void chbDisableSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbDisableSelection.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.DisableSelection: syntaxEdit1.Selection.Options ^ SelectionOptions.DisableSelection);
		}

		private void chbDisableDragging_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbDisableDragging.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.DisableDragging: syntaxEdit1.Selection.Options ^ SelectionOptions.DisableDragging);
		}

		private void chbSelectBeyondEol_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbSelectBeyondEol.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.SelectBeyondEol: syntaxEdit1.Selection.Options ^ SelectionOptions.SelectBeyondEol);
		}

		private void chbUseColors_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbUseColors.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.UseColors: syntaxEdit1.Selection.Options ^ SelectionOptions.UseColors);
		}

		private void chbHideSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbHideSelection.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.HideSelection: syntaxEdit1.Selection.Options ^ SelectionOptions.HideSelection);
		}

		private void chbSelectLineOnDblClick_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbSelectLineOnDblClick.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.SelectLineOnDblClick: syntaxEdit1.Selection.Options ^ SelectionOptions.SelectLineOnDblClick);
		}

		private void chbDeselectOnCopy_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbDeselectOnCopy.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.DeselectOnCopy: syntaxEdit1.Selection.Options ^ SelectionOptions.DeselectOnCopy);
		}

		private void chbPersistentBlocks_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbPersistentBlocks.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.PersistentBlocks: syntaxEdit1.Selection.Options ^ SelectionOptions.PersistentBlocks);
		}

		private void chbOverwriteBlocks_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.Options = (chbOverwriteBlocks.Checked ? syntaxEdit1.Selection.Options 
				| SelectionOptions.OverwriteBlocks: syntaxEdit1.Selection.Options ^ SelectionOptions.OverwriteBlocks);
		}

		private void cbSelectionForeColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.ForeColor = cbSelectionForeColor.SelectedColor;
		}

		private void cbSelectionBackColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.BackColor = cbSelectionBackColor.SelectedColor;
		}

		private void cbSelectionBorderColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Selection.BorderColor = cbSelectionBorderColor.SelectedColor;
		}
	}
}
