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
    Friend WithEvents laSourceState As System.Windows.Forms.Label
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents parser1 As QWhale.Syntax.Parser
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents miEdit As System.Windows.Forms.MenuItem
    Friend WithEvents miMoveCaret As System.Windows.Forms.MenuItem
    Friend WithEvents miSetBookmark As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents miUndo As System.Windows.Forms.MenuItem
    Friend WithEvents miRedo As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents miInsertLine As System.Windows.Forms.MenuItem
    Friend WithEvents miDeleteLine As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents miSave As System.Windows.Forms.MenuItem
    Friend WithEvents statusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents sbpPosition As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpModified As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpOverwrite As System.Windows.Forms.StatusBarPanel
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbSourceStates As System.Windows.Forms.TextBox
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.laSourceState = New System.Windows.Forms.Label
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.parser1 = New QWhale.Syntax.Parser
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.miEdit = New System.Windows.Forms.MenuItem
        Me.miMoveCaret = New System.Windows.Forms.MenuItem
        Me.miSetBookmark = New System.Windows.Forms.MenuItem
        Me.menuItem1 = New System.Windows.Forms.MenuItem
        Me.miUndo = New System.Windows.Forms.MenuItem
        Me.miRedo = New System.Windows.Forms.MenuItem
        Me.menuItem2 = New System.Windows.Forms.MenuItem
        Me.miInsertLine = New System.Windows.Forms.MenuItem
        Me.miDeleteLine = New System.Windows.Forms.MenuItem
        Me.menuItem3 = New System.Windows.Forms.MenuItem
        Me.miSave = New System.Windows.Forms.MenuItem
        Me.statusBar1 = New System.Windows.Forms.StatusBar
        Me.sbpPosition = New System.Windows.Forms.StatusBarPanel
        Me.sbpModified = New System.Windows.Forms.StatusBarPanel
        Me.sbpOverwrite = New System.Windows.Forms.StatusBarPanel
        Me.panel1 = New System.Windows.Forms.Panel
        Me.tbSourceStates = New System.Windows.Forms.TextBox
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.pnSettings.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        CType(Me.sbpPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpModified, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpOverwrite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.laSourceState)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 48)
        Me.pnSettings.TabIndex = 2
        '
        'laSourceState
        '
        Me.laSourceState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laSourceState.AutoSize = True
        Me.laSourceState.Location = New System.Drawing.Point(368, 26)
        Me.laSourceState.Name = "laSourceState"
        Me.laSourceState.Size = New System.Drawing.Size(75, 16)
        Me.laSourceState.TabIndex = 15
        Me.laSourceState.Text = "Source States"
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
        Me.laDescription.Text = "This demo shows how to respond notification when edit control's content is change" & _
        "d."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'parser1
        '
        Me.parser1.DefaultState = 0
        Me.parser1.XmlScheme = "<?xml version=""1.0"" encoding=""utf-16""?>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "<LexScheme xmlns:xsd=""http://www.w3.org/" & _
        "2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Autho" & _
        "r>Quantum Whale</Author>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Name>Visual_Basic.Net</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Desc>Syntax Scheme" & _
        " for VB.Net Language</Desc>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Copyright>Copyright Quantum Whale, 2003</Copyrig" & _
        "ht>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileExtension />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileType />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Version>1.0</Version>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>idents</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>ControlText</ForeColor>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>numbers</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>ControlText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>1</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>reswords</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Blue</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "    <Index>2</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>comments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "    <ForeColor>Silver</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <FontStyle>Italic</FontStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <I" & _
        "ndex>3</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "    <Name>whitespace</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>WindowText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Ind" & _
        "ex>4</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>strings</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Fore" & _
        "Color>Maroon</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>5</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "   <Name>directives</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Blue</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>6</I" & _
        "ndex>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <States>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <State>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>normal</N" & _
        "ame>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <CaseSensitive>false</CaseSensitive>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <SyntaxBlocks>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        " & _
        "<SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>directive</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LexStyle>6</LexStyle" & _
        ">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveState>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <ResWordSets>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <R" & _
        "esWordSet>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              <Name>ResWord Set0</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              <Index>0</Ind" & _
        "ex>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              <ResWordStyle>6</ResWordStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              <ResWords>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "             <word>#Region</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>#End Region</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "             <word>#ElseIf</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>#End If/String</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "                <word>#If</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>#Else</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        "      <word>#error</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>#Const</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                " & _
        "<word>#ExternalSource</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              </ResWords>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            </ResWordSe" & _
        "t>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </ResWordSets>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>\#.*<" & _
        "/string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        </Syntax" & _
        "Block>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>comment1</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LexSt" & _
        "yle>3</LexStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveState>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>\'.*</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>rem[\u0000-\u0020].*</st" & _
        "ring>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index>1</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        </SyntaxBlo" & _
        "ck>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>idents</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LexStyle>0" & _
        "</LexStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveState>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <ResWordSets>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    " & _
        "        <ResWordSet>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              <Name />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "            <ResWordStyle>2</ResWordStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              <ResWords>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        "      <word>try</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>catch</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <wor" & _
        "d>finally</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>when</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>inher" & _
        "its</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>overloads</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>readon" & _
        "ly</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>writeonly</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>default" & _
        "</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>notinheritable</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>must" & _
        "inherit</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>implements</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>m" & _
        "yclass</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>mybase</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>protec" & _
        "ted</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>friend</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>public</w" & _
        "ord>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>private</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>shared</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>overrides</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>overridable</word" & _
        ">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>namespace</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>string</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "                <word>unlock</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>do</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        "      <word>else</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>withevents</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              " & _
        "  <word>filecopy</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>explicit</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                " & _
        "<word>width</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>rmdir</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>wh" & _
        "ile</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>return</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>true</wor" & _
        "d>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>date</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>end</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       " & _
        "         <word>setattr</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>load</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              " & _
        "  <word>optional</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>loop</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <wor" & _
        "d>name</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>appactivate</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>m" & _
        "od</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>sendkeys</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>stop</wo" & _
        "rd>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>put</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>next</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      " & _
        "          <word>select</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>deftype</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "           " & _
        "     <word>then</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>chdrive</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <w" & _
        "ord>is</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>get</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>sub</word" & _
        ">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>type</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>mid</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        " & _
        "        <word>byref</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>enum</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <" & _
        "word>write</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>set</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>if</w" & _
        "ord>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>structure</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>delegate</wo" & _
        "rd>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>as</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>compare</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    " & _
        "            <word>static</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>rset</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            " & _
        "    <word>empty</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>raiseevent</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "               " & _
        " <word>input</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>const</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>s" & _
        "avepicture</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>case</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>eqv<" & _
        "/word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>binary</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>seek</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "                <word>lset</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>step</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        "      <word>gosub</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>resume</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <" & _
        "word>goto</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>imp</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>chdir<" & _
        "/word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>exit</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>dim</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "             <word>error</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>lock</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            " & _
        "    <word>base</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>savesetting</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "               " & _
        " <word>like</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>xor</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>to</" & _
        "word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>redim</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>beep</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "              <word>time</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>property</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        " & _
        "        <word>len</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>call</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <wo" & _
        "rd>randomize</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>wend</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>pr" & _
        "int</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>not</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>unload</word" & _
        ">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>addhandler</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>alias</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "                <word>andalso</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>ansi</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       " & _
        "         <word>assembly</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>auto</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "             " & _
        "   <word>boolean</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>byte</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <wor" & _
        "d>cbool</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>cbyte</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>cchar<" & _
        "/word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>cdate</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>cdec</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "               <word>cdbl</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>char</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "           " & _
        "     <word>cint</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>clng</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word" & _
        ">cobj</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>cshort</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>csng</w" & _
        "ord>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>cstr</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>ctype</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "             <word>decimal</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>directcast</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    " & _
        "            <word>double</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>elseif</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        "      <word>gettype</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>handles</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              " & _
        "  <word>in</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>integer</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>i" & _
        "nterface</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>lib</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>long</w" & _
        "ord>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>module</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>mustoverride</w" & _
        "ord>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>notoverridable</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>object<" & _
        "/word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>orelse</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>preserve</wor" & _
        "d>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>removehandler</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>shadows</w" & _
        "ord>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>short</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>single</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "               <word>synclock</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>throw</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      " & _
        "          <word>typeof</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>unicode</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "           " & _
        "     <word>until</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>variant</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <" & _
        "word>addressof</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>class</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word" & _
        ">imports</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>strict</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>line" & _
        "</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>friend</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>mkdir</word>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>nothing</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>new</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      " & _
        "          <word>with</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>close</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "               " & _
        " <word>event</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>deletesetting</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "               " & _
        " <word>me</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>declare</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>re" & _
        "set</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>off</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>on</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "               <word>paramarray</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>function</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " " & _
        "               <word>false</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>null</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        "      <word>for</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>let</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>" & _
        "open</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>kill</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>and</word>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>option</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>byval</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     " & _
        "           <word>or</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <word>each</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "                <" & _
        "word>erase</word>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "              </ResWords>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            </ResWordSet>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       " & _
        "   </ResWordSets>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>[a-zA-Z_][a-zA-Z" & _
        "0-9_]*</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index>2</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <" & _
        "/SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>numbers</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          " & _
        "<LexStyle>1</LexStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveState>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Express" & _
        "ions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>([0-9]+\.[0-9]*(e|E)(\+|\-)?[0-9]+)|([0-9]+\.[0-9]*)|" & _
        "([0-9]+)</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index>3</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "       " & _
        " </SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>string</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         " & _
        " <LexStyle>5</LexStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveState>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expres" & _
        "sions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>("""")|""((((\\"")|("""")|[^""])*"")|(((\\"")|("""")|[^""])*))</" & _
        "string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index>4</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        </SyntaxB" & _
        "lock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        <SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Name>whitespace</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LexS" & _
        "tyle>4</LexStyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <LeaveState>0</LeaveState>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Expressions>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            <string>(\s)*</string>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          </Expressions>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          <Index" & _
        ">5</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        </SyntaxBlock>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      </SyntaxBlocks>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>0</Index" & _
        ">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </State>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </States>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "</LexScheme>"
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miEdit})
        '
        'miEdit
        '
        Me.miEdit.Index = 0
        Me.miEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miMoveCaret, Me.miSetBookmark, Me.menuItem1, Me.miUndo, Me.miRedo, Me.menuItem2, Me.miInsertLine, Me.miDeleteLine, Me.menuItem3, Me.miSave})
        Me.miEdit.Text = "Edit"
        '
        'miMoveCaret
        '
        Me.miMoveCaret.Index = 0
        Me.miMoveCaret.Text = "Move Caret"
        '
        'miSetBookmark
        '
        Me.miSetBookmark.Index = 1
        Me.miSetBookmark.Text = "Set Bookmark"
        '
        'menuItem1
        '
        Me.menuItem1.Index = 2
        Me.menuItem1.Text = "-"
        '
        'miUndo
        '
        Me.miUndo.Index = 3
        Me.miUndo.Text = "Undo"
        '
        'miRedo
        '
        Me.miRedo.Index = 4
        Me.miRedo.Text = "Redo"
        '
        'menuItem2
        '
        Me.menuItem2.Index = 5
        Me.menuItem2.Text = "-"
        '
        'miInsertLine
        '
        Me.miInsertLine.Index = 6
        Me.miInsertLine.Text = "Insert Line"
        '
        'miDeleteLine
        '
        Me.miDeleteLine.Index = 7
        Me.miDeleteLine.Text = "Delete Line"
        '
        'menuItem3
        '
        Me.menuItem3.Index = 8
        Me.menuItem3.Text = "-"
        '
        'miSave
        '
        Me.miSave.Index = 9
        Me.miSave.Text = "Save"
        '
        'statusBar1
        '
        Me.statusBar1.Location = New System.Drawing.Point(0, 296)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpPosition, Me.sbpModified, Me.sbpOverwrite})
        Me.statusBar1.ShowPanels = True
        Me.statusBar1.Size = New System.Drawing.Size(568, 22)
        Me.statusBar1.TabIndex = 18
        '
        'sbpOverwrite
        '
        Me.sbpOverwrite.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpOverwrite.Width = 352
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.tbSourceStates)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.panel1.Location = New System.Drawing.Point(360, 48)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(208, 248)
        Me.panel1.TabIndex = 19
        '
        'tbSourceStates
        '
        Me.tbSourceStates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbSourceStates.Enabled = False
        Me.tbSourceStates.Location = New System.Drawing.Point(0, 0)
        Me.tbSourceStates.Multiline = True
        Me.tbSourceStates.Name = "tbSourceStates"
        Me.tbSourceStates.Size = New System.Drawing.Size(208, 248)
        Me.tbSourceStates.TabIndex = 14
        Me.tbSourceStates.Text = "None"
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.parser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 48)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(360, 248)
        Me.syntaxEdit1.TabIndex = 20
        Me.syntaxEdit1.Text = "Imports System" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class Person" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public age As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public name" & _
        " As String" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class MainClass" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public Sub New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " Dim p " & _
        "As Person = New Person" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Console.Write(""Name: {0}, Age: {1}"", p.name, p.a" & _
        "ge)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 318)
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.statusBar1)
        Me.Controls.Add(Me.pnSettings)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        CType(Me.sbpPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpModified, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpOverwrite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub DoSourceStateChanged(ByVal sender As Object, ByVal e As NotifyEventArgs)
        UpdateTextBox(e.State)
    End Sub

    Private Sub UpdateTextBox(ByVal state As NotifyState)
        Dim s As String = String.Empty
        For Each i As Integer In [Enum].GetValues(GetType(NotifyState))
            If ((CType(i, NotifyState) And state) <> 0) Then
                If s = String.Empty Then
                    s = String.Format("{0}", CType(i, NotifyState))
                Else
                    s = s + String.Format(",{0}", CType(i, NotifyState))
                End If
            End If
        Next i
        tbSourceStates.Lines = s.Split(","c)
    End Sub

    Public Sub UpdateStatusBar()
        sbpPosition.Text = String.Format("Line: {0}, Char: {1}", syntaxEdit1.Source.Position.Y, syntaxEdit1.Source.Position.X)
        If (syntaxEdit1.Source.Readonly) Then
            sbpModified.Text = "ReadOnly"
        ElseIf (syntaxEdit1.Source.Modified) Then
            sbpModified.Text = "Modified"
        Else
            sbpModified.Text = String.Empty
        End If
        If (syntaxEdit1.Source.OverWrite) Then
            sbpOverwrite.Text = "Overwrite"
        Else
            sbpOverwrite.Text = String.Empty
        End If
    End Sub


    Private Sub miMoveCaret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMoveCaret.Click
        syntaxEdit1.MoveCharRight()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler syntaxEdit1.SourceStateChanged, AddressOf DoSourceStateChanged
    End Sub

    Private Sub miSetBookmark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSetBookmark.Click
        syntaxEdit1.Source.BookMarks.SetBookMark(syntaxEdit1.Position, 11)
    End Sub

    Private Sub miUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miUndo.Click
        syntaxEdit1.Source.Undo()
    End Sub

    Private Sub miRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRedo.Click
        syntaxEdit1.Source.Redo()
    End Sub

    Private Sub miInsertLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miInsertLine.Click
        CType(syntaxEdit1.Source, INotify).BeginUpdate()
        Try
            syntaxEdit1.MoveTo(Integer.MaxValue, syntaxEdit1.Position.Y)
            syntaxEdit1.Source.NewLine()

        Finally
            syntaxEdit1.Source.EndUpdate()
        End Try
    End Sub

    Private Sub miDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDeleteLine.Click
        CType(syntaxEdit1.Source, INotify).BeginUpdate()
        Try
            syntaxEdit1.MoveTo(0, syntaxEdit1.Position.Y)
            syntaxEdit1.Source.DeleteRight(Integer.MaxValue)
            syntaxEdit1.Source.UnBreakLine()
        Finally
            syntaxEdit1.Source.EndUpdate()
        End Try

    End Sub

    Private Sub miSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSave.Click
        syntaxEdit1.Modified = False
    End Sub

    Private Sub miEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEdit.Popup
        miUndo.Enabled = syntaxEdit1.Source.CanUndo()
        miRedo.Enabled = syntaxEdit1.Source.CanRedo()
    End Sub

    Private Sub syntaxEdit1_SourceStateChanged(ByVal sender As Object, ByVal e As QWhale.Editor.NotifyEventArgs) Handles syntaxEdit1.SourceStateChanged
        UpdateStatusBar()
    End Sub
End Class
