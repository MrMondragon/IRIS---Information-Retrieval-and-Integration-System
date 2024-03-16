using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace WordWrap
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.CheckBox chbWordWrap;
		private System.Windows.Forms.CheckBox chbWrapAtMargin;
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
			this.chbWordWrap = new System.Windows.Forms.CheckBox();
			this.chbWrapAtMargin = new System.Windows.Forms.CheckBox();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
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
			this.groupBox1.Controls.Add(this.chbWordWrap);
			this.groupBox1.Controls.Add(this.chbWrapAtMargin);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 72);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Word Wrap";
			// 
			// chbWordWrap
			// 
			this.chbWordWrap.Location = new System.Drawing.Point(16, 16);
			this.chbWordWrap.Name = "chbWordWrap";
			this.chbWordWrap.TabIndex = 9;
			this.chbWordWrap.Text = "Word Wrap";
			this.chbWordWrap.CheckedChanged += new System.EventHandler(this.chbWordWrap_CheckedChanged);
			// 
			// chbWrapAtMargin
			// 
			this.chbWrapAtMargin.Location = new System.Drawing.Point(16, 40);
			this.chbWrapAtMargin.Name = "chbWrapAtMargin";
			this.chbWrapAtMargin.TabIndex = 10;
			this.chbWrapAtMargin.Text = "Wrap at Margin";
			this.chbWrapAtMargin.CheckedChanged += new System.EventHandler(this.chbWrapAtMargin_CheckedChanged);
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
			this.laDescription.Text = "This demo shows how to use wordwrap mode to wrap lines within edit control\'s cont" +
				"ent.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.EditMargin.Position = 50;
			this.syntaxEdit1.EditMargin.Visible = true;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 96);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 222);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = @"It is sometimes desirable for the user to see the codes which influence the layout of the text and are normally invisible themselves. These codes are space, tab, end-of-line, and the end-of-file (not really a code), and are often collectively referred to as the white-space. The SyntaxEdit has the option to display them, and to control their appearance.
The display of the white-space is enabled using the WhiteSpace.Visible property. The color used to display white-space codes is determined by the WhiteSpace.SymbolColor property, and the characters used to display those codes are determined by EofSymbol, EolSymbol, SpaceSymbol, and TabSymbol properties.";
			this.syntaxEdit1.WordWrap = true;
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
			chbWordWrap.Checked = syntaxEdit1.WordWrap;
			chbWrapAtMargin.Checked = syntaxEdit1.WrapAtMargin;
		}

		private void chbWordWrap_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.WordWrap = chbWordWrap.Checked;
		}

		private void chbWrapAtMargin_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.WrapAtMargin = chbWrapAtMargin.Checked;
		}
	}
}
