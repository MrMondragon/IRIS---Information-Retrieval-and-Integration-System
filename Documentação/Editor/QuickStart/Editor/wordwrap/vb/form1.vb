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
    Friend WithEvents chbWordWrap As System.Windows.Forms.CheckBox
    Friend WithEvents chbWrapAtMargin As System.Windows.Forms.CheckBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.chbWordWrap = New System.Windows.Forms.CheckBox
        Me.chbWrapAtMargin = New System.Windows.Forms.CheckBox
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
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
        Me.pnSettings.Size = New System.Drawing.Size(568, 96)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.chbWordWrap)
        Me.groupBox1.Controls.Add(Me.chbWrapAtMargin)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 72)
        Me.groupBox1.TabIndex = 11
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Word Wrap"
        '
        'chbWordWrap
        '
        Me.chbWordWrap.Location = New System.Drawing.Point(16, 16)
        Me.chbWordWrap.Name = "chbWordWrap"
        Me.chbWordWrap.TabIndex = 9
        Me.chbWordWrap.Text = "Word Wrap"
        '
        'chbWrapAtMargin
        '
        Me.chbWrapAtMargin.Location = New System.Drawing.Point(16, 40)
        Me.chbWrapAtMargin.Name = "chbWrapAtMargin"
        Me.chbWrapAtMargin.TabIndex = 10
        Me.chbWrapAtMargin.Text = "Wrap at Margin"
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
        Me.laDescription.Text = "This demo shows how to use wordwrap mode to wrap lines within edit control's cont" & _
        "ent."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.EditMargin.Position = 50
        Me.syntaxEdit1.EditMargin.Visible = True
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 96)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 222)
        Me.syntaxEdit1.TabIndex = 3
        Me.syntaxEdit1.Text = "It is sometimes desirable for the user to see the codes which influence the layou" & _
        "t of the text and are normally invisible themselves. These codes are space, tab," & _
        " end-of-line, and the end-of-file (not really a code), and are often collectivel" & _
        "y referred to as the white-space. The SyntaxEdit has the option to display them," & _
        " and to control their appearance." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "The display of the white-space is enabled usi" & _
        "ng the WhiteSpace.Visible property. The color used to display white-space codes " & _
        "is determined by the WhiteSpace.SymbolColor property, and the characters used to" & _
        " display those codes are determined by EofSymbol, EolSymbol, SpaceSymbol, and Ta" & _
        "bSymbol properties."
        Me.syntaxEdit1.WordWrap = True
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
        chbWordWrap.Checked = syntaxEdit1.WordWrap
        chbWrapAtMargin.Checked = syntaxEdit1.WrapAtMargin
    End Sub

    Private Sub chbWordWrap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbWordWrap.CheckedChanged
        syntaxEdit1.WordWrap = chbWordWrap.Checked
    End Sub

    Private Sub chbWrapAtMargin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbWrapAtMargin.CheckedChanged
        syntaxEdit1.WrapAtMargin = chbWrapAtMargin.Checked
    End Sub
End Class
