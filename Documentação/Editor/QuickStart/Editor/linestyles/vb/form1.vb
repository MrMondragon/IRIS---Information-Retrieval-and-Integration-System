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
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chbLineStyleBeyondEol As System.Windows.Forms.CheckBox
    Friend WithEvents cbLineStyleColor As QWhale.Common.ColorBox
    Friend WithEvents laLineStyleColor As System.Windows.Forms.Label
    Friend WithEvents btSetBreakpoint As System.Windows.Forms.Button
    Friend WithEvents btStepOver As System.Windows.Forms.Button
    Friend WithEvents btStart As System.Windows.Forms.Button
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents contextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents cmStart As System.Windows.Forms.MenuItem
    Friend WithEvents cmStepOver As System.Windows.Forms.MenuItem
    Friend WithEvents cmSetBreakpoint As System.Windows.Forms.MenuItem
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim LineStyle1 As QWhale.Editor.LineStyle = New QWhale.Editor.LineStyle
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.chbLineStyleBeyondEol = New System.Windows.Forms.CheckBox
        Me.cbLineStyleColor = New QWhale.Common.ColorBox(Me.components)
        Me.laLineStyleColor = New System.Windows.Forms.Label
        Me.btSetBreakpoint = New System.Windows.Forms.Button
        Me.btStepOver = New System.Windows.Forms.Button
        Me.btStart = New System.Windows.Forms.Button
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.contextMenu1 = New System.Windows.Forms.ContextMenu
        Me.cmStart = New System.Windows.Forms.MenuItem
        Me.cmStepOver = New System.Windows.Forms.MenuItem
        Me.cmSetBreakpoint = New System.Windows.Forms.MenuItem
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.pnSettings.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.groupBox1)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 96)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.chbLineStyleBeyondEol)
        Me.groupBox1.Controls.Add(Me.cbLineStyleColor)
        Me.groupBox1.Controls.Add(Me.laLineStyleColor)
        Me.groupBox1.Controls.Add(Me.btSetBreakpoint)
        Me.groupBox1.Controls.Add(Me.btStepOver)
        Me.groupBox1.Controls.Add(Me.btStart)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 72)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Line Styles"
        '
        'chbLineStyleBeyondEol
        '
        Me.chbLineStyleBeyondEol.Location = New System.Drawing.Point(296, 16)
        Me.chbLineStyleBeyondEol.Name = "chbLineStyleBeyondEol"
        Me.chbLineStyleBeyondEol.Size = New System.Drawing.Size(144, 24)
        Me.chbLineStyleBeyondEol.TabIndex = 3
        Me.chbLineStyleBeyondEol.Text = "Line Style Beyond Eol"
        '
        'cbLineStyleColor
        '
        Me.cbLineStyleColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbLineStyleColor.Location = New System.Drawing.Point(392, 40)
        Me.cbLineStyleColor.Name = "cbLineStyleColor"
        Me.cbLineStyleColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbLineStyleColor.Size = New System.Drawing.Size(121, 21)
        Me.cbLineStyleColor.TabIndex = 5
        '
        'laLineStyleColor
        '
        Me.laLineStyleColor.AutoSize = True
        Me.laLineStyleColor.Location = New System.Drawing.Point(296, 43)
        Me.laLineStyleColor.Name = "laLineStyleColor"
        Me.laLineStyleColor.Size = New System.Drawing.Size(84, 16)
        Me.laLineStyleColor.TabIndex = 4
        Me.laLineStyleColor.Text = "Line Style Color"
        '
        'btSetBreakpoint
        '
        Me.btSetBreakpoint.Location = New System.Drawing.Point(168, 24)
        Me.btSetBreakpoint.Name = "btSetBreakpoint"
        Me.btSetBreakpoint.Size = New System.Drawing.Size(96, 23)
        Me.btSetBreakpoint.TabIndex = 2
        Me.btSetBreakpoint.Text = "Set Breakpoint"
        '
        'btStepOver
        '
        Me.btStepOver.Enabled = False
        Me.btStepOver.Location = New System.Drawing.Point(88, 24)
        Me.btStepOver.Name = "btStepOver"
        Me.btStepOver.TabIndex = 1
        Me.btStepOver.Text = "Step Over"
        '
        'btStart
        '
        Me.btStart.Location = New System.Drawing.Point(8, 24)
        Me.btStart.Name = "btStart"
        Me.btStart.TabIndex = 0
        Me.btStart.Text = "Start"
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
        Me.laDescription.Text = "This demo shows how line styles can be applied to individual lines within edit co" & _
        "ntrols's content."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        LineStyle1.ForeColor = System.Drawing.Color.Maroon
        LineStyle1.ImageIndex = 12
        LineStyle1.Name = ""
        Me.syntaxEdit1.LinesStyles.AddRange(New QWhale.Editor.LineStyle() {LineStyle1})
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 96)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 222)
        Me.syntaxEdit1.TabIndex = 3
        Me.syntaxEdit1.Text = "Public Class Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Inherits System.Windows.Forms.Form" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private Sub For" & _
        "m1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBa" & _
        "se.Load" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        chbLineNumbers.Checked = (GutterOptions.PaintLineNumbers And sy" & _
        "ntaxEdit1.Gutter.Options) <> 0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        chbLinesOnGutter.Checked = (GutterOption" & _
        "s.PaintLinesOnGutter And syntaxEdit1.Gutter.Options) <> 0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        nudLineNumber" & _
        "sStart.Maximum = 10000" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        nudLineNumbersStart.Value = syntaxEdit1.Gutter.L" & _
        "ineNumbersStart" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim s As String() = System.Enum.GetNames(GetType(String" & _
        "Alignment))" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        cbLineNumbersAlign.Items.AddRange(s)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        cbLineNumbers" & _
        "Align.SelectedIndex = syntaxEdit1.Gutter.LineNumbersAlignment" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End " & _
        "Class"
        '
        'contextMenu1
        '
        Me.contextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmStart, Me.cmStepOver, Me.cmSetBreakpoint})
        '
        'cmStart
        '
        Me.cmStart.Index = 0
        Me.cmStart.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.cmStart.Text = "Start"
        '
        'cmStepOver
        '
        Me.cmStepOver.Index = 1
        Me.cmStepOver.Shortcut = System.Windows.Forms.Shortcut.F10
        Me.cmStepOver.Text = "Step Over"
        '
        'cmSetBreakpoint
        '
        Me.cmSetBreakpoint.Index = 2
        Me.cmSetBreakpoint.Shortcut = System.Windows.Forms.Shortcut.F9
        Me.cmSetBreakpoint.Text = "Set Breakpoint"
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
        Me.ContextMenu = Me.contextMenu1
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private startDebug As Boolean
    Private Const startLine As Integer = 4
    Private endLine As Integer = 0
    Private index As Integer

    Private Sub Debug()
        index = 0
        If startDebug Then
            btStart.Text = "Start"
        Else
            btStart.Text = "Stop"
        End If
        btStepOver.Enabled = Not startDebug
    End Sub

    Private Sub Start()
        syntaxEdit1.Source.LineStyles.ToggleLineStyle(startLine + index, 0)
        Debug()
        startDebug = Not startDebug
    End Sub

    Private Sub StepOver()
        If (index < (endLine - startLine)) Then
            If (syntaxEdit1.Source.LineStyles.GetLineStyle(startLine + index) >= 0) Then
                syntaxEdit1.Source.LineStyles.ToggleLineStyle(startLine + index, 0)
            End If
            index = index + 1
            syntaxEdit1.Source.LineStyles.ToggleLineStyle(startLine + index, 0)
        Else
            syntaxEdit1.Source.LineStyles.ToggleLineStyle(startLine + index, 0)
            Debug()
            startDebug = Not startDebug
        End If
    End Sub

    Private Sub SetBreakpoint()
        syntaxEdit1.Source.BookMarks.ClearAllBookMarks()
        syntaxEdit1.Source.BookMarks.SetBookMark(syntaxEdit1.Position, 11)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (syntaxEdit1.LineStyles.Count > 0) Then
            Dim lStyle As ILineStyle = syntaxEdit1.LinesStyles.GetLineStyle(0)
            chbLineStyleBeyondEol.Checked = (LineStyleOptions.BeyondEol And lStyle.Options) <> 0
            cbLineStyleColor.SelectedColor = lStyle.ForeColor
        End If
        endLine = syntaxEdit1.Lines.Count - 2
    End Sub

    Private Sub btStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btStart.Click
        Start()
    End Sub

    Private Sub btStepOver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btStepOver.Click
        StepOver()
    End Sub

    Private Sub btSetBreakpoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSetBreakpoint.Click
        SetBreakpoint()
    End Sub

    Private Sub chbLineStyleBeyondEol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLineStyleBeyondEol.CheckedChanged
        If (syntaxEdit1.LineStyles.Count > 0) Then
            Dim lStyle As ILineStyle = syntaxEdit1.LinesStyles.GetLineStyle(0)
            If chbLineStyleBeyondEol.Checked Then
                lStyle.Options = lStyle.Options Or LineStyleOptions.BeyondEol
            Else
                lStyle.Options = lStyle.Options Xor LineStyleOptions.BeyondEol
            End If
            syntaxEdit1.Invalidate()
        End If
    End Sub

    Private Sub cbLineStyleColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLineStyleColor.SelectedIndexChanged
        If (syntaxEdit1.LineStyles.Count > 0) Then
            Dim lStyle As ILineStyle = syntaxEdit1.LinesStyles.GetLineStyle(0)
            lStyle.ForeColor = cbLineStyleColor.SelectedColor
            syntaxEdit1.Invalidate()
        End If
    End Sub

    Private Sub cmStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmStart.Click
        Start()
    End Sub

    Private Sub cmStepOver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmStepOver.Click
        StepOver()
    End Sub

    Private Sub cmSetBreakpoint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmSetBreakpoint.Click
        SetBreakpoint()
    End Sub
End Class
