using System;
using System.Drawing;
using System.Collections; 
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace FindDeclaration
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem miFind;
		private System.Windows.Forms.MenuItem miFindDeclaration;
		private System.Windows.Forms.MenuItem miFindReference;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem cmFindDeclaration;
		private System.Windows.Forms.MenuItem cmFindReference;
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
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
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.cmFindDeclaration = new System.Windows.Forms.MenuItem();
			this.cmFindReference = new System.Windows.Forms.MenuItem();
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.miFind = new System.Windows.Forms.MenuItem();
			this.miFindDeclaration = new System.Windows.Forms.MenuItem();
			this.miFindReference = new System.Windows.Forms.MenuItem();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.pnSettings.SuspendLayout();
			this.pnDescription.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 48);
			this.pnSettings.TabIndex = 1;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.ContextMenu = this.contextMenu1;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.HyperText.HighlightUrls = true;
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 48);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 270);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
			this.syntaxEdit1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.syntaxEdit1_MouseMove);
			this.syntaxEdit1.SourceStateChanged += new QWhale.Editor.NotifyEvent(this.syntaxEdit1_SourceStateChanged);
			this.syntaxEdit1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.syntaxEdit1_MouseUp);
			this.syntaxEdit1.JumpToUrl += new QWhale.Editor.UrlJumpEvent(this.syntaxEdit1_JumpToUrl);
			this.syntaxEdit1.MouseLeave += new System.EventHandler(this.syntaxEdit1_MouseLeave);
			this.syntaxEdit1.CustomDraw += new QWhale.Editor.CustomDrawEvent(this.syntaxEdit1_CustomDraw);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.cmFindDeclaration,
																						 this.cmFindReference});
			this.contextMenu1.Popup += new System.EventHandler(this.miFind_Popup);
			// 
			// cmFindDeclaration
			// 
			this.cmFindDeclaration.Index = 0;
			this.cmFindDeclaration.Text = "Find Declaration";
			this.cmFindDeclaration.Click += new System.EventHandler(this.miFindDeclaration_Click);
			// 
			// cmFindReference
			// 
			this.cmFindReference.Index = 1;
			this.cmFindReference.Text = "Find Reference";
			this.cmFindReference.Click += new System.EventHandler(this.miFindReference_Click);
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
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miFind});
			// 
			// miFind
			// 
			this.miFind.Index = 0;
			this.miFind.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miFindDeclaration,
																				   this.miFindReference});
			this.miFind.Text = "Find";
			this.miFind.Popup += new System.EventHandler(this.miFind_Popup);
			// 
			// miFindDeclaration
			// 
			this.miFindDeclaration.Index = 0;
			this.miFindDeclaration.Text = "Declaration";
			this.miFindDeclaration.Click += new System.EventHandler(this.miFindDeclaration_Click);
			// 
			// miFindReference
			// 
			this.miFindReference.Index = 1;
			this.miFindReference.Text = "Reference";
			this.miFindReference.Click += new System.EventHandler(this.miFindReference_Click);
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(568, 48);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 48);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "The demo shows how to use Find Declaration/Find References of language elements w" +
				"ithin Edit control\'s content. Hit ctrl key and click on identifier or use popup " +
				"menu to find declaration of the element.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 318);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.pnSettings);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.pnDescription.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private SyntaxNodes references;
		private bool isDefinition;
		private Point definitionOrigin = new Point( - 1, - 1);
		private Point definitionDest = new Point( - 1, - 1);
		private int definitionLength;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


		private void ClearReferences()
		{
			if (references != null && references.Count >= 0)
			{
				references.Clear();
				syntaxEdit1.Invalidate();
			}
		}
		private void FindReferences()
		{
			if ((syntaxEdit1 != null) && (syntaxEdit1.Lexer != null) && (syntaxEdit1.Lexer is ISyntaxParser))
			{
				ISyntaxNode node = ((ISyntaxParser)syntaxEdit1.Lexer).FindDeclaration(string.Empty, syntaxEdit1.Position) as ISyntaxNode;
				if (node != null)
				{
					Point pt1 = node.Position;
					ISyntaxAttribute attr = node.FindAttribute(SyntaxConsts.DeclarationScope);
					Point pt2 = (attr != null) ? attr.Position : node.Range.EndPoint;
					syntaxEdit1.Selection.SetSelection(SelectionType.Stream, pt1, pt2);
					((ISyntaxParser)syntaxEdit1.Lexer).FindReferences(node, references);
					syntaxEdit1.Invalidate();
				}
				else
					ClearReferences();
			}
		}
		private void DoCustomDraw(object sender, CustomDrawEventArgs e)
		{
			// drawing rectangle around the found references (references are filled when executing FindReference popup menu).
			if ((references.Count > 0) && (e.DrawStage == DrawStage.After) && (e.DrawState == DrawState.Control))
			{
				e.Painter.ForeColor = Color.Navy;
				e.Painter.BackColor = Color.Navy;
				foreach(ISyntaxNode node in references)
				{
					if (sender is EditSyntaxPaint)
					{
						EditSyntaxPaint sPaint = (EditSyntaxPaint)sender;						
						Rectangle r = new Rectangle(node.Position, new Size(node.Range.EndPoint.X - node.Position.X, node.Range.EndPoint.Y - node.Position.Y));
						Point pt1 = sPaint.Owner.TextToScreen(r.Location);
						Point pt2 = sPaint.Owner.TextToScreen(new Point(r.Right, r.Bottom));
						pt2.Y += e.Painter.FontHeight;
						e.Painter.DrawRectangle(pt1.X, pt1.Y, pt2.X - pt1.X, pt2.Y - pt1.Y);
					}
				}
			}
		}
		private bool UpdateGotoDeclaration(bool jump)
		{
			bool result = false;
			if ((syntaxEdit1 != null) && (syntaxEdit1.Lexer != null) && (syntaxEdit1.Lexer is ISyntaxParser))
			{
				ISyntaxNode node = ((ISyntaxParser)syntaxEdit1.Lexer).FindDeclaration(string.Empty, syntaxEdit1.Position) as ISyntaxNode;
				if (node != null)
				{
					result = true;
					if (jump)
					{
						syntaxEdit1.Position = node.Position;
						syntaxEdit1.Invalidate();
					}
				}
			}
			return result;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			references = new SyntaxNodes();
		}

		private void syntaxEdit1_CustomDraw(object sender, QWhale.Editor.CustomDrawEventArgs e)
		{
			DoCustomDraw(sender, e);
		}

		private void miFind_Popup(object sender, System.EventArgs e)
		{
			miFindDeclaration.Enabled = UpdateGotoDeclaration(false);
			miFindReference.Enabled = miFindDeclaration.Enabled;
			cmFindDeclaration.Enabled = UpdateGotoDeclaration(false);
			cmFindReference.Enabled = miFindDeclaration.Enabled;
		}

		private void miFindDeclaration_Click(object sender, System.EventArgs e)
		{
			UpdateGotoDeclaration(true);
		}

		private void miFindReference_Click(object sender, System.EventArgs e)
		{
			FindReferences();
		}
		private void UpdateGotoDef(SyntaxEdit edit)
		{
			// updating identifiers that have declaration when moving mouse with Ctrl key pressed
			UpdateGotoDef(edit, definitionOrigin.Y, definitionOrigin.X, definitionLength, false);
		}
		private void UpdateGotoDef(SyntaxEdit edit, int line, int start, int len, bool isSet)
		{
			Point pt = new Point(start, line);
			if ((definitionOrigin == pt) && (isDefinition == isSet) && (definitionLength == len))
				return;
			if (isSet)
			{
				UpdateGotoDef(edit);
				definitionOrigin = new Point(start, line);
				definitionLength = len;
			}
			else
			{
				definitionLength = 0;
				definitionOrigin = new Point(- 1, - 1);
				definitionDest = new Point( - 1,  - 1);
			}
			isDefinition = isSet;
			IStrItem item =  edit.Lines.GetItem(line);
			if ((item != null) && (start >= 0) && (start < item.ColorData.Length))
			{
				item.SetColorFlag(start, Math.Min(len, item.ColorData.Length - start), ColorFlags.HyperText, isSet);
				edit.Source.BeginUpdate(UpdateReason.Other);
				try
				{
					edit.Source.LinesChanged(line, line, false);
					edit.Source.State |= NotifyState.BlockChanged;						
				}
				finally
				{
					edit.Source.EndUpdate();
				}
			}
		}
		public bool GotoDefinition(Point pt, bool jump, SyntaxEdit edit)
		{
			// jumping to the delcaration when mouse button is released
			if (!(edit.Lexer is ISyntaxParser))
				return false;
			ISyntaxParser parser = (ISyntaxParser)edit.Lexer;
			bool result = false;
			string s = edit.Lines[pt.Y];
			int left;
			int right;
			if (edit.Lines.GetWord(pt.Y, pt.X, out left, out right))
			{
				string name = s.Substring(left, right - left + 1); 
				ISyntaxNode node = parser.FindDeclaration(s, pt) as ISyntaxNode;
				if ((node != null) && (string.Compare(node.Name, name, !parser.CaseSensitive) == 0))
				{
					definitionDest = node.Position;
					UpdateGotoDef(edit, pt.Y, left, right - left + 1, true); 
				}
				else
					UpdateGotoDef(edit);
				result = node != null;
			}
			else
				UpdateGotoDef(edit);
			if (jump & isDefinition)
			{
				pt = definitionDest; 
				UpdateGotoDef(edit);
				edit.MoveTo(pt);
			}
			return result;
		}

		private void syntaxEdit1_MouseLeave(object sender, System.EventArgs e)
		{
			UpdateGotoDef((SyntaxEdit)sender);
		}

		private void syntaxEdit1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (isDefinition)
			{
				SyntaxEdit edit = (SyntaxEdit)sender;
				Point pt = definitionDest; 
				UpdateGotoDef(edit);
				edit.MoveTo(pt);
			}
		}
		private void syntaxEdit1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			SyntaxEdit edit = (SyntaxEdit)sender;
			if ((Control.ModifierKeys & Keys.Control) != 0)
			{
				Point Pt = edit.ScreenToText(e.X, e.Y);
				GotoDefinition(Pt, false, edit);
			}
			else
				UpdateGotoDef(edit);
		}
		private void syntaxEdit1_JumpToUrl(object sender, QWhale.Editor.UrlJumpEventArgs e)
		{
			e.Handled = isDefinition;
		}

		private void syntaxEdit1_SourceStateChanged(object sender, QWhale.Editor.NotifyEventArgs e)
		{
			if ((e.State & NotifyState.PositionChanged) != 0)
				ClearReferences();
		}
	}
}
