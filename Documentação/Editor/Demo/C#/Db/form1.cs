#region Copyright (c) 2004 - 2007 Quantum Whale LLC.
/*
	Quantum Whale .NET Component Library
	Editor.NET Dataset Demo

	Copyright (c) 2004 - 2007 Quantum Whale LLC.
	ALL RIGHTS RESERVED

	http://www.qwhale.net
	contact@qwhale.net
*/
#endregion Copyright (c) 2004 - 2007 Quantum Whale LLC.
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Editor;

namespace DbTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private MyDbTest.Data.TestDataset testDataset1;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonLast;
		private System.Windows.Forms.Button buttonFirst;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonPrevious;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
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
			this.testDataset1 = new MyDbTest.Data.TestDataset();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonLast = new System.Windows.Forms.Button();
			this.buttonFirst = new System.Windows.Forms.Button();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonPrevious = new System.Windows.Forms.Button();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.testDataset1)).BeginInit();
			this.panelLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// testDataset1
			// 
			this.testDataset1.DataSetName = "TestDataset";
			this.testDataset1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.buttonClose);
			this.panelLeft.Controls.Add(this.buttonLast);
			this.panelLeft.Controls.Add(this.buttonFirst);
			this.panelLeft.Controls.Add(this.buttonNext);
			this.panelLeft.Controls.Add(this.buttonPrevious);
			this.panelLeft.Controls.Add(this.syntaxEdit1);
			this.panelLeft.Controls.Add(this.label2);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(360, 270);
			this.panelLeft.TabIndex = 10;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(288, 238);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(56, 23);
			this.buttonClose.TabIndex = 18;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonLast
			// 
			this.buttonLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonLast.Location = new System.Drawing.Point(192, 238);
			this.buttonLast.Name = "buttonLast";
			this.buttonLast.Size = new System.Drawing.Size(40, 23);
			this.buttonLast.TabIndex = 17;
			this.buttonLast.Text = ">|";
			this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
			// 
			// buttonFirst
			// 
			this.buttonFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonFirst.Location = new System.Drawing.Point(72, 238);
			this.buttonFirst.Name = "buttonFirst";
			this.buttonFirst.Size = new System.Drawing.Size(40, 23);
			this.buttonFirst.TabIndex = 14;
			this.buttonFirst.Text = "|<";
			this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
			// 
			// buttonNext
			// 
			this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonNext.Location = new System.Drawing.Point(152, 238);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(40, 23);
			this.buttonNext.TabIndex = 16;
			this.buttonNext.Text = ">>";
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
			// 
			// buttonPrevious
			// 
			this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPrevious.Location = new System.Drawing.Point(112, 238);
			this.buttonPrevious.Name = "buttonPrevious";
			this.buttonPrevious.Size = new System.Drawing.Size(40, 23);
			this.buttonPrevious.TabIndex = 15;
			this.buttonPrevious.Text = "<<";
			this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testDataset1, "TestData.Text"));
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Location = new System.Drawing.Point(8, 32);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Pages.DefaultPage.Footer.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Pages.DefaultPage.Header.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Size = new System.Drawing.Size(336, 192);
			this.syntaxEdit1.TabIndex = 13;
			this.syntaxEdit1.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(215, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "QWhale Editor with Text field Databound :";
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.splitter1.Location = new System.Drawing.Point(360, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(5, 270);
			this.splitter1.TabIndex = 11;
			this.splitter1.TabStop = false;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "TestData";
			this.dataGrid1.DataSource = this.testDataset1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(365, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(315, 270);
			this.dataGrid1.TabIndex = 12;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.SystemColors.Control;
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn2});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "TestData";
			this.dataGridTableStyle1.PreferredRowHeight = 32;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Text";
			this.dataGridTextBoxColumn2.MappingName = "Text";
			this.dataGridTextBoxColumn2.Width = 225;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 270);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panelLeft);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.testDataset1)).EndInit();
			this.panelLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Form1_Load(object sender, System.EventArgs e)
		{
			InitData();
		}
		private void InitData()
		{
			testDataset1.Clear();

			// Fill the dataset with sample data
			testDataset1.TestData.AddTestDataRow(0, "Record 1\r\nThis is a test line of data.");
			testDataset1.TestData.AddTestDataRow(1, "Record 2\r\nAnother line of data.");
			testDataset1.TestData.AddTestDataRow(2, "Record 3\r\nBlue birds will be singing soon.");
			testDataset1.TestData.AddTestDataRow(3, "Record 4\r\nIt's been unseasonably warm.");
			testDataset1.TestData.AddTestDataRow(4, "Record 5\r\nHope the penguins are donig well this year.");
			testDataset1.TestData.AddTestDataRow(5, "Record 6\r\nThat's about it for all my creative juices.");
		}

		private void buttonFirst_Click(object sender, System.EventArgs e)
		{
			CurrencyManager cm = (CurrencyManager)this.BindingContext[testDataset1,"TestData"];
			cm.Position=0;
		}

		private void buttonPrevious_Click(object sender, System.EventArgs e)
		{
			CurrencyManager cm = (CurrencyManager)this.BindingContext[testDataset1,"TestData"];
			cm.Position--;
		}

		private void buttonNext_Click(object sender, System.EventArgs e)
		{
			CurrencyManager cm = (CurrencyManager)this.BindingContext[testDataset1,"TestData"];
			cm.Position++;
		}

		private void buttonLast_Click(object sender, System.EventArgs e)
		{
			CurrencyManager cm = (CurrencyManager)this.BindingContext[testDataset1,"TestData"];
			cm.Position=testDataset1.TestData.Rows.Count;
		}

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void buttonInitData_Click(object sender, System.EventArgs e)
		{
			InitData();
		}
	}
}
