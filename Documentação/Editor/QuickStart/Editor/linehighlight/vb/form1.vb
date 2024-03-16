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
    Friend WithEvents chbSeparateLines As System.Windows.Forms.CheckBox
    Friend WithEvents chbHighlightCurrentLine As System.Windows.Forms.CheckBox
    Friend WithEvents laLineColor As System.Windows.Forms.Label
    Friend WithEvents laHighlightBackColor As System.Windows.Forms.Label
    Friend WithEvents cbLineColor As QWhale.Common.ColorBox
    Friend WithEvents laHighlightForeColor As System.Windows.Forms.Label
    Friend WithEvents cbHighlightForeColor As QWhale.Common.ColorBox
    Friend WithEvents cbHighlightBackColor As QWhale.Common.ColorBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.chbSeparateLines = New System.Windows.Forms.CheckBox
        Me.chbHighlightCurrentLine = New System.Windows.Forms.CheckBox
        Me.laLineColor = New System.Windows.Forms.Label
        Me.laHighlightBackColor = New System.Windows.Forms.Label
        Me.cbLineColor = New QWhale.Common.ColorBox(Me.components)
        Me.laHighlightForeColor = New System.Windows.Forms.Label
        Me.cbHighlightForeColor = New QWhale.Common.ColorBox(Me.components)
        Me.cbHighlightBackColor = New QWhale.Common.ColorBox(Me.components)
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
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
        Me.pnSettings.Size = New System.Drawing.Size(568, 128)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.chbSeparateLines)
        Me.groupBox1.Controls.Add(Me.chbHighlightCurrentLine)
        Me.groupBox1.Controls.Add(Me.laLineColor)
        Me.groupBox1.Controls.Add(Me.laHighlightBackColor)
        Me.groupBox1.Controls.Add(Me.cbLineColor)
        Me.groupBox1.Controls.Add(Me.laHighlightForeColor)
        Me.groupBox1.Controls.Add(Me.cbHighlightForeColor)
        Me.groupBox1.Controls.Add(Me.cbHighlightBackColor)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 104)
        Me.groupBox1.TabIndex = 17
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Line highlight"
        '
        'chbSeparateLines
        '
        Me.chbSeparateLines.Location = New System.Drawing.Point(8, 40)
        Me.chbSeparateLines.Name = "chbSeparateLines"
        Me.chbSeparateLines.Size = New System.Drawing.Size(136, 24)
        Me.chbSeparateLines.TabIndex = 10
        Me.chbSeparateLines.Text = "Separate Lines"
        '
        'chbHighlightCurrentLine
        '
        Me.chbHighlightCurrentLine.Checked = True
        Me.chbHighlightCurrentLine.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbHighlightCurrentLine.Location = New System.Drawing.Point(8, 16)
        Me.chbHighlightCurrentLine.Name = "chbHighlightCurrentLine"
        Me.chbHighlightCurrentLine.Size = New System.Drawing.Size(136, 24)
        Me.chbHighlightCurrentLine.TabIndex = 9
        Me.chbHighlightCurrentLine.Text = "Highlight Current Line"
        '
        'laLineColor
        '
        Me.laLineColor.AutoSize = True
        Me.laLineColor.Location = New System.Drawing.Point(152, 69)
        Me.laLineColor.Name = "laLineColor"
        Me.laLineColor.Size = New System.Drawing.Size(56, 16)
        Me.laLineColor.TabIndex = 16
        Me.laLineColor.Text = "Line Color"
        '
        'laHighlightBackColor
        '
        Me.laHighlightBackColor.AutoSize = True
        Me.laHighlightBackColor.Location = New System.Drawing.Point(152, 21)
        Me.laHighlightBackColor.Name = "laHighlightBackColor"
        Me.laHighlightBackColor.Size = New System.Drawing.Size(107, 16)
        Me.laHighlightBackColor.TabIndex = 13
        Me.laHighlightBackColor.Text = "Highlight Back Color"
        '
        'cbLineColor
        '
        Me.cbLineColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbLineColor.Location = New System.Drawing.Point(272, 66)
        Me.cbLineColor.Name = "cbLineColor"
        Me.cbLineColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbLineColor.Size = New System.Drawing.Size(121, 21)
        Me.cbLineColor.TabIndex = 15
        '
        'laHighlightForeColor
        '
        Me.laHighlightForeColor.AutoSize = True
        Me.laHighlightForeColor.Location = New System.Drawing.Point(152, 45)
        Me.laHighlightForeColor.Name = "laHighlightForeColor"
        Me.laHighlightForeColor.Size = New System.Drawing.Size(105, 16)
        Me.laHighlightForeColor.TabIndex = 14
        Me.laHighlightForeColor.Text = "Highlight Fore Color"
        '
        'cbHighlightForeColor
        '
        Me.cbHighlightForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbHighlightForeColor.Location = New System.Drawing.Point(272, 42)
        Me.cbHighlightForeColor.Name = "cbHighlightForeColor"
        Me.cbHighlightForeColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbHighlightForeColor.Size = New System.Drawing.Size(121, 21)
        Me.cbHighlightForeColor.TabIndex = 12
        '
        'cbHighlightBackColor
        '
        Me.cbHighlightBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbHighlightBackColor.Location = New System.Drawing.Point(272, 18)
        Me.cbHighlightBackColor.Name = "cbHighlightBackColor"
        Me.cbHighlightBackColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbHighlightBackColor.Size = New System.Drawing.Size(121, 21)
        Me.cbHighlightBackColor.TabIndex = 11
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
        Me.laDescription.Text = "This demo shows how to visually separate lines in the edit control, and highlight" & _
        " current line."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.LineSeparator.Options = QWhale.Editor.SeparatorOptions.HighlightCurrentLine
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 128)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 190)
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
        Me.groupBox1.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbHighlightCurrentLine.Checked = (SeparatorOptions.HighlightCurrentLine And syntaxEdit1.LineSeparator.Options) <> 0
        chbSeparateLines.Checked = (SeparatorOptions.SeparateLines And syntaxEdit1.LineSeparator.Options) <> 0
        cbHighlightBackColor.SelectedColor = syntaxEdit1.LineSeparator.HighlightBackColor
        cbHighlightForeColor.SelectedColor = syntaxEdit1.LineSeparator.HighlightForeColor
        cbLineColor.SelectedColor = syntaxEdit1.LineSeparator.LineColor
    End Sub

    Private Sub chbHighlightCurrentLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHighlightCurrentLine.CheckedChanged
        If chbHighlightCurrentLine.Checked Then
            syntaxEdit1.LineSeparator.Options = syntaxEdit1.LineSeparator.Options Or SeparatorOptions.HighlightCurrentLine
        Else
            syntaxEdit1.LineSeparator.Options = syntaxEdit1.LineSeparator.Options Xor SeparatorOptions.HighlightCurrentLine
        End If
    End Sub

    Private Sub chbSeparateLines_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSeparateLines.CheckedChanged
        If chbSeparateLines.Checked Then
            syntaxEdit1.LineSeparator.Options = syntaxEdit1.LineSeparator.Options Or SeparatorOptions.SeparateLines
        Else
            syntaxEdit1.LineSeparator.Options = syntaxEdit1.LineSeparator.Options Xor SeparatorOptions.SeparateLines
        End If
    End Sub

    Private Sub cbHighlightBackColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbHighlightBackColor.SelectedIndexChanged
        syntaxEdit1.LineSeparator.HighlightBackColor = cbHighlightBackColor.SelectedColor
    End Sub

    Private Sub cbHighlightForeColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbHighlightForeColor.SelectedIndexChanged
        syntaxEdit1.LineSeparator.HighlightForeColor = cbHighlightForeColor.SelectedColor
    End Sub

    Private Sub cbLineColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLineColor.SelectedIndexChanged
        syntaxEdit1.LineSeparator.LineColor = cbLineColor.SelectedColor
    End Sub
End Class
