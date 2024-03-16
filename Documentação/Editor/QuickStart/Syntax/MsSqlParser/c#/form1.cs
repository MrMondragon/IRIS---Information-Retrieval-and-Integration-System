using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Syntax.Parsers;
using QWhale.Editor;

namespace MsSqlParser
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
		private QWhale.Syntax.Parsers.MSSQLParser mssqlParser1;
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
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.mssqlParser1 = new QWhale.Syntax.Parsers.MSSQLParser();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.pnSettings = new System.Windows.Forms.Panel();
			this.pnDescription.SuspendLayout();
			this.pnSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Braces.BracesOptions = QWhale.Editor.BracesOptions.Highlight;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.mssqlParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 32);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Outlining.AllowOutlining = true;
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 286);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = @"select 
	P.Name as [Site], 
	JE.Place, 
	count(distinct ES.ApplicantFK) as Hits, 
	ISNULL(T1.Hits, 0) as Departs, 
	min(JE.AsOfDate) as FirstAccessDate, 
	max(JE.AsOfDate) as LastAccessDate, 
	max(JE.OrderNum) as OrderNum 
	from JournalEntry JE inner join 
		EnrollmentSession ES on JE.EnrollmentSessionFK = ES.PK inner join 
		Applicant A on ES.ApplicantFK = A.PK inner join 
		Portfolio P on A.PortfolioFK = P.PK left outer join 
		( 
			select P.Name as [Site], JE.Place, count(distinct ES.ApplicantFK) as Hits, min(JE.AsOfDate) as FirstAccessdate, max(JE.AsOfDate) as LastAccessDate 
				from JournalEntry JE inner join 
					EnrollmentSession ES on JE.EnrollmentSessionFK = ES.PK inner join 
					Applicant A on ES.ApplicantFK = A.PK inner join 
					Portfolio P on A.PortfolioFK = P.PK 
				where JE.PK in ( 
						select max(JE.PK) 
							from JournalEntry JE inner join 
								EnrollmentSession ES on JE.EnrollmentSessionFK = ES.PK 
							where 
								JE.AsOfDate >= @StartDate and JE.AsOfDate < DATEADD(d, 1, @EndDate) 
							group by JE.EnrollmentSessionFK 
						) 
					and P.PK = @PortfolioID 
				group by P.Name, JE.Place 
			) T1 on P.Name = T1.Site and JE.Place = T1.Place 
	where 
		JE.AsOfDate >= @StartDate and JE.AsOfDate < DATEADD(d, 1, @EndDate) 
		and P.PK = @PortfolioID 
	group by P.Name, JE.Place, T1.Hits 
	order by T1.Site, T1.OrderNum ";
			// 
			// mssqlParser1
			// 
			this.mssqlParser1.CodeCompletionChars = new char[] {
																   '.'};
			this.mssqlParser1.DefaultState = 0;
			this.mssqlParser1.Options = ((QWhale.Syntax.SyntaxOptions)((((QWhale.Syntax.SyntaxOptions.Outline | QWhale.Syntax.SyntaxOptions.SmartIndent) 
				| QWhale.Syntax.SyntaxOptions.CodeCompletion) 
				| QWhale.Syntax.SyntaxOptions.SyntaxErrors)));
			this.mssqlParser1.XmlScheme = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<LexScheme xmlns:xsd=\"http://www.w3.org/" +
				"2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Autho" +
				"r>Quantum Whale LLC.</Author>\r\n  <Name />\r\n  <Desc />\r\n  <Copyright>Copyright (c" +
				") 2004, 2005 Quantum Whale LLC.</Copyright>\r\n  <FileExtension />\r\n  <FileType />" +
				"\r\n  <Version>1.1</Version>\r\n  <Styles>\r\n    <Style>\r\n      <Name>idents</Name>\r\n" +
				"      <ForeColor>Teal</ForeColor>\r\n      <Index>0</Index>\r\n    </Style>\r\n    <St" +
				"yle>\r\n      <Name>numbers</Name>\r\n      <ForeColor>Green</ForeColor>\r\n      <Ind" +
				"ex>1</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>reswords</Name>\r\n      <For" +
				"eColor>Blue</ForeColor>\r\n      <Index>2</Index>\r\n    </Style>\r\n    <Style>\r\n    " +
				"  <Name>comments</Name>\r\n      <ForeColor>Green</ForeColor>\r\n      <Index>3</Ind" +
				"ex>\r\n      <PlainText>true</PlainText>\r\n    </Style>\r\n    <Style>\r\n      <Name>x" +
				"mlcomments</Name>\r\n      <ForeColor>Gray</ForeColor>\r\n      <Index>4</Index>\r\n  " +
				"  </Style>\r\n    <Style>\r\n      <Name>symbols</Name>\r\n      <ForeColor>Gray</Fore" +
				"Color>\r\n      <Index>5</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>whitespac" +
				"e</Name>\r\n      <ForeColor>WindowText</ForeColor>\r\n      <Index>6</Index>\r\n    <" +
				"/Style>\r\n    <Style>\r\n      <Name>strings</Name>\r\n      <ForeColor>Maroon</ForeC" +
				"olor>\r\n      <Index>7</Index>\r\n      <PlainText>true</PlainText>\r\n    </Style>\r\n" +
				"    <Style>\r\n      <Name>directives</Name>\r\n      <ForeColor>Navy</ForeColor>\r\n " +
				"     <Index>8</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>syntaxerrors</Name" +
				">\r\n      <ForeColor>Red</ForeColor>\r\n      <Index>9</Index>\r\n    </Style>\r\n  </S" +
				"tyles>\r\n  <States />\r\n</LexScheme>";
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(568, 32);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 32);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows how to use Ms Sql Parser with code completion for tables and its " +
				"fields.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 32);
			this.pnSettings.TabIndex = 1;
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
			this.pnDescription.ResumeLayout(false);
			this.pnSettings.ResumeLayout(false);
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
			ICodeCompletionRepository completionRepository = mssqlParser1.CompletionRepository;
			TableItem table = new TableItem("JournalEntry");
			table.Fields.Add("EnrollmentSessionFK");
			table.Fields.Add("Place");
			table.Fields.Add("AsOfDate");
			table.Fields.Add("OrderNum");
			table.Fields.Add("PK");
			((SqlRepository)completionRepository).Tables.Add(table);

			table = new TableItem("EnrollmentSession");
			table.Fields.Add("ApplicantFK");
			table.Fields.Add("PK");
			((SqlRepository)completionRepository).Tables.Add(table);

			table = new TableItem("Portfolio");
			table.Fields.Add("Name");
			table.Fields.Add("PK");
			((SqlRepository)completionRepository).Tables.Add(table);
		}
	}
}
