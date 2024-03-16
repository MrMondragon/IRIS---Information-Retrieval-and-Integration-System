#Region "Copyright (c) 2004 - 2007 Quantum Whale LLC."

'	Quantum Whale .NET Component Library
'	Editor.NET Syntax Demo
'
'	Copyright (c) 2004 - 2007 Quantum Whale LLC.
'	ALL RIGHTS RESERVED
'
'	http://www.qwhale.net
'	contact@qwhale.net

#End Region

Imports QWhale.Syntax
Imports QWhale.Syntax.Parsers
Imports QWhale.Editor
Imports QWhale.Editor.Dialogs

Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        Explorer = New CodeExplorer
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents mainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents miFile As System.Windows.Forms.MenuItem
    Friend WithEvents miNew As System.Windows.Forms.MenuItem
    Friend WithEvents miOpen As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents miSave As System.Windows.Forms.MenuItem
    Friend WithEvents miSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents miPrintPreview As System.Windows.Forms.MenuItem
    Friend WithEvents miPrint As System.Windows.Forms.MenuItem
    Friend WithEvents miPageSetup As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents miExit As System.Windows.Forms.MenuItem
    Friend WithEvents miEdit As System.Windows.Forms.MenuItem
    Friend WithEvents miUndo As System.Windows.Forms.MenuItem
    Friend WithEvents miRedo As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents miCut As System.Windows.Forms.MenuItem
    Friend WithEvents miCopy As System.Windows.Forms.MenuItem
    Friend WithEvents miPaste As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents miSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents miSearch As System.Windows.Forms.MenuItem
    Friend WithEvents miFind As System.Windows.Forms.MenuItem
    Friend WithEvents miReplace As System.Windows.Forms.MenuItem
    Friend WithEvents miGoto As System.Windows.Forms.MenuItem
    Friend WithEvents miTools As System.Windows.Forms.MenuItem
    Friend WithEvents miOptions As System.Windows.Forms.MenuItem
    Friend WithEvents miSamples As System.Windows.Forms.MenuItem
    Friend WithEvents miHelp As System.Windows.Forms.MenuItem
    Friend WithEvents miAbout As System.Windows.Forms.MenuItem
    Friend WithEvents cmMain As System.Windows.Forms.ContextMenu
    Friend WithEvents cmiCut As System.Windows.Forms.MenuItem
    Friend WithEvents cmiCopy As System.Windows.Forms.MenuItem
    Friend WithEvents cmiPaste As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents cmiOpen As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents cmiFind As System.Windows.Forms.MenuItem
    Friend WithEvents cmiReplace As System.Windows.Forms.MenuItem
    Friend WithEvents cmiGoto As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents cmiOptions As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents cmiSplit As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents cmiAbout As System.Windows.Forms.MenuItem
    Friend WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuFiles As System.Windows.Forms.ContextMenu
    Friend WithEvents imMenu As System.Windows.Forms.ImageList
    Friend WithEvents tlbStandard As System.Windows.Forms.ToolBar
    Friend WithEvents tbbNew As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbOpen As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents toolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCut As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCopy As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbPaste As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbUndo As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbRedo As System.Windows.Forms.ToolBarButton
    Friend WithEvents toolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbReplace As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbGoto As System.Windows.Forms.ToolBarButton
    Friend WithEvents toolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbPrintPreview As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbPrint As System.Windows.Forms.ToolBarButton
    Friend WithEvents toolBarButton6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents statusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents sbpPosition As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpModified As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpOverwrite As System.Windows.Forms.StatusBarPanel
    Friend WithEvents miCodeExplorer As System.Windows.Forms.MenuItem
    Friend WithEvents grExplorer As System.Windows.Forms.GroupBox
    Friend WithEvents tvSyntax As System.Windows.Forms.TreeView
    Friend WithEvents splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents fontDialog As System.Windows.Forms.FontDialog
    Friend WithEvents cmiGotoDeclaration As System.Windows.Forms.MenuItem
    Friend WithEvents cmiFindReferences As System.Windows.Forms.MenuItem
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents tcEditors As System.Windows.Forms.TabControl
    Friend WithEvents cmEditors As System.Windows.Forms.ContextMenu
    Friend WithEvents cmiRemovePage As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
        Me.mainMenu = New System.Windows.Forms.MainMenu
        Me.miFile = New System.Windows.Forms.MenuItem
        Me.miNew = New System.Windows.Forms.MenuItem
        Me.miOpen = New System.Windows.Forms.MenuItem
        Me.menuItem1 = New System.Windows.Forms.MenuItem
        Me.miSave = New System.Windows.Forms.MenuItem
        Me.miSaveAs = New System.Windows.Forms.MenuItem
        Me.menuItem2 = New System.Windows.Forms.MenuItem
        Me.miPrintPreview = New System.Windows.Forms.MenuItem
        Me.miPrint = New System.Windows.Forms.MenuItem
        Me.miPageSetup = New System.Windows.Forms.MenuItem
        Me.menuItem3 = New System.Windows.Forms.MenuItem
        Me.miCodeExplorer = New System.Windows.Forms.MenuItem
        Me.miExit = New System.Windows.Forms.MenuItem
        Me.miEdit = New System.Windows.Forms.MenuItem
        Me.miUndo = New System.Windows.Forms.MenuItem
        Me.miRedo = New System.Windows.Forms.MenuItem
        Me.menuItem4 = New System.Windows.Forms.MenuItem
        Me.miCut = New System.Windows.Forms.MenuItem
        Me.miCopy = New System.Windows.Forms.MenuItem
        Me.miPaste = New System.Windows.Forms.MenuItem
        Me.menuItem8 = New System.Windows.Forms.MenuItem
        Me.miSelectAll = New System.Windows.Forms.MenuItem
        Me.miSearch = New System.Windows.Forms.MenuItem
        Me.miFind = New System.Windows.Forms.MenuItem
        Me.miReplace = New System.Windows.Forms.MenuItem
        Me.miGoto = New System.Windows.Forms.MenuItem
        Me.miTools = New System.Windows.Forms.MenuItem
        Me.miOptions = New System.Windows.Forms.MenuItem
        Me.miSamples = New System.Windows.Forms.MenuItem
        Me.miHelp = New System.Windows.Forms.MenuItem
        Me.miAbout = New System.Windows.Forms.MenuItem
        Me.cmMain = New System.Windows.Forms.ContextMenu
        Me.cmiCut = New System.Windows.Forms.MenuItem
        Me.cmiCopy = New System.Windows.Forms.MenuItem
        Me.cmiPaste = New System.Windows.Forms.MenuItem
        Me.menuItem9 = New System.Windows.Forms.MenuItem
        Me.cmiOpen = New System.Windows.Forms.MenuItem
        Me.menuItem11 = New System.Windows.Forms.MenuItem
        Me.cmiFind = New System.Windows.Forms.MenuItem
        Me.cmiReplace = New System.Windows.Forms.MenuItem
        Me.cmiGoto = New System.Windows.Forms.MenuItem
        Me.menuItem15 = New System.Windows.Forms.MenuItem
        Me.cmiGotoDeclaration = New System.Windows.Forms.MenuItem
        Me.cmiFindReferences = New System.Windows.Forms.MenuItem
        Me.cmiOptions = New System.Windows.Forms.MenuItem
        Me.menuItem17 = New System.Windows.Forms.MenuItem
        Me.cmiSplit = New System.Windows.Forms.MenuItem
        Me.menuItem5 = New System.Windows.Forms.MenuItem
        Me.cmiAbout = New System.Windows.Forms.MenuItem
        Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.mnuFiles = New System.Windows.Forms.ContextMenu
        Me.imMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.tlbStandard = New System.Windows.Forms.ToolBar
        Me.tbbNew = New System.Windows.Forms.ToolBarButton
        Me.tbbOpen = New System.Windows.Forms.ToolBarButton
        Me.tbbSave = New System.Windows.Forms.ToolBarButton
        Me.toolBarButton1 = New System.Windows.Forms.ToolBarButton
        Me.tbbCut = New System.Windows.Forms.ToolBarButton
        Me.tbbCopy = New System.Windows.Forms.ToolBarButton
        Me.tbbPaste = New System.Windows.Forms.ToolBarButton
        Me.tbbUndo = New System.Windows.Forms.ToolBarButton
        Me.tbbRedo = New System.Windows.Forms.ToolBarButton
        Me.toolBarButton2 = New System.Windows.Forms.ToolBarButton
        Me.tbbFind = New System.Windows.Forms.ToolBarButton
        Me.tbbReplace = New System.Windows.Forms.ToolBarButton
        Me.tbbGoto = New System.Windows.Forms.ToolBarButton
        Me.toolBarButton3 = New System.Windows.Forms.ToolBarButton
        Me.tbbPrintPreview = New System.Windows.Forms.ToolBarButton
        Me.tbbPrint = New System.Windows.Forms.ToolBarButton
        Me.toolBarButton6 = New System.Windows.Forms.ToolBarButton
        Me.statusBar1 = New System.Windows.Forms.StatusBar
        Me.sbpPosition = New System.Windows.Forms.StatusBarPanel
        Me.sbpModified = New System.Windows.Forms.StatusBarPanel
        Me.sbpOverwrite = New System.Windows.Forms.StatusBarPanel
        Me.grExplorer = New System.Windows.Forms.GroupBox
        Me.tvSyntax = New System.Windows.Forms.TreeView
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.splitter1 = New System.Windows.Forms.Splitter
        Me.fontDialog = New System.Windows.Forms.FontDialog
        Me.tcEditors = New System.Windows.Forms.TabControl
        Me.cmEditors = New System.Windows.Forms.ContextMenu
        Me.cmiRemovePage = New System.Windows.Forms.MenuItem
        CType(Me.sbpPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpModified, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpOverwrite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grExplorer.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu
        '
        Me.mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFile, Me.miEdit, Me.miSearch, Me.miTools, Me.miSamples, Me.miHelp})
        '
        'miFile
        '
        Me.miFile.Index = 0
        Me.miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miNew, Me.miOpen, Me.menuItem1, Me.miSave, Me.miSaveAs, Me.menuItem2, Me.miPrintPreview, Me.miPrint, Me.miPageSetup, Me.menuItem3, Me.miCodeExplorer, Me.miExit})
        Me.miFile.Text = "&File"
        '
        'miNew
        '
        Me.miNew.Index = 0
        Me.miNew.Text = "&New"
        '
        'miOpen
        '
        Me.miOpen.Index = 1
        Me.miOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.miOpen.Text = "&Open..."
        '
        'menuItem1
        '
        Me.menuItem1.Index = 2
        Me.menuItem1.Text = "-"
        '
        'miSave
        '
        Me.miSave.Index = 3
        Me.miSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.miSave.Text = "&Save"
        '
        'miSaveAs
        '
        Me.miSaveAs.Index = 4
        Me.miSaveAs.Text = "Save &As..."
        '
        'menuItem2
        '
        Me.menuItem2.Index = 5
        Me.menuItem2.Text = "-"
        '
        'miPrintPreview
        '
        Me.miPrintPreview.Index = 6
        Me.miPrintPreview.Text = "Print Preview..."
        '
        'miPrint
        '
        Me.miPrint.Index = 7
        Me.miPrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.miPrint.Text = "Print..."
        '
        'miPageSetup
        '
        Me.miPageSetup.Index = 8
        Me.miPageSetup.Text = "Page Setup..."
        '
        'menuItem3
        '
        Me.menuItem3.Index = 9
        Me.menuItem3.Text = "-"
        '
        'miCodeExplorer
        '
        Me.miCodeExplorer.Index = 10
        Me.miCodeExplorer.Text = "Close Code Explorer"
        '
        'miExit
        '
        Me.miExit.Index = 11
        Me.miExit.Text = "E&xit"
        '
        'miEdit
        '
        Me.miEdit.Index = 1
        Me.miEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miUndo, Me.miRedo, Me.menuItem4, Me.miCut, Me.miCopy, Me.miPaste, Me.menuItem8, Me.miSelectAll})
        Me.miEdit.Text = "&Edit"
        '
        'miUndo
        '
        Me.miUndo.Index = 0
        Me.miUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
        Me.miUndo.Text = "Undo"
        '
        'miRedo
        '
        Me.miRedo.Index = 1
        Me.miRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY
        Me.miRedo.Text = "Redo"
        '
        'menuItem4
        '
        Me.menuItem4.Index = 2
        Me.menuItem4.Text = "-"
        '
        'miCut
        '
        Me.miCut.Index = 3
        Me.miCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.miCut.Text = "Cut"
        '
        'miCopy
        '
        Me.miCopy.Index = 4
        Me.miCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.miCopy.Text = "Copy"
        '
        'miPaste
        '
        Me.miPaste.Index = 5
        Me.miPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.miPaste.Text = "Paste"
        '
        'menuItem8
        '
        Me.menuItem8.Index = 6
        Me.menuItem8.Text = "-"
        '
        'miSelectAll
        '
        Me.miSelectAll.Index = 7
        Me.miSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.miSelectAll.Text = "Select All"
        '
        'miSearch
        '
        Me.miSearch.Index = 2
        Me.miSearch.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFind, Me.miReplace, Me.miGoto})
        Me.miSearch.Text = "&Search"
        '
        'miFind
        '
        Me.miFind.Index = 0
        Me.miFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.miFind.Text = "Find..."
        '
        'miReplace
        '
        Me.miReplace.Index = 1
        Me.miReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlH
        Me.miReplace.Text = "Replace..."
        '
        'miGoto
        '
        Me.miGoto.Index = 2
        Me.miGoto.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.miGoto.Text = "Go to Line Number..."
        '
        'miTools
        '
        Me.miTools.Index = 3
        Me.miTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miOptions})
        Me.miTools.Text = "&Tools"
        '
        'miOptions
        '
        Me.miOptions.Index = 0
        Me.miOptions.Text = "Options..."
        '
        'miSamples
        '
        Me.miSamples.Index = 4
        Me.miSamples.Text = "Samples"
        '
        'miHelp
        '
        Me.miHelp.Index = 5
        Me.miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miAbout})
        Me.miHelp.Text = "&Help"
        '
        'miAbout
        '
        Me.miAbout.Index = 0
        Me.miAbout.Text = "About"
        '
        'cmMain
        '
        Me.cmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmiCut, Me.cmiCopy, Me.cmiPaste, Me.menuItem9, Me.cmiOpen, Me.menuItem11, Me.cmiFind, Me.cmiReplace, Me.cmiGoto, Me.menuItem15, Me.cmiGotoDeclaration, Me.cmiFindReferences, Me.cmiOptions, Me.menuItem17, Me.cmiSplit, Me.menuItem5, Me.cmiAbout})
        '
        'cmiCut
        '
        Me.cmiCut.Index = 0
        Me.cmiCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.cmiCut.Text = "Cut"
        '
        'cmiCopy
        '
        Me.cmiCopy.Index = 1
        Me.cmiCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.cmiCopy.Text = "Copy"
        '
        'cmiPaste
        '
        Me.cmiPaste.Index = 2
        Me.cmiPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.cmiPaste.Text = "Paste"
        '
        'menuItem9
        '
        Me.menuItem9.Index = 3
        Me.menuItem9.Text = "-"
        '
        'cmiOpen
        '
        Me.cmiOpen.Index = 4
        Me.cmiOpen.Text = "Open"
        '
        'menuItem11
        '
        Me.menuItem11.Index = 5
        Me.menuItem11.Text = "-"
        '
        'cmiFind
        '
        Me.cmiFind.Index = 6
        Me.cmiFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.cmiFind.Text = "Find"
        '
        'cmiReplace
        '
        Me.cmiReplace.Index = 7
        Me.cmiReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlH
        Me.cmiReplace.Text = "Replace"
        '
        'cmiGoto
        '
        Me.cmiGoto.Index = 8
        Me.cmiGoto.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.cmiGoto.Text = "Go to Line Number"
        '
        'menuItem15
        '
        Me.menuItem15.Index = 9
        Me.menuItem15.Text = "-"
        '
        'cmiGotoDeclaration
        '
        Me.cmiGotoDeclaration.Index = 10
        Me.cmiGotoDeclaration.Text = "Find Declaration"
        '
        'cmiFindReferences
        '
        Me.cmiFindReferences.Index = 11
        Me.cmiFindReferences.Text = "Find References"
        '
        'cmiOptions
        '
        Me.cmiOptions.Index = 12
        Me.cmiOptions.Text = "Options"
        '
        'menuItem17
        '
        Me.menuItem17.Index = 13
        Me.menuItem17.Text = "-"
        '
        'cmiSplit
        '
        Me.cmiSplit.Index = 14
        Me.cmiSplit.Text = "Split"
        '
        'menuItem5
        '
        Me.menuItem5.Index = 15
        Me.menuItem5.Text = "-"
        '
        'cmiAbout
        '
        Me.cmiAbout.Index = 16
        Me.cmiAbout.Text = "About"
        '
        'saveFileDialog
        '
        Me.saveFileDialog.FileName = "doc1"
        '
        'imMenu
        '
        Me.imMenu.ImageSize = New System.Drawing.Size(16, 16)
        Me.imMenu.ImageStream = CType(resources.GetObject("imMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imMenu.TransparentColor = System.Drawing.Color.Red
        '
        'tlbStandard
        '
        Me.tlbStandard.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbStandard.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbNew, Me.tbbOpen, Me.tbbSave, Me.toolBarButton1, Me.tbbCut, Me.tbbCopy, Me.tbbPaste, Me.tbbUndo, Me.tbbRedo, Me.toolBarButton2, Me.tbbFind, Me.tbbReplace, Me.tbbGoto, Me.toolBarButton3, Me.tbbPrintPreview, Me.tbbPrint, Me.toolBarButton6})
        Me.tlbStandard.DropDownArrows = True
        Me.tlbStandard.ImageList = Me.imMenu
        Me.tlbStandard.Location = New System.Drawing.Point(0, 0)
        Me.tlbStandard.Name = "tlbStandard"
        Me.tlbStandard.ShowToolTips = True
        Me.tlbStandard.Size = New System.Drawing.Size(792, 28)
        Me.tlbStandard.TabIndex = 7
        '
        'tbbNew
        '
        Me.tbbNew.DropDownMenu = Me.mnuFiles
        Me.tbbNew.ImageIndex = 0
        Me.tbbNew.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.tbbNew.Tag = ""
        Me.tbbNew.ToolTipText = "New"
        '
        'tbbOpen
        '
        Me.tbbOpen.ImageIndex = 1
        Me.tbbOpen.ToolTipText = "Open"
        '
        'tbbSave
        '
        Me.tbbSave.ImageIndex = 2
        Me.tbbSave.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbbSave.ToolTipText = "Save"
        '
        'toolBarButton1
        '
        Me.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCut
        '
        Me.tbbCut.ImageIndex = 3
        Me.tbbCut.ToolTipText = "Cut"
        '
        'tbbCopy
        '
        Me.tbbCopy.ImageIndex = 4
        Me.tbbCopy.ToolTipText = "Copy"
        '
        'tbbPaste
        '
        Me.tbbPaste.ImageIndex = 5
        Me.tbbPaste.ToolTipText = "Paste"
        '
        'tbbUndo
        '
        Me.tbbUndo.ImageIndex = 6
        Me.tbbUndo.ToolTipText = "Undo"
        '
        'tbbRedo
        '
        Me.tbbRedo.ImageIndex = 7
        Me.tbbRedo.ToolTipText = "Redo"
        '
        'toolBarButton2
        '
        Me.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbFind
        '
        Me.tbbFind.ImageIndex = 8
        Me.tbbFind.ToolTipText = "Find"
        '
        'tbbReplace
        '
        Me.tbbReplace.ImageIndex = 9
        Me.tbbReplace.ToolTipText = "Replace"
        '
        'tbbGoto
        '
        Me.tbbGoto.ImageIndex = 10
        Me.tbbGoto.ToolTipText = "Goto"
        '
        'toolBarButton3
        '
        Me.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbPrintPreview
        '
        Me.tbbPrintPreview.ImageIndex = 11
        '
        'tbbPrint
        '
        Me.tbbPrint.ImageIndex = 12
        '
        'toolBarButton6
        '
        Me.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'statusBar1
        '
        Me.statusBar1.Location = New System.Drawing.Point(0, 504)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpPosition, Me.sbpModified, Me.sbpOverwrite})
        Me.statusBar1.ShowPanels = True
        Me.statusBar1.Size = New System.Drawing.Size(792, 22)
        Me.statusBar1.TabIndex = 13
        '
        'sbpOverwrite
        '
        Me.sbpOverwrite.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpOverwrite.Width = 576
        '
        'grExplorer
        '
        Me.grExplorer.Controls.Add(Me.tvSyntax)
        Me.grExplorer.Dock = System.Windows.Forms.DockStyle.Left
        Me.grExplorer.Location = New System.Drawing.Point(0, 28)
        Me.grExplorer.Name = "grExplorer"
        Me.grExplorer.Size = New System.Drawing.Size(208, 476)
        Me.grExplorer.TabIndex = 15
        Me.grExplorer.TabStop = False
        Me.grExplorer.Text = "Explorer"
        '
        'tvSyntax
        '
        Me.tvSyntax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvSyntax.ImageList = Me.ImageList
        Me.tvSyntax.Location = New System.Drawing.Point(3, 16)
        Me.tvSyntax.Name = "tvSyntax"
        Me.tvSyntax.Size = New System.Drawing.Size(202, 457)
        Me.tvSyntax.TabIndex = 2
        '
        'ImageList
        '
        Me.ImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'splitter1
        '
        Me.splitter1.Location = New System.Drawing.Point(208, 28)
        Me.splitter1.Name = "splitter1"
        Me.splitter1.Size = New System.Drawing.Size(4, 476)
        Me.splitter1.TabIndex = 16
        Me.splitter1.TabStop = False
        '
        'tcEditors
        '
        Me.tcEditors.ContextMenu = Me.cmEditors
        Me.tcEditors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcEditors.Location = New System.Drawing.Point(212, 28)
        Me.tcEditors.Name = "tcEditors"
        Me.tcEditors.SelectedIndex = 0
        Me.tcEditors.Size = New System.Drawing.Size(580, 476)
        Me.tcEditors.TabIndex = 18
        '
        'cmEditors
        '
        Me.cmEditors.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmiRemovePage})
        '
        'cmiRemovePage
        '
        Me.cmiRemovePage.Index = 0
        Me.cmiRemovePage.Text = "Remove Page"
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.tcEditors)
        Me.Controls.Add(Me.splitter1)
        Me.Controls.Add(Me.grExplorer)
        Me.Controls.Add(Me.statusBar1)
        Me.Controls.Add(Me.tlbStandard)
        Me.IsMdiContainer = True
        Me.Menu = Me.mainMenu
        Me.Name = "MainForm"
        Me.Text = "Syntax Editor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.sbpPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpModified, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpOverwrite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grExplorer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Structure LanguageInfo
        Public FileType As String
        Public FileExt As String
        Public Description As String
        Public SchemeName As String
        Public FileName As String
        Public Sub New(ByVal AFileType As String, ByVal AFileExt As String, ByVal ADescription As String)
            FileType = AFileType
            FileExt = AFileExt
            Description = ADescription
            FileName = String.Empty
            SchemeName = String.Empty
        End Sub
    End Structure

    Private LangItems() As LanguageInfo = New LanguageInfo() {New LanguageInfo("c#", "*.cs", "C# Language"), New LanguageInfo("vb_net", "*.vb", "Visual Basic NET Language"), New LanguageInfo("java", "*.java", "Java Language"), New LanguageInfo("vbs_script", "*.vbs", "VB Script Language"), New LanguageInfo("java_script", "*.js", "Java Script Language"), New LanguageInfo("assembler", "*.asm", "Assembler Language"), New LanguageInfo("dfm_files", "*.dfm; *.xfm", "DFM File Language"), New LanguageInfo("c++builder", "*.hpp; *.cpp", "C++ Builder Language"), New LanguageInfo("c", "*.h;*.c", "C Language"), New LanguageInfo("delphi", "*.pas;*.bpg;*.dpr;*.dpk", "Delphi Language"), New LanguageInfo("html", "*.htm;*.html", "HTML Language"), New LanguageInfo("html_with_scripts", "*.htm;*.html", "ASP, VB, PHP, Java Scripts in HTML Language"), New LanguageInfo("perl", "*.pl", "Perl Language"), New LanguageInfo("php", "*.php", "PHP Language"), New LanguageInfo("python", "*.py", "Python Language"), New LanguageInfo("sql_oracle", "*.sql", "SQL Language"), New LanguageInfo("tcltk", "*.tcl", "TclTk Language"), New LanguageInfo("unix_shell", "*.sh;.csh", "Unix Shell Language"), New LanguageInfo("vbs_script_html", "*.htm;*.html", "VB Script in HTML Language"), New LanguageInfo("xml", "*.xml", "XML Language"), New LanguageInfo("xml_with_scripts", "*.xml", "PHP, VB, Java Scripts in XML Language"), New LanguageInfo("text", "*.txt", "Text files"), New LanguageInfo("batch", "*.bat", "Ms-Dos Batch Language"), New LanguageInfo("il", "*.il", "MSIL Language"), New LanguageInfo("ini", "*.ini", "Ini files"), New LanguageInfo("all", "*.*", "All files")}
    Private Const sDefaultFontName As String = "Courier New"
    Private Const sBlank As String = "Blank File"
    Private Const sOpenExplorer As String = "{0} Code Explorer"
    Private Dir As String = Application.StartupPath + "\"
    Private companyInfo As companyInfo
    Private GlobalSettings As SyntaxSettings
    Private references As SyntaxNodes
    Private Explorer As CodeExplorer

    Private editors As Hashtable = New Hashtable

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' creating internal list for hodling references
        references = New SyntaxNodes
        ' creating global settings and assigning default values.
        GlobalSettings = New SyntaxSettings
        GlobalSettings.LoadFromEdit(New SyntaxEdit)
        GlobalSettings.AllowOutlining = True
        GlobalSettings.OutlineOptions = GlobalSettings.OutlineOptions And Not OutlineOptions.DrawOnGutter
        GlobalSettings.GutterOptions = GlobalSettings.GutterOptions Or GutterOptions.PaintLineModificators Or GutterOptions.PaintLineNumbers

        ' assigning explorer tree
        Explorer.ExplorerTree = tvSyntax

        ' locating schemes
        If Not (New System.IO.DirectoryInfo(Dir + "Schemes").Exists) Then
            Dir = Dir + "..\"
        End If

        If Not (New System.IO.DirectoryInfo(Dir + "Schemes").Exists) Then
            Dir = Dir + "..\"
        End If

        If Not (New System.IO.DirectoryInfo(Dir + "Schemes").Exists) Then
            Dir = Dir + "..\..\"
        End If


        If Not (New System.IO.DirectoryInfo(Dir + "Schemes").Exists) Then
            Dir = Application.StartupPath + "\..\Demo\Editor\VBasic\Syntax\"
        End If

        If Not (New System.IO.DirectoryInfo(Dir + "Schemes").Exists) Then
            Dir = Application.StartupPath + "\"
        End If

        ' loading global settings
        Dim fInfo As System.IO.FileInfo = New System.IO.FileInfo(Application.StartupPath + "\GlobalSettings.xml")
        If fInfo.Exists Then
            GlobalSettings.LoadFile(Application.StartupPath + "\GlobalSettings.xml")
        End If
        ' loading schemes
        Dim info As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Dir + "Schemes")
        Dim Files() As System.IO.FileInfo = New System.IO.FileInfo() {}
        Dim idx As Integer = 0
        If info.Exists Then
            Files = info.GetFiles()
            For i As Integer = 0 To Files.Length - 1
                idx = FindLangByName(RemoveFileExt(Files(i).Name))
                If idx >= 0 Then
                    LangItems(idx).SchemeName = Files(i).FullName
                End If
            Next i
        End If
        ' loading example files
        info = New System.IO.DirectoryInfo(Dir + "Text")
        If info.Exists Then
            Files = info.GetFiles()
            For i As Integer = 0 To Files.Length - 1
                idx = FindLangByName(RemoveFileExt(Files(i).Name))
                If idx >= 0 Then
                    LangItems(idx).FileName = Files(i).FullName
                End If
            Next i
        End If
        ' populating sample menu
        Dim linfo As LanguageInfo
        For Each linfo In LangItems
            If (linfo.FileName <> String.Empty) And (linfo.SchemeName <> String.Empty) Then
                mnuFiles.MenuItems.Add(linfo.Description, New EventHandler(AddressOf NewClick))
                miNew.MenuItems.Add(linfo.Description, New EventHandler(AddressOf NewClick))
                miSamples.MenuItems.Add(linfo.Description, New EventHandler(AddressOf SampleClick))
            End If
        Next linfo

        miNew.MenuItems.Add(sBlank, New EventHandler(AddressOf NewClick))
        Dim filter As String = String.Empty
        For i As Integer = 0 To LangItems.Length - 1
            If i = LangItems.Length - 1 Then
                filter += String.Format("{0} files ({1})|{1}", LangItems(i).FileType, LangItems(i).FileExt)
            Else
                filter += String.Format("{0} files ({1})|{1}|", LangItems(i).FileType, LangItems(i).FileExt)
            End If
        Next i

        openFileDialog.Filter = filter
        saveFileDialog.Filter = filter

        ' assigning tags for toolbar buttons
        UpdateToolBar()
        miSamples.Visible = miSamples.MenuItems.Count > 0
        ' opening sample file
        NewSampleFile("C# Language")

        AddHandler cmiAbout.Click, AddressOf miAbout_Click
        AddHandler cmiCopy.Click, AddressOf miCopy_Click
        AddHandler cmiCut.Click, AddressOf miCut_Click
        AddHandler cmiFind.Click, AddressOf miFind_Click
        AddHandler cmiGoto.Click, AddressOf miGoto_Click
        AddHandler cmiOpen.Click, AddressOf miOpen_Click
        AddHandler cmiOptions.Click, AddressOf miOptions_Click
        AddHandler cmiPaste.Click, AddressOf miPaste_Click
        AddHandler cmiReplace.Click, AddressOf miReplace_Click
    End Sub

    Private Function RemoveFileExt(ByVal FileName As String) As String
        Dim P As Integer = FileName.LastIndexOf(".")
        If P >= 0 Then
            Return FileName.Substring(0, P)
        Else
            Return FileName
        End If
    End Function

    Private Function ExtractFileName(ByVal FileName As String) As String
        If FileName <> String.Empty Then
            Dim info As System.IO.FileInfo = New System.IO.FileInfo(FileName)
            Return info.Name
        Else
            Return String.Empty
        End If
    End Function

    Private Function ExtractFileExt(ByVal FileName As String) As String
        If FileName <> String.Empty Then
            Dim info As System.IO.FileInfo = New System.IO.FileInfo(FileName)
            Return info.Extension
        Else
            Return String.Empty
        End If
    End Function

    Private Function FindLangByName(ByVal Name As String) As Integer
        For i As Integer = 0 To LangItems.Length - 1
            If String.Compare(LangItems(i).FileType, Name, True) = 0 Then
                Return i
            End If
        Next i
        Return -1
    End Function

    Private Function FindLangByDesc(ByVal Desc As String) As Integer
        For i As Integer = 0 To LangItems.Length - 1
            If String.Compare(LangItems(i).Description, Desc, True) = 0 Then
                Return i
            End If
        Next i
        Return -1
    End Function

    Private Function FindLangByExt(ByVal Ext As String) As Integer
        For i As Integer = 0 To LangItems.Length - 1
            If LangItems(i).FileExt.ToLower().IndexOf(Ext.ToLower()) >= 0 Then
                Return i
            End If
        Next i
        Return -1
    End Function

    Private Const cCSharpSchemeIndex As Integer = 0
    Private Const cJSharpSchemeIndex As Integer = 8
    Private Const cVbSchemeIndex As Integer = 17

    Private Function GetLexer(ByVal Index As Integer, ByRef IsSpecialScheme As Boolean) As ILexer
        IsSpecialScheme = True
        Dim result As ILexer = Nothing
        Dim info As LanguageInfo = New LanguageInfo("", "", "")
        If (Index >= 0) And (Index < LangItems.Length) Then
            info = LangItems(Index)
        End If
        Select Case (info.FileType)
            Case "c#"
                result = New CsParser
            Case "java"
                result = New JsParser
            Case "vb_net"
                result = New VbParser
            Case "xml"
                result = New XmlParser
            Case "html"
                result = New HtmlParser
            Case "java_script"
                result = New JavaScriptParser
            Case "vbs_script"
                result = New VbScriptParser
            Case Else
                IsSpecialScheme = False
                result = New Parser
        End Select
        If TypeOf result Is ISyntaxParser Then
            CType(result, ISyntaxParser).Options() = CType(result, ISyntaxParser).Options() Or SyntaxOptions.CodeCompletion
        End If
        Return result
    End Function

    Private Sub DoCustomDraw(ByVal sender As Object, ByVal e As CustomDrawEventArgs)
        ' drawing known identifiers with different color
        Dim tok As LexToken = CType(e.DrawInfo.Style - 1, LexToken)
        If ((tok = LexToken.Identifier) And (e.DrawStage = DrawStage.Before) And ((DrawState.Selection And e.DrawState) = 0)) Then
            If (Explorer.items.ContainsKey(e.DrawInfo.Text)) Then
                e.Painter.TextColor = Color.Teal
            End If
        End If
        ' drawing rectangle around the found references (references are filled when executing FindReference popup menu).
        If ((references.Count > 0) And (e.DrawStage = DrawStage.After) And (e.DrawState = DrawState.Control)) Then
            e.Painter.ForeColor = Color.Navy
            e.Painter.BackColor = Color.Navy
            For Each node As ISyntaxNode In references
                If (TypeOf sender Is EditSyntaxPaint) Then
                    Dim sPaint As EditSyntaxPaint = CType(sender, EditSyntaxPaint)
                    Dim r As Rectangle = New Rectangle(node.Position, New Size(node.Range.EndPoint.X - node.Position.X, node.Range.EndPoint.Y - node.Position.Y))
                    Dim pt1 As Point = sPaint.Owner.TextToScreen(r.Location)
                    Dim pt2 As Point = sPaint.Owner.TextToScreen(New Point(r.Right, r.Bottom))
                    pt2.Y += e.Painter.FontHeight
                    e.Painter.DrawRectangle(pt1.X, pt1.Y, pt2.X - pt1.X, pt2.Y - pt1.Y)
                End If
            Next node
        End If
    End Sub

    Private Sub DoReparse(ByVal sender As Object, ByVal e As EventArgs)
        ' text is fully parsed, updating explorer
        UpdateCodeExplorer()
    End Sub

    Private Sub InitEditor(ByVal edit As SyntaxEdit, ByVal lexer As ILexer)
        edit.ContextMenu = cmMain
        edit.Source.Lexer = lexer
        edit.CodeCompletionBox.Images = ImageList
        AddHandler edit.CustomDraw, AddressOf DoCustomDraw
        AddHandler edit.SourceStateChanged, AddressOf SourceStateChanged
        AddHandler edit.Selection.SelectionChanged, AddressOf SelectionChanged
        UpdateEdit(edit)
    End Sub

    Private Sub NewFile(ByVal fileName As String, ByVal index As Integer)
        ' creating new editor window and assigning lexer if possible.
        If (index = -1) Then
            index = FindLangByExt(ExtractFileExt(fileName))
        End If
        Dim isSpecialScheme As Boolean
        Dim lexer As ILexer = GetLexer(index, isSpecialScheme)
        Dim source As TextSource = New TextSource
        If TypeOf lexer Is ISyntaxParser Then
            AddHandler CType(lexer, ISyntaxParser).TextReparsed, AddressOf DoReparse
        End If
        If (Not isSpecialScheme) And (index > -1) Then
            If LangItems(index).SchemeName <> String.Empty Then
                lexer.LoadScheme(LangItems(index).SchemeName)
            End If
        End If

        Dim page As TabPage = New TabPage(ExtractFileName(fileName))
        tcEditors.TabPages.Add(page)
        tcEditors.SelectedTab = page

        Dim edit As SyntaxEdit = New SyntaxEdit

        editors.Add(page, edit)
        edit.SetBounds(0, 0, page.ClientRectangle.Width, page.ClientRectangle.Height)
        edit.Source = source
        edit.Dock = DockStyle.Fill


        page.Controls.Add(edit)

        InitEditor(edit, lexer)
        Dim fInfo As System.IO.FileInfo = New System.IO.FileInfo(fileName)
        If (fInfo.Exists) Then
            edit.LoadFile(fileName)
            edit.Source.FileName = fileName
        End If
        UpdateCodeExplorer()
    End Sub


    Private Sub NewEmptyFile(ByVal fileName As String, ByVal index As Integer)
        ' creating new blank file
        NewFile(fileName, index)
        UpdateControls()
    End Sub

    Private Sub NewSampleFile(ByVal lang As String)
        ' creating new sample file
        Dim idx As Integer = FindLangByDesc(lang)
        If (idx >= 0) And (LangItems(idx).FileName <> String.Empty) Then
            OpenFile(LangItems(idx).FileName, idx)
        End If
    End Sub

    Private Sub OpenFile(ByVal fileName As String, ByVal index As Integer)
        ' loading file from disk
        NewFile(fileName, index)
        UpdateControls()
    End Sub

    Private Sub OpenFile(ByVal FileName As String)
        OpenFile(FileName, -1)
    End Sub

    Private Sub NewClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ' new file
        Dim idx As Integer = FindLangByDesc(CType(sender, MenuItem).Text)
        If idx >= 0 Then
            NewEmptyFile(LangItems(idx).Description + (MdiChildren.Length + 1).ToString(), idx)
        Else
            NewEmptyFile("Noname" + (tcEditors.TabPages.Count + 1).ToString(), idx)
        End If
    End Sub

    Private Sub SampleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ' new sample file
        NewSampleFile(CType(sender, MenuItem).Text)
    End Sub

    Private Function GetActiveSyntaxEdit() As SyntaxEdit
        ' getting syntaxedit being focused
        If (tcEditors.SelectedIndex < 0) Or (tcEditors.TabCount = 0) Then
            Return Nothing
        End If
        Return CType(editors(tcEditors.SelectedTab), SyntaxEdit)
    End Function

    Private Sub SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' updating status bar and toolbar buttons when changing selection in the editor
        UpdateControls()
    End Sub

    Private Sub SourceStateChanged(ByVal sender As Object, ByVal e As NotifyEventArgs)
        ' updating status bar and toolbar buttons when source state is chagned.
        UpdateControls()
        ' clearing list of references
        ClearReferences()
    End Sub

    Private Sub RemovePage()
        ' removing page from tab control when editor window is closed
        Dim index As Integer = tcEditors.SelectedIndex
        tcEditors.TabPages.Remove(tcEditors.SelectedTab)
        tcEditors.SelectedIndex = Math.Max(index - 1, 0)
    End Sub

    Private Sub UpdatePage(ByVal page As TabPage, ByVal FileName As String)
        ' updating page control when editor is saved to another file
        page.Text = ExtractFileName(FileName)
        page.ToolTipText = FileName
    End Sub

    Private Sub UpdateMenu()
        ' updating menu items
        Dim edit As SyntaxEdit = GetActiveSyntaxEdit()
        Dim enabled As Boolean = Not edit Is Nothing
        miSave.Enabled = enabled
        miSaveAs.Enabled = enabled
        miFind.Enabled = enabled
        cmiFind.Enabled = enabled
        miReplace.Enabled = enabled
        cmiReplace.Enabled = enabled
        miGoto.Enabled = enabled
        cmiGoto.Enabled = enabled
        cmiSplit.Enabled = enabled
        miSelectAll.Enabled = enabled
        If enabled Then
            miCut.Enabled = edit.Selection.CanCut()
            cmiCut.Enabled = edit.Selection.CanCut()
            miCopy.Enabled = edit.Selection.CanCopy()
            cmiCopy.Enabled = edit.Selection.CanCopy()
            miPaste.Enabled = edit.Selection.CanPaste()
            cmiPaste.Enabled = edit.Selection.CanPaste()
            miUndo.Enabled = edit.Source.CanUndo()
            miRedo.Enabled = edit.Source.CanRedo()
        Else
            miCut.Enabled = False
            cmiCut.Enabled = False
            miCopy.Enabled = False
            cmiCopy.Enabled = False
            miPaste.Enabled = False
            cmiPaste.Enabled = False
            miUndo.Enabled = False
            miRedo.Enabled = False
        End If
    End Sub

    Private Sub UpdateToolBar()
        tbbOpen.Tag = miOpen
        tbbSave.Tag = miSave
        tbbCut.Tag = miCut
        tbbCopy.Tag = miCopy
        tbbPaste.Tag = miPaste
        tbbUndo.Tag = miUndo
        tbbRedo.Tag = miRedo
        tbbFind.Tag = miFind
        tbbReplace.Tag = miReplace
        tbbGoto.Tag = miGoto
        tbbPrintPreview.Tag = miPrintPreview
        tbbPrint.Tag = miPrint
    End Sub

    Private Sub UpdateControls()
        ' updating toolbar, status bar and menu
        UpdateMenu()
        UpdateToolBarButtons()
        UpdateStatusBar()
    End Sub

    Private Sub UpdateToolBarButtons()
        ' updating toolbar buttons
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        Dim enabled As Boolean = Not SyntaxEdit Is Nothing
        tbbSave.Enabled = enabled
        tbbReplace.Enabled = enabled
        tbbGoto.Enabled = enabled
        tbbFind.Enabled = enabled
        If enabled Then
            tbbCut.Enabled = SyntaxEdit.Selection.CanCut()
            tbbCopy.Enabled = SyntaxEdit.Selection.CanCopy()
            tbbPaste.Enabled = SyntaxEdit.Selection.CanPaste()
            tbbUndo.Enabled = SyntaxEdit.Source.CanUndo()
            tbbRedo.Enabled = SyntaxEdit.Source.CanRedo()
        Else
            tbbCut.Enabled = False
            tbbCopy.Enabled = False
            tbbPaste.Enabled = False
            tbbUndo.Enabled = False
            tbbRedo.Enabled = False
        End If
    End Sub

    Private ReadOnly Property DefaultFontIndex() As Integer
        Get
            Dim fonts() As FontFamily = FontFamily.Families
            For i As Integer = 0 To fonts.Length - 1
                If String.Compare(sDefaultFontName, fonts(i).Name) = 0 Then
                    Return i
                End If
            Next i
            Return -1
        End Get
    End Property


    Private Sub UpdateEdits()
        Dim list As ArrayList = New ArrayList(editors.Values)
        For i As Integer = 0 To list.Count - 1
            UpdateEdit(CType(list(i), SyntaxEdit))
        Next i
    End Sub

    Private Sub UpdateEdit(ByVal edit As SyntaxEdit)
        ' applying global settings to the editor
        GlobalSettings.ApplyToEdit(edit)
    End Sub

    Public Sub UpdateStatusBar()
        ' updating status bar
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not SyntaxEdit Is Nothing Then
            sbpPosition.Text = String.Format("Line: {0}, Char: {1}", SyntaxEdit.Source.Position.Y, SyntaxEdit.Source.Position.X)
            If SyntaxEdit.Source.Readonly Then
                sbpModified.Text = "ReadOnly"
            Else
                If SyntaxEdit.Source.Modified Then
                    sbpModified.Text = "Modified"
                Else
                    sbpModified.Text = String.Empty
                    If SyntaxEdit.Source.OverWrite Then
                        sbpOverwrite.Text = "Overwrite"
                    Else
                        sbpOverwrite.Text = String.Empty
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub miSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miSave.Click
        ' saving contet of editor to file
        Dim edit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not edit Is Nothing Then
            If edit.Source.FileName <> String.Empty Then
                edit.Source.SaveFile(edit.Source.FileName)
            Else
                miSaveAs_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miSaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miSaveAs.Click
        ' saving editor content to file on disk prompting for file name
        Dim edit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not edit Is Nothing Then
            saveFileDialog.FilterIndex = LangItems.Length
            Dim oldExt As String = String.Empty
            If Not edit.Source.FileName Is Nothing Then
                saveFileDialog.FileName = edit.Source.FileName
                oldExt = ExtractFileExt(edit.Source.FileName)
                Dim idx As Integer = FindLangByExt(oldExt)
                If idx >= 0 Then
                    saveFileDialog.FilterIndex = idx
                End If
            End If

            If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fName As String = saveFileDialog.FileName
                edit.Source.SaveFile(fName)
                edit.Source.FileName = fName
                UpdatePage(tcEditors.SelectedTab, fName)

                Dim ext As String = ExtractFileExt(edit.Source.FileName)
                If String.Compare(ext, oldExt, True) <> 0 Then
                    Dim Index As Integer = FindLangByExt(ext)
                    If Index >= 0 Then
                        Dim Lexer As Lexer = New Lexer
                        If LangItems(Index).SchemeName <> String.Empty Then
                            Lexer.LoadScheme(LangItems(Index).SchemeName)
                        End If
                        edit.Source.Lexer = Lexer
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub miCascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub miArrangeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub miTileHorz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub miTileVert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub miUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miUndo.Click
        ' undoing the last change
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not (SyntaxEdit Is Nothing) And SyntaxEdit.Source.CanUndo() Then
            SyntaxEdit.Source.Undo()
        End If
    End Sub

    Private Sub miRedo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miRedo.Click
        ' redoing the last change
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not (SyntaxEdit Is Nothing) And SyntaxEdit.Source.CanRedo() Then
            SyntaxEdit.Source.Redo()
        End If
    End Sub


    Private Sub miReplace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miReplace.Click
        ' executing replace dialog
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not SyntaxEdit Is Nothing Then
            SyntaxEdit.DisplayReplaceDialog()
        End If
    End Sub

    Private Sub miOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miOptions.Click
        ' executing editor settings dialog
        Dim options As DlgSyntaxSettings = New DlgSyntaxSettings
        options.SyntaxSettings.Assign(GlobalSettings)
        If options.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            GlobalSettings.Assign(options.SyntaxSettings)
            UpdateEdits()
        End If
    End Sub

    Private Sub miFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFind.Click
        ' executing search dialog
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not SyntaxEdit Is Nothing Then
            SyntaxEdit.DisplaySearchDialog()
        End If
    End Sub

    Private Sub miGoto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miGoto.Click
        ' executing goto line dialog
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not SyntaxEdit Is Nothing Then
            SyntaxEdit.DisplayGotoLineDialog()
        End If
    End Sub

    Private Sub miCut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miCut.Click
        ' cutting selection to clipboard
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If (Not SyntaxEdit Is Nothing) And SyntaxEdit.Selection.CanCut() Then
            SyntaxEdit.Selection.Cut()
        End If
    End Sub

    Private Sub miCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miCopy.Click
        ' copying selection to clipboard
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If (Not SyntaxEdit Is Nothing) And SyntaxEdit.Selection.CanCopy() Then
            SyntaxEdit.Selection.Copy()
        End If
    End Sub

    Private Sub miPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miPaste.Click
        ' pasting selection from clipboard
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If (Not SyntaxEdit Is Nothing) And SyntaxEdit.Selection.CanPaste() Then
            SyntaxEdit.Selection.Paste()
        End If
    End Sub

    Private Sub miSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miSelectAll.Click
        ' selecting editor's content
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not SyntaxEdit Is Nothing Then
            SyntaxEdit.Selection.SelectAll()
        End If
    End Sub

    Private Sub miExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miExit.Click
        ' closing the application
        Close()
    End Sub

    Private Sub tlbStandard_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbStandard.ButtonClick
        If TypeOf e.Button.Tag Is MenuItem Then
            Dim mi As MenuItem = CType(e.Button.Tag, MenuItem)
            mi.PerformClick()
        Else
            If e.Button Is tbbNew Then
                NewEmptyFile("Noname" + (tcEditors.TabPages.Count + 1).ToString(), -1)
            End If
        End If
    End Sub


    Private Sub miPrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miPrintPreview.Click
        ' executing print preview dialog
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not SyntaxEdit Is Nothing Then
            SyntaxEdit.Printing.ExecutePrintPreviewDialog()
        End If
    End Sub

    Private Sub miPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miPrint.Click
        ' printing the editor
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not SyntaxEdit Is Nothing Then
            SyntaxEdit.Printing.Print()
        End If
    End Sub

    Private Sub miPageSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miPageSetup.Click
        ' executing page setup dialog
        Dim SyntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not SyntaxEdit Is Nothing Then
            SyntaxEdit.Printing.ExecutePageSetupDialog()
        End If
    End Sub

    Private Sub miAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAbout.Click
        ' executing about box dialog
        If companyInfo Is Nothing Then
            companyInfo = New CompanyInfo
        End If
        companyInfo.ShowDialog()
    End Sub

    Private Sub MainForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        GlobalSettings.SaveFile(Application.StartupPath + "\GlobalSettings.xml")
    End Sub

    Private Sub miOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miOpen.Click
        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            OpenFile(openFileDialog.FileName)
        End If
    End Sub

    Private Sub miCodeExplorer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCodeExplorer.Click
        OpenExplorer()
    End Sub

    Private Sub OpenExplorer()
        If grExplorer.Visible Then
            miCodeExplorer.Text = String.Format(sOpenExplorer, "Open")
        Else
            miCodeExplorer.Text = String.Format(sOpenExplorer, "Close")
        End If
        grExplorer.Visible = Not grExplorer.Visible
    End Sub

    Private Sub UpdateCodeExplorer()
        ' updating explorer tree
        Dim syntaxEdit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not (syntaxEdit Is Nothing) Then
            If (TypeOf syntaxEdit.Lexer Is ISyntaxParser) And Not (TypeOf syntaxEdit.Lexer Is XmlParser) Then
                Explorer.UpdateExplorer(CType(syntaxEdit.Lexer, ISyntaxParser).SyntaxTree)
            Else
                Explorer.UpdateExplorer(Nothing)
            End If
            syntaxEdit.Invalidate()
        Else
            Explorer.UpdateExplorer(Nothing)
        End If
    End Sub

    Public Class CodeExplorer
        Private explorer As TreeView
        Protected Friend items As Hashtable

        Private Const cDotImage As Integer = 0
        Private Const cEnumFieldImage As Integer = 1
        Private Const cNameSpaceImage As Integer = 2
        Private Const cClassImage As Integer = 3
        Private Const cConstImage As Integer = 4
        Private Const cDelegateImage As Integer = 5
        Private Const cEnumImage As Integer = 6
        Private Const cEventImage As Integer = 7
        Private Const cFieldImage As Integer = 8
        Private Const cInterfaceImage As Integer = 9
        Private Const cMethodImage As Integer = 10
        Private Const cPropImage As Integer = 11
        Private Const cStructImage As Integer = 12

        Private Const cImageDelta As Integer = 10

        Private selectedNodeName As String = String.Empty
        Private topNodeName As String = String.Empty

        Public Sub New()
            items = New Hashtable
        End Sub
        Private Sub BeforeRefresh(ByVal list As ArrayList, ByVal nodes As TreeNodeCollection)
            Dim node As TreeNode
            For Each node In nodes
                If (node.IsExpanded) Then
                    list.Add(node.FullPath)
                    BeforeRefresh(list, node.Nodes)
                End If
            Next node
        End Sub

        Private Sub BeforeRefresh(ByVal list As ArrayList)
            If explorer.TopNode Is Nothing Then
                topNodeName = String.Empty
            Else
                topNodeName = explorer.TopNode.FullPath
            End If
            If explorer.SelectedNode Is Nothing Then
                selectedNodeName = String.Empty
            Else
                selectedNodeName = explorer.SelectedNode.FullPath
            End If
            list.Clear()
            BeforeRefresh(list, explorer.Nodes)
        End Sub

        Private Sub AfterRefresh(ByVal list As ArrayList, ByVal nodes As TreeNodeCollection, ByRef SelNode As TreeNode, ByRef TopNode As TreeNode)
            Dim node As TreeNode
            Dim s As String
            For Each node In nodes
                s = node.FullPath
                If ((SelNode Is Nothing) And (s = selectedNodeName)) Then
                    SelNode = node
                End If
                If ((TopNode Is Nothing) And (s = topNodeName)) Then
                    TopNode = node
                End If

                If ((node.Nodes.Count > 0) And (list.IndexOf(s) >= 0)) Then
                    node.Expand()
                End If
                AfterRefresh(list, node.Nodes, SelNode, TopNode)
            Next node
        End Sub

        Private Sub AfterRefresh(ByVal list As ArrayList)
            Dim topNode As TreeNode = Nothing
            Dim selNode As TreeNode = Nothing
            AfterRefresh(list, explorer.Nodes, selNode, topNode)
            If Not (selNode Is Nothing) Then
                explorer.SelectedNode = selNode
            End If
            If Not (topNode Is Nothing) Then
                topNode.EnsureVisible()
            End If
        End Sub
        Private Function ScopeImageIndex(ByVal node As ISyntaxNode, ByVal isScopedImage As Boolean) As Integer
            Dim syntaxAttribute As ISyntaxAttribute = node.FindAttribute(NetNodeType.Modifier.ToString())
            If Not (syntaxAttribute Is Nothing) Then
                Dim s As String = syntaxAttribute.Value.ToString().ToLower()
                If (s = SyntaxConsts.PrivateModifier) Then
                    Return cImageDelta
                Else
                    If (s = SyntaxConsts.ProtectedModifier) Then
                        Return cImageDelta * 2
                    Else
                        If (s = SyntaxConsts.PublicModifier) Then
                            Return cImageDelta * 3
                        End If
                    End If
                End If
            End If
            If isScopedImage Then
                Return cImageDelta
            Else
                Return 0
            End If
        End Function
        Private Function IsIdentNode(ByVal nodeType As NetNodeType) As Boolean
            Select Case (nodeType)
                Case NetNodeType.Namespace To NetNodeType.Field, NetNodeType.Method To NetNodeType.Event, NetNodeType.Indexer
                    'Case NetNodeType.Class
                    'Case NetNodeType.Constructor
                    'Case NetNodeType.Delegate
                    'Case NetNodeType.Destructor
                    'Case NetNodeType.Enum
                    'Case NetNodeType.Event
                    'Case NetNodeType.Field
                    'Case NetNodeType.Indexer
                    'Case NetNodeType.Interface
                    'Case NetNodeType.Method
                    'Case NetNodeType.Namespace
                    'Case NetNodeType.Property
                    'Case NetNodeType.Struct
                    Return True
                Case Else
                    Return False
            End Select
        End Function

        Private Function IsValidNode(ByVal nodeType As NetNodeType, ByRef index As Integer) As Boolean
            Dim result As Boolean = False
            Select Case (nodeType)
                Case NetNodeType.Class
                    result = True
                    index = cClassImage
                Case NetNodeType.Constructor
                    result = True
                    index = cMethodImage
                Case NetNodeType.Delegate
                    result = True
                    index = cDelegateImage
                Case NetNodeType.Destructor
                    result = True
                    index = cMethodImage
                Case NetNodeType.Enum
                    result = True
                    index = cEnumImage
                Case NetNodeType.Event
                    result = True
                    index = cEventImage
                Case NetNodeType.Field
                    result = True
                    index = cFieldImage
                Case NetNodeType.Indexer
                    result = True
                    index = cPropImage
                Case NetNodeType.Interface
                    result = True
                    index = cInterfaceImage
                Case NetNodeType.Method
                    result = True
                    index = cMethodImage
                Case NetNodeType.Namespace
                    result = True
                    index = cNameSpaceImage
                Case NetNodeType.Property
                    result = True
                    index = cPropImage
                Case NetNodeType.Struct
                    result = True
                    index = cStructImage
                Case NetNodeType.Unit
                    result = True
                    index = cDotImage
                Case NetNodeType.Using
                    result = True
                    index = cNameSpaceImage
                Case NetNodeType.UsingList
                    result = True
                    index = cNameSpaceImage
                Case Else
                    result = False
                    index = -1
            End Select
            Return result
        End Function

        Private Sub BuildNode(ByVal nodes As TreeNodeCollection, ByVal snode As ISyntaxNode)
            Dim node As TreeNode = Nothing
            Dim index As Integer = -1
            If (IsValidNode(CType(snode.NodeType, NetNodeType), index)) Then
                node = nodes.Add(snode.Name)
                node.Text = CType(snode.NodeType, NetNodeType).ToString() + " : " + snode.Name
                index = index + ScopeImageIndex(snode, index > cNameSpaceImage)
                node.ImageIndex = index
                node.SelectedImageIndex = index
                node.Tag = snode
                If ((snode.Name <> String.Empty) And IsIdentNode(CType(snode.NodeType, NetNodeType))) Then
                    items(snode.Name) = snode.Name
                End If
            End If
            If Not (snode.ChildList Is Nothing) Then
                For Each n As ISyntaxNode In snode.ChildList
                    If Not node Is Nothing Then
                        BuildNode(node.Nodes, n)
                    Else
                        BuildNode(nodes, n)
                    End If
                Next n
            End If
        End Sub

        Private Sub BuildSyntaxTree(ByVal tree As ISyntaxTree, ByVal treeView As TreeView)
            items.Clear()
            Dim list As ArrayList = New ArrayList
            treeView.BeginUpdate()
            BeforeRefresh(list)
            Try
                treeView.Nodes.Clear()
                If Not (tree Is Nothing) Then
                    BuildNode(treeView.Nodes, tree.Root)
                End If
            Finally
                AfterRefresh(list)
                treeView.EndUpdate()
            End Try
        End Sub

        Public Sub UpdateExplorer(ByVal syntaxTree As ISyntaxTree)
            If (explorer Is Nothing) Then
                Return
            End If
            BuildSyntaxTree(syntaxTree, explorer)
        End Sub

        Public Property ExplorerTree() As TreeView

            Get
                Return explorer
            End Get
            Set(ByVal Value As TreeView)
                explorer = Value
            End Set
        End Property

    End Class

    Private Sub tvSyntax_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvSyntax.DoubleClick
        MoveToContext()
    End Sub

    Private Sub MoveToContext()
        ' moves to the position in the editor where current explorer node is declared
        Dim node As TreeNode = tvSyntax.SelectedNode
        If Not (node Is Nothing) Then
            Dim myEdit As SyntaxEdit = GetActiveSyntaxEdit()
            Dim p As Point = New Point(-1, -1)
            Dim endP As Point = New Point(-1, -1)
            Dim name As String = String.Empty
            If (TypeOf node.Tag Is ISyntaxNode) Then
                p = CType(node.Tag, ISyntaxNode).Position
                myEdit.Position = p
                myEdit.Focus()
            End If
        End If
    End Sub
    Private Sub ClearReferences()
        ' clears all references
        Dim edit As SyntaxEdit = GetActiveSyntaxEdit()
        If (Not (references Is Nothing) And references.Count >= 0) Then
            references.Clear()
            If (edit Is Nothing) Then
                edit.Invalidate()
            End If
        End If
    End Sub

    Private Sub cmiGotoDeclaration_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmiGotoDeclaration.Click
        ' invalidating text region containing underlined text
        UpdateGotoDeclaration(True)
    End Sub
    Private Function UpdateGotoDeclaration(ByVal jump As Boolean) As Boolean
        Dim result As Boolean = False
        Dim edit As SyntaxEdit = GetActiveSyntaxEdit()
        If Not (edit Is Nothing) Then
            If Not (edit.Lexer Is Nothing) And (TypeOf edit.Lexer Is ISyntaxParser) Then
                Dim node As ISyntaxNode = (CType(edit.Lexer, ISyntaxParser).FindDeclaration(String.Empty, edit.Position))
                If Not (node Is Nothing) Then
                    result = True
                    If (jump) Then
                        edit.Position = node.Position
                        edit.Invalidate()
                    End If
                End If
            End If
        End If
        Return result
    End Function

    Private Sub FindReferences()
        ' finds all references relative to the indentifier under caret position
        Dim edit As SyntaxEdit = GetActiveSyntaxEdit()
        If (Not (edit Is Nothing) And Not (edit.Lexer Is Nothing) And (TypeOf edit.Lexer Is ISyntaxParser)) Then
            Dim node As ISyntaxNode = CType(edit.Lexer, ISyntaxParser).FindDeclaration(String.Empty, edit.Position)
            If Not (node Is Nothing) Then
                Dim pt1 As Point = node.Position
                Dim attr As ISyntaxAttribute = node.FindAttribute(SyntaxConsts.DeclarationScope)
                Dim pt2 As Point
                If Not (attr Is Nothing) Then
                    pt2 = attr.Position
                Else
                    pt2 = node.Range.EndPoint
                End If
                edit.Selection.SetSelection(SelectionType.Stream, pt1, pt2)
                CType(edit.Lexer, ISyntaxParser).FindReferences(node, references)
                edit.Invalidate()
                edit = GetActiveSyntaxEdit()
                If Not (edit Is Nothing) Then
                    edit.Selection.SetSelection(SelectionType.Stream, pt1, pt2)
                    edit.Invalidate()
                End If
            End If
        Else
            ClearReferences()
        End If
    End Sub
    Private Sub cmiFindReferences_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmiFindReferences.Click
        FindReferences()
    End Sub

    Private Sub cmMain_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmMain.Popup
        cmiGotoDeclaration.Enabled = UpdateGotoDeclaration(False)
        cmiFindReferences.Enabled = cmiGotoDeclaration.Enabled
    End Sub

    Private Sub tcEditors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcEditors.SelectedIndexChanged
        UpdateControls()
        UpdateCodeExplorer()
    End Sub

    Private Sub cmiRemovePage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmiRemovePage.Click
        RemovePage()
    End Sub
End Class
