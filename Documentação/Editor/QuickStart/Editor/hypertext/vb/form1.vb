Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections
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
    Friend WithEvents laFontStyle As System.Windows.Forms.Label
    Friend WithEvents cbFontStyle As System.Windows.Forms.ComboBox
    Friend WithEvents chbCustomHypertext As System.Windows.Forms.CheckBox
    Friend WithEvents laUrlColor As System.Windows.Forms.Label
    Friend WithEvents cbUrlColor As QWhale.Common.ColorBox
    Friend WithEvents chbHighlightUrls As System.Windows.Forms.CheckBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents parser1 As QWhale.Syntax.Parser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.laFontStyle = New System.Windows.Forms.Label
        Me.cbFontStyle = New System.Windows.Forms.ComboBox
        Me.chbCustomHypertext = New System.Windows.Forms.CheckBox
        Me.laUrlColor = New System.Windows.Forms.Label
        Me.cbUrlColor = New QWhale.Common.ColorBox(Me.components)
        Me.chbHighlightUrls = New System.Windows.Forms.CheckBox
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.parser1 = New QWhale.Syntax.Parser
        Me.pnSettings.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.laFontStyle)
        Me.pnSettings.Controls.Add(Me.cbFontStyle)
        Me.pnSettings.Controls.Add(Me.chbCustomHypertext)
        Me.pnSettings.Controls.Add(Me.laUrlColor)
        Me.pnSettings.Controls.Add(Me.cbUrlColor)
        Me.pnSettings.Controls.Add(Me.chbHighlightUrls)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 104)
        Me.pnSettings.TabIndex = 2
        '
        'laFontStyle
        '
        Me.laFontStyle.AutoSize = True
        Me.laFontStyle.Location = New System.Drawing.Point(128, 69)
        Me.laFontStyle.Name = "laFontStyle"
        Me.laFontStyle.Size = New System.Drawing.Size(55, 16)
        Me.laFontStyle.TabIndex = 3
        Me.laFontStyle.Text = "Font Style"
        '
        'cbFontStyle
        '
        Me.cbFontStyle.Location = New System.Drawing.Point(192, 66)
        Me.cbFontStyle.Name = "cbFontStyle"
        Me.cbFontStyle.Size = New System.Drawing.Size(121, 21)
        Me.cbFontStyle.TabIndex = 5
        Me.cbFontStyle.Text = "Regular"
        '
        'chbCustomHypertext
        '
        Me.chbCustomHypertext.Location = New System.Drawing.Point(8, 64)
        Me.chbCustomHypertext.Name = "chbCustomHypertext"
        Me.chbCustomHypertext.Size = New System.Drawing.Size(120, 24)
        Me.chbCustomHypertext.TabIndex = 1
        Me.chbCustomHypertext.Text = "Custom Hypertext"
        '
        'laUrlColor
        '
        Me.laUrlColor.AutoSize = True
        Me.laUrlColor.Location = New System.Drawing.Point(128, 45)
        Me.laUrlColor.Name = "laUrlColor"
        Me.laUrlColor.Size = New System.Drawing.Size(49, 16)
        Me.laUrlColor.TabIndex = 2
        Me.laUrlColor.Text = "Url Color"
        '
        'cbUrlColor
        '
        Me.cbUrlColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbUrlColor.Location = New System.Drawing.Point(192, 42)
        Me.cbUrlColor.Name = "cbUrlColor"
        Me.cbUrlColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbUrlColor.Size = New System.Drawing.Size(121, 21)
        Me.cbUrlColor.TabIndex = 4
        '
        'chbHighlightUrls
        '
        Me.chbHighlightUrls.Checked = True
        Me.chbHighlightUrls.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbHighlightUrls.Location = New System.Drawing.Point(8, 40)
        Me.chbHighlightUrls.Name = "chbHighlightUrls"
        Me.chbHighlightUrls.Size = New System.Drawing.Size(96, 24)
        Me.chbHighlightUrls.TabIndex = 0
        Me.chbHighlightUrls.Text = "Highlight Urls"
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
        Me.laDescription.Text = "This demo shows how to handle hypertext sections inside the Edit control's conten" & _
        "t."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.HyperText.HighlightUrls = True
        Me.syntaxEdit1.Lexer = Me.parser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 104)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 214)
        Me.syntaxEdit1.TabIndex = 3
        Me.syntaxEdit1.Text = "[Common]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Url=""http://www.qwhale.net""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "MailTo=""mailto:contact@qwhale.net""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[Conte" & _
        "nts.Server]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "00000001=0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "00000002=0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[Server.00000001]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Title=FTP Server" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Protoc" & _
        "ol=TCP" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Port=21" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "InternalPort=21" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "BuiltIn=1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[Server.00000002]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Title=Telnet Ser" & _
        "ver" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Protocol=TCP" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Port=23" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "InternalPort=23" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "BuiltIn=1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[Server.00000003]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Title" & _
        "=Internet Mail Server (SMTP)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Protocol=TCP" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Port=25" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "InternalPort=25" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "BuiltIn=1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[Server.00000004]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Title=Post-Office Protocol Version 3 (POP3)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Protocol=TCP" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "P" & _
        "ort=110" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "InternalPort=110" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "BuiltIn=1"
        '
        'parser1
        '
        Me.parser1.DefaultState = 0
        Me.parser1.XmlScheme = "<?xml version=""1.0"" encoding=""utf-16""?>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "<LexScheme xmlns:xsd=""http://www.w3.org/" & _
        "2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Autho" & _
        "r>Quantum Whale</Author>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Name>Ini files</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Desc>Syntax Scheme for In" & _
        "i files</Desc>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Copyright>Copyright Quantum Whale, 2003</Copyright>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileE" & _
        "xtension>.ini</FileExtension>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileType>ini</FileType>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Version>1.1</Versi" & _
        "on>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>idents</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Contro" & _
        "lText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Nam" & _
        "e>comments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Gray</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <FontStyle>Bold</Fon" & _
        "tStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>1</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>whitespace</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>WindowText</ForeC" & _
        "olor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>2</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>strings</N" & _
        "ame>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Maroon</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>3</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <States>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <State>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>normal</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <CaseSen" & _
        "sitive>false</CaseSensitive>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <SyntaxBlocks>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     " & _
        "     <Name>comments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LexStyle>1</LexStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveSt" & _
        "ate>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>\;.*</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        </SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "      <SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>idents</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LexStyle>0</LexSt" & _
        "yle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveState>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "           " & _
        " <string>[a-zA-Z_][a-zA-Z0-9_]*</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <I" & _
        "ndex>1</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        </SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>s" & _
        "trings</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LexStyle>3</LexStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveState>0</LeaveS" & _
        "tate>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>(\[\])|\[(([^\]]*\])|([^\]]*" & _
        "))</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>("""")|""(([^""]*"")|([^""]*))</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </" & _
        "Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index>2</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        </SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <Synta" & _
        "xBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>whitespace</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LexStyle>2</LexStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "        <LeaveState>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string" & _
        ">(\s)+</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index>3</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <" & _
        "/SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      </SyntaxBlocks>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </State>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </" & _
        "States>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "</LexScheme>"
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
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbHighlightUrls.Checked = syntaxEdit1.HyperText.HighlightUrls
        cbUrlColor.SelectedColor = syntaxEdit1.HyperText.UrlColor
        Dim s As String() = [Enum].GetNames(GetType(FontStyle))
        cbFontStyle.Items.AddRange(s)
        cbFontStyle.SelectedItem = syntaxEdit1.HyperText.UrlStyle.ToString()
    End Sub

    Private Sub chbHighlightUrls_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHighlightUrls.CheckedChanged
        syntaxEdit1.HyperText.HighlightUrls = chbHighlightUrls.Checked
    End Sub

    Private Sub chbCustomHypertext_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCustomHypertext.CheckedChanged
        Dim hs As Hashtable = CType(syntaxEdit1.Source, TextSource).UrlTable
        If (chbCustomHypertext.Checked) Then
            hs.Add("["c, True)
            hs.Add("]"c, False)
        Else
            hs.Remove("["c)
            hs.Remove("]"c)
        End If
        syntaxEdit1.Source.Notification(syntaxEdit1.Lexer, EventArgs.Empty)
    End Sub

    Private Sub cbUrlColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbUrlColor.SelectedIndexChanged
        syntaxEdit1.HyperText.UrlColor = cbUrlColor.SelectedColor
    End Sub

    Private Sub cbFontStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFontStyle.SelectedIndexChanged
        Dim obj As Object = System.Enum.Parse(GetType(FontStyle), cbFontStyle.Text)
        If ((Not obj Is Nothing) And (TypeOf obj Is FontStyle)) Then
            syntaxEdit1.HyperText.UrlStyle = CType(obj, FontStyle)
        End If
    End Sub

    Private Sub syntaxEdit1_CheckHyperText(ByVal sender As Object, ByVal e As QWhale.Editor.HyperTextEventArgs) Handles syntaxEdit1.CheckHyperText
        If (chbCustomHypertext.Checked) Then
            e.IsHyperText = e.Text.IndexOf("[") >= 0
        End If
    End Sub

    Private Sub syntaxEdit1_JumpToUrl(ByVal sender As Object, ByVal e As QWhale.Editor.UrlJumpEventArgs) Handles syntaxEdit1.JumpToUrl
        If chbCustomHypertext.Checked Then
            MessageBox.Show(e.Text)
            e.Handled = True
        End If
    End Sub
End Class
