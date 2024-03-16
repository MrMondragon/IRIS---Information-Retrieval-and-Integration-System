Imports System
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
    Friend WithEvents laUserMarginBkColor As System.Windows.Forms.Label
    Friend WithEvents cbUserMarginBkColor As QWhale.Common.ColorBox
    Friend WithEvents laUserMarginForeColor As System.Windows.Forms.Label
    Friend WithEvents cbUserMarginForeColor As QWhale.Common.ColorBox
    Friend WithEvents laUserMarginText As System.Windows.Forms.Label
    Friend WithEvents tbUserMarginText As System.Windows.Forms.TextBox
    Friend WithEvents laUserMarginWidth As System.Windows.Forms.Label
    Friend WithEvents nudUserMarginWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents chbPaintUserMargin As System.Windows.Forms.CheckBox
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.laUserMarginBkColor = New System.Windows.Forms.Label
        Me.cbUserMarginBkColor = New QWhale.Common.ColorBox(Me.components)
        Me.laUserMarginForeColor = New System.Windows.Forms.Label
        Me.cbUserMarginForeColor = New QWhale.Common.ColorBox(Me.components)
        Me.laUserMarginText = New System.Windows.Forms.Label
        Me.tbUserMarginText = New System.Windows.Forms.TextBox
        Me.laUserMarginWidth = New System.Windows.Forms.Label
        Me.nudUserMarginWidth = New System.Windows.Forms.NumericUpDown
        Me.chbPaintUserMargin = New System.Windows.Forms.CheckBox
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.SyntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.pnSettings.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.nudUserMarginWidth, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnSettings.Size = New System.Drawing.Size(568, 104)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.laUserMarginBkColor)
        Me.groupBox1.Controls.Add(Me.cbUserMarginBkColor)
        Me.groupBox1.Controls.Add(Me.laUserMarginForeColor)
        Me.groupBox1.Controls.Add(Me.cbUserMarginForeColor)
        Me.groupBox1.Controls.Add(Me.laUserMarginText)
        Me.groupBox1.Controls.Add(Me.tbUserMarginText)
        Me.groupBox1.Controls.Add(Me.laUserMarginWidth)
        Me.groupBox1.Controls.Add(Me.nudUserMarginWidth)
        Me.groupBox1.Controls.Add(Me.chbPaintUserMargin)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 80)
        Me.groupBox1.TabIndex = 19
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "User margin"
        '
        'laUserMarginBkColor
        '
        Me.laUserMarginBkColor.AutoSize = True
        Me.laUserMarginBkColor.Location = New System.Drawing.Point(352, 51)
        Me.laUserMarginBkColor.Name = "laUserMarginBkColor"
        Me.laUserMarginBkColor.Size = New System.Drawing.Size(59, 16)
        Me.laUserMarginBkColor.TabIndex = 38
        Me.laUserMarginBkColor.Text = "Back Color"
        '
        'cbUserMarginBkColor
        '
        Me.cbUserMarginBkColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbUserMarginBkColor.Location = New System.Drawing.Point(424, 48)
        Me.cbUserMarginBkColor.Name = "cbUserMarginBkColor"
        Me.cbUserMarginBkColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbUserMarginBkColor.Size = New System.Drawing.Size(104, 21)
        Me.cbUserMarginBkColor.TabIndex = 37
        '
        'laUserMarginForeColor
        '
        Me.laUserMarginForeColor.AutoSize = True
        Me.laUserMarginForeColor.Location = New System.Drawing.Point(352, 19)
        Me.laUserMarginForeColor.Name = "laUserMarginForeColor"
        Me.laUserMarginForeColor.Size = New System.Drawing.Size(58, 16)
        Me.laUserMarginForeColor.TabIndex = 36
        Me.laUserMarginForeColor.Text = "Fore Color"
        '
        'cbUserMarginForeColor
        '
        Me.cbUserMarginForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbUserMarginForeColor.Location = New System.Drawing.Point(424, 16)
        Me.cbUserMarginForeColor.Name = "cbUserMarginForeColor"
        Me.cbUserMarginForeColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbUserMarginForeColor.Size = New System.Drawing.Size(104, 21)
        Me.cbUserMarginForeColor.TabIndex = 35
        '
        'laUserMarginText
        '
        Me.laUserMarginText.AutoSize = True
        Me.laUserMarginText.Location = New System.Drawing.Point(120, 51)
        Me.laUserMarginText.Name = "laUserMarginText"
        Me.laUserMarginText.Size = New System.Drawing.Size(87, 16)
        Me.laUserMarginText.TabIndex = 34
        Me.laUserMarginText.Text = "User margin text"
        '
        'tbUserMarginText
        '
        Me.tbUserMarginText.Location = New System.Drawing.Point(224, 48)
        Me.tbUserMarginText.Name = "tbUserMarginText"
        Me.tbUserMarginText.TabIndex = 33
        Me.tbUserMarginText.Text = ""
        '
        'laUserMarginWidth
        '
        Me.laUserMarginWidth.AutoSize = True
        Me.laUserMarginWidth.Location = New System.Drawing.Point(120, 19)
        Me.laUserMarginWidth.Name = "laUserMarginWidth"
        Me.laUserMarginWidth.Size = New System.Drawing.Size(95, 16)
        Me.laUserMarginWidth.TabIndex = 31
        Me.laUserMarginWidth.Text = "User margin width"
        '
        'nudUserMarginWidth
        '
        Me.nudUserMarginWidth.Location = New System.Drawing.Point(224, 16)
        Me.nudUserMarginWidth.Name = "nudUserMarginWidth"
        Me.nudUserMarginWidth.Size = New System.Drawing.Size(100, 20)
        Me.nudUserMarginWidth.TabIndex = 32
        '
        'chbPaintUserMargin
        '
        Me.chbPaintUserMargin.Location = New System.Drawing.Point(8, 16)
        Me.chbPaintUserMargin.Name = "chbPaintUserMargin"
        Me.chbPaintUserMargin.Size = New System.Drawing.Size(112, 24)
        Me.chbPaintUserMargin.TabIndex = 30
        Me.chbPaintUserMargin.Text = "Paint user margin"
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
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(568, 24)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo show how user margin can be used."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SyntaxEdit1
        '
        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SyntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SyntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.SyntaxEdit1.Lexer = Me.VbParser1
        Me.SyntaxEdit1.Location = New System.Drawing.Point(0, 104)
        Me.SyntaxEdit1.Name = "SyntaxEdit1"
        Me.SyntaxEdit1.Pages.RulerBackColor = System.Drawing.Color.LightSteelBlue
        Me.SyntaxEdit1.Pages.RulerIndentBackColor = System.Drawing.Color.SteelBlue
        Me.SyntaxEdit1.Pages.Transparent = False
        Me.SyntaxEdit1.Size = New System.Drawing.Size(568, 214)
        Me.SyntaxEdit1.TabIndex = 3
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
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 318)
        Me.Controls.Add(Me.SyntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        CType(Me.nudUserMarginWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbPaintUserMargin.Checked = (SyntaxEdit1.Gutter.Options And GutterOptions.PaintUserMargin) <> 0
        nudUserMarginWidth.Maximum = SyntaxEdit1.Width
        nudUserMarginWidth.Value = SyntaxEdit1.Gutter.UserMarginWidth
        tbUserMarginText.Text = SyntaxEdit1.Gutter.UserMarginText
        cbUserMarginForeColor.SelectedColor = SyntaxEdit1.Gutter.UserMarginForeColor
        cbUserMarginBkColor.SelectedColor = SyntaxEdit1.Gutter.UserMarginBackColor
    End Sub

    Private Sub chbPaintUserMargin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbPaintUserMargin.CheckedChanged
        If chbPaintUserMargin.Checked Then
            SyntaxEdit1.Gutter.Options = SyntaxEdit1.Gutter.Options Or GutterOptions.PaintUserMargin
        Else
            SyntaxEdit1.Gutter.Options = SyntaxEdit1.Gutter.Options Xor GutterOptions.PaintUserMargin
        End If
    End Sub

    Private Sub nudUserMarginWidth_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudUserMarginWidth.ValueChanged
        SyntaxEdit1.Gutter.UserMarginWidth = CType(nudUserMarginWidth.Value, Integer)
    End Sub

    Private Sub tbUserMarginText_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbUserMarginText.KeyDown
        If (e.KeyCode = System.Windows.Forms.Keys.Enter) Then
            SyntaxEdit1.Gutter.UserMarginText = tbUserMarginText.Text
        End If
    End Sub

    Private Sub tbUserMarginText_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUserMarginText.Leave
        SyntaxEdit1.Gutter.UserMarginText = tbUserMarginText.Text
    End Sub

    Private Sub cbUserMarginForeColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUserMarginForeColor.SelectedIndexChanged
        SyntaxEdit1.Gutter.UserMarginForeColor = cbUserMarginForeColor.SelectedColor
    End Sub

    Private Sub cbUserMarginBkColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUserMarginBkColor.SelectedIndexChanged
        SyntaxEdit1.Gutter.UserMarginBackColor = cbUserMarginBkColor.SelectedColor
    End Sub
End Class
