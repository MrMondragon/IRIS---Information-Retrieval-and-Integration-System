using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Syntax.Parsers;
using QWhale.Editor;

namespace OwnerDraw
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
		private System.Windows.Forms.Label laIdentsColor;
		private QWhale.Common.ColorBox cbIdentsColor;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label laMethodBkColor;
		private QWhale.Common.ColorBox cbMethodBkColor;
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
			this.cbMethodBkColor = new QWhale.Common.ColorBox(this.components);
			this.laMethodBkColor = new System.Windows.Forms.Label();
			this.laIdentsColor = new System.Windows.Forms.Label();
			this.cbIdentsColor = new QWhale.Common.ColorBox(this.components);
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
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
			this.groupBox1.Controls.Add(this.cbMethodBkColor);
			this.groupBox1.Controls.Add(this.laMethodBkColor);
			this.groupBox1.Controls.Add(this.laIdentsColor);
			this.groupBox1.Controls.Add(this.cbIdentsColor);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 72);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Custom Draw";
			// 
			// cbMethodBkColor
			// 
			this.cbMethodBkColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbMethodBkColor.Location = new System.Drawing.Point(152, 40);
			this.cbMethodBkColor.Name = "cbMethodBkColor";
			this.cbMethodBkColor.SelectedColor = System.Drawing.SystemColors.Info;
			this.cbMethodBkColor.Size = new System.Drawing.Size(121, 21);
			this.cbMethodBkColor.TabIndex = 12;
			this.cbMethodBkColor.SelectedIndexChanged += new System.EventHandler(this.cbMethodBkColor_SelectedIndexChanged);
			// 
			// laMethodBkColor
			// 
			this.laMethodBkColor.AutoSize = true;
			this.laMethodBkColor.Location = new System.Drawing.Point(8, 43);
			this.laMethodBkColor.Name = "laMethodBkColor";
			this.laMethodBkColor.Size = new System.Drawing.Size(139, 16);
			this.laMethodBkColor.TabIndex = 11;
			this.laMethodBkColor.Text = "Method Background Color:";
			// 
			// laIdentsColor
			// 
			this.laIdentsColor.AutoSize = true;
			this.laIdentsColor.Location = new System.Drawing.Point(8, 19);
			this.laIdentsColor.Name = "laIdentsColor";
			this.laIdentsColor.Size = new System.Drawing.Size(68, 16);
			this.laIdentsColor.TabIndex = 10;
			this.laIdentsColor.Text = "Idents Color:";
			// 
			// cbIdentsColor
			// 
			this.cbIdentsColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbIdentsColor.Location = new System.Drawing.Point(152, 16);
			this.cbIdentsColor.Name = "cbIdentsColor";
			this.cbIdentsColor.SelectedColor = System.Drawing.Color.Teal;
			this.cbIdentsColor.Size = new System.Drawing.Size(121, 21);
			this.cbIdentsColor.TabIndex = 9;
			this.cbIdentsColor.SelectedIndexChanged += new System.EventHandler(this.cbIdentsColor_SelectedIndexChanged);
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
			this.laDescription.Text = "This demo shows ability to use owner drawing for edit control\'s text.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.csParser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 96);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Outlining.AllowOutlining = true;
			this.syntaxEdit1.Size = new System.Drawing.Size(568, 286);
			this.syntaxEdit1.TabIndex = 2;
			this.syntaxEdit1.Text = @"using System;

public class Person
{
   public int age;
   public string name;
}
/// <summary>
/// The main entry point for the application.
/// </summary>
public class MainClass 
{
   static void Main() 
   {
      Person p = new Person(); //test

      Console.Write(""Name: {0}, Age: {1}"",p.name, p.age);
   }
}";
			this.syntaxEdit1.Resize += new System.EventHandler(this.syntaxEdit1_Resize);
			this.syntaxEdit1.CustomDraw += new QWhale.Editor.CustomDrawEvent(this.syntaxEdit1_CustomDraw);
			this.syntaxEdit1.HorizontalScroll += new System.EventHandler(this.syntaxEdit1_HorizontalScroll);
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
			this.csParser1.TextReparsed += new System.EventHandler(this.csParser1_TextReparsed);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 382);
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

		private IComparer comparer = new RangeComparer();
		private ArrayList methods;
		private ArrayList comments;
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
			methods = new ArrayList();
			comments = new ArrayList();
		}

		private void syntaxEdit1_CustomDraw(object sender, QWhale.Editor.CustomDrawEventArgs e)
		{
			// drawing all identifier with different color
			if ((e.DrawStage == DrawStage.Before) && (((e.DrawState & DrawState.Text) != 0) && (e.DrawState & DrawState.Selection) == 0))
			{
				LexToken tok = (LexToken)(e.DrawInfo.Style - 1);
				if (tok == LexToken.Identifier)
					e.Painter.TextColor = cbIdentsColor.SelectedColor;
			}
			//fill button gradient
			if ((e.DrawStage == DrawStage.Before) && (DrawState.OutlineImage & e.DrawState) != 0)
			{
				Rectangle r = e.Rect;
				r.X++;
				r.Y++;
				r.Width--;
				r.Height--;
				e.Painter.FillGradient(r.X, r.Y, r.Width, r.Height, Color.Blue, Color.White, e.Rect.Location, new Point(r.Right, r.Bottom));
				e.Painter.ExcludeClipRect(e.Rect);
			}
			//fill method background
			if ((e.DrawStage == DrawStage.Before) && ((e.DrawState == DrawState.Text) || (e.DrawState == DrawState.BeyondEol)))
				if (DrawInMethod(syntaxEdit1.ScreenToText(e.Rect.Left, e.Rect.Top)))
					e.Painter.BackColor = cbMethodBkColor.SelectedColor;

			if ((e.DrawStage == DrawStage.Before) && (e.DrawState == DrawState.Control))
			{
				foreach(ISyntaxNode method in methods)
				{
					IOutlineRange outRange = syntaxEdit1.Outlining.GetOutlineRange(method.Range.StartPoint);
					if ((outRange != null) && outRange.Visible)
						DrawRangeRect(e.Painter, method.Range, Color.Red);
				}
			}
			if ((e.DrawState == DrawState.Control) && (e.DrawStage == DrawStage.After))
			{
				// drawing separator between methods
				int x1 = syntaxEdit1.ClientRect.Left + syntaxEdit1.Gutter.Rect.Width;
				int x2 = syntaxEdit1.ClientRect.Right;
				for (int i = 0; i < methods.Count; i++)
				{
					//int index = (int)methods[i];
					int index = ((ISyntaxNode)methods[i]).Range.EndPoint.Y + 1;
					Point pos = syntaxEdit1.DisplayToScreen(0, index);
					e.Painter.DrawLine(x1, pos.Y, x2, pos.Y, Color.Green, 1, DashStyle.Dot);
				}
				// draw rectangle around comments
				Point start = Point.Empty;
				Point end = Point.Empty;
				foreach(IRange range in comments)
					if (range.StartPoint.Y < syntaxEdit1.Lines.Count) 
						DrawRangeRect(e.Painter, range, Color.Gray);
			}
		}

		private void cbIdentsColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Invalidate();
		}
		private void ProcessNode(ISyntaxNode node)
		{
			if (node.NodeType == (int)NetNodeType.Method)
				methods.Add(node);
			if ((node.NodeType == (int)NetNodeType.Comment) || (node.NodeType == (int)NetNodeType.XmlComment))
				comments.Add(node.Range);
			if (node.HasChildren)
				for (int i = 0; i < node.ChildCount; i++)
					ProcessNode(node.ChildList[i]);
		}
		private void csParser1_TextReparsed(object sender, System.EventArgs e)
		{
			methods.Clear();
			comments.Clear();
			ProcessNode(csParser1.SyntaxTree.Root);
			syntaxEdit1.Invalidate();
		}
		private void syntaxEdit1_Resize(object sender, System.EventArgs e)
		{
			syntaxEdit1.Invalidate();
		}
		private Point[] GetPolygon(Point startPt, Point endPt, int h)
		{
			bool isRect = true;
			int right = syntaxEdit1.ClientRect.Right - 1;
			int left = syntaxEdit1.Gutter.Rect.Width;
			Point[] result;
			isRect = startPt.Y == endPt.Y;
			if (isRect)
				result = new Point[4];
			else
				result = new Point[8];
			for(int i = 0; i < result.Length; i++)
			{
				switch(i)
				{
					case 0:
						result[i] = startPt;
						break;
					case 1:
						result[i] = isRect ? endPt : new Point(right, startPt.Y);
						break;
					case 2:
						result[i] = isRect ? new Point(endPt.X, endPt.Y + h) : new Point(right, endPt.Y);
						break;
					case 3:
						result[i] = isRect ? new Point(startPt.X, startPt.Y + h) : endPt;
						break;
					case 4:
						result[i] = /*(startPt.X == endPt.X) ? endPt : */new Point(endPt.X, endPt.Y + h);
						break;
					case 5:
						result[i] = /*(startPt.X == endPt.X) ? endPt : */ new Point(left, endPt.Y + h);
						break;
					case 6:
						result[i] = /*(startPt.X == endPt.X) ? new Point(startPt.X, startPt.Y + h) :*/ new Point(left, startPt.Y + h);
						break;
					case 7:
						result[i] = new Point(startPt.X, startPt.Y + h);
						break;
				}
			}			
			return result;
		}
		private class RangeComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				Point pt = (Point)x; 

				Point sPt = ((IRange)y).StartPoint;
				Point ePt = ((IRange)y).EndPoint;
				if ((pt.Y < sPt.Y) || ((pt.Y == sPt.Y) && (pt.X < sPt.X))) 
					return - 1;
				else
					if ((pt.Y > ePt.Y) || ((pt.Y == ePt.Y) && (pt.X >= ePt.X))) 
					return 1;
				else
					return 0;
			}
		}
		private bool DrawInMethod(Point pt)
		{
			foreach(ISyntaxNode method in methods)
			{
				if (comparer.Compare(pt, method.Range) == 0)
					return true;
			}
			return false;
		}
		private void DrawRangeRect(IPainter painter, IRange range, Color color)
		{
			painter.ForeColor = color;
			int right = syntaxEdit1.ClientRect.Right - 1;
			int left = syntaxEdit1.Gutter.Rect.Width + 1;
			int h = painter.FontHeight;			

			Point startPt = syntaxEdit1.TextToScreen(range.StartPoint.X, range.StartPoint.Y);
			Point endPt = syntaxEdit1.TextToScreen(range.EndPoint.X, range.EndPoint.Y);
			startPt.X = Math.Max(startPt.X, left - 1);
			endPt.X = Math.Max(endPt.X, left - 1);
			
			if (range.EndPoint.X == int.MaxValue)
				endPt.X = syntaxEdit1.ClientRect.Right - 1;
			Point[] points = GetPolygon(startPt, endPt, h);
			for(int i = 0; i < points.Length; i++)
			{
				if (i < points.Length - 1)
				{
					if ((points[i].X <= points[i + 1].X) && (points[i].Y <= points[i + 1].Y))
						painter.DrawLine(points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
					else
						painter.DrawLine(points[i + 1].X, points[i + 1].Y, points[i].X, points[i].Y);
				}
				else
					painter.DrawLine(points[0].X, points[0].Y, points[i].X, points[i].Y);
			}
			Rectangle rect;
			for(int j = 0; j < points.Length; j++)
			{
				if (j < points.Length - 1)
				{
					if ((points[j].X <= points[j + 1].X) && (points[j].Y <= points[j + 1].Y))
						rect = new Rectangle(points[j].X, points[j].Y, Math.Max(1, points[j + 1].X - points[j].X), Math.Max(1, points[j + 1].Y - points[j].Y));
					else
						rect = new Rectangle(points[j + 1].X, points[j + 1].Y, Math.Max(1, points[j].X - points[j + 1].X), Math.Max(1, points[j].Y - points[j + 1].Y));
				}
				else
					rect = new Rectangle(points[0].X, points[0].Y, Math.Max(1, points[j].X - points[0].X), Math.Max(1, points[j].Y - points[0].Y));
				painter.ExcludeClipRect(rect);
			}
		}

		private void cbMethodBkColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			syntaxEdit1.Invalidate();
		}

		private void syntaxEdit1_HorizontalScroll(object sender, System.EventArgs e)
		{
			syntaxEdit1.Invalidate();
		}
	}
}
