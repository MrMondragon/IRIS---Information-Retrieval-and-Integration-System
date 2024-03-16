#Region "Copyright (c) 2004 - 2007 Quantum Whale LLC."

'	Quantum Whale .NET Component Library
'	Editor.NET Main Demo
'
'	Copyright (c) 2004 - 2007 Quantum Whale LLC.
'	ALL RIGHTS RESERVED
'
'	http://www.qwhale.net
'	contact@qwhale.net

#End Region
Imports System.Drawing.Printing
Imports QWhale.Editor
Imports QWhale.Syntax
Imports QWhale.Common
Imports QWhale.Editor.Dialogs
Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
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
    Friend WithEvents pnMain As System.Windows.Forms.Panel
    Friend WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents saveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents textSource1 As TextSource
    Friend WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents csParser1 As QWhale.Syntax.Parsers.CsParser
    Friend WithEvents imageList2 As System.Windows.Forms.ImageList
    Friend WithEvents treeView1 As System.Windows.Forms.TreeView
    Friend WithEvents pnManage As System.Windows.Forms.Panel
    Public WithEvents tcContainer As System.Windows.Forms.TabControl
    Public WithEvents tpGutter As System.Windows.Forms.TabPage
    Friend WithEvents pnGutter As System.Windows.Forms.Panel
    Friend WithEvents gbGutter As System.Windows.Forms.GroupBox
    Friend WithEvents btShowBookmarks As System.Windows.Forms.Button
    Friend WithEvents chbPaintBookMarks As System.Windows.Forms.CheckBox
    Friend WithEvents chbDrawLineBookmarks As System.Windows.Forms.CheckBox
    Friend WithEvents laGutterWidth As System.Windows.Forms.Label
    Friend WithEvents nudGutterWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents chbShowGutter As System.Windows.Forms.CheckBox
    Friend WithEvents tpOther As System.Windows.Forms.TabPage
    Friend WithEvents pnOther As System.Windows.Forms.Panel
    Friend WithEvents gbBraces As System.Windows.Forms.GroupBox
    Friend WithEvents cbTempHighlightBraces As System.Windows.Forms.CheckBox
    Friend WithEvents chbUseRoundRect As System.Windows.Forms.CheckBox
    Friend WithEvents chbHighlightBraces As System.Windows.Forms.CheckBox
    Friend WithEvents gbOther As System.Windows.Forms.GroupBox
    Friend WithEvents chbTransparent As System.Windows.Forms.CheckBox
    Friend WithEvents chbSeparateLines As System.Windows.Forms.CheckBox
    Friend WithEvents chbWhiteSpaceVisible As System.Windows.Forms.CheckBox
    Public WithEvents tpWordWrap As System.Windows.Forms.TabPage
    Friend WithEvents pnWordWrap As System.Windows.Forms.Panel
    Friend WithEvents gbWordWrap As System.Windows.Forms.GroupBox
    Friend WithEvents chbFlatScrollBars As System.Windows.Forms.CheckBox
    Friend WithEvents chbSystemScrollBars As System.Windows.Forms.CheckBox
    Friend WithEvents chbScrollButtons As System.Windows.Forms.CheckBox
    Friend WithEvents chbAllowSplit As System.Windows.Forms.CheckBox
    Friend WithEvents chbWrapAtMargin As System.Windows.Forms.CheckBox
    Friend WithEvents chbWordWrap As System.Windows.Forms.CheckBox
    Friend WithEvents chbShowScrollHint As System.Windows.Forms.CheckBox
    Friend WithEvents chbSmoothScroll As System.Windows.Forms.CheckBox
    Friend WithEvents tpPages As System.Windows.Forms.TabPage
    Friend WithEvents pnPageLayout As System.Windows.Forms.Panel
    Friend WithEvents gbPages As System.Windows.Forms.GroupBox
    Friend WithEvents cbPageSize As System.Windows.Forms.ComboBox
    Friend WithEvents laPageSize As System.Windows.Forms.Label
    Friend WithEvents cbPageLayout As System.Windows.Forms.ComboBox
    Friend WithEvents laPageLayout As System.Windows.Forms.Label
    Friend WithEvents gbRulers As System.Windows.Forms.GroupBox
    Friend WithEvents chbVertRuler As System.Windows.Forms.CheckBox
    Friend WithEvents chbHorzRuler As System.Windows.Forms.CheckBox
    Friend WithEvents cbRulerUnits As System.Windows.Forms.ComboBox
    Friend WithEvents laRulerUnits As System.Windows.Forms.Label
    Friend WithEvents chbRulerDisplayDragLines As System.Windows.Forms.CheckBox
    Friend WithEvents chbRulerDiscrete As System.Windows.Forms.CheckBox
    Friend WithEvents chbRulerAllowDrag As System.Windows.Forms.CheckBox
    Friend WithEvents tpLineNumbers As System.Windows.Forms.TabPage
    Friend WithEvents pnLineNumbers As System.Windows.Forms.Panel
    Friend WithEvents gbLineNumbers As System.Windows.Forms.GroupBox
    Friend WithEvents chbLineModificator As System.Windows.Forms.CheckBox
    Friend WithEvents laLineNumbersStart As System.Windows.Forms.Label
    Friend WithEvents nudLineNumbersStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbLineNumbersAlign As System.Windows.Forms.ComboBox
    Friend WithEvents laLineNumbersAlign As System.Windows.Forms.Label
    Friend WithEvents chbLinesOnGutter As System.Windows.Forms.CheckBox
    Friend WithEvents chbLineNumbers As System.Windows.Forms.CheckBox
    Friend WithEvents chbLinesBeyondEof As System.Windows.Forms.CheckBox
    Friend WithEvents chbHighlightCurrentLine As System.Windows.Forms.CheckBox
    Friend WithEvents tpSelection As System.Windows.Forms.TabPage
    Friend WithEvents pnSelection As System.Windows.Forms.Panel
    Friend WithEvents gbSelection As System.Windows.Forms.GroupBox
    Friend WithEvents chbOverwriteBlocks As System.Windows.Forms.CheckBox
    Friend WithEvents chbPersistentBlocks As System.Windows.Forms.CheckBox
    Friend WithEvents chbDeselectOnCopy As System.Windows.Forms.CheckBox
    Friend WithEvents chbSelectLineOnDblClick As System.Windows.Forms.CheckBox
    Friend WithEvents chbHideSelection As System.Windows.Forms.CheckBox
    Friend WithEvents chbUseColors As System.Windows.Forms.CheckBox
    Friend WithEvents chbSelectBeyondEol As System.Windows.Forms.CheckBox
    Friend WithEvents chbDisableDragging As System.Windows.Forms.CheckBox
    Friend WithEvents chbDisableSelection As System.Windows.Forms.CheckBox
    Friend WithEvents tpNavigate As System.Windows.Forms.TabPage
    Friend WithEvents pnNavigate As System.Windows.Forms.Panel
    Friend WithEvents gbNavigateOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chbMoveOnRightButton As System.Windows.Forms.CheckBox
    Friend WithEvents chbDownAtLineEnd As System.Windows.Forms.CheckBox
    Friend WithEvents chbUpAtLineBegin As System.Windows.Forms.CheckBox
    Friend WithEvents chbBeyondEof As System.Windows.Forms.CheckBox
    Friend WithEvents chbBeyondEol As System.Windows.Forms.CheckBox
    Friend WithEvents tpMargin As System.Windows.Forms.TabPage
    Friend WithEvents pnMargin As System.Windows.Forms.Panel
    Friend WithEvents gbMargin As System.Windows.Forms.GroupBox
    Friend WithEvents chbShowMarginHints As System.Windows.Forms.CheckBox
    Friend WithEvents chbAllowDragMargin As System.Windows.Forms.CheckBox
    Friend WithEvents nudMarginPos As System.Windows.Forms.NumericUpDown
    Friend WithEvents laMarginPos As System.Windows.Forms.Label
    Friend WithEvents chbShowMargin As System.Windows.Forms.CheckBox
    Friend WithEvents tpTextSource As System.Windows.Forms.TabPage
    Friend WithEvents pnTextSource As System.Windows.Forms.Panel
    Friend WithEvents laSource As System.Windows.Forms.Label
    Friend WithEvents tpSpellAndUrl As System.Windows.Forms.TabPage
    Friend WithEvents pnSpellAndUrl As System.Windows.Forms.Panel
    Friend WithEvents gbSpellAndUrl As System.Windows.Forms.GroupBox
    Friend WithEvents chbShowHyperTextHints As System.Windows.Forms.CheckBox
    Friend WithEvents chbCheckSpelling As System.Windows.Forms.CheckBox
    Friend WithEvents chbHighlightUrls As System.Windows.Forms.CheckBox
    Friend WithEvents tpOutlining As System.Windows.Forms.TabPage
    Friend WithEvents pnOutlining As System.Windows.Forms.Panel
    Friend WithEvents gbOutlining As System.Windows.Forms.GroupBox
    Friend WithEvents chbAllowOutlining As System.Windows.Forms.CheckBox
    Friend WithEvents chbDrawButtons As System.Windows.Forms.CheckBox
    Friend WithEvents chbDrawLines As System.Windows.Forms.CheckBox
    Friend WithEvents chbDrawOnGutter As System.Windows.Forms.CheckBox
    Friend WithEvents chbShowHints As System.Windows.Forms.CheckBox
    Friend WithEvents tpCompanyInfo As System.Windows.Forms.TabPage
    Public WithEvents pnCompanyInfo As System.Windows.Forms.Panel
    Friend WithEvents tbCompanyInfo As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents laMailTo As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents laAdress As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents laCompany As System.Windows.Forms.Label
    Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents tpDialogs As System.Windows.Forms.TabPage
    Friend WithEvents pnDialogs As System.Windows.Forms.Panel
    Friend WithEvents gbDialogs As System.Windows.Forms.GroupBox
    Friend WithEvents btCustomize As System.Windows.Forms.Button
    Friend WithEvents btGoto As System.Windows.Forms.Button
    Friend WithEvents btReplace As System.Windows.Forms.Button
    Friend WithEvents btFind As System.Windows.Forms.Button
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents btLoad As System.Windows.Forms.Button
    Public WithEvents tpPrinting As System.Windows.Forms.TabPage
    Friend WithEvents pnPrinting As System.Windows.Forms.Panel
    Friend WithEvents gbPrint As System.Windows.Forms.GroupBox
    Friend WithEvents btPageSetup As System.Windows.Forms.Button
    Friend WithEvents btPrint As System.Windows.Forms.Button
    Friend WithEvents btPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btXml As System.Windows.Forms.Button
    Friend WithEvents btHtml As System.Windows.Forms.Button
    Friend WithEvents btRtf As System.Windows.Forms.Button
    Friend WithEvents tpProperties As System.Windows.Forms.TabPage
    Friend WithEvents pnProperties As System.Windows.Forms.Panel
    Friend WithEvents pnPropertyGrid As System.Windows.Forms.Panel
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents pnEditContainer As System.Windows.Forms.Panel
    Friend WithEvents syntaxEdit As QWhale.Editor.SyntaxEdit
    Friend WithEvents splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents syntaxSplitEdit As QWhale.Editor.SyntaxEdit
    Friend WithEvents chbColumnsVisible As System.Windows.Forms.CheckBox
    Friend WithEvents chbDrawColumnsIndent As System.Windows.Forms.CheckBox
    Friend WithEvents chbQuickInfoTips As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
        Dim ScrollingButton1 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Dim ScrollingButton2 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Dim ScrollingButton3 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Dim ScrollingButton4 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Dim ScrollingButton5 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnMain = New System.Windows.Forms.Panel
        Me.pnEditContainer = New System.Windows.Forms.Panel
        Me.syntaxEdit = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.csParser1 = New QWhale.Syntax.Parsers.CsParser
        Me.textSource1 = New QWhale.Editor.TextSource(Me.components)
        Me.splitter1 = New System.Windows.Forms.Splitter
        Me.syntaxSplitEdit = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.pnPropertyGrid = New System.Windows.Forms.Panel
        Me.pnManage = New System.Windows.Forms.Panel
        Me.tcContainer = New System.Windows.Forms.TabControl
        Me.tpGutter = New System.Windows.Forms.TabPage
        Me.pnGutter = New System.Windows.Forms.Panel
        Me.gbGutter = New System.Windows.Forms.GroupBox
        Me.btShowBookmarks = New System.Windows.Forms.Button
        Me.chbPaintBookMarks = New System.Windows.Forms.CheckBox
        Me.chbDrawLineBookmarks = New System.Windows.Forms.CheckBox
        Me.laGutterWidth = New System.Windows.Forms.Label
        Me.nudGutterWidth = New System.Windows.Forms.NumericUpDown
        Me.chbShowGutter = New System.Windows.Forms.CheckBox
        Me.tpMargin = New System.Windows.Forms.TabPage
        Me.pnMargin = New System.Windows.Forms.Panel
        Me.gbMargin = New System.Windows.Forms.GroupBox
        Me.chbColumnsVisible = New System.Windows.Forms.CheckBox
        Me.chbShowMarginHints = New System.Windows.Forms.CheckBox
        Me.chbAllowDragMargin = New System.Windows.Forms.CheckBox
        Me.nudMarginPos = New System.Windows.Forms.NumericUpDown
        Me.laMarginPos = New System.Windows.Forms.Label
        Me.chbShowMargin = New System.Windows.Forms.CheckBox
        Me.tpOther = New System.Windows.Forms.TabPage
        Me.pnOther = New System.Windows.Forms.Panel
        Me.gbBraces = New System.Windows.Forms.GroupBox
        Me.cbTempHighlightBraces = New System.Windows.Forms.CheckBox
        Me.chbUseRoundRect = New System.Windows.Forms.CheckBox
        Me.chbHighlightBraces = New System.Windows.Forms.CheckBox
        Me.gbOther = New System.Windows.Forms.GroupBox
        Me.chbDrawColumnsIndent = New System.Windows.Forms.CheckBox
        Me.chbQuickInfoTips = New System.Windows.Forms.CheckBox
        Me.chbTransparent = New System.Windows.Forms.CheckBox
        Me.chbSeparateLines = New System.Windows.Forms.CheckBox
        Me.chbWhiteSpaceVisible = New System.Windows.Forms.CheckBox
        Me.tpCompanyInfo = New System.Windows.Forms.TabPage
        Me.pnCompanyInfo = New System.Windows.Forms.Panel
        Me.tbCompanyInfo = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.laMailTo = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.laAdress = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.laCompany = New System.Windows.Forms.Label
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.tpWordWrap = New System.Windows.Forms.TabPage
        Me.pnWordWrap = New System.Windows.Forms.Panel
        Me.gbWordWrap = New System.Windows.Forms.GroupBox
        Me.chbFlatScrollBars = New System.Windows.Forms.CheckBox
        Me.chbSystemScrollBars = New System.Windows.Forms.CheckBox
        Me.chbScrollButtons = New System.Windows.Forms.CheckBox
        Me.chbAllowSplit = New System.Windows.Forms.CheckBox
        Me.chbWrapAtMargin = New System.Windows.Forms.CheckBox
        Me.chbWordWrap = New System.Windows.Forms.CheckBox
        Me.chbShowScrollHint = New System.Windows.Forms.CheckBox
        Me.chbSmoothScroll = New System.Windows.Forms.CheckBox
        Me.tpLineNumbers = New System.Windows.Forms.TabPage
        Me.pnLineNumbers = New System.Windows.Forms.Panel
        Me.gbLineNumbers = New System.Windows.Forms.GroupBox
        Me.chbLineModificator = New System.Windows.Forms.CheckBox
        Me.laLineNumbersStart = New System.Windows.Forms.Label
        Me.nudLineNumbersStart = New System.Windows.Forms.NumericUpDown
        Me.cbLineNumbersAlign = New System.Windows.Forms.ComboBox
        Me.laLineNumbersAlign = New System.Windows.Forms.Label
        Me.chbLinesOnGutter = New System.Windows.Forms.CheckBox
        Me.chbLineNumbers = New System.Windows.Forms.CheckBox
        Me.chbLinesBeyondEof = New System.Windows.Forms.CheckBox
        Me.chbHighlightCurrentLine = New System.Windows.Forms.CheckBox
        Me.tpNavigate = New System.Windows.Forms.TabPage
        Me.pnNavigate = New System.Windows.Forms.Panel
        Me.gbNavigateOptions = New System.Windows.Forms.GroupBox
        Me.chbMoveOnRightButton = New System.Windows.Forms.CheckBox
        Me.chbDownAtLineEnd = New System.Windows.Forms.CheckBox
        Me.chbUpAtLineBegin = New System.Windows.Forms.CheckBox
        Me.chbBeyondEof = New System.Windows.Forms.CheckBox
        Me.chbBeyondEol = New System.Windows.Forms.CheckBox
        Me.tpTextSource = New System.Windows.Forms.TabPage
        Me.pnTextSource = New System.Windows.Forms.Panel
        Me.laSource = New System.Windows.Forms.Label
        Me.tpOutlining = New System.Windows.Forms.TabPage
        Me.pnOutlining = New System.Windows.Forms.Panel
        Me.gbOutlining = New System.Windows.Forms.GroupBox
        Me.chbAllowOutlining = New System.Windows.Forms.CheckBox
        Me.chbDrawButtons = New System.Windows.Forms.CheckBox
        Me.chbDrawLines = New System.Windows.Forms.CheckBox
        Me.chbDrawOnGutter = New System.Windows.Forms.CheckBox
        Me.chbShowHints = New System.Windows.Forms.CheckBox
        Me.tpDialogs = New System.Windows.Forms.TabPage
        Me.pnDialogs = New System.Windows.Forms.Panel
        Me.gbDialogs = New System.Windows.Forms.GroupBox
        Me.btCustomize = New System.Windows.Forms.Button
        Me.btGoto = New System.Windows.Forms.Button
        Me.btReplace = New System.Windows.Forms.Button
        Me.btFind = New System.Windows.Forms.Button
        Me.btSave = New System.Windows.Forms.Button
        Me.btLoad = New System.Windows.Forms.Button
        Me.tpProperties = New System.Windows.Forms.TabPage
        Me.pnProperties = New System.Windows.Forms.Panel
        Me.tpPages = New System.Windows.Forms.TabPage
        Me.pnPageLayout = New System.Windows.Forms.Panel
        Me.gbPages = New System.Windows.Forms.GroupBox
        Me.cbPageSize = New System.Windows.Forms.ComboBox
        Me.laPageSize = New System.Windows.Forms.Label
        Me.cbPageLayout = New System.Windows.Forms.ComboBox
        Me.laPageLayout = New System.Windows.Forms.Label
        Me.gbRulers = New System.Windows.Forms.GroupBox
        Me.chbVertRuler = New System.Windows.Forms.CheckBox
        Me.chbHorzRuler = New System.Windows.Forms.CheckBox
        Me.cbRulerUnits = New System.Windows.Forms.ComboBox
        Me.laRulerUnits = New System.Windows.Forms.Label
        Me.chbRulerDisplayDragLines = New System.Windows.Forms.CheckBox
        Me.chbRulerDiscrete = New System.Windows.Forms.CheckBox
        Me.chbRulerAllowDrag = New System.Windows.Forms.CheckBox
        Me.tpSelection = New System.Windows.Forms.TabPage
        Me.pnSelection = New System.Windows.Forms.Panel
        Me.gbSelection = New System.Windows.Forms.GroupBox
        Me.chbOverwriteBlocks = New System.Windows.Forms.CheckBox
        Me.chbPersistentBlocks = New System.Windows.Forms.CheckBox
        Me.chbDeselectOnCopy = New System.Windows.Forms.CheckBox
        Me.chbSelectLineOnDblClick = New System.Windows.Forms.CheckBox
        Me.chbHideSelection = New System.Windows.Forms.CheckBox
        Me.chbUseColors = New System.Windows.Forms.CheckBox
        Me.chbSelectBeyondEol = New System.Windows.Forms.CheckBox
        Me.chbDisableDragging = New System.Windows.Forms.CheckBox
        Me.chbDisableSelection = New System.Windows.Forms.CheckBox
        Me.tpSpellAndUrl = New System.Windows.Forms.TabPage
        Me.pnSpellAndUrl = New System.Windows.Forms.Panel
        Me.gbSpellAndUrl = New System.Windows.Forms.GroupBox
        Me.chbShowHyperTextHints = New System.Windows.Forms.CheckBox
        Me.chbCheckSpelling = New System.Windows.Forms.CheckBox
        Me.chbHighlightUrls = New System.Windows.Forms.CheckBox
        Me.tpPrinting = New System.Windows.Forms.TabPage
        Me.pnPrinting = New System.Windows.Forms.Panel
        Me.gbPrint = New System.Windows.Forms.GroupBox
        Me.btPageSetup = New System.Windows.Forms.Button
        Me.btPrint = New System.Windows.Forms.Button
        Me.btPrintPreview = New System.Windows.Forms.Button
        Me.btXml = New System.Windows.Forms.Button
        Me.btHtml = New System.Windows.Forms.Button
        Me.btRtf = New System.Windows.Forms.Button
        Me.treeView1 = New System.Windows.Forms.TreeView
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.saveFileDialog2 = New System.Windows.Forms.SaveFileDialog
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.pnMain.SuspendLayout()
        Me.pnEditContainer.SuspendLayout()
        Me.pnManage.SuspendLayout()
        Me.tcContainer.SuspendLayout()
        Me.tpGutter.SuspendLayout()
        Me.pnGutter.SuspendLayout()
        Me.gbGutter.SuspendLayout()
        CType(Me.nudGutterWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMargin.SuspendLayout()
        Me.pnMargin.SuspendLayout()
        Me.gbMargin.SuspendLayout()
        CType(Me.nudMarginPos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpOther.SuspendLayout()
        Me.pnOther.SuspendLayout()
        Me.gbBraces.SuspendLayout()
        Me.gbOther.SuspendLayout()
        Me.tpCompanyInfo.SuspendLayout()
        Me.pnCompanyInfo.SuspendLayout()
        Me.tpWordWrap.SuspendLayout()
        Me.pnWordWrap.SuspendLayout()
        Me.gbWordWrap.SuspendLayout()
        Me.tpLineNumbers.SuspendLayout()
        Me.pnLineNumbers.SuspendLayout()
        Me.gbLineNumbers.SuspendLayout()
        CType(Me.nudLineNumbersStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNavigate.SuspendLayout()
        Me.pnNavigate.SuspendLayout()
        Me.gbNavigateOptions.SuspendLayout()
        Me.tpTextSource.SuspendLayout()
        Me.pnTextSource.SuspendLayout()
        Me.tpOutlining.SuspendLayout()
        Me.pnOutlining.SuspendLayout()
        Me.gbOutlining.SuspendLayout()
        Me.tpDialogs.SuspendLayout()
        Me.pnDialogs.SuspendLayout()
        Me.gbDialogs.SuspendLayout()
        Me.tpProperties.SuspendLayout()
        Me.tpPages.SuspendLayout()
        Me.pnPageLayout.SuspendLayout()
        Me.gbPages.SuspendLayout()
        Me.gbRulers.SuspendLayout()
        Me.tpSelection.SuspendLayout()
        Me.pnSelection.SuspendLayout()
        Me.gbSelection.SuspendLayout()
        Me.tpSpellAndUrl.SuspendLayout()
        Me.pnSpellAndUrl.SuspendLayout()
        Me.gbSpellAndUrl.SuspendLayout()
        Me.tpPrinting.SuspendLayout()
        Me.pnPrinting.SuspendLayout()
        Me.gbPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList2
        '
        Me.imageList2.ImageSize = New System.Drawing.Size(15, 15)
        Me.imageList2.ImageStream = CType(resources.GetObject("imageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'pnMain
        '
        Me.pnMain.Controls.Add(Me.pnEditContainer)
        Me.pnMain.Controls.Add(Me.Splitter2)
        Me.pnMain.Controls.Add(Me.pnPropertyGrid)
        Me.pnMain.Controls.Add(Me.pnManage)
        Me.pnMain.Controls.Add(Me.treeView1)
        Me.pnMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnMain.Location = New System.Drawing.Point(0, 0)
        Me.pnMain.Name = "pnMain"
        Me.pnMain.Size = New System.Drawing.Size(674, 478)
        Me.pnMain.TabIndex = 2
        '
        'pnEditContainer
        '
        Me.pnEditContainer.Controls.Add(Me.syntaxEdit)
        Me.pnEditContainer.Controls.Add(Me.splitter1)
        Me.pnEditContainer.Controls.Add(Me.syntaxSplitEdit)
        Me.pnEditContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnEditContainer.Location = New System.Drawing.Point(160, 144)
        Me.pnEditContainer.Name = "pnEditContainer"
        Me.pnEditContainer.Size = New System.Drawing.Size(295, 334)
        Me.pnEditContainer.TabIndex = 32
        '
        'syntaxEdit
        '
        Me.syntaxEdit.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit.BackgroundImage = CType(resources.GetObject("syntaxEdit.BackgroundImage"), System.Drawing.Image)
        Me.syntaxEdit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit.EditMargin.ColumnPositions = New Integer() {16, 48}
        Me.syntaxEdit.EditMargin.ColumnsVisible = True
        Me.syntaxEdit.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit.Gutter.LineNumbersAlignment = System.Drawing.StringAlignment.Far
        Me.syntaxEdit.Gutter.Options = CType((QWhale.Editor.GutterOptions.PaintLineNumbers Or QWhale.Editor.GutterOptions.PaintBookMarks), QWhale.Editor.GutterOptions)
        Me.syntaxEdit.HyperText.HighlightUrls = True
        Me.syntaxEdit.Lexer = Me.csParser1
        Me.syntaxEdit.LineSeparator.Options = QWhale.Editor.SeparatorOptions.HighlightCurrentLine
        Me.syntaxEdit.Location = New System.Drawing.Point(0, 0)
        Me.syntaxEdit.Name = "syntaxEdit"
        Me.syntaxEdit.Outlining.AllowOutlining = True
        ScrollingButton1.Description = "Normal Mode"
        ScrollingButton1.ImageIndex = 0
        ScrollingButton1.Images = Me.imageList2
        ScrollingButton1.Name = "Normal"
        ScrollingButton2.Description = "Page Layout Mode"
        ScrollingButton2.ImageIndex = 1
        ScrollingButton2.Images = Me.imageList2
        ScrollingButton2.Name = "PageLayout"
        ScrollingButton3.Description = "Page Breaks Mode"
        ScrollingButton3.ImageIndex = 2
        ScrollingButton3.Images = Me.imageList2
        ScrollingButton3.Name = "PageBreaks"
        Me.syntaxEdit.Scroll.HorizontalButtons.AddRange(New QWhale.Editor.ScrollingButton() {ScrollingButton1, ScrollingButton2, ScrollingButton3})
        Me.syntaxEdit.Scroll.Options = CType((((((QWhale.Editor.ScrollingOptions.SmoothScroll Or QWhale.Editor.ScrollingOptions.UseScrollDelta) _
                    Or QWhale.Editor.ScrollingOptions.AllowSplitHorz) _
                    Or QWhale.Editor.ScrollingOptions.AllowSplitVert) _
                    Or QWhale.Editor.ScrollingOptions.HorzButtons) _
                    Or QWhale.Editor.ScrollingOptions.VertButtons), QWhale.Editor.ScrollingOptions)
        ScrollingButton4.Description = "Page Down"
        ScrollingButton4.ImageIndex = 3
        ScrollingButton4.Images = Me.imageList2
        ScrollingButton4.Name = "PageDown"
        ScrollingButton5.Description = "Page Up"
        ScrollingButton5.ImageIndex = 4
        ScrollingButton5.Images = Me.imageList2
        ScrollingButton5.Name = "PageUp"
        Me.syntaxEdit.Scroll.VerticalButtons.AddRange(New QWhale.Editor.ScrollingButton() {ScrollingButton4, ScrollingButton5})
        Me.syntaxEdit.Size = New System.Drawing.Size(295, 177)
        Me.syntaxEdit.Source = Me.textSource1
        Me.syntaxEdit.TabIndex = 27
        Me.syntaxEdit.WordWrap = True
        Me.syntaxEdit.WrapAtMargin = True
        '
        'csParser1
        '
        Me.csParser1.DefaultState = 0
        Me.csParser1.Options = QWhale.Syntax.SyntaxOptions.CodeCompletion
        Me.csParser1.XmlScheme = "<?xml version=""1.0"" encoding=""utf-16""?>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "<LexScheme xmlns:xsd=""http://www.w3.org/" & _
        "2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Autho" & _
        "r>Quantum Whale LLC.</Author>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Name />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Desc />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Copyright>Copyright (c" & _
        ") 2004, 2005 Quantum Whale LLC.</Copyright>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileExtension />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileType>c#" & _
        "</FileType>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Version>1.0</Version>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>iden" & _
        "ts</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>ControlText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled>tru" & _
        "e</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEnabled>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Bo" & _
        "ldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ItalicEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <" & _
        "UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name" & _
        ">numbers</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Green</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled>tru" & _
        "e</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEnabled>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Bo" & _
        "ldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ItalicEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <" & _
        "UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name" & _
        ">reswords</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Blue</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled>tru" & _
        "e</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEnabled>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Bo" & _
        "ldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ItalicEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <" & _
        "UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name" & _
        ">comments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Green</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</Pla" & _
        "inText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled>true</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEnable" & _
        "d>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BoldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ItalicE" & _
        "nabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "  </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>xmlcomments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Gray</" & _
        "ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled>true</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEna" & _
        "bled>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BoldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Ital" & _
        "icEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>symbols</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Gray</F" & _
        "oreColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled>true</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEnab" & _
        "led>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BoldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Itali" & _
        "cEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>whitespace</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Windo" & _
        "wText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled>true</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackC" & _
        "olorEnabled>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BoldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    " & _
        "  <ItalicEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <UnderlineEnabled>true</UnderlineEn" & _
        "abled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>strings</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>" & _
        "Maroon</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled>t" & _
        "rue</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEnabled>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <" & _
        "BoldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ItalicEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     " & _
        " <UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Na" & _
        "me>directives</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Blue</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnabled" & _
        ">true</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEnabled>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     " & _
        " <BoldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ItalicEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "   <UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <" & _
        "Name>syntaxerrors</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Red</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColorEnab" & _
        "led>true</ForeColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColorEnabled>true</BackColorEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "    <BoldEnabled>true</BoldEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ItalicEnabled>true</ItalicEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "      <UnderlineEnabled>true</UnderlineEnabled>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <S" & _
        "tates />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "</LexScheme>"
        '
        'textSource1
        '
        Me.textSource1.HighlightUrls = True
        Me.textSource1.Lexer = Me.csParser1
        Me.textSource1.Text = "#region Copyright (c) 2004 - 2007 Quantum Whale LLC." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "/*" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "Quantum Whale .NET Com" & _
        "ponent Library" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "Editor.NET Main Demo" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "Copyright (c) 2004 Quantum Whale LLC." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "ALL RIGHTS RESERVED" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "http://www.qwhale.net" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "contact@qwhale.net" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "*/" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "#endre" & _
        "gion Copyright (c) 2004 Quantum Whale LLC." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Drawing;" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Collections;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.ComponentModel;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Windows." & _
        "Forms;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Data;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using QWEditor;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using QWEditor.Dialogs;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "namespac" & _
        "e MainDemo" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "/// <summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "/// Summary description for Form1." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "/// </summa" & _
        "ry>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "public class MainForm : System.Windows.Forms.Form" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "public MainForm()" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// Required for Windows Form Designer support" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "Initia" & _
        "lizeComponent();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// TODO: Add any constructor code after Initialize" & _
        "Component call" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// <summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// Clean up any resources bein" & _
        "g used." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// </summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "protected override void Dispose( bool disposing )" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "" & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "if( disposing )" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "if (components != null) " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "compone" & _
        "nts.Dispose();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "base.Dispose( disposing );" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// <summary>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// The main entry point for the application." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// </summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "[STAThrea" & _
        "d]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "static void Main() " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "Application.Run(new MainForm());" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "pr" & _
        "ivate void MainForm_Load(object sender, System.EventArgs e)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "FillControl" & _
        "s();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "GlobalSettings = new SyntaxSettings();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "Options = new DlgSyntaxSetti" & _
        "ngs();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "GlobalSettings.LoadFromEdit(syntaxEdit);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "if (pictureBox1.Image is" & _
        " Bitmap)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "(pictureBox1.Image as Bitmap).MakeTransparent(Color.White);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "Up" & _
        "datePanels(grAppearance, oiGutter);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "ToggleOutline(syntaxEdit);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "ToggleOut" & _
        "line(syntaxSplitEdit);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//syntaxEdit.LoadFile(Application.StartupPath + @""\.." & _
        "\..\main.cs"");" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "}"
        '
        'splitter1
        '
        Me.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splitter1.Location = New System.Drawing.Point(0, 177)
        Me.splitter1.Name = "splitter1"
        Me.splitter1.Size = New System.Drawing.Size(295, 5)
        Me.splitter1.TabIndex = 26
        Me.splitter1.TabStop = False
        '
        'syntaxSplitEdit
        '
        Me.syntaxSplitEdit.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxSplitEdit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxSplitEdit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.syntaxSplitEdit.EditMargin.ColumnPositions = New Integer() {16, 48}
        Me.syntaxSplitEdit.EditMargin.ColumnsVisible = True
        Me.syntaxSplitEdit.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxSplitEdit.Gutter.LineNumbersAlignment = System.Drawing.StringAlignment.Far
        Me.syntaxSplitEdit.Gutter.Options = CType((QWhale.Editor.GutterOptions.PaintLineNumbers Or QWhale.Editor.GutterOptions.PaintBookMarks), QWhale.Editor.GutterOptions)
        Me.syntaxSplitEdit.HyperText.HighlightUrls = True
        Me.syntaxSplitEdit.Lexer = Me.csParser1
        Me.syntaxSplitEdit.LineSeparator.Options = QWhale.Editor.SeparatorOptions.HighlightCurrentLine
        Me.syntaxSplitEdit.Location = New System.Drawing.Point(0, 182)
        Me.syntaxSplitEdit.Name = "syntaxSplitEdit"
        Me.syntaxSplitEdit.Outlining.AllowOutlining = True
        Me.syntaxSplitEdit.Scroll.Options = CType((((((QWhale.Editor.ScrollingOptions.SmoothScroll Or QWhale.Editor.ScrollingOptions.UseScrollDelta) _
                    Or QWhale.Editor.ScrollingOptions.AllowSplitHorz) _
                    Or QWhale.Editor.ScrollingOptions.AllowSplitVert) _
                    Or QWhale.Editor.ScrollingOptions.HorzButtons) _
                    Or QWhale.Editor.ScrollingOptions.VertButtons), QWhale.Editor.ScrollingOptions)
        Me.syntaxSplitEdit.Size = New System.Drawing.Size(295, 152)
        Me.syntaxSplitEdit.Source = Me.textSource1
        Me.syntaxSplitEdit.TabIndex = 24
        Me.syntaxSplitEdit.Visible = False
        Me.syntaxSplitEdit.WordWrap = True
        Me.syntaxSplitEdit.WrapAtMargin = True
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter2.Location = New System.Drawing.Point(455, 144)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 334)
        Me.Splitter2.TabIndex = 31
        Me.Splitter2.TabStop = False
        '
        'pnPropertyGrid
        '
        Me.pnPropertyGrid.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnPropertyGrid.Location = New System.Drawing.Point(458, 144)
        Me.pnPropertyGrid.Name = "pnPropertyGrid"
        Me.pnPropertyGrid.Size = New System.Drawing.Size(216, 334)
        Me.pnPropertyGrid.TabIndex = 30
        Me.pnPropertyGrid.Visible = False
        '
        'pnManage
        '
        Me.pnManage.Controls.Add(Me.tcContainer)
        Me.pnManage.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnManage.Location = New System.Drawing.Point(160, 0)
        Me.pnManage.Name = "pnManage"
        Me.pnManage.Size = New System.Drawing.Size(514, 144)
        Me.pnManage.TabIndex = 28
        '
        'tcContainer
        '
        Me.tcContainer.Controls.Add(Me.tpGutter)
        Me.tcContainer.Controls.Add(Me.tpMargin)
        Me.tcContainer.Controls.Add(Me.tpOther)
        Me.tcContainer.Controls.Add(Me.tpCompanyInfo)
        Me.tcContainer.Controls.Add(Me.tpWordWrap)
        Me.tcContainer.Controls.Add(Me.tpLineNumbers)
        Me.tcContainer.Controls.Add(Me.tpNavigate)
        Me.tcContainer.Controls.Add(Me.tpTextSource)
        Me.tcContainer.Controls.Add(Me.tpOutlining)
        Me.tcContainer.Controls.Add(Me.tpDialogs)
        Me.tcContainer.Controls.Add(Me.tpProperties)
        Me.tcContainer.Controls.Add(Me.tpPages)
        Me.tcContainer.Controls.Add(Me.tpSelection)
        Me.tcContainer.Controls.Add(Me.tpSpellAndUrl)
        Me.tcContainer.Controls.Add(Me.tpPrinting)
        Me.tcContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcContainer.Location = New System.Drawing.Point(0, 0)
        Me.tcContainer.Name = "tcContainer"
        Me.tcContainer.SelectedIndex = 0
        Me.tcContainer.Size = New System.Drawing.Size(514, 144)
        Me.tcContainer.TabIndex = 2
        Me.tcContainer.Visible = False
        '
        'tpGutter
        '
        Me.tpGutter.Controls.Add(Me.pnGutter)
        Me.tpGutter.Location = New System.Drawing.Point(4, 22)
        Me.tpGutter.Name = "tpGutter"
        Me.tpGutter.Size = New System.Drawing.Size(506, 118)
        Me.tpGutter.TabIndex = 0
        Me.tpGutter.Text = "Gutter"
        '
        'pnGutter
        '
        Me.pnGutter.BackColor = System.Drawing.SystemColors.Control
        Me.pnGutter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnGutter.Controls.Add(Me.gbGutter)
        Me.pnGutter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnGutter.Location = New System.Drawing.Point(0, 0)
        Me.pnGutter.Name = "pnGutter"
        Me.pnGutter.Size = New System.Drawing.Size(506, 112)
        Me.pnGutter.TabIndex = 1
        '
        'gbGutter
        '
        Me.gbGutter.Controls.Add(Me.btShowBookmarks)
        Me.gbGutter.Controls.Add(Me.chbPaintBookMarks)
        Me.gbGutter.Controls.Add(Me.chbDrawLineBookmarks)
        Me.gbGutter.Controls.Add(Me.laGutterWidth)
        Me.gbGutter.Controls.Add(Me.nudGutterWidth)
        Me.gbGutter.Controls.Add(Me.chbShowGutter)
        Me.gbGutter.Location = New System.Drawing.Point(8, 8)
        Me.gbGutter.Name = "gbGutter"
        Me.gbGutter.Size = New System.Drawing.Size(496, 96)
        Me.gbGutter.TabIndex = 0
        Me.gbGutter.TabStop = False
        Me.gbGutter.Text = "Gutter"
        '
        'btShowBookmarks
        '
        Me.btShowBookmarks.BackColor = System.Drawing.SystemColors.Control
        Me.btShowBookmarks.Location = New System.Drawing.Point(184, 48)
        Me.btShowBookmarks.Name = "btShowBookmarks"
        Me.btShowBookmarks.Size = New System.Drawing.Size(104, 23)
        Me.btShowBookmarks.TabIndex = 10
        Me.btShowBookmarks.Text = "Set Bookmarks"
        '
        'chbPaintBookMarks
        '
        Me.chbPaintBookMarks.Location = New System.Drawing.Point(8, 40)
        Me.chbPaintBookMarks.Name = "chbPaintBookMarks"
        Me.chbPaintBookMarks.Size = New System.Drawing.Size(112, 16)
        Me.chbPaintBookMarks.TabIndex = 1
        Me.chbPaintBookMarks.Text = "Paint Bookmarks"
        '
        'chbDrawLineBookmarks
        '
        Me.chbDrawLineBookmarks.Location = New System.Drawing.Point(8, 64)
        Me.chbDrawLineBookmarks.Name = "chbDrawLineBookmarks"
        Me.chbDrawLineBookmarks.Size = New System.Drawing.Size(136, 16)
        Me.chbDrawLineBookmarks.TabIndex = 2
        Me.chbDrawLineBookmarks.Text = "Draw Line Bookmarks"
        '
        'laGutterWidth
        '
        Me.laGutterWidth.AutoSize = True
        Me.laGutterWidth.Location = New System.Drawing.Point(144, 19)
        Me.laGutterWidth.Name = "laGutterWidth"
        Me.laGutterWidth.Size = New System.Drawing.Size(66, 16)
        Me.laGutterWidth.TabIndex = 6
        Me.laGutterWidth.Text = "Gutter Width"
        '
        'nudGutterWidth
        '
        Me.nudGutterWidth.Location = New System.Drawing.Point(224, 16)
        Me.nudGutterWidth.Name = "nudGutterWidth"
        Me.nudGutterWidth.Size = New System.Drawing.Size(64, 20)
        Me.nudGutterWidth.TabIndex = 8
        '
        'chbShowGutter
        '
        Me.chbShowGutter.Location = New System.Drawing.Point(8, 16)
        Me.chbShowGutter.Name = "chbShowGutter"
        Me.chbShowGutter.Size = New System.Drawing.Size(104, 16)
        Me.chbShowGutter.TabIndex = 0
        Me.chbShowGutter.Text = "Show Gutter"
        '
        'tpMargin
        '
        Me.tpMargin.Controls.Add(Me.pnMargin)
        Me.tpMargin.Location = New System.Drawing.Point(4, 22)
        Me.tpMargin.Name = "tpMargin"
        Me.tpMargin.Size = New System.Drawing.Size(506, 118)
        Me.tpMargin.TabIndex = 9
        Me.tpMargin.Text = "Margin"
        Me.tpMargin.Visible = False
        '
        'pnMargin
        '
        Me.pnMargin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnMargin.Controls.Add(Me.gbMargin)
        Me.pnMargin.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnMargin.Location = New System.Drawing.Point(0, 0)
        Me.pnMargin.Name = "pnMargin"
        Me.pnMargin.Size = New System.Drawing.Size(506, 112)
        Me.pnMargin.TabIndex = 0
        '
        'gbMargin
        '
        Me.gbMargin.Controls.Add(Me.chbColumnsVisible)
        Me.gbMargin.Controls.Add(Me.chbShowMarginHints)
        Me.gbMargin.Controls.Add(Me.chbAllowDragMargin)
        Me.gbMargin.Controls.Add(Me.nudMarginPos)
        Me.gbMargin.Controls.Add(Me.laMarginPos)
        Me.gbMargin.Controls.Add(Me.chbShowMargin)
        Me.gbMargin.Location = New System.Drawing.Point(8, 8)
        Me.gbMargin.Name = "gbMargin"
        Me.gbMargin.Size = New System.Drawing.Size(496, 96)
        Me.gbMargin.TabIndex = 0
        Me.gbMargin.TabStop = False
        Me.gbMargin.Text = "Margin"
        '
        'chbColumnsVisible
        '
        Me.chbColumnsVisible.Location = New System.Drawing.Point(168, 64)
        Me.chbColumnsVisible.Name = "chbColumnsVisible"
        Me.chbColumnsVisible.Size = New System.Drawing.Size(120, 16)
        Me.chbColumnsVisible.TabIndex = 9
        Me.chbColumnsVisible.Text = "Columns Visible"
        '
        'chbShowMarginHints
        '
        Me.chbShowMarginHints.Location = New System.Drawing.Point(168, 40)
        Me.chbShowMarginHints.Name = "chbShowMarginHints"
        Me.chbShowMarginHints.Size = New System.Drawing.Size(112, 16)
        Me.chbShowMarginHints.TabIndex = 8
        Me.chbShowMarginHints.Text = "Show Drag Hints"
        '
        'chbAllowDragMargin
        '
        Me.chbAllowDragMargin.Location = New System.Drawing.Point(168, 16)
        Me.chbAllowDragMargin.Name = "chbAllowDragMargin"
        Me.chbAllowDragMargin.Size = New System.Drawing.Size(120, 16)
        Me.chbAllowDragMargin.TabIndex = 7
        Me.chbAllowDragMargin.Text = "Allow Drag Margin"
        '
        'nudMarginPos
        '
        Me.nudMarginPos.Location = New System.Drawing.Point(88, 40)
        Me.nudMarginPos.Name = "nudMarginPos"
        Me.nudMarginPos.Size = New System.Drawing.Size(64, 20)
        Me.nudMarginPos.TabIndex = 4
        '
        'laMarginPos
        '
        Me.laMarginPos.AutoSize = True
        Me.laMarginPos.Location = New System.Drawing.Point(8, 43)
        Me.laMarginPos.Name = "laMarginPos"
        Me.laMarginPos.Size = New System.Drawing.Size(78, 16)
        Me.laMarginPos.TabIndex = 3
        Me.laMarginPos.Text = "Margin position"
        '
        'chbShowMargin
        '
        Me.chbShowMargin.Location = New System.Drawing.Point(8, 16)
        Me.chbShowMargin.Name = "chbShowMargin"
        Me.chbShowMargin.Size = New System.Drawing.Size(96, 16)
        Me.chbShowMargin.TabIndex = 0
        Me.chbShowMargin.Text = "Show Margin"
        '
        'tpOther
        '
        Me.tpOther.Controls.Add(Me.pnOther)
        Me.tpOther.Location = New System.Drawing.Point(4, 22)
        Me.tpOther.Name = "tpOther"
        Me.tpOther.Size = New System.Drawing.Size(506, 118)
        Me.tpOther.TabIndex = 12
        Me.tpOther.Text = "Other"
        Me.tpOther.Visible = False
        '
        'pnOther
        '
        Me.pnOther.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnOther.Controls.Add(Me.gbBraces)
        Me.pnOther.Controls.Add(Me.gbOther)
        Me.pnOther.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnOther.Location = New System.Drawing.Point(0, 0)
        Me.pnOther.Name = "pnOther"
        Me.pnOther.Size = New System.Drawing.Size(506, 112)
        Me.pnOther.TabIndex = 0
        '
        'gbBraces
        '
        Me.gbBraces.Controls.Add(Me.cbTempHighlightBraces)
        Me.gbBraces.Controls.Add(Me.chbUseRoundRect)
        Me.gbBraces.Controls.Add(Me.chbHighlightBraces)
        Me.gbBraces.Location = New System.Drawing.Point(272, 8)
        Me.gbBraces.Name = "gbBraces"
        Me.gbBraces.Size = New System.Drawing.Size(232, 96)
        Me.gbBraces.TabIndex = 6
        Me.gbBraces.TabStop = False
        Me.gbBraces.Text = "Braces"
        '
        'cbTempHighlightBraces
        '
        Me.cbTempHighlightBraces.Location = New System.Drawing.Point(8, 64)
        Me.cbTempHighlightBraces.Name = "cbTempHighlightBraces"
        Me.cbTempHighlightBraces.Size = New System.Drawing.Size(112, 16)
        Me.cbTempHighlightBraces.TabIndex = 3
        Me.cbTempHighlightBraces.Text = "Temp Hightlight"
        '
        'chbUseRoundRect
        '
        Me.chbUseRoundRect.Location = New System.Drawing.Point(8, 40)
        Me.chbUseRoundRect.Name = "chbUseRoundRect"
        Me.chbUseRoundRect.Size = New System.Drawing.Size(112, 16)
        Me.chbUseRoundRect.TabIndex = 2
        Me.chbUseRoundRect.Text = "Use Round Rect"
        '
        'chbHighlightBraces
        '
        Me.chbHighlightBraces.Location = New System.Drawing.Point(8, 16)
        Me.chbHighlightBraces.Name = "chbHighlightBraces"
        Me.chbHighlightBraces.Size = New System.Drawing.Size(112, 16)
        Me.chbHighlightBraces.TabIndex = 1
        Me.chbHighlightBraces.Text = "Highlight Braces"
        '
        'gbOther
        '
        Me.gbOther.Controls.Add(Me.chbDrawColumnsIndent)
        Me.gbOther.Controls.Add(Me.chbQuickInfoTips)
        Me.gbOther.Controls.Add(Me.chbTransparent)
        Me.gbOther.Controls.Add(Me.chbSeparateLines)
        Me.gbOther.Controls.Add(Me.chbWhiteSpaceVisible)
        Me.gbOther.Location = New System.Drawing.Point(8, 8)
        Me.gbOther.Name = "gbOther"
        Me.gbOther.Size = New System.Drawing.Size(256, 96)
        Me.gbOther.TabIndex = 4
        Me.gbOther.TabStop = False
        Me.gbOther.Text = "Other"
        '
        'chbDrawColumnsIndent
        '
        Me.chbDrawColumnsIndent.Location = New System.Drawing.Point(120, 40)
        Me.chbDrawColumnsIndent.Name = "chbDrawColumnsIndent"
        Me.chbDrawColumnsIndent.Size = New System.Drawing.Size(130, 16)
        Me.chbDrawColumnsIndent.TabIndex = 7
        Me.chbDrawColumnsIndent.Text = "Draw Columns Indent"
        '
        'chbQuickInfoTips
        '
        Me.chbQuickInfoTips.Location = New System.Drawing.Point(120, 16)
        Me.chbQuickInfoTips.Name = "chbQuickInfoTips"
        Me.chbQuickInfoTips.Size = New System.Drawing.Size(96, 16)
        Me.chbQuickInfoTips.TabIndex = 6
        Me.chbQuickInfoTips.Text = "Quick Info Tips"
        '
        'chbTransparent
        '
        Me.chbTransparent.Location = New System.Drawing.Point(8, 64)
        Me.chbTransparent.Name = "chbTransparent"
        Me.chbTransparent.Size = New System.Drawing.Size(112, 16)
        Me.chbTransparent.TabIndex = 3
        Me.chbTransparent.Text = "Transparent"
        '
        'chbSeparateLines
        '
        Me.chbSeparateLines.Location = New System.Drawing.Point(8, 16)
        Me.chbSeparateLines.Name = "chbSeparateLines"
        Me.chbSeparateLines.Size = New System.Drawing.Size(104, 16)
        Me.chbSeparateLines.TabIndex = 1
        Me.chbSeparateLines.Text = "Separate Lines"
        '
        'chbWhiteSpaceVisible
        '
        Me.chbWhiteSpaceVisible.Location = New System.Drawing.Point(8, 40)
        Me.chbWhiteSpaceVisible.Name = "chbWhiteSpaceVisible"
        Me.chbWhiteSpaceVisible.Size = New System.Drawing.Size(120, 16)
        Me.chbWhiteSpaceVisible.TabIndex = 2
        Me.chbWhiteSpaceVisible.Text = "Whitespace Visible"
        '
        'tpCompanyInfo
        '
        Me.tpCompanyInfo.Controls.Add(Me.pnCompanyInfo)
        Me.tpCompanyInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpCompanyInfo.Name = "tpCompanyInfo"
        Me.tpCompanyInfo.Size = New System.Drawing.Size(506, 118)
        Me.tpCompanyInfo.TabIndex = 8
        Me.tpCompanyInfo.Text = "Company Info"
        Me.tpCompanyInfo.Visible = False
        '
        'pnCompanyInfo
        '
        Me.pnCompanyInfo.BackColor = System.Drawing.SystemColors.Control
        Me.pnCompanyInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnCompanyInfo.Controls.Add(Me.tbCompanyInfo)
        Me.pnCompanyInfo.Controls.Add(Me.label7)
        Me.pnCompanyInfo.Controls.Add(Me.label6)
        Me.pnCompanyInfo.Controls.Add(Me.laMailTo)
        Me.pnCompanyInfo.Controls.Add(Me.label4)
        Me.pnCompanyInfo.Controls.Add(Me.laAdress)
        Me.pnCompanyInfo.Controls.Add(Me.label2)
        Me.pnCompanyInfo.Controls.Add(Me.laCompany)
        Me.pnCompanyInfo.Controls.Add(Me.pictureBox1)
        Me.pnCompanyInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnCompanyInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnCompanyInfo.Name = "pnCompanyInfo"
        Me.pnCompanyInfo.Size = New System.Drawing.Size(506, 118)
        Me.pnCompanyInfo.TabIndex = 0
        '
        'tbCompanyInfo
        '
        Me.tbCompanyInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tbCompanyInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCompanyInfo.Location = New System.Drawing.Point(24, 160)
        Me.tbCompanyInfo.Multiline = True
        Me.tbCompanyInfo.Name = "tbCompanyInfo"
        Me.tbCompanyInfo.Size = New System.Drawing.Size(400, 120)
        Me.tbCompanyInfo.TabIndex = 9
        Me.tbCompanyInfo.Text = "Editor.NET is an advanced code editor allowing integration of a highly flexible e" & _
        "dit control in your .NET applications." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "It has almost all the features that ca" & _
        "n be found in the Visual Studio.NET code Editor, including customizable syntax h" & _
        "ighlighting, code outlining, code completion, unlimited undo/redo, bookmarks, wo" & _
        "rd wrap, drag-n-drop, search/replace, and displaying gutter/margin/line numbers." & _
        ""
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(8, 312)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(205, 16)
        Me.label7.TabIndex = 7
        Me.label7.Text = "Copyright (c) 2004-2006 Quantum Whale"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(8, 336)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(131, 16)
        Me.label6.TabIndex = 6
        Me.label6.Text = "Quantum Whale Company"
        '
        'laMailTo
        '
        Me.laMailTo.AutoSize = True
        Me.laMailTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.laMailTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laMailTo.ForeColor = System.Drawing.Color.Blue
        Me.laMailTo.Location = New System.Drawing.Point(256, 128)
        Me.laMailTo.Name = "laMailTo"
        Me.laMailTo.Size = New System.Drawing.Size(141, 16)
        Me.laMailTo.TabIndex = 5
        Me.laMailTo.Text = "mailto:contact@qwhale.net"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(216, 128)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(38, 16)
        Me.label4.TabIndex = 4
        Me.label4.Text = "e-mail:"
        '
        'laAdress
        '
        Me.laAdress.AutoSize = True
        Me.laAdress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.laAdress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laAdress.ForeColor = System.Drawing.Color.Blue
        Me.laAdress.Location = New System.Drawing.Point(256, 104)
        Me.laAdress.Name = "laAdress"
        Me.laAdress.Size = New System.Drawing.Size(115, 16)
        Me.laAdress.TabIndex = 3
        Me.laAdress.Text = "http://www.qwhale.net"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(216, 104)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(38, 16)
        Me.label2.TabIndex = 2
        Me.label2.Text = "WWW:"
        '
        'laCompany
        '
        Me.laCompany.AutoSize = True
        Me.laCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laCompany.ForeColor = System.Drawing.Color.MidnightBlue
        Me.laCompany.Location = New System.Drawing.Point(200, 28)
        Me.laCompany.Name = "laCompany"
        Me.laCompany.Size = New System.Drawing.Size(311, 49)
        Me.laCompany.TabIndex = 1
        Me.laCompany.Text = "Quantum Whale"
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(8, 16)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(180, 80)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox1.TabIndex = 0
        Me.pictureBox1.TabStop = False
        '
        'tpWordWrap
        '
        Me.tpWordWrap.Controls.Add(Me.pnWordWrap)
        Me.tpWordWrap.Location = New System.Drawing.Point(4, 22)
        Me.tpWordWrap.Name = "tpWordWrap"
        Me.tpWordWrap.Size = New System.Drawing.Size(506, 118)
        Me.tpWordWrap.TabIndex = 1
        Me.tpWordWrap.Text = "WordWrap"
        Me.tpWordWrap.Visible = False
        '
        'pnWordWrap
        '
        Me.pnWordWrap.BackColor = System.Drawing.SystemColors.Control
        Me.pnWordWrap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnWordWrap.Controls.Add(Me.gbWordWrap)
        Me.pnWordWrap.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnWordWrap.Location = New System.Drawing.Point(0, 0)
        Me.pnWordWrap.Name = "pnWordWrap"
        Me.pnWordWrap.Size = New System.Drawing.Size(506, 112)
        Me.pnWordWrap.TabIndex = 1
        '
        'gbWordWrap
        '
        Me.gbWordWrap.Controls.Add(Me.chbFlatScrollBars)
        Me.gbWordWrap.Controls.Add(Me.chbSystemScrollBars)
        Me.gbWordWrap.Controls.Add(Me.chbScrollButtons)
        Me.gbWordWrap.Controls.Add(Me.chbAllowSplit)
        Me.gbWordWrap.Controls.Add(Me.chbWrapAtMargin)
        Me.gbWordWrap.Controls.Add(Me.chbWordWrap)
        Me.gbWordWrap.Controls.Add(Me.chbShowScrollHint)
        Me.gbWordWrap.Controls.Add(Me.chbSmoothScroll)
        Me.gbWordWrap.Location = New System.Drawing.Point(8, 8)
        Me.gbWordWrap.Name = "gbWordWrap"
        Me.gbWordWrap.Size = New System.Drawing.Size(496, 96)
        Me.gbWordWrap.TabIndex = 13
        Me.gbWordWrap.TabStop = False
        Me.gbWordWrap.Text = "Word Wrap && Scrolling"
        '
        'chbFlatScrollBars
        '
        Me.chbFlatScrollBars.Location = New System.Drawing.Point(288, 40)
        Me.chbFlatScrollBars.Name = "chbFlatScrollBars"
        Me.chbFlatScrollBars.TabIndex = 12
        Me.chbFlatScrollBars.Text = "Flat Scroll"
        '
        'chbSystemScrollBars
        '
        Me.chbSystemScrollBars.Location = New System.Drawing.Point(288, 16)
        Me.chbSystemScrollBars.Name = "chbSystemScrollBars"
        Me.chbSystemScrollBars.TabIndex = 11
        Me.chbSystemScrollBars.Text = "System Scroll"
        '
        'chbScrollButtons
        '
        Me.chbScrollButtons.Location = New System.Drawing.Point(144, 64)
        Me.chbScrollButtons.Name = "chbScrollButtons"
        Me.chbScrollButtons.Size = New System.Drawing.Size(104, 16)
        Me.chbScrollButtons.TabIndex = 10
        Me.chbScrollButtons.Text = "Scroll Buttons"
        '
        'chbAllowSplit
        '
        Me.chbAllowSplit.Location = New System.Drawing.Point(144, 40)
        Me.chbAllowSplit.Name = "chbAllowSplit"
        Me.chbAllowSplit.Size = New System.Drawing.Size(104, 16)
        Me.chbAllowSplit.TabIndex = 9
        Me.chbAllowSplit.Text = "Allow Split"
        '
        'chbWrapAtMargin
        '
        Me.chbWrapAtMargin.Location = New System.Drawing.Point(8, 40)
        Me.chbWrapAtMargin.Name = "chbWrapAtMargin"
        Me.chbWrapAtMargin.Size = New System.Drawing.Size(104, 16)
        Me.chbWrapAtMargin.TabIndex = 1
        Me.chbWrapAtMargin.Text = "Wrap at Margin"
        '
        'chbWordWrap
        '
        Me.chbWordWrap.Location = New System.Drawing.Point(8, 16)
        Me.chbWordWrap.Name = "chbWordWrap"
        Me.chbWordWrap.Size = New System.Drawing.Size(104, 16)
        Me.chbWordWrap.TabIndex = 0
        Me.chbWordWrap.Text = "Word Wrap"
        '
        'chbShowScrollHint
        '
        Me.chbShowScrollHint.Location = New System.Drawing.Point(8, 64)
        Me.chbShowScrollHint.Name = "chbShowScrollHint"
        Me.chbShowScrollHint.Size = New System.Drawing.Size(112, 16)
        Me.chbShowScrollHint.TabIndex = 3
        Me.chbShowScrollHint.Text = "Show Scroll Hint"
        '
        'chbSmoothScroll
        '
        Me.chbSmoothScroll.Location = New System.Drawing.Point(144, 16)
        Me.chbSmoothScroll.Name = "chbSmoothScroll"
        Me.chbSmoothScroll.Size = New System.Drawing.Size(104, 16)
        Me.chbSmoothScroll.TabIndex = 4
        Me.chbSmoothScroll.Text = "Smooth Scroll"
        '
        'tpLineNumbers
        '
        Me.tpLineNumbers.Controls.Add(Me.pnLineNumbers)
        Me.tpLineNumbers.Location = New System.Drawing.Point(4, 22)
        Me.tpLineNumbers.Name = "tpLineNumbers"
        Me.tpLineNumbers.Size = New System.Drawing.Size(506, 118)
        Me.tpLineNumbers.TabIndex = 10
        Me.tpLineNumbers.Text = "Line Numbers"
        Me.tpLineNumbers.Visible = False
        '
        'pnLineNumbers
        '
        Me.pnLineNumbers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnLineNumbers.Controls.Add(Me.gbLineNumbers)
        Me.pnLineNumbers.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnLineNumbers.Location = New System.Drawing.Point(0, 0)
        Me.pnLineNumbers.Name = "pnLineNumbers"
        Me.pnLineNumbers.Size = New System.Drawing.Size(506, 112)
        Me.pnLineNumbers.TabIndex = 0
        '
        'gbLineNumbers
        '
        Me.gbLineNumbers.Controls.Add(Me.chbLineModificator)
        Me.gbLineNumbers.Controls.Add(Me.laLineNumbersStart)
        Me.gbLineNumbers.Controls.Add(Me.nudLineNumbersStart)
        Me.gbLineNumbers.Controls.Add(Me.cbLineNumbersAlign)
        Me.gbLineNumbers.Controls.Add(Me.laLineNumbersAlign)
        Me.gbLineNumbers.Controls.Add(Me.chbLinesOnGutter)
        Me.gbLineNumbers.Controls.Add(Me.chbLineNumbers)
        Me.gbLineNumbers.Controls.Add(Me.chbLinesBeyondEof)
        Me.gbLineNumbers.Controls.Add(Me.chbHighlightCurrentLine)
        Me.gbLineNumbers.Location = New System.Drawing.Point(8, 8)
        Me.gbLineNumbers.Name = "gbLineNumbers"
        Me.gbLineNumbers.Size = New System.Drawing.Size(496, 96)
        Me.gbLineNumbers.TabIndex = 3
        Me.gbLineNumbers.TabStop = False
        Me.gbLineNumbers.Text = "Line Numbers"
        '
        'chbLineModificator
        '
        Me.chbLineModificator.Checked = True
        Me.chbLineModificator.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbLineModificator.Location = New System.Drawing.Point(144, 16)
        Me.chbLineModificator.Name = "chbLineModificator"
        Me.chbLineModificator.Size = New System.Drawing.Size(112, 16)
        Me.chbLineModificator.TabIndex = 3
        Me.chbLineModificator.Text = "Line Modificators"
        '
        'laLineNumbersStart
        '
        Me.laLineNumbersStart.AutoSize = True
        Me.laLineNumbersStart.Location = New System.Drawing.Point(296, 19)
        Me.laLineNumbersStart.Name = "laLineNumbersStart"
        Me.laLineNumbersStart.Size = New System.Drawing.Size(95, 16)
        Me.laLineNumbersStart.TabIndex = 5
        Me.laLineNumbersStart.Text = "Line numbers start"
        '
        'nudLineNumbersStart
        '
        Me.nudLineNumbersStart.Location = New System.Drawing.Point(400, 16)
        Me.nudLineNumbersStart.Name = "nudLineNumbersStart"
        Me.nudLineNumbersStart.Size = New System.Drawing.Size(64, 20)
        Me.nudLineNumbersStart.TabIndex = 6
        '
        'cbLineNumbersAlign
        '
        Me.cbLineNumbersAlign.ItemHeight = 13
        Me.cbLineNumbersAlign.Location = New System.Drawing.Point(400, 40)
        Me.cbLineNumbersAlign.Name = "cbLineNumbersAlign"
        Me.cbLineNumbersAlign.Size = New System.Drawing.Size(64, 21)
        Me.cbLineNumbersAlign.TabIndex = 8
        '
        'laLineNumbersAlign
        '
        Me.laLineNumbersAlign.AutoSize = True
        Me.laLineNumbersAlign.Location = New System.Drawing.Point(296, 43)
        Me.laLineNumbersAlign.Name = "laLineNumbersAlign"
        Me.laLineNumbersAlign.Size = New System.Drawing.Size(96, 16)
        Me.laLineNumbersAlign.TabIndex = 7
        Me.laLineNumbersAlign.Text = "Line numbers align"
        '
        'chbLinesOnGutter
        '
        Me.chbLinesOnGutter.Location = New System.Drawing.Point(8, 40)
        Me.chbLinesOnGutter.Name = "chbLinesOnGutter"
        Me.chbLinesOnGutter.Size = New System.Drawing.Size(104, 16)
        Me.chbLinesOnGutter.TabIndex = 1
        Me.chbLinesOnGutter.Text = "Lines on Gutter"
        '
        'chbLineNumbers
        '
        Me.chbLineNumbers.Location = New System.Drawing.Point(8, 16)
        Me.chbLineNumbers.Name = "chbLineNumbers"
        Me.chbLineNumbers.Size = New System.Drawing.Size(104, 16)
        Me.chbLineNumbers.TabIndex = 0
        Me.chbLineNumbers.Text = "Line Numbers"
        '
        'chbLinesBeyondEof
        '
        Me.chbLinesBeyondEof.Location = New System.Drawing.Point(8, 64)
        Me.chbLinesBeyondEof.Name = "chbLinesBeyondEof"
        Me.chbLinesBeyondEof.Size = New System.Drawing.Size(112, 16)
        Me.chbLinesBeyondEof.TabIndex = 2
        Me.chbLinesBeyondEof.Text = "Lines Beyond Eof"
        '
        'chbHighlightCurrentLine
        '
        Me.chbHighlightCurrentLine.Location = New System.Drawing.Point(144, 40)
        Me.chbHighlightCurrentLine.Name = "chbHighlightCurrentLine"
        Me.chbHighlightCurrentLine.Size = New System.Drawing.Size(136, 16)
        Me.chbHighlightCurrentLine.TabIndex = 4
        Me.chbHighlightCurrentLine.Text = "Highlight Current Line"
        '
        'tpNavigate
        '
        Me.tpNavigate.Controls.Add(Me.pnNavigate)
        Me.tpNavigate.Location = New System.Drawing.Point(4, 22)
        Me.tpNavigate.Name = "tpNavigate"
        Me.tpNavigate.Size = New System.Drawing.Size(506, 118)
        Me.tpNavigate.TabIndex = 7
        Me.tpNavigate.Text = "Navigate"
        Me.tpNavigate.Visible = False
        '
        'pnNavigate
        '
        Me.pnNavigate.BackColor = System.Drawing.SystemColors.Control
        Me.pnNavigate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnNavigate.Controls.Add(Me.gbNavigateOptions)
        Me.pnNavigate.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnNavigate.Location = New System.Drawing.Point(0, 0)
        Me.pnNavigate.Name = "pnNavigate"
        Me.pnNavigate.Size = New System.Drawing.Size(506, 112)
        Me.pnNavigate.TabIndex = 1
        '
        'gbNavigateOptions
        '
        Me.gbNavigateOptions.Controls.Add(Me.chbMoveOnRightButton)
        Me.gbNavigateOptions.Controls.Add(Me.chbDownAtLineEnd)
        Me.gbNavigateOptions.Controls.Add(Me.chbUpAtLineBegin)
        Me.gbNavigateOptions.Controls.Add(Me.chbBeyondEof)
        Me.gbNavigateOptions.Controls.Add(Me.chbBeyondEol)
        Me.gbNavigateOptions.Location = New System.Drawing.Point(8, 8)
        Me.gbNavigateOptions.Name = "gbNavigateOptions"
        Me.gbNavigateOptions.Size = New System.Drawing.Size(496, 96)
        Me.gbNavigateOptions.TabIndex = 0
        Me.gbNavigateOptions.TabStop = False
        Me.gbNavigateOptions.Text = "Navigate Options"
        '
        'chbMoveOnRightButton
        '
        Me.chbMoveOnRightButton.Location = New System.Drawing.Point(144, 64)
        Me.chbMoveOnRightButton.Name = "chbMoveOnRightButton"
        Me.chbMoveOnRightButton.Size = New System.Drawing.Size(136, 24)
        Me.chbMoveOnRightButton.TabIndex = 4
        Me.chbMoveOnRightButton.Text = "Move on Right Button"
        '
        'chbDownAtLineEnd
        '
        Me.chbDownAtLineEnd.Location = New System.Drawing.Point(144, 40)
        Me.chbDownAtLineEnd.Name = "chbDownAtLineEnd"
        Me.chbDownAtLineEnd.Size = New System.Drawing.Size(112, 24)
        Me.chbDownAtLineEnd.TabIndex = 3
        Me.chbDownAtLineEnd.Text = "Down at Line End"
        '
        'chbUpAtLineBegin
        '
        Me.chbUpAtLineBegin.Location = New System.Drawing.Point(144, 16)
        Me.chbUpAtLineBegin.Name = "chbUpAtLineBegin"
        Me.chbUpAtLineBegin.Size = New System.Drawing.Size(112, 24)
        Me.chbUpAtLineBegin.TabIndex = 2
        Me.chbUpAtLineBegin.Text = "Up at Line Begin"
        '
        'chbBeyondEof
        '
        Me.chbBeyondEof.Location = New System.Drawing.Point(8, 40)
        Me.chbBeyondEof.Name = "chbBeyondEof"
        Me.chbBeyondEof.TabIndex = 1
        Me.chbBeyondEof.Text = "Beyond Eof"
        '
        'chbBeyondEol
        '
        Me.chbBeyondEol.Location = New System.Drawing.Point(8, 16)
        Me.chbBeyondEol.Name = "chbBeyondEol"
        Me.chbBeyondEol.TabIndex = 0
        Me.chbBeyondEol.Text = "Beyond Eol"
        '
        'tpTextSource
        '
        Me.tpTextSource.Controls.Add(Me.pnTextSource)
        Me.tpTextSource.Location = New System.Drawing.Point(4, 22)
        Me.tpTextSource.Name = "tpTextSource"
        Me.tpTextSource.Size = New System.Drawing.Size(506, 118)
        Me.tpTextSource.TabIndex = 6
        Me.tpTextSource.Text = "Text Source"
        Me.tpTextSource.Visible = False
        '
        'pnTextSource
        '
        Me.pnTextSource.BackColor = System.Drawing.SystemColors.Control
        Me.pnTextSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnTextSource.Controls.Add(Me.laSource)
        Me.pnTextSource.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnTextSource.Location = New System.Drawing.Point(0, 0)
        Me.pnTextSource.Name = "pnTextSource"
        Me.pnTextSource.Size = New System.Drawing.Size(506, 73)
        Me.pnTextSource.TabIndex = 4
        '
        'laSource
        '
        Me.laSource.AutoSize = True
        Me.laSource.Location = New System.Drawing.Point(160, 24)
        Me.laSource.Name = "laSource"
        Me.laSource.Size = New System.Drawing.Size(213, 16)
        Me.laSource.TabIndex = 0
        Me.laSource.Text = "Several Editor can work with the same text"
        '
        'tpOutlining
        '
        Me.tpOutlining.Controls.Add(Me.pnOutlining)
        Me.tpOutlining.Location = New System.Drawing.Point(4, 22)
        Me.tpOutlining.Name = "tpOutlining"
        Me.tpOutlining.Size = New System.Drawing.Size(506, 118)
        Me.tpOutlining.TabIndex = 4
        Me.tpOutlining.Text = "Outlining"
        Me.tpOutlining.Visible = False
        '
        'pnOutlining
        '
        Me.pnOutlining.BackColor = System.Drawing.SystemColors.Control
        Me.pnOutlining.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnOutlining.Controls.Add(Me.gbOutlining)
        Me.pnOutlining.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnOutlining.Location = New System.Drawing.Point(0, 0)
        Me.pnOutlining.Name = "pnOutlining"
        Me.pnOutlining.Size = New System.Drawing.Size(506, 112)
        Me.pnOutlining.TabIndex = 3
        '
        'gbOutlining
        '
        Me.gbOutlining.BackColor = System.Drawing.SystemColors.Control
        Me.gbOutlining.Controls.Add(Me.chbAllowOutlining)
        Me.gbOutlining.Controls.Add(Me.chbDrawButtons)
        Me.gbOutlining.Controls.Add(Me.chbDrawLines)
        Me.gbOutlining.Controls.Add(Me.chbDrawOnGutter)
        Me.gbOutlining.Controls.Add(Me.chbShowHints)
        Me.gbOutlining.Location = New System.Drawing.Point(8, 8)
        Me.gbOutlining.Name = "gbOutlining"
        Me.gbOutlining.Size = New System.Drawing.Size(496, 96)
        Me.gbOutlining.TabIndex = 5
        Me.gbOutlining.TabStop = False
        Me.gbOutlining.Text = "Outlining"
        '
        'chbAllowOutlining
        '
        Me.chbAllowOutlining.BackColor = System.Drawing.SystemColors.Control
        Me.chbAllowOutlining.Location = New System.Drawing.Point(8, 16)
        Me.chbAllowOutlining.Name = "chbAllowOutlining"
        Me.chbAllowOutlining.Size = New System.Drawing.Size(104, 16)
        Me.chbAllowOutlining.TabIndex = 0
        Me.chbAllowOutlining.Text = "Allow Outlining"
        '
        'chbDrawButtons
        '
        Me.chbDrawButtons.BackColor = System.Drawing.SystemColors.Control
        Me.chbDrawButtons.Location = New System.Drawing.Point(144, 16)
        Me.chbDrawButtons.Name = "chbDrawButtons"
        Me.chbDrawButtons.Size = New System.Drawing.Size(104, 16)
        Me.chbDrawButtons.TabIndex = 3
        Me.chbDrawButtons.Text = "Draw Buttons"
        '
        'chbDrawLines
        '
        Me.chbDrawLines.BackColor = System.Drawing.SystemColors.Control
        Me.chbDrawLines.Location = New System.Drawing.Point(8, 64)
        Me.chbDrawLines.Name = "chbDrawLines"
        Me.chbDrawLines.Size = New System.Drawing.Size(104, 16)
        Me.chbDrawLines.TabIndex = 2
        Me.chbDrawLines.Text = "Draw Lines"
        '
        'chbDrawOnGutter
        '
        Me.chbDrawOnGutter.BackColor = System.Drawing.SystemColors.Control
        Me.chbDrawOnGutter.Location = New System.Drawing.Point(8, 40)
        Me.chbDrawOnGutter.Name = "chbDrawOnGutter"
        Me.chbDrawOnGutter.Size = New System.Drawing.Size(104, 16)
        Me.chbDrawOnGutter.TabIndex = 1
        Me.chbDrawOnGutter.Text = "Draw on Gutter"
        '
        'chbShowHints
        '
        Me.chbShowHints.BackColor = System.Drawing.SystemColors.Control
        Me.chbShowHints.Location = New System.Drawing.Point(144, 40)
        Me.chbShowHints.Name = "chbShowHints"
        Me.chbShowHints.Size = New System.Drawing.Size(104, 16)
        Me.chbShowHints.TabIndex = 4
        Me.chbShowHints.Text = "Show Hints"
        '
        'tpDialogs
        '
        Me.tpDialogs.Controls.Add(Me.pnDialogs)
        Me.tpDialogs.Location = New System.Drawing.Point(4, 22)
        Me.tpDialogs.Name = "tpDialogs"
        Me.tpDialogs.Size = New System.Drawing.Size(506, 118)
        Me.tpDialogs.TabIndex = 2
        Me.tpDialogs.Text = "Dialogs"
        Me.tpDialogs.Visible = False
        '
        'pnDialogs
        '
        Me.pnDialogs.BackColor = System.Drawing.SystemColors.Control
        Me.pnDialogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnDialogs.Controls.Add(Me.gbDialogs)
        Me.pnDialogs.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDialogs.Location = New System.Drawing.Point(0, 0)
        Me.pnDialogs.Name = "pnDialogs"
        Me.pnDialogs.Size = New System.Drawing.Size(506, 112)
        Me.pnDialogs.TabIndex = 1
        '
        'gbDialogs
        '
        Me.gbDialogs.Controls.Add(Me.btCustomize)
        Me.gbDialogs.Controls.Add(Me.btGoto)
        Me.gbDialogs.Controls.Add(Me.btReplace)
        Me.gbDialogs.Controls.Add(Me.btFind)
        Me.gbDialogs.Controls.Add(Me.btSave)
        Me.gbDialogs.Controls.Add(Me.btLoad)
        Me.gbDialogs.Location = New System.Drawing.Point(8, 8)
        Me.gbDialogs.Name = "gbDialogs"
        Me.gbDialogs.Size = New System.Drawing.Size(496, 96)
        Me.gbDialogs.TabIndex = 6
        Me.gbDialogs.TabStop = False
        Me.gbDialogs.Text = "Dialogs"
        '
        'btCustomize
        '
        Me.btCustomize.BackColor = System.Drawing.SystemColors.Control
        Me.btCustomize.Location = New System.Drawing.Point(200, 56)
        Me.btCustomize.Name = "btCustomize"
        Me.btCustomize.Size = New System.Drawing.Size(80, 23)
        Me.btCustomize.TabIndex = 11
        Me.btCustomize.Text = "Customize"
        '
        'btGoto
        '
        Me.btGoto.BackColor = System.Drawing.SystemColors.Control
        Me.btGoto.Location = New System.Drawing.Point(200, 24)
        Me.btGoto.Name = "btGoto"
        Me.btGoto.Size = New System.Drawing.Size(80, 23)
        Me.btGoto.TabIndex = 10
        Me.btGoto.Text = "Go to Line"
        '
        'btReplace
        '
        Me.btReplace.BackColor = System.Drawing.SystemColors.Control
        Me.btReplace.Location = New System.Drawing.Point(104, 56)
        Me.btReplace.Name = "btReplace"
        Me.btReplace.Size = New System.Drawing.Size(80, 23)
        Me.btReplace.TabIndex = 9
        Me.btReplace.Text = "Replace"
        '
        'btFind
        '
        Me.btFind.BackColor = System.Drawing.SystemColors.Control
        Me.btFind.Location = New System.Drawing.Point(104, 24)
        Me.btFind.Name = "btFind"
        Me.btFind.Size = New System.Drawing.Size(80, 23)
        Me.btFind.TabIndex = 8
        Me.btFind.Text = "Find"
        '
        'btSave
        '
        Me.btSave.BackColor = System.Drawing.SystemColors.Control
        Me.btSave.Location = New System.Drawing.Point(8, 56)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(80, 23)
        Me.btSave.TabIndex = 7
        Me.btSave.Text = "Save"
        '
        'btLoad
        '
        Me.btLoad.BackColor = System.Drawing.SystemColors.Control
        Me.btLoad.Location = New System.Drawing.Point(8, 24)
        Me.btLoad.Name = "btLoad"
        Me.btLoad.Size = New System.Drawing.Size(80, 23)
        Me.btLoad.TabIndex = 6
        Me.btLoad.Text = "Load"
        '
        'tpProperties
        '
        Me.tpProperties.Controls.Add(Me.pnProperties)
        Me.tpProperties.Location = New System.Drawing.Point(4, 22)
        Me.tpProperties.Name = "tpProperties"
        Me.tpProperties.Size = New System.Drawing.Size(506, 118)
        Me.tpProperties.TabIndex = 14
        Me.tpProperties.Text = "Properties"
        '
        'pnProperties
        '
        Me.pnProperties.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnProperties.Location = New System.Drawing.Point(0, 0)
        Me.pnProperties.Name = "pnProperties"
        Me.pnProperties.Size = New System.Drawing.Size(506, 0)
        Me.pnProperties.TabIndex = 0
        '
        'tpPages
        '
        Me.tpPages.Controls.Add(Me.pnPageLayout)
        Me.tpPages.Location = New System.Drawing.Point(4, 22)
        Me.tpPages.Name = "tpPages"
        Me.tpPages.Size = New System.Drawing.Size(506, 118)
        Me.tpPages.TabIndex = 13
        Me.tpPages.Text = "Page Layout"
        Me.tpPages.Visible = False
        '
        'pnPageLayout
        '
        Me.pnPageLayout.Controls.Add(Me.gbPages)
        Me.pnPageLayout.Controls.Add(Me.gbRulers)
        Me.pnPageLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPageLayout.Location = New System.Drawing.Point(0, 0)
        Me.pnPageLayout.Name = "pnPageLayout"
        Me.pnPageLayout.Size = New System.Drawing.Size(506, 112)
        Me.pnPageLayout.TabIndex = 17
        '
        'gbPages
        '
        Me.gbPages.Controls.Add(Me.cbPageSize)
        Me.gbPages.Controls.Add(Me.laPageSize)
        Me.gbPages.Controls.Add(Me.cbPageLayout)
        Me.gbPages.Controls.Add(Me.laPageLayout)
        Me.gbPages.Location = New System.Drawing.Point(8, 8)
        Me.gbPages.Name = "gbPages"
        Me.gbPages.Size = New System.Drawing.Size(192, 96)
        Me.gbPages.TabIndex = 15
        Me.gbPages.TabStop = False
        Me.gbPages.Text = "Pages"
        '
        'cbPageSize
        '
        Me.cbPageSize.Location = New System.Drawing.Point(88, 48)
        Me.cbPageSize.Name = "cbPageSize"
        Me.cbPageSize.Size = New System.Drawing.Size(96, 21)
        Me.cbPageSize.TabIndex = 4
        '
        'laPageSize
        '
        Me.laPageSize.AutoSize = True
        Me.laPageSize.Location = New System.Drawing.Point(8, 48)
        Me.laPageSize.Name = "laPageSize"
        Me.laPageSize.Size = New System.Drawing.Size(50, 16)
        Me.laPageSize.TabIndex = 3
        Me.laPageSize.Text = "Page Size"
        '
        'cbPageLayout
        '
        Me.cbPageLayout.Location = New System.Drawing.Point(88, 24)
        Me.cbPageLayout.Name = "cbPageLayout"
        Me.cbPageLayout.Size = New System.Drawing.Size(96, 21)
        Me.cbPageLayout.TabIndex = 2
        '
        'laPageLayout
        '
        Me.laPageLayout.AutoSize = True
        Me.laPageLayout.Location = New System.Drawing.Point(8, 24)
        Me.laPageLayout.Name = "laPageLayout"
        Me.laPageLayout.Size = New System.Drawing.Size(64, 16)
        Me.laPageLayout.TabIndex = 1
        Me.laPageLayout.Text = "Page Layout"
        '
        'gbRulers
        '
        Me.gbRulers.Controls.Add(Me.chbVertRuler)
        Me.gbRulers.Controls.Add(Me.chbHorzRuler)
        Me.gbRulers.Controls.Add(Me.cbRulerUnits)
        Me.gbRulers.Controls.Add(Me.laRulerUnits)
        Me.gbRulers.Controls.Add(Me.chbRulerDisplayDragLines)
        Me.gbRulers.Controls.Add(Me.chbRulerDiscrete)
        Me.gbRulers.Controls.Add(Me.chbRulerAllowDrag)
        Me.gbRulers.Location = New System.Drawing.Point(208, 8)
        Me.gbRulers.Name = "gbRulers"
        Me.gbRulers.Size = New System.Drawing.Size(296, 96)
        Me.gbRulers.TabIndex = 16
        Me.gbRulers.TabStop = False
        Me.gbRulers.Text = "Rulers"
        '
        'chbVertRuler
        '
        Me.chbVertRuler.Location = New System.Drawing.Point(16, 40)
        Me.chbVertRuler.Name = "chbVertRuler"
        Me.chbVertRuler.Size = New System.Drawing.Size(104, 16)
        Me.chbVertRuler.TabIndex = 2
        Me.chbVertRuler.Text = "Vert Ruler"
        '
        'chbHorzRuler
        '
        Me.chbHorzRuler.Location = New System.Drawing.Point(16, 16)
        Me.chbHorzRuler.Name = "chbHorzRuler"
        Me.chbHorzRuler.Size = New System.Drawing.Size(104, 16)
        Me.chbHorzRuler.TabIndex = 1
        Me.chbHorzRuler.Text = "Horz Ruler"
        '
        'cbRulerUnits
        '
        Me.cbRulerUnits.Location = New System.Drawing.Point(72, 64)
        Me.cbRulerUnits.Name = "cbRulerUnits"
        Me.cbRulerUnits.Size = New System.Drawing.Size(96, 21)
        Me.cbRulerUnits.TabIndex = 4
        '
        'laRulerUnits
        '
        Me.laRulerUnits.AutoSize = True
        Me.laRulerUnits.Location = New System.Drawing.Point(8, 64)
        Me.laRulerUnits.Name = "laRulerUnits"
        Me.laRulerUnits.Size = New System.Drawing.Size(57, 16)
        Me.laRulerUnits.TabIndex = 3
        Me.laRulerUnits.Text = "Ruler Units"
        '
        'chbRulerDisplayDragLines
        '
        Me.chbRulerDisplayDragLines.Location = New System.Drawing.Point(176, 64)
        Me.chbRulerDisplayDragLines.Name = "chbRulerDisplayDragLines"
        Me.chbRulerDisplayDragLines.Size = New System.Drawing.Size(118, 16)
        Me.chbRulerDisplayDragLines.TabIndex = 7
        Me.chbRulerDisplayDragLines.Text = "Display Drag Lines"
        '
        'chbRulerDiscrete
        '
        Me.chbRulerDiscrete.Location = New System.Drawing.Point(176, 40)
        Me.chbRulerDiscrete.Name = "chbRulerDiscrete"
        Me.chbRulerDiscrete.Size = New System.Drawing.Size(104, 16)
        Me.chbRulerDiscrete.TabIndex = 6
        Me.chbRulerDiscrete.Text = "Discrete"
        '
        'chbRulerAllowDrag
        '
        Me.chbRulerAllowDrag.Location = New System.Drawing.Point(176, 16)
        Me.chbRulerAllowDrag.Name = "chbRulerAllowDrag"
        Me.chbRulerAllowDrag.Size = New System.Drawing.Size(104, 16)
        Me.chbRulerAllowDrag.TabIndex = 5
        Me.chbRulerAllowDrag.Text = "Allow Drag"
        '
        'tpSelection
        '
        Me.tpSelection.Controls.Add(Me.pnSelection)
        Me.tpSelection.Location = New System.Drawing.Point(4, 22)
        Me.tpSelection.Name = "tpSelection"
        Me.tpSelection.Size = New System.Drawing.Size(506, 118)
        Me.tpSelection.TabIndex = 11
        Me.tpSelection.Text = "Selection"
        Me.tpSelection.Visible = False
        '
        'pnSelection
        '
        Me.pnSelection.BackColor = System.Drawing.SystemColors.Control
        Me.pnSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnSelection.Controls.Add(Me.gbSelection)
        Me.pnSelection.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSelection.Location = New System.Drawing.Point(0, 0)
        Me.pnSelection.Name = "pnSelection"
        Me.pnSelection.Size = New System.Drawing.Size(506, 112)
        Me.pnSelection.TabIndex = 0
        '
        'gbSelection
        '
        Me.gbSelection.Controls.Add(Me.chbOverwriteBlocks)
        Me.gbSelection.Controls.Add(Me.chbPersistentBlocks)
        Me.gbSelection.Controls.Add(Me.chbDeselectOnCopy)
        Me.gbSelection.Controls.Add(Me.chbSelectLineOnDblClick)
        Me.gbSelection.Controls.Add(Me.chbHideSelection)
        Me.gbSelection.Controls.Add(Me.chbUseColors)
        Me.gbSelection.Controls.Add(Me.chbSelectBeyondEol)
        Me.gbSelection.Controls.Add(Me.chbDisableDragging)
        Me.gbSelection.Controls.Add(Me.chbDisableSelection)
        Me.gbSelection.Location = New System.Drawing.Point(8, 8)
        Me.gbSelection.Name = "gbSelection"
        Me.gbSelection.Size = New System.Drawing.Size(496, 96)
        Me.gbSelection.TabIndex = 2
        Me.gbSelection.TabStop = False
        Me.gbSelection.Text = "Selection Options"
        '
        'chbOverwriteBlocks
        '
        Me.chbOverwriteBlocks.Location = New System.Drawing.Point(296, 64)
        Me.chbOverwriteBlocks.Name = "chbOverwriteBlocks"
        Me.chbOverwriteBlocks.Size = New System.Drawing.Size(112, 24)
        Me.chbOverwriteBlocks.TabIndex = 13
        Me.chbOverwriteBlocks.Text = "Overwrite Blocks"
        '
        'chbPersistentBlocks
        '
        Me.chbPersistentBlocks.Location = New System.Drawing.Point(296, 40)
        Me.chbPersistentBlocks.Name = "chbPersistentBlocks"
        Me.chbPersistentBlocks.Size = New System.Drawing.Size(112, 24)
        Me.chbPersistentBlocks.TabIndex = 12
        Me.chbPersistentBlocks.Text = "Persistent Blocks"
        '
        'chbDeselectOnCopy
        '
        Me.chbDeselectOnCopy.Location = New System.Drawing.Point(296, 16)
        Me.chbDeselectOnCopy.Name = "chbDeselectOnCopy"
        Me.chbDeselectOnCopy.Size = New System.Drawing.Size(112, 24)
        Me.chbDeselectOnCopy.TabIndex = 11
        Me.chbDeselectOnCopy.Text = "Deselect on Copy"
        '
        'chbSelectLineOnDblClick
        '
        Me.chbSelectLineOnDblClick.Location = New System.Drawing.Point(144, 64)
        Me.chbSelectLineOnDblClick.Name = "chbSelectLineOnDblClick"
        Me.chbSelectLineOnDblClick.Size = New System.Drawing.Size(140, 24)
        Me.chbSelectLineOnDblClick.TabIndex = 10
        Me.chbSelectLineOnDblClick.Text = "Select Line on DblClick"
        '
        'chbHideSelection
        '
        Me.chbHideSelection.Location = New System.Drawing.Point(144, 40)
        Me.chbHideSelection.Name = "chbHideSelection"
        Me.chbHideSelection.TabIndex = 9
        Me.chbHideSelection.Text = "Hide Selection"
        '
        'chbUseColors
        '
        Me.chbUseColors.Location = New System.Drawing.Point(144, 16)
        Me.chbUseColors.Name = "chbUseColors"
        Me.chbUseColors.TabIndex = 8
        Me.chbUseColors.Text = "Use Colors"
        '
        'chbSelectBeyondEol
        '
        Me.chbSelectBeyondEol.Location = New System.Drawing.Point(8, 64)
        Me.chbSelectBeyondEol.Name = "chbSelectBeyondEol"
        Me.chbSelectBeyondEol.Size = New System.Drawing.Size(120, 24)
        Me.chbSelectBeyondEol.TabIndex = 7
        Me.chbSelectBeyondEol.Text = "Select Beyond Eol"
        '
        'chbDisableDragging
        '
        Me.chbDisableDragging.Location = New System.Drawing.Point(8, 40)
        Me.chbDisableDragging.Name = "chbDisableDragging"
        Me.chbDisableDragging.Size = New System.Drawing.Size(112, 24)
        Me.chbDisableDragging.TabIndex = 6
        Me.chbDisableDragging.Text = "Disable Dragging"
        '
        'chbDisableSelection
        '
        Me.chbDisableSelection.Location = New System.Drawing.Point(8, 16)
        Me.chbDisableSelection.Name = "chbDisableSelection"
        Me.chbDisableSelection.Size = New System.Drawing.Size(112, 24)
        Me.chbDisableSelection.TabIndex = 5
        Me.chbDisableSelection.Text = "Disable Selection"
        '
        'tpSpellAndUrl
        '
        Me.tpSpellAndUrl.Controls.Add(Me.pnSpellAndUrl)
        Me.tpSpellAndUrl.Location = New System.Drawing.Point(4, 22)
        Me.tpSpellAndUrl.Name = "tpSpellAndUrl"
        Me.tpSpellAndUrl.Size = New System.Drawing.Size(506, 118)
        Me.tpSpellAndUrl.TabIndex = 5
        Me.tpSpellAndUrl.Text = "Spell&&Url"
        Me.tpSpellAndUrl.Visible = False
        '
        'pnSpellAndUrl
        '
        Me.pnSpellAndUrl.BackColor = System.Drawing.SystemColors.Control
        Me.pnSpellAndUrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnSpellAndUrl.Controls.Add(Me.gbSpellAndUrl)
        Me.pnSpellAndUrl.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSpellAndUrl.Location = New System.Drawing.Point(0, 0)
        Me.pnSpellAndUrl.Name = "pnSpellAndUrl"
        Me.pnSpellAndUrl.Size = New System.Drawing.Size(506, 112)
        Me.pnSpellAndUrl.TabIndex = 3
        '
        'gbSpellAndUrl
        '
        Me.gbSpellAndUrl.Controls.Add(Me.chbShowHyperTextHints)
        Me.gbSpellAndUrl.Controls.Add(Me.chbCheckSpelling)
        Me.gbSpellAndUrl.Controls.Add(Me.chbHighlightUrls)
        Me.gbSpellAndUrl.Location = New System.Drawing.Point(8, 8)
        Me.gbSpellAndUrl.Name = "gbSpellAndUrl"
        Me.gbSpellAndUrl.Size = New System.Drawing.Size(496, 96)
        Me.gbSpellAndUrl.TabIndex = 0
        Me.gbSpellAndUrl.TabStop = False
        Me.gbSpellAndUrl.Text = "Spelling && HyperText"
        '
        'chbShowHyperTextHints
        '
        Me.chbShowHyperTextHints.Location = New System.Drawing.Point(16, 58)
        Me.chbShowHyperTextHints.Name = "chbShowHyperTextHints"
        Me.chbShowHyperTextHints.TabIndex = 3
        Me.chbShowHyperTextHints.Text = "Show Hints"
        '
        'chbCheckSpelling
        '
        Me.chbCheckSpelling.Location = New System.Drawing.Point(16, 16)
        Me.chbCheckSpelling.Name = "chbCheckSpelling"
        Me.chbCheckSpelling.Size = New System.Drawing.Size(104, 16)
        Me.chbCheckSpelling.TabIndex = 0
        Me.chbCheckSpelling.Text = "Check Spelling"
        '
        'chbHighlightUrls
        '
        Me.chbHighlightUrls.Location = New System.Drawing.Point(16, 40)
        Me.chbHighlightUrls.Name = "chbHighlightUrls"
        Me.chbHighlightUrls.Size = New System.Drawing.Size(104, 16)
        Me.chbHighlightUrls.TabIndex = 2
        Me.chbHighlightUrls.Text = "Highlight Urls"
        '
        'tpPrinting
        '
        Me.tpPrinting.Controls.Add(Me.pnPrinting)
        Me.tpPrinting.Location = New System.Drawing.Point(4, 22)
        Me.tpPrinting.Name = "tpPrinting"
        Me.tpPrinting.Size = New System.Drawing.Size(506, 118)
        Me.tpPrinting.TabIndex = 3
        Me.tpPrinting.Text = "Printing"
        Me.tpPrinting.Visible = False
        '
        'pnPrinting
        '
        Me.pnPrinting.BackColor = System.Drawing.SystemColors.Control
        Me.pnPrinting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnPrinting.Controls.Add(Me.gbPrint)
        Me.pnPrinting.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPrinting.Location = New System.Drawing.Point(0, 0)
        Me.pnPrinting.Name = "pnPrinting"
        Me.pnPrinting.Size = New System.Drawing.Size(506, 112)
        Me.pnPrinting.TabIndex = 1
        '
        'gbPrint
        '
        Me.gbPrint.Controls.Add(Me.btPageSetup)
        Me.gbPrint.Controls.Add(Me.btPrint)
        Me.gbPrint.Controls.Add(Me.btPrintPreview)
        Me.gbPrint.Controls.Add(Me.btXml)
        Me.gbPrint.Controls.Add(Me.btHtml)
        Me.gbPrint.Controls.Add(Me.btRtf)
        Me.gbPrint.Location = New System.Drawing.Point(8, 8)
        Me.gbPrint.Name = "gbPrint"
        Me.gbPrint.Size = New System.Drawing.Size(496, 96)
        Me.gbPrint.TabIndex = 6
        Me.gbPrint.TabStop = False
        Me.gbPrint.Text = "Printing && Exporting"
        '
        'btPageSetup
        '
        Me.btPageSetup.BackColor = System.Drawing.SystemColors.Control
        Me.btPageSetup.Location = New System.Drawing.Point(200, 56)
        Me.btPageSetup.Name = "btPageSetup"
        Me.btPageSetup.Size = New System.Drawing.Size(80, 23)
        Me.btPageSetup.TabIndex = 11
        Me.btPageSetup.Text = "Page Setup"
        '
        'btPrint
        '
        Me.btPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btPrint.Location = New System.Drawing.Point(104, 56)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(80, 23)
        Me.btPrint.TabIndex = 10
        Me.btPrint.Text = "Print"
        '
        'btPrintPreview
        '
        Me.btPrintPreview.BackColor = System.Drawing.SystemColors.Control
        Me.btPrintPreview.Location = New System.Drawing.Point(8, 56)
        Me.btPrintPreview.Name = "btPrintPreview"
        Me.btPrintPreview.Size = New System.Drawing.Size(80, 23)
        Me.btPrintPreview.TabIndex = 9
        Me.btPrintPreview.Text = "Print Preview"
        '
        'btXml
        '
        Me.btXml.BackColor = System.Drawing.SystemColors.Control
        Me.btXml.Location = New System.Drawing.Point(200, 24)
        Me.btXml.Name = "btXml"
        Me.btXml.Size = New System.Drawing.Size(80, 23)
        Me.btXml.TabIndex = 8
        Me.btXml.Text = "XML"
        '
        'btHtml
        '
        Me.btHtml.BackColor = System.Drawing.SystemColors.Control
        Me.btHtml.Location = New System.Drawing.Point(104, 24)
        Me.btHtml.Name = "btHtml"
        Me.btHtml.Size = New System.Drawing.Size(80, 23)
        Me.btHtml.TabIndex = 7
        Me.btHtml.Text = "HTML"
        '
        'btRtf
        '
        Me.btRtf.BackColor = System.Drawing.SystemColors.Control
        Me.btRtf.Location = New System.Drawing.Point(8, 24)
        Me.btRtf.Name = "btRtf"
        Me.btRtf.Size = New System.Drawing.Size(80, 23)
        Me.btRtf.TabIndex = 6
        Me.btRtf.Text = "RTF"
        '
        'treeView1
        '
        Me.treeView1.BackColor = System.Drawing.SystemColors.Window
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.treeView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.treeView1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.treeView1.ImageIndex = -1
        Me.treeView1.Location = New System.Drawing.Point(0, 0)
        Me.treeView1.Name = "treeView1"
        Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Appearance", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Gutter"), New System.Windows.Forms.TreeNode("Margin"), New System.Windows.Forms.TreeNode("Line Numbers"), New System.Windows.Forms.TreeNode("Other"), New System.Windows.Forms.TreeNode("Pages & Rulers")}), New System.Windows.Forms.TreeNode("Behavior", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Outlining"), New System.Windows.Forms.TreeNode("Text Source"), New System.Windows.Forms.TreeNode("Navigation"), New System.Windows.Forms.TreeNode("Selection"), New System.Windows.Forms.TreeNode("WordWrap & Scrolling"), New System.Windows.Forms.TreeNode("Spelling & HyperText")}), New System.Windows.Forms.TreeNode("Dialogs", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Common Dialogs"), New System.Windows.Forms.TreeNode("Printing & Exporting")}), New System.Windows.Forms.TreeNode("Properties"), New System.Windows.Forms.TreeNode("Company Info", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("About QWhale")})})
        Me.treeView1.SelectedImageIndex = -1
        Me.treeView1.Size = New System.Drawing.Size(160, 478)
        Me.treeView1.TabIndex = 27
        '
        'imageList1
        '
        Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Red
        '
        'saveFileDialog2
        '
        Me.saveFileDialog2.Filter = "Rtf files (*.rtf)|*.rtf|Html files (*.html; *.htm)|*.html;*.htm|Xml files (*.xml)" & _
        "|*.xml|All files (*.*)|*.*"
        '
        'openFileDialog1
        '
        Me.openFileDialog1.Filter = "Text files (*.txt)|*.txt|C # files (*.cs)|*.cs|All files (*.*)|*.*"
        '
        'saveFileDialog1
        '
        Me.saveFileDialog1.Filter = "Text files (*.txt)|*.txt|C # files (*.cs)|*.cs|All files (*.*)|*.*"
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(674, 478)
        Me.Controls.Add(Me.pnMain)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Editor.NET"
        Me.pnMain.ResumeLayout(False)
        Me.pnEditContainer.ResumeLayout(False)
        Me.pnManage.ResumeLayout(False)
        Me.tcContainer.ResumeLayout(False)
        Me.tpGutter.ResumeLayout(False)
        Me.pnGutter.ResumeLayout(False)
        Me.gbGutter.ResumeLayout(False)
        CType(Me.nudGutterWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMargin.ResumeLayout(False)
        Me.pnMargin.ResumeLayout(False)
        Me.gbMargin.ResumeLayout(False)
        CType(Me.nudMarginPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpOther.ResumeLayout(False)
        Me.pnOther.ResumeLayout(False)
        Me.gbBraces.ResumeLayout(False)
        Me.gbOther.ResumeLayout(False)
        Me.tpCompanyInfo.ResumeLayout(False)
        Me.pnCompanyInfo.ResumeLayout(False)
        Me.tpWordWrap.ResumeLayout(False)
        Me.pnWordWrap.ResumeLayout(False)
        Me.gbWordWrap.ResumeLayout(False)
        Me.tpLineNumbers.ResumeLayout(False)
        Me.pnLineNumbers.ResumeLayout(False)
        Me.gbLineNumbers.ResumeLayout(False)
        CType(Me.nudLineNumbersStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNavigate.ResumeLayout(False)
        Me.pnNavigate.ResumeLayout(False)
        Me.gbNavigateOptions.ResumeLayout(False)
        Me.tpTextSource.ResumeLayout(False)
        Me.pnTextSource.ResumeLayout(False)
        Me.tpOutlining.ResumeLayout(False)
        Me.pnOutlining.ResumeLayout(False)
        Me.gbOutlining.ResumeLayout(False)
        Me.tpDialogs.ResumeLayout(False)
        Me.pnDialogs.ResumeLayout(False)
        Me.gbDialogs.ResumeLayout(False)
        Me.tpProperties.ResumeLayout(False)
        Me.tpPages.ResumeLayout(False)
        Me.pnPageLayout.ResumeLayout(False)
        Me.gbPages.ResumeLayout(False)
        Me.gbRulers.ResumeLayout(False)
        Me.tpSelection.ResumeLayout(False)
        Me.pnSelection.ResumeLayout(False)
        Me.gbSelection.ResumeLayout(False)
        Me.tpSpellAndUrl.ResumeLayout(False)
        Me.pnSpellAndUrl.ResumeLayout(False)
        Me.gbSpellAndUrl.ResumeLayout(False)
        Me.tpPrinting.ResumeLayout(False)
        Me.pnPrinting.ResumeLayout(False)
        Me.gbPrint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private GlobalSettings As SyntaxSettings
    Private Options As DlgSyntaxSettings
    Private Const sFileFilter As String = "Text files (*.txt)|*.txt|C # files (*.cs)|*.cs|All files (*.*)|*.*"
    Private scrollBoxUpdate As Integer
    Private Const cCommentColorStyle As Integer = 4

    Private ObsoleteProps As String() = {"AccessibleDescription", "AccessibleName", "Accessible Role"}
    Private propertyGrid As PropertyGrid = New PropertyGrid
    Private obsolete As ArrayList = New ArrayList
    Private descriptor As ComponentTypeDescriptorEx
    Private controlContainer As DefaultComponentContainer = New DefaultComponentContainer
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each prop As String In ObsoleteProps
            obsolete.Add(prop)
        Next prop
        descriptor = New ComponentTypeDescriptorEx(syntaxEdit, obsolete)
        controlContainer = New DefaultComponentContainer
        controlContainer.Add(descriptor, String.Format("{0}{1}", "SyntaxEdit", "_Wrapper"))
        controlContainer.Add(textSource1, "TextSource1")
        controlContainer.Add(csParser1, "CsParser1")
        propertyGrid.Parent = pnPropertyGrid
        propertyGrid.Dock = DockStyle.Fill
        propertyGrid.SelectedObject = descriptor
        propertyGrid.CommandsVisibleIfAvailable = True
        propertyGrid.Text = "Property Grid"
        propertyGrid.ToolbarVisible = True
        treeView1.ExpandAll()
        ' changing default settings
        syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Or ScrollingOptions.ShowScrollHint
        syntaxSplitEdit.Scrolling.Options = syntaxSplitEdit.Scrolling.Options Or ScrollingOptions.ShowScrollHint
        ' updating controls
        FillControls()
        ' creating global settings
        GlobalSettings = New SyntaxSettings
        Options = New DlgSyntaxSettings
        GlobalSettings.LoadFromEdit(syntaxEdit)
        If (TypeOf pictureBox1.Image Is Bitmap) Then
            CType(pictureBox1.Image, Bitmap).MakeTransparent(Color.White)
        End If
        ' displaying gutter panel
        UpdatePanels(treeView1.Nodes(0))
    End Sub
    Private Function GetCurrentPanel(ByVal node As TreeNode) As Panel
        'getting current panel to display
        If (Not node Is Nothing) Then
            Dim root As TreeNode = node
            While (Not root.Parent Is Nothing)
                root = root.Parent
            End While
            If root.Index = 0 Then
                Select Case node.Index
                    Case 0
                        Return pnGutter
                    Case 1
                        Return pnMargin
                    Case 2
                        Return pnLineNumbers
                    Case 3
                        Return pnOther
                    Case 4
                        Return pnPageLayout
                    Case Else
                        Return pnGutter
                End Select
            Else
                If root.Index = 1 Then
                    Select Case node.Index
                        Case 0
                            Return pnOutlining
                        Case 1
                            Return pnTextSource
                        Case 2
                            Return pnNavigate
                        Case 3
                            Return pnSelection
                        Case 4
                            Return pnWordWrap
                        Case 5
                            Return pnSpellAndUrl
                        Case Else
                            Return pnOutlining
                    End Select
                Else
                    If root.Index = 2 Then
                        Select Case node.Index
                            Case 0
                                Return pnDialogs
                            Case 1
                                Return pnPrinting
                            Case Else
                                Return pnDialogs
                        End Select
                    Else
                        If root.Index = 3 Then
                            Return pnProperties
                        Else
                            Return pnCompanyInfo
                        End If
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function
    Private Sub UpdatePanels(ByVal node As TreeNode)
        ' displaying new panel
        Dim panel As Panel = GetCurrentPanel(node)
        If Not (panel Is Nothing) And Not pnManage.Controls.Contains(panel) Then
            pnManage.Controls.Add(panel)
        End If
        Dim j As Integer = pnManage.Controls.IndexOf(panel)
        For i As Integer = 0 To pnManage.Controls.Count - 1
            If (i <> j) And (TypeOf pnManage.Controls(i) Is Panel) Then
                pnManage.Controls(i).Visible = False
            End If
        Next i
        Dim IsAbout As Boolean = (Not panel Is Nothing) And (panel.Equals(pnCompanyInfo))
        Dim IsTextSource As Boolean = (Not panel Is Nothing) And (panel.Equals(pnTextSource))
        Dim isProperties As Boolean = (Not panel Is Nothing) And (panel.Equals(pnProperties))
        If IsAbout Then
            pnManage.Dock = DockStyle.Fill
            panel.Dock = DockStyle.Fill
            pnEditContainer.Visible = False
        Else
            pnManage.Dock = DockStyle.Top
            panel.Dock = DockStyle.Top
            pnManage.Height = panel.Height
            pnEditContainer.Visible = True
        End If
        pnPropertyGrid.Visible = isProperties
        Splitter2.Visible = isProperties
        panel.Visible = True
        panel.BringToFront()
        UpdateEditorVisibility(Not IsAbout, IsTextSource, pnMain.Height - panel.Height - splitter1.Height)
    End Sub
    Private Sub UpdateEditorVisibility(ByVal visible As Boolean, ByVal split As Boolean, ByVal height As Integer)
        ' splitting view if needed
        syntaxEdit.Visible = visible
        syntaxSplitEdit.Visible = split
        splitter1.Visible = split
        If split Then
            syntaxSplitEdit.Height = height / 2
        End If
    End Sub
    Private Sub FillControls()
        ' updating controls according to editor properties
        scrollBoxUpdate += 1
        Try
            'margin
            nudMarginPos.Maximum = 1000
            nudMarginPos.Value = syntaxEdit.EditMargin.Position
            chbShowMargin.Checked = syntaxEdit.EditMargin.Visible
            chbAllowDragMargin.Checked = syntaxEdit.EditMargin.AllowDrag
            chbShowMarginHints.Checked = syntaxEdit.EditMargin.ShowHints
            chbColumnsVisible.Checked = syntaxEdit.EditMargin.ColumnsVisible
            'gutter
            syntaxEdit.LineStyles.AddLineStyle("breakpoint", Color.White, Color.Red, Color.Empty, 12, LineStyleOptions.BeyondEol)
            syntaxSplitEdit.LineStyles.AddLineStyle("breakpoint", Color.White, Color.Red, Color.Empty, 12, LineStyleOptions.BeyondEol)
            chbShowGutter.Checked = syntaxEdit.Gutter.Visible
            chbPaintBookMarks.Checked = (GutterOptions.PaintBookMarks And syntaxEdit.Gutter.Options) <> 0
            chbLineNumbers.Checked = (GutterOptions.PaintLineNumbers And syntaxEdit.Gutter.Options) <> 0
            chbLinesOnGutter.Checked = (GutterOptions.PaintLinesOnGutter And syntaxEdit.Gutter.Options) <> 0
            chbLinesBeyondEof.Checked = (GutterOptions.PaintLinesBeyondEof And syntaxEdit.Gutter.Options) <> 0
            chbDrawLineBookmarks.Checked = syntaxEdit.Gutter.DrawLineBookmarks
            chbLineModificator.Checked = (GutterOptions.PaintLineModificators And syntaxEdit.Gutter.Options) <> 0
            nudGutterWidth.Maximum = syntaxEdit.Width
            nudGutterWidth.Value = syntaxEdit.Gutter.Width
            nudLineNumbersStart.Maximum = 10000
            nudLineNumbersStart.Value = syntaxEdit.Gutter.LineNumbersStart
            Dim s As String() = [Enum].GetNames(GetType(StringAlignment))
            cbLineNumbersAlign.Items.AddRange(s)
            cbLineNumbersAlign.SelectedIndex = syntaxEdit.Gutter.LineNumbersAlignment
            chbHighlightCurrentLine.Checked = (SeparatorOptions.HighlightCurrentLine And syntaxEdit.LineSeparator.Options) <> 0
            'other
            chbSeparateLines.Checked = (SeparatorOptions.SeparateLines And syntaxEdit.LineSeparator.Options) <> 0
            chbQuickInfoTips.Checked = (SyntaxOptions.QuickInfoTips And csParser1.Options) <> 0
            chbDrawColumnsIndent.Checked = syntaxEdit.DrawColumnsIndent
            chbWhiteSpaceVisible.Checked = syntaxEdit.WhiteSpace.Visible
            chbHighlightBraces.Checked = (BracesOptions.Highlight And syntaxEdit.Braces.BracesOptions) <> 0
            chbUseRoundRect.Checked = syntaxEdit.Braces.UseRoundRect
            cbTempHighlightBraces.Checked = (BracesOptions.TempHighlight And syntaxEdit.Braces.BracesOptions) <> 0
            chbTransparent.Checked = syntaxEdit.Transparent
            'PageLayout&Ruler
            s = [Enum].GetNames(GetType(PageType))
            cbPageLayout.Items.AddRange(s)
            cbPageLayout.SelectedIndex = syntaxEdit.Pages.PageType
            s = [Enum].GetNames(GetType(RulerUnits))
            cbRulerUnits.Items.AddRange(s)
            cbRulerUnits.SelectedIndex = syntaxEdit.Pages.RulerUnits
            chbRulerAllowDrag.Checked = (RulerOptions.AllowDrag And syntaxEdit.Pages.RulerOptions) <> 0
            chbRulerDiscrete.Checked = (RulerOptions.Discrete And syntaxEdit.Pages.RulerOptions) <> 0
            chbRulerDisplayDragLines.Checked = (RulerOptions.DisplayDragLine And syntaxEdit.Pages.RulerOptions) <> 0
            chbHorzRuler.Checked = (EditRulers.Horizonal And syntaxEdit.Pages.Rulers) <> 0
            chbVertRuler.Checked = (EditRulers.Vertical And syntaxEdit.Pages.Rulers) <> 0

            For Each psize As PaperSize In syntaxEdit.Printing.PrinterSettings.PaperSizes
                If Not cbPageSize.Items.Contains(psize.Kind) Then
                    cbPageSize.Items.Add(psize.Kind)
                End If
            Next
            cbPageSize.Enabled = cbPageSize.Items.Count > 0
            If cbPageSize.Enabled Then
                cbPageSize.SelectedIndex = 0
            End If
            'wordwrap
            chbWordWrap.Checked = syntaxEdit.WordWrap
            chbWrapAtMargin.Checked = syntaxEdit.WrapAtMargin
            chbAllowSplit.Checked = ((ScrollingOptions.AllowSplitHorz And syntaxEdit.Scrolling.Options) <> 0) And ((ScrollingOptions.AllowSplitVert And syntaxEdit.Scrolling.Options) <> 0)
            chbScrollButtons.Checked = ((ScrollingOptions.HorzButtons And syntaxEdit.Scrolling.Options) <> 0) And ((ScrollingOptions.VertButtons And syntaxEdit.Scrolling.Options) <> 0)
            chbSystemScrollBars.Checked = (syntaxEdit.Scrolling.Options And ScrollingOptions.SystemScrollbars) <> 0
            chbFlatScrollBars.Checked = (syntaxEdit.Scrolling.Options And ScrollingOptions.FlatScrollbars) <> 0
            'outlining
            chbAllowOutlining.Checked = syntaxEdit.Outlining.AllowOutlining
            chbDrawOnGutter.Checked = (OutlineOptions.DrawOnGutter And syntaxEdit.Outlining.OutlineOptions) <> 0
            chbDrawLines.Checked = (OutlineOptions.DrawLines And syntaxEdit.Outlining.OutlineOptions) <> 0
            chbDrawButtons.Checked = (OutlineOptions.DrawButtons And syntaxEdit.Outlining.OutlineOptions) <> 0
            chbShowHints.Checked = (OutlineOptions.ShowHints And syntaxEdit.Outlining.OutlineOptions) <> 0
            'spell&url
            chbCheckSpelling.Checked = syntaxEdit.Spelling.CheckSpelling
            chbHighlightUrls.Checked = syntaxEdit.HyperText.HighlightUrls
            chbShowScrollHint.Checked = (syntaxEdit.Scrolling.Options And ScrollingOptions.ShowScrollHint) <> 0
            chbSmoothScroll.Checked = (syntaxEdit.Scrolling.Options And ScrollingOptions.SmoothScroll) <> 0
            chbShowHyperTextHints.Checked = syntaxEdit.HyperText.ShowHints
            'navigate&selection
            chbBeyondEol.Checked = (NavigateOptions.BeyondEol And syntaxEdit.NavigateOptions) <> 0
            chbBeyondEof.Checked = (NavigateOptions.BeyondEof And syntaxEdit.NavigateOptions) <> 0
            chbUpAtLineBegin.Checked = (NavigateOptions.UpAtLineBegin And syntaxEdit.NavigateOptions) <> 0
            chbDownAtLineEnd.Checked = (NavigateOptions.DownAtLineEnd And syntaxEdit.NavigateOptions) <> 0
            chbMoveOnRightButton.Checked = (NavigateOptions.MoveOnRightButton And syntaxEdit.NavigateOptions) <> 0

            chbDisableSelection.Checked = (SelectionOptions.DisableSelection And syntaxEdit.Selection.Options) <> 0
            chbDisableDragging.Checked = (SelectionOptions.DisableDragging And syntaxEdit.Selection.Options) <> 0
            chbSelectBeyondEol.Checked = (SelectionOptions.SelectBeyondEol And syntaxEdit.Selection.Options) <> 0
            chbUseColors.Checked = (SelectionOptions.UseColors And syntaxEdit.Selection.Options) <> 0
            chbHideSelection.Checked = (SelectionOptions.HideSelection And syntaxEdit.Selection.Options) <> 0
            chbSelectLineOnDblClick.Checked = (SelectionOptions.SelectLineOnDblClick And syntaxEdit.Selection.Options) <> 0
            chbDeselectOnCopy.Checked = (SelectionOptions.DeselectOnCopy And syntaxEdit.Selection.Options) <> 0
            chbPersistentBlocks.Checked = (SelectionOptions.PersistentBlocks And syntaxEdit.Selection.Options) <> 0
            chbOverwriteBlocks.Checked = (SelectionOptions.OverwriteBlocks And syntaxEdit.Selection.Options) <> 0
        Finally
            scrollBoxUpdate -= 1
        End Try
    End Sub

    Private Sub UpdateScrollBoxes(ByVal sender As Object)
        ' updating checkboxes related to scrolling properties
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        scrollBoxUpdate += 1
        Try
            If Not (chbAllowSplit Is sender) Then
                chbAllowSplit.Checked = ((ScrollingOptions.AllowSplitHorz And syntaxEdit.Scrolling.Options) <> 0) And ((ScrollingOptions.AllowSplitVert And syntaxEdit.Scrolling.Options) <> 0)
            End If
            If Not (chbScrollButtons Is sender) Then
                chbScrollButtons.Checked = ((ScrollingOptions.HorzButtons And syntaxEdit.Scrolling.Options) <> 0) And ((ScrollingOptions.VertButtons And syntaxEdit.Scrolling.Options) <> 0)
            End If
            If Not (chbSystemScrollBars Is sender) Then
                chbSystemScrollBars.Checked = (syntaxEdit.Scrolling.Options And ScrollingOptions.SystemScrollbars) <> 0
            End If

            If Not (chbFlatScrollBars Is sender) Then
                chbFlatScrollBars.Checked = (syntaxEdit.Scrolling.Options And ScrollingOptions.FlatScrollbars) <> 0
            End If
        Finally
            scrollBoxUpdate -= 1
        End Try

    End Sub

    Private Sub chbShowGutter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowGutter.CheckedChanged
        ' updating gutter visiblility
        syntaxEdit.Gutter.Visible = chbShowGutter.Checked
        syntaxSplitEdit.Gutter.Visible = chbShowGutter.Checked
    End Sub

    Private Sub chbShowMargin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowMargin.CheckedChanged
        ' updating margin visiblility
        syntaxEdit.EditMargin.Visible = chbShowMargin.Checked
        syntaxSplitEdit.EditMargin.Visible = chbShowMargin.Checked
    End Sub

    Private Sub chbSeparateLines_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSeparateLines.CheckedChanged
        ' updating lineseparator properties
        If chbSeparateLines.Checked Then
            syntaxEdit.LineSeparator.Options = syntaxEdit.LineSeparator.Options Or SeparatorOptions.SeparateLines
        Else
            syntaxEdit.LineSeparator.Options = syntaxEdit.LineSeparator.Options Xor SeparatorOptions.SeparateLines
        End If
        syntaxSplitEdit.LineSeparator.Options = syntaxEdit.LineSeparator.Options
    End Sub

    Private Sub chbPaintBookMarks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPaintBookMarks.CheckedChanged
        ' updating bookmarks visiblity
        If chbPaintBookMarks.Checked Then
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Or GutterOptions.PaintBookMarks
        Else
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Xor GutterOptions.PaintBookMarks
        End If
        syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options
    End Sub

    Private Sub chbDrawLineBookmarks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDrawLineBookmarks.CheckedChanged
        ' updating line bookmarks visibility
        syntaxEdit.Gutter.DrawLineBookmarks = chbDrawLineBookmarks.Checked
        syntaxSplitEdit.Gutter.DrawLineBookmarks = chbDrawLineBookmarks.Checked
    End Sub

    Private Sub chbHighlightCurrentLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHighlightCurrentLine.CheckedChanged
        ' updating line separator visibility
        If chbHighlightCurrentLine.Checked Then
            syntaxEdit.LineSeparator.Options = syntaxEdit.LineSeparator.Options Or SeparatorOptions.HighlightCurrentLine
        Else
            syntaxEdit.LineSeparator.Options = syntaxEdit.LineSeparator.Options Xor SeparatorOptions.HighlightCurrentLine
        End If
        syntaxSplitEdit.LineSeparator.Options = syntaxEdit.LineSeparator.Options
    End Sub

    Private Sub nudGutterWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGutterWidth.ValueChanged
        ' updating gutter width
        syntaxEdit.Gutter.Width = nudGutterWidth.Value
        syntaxSplitEdit.Gutter.Width = nudGutterWidth.Value
    End Sub

    Private Sub nudMarginPos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMarginPos.ValueChanged
        ' updating margin position
        syntaxEdit.EditMargin.Position = nudMarginPos.Value
        syntaxSplitEdit.EditMargin.Position = nudMarginPos.Value
    End Sub

    Private Sub btShowBookmarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btShowBookmarks.Click
        ' setting or removing sample bookmarks and line styles
        Dim i As Integer = syntaxEdit.ScreenToText(0, 0).Y
        CType(syntaxEdit.Source, INotify).BeginUpdate()
        Try
            If btShowBookmarks.Text = "Set Bookmarks" Then
                syntaxEdit.Source.LineStyles.SetLineStyle(i + 12, 0)
                syntaxEdit.Source.BookMarks.SetBookMark(New Point(6, i + 1), 0)
                syntaxEdit.Source.BookMarks.SetBookMark(New Point(9, i + 15), 7)
                syntaxEdit.Source.BookMarks.SetBookMark(New Point(14, i + 6), 10)
                btShowBookmarks.Text = "Clear Bookmarks"
            Else
                syntaxEdit.Source.LineStyles.Clear()
                syntaxEdit.Source.BookMarks.ClearAllBookMarks()
                btShowBookmarks.Text = "Set Bookmarks"
            End If
        Finally
            syntaxEdit.Source.EndUpdate()
            syntaxEdit.Invalidate()
        End Try
    End Sub

    Private Sub chbLineNumbers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLineNumbers.CheckedChanged
        ' updating line numbers visibility
        If chbLineNumbers.Checked Then
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Or GutterOptions.PaintLineNumbers
        Else
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Xor GutterOptions.PaintLineNumbers
        End If
        syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options
    End Sub

    Private Sub chbLinesOnGutter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLinesOnGutter.CheckedChanged
        ' updating displaying line numbers on gutter
        If chbLinesOnGutter.Checked Then
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Or GutterOptions.PaintLinesOnGutter
        Else
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Xor GutterOptions.PaintLinesOnGutter
        End If
        syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options
    End Sub

    Private Sub chbLinesBeyondEof_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLinesBeyondEof.CheckedChanged
        ' updating displaying line numbers beyond end of file
        If chbLinesBeyondEof.Checked Then
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Or GutterOptions.PaintLinesBeyondEof
        Else
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Xor GutterOptions.PaintLinesBeyondEof
        End If
        syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options
    End Sub

    Private Sub nudLineNumbersStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLineNumbersStart.ValueChanged
        ' updating line number start
        syntaxEdit.Gutter.LineNumbersStart = nudLineNumbersStart.Value
        syntaxSplitEdit.Gutter.LineNumbersStart = nudLineNumbersStart.Value
    End Sub

    Private Sub cbLineNumbersAlign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLineNumbersAlign.SelectedIndexChanged
        ' updating line numbers alignment
        syntaxEdit.Gutter.LineNumbersAlignment = CType(cbLineNumbersAlign.SelectedIndex, StringAlignment)
        syntaxSplitEdit.Gutter.LineNumbersAlignment = CType(cbLineNumbersAlign.SelectedIndex, StringAlignment)
    End Sub

    Private Sub btLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLoad.Click
        ' loading editor content from the file
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fi As System.IO.FileInfo = New System.IO.FileInfo(openFileDialog1.FileName)
            If fi.Extension = ".xml" Then
                syntaxEdit.LoadFile(openFileDialog1.FileName, ExportFormat.Xml)
            Else
                textSource1.LoadFile(openFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        ' saving editor content to the file
        If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            textSource1.SaveFile(saveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFind.Click
        ' displaying search dialog
        syntaxEdit.DisplaySearchDialog()
    End Sub

    Private Sub btReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btReplace.Click
        ' displaying search dialog
        syntaxEdit.DisplayReplaceDialog()
    End Sub

    Private Sub btGoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGoto.Click
        ' displaying goto line dialog
        syntaxEdit.DisplayGotoLineDialog()
    End Sub

    Private Sub btCustomize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCustomize.Click
        ' displaying editor settings dialog.
        Options.SyntaxSettings.Assign(GlobalSettings)
        If Options.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            GlobalSettings.Assign(Options.SyntaxSettings)
            GlobalSettings.ApplyToEdit(syntaxEdit)
            GlobalSettings.ApplyToEdit(syntaxSplitEdit)
        End If
    End Sub

    Private Sub chbWordWrap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbWordWrap.CheckedChanged
        ' updating wordwrap mode
        syntaxEdit.WordWrap = chbWordWrap.Checked
        syntaxSplitEdit.WordWrap = chbWordWrap.Checked
    End Sub

    Private Sub chbWrapAtMargin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbWrapAtMargin.CheckedChanged
        ' updating wrapping at margin 
        syntaxEdit.WrapAtMargin = chbWrapAtMargin.Checked
        syntaxSplitEdit.WrapAtMargin = chbWrapAtMargin.Checked
    End Sub

    Private Sub chbWhiteSpaceVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbWhiteSpaceVisible.CheckedChanged
        ' updating whitespace visibility
        syntaxEdit.WhiteSpace.Visible = chbWhiteSpaceVisible.Checked
        syntaxSplitEdit.WhiteSpace.Visible = chbWhiteSpaceVisible.Checked
    End Sub

    Private Sub btRtf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRtf.Click
        ' saving editor to rtf
        saveFileDialog2.FilterIndex = 1
        If saveFileDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            syntaxEdit.SaveFile(saveFileDialog2.FileName, ExportFormat.Rtf)
        End If
    End Sub

    Private Sub btHtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHtml.Click
        ' saving editor to xml
        saveFileDialog2.FilterIndex = 2
        If saveFileDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            syntaxEdit.SaveFile(saveFileDialog2.FileName, ExportFormat.Html)
        End If
    End Sub

    Private Sub btXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXml.Click
        ' saving editor to xml
        saveFileDialog2.FilterIndex = 3
        If saveFileDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            syntaxEdit.SaveFile(saveFileDialog2.FileName, ExportFormat.Xml)
        End If
    End Sub

    Private Sub btPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrintPreview.Click
        ' executing print preview dialog
        syntaxEdit.Printing.ExecutePrintPreviewDialog()
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        ' executing print dialog
        syntaxEdit.Printing.ExecutePrintDialog()
    End Sub

    Private Sub btPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPageSetup.Click
        ' executing page setup dialog
        syntaxEdit.Printing.ExecutePageSetupDialog()
    End Sub

    Private Sub chbAllowOutlining_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAllowOutlining.CheckedChanged
        ' updating outlining mode
        syntaxEdit.Outlining.AllowOutlining = chbAllowOutlining.Checked
        syntaxSplitEdit.Outlining.AllowOutlining = syntaxEdit.Outlining.AllowOutlining
    End Sub

    Private Sub chbDrawOnGutter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDrawOnGutter.CheckedChanged
        ' updating outlining options
        If chbDrawOnGutter.Checked Then
            syntaxEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions Or OutlineOptions.DrawOnGutter
        Else
            syntaxEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions Xor OutlineOptions.DrawOnGutter
        End If
        syntaxSplitEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions
    End Sub

    Private Sub chbDrawLines_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDrawLines.CheckedChanged
        ' updating outlining options
        If chbDrawLines.Checked Then
            syntaxEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions Or OutlineOptions.DrawLines
        Else
            syntaxEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions Xor OutlineOptions.DrawLines
        End If
        syntaxSplitEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions
    End Sub

    Private Sub chbDrawButtons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDrawButtons.CheckedChanged
        ' updating outlining options
        If chbDrawButtons.Checked Then
            syntaxEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions Or OutlineOptions.DrawButtons
        Else
            syntaxEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions Xor OutlineOptions.DrawButtons
        End If
        syntaxSplitEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions
    End Sub

    Private Sub chbShowHints_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowHints.CheckedChanged
        ' updating outlining options
        If chbShowHints.Checked Then
            syntaxEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions Or OutlineOptions.ShowHints
        Else
            syntaxEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions Xor OutlineOptions.ShowHints
        End If
        syntaxSplitEdit.Outlining.OutlineOptions = syntaxEdit.Outlining.OutlineOptions
    End Sub

    Private Sub chbCheckSpelling_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCheckSpelling.CheckedChanged
        ' updating spelling options
        syntaxEdit.Spelling.CheckSpelling = chbCheckSpelling.Checked
        syntaxSplitEdit.Spelling.CheckSpelling = chbCheckSpelling.Checked
    End Sub

    Private Sub chbHighlightUrls_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHighlightUrls.CheckedChanged
        ' updating hypertext options
        syntaxEdit.HyperText.HighlightUrls = chbHighlightUrls.Checked
        syntaxSplitEdit.HyperText.HighlightUrls = chbHighlightUrls.Checked
    End Sub

    Private Sub chbShowScrollHint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowScrollHint.CheckedChanged
        ' updating scrolling options
        If chbShowScrollHint.Checked Then
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Or ScrollingOptions.ShowScrollHint
        Else
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Xor ScrollingOptions.ShowScrollHint
        End If
        syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options
    End Sub

    Private Sub chbSmoothScroll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSmoothScroll.CheckedChanged
        ' updating scrolling options
        If chbSmoothScroll.Checked Then
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Or ScrollingOptions.SmoothScroll
        Else
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Xor ScrollingOptions.SmoothScroll
        End If
        syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options
    End Sub

    Private Sub chbBeyondEof_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbBeyondEof.CheckedChanged
        ' updating navigate options
        If chbBeyondEof.Checked Then
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Or NavigateOptions.BeyondEof
        Else
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Xor NavigateOptions.BeyondEof
        End If
        syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions
    End Sub

    Private Sub chbBeyondEol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbBeyondEol.CheckedChanged
        ' updating navigate options
        If chbBeyondEol.Checked Then
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Or NavigateOptions.BeyondEol
        Else
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Xor NavigateOptions.BeyondEol
        End If
        syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions
    End Sub

    Private Sub chbUpAtLineBegin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUpAtLineBegin.CheckedChanged
        ' updating navigate options
        If chbUpAtLineBegin.Checked Then
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Or NavigateOptions.UpAtLineBegin
        Else
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Xor NavigateOptions.UpAtLineBegin
        End If
        syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions
    End Sub

    Private Sub chbDownAtLineEnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDownAtLineEnd.CheckedChanged
        ' updating navigate options
        If chbDownAtLineEnd.Checked Then
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Or NavigateOptions.DownAtLineEnd
        Else
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Xor NavigateOptions.DownAtLineEnd
        End If
        syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions
    End Sub

    Private Sub chbMoveOnRightButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMoveOnRightButton.CheckedChanged
        ' updating navigate options
        If chbMoveOnRightButton.Checked Then
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Or NavigateOptions.MoveOnRightButton
        Else
            syntaxEdit.NavigateOptions = syntaxEdit.NavigateOptions Xor NavigateOptions.MoveOnRightButton
        End If
        syntaxSplitEdit.NavigateOptions = syntaxEdit.NavigateOptions
    End Sub

    Private Sub chbDisableSelection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDisableSelection.CheckedChanged
        ' updating selection options
        If chbDisableSelection.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.DisableSelection
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.DisableSelection
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub chbDisableDragging_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDisableDragging.CheckedChanged
        ' updating selection options
        If chbDisableDragging.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.DisableDragging
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.DisableDragging
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub chbSelectBeyondEol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectBeyondEol.CheckedChanged
        ' updating selection options
        If chbSelectBeyondEol.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.SelectBeyondEol
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.SelectBeyondEol
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub chbUseColors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUseColors.CheckedChanged
        ' updating selection appearance
        If chbUseColors.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.UseColors
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.UseColors
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub chbHideSelection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHideSelection.CheckedChanged
        ' updating selection appearance
        If chbHideSelection.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.HideSelection
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.HideSelection
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub chbSelectLineOnDblClick_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectLineOnDblClick.CheckedChanged
        ' updating selection options
        If chbSelectLineOnDblClick.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.SelectLineOnDblClick
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.SelectLineOnDblClick
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub chbDeselectOnCopy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDeselectOnCopy.CheckedChanged
        ' updating selection options
        If chbDeselectOnCopy.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.DeselectOnCopy
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.DeselectOnCopy
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub chbPersistentBlocks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPersistentBlocks.CheckedChanged
        ' updating selection options
        If chbPersistentBlocks.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.PersistentBlocks
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.PersistentBlocks
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub chbOverwriteBlocks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbOverwriteBlocks.CheckedChanged
        ' updating selection options
        If chbOverwriteBlocks.Checked Then
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Or SelectionOptions.OverwriteBlocks
        Else
            syntaxEdit.Selection.Options = syntaxEdit.Selection.Options Xor SelectionOptions.OverwriteBlocks
        End If
        syntaxSplitEdit.Selection.Options = syntaxEdit.Selection.Options
    End Sub

    Private Sub laAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles laAdress.Click
        laAdress.ForeColor = Color.Purple
        Try
            System.Diagnostics.Process.Start(laAdress.Text)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub laMailTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles laMailTo.Click
        laMailTo.ForeColor = Color.Purple
        Try
            System.Diagnostics.Process.Start(laMailTo.Text)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub chbShowHyperTextHints_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowHyperTextHints.CheckedChanged
        ' updating hypertext options
        syntaxEdit.HyperText.ShowHints = chbShowHyperTextHints.Checked
        syntaxSplitEdit.HyperText.ShowHints = chbShowHyperTextHints.Checked
    End Sub

    Private Sub chbAllowDragMargin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAllowDragMargin.CheckedChanged
        ' updating margin options
        syntaxEdit.EditMargin.AllowDrag = chbAllowDragMargin.Checked
        syntaxSplitEdit.EditMargin.AllowDrag = chbAllowDragMargin.Checked
    End Sub

    Private Sub chbShowMarginHints_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowMarginHints.CheckedChanged
        ' updating margin options
        syntaxEdit.EditMargin.ShowHints = chbShowMarginHints.Checked
        syntaxSplitEdit.EditMargin.ShowHints = chbShowMarginHints.Checked
    End Sub

    Private Sub chbTransparent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTransparent.CheckedChanged
        ' updating transparent property
        syntaxEdit.Transparent = chbTransparent.Checked
        syntaxSplitEdit.Transparent = chbTransparent.Checked
    End Sub

    Private Sub chbHighlightBraces_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHighlightBraces.CheckedChanged
        ' updating matching braces appearance
        If chbHighlightBraces.Checked Then
            syntaxEdit.Braces.BracesOptions = syntaxEdit.Braces.BracesOptions Or BracesOptions.Highlight
        Else
            syntaxEdit.Braces.BracesOptions = syntaxEdit.Braces.BracesOptions Xor BracesOptions.Highlight
        End If
        syntaxSplitEdit.Braces.BracesOptions = syntaxEdit.Braces.BracesOptions
    End Sub

    Private Sub chbUseRoundRect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUseRoundRect.CheckedChanged
        ' updating matching braces appearance
        syntaxEdit.Braces.UseRoundRect = chbUseRoundRect.Checked
        syntaxSplitEdit.Braces.UseRoundRect = chbUseRoundRect.Checked
        If chbUseRoundRect.Checked Then
            syntaxEdit.Braces.ForeColor = Color.Gray
        Else
            syntaxEdit.Braces.ForeColor = Color.Black
        End If
        syntaxSplitEdit.Braces.ForeColor = syntaxEdit.Braces.ForeColor
    End Sub

    Private Sub cbTempHighlightBraces_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTempHighlightBraces.CheckedChanged
        ' updating matching braces appearance
        If cbTempHighlightBraces.Checked Then
            syntaxEdit.Braces.BracesOptions = syntaxEdit.Braces.BracesOptions Or BracesOptions.TempHighlight
        Else
            syntaxEdit.Braces.BracesOptions = syntaxEdit.Braces.BracesOptions Xor BracesOptions.TempHighlight
        End If
        syntaxSplitEdit.Braces.BracesOptions = syntaxEdit.Braces.BracesOptions
    End Sub

    Private Sub cbPageLayout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPageLayout.SelectedIndexChanged
        ' updating page layout mode
        syntaxEdit.Pages.PageType = CType(cbPageLayout.SelectedIndex, QWhale.Editor.PageType)
        syntaxSplitEdit.Pages.PageType = CType(cbPageLayout.SelectedIndex, QWhale.Editor.PageType)
        If cbPageSize.Items.Count > 0 Then
            cbPageSize.SelectedIndex = Math.Max(cbPageSize.Items.IndexOf(syntaxEdit.Pages.DefaultPage.PageKind), 0)
        End If
    End Sub
    Private Sub UpdatePageKind(ByVal edit As ISyntaxEdit, ByVal kind As PaperKind)
        For i As Integer = 0 To edit.Pages.Count - 1
            edit.Pages(i).PageKind = kind
        Next i
    End Sub

    Private Sub cbPageSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPageSize.SelectedIndexChanged
        ' updating page size
        Dim obj As Object = [Enum].Parse(GetType(PaperKind), cbPageSize.Text)
        If TypeOf obj Is PaperKind Then
            UpdatePageKind(syntaxEdit, CType(obj, PaperKind))
            UpdatePageKind(syntaxSplitEdit, CType(obj, PaperKind))
        End If
    End Sub

    Private Sub chbHorzRuler_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHorzRuler.CheckedChanged
        ' updating ruler options
        If chbHorzRuler.Checked Then
            syntaxEdit.Pages.Rulers = syntaxEdit.Pages.Rulers Or EditRulers.Horizonal
        Else
            syntaxEdit.Pages.Rulers = syntaxEdit.Pages.Rulers Xor EditRulers.Horizonal
        End If
        syntaxSplitEdit.Pages.Rulers = syntaxEdit.Pages.Rulers
    End Sub

    Private Sub chbVertRuler_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVertRuler.CheckedChanged
        ' updating ruler options
        If chbVertRuler.Checked Then
            syntaxEdit.Pages.Rulers = syntaxEdit.Pages.Rulers Or EditRulers.Vertical
        Else
            syntaxEdit.Pages.Rulers = syntaxEdit.Pages.Rulers Xor EditRulers.Vertical
        End If
        syntaxSplitEdit.Pages.Rulers = syntaxEdit.Pages.Rulers
    End Sub

    Private Sub cbRulerUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRulerUnits.SelectedIndexChanged
        ' updating ruler units
        syntaxEdit.Pages.RulerUnits = CType(cbRulerUnits.SelectedIndex, RulerUnits)
        syntaxSplitEdit.Pages.RulerUnits = CType(cbRulerUnits.SelectedIndex, RulerUnits)
    End Sub

    Private Sub chbRulerAllowDrag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRulerAllowDrag.CheckedChanged
        ' updating ruler options
        If chbRulerAllowDrag.Checked Then
            syntaxEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions Or RulerOptions.AllowDrag
        Else
            syntaxEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions Xor RulerOptions.AllowDrag
        End If
        syntaxSplitEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions
    End Sub

    Private Sub chbRulerDiscrete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRulerDiscrete.CheckedChanged
        ' updating ruler options
        If chbRulerDiscrete.Checked Then
            syntaxEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions Or RulerOptions.Discrete
        Else
            syntaxEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions Xor RulerOptions.Discrete
        End If
        syntaxSplitEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions
    End Sub

    Private Sub chbRulerDisplayDragLines_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRulerDisplayDragLines.CheckedChanged
        ' updating ruler options
        If chbRulerDisplayDragLines.Checked Then
            syntaxEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions Or RulerOptions.DisplayDragLine
        Else
            syntaxEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions Xor RulerOptions.DisplayDragLine
        End If
        syntaxSplitEdit.Pages.RulerOptions = syntaxEdit.Pages.RulerOptions
    End Sub

    Private Sub syntaxEdit_WordSpell(ByVal sender As System.Object, ByVal e As QWhale.Editor.WordSpellEventArgs) Handles syntaxEdit.WordSpell
        ' sample event for checking spelling
        e.Correct = (syntaxEdit.Lexer Is Nothing) Or Not syntaxEdit.Lexer.Scheme.IsPlainText(e.ColorStyle - 1)
    End Sub

    Private Sub chbLineModificator_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLineModificator.CheckedChanged
        ' updating line modificator visibility
        If chbLineModificator.Checked Then
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Or GutterOptions.PaintLineModificators
        Else
            syntaxEdit.Gutter.Options = syntaxEdit.Gutter.Options Xor GutterOptions.PaintLineModificators
        End If
        syntaxSplitEdit.Gutter.Options = syntaxEdit.Gutter.Options

    End Sub

    Private Sub chbAllowSplit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAllowSplit.CheckedChanged
        ' updating splitting options
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbAllowSplit.Checked Then
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Or ScrollingOptions.AllowSplitHorz Or ScrollingOptions.AllowSplitVert
        Else
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Xor ScrollingOptions.AllowSplitHorz Xor ScrollingOptions.AllowSplitVert
        End If
        syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options
        UpdateScrollBoxes(chbAllowSplit)
    End Sub

    Private Sub chbScrollButtons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbScrollButtons.CheckedChanged
        ' updating scrolling options
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbScrollButtons.Checked Then
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Or ScrollingOptions.HorzButtons Or ScrollingOptions.VertButtons
        Else
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Xor ScrollingOptions.HorzButtons Xor ScrollingOptions.VertButtons
        End If
        syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options
        UpdateScrollBoxes(chbScrollButtons)
    End Sub

    Private Sub chbSystemScrollBars_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSystemScrollBars.CheckedChanged
        ' updating scrolling options
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbSystemScrollBars.Checked Then
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Or ScrollingOptions.SystemScrollbars
        Else
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Xor ScrollingOptions.SystemScrollbars
        End If
        syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options
        UpdateScrollBoxes(chbSystemScrollBars)
    End Sub

    Private Sub chbFlatScrollBars_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFlatScrollBars.CheckedChanged
        ' updating scrolling options
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbFlatScrollBars.Checked Then
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Or ScrollingOptions.FlatScrollbars
        Else
            syntaxEdit.Scrolling.Options = syntaxEdit.Scrolling.Options Xor ScrollingOptions.FlatScrollbars
        End If
        syntaxSplitEdit.Scrolling.Options = syntaxEdit.Scrolling.Options
        UpdateScrollBoxes(chbFlatScrollBars)
    End Sub

    Private Sub syntaxEdit_ScrollButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles syntaxEdit.ScrollButtonClick
        ' sample event for scrolling buttons
        If (TypeOf sender Is IScrollingButton) Then
            Select Case (CType(sender, IScrollingButton).Name)
                Case "Normal"
                    syntaxEdit.Pages.PageType = PageType.Normal
                Case "PageLayout"
                    syntaxEdit.Pages.PageType = PageType.PageLayout
                Case "PageBreaks"
                    syntaxEdit.Pages.PageType = PageType.PageBreaks
                Case "PageUp"
                    syntaxEdit.MovePageUp()
                Case "PageDown"
                    syntaxEdit.MovePageDown()
            End Select
        End If
    End Sub

    Private Sub treeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeView1.AfterSelect
        UpdatePanels(e.Node)
    End Sub
    Friend Class CustomElementSite
        Implements ISite, IServiceProvider
        Private fComponent As IComponent
        Private fContainer As DefaultComponentContainer
        Private fName As String
        Friend Sub New(ByVal component As IComponent, ByVal container As DefaultComponentContainer, ByVal name As String)
            fComponent = component
            fContainer = container
            fName = name
        End Sub
        Public Function GetService(ByVal service As Type) As Object Implements IServiceProvider.GetService
            If TypeOf service Is ITypeDescriptorFilterService Then
                Return CType(fComponent, ITypeDescriptorFilterService)
            End If
            If Not TypeOf service Is ISite Then
                Return fContainer.GetService(service)
            End If
            Return Me
        End Function
        Public ReadOnly Property Component() As IComponent Implements ISite.Component
            Get
                Return fComponent
            End Get
        End Property
        Public ReadOnly Property Container() As IContainer Implements ISite.Container
            Get
                Return fContainer
            End Get
        End Property
        Public ReadOnly Property DesignMode() As Boolean Implements ISite.DesignMode
            Get
                Return False
            End Get
        End Property
        Public Property Name() As String Implements ISite.Name
            Get
                Return fName
            End Get
            Set(ByVal Value As String)
                fName = Value
            End Set
        End Property
    End Class

    Friend Class DefaultComponentContainer
        Inherits Container
        Protected Overrides Function CreateSite(ByVal component As IComponent, ByVal name As String) As ISite
            Return New CustomElementSite(component, Me, name)
        End Function
        Public Shadows Function GetService(ByVal service As Type) As Object
            Return MyBase.GetService(service)
        End Function
    End Class
    Friend Class ComponentTypeDescriptorEx
        Inherits ComponentTypeDescriptor
        Private obsolete As ArrayList = Nothing
        Public Sub New(ByVal owner As Component)
            MyBase.New(owner)
        End Sub
        Public Sub New(ByVal owner As Component, ByVal obsolete As ArrayList)
            MyBase.New(owner)
            Me.obsolete = obsolete
        End Sub

        Protected Overrides Function TypeDescriptorGetProperties(ByVal attributes As Attribute()) As PropertyDescriptorCollection
            Dim result As PropertyDescriptorCollection = MyBase.TypeDescriptorGetProperties(attributes)
            Dim props As ArrayList = New ArrayList

            props.AddRange(result)
            RemoveObsoleteProperties(props)
            Dim propArray As PropertyDescriptor() = CType(props.ToArray(GetType(PropertyDescriptor)), PropertyDescriptor())
            Return New PropertyDescriptorCollection(propArray)
        End Function
        Private Sub RemoveObsoleteProperties(ByRef properties As ArrayList)
            For i As Integer = properties.Count - 1 To 0 Step -1
                If (obsolete.Contains((CType(properties(i), PropertyDescriptor).Name))) Then
                    properties.Remove(properties(i))
                End If
            Next i
        End Sub
    End Class
    Friend Class ComponentTypeDescriptor
        Inherits Component
        Implements ICustomTypeDescriptor

        Public owner As Component
        Public Sub New(ByVal owner As Component)
            Me.owner = owner
        End Sub
        Function GetAttributes() As AttributeCollection Implements ICustomTypeDescriptor.GetAttributes
            Return TypeDescriptor.GetAttributes(owner, True)
        End Function
        Function GetClassName() As String Implements ICustomTypeDescriptor.GetClassName
            Return TypeDescriptor.GetClassName(owner, True)
        End Function
        Function GetComponentName() As String Implements ICustomTypeDescriptor.GetComponentName
            Return TypeDescriptor.GetComponentName(owner, True)
        End Function
        Function GetConverter() As TypeConverter Implements ICustomTypeDescriptor.GetConverter
            Return TypeDescriptor.GetConverter(owner, True)
        End Function
        Function GetDefaultEvent() As EventDescriptor Implements ICustomTypeDescriptor.GetDefaultEvent
            Return TypeDescriptor.GetDefaultEvent(owner, True)
        End Function
        Function GetEditor(ByVal editorBaseType As Type) As Object Implements ICustomTypeDescriptor.GetEditor
            Return TypeDescriptor.GetEditor(owner, editorBaseType, True)
        End Function
        Function GetEvents() As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
            Return TypeDescriptor.GetEvents(owner, True)
        End Function
        Protected Overridable Function TypeDescriptorGetProperties(ByVal attributes As Attribute()) As PropertyDescriptorCollection
            Return TypeDescriptor.GetProperties(owner, attributes, True)
        End Function
        Function GetProperties(ByVal attributes As Attribute()) As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
            Return TypeDescriptorGetProperties(attributes)
        End Function
        Function GetDefaultProperty() As PropertyDescriptor Implements ICustomTypeDescriptor.GetDefaultProperty
            Return TypeDescriptor.GetDefaultProperty(owner, True)
        End Function
        Function GetEvents(ByVal attributes As Attribute()) As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
            Return TypeDescriptor.GetEvents(owner, attributes, True)
        End Function

        Function GetProperties() As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
            Return (CType(owner, ICustomTypeDescriptor).GetProperties(Nothing))
        End Function
        Function GetPropertyOwner(ByVal pd As PropertyDescriptor) As Object Implements ICustomTypeDescriptor.GetPropertyOwner
            Return owner
        End Function
    End Class

    Private Sub chbQuickInfoTips_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbQuickInfoTips.CheckedChanged
        If chbQuickInfoTips.Checked Then
            csParser1.Options = csParser1.Options Or SyntaxOptions.QuickInfoTips
        Else
            csParser1.Options = csParser1.Options Xor SyntaxOptions.QuickInfoTips
        End If
    End Sub

    Private Sub chbDrawColumnsIndent_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDrawColumnsIndent.CheckedChanged
        syntaxEdit.DrawColumnsIndent = chbDrawColumnsIndent.Checked
        syntaxSplitEdit.DrawColumnsIndent = chbDrawColumnsIndent.Checked
    End Sub

    Private Sub chbColumnsVisible_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbColumnsVisible.CheckedChanged
        syntaxEdit.EditMargin.ColumnsVisible = chbColumnsVisible.Checked
        syntaxSplitEdit.EditMargin.ColumnsVisible = chbColumnsVisible.Checked
    End Sub
End Class
