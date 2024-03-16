#region Copyright (c) 2004 - 2007 Quantum Whale LLC.
/*
	Quantum Whale .NET Component Library
	Editor.NET Main Demo

	Copyright (c) 2004 - 2007 Quantum Whale LLC.
	ALL RIGHTS RESERVED

	http://www.qwhale.net
	contact@qwhale.net
*/
#endregion Copyright (c) 2004 - 2007 Quantum Whale LLC.
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Syntax;
using QWhale.Editor;
using QWhale.Editor.Dialogs;
using System.ComponentModel.Design;

namespace MainDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnMain;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog2;
		private System.Windows.Forms.Panel pnManage;
		public System.Windows.Forms.TabControl tcContainer;
		public System.Windows.Forms.TabPage tpGutter;
		private System.Windows.Forms.GroupBox gbGutter;
		private System.Windows.Forms.Button btShowBookmarks;
		private System.Windows.Forms.CheckBox chbPaintBookMarks;
		private System.Windows.Forms.CheckBox chbDrawLineBookmarks;
		private System.Windows.Forms.Label laGutterWidth;
		private System.Windows.Forms.NumericUpDown nudGutterWidth;
		private System.Windows.Forms.CheckBox chbShowGutter;
		private System.Windows.Forms.GroupBox gbNavigateOptions;
		private System.Windows.Forms.CheckBox chbMoveOnRightButton;
		private System.Windows.Forms.CheckBox chbDownAtLineEnd;
		private System.Windows.Forms.CheckBox chbUpAtLineBegin;
		private System.Windows.Forms.CheckBox chbBeyondEof;
		private System.Windows.Forms.CheckBox chbBeyondEol;
		private System.Windows.Forms.TabPage tpMargin;
		private System.Windows.Forms.TabPage tpLineNumbers;
		public System.Windows.Forms.TabPage tpDialogs;
		private System.Windows.Forms.Panel pnDialogs;
		private System.Windows.Forms.TabPage tpTextSource;
		private System.Windows.Forms.Panel pnTextSource;
		private System.Windows.Forms.Label laSource;
		private System.Windows.Forms.TabPage tpSpellAndUrl;
		private System.Windows.Forms.Panel pnSpellAndUrl;
		private System.Windows.Forms.CheckBox chbSmoothScroll;
		private System.Windows.Forms.CheckBox chbShowScrollHint;
		private System.Windows.Forms.CheckBox chbHighlightUrls;
		private System.Windows.Forms.CheckBox chbCheckSpelling;
		private System.Windows.Forms.TabPage tpOutlining;
		private System.Windows.Forms.Panel pnOutlining;
		private System.Windows.Forms.GroupBox gbOutlining;
		private System.Windows.Forms.CheckBox chbAllowOutlining;
		private System.Windows.Forms.CheckBox chbDrawButtons;
		private System.Windows.Forms.CheckBox chbDrawLines;
		private System.Windows.Forms.CheckBox chbDrawOnGutter;
		private System.Windows.Forms.CheckBox chbShowHints;
		public System.Windows.Forms.TabPage tpPrinting;
		private System.Windows.Forms.Panel pnPrinting;
		public System.Windows.Forms.TabPage tpWordWrap;
		private System.Windows.Forms.Panel pnWordWrap;
		private System.Windows.Forms.GroupBox gbWordWrap;
		private System.Windows.Forms.CheckBox chbWrapAtMargin;
		private System.Windows.Forms.CheckBox chbWordWrap;
		private System.Windows.Forms.TabPage tpCompanyInfo;
		private System.Windows.Forms.Panel pnGutter;
		private System.Windows.Forms.Panel pnMargin;
		private System.Windows.Forms.GroupBox gbMargin;
		private System.Windows.Forms.CheckBox chbShowMargin;
		private System.Windows.Forms.NumericUpDown nudMarginPos;
		private System.Windows.Forms.Label laMarginPos;
		private System.Windows.Forms.CheckBox chbHighlightCurrentLine;
		private System.Windows.Forms.Panel pnLineNumbers;
		private System.Windows.Forms.GroupBox gbLineNumbers;
		private System.Windows.Forms.Label laLineNumbersStart;
		private System.Windows.Forms.NumericUpDown nudLineNumbersStart;
		private System.Windows.Forms.ComboBox cbLineNumbersAlign;
		private System.Windows.Forms.Label laLineNumbersAlign;
		private System.Windows.Forms.CheckBox chbLinesOnGutter;
		private System.Windows.Forms.CheckBox chbLineNumbers;
		private System.Windows.Forms.CheckBox chbLinesBeyondEof;
		private System.Windows.Forms.TabPage tpNavigate;
		private System.Windows.Forms.Panel pnNavigate;
		private System.Windows.Forms.TabPage tpSelection;
		private System.Windows.Forms.Panel pnSelection;
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
		private System.Windows.Forms.GroupBox gbSpellAndUrl;
		private System.Windows.Forms.GroupBox gbDialogs;
		private System.Windows.Forms.Button btCustomize;
		private System.Windows.Forms.Button btGoto;
		private System.Windows.Forms.Button btReplace;
		private System.Windows.Forms.Button btFind;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btLoad;
		private System.Windows.Forms.GroupBox gbPrint;
		private System.Windows.Forms.Button btPrintSetup;
		private System.Windows.Forms.Button btPrint;
		private System.Windows.Forms.Button btPrintPreview;
		private System.Windows.Forms.Button btXml;
		private System.Windows.Forms.Button btHtml;
		private System.Windows.Forms.Button btRtf;
		private System.Windows.Forms.CheckBox chbShowHyperTextHints;
		private System.Windows.Forms.TabPage tpOther;
		private System.Windows.Forms.Panel pnOther;
		private System.Windows.Forms.CheckBox chbSeparateLines;
		private System.Windows.Forms.CheckBox chbWhiteSpaceVisible;
		private System.Windows.Forms.GroupBox gbOther;
		private System.Windows.Forms.TabPage tpPageLayout;
		private System.Windows.Forms.Panel pnPageLayout;
		private System.Windows.Forms.Label laPageLayout;
		private System.Windows.Forms.ComboBox cbPageLayout;
		private System.Windows.Forms.ComboBox cbPageSize;
		private System.Windows.Forms.Label laPageSize;
		private System.Windows.Forms.CheckBox chbRulerAllowDrag;
		private System.Windows.Forms.CheckBox chbRulerDisplayDragLines;
		private System.Windows.Forms.CheckBox chbHighlightBraces;
		private System.Windows.Forms.CheckBox chbUseRoundRect;
		private System.Windows.Forms.CheckBox chbAllowDragMargin;
		private System.Windows.Forms.CheckBox chbShowMarginHints;
		private System.Windows.Forms.CheckBox chbTransparent;
		private System.Windows.Forms.GroupBox gbPages;
		private System.Windows.Forms.GroupBox gbRulers;
		private System.Windows.Forms.Label laRulerUnits;
		private System.Windows.Forms.ComboBox cbRulerUnits;
		private System.Windows.Forms.GroupBox gbBraces;
		private System.Windows.Forms.CheckBox cbTempHighlightBraces;
		private System.Windows.Forms.CheckBox chbHorzRuler;
		private System.Windows.Forms.CheckBox chbVertRuler;
		private System.Windows.Forms.CheckBox chbRulerDiscrete;
		private System.Windows.Forms.CheckBox chbLineModificator;
		private System.Windows.Forms.CheckBox chbAllowSplit;
		private System.Windows.Forms.CheckBox chbScrollButtons;
		private QWhale.Editor.TextSource textSource1;
		private QWhale.Syntax.Parsers.CsParser csParser1;
		private System.Windows.Forms.ImageList imageList2;
		public System.Windows.Forms.Panel pnCompanyInfo;
		private System.Windows.Forms.TextBox tbCompanyInfo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label laMailTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label laAdress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label laCompany;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.CheckBox chbSystemScrollBars;
		private System.Windows.Forms.CheckBox chbFlatScrollBars;

		private const string sXmlFileFilter = "Rtf files (*.rtf)|*.rtf|Html files (*.html; *.htm)|*.html;*.htm|Xml files (*.xml)|*.xml|All files (*.*)|*.*";
		private SyntaxSettings GlobalSettings;
		private DlgSyntaxSettings Options;
		private const string sFileFilter = "Text files (*.txt)|*.txt|C # files (*.cs)|*.cs|All files (*.*)|*.*";
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TabPage tpProperties;
		private System.Windows.Forms.Panel pnProperties;
		private System.Windows.Forms.Panel pnPropertyGrid;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel pnEditContainer;
		private QWhale.Editor.SyntaxEdit syntaxEdit;
		private System.Windows.Forms.Splitter splitter1;
		private QWhale.Editor.SyntaxEdit syntaxSplitEdit;
		private System.Windows.Forms.CheckBox chbQuickInfoTips;
		private System.Windows.Forms.CheckBox chbDrawColumnsIndent;
		private System.Windows.Forms.CheckBox chbColumnsVisible;
		private int scrollBoxUpdate;

		public MainForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			QWhale.Editor.ScrollingButton scrollingButton1 = new QWhale.Editor.ScrollingButton();
			QWhale.Editor.ScrollingButton scrollingButton2 = new QWhale.Editor.ScrollingButton();
			QWhale.Editor.ScrollingButton scrollingButton3 = new QWhale.Editor.ScrollingButton();
			QWhale.Editor.ScrollingButton scrollingButton4 = new QWhale.Editor.ScrollingButton();
			QWhale.Editor.ScrollingButton scrollingButton5 = new QWhale.Editor.ScrollingButton();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.pnMain = new System.Windows.Forms.Panel();
			this.pnEditContainer = new System.Windows.Forms.Panel();
			this.syntaxEdit = new QWhale.Editor.SyntaxEdit(this.components);
			this.csParser1 = new QWhale.Syntax.Parsers.CsParser();
			this.textSource1 = new QWhale.Editor.TextSource(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.syntaxSplitEdit = new QWhale.Editor.SyntaxEdit(this.components);
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.pnPropertyGrid = new System.Windows.Forms.Panel();
			this.pnManage = new System.Windows.Forms.Panel();
			this.tcContainer = new System.Windows.Forms.TabControl();
			this.tpGutter = new System.Windows.Forms.TabPage();
			this.pnGutter = new System.Windows.Forms.Panel();
			this.gbGutter = new System.Windows.Forms.GroupBox();
			this.btShowBookmarks = new System.Windows.Forms.Button();
			this.chbPaintBookMarks = new System.Windows.Forms.CheckBox();
			this.chbDrawLineBookmarks = new System.Windows.Forms.CheckBox();
			this.laGutterWidth = new System.Windows.Forms.Label();
			this.nudGutterWidth = new System.Windows.Forms.NumericUpDown();
			this.chbShowGutter = new System.Windows.Forms.CheckBox();
			this.tpCompanyInfo = new System.Windows.Forms.TabPage();
			this.pnCompanyInfo = new System.Windows.Forms.Panel();
			this.tbCompanyInfo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.laMailTo = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.laAdress = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.laCompany = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tpMargin = new System.Windows.Forms.TabPage();
			this.pnMargin = new System.Windows.Forms.Panel();
			this.gbMargin = new System.Windows.Forms.GroupBox();
			this.chbShowMarginHints = new System.Windows.Forms.CheckBox();
			this.chbAllowDragMargin = new System.Windows.Forms.CheckBox();
			this.nudMarginPos = new System.Windows.Forms.NumericUpDown();
			this.laMarginPos = new System.Windows.Forms.Label();
			this.chbShowMargin = new System.Windows.Forms.CheckBox();
			this.tpWordWrap = new System.Windows.Forms.TabPage();
			this.pnWordWrap = new System.Windows.Forms.Panel();
			this.gbWordWrap = new System.Windows.Forms.GroupBox();
			this.chbFlatScrollBars = new System.Windows.Forms.CheckBox();
			this.chbSystemScrollBars = new System.Windows.Forms.CheckBox();
			this.chbScrollButtons = new System.Windows.Forms.CheckBox();
			this.chbAllowSplit = new System.Windows.Forms.CheckBox();
			this.chbWrapAtMargin = new System.Windows.Forms.CheckBox();
			this.chbWordWrap = new System.Windows.Forms.CheckBox();
			this.chbShowScrollHint = new System.Windows.Forms.CheckBox();
			this.chbSmoothScroll = new System.Windows.Forms.CheckBox();
			this.tpTextSource = new System.Windows.Forms.TabPage();
			this.pnTextSource = new System.Windows.Forms.Panel();
			this.laSource = new System.Windows.Forms.Label();
			this.tpPageLayout = new System.Windows.Forms.TabPage();
			this.pnPageLayout = new System.Windows.Forms.Panel();
			this.gbRulers = new System.Windows.Forms.GroupBox();
			this.chbVertRuler = new System.Windows.Forms.CheckBox();
			this.chbHorzRuler = new System.Windows.Forms.CheckBox();
			this.cbRulerUnits = new System.Windows.Forms.ComboBox();
			this.laRulerUnits = new System.Windows.Forms.Label();
			this.chbRulerDisplayDragLines = new System.Windows.Forms.CheckBox();
			this.chbRulerDiscrete = new System.Windows.Forms.CheckBox();
			this.chbRulerAllowDrag = new System.Windows.Forms.CheckBox();
			this.gbPages = new System.Windows.Forms.GroupBox();
			this.cbPageSize = new System.Windows.Forms.ComboBox();
			this.laPageSize = new System.Windows.Forms.Label();
			this.cbPageLayout = new System.Windows.Forms.ComboBox();
			this.laPageLayout = new System.Windows.Forms.Label();
			this.tpSpellAndUrl = new System.Windows.Forms.TabPage();
			this.pnSpellAndUrl = new System.Windows.Forms.Panel();
			this.gbSpellAndUrl = new System.Windows.Forms.GroupBox();
			this.chbShowHyperTextHints = new System.Windows.Forms.CheckBox();
			this.chbCheckSpelling = new System.Windows.Forms.CheckBox();
			this.chbHighlightUrls = new System.Windows.Forms.CheckBox();
			this.tpProperties = new System.Windows.Forms.TabPage();
			this.pnProperties = new System.Windows.Forms.Panel();
			this.tpOutlining = new System.Windows.Forms.TabPage();
			this.pnOutlining = new System.Windows.Forms.Panel();
			this.gbOutlining = new System.Windows.Forms.GroupBox();
			this.chbAllowOutlining = new System.Windows.Forms.CheckBox();
			this.chbDrawButtons = new System.Windows.Forms.CheckBox();
			this.chbDrawLines = new System.Windows.Forms.CheckBox();
			this.chbDrawOnGutter = new System.Windows.Forms.CheckBox();
			this.chbShowHints = new System.Windows.Forms.CheckBox();
			this.tpPrinting = new System.Windows.Forms.TabPage();
			this.pnPrinting = new System.Windows.Forms.Panel();
			this.gbPrint = new System.Windows.Forms.GroupBox();
			this.btPrintSetup = new System.Windows.Forms.Button();
			this.btPrint = new System.Windows.Forms.Button();
			this.btPrintPreview = new System.Windows.Forms.Button();
			this.btXml = new System.Windows.Forms.Button();
			this.btHtml = new System.Windows.Forms.Button();
			this.btRtf = new System.Windows.Forms.Button();
			this.tpSelection = new System.Windows.Forms.TabPage();
			this.pnSelection = new System.Windows.Forms.Panel();
			this.gbSelection = new System.Windows.Forms.GroupBox();
			this.chbOverwriteBlocks = new System.Windows.Forms.CheckBox();
			this.chbPersistentBlocks = new System.Windows.Forms.CheckBox();
			this.chbDeselectOnCopy = new System.Windows.Forms.CheckBox();
			this.chbSelectLineOnDblClick = new System.Windows.Forms.CheckBox();
			this.chbHideSelection = new System.Windows.Forms.CheckBox();
			this.chbUseColors = new System.Windows.Forms.CheckBox();
			this.chbSelectBeyondEol = new System.Windows.Forms.CheckBox();
			this.chbDisableDragging = new System.Windows.Forms.CheckBox();
			this.chbDisableSelection = new System.Windows.Forms.CheckBox();
			this.tpNavigate = new System.Windows.Forms.TabPage();
			this.pnNavigate = new System.Windows.Forms.Panel();
			this.gbNavigateOptions = new System.Windows.Forms.GroupBox();
			this.chbMoveOnRightButton = new System.Windows.Forms.CheckBox();
			this.chbDownAtLineEnd = new System.Windows.Forms.CheckBox();
			this.chbUpAtLineBegin = new System.Windows.Forms.CheckBox();
			this.chbBeyondEof = new System.Windows.Forms.CheckBox();
			this.chbBeyondEol = new System.Windows.Forms.CheckBox();
			this.tpLineNumbers = new System.Windows.Forms.TabPage();
			this.pnLineNumbers = new System.Windows.Forms.Panel();
			this.gbLineNumbers = new System.Windows.Forms.GroupBox();
			this.chbLineModificator = new System.Windows.Forms.CheckBox();
			this.laLineNumbersStart = new System.Windows.Forms.Label();
			this.nudLineNumbersStart = new System.Windows.Forms.NumericUpDown();
			this.cbLineNumbersAlign = new System.Windows.Forms.ComboBox();
			this.laLineNumbersAlign = new System.Windows.Forms.Label();
			this.chbLinesOnGutter = new System.Windows.Forms.CheckBox();
			this.chbLineNumbers = new System.Windows.Forms.CheckBox();
			this.chbLinesBeyondEof = new System.Windows.Forms.CheckBox();
			this.chbHighlightCurrentLine = new System.Windows.Forms.CheckBox();
			this.tpOther = new System.Windows.Forms.TabPage();
			this.pnOther = new System.Windows.Forms.Panel();
			this.gbBraces = new System.Windows.Forms.GroupBox();
			this.cbTempHighlightBraces = new System.Windows.Forms.CheckBox();
			this.chbUseRoundRect = new System.Windows.Forms.CheckBox();
			this.chbHighlightBraces = new System.Windows.Forms.CheckBox();
			this.gbOther = new System.Windows.Forms.GroupBox();
			this.chbTransparent = new System.Windows.Forms.CheckBox();
			this.chbSeparateLines = new System.Windows.Forms.CheckBox();
			this.chbWhiteSpaceVisible = new System.Windows.Forms.CheckBox();
			this.tpDialogs = new System.Windows.Forms.TabPage();
			this.pnDialogs = new System.Windows.Forms.Panel();
			this.gbDialogs = new System.Windows.Forms.GroupBox();
			this.btCustomize = new System.Windows.Forms.Button();
			this.btGoto = new System.Windows.Forms.Button();
			this.btReplace = new System.Windows.Forms.Button();
			this.btFind = new System.Windows.Forms.Button();
			this.btSave = new System.Windows.Forms.Button();
			this.btLoad = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
			this.chbQuickInfoTips = new System.Windows.Forms.CheckBox();
			this.chbDrawColumnsIndent = new System.Windows.Forms.CheckBox();
			this.chbColumnsVisible = new System.Windows.Forms.CheckBox();
			this.pnMain.SuspendLayout();
			this.pnEditContainer.SuspendLayout();
			this.pnManage.SuspendLayout();
			this.tcContainer.SuspendLayout();
			this.tpGutter.SuspendLayout();
			this.pnGutter.SuspendLayout();
			this.gbGutter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudGutterWidth)).BeginInit();
			this.tpCompanyInfo.SuspendLayout();
			this.pnCompanyInfo.SuspendLayout();
			this.tpMargin.SuspendLayout();
			this.pnMargin.SuspendLayout();
			this.gbMargin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMarginPos)).BeginInit();
			this.tpWordWrap.SuspendLayout();
			this.pnWordWrap.SuspendLayout();
			this.gbWordWrap.SuspendLayout();
			this.tpTextSource.SuspendLayout();
			this.pnTextSource.SuspendLayout();
			this.tpPageLayout.SuspendLayout();
			this.pnPageLayout.SuspendLayout();
			this.gbRulers.SuspendLayout();
			this.gbPages.SuspendLayout();
			this.tpSpellAndUrl.SuspendLayout();
			this.pnSpellAndUrl.SuspendLayout();
			this.gbSpellAndUrl.SuspendLayout();
			this.tpProperties.SuspendLayout();
			this.tpOutlining.SuspendLayout();
			this.pnOutlining.SuspendLayout();
			this.gbOutlining.SuspendLayout();
			this.tpPrinting.SuspendLayout();
			this.pnPrinting.SuspendLayout();
			this.gbPrint.SuspendLayout();
			this.tpSelection.SuspendLayout();
			this.pnSelection.SuspendLayout();
			this.gbSelection.SuspendLayout();
			this.tpNavigate.SuspendLayout();
			this.pnNavigate.SuspendLayout();
			this.gbNavigateOptions.SuspendLayout();
			this.tpLineNumbers.SuspendLayout();
			this.pnLineNumbers.SuspendLayout();
			this.gbLineNumbers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudLineNumbersStart)).BeginInit();
			this.tpOther.SuspendLayout();
			this.pnOther.SuspendLayout();
			this.gbBraces.SuspendLayout();
			this.gbOther.SuspendLayout();
			this.tpDialogs.SuspendLayout();
			this.pnDialogs.SuspendLayout();
			this.gbDialogs.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList2
			// 
			this.imageList2.ImageSize = new System.Drawing.Size(15, 15);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.White;
			// 
			// pnMain
			// 
			this.pnMain.Controls.Add(this.pnEditContainer);
			this.pnMain.Controls.Add(this.splitter2);
			this.pnMain.Controls.Add(this.pnPropertyGrid);
			this.pnMain.Controls.Add(this.pnManage);
			this.pnMain.Controls.Add(this.treeView1);
			this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnMain.Location = new System.Drawing.Point(0, 0);
			this.pnMain.Name = "pnMain";
			this.pnMain.Size = new System.Drawing.Size(674, 478);
			this.pnMain.TabIndex = 1;
			// 
			// pnEditContainer
			// 
			this.pnEditContainer.Controls.Add(this.syntaxEdit);
			this.pnEditContainer.Controls.Add(this.splitter1);
			this.pnEditContainer.Controls.Add(this.syntaxSplitEdit);
			this.pnEditContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnEditContainer.Location = new System.Drawing.Point(160, 144);
			this.pnEditContainer.Name = "pnEditContainer";
			this.pnEditContainer.Size = new System.Drawing.Size(287, 334);
			this.pnEditContainer.TabIndex = 39;
			// 
			// syntaxEdit
			// 
			this.syntaxEdit.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("syntaxEdit.BackgroundImage")));
			this.syntaxEdit.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit.EditMargin.ColumnPositions = new int[] {
																	   16,
																	   48};
			this.syntaxEdit.EditMargin.ColumnsVisible = true;
			this.syntaxEdit.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit.Gutter.Options = ((QWhale.Editor.GutterOptions)((QWhale.Editor.GutterOptions.PaintBookMarks | QWhale.Editor.GutterOptions.PaintLineModificators)));
			this.syntaxEdit.Lexer = this.csParser1;
			this.syntaxEdit.Location = new System.Drawing.Point(0, 0);
			this.syntaxEdit.Name = "syntaxEdit";
			this.syntaxEdit.Pages.ApplyRulerToAllPages = true;
			scrollingButton1.Description = "Normal Mode";
			scrollingButton1.ImageIndex = 0;
			scrollingButton1.Images = this.imageList2;
			scrollingButton1.Name = "Normal";
			scrollingButton2.Description = "Page Layout Mode";
			scrollingButton2.ImageIndex = 1;
			scrollingButton2.Images = this.imageList2;
			scrollingButton2.Name = "PageLayout";
			scrollingButton3.Description = "Page Breaks Mode";
			scrollingButton3.ImageIndex = 2;
			scrollingButton3.Images = this.imageList2;
			scrollingButton3.Name = "PageBreaks";
			this.syntaxEdit.Scroll.HorizontalButtons.AddRange(new QWhale.Editor.ScrollingButton[] {
																									  scrollingButton1,
																									  scrollingButton2,
																									  scrollingButton3});
			this.syntaxEdit.Scroll.Options = ((QWhale.Editor.ScrollingOptions)((((((QWhale.Editor.ScrollingOptions.SmoothScroll | QWhale.Editor.ScrollingOptions.UseScrollDelta) 
				| QWhale.Editor.ScrollingOptions.AllowSplitHorz) 
				| QWhale.Editor.ScrollingOptions.AllowSplitVert) 
				| QWhale.Editor.ScrollingOptions.HorzButtons) 
				| QWhale.Editor.ScrollingOptions.VertButtons)));
			scrollingButton4.Description = "Page Down";
			scrollingButton4.ImageIndex = 3;
			scrollingButton4.Images = this.imageList2;
			scrollingButton4.Name = "PageDown";
			scrollingButton5.Description = "Page Up";
			scrollingButton5.ImageIndex = 4;
			scrollingButton5.Images = this.imageList2;
			scrollingButton5.Name = "PageUp";
			this.syntaxEdit.Scroll.VerticalButtons.AddRange(new QWhale.Editor.ScrollingButton[] {
																									scrollingButton4,
																									scrollingButton5});
			this.syntaxEdit.Size = new System.Drawing.Size(287, 233);
			this.syntaxEdit.Source = this.textSource1;
			this.syntaxEdit.TabIndex = 38;
			this.syntaxEdit.WordSpell += new QWhale.Editor.WordSpellEvent(this.syntaxEdit_WordSpell);
			this.syntaxEdit.ScrollButtonClick += new System.EventHandler(this.syntaxEdit_ScrollButtonClick);
			// 
			// csParser1
			// 
			this.csParser1.DefaultState = 0;
			this.csParser1.Options = ((QWhale.Syntax.SyntaxOptions)(((((QWhale.Syntax.SyntaxOptions.Outline | QWhale.Syntax.SyntaxOptions.SmartIndent) 
				| QWhale.Syntax.SyntaxOptions.CodeCompletion) 
				| QWhale.Syntax.SyntaxOptions.SyntaxErrors) 
				| QWhale.Syntax.SyntaxOptions.QuickInfoTips)));
			this.csParser1.XmlScheme = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<LexScheme xmlns:xsd=\"http://www.w3.org/" +
				"2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Autho" +
				"r>Quantum Whale LLC.</Author>\r\n  <Name />\r\n  <Desc />\r\n  <Copyright>Copyright (c" +
				") 2004, 2005 Quantum Whale LLC.</Copyright>\r\n  <FileExtension />\r\n  <FileType>c#" +
				"</FileType>\r\n  <Version>1.0</Version>\r\n  <Styles>\r\n    <Style>\r\n      <Name>iden" +
				"ts</Name>\r\n      <ForeColor>ControlText</ForeColor>\r\n      <ForeColorEnabled>tru" +
				"e</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n      <Bo" +
				"ldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n      <" +
				"UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <Name" +
				">numbers</Name>\r\n      <ForeColor>Green</ForeColor>\r\n      <ForeColorEnabled>tru" +
				"e</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n      <Bo" +
				"ldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n      <" +
				"UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <Name" +
				">reswords</Name>\r\n      <ForeColor>Blue</ForeColor>\r\n      <ForeColorEnabled>tru" +
				"e</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n      <Bo" +
				"ldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n      <" +
				"UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <Name" +
				">comments</Name>\r\n      <ForeColor>Green</ForeColor>\r\n      <PlainText>true</Pla" +
				"inText>\r\n      <ForeColorEnabled>true</ForeColorEnabled>\r\n      <BackColorEnable" +
				"d>true</BackColorEnabled>\r\n      <BoldEnabled>true</BoldEnabled>\r\n      <ItalicE" +
				"nabled>true</ItalicEnabled>\r\n      <UnderlineEnabled>true</UnderlineEnabled>\r\n  " +
				"  </Style>\r\n    <Style>\r\n      <Name>xmlcomments</Name>\r\n      <ForeColor>Gray</" +
				"ForeColor>\r\n      <ForeColorEnabled>true</ForeColorEnabled>\r\n      <BackColorEna" +
				"bled>true</BackColorEnabled>\r\n      <BoldEnabled>true</BoldEnabled>\r\n      <Ital" +
				"icEnabled>true</ItalicEnabled>\r\n      <UnderlineEnabled>true</UnderlineEnabled>\r" +
				"\n    </Style>\r\n    <Style>\r\n      <Name>symbols</Name>\r\n      <ForeColor>Gray</F" +
				"oreColor>\r\n      <ForeColorEnabled>true</ForeColorEnabled>\r\n      <BackColorEnab" +
				"led>true</BackColorEnabled>\r\n      <BoldEnabled>true</BoldEnabled>\r\n      <Itali" +
				"cEnabled>true</ItalicEnabled>\r\n      <UnderlineEnabled>true</UnderlineEnabled>\r\n" +
				"    </Style>\r\n    <Style>\r\n      <Name>whitespace</Name>\r\n      <ForeColor>Windo" +
				"wText</ForeColor>\r\n      <ForeColorEnabled>true</ForeColorEnabled>\r\n      <BackC" +
				"olorEnabled>true</BackColorEnabled>\r\n      <BoldEnabled>true</BoldEnabled>\r\n    " +
				"  <ItalicEnabled>true</ItalicEnabled>\r\n      <UnderlineEnabled>true</UnderlineEn" +
				"abled>\r\n    </Style>\r\n    <Style>\r\n      <Name>strings</Name>\r\n      <ForeColor>" +
				"Maroon</ForeColor>\r\n      <PlainText>true</PlainText>\r\n      <ForeColorEnabled>t" +
				"rue</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n      <" +
				"BoldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n     " +
				" <UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <Na" +
				"me>directives</Name>\r\n      <ForeColor>Blue</ForeColor>\r\n      <ForeColorEnabled" +
				">true</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n     " +
				" <BoldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n   " +
				"   <UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n    <Style>\r\n      <" +
				"Name>syntaxerrors</Name>\r\n      <ForeColor>Red</ForeColor>\r\n      <ForeColorEnab" +
				"led>true</ForeColorEnabled>\r\n      <BackColorEnabled>true</BackColorEnabled>\r\n  " +
				"    <BoldEnabled>true</BoldEnabled>\r\n      <ItalicEnabled>true</ItalicEnabled>\r\n" +
				"      <UnderlineEnabled>true</UnderlineEnabled>\r\n    </Style>\r\n  </Styles>\r\n  <S" +
				"tates />\r\n</LexScheme>";
			// 
			// textSource1
			// 
			this.textSource1.Lexer = this.csParser1;
			this.textSource1.Text = "#region Copyright (c) 2004 - 2007 Quantum Whale LLC.\r\n/*\r\n\tQuantum Whale .NET Com" +
				"ponent Library\r\n\tEditor.NET Main Demo\r\n\r\n\tCopyright (c) 2004 Quantum Whale LLC.\r" +
				"\n\tALL RIGHTS RESERVED\r\n\r\n\thttp://www.qwhale.net\r\n\tcontact@qwhale.net\r\n*/\r\n#endre" +
				"gion Copyright (c) 2004 Quantum Whale LLC.\r\nusing System;\r\nusing System.Drawing;" +
				"\r\nusing System.Drawing.Printing;\r\nusing System.Collections;\r\nusing System.Compon" +
				"entModel;\r\nusing System.Windows.Forms;\r\nusing System.Data;\r\nusing QWhale.Editor;" +
				"\r\nusing QWhale.Editor.Dialogs;\r\n\r\nnamespace MainDemo\r\n{\r\n\tpublic class Test\r\n\t{\r" +
				"\n\t\tpublic MainForm()\r\n\t\t{\r\n\t\t\t//\r\n\t\t\t// Required for Windows Form Designer suppo" +
				"rt\r\n\t\t\t//\r\n\t\t\tInitializeComponent();\r\n\r\n\t\t\t//\r\n\t\t\t// TODO: Add any constructor c" +
				"ode after InitializeComponent call\r\n\t\t\t//\r\n\t\t}\r\n\r\n\t\t/// <summary>\r\n\t\t/// Clean u" +
				"p any resources being used.\r\n\t\t/// </summary>\r\n\t\tprotected override void Dispose" +
				"( bool disposing )\r\n\t\t{\r\n\t\t\tif( disposing )\r\n\t\t\t{\r\n\t\t\t\tif (components != null) \r" +
				"\n\t\t\t\t{\r\n\t\t\t\t\tcomponents.Dispose();\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\tbase.Dispose( disposing );\r\n" +
				"\t\t}\r\n\t\t[STAThread]\r\n\t\tstatic void Main() \r\n\t\t{\r\n\t\t\tApplication.Run(new MainForm(" +
				"));\r\n\t\t}\r\n\r\n\t\tprivate void MainForm_Load(object sender, System.EventArgs e)\r\n\t\t{" +
				"\r\n\t\t\tsyntaxEdit.Scrolling.Options |= ScrollingOptions.ShowScrollHint;\r\n\t\t\tsyntax" +
				"SplitEdit.Scrolling.Options |= ScrollingOptions.ShowScrollHint;\r\n\t\t\tFillControls" +
				"();\r\n\t\t\tGlobalSettings = new SyntaxSettings();\r\n\t\t\tOptions = new DlgSyntaxSettin" +
				"gs();\r\n\t\t\tGlobalSettings.LoadFromEdit(syntaxEdit);\r\n\t\t\tif (pictureBox1.Image is " +
				"Bitmap)\r\n\t\t\t\t(pictureBox1.Image as Bitmap).MakeTransparent(Color.White);\r\n\t\t\tUpd" +
				"atePanels(grAppearance, oiGutter);\r\n\t\t}\r\n\t}\r\n}";
			// 
			// splitter1
			// 
			this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 233);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(287, 5);
			this.splitter1.TabIndex = 37;
			this.splitter1.TabStop = false;
			// 
			// syntaxSplitEdit
			// 
			this.syntaxSplitEdit.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxSplitEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("syntaxSplitEdit.BackgroundImage")));
			this.syntaxSplitEdit.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxSplitEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.syntaxSplitEdit.EditMargin.ColumnPositions = new int[] {
																			16,
																			48};
			this.syntaxSplitEdit.EditMargin.ColumnsVisible = true;
			this.syntaxSplitEdit.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxSplitEdit.Lexer = this.csParser1;
			this.syntaxSplitEdit.Location = new System.Drawing.Point(0, 238);
			this.syntaxSplitEdit.Name = "syntaxSplitEdit";
			this.syntaxSplitEdit.Pages.ApplyRulerToAllPages = true;
			this.syntaxSplitEdit.Scroll.Options = ((QWhale.Editor.ScrollingOptions)((((((QWhale.Editor.ScrollingOptions.SmoothScroll | QWhale.Editor.ScrollingOptions.UseScrollDelta) 
				| QWhale.Editor.ScrollingOptions.AllowSplitHorz) 
				| QWhale.Editor.ScrollingOptions.AllowSplitVert) 
				| QWhale.Editor.ScrollingOptions.HorzButtons) 
				| QWhale.Editor.ScrollingOptions.VertButtons)));
			this.syntaxSplitEdit.Size = new System.Drawing.Size(287, 96);
			this.syntaxSplitEdit.Source = this.textSource1;
			this.syntaxSplitEdit.TabIndex = 36;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter2.Location = new System.Drawing.Point(447, 144);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 334);
			this.splitter2.TabIndex = 38;
			this.splitter2.TabStop = false;
			// 
			// pnPropertyGrid
			// 
			this.pnPropertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnPropertyGrid.Location = new System.Drawing.Point(450, 144);
			this.pnPropertyGrid.Name = "pnPropertyGrid";
			this.pnPropertyGrid.Size = new System.Drawing.Size(224, 334);
			this.pnPropertyGrid.TabIndex = 36;
			this.pnPropertyGrid.Visible = false;
			// 
			// pnManage
			// 
			this.pnManage.Controls.Add(this.tcContainer);
			this.pnManage.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnManage.Location = new System.Drawing.Point(160, 0);
			this.pnManage.Name = "pnManage";
			this.pnManage.Size = new System.Drawing.Size(514, 144);
			this.pnManage.TabIndex = 0;
			// 
			// tcContainer
			// 
			this.tcContainer.Controls.Add(this.tpGutter);
			this.tcContainer.Controls.Add(this.tpCompanyInfo);
			this.tcContainer.Controls.Add(this.tpMargin);
			this.tcContainer.Controls.Add(this.tpWordWrap);
			this.tcContainer.Controls.Add(this.tpTextSource);
			this.tcContainer.Controls.Add(this.tpPageLayout);
			this.tcContainer.Controls.Add(this.tpSpellAndUrl);
			this.tcContainer.Controls.Add(this.tpProperties);
			this.tcContainer.Controls.Add(this.tpOutlining);
			this.tcContainer.Controls.Add(this.tpPrinting);
			this.tcContainer.Controls.Add(this.tpSelection);
			this.tcContainer.Controls.Add(this.tpNavigate);
			this.tcContainer.Controls.Add(this.tpLineNumbers);
			this.tcContainer.Controls.Add(this.tpOther);
			this.tcContainer.Controls.Add(this.tpDialogs);
			this.tcContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcContainer.Location = new System.Drawing.Point(0, 0);
			this.tcContainer.Name = "tcContainer";
			this.tcContainer.SelectedIndex = 0;
			this.tcContainer.Size = new System.Drawing.Size(514, 144);
			this.tcContainer.TabIndex = 2;
			this.tcContainer.Visible = false;
			// 
			// tpGutter
			// 
			this.tpGutter.Controls.Add(this.pnGutter);
			this.tpGutter.Location = new System.Drawing.Point(4, 22);
			this.tpGutter.Name = "tpGutter";
			this.tpGutter.Size = new System.Drawing.Size(506, 118);
			this.tpGutter.TabIndex = 0;
			this.tpGutter.Text = "Gutter";
			// 
			// pnGutter
			// 
			this.pnGutter.BackColor = System.Drawing.SystemColors.Control;
			this.pnGutter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnGutter.Controls.Add(this.gbGutter);
			this.pnGutter.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnGutter.Location = new System.Drawing.Point(0, 0);
			this.pnGutter.Name = "pnGutter";
			this.pnGutter.Size = new System.Drawing.Size(506, 112);
			this.pnGutter.TabIndex = 1;
			// 
			// gbGutter
			// 
			this.gbGutter.Controls.Add(this.btShowBookmarks);
			this.gbGutter.Controls.Add(this.chbPaintBookMarks);
			this.gbGutter.Controls.Add(this.chbDrawLineBookmarks);
			this.gbGutter.Controls.Add(this.laGutterWidth);
			this.gbGutter.Controls.Add(this.nudGutterWidth);
			this.gbGutter.Controls.Add(this.chbShowGutter);
			this.gbGutter.Location = new System.Drawing.Point(8, 8);
			this.gbGutter.Name = "gbGutter";
			this.gbGutter.Size = new System.Drawing.Size(496, 96);
			this.gbGutter.TabIndex = 0;
			this.gbGutter.TabStop = false;
			this.gbGutter.Text = "Gutter";
			// 
			// btShowBookmarks
			// 
			this.btShowBookmarks.BackColor = System.Drawing.SystemColors.Control;
			this.btShowBookmarks.Location = new System.Drawing.Point(184, 48);
			this.btShowBookmarks.Name = "btShowBookmarks";
			this.btShowBookmarks.Size = new System.Drawing.Size(104, 23);
			this.btShowBookmarks.TabIndex = 10;
			this.btShowBookmarks.Text = "Set Bookmarks";
			this.btShowBookmarks.Click += new System.EventHandler(this.btShowBookmarks_Click);
			// 
			// chbPaintBookMarks
			// 
			this.chbPaintBookMarks.Location = new System.Drawing.Point(8, 40);
			this.chbPaintBookMarks.Name = "chbPaintBookMarks";
			this.chbPaintBookMarks.Size = new System.Drawing.Size(112, 16);
			this.chbPaintBookMarks.TabIndex = 1;
			this.chbPaintBookMarks.Text = "Paint Bookmarks";
			this.chbPaintBookMarks.CheckedChanged += new System.EventHandler(this.chbPaintBookMarks_CheckedChanged);
			// 
			// chbDrawLineBookmarks
			// 
			this.chbDrawLineBookmarks.Location = new System.Drawing.Point(8, 64);
			this.chbDrawLineBookmarks.Name = "chbDrawLineBookmarks";
			this.chbDrawLineBookmarks.Size = new System.Drawing.Size(136, 16);
			this.chbDrawLineBookmarks.TabIndex = 2;
			this.chbDrawLineBookmarks.Text = "Draw Line Bookmarks";
			this.chbDrawLineBookmarks.CheckedChanged += new System.EventHandler(this.chbDrawLineBookmarks_CheckedChanged);
			// 
			// laGutterWidth
			// 
			this.laGutterWidth.AutoSize = true;
			this.laGutterWidth.Location = new System.Drawing.Point(144, 19);
			this.laGutterWidth.Name = "laGutterWidth";
			this.laGutterWidth.Size = new System.Drawing.Size(66, 16);
			this.laGutterWidth.TabIndex = 6;
			this.laGutterWidth.Text = "Gutter Width";
			// 
			// nudGutterWidth
			// 
			this.nudGutterWidth.Location = new System.Drawing.Point(224, 16);
			this.nudGutterWidth.Name = "nudGutterWidth";
			this.nudGutterWidth.Size = new System.Drawing.Size(64, 20);
			this.nudGutterWidth.TabIndex = 8;
			this.nudGutterWidth.ValueChanged += new System.EventHandler(this.nudGutterWidth_ValueChanged);
			// 
			// chbShowGutter
			// 
			this.chbShowGutter.Location = new System.Drawing.Point(8, 16);
			this.chbShowGutter.Name = "chbShowGutter";
			this.chbShowGutter.Size = new System.Drawing.Size(104, 16);
			this.chbShowGutter.TabIndex = 0;
			this.chbShowGutter.Text = "Show Gutter";
			this.chbShowGutter.CheckedChanged += new System.EventHandler(this.chbShowGutter_CheckedChanged);
			// 
			// tpCompanyInfo
			// 
			this.tpCompanyInfo.Controls.Add(this.pnCompanyInfo);
			this.tpCompanyInfo.Location = new System.Drawing.Point(4, 22);
			this.tpCompanyInfo.Name = "tpCompanyInfo";
			this.tpCompanyInfo.Size = new System.Drawing.Size(506, 118);
			this.tpCompanyInfo.TabIndex = 8;
			this.tpCompanyInfo.Text = "Company Info";
			this.tpCompanyInfo.Visible = false;
			// 
			// pnCompanyInfo
			// 
			this.pnCompanyInfo.BackColor = System.Drawing.SystemColors.Control;
			this.pnCompanyInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnCompanyInfo.Controls.Add(this.tbCompanyInfo);
			this.pnCompanyInfo.Controls.Add(this.label7);
			this.pnCompanyInfo.Controls.Add(this.label6);
			this.pnCompanyInfo.Controls.Add(this.laMailTo);
			this.pnCompanyInfo.Controls.Add(this.label4);
			this.pnCompanyInfo.Controls.Add(this.laAdress);
			this.pnCompanyInfo.Controls.Add(this.label2);
			this.pnCompanyInfo.Controls.Add(this.laCompany);
			this.pnCompanyInfo.Controls.Add(this.pictureBox1);
			this.pnCompanyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnCompanyInfo.Location = new System.Drawing.Point(0, 0);
			this.pnCompanyInfo.Name = "pnCompanyInfo";
			this.pnCompanyInfo.Size = new System.Drawing.Size(506, 118);
			this.pnCompanyInfo.TabIndex = 1;
			// 
			// tbCompanyInfo
			// 
			this.tbCompanyInfo.BackColor = System.Drawing.SystemColors.Control;
			this.tbCompanyInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbCompanyInfo.Location = new System.Drawing.Point(24, 160);
			this.tbCompanyInfo.Multiline = true;
			this.tbCompanyInfo.Name = "tbCompanyInfo";
			this.tbCompanyInfo.Size = new System.Drawing.Size(400, 120);
			this.tbCompanyInfo.TabIndex = 9;
			this.tbCompanyInfo.Text = @"Editor.NET is an advanced code editor allowing integration of a highly flexible edit control in your .NET applications.

It has almost all the features that can be found in the Visual Studio.NET code Editor, including customizable syntax highlighting, code outlining, code completion, unlimited undo/redo, bookmarks, word wrap, drag-n-drop, search/replace, and displaying gutter/margin/line numbers.";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 312);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(205, 16);
			this.label7.TabIndex = 7;
			this.label7.Text = "Copyright (c) 2004-2006 Quantum Whale";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 336);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(131, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "Quantum Whale Company";
			// 
			// laMailTo
			// 
			this.laMailTo.AutoSize = true;
			this.laMailTo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.laMailTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laMailTo.ForeColor = System.Drawing.Color.Blue;
			this.laMailTo.Location = new System.Drawing.Point(256, 128);
			this.laMailTo.Name = "laMailTo";
			this.laMailTo.Size = new System.Drawing.Size(141, 16);
			this.laMailTo.TabIndex = 5;
			this.laMailTo.Text = "mailto:contact@qwhale.net";
			this.laMailTo.Click += new System.EventHandler(this.laMailTo_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(216, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "e-mail:";
			// 
			// laAdress
			// 
			this.laAdress.AutoSize = true;
			this.laAdress.Cursor = System.Windows.Forms.Cursors.Hand;
			this.laAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laAdress.ForeColor = System.Drawing.Color.Blue;
			this.laAdress.Location = new System.Drawing.Point(256, 104);
			this.laAdress.Name = "laAdress";
			this.laAdress.Size = new System.Drawing.Size(115, 16);
			this.laAdress.TabIndex = 3;
			this.laAdress.Text = "http://www.qwhale.net";
			this.laAdress.Click += new System.EventHandler(this.laAdress_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(216, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "WWW:";
			// 
			// laCompany
			// 
			this.laCompany.AutoSize = true;
			this.laCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laCompany.ForeColor = System.Drawing.Color.MidnightBlue;
			this.laCompany.Location = new System.Drawing.Point(200, 28);
			this.laCompany.Name = "laCompany";
			this.laCompany.Size = new System.Drawing.Size(311, 49);
			this.laCompany.TabIndex = 1;
			this.laCompany.Text = "Quantum Whale";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(180, 80);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// tpMargin
			// 
			this.tpMargin.Controls.Add(this.pnMargin);
			this.tpMargin.Location = new System.Drawing.Point(4, 22);
			this.tpMargin.Name = "tpMargin";
			this.tpMargin.Size = new System.Drawing.Size(506, 118);
			this.tpMargin.TabIndex = 9;
			this.tpMargin.Text = "Margin";
			this.tpMargin.Visible = false;
			// 
			// pnMargin
			// 
			this.pnMargin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnMargin.Controls.Add(this.gbMargin);
			this.pnMargin.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnMargin.Location = new System.Drawing.Point(0, 0);
			this.pnMargin.Name = "pnMargin";
			this.pnMargin.Size = new System.Drawing.Size(506, 112);
			this.pnMargin.TabIndex = 0;
			// 
			// gbMargin
			// 
			this.gbMargin.Controls.Add(this.chbColumnsVisible);
			this.gbMargin.Controls.Add(this.chbShowMarginHints);
			this.gbMargin.Controls.Add(this.chbAllowDragMargin);
			this.gbMargin.Controls.Add(this.nudMarginPos);
			this.gbMargin.Controls.Add(this.laMarginPos);
			this.gbMargin.Controls.Add(this.chbShowMargin);
			this.gbMargin.Location = new System.Drawing.Point(8, 8);
			this.gbMargin.Name = "gbMargin";
			this.gbMargin.Size = new System.Drawing.Size(496, 96);
			this.gbMargin.TabIndex = 0;
			this.gbMargin.TabStop = false;
			this.gbMargin.Text = "Margin";
			// 
			// chbShowMarginHints
			// 
			this.chbShowMarginHints.Location = new System.Drawing.Point(168, 40);
			this.chbShowMarginHints.Name = "chbShowMarginHints";
			this.chbShowMarginHints.Size = new System.Drawing.Size(112, 16);
			this.chbShowMarginHints.TabIndex = 6;
			this.chbShowMarginHints.Text = "Show Drag Hints";
			this.chbShowMarginHints.CheckedChanged += new System.EventHandler(this.chbShowMarginHints_CheckedChanged);
			// 
			// chbAllowDragMargin
			// 
			this.chbAllowDragMargin.Location = new System.Drawing.Point(168, 16);
			this.chbAllowDragMargin.Name = "chbAllowDragMargin";
			this.chbAllowDragMargin.Size = new System.Drawing.Size(120, 16);
			this.chbAllowDragMargin.TabIndex = 5;
			this.chbAllowDragMargin.Text = "Allow Drag Margin";
			this.chbAllowDragMargin.CheckedChanged += new System.EventHandler(this.chbAllowDragMargin_CheckedChanged);
			// 
			// nudMarginPos
			// 
			this.nudMarginPos.Location = new System.Drawing.Point(88, 40);
			this.nudMarginPos.Name = "nudMarginPos";
			this.nudMarginPos.Size = new System.Drawing.Size(64, 20);
			this.nudMarginPos.TabIndex = 4;
			this.nudMarginPos.ValueChanged += new System.EventHandler(this.nudMarginPos_ValueChanged);
			// 
			// laMarginPos
			// 
			this.laMarginPos.AutoSize = true;
			this.laMarginPos.Location = new System.Drawing.Point(8, 43);
			this.laMarginPos.Name = "laMarginPos";
			this.laMarginPos.Size = new System.Drawing.Size(78, 16);
			this.laMarginPos.TabIndex = 3;
			this.laMarginPos.Text = "Margin position";
			// 
			// chbShowMargin
			// 
			this.chbShowMargin.Location = new System.Drawing.Point(8, 16);
			this.chbShowMargin.Name = "chbShowMargin";
			this.chbShowMargin.Size = new System.Drawing.Size(96, 16);
			this.chbShowMargin.TabIndex = 0;
			this.chbShowMargin.Text = "Show Margin";
			this.chbShowMargin.CheckedChanged += new System.EventHandler(this.chbShowMargin_CheckedChanged);
			// 
			// tpWordWrap
			// 
			this.tpWordWrap.Controls.Add(this.pnWordWrap);
			this.tpWordWrap.Location = new System.Drawing.Point(4, 22);
			this.tpWordWrap.Name = "tpWordWrap";
			this.tpWordWrap.Size = new System.Drawing.Size(506, 118);
			this.tpWordWrap.TabIndex = 1;
			this.tpWordWrap.Text = "WordWrap";
			this.tpWordWrap.Visible = false;
			// 
			// pnWordWrap
			// 
			this.pnWordWrap.BackColor = System.Drawing.SystemColors.Control;
			this.pnWordWrap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnWordWrap.Controls.Add(this.gbWordWrap);
			this.pnWordWrap.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnWordWrap.Location = new System.Drawing.Point(0, 0);
			this.pnWordWrap.Name = "pnWordWrap";
			this.pnWordWrap.Size = new System.Drawing.Size(506, 112);
			this.pnWordWrap.TabIndex = 1;
			// 
			// gbWordWrap
			// 
			this.gbWordWrap.Controls.Add(this.chbFlatScrollBars);
			this.gbWordWrap.Controls.Add(this.chbSystemScrollBars);
			this.gbWordWrap.Controls.Add(this.chbScrollButtons);
			this.gbWordWrap.Controls.Add(this.chbAllowSplit);
			this.gbWordWrap.Controls.Add(this.chbWrapAtMargin);
			this.gbWordWrap.Controls.Add(this.chbWordWrap);
			this.gbWordWrap.Controls.Add(this.chbShowScrollHint);
			this.gbWordWrap.Controls.Add(this.chbSmoothScroll);
			this.gbWordWrap.Location = new System.Drawing.Point(8, 8);
			this.gbWordWrap.Name = "gbWordWrap";
			this.gbWordWrap.Size = new System.Drawing.Size(496, 96);
			this.gbWordWrap.TabIndex = 13;
			this.gbWordWrap.TabStop = false;
			this.gbWordWrap.Text = "Word Wrap && Scrolling";
			// 
			// chbFlatScrollBars
			// 
			this.chbFlatScrollBars.Location = new System.Drawing.Point(288, 40);
			this.chbFlatScrollBars.Name = "chbFlatScrollBars";
			this.chbFlatScrollBars.TabIndex = 8;
			this.chbFlatScrollBars.Text = "Flat Scroll";
			this.chbFlatScrollBars.CheckedChanged += new System.EventHandler(this.chbFlatScrollBars_CheckedChanged);
			// 
			// chbSystemScrollBars
			// 
			this.chbSystemScrollBars.Location = new System.Drawing.Point(288, 16);
			this.chbSystemScrollBars.Name = "chbSystemScrollBars";
			this.chbSystemScrollBars.TabIndex = 7;
			this.chbSystemScrollBars.Text = "System Scroll";
			this.chbSystemScrollBars.CheckedChanged += new System.EventHandler(this.chbSystemScrollBars_CheckedChanged);
			// 
			// chbScrollButtons
			// 
			this.chbScrollButtons.Location = new System.Drawing.Point(144, 64);
			this.chbScrollButtons.Name = "chbScrollButtons";
			this.chbScrollButtons.Size = new System.Drawing.Size(104, 16);
			this.chbScrollButtons.TabIndex = 6;
			this.chbScrollButtons.Text = "Scroll Buttons";
			this.chbScrollButtons.CheckedChanged += new System.EventHandler(this.chbScrollButtons_CheckedChanged);
			// 
			// chbAllowSplit
			// 
			this.chbAllowSplit.Location = new System.Drawing.Point(144, 40);
			this.chbAllowSplit.Name = "chbAllowSplit";
			this.chbAllowSplit.Size = new System.Drawing.Size(104, 16);
			this.chbAllowSplit.TabIndex = 5;
			this.chbAllowSplit.Text = "Allow Split";
			this.chbAllowSplit.CheckedChanged += new System.EventHandler(this.chbAllowSplit_CheckedChanged);
			// 
			// chbWrapAtMargin
			// 
			this.chbWrapAtMargin.Location = new System.Drawing.Point(8, 40);
			this.chbWrapAtMargin.Name = "chbWrapAtMargin";
			this.chbWrapAtMargin.Size = new System.Drawing.Size(104, 16);
			this.chbWrapAtMargin.TabIndex = 1;
			this.chbWrapAtMargin.Text = "Wrap at Margin";
			this.chbWrapAtMargin.CheckedChanged += new System.EventHandler(this.chbWrapAtMargin_CheckedChanged);
			// 
			// chbWordWrap
			// 
			this.chbWordWrap.Location = new System.Drawing.Point(8, 16);
			this.chbWordWrap.Name = "chbWordWrap";
			this.chbWordWrap.Size = new System.Drawing.Size(104, 16);
			this.chbWordWrap.TabIndex = 0;
			this.chbWordWrap.Text = "Word Wrap";
			this.chbWordWrap.CheckedChanged += new System.EventHandler(this.chbWordWrap_CheckedChanged);
			// 
			// chbShowScrollHint
			// 
			this.chbShowScrollHint.Location = new System.Drawing.Point(8, 64);
			this.chbShowScrollHint.Name = "chbShowScrollHint";
			this.chbShowScrollHint.Size = new System.Drawing.Size(112, 16);
			this.chbShowScrollHint.TabIndex = 3;
			this.chbShowScrollHint.Text = "Show Scroll Hint";
			this.chbShowScrollHint.CheckedChanged += new System.EventHandler(this.chbShowScrollHint_CheckedChanged);
			// 
			// chbSmoothScroll
			// 
			this.chbSmoothScroll.Location = new System.Drawing.Point(144, 16);
			this.chbSmoothScroll.Name = "chbSmoothScroll";
			this.chbSmoothScroll.Size = new System.Drawing.Size(104, 16);
			this.chbSmoothScroll.TabIndex = 4;
			this.chbSmoothScroll.Text = "Smooth Scroll";
			this.chbSmoothScroll.CheckedChanged += new System.EventHandler(this.chbSmoothScroll_CheckedChanged);
			// 
			// tpTextSource
			// 
			this.tpTextSource.Controls.Add(this.pnTextSource);
			this.tpTextSource.Location = new System.Drawing.Point(4, 22);
			this.tpTextSource.Name = "tpTextSource";
			this.tpTextSource.Size = new System.Drawing.Size(506, 118);
			this.tpTextSource.TabIndex = 6;
			this.tpTextSource.Text = "Text Source";
			this.tpTextSource.Visible = false;
			// 
			// pnTextSource
			// 
			this.pnTextSource.BackColor = System.Drawing.SystemColors.Control;
			this.pnTextSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnTextSource.Controls.Add(this.laSource);
			this.pnTextSource.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnTextSource.Location = new System.Drawing.Point(0, 0);
			this.pnTextSource.Name = "pnTextSource";
			this.pnTextSource.Size = new System.Drawing.Size(506, 73);
			this.pnTextSource.TabIndex = 4;
			// 
			// laSource
			// 
			this.laSource.AutoSize = true;
			this.laSource.Location = new System.Drawing.Point(160, 24);
			this.laSource.Name = "laSource";
			this.laSource.Size = new System.Drawing.Size(213, 16);
			this.laSource.TabIndex = 0;
			this.laSource.Text = "Several Editor can work with the same text";
			// 
			// tpPageLayout
			// 
			this.tpPageLayout.Controls.Add(this.pnPageLayout);
			this.tpPageLayout.Location = new System.Drawing.Point(4, 22);
			this.tpPageLayout.Name = "tpPageLayout";
			this.tpPageLayout.Size = new System.Drawing.Size(506, 118);
			this.tpPageLayout.TabIndex = 13;
			this.tpPageLayout.Text = "Page Layout";
			// 
			// pnPageLayout
			// 
			this.pnPageLayout.BackColor = System.Drawing.SystemColors.Control;
			this.pnPageLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnPageLayout.Controls.Add(this.gbRulers);
			this.pnPageLayout.Controls.Add(this.gbPages);
			this.pnPageLayout.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnPageLayout.Location = new System.Drawing.Point(0, 0);
			this.pnPageLayout.Name = "pnPageLayout";
			this.pnPageLayout.Size = new System.Drawing.Size(506, 112);
			this.pnPageLayout.TabIndex = 2;
			// 
			// gbRulers
			// 
			this.gbRulers.Controls.Add(this.chbVertRuler);
			this.gbRulers.Controls.Add(this.chbHorzRuler);
			this.gbRulers.Controls.Add(this.cbRulerUnits);
			this.gbRulers.Controls.Add(this.laRulerUnits);
			this.gbRulers.Controls.Add(this.chbRulerDisplayDragLines);
			this.gbRulers.Controls.Add(this.chbRulerDiscrete);
			this.gbRulers.Controls.Add(this.chbRulerAllowDrag);
			this.gbRulers.Location = new System.Drawing.Point(208, 8);
			this.gbRulers.Name = "gbRulers";
			this.gbRulers.Size = new System.Drawing.Size(296, 96);
			this.gbRulers.TabIndex = 14;
			this.gbRulers.TabStop = false;
			this.gbRulers.Text = "Rulers";
			// 
			// chbVertRuler
			// 
			this.chbVertRuler.Location = new System.Drawing.Point(16, 40);
			this.chbVertRuler.Name = "chbVertRuler";
			this.chbVertRuler.Size = new System.Drawing.Size(104, 16);
			this.chbVertRuler.TabIndex = 2;
			this.chbVertRuler.Text = "Vert Ruler";
			this.chbVertRuler.CheckedChanged += new System.EventHandler(this.chbVertRuler_CheckedChanged);
			// 
			// chbHorzRuler
			// 
			this.chbHorzRuler.Location = new System.Drawing.Point(16, 16);
			this.chbHorzRuler.Name = "chbHorzRuler";
			this.chbHorzRuler.Size = new System.Drawing.Size(104, 16);
			this.chbHorzRuler.TabIndex = 1;
			this.chbHorzRuler.Text = "Horz Ruler";
			this.chbHorzRuler.CheckedChanged += new System.EventHandler(this.chbHorzRuler_CheckedChanged);
			// 
			// cbRulerUnits
			// 
			this.cbRulerUnits.Location = new System.Drawing.Point(72, 64);
			this.cbRulerUnits.Name = "cbRulerUnits";
			this.cbRulerUnits.Size = new System.Drawing.Size(96, 21);
			this.cbRulerUnits.TabIndex = 4;
			this.cbRulerUnits.SelectedIndexChanged += new System.EventHandler(this.cbRulerUnits_SelectedIndexChanged);
			// 
			// laRulerUnits
			// 
			this.laRulerUnits.AutoSize = true;
			this.laRulerUnits.Location = new System.Drawing.Point(8, 67);
			this.laRulerUnits.Name = "laRulerUnits";
			this.laRulerUnits.Size = new System.Drawing.Size(57, 16);
			this.laRulerUnits.TabIndex = 3;
			this.laRulerUnits.Text = "Ruler Units";
			// 
			// chbRulerDisplayDragLines
			// 
			this.chbRulerDisplayDragLines.Location = new System.Drawing.Point(176, 64);
			this.chbRulerDisplayDragLines.Name = "chbRulerDisplayDragLines";
			this.chbRulerDisplayDragLines.Size = new System.Drawing.Size(118, 16);
			this.chbRulerDisplayDragLines.TabIndex = 7;
			this.chbRulerDisplayDragLines.Text = "Display Drag Lines";
			this.chbRulerDisplayDragLines.CheckedChanged += new System.EventHandler(this.chbRulerDisplayDragLines_CheckedChanged);
			// 
			// chbRulerDiscrete
			// 
			this.chbRulerDiscrete.Location = new System.Drawing.Point(176, 40);
			this.chbRulerDiscrete.Name = "chbRulerDiscrete";
			this.chbRulerDiscrete.Size = new System.Drawing.Size(104, 16);
			this.chbRulerDiscrete.TabIndex = 6;
			this.chbRulerDiscrete.Text = "Discrete";
			this.chbRulerDiscrete.CheckedChanged += new System.EventHandler(this.chbRulerDiscrete_CheckedChanged);
			// 
			// chbRulerAllowDrag
			// 
			this.chbRulerAllowDrag.Location = new System.Drawing.Point(176, 16);
			this.chbRulerAllowDrag.Name = "chbRulerAllowDrag";
			this.chbRulerAllowDrag.Size = new System.Drawing.Size(104, 16);
			this.chbRulerAllowDrag.TabIndex = 5;
			this.chbRulerAllowDrag.Text = "Allow Drag";
			this.chbRulerAllowDrag.CheckedChanged += new System.EventHandler(this.chbRulerAllowDrag_CheckedChanged);
			// 
			// gbPages
			// 
			this.gbPages.Controls.Add(this.cbPageSize);
			this.gbPages.Controls.Add(this.laPageSize);
			this.gbPages.Controls.Add(this.cbPageLayout);
			this.gbPages.Controls.Add(this.laPageLayout);
			this.gbPages.Location = new System.Drawing.Point(8, 8);
			this.gbPages.Name = "gbPages";
			this.gbPages.Size = new System.Drawing.Size(184, 96);
			this.gbPages.TabIndex = 13;
			this.gbPages.TabStop = false;
			this.gbPages.Text = "Pages";
			// 
			// cbPageSize
			// 
			this.cbPageSize.Location = new System.Drawing.Point(80, 48);
			this.cbPageSize.Name = "cbPageSize";
			this.cbPageSize.Size = new System.Drawing.Size(96, 21);
			this.cbPageSize.TabIndex = 4;
			this.cbPageSize.SelectedIndexChanged += new System.EventHandler(this.cbPageSize_SelectedIndexChanged);
			// 
			// laPageSize
			// 
			this.laPageSize.AutoSize = true;
			this.laPageSize.Location = new System.Drawing.Point(8, 51);
			this.laPageSize.Name = "laPageSize";
			this.laPageSize.Size = new System.Drawing.Size(50, 16);
			this.laPageSize.TabIndex = 3;
			this.laPageSize.Text = "Page Size";
			// 
			// cbPageLayout
			// 
			this.cbPageLayout.Location = new System.Drawing.Point(80, 24);
			this.cbPageLayout.Name = "cbPageLayout";
			this.cbPageLayout.Size = new System.Drawing.Size(96, 21);
			this.cbPageLayout.TabIndex = 2;
			this.cbPageLayout.SelectedIndexChanged += new System.EventHandler(this.cbPageLayout_SelectedIndexChanged);
			// 
			// laPageLayout
			// 
			this.laPageLayout.AutoSize = true;
			this.laPageLayout.Location = new System.Drawing.Point(8, 27);
			this.laPageLayout.Name = "laPageLayout";
			this.laPageLayout.Size = new System.Drawing.Size(64, 16);
			this.laPageLayout.TabIndex = 1;
			this.laPageLayout.Text = "Page Layout";
			// 
			// tpSpellAndUrl
			// 
			this.tpSpellAndUrl.Controls.Add(this.pnSpellAndUrl);
			this.tpSpellAndUrl.Location = new System.Drawing.Point(4, 22);
			this.tpSpellAndUrl.Name = "tpSpellAndUrl";
			this.tpSpellAndUrl.Size = new System.Drawing.Size(506, 118);
			this.tpSpellAndUrl.TabIndex = 5;
			this.tpSpellAndUrl.Text = "Spell&&Url";
			this.tpSpellAndUrl.Visible = false;
			// 
			// pnSpellAndUrl
			// 
			this.pnSpellAndUrl.BackColor = System.Drawing.SystemColors.Control;
			this.pnSpellAndUrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnSpellAndUrl.Controls.Add(this.gbSpellAndUrl);
			this.pnSpellAndUrl.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSpellAndUrl.Location = new System.Drawing.Point(0, 0);
			this.pnSpellAndUrl.Name = "pnSpellAndUrl";
			this.pnSpellAndUrl.Size = new System.Drawing.Size(506, 112);
			this.pnSpellAndUrl.TabIndex = 3;
			// 
			// gbSpellAndUrl
			// 
			this.gbSpellAndUrl.Controls.Add(this.chbShowHyperTextHints);
			this.gbSpellAndUrl.Controls.Add(this.chbCheckSpelling);
			this.gbSpellAndUrl.Controls.Add(this.chbHighlightUrls);
			this.gbSpellAndUrl.Location = new System.Drawing.Point(8, 8);
			this.gbSpellAndUrl.Name = "gbSpellAndUrl";
			this.gbSpellAndUrl.Size = new System.Drawing.Size(496, 96);
			this.gbSpellAndUrl.TabIndex = 0;
			this.gbSpellAndUrl.TabStop = false;
			this.gbSpellAndUrl.Text = "Spelling && HyperText";
			// 
			// chbShowHyperTextHints
			// 
			this.chbShowHyperTextHints.Location = new System.Drawing.Point(8, 58);
			this.chbShowHyperTextHints.Name = "chbShowHyperTextHints";
			this.chbShowHyperTextHints.TabIndex = 3;
			this.chbShowHyperTextHints.Text = "Show Hints";
			this.chbShowHyperTextHints.CheckedChanged += new System.EventHandler(this.chbShowHyperTextHints_CheckedChanged);
			// 
			// chbCheckSpelling
			// 
			this.chbCheckSpelling.Location = new System.Drawing.Point(8, 16);
			this.chbCheckSpelling.Name = "chbCheckSpelling";
			this.chbCheckSpelling.Size = new System.Drawing.Size(104, 16);
			this.chbCheckSpelling.TabIndex = 0;
			this.chbCheckSpelling.Text = "Check Spelling";
			this.chbCheckSpelling.CheckedChanged += new System.EventHandler(this.chbCheckSpelling_CheckedChanged);
			// 
			// chbHighlightUrls
			// 
			this.chbHighlightUrls.Location = new System.Drawing.Point(8, 40);
			this.chbHighlightUrls.Name = "chbHighlightUrls";
			this.chbHighlightUrls.Size = new System.Drawing.Size(104, 16);
			this.chbHighlightUrls.TabIndex = 2;
			this.chbHighlightUrls.Text = "Highlight Urls";
			this.chbHighlightUrls.CheckedChanged += new System.EventHandler(this.chbHighlightUrls_CheckedChanged);
			// 
			// tpProperties
			// 
			this.tpProperties.Controls.Add(this.pnProperties);
			this.tpProperties.Location = new System.Drawing.Point(4, 22);
			this.tpProperties.Name = "tpProperties";
			this.tpProperties.Size = new System.Drawing.Size(506, 118);
			this.tpProperties.TabIndex = 14;
			this.tpProperties.Text = "Properties";
			// 
			// pnProperties
			// 
			this.pnProperties.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnProperties.Location = new System.Drawing.Point(0, 0);
			this.pnProperties.Name = "pnProperties";
			this.pnProperties.Size = new System.Drawing.Size(506, 0);
			this.pnProperties.TabIndex = 0;
			// 
			// tpOutlining
			// 
			this.tpOutlining.Controls.Add(this.pnOutlining);
			this.tpOutlining.Location = new System.Drawing.Point(4, 22);
			this.tpOutlining.Name = "tpOutlining";
			this.tpOutlining.Size = new System.Drawing.Size(506, 118);
			this.tpOutlining.TabIndex = 4;
			this.tpOutlining.Text = "Outlining";
			this.tpOutlining.Visible = false;
			// 
			// pnOutlining
			// 
			this.pnOutlining.BackColor = System.Drawing.SystemColors.Control;
			this.pnOutlining.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnOutlining.Controls.Add(this.gbOutlining);
			this.pnOutlining.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnOutlining.Location = new System.Drawing.Point(0, 0);
			this.pnOutlining.Name = "pnOutlining";
			this.pnOutlining.Size = new System.Drawing.Size(506, 112);
			this.pnOutlining.TabIndex = 3;
			// 
			// gbOutlining
			// 
			this.gbOutlining.BackColor = System.Drawing.SystemColors.Control;
			this.gbOutlining.Controls.Add(this.chbAllowOutlining);
			this.gbOutlining.Controls.Add(this.chbDrawButtons);
			this.gbOutlining.Controls.Add(this.chbDrawLines);
			this.gbOutlining.Controls.Add(this.chbDrawOnGutter);
			this.gbOutlining.Controls.Add(this.chbShowHints);
			this.gbOutlining.Location = new System.Drawing.Point(8, 8);
			this.gbOutlining.Name = "gbOutlining";
			this.gbOutlining.Size = new System.Drawing.Size(496, 96);
			this.gbOutlining.TabIndex = 5;
			this.gbOutlining.TabStop = false;
			this.gbOutlining.Text = "Outlining";
			// 
			// chbAllowOutlining
			// 
			this.chbAllowOutlining.BackColor = System.Drawing.SystemColors.Control;
			this.chbAllowOutlining.Location = new System.Drawing.Point(8, 16);
			this.chbAllowOutlining.Name = "chbAllowOutlining";
			this.chbAllowOutlining.Size = new System.Drawing.Size(104, 16);
			this.chbAllowOutlining.TabIndex = 0;
			this.chbAllowOutlining.Text = "Allow Outlining";
			this.chbAllowOutlining.CheckedChanged += new System.EventHandler(this.chbAllowOutlining_CheckedChanged);
			// 
			// chbDrawButtons
			// 
			this.chbDrawButtons.BackColor = System.Drawing.SystemColors.Control;
			this.chbDrawButtons.Location = new System.Drawing.Point(144, 16);
			this.chbDrawButtons.Name = "chbDrawButtons";
			this.chbDrawButtons.Size = new System.Drawing.Size(104, 16);
			this.chbDrawButtons.TabIndex = 3;
			this.chbDrawButtons.Text = "Draw Buttons";
			this.chbDrawButtons.CheckedChanged += new System.EventHandler(this.chbDrawButtons_CheckedChanged);
			// 
			// chbDrawLines
			// 
			this.chbDrawLines.BackColor = System.Drawing.SystemColors.Control;
			this.chbDrawLines.Location = new System.Drawing.Point(8, 64);
			this.chbDrawLines.Name = "chbDrawLines";
			this.chbDrawLines.Size = new System.Drawing.Size(104, 16);
			this.chbDrawLines.TabIndex = 2;
			this.chbDrawLines.Text = "Draw Lines";
			this.chbDrawLines.CheckedChanged += new System.EventHandler(this.chbDrawLines_CheckedChanged);
			// 
			// chbDrawOnGutter
			// 
			this.chbDrawOnGutter.BackColor = System.Drawing.SystemColors.Control;
			this.chbDrawOnGutter.Location = new System.Drawing.Point(8, 40);
			this.chbDrawOnGutter.Name = "chbDrawOnGutter";
			this.chbDrawOnGutter.Size = new System.Drawing.Size(104, 16);
			this.chbDrawOnGutter.TabIndex = 1;
			this.chbDrawOnGutter.Text = "Draw on Gutter";
			this.chbDrawOnGutter.CheckedChanged += new System.EventHandler(this.chbDrawOnGutter_CheckedChanged);
			// 
			// chbShowHints
			// 
			this.chbShowHints.BackColor = System.Drawing.SystemColors.Control;
			this.chbShowHints.Location = new System.Drawing.Point(144, 40);
			this.chbShowHints.Name = "chbShowHints";
			this.chbShowHints.Size = new System.Drawing.Size(104, 16);
			this.chbShowHints.TabIndex = 4;
			this.chbShowHints.Text = "Show Hints";
			this.chbShowHints.CheckedChanged += new System.EventHandler(this.chbShowHints_CheckedChanged);
			// 
			// tpPrinting
			// 
			this.tpPrinting.Controls.Add(this.pnPrinting);
			this.tpPrinting.Location = new System.Drawing.Point(4, 22);
			this.tpPrinting.Name = "tpPrinting";
			this.tpPrinting.Size = new System.Drawing.Size(506, 118);
			this.tpPrinting.TabIndex = 3;
			this.tpPrinting.Text = "Printing";
			this.tpPrinting.Visible = false;
			// 
			// pnPrinting
			// 
			this.pnPrinting.BackColor = System.Drawing.SystemColors.Control;
			this.pnPrinting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnPrinting.Controls.Add(this.gbPrint);
			this.pnPrinting.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnPrinting.Location = new System.Drawing.Point(0, 0);
			this.pnPrinting.Name = "pnPrinting";
			this.pnPrinting.Size = new System.Drawing.Size(506, 112);
			this.pnPrinting.TabIndex = 1;
			// 
			// gbPrint
			// 
			this.gbPrint.Controls.Add(this.btPrintSetup);
			this.gbPrint.Controls.Add(this.btPrint);
			this.gbPrint.Controls.Add(this.btPrintPreview);
			this.gbPrint.Controls.Add(this.btXml);
			this.gbPrint.Controls.Add(this.btHtml);
			this.gbPrint.Controls.Add(this.btRtf);
			this.gbPrint.Location = new System.Drawing.Point(8, 8);
			this.gbPrint.Name = "gbPrint";
			this.gbPrint.Size = new System.Drawing.Size(496, 96);
			this.gbPrint.TabIndex = 6;
			this.gbPrint.TabStop = false;
			this.gbPrint.Text = "Printing && Exporting";
			// 
			// btPrintSetup
			// 
			this.btPrintSetup.BackColor = System.Drawing.SystemColors.Control;
			this.btPrintSetup.Location = new System.Drawing.Point(200, 56);
			this.btPrintSetup.Name = "btPrintSetup";
			this.btPrintSetup.Size = new System.Drawing.Size(80, 23);
			this.btPrintSetup.TabIndex = 11;
			this.btPrintSetup.Text = "Page Setup";
			this.btPrintSetup.Click += new System.EventHandler(this.btPageSetup_Click);
			// 
			// btPrint
			// 
			this.btPrint.BackColor = System.Drawing.SystemColors.Control;
			this.btPrint.Location = new System.Drawing.Point(104, 56);
			this.btPrint.Name = "btPrint";
			this.btPrint.Size = new System.Drawing.Size(80, 23);
			this.btPrint.TabIndex = 10;
			this.btPrint.Text = "Print";
			this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
			// 
			// btPrintPreview
			// 
			this.btPrintPreview.BackColor = System.Drawing.SystemColors.Control;
			this.btPrintPreview.Location = new System.Drawing.Point(8, 56);
			this.btPrintPreview.Name = "btPrintPreview";
			this.btPrintPreview.Size = new System.Drawing.Size(80, 23);
			this.btPrintPreview.TabIndex = 9;
			this.btPrintPreview.Text = "Print Preview";
			this.btPrintPreview.Click += new System.EventHandler(this.btPrintPreview_Click);
			// 
			// btXml
			// 
			this.btXml.BackColor = System.Drawing.SystemColors.Control;
			this.btXml.Location = new System.Drawing.Point(200, 24);
			this.btXml.Name = "btXml";
			this.btXml.Size = new System.Drawing.Size(80, 23);
			this.btXml.TabIndex = 8;
			this.btXml.Text = "XML";
			this.btXml.Click += new System.EventHandler(this.btXml_Click);
			// 
			// btHtml
			// 
			this.btHtml.BackColor = System.Drawing.SystemColors.Control;
			this.btHtml.Location = new System.Drawing.Point(104, 24);
			this.btHtml.Name = "btHtml";
			this.btHtml.Size = new System.Drawing.Size(80, 23);
			this.btHtml.TabIndex = 7;
			this.btHtml.Text = "HTML";
			this.btHtml.Click += new System.EventHandler(this.btHtml_Click);
			// 
			// btRtf
			// 
			this.btRtf.BackColor = System.Drawing.SystemColors.Control;
			this.btRtf.Location = new System.Drawing.Point(8, 24);
			this.btRtf.Name = "btRtf";
			this.btRtf.Size = new System.Drawing.Size(80, 23);
			this.btRtf.TabIndex = 6;
			this.btRtf.Text = "RTF";
			this.btRtf.Click += new System.EventHandler(this.btRtf_Click);
			// 
			// tpSelection
			// 
			this.tpSelection.Controls.Add(this.pnSelection);
			this.tpSelection.Location = new System.Drawing.Point(4, 22);
			this.tpSelection.Name = "tpSelection";
			this.tpSelection.Size = new System.Drawing.Size(506, 118);
			this.tpSelection.TabIndex = 11;
			this.tpSelection.Text = "Selection";
			// 
			// pnSelection
			// 
			this.pnSelection.BackColor = System.Drawing.SystemColors.Control;
			this.pnSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnSelection.Controls.Add(this.gbSelection);
			this.pnSelection.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSelection.Location = new System.Drawing.Point(0, 0);
			this.pnSelection.Name = "pnSelection";
			this.pnSelection.Size = new System.Drawing.Size(506, 112);
			this.pnSelection.TabIndex = 0;
			// 
			// gbSelection
			// 
			this.gbSelection.Controls.Add(this.chbOverwriteBlocks);
			this.gbSelection.Controls.Add(this.chbPersistentBlocks);
			this.gbSelection.Controls.Add(this.chbDeselectOnCopy);
			this.gbSelection.Controls.Add(this.chbSelectLineOnDblClick);
			this.gbSelection.Controls.Add(this.chbHideSelection);
			this.gbSelection.Controls.Add(this.chbUseColors);
			this.gbSelection.Controls.Add(this.chbSelectBeyondEol);
			this.gbSelection.Controls.Add(this.chbDisableDragging);
			this.gbSelection.Controls.Add(this.chbDisableSelection);
			this.gbSelection.Location = new System.Drawing.Point(8, 8);
			this.gbSelection.Name = "gbSelection";
			this.gbSelection.Size = new System.Drawing.Size(496, 96);
			this.gbSelection.TabIndex = 2;
			this.gbSelection.TabStop = false;
			this.gbSelection.Text = "Selection Options";
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
			this.chbSelectBeyondEol.Size = new System.Drawing.Size(120, 24);
			this.chbSelectBeyondEol.TabIndex = 7;
			this.chbSelectBeyondEol.Text = "Select Beyond Eol";
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
			// tpNavigate
			// 
			this.tpNavigate.Controls.Add(this.pnNavigate);
			this.tpNavigate.Location = new System.Drawing.Point(4, 22);
			this.tpNavigate.Name = "tpNavigate";
			this.tpNavigate.Size = new System.Drawing.Size(506, 118);
			this.tpNavigate.TabIndex = 7;
			this.tpNavigate.Text = "Navigate";
			this.tpNavigate.Visible = false;
			// 
			// pnNavigate
			// 
			this.pnNavigate.BackColor = System.Drawing.SystemColors.Control;
			this.pnNavigate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnNavigate.Controls.Add(this.gbNavigateOptions);
			this.pnNavigate.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnNavigate.Location = new System.Drawing.Point(0, 0);
			this.pnNavigate.Name = "pnNavigate";
			this.pnNavigate.Size = new System.Drawing.Size(506, 112);
			this.pnNavigate.TabIndex = 1;
			// 
			// gbNavigateOptions
			// 
			this.gbNavigateOptions.Controls.Add(this.chbMoveOnRightButton);
			this.gbNavigateOptions.Controls.Add(this.chbDownAtLineEnd);
			this.gbNavigateOptions.Controls.Add(this.chbUpAtLineBegin);
			this.gbNavigateOptions.Controls.Add(this.chbBeyondEof);
			this.gbNavigateOptions.Controls.Add(this.chbBeyondEol);
			this.gbNavigateOptions.Location = new System.Drawing.Point(8, 8);
			this.gbNavigateOptions.Name = "gbNavigateOptions";
			this.gbNavigateOptions.Size = new System.Drawing.Size(496, 96);
			this.gbNavigateOptions.TabIndex = 0;
			this.gbNavigateOptions.TabStop = false;
			this.gbNavigateOptions.Text = "Navigate Options";
			// 
			// chbMoveOnRightButton
			// 
			this.chbMoveOnRightButton.Location = new System.Drawing.Point(144, 64);
			this.chbMoveOnRightButton.Name = "chbMoveOnRightButton";
			this.chbMoveOnRightButton.Size = new System.Drawing.Size(136, 24);
			this.chbMoveOnRightButton.TabIndex = 4;
			this.chbMoveOnRightButton.Text = "Move on Right Button";
			this.chbMoveOnRightButton.CheckedChanged += new System.EventHandler(this.chbMoveOnRightButton_CheckedChanged);
			// 
			// chbDownAtLineEnd
			// 
			this.chbDownAtLineEnd.Location = new System.Drawing.Point(144, 40);
			this.chbDownAtLineEnd.Name = "chbDownAtLineEnd";
			this.chbDownAtLineEnd.Size = new System.Drawing.Size(112, 24);
			this.chbDownAtLineEnd.TabIndex = 3;
			this.chbDownAtLineEnd.Text = "Down at Line End";
			this.chbDownAtLineEnd.CheckedChanged += new System.EventHandler(this.chbDownAtLineEnd_CheckedChanged);
			// 
			// chbUpAtLineBegin
			// 
			this.chbUpAtLineBegin.Location = new System.Drawing.Point(144, 16);
			this.chbUpAtLineBegin.Name = "chbUpAtLineBegin";
			this.chbUpAtLineBegin.Size = new System.Drawing.Size(112, 24);
			this.chbUpAtLineBegin.TabIndex = 2;
			this.chbUpAtLineBegin.Text = "Up at Line Begin";
			this.chbUpAtLineBegin.CheckedChanged += new System.EventHandler(this.chbUpAtLineBegin_CheckedChanged);
			// 
			// chbBeyondEof
			// 
			this.chbBeyondEof.Location = new System.Drawing.Point(8, 40);
			this.chbBeyondEof.Name = "chbBeyondEof";
			this.chbBeyondEof.TabIndex = 1;
			this.chbBeyondEof.Text = "Beyond Eof";
			this.chbBeyondEof.CheckedChanged += new System.EventHandler(this.chbBeyondEof_CheckedChanged);
			// 
			// chbBeyondEol
			// 
			this.chbBeyondEol.Location = new System.Drawing.Point(8, 16);
			this.chbBeyondEol.Name = "chbBeyondEol";
			this.chbBeyondEol.TabIndex = 0;
			this.chbBeyondEol.Text = "Beyond Eol";
			this.chbBeyondEol.CheckedChanged += new System.EventHandler(this.chbBeyondEol_CheckedChanged);
			// 
			// tpLineNumbers
			// 
			this.tpLineNumbers.Controls.Add(this.pnLineNumbers);
			this.tpLineNumbers.Location = new System.Drawing.Point(4, 22);
			this.tpLineNumbers.Name = "tpLineNumbers";
			this.tpLineNumbers.Size = new System.Drawing.Size(506, 118);
			this.tpLineNumbers.TabIndex = 10;
			this.tpLineNumbers.Text = "Line Numbers";
			this.tpLineNumbers.Visible = false;
			// 
			// pnLineNumbers
			// 
			this.pnLineNumbers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnLineNumbers.Controls.Add(this.gbLineNumbers);
			this.pnLineNumbers.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnLineNumbers.Location = new System.Drawing.Point(0, 0);
			this.pnLineNumbers.Name = "pnLineNumbers";
			this.pnLineNumbers.Size = new System.Drawing.Size(506, 112);
			this.pnLineNumbers.TabIndex = 0;
			// 
			// gbLineNumbers
			// 
			this.gbLineNumbers.Controls.Add(this.chbLineModificator);
			this.gbLineNumbers.Controls.Add(this.laLineNumbersStart);
			this.gbLineNumbers.Controls.Add(this.nudLineNumbersStart);
			this.gbLineNumbers.Controls.Add(this.cbLineNumbersAlign);
			this.gbLineNumbers.Controls.Add(this.laLineNumbersAlign);
			this.gbLineNumbers.Controls.Add(this.chbLinesOnGutter);
			this.gbLineNumbers.Controls.Add(this.chbLineNumbers);
			this.gbLineNumbers.Controls.Add(this.chbLinesBeyondEof);
			this.gbLineNumbers.Controls.Add(this.chbHighlightCurrentLine);
			this.gbLineNumbers.Location = new System.Drawing.Point(8, 8);
			this.gbLineNumbers.Name = "gbLineNumbers";
			this.gbLineNumbers.Size = new System.Drawing.Size(496, 96);
			this.gbLineNumbers.TabIndex = 3;
			this.gbLineNumbers.TabStop = false;
			this.gbLineNumbers.Text = "Line Numbers";
			// 
			// chbLineModificator
			// 
			this.chbLineModificator.Checked = true;
			this.chbLineModificator.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbLineModificator.Location = new System.Drawing.Point(144, 16);
			this.chbLineModificator.Name = "chbLineModificator";
			this.chbLineModificator.Size = new System.Drawing.Size(112, 16);
			this.chbLineModificator.TabIndex = 3;
			this.chbLineModificator.Text = "Line Modificators";
			this.chbLineModificator.CheckedChanged += new System.EventHandler(this.chbLineModificator_CheckedChanged);
			// 
			// laLineNumbersStart
			// 
			this.laLineNumbersStart.AutoSize = true;
			this.laLineNumbersStart.Location = new System.Drawing.Point(296, 19);
			this.laLineNumbersStart.Name = "laLineNumbersStart";
			this.laLineNumbersStart.Size = new System.Drawing.Size(95, 16);
			this.laLineNumbersStart.TabIndex = 5;
			this.laLineNumbersStart.Text = "Line numbers start";
			// 
			// nudLineNumbersStart
			// 
			this.nudLineNumbersStart.Location = new System.Drawing.Point(400, 16);
			this.nudLineNumbersStart.Name = "nudLineNumbersStart";
			this.nudLineNumbersStart.Size = new System.Drawing.Size(64, 20);
			this.nudLineNumbersStart.TabIndex = 7;
			this.nudLineNumbersStart.ValueChanged += new System.EventHandler(this.nudLineNumbersStart_ValueChanged);
			// 
			// cbLineNumbersAlign
			// 
			this.cbLineNumbersAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLineNumbersAlign.ItemHeight = 13;
			this.cbLineNumbersAlign.Location = new System.Drawing.Point(400, 40);
			this.cbLineNumbersAlign.Name = "cbLineNumbersAlign";
			this.cbLineNumbersAlign.Size = new System.Drawing.Size(64, 21);
			this.cbLineNumbersAlign.TabIndex = 8;
			this.cbLineNumbersAlign.SelectedIndexChanged += new System.EventHandler(this.cbLineNumbersAlign_SelectedIndexChanged);
			// 
			// laLineNumbersAlign
			// 
			this.laLineNumbersAlign.AutoSize = true;
			this.laLineNumbersAlign.Location = new System.Drawing.Point(296, 43);
			this.laLineNumbersAlign.Name = "laLineNumbersAlign";
			this.laLineNumbersAlign.Size = new System.Drawing.Size(96, 16);
			this.laLineNumbersAlign.TabIndex = 6;
			this.laLineNumbersAlign.Text = "Line numbers align";
			// 
			// chbLinesOnGutter
			// 
			this.chbLinesOnGutter.Location = new System.Drawing.Point(8, 40);
			this.chbLinesOnGutter.Name = "chbLinesOnGutter";
			this.chbLinesOnGutter.Size = new System.Drawing.Size(104, 16);
			this.chbLinesOnGutter.TabIndex = 1;
			this.chbLinesOnGutter.Text = "Lines on Gutter";
			this.chbLinesOnGutter.CheckedChanged += new System.EventHandler(this.chbLinesOnGutter_CheckedChanged);
			// 
			// chbLineNumbers
			// 
			this.chbLineNumbers.Location = new System.Drawing.Point(8, 16);
			this.chbLineNumbers.Name = "chbLineNumbers";
			this.chbLineNumbers.Size = new System.Drawing.Size(104, 16);
			this.chbLineNumbers.TabIndex = 0;
			this.chbLineNumbers.Text = "Line Numbers";
			this.chbLineNumbers.CheckedChanged += new System.EventHandler(this.chbLineNumbers_CheckedChanged);
			// 
			// chbLinesBeyondEof
			// 
			this.chbLinesBeyondEof.Location = new System.Drawing.Point(8, 64);
			this.chbLinesBeyondEof.Name = "chbLinesBeyondEof";
			this.chbLinesBeyondEof.Size = new System.Drawing.Size(112, 16);
			this.chbLinesBeyondEof.TabIndex = 2;
			this.chbLinesBeyondEof.Text = "Lines Beyond Eof";
			this.chbLinesBeyondEof.CheckedChanged += new System.EventHandler(this.chbLinesBeyondEof_CheckedChanged);
			// 
			// chbHighlightCurrentLine
			// 
			this.chbHighlightCurrentLine.Location = new System.Drawing.Point(144, 40);
			this.chbHighlightCurrentLine.Name = "chbHighlightCurrentLine";
			this.chbHighlightCurrentLine.Size = new System.Drawing.Size(136, 16);
			this.chbHighlightCurrentLine.TabIndex = 4;
			this.chbHighlightCurrentLine.Text = "Highlight Current Line";
			this.chbHighlightCurrentLine.CheckedChanged += new System.EventHandler(this.chbHighlightCurrentLine_CheckedChanged);
			// 
			// tpOther
			// 
			this.tpOther.Controls.Add(this.pnOther);
			this.tpOther.Location = new System.Drawing.Point(4, 22);
			this.tpOther.Name = "tpOther";
			this.tpOther.Size = new System.Drawing.Size(506, 118);
			this.tpOther.TabIndex = 12;
			this.tpOther.Text = "Other";
			// 
			// pnOther
			// 
			this.pnOther.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnOther.Controls.Add(this.gbBraces);
			this.pnOther.Controls.Add(this.gbOther);
			this.pnOther.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnOther.Location = new System.Drawing.Point(0, 0);
			this.pnOther.Name = "pnOther";
			this.pnOther.Size = new System.Drawing.Size(506, 112);
			this.pnOther.TabIndex = 0;
			// 
			// gbBraces
			// 
			this.gbBraces.Controls.Add(this.cbTempHighlightBraces);
			this.gbBraces.Controls.Add(this.chbUseRoundRect);
			this.gbBraces.Controls.Add(this.chbHighlightBraces);
			this.gbBraces.Location = new System.Drawing.Point(272, 8);
			this.gbBraces.Name = "gbBraces";
			this.gbBraces.Size = new System.Drawing.Size(232, 96);
			this.gbBraces.TabIndex = 5;
			this.gbBraces.TabStop = false;
			this.gbBraces.Text = "Braces";
			// 
			// cbTempHighlightBraces
			// 
			this.cbTempHighlightBraces.Location = new System.Drawing.Point(8, 64);
			this.cbTempHighlightBraces.Name = "cbTempHighlightBraces";
			this.cbTempHighlightBraces.Size = new System.Drawing.Size(112, 16);
			this.cbTempHighlightBraces.TabIndex = 3;
			this.cbTempHighlightBraces.Text = "Temp Hightlight";
			this.cbTempHighlightBraces.CheckedChanged += new System.EventHandler(this.cbTempHighlightBraces_CheckedChanged);
			// 
			// chbUseRoundRect
			// 
			this.chbUseRoundRect.Location = new System.Drawing.Point(8, 40);
			this.chbUseRoundRect.Name = "chbUseRoundRect";
			this.chbUseRoundRect.Size = new System.Drawing.Size(112, 16);
			this.chbUseRoundRect.TabIndex = 2;
			this.chbUseRoundRect.Text = "Use Round Rect";
			this.chbUseRoundRect.CheckedChanged += new System.EventHandler(this.chbUseRoundRect_CheckedChanged);
			// 
			// chbHighlightBraces
			// 
			this.chbHighlightBraces.Location = new System.Drawing.Point(8, 16);
			this.chbHighlightBraces.Name = "chbHighlightBraces";
			this.chbHighlightBraces.Size = new System.Drawing.Size(112, 16);
			this.chbHighlightBraces.TabIndex = 1;
			this.chbHighlightBraces.Text = "Highlight Braces";
			this.chbHighlightBraces.CheckedChanged += new System.EventHandler(this.chbHighlightBraces_CheckedChanged);
			// 
			// gbOther
			// 
			this.gbOther.Controls.Add(this.chbDrawColumnsIndent);
			this.gbOther.Controls.Add(this.chbQuickInfoTips);
			this.gbOther.Controls.Add(this.chbTransparent);
			this.gbOther.Controls.Add(this.chbSeparateLines);
			this.gbOther.Controls.Add(this.chbWhiteSpaceVisible);
			this.gbOther.Location = new System.Drawing.Point(8, 8);
			this.gbOther.Name = "gbOther";
			this.gbOther.Size = new System.Drawing.Size(256, 96);
			this.gbOther.TabIndex = 4;
			this.gbOther.TabStop = false;
			this.gbOther.Text = "Other";
			// 
			// chbTransparent
			// 
			this.chbTransparent.Location = new System.Drawing.Point(8, 64);
			this.chbTransparent.Name = "chbTransparent";
			this.chbTransparent.Size = new System.Drawing.Size(112, 16);
			this.chbTransparent.TabIndex = 3;
			this.chbTransparent.Text = "Transparent";
			this.chbTransparent.CheckedChanged += new System.EventHandler(this.chbTransparent_CheckedChanged);
			// 
			// chbSeparateLines
			// 
			this.chbSeparateLines.Location = new System.Drawing.Point(8, 16);
			this.chbSeparateLines.Name = "chbSeparateLines";
			this.chbSeparateLines.Size = new System.Drawing.Size(104, 16);
			this.chbSeparateLines.TabIndex = 1;
			this.chbSeparateLines.Text = "Separate Lines";
			this.chbSeparateLines.CheckedChanged += new System.EventHandler(this.chbSeparateLines_CheckedChanged);
			// 
			// chbWhiteSpaceVisible
			// 
			this.chbWhiteSpaceVisible.Location = new System.Drawing.Point(8, 40);
			this.chbWhiteSpaceVisible.Name = "chbWhiteSpaceVisible";
			this.chbWhiteSpaceVisible.Size = new System.Drawing.Size(120, 16);
			this.chbWhiteSpaceVisible.TabIndex = 2;
			this.chbWhiteSpaceVisible.Text = "Whitespace Visible";
			this.chbWhiteSpaceVisible.CheckedChanged += new System.EventHandler(this.chbWhiteSpaceVisible_CheckedChanged);
			// 
			// tpDialogs
			// 
			this.tpDialogs.Controls.Add(this.pnDialogs);
			this.tpDialogs.Location = new System.Drawing.Point(4, 22);
			this.tpDialogs.Name = "tpDialogs";
			this.tpDialogs.Size = new System.Drawing.Size(506, 118);
			this.tpDialogs.TabIndex = 2;
			this.tpDialogs.Text = "Dialogs";
			this.tpDialogs.Visible = false;
			// 
			// pnDialogs
			// 
			this.pnDialogs.BackColor = System.Drawing.SystemColors.Control;
			this.pnDialogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnDialogs.Controls.Add(this.gbDialogs);
			this.pnDialogs.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDialogs.Location = new System.Drawing.Point(0, 0);
			this.pnDialogs.Name = "pnDialogs";
			this.pnDialogs.Size = new System.Drawing.Size(506, 112);
			this.pnDialogs.TabIndex = 1;
			// 
			// gbDialogs
			// 
			this.gbDialogs.Controls.Add(this.btCustomize);
			this.gbDialogs.Controls.Add(this.btGoto);
			this.gbDialogs.Controls.Add(this.btReplace);
			this.gbDialogs.Controls.Add(this.btFind);
			this.gbDialogs.Controls.Add(this.btSave);
			this.gbDialogs.Controls.Add(this.btLoad);
			this.gbDialogs.Location = new System.Drawing.Point(8, 8);
			this.gbDialogs.Name = "gbDialogs";
			this.gbDialogs.Size = new System.Drawing.Size(496, 96);
			this.gbDialogs.TabIndex = 6;
			this.gbDialogs.TabStop = false;
			this.gbDialogs.Text = "Dialogs";
			// 
			// btCustomize
			// 
			this.btCustomize.BackColor = System.Drawing.SystemColors.Control;
			this.btCustomize.Location = new System.Drawing.Point(200, 56);
			this.btCustomize.Name = "btCustomize";
			this.btCustomize.Size = new System.Drawing.Size(80, 23);
			this.btCustomize.TabIndex = 11;
			this.btCustomize.Text = "Customize";
			this.btCustomize.Click += new System.EventHandler(this.btCustomize_Click);
			// 
			// btGoto
			// 
			this.btGoto.BackColor = System.Drawing.SystemColors.Control;
			this.btGoto.Location = new System.Drawing.Point(200, 24);
			this.btGoto.Name = "btGoto";
			this.btGoto.Size = new System.Drawing.Size(80, 23);
			this.btGoto.TabIndex = 10;
			this.btGoto.Text = "Go to Line";
			this.btGoto.Click += new System.EventHandler(this.btGoto_Click);
			// 
			// btReplace
			// 
			this.btReplace.BackColor = System.Drawing.SystemColors.Control;
			this.btReplace.Location = new System.Drawing.Point(104, 56);
			this.btReplace.Name = "btReplace";
			this.btReplace.Size = new System.Drawing.Size(80, 23);
			this.btReplace.TabIndex = 9;
			this.btReplace.Text = "Replace";
			this.btReplace.Click += new System.EventHandler(this.btReplace_Click);
			// 
			// btFind
			// 
			this.btFind.BackColor = System.Drawing.SystemColors.Control;
			this.btFind.Location = new System.Drawing.Point(104, 24);
			this.btFind.Name = "btFind";
			this.btFind.Size = new System.Drawing.Size(80, 23);
			this.btFind.TabIndex = 8;
			this.btFind.Text = "Find";
			this.btFind.Click += new System.EventHandler(this.btFind_Click);
			// 
			// btSave
			// 
			this.btSave.BackColor = System.Drawing.SystemColors.Control;
			this.btSave.Location = new System.Drawing.Point(8, 56);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(80, 23);
			this.btSave.TabIndex = 7;
			this.btSave.Text = "Save";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btLoad
			// 
			this.btLoad.BackColor = System.Drawing.SystemColors.Control;
			this.btLoad.Location = new System.Drawing.Point(8, 24);
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(80, 23);
			this.btLoad.TabIndex = 6;
			this.btLoad.Text = "Load";
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			// 
			// treeView1
			// 
			this.treeView1.BackColor = System.Drawing.SystemColors.Window;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.treeView1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("Appearance", new System.Windows.Forms.TreeNode[] {
																																										  new System.Windows.Forms.TreeNode("Gutter"),
																																										  new System.Windows.Forms.TreeNode("Margin"),
																																										  new System.Windows.Forms.TreeNode("Line Numbers"),
																																										  new System.Windows.Forms.TreeNode("Other"),
																																										  new System.Windows.Forms.TreeNode("Pages & Rulers")}),
																				  new System.Windows.Forms.TreeNode("Behavior", new System.Windows.Forms.TreeNode[] {
																																										new System.Windows.Forms.TreeNode("Outlining"),
																																										new System.Windows.Forms.TreeNode("Text Source"),
																																										new System.Windows.Forms.TreeNode("Navigation"),
																																										new System.Windows.Forms.TreeNode("Selection"),
																																										new System.Windows.Forms.TreeNode("WordWrap & Scrolling"),
																																										new System.Windows.Forms.TreeNode("Spelling & HyperText")}),
																				  new System.Windows.Forms.TreeNode("Dialogs", new System.Windows.Forms.TreeNode[] {
																																									   new System.Windows.Forms.TreeNode("Common Dialogs"),
																																									   new System.Windows.Forms.TreeNode("Printing & Exporting")}),
																				  new System.Windows.Forms.TreeNode("Properties"),
																				  new System.Windows.Forms.TreeNode("Company Info", new System.Windows.Forms.TreeNode[] {
																																											new System.Windows.Forms.TreeNode("About QWhale")})});
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(160, 478);
			this.treeView1.TabIndex = 11;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|C # files (*.cs)|*.cs|All files (*.*)|*.*";
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
			// chbQuickInfoTips
			// 
			this.chbQuickInfoTips.Location = new System.Drawing.Point(120, 16);
			this.chbQuickInfoTips.Name = "chbQuickInfoTips";
			this.chbQuickInfoTips.Size = new System.Drawing.Size(96, 16);
			this.chbQuickInfoTips.TabIndex = 4;
			this.chbQuickInfoTips.Text = "Quick Info Tips";
			this.chbQuickInfoTips.CheckedChanged += new System.EventHandler(this.chbQuickInfoTips_CheckedChanged);
			// 
			// chbDrawColumnsIndent
			// 
			this.chbDrawColumnsIndent.Location = new System.Drawing.Point(120, 40);
			this.chbDrawColumnsIndent.Name = "chbDrawColumnsIndent";
			this.chbDrawColumnsIndent.Size = new System.Drawing.Size(130, 16);
			this.chbDrawColumnsIndent.TabIndex = 5;
			this.chbDrawColumnsIndent.Text = "Draw Columns Indent";
			this.chbDrawColumnsIndent.CheckedChanged += new System.EventHandler(this.chbDrawColumnsIndent_CheckedChanged);
			// 
			// chbColumnsVisible
			// 
			this.chbColumnsVisible.Location = new System.Drawing.Point(168, 64);
			this.chbColumnsVisible.Name = "chbColumnsVisible";
			this.chbColumnsVisible.Size = new System.Drawing.Size(120, 16);
			this.chbColumnsVisible.TabIndex = 7;
			this.chbColumnsVisible.Text = "Columns Visible";
			this.chbColumnsVisible.CheckedChanged += new System.EventHandler(this.chbColumnsVisible_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(674, 478);
			this.Controls.Add(this.pnMain);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main Editor.NET Demo";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.pnMain.ResumeLayout(false);
			this.pnEditContainer.ResumeLayout(false);
			this.pnManage.ResumeLayout(false);
			this.tcContainer.ResumeLayout(false);
			this.tpGutter.ResumeLayout(false);
			this.pnGutter.ResumeLayout(false);
			this.gbGutter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudGutterWidth)).EndInit();
			this.tpCompanyInfo.ResumeLayout(false);
			this.pnCompanyInfo.ResumeLayout(false);
			this.tpMargin.ResumeLayout(false);
			this.pnMargin.ResumeLayout(false);
			this.gbMargin.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudMarginPos)).EndInit();
			this.tpWordWrap.ResumeLayout(false);
			this.pnWordWrap.ResumeLayout(false);
			this.gbWordWrap.ResumeLayout(false);
			this.tpTextSource.ResumeLayout(false);
			this.pnTextSource.ResumeLayout(false);
			this.tpPageLayout.ResumeLayout(false);
			this.pnPageLayout.ResumeLayout(false);
			this.gbRulers.ResumeLayout(false);
			this.gbPages.ResumeLayout(false);
			this.tpSpellAndUrl.ResumeLayout(false);
			this.pnSpellAndUrl.ResumeLayout(false);
			this.gbSpellAndUrl.ResumeLayout(false);
			this.tpProperties.ResumeLayout(false);
			this.tpOutlining.ResumeLayout(false);
			this.pnOutlining.ResumeLayout(false);
			this.gbOutlining.ResumeLayout(false);
			this.tpPrinting.ResumeLayout(false);
			this.pnPrinting.ResumeLayout(false);
			this.gbPrint.ResumeLayout(false);
			this.tpSelection.ResumeLayout(false);
			this.pnSelection.ResumeLayout(false);
			this.gbSelection.ResumeLayout(false);
			this.tpNavigate.ResumeLayout(false);
			this.pnNavigate.ResumeLayout(false);
			this.gbNavigateOptions.ResumeLayout(false);
			this.tpLineNumbers.ResumeLayout(false);
			this.pnLineNumbers.ResumeLayout(false);
			this.gbLineNumbers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudLineNumbersStart)).EndInit();
			this.tpOther.ResumeLayout(false);
			this.pnOther.ResumeLayout(false);
			this.gbBraces.ResumeLayout(false);
			this.gbOther.ResumeLayout(false);
			this.tpDialogs.ResumeLayout(false);
			this.pnDialogs.ResumeLayout(false);
			this.gbDialogs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}
		private string[] ObsoleteProps = 
		{
			"AccessibleDescription",
			"AccessibleName",
			"AccessibleRole"
		};
		private PropertyGrid propertyGrid = new PropertyGrid();
		private ArrayList obsolete = new ArrayList();
		private ComponentTypeDescriptorEx descriptor;
		private DefaultComponentContainer container = new DefaultComponentContainer();
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			foreach (string prop in ObsoleteProps)
				obsolete.Add(prop);
			descriptor = new ComponentTypeDescriptorEx(syntaxEdit, obsolete);
			container.Add(descriptor, string.Format("{0}{1}", "SyntaxEdit", "_Wrapper"));
			container.Add(textSource1, "TextSource1");
			container.Add(csParser1, "CsParser1");
			propertyGrid.Parent = pnPropertyGrid;
			propertyGrid.Dock = DockStyle.Fill;
			propertyGrid.SelectedObject = descriptor;
			propertyGrid.CommandsVisibleIfAvailable = true;
			propertyGrid.Text = "Property Grid";
			propertyGrid.ToolbarVisible = true;
			treeView1.ExpandAll();
			// changing default settings
			syntaxEdit.Scrolling.Options |= ScrollingOptions.ShowScrollHint;
			syntaxSplitEdit.Scrolling.Options |= ScrollingOptions.ShowScrollHint;
			// updating controls
			FillControls();
			// creating global settings
			GlobalSettings = new SyntaxSettings();
			Options = new DlgSyntaxSettings();
			GlobalSettings.LoadFromEdit(syntaxEdit);
			if (pictureBox1.Image is Bitmap)
				(pictureBox1.Image as Bitmap).MakeTransparent(Color.White);
			// displaying gutter panel
			UpdatePanels(treeView1.Nodes[0]);
		}

		private Panel GetCurrentPanel(TreeNode node)
		{
			//getting current panel to display
			if (node != null)
			{
				TreeNode root = node;
				while (root.Parent != null)
					root = root.Parent;
				if (root.Index == 0)
					switch(node.Index)
					{
						case 0:
							return pnGutter;
						case 1:
							return pnMargin;
						case 2:
							return pnLineNumbers;
						case 3:
							return pnOther;
						case 4:
							return pnPageLayout;
						default:
							return pnGutter;
					}
				else
					if (root.Index == 1)
					switch(node.Index)
					{
						case 0:
							return pnOutlining;
						case 1:
							return pnTextSource;
						case 2:
							return pnNavigate;
						case 3:
							return pnSelection;
						case 4:
							return pnWordWrap;
						case 5:
							return pnSpellAndUrl;
						default:
							return pnOutlining;
					}
				else
					if (root.Index == 2)
					switch(node.Index)
					{
						case 0:
							return pnDialogs;
						case 1:
							return pnPrinting;
						default:
							return pnDialogs;
					}
				else
					if (root.Index == 3)
					return pnProperties;
				else
					return pnCompanyInfo;
			}
			return pnGutter;
		}

		private void UpdatePanels(TreeNode node)
		{
			// displaying new panel
			Panel panel = GetCurrentPanel(node);
			if((panel != null) && !pnManage.Controls.Contains(panel))
				pnManage.Controls.Add(panel);
			int j = pnManage.Controls.IndexOf(panel);
			for(int i = 0; i < pnManage.Controls.Count; i++)
				if ((i != j) && (pnManage.Controls[i] is Panel))
					pnManage.Controls[i].Visible = false;
			bool isAbout = (panel != null)  && (panel.Equals(pnCompanyInfo));
			bool isTextSource = (panel != null)  && (panel.Equals(pnTextSource));
			bool isProperties = (panel != null) && (panel.Equals(pnProperties));
			if (isAbout)
			{
				pnManage.Dock = DockStyle.Fill;
				panel.Dock = DockStyle.Fill;
				pnEditContainer.Visible = false;
			}
			else
			{
				pnManage.Dock = DockStyle.Top;
				panel.Dock = DockStyle.Top;
				pnManage.Height = panel.Height;
				pnEditContainer.Visible = true;
			}
			pnPropertyGrid.Visible = isProperties;
			splitter2.Visible = isProperties;
			panel.Visible = true;
			panel.BringToFront();
			UpdateEditorVisibility(!isAbout, isTextSource, pnMain.Height - panel.Height - splitter1.Height);
		}
		private void UpdateEditorVisibility(bool visible, bool split, int height)
		{
			// splitting view if needed
			syntaxEdit.Visible = visible;
			syntaxSplitEdit.Visible = split;
			splitter1.Visible = split;
			if (split)
			{
				syntaxSplitEdit.Height = height / 2;
			}
		}
		private void FillControls()
		{
			// updating controls according to editor properties
			scrollBoxUpdate ++;
			try
			{
				//margin
				nudMarginPos.Maximum = 1000;
				nudMarginPos.Value = syntaxEdit.EditMargin.Position;
				chbShowMargin.Checked = syntaxEdit.EditMargin.Visible;
				chbAllowDragMargin.Checked = syntaxEdit.EditMargin.AllowDrag;
				chbShowMarginHints.Checked = syntaxEdit.EditMargin.ShowHints;
				chbColumnsVisible.Checked = syntaxEdit.EditMargin.ColumnsVisible;
				//gutter
				syntaxEdit.LineStyles.AddLineStyle("breakpoint", Color.White, Color.Red, Color.Empty, 12, LineStyleOptions.BeyondEol);
				syntaxSplitEdit.LineStyles.AddLineStyle("breakpoint", Color.White, Color.Red, Color.Empty, 12, LineStyleOptions.BeyondEol);
				chbShowGutter.Checked = syntaxEdit.Gutter.Visible;
				chbPaintBookMarks.Checked = (GutterOptions.PaintBookMarks & syntaxEdit.Gutter.Options) != 0;
				chbLineNumbers.Checked = (GutterOptions.PaintLineNumbers & syntaxEdit.Gutter.Options) != 0;
				chbLinesOnGutter.Checked = (GutterOptions.PaintLinesOnGutter & syntaxEdit.Gutter.Options) != 0;
				chbLinesBeyondEof.Checked = (GutterOptions.PaintLinesBeyondEof & syntaxEdit.Gutter.Options) != 0;
				chbDrawLineBookmarks.Checked = syntaxEdit.Gutter.DrawLineBookmarks;
				chbLineModificator.Checked = (GutterOptions.PaintLineModificators & syntaxEdit.Gutter.Options) != 0;
				nudGutterWidth.Maximum = syntaxEdit.Width;
				nudGutterWidth.Value = syntaxEdit.Gutter.Width;
				nudLineNumbersStart.Maximum = 10000;
				nudLineNumbersStart.Value = syntaxEdit.Gutter.LineNumbersStart;
				string [] s = Enum.GetNames(typeof(StringAlignment));
				cbLineNumbersAlign.Items.AddRange(s);
				cbLineNumbersAlign.SelectedIndex = (int)syntaxEdit.Gutter.LineNumbersAlignment;			
				chbHighlightCurrentLine.Checked = (SeparatorOptions.HighlightCurrentLine & syntaxEdit.LineSeparator.Options) != 0;
				//other
				chbSeparateLines.Checked = (SeparatorOptions.SeparateLines & syntaxEdit.LineSeparator.Options) != 0;
				chbQuickInfoTips.Checked = (SyntaxOptions.QuickInfoTips & csParser1.Options ) != 0;
				chbDrawColumnsIndent.Checked = syntaxEdit.DrawColumnsIndent;
				chbWhiteSpaceVisible.Checked = syntaxEdit.WhiteSpace.Visible;
				chbHighlightBraces.Checked = (BracesOptions.Highlight & syntaxEdit.Braces.BracesOptions) != 0;
				chbUseRoundRect.Checked = syntaxEdit.Braces.UseRoundRect;
				cbTempHighlightBraces.Checked = (BracesOptions.TempHighlight & syntaxEdit.Braces.BracesOptions) != 0;
				chbTransparent.Checked = syntaxEdit.Transparent;
				//PageLayout&Ruler
				s = Enum.GetNames(typeof(PageType));
				cbPageLayout.Items.AddRange(s);
				cbPageLayout.SelectedIndex = (int)syntaxEdit.Pages.PageType;
				s = Enum.GetNames(typeof(RulerUnits));
				cbRulerUnits.Items.AddRange(s);
				cbRulerUnits.SelectedIndex = (int)syntaxEdit.Pages.RulerUnits;	
				chbRulerAllowDrag.Checked = (RulerOptions.AllowDrag & syntaxEdit.Pages.RulerOptions) != 0;
				chbRulerDiscrete.Checked = (RulerOptions.Discrete & syntaxEdit.Pages.RulerOptions) != 0;
				chbRulerDisplayDragLines.Checked = (RulerOptions.DisplayDragLine & syntaxEdit.Pages.RulerOptions) != 0;
				chbHorzRuler.Checked = (EditRulers.Horizonal & syntaxEdit.Pages.Rulers) != 0;
				chbVertRuler.Checked = (EditRulers.Vertical & syntaxEdit.Pages.Rulers) != 0;

				foreach(PaperSize psize in syntaxEdit.Printing.PrinterSettings.PaperSizes)
				{
					if (!cbPageSize.Items.Contains(psize.Kind))
						cbPageSize.Items.Add(psize.Kind);
				}
				cbPageSize.Enabled = cbPageSize.Items.Count > 0;
				if (cbPageSize.Enabled)
					cbPageSize.SelectedIndex = 0;
				//wordwrap
				chbWordWrap.Checked = syntaxEdit.WordWrap;
				chbWrapAtMargin.Checked = syntaxEdit.WrapAtMargin;
				chbAllowSplit.Checked = ((ScrollingOptions.AllowSplitHorz & syntaxEdit.Scrolling.Options) != 0) &
					((ScrollingOptions.AllowSplitVert & syntaxEdit.Scrolling.Options) != 0);
				chbScrollButtons.Checked = ((ScrollingOptions.HorzButtons & syntaxEdit.Scrolling.Options) != 0) &
					((ScrollingOptions.VertButtons & syntaxEdit.Scrolling.Options) != 0);
				chbSystemScrollBars.Checked = (syntaxEdit.Scrolling.Options & ScrollingOptions.SystemScrollbars) != 0;
				chbFlatScrollBars.Checked = (syntaxEdit.Scrolling.Options & ScrollingOptions.FlatScrollbars) != 0;
				//outlining
				chbAllowOutlining.Checked = syntaxEdit.Outlining.AllowOutlining;
				chbDrawOnGutter.Checked = (OutlineOptions.DrawOnGutter & syntaxEdit.Outlining.OutlineOptions) != 0;
				chbDrawLines.Checked = (OutlineOptions.DrawLines & syntaxEdit.Outlining.OutlineOptions) != 0;
				chbDrawButtons.Checked = (OutlineOptions.DrawButtons & syntaxEdit.Outlining.OutlineOptions) != 0;
				chbShowHints.Checked = (OutlineOptions.ShowHints & syntaxEdit.Outlining.OutlineOptions) != 0;
				//spell&url
				chbCheckSpelling.Checked = syntaxEdit.Spelling.CheckSpelling;
				chbHighlightUrls.Checked = syntaxEdit.HyperText.HighlightUrls;
				chbShowScrollHint.Checked = (syntaxEdit.Scrolling.Options & ScrollingOptions.ShowScrollHint) != 0;
				chbSmoothScroll.Checked = (syntaxEdit.Scrolling.Options & ScrollingOptions.SmoothScroll) != 0;
				chbShowHyperTextHints.Checked = syntaxEdit.HyperText.ShowHints;
				//navigate&selection
				chbBeyondEol.Checked = (NavigateOptions.BeyondEol & syntaxEdit.NavigateOptions) != 0;
				chbBeyondEof.Checked = (NavigateOptions.BeyondEof & syntaxEdit.NavigateOptions) != 0;
				chbUpAtLineBegin.Checked = (NavigateOptions.UpAtLineBegin & syntaxEdit.NavigateOptions) != 0;
				chbDownAtLineEnd.Checked = (NavigateOptions.DownAtLineEnd & syntaxEdit.NavigateOptions) != 0;
				chbMoveOnRightButton.Checked = (NavigateOptions.MoveOnRightButton & syntaxEdit.NavigateOptions) != 0;

				chbDisableSelection.Checked = (SelectionOptions.DisableSelection & syntaxEdit.Selection.Options) != 0;
				chbDisableDragging.Checked = (SelectionOptions.DisableDragging & syntaxEdit.Selection.Options) != 0;
				chbSelectBeyondEol.Checked = (SelectionOptions.SelectBeyondEol & syntaxEdit.Selection.Options) != 0;
				chbUseColors.Checked = (SelectionOptions.UseColors & syntaxEdit.Selection.Options) != 0;
				chbHideSelection.Checked = (SelectionOptions.HideSelection & syntaxEdit.Selection.Options) != 0;
				chbSelectLineOnDblClick.Checked = (SelectionOptions.SelectLineOnDblClick & syntaxEdit.Selection.Options) != 0;
				chbDeselectOnCopy.Checked = (SelectionOptions.DeselectOnCopy & syntaxEdit.Selection.Options) != 0;
				chbPersistentBlocks.Checked = (SelectionOptions.PersistentBlocks & syntaxEdit.Selection.Options) != 0;
				chbOverwriteBlocks.Checked = (SelectionOptions.OverwriteBlocks & syntaxEdit.Selection.Options) != 0;
			}
			finally
			{
				scrollBoxUpdate--;
			}
		}
		private void UpdateScrollBoxes(object sender)
		{
			// updating checkboxes related to scrolling properties
			if (scrollBoxUpdate > 0)
				return;
			scrollBoxUpdate++;
			try
			{
				if (chbAllowSplit != sender)
				{
					chbAllowSplit.Checked = ((ScrollingOptions.AllowSplitHorz & syntaxEdit.Scrolling.Options) != 0) &
						((ScrollingOptions.AllowSplitVert & syntaxEdit.Scrolling.Options) != 0);
				}
				if (chbScrollButtons != sender)
				{
					chbScrollButtons.Checked = ((ScrollingOptions.HorzButtons & syntaxEdit.Scrolling.Options) != 0) &
						((ScrollingOptions.VertButtons & syntaxEdit.Scrolling.Options) != 0);
				}
				if (chbSystemScrollBars != sender)
					chbSystemScrollBars.Checked = (syntaxEdit.Scrolling.Options & ScrollingOptions.SystemScrollbars) != 0;
	
				if (chbFlatScrollBars != sender)
					chbFlatScrollBars.Checked = (syntaxEdit.Scrolling.Options & ScrollingOptions.FlatScrollbars) != 0;
			}
			finally
			{
				scrollBoxUpdate--;
			}

		}

		private void chbShowGutter_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating gutter visiblility
			syntaxEdit.Gutter.Visible = chbShowGutter.Checked;
			syntaxSplitEdit.Gutter.Visible = chbShowGutter.Checked;
		}

		private void chbShowMargin_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating margin visiblility
			syntaxEdit.EditMargin.Visible = chbShowMargin.Checked;
			syntaxSplitEdit.EditMargin.Visible = chbShowMargin.Checked;
		}

		private void chbSeparateLines_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating lineseparator properties
			syntaxEdit.LineSeparator.Options = (chbSeparateLines.Checked ? syntaxEdit.LineSeparator.Options 
				| SeparatorOptions.SeparateLines : syntaxEdit.LineSeparator.Options ^ SeparatorOptions.SeparateLines);		
			syntaxSplitEdit.LineSeparator.Options = syntaxEdit.LineSeparator.Options;
		}

		private void chbPaintBookMarks_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating bookmarks visibility
			syntaxEdit.Gutter.Options = (chbPaintBookMarks.Checked ? syntaxEdit.Gutter.Options 
				| GutterOptions.PaintBookMarks : syntaxEdit.Gutter.Options ^ GutterOptions.PaintBookMarks);		
			syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options;
		}

		private void chbDrawLineBookmarks_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating line bookmarks visibility
			syntaxEdit.Gutter.DrawLineBookmarks = chbDrawLineBookmarks.Checked;
			syntaxSplitEdit.Gutter.DrawLineBookmarks = chbDrawLineBookmarks.Checked;
		}

		private void chbHighlightCurrentLine_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating line separator visibility
			syntaxEdit.LineSeparator.Options = (chbHighlightCurrentLine.Checked ? syntaxEdit.LineSeparator.Options 
				| SeparatorOptions.HighlightCurrentLine : syntaxEdit.LineSeparator.Options ^ SeparatorOptions.HighlightCurrentLine);		
			syntaxSplitEdit.LineSeparator.Options = syntaxEdit.LineSeparator.Options;
		}
		private void chbLineModificator_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating line modificator visibility
			syntaxEdit.Gutter.Options = (chbLineModificator.Checked ? syntaxEdit.Gutter.Options 
				| GutterOptions.PaintLineModificators : syntaxEdit.Gutter.Options ^ GutterOptions.PaintLineModificators);
			syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options;
		}
		private void nudGutterWidth_ValueChanged(object sender, System.EventArgs e)
		{
			// updating gutter width
			syntaxEdit.Gutter.Width = (int)nudGutterWidth.Value;
			syntaxSplitEdit.Gutter.Width = (int)nudGutterWidth.Value;
		}

		private void nudMarginPos_ValueChanged(object sender, System.EventArgs e)
		{
			// updating margin position
			syntaxEdit.EditMargin.Position = (int)nudMarginPos.Value;
			syntaxSplitEdit.EditMargin.Position = (int)nudMarginPos.Value;
		}

		private void btShowBookmarks_Click(object sender, System.EventArgs e)
		{
			// setting or removing sample bookmarks and line styles
			int i = syntaxEdit.ScreenToText(0, 0).Y;
			syntaxEdit.Source.BeginUpdate();
			try
			{
				if (btShowBookmarks.Text == "Set Bookmarks")
				{
					syntaxEdit.Source.LineStyles.SetLineStyle(i + 12, 0);
					syntaxEdit.Source.BookMarks.SetBookMark(new Point(6,i + 1), 0);
					syntaxEdit.Source.BookMarks.SetBookMark(new Point(9,i + 15), 7);
					syntaxEdit.Source.BookMarks.SetBookMark(new Point(14,i + 6), 10);
					btShowBookmarks.Text = "Clear Bookmarks";
				}
				else
				{
					syntaxEdit.Source.LineStyles.Clear();
					syntaxEdit.Source.BookMarks.ClearAllBookMarks();
					btShowBookmarks.Text = "Set Bookmarks";
				}
			}
			finally
			{
				syntaxEdit.Source.EndUpdate();
				syntaxEdit.Invalidate();
			}
		}

		private void chbLineNumbers_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating line numbers visibility
			syntaxEdit.Gutter.Options = (chbLineNumbers.Checked ? syntaxEdit.Gutter.Options 
				| GutterOptions.PaintLineNumbers : syntaxEdit.Gutter.Options ^ GutterOptions.PaintLineNumbers);
			syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options;
		}

		private void chbLinesOnGutter_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating displaying line numbers on gutter
			syntaxEdit.Gutter.Options = (chbLinesOnGutter.Checked ? syntaxEdit.Gutter.Options 
				| GutterOptions.PaintLinesOnGutter : syntaxEdit.Gutter.Options ^ GutterOptions.PaintLinesOnGutter);		
			syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options;
		}

		private void chbLinesBeyondEof_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating displaying line numbers beyond end of file
			syntaxEdit.Gutter.Options = (chbLinesBeyondEof.Checked ? syntaxEdit.Gutter.Options | 
				GutterOptions.PaintLinesBeyondEof : syntaxEdit.Gutter.Options ^ GutterOptions.PaintLinesBeyondEof);		
			syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options;
		}

		private void nudLineNumbersStart_ValueChanged(object sender, System.EventArgs e)
		{
			//updating line number start
			syntaxEdit.Gutter.LineNumbersStart = (int)nudLineNumbersStart.Value;
			syntaxSplitEdit.Gutter.LineNumbersStart = (int)nudLineNumbersStart.Value;
		}

		private void cbLineNumbersAlign_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// updating line numbers alignment
			syntaxEdit.Gutter.LineNumbersAlignment = (StringAlignment)cbLineNumbersAlign.SelectedIndex;
			syntaxSplitEdit.Gutter.LineNumbersAlignment = (StringAlignment)cbLineNumbersAlign.SelectedIndex;
		}
		//dialogs
		private void btLoad_Click(object sender, System.EventArgs e)
		{
			// loading editor content from the file
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				System.IO.FileInfo fi = new System.IO.FileInfo(openFileDialog1.FileName);
				if (fi.Extension == ".xml")
					syntaxEdit.LoadFile(openFileDialog1.FileName, ExportFormat.Xml);
				else
					textSource1.LoadFile(openFileDialog1.FileName);
			}
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
			// saving editor content to the file
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				textSource1.SaveFile(saveFileDialog1.FileName);				
		}

		private void btFind_Click(object sender, System.EventArgs e)
		{
			// displaying search dialog
			syntaxEdit.DisplaySearchDialog();
		}

		private void btReplace_Click(object sender, System.EventArgs e)
		{
			// displaying search dialog
			syntaxEdit.DisplayReplaceDialog();
		}

		private void btGoto_Click(object sender, System.EventArgs e)
		{
			// displaying goto line dialog
			syntaxEdit.DisplayGotoLineDialog();
		}

		private void btCustomize_Click(object sender, System.EventArgs e)
		{
			// displaying editor settings dialog.
			Options.SyntaxSettings.Assign(GlobalSettings);
			if (Options.ShowDialog() == DialogResult.OK)
			{
				GlobalSettings.Assign(Options.SyntaxSettings);
				GlobalSettings.ApplyToEdit(syntaxEdit);
				GlobalSettings.ApplyToEdit(syntaxSplitEdit);
			}		
		}
		private void chbWordWrap_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating wordwrap mode
			syntaxEdit.WordWrap = chbWordWrap.Checked;
			syntaxSplitEdit.WordWrap = chbWordWrap.Checked;
		}

		private void chbWrapAtMargin_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating wrapping at margin 
			syntaxEdit.WrapAtMargin = chbWrapAtMargin.Checked;
			syntaxSplitEdit.WrapAtMargin = chbWrapAtMargin.Checked;
		}

		private void chbWhiteSpaceVisible_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating whitespace visibility
			syntaxEdit.WhiteSpace.Visible = chbWhiteSpaceVisible.Checked;
			syntaxSplitEdit.WhiteSpace.Visible = chbWhiteSpaceVisible.Checked;
		}

		//printing&exporting
		private void btRtf_Click(object sender, System.EventArgs e)
		{
			// saving editor to rtf
			saveFileDialog2.FilterIndex = 1;
			if (saveFileDialog2.ShowDialog() == DialogResult.OK)
				syntaxEdit.SaveFile(saveFileDialog2.FileName, ExportFormat.Rtf);				
		}

		private void btHtml_Click(object sender, System.EventArgs e)
		{
			// saving editor to html
			saveFileDialog2.FilterIndex = 2;
			if (saveFileDialog2.ShowDialog() == DialogResult.OK)
				syntaxEdit.SaveFile(saveFileDialog2.FileName, ExportFormat.Html);				
		}

		private void btXml_Click(object sender, System.EventArgs e)
		{
			// saving editor to xml
			saveFileDialog2.FilterIndex = 3;
			if (saveFileDialog2.ShowDialog() == DialogResult.OK)
				syntaxEdit.SaveFile(saveFileDialog2.FileName, ExportFormat.Xml);				
		}

		private void btPrintPreview_Click(object sender, System.EventArgs e)
		{
			// executing print preview dialog
			syntaxEdit.Printing.ExecutePrintPreviewDialog();
		}

		private void btPrint_Click(object sender, System.EventArgs e)
		{
			// executing print dialog
			syntaxEdit.Printing.ExecutePrintDialog();
		}

		private void btPageSetup_Click(object sender, System.EventArgs e)
		{
			// executing page setup dialog
			syntaxEdit.Printing.ExecutePageSetupDialog();;
		}
		//outlining
		private void chbAllowOutlining_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating outlining mode
			syntaxEdit.Outlining.AllowOutlining = chbAllowOutlining.Checked;
			syntaxSplitEdit.Outlining.AllowOutlining = syntaxEdit.Outlining.AllowOutlining;
		}
		private void chbDrawOnGutter_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating outlining options
			syntaxEdit.Outlining.OutlineOptions = (chbDrawOnGutter.Checked ? syntaxEdit.Outlining.OutlineOptions 
				| OutlineOptions.DrawOnGutter : syntaxEdit.Outlining.OutlineOptions ^ OutlineOptions.DrawOnGutter);		
			syntaxSplitEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions;
		}

		private void chbDrawLines_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating outlining options
			syntaxEdit.Outlining.OutlineOptions = (chbDrawLines.Checked ? syntaxEdit.Outlining.OutlineOptions 
				| OutlineOptions.DrawLines : syntaxEdit.Outlining.OutlineOptions ^ OutlineOptions.DrawLines);		
			syntaxSplitEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions;
		}

		private void chbDrawButtons_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating outlining options
			syntaxEdit.Outlining.OutlineOptions = (chbDrawButtons.Checked ? syntaxEdit.Outlining.OutlineOptions 
				| OutlineOptions.DrawButtons: syntaxEdit.Outlining.OutlineOptions ^ OutlineOptions.DrawButtons);
			syntaxSplitEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions;
		}

		private void chbShowHints_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating outlining options
			syntaxEdit.Outlining.OutlineOptions = (chbShowHints.Checked ? syntaxEdit.Outlining.OutlineOptions 
				| OutlineOptions.ShowHints: syntaxEdit.Outlining.OutlineOptions ^ OutlineOptions.ShowHints);		
			syntaxSplitEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions;
		}
		//spell&url
		private void chbCheckSpelling_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating spelling options
			syntaxEdit.Spelling.CheckSpelling = chbCheckSpelling.Checked;
			syntaxSplitEdit.Spelling.CheckSpelling = chbCheckSpelling.Checked;
		}

		private void chbHighlightUrls_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating hypertext options
			syntaxEdit.HyperText.HighlightUrls = chbHighlightUrls.Checked;
			syntaxSplitEdit.HyperText.HighlightUrls = chbHighlightUrls.Checked;
		}

		private void chbShowScrollHint_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating scrolling options
			syntaxEdit.Scrolling.Options = (chbShowScrollHint.Checked ? syntaxEdit.Scrolling.Options
				| ScrollingOptions.ShowScrollHint : syntaxEdit.Scrolling.Options ^ ScrollingOptions.ShowScrollHint);
			syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options;
		}
		private void chbAllowSplit_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating splitting options
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit.Scrolling.Options = (chbAllowSplit.Checked ? syntaxEdit.Scrolling.Options
			| ScrollingOptions.AllowSplitHorz | ScrollingOptions.AllowSplitVert : 
				syntaxEdit.Scrolling.Options ^ ScrollingOptions.AllowSplitHorz ^ ScrollingOptions.AllowSplitVert);
			syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options;
			UpdateScrollBoxes(chbAllowSplit);
		}
		private void chbScrollButtons_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating scrolling buttons
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit.Scrolling.Options = (chbScrollButtons.Checked ? syntaxEdit.Scrolling.Options
				| ScrollingOptions.HorzButtons | ScrollingOptions.VertButtons : 
				syntaxEdit.Scrolling.Options ^ ScrollingOptions.HorzButtons ^ ScrollingOptions.VertButtons);
			syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options;		
			UpdateScrollBoxes(chbScrollButtons);
		}
		private void chbSmoothScroll_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating smooth scroll
			syntaxEdit.Scrolling.Options = (chbSmoothScroll.Checked ? syntaxEdit.Scrolling.Options
				| ScrollingOptions.SmoothScroll : syntaxEdit.Scrolling.Options ^ ScrollingOptions.SmoothScroll);
			syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options;
		}
		//navigate&selection
		private void chbBeyondEol_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating navigate options
			syntaxEdit.NavigateOptions = (chbBeyondEol.Checked ? syntaxEdit.NavigateOptions 
				| NavigateOptions.BeyondEol: syntaxEdit.NavigateOptions ^ NavigateOptions.BeyondEol);
			syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions;
		}

		private void chbBeyondEof_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating navigate options
			syntaxEdit.NavigateOptions = (chbBeyondEof.Checked ? syntaxEdit.NavigateOptions 
				| NavigateOptions.BeyondEof: syntaxEdit.NavigateOptions ^ NavigateOptions.BeyondEof);		
			syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions;
		}

		private void chbUpAtLineBegin_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating navigate options
			syntaxEdit.NavigateOptions = (chbUpAtLineBegin.Checked ? syntaxEdit.NavigateOptions 
				| NavigateOptions.UpAtLineBegin: syntaxEdit.NavigateOptions ^ NavigateOptions.UpAtLineBegin);		
			syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions;
		}

		private void chbDownAtLineEnd_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating navigate options
			syntaxEdit.NavigateOptions = (chbDownAtLineEnd.Checked ? syntaxEdit.NavigateOptions 
				| NavigateOptions.DownAtLineEnd: syntaxEdit.NavigateOptions ^ NavigateOptions.DownAtLineEnd);		
			syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions;
		}

		private void chbMoveOnRightButton_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating navigate options
			syntaxEdit.NavigateOptions = (chbMoveOnRightButton.Checked ? syntaxEdit.NavigateOptions 
				| NavigateOptions.MoveOnRightButton: syntaxEdit.NavigateOptions ^ NavigateOptions.MoveOnRightButton);	
			syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions;
		}

		private void chbDisableSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection options
			syntaxEdit.Selection.Options = (chbDisableSelection.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.DisableSelection: syntaxEdit.Selection.Options ^ SelectionOptions.DisableSelection);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
		}

		private void chbDisableDragging_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection options
			syntaxEdit.Selection.Options = (chbDisableDragging.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.DisableDragging: syntaxEdit.Selection.Options ^ SelectionOptions.DisableDragging);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
		}

		private void chbSelectBeyondEol_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection options
			syntaxEdit.Selection.Options = (chbSelectBeyondEol.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.SelectBeyondEol: syntaxEdit.Selection.Options ^ SelectionOptions.SelectBeyondEol);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
		}

		private void chbUseColors_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection appearance
			syntaxEdit.Selection.Options = (chbUseColors.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.UseColors: syntaxEdit.Selection.Options ^ SelectionOptions.UseColors);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
		}

		private void chbHideSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection appearance
			syntaxEdit.Selection.Options = (chbHideSelection.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.HideSelection: syntaxEdit.Selection.Options ^ SelectionOptions.HideSelection);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
		}

		private void chbSelectLineOnDblClick_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection options
			syntaxEdit.Selection.Options = (chbSelectLineOnDblClick.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.SelectLineOnDblClick: syntaxEdit.Selection.Options ^ SelectionOptions.SelectLineOnDblClick);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
		}

		private void chbDeselectOnCopy_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection options
			syntaxEdit.Selection.Options = (chbDeselectOnCopy.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.DeselectOnCopy: syntaxEdit.Selection.Options ^ SelectionOptions.DeselectOnCopy);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
		}

		private void chbPersistentBlocks_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection options
			syntaxEdit.Selection.Options = (chbPersistentBlocks.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.PersistentBlocks: syntaxEdit.Selection.Options ^ SelectionOptions.PersistentBlocks);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
		}

		private void chbOverwriteBlocks_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating selection options
			syntaxEdit.Selection.Options = (chbOverwriteBlocks.Checked ? syntaxEdit.Selection.Options 
				| SelectionOptions.OverwriteBlocks: syntaxEdit.Selection.Options ^ SelectionOptions.OverwriteBlocks);		
			syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options;
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
			try
			{
				System.Diagnostics.Process.Start(laMailTo.Text);		
			}
			catch
			{
				//
			}
		}

		private void chbShowHyperTextHints_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating hypertext options
			syntaxEdit.HyperText.ShowHints = chbShowHyperTextHints.Checked;
			syntaxSplitEdit.HyperText.ShowHints = chbShowHyperTextHints.Checked;
		}

		private void cbPageLayout_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// updating page layout mode
			syntaxEdit.Pages.PageType = (PageType)cbPageLayout.SelectedIndex;
			syntaxSplitEdit.Pages.PageType = (PageType)cbPageLayout.SelectedIndex;
			if (cbPageSize.Items.Count > 0)
				cbPageSize.SelectedIndex = Math.Max(cbPageSize.Items.IndexOf(syntaxEdit.Pages.DefaultPage.PageKind), 0);
		}

		private void UpdatePageKind(ISyntaxEdit edit, PaperKind kind)
		{
			for(int i = 0; i < edit.Pages.Count; i++)
				edit.Pages[i].PageKind = kind;
		}
		private void cbPageSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// updating page size
			object obj = Enum.Parse(typeof(PaperKind), cbPageSize.Text);
			if (obj is PaperKind)
			{
				UpdatePageKind(syntaxEdit, (PaperKind)obj);
				UpdatePageKind(syntaxSplitEdit, (PaperKind)obj);
			}
		}

		private void chbRulerAllowDrag_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating ruler options
			syntaxEdit.Pages.RulerOptions = (chbRulerAllowDrag.Checked ? syntaxEdit.Pages.RulerOptions
				| RulerOptions.AllowDrag: syntaxEdit.Pages.RulerOptions ^ RulerOptions.AllowDrag);
			syntaxSplitEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions;
		}

		private void chbRulerDiscrete_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating ruler options
			syntaxEdit.Pages.RulerOptions = (chbRulerDiscrete.Checked ? syntaxEdit.Pages.RulerOptions
				| RulerOptions.Discrete: syntaxEdit.Pages.RulerOptions ^ RulerOptions.Discrete);
			syntaxSplitEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions;		
		}

		private void chbRulerDisplayDragLines_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating ruler options
			syntaxEdit.Pages.RulerOptions = (chbRulerDisplayDragLines.Checked ? syntaxEdit.Pages.RulerOptions
				| RulerOptions.DisplayDragLine: syntaxEdit.Pages.RulerOptions ^ RulerOptions.DisplayDragLine);
			syntaxSplitEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions;				
		}

		private void chbHighlightBraces_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating matching braces options
			if (chbHighlightBraces.Checked)
				syntaxEdit.Braces.BracesOptions = BracesOptions.Highlight | BracesOptions.HighlightBounds;
			else
				syntaxEdit.Braces.BracesOptions = BracesOptions.None;
			syntaxSplitEdit.Braces.BracesOptions = syntaxEdit.Braces.BracesOptions;
		}

		private void chbUseRoundRect_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating matching braces appearance
			syntaxEdit.Braces.UseRoundRect = chbUseRoundRect.Checked;
			syntaxSplitEdit.Braces.UseRoundRect = chbUseRoundRect.Checked;
			syntaxEdit.Braces.ForeColor = chbUseRoundRect.Checked? Color.Gray: Color.Black;
			syntaxSplitEdit.Braces.ForeColor = syntaxEdit.Braces.ForeColor;
		}

		private void chbAllowDragMargin_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating margin options
			syntaxEdit.EditMargin.AllowDrag = chbAllowDragMargin.Checked;
			syntaxSplitEdit.EditMargin.AllowDrag = chbAllowDragMargin.Checked;
		}

		private void chbShowMarginHints_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating margin options
			syntaxEdit.EditMargin.ShowHints = chbShowMarginHints.Checked;
			syntaxSplitEdit.EditMargin.ShowHints = chbShowMarginHints.Checked;
		}

		private void chbTransparent_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating transparent property
			syntaxEdit.Transparent = chbTransparent.Checked;
			syntaxSplitEdit.Transparent = chbTransparent.Checked;
		}

		private void cbRulerUnits_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// updating ruler units
			syntaxEdit.Pages.RulerUnits = (RulerUnits)cbRulerUnits.SelectedIndex;
			syntaxSplitEdit.Pages.RulerUnits = (RulerUnits)cbRulerUnits.SelectedIndex;		
		}

		private void cbTempHighlightBraces_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating braces options
			syntaxEdit.Braces.BracesOptions = (cbTempHighlightBraces.Checked ? syntaxEdit.Braces.BracesOptions
				| BracesOptions.TempHighlight: syntaxEdit.Braces.BracesOptions ^ BracesOptions.TempHighlight);
			syntaxSplitEdit.Braces.BracesOptions = syntaxEdit.Braces.BracesOptions;
		}

		private void chbHorzRuler_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating ruler options
			syntaxEdit.Pages.Rulers = (chbHorzRuler.Checked ? syntaxEdit.Pages.Rulers
				| EditRulers.Horizonal: syntaxEdit.Pages.Rulers ^ EditRulers.Horizonal);
			syntaxSplitEdit.Pages.Rulers = syntaxEdit.Pages.Rulers;
		}

		private void chbVertRuler_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating ruler options
			syntaxEdit.Pages.Rulers = (chbVertRuler.Checked ? syntaxEdit.Pages.Rulers
				| EditRulers.Vertical: syntaxEdit.Pages.Rulers ^ EditRulers.Vertical);
			syntaxSplitEdit.Pages.Rulers = syntaxEdit.Pages.Rulers;		
		}

		private void syntaxEdit_WordSpell(object sender, QWhale.Editor.WordSpellEventArgs e)
		{
			// sample event for checking spelling
			e.Correct = (syntaxEdit.Lexer == null) || !syntaxEdit.Lexer.Scheme.IsPlainText(e.ColorStyle - 1);
		}

		private void syntaxEdit_ScrollButtonClick(object sender, System.EventArgs e)
		{
			// sample event for scrolling buttons
			if (sender is IScrollingButton)
			{
				switch (((IScrollingButton)sender).Name)
				{
					case "Normal" :
					{
						syntaxEdit.Pages.PageType  = PageType.Normal;
						break;
					}
					case "PageLayout" :
					{
						syntaxEdit.Pages.PageType  = PageType.PageLayout;
						break;
					}
					case "PageBreaks" :
					{
						syntaxEdit.Pages.PageType  = PageType.PageBreaks;
						break;
					}
					case "PageUp" :
					{
						syntaxEdit.MovePageUp();
						break;
					}
					case "PageDown" :
					{
						syntaxEdit.MovePageDown();
						break;
					}
				}
			}
		}

		private void chbSystemScrollBars_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating scrolling options
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit.Scrolling.Options = (chbSystemScrollBars.Checked ? syntaxEdit.Scrolling.Options
				| ScrollingOptions.SystemScrollbars : syntaxEdit.Scrolling.Options ^ ScrollingOptions.SystemScrollbars);
			syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options;
			UpdateScrollBoxes(chbSystemScrollBars);
		}

		private void chbFlatScrollBars_CheckedChanged(object sender, System.EventArgs e)
		{
			// updating scrolling options
			if (scrollBoxUpdate > 0)
				return;
			syntaxEdit.Scrolling.Options = (chbFlatScrollBars.Checked ? syntaxEdit.Scrolling.Options
				| ScrollingOptions.FlatScrollbars : syntaxEdit.Scrolling.Options ^ ScrollingOptions.FlatScrollbars);
			syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options;
			UpdateScrollBoxes(chbFlatScrollBars);
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			UpdatePanels(e.Node);
		}

		private void chbQuickInfoTips_CheckedChanged(object sender, System.EventArgs e)
		{
			csParser1.Options = (chbQuickInfoTips.Checked ? csParser1.Options
				| SyntaxOptions.QuickInfoTips : csParser1.Options ^ SyntaxOptions.QuickInfoTips);
		}

		private void chbDrawColumnsIndent_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit.DrawColumnsIndent = chbDrawColumnsIndent.Checked;
			syntaxSplitEdit.DrawColumnsIndent = chbDrawColumnsIndent.Checked;
		}

		private void chbColumnsVisible_CheckedChanged(object sender, System.EventArgs e)
		{
			syntaxEdit.EditMargin.ColumnsVisible = chbColumnsVisible.Checked;
			syntaxSplitEdit.EditMargin.ColumnsVisible = chbColumnsVisible.Checked;
		}
	
		internal class CustomElementSite : ISite, IServiceProvider
		{
			#region Fields
			private IComponent fComponent;
			private DefaultComponentContainer fContainer;
			private string name;
			#endregion

			#region Methods
			internal CustomElementSite(IComponent component, DefaultComponentContainer container, string name)
			{
				fComponent = component;
				fContainer = container;
				this.name = name;
			}
			public object GetService(Type service)
			{
				if (service == typeof(ITypeDescriptorFilterService))
					return fComponent as ITypeDescriptorFilterService;
				if (service != typeof(ISite))
					return fContainer.GetService(service);
				return this;
			}
			#endregion

			#region Methods
			public IComponent Component
			{
				get
				{
					return fComponent;
				}
			}
			public IContainer Container
			{
				get
				{
					return fContainer;
				}
			}
			public bool DesignMode
			{
				get
				{
					return false;
				}
			}
			public string Name
			{
				get
				{
					return name;
				}
				set
				{
					name = value;
				}
			}
			#endregion
		}
		internal class DefaultComponentContainer : Container, IContainer
		{
			#region Consts
			#endregion

			#region Fields
			#endregion

			#region Methods
			protected override ISite CreateSite(IComponent component, string name)
			{
				return new CustomElementSite(component, this, name);
			}
			new public object GetService(Type service)
			{
				return base.GetService(service);
			}
			#endregion

			#region Properties
			#endregion
		}
		internal class ComponentTypeDescriptorEx : ComponentTypeDescriptor
		{
			private ArrayList obsolete = null;
			public ComponentTypeDescriptorEx(Component owner)
				: base(owner)
			{
			}
			public ComponentTypeDescriptorEx(Component owner, ArrayList obsolete)
				: base(owner)
			{
				this.obsolete = obsolete;
			}

			protected override PropertyDescriptorCollection TypeDescriptorGetProperties(Attribute[] attributes)
			{
				PropertyDescriptorCollection result = base.TypeDescriptorGetProperties(attributes);
				ArrayList props = new ArrayList();

				props.AddRange(result);
				RemoveObsoleteProperties(ref props);
				PropertyDescriptor[] propArray = (PropertyDescriptor[])props.ToArray(
					typeof(PropertyDescriptor));
				return new PropertyDescriptorCollection(propArray);
			}
			private void RemoveObsoleteProperties(ref ArrayList properties)
			{
				for (int i = properties.Count - 1; i >= 0; i--)
				{
					if (obsolete.Contains(((PropertyDescriptor)properties[i]).Name))
						properties.Remove(properties[i]);
				}
			}
		}
		internal class ComponentTypeDescriptor : Component, ICustomTypeDescriptor
		{
			public Component owner;
			public ComponentTypeDescriptor(Component owner)
			{
				this.owner = owner;
			}
			#region Methods
			AttributeCollection ICustomTypeDescriptor.GetAttributes()
			{
				return TypeDescriptor.GetAttributes(owner, true);
			}
			string ICustomTypeDescriptor.GetClassName()
			{
				return TypeDescriptor.GetClassName(owner, true);
			}
			string ICustomTypeDescriptor.GetComponentName()
			{
				return TypeDescriptor.GetComponentName(owner, true);
			}
			TypeConverter ICustomTypeDescriptor.GetConverter()
			{
				return TypeDescriptor.GetConverter(owner, true);
			}
			EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
			{
				return TypeDescriptor.GetDefaultEvent(owner, true);
			}
			object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
			{
				return TypeDescriptor.GetEditor(owner, editorBaseType, true);
			}
			EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
			{
				return TypeDescriptor.GetEvents(owner, true);
			}
			protected virtual PropertyDescriptorCollection TypeDescriptorGetProperties(Attribute[] attributes)
			{
				return TypeDescriptor.GetProperties(owner, attributes, true);
			}
			PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
			{
				return TypeDescriptorGetProperties(attributes);
			}
			PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
			{
				return TypeDescriptor.GetDefaultProperty(owner, true);
			}
			EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
			{
				return TypeDescriptor.GetEvents(owner, attributes, true);
			}
			PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
			{
				return ((ICustomTypeDescriptor)owner).GetProperties(new Attribute[0]);
			}
			object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
			{
				return owner;
			}
			#endregion
		}
	}
}