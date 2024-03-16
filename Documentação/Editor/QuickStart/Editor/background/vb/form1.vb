Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports QWhale.Common
Imports QWhale.Syntax
Imports QWhale.Editor
Imports QWhale.Syntax.Parsers

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
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbGradientEndColor As QWhale.Common.ColorBox
    Friend WithEvents cbGradientBeginColor As QWhale.Common.ColorBox
    Friend WithEvents laGradientEndColor As System.Windows.Forms.Label
    Friend WithEvents laGradientBeginColor As System.Windows.Forms.Label
    Friend WithEvents laBackgroundStyle As System.Windows.Forms.Label
    Friend WithEvents cbBackgroundStyle As System.Windows.Forms.ComboBox
    Friend WithEvents chbTransparent As System.Windows.Forms.CheckBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.cbGradientEndColor = New QWhale.Common.ColorBox(Me.components)
        Me.cbGradientBeginColor = New QWhale.Common.ColorBox(Me.components)
        Me.laGradientEndColor = New System.Windows.Forms.Label
        Me.laGradientBeginColor = New System.Windows.Forms.Label
        Me.laBackgroundStyle = New System.Windows.Forms.Label
        Me.cbBackgroundStyle = New System.Windows.Forms.ComboBox
        Me.chbTransparent = New System.Windows.Forms.CheckBox
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.pnSettings.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.SuspendLayout()
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
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.groupBox1)
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 112)
        Me.pnSettings.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.cbGradientEndColor)
        Me.groupBox1.Controls.Add(Me.cbGradientBeginColor)
        Me.groupBox1.Controls.Add(Me.laGradientEndColor)
        Me.groupBox1.Controls.Add(Me.laGradientBeginColor)
        Me.groupBox1.Controls.Add(Me.laBackgroundStyle)
        Me.groupBox1.Controls.Add(Me.cbBackgroundStyle)
        Me.groupBox1.Controls.Add(Me.chbTransparent)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 88)
        Me.groupBox1.TabIndex = 8
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Background"
        '
        'cbGradientEndColor
        '
        Me.cbGradientEndColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbGradientEndColor.Location = New System.Drawing.Point(376, 56)
        Me.cbGradientEndColor.Name = "cbGradientEndColor"
        Me.cbGradientEndColor.SelectedColor = System.Drawing.Color.White
        Me.cbGradientEndColor.Size = New System.Drawing.Size(121, 21)
        Me.cbGradientEndColor.TabIndex = 13
        '
        'cbGradientBeginColor
        '
        Me.cbGradientBeginColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbGradientBeginColor.Location = New System.Drawing.Point(376, 24)
        Me.cbGradientBeginColor.Name = "cbGradientBeginColor"
        Me.cbGradientBeginColor.SelectedColor = System.Drawing.Color.Blue
        Me.cbGradientBeginColor.Size = New System.Drawing.Size(121, 21)
        Me.cbGradientBeginColor.TabIndex = 12
        '
        'laGradientEndColor
        '
        Me.laGradientEndColor.AutoSize = True
        Me.laGradientEndColor.Location = New System.Drawing.Point(256, 56)
        Me.laGradientEndColor.Name = "laGradientEndColor"
        Me.laGradientEndColor.Size = New System.Drawing.Size(101, 16)
        Me.laGradientEndColor.TabIndex = 11
        Me.laGradientEndColor.Text = "Gradient End Color"
        '
        'laGradientBeginColor
        '
        Me.laGradientBeginColor.AutoSize = True
        Me.laGradientBeginColor.Location = New System.Drawing.Point(256, 24)
        Me.laGradientBeginColor.Name = "laGradientBeginColor"
        Me.laGradientBeginColor.Size = New System.Drawing.Size(110, 16)
        Me.laGradientBeginColor.TabIndex = 10
        Me.laGradientBeginColor.Text = "Gradient Begin Color"
        '
        'laBackgroundStyle
        '
        Me.laBackgroundStyle.AutoSize = True
        Me.laBackgroundStyle.Location = New System.Drawing.Point(16, 59)
        Me.laBackgroundStyle.Name = "laBackgroundStyle"
        Me.laBackgroundStyle.Size = New System.Drawing.Size(93, 16)
        Me.laBackgroundStyle.TabIndex = 9
        Me.laBackgroundStyle.Text = "Background Style"
        '
        'cbBackgroundStyle
        '
        Me.cbBackgroundStyle.Items.AddRange(New Object() {"Background Image", "Gradient", "Theme Background"})
        Me.cbBackgroundStyle.Location = New System.Drawing.Point(120, 56)
        Me.cbBackgroundStyle.Name = "cbBackgroundStyle"
        Me.cbBackgroundStyle.Size = New System.Drawing.Size(121, 21)
        Me.cbBackgroundStyle.TabIndex = 8
        Me.cbBackgroundStyle.Text = "Background Image"
        '
        'chbTransparent
        '
        Me.chbTransparent.Checked = True
        Me.chbTransparent.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTransparent.Location = New System.Drawing.Point(16, 28)
        Me.chbTransparent.Name = "chbTransparent"
        Me.chbTransparent.Size = New System.Drawing.Size(112, 16)
        Me.chbTransparent.TabIndex = 7
        Me.chbTransparent.Text = "Transparent"
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(568, 24)
        Me.pnDescription.TabIndex = 7
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(568, 24)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo shows how to paint edit control's background."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.BackgroundImage = CType(resources.GetObject("syntaxEdit1.BackgroundImage"), System.Drawing.Image)
        Me.syntaxEdit1.BorderStyle = QWhale.Common.EditBorderStyle.System
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 112)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 206)
        Me.syntaxEdit1.TabIndex = 3
        Me.syntaxEdit1.Text = "Imports System" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class Person" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public age As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public name" & _
        " As String" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class MainClass" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public Sub New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " Dim p " & _
        "As Person = New Person" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Console.Write(""Name: {0}, Age: {1}"", p.name, p.a" & _
        "ge)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class"
        Me.syntaxEdit1.Transparent = True
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


    Private Sub chbTransparent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTransparent.CheckedChanged
        syntaxEdit1.Transparent = chbTransparent.Checked
    End Sub

    Private Sub cbBackgroundStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBackgroundStyle.SelectedIndexChanged
        syntaxEdit1.Invalidate()
    End Sub

    Private Sub cbGradientBeginColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGradientBeginColor.SelectedIndexChanged
        cbBackgroundStyle_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cbGradientEndColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGradientEndColor.SelectedIndexChanged
        cbBackgroundStyle_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub syntaxEdit1_PaintBackground(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles syntaxEdit1.PaintBackground
        Select Case (cbBackgroundStyle.SelectedIndex)
            Case 0
                'do nothing, painting background image specified by BackgroundImage property
            Case 1
                'painting gradient using linear gradient brush
                Dim r As Rectangle = syntaxEdit1.ClientRect
                e.Graphics.FillRectangle(New System.Drawing.Drawing2D.LinearGradientBrush(r.Location, New Point(r.Right, r.Bottom), cbGradientBeginColor.SelectedColor, cbGradientEndColor.SelectedColor), r)
            Case 2
                'painthing theme background
                Dim painter As IPainter = New GdiPainter
                painter.BeginPaint(e.Graphics)
                Try
                    Dim r As Rectangle = syntaxEdit1.ClientRect
                    XPThemes.DrawBackground(painter, r, cbGradientBeginColor.SelectedColor, cbGradientEndColor.SelectedColor)
                Finally
                    painter.EndPaint()
                End Try
        End Select
    End Sub

End Class
