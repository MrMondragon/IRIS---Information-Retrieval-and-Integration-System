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
    Friend WithEvents gbOutlining As System.Windows.Forms.GroupBox
    Friend WithEvents cbAutomatic As System.Windows.Forms.ComboBox
    Friend WithEvents chbAllowOutlining As System.Windows.Forms.CheckBox
    Friend WithEvents chbDrawButtons As System.Windows.Forms.CheckBox
    Friend WithEvents chbDrawLines As System.Windows.Forms.CheckBox
    Friend WithEvents chbDrawOnGutter As System.Windows.Forms.CheckBox
    Friend WithEvents chbShowHints As System.Windows.Forms.CheckBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents textSource1 As QWhale.Editor.TextSource
    Friend WithEvents parser1 As QWhale.Syntax.Parser
    Friend WithEvents textSource2 As QWhale.Editor.TextSource
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.gbOutlining = New System.Windows.Forms.GroupBox
        Me.cbAutomatic = New System.Windows.Forms.ComboBox
        Me.chbAllowOutlining = New System.Windows.Forms.CheckBox
        Me.chbDrawButtons = New System.Windows.Forms.CheckBox
        Me.chbDrawLines = New System.Windows.Forms.CheckBox
        Me.chbDrawOnGutter = New System.Windows.Forms.CheckBox
        Me.chbShowHints = New System.Windows.Forms.CheckBox
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.textSource1 = New QWhale.Editor.TextSource(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.parser1 = New QWhale.Syntax.Parser
        Me.textSource2 = New QWhale.Editor.TextSource(Me.components)
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.pnSettings.SuspendLayout()
        Me.gbOutlining.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.gbOutlining)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 104)
        Me.pnSettings.TabIndex = 2
        '
        'gbOutlining
        '
        Me.gbOutlining.BackColor = System.Drawing.SystemColors.Control
        Me.gbOutlining.Controls.Add(Me.cbAutomatic)
        Me.gbOutlining.Controls.Add(Me.chbAllowOutlining)
        Me.gbOutlining.Controls.Add(Me.chbDrawButtons)
        Me.gbOutlining.Controls.Add(Me.chbDrawLines)
        Me.gbOutlining.Controls.Add(Me.chbDrawOnGutter)
        Me.gbOutlining.Controls.Add(Me.chbShowHints)
        Me.gbOutlining.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbOutlining.Location = New System.Drawing.Point(0, 28)
        Me.gbOutlining.Name = "gbOutlining"
        Me.gbOutlining.Size = New System.Drawing.Size(568, 76)
        Me.gbOutlining.TabIndex = 10
        Me.gbOutlining.TabStop = False
        Me.gbOutlining.Text = "Outlining"
        '
        'cbAutomatic
        '
        Me.cbAutomatic.Items.AddRange(New Object() {"Automatic", "Manual"})
        Me.cbAutomatic.Location = New System.Drawing.Point(8, 16)
        Me.cbAutomatic.Name = "cbAutomatic"
        Me.cbAutomatic.Size = New System.Drawing.Size(96, 21)
        Me.cbAutomatic.TabIndex = 0
        Me.cbAutomatic.Text = "Automatic"
        '
        'chbAllowOutlining
        '
        Me.chbAllowOutlining.BackColor = System.Drawing.SystemColors.Control
        Me.chbAllowOutlining.Location = New System.Drawing.Point(8, 40)
        Me.chbAllowOutlining.Name = "chbAllowOutlining"
        Me.chbAllowOutlining.TabIndex = 1
        Me.chbAllowOutlining.Text = "Allow Outlining"
        '
        'chbDrawButtons
        '
        Me.chbDrawButtons.BackColor = System.Drawing.SystemColors.Control
        Me.chbDrawButtons.Location = New System.Drawing.Point(240, 16)
        Me.chbDrawButtons.Name = "chbDrawButtons"
        Me.chbDrawButtons.TabIndex = 4
        Me.chbDrawButtons.Text = "Draw Buttons"
        '
        'chbDrawLines
        '
        Me.chbDrawLines.BackColor = System.Drawing.SystemColors.Control
        Me.chbDrawLines.Location = New System.Drawing.Point(128, 40)
        Me.chbDrawLines.Name = "chbDrawLines"
        Me.chbDrawLines.TabIndex = 3
        Me.chbDrawLines.Text = "Draw Lines"
        '
        'chbDrawOnGutter
        '
        Me.chbDrawOnGutter.BackColor = System.Drawing.SystemColors.Control
        Me.chbDrawOnGutter.Location = New System.Drawing.Point(128, 16)
        Me.chbDrawOnGutter.Name = "chbDrawOnGutter"
        Me.chbDrawOnGutter.TabIndex = 2
        Me.chbDrawOnGutter.Text = "Draw on Gutter"
        '
        'chbShowHints
        '
        Me.chbShowHints.BackColor = System.Drawing.SystemColors.Control
        Me.chbShowHints.Location = New System.Drawing.Point(240, 40)
        Me.chbShowHints.Name = "chbShowHints"
        Me.chbShowHints.TabIndex = 5
        Me.chbShowHints.Text = "Show Hints"
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(568, 28)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(568, 28)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo shows how to use automatic and manual outlining for text fragments with" & _
        "in edit conttrol's content."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textSource1
        '
        Me.textSource1.Lexer = Me.VbParser1
        Me.textSource1.Text = "Imports System" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class Person" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public age As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public name" & _
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
        ") 2004, 2005 Quantum Whale LLC.</Copyright>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileExtension />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <FileType />" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Version>1.1</Version>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>idents</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "      <ForeColor>ControlText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>0</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>numbers</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Green</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "   <Index>1</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>reswords</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   " & _
        "   <ForeColor>Blue</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>2</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style" & _
        ">" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>comments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Green</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index" & _
        ">3</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      " & _
        "<Name>xmlcomments</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Gray</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>4</Ind" & _
        "ex>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>symbols</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Gra" & _
        "y</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>5</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>wh" & _
        "itespace</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>WindowText</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>6</Index>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>strings</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Maroon" & _
        "</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>7</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <PlainText>true</PlainText>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </S" & _
        "tyle>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>directives</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Blue</ForeCo" & _
        "lor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>8</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    <Style>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Name>syntaxerror" & _
        "s</Name>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <ForeColor>Red</ForeColor>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      <Index>9</Index>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    </Style>" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  </Styles>" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  <States />" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "</LexScheme>"
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
        'textSource2
        '
        Me.textSource2.Lexer = Me.parser1
        Me.textSource2.Text = "[connect default]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & ";If we want to disable unknown connect values, we set Access t" & _
        "o NoAccess" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Access=NoAccess" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[sql default]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & ";If we want to disable unknown sql" & _
        " values, we set Sql to an invalid query." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Sql="" """ & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[connect CustomerDatabase]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Access=ReadWrite" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Connect=""DSN=AdvWorks""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[sql CustomerById]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Sql=""SELECT * F" & _
        "ROM Customers WHERE CustomerID = ?""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[connect AuthorDatabase]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Access=ReadOnly" & _
        "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Connect=""DSN=MyLibraryInfo;UID=MyUserID;PWD=MyPassword""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[userlist AuthorDat" & _
        "abase]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Administrator=ReadWrite" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "[sql AuthorById]" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Sql=""SELECT * FROM Authors " & _
        "WHERE au_id = ?"""
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 104)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Outlining.AllowOutlining = True
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 214)
        Me.syntaxEdit1.Source = Me.textSource1
        Me.syntaxEdit1.TabIndex = 3
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
        Me.gbOutlining.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private timer As timer = Nothing

    Private Sub DoTimer(ByVal sender As Object, ByVal e As System.EventArgs)
        DoCustomOutlining()
        timer.Stop()
    End Sub

    Private Function PrevPosition(ByVal position As Point) As Point
        Dim pos As Point = position
        If (pos.Y > 0) Then
            pos.Y = pos.Y - 1
            pos.X = Math.Max(0, syntaxEdit1.Strings(pos.Y).Length - 1)
        Else
            pos.Y = pos.Y - 1
        End If
        Return pos
    End Function

    Private Sub DoCustomOutlining()
        Dim oldPos As Point = syntaxEdit1.Position
        CType(syntaxEdit1.Source, INotify).BeginUpdate()
        Try
            If (syntaxEdit1.Find("\[.*\]", SearchOptions.EntireScope Or SearchOptions.RegularExpressions, New System.Text.RegularExpressions.Regex("\[.*\]", System.Text.RegularExpressions.RegexOptions.Singleline))) Then
                Dim ranges As ArrayList = New ArrayList
                Dim start As Point = syntaxEdit1.Position
                While (syntaxEdit1.FindNext())
                    ranges.Add(New OutlineRange(start, PrevPosition(syntaxEdit1.Position), 0, "..."))
                    start = syntaxEdit1.Position
                End While
                ranges.Add(New OutlineRange(start, New Point(syntaxEdit1.Lines(syntaxEdit1.Lines.Count - 1).Length, syntaxEdit1.Lines.Count - 1), 0, "..."))
                syntaxEdit1.Outlining.SetOutlineRanges(ranges)
            End If
            syntaxEdit1.Selection.Clear()
        Finally
            syntaxEdit1.MoveTo(oldPos)
            syntaxEdit1.Source.EndUpdate()
        End Try
    End Sub

    Private Sub UpdateOutlining(ByVal automatic As Boolean)
        If automatic Then
            syntaxEdit1.Source = textSource1
        Else
            syntaxEdit1.Source = textSource2
            DoCustomOutlining()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timer = New Timer
        timer.Interval = 500
        AddHandler timer.Tick, AddressOf DoTimer
        chbAllowOutlining.Checked = syntaxEdit1.Outlining.AllowOutlining
        chbDrawOnGutter.Checked = (OutlineOptions.DrawOnGutter And syntaxEdit1.Outlining.OutlineOptions) <> 0
        chbDrawLines.Checked = (OutlineOptions.DrawLines And syntaxEdit1.Outlining.OutlineOptions) <> 0
        chbDrawButtons.Checked = (OutlineOptions.DrawButtons And syntaxEdit1.Outlining.OutlineOptions) <> 0
        chbShowHints.Checked = (OutlineOptions.ShowHints And syntaxEdit1.Outlining.OutlineOptions) <> 0
    End Sub

    Private Sub cbAutomatic_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAutomatic.SelectedIndexChanged
        UpdateOutlining(cbAutomatic.SelectedIndex = 0)
    End Sub

    Private Sub syntaxEdit1_SourceStateChanged(ByVal sender As Object, ByVal e As QWhale.Editor.NotifyEventArgs) Handles syntaxEdit1.SourceStateChanged
        If (CType(syntaxEdit1.Source, Object).Equals(textSource2)) Then
            If ((e.State And NotifyState.Edit) <> 0) Then
                timer.Start()
            End If
        End If
    End Sub

    Private Sub chbAllowOutlining_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAllowOutlining.CheckedChanged
        syntaxEdit1.Outlining.AllowOutlining = chbAllowOutlining.Checked
        If ((chbAllowOutlining.Checked) And (cbAutomatic.SelectedIndex <> 0)) Then
            DoCustomOutlining()
        End If
    End Sub

    Private Sub chbDrawOnGutter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDrawOnGutter.CheckedChanged
        If chbDrawOnGutter.Checked Then
            syntaxEdit1.Outlining.OutlineOptions = syntaxEdit1.Outlining.OutlineOptions Or OutlineOptions.DrawOnGutter
        Else
            syntaxEdit1.Outlining.OutlineOptions = syntaxEdit1.Outlining.OutlineOptions Xor OutlineOptions.DrawOnGutter
        End If
    End Sub

    Private Sub chbDrawLines_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDrawLines.CheckedChanged
        If chbDrawLines.Checked Then
            syntaxEdit1.Outlining.OutlineOptions = syntaxEdit1.Outlining.OutlineOptions Or OutlineOptions.DrawLines
        Else
            syntaxEdit1.Outlining.OutlineOptions = syntaxEdit1.Outlining.OutlineOptions Xor OutlineOptions.DrawLines
        End If
    End Sub

    Private Sub chbDrawButtons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDrawButtons.CheckedChanged
        If chbDrawButtons.Checked Then
            syntaxEdit1.Outlining.OutlineOptions = syntaxEdit1.Outlining.OutlineOptions Or OutlineOptions.DrawButtons
        Else
            syntaxEdit1.Outlining.OutlineOptions = syntaxEdit1.Outlining.OutlineOptions Xor OutlineOptions.DrawButtons
        End If
    End Sub

    Private Sub chbShowHints_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowHints.CheckedChanged
        If chbShowHints.Checked Then
            syntaxEdit1.Outlining.OutlineOptions = syntaxEdit1.Outlining.OutlineOptions Or OutlineOptions.ShowHints
        Else
            syntaxEdit1.Outlining.OutlineOptions = syntaxEdit1.Outlining.OutlineOptions Xor OutlineOptions.ShowHints
        End If
    End Sub
End Class
