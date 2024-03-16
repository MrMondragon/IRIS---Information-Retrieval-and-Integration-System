#region Copyright (c) 2004, 2005 Quantum Whale LLC.
/*
	Quantum Whale .NET Component Library
	Editor.NET Syntax Demo

	Copyright (c) 2004 Quantum Whale LLC.
	ALL RIGHTS RESERVED

	http://www.qwhale.net
	contact@qwhale.net
*/
#endregion Copyright (c) 2004 Quantum Whale LLC.
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SyntaxEditor
{
	/// <summary>
	/// Summary description for CompanyInfo.
	/// </summary>
	public class CompanyInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label laWWW;
		private System.Windows.Forms.Label laAdress;
		private System.Windows.Forms.Label laEMail;
		private System.Windows.Forms.Label laMailTo;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.TextBox tbCompanyInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CompanyInfo()
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
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CompanyInfo));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.laWWW = new System.Windows.Forms.Label();
			this.laAdress = new System.Windows.Forms.Label();
			this.laEMail = new System.Windows.Forms.Label();
			this.laMailTo = new System.Windows.Forms.Label();
			this.btClose = new System.Windows.Forms.Button();
			this.tbCompanyInfo = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 88);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(180, 80);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// laWWW
			// 
			this.laWWW.AutoSize = true;
			this.laWWW.Location = new System.Drawing.Point(216, 96);
			this.laWWW.Name = "laWWW";
			this.laWWW.Size = new System.Drawing.Size(39, 16);
			this.laWWW.TabIndex = 1;
			this.laWWW.Text = "WWW:";
			// 
			// laAdress
			// 
			this.laAdress.AutoSize = true;
			this.laAdress.Cursor = System.Windows.Forms.Cursors.Hand;
			this.laAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laAdress.ForeColor = System.Drawing.Color.Blue;
			this.laAdress.Location = new System.Drawing.Point(264, 96);
			this.laAdress.Name = "laAdress";
			this.laAdress.Size = new System.Drawing.Size(115, 16);
			this.laAdress.TabIndex = 2;
			this.laAdress.Text = "http://www.qwhale.net";
			this.laAdress.Click += new System.EventHandler(this.laAdress_Click);
			// 
			// laEMail
			// 
			this.laEMail.AutoSize = true;
			this.laEMail.Location = new System.Drawing.Point(216, 120);
			this.laEMail.Name = "laEMail";
			this.laEMail.Size = new System.Drawing.Size(38, 16);
			this.laEMail.TabIndex = 3;
			this.laEMail.Text = "e-mail:";
			// 
			// laMailTo
			// 
			this.laMailTo.AutoSize = true;
			this.laMailTo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.laMailTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laMailTo.ForeColor = System.Drawing.Color.Blue;
			this.laMailTo.Location = new System.Drawing.Point(264, 120);
			this.laMailTo.Name = "laMailTo";
			this.laMailTo.Size = new System.Drawing.Size(141, 16);
			this.laMailTo.TabIndex = 4;
			this.laMailTo.Text = "mailto:contact@qwhale.net";
			this.laMailTo.Click += new System.EventHandler(this.laMailTo_Click);
			// 
			// btClose
			// 
			this.btClose.Location = new System.Drawing.Point(184, 192);
			this.btClose.Name = "btClose";
			this.btClose.TabIndex = 5;
			this.btClose.Text = "Close";
			this.btClose.Click += new System.EventHandler(this.btClose_Click);
			// 
			// tbCompanyInfo
			// 
			this.tbCompanyInfo.BackColor = System.Drawing.SystemColors.Control;
			this.tbCompanyInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbCompanyInfo.Location = new System.Drawing.Point(16, 16);
			this.tbCompanyInfo.Multiline = true;
			this.tbCompanyInfo.Name = "tbCompanyInfo";
			this.tbCompanyInfo.Size = new System.Drawing.Size(400, 56);
			this.tbCompanyInfo.TabIndex = 6;
			this.tbCompanyInfo.Text = "This demo is designed to show how Editor.NET can display sources writen in differ" +
				"ent languages and highlight code outlining and intellisence features (in charp f" +
				"iles).";
			// 
			// CompanyInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(426, 240);
			this.Controls.Add(this.tbCompanyInfo);
			this.Controls.Add(this.btClose);
			this.Controls.Add(this.laMailTo);
			this.Controls.Add(this.laEMail);
			this.Controls.Add(this.laAdress);
			this.Controls.Add(this.laWWW);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "CompanyInfo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Company Info";
			this.Load += new System.EventHandler(this.CompanyInfo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CompanyInfo_Load(object sender, System.EventArgs e)
		{
			if (pictureBox1.Image is Bitmap)
				(pictureBox1.Image as Bitmap).MakeTransparent(Color.White);
		}

		private void laAdress_Click(object sender, System.EventArgs e)
		{
			laAdress.ForeColor = Color.Purple;
			try
			{
				System.Diagnostics.Process.Start(laAdress.Text);
			}
			catch
			{
				//
			}
		}

		private void laMailTo_Click(object sender, System.EventArgs e)
		{
			laMailTo.ForeColor = Color.Purple;
			System.Diagnostics.Process.Start(laMailTo.Text);		
		}

		private void btClose_Click(object sender, System.EventArgs e)
		{
			Hide();
		}
	}
}
