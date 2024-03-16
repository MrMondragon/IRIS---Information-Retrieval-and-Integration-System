Imports System.Reflection
Imports QWhale.Common
Imports QWhale.Syntax
Imports QWhale.Syntax.Parsers
Imports QWhale.Editor

Public Class Form1
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
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lbAssemblies As System.Windows.Forms.ListBox
    Friend WithEvents SyntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents cmAssemblies As System.Windows.Forms.ContextMenu
    Friend WithEvents miAddAssembly As System.Windows.Forms.MenuItem
    Friend WithEvents miRemoveAssembly As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.splitter1 = New System.Windows.Forms.Splitter
        Me.lbAssemblies = New System.Windows.Forms.ListBox
        Me.SyntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.cmAssemblies = New System.Windows.Forms.ContextMenu
        Me.miAddAssembly = New System.Windows.Forms.MenuItem
        Me.miRemoveAssembly = New System.Windows.Forms.MenuItem
        Me.pnSettings.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        '
        'openFileDialog1
        '
        Me.openFileDialog1.Filter = "Assembly files(*.dll)|*.dll|All files (*.*)|*.*"
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 40)
        Me.pnSettings.TabIndex = 6
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
        Me.laDescription.Text = "This demo shows how to use external assemblies in code completion."
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
        'splitter1
        '
        Me.splitter1.Location = New System.Drawing.Point(120, 40)
        Me.splitter1.Name = "splitter1"
        Me.splitter1.Size = New System.Drawing.Size(4, 278)
        Me.splitter1.TabIndex = 9
        Me.splitter1.TabStop = False
        '
        'lbAssemblies
        '
        Me.lbAssemblies.ContextMenu = Me.cmAssemblies
        Me.lbAssemblies.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbAssemblies.Location = New System.Drawing.Point(0, 40)
        Me.lbAssemblies.Name = "lbAssemblies"
        Me.lbAssemblies.Size = New System.Drawing.Size(120, 277)
        Me.lbAssemblies.TabIndex = 8
        '
        'SyntaxEdit1
        '
        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SyntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SyntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.SyntaxEdit1.Lexer = Me.VbParser1
        Me.SyntaxEdit1.Location = New System.Drawing.Point(124, 40)
        Me.SyntaxEdit1.Name = "SyntaxEdit1"
        Me.SyntaxEdit1.Size = New System.Drawing.Size(444, 278)
        Me.SyntaxEdit1.TabIndex = 10
        Me.SyntaxEdit1.Text = "Public Class Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Inherits System.Windows.Forms.Form" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "#Region "" Windows F" & _
        "orm Designer generated code """ & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public Sub New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        MyBase.New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "'This call is required by the Windows Form Designer." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        InitializeComponen" & _
        "t()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'Add any initialization after the InitializeComponent() call" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "   End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Form overrides dispose to clean up the component list." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " Prot" & _
        "ected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " If disposing" & _
        " Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            If Not (components Is Nothing) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         components.Disp" & _
        "ose()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        MyBase.Dispose(disposing)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        " End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Required by the Windows Form Designer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Private components A" & _
        "s System.ComponentModel.IContainer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'NOTE: The following procedure is requ" & _
        "ired by the Windows Form Designer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'It can be modified using the Windows For" & _
        "m Designer.  " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    'Do not modify it using the code editor." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEven" & _
        "ts pnManage As System.Windows.Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents SyntaxEdit1 As " & _
        "QWhale.Editor.SyntaxEdit" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents pnDescription As System.Windows." & _
        "Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Friend WithEvents laDescription As System.Windows.Forms.Label" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.components = New System.ComponentModel.Container" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.pnManage " & _
        "= New System.Windows.Forms.Panel" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1 = New QWhale.Editor.Syn" & _
        "taxEdit(Me.components)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription = New System.Windows.Forms.Pane" & _
        "l" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription = New System.Windows.Forms.Label" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       Me.pnManage" & _
        ".SuspendLayout()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.SuspendLayout()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.SuspendLayo" & _
        "ut()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'pnManage" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.pnManage.Controls.Add(Me" & _
        ".pnDescription)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Dock = System.Windows.Forms.DockStyle.Top" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "        Me.pnManage.Location = New System.Drawing.Point(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Me.pnManage.Name " & _
        "= ""pnManage""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnManage.Size = New System.Drawing.Size(568, 88)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   Me" & _
        ".pnManage.TabIndex = 2" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'SyntaxEdit1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " Me.SyntaxEdi" & _
        "t1.BackColor = System.Drawing.SystemColors.Window" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Cursor" & _
        " = System.Windows.Forms.Cursors.IBeam" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Dock = System.Wind" & _
        "ows.Forms.DockStyle.Fill" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Font = New System.Drawing.Font(" & _
        """Courier New"", 10.0!)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.SyntaxEdit1.Location = New System.Drawing.Point(0" & _
        ", 88)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.SyntaxEdit1.Name = ""SyntaxEdit1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Me.SyntaxEdit1.Size = New Sy" & _
        "stem.Drawing.Size(568, 230)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.SyntaxEdit1.TabIndex = 3" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.SyntaxEd" & _
        "it1.Text = """"" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'pnDescription" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.pnDescripti" & _
        "on.Controls.Add(Me.laDescription)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       Me.pnDescription.Dock = System.Windows" & _
        ".Forms.DockStyle.Top" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.Location = New System.Drawing.Poi" & _
        "nt(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.pnDescription.Name = ""pnDescription""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.pnDescriptio" & _
        "n.Size = New System.Drawing.Size(568, 40)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       Me.pnDescription.TabIndex = 8" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'laDescription" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.Dock = Sys" & _
        "tem.Windows.Forms.DockStyle.Fill" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.Location = New System" & _
        ".Drawing.Point(0, 0)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.laDescription.Name = ""laDescription""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Me.la" & _
        "Description.Size = New System.Drawing.Size(568, 40)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.laDescription.TabI" & _
        "ndex = 1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     Me.laDescription.Text = ""Label1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Me.laDescription.TextAlign " & _
        "= System.Drawing.ContentAlignment.TopCenter" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        'Form1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     '" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    " & _
        " Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.ClientSize = Ne" & _
        "w System.Drawing.Size(568, 318)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Me.Controls.Add(Me.SyntaxEdit1)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Me.C" & _
        "ontrols.Add(Me.pnManage)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " Me.Name = ""Form1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Me.Text = ""Form1""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       " & _
        " Me.pnManage.ResumeLayout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Me.pnDescription.ResumeLayout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Me.R" & _
        "esumeLayout(False)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "#End Region" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class"
        '
        'cmAssemblies
        '
        Me.cmAssemblies.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miAddAssembly, Me.miRemoveAssembly})
        '
        'miAddAssembly
        '
        Me.miAddAssembly.Index = 0
        Me.miAddAssembly.Text = "Add Assembly"
        '
        'miRemoveAssembly
        '
        Me.miRemoveAssembly.Index = 1
        Me.miRemoveAssembly.Text = "Remove Assembly"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 318)
        Me.Controls.Add(Me.SyntaxEdit1)
        Me.Controls.Add(Me.splitter1)
        Me.Controls.Add(Me.lbAssemblies)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim assemblies As Hashtable = New Hashtable
    Dim namespaces As Hashtable = New Hashtable
    Private Sub OpenFile()
        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            AddAssembly(openFileDialog1.FileName)
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(openFileDialog1.FileName)
            If ((Not asm Is Nothing) And (Not assemblies.Contains(asm.FullName))) Then
                assemblies.Add(asm.FullName, asm)
                VbParser1.RegisterAssembly(asm)
                Dim namespaces As ArrayList = GetNamespaces(asm)
                For Each nSpace As String In namespaces
                    VbParser1.RegisterNamespace(nSpace)
                Next (nSpace)
            End If
        End If
    End Sub
    Private Function GetNamespaces(ByVal asm As System.Reflection.Assembly) As ArrayList
        Dim result As ArrayList = New ArrayList
        Dim types As Type() = asm.GetTypes()
        For i As Integer = 0 To types.Length - 1

            If (Not result.Contains(types(i).Namespace) And (types(i).Namespace <> String.Empty) And (types(i).Namespace <> Nothing)) Then
                result.Add(types(i).Namespace)
            End If
        Next i
        Return result
    End Function
    Private Sub AddAssemblies()
        lbAssemblies.Items.Clear()
        'For Each asm As System.Reflection.Assembly In AppDomain.CurrentDomain.GetAssemblies()
        For Each asm As System.Reflection.Assembly In CType(VbParser1.CompletionRepository, IReflectionRepository).Assemblies
            AddAssembly(asm, False)
        Next asm
    End Sub

    Private Sub AddAssembly(ByVal asmName As String)
        Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(asmName)
        AddAssembly(asm, True)
    End Sub
    Private Sub AddAssembly(ByVal asm As System.Reflection.Assembly, ByVal addToParser As Boolean)
        If (Not asm Is Nothing) Then
            Dim asmName As String = asm.GetName().Name
            If (Not assemblies.Contains(asmName)) Then
                assemblies.Add(asmName, asm)
                If addToParser Then
                    VbParser1.RegisterAssembly(asm)
                End If
                Dim nSpaces As ArrayList = GetNamespaces(asm)
                For Each nSpace As String In namespaces
                    Dim asmNames As ArrayList = Nothing
                    If (namespaces.Contains(nSpace)) Then
                        asmNames = CType(namespaces(nSpace), ArrayList)
                        asmNames.Add(asmName)
                    Else
                        asmNames = New ArrayList
                        asmNames.Add(asm.FullName)
                        namespaces.Add(nSpace, asmNames)
                    End If
                    If addToParser Then
                        VbParser1.RegisterNamespace(nSpace)
                    End If
                Next nSpace
                lbAssemblies.Items.Add(asmName)
                lbAssemblies.SelectedIndex = lbAssemblies.Items.Count - 1
            End If
        End If
    End Sub
    Private Sub RemoveAssembly(ByVal asmName As String)
        Dim asm As System.Reflection.Assembly = CType(assemblies(asmName), System.Reflection.Assembly)
        If Not asm Is Nothing Then
            assemblies.Remove(asmName)
            VbParser1.UnregisterAssembly(asm, True)
            Dim nSpaces As ArrayList = GetNamespaces(asm)
            For Each nSpace As String In namespaces
                Dim asmNames As ArrayList = CType(namespaces(nSpace), ArrayList)
                If Not asmNames Is Nothing Then
                    asmNames.Remove(asmName)
                End If
                If asmNames.Count = 0 Then
                    VbParser1.UnregisterNamespace(nSpace)
                End If
            Next nSpace
            lbAssemblies.Items.Remove(asmName)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddAssemblies()
    End Sub

    Private Sub miAddAssembly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAddAssembly.Click
        OpenFile()
    End Sub

    Private Sub miRemoveAssembly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miRemoveAssembly.Click
        Dim asmName As String = String.Empty
        If (Not lbAssemblies.SelectedItem Is Nothing) Then
            asmName = CType(lbAssemblies.SelectedItem, String)
        End If
        If (asmName <> String.Empty) Then
            RemoveAssembly(asmName)
        End If
    End Sub

    Private Sub cmAssemblies_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmAssemblies.Popup
        miRemoveAssembly.Enabled = (Not lbAssemblies.SelectedItem Is Nothing)
    End Sub
End Class
