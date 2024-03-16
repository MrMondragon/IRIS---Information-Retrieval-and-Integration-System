using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace SnippetsParsers
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbMethodBody;
		private System.Windows.Forms.RadioButton rbClassBody;
		private QWhale.Editor.TextSource textSource1;
		private QWhale.Editor.TextSource textSource2;
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
			this.rbMethodBody = new System.Windows.Forms.RadioButton();
			this.rbClassBody = new System.Windows.Forms.RadioButton();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.textSource1 = new QWhale.Editor.TextSource(this.components);
			this.textSource2 = new QWhale.Editor.TextSource(this.components);
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
			this.groupBox1.Controls.Add(this.rbMethodBody);
			this.groupBox1.Controls.Add(this.rbClassBody);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(640, 72);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Parser type";
			// 
			// rbMethodBody
			// 
			this.rbMethodBody.Location = new System.Drawing.Point(16, 40);
			this.rbMethodBody.Name = "rbMethodBody";
			this.rbMethodBody.TabIndex = 1;
			this.rbMethodBody.Text = "Method body";
			this.rbMethodBody.CheckedChanged += new System.EventHandler(this.rbClassBody_CheckedChanged);
			// 
			// rbClassBody
			// 
			this.rbClassBody.Checked = true;
			this.rbClassBody.Location = new System.Drawing.Point(16, 16);
			this.rbClassBody.Name = "rbClassBody";
			this.rbClassBody.TabIndex = 0;
			this.rbClassBody.TabStop = true;
			this.rbClassBody.Text = "Class body";
			this.rbClassBody.CheckedChanged += new System.EventHandler(this.rbClassBody_CheckedChanged);
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
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(640, 40);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "The demo project shows how to use simple parsers.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 112);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Pages.RulerBackColor = System.Drawing.Color.LightSteelBlue;
			this.syntaxEdit1.Pages.RulerIndentBackColor = System.Drawing.Color.SteelBlue;
			this.syntaxEdit1.Size = new System.Drawing.Size(640, 342);
			this.syntaxEdit1.Source = this.textSource1;
			this.syntaxEdit1.TabIndex = 2;
			// 
			// textSource1
			// 
			this.textSource1.Text = @"public void Test()
{
	Frame frame = (Frame)frames[0];

	int idx_group = 0;
	foreach(GroupAbstract group in frame)
	{
		foreach(Item publication in group)
		{
			FieldInteger scheduled = ((FieldInteger)publication.GetFieldAt(5));
			if (scheduled.Value==1)
			{
				string current_parent2 = ((FieldString)publication.GetFieldAt(1)).StringValue;		
				DateTime current_date = ((GroupDateTime)group).TheDateTime;
				int diff = 0;
				int idx_group2 = idx_group;

				while (diff == 0 && idx_group2 >=0)
				{
					foreach(Item publication2 in frame[idx_group2])
					{
						scheduled = ((FieldInteger)publication2.GetFieldAt(5));
						if (scheduled.Value==1)
						{
							if (! publication2.Equals(publication))
							{
								string parent2 = ((FieldString)publication2.GetFieldAt(1)).StringValue;		
								if (parent2 == current_parent2)
								{
									diff = ((TimeSpan)current_date.Subtract(((GroupDateTime)frame[idx_group2]).TheDateTime)).Days;
									break;
								}
							}
						}
					}
					idx_group2 --;					
				}

				if (diff == 0) 
				{
					publication.GetFieldAt(12).UnscaledValue = 9999 ;
				}
				else
				{
					publication.GetFieldAt(12).UnscaledValue = diff ;
				}
			} else {
				//((FieldInteger)publication.GetFieldAt(12)).UnscaledValue = 0 ;
			}
		
		}
		idx_group++;
	}
}";
			// 
			// textSource2
			// 
			this.textSource2.Text = @"
Frame frame = (Frame)frames[0];

int idx_group = 0;
foreach(GroupAbstract group in frame)
{
	foreach(Item publication in group)
	{
		FieldInteger scheduled = ((FieldInteger)publication.GetFieldAt(5));
		if (scheduled.Value==1)
		{
			string current_parent2 = ((FieldString)publication.GetFieldAt(1)).StringValue;		
			DateTime current_date = ((GroupDateTime)group).TheDateTime;
			int diff = 0;
			int idx_group2 = idx_group;

			while (diff == 0 && idx_group2 >=0)
			{
				foreach(Item publication2 in frame[idx_group2])
				{
					scheduled = ((FieldInteger)publication2.GetFieldAt(5));
					if (scheduled.Value==1)
					{
						if (! publication2.Equals(publication))
						{
							string parent2 = ((FieldString)publication2.GetFieldAt(1)).StringValue;		
							if (parent2 == current_parent2)
							{
								diff = ((TimeSpan)current_date.Subtract(((GroupDateTime)frame[idx_group2]).TheDateTime)).Days;
								break;
							}
						}
					}
				}
				idx_group2 --;					
			}

			if (diff == 0) 
			{
				publication.GetFieldAt(12).UnscaledValue = 9999 ;
			}
			else
			{
				publication.GetFieldAt(12).UnscaledValue = diff ;
			}
		} else {
			//((FieldInteger)publication.GetFieldAt(12)).UnscaledValue = 0 ;
		}
	
	}
	idx_group++;
}";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 454);
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

		private CsClassBodyParser classParser;
		private CsMethodBodyParser methodParser;

		private void UpdateSource()
		{
			if (rbClassBody.Checked)
			{
				syntaxEdit1.Source = textSource1;
				syntaxEdit1.Lexer = classParser;
			}
			else
			{
				syntaxEdit1.Source = textSource2;
				syntaxEdit1.Lexer = methodParser;
			}
		}

		private void rbClassBody_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSource();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			classParser = new CsClassBodyParser();
			classParser.RegisterAssembly("QWhale.Editor");
			methodParser = new CsMethodBodyParser();
			UpdateSource();
		}
	}
}
