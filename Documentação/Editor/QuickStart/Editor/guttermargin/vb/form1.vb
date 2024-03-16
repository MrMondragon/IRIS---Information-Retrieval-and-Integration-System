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
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents laMarginColor As System.Windows.Forms.Label
    Friend WithEvents cbMarginColor As QWhale.Common.ColorBox
    Friend WithEvents laMarginPos As System.Windows.Forms.Label
    Friend WithEvents chbShowMargin As System.Windows.Forms.CheckBox
    Friend WithEvents nudMarginPos As System.Windows.Forms.NumericUpDown
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents laGradientEndColor As System.Windows.Forms.Label
    Friend WithEvents laGradientBeginColor As System.Windows.Forms.Label
    Friend WithEvents laPenColor As System.Windows.Forms.Label
    Friend WithEvents cbGradientBeginColor As QWhale.Common.ColorBox
    Friend WithEvents cbPenColor As QWhale.Common.ColorBox
    Friend WithEvents cbGradientEndColor As QWhale.Common.ColorBox
    Friend WithEvents chbGradientGutter As System.Windows.Forms.CheckBox
    Friend WithEvents nudGutterWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents chbShowGutter As System.Windows.Forms.CheckBox
    Friend WithEvents laGutterWidth As System.Windows.Forms.Label
    Friend WithEvents cbGutterColor As QWhale.Common.ColorBox
    Friend WithEvents laGutterColor As System.Windows.Forms.Label
    Friend WithEvents chbColumnsVisible As System.Windows.Forms.CheckBox
    Friend WithEvents laColumnPenColor As System.Windows.Forms.Label
    Friend WithEvents cbColumnsPenColor As QWhale.Common.ColorBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.laGradientEndColor = New System.Windows.Forms.Label
        Me.laGradientBeginColor = New System.Windows.Forms.Label
        Me.laPenColor = New System.Windows.Forms.Label
        Me.cbGradientBeginColor = New QWhale.Common.ColorBox(Me.components)
        Me.cbPenColor = New QWhale.Common.ColorBox(Me.components)
        Me.cbGradientEndColor = New QWhale.Common.ColorBox(Me.components)
        Me.chbGradientGutter = New System.Windows.Forms.CheckBox
        Me.nudGutterWidth = New System.Windows.Forms.NumericUpDown
        Me.chbShowGutter = New System.Windows.Forms.CheckBox
        Me.laGutterWidth = New System.Windows.Forms.Label
        Me.cbGutterColor = New QWhale.Common.ColorBox(Me.components)
        Me.laGutterColor = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.laColumnPenColor = New System.Windows.Forms.Label
        Me.cbColumnsPenColor = New QWhale.Common.ColorBox(Me.components)
        Me.chbColumnsVisible = New System.Windows.Forms.CheckBox
        Me.laMarginColor = New System.Windows.Forms.Label
        Me.cbMarginColor = New QWhale.Common.ColorBox(Me.components)
        Me.laMarginPos = New System.Windows.Forms.Label
        Me.chbShowMargin = New System.Windows.Forms.CheckBox
        Me.nudMarginPos = New System.Windows.Forms.NumericUpDown
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.pnSettings.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.nudGutterWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        CType(Me.nudMarginPos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.groupBox1)
        Me.pnSettings.Controls.Add(Me.groupBox2)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(592, 144)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.laGradientEndColor)
        Me.groupBox1.Controls.Add(Me.laGradientBeginColor)
        Me.groupBox1.Controls.Add(Me.laPenColor)
        Me.groupBox1.Controls.Add(Me.cbGradientBeginColor)
        Me.groupBox1.Controls.Add(Me.cbPenColor)
        Me.groupBox1.Controls.Add(Me.cbGradientEndColor)
        Me.groupBox1.Controls.Add(Me.chbGradientGutter)
        Me.groupBox1.Controls.Add(Me.nudGutterWidth)
        Me.groupBox1.Controls.Add(Me.chbShowGutter)
        Me.groupBox1.Controls.Add(Me.laGutterWidth)
        Me.groupBox1.Controls.Add(Me.cbGutterColor)
        Me.groupBox1.Controls.Add(Me.laGutterColor)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(368, 120)
        Me.groupBox1.TabIndex = 28
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Gutter"
        '
        'laGradientEndColor
        '
        Me.laGradientEndColor.AutoSize = True
        Me.laGradientEndColor.Location = New System.Drawing.Point(232, 56)
        Me.laGradientEndColor.Name = "laGradientEndColor"
        Me.laGradientEndColor.Size = New System.Drawing.Size(95, 16)
        Me.laGradientEndColor.TabIndex = 24
        Me.laGradientEndColor.Text = "Gradient End Color"
        '
        'laGradientBeginColor
        '
        Me.laGradientBeginColor.AutoSize = True
        Me.laGradientBeginColor.Location = New System.Drawing.Point(232, 16)
        Me.laGradientBeginColor.Name = "laGradientBeginColor"
        Me.laGradientBeginColor.Size = New System.Drawing.Size(104, 16)
        Me.laGradientBeginColor.TabIndex = 23
        Me.laGradientBeginColor.Text = "Gradient Begin Color"
        '
        'laPenColor
        '
        Me.laPenColor.AutoSize = True
        Me.laPenColor.Location = New System.Drawing.Point(104, 56)
        Me.laPenColor.Name = "laPenColor"
        Me.laPenColor.Size = New System.Drawing.Size(50, 16)
        Me.laPenColor.TabIndex = 22
        Me.laPenColor.Text = "Pen Color"
        '
        'cbGradientBeginColor
        '
        Me.cbGradientBeginColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbGradientBeginColor.Location = New System.Drawing.Point(232, 32)
        Me.cbGradientBeginColor.Name = "cbGradientBeginColor"
        Me.cbGradientBeginColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbGradientBeginColor.Size = New System.Drawing.Size(121, 21)
        Me.cbGradientBeginColor.TabIndex = 21
        '
        'cbPenColor
        '
        Me.cbPenColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbPenColor.Location = New System.Drawing.Point(104, 72)
        Me.cbPenColor.Name = "cbPenColor"
        Me.cbPenColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbPenColor.Size = New System.Drawing.Size(121, 21)
        Me.cbPenColor.TabIndex = 20
        '
        'cbGradientEndColor
        '
        Me.cbGradientEndColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbGradientEndColor.Location = New System.Drawing.Point(232, 72)
        Me.cbGradientEndColor.Name = "cbGradientEndColor"
        Me.cbGradientEndColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbGradientEndColor.Size = New System.Drawing.Size(121, 21)
        Me.cbGradientEndColor.TabIndex = 19
        '
        'chbGradientGutter
        '
        Me.chbGradientGutter.Location = New System.Drawing.Point(8, 32)
        Me.chbGradientGutter.Name = "chbGradientGutter"
        Me.chbGradientGutter.Size = New System.Drawing.Size(88, 24)
        Me.chbGradientGutter.TabIndex = 11
        Me.chbGradientGutter.Text = "Use gradient"
        '
        'nudGutterWidth
        '
        Me.nudGutterWidth.Location = New System.Drawing.Point(8, 72)
        Me.nudGutterWidth.Name = "nudGutterWidth"
        Me.nudGutterWidth.Size = New System.Drawing.Size(64, 20)
        Me.nudGutterWidth.TabIndex = 14
        '
        'chbShowGutter
        '
        Me.chbShowGutter.Location = New System.Drawing.Point(8, 16)
        Me.chbShowGutter.Name = "chbShowGutter"
        Me.chbShowGutter.Size = New System.Drawing.Size(96, 16)
        Me.chbShowGutter.TabIndex = 9
        Me.chbShowGutter.Text = "Show Gutter"
        '
        'laGutterWidth
        '
        Me.laGutterWidth.AutoSize = True
        Me.laGutterWidth.Location = New System.Drawing.Point(8, 56)
        Me.laGutterWidth.Name = "laGutterWidth"
        Me.laGutterWidth.Size = New System.Drawing.Size(66, 16)
        Me.laGutterWidth.TabIndex = 12
        Me.laGutterWidth.Text = "Gutter Width"
        '
        'cbGutterColor
        '
        Me.cbGutterColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbGutterColor.Location = New System.Drawing.Point(104, 32)
        Me.cbGutterColor.Name = "cbGutterColor"
        Me.cbGutterColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbGutterColor.Size = New System.Drawing.Size(121, 21)
        Me.cbGutterColor.TabIndex = 18
        '
        'laGutterColor
        '
        Me.laGutterColor.AutoSize = True
        Me.laGutterColor.Location = New System.Drawing.Point(104, 16)
        Me.laGutterColor.Name = "laGutterColor"
        Me.laGutterColor.Size = New System.Drawing.Size(63, 16)
        Me.laGutterColor.TabIndex = 17
        Me.laGutterColor.Text = "Gutter Color"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.laColumnPenColor)
        Me.groupBox2.Controls.Add(Me.cbColumnsPenColor)
        Me.groupBox2.Controls.Add(Me.chbColumnsVisible)
        Me.groupBox2.Controls.Add(Me.laMarginColor)
        Me.groupBox2.Controls.Add(Me.cbMarginColor)
        Me.groupBox2.Controls.Add(Me.laMarginPos)
        Me.groupBox2.Controls.Add(Me.chbShowMargin)
        Me.groupBox2.Controls.Add(Me.nudMarginPos)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.groupBox2.Location = New System.Drawing.Point(368, 24)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(224, 120)
        Me.groupBox2.TabIndex = 27
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Margin"
        '
        'laColumnPenColor
        '
        Me.laColumnPenColor.AutoSize = True
        Me.laColumnPenColor.Location = New System.Drawing.Point(8, 88)
        Me.laColumnPenColor.Name = "laColumnPenColor"
        Me.laColumnPenColor.Size = New System.Drawing.Size(69, 16)
        Me.laColumnPenColor.TabIndex = 29
        Me.laColumnPenColor.Text = "Column Color"
        '
        'cbColumnsPenColor
        '
        Me.cbColumnsPenColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbColumnsPenColor.Location = New System.Drawing.Point(96, 88)
        Me.cbColumnsPenColor.Name = "cbColumnsPenColor"
        Me.cbColumnsPenColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbColumnsPenColor.Size = New System.Drawing.Size(104, 21)
        Me.cbColumnsPenColor.TabIndex = 28
        '
        'chbColumnsVisible
        '
        Me.chbColumnsVisible.Location = New System.Drawing.Point(96, 16)
        Me.chbColumnsVisible.Name = "chbColumnsVisible"
        Me.chbColumnsVisible.Size = New System.Drawing.Size(104, 16)
        Me.chbColumnsVisible.TabIndex = 17
        Me.chbColumnsVisible.Text = "Columns Visible"
        '
        'laMarginColor
        '
        Me.laMarginColor.AutoSize = True
        Me.laMarginColor.Location = New System.Drawing.Point(8, 64)
        Me.laMarginColor.Name = "laMarginColor"
        Me.laMarginColor.Size = New System.Drawing.Size(65, 16)
        Me.laMarginColor.TabIndex = 25
        Me.laMarginColor.Text = "Margin Color"
        '
        'cbMarginColor
        '
        Me.cbMarginColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbMarginColor.Location = New System.Drawing.Point(96, 64)
        Me.cbMarginColor.Name = "cbMarginColor"
        Me.cbMarginColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbMarginColor.Size = New System.Drawing.Size(104, 21)
        Me.cbMarginColor.TabIndex = 24
        '
        'laMarginPos
        '
        Me.laMarginPos.AutoSize = True
        Me.laMarginPos.Location = New System.Drawing.Point(8, 40)
        Me.laMarginPos.Name = "laMarginPos"
        Me.laMarginPos.Size = New System.Drawing.Size(78, 16)
        Me.laMarginPos.TabIndex = 17
        Me.laMarginPos.Text = "Margin position"
        '
        'chbShowMargin
        '
        Me.chbShowMargin.Location = New System.Drawing.Point(8, 16)
        Me.chbShowMargin.Name = "chbShowMargin"
        Me.chbShowMargin.Size = New System.Drawing.Size(96, 16)
        Me.chbShowMargin.TabIndex = 16
        Me.chbShowMargin.Text = "Show Margin"
        '
        'nudMarginPos
        '
        Me.nudMarginPos.Location = New System.Drawing.Point(96, 40)
        Me.nudMarginPos.Name = "nudMarginPos"
        Me.nudMarginPos.Size = New System.Drawing.Size(64, 20)
        Me.nudMarginPos.TabIndex = 18
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
        Me.laDescription.Text = "This demo shows how to customize appearance of the gutter and margin."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.EditMargin.ColumnPenColor = System.Drawing.Color.DimGray
        Me.syntaxEdit1.EditMargin.ColumnPositions = New Integer() {16, 48}
        Me.syntaxEdit1.EditMargin.ColumnsVisible = True
        Me.syntaxEdit1.EditMargin.Position = 60
        Me.syntaxEdit1.EditMargin.Visible = True
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Gutter.Options = CType(((QWhale.Editor.GutterOptions.PaintLineNumbers Or QWhale.Editor.GutterOptions.PaintLinesOnGutter) _
                    Or QWhale.Editor.GutterOptions.PaintBookMarks), QWhale.Editor.GutterOptions)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 144)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(592, 253)
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
        ") 2004, 2005 Quantum Whale LLC.</Copyright>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileExtension />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileType>vb" & _
        "</FileType>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Version>1.1</Version>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>iden" & _
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
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 397)
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        CType(Me.nudGutterWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        CType(Me.nudMarginPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private gradientBeginColor As Color = Color.Blue
    Private gradientEndColor As Color = Color.White

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbShowGutter.Checked = syntaxEdit1.Gutter.Visible
        chbShowMargin.Checked = syntaxEdit1.EditMargin.Visible
        nudGutterWidth.Maximum = syntaxEdit1.Width
        nudGutterWidth.Value = syntaxEdit1.Gutter.Width
        nudMarginPos.Maximum = 1000
        nudMarginPos.Value = syntaxEdit1.EditMargin.Position
        cbGutterColor.SelectedColor = syntaxEdit1.Gutter.BrushColor
        cbPenColor.SelectedColor = syntaxEdit1.Gutter.PenColor
        cbMarginColor.SelectedColor = syntaxEdit1.EditMargin.PenColor
        cbGradientBeginColor.SelectedColor = gradientBeginColor
        cbGradientEndColor.SelectedColor = gradientEndColor
        chbColumnsVisible.Checked = syntaxEdit1.EditMargin.ColumnsVisible
        cbColumnsPenColor.SelectedColor = syntaxEdit1.EditMargin.ColumnPenColor
    End Sub

    Private Sub syntaxEdit1_PaintBackground(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles syntaxEdit1.PaintBackground
        If (syntaxEdit1.Transparent And syntaxEdit1.Gutter.Visible) Then
            Dim r As Rectangle = syntaxEdit1.Gutter.Rect
            e.Graphics.FillRectangle(New System.Drawing.Drawing2D.LinearGradientBrush(r.Location, New Point(r.Right, r.Bottom), gradientBeginColor, gradientEndColor), r)
        End If

    End Sub

    Private Sub chbShowGutter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowGutter.CheckedChanged
        syntaxEdit1.Gutter.Visible = chbShowGutter.Checked
    End Sub

    Private Sub chbGradientGutter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbGradientGutter.CheckedChanged
        syntaxEdit1.Transparent = chbGradientGutter.Checked
        syntaxEdit1.Invalidate()
    End Sub

    Private Sub nudGutterWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGutterWidth.ValueChanged
        syntaxEdit1.Gutter.Width = nudGutterWidth.Value
    End Sub

    Private Sub cbGutterColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGutterColor.SelectedIndexChanged
        syntaxEdit1.Gutter.BrushColor = cbGutterColor.SelectedColor
    End Sub

    Private Sub cbPenColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPenColor.SelectedIndexChanged
        syntaxEdit1.Gutter.PenColor = cbPenColor.SelectedColor
    End Sub

    Private Sub cbGradientBeginColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGradientBeginColor.SelectedIndexChanged
        gradientBeginColor = cbGradientBeginColor.SelectedColor
        If (chbGradientGutter.Checked) Then
            syntaxEdit1.Invalidate()
        End If
    End Sub

    Private Sub cbGradientEndColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGradientEndColor.SelectedIndexChanged
        gradientEndColor = cbGradientEndColor.SelectedColor
        If (chbGradientGutter.Checked) Then
            syntaxEdit1.Invalidate()
        End If
    End Sub

    Private Sub chbShowMargin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowMargin.CheckedChanged
        syntaxEdit1.EditMargin.Visible = chbShowMargin.Checked
    End Sub

    Private Sub nudMarginPos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMarginPos.ValueChanged
        syntaxEdit1.EditMargin.Position = nudMarginPos.Value
    End Sub

    Private Sub cbMarginColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMarginColor.SelectedIndexChanged
        syntaxEdit1.EditMargin.PenColor = cbMarginColor.SelectedColor
        syntaxEdit1.Invalidate()
    End Sub

    Private Sub chbColumnsVisible_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbColumnsVisible.CheckedChanged
        syntaxEdit1.EditMargin.ColumnsVisible = chbColumnsVisible.Checked
    End Sub

    Private Sub cbColumnsPenColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbColumnsPenColor.SelectedIndexChanged
        syntaxEdit1.EditMargin.ColumnPenColor = cbColumnsPenColor.SelectedColor
        syntaxEdit1.Invalidate()
    End Sub
End Class
