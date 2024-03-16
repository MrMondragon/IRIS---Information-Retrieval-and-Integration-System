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
    Friend WithEvents btUndo As System.Windows.Forms.Button
    Friend WithEvents chbLineModificator As System.Windows.Forms.CheckBox
    Friend WithEvents btRedo As System.Windows.Forms.Button
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents imMenu As System.Windows.Forms.ImageList
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents cbSavedColor As QWhale.Common.ColorBox
    Friend WithEvents cbChangedColor As QWhale.Common.ColorBox
    Friend WithEvents laSavedColor As System.Windows.Forms.Label
    Friend WithEvents laChangedColor As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.btUndo = New System.Windows.Forms.Button
        Me.imMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.chbLineModificator = New System.Windows.Forms.CheckBox
        Me.btRedo = New System.Windows.Forms.Button
        Me.btSave = New System.Windows.Forms.Button
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
        Me.cbSavedColor = New QWhale.Common.ColorBox(Me.components)
        Me.cbChangedColor = New QWhale.Common.ColorBox(Me.components)
        Me.laSavedColor = New System.Windows.Forms.Label
        Me.laChangedColor = New System.Windows.Forms.Label
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
        Me.groupBox1.Controls.Add(Me.cbSavedColor)
        Me.groupBox1.Controls.Add(Me.cbChangedColor)
        Me.groupBox1.Controls.Add(Me.laSavedColor)
        Me.groupBox1.Controls.Add(Me.laChangedColor)
        Me.groupBox1.Controls.Add(Me.btUndo)
        Me.groupBox1.Controls.Add(Me.chbLineModificator)
        Me.groupBox1.Controls.Add(Me.btRedo)
        Me.groupBox1.Controls.Add(Me.btSave)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 72)
        Me.groupBox1.TabIndex = 13
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Line modificators"
        '
        'btUndo
        '
        Me.btUndo.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btUndo.ImageIndex = 0
        Me.btUndo.ImageList = Me.imMenu
        Me.btUndo.Location = New System.Drawing.Point(8, 40)
        Me.btUndo.Name = "btUndo"
        Me.btUndo.Size = New System.Drawing.Size(72, 23)
        Me.btUndo.TabIndex = 10
        Me.btUndo.Text = "Undo"
        '
        'imMenu
        '
        Me.imMenu.ImageSize = New System.Drawing.Size(16, 16)
        Me.imMenu.ImageStream = CType(resources.GetObject("imMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imMenu.TransparentColor = System.Drawing.Color.Red
        '
        'chbLineModificator
        '
        Me.chbLineModificator.Checked = True
        Me.chbLineModificator.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbLineModificator.Location = New System.Drawing.Point(8, 16)
        Me.chbLineModificator.Name = "chbLineModificator"
        Me.chbLineModificator.Size = New System.Drawing.Size(112, 24)
        Me.chbLineModificator.TabIndex = 9
        Me.chbLineModificator.Text = "Line Modificators"
        '
        'btRedo
        '
        Me.btRedo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btRedo.ImageIndex = 1
        Me.btRedo.ImageList = Me.imMenu
        Me.btRedo.Location = New System.Drawing.Point(88, 40)
        Me.btRedo.Name = "btRedo"
        Me.btRedo.Size = New System.Drawing.Size(72, 23)
        Me.btRedo.TabIndex = 11
        Me.btRedo.Text = "Redo"
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(168, 40)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(72, 23)
        Me.btSave.TabIndex = 12
        Me.btSave.Text = "Save"
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
        Me.laDescription.Text = "This demo shows how to visually identify modified lines."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Gutter.Options = CType((QWhale.Editor.GutterOptions.PaintBookMarks Or QWhale.Editor.GutterOptions.PaintLineModificators), QWhale.Editor.GutterOptions)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 96)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 222)
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
        'cbSavedColor
        '
        Me.cbSavedColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbSavedColor.Location = New System.Drawing.Point(376, 48)
        Me.cbSavedColor.Name = "cbSavedColor"
        Me.cbSavedColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbSavedColor.Size = New System.Drawing.Size(121, 21)
        Me.cbSavedColor.TabIndex = 20
        '
        'cbChangedColor
        '
        Me.cbChangedColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbChangedColor.Location = New System.Drawing.Point(376, 16)
        Me.cbChangedColor.Name = "cbChangedColor"
        Me.cbChangedColor.SelectedColor = System.Drawing.Color.Empty
        Me.cbChangedColor.Size = New System.Drawing.Size(121, 21)
        Me.cbChangedColor.TabIndex = 19
        '
        'laSavedColor
        '
        Me.laSavedColor.Location = New System.Drawing.Point(272, 48)
        Me.laSavedColor.Name = "laSavedColor"
        Me.laSavedColor.Size = New System.Drawing.Size(80, 16)
        Me.laSavedColor.TabIndex = 18
        Me.laSavedColor.Text = "Saved Color"
        '
        'laChangedColor
        '
        Me.laChangedColor.Location = New System.Drawing.Point(272, 16)
        Me.laChangedColor.Name = "laChangedColor"
        Me.laChangedColor.Size = New System.Drawing.Size(100, 16)
        Me.laChangedColor.TabIndex = 17
        Me.laChangedColor.Text = "Changed color"
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
        chbLineModificator.Checked = (GutterOptions.PaintLineModificators And syntaxEdit1.Gutter.Options) <> 0
        cbChangedColor.SelectedColor = syntaxEdit1.Gutter.LineModificatorChangedColor
        cbSavedColor.SelectedColor = syntaxEdit1.Gutter.LineModificatorSavedColor
        syntaxEdit1.Source.NewLine()
    End Sub

    Private Sub chbLineModificator_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLineModificator.CheckedChanged
        If chbLineModificator.Checked Then
            syntaxEdit1.Gutter.Options = syntaxEdit1.Gutter.Options Or GutterOptions.PaintLineModificators
        Else
            syntaxEdit1.Gutter.Options = syntaxEdit1.Gutter.Options Xor GutterOptions.PaintLineModificators
        End If
    End Sub

    Private Sub btUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUndo.Click
        If (syntaxEdit1.Source.CanUndo()) Then
            syntaxEdit1.Source.Undo()
        End If
    End Sub

    Private Sub btRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRedo.Click
        If (syntaxEdit1.Source.CanRedo()) Then
            syntaxEdit1.Source.Redo()
        End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        syntaxEdit1.Modified = False
    End Sub

    Private Sub syntaxEdit1_SourceStateChanged(ByVal sender As Object, ByVal e As QWhale.Editor.NotifyEventArgs) Handles syntaxEdit1.SourceStateChanged
        If (((e.State And NotifyState.Modified) <> 0) Or ((e.State And NotifyState.Undo) <> 0) Or ((e.State And NotifyState.ModifiedChanged) <> 0) Or ((e.State And NotifyState.Edit) <> 0) Or ((e.State And NotifyState.Edit) <> 0) Or ((e.State And NotifyState.BlockChanged) <> 0)) Then
            Dim edit As SyntaxEdit = CType(sender, SyntaxEdit)
            btRedo.Enabled = edit.Source.CanRedo()
            btUndo.Enabled = edit.Source.CanUndo()
            btSave.Enabled = edit.Modified
        End If
    End Sub

    Private Sub cbChangedColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbChangedColor.SelectedIndexChanged
        syntaxEdit1.Gutter.LineModificatorChangedColor = cbChangedColor.SelectedColor
    End Sub

    Private Sub cbSavedColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSavedColor.SelectedIndexChanged
        syntaxEdit1.Gutter.LineModificatorSavedColor = cbSavedColor.SelectedColor
    End Sub
End Class
