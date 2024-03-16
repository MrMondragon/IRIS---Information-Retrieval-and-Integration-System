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
    Friend WithEvents cbFontStyle As System.Windows.Forms.ComboBox
    Friend WithEvents laFontStyle As System.Windows.Forms.Label
    Friend WithEvents cbBracesColor As QWhale.Common.ColorBox
    Friend WithEvents laBracesColor As System.Windows.Forms.Label
    Friend WithEvents chbHighlightBounds As System.Windows.Forms.CheckBox
    Friend WithEvents chbTempHighlightBraces As System.Windows.Forms.CheckBox
    Friend WithEvents chbHighlightBraces As System.Windows.Forms.CheckBox
    Friend WithEvents chbUseRoundRect As System.Windows.Forms.CheckBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.cbFontStyle = New System.Windows.Forms.ComboBox
        Me.laFontStyle = New System.Windows.Forms.Label
        Me.cbBracesColor = New QWhale.Common.ColorBox(Me.components)
        Me.laBracesColor = New System.Windows.Forms.Label
        Me.chbHighlightBounds = New System.Windows.Forms.CheckBox
        Me.chbTempHighlightBraces = New System.Windows.Forms.CheckBox
        Me.chbHighlightBraces = New System.Windows.Forms.CheckBox
        Me.chbUseRoundRect = New System.Windows.Forms.CheckBox
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
        Me.pnSettings.Size = New System.Drawing.Size(568, 104)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.cbFontStyle)
        Me.groupBox1.Controls.Add(Me.laFontStyle)
        Me.groupBox1.Controls.Add(Me.cbBracesColor)
        Me.groupBox1.Controls.Add(Me.laBracesColor)
        Me.groupBox1.Controls.Add(Me.chbHighlightBounds)
        Me.groupBox1.Controls.Add(Me.chbTempHighlightBraces)
        Me.groupBox1.Controls.Add(Me.chbHighlightBraces)
        Me.groupBox1.Controls.Add(Me.chbUseRoundRect)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 80)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Braces"
        '
        'cbFontStyle
        '
        Me.cbFontStyle.Location = New System.Drawing.Point(344, 18)
        Me.cbFontStyle.Name = "cbFontStyle"
        Me.cbFontStyle.Size = New System.Drawing.Size(121, 21)
        Me.cbFontStyle.TabIndex = 15
        Me.cbFontStyle.Text = "Regular"
        '
        'laFontStyle
        '
        Me.laFontStyle.AutoSize = True
        Me.laFontStyle.Location = New System.Drawing.Point(272, 21)
        Me.laFontStyle.Name = "laFontStyle"
        Me.laFontStyle.Size = New System.Drawing.Size(55, 16)
        Me.laFontStyle.TabIndex = 13
        Me.laFontStyle.Text = "Font Style"
        '
        'cbBracesColor
        '
        Me.cbBracesColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbBracesColor.Location = New System.Drawing.Point(344, 42)
        Me.cbBracesColor.Name = "cbBracesColor"
        Me.cbBracesColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbBracesColor.Size = New System.Drawing.Size(121, 21)
        Me.cbBracesColor.TabIndex = 16
        '
        'laBracesColor
        '
        Me.laBracesColor.AutoSize = True
        Me.laBracesColor.Location = New System.Drawing.Point(272, 45)
        Me.laBracesColor.Name = "laBracesColor"
        Me.laBracesColor.Size = New System.Drawing.Size(70, 16)
        Me.laBracesColor.TabIndex = 14
        Me.laBracesColor.Text = "Braces Color"
        '
        'chbHighlightBounds
        '
        Me.chbHighlightBounds.Location = New System.Drawing.Point(16, 40)
        Me.chbHighlightBounds.Name = "chbHighlightBounds"
        Me.chbHighlightBounds.Size = New System.Drawing.Size(112, 24)
        Me.chbHighlightBounds.TabIndex = 10
        Me.chbHighlightBounds.Text = "Highlight Bounds"
        '
        'chbTempHighlightBraces
        '
        Me.chbTempHighlightBraces.Location = New System.Drawing.Point(144, 16)
        Me.chbTempHighlightBraces.Name = "chbTempHighlightBraces"
        Me.chbTempHighlightBraces.Size = New System.Drawing.Size(112, 24)
        Me.chbTempHighlightBraces.TabIndex = 11
        Me.chbTempHighlightBraces.Text = "Temp Hightlight"
        '
        'chbHighlightBraces
        '
        Me.chbHighlightBraces.Checked = True
        Me.chbHighlightBraces.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbHighlightBraces.Location = New System.Drawing.Point(16, 16)
        Me.chbHighlightBraces.Name = "chbHighlightBraces"
        Me.chbHighlightBraces.Size = New System.Drawing.Size(112, 24)
        Me.chbHighlightBraces.TabIndex = 9
        Me.chbHighlightBraces.Text = "Highlight Braces"
        '
        'chbUseRoundRect
        '
        Me.chbUseRoundRect.Location = New System.Drawing.Point(144, 40)
        Me.chbUseRoundRect.Name = "chbUseRoundRect"
        Me.chbUseRoundRect.Size = New System.Drawing.Size(112, 24)
        Me.chbUseRoundRect.TabIndex = 12
        Me.chbUseRoundRect.Text = "Use Round Rect"
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
        Me.laDescription.Text = "This demo shows ways of highlighting matching braces within edit control's conten" & _
        "t."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.BorderColor = System.Drawing.Color.Empty
        Me.syntaxEdit1.Braces.BackColor = System.Drawing.Color.Yellow
        Me.syntaxEdit1.Braces.BracesOptions = QWhale.Editor.BracesOptions.Highlight
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 104)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Pages.Transparent = False
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 214)
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
        chbHighlightBraces.Checked = (BracesOptions.Highlight And syntaxEdit1.Braces.BracesOptions) <> 0
        chbUseRoundRect.Checked = syntaxEdit1.Braces.UseRoundRect
        chbTempHighlightBraces.Checked = (BracesOptions.TempHighlight And syntaxEdit1.Braces.BracesOptions) <> 0
        chbHighlightBounds.Checked = (BracesOptions.HighlightBounds And syntaxEdit1.Braces.BracesOptions) <> 0
        cbBracesColor.SelectedColor = syntaxEdit1.Braces.BackColor
        cbFontStyle.Items.Add(FontStyle.Regular)
        cbFontStyle.Items.Add(FontStyle.Bold)
        cbFontStyle.SelectedIndex = cbFontStyle.Items.IndexOf(syntaxEdit1.Braces.Style)
    End Sub

    Private Sub chbHighlightBraces_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHighlightBraces.CheckedChanged
        If chbHighlightBraces.Checked Then
            syntaxEdit1.Braces.BracesOptions = syntaxEdit1.Braces.BracesOptions Or BracesOptions.Highlight
        Else
            syntaxEdit1.Braces.BracesOptions = syntaxEdit1.Braces.BracesOptions Xor BracesOptions.Highlight
        End If
    End Sub

    Private Sub chbHighlightBounds_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHighlightBounds.CheckedChanged
        If chbHighlightBounds.Checked Then
            syntaxEdit1.Braces.BracesOptions = syntaxEdit1.Braces.BracesOptions Or BracesOptions.HighlightBounds
        Else
            syntaxEdit1.Braces.BracesOptions = syntaxEdit1.Braces.BracesOptions Xor BracesOptions.HighlightBounds
        End If
    End Sub

    Private Sub chbTempHighlightBraces_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTempHighlightBraces.CheckedChanged
        If chbTempHighlightBraces.Checked Then
            syntaxEdit1.Braces.BracesOptions = syntaxEdit1.Braces.BracesOptions Or BracesOptions.TempHighlight
        Else
            syntaxEdit1.Braces.BracesOptions = syntaxEdit1.Braces.BracesOptions Xor BracesOptions.TempHighlight
        End If
    End Sub

    Private Sub chbUseRoundRect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUseRoundRect.CheckedChanged
        syntaxEdit1.Braces.UseRoundRect = chbUseRoundRect.Checked
        If chbUseRoundRect.Checked Then
            syntaxEdit1.Braces.ForeColor = Color.Gray
        Else
            syntaxEdit1.Braces.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cbFontStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFontStyle.SelectedIndexChanged
        Dim obj As Object = System.Enum.Parse(GetType(FontStyle), cbFontStyle.Text)
        If ((Not obj Is Nothing) And (TypeOf obj Is FontStyle)) Then
            syntaxEdit1.Braces.Style = CType(obj, FontStyle)
        End If
    End Sub

    Private Sub cbBracesColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBracesColor.SelectedIndexChanged
        syntaxEdit1.Braces.BackColor = cbBracesColor.SelectedColor
    End Sub
End Class
