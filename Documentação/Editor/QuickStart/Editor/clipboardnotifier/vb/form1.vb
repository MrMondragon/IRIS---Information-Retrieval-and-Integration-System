Imports System
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
    Friend WithEvents SyntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.SyntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.pnSettings.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 24)
        Me.pnSettings.TabIndex = 2
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
        Me.laDescription.Text = "This demo project shows how to see clipboard content changed by the another appli" & _
        "cations."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SyntaxEdit1
        '
        Me.SyntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.SyntaxEdit1.BorderStyle = QWhale.Common.EditBorderStyle.Fixed3D
        Me.SyntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SyntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SyntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.SyntaxEdit1.Location = New System.Drawing.Point(0, 24)
        Me.SyntaxEdit1.Name = "SyntaxEdit1"
        Me.SyntaxEdit1.Size = New System.Drawing.Size(568, 294)
        Me.SyntaxEdit1.TabIndex = 3
        Me.SyntaxEdit1.Text = ""
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
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private clipChange As ClipboardChangeNotifier = Nothing

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clipChange = New ClipboardChangeNotifier
        AddHandler clipChange.ClipboardChanged, AddressOf clipChange_ClipboardChanged
        clipChange.AssignHandle(Handle)
        clipChange.Install()
    End Sub

    Private Sub clipChange_ClipboardChanged(ByVal sender As Object, ByVal e As EventArgs)
        Application.DoEvents()
        showFormats()
    End Sub

    Private Sub showFormats()
        SyntaxEdit1.Lines.Clear()
        SyntaxEdit1.Lines.Add("Clipboard Changed at " + DateTime.Now)
        Dim dto As IDataObject = Clipboard.GetDataObject()
        Dim obj As Object = Nothing
        For Each fmt As String In dto.GetFormats()
            SyntaxEdit1.Lines.Add(fmt)
            obj = dto.GetData(fmt)
            SyntaxEdit1.Lines.Add(obj.ToString())
        Next fmt
    End Sub
End Class
