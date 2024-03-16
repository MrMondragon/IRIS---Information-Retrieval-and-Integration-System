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
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    Friend WithEvents btReverse As System.Windows.Forms.Button
    Friend WithEvents laUndoRedo As System.Windows.Forms.Label
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbUndoOperations As System.Windows.Forms.ListBox
    Friend WithEvents SyntaxEdit1 As QWhale.Editor.SyntaxEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.btReverse = New System.Windows.Forms.Button
        Me.laUndoRedo = New System.Windows.Forms.Label
        Me.panel1 = New System.Windows.Forms.Panel
        Me.lbUndoOperations = New System.Windows.Forms.ListBox
        Me.SyntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.pnSettings.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.btReverse)
        Me.pnSettings.Controls.Add(Me.laUndoRedo)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 72)
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
        Me.laDescription.Text = "This demo show how to use undo\redo history."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'btReverse
        '
        Me.btReverse.Enabled = False
        Me.btReverse.Location = New System.Drawing.Point(8, 40)
        Me.btReverse.Name = "btReverse"
        Me.btReverse.Size = New System.Drawing.Size(96, 23)
        Me.btReverse.TabIndex = 19
        Me.btReverse.Text = "Reverse undo"
        '
        'laUndoRedo
        '
        Me.laUndoRedo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laUndoRedo.AutoSize = True
        Me.laUndoRedo.Location = New System.Drawing.Point(368, 48)
        Me.laUndoRedo.Name = "laUndoRedo"
        Me.laUndoRedo.Size = New System.Drawing.Size(61, 16)
        Me.laUndoRedo.TabIndex = 18
        Me.laUndoRedo.Text = "Undo\Redo"
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.lbUndoOperations)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.panel1.Location = New System.Drawing.Point(360, 72)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(208, 246)
        Me.panel1.TabIndex = 17
        '
        'lbUndoOperations
        '
        Me.lbUndoOperations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbUndoOperations.Location = New System.Drawing.Point(0, 0)
        Me.lbUndoOperations.Name = "lbUndoOperations"
        Me.lbUndoOperations.Size = New System.Drawing.Size(208, 238)
        Me.lbUndoOperations.TabIndex = 0
        '
        'SyntaxEdit1
        '
        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SyntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SyntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.SyntaxEdit1.Lexer = Me.VbParser1
        Me.SyntaxEdit1.Location = New System.Drawing.Point(0, 72)
        Me.SyntaxEdit1.Name = "SyntaxEdit1"
        Me.SyntaxEdit1.Pages.Transparent = False
        Me.SyntaxEdit1.Size = New System.Drawing.Size(360, 246)
        Me.SyntaxEdit1.TabIndex = 18
        Me.SyntaxEdit1.Text = "Public Class Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Inherits System.Windows.Forms.Form" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "#Region "" Windows F" & _
        "orm Designer generated code """ & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public Sub New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        MyBase.New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "    'This call is required by the Windows Form Designer." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        InitializeComp" & _
        "onent()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'Add any initialization after the InitializeComponent() call" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Form overrides dispose to clean up the component list." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " If di" & _
        "sposing Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            If Not (components Is Nothing) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         componen" & _
        "ts.Dispose()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        MyBase.Dispose(disposi" & _
        "ng)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Required by the Windows Form Designer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private comp" & _
        "onents As System.ComponentModel.IContainer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'NOTE: The following procedure" & _
        " is required by the Windows Form Designer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'It can be modified using the Win" & _
        "dows Form Designer.  " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Do not modify it using the code editor." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend " & _
        "WithEvents pnManage As System.Windows.Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents SyntaxE" & _
        "dit1 As QWhale.Editor.SyntaxEdit" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents pnDescription As System." & _
        "Windows.Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents laDescription As System.Windows.Forms" & _
        ".Label" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeCom" & _
        "ponent()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.components = New System.ComponentModel.Container" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.p" & _
        "nManage = New System.Windows.Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1 = New QWhale.Ed" & _
        "itor.SyntaxEdit(Me.components)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription = New System.Windows.Fo" & _
        "rms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription = New System.Windows.Forms.Label" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       Me." & _
        "pnManage.SuspendLayout()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.SuspendLayout()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.Sus" & _
        "pendLayout()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'pnManage" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.pnManage.Control" & _
        "s.Add(Me.pnDescription)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Dock = System.Windows.Forms.DockSty" & _
        "le.Top" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Location = New System.Drawing.Point(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Me.pnMana" & _
        "ge.Name = ""pnManage""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Size = New System.Drawing.Size(568, 88" & _
        ")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.TabIndex = 2" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'SyntaxEdit1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        M" & _
        "e.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit" & _
        "1.Dock = System.Windows.Forms.DockStyle.Fill" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Font = New " & _
        "System.Drawing.Font(""Courier New"", 10.0!)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.SyntaxEdit1.Location = New Sy" & _
        "stem.Drawing.Point(0, 88)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Name = ""SyntaxEdit1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        " & _
        "Me.SyntaxEdit1.Size = New System.Drawing.Size(568, 230)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.SyntaxEdit1.Ta" & _
        "bIndex = 3" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Text = """"" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'pnDescription" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.Controls.Add(Me.laDescription)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       Me.p" & _
        "nDescription.Dock = System.Windows.Forms.DockStyle.Top" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription" & _
        ".Location = New System.Drawing.Point(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.Name = ""pnD" & _
        "escription""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.Size = New System.Drawing.Size(568, 40)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "       Me.pnDescription.TabIndex = 8" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'laDescription" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        M" & _
        "e.laDescription.Location = New System.Drawing.Point(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescript" & _
        "ion.Name = ""laDescription""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.Size = New System.Drawing.S" & _
        "ize(568, 40)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.TabIndex = 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.laDescription.Text " & _
        "= ""Label1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.TextAlign = System.Drawing.ContentAlignment" & _
        ".TopCenter" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.AutoScaleBaseSize = Ne" & _
        "w System.Drawing.Size(5, 13)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.ClientSize = New System.Drawing.Size(568," & _
        " 318)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.Controls.Add(Me.SyntaxEdit1)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.Controls.Add(Me.pnManag" & _
        "e)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.Name = ""Form1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.Text = ""Form1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Re" & _
        "sumeLayout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.ResumeLayout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Me.ResumeLa" & _
        "yout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "#End Region" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 318)
        Me.Controls.Add(Me.SyntaxEdit1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub SyntaxEdit1_SourceStateChanged(ByVal sender As Object, ByVal e As QWhale.Editor.NotifyEventArgs) Handles SyntaxEdit1.SourceStateChanged
        If (SyntaxEdit1.Source.UndoList.Count <> undoListCount) Then
            UpdateUndoList()
        End If
    End Sub

    Private undoListCount As Integer

    Private Sub UpdateUndoList()
        undoListCount = SyntaxEdit1.Source.UndoList.Count
        Dim s As String = String.Empty
        lbUndoOperations.BeginUpdate()
        Try
            lbUndoOperations.Items.Clear()
            For Each uData As UndoData In SyntaxEdit1.Source.UndoList
                'if (uData.Operation != UndoOperation.Navigate)
                If s = String.Empty Then
                    s = s + String.Format("{0}", uData.Operation)
                Else
                    s = s + String.Format(",{0}", uData.Operation)
                End If
            Next uData
        Finally
            lbUndoOperations.Items.AddRange(s.Split(","c))
            lbUndoOperations.EndUpdate()
        End Try
    End Sub
    Private Function GetUndoData() As UndoData
        If ((lbUndoOperations.SelectedIndex = -1) Or (lbUndoOperations.SelectedIndex > SyntaxEdit1.Source.UndoList.Count)) Then
            Return Nothing
        End If
        Return CType(SyntaxEdit1.Source.UndoList(lbUndoOperations.SelectedIndex), UndoData)
    End Function
    Private Sub OperateUndo()
        SyntaxEdit1.Source.Undo(GetUndoData())
        UpdateUndoList()
    End Sub

    Private Sub btReverse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btReverse.Click
        OperateUndo()
    End Sub

    Private Sub lbUndoOperations_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbUndoOperations.SelectedIndexChanged
        btReverse.Enabled = lbUndoOperations.SelectedIndex >= -1
    End Sub
End Class
