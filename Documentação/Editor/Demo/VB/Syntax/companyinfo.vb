#Region "Copyright (c) 2004, 2005 Quantum Whale LLC."

'	Quantum Whale .NET Component Library
'	Editor.NET Syntax Demo
'
'	Copyright (c) 2004 Quantum Whale LLC.
'	ALL RIGHTS RESERVED
'
'	http://www.qwhale.net
'	contact@qwhale.net

#End Region

Public Class CompanyInfo
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
    Friend WithEvents tbCompanyInfo As System.Windows.Forms.TextBox
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents laMailTo As System.Windows.Forms.Label
    Friend WithEvents laEMail As System.Windows.Forms.Label
    Friend WithEvents laAdress As System.Windows.Forms.Label
    Friend WithEvents laWWW As System.Windows.Forms.Label
    Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CompanyInfo))
        Me.tbCompanyInfo = New System.Windows.Forms.TextBox
        Me.btClose = New System.Windows.Forms.Button
        Me.laMailTo = New System.Windows.Forms.Label
        Me.laEMail = New System.Windows.Forms.Label
        Me.laAdress = New System.Windows.Forms.Label
        Me.laWWW = New System.Windows.Forms.Label
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'tbCompanyInfo
        '
        Me.tbCompanyInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tbCompanyInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCompanyInfo.Location = New System.Drawing.Point(16, 16)
        Me.tbCompanyInfo.Multiline = True
        Me.tbCompanyInfo.Name = "tbCompanyInfo"
        Me.tbCompanyInfo.Size = New System.Drawing.Size(400, 52)
        Me.tbCompanyInfo.TabIndex = 13
        Me.tbCompanyInfo.Text = "This demo is designed to show how Editor.NET can display sources writen in differ" & _
        "ent languages and highlight code outlining and intellisence features (in charp f" & _
        "iles)."
        '
        'btClose
        '
        Me.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btClose.Location = New System.Drawing.Point(192, 168)
        Me.btClose.Name = "btClose"
        Me.btClose.TabIndex = 12
        Me.btClose.Text = "Close"
        '
        'laMailTo
        '
        Me.laMailTo.AutoSize = True
        Me.laMailTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.laMailTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laMailTo.ForeColor = System.Drawing.Color.Blue
        Me.laMailTo.Location = New System.Drawing.Point(256, 104)
        Me.laMailTo.Name = "laMailTo"
        Me.laMailTo.Size = New System.Drawing.Size(141, 16)
        Me.laMailTo.TabIndex = 11
        Me.laMailTo.Text = "mailto:contact@qwhale.net"
        '
        'laEMail
        '
        Me.laEMail.AutoSize = True
        Me.laEMail.Location = New System.Drawing.Point(208, 104)
        Me.laEMail.Name = "laEMail"
        Me.laEMail.Size = New System.Drawing.Size(38, 16)
        Me.laEMail.TabIndex = 10
        Me.laEMail.Text = "e-mail:"
        '
        'laAdress
        '
        Me.laAdress.AutoSize = True
        Me.laAdress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.laAdress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laAdress.ForeColor = System.Drawing.Color.Blue
        Me.laAdress.Location = New System.Drawing.Point(256, 80)
        Me.laAdress.Name = "laAdress"
        Me.laAdress.Size = New System.Drawing.Size(115, 16)
        Me.laAdress.TabIndex = 9
        Me.laAdress.Text = "http://www.qwhale.net"
        '
        'laWWW
        '
        Me.laWWW.AutoSize = True
        Me.laWWW.Location = New System.Drawing.Point(208, 80)
        Me.laWWW.Name = "laWWW"
        Me.laWWW.Size = New System.Drawing.Size(39, 16)
        Me.laWWW.TabIndex = 8
        Me.laWWW.Text = "WWW:"
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(16, 48)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(180, 80)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox1.TabIndex = 7
        Me.pictureBox1.TabStop = False
        '
        'CompanyInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 224)
        Me.Controls.Add(Me.tbCompanyInfo)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.laMailTo)
        Me.Controls.Add(Me.laEMail)
        Me.Controls.Add(Me.laAdress)
        Me.Controls.Add(Me.laWWW)
        Me.Controls.Add(Me.pictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "CompanyInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Info"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btClose.Click
        Hide()
    End Sub

    Private Sub CompanyInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If TypeOf pictureBox1.Image Is Bitmap Then
            CType(pictureBox1.Image, Bitmap).MakeTransparent(Color.White)
        End If
    End Sub

    Private Sub laAdress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles laAdress.Click
        laAdress.ForeColor = Color.Purple
        Try
            System.Diagnostics.Process.Start(laAdress.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub laMailTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles laMailTo.Click
        laMailTo.ForeColor = Color.Purple
        Try
            System.Diagnostics.Process.Start(laMailTo.Text)
        Catch ex As Exception
        End Try
    End Sub
End Class
