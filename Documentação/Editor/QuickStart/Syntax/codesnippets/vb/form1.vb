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
    Friend WithEvents SyntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbVBSnippets As System.Windows.Forms.RadioButton
    Friend WithEvents rbCSharpSnippets As System.Windows.Forms.RadioButton
    Friend WithEvents textSource2 As QWhale.Editor.TextSource
    Friend WithEvents vbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents csParser1 As QWhale.Syntax.Parsers.CsParser
    Friend WithEvents textSource1 As QWhale.Editor.TextSource
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.SyntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.rbVBSnippets = New System.Windows.Forms.RadioButton
        Me.rbCSharpSnippets = New System.Windows.Forms.RadioButton
        Me.textSource2 = New QWhale.Editor.TextSource(Me.components)
        Me.vbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.csParser1 = New QWhale.Syntax.Parsers.CsParser
        Me.textSource1 = New QWhale.Editor.TextSource(Me.components)
        Me.pnSettings.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.groupBox1)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 104)
        Me.pnSettings.TabIndex = 2
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(568, 40)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(568, 40)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo shows how to use code snippets to complete content. Press ""Ctrl + K + X" & _
        """ to see snippets."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SyntaxEdit1
        '
        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SyntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SyntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.SyntaxEdit1.Lexer = Me.vbParser1
        Me.SyntaxEdit1.Location = New System.Drawing.Point(0, 104)
        Me.SyntaxEdit1.Name = "SyntaxEdit1"
        Me.SyntaxEdit1.Pages.RulerBackColor = System.Drawing.Color.LightSteelBlue
        Me.SyntaxEdit1.Pages.RulerIndentBackColor = System.Drawing.Color.SteelBlue
        Me.SyntaxEdit1.Size = New System.Drawing.Size(568, 214)
        Me.SyntaxEdit1.Source = Me.textSource2
        Me.SyntaxEdit1.TabIndex = 3
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.rbVBSnippets)
        Me.groupBox1.Controls.Add(Me.rbCSharpSnippets)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 40)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 64)
        Me.groupBox1.TabIndex = 18
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Snippets"
        '
        'rbVBSnippets
        '
        Me.rbVBSnippets.Checked = True
        Me.rbVBSnippets.Location = New System.Drawing.Point(8, 36)
        Me.rbVBSnippets.Name = "rbVBSnippets"
        Me.rbVBSnippets.TabIndex = 1
        Me.rbVBSnippets.TabStop = True
        Me.rbVBSnippets.Text = "VB snippets"
        '
        'rbCSharpSnippets
        '
        Me.rbCSharpSnippets.Location = New System.Drawing.Point(8, 16)
        Me.rbCSharpSnippets.Name = "rbCSharpSnippets"
        Me.rbCSharpSnippets.TabIndex = 0
        Me.rbCSharpSnippets.Text = "C# snippets"
        '
        'textSource2
        '
        Me.textSource2.Lexer = Me.vbParser1
        Me.textSource2.Text = "Public Class Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Inherits System.Windows.Forms.Form" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "#Region "" Windows F" & _
        "orm Designer generated code """ & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public Sub New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        MyBase.New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "     'This call is required by the Windows Form Designer." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        InitializeCom" & _
        "ponent()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'Add any initialization after the InitializeComponent() call" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Form overrides dispose to clean up the component list." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " If d" & _
        "isposing Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            If Not (components Is Nothing) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         compone" & _
        "nts.Dispose()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        MyBase.Dispose(dispos" & _
        "ing)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Required by the Windows Form Designer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private com" & _
        "ponents As System.ComponentModel.IContainer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'NOTE: The following procedur" & _
        "e is required by the Windows Form Designer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'It can be modified using the Wi" & _
        "ndows Form Designer.  " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Do not modify it using the code editor." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend" & _
        " WithEvents pnManage As System.Windows.Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents Syntax" & _
        "Edit1 As QWhale.Editor.SyntaxEdit" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents pnDescription As System" & _
        ".Windows.Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents laDescription As System.Windows.Form" & _
        "s.Label" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeCo" & _
        "mponent()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.components = New System.ComponentModel.Container" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me." & _
        "pnManage = New System.Windows.Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1 = New QWhale.E" & _
        "ditor.SyntaxEdit(Me.components)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription = New System.Windows.F" & _
        "orms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription = New System.Windows.Forms.Label" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       Me" & _
        ".pnManage.SuspendLayout()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.SuspendLayout()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.Su" & _
        "spendLayout()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'pnManage" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.pnManage.Contro" & _
        "ls.Add(Me.pnDescription)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Dock = System.Windows.Forms.DockSt" & _
        "yle.Top" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Location = New System.Drawing.Point(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        " & _
        "Me.pnManage.Name = ""pnManage""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Size = New System.Drawing.Siz" & _
        "e(568, 88)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.TabIndex = 2" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'SyntaxEdit1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "       '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me." & _
        "SyntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.F" & _
        "ont = New System.Drawing.Font(""Courier New"", 10.0!)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.SyntaxEdit1.Locatio" & _
        "n = New System.Drawing.Point(0, 88)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Name = ""SyntaxEdit1""" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Size = New System.Drawing.Size(568, 230)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.Synt" & _
        "axEdit1.TabIndex = 3" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Text = """"" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'pnDe" & _
        "scription" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.Controls.Add(Me.laDescription)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "       Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pn" & _
        "Description.Location = New System.Drawing.Point(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription." & _
        "Name = ""pnDescription""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.Size = New System.Drawing.Size(" & _
        "568, 40)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.TabIndex = 8" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'laDescription" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.Location = New System.Drawing.Point(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me" & _
        ".laDescription.Name = ""laDescription""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.Size = New Syste" & _
        "m.Drawing.Size(568, 40)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.TabIndex = 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.laDescri" & _
        "ption.Text = ""Label1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.TextAlign = System.Drawing.Conte" & _
        "ntAlignment.TopCenter" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.AutoScaleBa" & _
        "seSize = New System.Drawing.Size(5, 13)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.ClientSize = New System.Drawin" & _
        "g.Size(568, 318)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.Controls.Add(Me.SyntaxEdit1)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.Controls.Add" & _
        "(Me.pnManage)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.Name = ""Form1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.Text = ""Form1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me." & _
        "pnManage.ResumeLayout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.ResumeLayout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    " & _
        "    Me.ResumeLayout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "#End Region" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class"
        '
        'vbParser1
        '
        Me.vbParser1.DefaultState = 0
        Me.VbParser1.Options = CType(((((QWhale.Syntax.SyntaxOptions.Outline Or QWhale.Syntax.SyntaxOptions.SmartIndent) _
                    Or QWhale.Syntax.SyntaxOptions.CodeCompletion) _
                    Or QWhale.Syntax.SyntaxOptions.SyntaxErrors) _
                    Or QWhale.Syntax.SyntaxOptions.ReparseOnLineChange), QWhale.Syntax.SyntaxOptions)
        Me.vbParser1.XmlScheme = "<?xml version=""1.0"" encoding=""utf-16""?>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "<LexScheme xmlns:xsd=""http://www.w3.org/" & _
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
        'csParser1
        '
        Me.csParser1.DefaultState = 0
        Me.csParser1.Options = CType((((QWhale.Syntax.SyntaxOptions.Outline Or QWhale.Syntax.SyntaxOptions.SmartIndent) _
                    Or QWhale.Syntax.SyntaxOptions.CodeCompletion) _
                    Or QWhale.Syntax.SyntaxOptions.SyntaxErrors), QWhale.Syntax.SyntaxOptions)
        Me.csParser1.XmlScheme = "<?xml version=""1.0"" encoding=""utf-16""?>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "<LexScheme xmlns:xsd=""http://www.w3.org/" & _
        "2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Autho" & _
        "r>Quantum Whale LLC.</Author>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Name />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Desc />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Copyright>Copyright (c" & _
        ") 2004, 2005 Quantum Whale LLC.</Copyright>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileExtension />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileType>c#" & _
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
        "   </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <States />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "</LexScheme>"
        '
        'textSource1
        '
        Me.textSource1.Lexer = Me.csParser1
        Me.textSource1.Text = "using System;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Drawing;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Collections;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Com" & _
        "ponentModel;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Windows.Forms;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "using System.Data;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "namespace Templ" & _
        "ate" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "/// <summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "/// Summary description for Form1." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "/// </summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "p" & _
        "ublic class Form1 : System.Windows.Forms.Form" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "private QWhale.Editor.Synta" & _
        "xEdit syntaxEdit1;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "private System.Windows.Forms.Panel pnManage;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "private Sy" & _
        "stem.Windows.Forms.Panel pnDescription;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "private System.Windows.Forms.Label la" & _
        "Description;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "private System.ComponentModel.IContainer components;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "public" & _
        " Form1()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// Required for Windows Form Designer support" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & _
        "" & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "InitializeComponent();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// TODO: Add any constructor code after In" & _
        "itializeComponent call" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "//" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// <summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// Clean up any resour" & _
        "ces being used." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// </summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "protected override void Dispose( bool dispo" & _
        "sing )" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "if( disposing )" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "if (components != null) " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & _
        "" & Microsoft.VisualBasic.ChrW(9) & "components.Dispose();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "base.Dispose( disposing );" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "#re" & _
        "gion Windows Form Designer generated code" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// <summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// Required metho" & _
        "d for Designer support - do not modify" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// the contents of this method with t" & _
        "he code editor." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// </summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "private void InitializeComponent()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & _
        "" & Microsoft.VisualBasic.ChrW(9) & "this.components = new System.ComponentModel.Container();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnManage = ne" & _
        "w System.Windows.Forms.Panel();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1 = new QWhale.Editor.SyntaxE" & _
        "dit(this.components);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDescription = new System.Windows.Forms.Panel();" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.laDescription = new System.Windows.Forms.Label();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnManage.Su" & _
        "spendLayout();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDescription.SuspendLayout();" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.SuspendLayout();" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// pnManage" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnManage.Controls.Add(this.pnDescripti" & _
        "on);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnManage.Dock = System.Windows.Forms.DockStyle.Top;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnMan" & _
        "age.Location = new System.Drawing.Point(0, 0);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnManage.Name = ""pnManag" & _
        "e"";" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnManage.Size = new System.Drawing.Size(568, 88);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnManage" & _
        ".TabIndex = 1;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// syntaxEdit1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1.BackColor" & _
        " = System.Drawing.SystemColors.Window;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1.Cursor = System.Wind" & _
        "ows.Forms.Cursors.IBeam;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1.Dock = System.Windows.Forms.DockSt" & _
        "yle.Fill;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1.Font = new System.Drawing.Font(""Courier New"", 10F" & _
        ");" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1.Location = new System.Drawing.Point(0, 88);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syn" & _
        "taxEdit1.Name = ""syntaxEdit1"";" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1.Size = new System.Drawing.Si" & _
        "ze(568, 230);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1.TabIndex = 2;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.syntaxEdit1.Text = """";" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// pnDescription" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDescription.Controls.Add(this.l" & _
        "aDescription);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDescription.Location = new System.Drawing.Point(0, 0);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDe" & _
        "scription.Name = ""pnDescription"";" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDescription.Size = new System.Drawi" & _
        "ng.Size(568, 40);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDescription.TabIndex = 8;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// laDescript" & _
        "ion" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "" & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.laDescription.Location = new System.Drawing.Point(0, 0);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.laDesc" & _
        "ription.Name = ""laDescription"";" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.laDescription.Size = new System.Drawing" & _
        ".Size(568, 40);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.laDescription.TabIndex = 1;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.laDescription.Text" & _
        " = ""Label1"";" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.laDescription.TextAlign = System.Drawing.ContentAlignment." & _
        "TopCenter;" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "// " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.AutoScaleBaseSize = new System." & _
        "Drawing.Size(5, 13);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.ClientSize = new System.Drawing.Size(568, 318);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & _
        "" & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.Controls.Add(this.syntaxEdit1);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.Controls.Add(this.pnManage);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & _
        "" & Microsoft.VisualBasic.ChrW(9) & "this.Name = ""Form1"";" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.Text = ""Form1"";" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnManage.ResumeLayout(fa" & _
        "lse);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.pnDescription.ResumeLayout(false);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "this.ResumeLayout(false);" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "#endregion" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// <summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// The main entry point for the appl" & _
        "ication." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "/// </summary>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "[STAThread]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "static void Main() " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "{" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "Applic" & _
        "ation.Run(new Form1());" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "}" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "}"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 318)
        Me.Controls.Add(Me.SyntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UpdateSnippets()
        If (rbCSharpSnippets.Checked) Then
            SyntaxEdit1.Source = textSource1
            SyntaxEdit1.Lexer = csParser1
        Else
            SyntaxEdit1.Source = textSource2
            SyntaxEdit1.Lexer = vbParser1
        End If
    End Sub

    Private dir As String = Application.StartupPath

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateSnippets()
        vbParser1.CodeSnippets.LoadFile(dir + "\VB.xml")
    End Sub

    Private Sub rbCSharpSnippets_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCSharpSnippets.CheckedChanged
        UpdateSnippets()
    End Sub

    Private Sub rbVBSnippets_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbVBSnippets.CheckedChanged
        UpdateSnippets()
    End Sub
End Class
