Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports QWhale.Common
Imports QWhale.Syntax
Imports QWhale.Syntax.Parsers
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
    Friend WithEvents gbSelection As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelectionBackColor As QWhale.Common.ColorBox
    Friend WithEvents cbSelectionForeColor As QWhale.Common.ColorBox
    Friend WithEvents laSelectionBackColor As System.Windows.Forms.Label
    Friend WithEvents laSelectionForeColor As System.Windows.Forms.Label
    Friend WithEvents chbOverwriteBlocks As System.Windows.Forms.CheckBox
    Friend WithEvents chbPersistentBlocks As System.Windows.Forms.CheckBox
    Friend WithEvents chbDeselectOnCopy As System.Windows.Forms.CheckBox
    Friend WithEvents chbSelectLineOnDblClick As System.Windows.Forms.CheckBox
    Friend WithEvents chbHideSelection As System.Windows.Forms.CheckBox
    Friend WithEvents chbUseColors As System.Windows.Forms.CheckBox
    Friend WithEvents chbSelectBeyondEol As System.Windows.Forms.CheckBox
    Friend WithEvents chbDisableDragging As System.Windows.Forms.CheckBox
    Friend WithEvents chbDisableSelection As System.Windows.Forms.CheckBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents cbSelectionBorderColor As QWhale.Common.ColorBox
    Friend WithEvents laSelectionBorderColor As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.gbSelection = New System.Windows.Forms.GroupBox
        Me.cbSelectionBackColor = New QWhale.Common.ColorBox(Me.components)
        Me.cbSelectionForeColor = New QWhale.Common.ColorBox(Me.components)
        Me.laSelectionBackColor = New System.Windows.Forms.Label
        Me.laSelectionForeColor = New System.Windows.Forms.Label
        Me.chbOverwriteBlocks = New System.Windows.Forms.CheckBox
        Me.chbPersistentBlocks = New System.Windows.Forms.CheckBox
        Me.chbDeselectOnCopy = New System.Windows.Forms.CheckBox
        Me.chbSelectLineOnDblClick = New System.Windows.Forms.CheckBox
        Me.chbHideSelection = New System.Windows.Forms.CheckBox
        Me.chbUseColors = New System.Windows.Forms.CheckBox
        Me.chbSelectBeyondEol = New System.Windows.Forms.CheckBox
        Me.chbDisableDragging = New System.Windows.Forms.CheckBox
        Me.chbDisableSelection = New System.Windows.Forms.CheckBox
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.cbSelectionBorderColor = New QWhale.Common.ColorBox(Me.components)
        Me.laSelectionBorderColor = New System.Windows.Forms.Label
        Me.pnSettings.SuspendLayout()
        Me.gbSelection.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.gbSelection)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(624, 136)
        Me.pnSettings.TabIndex = 2
        '
        'gbSelection
        '
        Me.gbSelection.Controls.Add(Me.cbSelectionBorderColor)
        Me.gbSelection.Controls.Add(Me.laSelectionBorderColor)
        Me.gbSelection.Controls.Add(Me.cbSelectionBackColor)
        Me.gbSelection.Controls.Add(Me.cbSelectionForeColor)
        Me.gbSelection.Controls.Add(Me.laSelectionBackColor)
        Me.gbSelection.Controls.Add(Me.laSelectionForeColor)
        Me.gbSelection.Controls.Add(Me.chbOverwriteBlocks)
        Me.gbSelection.Controls.Add(Me.chbPersistentBlocks)
        Me.gbSelection.Controls.Add(Me.chbDeselectOnCopy)
        Me.gbSelection.Controls.Add(Me.chbSelectLineOnDblClick)
        Me.gbSelection.Controls.Add(Me.chbHideSelection)
        Me.gbSelection.Controls.Add(Me.chbUseColors)
        Me.gbSelection.Controls.Add(Me.chbSelectBeyondEol)
        Me.gbSelection.Controls.Add(Me.chbDisableDragging)
        Me.gbSelection.Controls.Add(Me.chbDisableSelection)
        Me.gbSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbSelection.Location = New System.Drawing.Point(0, 36)
        Me.gbSelection.Name = "gbSelection"
        Me.gbSelection.Size = New System.Drawing.Size(624, 100)
        Me.gbSelection.TabIndex = 9
        Me.gbSelection.TabStop = False
        Me.gbSelection.Text = "Selection Options"
        '
        'cbSelectionBackColor
        '
        Me.cbSelectionBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbSelectionBackColor.Location = New System.Drawing.Point(496, 42)
        Me.cbSelectionBackColor.Name = "cbSelectionBackColor"
        Me.cbSelectionBackColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbSelectionBackColor.Size = New System.Drawing.Size(121, 21)
        Me.cbSelectionBackColor.TabIndex = 17
        '
        'cbSelectionForeColor
        '
        Me.cbSelectionForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbSelectionForeColor.Location = New System.Drawing.Point(496, 18)
        Me.cbSelectionForeColor.Name = "cbSelectionForeColor"
        Me.cbSelectionForeColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbSelectionForeColor.Size = New System.Drawing.Size(121, 21)
        Me.cbSelectionForeColor.TabIndex = 16
        '
        'laSelectionBackColor
        '
        Me.laSelectionBackColor.AutoSize = True
        Me.laSelectionBackColor.Location = New System.Drawing.Point(424, 45)
        Me.laSelectionBackColor.Name = "laSelectionBackColor"
        Me.laSelectionBackColor.Size = New System.Drawing.Size(59, 16)
        Me.laSelectionBackColor.TabIndex = 15
        Me.laSelectionBackColor.Text = "Back Color"
        '
        'laSelectionForeColor
        '
        Me.laSelectionForeColor.AutoSize = True
        Me.laSelectionForeColor.Location = New System.Drawing.Point(424, 21)
        Me.laSelectionForeColor.Name = "laSelectionForeColor"
        Me.laSelectionForeColor.Size = New System.Drawing.Size(58, 16)
        Me.laSelectionForeColor.TabIndex = 14
        Me.laSelectionForeColor.Text = "Fore Color"
        '
        'chbOverwriteBlocks
        '
        Me.chbOverwriteBlocks.Location = New System.Drawing.Point(296, 64)
        Me.chbOverwriteBlocks.Name = "chbOverwriteBlocks"
        Me.chbOverwriteBlocks.Size = New System.Drawing.Size(112, 24)
        Me.chbOverwriteBlocks.TabIndex = 13
        Me.chbOverwriteBlocks.Text = "Overwrite Blocks"
        '
        'chbPersistentBlocks
        '
        Me.chbPersistentBlocks.Location = New System.Drawing.Point(296, 40)
        Me.chbPersistentBlocks.Name = "chbPersistentBlocks"
        Me.chbPersistentBlocks.Size = New System.Drawing.Size(112, 24)
        Me.chbPersistentBlocks.TabIndex = 12
        Me.chbPersistentBlocks.Text = "Persistent Blocks"
        '
        'chbDeselectOnCopy
        '
        Me.chbDeselectOnCopy.Location = New System.Drawing.Point(296, 16)
        Me.chbDeselectOnCopy.Name = "chbDeselectOnCopy"
        Me.chbDeselectOnCopy.Size = New System.Drawing.Size(112, 24)
        Me.chbDeselectOnCopy.TabIndex = 11
        Me.chbDeselectOnCopy.Text = "Deselect on Copy"
        '
        'chbSelectLineOnDblClick
        '
        Me.chbSelectLineOnDblClick.Location = New System.Drawing.Point(144, 64)
        Me.chbSelectLineOnDblClick.Name = "chbSelectLineOnDblClick"
        Me.chbSelectLineOnDblClick.Size = New System.Drawing.Size(140, 24)
        Me.chbSelectLineOnDblClick.TabIndex = 10
        Me.chbSelectLineOnDblClick.Text = "Select Line on DblClick"
        '
        'chbHideSelection
        '
        Me.chbHideSelection.Location = New System.Drawing.Point(144, 40)
        Me.chbHideSelection.Name = "chbHideSelection"
        Me.chbHideSelection.TabIndex = 9
        Me.chbHideSelection.Text = "Hide Selection"
        '
        'chbUseColors
        '
        Me.chbUseColors.Location = New System.Drawing.Point(144, 16)
        Me.chbUseColors.Name = "chbUseColors"
        Me.chbUseColors.TabIndex = 8
        Me.chbUseColors.Text = "Use Colors"
        '
        'chbSelectBeyondEol
        '
        Me.chbSelectBeyondEol.Location = New System.Drawing.Point(8, 64)
        Me.chbSelectBeyondEol.Name = "chbSelectBeyondEol"
        Me.chbSelectBeyondEol.Size = New System.Drawing.Size(122, 24)
        Me.chbSelectBeyondEol.TabIndex = 7
        Me.chbSelectBeyondEol.Text = "Select Beyond EOL"
        '
        'chbDisableDragging
        '
        Me.chbDisableDragging.Location = New System.Drawing.Point(8, 40)
        Me.chbDisableDragging.Name = "chbDisableDragging"
        Me.chbDisableDragging.Size = New System.Drawing.Size(112, 24)
        Me.chbDisableDragging.TabIndex = 6
        Me.chbDisableDragging.Text = "Disable Dragging"
        '
        'chbDisableSelection
        '
        Me.chbDisableSelection.Location = New System.Drawing.Point(8, 16)
        Me.chbDisableSelection.Name = "chbDisableSelection"
        Me.chbDisableSelection.Size = New System.Drawing.Size(112, 24)
        Me.chbDisableSelection.TabIndex = 5
        Me.chbDisableSelection.Text = "Disable Selection"
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(624, 36)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(624, 36)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo shows how to customize appearance and behaviour of selected text within" & _
        " edit control's content."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 136)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Pages.RulerBackColor = System.Drawing.Color.LightSteelBlue
        Me.syntaxEdit1.Pages.RulerIndentBackColor = System.Drawing.Color.SteelBlue
        Me.syntaxEdit1.Selection.Options = CType(((((QWhale.Editor.SelectionOptions.SelectBeyondEol Or QWhale.Editor.SelectionOptions.HideSelection) _
                    Or QWhale.Editor.SelectionOptions.OverwriteBlocks) _
                    Or QWhale.Editor.SelectionOptions.SmartFormat) _
                    Or QWhale.Editor.SelectionOptions.DrawBorder), QWhale.Editor.SelectionOptions)
        Me.syntaxEdit1.Size = New System.Drawing.Size(624, 182)
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
        'cbSelectionBorderColor
        '
        Me.cbSelectionBorderColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbSelectionBorderColor.Location = New System.Drawing.Point(496, 66)
        Me.cbSelectionBorderColor.Name = "cbSelectionBorderColor"
        Me.cbSelectionBorderColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbSelectionBorderColor.Size = New System.Drawing.Size(121, 21)
        Me.cbSelectionBorderColor.TabIndex = 21
        '
        'laSelectionBorderColor
        '
        Me.laSelectionBorderColor.AutoSize = True
        Me.laSelectionBorderColor.Location = New System.Drawing.Point(424, 69)
        Me.laSelectionBorderColor.Name = "laSelectionBorderColor"
        Me.laSelectionBorderColor.Size = New System.Drawing.Size(68, 16)
        Me.laSelectionBorderColor.TabIndex = 20
        Me.laSelectionBorderColor.Text = "Border Color"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 318)
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.gbSelection.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbDisableSelection.Checked = (SelectionOptions.DisableSelection And syntaxEdit1.Selection.Options) <> 0
        chbDisableDragging.Checked = (SelectionOptions.DisableDragging And syntaxEdit1.Selection.Options) <> 0
        chbSelectBeyondEol.Checked = (SelectionOptions.SelectBeyondEol And syntaxEdit1.Selection.Options) <> 0
        chbUseColors.Checked = (SelectionOptions.UseColors And syntaxEdit1.Selection.Options) <> 0
        chbHideSelection.Checked = (SelectionOptions.HideSelection And syntaxEdit1.Selection.Options) <> 0
        chbSelectLineOnDblClick.Checked = (SelectionOptions.SelectLineOnDblClick And syntaxEdit1.Selection.Options) <> 0
        chbDeselectOnCopy.Checked = (SelectionOptions.DeselectOnCopy And syntaxEdit1.Selection.Options) <> 0
        chbPersistentBlocks.Checked = (SelectionOptions.PersistentBlocks And syntaxEdit1.Selection.Options) <> 0
        chbOverwriteBlocks.Checked = (SelectionOptions.OverwriteBlocks And syntaxEdit1.Selection.Options) <> 0
        cbSelectionForeColor.SelectedColor = syntaxEdit1.Selection.ForeColor
        cbSelectionBackColor.SelectedColor = syntaxEdit1.Selection.BackColor
        cbSelectionBorderColor.SelectedColor = syntaxEdit1.Selection.BorderColor
    End Sub

    Private Sub chbDisableSelection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDisableSelection.CheckedChanged
        If chbDisableSelection.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.DisableSelection
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.DisableSelection
        End If
    End Sub

    Private Sub chbDisableDragging_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDisableDragging.CheckedChanged
        If chbDisableDragging.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.DisableDragging
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.DisableDragging
        End If
    End Sub

    Private Sub chbSelectBeyondEol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectBeyondEol.CheckedChanged
        If chbSelectBeyondEol.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.SelectBeyondEol
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.SelectBeyondEol
        End If
    End Sub

    Private Sub chbUseColors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUseColors.CheckedChanged
        If chbUseColors.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.UseColors
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.UseColors
        End If
    End Sub

    Private Sub chbHideSelection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHideSelection.CheckedChanged
        If chbHideSelection.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.HideSelection
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.HideSelection
        End If
    End Sub

    Private Sub chbSelectLineOnDblClick_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectLineOnDblClick.CheckedChanged
        If chbSelectLineOnDblClick.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.SelectLineOnDblClick
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.SelectLineOnDblClick
        End If
    End Sub

    Private Sub chbDeselectOnCopy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDeselectOnCopy.CheckedChanged
        If chbDeselectOnCopy.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.DeselectOnCopy
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.DeselectOnCopy
        End If
    End Sub

    Private Sub chbPersistentBlocks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPersistentBlocks.CheckedChanged
        If chbPersistentBlocks.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.PersistentBlocks
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.PersistentBlocks
        End If
    End Sub

    Private Sub chbOverwriteBlocks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbOverwriteBlocks.CheckedChanged
        If chbOverwriteBlocks.Checked Then
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Or SelectionOptions.OverwriteBlocks
        Else
            syntaxEdit1.Selection.Options = syntaxEdit1.Selection.Options Xor SelectionOptions.OverwriteBlocks
        End If
    End Sub

    Private Sub cbSelectionForeColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelectionForeColor.SelectedIndexChanged
        syntaxEdit1.Selection.ForeColor = cbSelectionForeColor.SelectedColor
    End Sub

    Private Sub cbSelectionBackColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelectionBackColor.SelectedIndexChanged
        syntaxEdit1.Selection.BackColor = cbSelectionBackColor.SelectedColor
    End Sub

    Private Sub cbSelectionBorderColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelectionBorderColor.SelectedIndexChanged
        syntaxEdit1.Selection.BorderColor = cbSelectionBorderColor.SelectedColor
    End Sub
End Class
