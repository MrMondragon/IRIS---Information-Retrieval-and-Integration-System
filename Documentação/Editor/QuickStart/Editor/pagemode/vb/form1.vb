Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Printing
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
    Friend WithEvents gbRulers As System.Windows.Forms.GroupBox
    Friend WithEvents chbVertRuler As System.Windows.Forms.CheckBox
    Friend WithEvents chbHorzRuler As System.Windows.Forms.CheckBox
    Friend WithEvents cbRulerUnits As System.Windows.Forms.ComboBox
    Friend WithEvents laRulerUnits As System.Windows.Forms.Label
    Friend WithEvents chbRulerDisplayDragLines As System.Windows.Forms.CheckBox
    Friend WithEvents chbRulerDiscrete As System.Windows.Forms.CheckBox
    Friend WithEvents chbRulerAllowDrag As System.Windows.Forms.CheckBox
    Friend WithEvents gbPages As System.Windows.Forms.GroupBox
    Friend WithEvents cbPageSize As System.Windows.Forms.ComboBox
    Friend WithEvents laPageSize As System.Windows.Forms.Label
    Friend WithEvents cbPageLayout As System.Windows.Forms.ComboBox
    Friend WithEvents laPageLayout As System.Windows.Forms.Label
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.gbRulers = New System.Windows.Forms.GroupBox
        Me.chbVertRuler = New System.Windows.Forms.CheckBox
        Me.chbHorzRuler = New System.Windows.Forms.CheckBox
        Me.cbRulerUnits = New System.Windows.Forms.ComboBox
        Me.laRulerUnits = New System.Windows.Forms.Label
        Me.chbRulerDisplayDragLines = New System.Windows.Forms.CheckBox
        Me.chbRulerDiscrete = New System.Windows.Forms.CheckBox
        Me.chbRulerAllowDrag = New System.Windows.Forms.CheckBox
        Me.gbPages = New System.Windows.Forms.GroupBox
        Me.cbPageSize = New System.Windows.Forms.ComboBox
        Me.laPageSize = New System.Windows.Forms.Label
        Me.cbPageLayout = New System.Windows.Forms.ComboBox
        Me.laPageLayout = New System.Windows.Forms.Label
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.pnSettings.SuspendLayout()
        Me.gbRulers.SuspendLayout()
        Me.gbPages.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.gbRulers)
        Me.pnSettings.Controls.Add(Me.gbPages)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 136)
        Me.pnSettings.TabIndex = 2
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
        Me.gbRulers.Location = New System.Drawing.Point(208, 32)
        Me.gbRulers.Name = "gbRulers"
        Me.gbRulers.Size = New System.Drawing.Size(352, 96)
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
        Me.laRulerUnits.Location = New System.Drawing.Point(12, 67)
        Me.laRulerUnits.Name = "laRulerUnits"
        Me.laRulerUnits.Size = New System.Drawing.Size(60, 16)
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
        'gbPages
        '
        Me.gbPages.Controls.Add(Me.cbPageSize)
        Me.gbPages.Controls.Add(Me.laPageSize)
        Me.gbPages.Controls.Add(Me.cbPageLayout)
        Me.gbPages.Controls.Add(Me.laPageLayout)
        Me.gbPages.Location = New System.Drawing.Point(8, 32)
        Me.gbPages.Name = "gbPages"
        Me.gbPages.Size = New System.Drawing.Size(184, 96)
        Me.gbPages.TabIndex = 15
        Me.gbPages.TabStop = False
        Me.gbPages.Text = "Pages"
        '
        'cbPageSize
        '
        Me.cbPageSize.Location = New System.Drawing.Point(80, 48)
        Me.cbPageSize.Name = "cbPageSize"
        Me.cbPageSize.Size = New System.Drawing.Size(96, 21)
        Me.cbPageSize.TabIndex = 4
        '
        'laPageSize
        '
        Me.laPageSize.AutoSize = True
        Me.laPageSize.Location = New System.Drawing.Point(8, 51)
        Me.laPageSize.Name = "laPageSize"
        Me.laPageSize.Size = New System.Drawing.Size(56, 16)
        Me.laPageSize.TabIndex = 3
        Me.laPageSize.Text = "Page Size"
        '
        'cbPageLayout
        '
        Me.cbPageLayout.Location = New System.Drawing.Point(80, 24)
        Me.cbPageLayout.Name = "cbPageLayout"
        Me.cbPageLayout.Size = New System.Drawing.Size(96, 21)
        Me.cbPageLayout.TabIndex = 2
        '
        'laPageLayout
        '
        Me.laPageLayout.AutoSize = True
        Me.laPageLayout.Location = New System.Drawing.Point(8, 27)
        Me.laPageLayout.Name = "laPageLayout"
        Me.laPageLayout.Size = New System.Drawing.Size(68, 16)
        Me.laPageLayout.TabIndex = 1
        Me.laPageLayout.Text = "Page Layout"
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
        Me.laDescription.Text = "This demo shows how to use different page layout modes of the edit control text."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Gutter.Visible = False
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 136)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Pages.PageType = QWhale.Editor.PageType.PageLayout
        Me.syntaxEdit1.Pages.Rulers = CType((QWhale.Editor.EditRulers.Horizonal Or QWhale.Editor.EditRulers.Vertical), QWhale.Editor.EditRulers)
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 246)
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
        Me.ClientSize = New System.Drawing.Size(568, 382)
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.gbRulers.ResumeLayout(False)
        Me.gbPages.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim s As String() = [Enum].GetNames(GetType(PageType))
        cbPageLayout.Items.AddRange(s)
        cbPageLayout.SelectedIndex = syntaxEdit1.Pages.PageType
        For Each psize As PaperSize In syntaxEdit1.Printing.PrinterSettings.PaperSizes
            If (Not cbPageSize.Items.Contains(psize.Kind)) Then
                cbPageSize.Items.Add(psize.Kind)
            End If
        Next psize
        If (cbPageSize.Items.Count > 0) Then
            cbPageSize.SelectedIndex = Math.Max(cbPageSize.Items.IndexOf(syntaxEdit1.Pages.DefaultPage.PageKind), 0)
            cbPageSize.Enabled = True
        Else
            cbPageSize.Enabled = False
        End If
        s = [Enum].GetNames(GetType(RulerUnits))
        cbRulerUnits.Items.AddRange(s)
        cbRulerUnits.SelectedIndex = syntaxEdit1.Pages.RulerUnits
        chbRulerAllowDrag.Checked = (RulerOptions.AllowDrag And syntaxEdit1.Pages.RulerOptions) <> 0
        chbRulerDiscrete.Checked = (RulerOptions.Discrete And syntaxEdit1.Pages.RulerOptions) <> 0
        chbRulerDisplayDragLines.Checked = (RulerOptions.DisplayDragLine And syntaxEdit1.Pages.RulerOptions) <> 0
        chbHorzRuler.Checked = (EditRulers.Horizonal And syntaxEdit1.Pages.Rulers) <> 0
        chbVertRuler.Checked = (EditRulers.Vertical And syntaxEdit1.Pages.Rulers) <> 0
    End Sub

    Private Sub cbPageLayout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPageLayout.SelectedIndexChanged
        syntaxEdit1.Pages.PageType = CType(cbPageLayout.SelectedIndex, PageType)
    End Sub

    Private Sub cbPageSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPageSize.SelectedIndexChanged
        Dim obj As Object = [Enum].Parse(GetType(PaperKind), cbPageSize.Text)
        If (TypeOf obj Is PaperKind) Then
            For i As Integer = syntaxEdit1.Pages.Count - 1 To 0 Step -1
                syntaxEdit1.Pages(i).PageKind = CType(obj, PaperKind)
            Next i
        End If
    End Sub

    Private Sub chbHorzRuler_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHorzRuler.CheckedChanged
        If chbHorzRuler.Checked Then
            syntaxEdit1.Pages.Rulers = syntaxEdit1.Pages.Rulers Or EditRulers.Horizonal
        Else
            syntaxEdit1.Pages.Rulers = syntaxEdit1.Pages.Rulers Xor EditRulers.Horizonal
        End If
    End Sub

    Private Sub chbVertRuler_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVertRuler.CheckedChanged
        If chbVertRuler.Checked Then
            syntaxEdit1.Pages.Rulers = syntaxEdit1.Pages.Rulers Or EditRulers.Vertical
        Else
            syntaxEdit1.Pages.Rulers = syntaxEdit1.Pages.Rulers Xor EditRulers.Vertical
        End If
    End Sub

    Private Sub cbRulerUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRulerUnits.SelectedIndexChanged
        syntaxEdit1.Pages.RulerUnits = CType(cbRulerUnits.SelectedIndex, RulerUnits)
    End Sub

    Private Sub chbRulerAllowDrag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRulerAllowDrag.CheckedChanged
        If chbRulerAllowDrag.Checked Then
            syntaxEdit1.Pages.RulerOptions = syntaxEdit1.Pages.RulerOptions Or RulerOptions.AllowDrag
        Else
            syntaxEdit1.Pages.RulerOptions = syntaxEdit1.Pages.RulerOptions Xor RulerOptions.AllowDrag
        End If
    End Sub

    Private Sub chbRulerDiscrete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRulerDiscrete.CheckedChanged
        If chbRulerDiscrete.Checked Then
            syntaxEdit1.Pages.RulerOptions = syntaxEdit1.Pages.RulerOptions Or RulerOptions.Discrete
        Else
            syntaxEdit1.Pages.RulerOptions = syntaxEdit1.Pages.RulerOptions Xor RulerOptions.Discrete
        End If
    End Sub

    Private Sub chbRulerDisplayDragLines_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRulerDisplayDragLines.CheckedChanged
        If chbRulerDisplayDragLines.Checked Then
            syntaxEdit1.Pages.RulerOptions = syntaxEdit1.Pages.RulerOptions Or RulerOptions.DisplayDragLine
        Else
            syntaxEdit1.Pages.RulerOptions = syntaxEdit1.Pages.RulerOptions Xor RulerOptions.DisplayDragLine
        End If
    End Sub
End Class
