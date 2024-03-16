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
    Friend WithEvents cbLineNumbersBackColor As QWhale.Common.ColorBox
    Friend WithEvents cbLineNumbersForeColor As QWhale.Common.ColorBox
    Friend WithEvents laLineNumbersBackColor As System.Windows.Forms.Label
    Friend WithEvents laLineNumbersForeColor As System.Windows.Forms.Label
    Friend WithEvents nudLineNumbersStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLineNumbersRightIndent As System.Windows.Forms.NumericUpDown
    Friend WithEvents laLineNumbersLeftIndent As System.Windows.Forms.Label
    Friend WithEvents nudLineNumbersLeftIndent As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbLineNumbersAlign As System.Windows.Forms.ComboBox
    Friend WithEvents laLineNumbersRightIndent As System.Windows.Forms.Label
    Friend WithEvents laLineNumbersAlign As System.Windows.Forms.Label
    Friend WithEvents chbLineNumbers As System.Windows.Forms.CheckBox
    Friend WithEvents chbLinesOnGutter As System.Windows.Forms.CheckBox
    Friend WithEvents laLineNumbersStart As System.Windows.Forms.Label
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.cbLineNumbersBackColor = New QWhale.Common.ColorBox(Me.components)
        Me.cbLineNumbersForeColor = New QWhale.Common.ColorBox(Me.components)
        Me.laLineNumbersBackColor = New System.Windows.Forms.Label
        Me.laLineNumbersForeColor = New System.Windows.Forms.Label
        Me.nudLineNumbersStart = New System.Windows.Forms.NumericUpDown
        Me.nudLineNumbersRightIndent = New System.Windows.Forms.NumericUpDown
        Me.laLineNumbersLeftIndent = New System.Windows.Forms.Label
        Me.nudLineNumbersLeftIndent = New System.Windows.Forms.NumericUpDown
        Me.cbLineNumbersAlign = New System.Windows.Forms.ComboBox
        Me.laLineNumbersRightIndent = New System.Windows.Forms.Label
        Me.laLineNumbersAlign = New System.Windows.Forms.Label
        Me.chbLineNumbers = New System.Windows.Forms.CheckBox
        Me.chbLinesOnGutter = New System.Windows.Forms.CheckBox
        Me.laLineNumbersStart = New System.Windows.Forms.Label
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.pnSettings.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.nudLineNumbersStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLineNumbersRightIndent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLineNumbersLeftIndent, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnSettings.Size = New System.Drawing.Size(592, 104)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.cbLineNumbersBackColor)
        Me.groupBox1.Controls.Add(Me.cbLineNumbersForeColor)
        Me.groupBox1.Controls.Add(Me.laLineNumbersBackColor)
        Me.groupBox1.Controls.Add(Me.laLineNumbersForeColor)
        Me.groupBox1.Controls.Add(Me.nudLineNumbersStart)
        Me.groupBox1.Controls.Add(Me.nudLineNumbersRightIndent)
        Me.groupBox1.Controls.Add(Me.laLineNumbersLeftIndent)
        Me.groupBox1.Controls.Add(Me.nudLineNumbersLeftIndent)
        Me.groupBox1.Controls.Add(Me.cbLineNumbersAlign)
        Me.groupBox1.Controls.Add(Me.laLineNumbersRightIndent)
        Me.groupBox1.Controls.Add(Me.laLineNumbersAlign)
        Me.groupBox1.Controls.Add(Me.chbLineNumbers)
        Me.groupBox1.Controls.Add(Me.chbLinesOnGutter)
        Me.groupBox1.Controls.Add(Me.laLineNumbersStart)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(592, 80)
        Me.groupBox1.TabIndex = 19
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Line Numbers"
        '
        'cbLineNumbersBackColor
        '
        Me.cbLineNumbersBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbLineNumbersBackColor.Location = New System.Drawing.Point(456, 42)
        Me.cbLineNumbersBackColor.Name = "cbLineNumbersBackColor"
        Me.cbLineNumbersBackColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbLineNumbersBackColor.Size = New System.Drawing.Size(121, 21)
        Me.cbLineNumbersBackColor.TabIndex = 22
        '
        'cbLineNumbersForeColor
        '
        Me.cbLineNumbersForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbLineNumbersForeColor.Location = New System.Drawing.Point(456, 18)
        Me.cbLineNumbersForeColor.Name = "cbLineNumbersForeColor"
        Me.cbLineNumbersForeColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbLineNumbersForeColor.Size = New System.Drawing.Size(121, 21)
        Me.cbLineNumbersForeColor.TabIndex = 21
        '
        'laLineNumbersBackColor
        '
        Me.laLineNumbersBackColor.AutoSize = True
        Me.laLineNumbersBackColor.Location = New System.Drawing.Point(376, 45)
        Me.laLineNumbersBackColor.Name = "laLineNumbersBackColor"
        Me.laLineNumbersBackColor.Size = New System.Drawing.Size(59, 16)
        Me.laLineNumbersBackColor.TabIndex = 20
        Me.laLineNumbersBackColor.Text = "Back Color"
        '
        'laLineNumbersForeColor
        '
        Me.laLineNumbersForeColor.AutoSize = True
        Me.laLineNumbersForeColor.Location = New System.Drawing.Point(376, 21)
        Me.laLineNumbersForeColor.Name = "laLineNumbersForeColor"
        Me.laLineNumbersForeColor.Size = New System.Drawing.Size(58, 16)
        Me.laLineNumbersForeColor.TabIndex = 19
        Me.laLineNumbersForeColor.Text = "Fore Color"
        '
        'nudLineNumbersStart
        '
        Me.nudLineNumbersStart.Location = New System.Drawing.Point(156, 18)
        Me.nudLineNumbersStart.Name = "nudLineNumbersStart"
        Me.nudLineNumbersStart.Size = New System.Drawing.Size(64, 20)
        Me.nudLineNumbersStart.TabIndex = 13
        '
        'nudLineNumbersRightIndent
        '
        Me.nudLineNumbersRightIndent.Location = New System.Drawing.Point(304, 42)
        Me.nudLineNumbersRightIndent.Name = "nudLineNumbersRightIndent"
        Me.nudLineNumbersRightIndent.Size = New System.Drawing.Size(64, 20)
        Me.nudLineNumbersRightIndent.TabIndex = 18
        '
        'laLineNumbersLeftIndent
        '
        Me.laLineNumbersLeftIndent.AutoSize = True
        Me.laLineNumbersLeftIndent.Location = New System.Drawing.Point(232, 21)
        Me.laLineNumbersLeftIndent.Name = "laLineNumbersLeftIndent"
        Me.laLineNumbersLeftIndent.Size = New System.Drawing.Size(58, 16)
        Me.laLineNumbersLeftIndent.TabIndex = 15
        Me.laLineNumbersLeftIndent.Text = "Left Indent"
        '
        'nudLineNumbersLeftIndent
        '
        Me.nudLineNumbersLeftIndent.Location = New System.Drawing.Point(304, 18)
        Me.nudLineNumbersLeftIndent.Name = "nudLineNumbersLeftIndent"
        Me.nudLineNumbersLeftIndent.Size = New System.Drawing.Size(64, 20)
        Me.nudLineNumbersLeftIndent.TabIndex = 17
        '
        'cbLineNumbersAlign
        '
        Me.cbLineNumbersAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLineNumbersAlign.ItemHeight = 13
        Me.cbLineNumbersAlign.Location = New System.Drawing.Point(156, 42)
        Me.cbLineNumbersAlign.Name = "cbLineNumbersAlign"
        Me.cbLineNumbersAlign.Size = New System.Drawing.Size(64, 21)
        Me.cbLineNumbersAlign.TabIndex = 14
        '
        'laLineNumbersRightIndent
        '
        Me.laLineNumbersRightIndent.AutoSize = True
        Me.laLineNumbersRightIndent.Location = New System.Drawing.Point(232, 45)
        Me.laLineNumbersRightIndent.Name = "laLineNumbersRightIndent"
        Me.laLineNumbersRightIndent.Size = New System.Drawing.Size(65, 16)
        Me.laLineNumbersRightIndent.TabIndex = 16
        Me.laLineNumbersRightIndent.Text = "Right Indent"
        '
        'laLineNumbersAlign
        '
        Me.laLineNumbersAlign.AutoSize = True
        Me.laLineNumbersAlign.Location = New System.Drawing.Point(112, 45)
        Me.laLineNumbersAlign.Name = "laLineNumbersAlign"
        Me.laLineNumbersAlign.Size = New System.Drawing.Size(29, 16)
        Me.laLineNumbersAlign.TabIndex = 12
        Me.laLineNumbersAlign.Text = "Align"
        '
        'chbLineNumbers
        '
        Me.chbLineNumbers.Location = New System.Drawing.Point(8, 16)
        Me.chbLineNumbers.Name = "chbLineNumbers"
        Me.chbLineNumbers.TabIndex = 9
        Me.chbLineNumbers.Text = "Line Numbers"
        '
        'chbLinesOnGutter
        '
        Me.chbLinesOnGutter.Location = New System.Drawing.Point(8, 40)
        Me.chbLinesOnGutter.Name = "chbLinesOnGutter"
        Me.chbLinesOnGutter.TabIndex = 10
        Me.chbLinesOnGutter.Text = "Lines on Gutter"
        '
        'laLineNumbersStart
        '
        Me.laLineNumbersStart.AutoSize = True
        Me.laLineNumbersStart.Location = New System.Drawing.Point(112, 21)
        Me.laLineNumbersStart.Name = "laLineNumbersStart"
        Me.laLineNumbersStart.Size = New System.Drawing.Size(28, 16)
        Me.laLineNumbersStart.TabIndex = 11
        Me.laLineNumbersStart.Text = "Start"
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(592, 24)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(592, 24)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo shows how to customize appearance of line numbers."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Gutter.Options = CType((QWhale.Editor.GutterOptions.PaintLineNumbers Or QWhale.Editor.GutterOptions.PaintBookMarks), QWhale.Editor.GutterOptions)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 104)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(592, 214)
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
        Me.ClientSize = New System.Drawing.Size(592, 318)
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        CType(Me.nudLineNumbersStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLineNumbersRightIndent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLineNumbersLeftIndent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbLineNumbers.Checked = (GutterOptions.PaintLineNumbers And syntaxEdit1.Gutter.Options) <> 0
        chbLinesOnGutter.Checked = (GutterOptions.PaintLinesOnGutter And syntaxEdit1.Gutter.Options) <> 0
        nudLineNumbersStart.Maximum = 10000
        nudLineNumbersStart.Value = syntaxEdit1.Gutter.LineNumbersStart
        Dim s As String() = [Enum].GetNames(GetType(StringAlignment))
        cbLineNumbersAlign.Items.AddRange(s)
        cbLineNumbersAlign.SelectedIndex = syntaxEdit1.Gutter.LineNumbersAlignment
        nudLineNumbersLeftIndent.Maximum = 10000
        nudLineNumbersLeftIndent.Value = syntaxEdit1.Gutter.LineNumbersLeftIndent
        nudLineNumbersRightIndent.Maximum = 10000
        nudLineNumbersRightIndent.Value = syntaxEdit1.Gutter.LineNumbersRightIndent
        cbLineNumbersForeColor.SelectedColor = syntaxEdit1.Gutter.LineNumbersForeColor
        cbLineNumbersBackColor.SelectedColor = syntaxEdit1.Gutter.LineNumbersBackColor
    End Sub

    Private Sub chbLineNumbers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLineNumbers.CheckedChanged
        If chbLineNumbers.Checked Then
            syntaxEdit1.Gutter.Options = syntaxEdit1.Gutter.Options Or GutterOptions.PaintLineNumbers
        Else
            syntaxEdit1.Gutter.Options = syntaxEdit1.Gutter.Options Xor GutterOptions.PaintLineNumbers
        End If
    End Sub

    Private Sub chbLinesOnGutter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLinesOnGutter.CheckedChanged
        If chbLinesOnGutter.Checked Then
            syntaxEdit1.Gutter.Options = syntaxEdit1.Gutter.Options Or GutterOptions.PaintLinesOnGutter
        Else
            syntaxEdit1.Gutter.Options = syntaxEdit1.Gutter.Options Xor GutterOptions.PaintLinesOnGutter
        End If
    End Sub

    Private Sub nudLineNumbersStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLineNumbersStart.ValueChanged
        syntaxEdit1.Gutter.LineNumbersStart = nudLineNumbersStart.Value
    End Sub

    Private Sub cbLineNumbersAlign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLineNumbersAlign.SelectedIndexChanged
        syntaxEdit1.Gutter.LineNumbersAlignment = CType(cbLineNumbersAlign.SelectedIndex, StringAlignment)
    End Sub

    Private Sub nudLineNumbersLeftIndent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLineNumbersLeftIndent.ValueChanged
        syntaxEdit1.Gutter.LineNumbersLeftIndent = nudLineNumbersLeftIndent.Value
    End Sub

    Private Sub nudLineNumbersRightIndent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLineNumbersRightIndent.ValueChanged
        syntaxEdit1.Gutter.LineNumbersRightIndent = nudLineNumbersRightIndent.Value
    End Sub

    Private Sub cbLineNumbersForeColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLineNumbersForeColor.SelectedIndexChanged
        syntaxEdit1.Gutter.LineNumbersForeColor = cbLineNumbersForeColor.SelectedColor
    End Sub

    Private Sub cbLineNumbersBackColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLineNumbersBackColor.SelectedIndexChanged
        syntaxEdit1.Gutter.LineNumbersBackColor = cbLineNumbersBackColor.SelectedColor
    End Sub
End Class
