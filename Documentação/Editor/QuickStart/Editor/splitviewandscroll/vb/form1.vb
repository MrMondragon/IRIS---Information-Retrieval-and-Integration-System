Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports QWhale.Common
Imports QWhale.Syntax
Imports QWhale.Editor

Public Class Form1
    Inherits System.Windows.Forms.Form
    <STAThread()> Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub

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
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chbFlatScrollBars As System.Windows.Forms.CheckBox
    Friend WithEvents chbSystemScrollBars As System.Windows.Forms.CheckBox
    Friend WithEvents chbSmoothScroll As System.Windows.Forms.CheckBox
    Friend WithEvents chbShowScrollHint As System.Windows.Forms.CheckBox
    Friend WithEvents chbVertButton As System.Windows.Forms.CheckBox
    Friend WithEvents chbHorzButton As System.Windows.Forms.CheckBox
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chbAllowSplitHorz As System.Windows.Forms.CheckBox
    Friend WithEvents chbAllowSplitVert As System.Windows.Forms.CheckBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents imageList2 As System.Windows.Forms.ImageList
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Dim ScrollingButton1 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Dim ScrollingButton2 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Dim ScrollingButton3 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Dim ScrollingButton4 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Dim ScrollingButton5 As QWhale.Editor.ScrollingButton = New QWhale.Editor.ScrollingButton
        Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.chbFlatScrollBars = New System.Windows.Forms.CheckBox
        Me.chbSystemScrollBars = New System.Windows.Forms.CheckBox
        Me.chbSmoothScroll = New System.Windows.Forms.CheckBox
        Me.chbShowScrollHint = New System.Windows.Forms.CheckBox
        Me.chbVertButton = New System.Windows.Forms.CheckBox
        Me.chbHorzButton = New System.Windows.Forms.CheckBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.chbAllowSplitHorz = New System.Windows.Forms.CheckBox
        Me.chbAllowSplitVert = New System.Windows.Forms.CheckBox
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.pnSettings.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList2
        '
        Me.imageList2.ImageSize = New System.Drawing.Size(15, 15)
        Me.imageList2.ImageStream = CType(resources.GetObject("imageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.groupBox2)
        Me.pnSettings.Controls.Add(Me.groupBox1)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 104)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.chbFlatScrollBars)
        Me.groupBox2.Controls.Add(Me.chbSystemScrollBars)
        Me.groupBox2.Controls.Add(Me.chbSmoothScroll)
        Me.groupBox2.Controls.Add(Me.chbShowScrollHint)
        Me.groupBox2.Controls.Add(Me.chbVertButton)
        Me.groupBox2.Controls.Add(Me.chbHorzButton)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox2.Location = New System.Drawing.Point(200, 24)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(368, 80)
        Me.groupBox2.TabIndex = 14
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Scrolling"
        '
        'chbFlatScrollBars
        '
        Me.chbFlatScrollBars.Location = New System.Drawing.Point(232, 40)
        Me.chbFlatScrollBars.Name = "chbFlatScrollBars"
        Me.chbFlatScrollBars.TabIndex = 16
        Me.chbFlatScrollBars.Text = "Flat Scroll"
        '
        'chbSystemScrollBars
        '
        Me.chbSystemScrollBars.Location = New System.Drawing.Point(232, 16)
        Me.chbSystemScrollBars.Name = "chbSystemScrollBars"
        Me.chbSystemScrollBars.TabIndex = 15
        Me.chbSystemScrollBars.Text = "System Scroll"
        '
        'chbSmoothScroll
        '
        Me.chbSmoothScroll.Location = New System.Drawing.Point(112, 40)
        Me.chbSmoothScroll.Name = "chbSmoothScroll"
        Me.chbSmoothScroll.TabIndex = 14
        Me.chbSmoothScroll.Text = "Smooth Scroll"
        '
        'chbShowScrollHint
        '
        Me.chbShowScrollHint.Location = New System.Drawing.Point(112, 16)
        Me.chbShowScrollHint.Name = "chbShowScrollHint"
        Me.chbShowScrollHint.Size = New System.Drawing.Size(112, 24)
        Me.chbShowScrollHint.TabIndex = 13
        Me.chbShowScrollHint.Text = "Show Scroll Hint"
        '
        'chbVertButton
        '
        Me.chbVertButton.Location = New System.Drawing.Point(8, 40)
        Me.chbVertButton.Name = "chbVertButton"
        Me.chbVertButton.TabIndex = 12
        Me.chbVertButton.Text = "Vert Button"
        '
        'chbHorzButton
        '
        Me.chbHorzButton.Location = New System.Drawing.Point(8, 16)
        Me.chbHorzButton.Name = "chbHorzButton"
        Me.chbHorzButton.TabIndex = 11
        Me.chbHorzButton.Text = "Horz Button"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.chbAllowSplitHorz)
        Me.groupBox1.Controls.Add(Me.chbAllowSplitVert)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(200, 80)
        Me.groupBox1.TabIndex = 13
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Split"
        '
        'chbAllowSplitHorz
        '
        Me.chbAllowSplitHorz.Location = New System.Drawing.Point(8, 16)
        Me.chbAllowSplitHorz.Name = "chbAllowSplitHorz"
        Me.chbAllowSplitHorz.Size = New System.Drawing.Size(112, 24)
        Me.chbAllowSplitHorz.TabIndex = 9
        Me.chbAllowSplitHorz.Text = "Split Horizontally"
        '
        'chbAllowSplitVert
        '
        Me.chbAllowSplitVert.Location = New System.Drawing.Point(8, 40)
        Me.chbAllowSplitVert.Name = "chbAllowSplitVert"
        Me.chbAllowSplitVert.Size = New System.Drawing.Size(112, 24)
        Me.chbAllowSplitVert.TabIndex = 10
        Me.chbAllowSplitVert.Text = "Split Vertically"
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(568, 24)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(568, 24)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo shows ability to visually split edit control to provide different views" & _
        " of the same text."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 104)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        ScrollingButton1.Description = "Page Normal Mode"
        ScrollingButton1.ImageIndex = 0
        ScrollingButton1.Images = Me.imageList2
        ScrollingButton1.Name = "Normal"
        ScrollingButton1.Visible = False
        ScrollingButton2.Description = "Page Layout Mode"
        ScrollingButton2.ImageIndex = 1
        ScrollingButton2.Images = Me.imageList2
        ScrollingButton2.Name = "PageLayout"
        ScrollingButton2.Visible = False
        ScrollingButton3.Description = "Page Breaks Mode"
        ScrollingButton3.ImageIndex = 2
        ScrollingButton3.Images = Me.imageList2
        ScrollingButton3.Name = "PageBreaks"
        ScrollingButton3.Visible = False
        Me.syntaxEdit1.Scroll.HorizontalButtons.AddRange(New QWhale.Editor.ScrollingButton() {ScrollingButton1, ScrollingButton2, ScrollingButton3})
        Me.syntaxEdit1.Scroll.Options = CType((((QWhale.Editor.ScrollingOptions.SmoothScroll Or QWhale.Editor.ScrollingOptions.UseScrollDelta) _
                    Or QWhale.Editor.ScrollingOptions.AllowSplitHorz) _
                    Or QWhale.Editor.ScrollingOptions.AllowSplitVert), QWhale.Editor.ScrollingOptions)
        Me.syntaxEdit1.Scroll.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        ScrollingButton4.Description = "Page Down"
        ScrollingButton4.ImageIndex = 3
        ScrollingButton4.Images = Me.imageList2
        ScrollingButton4.Name = "PageDown"
        ScrollingButton4.Visible = False
        ScrollingButton5.Description = "Page Up"
        ScrollingButton5.ImageIndex = 4
        ScrollingButton5.Images = Me.imageList2
        ScrollingButton5.Name = "PageUp"
        ScrollingButton5.Visible = False
        Me.syntaxEdit1.Scroll.VerticalButtons.AddRange(New QWhale.Editor.ScrollingButton() {ScrollingButton4, ScrollingButton5})
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 214)
        Me.syntaxEdit1.TabIndex = 3
        Me.syntaxEdit1.Text = "Imports System" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class Person" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public age As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public name" & _
        " As String" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class MainClass" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public Sub New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " Dim p " & _
        "As Person = New Person" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Console.Write(""Name: {0}, Age: {1}"", p.name, p.a" & _
        "ge)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class"
        '
        'VbParser1
        '
        Me.VbParser1.DefaultState = 0
        Me.VbParser1.Options = CType(((((QWhale.Syntax.SyntaxOptions.Outline Or QWhale.Syntax.SyntaxOptions.SmartIndent) _
                    Or QWhale.Syntax.SyntaxOptions.CodeCompletion) _
                    Or QWhale.Syntax.SyntaxOptions.SyntaxErrors) _
                    Or QWhale.Syntax.SyntaxOptions.ReparseOnLineChange), QWhale.Syntax.SyntaxOptions)
        Me.VbParser1.XmlScheme = "<?xml version=""1.0"" encoding=""utf-16""?>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "<LexScheme xmlns:xsd=""http://www.w3.org/" & _
        "2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Autho" & _
        "r>Quantum Whale LLC.</Author>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Name />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Desc />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Copyright>Copyright (c" & _
        ") 2004, 2005 Quantum Whale LLC.</Copyright>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileExtension />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileType />" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Version>1.1</Version>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>idents</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "      <ForeColor>ControlText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>numbers</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Green</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "   <Index>1</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>reswords</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "   <ForeColor>Blue</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>2</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style" & _
        ">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>comments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Green</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index" & _
        ">3</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      " & _
        "<Name>xmlcomments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Gray</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>4</Ind" & _
        "ex>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>symbols</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Gra" & _
        "y</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>5</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>wh" & _
        "itespace</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>WindowText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>6</Index>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>strings</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Maroon" & _
        "</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>7</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </S" & _
        "tyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>directives</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Blue</ForeCo" & _
        "lor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>8</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>syntaxerror" & _
        "s</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Red</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>9</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <States />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "</LexScheme>"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 318)
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private scrollBoxUpdate As Integer

    Private Sub UpdateScrollBoxes(ByVal sender As Object)
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        scrollBoxUpdate = scrollBoxUpdate + 1
        Try
            If (Not chbAllowSplitHorz Is sender) Then
                chbAllowSplitHorz.Checked = ((ScrollingOptions.AllowSplitHorz And syntaxEdit1.Scrolling.Options) <> 0)
            End If
            If (Not chbAllowSplitVert Is sender) Then
                chbAllowSplitVert.Checked = ((ScrollingOptions.AllowSplitVert And syntaxEdit1.Scrolling.Options) <> 0)
            End If
            If (Not chbHorzButton Is sender) Then
                chbHorzButton.Checked = ((ScrollingOptions.HorzButtons And syntaxEdit1.Scrolling.Options) <> 0)
            End If
            If (Not chbVertButton Is sender) Then
                chbVertButton.Checked = ((ScrollingOptions.VertButtons And syntaxEdit1.Scrolling.Options) <> 0)
            End If
            If (Not chbSystemScrollBars Is sender) Then
                chbSystemScrollBars.Checked = (syntaxEdit1.Scrolling.Options And ScrollingOptions.SystemScrollbars) <> 0
            End If
            If (Not chbFlatScrollBars Is sender) Then
                chbFlatScrollBars.Checked = (syntaxEdit1.Scrolling.Options And ScrollingOptions.FlatScrollbars) <> 0
            End If
        Finally
            scrollBoxUpdate = scrollBoxUpdate - 1
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbAllowSplitHorz.Checked = ((ScrollingOptions.AllowSplitHorz And syntaxEdit1.Scrolling.Options) <> 0)
        chbAllowSplitVert.Checked = ((ScrollingOptions.AllowSplitVert And syntaxEdit1.Scrolling.Options) <> 0)
        chbHorzButton.Checked = ((ScrollingOptions.HorzButtons And syntaxEdit1.Scrolling.Options) <> 0)
        chbVertButton.Checked = ((ScrollingOptions.VertButtons And syntaxEdit1.Scrolling.Options) <> 0)
        chbShowScrollHint.Checked = (syntaxEdit1.Scrolling.Options And ScrollingOptions.ShowScrollHint) <> 0
        chbSmoothScroll.Checked = (syntaxEdit1.Scrolling.Options And ScrollingOptions.SmoothScroll) <> 0
        chbSystemScrollBars.Checked = (syntaxEdit1.Scrolling.Options And ScrollingOptions.SystemScrollbars) <> 0
        chbFlatScrollBars.Checked = (syntaxEdit1.Scrolling.Options And ScrollingOptions.FlatScrollbars) <> 0
    End Sub

    Private Sub syntaxEdit1_ScrollButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles syntaxEdit1.ScrollButtonClick
        If (TypeOf sender Is IScrollingButton) Then
            Select Case (CType(sender, IScrollingButton).Name)
            Case "Normal"
                    syntaxEdit1.Pages.PageType = PageType.Normal
                Case "PageLayout"
                    syntaxEdit1.Pages.PageType = PageType.PageLayout
                Case "PageBreaks"
                    syntaxEdit1.Pages.PageType = PageType.PageBreaks
                Case "PageUp"
                    syntaxEdit1.MovePageUp()
                Case "PageDown"
                    syntaxEdit1.MovePageDown()
            End Select
        End If
    End Sub

    Private Sub chbAllowSplitHorz_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAllowSplitHorz.CheckedChanged
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbAllowSplitHorz.Checked Then
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Or ScrollingOptions.AllowSplitHorz
        Else
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Xor ScrollingOptions.AllowSplitHorz
        End If
        UpdateScrollBoxes(chbAllowSplitHorz)
    End Sub

    Private Sub chbAllowSplitVert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAllowSplitVert.CheckedChanged
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbAllowSplitVert.Checked Then
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Or ScrollingOptions.AllowSplitVert
        Else
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Xor ScrollingOptions.AllowSplitVert
        End If
        UpdateScrollBoxes(chbAllowSplitVert)
    End Sub

    Private Sub chbHorzButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHorzButton.CheckedChanged
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbHorzButton.Checked Then
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Or ScrollingOptions.HorzButtons
        Else
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Xor ScrollingOptions.HorzButtons
        End If
        UpdateScrollBoxes(chbHorzButton)
    End Sub

    Private Sub chbVertButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVertButton.CheckedChanged
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbVertButton.Checked Then
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Or ScrollingOptions.VertButtons
        Else
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Xor ScrollingOptions.VertButtons
        End If
        UpdateScrollBoxes(chbVertButton)
    End Sub

    Private Sub chbShowScrollHint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowScrollHint.CheckedChanged
        If chbShowScrollHint.Checked Then
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Or ScrollingOptions.ShowScrollHint
        Else
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Xor ScrollingOptions.ShowScrollHint
        End If
    End Sub

    Private Sub chbSmoothScroll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSmoothScroll.CheckedChanged
        If chbSmoothScroll.Checked Then
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Or ScrollingOptions.SmoothScroll
        Else
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Xor ScrollingOptions.SmoothScroll
        End If
    End Sub

    Private Sub chbSystemScrollBars_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSystemScrollBars.CheckedChanged
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbSystemScrollBars.Checked Then
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Or ScrollingOptions.SystemScrollbars
        Else
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Xor ScrollingOptions.SystemScrollbars
        End If
        UpdateScrollBoxes(chbSystemScrollBars)
    End Sub

    Private Sub chbFlatScrollBars_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFlatScrollBars.CheckedChanged
        If (scrollBoxUpdate > 0) Then
            Return
        End If
        If chbFlatScrollBars.Checked Then
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Or ScrollingOptions.FlatScrollbars
        Else
            syntaxEdit1.Scrolling.Options = syntaxEdit1.Scrolling.Options Xor ScrollingOptions.FlatScrollbars
        End If
        UpdateScrollBoxes(chbFlatScrollBars)
    End Sub
End Class
