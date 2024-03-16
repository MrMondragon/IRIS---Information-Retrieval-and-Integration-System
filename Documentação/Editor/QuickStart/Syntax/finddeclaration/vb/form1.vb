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
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents contextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents cmFindDeclaration As System.Windows.Forms.MenuItem
    Friend WithEvents cmFindReference As System.Windows.Forms.MenuItem
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents miFind As System.Windows.Forms.MenuItem
    Friend WithEvents miFindDeclaration As System.Windows.Forms.MenuItem
    Friend WithEvents miFindReference As System.Windows.Forms.MenuItem
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.contextMenu1 = New System.Windows.Forms.ContextMenu
        Me.cmFindDeclaration = New System.Windows.Forms.MenuItem
        Me.cmFindReference = New System.Windows.Forms.MenuItem
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.miFind = New System.Windows.Forms.MenuItem
        Me.miFindDeclaration = New System.Windows.Forms.MenuItem
        Me.miFindReference = New System.Windows.Forms.MenuItem
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
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
        Me.pnSettings.Size = New System.Drawing.Size(568, 48)
        Me.pnSettings.TabIndex = 2
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(568, 48)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(568, 48)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "The demo shows how to use Find Declaration/Find References of language elements w" & _
        "ithin Edit control's content. Hit ctrl key and click on identifier or use popup " & _
        "menu to find declaration of the element."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'contextMenu1
        '
        Me.contextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmFindDeclaration, Me.cmFindReference})
        '
        'cmFindDeclaration
        '
        Me.cmFindDeclaration.Index = 0
        Me.cmFindDeclaration.Text = "Find Declaration"
        '
        'cmFindReference
        '
        Me.cmFindReference.Index = 1
        Me.cmFindReference.Text = "Find Reference"
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFind})
        '
        'miFind
        '
        Me.miFind.Index = 0
        Me.miFind.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFindDeclaration, Me.miFindReference})
        Me.miFind.Text = "Find"
        '
        'miFindDeclaration
        '
        Me.miFindDeclaration.Index = 0
        Me.miFindDeclaration.Text = "Declaration"
        '
        'miFindReference
        '
        Me.miFindReference.Index = 1
        Me.miFindReference.Text = "Reference"
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.ContextMenu = Me.contextMenu1
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.HyperText.HighlightUrls = True
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 48)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 291)
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
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 339)
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.pnSettings)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private references As SyntaxNodes
    Private isDefinition As Boolean
    Private definitionOrigin As Point = New Point(-1, -1)
    Private definitionDest As Point = New Point(-1, -1)
    Private definitionLength As Integer

    Private Sub ClearReferences()
        If (Not references Is Nothing) Then
            If (references.Count >= 0) Then
                references.Clear()
                syntaxEdit1.Invalidate()
            End If
        End If
    End Sub

    Private Sub FindReferences()
        If (Not syntaxEdit1 Is Nothing) And (Not (syntaxEdit1.Lexer Is Nothing)) And (TypeOf syntaxEdit1.Lexer Is ISyntaxParser) Then
            Dim node As ISyntaxNode = CType(syntaxEdit1.Lexer, ISyntaxParser).FindDeclaration(String.Empty, syntaxEdit1.Position)
            If (Not node Is Nothing) Then
                Dim pt1 As Point = node.Position
                Dim attr As ISyntaxAttribute = node.FindAttribute(SyntaxConsts.DeclarationScope)
                Dim pt2 As Point
                If Not attr Is Nothing Then
                    pt2 = attr.Position
                Else
                    pt2 = node.Range.EndPoint
                End If
                syntaxEdit1.Selection.SetSelection(SelectionType.Stream, pt1, pt2)
                CType(syntaxEdit1.Lexer, ISyntaxParser).FindReferences(node, references)
                syntaxEdit1.Invalidate()
            Else
                ClearReferences()
            End If
        End If
    End Sub

    Private Sub DoCustomDraw(ByVal sender As Object, ByVal e As CustomDrawEventArgs)
        ' drawing rectangle around the found references (references are filled when executing FindReference popup menu).
        If ((references.Count > 0) And (e.DrawStage = DrawStage.After) And (e.DrawState = DrawState.Control)) Then
            e.Painter.ForeColor = Color.Navy
            e.Painter.BackColor = Color.Navy
            For Each node As ISyntaxNode In references
                If (TypeOf sender Is EditSyntaxPaint) Then
                    Dim sPaint As EditSyntaxPaint = CType(sender, EditSyntaxPaint)
                    Dim r As Rectangle = New Rectangle(node.Position, New Size(node.Range.EndPoint.X - node.Position.X, node.Range.EndPoint.Y - node.Position.Y))
                    Dim pt1 As Point = sPaint.Owner.TextToScreen(r.Location)
                    Dim pt2 As Point = sPaint.Owner.TextToScreen(New Point(r.Right, r.Bottom))
                    pt2.Y += e.Painter.FontHeight
                    e.Painter.DrawRectangle(pt1.X, pt1.Y, pt2.X - pt1.X, pt2.Y - pt1.Y)
                End If
            Next node
        End If
    End Sub

    Private Function UpdateGotoDeclaration(ByVal jump As Boolean) As Boolean
        Dim result As Boolean = False
        If ((Not syntaxEdit1 Is Nothing) And (Not syntaxEdit1.Lexer Is Nothing) And (TypeOf syntaxEdit1.Lexer Is ISyntaxParser)) Then
            Dim node As ISyntaxNode = (CType(syntaxEdit1.Lexer, ISyntaxParser).FindDeclaration(String.Empty, syntaxEdit1.Position))
            If (Not node Is Nothing) Then
                result = True
                If (jump) Then
                    syntaxEdit1.Position = node.Position
                    syntaxEdit1.Invalidate()
                End If
            End If
        End If
        Return result
    End Function

    Private Sub UpdateGotoDef(ByVal edit As SyntaxEdit)
        ' updating identifiers that have declaration when moving mouse with Ctrl key pressed
        UpdateGotoDef(edit, definitionOrigin.Y, definitionOrigin.X, definitionLength, False)
    End Sub
    Private Sub UpdateGotoDef(ByVal edit As SyntaxEdit, ByVal line As Integer, ByVal start As Integer, ByVal len As Integer, ByVal isSet As Boolean)
        Dim pt As Point = New Point(start, line)
        If ((definitionOrigin.Equals(pt)) And (isDefinition = isSet) And (definitionLength = len)) Then
            Return
        End If
        If (isSet) Then
            UpdateGotoDef(edit)
            definitionOrigin = New Point(start, line)
            definitionLength = len
        Else
            definitionLength = 0
            definitionOrigin = New Point(-1, -1)
            definitionDest = New Point(-1, -1)
        End If
        isDefinition = isSet
        Dim item As IStrItem = edit.Lines.GetItem(line)
        If ((Not item Is Nothing) And (start >= 0) And (start < item.ColorData.Length)) Then
            item.SetColorFlag(start, Math.Min(len, item.ColorData.Length - start), ColorFlags.HyperText, isSet)
            CType(edit.Source, ISourceNotify).BeginUpdate(UpdateReason.Other)
            Try
                edit.Source.LinesChanged(line, line, False)
                edit.Source.State = edit.Source.State Or NotifyState.BlockChanged
            Finally
                edit.Source.EndUpdate()
            End Try
        End If
    End Sub

    Public Function GotoDefinition(ByVal pt As Point, ByVal jump As Boolean, ByVal edit As SyntaxEdit) As Boolean
        ' jumping to the delcaration when mouse button is released
        If (Not (TypeOf edit.Lexer Is ISyntaxParser)) Then
            Return False
        End If
        Dim parser As ISyntaxParser = CType(edit.Lexer, ISyntaxParser)
        Dim result As Boolean = False
        Dim s As String = edit.Lines(pt.Y)
        Dim left As Integer
        Dim right As Integer
        If (edit.Lines.GetWord(pt.Y, pt.X, left, right)) Then
            Dim name As String = s.Substring(left, right - left + 1)
            Dim node As ISyntaxNode = parser.FindDeclaration(s, pt)
            If (Not node Is Nothing) Then
                If String.Compare(node.Name, name, Not parser.CaseSensitive) = 0 Then
                    definitionDest = node.Position
                    UpdateGotoDef(edit, pt.Y, left, right - left + 1, True)
                Else
                    UpdateGotoDef(edit)
                End If
            Else
                UpdateGotoDef(edit)
            End If
            result = Not node Is Nothing
        Else
            UpdateGotoDef(edit)
        End If
        If (jump And isDefinition) Then
            pt = definitionDest
            UpdateGotoDef(edit)
            edit.MoveTo(pt)
        End If
        Return result
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        references = New SyntaxNodes
    End Sub

    Private Sub syntaxEdit1_CustomDraw(ByVal sender As Object, ByVal e As QWhale.Editor.CustomDrawEventArgs) Handles syntaxEdit1.CustomDraw
        DoCustomDraw(sender, e)
    End Sub

    Private Sub miFind_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFind.Popup
        miFindDeclaration.Enabled = UpdateGotoDeclaration(False)
        miFindReference.Enabled = miFindDeclaration.Enabled
        cmFindDeclaration.Enabled = UpdateGotoDeclaration(False)
        cmFindReference.Enabled = miFindDeclaration.Enabled
    End Sub

    Private Sub contextMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles contextMenu1.Popup
        miFind_Popup(sender, e)
    End Sub

    Private Sub miFindDeclaration_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFindDeclaration.Click
        UpdateGotoDeclaration(True)
    End Sub

    Private Sub miFindReference_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFindReference.Click
        FindReferences()
    End Sub

    Private Sub cmFindDeclaration_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmFindDeclaration.Click
        miFindDeclaration_Click(sender, e)
    End Sub

    Private Sub cmFindReference_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmFindReference.Click
        miFindReference_Click(sender, e)
    End Sub

    Private Sub syntaxEdit1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles syntaxEdit1.MouseLeave
        UpdateGotoDef(CType(sender, SyntaxEdit))
    End Sub

    Private Sub syntaxEdit1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles syntaxEdit1.MouseUp
        If (isDefinition) Then
            Dim edit As SyntaxEdit = CType(sender, SyntaxEdit)
            Dim pt As Point = definitionDest
            UpdateGotoDef(edit)
            edit.MoveTo(pt)
        End If
    End Sub

    Private Sub syntaxEdit1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles syntaxEdit1.MouseMove
        Dim edit As SyntaxEdit = CType(sender, SyntaxEdit)
        If ((Control.ModifierKeys And Keys.Control) <> 0) Then
            Dim Pt As Point = edit.ScreenToText(e.X, e.Y)
            GotoDefinition(Pt, False, edit)
        Else
            UpdateGotoDef(edit)
        End If
    End Sub

    Private Sub syntaxEdit1_JumpToUrl(ByVal sender As Object, ByVal e As QWhale.Editor.UrlJumpEventArgs) Handles syntaxEdit1.JumpToUrl
        e.Handled = isDefinition
    End Sub

    Private Sub syntaxEdit1_SourceStateChanged(ByVal sender As Object, ByVal e As QWhale.Editor.NotifyEventArgs) Handles syntaxEdit1.SourceStateChanged
        If ((e.State And NotifyState.PositionChanged) <> 0) Then
            ClearReferences()
        End If
    End Sub
End Class
