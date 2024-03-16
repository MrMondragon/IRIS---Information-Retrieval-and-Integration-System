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
    Friend WithEvents textSource1 As QWhale.Editor.TextSource
    Friend WithEvents textSource2 As QWhale.Editor.TextSource
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMethodBody As System.Windows.Forms.RadioButton
    Friend WithEvents rbClassBody As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.rbMethodBody = New System.Windows.Forms.RadioButton
        Me.rbClassBody = New System.Windows.Forms.RadioButton
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.SyntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.textSource1 = New QWhale.Editor.TextSource(Me.components)
        Me.textSource2 = New QWhale.Editor.TextSource(Me.components)
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
        Me.pnSettings.Size = New System.Drawing.Size(640, 112)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.rbMethodBody)
        Me.groupBox1.Controls.Add(Me.rbClassBody)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 40)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(640, 72)
        Me.groupBox1.TabIndex = 11
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Parser type"
        '
        'rbMethodBody
        '
        Me.rbMethodBody.Location = New System.Drawing.Point(16, 40)
        Me.rbMethodBody.Name = "rbMethodBody"
        Me.rbMethodBody.TabIndex = 1
        Me.rbMethodBody.Text = "Method body"
        '
        'rbClassBody
        '
        Me.rbClassBody.Checked = True
        Me.rbClassBody.Location = New System.Drawing.Point(16, 16)
        Me.rbClassBody.Name = "rbClassBody"
        Me.rbClassBody.TabIndex = 0
        Me.rbClassBody.TabStop = True
        Me.rbClassBody.Text = "Class body"
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(640, 40)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(640, 40)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "The demo project shows how to use simple parsers."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SyntaxEdit1
        '
        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SyntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SyntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.SyntaxEdit1.Location = New System.Drawing.Point(0, 112)
        Me.SyntaxEdit1.Name = "SyntaxEdit1"
        Me.SyntaxEdit1.Pages.RulerBackColor = System.Drawing.Color.LightSteelBlue
        Me.SyntaxEdit1.Pages.RulerIndentBackColor = System.Drawing.Color.SteelBlue
        Me.SyntaxEdit1.Size = New System.Drawing.Size(640, 342)
        Me.SyntaxEdit1.Source = Me.textSource1
        Me.SyntaxEdit1.TabIndex = 3
        '
        'textSource1
        '
        Me.textSource1.Text = "Private classParser As VbClassBodyParser" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Private methodParser As VbMethodBodyPar" & _
        "ser" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Private Sub UpdateSource()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    If (rbClassBody.Checked) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Sy" & _
        "ntaxEdit1.Source = textSource1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        SyntaxEdit1.Lexer = classParser" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Els" & _
        "e" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        SyntaxEdit1.Source = textSource2" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        SyntaxEdit1.Lexer = methodP" & _
        "arser" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Private Sub Form1_Load(ByVal sender As System.Obje" & _
        "ct, ByVal e As System.EventArgs) Handles MyBase.Load" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    classParser = New VbCl" & _
        "assBodyParser" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    methodParser = New VbMethodBodyParser" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    UpdateSource()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "En" & _
        "d Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Private Sub rbClassBody_CheckedChanged(ByVal sender As Object, ByVal e " & _
        "As System.EventArgs) Handles rbClassBody.CheckedChanged" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    UpdateSource()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End" & _
        " Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Private Sub rbMethodBody_CheckedChanged(ByVal sender As Object, ByVal e " & _
        "As System.EventArgs) Handles rbMethodBody.CheckedChanged" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    UpdateSource()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "En" & _
        "d Sub"
        '
        'textSource2
        '
        Me.textSource2.Text = "If (rbClassBody.Checked) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    SyntaxEdit1.Source = textSource1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    SyntaxEd" & _
        "it1.Lexer = classParser" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Else" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    SyntaxEdit1.Source = textSource2" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    SyntaxE" & _
        "dit1.Lexer = methodParser" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End If"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(640, 454)
        Me.Controls.Add(Me.SyntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private classParser As VbClassBodyParser
    Private methodParser As VbMethodBodyParser

    Private Sub UpdateSource()
        If (rbClassBody.Checked) Then
            SyntaxEdit1.Source = textSource1
            SyntaxEdit1.Lexer = classParser
        Else
            SyntaxEdit1.Source = textSource2
            SyntaxEdit1.Lexer = methodParser
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        classParser = New VbClassBodyParser
        methodParser = New VbMethodBodyParser
        UpdateSource()
    End Sub

    Private Sub rbClassBody_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbClassBody.CheckedChanged
        UpdateSource()
    End Sub

    Private Sub rbMethodBody_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbMethodBody.CheckedChanged
        UpdateSource()
    End Sub
End Class
