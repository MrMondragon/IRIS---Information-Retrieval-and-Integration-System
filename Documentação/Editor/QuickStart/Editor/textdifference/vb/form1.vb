Imports System
Imports QWhale.Common
Imports QWhale.Syntax
Imports QWhale.Editor

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    <STAThread()> Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub
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
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents panel4 As System.Windows.Forms.Panel
    Friend WithEvents btOpenLeftFile As System.Windows.Forms.Button
    Friend WithEvents tbLeftSourceFile As System.Windows.Forms.TextBox
    Friend WithEvents panel5 As System.Windows.Forms.Panel
    Friend WithEvents btOpenRightFile As System.Windows.Forms.Button
    Friend WithEvents tbRightSourceFile As System.Windows.Forms.TextBox
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents syntaxEdit2 As QWhale.Editor.SyntaxEdit
    Friend WithEvents panel3 As System.Windows.Forms.Panel
    Friend WithEvents btRefresh As System.Windows.Forms.Button
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim LineStyle1 As QWhale.Editor.LineStyle = New QWhale.Editor.LineStyle
        Dim LineStyle2 As QWhale.Editor.LineStyle = New QWhale.Editor.LineStyle
        Dim LineStyle3 As QWhale.Editor.LineStyle = New QWhale.Editor.LineStyle
        Dim LineStyle4 As QWhale.Editor.LineStyle = New QWhale.Editor.LineStyle
        Dim LineStyle5 As QWhale.Editor.LineStyle = New QWhale.Editor.LineStyle
        Dim LineStyle6 As QWhale.Editor.LineStyle = New QWhale.Editor.LineStyle
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.panel3 = New System.Windows.Forms.Panel
        Me.btRefresh = New System.Windows.Forms.Button
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.panel1 = New System.Windows.Forms.Panel
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.panel4 = New System.Windows.Forms.Panel
        Me.btOpenLeftFile = New System.Windows.Forms.Button
        Me.tbLeftSourceFile = New System.Windows.Forms.TextBox
        Me.splitter1 = New System.Windows.Forms.Splitter
        Me.panel2 = New System.Windows.Forms.Panel
        Me.syntaxEdit2 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.panel5 = New System.Windows.Forms.Panel
        Me.btOpenRightFile = New System.Windows.Forms.Button
        Me.tbRightSourceFile = New System.Windows.Forms.TextBox
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.pnSettings.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.panel4.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.panel3)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(936, 56)
        Me.pnSettings.TabIndex = 2
        '
        'panel3
        '
        Me.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel3.Controls.Add(Me.btRefresh)
        Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel3.Location = New System.Drawing.Point(0, 24)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(936, 32)
        Me.panel3.TabIndex = 10
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(8, 4)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.TabIndex = 0
        Me.btRefresh.Text = "Refresh"
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(936, 24)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(936, 24)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo project shows how to use syntax editor to highlight differences between" & _
        " source codes."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.syntaxEdit1)
        Me.panel1.Controls.Add(Me.panel4)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel1.Location = New System.Drawing.Point(0, 56)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(448, 446)
        Me.panel1.TabIndex = 4
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        LineStyle1.ForeColor = System.Drawing.Color.Red
        LineStyle1.Name = ""
        LineStyle1.Options = CType((QWhale.Editor.LineStyleOptions.BeyondEol Or QWhale.Editor.LineStyleOptions.InvertColors), QWhale.Editor.LineStyleOptions)
        LineStyle1.PenColor = System.Drawing.Color.Empty
        LineStyle2.ForeColor = System.Drawing.Color.Orange
        LineStyle2.Name = ""
        LineStyle2.Options = CType((QWhale.Editor.LineStyleOptions.BeyondEol Or QWhale.Editor.LineStyleOptions.InvertColors), QWhale.Editor.LineStyleOptions)
        LineStyle2.PenColor = System.Drawing.Color.Empty
        LineStyle3.ForeColor = System.Drawing.SystemColors.ControlDark
        LineStyle3.Name = ""
        LineStyle3.Options = CType((QWhale.Editor.LineStyleOptions.BeyondEol Or QWhale.Editor.LineStyleOptions.InvertColors), QWhale.Editor.LineStyleOptions)
        LineStyle3.PenColor = System.Drawing.Color.Empty
        Me.syntaxEdit1.LinesStyles.AddRange(New QWhale.Editor.LineStyle() {LineStyle1, LineStyle2, LineStyle3})
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 30)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(448, 416)
        Me.syntaxEdit1.TabIndex = 7
        Me.syntaxEdit1.Text = "Imports QWhale.Common" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports QWhale.Syntax" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports QWhale.Editor" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports my.u" & _
        "tils" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Inherits System.Windows.Forms.Form" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private " & _
        "Sub btProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) " & _
        "Handles btProcess.Click" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        ProcessDifferences()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Privat" & _
        "e Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Han" & _
        "dles MyBase.Load" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        ProcessDifferences()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private Sub P" & _
        "rocessDifferences()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim s1 As String = syntaxEdit1.Lines.Text" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Dim s2 A" & _
        "s String = syntaxEdit2.Lines.Text" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim f As Diff.Item() = Diff.DiffText(" & _
        "s1, s2, True, True, False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim n As Integer = 0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim styleIndex" & _
        " As Integer = -1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        For fdx As Integer = 0 To f.Length - 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim aI" & _
        "tem As Diff.Item = f(fdx)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            If aItem.deletedA = aItem.insertedB Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                styleIndex = 0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            Else" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " styleIndex = 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "        n = aItem.StartB" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   For m As Integer = 0 To aItem.deletedA - 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     " & _
        "        syntaxEdit1.Source.LineStyles.SetLineStyle(aItem.StartA + m, styleIndex)" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            Next m" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         While (n < aItem.StartB + aItem.insertedB)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     " & _
        "           syntaxEdit2.Source.LineStyles.SetLineStyle(n, styleIndex)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        " n = n + 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       End While" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Next fdx" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class"
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
        "ts</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>ControlText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        " </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>numbers</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Green</Fore" & _
        "Color>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>1</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>reswords<" & _
        "/Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Blue</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>2</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>comments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Green</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "     <Index>3</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Sty" & _
        "le>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>xmlcomments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Gray</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <I" & _
        "ndex>4</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>symbols</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Fo" & _
        "reColor>Gray</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>5</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "   <Name>whitespace</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>WindowText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Inde" & _
        "x>6</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>strings</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeC" & _
        "olor>Maroon</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>7</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainTex" & _
        "t>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>directives</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>B" & _
        "lue</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>8</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>" & _
        "syntaxerrors</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Red</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>9</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "   </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>codesnippets</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Blac" & _
        "k</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <BackColor>255:180:228:180</BackColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>10</In" & _
        "dex>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <States />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "</LexScheme>"
        '
        'panel4
        '
        Me.panel4.Controls.Add(Me.btOpenLeftFile)
        Me.panel4.Controls.Add(Me.tbLeftSourceFile)
        Me.panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel4.Location = New System.Drawing.Point(0, 0)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(448, 30)
        Me.panel4.TabIndex = 6
        '
        'btOpenLeftFile
        '
        Me.btOpenLeftFile.Location = New System.Drawing.Point(416, 4)
        Me.btOpenLeftFile.Name = "btOpenLeftFile"
        Me.btOpenLeftFile.Size = New System.Drawing.Size(24, 21)
        Me.btOpenLeftFile.TabIndex = 6
        Me.btOpenLeftFile.Text = "..."
        '
        'tbLeftSourceFile
        '
        Me.tbLeftSourceFile.Location = New System.Drawing.Point(8, 4)
        Me.tbLeftSourceFile.Name = "tbLeftSourceFile"
        Me.tbLeftSourceFile.Size = New System.Drawing.Size(408, 20)
        Me.tbLeftSourceFile.TabIndex = 5
        Me.tbLeftSourceFile.Text = ""
        '
        'splitter1
        '
        Me.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitter1.Location = New System.Drawing.Point(448, 56)
        Me.splitter1.Name = "splitter1"
        Me.splitter1.Size = New System.Drawing.Size(5, 446)
        Me.splitter1.TabIndex = 6
        Me.splitter1.TabStop = False
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.syntaxEdit2)
        Me.panel2.Controls.Add(Me.panel5)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel2.Location = New System.Drawing.Point(453, 56)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(483, 446)
        Me.panel2.TabIndex = 7
        '
        'syntaxEdit2
        '
        Me.syntaxEdit2.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit2.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit2.Lexer = Me.VbParser1
        LineStyle4.ForeColor = System.Drawing.Color.Red
        LineStyle4.Name = ""
        LineStyle4.Options = CType((QWhale.Editor.LineStyleOptions.BeyondEol Or QWhale.Editor.LineStyleOptions.InvertColors), QWhale.Editor.LineStyleOptions)
        LineStyle4.PenColor = System.Drawing.Color.Empty
        LineStyle5.ForeColor = System.Drawing.Color.Orange
        LineStyle5.Name = ""
        LineStyle5.Options = CType((QWhale.Editor.LineStyleOptions.BeyondEol Or QWhale.Editor.LineStyleOptions.InvertColors), QWhale.Editor.LineStyleOptions)
        LineStyle5.PenColor = System.Drawing.Color.Empty
        LineStyle6.ForeColor = System.Drawing.SystemColors.ControlDark
        LineStyle6.Name = ""
        LineStyle6.Options = CType((QWhale.Editor.LineStyleOptions.BeyondEol Or QWhale.Editor.LineStyleOptions.InvertColors), QWhale.Editor.LineStyleOptions)
        LineStyle6.PenColor = System.Drawing.Color.Empty
        Me.syntaxEdit2.LinesStyles.AddRange(New QWhale.Editor.LineStyle() {LineStyle4, LineStyle5, LineStyle6})
        Me.syntaxEdit2.Location = New System.Drawing.Point(0, 30)
        Me.syntaxEdit2.Name = "syntaxEdit2"
        Me.syntaxEdit2.Size = New System.Drawing.Size(483, 416)
        Me.syntaxEdit2.TabIndex = 3
        Me.syntaxEdit2.Text = "Imports QWhale.Common" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports QWhale.Syntax" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports QWhale.Editor" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Cla" & _
        "ss Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Inherits Form" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private Sub btProcess_Click(ByVal sender As Sys" & _
        "tem.Object, ByVal e As System.EventArgs) Handles btProcess.Click" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Proces" & _
        "sDifferences()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private Sub Form1_Load(ByVal sender As System" & _
        ".Object, ByVal e As System.EventArgs) Handles MyBase.Load" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        ProcessDiffer" & _
        "ences()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private Sub ProcessDifferences()'test" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim s" & _
        "1 As String = syntaxEdit1.Lines.Text" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim s2 As String = syntaxEdit2.Lin" & _
        "es.Text" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim f As Diff.Item() = Diff.DiffText(s1, s2, True, True, False)" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim n As Integer = 0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim styleIndex As Integer = -1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "  For fdx As Integer = 0 To f.Length - 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            Dim aItem As Diff.Item = f" & _
        "(fdx)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            If aItem.deletedA = aItem.insertedB Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " styleIndex = 0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "          Else" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                styleIndex = 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    n = aI" & _
        "tem.StartB" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            For m As Integer = 0 To aItem.deletedA - 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        "      syntaxEdit1.Source.LineStyles.SetLineStyle(aItem.StartA + m, styleIndex)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "            Next m" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            While (n < aItem.StartB + aItem.insertedB)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    " & _
        "            syntaxEdit2.Source.LineStyles.SetLineStyle(n, styleIndex)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         " & _
        "       n = n + 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            End While" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Next fdx" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Clas" & _
        "s"
        '
        'panel5
        '
        Me.panel5.Controls.Add(Me.btOpenRightFile)
        Me.panel5.Controls.Add(Me.tbRightSourceFile)
        Me.panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel5.Location = New System.Drawing.Point(0, 0)
        Me.panel5.Name = "panel5"
        Me.panel5.Size = New System.Drawing.Size(483, 30)
        Me.panel5.TabIndex = 2
        '
        'btOpenRightFile
        '
        Me.btOpenRightFile.Location = New System.Drawing.Point(456, 4)
        Me.btOpenRightFile.Name = "btOpenRightFile"
        Me.btOpenRightFile.Size = New System.Drawing.Size(24, 21)
        Me.btOpenRightFile.TabIndex = 6
        Me.btOpenRightFile.Text = "..."
        '
        'tbRightSourceFile
        '
        Me.tbRightSourceFile.Location = New System.Drawing.Point(16, 4)
        Me.tbRightSourceFile.Name = "tbRightSourceFile"
        Me.tbRightSourceFile.Size = New System.Drawing.Size(440, 20)
        Me.tbRightSourceFile.TabIndex = 5
        Me.tbRightSourceFile.Text = ""
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(936, 502)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.splitter1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.panel3.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel4.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProcessDifferences()
    End Sub

    Private Sub PrepareLines()
        Dim item As IStrItem = Nothing
        For i As Integer = syntaxEdit1.Lines.Count - 1 To 0 Step -1
            item = syntaxEdit1.Lines.GetItem(i)
            If ((item.State And StrItemState.Readonly) <> 0) Then
                syntaxEdit1.Lines.RemoveAt(i)
            End If
        Next i
        For i As Integer = syntaxEdit2.Lines.Count - 1 To 0 Step -1
            item = syntaxEdit2.Lines.GetItem(i)
            If ((item.State And StrItemState.Readonly) <> 0) Then
                syntaxEdit2.Lines.RemoveAt(i)
            End If
        Next i
    End Sub
    Private Sub ProcessDifferences()
        syntaxEdit1.Lines.BeginUpdate()
        syntaxEdit2.Lines.BeginUpdate()
        Try
            PrepareLines()
            Dim s1 As String = syntaxEdit1.Lines.Text
            Dim s2 As String = syntaxEdit2.Lines.Text
            Dim f As Diff.Item() = Diff.DiffText(s1, s2, True, True, False)

            Dim n As Integer = 0
            Dim styleIndex As Integer = -1
            Dim offsetA As Integer = 0
            Dim offsetB As Integer = 0
            Dim readOnlyIndex As Integer = -1
            For fdx As Integer = 0 To f.Length - 1
                Dim aItem As Diff.Item = f(fdx)
                If aItem.deletedA = aItem.insertedB Then
                    styleIndex = 0
                Else
                    styleIndex = 1
                End If

                n = aItem.StartB

                For m As Integer = 0 To aItem.deletedA - 1
                    syntaxEdit1.Source.LineStyles.SetLineStyle(aItem.StartA + m + offsetA, styleIndex)
                Next m
                While (n < aItem.StartB + aItem.insertedB)
                    syntaxEdit2.Source.LineStyles.SetLineStyle(n + offsetB, styleIndex)
                    n = n + 1
                End While
                If (aItem.deletedA > aItem.insertedB) Then
                    readOnlyIndex = aItem.StartB + offsetB
                    For m As Integer = 0 To aItem.deletedA - aItem.insertedB - 1
                        syntaxEdit2.Lines.Insert(readOnlyIndex, String.Empty)
                        syntaxEdit2.Source.LineStyles.SetLineStyle(readOnlyIndex, 2)
                        syntaxEdit2.Source.SetLineReadonly(readOnlyIndex, True)
                        offsetB = offsetB + 1
                        readOnlyIndex = readOnlyIndex + 1
                    Next m
                End If
                If (aItem.insertedB > aItem.deletedA) Then
                    readOnlyIndex = aItem.StartA + offsetA
                    For m As Integer = 0 To aItem.insertedB - aItem.deletedA - 1
                        syntaxEdit1.Lines.Insert(readOnlyIndex, String.Empty)
                        syntaxEdit1.Source.LineStyles.SetLineStyle(readOnlyIndex, 2)
                        syntaxEdit1.Source.SetLineReadonly(readOnlyIndex, True)
                        offsetA = offsetA + 1
                        readOnlyIndex = readOnlyIndex + 1
                    Next m
                End If
            Next fdx
        Finally
            syntaxEdit1.Lines.EndUpdate()
            syntaxEdit2.Lines.EndUpdate()
        End Try
    End Sub

    Private Sub btRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Click
        ProcessDifferences()
    End Sub

    Private Sub btOpenLeftFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpenLeftFile.Click
        If (openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            tbLeftSourceFile.Text = openFileDialog1.FileName
            syntaxEdit1.LoadFile(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub btOpenRightFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpenRightFile.Click
        If (openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            tbRightSourceFile.Text = openFileDialog1.FileName
            syntaxEdit2.LoadFile(openFileDialog1.FileName)
        End If
    End Sub
End Class
