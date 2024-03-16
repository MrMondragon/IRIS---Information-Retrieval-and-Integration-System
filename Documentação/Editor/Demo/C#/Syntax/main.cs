#region Copyright (c) 2004 - 2007 Quantum Whale LLC.
/*
	Quantum Whale .NET Component Library
	Editor.NET Syntax Demo

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
using System.IO;
using System.Text;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.Resources;
using QWhale.Editor;
using QWhale.Editor.Dialogs;
using QWhale.Syntax;
using QWhale.Syntax.Parsers;

namespace SyntaxEditor
{
	public class frmMain : System.Windows.Forms.Form
	{
		private struct LanguageInfo
		{
			public string FileType;
			public string FileExt;
			public string Description;
			public string SchemeName;
			public string FileName;
			public LanguageInfo(string AFileType, string AFileExt, string ADescription)
			{
				FileType = AFileType;
				FileExt = AFileExt;
				Description = ADescription;
				FileName = string.Empty;
				SchemeName = string.Empty;
			}
		}
		private LanguageInfo[] LangItems =
		{
			new LanguageInfo("c#", "*.cs", "C# Language"),
			new LanguageInfo("vb_net", "*.vb", "Visual Basic NET Language"),
			new LanguageInfo("java", "*.java", "Java Language"),
			new LanguageInfo("vbs_script", "*.vbs", "VB Script Language"),
			new LanguageInfo("java_script", "*.js", "Java Script Language"),
			new LanguageInfo("assembler", "*.asm", "Assembler Language"),
			new LanguageInfo("dfm_files", "*.dfm; *.xfm", "DFM File Language"),
			new LanguageInfo("c++builder", "*.hpp; *.cpp", "C++ Builder Language"),
			new LanguageInfo("c", "*.h;*.c", "C Language"),
			new LanguageInfo("delphi", "*.pas;*.bpg;*.dpr;*.dpk", "Delphi Language"),
			new LanguageInfo("html", "*.htm;*.html", "HTML Language"),
			new LanguageInfo("html_with_scripts", "*.htm;*.html", "ASP, VB, PHP, Java Scripts in HTML Language"),
			new LanguageInfo("perl", "*.pl", "Perl Language"),
			new LanguageInfo("php", "*.php", "PHP Language"),
			new LanguageInfo("python", "*.py", "Python Language"),
			new LanguageInfo("sql_oracle", "*.sql", "SQL Language"),
			new LanguageInfo("tcltk", "*.tcl", "TclTk Language"),
			new LanguageInfo("unix_shell", "*.sh;.csh", "Unix Shell Language"),
			new LanguageInfo("vbs_script_html", "*.htm;*.html", "VB Script in HTML Language"),
			new LanguageInfo("xml", "*.xml", "XML Language"),
			new LanguageInfo("xml_with_scripts", "*.xml", "PHP, VB, Java Scripts in XML Language"),
			new LanguageInfo("text", "*.txt", "Text files"),
			new LanguageInfo("batch", "*.bat", "Ms-Dos Batch Language"),
			new LanguageInfo("il", "*.il", "MSIL Language"),
			new LanguageInfo("ini", "*.ini", "Ini files"),
			new LanguageInfo("all", "*.*", "All files")
		};

		private const string sDefaultFontName = "Courier New";
		private const string sBlank = "Blank File";
		private const string sOpenExplorer = "{0} Code Explorer";

		private Explorer explorer;


		private System.Windows.Forms.MenuItem miFile;
		private System.Windows.Forms.MenuItem miNew;
		private System.Windows.Forms.MenuItem miOpen;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miSaveAs;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem miEdit;
		private System.Windows.Forms.MenuItem miUndo;
		private System.Windows.Forms.MenuItem miRedo;
		private System.Windows.Forms.MenuItem miCut;
		private System.Windows.Forms.MenuItem miCopy;
		private System.Windows.Forms.MenuItem miPaste;
		private System.Windows.Forms.MenuItem miSelectAll;
		private System.Windows.Forms.MenuItem miSearch;
		private System.Windows.Forms.MenuItem miFind;
		private System.Windows.Forms.MenuItem miReplace;
		private System.Windows.Forms.MenuItem miGoto;
		private System.Windows.Forms.MenuItem miTools;
		private System.Windows.Forms.MenuItem miOptions;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbOpen;
		private System.Windows.Forms.ToolBarButton tbbSave;
		private System.Windows.Forms.ToolBarButton tbbCut;
		private System.Windows.Forms.ToolBarButton tbbCopy;
		private System.Windows.Forms.ToolBarButton tbbPaste;
		private System.Windows.Forms.ToolBarButton tbbUndo;
		private System.Windows.Forms.ToolBarButton tbbRedo;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton tbbFind;
		private System.Windows.Forms.ToolBarButton tbbReplace;
		private System.Windows.Forms.ToolBarButton tbbGoto;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.MenuItem miSamples;
		private System.Windows.Forms.MenuItem miPrint;
		private System.Windows.Forms.MenuItem miPrintPreview;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem miPageSetup;
		private System.Windows.Forms.MenuItem miHelp;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.ToolBarButton tbbPrintPreview;
		private System.Windows.Forms.ToolBarButton tbbPrint;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ContextMenu cmMain;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem cmiCut;
		private System.Windows.Forms.MenuItem cmiCopy;
		private System.Windows.Forms.MenuItem cmiPaste;
		private System.Windows.Forms.MenuItem cmiOpen;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem cmiFind;
		private System.Windows.Forms.MenuItem cmiGoto;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem cmiOptions;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem cmiSplit;
		private System.Windows.Forms.ImageList imMenu;
		private System.Windows.Forms.MenuItem miCodeExplorer;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.GroupBox grExplorer;
		private System.Windows.Forms.TreeView tvSyntax;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ContextMenu mnuFiles;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.MenuItem cmiReplace;
		private System.Windows.Forms.ToolBar tlbStandard;
		private System.Windows.Forms.StatusBarPanel sbpPosition;
		private System.Windows.Forms.StatusBarPanel sbpModified;
		private System.Windows.Forms.StatusBarPanel sbpOverwrite;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem cmiAbout;
		private SyntaxSettings globalSettings;
		private SyntaxNodes references;
		private CompanyInfo companyInfo;
		private System.Windows.Forms.MenuItem cmiFindReferences;
		private System.Windows.Forms.MenuItem cmiGotoDeclaration;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.TabControl tcEditors;
		private System.Windows.Forms.ContextMenu cmEditors;
		private System.Windows.Forms.MenuItem cmiRemovePage;
		private string dir = Application.StartupPath + @"\";

		public frmMain()
		{
			InitializeComponent();
			explorer = new Explorer();
		}
	
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
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.miFile = new System.Windows.Forms.MenuItem();
			this.miNew = new System.Windows.Forms.MenuItem();
			this.miOpen = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.miSaveAs = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.miPrintPreview = new System.Windows.Forms.MenuItem();
			this.miPrint = new System.Windows.Forms.MenuItem();
			this.miPageSetup = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.miCodeExplorer = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.miEdit = new System.Windows.Forms.MenuItem();
			this.miUndo = new System.Windows.Forms.MenuItem();
			this.miRedo = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.miCut = new System.Windows.Forms.MenuItem();
			this.miCopy = new System.Windows.Forms.MenuItem();
			this.miPaste = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.miSelectAll = new System.Windows.Forms.MenuItem();
			this.miSearch = new System.Windows.Forms.MenuItem();
			this.miFind = new System.Windows.Forms.MenuItem();
			this.miReplace = new System.Windows.Forms.MenuItem();
			this.miGoto = new System.Windows.Forms.MenuItem();
			this.miTools = new System.Windows.Forms.MenuItem();
			this.miOptions = new System.Windows.Forms.MenuItem();
			this.miSamples = new System.Windows.Forms.MenuItem();
			this.miHelp = new System.Windows.Forms.MenuItem();
			this.miAbout = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tlbStandard = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.mnuFiles = new System.Windows.Forms.ContextMenu();
			this.tbbOpen = new System.Windows.Forms.ToolBarButton();
			this.tbbSave = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbCut = new System.Windows.Forms.ToolBarButton();
			this.tbbCopy = new System.Windows.Forms.ToolBarButton();
			this.tbbPaste = new System.Windows.Forms.ToolBarButton();
			this.tbbUndo = new System.Windows.Forms.ToolBarButton();
			this.tbbRedo = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbbFind = new System.Windows.Forms.ToolBarButton();
			this.tbbReplace = new System.Windows.Forms.ToolBarButton();
			this.tbbGoto = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.tbbPrintPreview = new System.Windows.Forms.ToolBarButton();
			this.tbbPrint = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.imMenu = new System.Windows.Forms.ImageList(this.components);
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.cmMain = new System.Windows.Forms.ContextMenu();
			this.cmiCut = new System.Windows.Forms.MenuItem();
			this.cmiCopy = new System.Windows.Forms.MenuItem();
			this.cmiPaste = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.cmiOpen = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.cmiFind = new System.Windows.Forms.MenuItem();
			this.cmiReplace = new System.Windows.Forms.MenuItem();
			this.cmiGoto = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.cmiGotoDeclaration = new System.Windows.Forms.MenuItem();
			this.cmiFindReferences = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.cmiOptions = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.cmiSplit = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.cmiAbout = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.sbpPosition = new System.Windows.Forms.StatusBarPanel();
			this.sbpModified = new System.Windows.Forms.StatusBarPanel();
			this.sbpOverwrite = new System.Windows.Forms.StatusBarPanel();
			this.grExplorer = new System.Windows.Forms.GroupBox();
			this.tvSyntax = new System.Windows.Forms.TreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tcEditors = new System.Windows.Forms.TabControl();
			this.cmEditors = new System.Windows.Forms.ContextMenu();
			this.cmiRemovePage = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.sbpPosition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpModified)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpOverwrite)).BeginInit();
			this.grExplorer.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miFile,
																					 this.miEdit,
																					 this.miSearch,
																					 this.miTools,
																					 this.miSamples,
																					 this.miHelp});
			// 
			// miFile
			// 
			this.miFile.Index = 0;
			this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miNew,
																				   this.miOpen,
																				   this.menuItem1,
																				   this.miSave,
																				   this.miSaveAs,
																				   this.menuItem2,
																				   this.miPrintPreview,
																				   this.miPrint,
																				   this.miPageSetup,
																				   this.menuItem3,
																				   this.miCodeExplorer,
																				   this.miExit});
			this.miFile.Text = "&File";
			// 
			// miNew
			// 
			this.miNew.Index = 0;
			this.miNew.Text = "&New";
			// 
			// miOpen
			// 
			this.miOpen.Index = 1;
			this.miOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.miOpen.Text = "&Open...";
			this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 2;
			this.menuItem1.Text = "-";
			// 
			// miSave
			// 
			this.miSave.Index = 3;
			this.miSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.miSave.Text = "&Save";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// miSaveAs
			// 
			this.miSaveAs.Index = 4;
			this.miSaveAs.Text = "Save &As...";
			this.miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "-";
			// 
			// miPrintPreview
			// 
			this.miPrintPreview.Index = 6;
			this.miPrintPreview.Text = "Print Preview...";
			this.miPrintPreview.Click += new System.EventHandler(this.miPrintPreview_Click);
			// 
			// miPrint
			// 
			this.miPrint.Index = 7;
			this.miPrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.miPrint.Text = "Print...";
			this.miPrint.Click += new System.EventHandler(this.miPrint_Click);
			// 
			// miPageSetup
			// 
			this.miPageSetup.Index = 8;
			this.miPageSetup.Text = "Page Setup...";
			this.miPageSetup.Click += new System.EventHandler(this.miPageSetup_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 9;
			this.menuItem3.Text = "-";
			// 
			// miCodeExplorer
			// 
			this.miCodeExplorer.Index = 10;
			this.miCodeExplorer.Text = "Close Code Explorer";
			this.miCodeExplorer.Click += new System.EventHandler(this.miCodeExplorer_Click);
			// 
			// miExit
			// 
			this.miExit.Index = 11;
			this.miExit.Text = "E&xit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// miEdit
			// 
			this.miEdit.Index = 1;
			this.miEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miUndo,
																				   this.miRedo,
																				   this.menuItem4,
																				   this.miCut,
																				   this.miCopy,
																				   this.miPaste,
																				   this.menuItem8,
																				   this.miSelectAll});
			this.miEdit.Text = "&Edit";
			// 
			// miUndo
			// 
			this.miUndo.Index = 0;
			this.miUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
			this.miUndo.Text = "Undo";
			this.miUndo.Click += new System.EventHandler(this.miUndo_Click);
			// 
			// miRedo
			// 
			this.miRedo.Index = 1;
			this.miRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
			this.miRedo.Text = "Redo";
			this.miRedo.Click += new System.EventHandler(this.miRedo_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// miCut
			// 
			this.miCut.Index = 3;
			this.miCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.miCut.Text = "Cut";
			this.miCut.Click += new System.EventHandler(this.miCut_Click);
			// 
			// miCopy
			// 
			this.miCopy.Index = 4;
			this.miCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.miCopy.Text = "Copy";
			this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
			// 
			// miPaste
			// 
			this.miPaste.Index = 5;
			this.miPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.miPaste.Text = "Paste";
			this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 6;
			this.menuItem8.Text = "-";
			// 
			// miSelectAll
			// 
			this.miSelectAll.Index = 7;
			this.miSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.miSelectAll.Text = "Select All";
			this.miSelectAll.Click += new System.EventHandler(this.miSelectAll_Click);
			// 
			// miSearch
			// 
			this.miSearch.Index = 2;
			this.miSearch.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miFind,
																					 this.miReplace,
																					 this.miGoto});
			this.miSearch.Text = "&Search";
			// 
			// miFind
			// 
			this.miFind.Index = 0;
			this.miFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.miFind.Text = "Find...";
			this.miFind.Click += new System.EventHandler(this.miFind_Click);
			// 
			// miReplace
			// 
			this.miReplace.Index = 1;
			this.miReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			this.miReplace.Text = "Replace...";
			this.miReplace.Click += new System.EventHandler(this.miReplace_Click);
			// 
			// miGoto
			// 
			this.miGoto.Index = 2;
			this.miGoto.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.miGoto.Text = "Go to Line Number...";
			this.miGoto.Click += new System.EventHandler(this.miGoto_Click);
			// 
			// miTools
			// 
			this.miTools.Index = 3;
			this.miTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miOptions});
			this.miTools.Text = "&Tools";
			// 
			// miOptions
			// 
			this.miOptions.Index = 0;
			this.miOptions.Text = "Options...";
			this.miOptions.Click += new System.EventHandler(this.miOptions_Click);
			// 
			// miSamples
			// 
			this.miSamples.Index = 4;
			this.miSamples.Text = "Samples";
			// 
			// miHelp
			// 
			this.miHelp.Index = 5;
			this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miAbout});
			this.miHelp.Text = "&Help";
			// 
			// miAbout
			// 
			this.miAbout.Index = 0;
			this.miAbout.Text = "About";
			this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.FileName = "doc1";
			// 
			// tlbStandard
			// 
			this.tlbStandard.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tlbStandard.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						   this.tbbNew,
																						   this.tbbOpen,
																						   this.tbbSave,
																						   this.toolBarButton1,
																						   this.tbbCut,
																						   this.tbbCopy,
																						   this.tbbPaste,
																						   this.tbbUndo,
																						   this.tbbRedo,
																						   this.toolBarButton2,
																						   this.tbbFind,
																						   this.tbbReplace,
																						   this.tbbGoto,
																						   this.toolBarButton3,
																						   this.tbbPrintPreview,
																						   this.tbbPrint,
																						   this.toolBarButton6});
			this.tlbStandard.DropDownArrows = true;
			this.tlbStandard.ImageList = this.imMenu;
			this.tlbStandard.Location = new System.Drawing.Point(0, 0);
			this.tlbStandard.Name = "tlbStandard";
			this.tlbStandard.ShowToolTips = true;
			this.tlbStandard.Size = new System.Drawing.Size(792, 28);
			this.tlbStandard.TabIndex = 1;
			this.tlbStandard.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbStandard_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.DropDownMenu = this.mnuFiles;
			this.tbbNew.ImageIndex = 0;
			this.tbbNew.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbbNew.Tag = "";
			this.tbbNew.ToolTipText = "New";
			// 
			// tbbOpen
			// 
			this.tbbOpen.ImageIndex = 1;
			this.tbbOpen.ToolTipText = "Open";
			// 
			// tbbSave
			// 
			this.tbbSave.ImageIndex = 2;
			this.tbbSave.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbbSave.ToolTipText = "Save";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbCut
			// 
			this.tbbCut.ImageIndex = 3;
			this.tbbCut.ToolTipText = "Cut";
			// 
			// tbbCopy
			// 
			this.tbbCopy.ImageIndex = 4;
			this.tbbCopy.ToolTipText = "Copy";
			// 
			// tbbPaste
			// 
			this.tbbPaste.ImageIndex = 5;
			this.tbbPaste.ToolTipText = "Paste";
			// 
			// tbbUndo
			// 
			this.tbbUndo.ImageIndex = 6;
			this.tbbUndo.ToolTipText = "Undo";
			// 
			// tbbRedo
			// 
			this.tbbRedo.ImageIndex = 7;
			this.tbbRedo.ToolTipText = "Redo";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbFind
			// 
			this.tbbFind.ImageIndex = 8;
			this.tbbFind.ToolTipText = "Find";
			// 
			// tbbReplace
			// 
			this.tbbReplace.ImageIndex = 9;
			this.tbbReplace.ToolTipText = "Replace";
			// 
			// tbbGoto
			// 
			this.tbbGoto.ImageIndex = 10;
			this.tbbGoto.ToolTipText = "Goto";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbPrintPreview
			// 
			this.tbbPrintPreview.ImageIndex = 11;
			// 
			// tbbPrint
			// 
			this.tbbPrint.ImageIndex = 12;
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// imMenu
			// 
			this.imMenu.ImageSize = new System.Drawing.Size(16, 16);
			this.imMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imMenu.ImageStream")));
			this.imMenu.TransparentColor = System.Drawing.Color.Red;
			// 
			// cmMain
			// 
			this.cmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.cmiCut,
																				   this.cmiCopy,
																				   this.cmiPaste,
																				   this.menuItem9,
																				   this.cmiOpen,
																				   this.menuItem11,
																				   this.cmiFind,
																				   this.cmiReplace,
																				   this.cmiGoto,
																				   this.menuItem6,
																				   this.cmiGotoDeclaration,
																				   this.cmiFindReferences,
																				   this.menuItem15,
																				   this.cmiOptions,
																				   this.menuItem17,
																				   this.cmiSplit,
																				   this.menuItem5,
																				   this.cmiAbout});
			this.cmMain.Popup += new System.EventHandler(this.cmMain_Popup);
			// 
			// cmiCut
			// 
			this.cmiCut.Index = 0;
			this.cmiCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.cmiCut.Text = "Cut";
			this.cmiCut.Click += new System.EventHandler(this.miCut_Click);
			// 
			// cmiCopy
			// 
			this.cmiCopy.Index = 1;
			this.cmiCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.cmiCopy.Text = "Copy";
			this.cmiCopy.Click += new System.EventHandler(this.miCopy_Click);
			// 
			// cmiPaste
			// 
			this.cmiPaste.Index = 2;
			this.cmiPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.cmiPaste.Text = "Paste";
			this.cmiPaste.Click += new System.EventHandler(this.miPaste_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 3;
			this.menuItem9.Text = "-";
			// 
			// cmiOpen
			// 
			this.cmiOpen.Index = 4;
			this.cmiOpen.Text = "Open";
			this.cmiOpen.Click += new System.EventHandler(this.miOpen_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 5;
			this.menuItem11.Text = "-";
			// 
			// cmiFind
			// 
			this.cmiFind.Index = 6;
			this.cmiFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.cmiFind.Text = "Find";
			this.cmiFind.Click += new System.EventHandler(this.miFind_Click);
			// 
			// cmiReplace
			// 
			this.cmiReplace.Index = 7;
			this.cmiReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			this.cmiReplace.Text = "Replace";
			this.cmiReplace.Click += new System.EventHandler(this.miReplace_Click);
			// 
			// cmiGoto
			// 
			this.cmiGoto.Index = 8;
			this.cmiGoto.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.cmiGoto.Text = "Go to Line Number";
			this.cmiGoto.Click += new System.EventHandler(this.miGoto_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 9;
			this.menuItem6.Text = "-";
			// 
			// cmiGotoDeclaration
			// 
			this.cmiGotoDeclaration.Index = 10;
			this.cmiGotoDeclaration.Text = "Find Declaration";
			this.cmiGotoDeclaration.Click += new System.EventHandler(this.cmiGotoDeclaration_Click);
			// 
			// cmiFindReferences
			// 
			this.cmiFindReferences.Index = 11;
			this.cmiFindReferences.Text = "Find References";
			this.cmiFindReferences.Click += new System.EventHandler(this.cmiFindReferences_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 12;
			this.menuItem15.Text = "-";
			// 
			// cmiOptions
			// 
			this.cmiOptions.Index = 13;
			this.cmiOptions.Text = "Options";
			this.cmiOptions.Click += new System.EventHandler(this.miOptions_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 14;
			this.menuItem17.Text = "-";
			// 
			// cmiSplit
			// 
			this.cmiSplit.Index = 15;
			this.cmiSplit.Text = "Split";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 16;
			this.menuItem5.Text = "-";
			// 
			// cmiAbout
			// 
			this.cmiAbout.Index = 17;
			this.cmiAbout.Text = "About";
			this.cmiAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 483);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.sbpPosition,
																						  this.sbpModified,
																						  this.sbpOverwrite});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(792, 22);
			this.statusBar1.TabIndex = 12;
			// 
			// sbpOverwrite
			// 
			this.sbpOverwrite.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbpOverwrite.Width = 576;
			// 
			// grExplorer
			// 
			this.grExplorer.Controls.Add(this.tvSyntax);
			this.grExplorer.Dock = System.Windows.Forms.DockStyle.Left;
			this.grExplorer.Location = new System.Drawing.Point(0, 28);
			this.grExplorer.Name = "grExplorer";
			this.grExplorer.Size = new System.Drawing.Size(208, 455);
			this.grExplorer.TabIndex = 13;
			this.grExplorer.TabStop = false;
			this.grExplorer.Text = "Explorer";
			// 
			// tvSyntax
			// 
			this.tvSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvSyntax.ImageList = this.imageList;
			this.tvSyntax.Location = new System.Drawing.Point(3, 16);
			this.tvSyntax.Name = "tvSyntax";
			this.tvSyntax.Size = new System.Drawing.Size(202, 436);
			this.tvSyntax.TabIndex = 2;
			this.tvSyntax.DoubleClick += new System.EventHandler(this.tvSyntax_DoubleClick);
			// 
			// imageList
			// 
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(208, 28);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 455);
			this.splitter1.TabIndex = 14;
			this.splitter1.TabStop = false;
			// 
			// tcEditors
			// 
			this.tcEditors.ContextMenu = this.cmEditors;
			this.tcEditors.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcEditors.Location = new System.Drawing.Point(212, 28);
			this.tcEditors.Name = "tcEditors";
			this.tcEditors.SelectedIndex = 0;
			this.tcEditors.Size = new System.Drawing.Size(580, 455);
			this.tcEditors.TabIndex = 16;
			this.tcEditors.SelectedIndexChanged += new System.EventHandler(this.tcEditors_SelectedIndexChanged);
			// 
			// cmEditors
			// 
			this.cmEditors.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.cmiRemovePage});
			this.cmEditors.Popup += new System.EventHandler(this.cmEditors_Popup);
			// 
			// cmiRemovePage
			// 
			this.cmiRemovePage.Index = 0;
			this.cmiRemovePage.Text = "Remove Page";
			this.cmiRemovePage.Click += new System.EventHandler(this.cmiRemovePage_Click);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 505);
			this.Controls.Add(this.tcEditors);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.grExplorer);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.tlbStandard);
			this.Menu = this.mainMenu;
			this.Name = "frmMain";
			this.Text = "Syntax Editor";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmSyntaxEditor_Load);
			this.Closed += new System.EventHandler(this.frmMain_Closed);
			((System.ComponentModel.ISupportInitialize)(this.sbpPosition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpModified)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpOverwrite)).EndInit();
			this.grExplorer.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}
		private Hashtable editors = new Hashtable();

		private void frmSyntaxEditor_Load(object sender, System.EventArgs e)
		{
			// creating internal list for hodling references
			references = new SyntaxNodes();
			// creating global settings and assigning default values.
			globalSettings = new SyntaxSettings();
			globalSettings.LoadFromEdit(new SyntaxEdit());
			globalSettings.AllowOutlining = true;
			globalSettings.OutlineOptions &= ~OutlineOptions.DrawOnGutter;
			globalSettings.GutterOptions |= GutterOptions.PaintLineModificators | GutterOptions.PaintLineNumbers;
			// assigning explorer tree
			explorer.ExplorerTree = tvSyntax;

			// locating schemes
			if (!(new DirectoryInfo(dir + "Schemes").Exists))
				dir = dir + @"..\";

			if (!(new DirectoryInfo(dir + "Schemes").Exists))
				dir = dir + @"..\";

			if (!(new DirectoryInfo(dir + "Schemes").Exists))
				dir = dir + @"..\..\";

			if (!(new DirectoryInfo(dir + "Schemes").Exists))
				dir = Application.StartupPath + @"\..\Demo\Editor\C#\Syntax\";
			
			if (!(new DirectoryInfo(dir + "Schemes").Exists))
				dir = Application.StartupPath + @"\";

			// loading global settings
			FileInfo fInfo = new FileInfo(Application.StartupPath + @"\GlobalSettings.xml");
			if (fInfo.Exists)
				globalSettings.LoadFile(fInfo.FullName);
			
			// loading schemes
			DirectoryInfo info = new DirectoryInfo(dir + "Schemes");
			FileInfo[] files;
			if (info.Exists)
			{
				files = info.GetFiles();
				for(int i = 0; i < files.Length; i++)
				{
					int idx = FindLangByName(RemoveFileExt(files[i].Name));
					if (idx >= 0)
						LangItems[idx].SchemeName = files[i].FullName;
				}
			}
			// loading example files
			info = new DirectoryInfo(dir + "Text");
			if (info.Exists)
			{
				files = info.GetFiles();
				for(int i = 0; i < files.Length; i++)
				{
					int idx = FindLangByName(RemoveFileExt(files[i].Name));
					if (idx >= 0)
						LangItems[idx].FileName = files[i].FullName;
				}
			}

			// populating sample menu
			foreach(LanguageInfo linfo in LangItems)
			{
				if ((linfo.FileName != string.Empty) && (linfo.SchemeName != string.Empty))
				{
					mnuFiles.MenuItems.Add(linfo.Description, new EventHandler(NewClick));
					miNew.MenuItems.Add(linfo.Description, new EventHandler(NewClick));
					miSamples.MenuItems.Add(linfo.Description, new EventHandler(SampleClick));
				}
			}
			
			miNew.MenuItems.Add(sBlank, new EventHandler(NewClick));
			string filter = string.Empty;
			for(int i = 0; i < LangItems.Length; i++)
				filter += string.Format("{0} files ({1})|{1}" + ((i == LangItems.Length - 1) ? string.Empty : "|"), LangItems[i].FileType, LangItems[i].FileExt);
			
			openFileDialog.Filter = filter;
			saveFileDialog.Filter = filter;
			
			// assigning tags for toolbar buttons
			UpdateToolBar();
			miSamples.Visible = miSamples.MenuItems.Count > 0;
			// opening sample file
			NewSampleFile("C# Language");
		
		}
		private string RemoveFileExt(string fileName)
		{
			int P = fileName.LastIndexOf(".");
			return (P >= 0) ? fileName.Substring(0, P) : fileName;
		}
		private string ExtractFileName(string fileName)
		{
			if (fileName != string.Empty)
			{
				FileInfo info = new FileInfo(fileName);
				return info.Name;
			}
			else
				return string.Empty;
		}
		private string ExtractFileExt(string fileName)
		{
			if (fileName != string.Empty)
			{
				FileInfo info = new FileInfo(fileName);
				return info.Extension;
			}
			else
				return string.Empty;
		}
		private int FindLangByName(string name)
		{
			for(int i = 0; i < LangItems.Length; i++)
				if (string.Compare(LangItems[i].FileType, name, true) == 0)
					return i;
			return - 1;
		}
		private int FindLangByDesc(string desc)
		{
			for(int i = 0; i < LangItems.Length; i++)
				if (string.Compare(LangItems[i].Description, desc, true) == 0)
					return i;
			return - 1;
		}
		private int FindLangByExt(string ext)
		{
			for(int i = 0; i < LangItems.Length; i++)
				if (LangItems[i].FileExt.Substring(1).ToLower() == ext.ToLower())
					return i;
			return - 1;
		}

		private ILexer GetLexer(int index, out bool isSpecialScheme)
		{
			isSpecialScheme = true;
			LanguageInfo info = (index >= 0) && (index < LangItems.Length) ? LangItems[index] : new LanguageInfo("", "", "");
			ILexer result = null;
			switch (info.FileType)
			{
				case "c#":
					result = new CsParser();					
					break;
				case "java":
					result = new JsParser();
					break;
				case "vb_net" :
					result = new VbParser();
					break;
				case "xml" :
					result = new XmlParser();
					break;
				case "html" :
					result = new HtmlParser();
					break;
				case "java_script" :
					result = new JavaScriptParser();
					break;
				case "vbs_script" :
					result = new VbScriptParser();
					break;
				default :
					isSpecialScheme = false;
					result = new Parser();
					break;
			}
			if (result is ISyntaxParser)
				((ISyntaxParser)result).Options |= SyntaxOptions.CodeCompletion;
			return result;
		}
		private void DoCustomDraw(object sender, CustomDrawEventArgs e)
		{
			// drawing known identifiers with different color
			LexToken tok = (LexToken)(e.DrawInfo.Style - 1);			
			if ((tok == LexToken.Identifier) && (e.DrawStage == DrawStage.Before) && ((DrawState.Selection & e.DrawState) == 0))
			{
				if (explorer.items.ContainsKey(e.DrawInfo.Text))
					e.Painter.TextColor = Color.Teal;
			}
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
		private void InitEditor(SyntaxEdit edit, ILexer lexer)
		{
			edit.ContextMenu = cmMain;
			edit.Source.Lexer = lexer;
			edit.CodeCompletionBox.Images = imageList;
			edit.CustomDraw += new CustomDrawEvent(DoCustomDraw);
			edit.SourceStateChanged += new NotifyEvent(SourceStateChanged);
			edit.Selection.SelectionChanged += new EventHandler(SelectionChanged);
			UpdateEdit(edit);
		}
		private void NewFile(string fileName, int index)
		{
			// creating new editor window and assigning lexer if possible.
			if (index == - 1)
				index = FindLangByExt(ExtractFileExt(fileName));		
			bool isSpecialScheme;
			ILexer lexer = GetLexer(index, out isSpecialScheme);
			TextSource source = new TextSource();
			if (lexer is ISyntaxParser)
				((ISyntaxParser)lexer).TextReparsed += new EventHandler(DoReparse);
			if ((!isSpecialScheme) && (index > -1))
				if (LangItems[index].SchemeName != string.Empty)
					lexer.LoadScheme(LangItems[index].SchemeName);

			TabPage page = new TabPage(ExtractFileName(fileName));
			tcEditors.TabPages.Add(page);
			tcEditors.SelectedTab = page;

			SyntaxEdit edit = new SyntaxEdit();

			editors.Add(page, edit);

			edit.Source = source;
			edit.Dock = DockStyle.Fill;
			edit.SetBounds(0, 0, page.ClientRectangle.Width, page.ClientRectangle.Height);
			
			page.Controls.Add(edit);
			
			InitEditor(edit, lexer);
			FileInfo fInfo = new FileInfo(fileName);
			if (fInfo.Exists)
			{
				edit.LoadFile(fileName);
				edit.Source.FileName = fileName;
			}
			UpdateCodeExplorer();
		}
		private void NewEmptyFile(string fileName, int index)
		{
			// creating new blank file
			NewFile(fileName, index);
			UpdateControls();
		}
		private void NewSampleFile(string lang)
		{
			// creating new sample file
			int idx = FindLangByDesc(lang);
			if ((idx >= 0) && (LangItems[idx].FileName != string.Empty))
				OpenFile(LangItems[idx].FileName, idx);
		}

		private void OpenFile(string fileName, int index)
		{
			// loading file from disk
			NewFile(fileName, index);
			UpdateControls();
		}
		private void OpenFile(string FileName)
		{
			OpenFile(FileName, - 1);
		}
		private void NewClick(object sender, System.EventArgs e)
		{
			// new file
			int idx = FindLangByDesc((sender as MenuItem).Text);
			NewEmptyFile((idx >=0) ? LangItems[idx].Description : "Noname" + (tcEditors.TabPages.Count + 1).ToString(), idx);
		}
		private void SampleClick(object sender, System.EventArgs e)
		{
			// new sample file
			NewSampleFile((sender as MenuItem).Text);
		}
		private void miOpen_Click(object sender, System.EventArgs e)
		{
			// loading file
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				OpenFile(openFileDialog.FileName);
		}

		private SyntaxEdit GetActiveSyntaxEdit()
		{
			// getting syntaxedit being focused
			return (tcEditors.SelectedTab) != null ? (SyntaxEdit)editors[tcEditors.SelectedTab] : null;
		}
		private void miSave_Click(object sender, System.EventArgs e)
		{
			// saving editor content to file on disk
			SyntaxEdit edit = GetActiveSyntaxEdit();
			if (edit != null)
				if (edit.Source.FileName != string.Empty)
					edit.Source.SaveFile(edit.Source.FileName);
				else
					miSaveAs_Click(sender, e);
		}

		private void miSaveAs_Click(object sender, System.EventArgs e)
		{
			// saving editor content to file on disk prompting for file name
			SyntaxEdit edit = GetActiveSyntaxEdit();
			if (edit != null)
			{
				saveFileDialog.FilterIndex = LangItems.Length;
				string oldExt = string.Empty;
				if ((edit.Source.FileName) != null)
				{
					saveFileDialog.FileName = edit.Source.FileName;
					oldExt = ExtractFileExt(edit.Source.FileName);
					int idx = FindLangByExt(oldExt);
					if (idx >= 0)
						saveFileDialog.FilterIndex = idx;
				}
				
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fName = saveFileDialog.FileName;
					edit.Source.SaveFile(fName);
					edit.Source.FileName = fName;
					UpdatePage(tcEditors.SelectedTab, fName);

					string ext =  ExtractFileExt(edit.Source.FileName);
					if (string.Compare(ext, oldExt, true) != 0)
					{
						int index = FindLangByExt(ext);
						if (index >= 0) 
						{
							Lexer lexer = new Lexer();
							if (LangItems[index].SchemeName != string.Empty)
								lexer.LoadScheme(LangItems[index].SchemeName);
							edit.Source.Lexer = lexer;
						}
					}
				}
			}
		}

		private void SelectionChanged(object sender, EventArgs e)
		{
			// updating status bar and toolbar buttons when changing selection in the editor
			UpdateControls();
		}
		private void SourceStateChanged(object sender, NotifyEventArgs e)
		{
			// updating status bar and toolbar buttons when source state is chagned.
			UpdateControls();
			// clearing list of references
			ClearReferences();
		}
		private void DoReparse(object sender, EventArgs e)
		{
			// text was fully parsed, updating explorer tree
			UpdateCodeExplorer();
		}
		private void OpenExplorer()
		{
			// opening explorer
			if (grExplorer.Visible)
				miCodeExplorer.Text = String.Format(sOpenExplorer, "Open");
			else
				miCodeExplorer.Text = String.Format(sOpenExplorer, "Close");
			grExplorer.Visible = !grExplorer.Visible;
		}
		private void miUndo_Click(object sender, System.EventArgs e)
		{
			// undoing the last change
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null && syntaxEdit.Source.CanUndo())
				syntaxEdit.Source.Undo();
		}
		private void miRedo_Click(object sender, System.EventArgs e)
		{
			// redoing the last change
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null && syntaxEdit.Source.CanRedo())
				syntaxEdit.Source.Redo();
		}
		private void RemovePage(object sender, EventArgs e)
		{
			// removing page from tab control when editor window is closed
			int index = tcEditors.SelectedIndex;
			tcEditors.TabPages.Remove(tcEditors.SelectedTab);
			tcEditors.SelectedIndex = Math.Max(index - 1, 0);
		}
		private void tcEditors_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateControls();
			UpdateCodeExplorer();
		}
	
		private void UpdatePage(TabPage page, string FileName)
		{
			// updating page control when editor is saved to another file
			page.Text = ExtractFileName(FileName);
			page.ToolTipText = FileName;
		}
		private void UpdateCodeExplorer()
		{
			// updating explorer tree
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if ((syntaxEdit != null) && (syntaxEdit.Lexer is ISyntaxParser) && !(syntaxEdit.Lexer is XmlParser))
				explorer.UpdateExplorer(((ISyntaxParser)(syntaxEdit.Lexer)).SyntaxTree);
			else
				explorer.UpdateExplorer(null);
			if (syntaxEdit != null)
				syntaxEdit.Invalidate();
		}
		private void MoveToContext()
		{
			// moves to the position in the editor where current explorer node is declared
			TreeNode node = tvSyntax.SelectedNode;
			if (node != null)
			{
				SyntaxEdit myEdit = GetActiveSyntaxEdit();
				Point p = new Point(- 1, - 1);
				Point endP = new Point(- 1, - 1);
				string name = string.Empty;
				if (node.Tag is ISyntaxNode)
				{
					p = ((ISyntaxNode)node.Tag).Position;
					myEdit.Position = p;
					myEdit.Focus();
				}
			}
		}
		void UpdateMenu()
		{
			// updating menu items
			SyntaxEdit edit = GetActiveSyntaxEdit();
			bool enabled = (edit != null);
			miSave.Enabled = enabled;
			miSaveAs.Enabled = enabled;
			miFind.Enabled = enabled;
			cmiFind.Enabled = enabled;
			miReplace.Enabled = enabled;
			cmiReplace.Enabled = enabled;
			miGoto.Enabled = enabled;
			cmiGoto.Enabled = enabled;
			cmiSplit.Enabled = enabled;
			miSelectAll.Enabled = enabled;
			miCut.Enabled = enabled && edit.Selection.CanCut();
			cmiCut.Enabled = enabled && edit.Selection.CanCut();
			miCopy.Enabled = enabled && edit.Selection.CanCopy();
			cmiCopy.Enabled = enabled && edit.Selection.CanCopy();
			miPaste.Enabled = enabled && edit.Selection.CanPaste();
			cmiPaste.Enabled = enabled && edit.Selection.CanPaste();
			miUndo.Enabled = enabled && edit.Source.CanUndo();
			miRedo.Enabled = enabled && edit.Source.CanRedo();
		}
		private void miOptions_Click(object sender, System.EventArgs e)
		{
			// executing editor settings dialog
			DlgSyntaxSettings options = new DlgSyntaxSettings();
			options.SyntaxSettings.Assign(globalSettings);
			if (options.ShowDialog() == DialogResult.OK)
			{
				globalSettings.Assign(options.SyntaxSettings);
				UpdateEdits();
			}
		}
		private void miFind_Click(object sender, System.EventArgs e)
		{
			// executing search dialog
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null)
				syntaxEdit.DisplaySearchDialog();
		}
		private void miReplace_Click(object sender, System.EventArgs e)
		{
			// executing replace dialog
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null)
				syntaxEdit.DisplayReplaceDialog();
		}
		private void miGoto_Click(object sender, System.EventArgs e)
		{
			// executing goto line dialog
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null)
				syntaxEdit.DisplayGotoLineDialog();
		}
		private void miCut_Click(object sender, System.EventArgs e)
		{
			// cutting selection to clipboard
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null && syntaxEdit.Selection.CanCut())
				syntaxEdit.Selection.Cut();
		}
		private void miCopy_Click(object sender, System.EventArgs e)
		{
			// copying selection to clipboard
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null && syntaxEdit.Selection.CanCopy())
				syntaxEdit.Selection.Copy();		
		}
		private void miPaste_Click(object sender, System.EventArgs e)
		{
			// pasting selection to clipboard
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null && syntaxEdit.Selection.CanPaste())
				syntaxEdit.Selection.Paste();
		}
		private void miSelectAll_Click(object sender, System.EventArgs e)
		{
			// selecting editor's content
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null)
				syntaxEdit.Selection.SelectAll();
		}
		private void miExit_Click(object sender, System.EventArgs e)
		{
			// closing the application
			this.Close();
		}
		private void miFont_Click(object sender, System.EventArgs e)
		{
			// assigning new font to the editor.
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if (syntaxEdit != null && fontDialog.ShowDialog() == DialogResult.OK)
				syntaxEdit.Font = fontDialog.Font;
		}
		private void tlbStandard_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Tag is MenuItem)
			{
				MenuItem mi = (MenuItem)e.Button.Tag;
				mi.PerformClick();
			}
			else
				if (e.Button == tbbNew)
				NewEmptyFile("Noname" + (tcEditors.TabPages.Count + 1).ToString(), - 1);
		}
		private void UpdateToolBar()
		{
			this.tbbOpen.Tag = miOpen;
			this.tbbSave.Tag = miSave;
			this.tbbCut.Tag = miCut;
			this.tbbCopy.Tag = miCopy;
			this.tbbPaste.Tag = miPaste;
			this.tbbUndo.Tag = miUndo;
			this.tbbRedo.Tag = miRedo;
			this.tbbFind.Tag = miFind;
			this.tbbReplace.Tag = miReplace;
			this.tbbGoto.Tag = miGoto;
			this.tbbPrintPreview.Tag = miPrintPreview;
			this.tbbPrint.Tag = miPrint;
		}
		private void UpdateControls()
		{
			// updating toolbar, status bar and menu
			UpdateMenu();
			UpdateToolBarButtons();
			UpdateStatusBar();
		}
		private void UpdateToolBarButtons()
		{
			// updating toolbar buttons
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			bool enabled = (syntaxEdit != null);
			tbbSave.Enabled = enabled;
			tbbCut.Enabled = enabled && syntaxEdit.Selection.CanCut();
			tbbCopy.Enabled = enabled && syntaxEdit.Selection.CanCopy();
			tbbPaste.Enabled = enabled && syntaxEdit.Selection.CanPaste();
			tbbUndo.Enabled = enabled && syntaxEdit.Source.CanUndo();
			tbbRedo.Enabled = enabled && syntaxEdit.Source.CanRedo();
			tbbFind.Enabled = enabled;
			tbbReplace.Enabled = enabled;
			tbbGoto.Enabled = enabled;
		}
		private int DefaultFontIndex 
		{
			get
			{
				FontFamily[] fonts = FontFamily.Families;
				for (int i = 0; i < fonts.Length; i++)
				{
					if (string.Compare(sDefaultFontName, fonts[i].Name) == 0)
						return i;
				}

				return - 1;
			}
		}
		private void UpdateEdits()
		{
			ArrayList list = new ArrayList(editors.Values);
			for(int i = 0; i < list.Count; i++)
				UpdateEdit((SyntaxEdit)list[i]);
		}
		private void UpdateEdit(SyntaxEdit edit)
		{
			// applying global settings to the editor
			globalSettings.ApplyToEdit(edit);
		}
		private void miPrintPreview_Click(object sender, System.EventArgs e)
		{
			// executing print preview dialog
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if(syntaxEdit != null)
				syntaxEdit.Printing.ExecutePrintPreviewDialog();
		}
		private void miPrint_Click(object sender, System.EventArgs e)
		{
			// printing the editor
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if(syntaxEdit != null)
				syntaxEdit.Printing.Print();
		}

		private void miPageSetup_Click(object sender, System.EventArgs e)
		{
			// executing page setup dialog
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if(syntaxEdit != null)
				syntaxEdit.Printing.ExecutePageSetupDialog();
		}
		private void miAbout_Click(object sender, System.EventArgs e)
		{
			// executing about box dialog
			if (companyInfo == null)
				companyInfo = new CompanyInfo();
			companyInfo.ShowDialog();
		}

		private void miCodeExplorer_Click(object sender, System.EventArgs e)
		{
			OpenExplorer();
		}

		private void tvSyntax_DoubleClick(object sender, System.EventArgs e)
		{
			MoveToContext();
		}
		public void UpdateStatusBar()
		{
			// updating status bar
			SyntaxEdit syntaxEdit = GetActiveSyntaxEdit();
			if(syntaxEdit != null)
			{
				sbpPosition.Text = string.Format("Line: {0}, Char: {1}", syntaxEdit.Source.Position.Y, syntaxEdit.Source.Position.X);
				if (syntaxEdit.Source.Readonly)
					sbpModified.Text = "Readonly";
				else
					if (syntaxEdit.Source.Modified)
						sbpModified.Text = "Modified";
				else
					sbpModified.Text = string.Empty;
				if (syntaxEdit.Source.OverWrite)
					sbpOverwrite.Text = "Overwrite";
				else
					sbpOverwrite.Text = string.Empty;
			}
		}		
		private void ClearReferences()
		{
			// clears all references
			SyntaxEdit edit = GetActiveSyntaxEdit();
			if (references != null && references.Count >= 0)
			{
				references.Clear();
				if (edit != null)
					edit.Invalidate();
			}
		}
		private void cmiGotoDeclaration_Click(object sender, System.EventArgs e)
		{
			// invalidating text region containing underlined text
			UpdateGotoDeclaration(true);
		}
		private bool UpdateGotoDeclaration(bool jump)
		{
			bool result = false;
			SyntaxEdit edit = GetActiveSyntaxEdit();
			if ((edit != null) && (edit.Lexer != null) && (edit.Lexer is ISyntaxParser))
			{
				ISyntaxNode node = ((ISyntaxParser)edit.Lexer).FindDeclaration(string.Empty, edit.Position) as ISyntaxNode;
				if (node != null)
				{
					result = true;
					if (jump)
					{
						edit.Position = node.Position;
						edit.Invalidate();
					}
				}
			}
			return result;
		}
		private void FindReferences()
		{
			// finds all references relative to the indentifier under caret position
			SyntaxEdit edit = GetActiveSyntaxEdit();
			if ((edit != null) && (edit.Lexer != null) && (edit.Lexer is ISyntaxParser))
			{
				ISyntaxNode node = ((ISyntaxParser)edit.Lexer).FindDeclaration(string.Empty, edit.Position)  as ISyntaxNode;
				if (node != null)
				{
					Point pt1 = node.Position;
					ISyntaxAttribute attr = node.FindAttribute(SyntaxConsts.DeclarationScope);
					Point pt2 = (attr != null) ? attr.Position : node.Range.EndPoint;
					edit.Selection.SetSelection(SelectionType.Stream, pt1, pt2);
					((ISyntaxParser)edit.Lexer).FindReferences(node, references);
					edit.Invalidate();
					edit = GetActiveSyntaxEdit();
					if (edit != null)
					{
						edit.Selection.SetSelection(SelectionType.Stream, pt1, pt2);
						edit.Invalidate();
					}
				}
				else
					ClearReferences();
			}
		}
		private void cmiFindReferences_Click(object sender, System.EventArgs e)
		{
			FindReferences();
		}

		private void cmMain_Popup(object sender, System.EventArgs e)
		{
			cmiGotoDeclaration.Enabled = UpdateGotoDeclaration(false);
			cmiFindReferences.Enabled = cmiGotoDeclaration.Enabled;
		}

		private void frmMain_Closed(object sender, System.EventArgs e)
		{
			// saving global settings
			globalSettings.SaveFile(Application.StartupPath + @"\GlobalSettings.xml");
		}

		private void cmEditors_Popup(object sender, System.EventArgs e)
		{
			cmiRemovePage.Enabled = (tcEditors.SelectedTab != null);
		}

		private void cmiRemovePage_Click(object sender, System.EventArgs e)
		{
			RemovePage();
		}
		private void RemovePage()
		{
			tcEditors.TabPages.Remove(tcEditors.SelectedTab);
			UpdateControls();
			UpdateCodeExplorer();
		}

		#region Explorer
		public class Explorer
		{
			private TreeView explorer;			
			protected internal Hashtable items;

			private const int cDotImage = 0;
			private const int cEnumFieldImage = 1;
			private const int cNameSpaceImage = 2;
			private const int cClassImage = 3;
			private const int cConstImage = 4;
			private const int cDelegateImage = 5;
			private const int cEnumImage = 6;
			private const int cEventImage = 7;
			private const int cFieldImage = 8;
			private const int cInterfaceImage = 9;
			private const int cMethodImage = 10;
			private const int cPropImage = 11;
			private const int cStructImage = 12;		

			private const int cImageDelta = 10;

			private string selectedNode = string.Empty;
			private string topNode = string.Empty;

			public Explorer()
			{
				items = new Hashtable();
			}
			private void BeforeRefresh(ArrayList list, TreeNodeCollection nodes)
			{
				foreach(TreeNode node in nodes)
					if (node.IsExpanded)
					{
						list.Add(node.FullPath);
						BeforeRefresh(list, node.Nodes);
					}
			}
			private void BeforeRefresh(ArrayList list)
			{
				topNode = (explorer.TopNode != null) ? explorer.TopNode.FullPath : string.Empty;
				selectedNode = (explorer.SelectedNode != null) ? explorer.SelectedNode.FullPath : string.Empty;

				list.Clear();					   
				BeforeRefresh(list, explorer.Nodes);
			}
			private void AfterRefresh(ArrayList list, TreeNodeCollection nodes, ref TreeNode selNode, ref TreeNode tNode)
			{
				foreach(TreeNode node in nodes)
				{
					string s = node.FullPath;
					if ((selNode == null) && (s == selectedNode))
						selNode = node;
					if ((tNode == null) && (s == topNode))
						tNode = node;

					if ((node.Nodes.Count > 0) && (list.IndexOf(s) >= 0))
						node.Expand();
					AfterRefresh(list, node.Nodes, ref selNode, ref tNode);
				}
			}
			private void AfterRefresh(ArrayList list)
			{
				TreeNode topNode= null;
				TreeNode selNode = null;
				AfterRefresh(list, explorer.Nodes, ref selNode, ref topNode);
				if (selNode != null)
					explorer.SelectedNode = selNode;
				if (topNode != null)
					topNode.EnsureVisible();
			}
			private int ScopeImageIndex(ISyntaxNode node, bool isScopedImage)
			{
				ISyntaxAttribute syntaxAttribute = node.FindAttribute(NetNodeType.Modifier.ToString());
				if (syntaxAttribute != null)
				{
					string s = syntaxAttribute.Value.ToString().ToLower();
					if (s == SyntaxConsts.PrivateModifier)
						return cImageDelta;
					else
						if (s == SyntaxConsts.ProtectedModifier) 
						return cImageDelta * 2;
					else
						if (s == SyntaxConsts.PublicModifier) 
						return cImageDelta * 3;
				}
				return isScopedImage ? cImageDelta : 0;
			}

			private bool IsIdentNode(NetNodeType nodeType)
			{
				switch(nodeType)
				{
					case NetNodeType.Class:
					case NetNodeType.Constructor:
					case NetNodeType.Delegate:
					case NetNodeType.Destructor:
					case NetNodeType.Enum:
					case NetNodeType.Event:
					case NetNodeType.Field:
					case NetNodeType.Indexer:
					case NetNodeType.Interface:
					case NetNodeType.Method:
					case NetNodeType.Namespace:
					case NetNodeType.Property:
					case NetNodeType.Struct:
						return true;
					default:
						return false;
				}
			}
			private bool IsValidNode(NetNodeType nodeType, out int index)
			{
				bool result = false;
				switch(nodeType)
				{
					case NetNodeType.Class:
						result = true;
						index = cClassImage;
						break;
					case NetNodeType.Constructor:
						result = true;
						index = cMethodImage;
						break;
					case NetNodeType.Delegate:
						result = true;
						index = cDelegateImage;
						break;
					case NetNodeType.Destructor:
						result = true;
						index = cMethodImage;
						break;
					case NetNodeType.Enum:
						result = true;
						index = cEnumImage;
						break;
					case NetNodeType.Event:
						result = true;
						index = cEventImage;
						break;
					case NetNodeType.Field:
						result = true;
						index = cFieldImage;
						break;
					case NetNodeType.Indexer:
						result = true;
						index = cPropImage;
						break;
					case NetNodeType.Interface:
						result = true;
						index = cInterfaceImage;
						break;
					case NetNodeType.Method:
						result = true;
						index = cMethodImage;
						break;
					case NetNodeType.Namespace:
						result = true;
						index = cNameSpaceImage;
						break;
					case NetNodeType.Property:
						result = true;
						index = cPropImage;
						break;
					case NetNodeType.Struct:
						result = true;
						index = cStructImage;
						break;
					case NetNodeType.Unit:
						result = true;
						index = cDotImage;
						break;
					case NetNodeType.Using:
						result = true;
						index = cNameSpaceImage;
						break;
					case NetNodeType.UsingList:
						result = true;
						index = cNameSpaceImage;
						break;
					default:
						result = false;
						index = -1;
						break;
				}
				return result;
			}
			private void BuildNode(TreeNodeCollection nodes, ISyntaxNode snode)
			{
				TreeNode node = null;
				int index = -1;
				if (IsValidNode((NetNodeType)snode.NodeType, out index))
				{
					node = nodes.Add(snode.Name);
					node.Text = ((NetNodeType)snode.NodeType).ToString() + " : " + snode.Name;
					index = index + ScopeImageIndex(snode, index > cNameSpaceImage);
					node.ImageIndex = index;
					node.SelectedImageIndex = index;
					node.Tag = snode;
					if ((snode.Name != string.Empty) && IsIdentNode((NetNodeType)snode.NodeType))
						items[snode.Name] = snode.Name;
				}
				if (snode.ChildList != null)
					foreach(ISyntaxNode n in snode.ChildList)
					{
						BuildNode((node != null) ? node.Nodes : nodes, n);
					}
			}			
			private void BuildSyntaxTree(ISyntaxTree tree, TreeView treeView)
			{
				items.Clear();
				ArrayList list = new ArrayList();
				treeView.BeginUpdate();
				BeforeRefresh(list);
				try
				{
					treeView.Nodes.Clear();
					if (tree != null)
						BuildNode(treeView.Nodes, tree.Root);
				}
				finally
				{
					AfterRefresh(list);
					treeView.EndUpdate();
				}
			}
			public void UpdateExplorer(ISyntaxTree syntaxTree)
			{
				if (explorer == null)
					return;
				BuildSyntaxTree(syntaxTree, explorer);
			}			
			public TreeView ExplorerTree
			{
				get
				{
					return explorer;
				}
				set
				{
					explorer = value;
				}
			}
		}
		#endregion Explorer
	}
}
