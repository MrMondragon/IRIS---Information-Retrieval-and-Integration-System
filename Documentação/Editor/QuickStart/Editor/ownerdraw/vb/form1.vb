Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports QWhale.Common
Imports System.Collections
Imports QWhale.Syntax
Imports QWhale.Syntax.Parsers
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
    Friend WithEvents laIdentsColor As System.Windows.Forms.Label
    Friend WithEvents cbIdentsColor As QWhale.Common.ColorBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents VbParser1 As QWhale.Syntax.Parsers.VbParser
    Friend WithEvents cbMethodBkColor As QWhale.Common.ColorBox
    Friend WithEvents laMethodBkColor As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.cbMethodBkColor = New QWhale.Common.ColorBox(Me.components)
        Me.laMethodBkColor = New System.Windows.Forms.Label
        Me.laIdentsColor = New System.Windows.Forms.Label
        Me.cbIdentsColor = New QWhale.Common.ColorBox(Me.components)
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.VbParser1 = New QWhale.Syntax.Parsers.VbParser
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
        Me.groupBox1.Controls.Add(Me.cbMethodBkColor)
        Me.groupBox1.Controls.Add(Me.laMethodBkColor)
        Me.groupBox1.Controls.Add(Me.laIdentsColor)
        Me.groupBox1.Controls.Add(Me.cbIdentsColor)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 24)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(568, 72)
        Me.groupBox1.TabIndex = 11
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Custom Draw"
        '
        'cbMethodBkColor
        '
        Me.cbMethodBkColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbMethodBkColor.Location = New System.Drawing.Point(152, 40)
        Me.cbMethodBkColor.Name = "cbMethodBkColor"
        Me.cbMethodBkColor.SelectedColor = System.Drawing.SystemColors.Info
        Me.cbMethodBkColor.Size = New System.Drawing.Size(121, 21)
        Me.cbMethodBkColor.TabIndex = 14
        '
        'laMethodBkColor
        '
        Me.laMethodBkColor.AutoSize = True
        Me.laMethodBkColor.Location = New System.Drawing.Point(8, 43)
        Me.laMethodBkColor.Name = "laMethodBkColor"
        Me.laMethodBkColor.Size = New System.Drawing.Size(139, 16)
        Me.laMethodBkColor.TabIndex = 13
        Me.laMethodBkColor.Text = "Method Background Color:"
        '
        'laIdentsColor
        '
        Me.laIdentsColor.AutoSize = True
        Me.laIdentsColor.Location = New System.Drawing.Point(8, 19)
        Me.laIdentsColor.Name = "laIdentsColor"
        Me.laIdentsColor.Size = New System.Drawing.Size(68, 16)
        Me.laIdentsColor.TabIndex = 10
        Me.laIdentsColor.Text = "Idents Color:"
        '
        'cbIdentsColor
        '
        Me.cbIdentsColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbIdentsColor.Location = New System.Drawing.Point(152, 16)
        Me.cbIdentsColor.Name = "cbIdentsColor"
        Me.cbIdentsColor.SelectedColor = System.Drawing.Color.Teal
        Me.cbIdentsColor.Size = New System.Drawing.Size(121, 21)
        Me.cbIdentsColor.TabIndex = 9
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
        Me.laDescription.Text = "This demo shows ability to use owner drawing for edit control's text."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.VbParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(0, 96)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Outlining.AllowOutlining = True
        Me.syntaxEdit1.Size = New System.Drawing.Size(568, 286)
        Me.syntaxEdit1.TabIndex = 3
        Me.syntaxEdit1.Text = "Imports System" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class Person" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public age As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public name" & _
        " As String" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "'The main entry point for the application" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class" & _
        " MainClass" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Public Sub New()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim p As Person = New Person 'test" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
        "        Console.Write(""Name: {0}, Age: {1}"", p.name, p.age)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End " & _
        "Class"
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
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 382)
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

    Private methods As ArrayList
    Private comments As ArrayList

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        methods = New ArrayList
        comments = New ArrayList
    End Sub

    Private Sub cbIdentsColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIdentsColor.SelectedIndexChanged
        syntaxEdit1.Invalidate()
    End Sub

    Private Sub syntaxEdit1_CustomDraw(ByVal sender As Object, ByVal e As QWhale.Editor.CustomDrawEventArgs) Handles syntaxEdit1.CustomDraw
        ' drawing all identifier with different color
        If ((e.DrawStage = DrawStage.Before) And (((e.DrawState And DrawState.Text) <> 0) And (e.DrawState And DrawState.Selection) = 0)) Then
            Dim tok As LexToken = CType(e.DrawInfo.Style - 1, LexToken)
            If (tok = LexToken.Identifier) Then
                e.Painter.TextColor = cbIdentsColor.SelectedColor
            End If
        End If
        'fill button gradient
        If ((e.DrawStage = DrawStage.Before) And (DrawState.OutlineImage And e.DrawState) <> 0) Then
            Dim r As Rectangle = e.Rect
            r.X = r.X + 1
            r.Y = r.Y + 1
            r.Width = r.Width - 1
            r.Height = r.Height - 1
            e.Painter.FillGradient(r.X, r.Y, r.Width, r.Height, Color.Blue, Color.White, e.Rect.Location, New Point(r.Right, r.Bottom))
            e.Painter.ExcludeClipRect(e.Rect)
        End If
        'fill method background
        If ((e.DrawStage = DrawStage.Before) And ((e.DrawState = DrawState.Text) Or (e.DrawState = DrawState.BeyondEol))) Then
            If (DrawInMethod(syntaxEdit1.ScreenToText(e.Rect.Left, e.Rect.Top))) Then
                e.Painter.BackColor = cbMethodBkColor.SelectedColor
            End If
        End If
        'drawwing polygon around method
        If ((e.DrawStage = DrawStage.Before) And (e.DrawState = DrawState.Control)) Then
            For Each method As ISyntaxNode In methods
                Dim outRange As IOutlineRange = syntaxEdit1.Outlining.GetOutlineRange(method.Range.StartPoint)
                If (Not outRange Is Nothing) Then
                    If (outRange.Visible) Then
                        DrawRangeRect(e.Painter, method.Range, Color.Red)
                    End If
                End If
            Next method
        End If
        If ((e.DrawState = DrawState.Control) And (e.DrawStage = DrawStage.After)) Then
            ' drawing separator between methods
            Dim x1 As Integer = syntaxEdit1.ClientRect.Left + syntaxEdit1.Gutter.Rect.Width
            Dim x2 As Integer = syntaxEdit1.ClientRect.Right
            For i As Integer = 0 To methods.Count - 1
                'Dim index As Integer = CType(methods(i), Integer)
                Dim index As Integer = CType(methods(i), ISyntaxNode).Range.EndPoint.Y + 1
                Dim pos As Point = syntaxEdit1.DisplayToScreen(0, index)
                e.Painter.DrawLine(x1, pos.Y, x2, pos.Y, Color.Green, 1, System.Drawing.Drawing2D.DashStyle.Dot)
            Next i
            ' draw rectangle around comments
            Dim start As Point = Point.Empty
            Dim endPos As Point = Point.Empty
            For Each range As IRange In comments
                DrawRangeRect(e.Painter, range, Color.Gray)
            Next range
        End If
    End Sub

    Private Sub ProcessNode(ByVal node As ISyntaxNode)
        If (node.NodeType = NetNodeType.Method) Or (node.NodeType = NetNodeType.Constructor) Then
            methods.Add(node)
        End If
        '        If (node.NodeType = NetNodeType.Method) Or (node.NodeType = NetNodeType.Constructor) Then
        '       methods.Add(node.Range.EndPoint.Y + 1)
        '      End If
        If ((node.NodeType = NetNodeType.Comment) Or (node.NodeType = NetNodeType.XmlComment)) Then
            comments.Add(node.Range)
        End If
        If (node.HasChildren) Then
            For i As Integer = 0 To node.ChildCount - 1
                ProcessNode(node.ChildList(i))
            Next i
        End If
    End Sub

    Private Sub syntaxEdit1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles syntaxEdit1.Resize
        syntaxEdit1.Invalidate()
    End Sub

    Private Sub VbParser1_TextReparsed(ByVal sender As Object, ByVal e As System.EventArgs) Handles VbParser1.TextReparsed
        If (Not methods Is Nothing) And (Not comments Is Nothing) Then
            methods.Clear()
            comments.Clear()
            ProcessNode(VbParser1.SyntaxTree.Root)
            syntaxEdit1.Invalidate()
        End If
    End Sub
    Private Function GetPolygon(ByVal startPt As Point, ByVal endPt As Point, ByVal h As Integer) As Point()
        Dim isRect As Boolean = True
        Dim right As Integer = syntaxEdit1.ClientRect.Right - 1
        Dim left As Integer = syntaxEdit1.Gutter.Rect.Width
        Dim result As Point()
        isRect = startPt.Y = endPt.Y
        If (isRect) Then
            result = New Point(3) {}
        Else
            result = New Point(7) {}
        End If
        For i As Integer = 0 To result.Length - 1
            Select Case (i)
                Case 0
                    result(i) = startPt
                Case 1
                    If isRect Then
                        result(i) = endPt
                    Else
                        result(i) = New Point(right, startPt.Y)
                    End If
                Case 2
                    If isRect Then
                        result(i) = New Point(endPt.X, endPt.Y + h)
                    Else
                        result(i) = New Point(right, endPt.Y)
                    End If
                Case 3
                    If isRect Then
                        result(i) = New Point(startPt.X, startPt.Y + h)
                    Else
                        result(i) = endPt
                    End If
                Case 4
                    result(i) = New Point(endPt.X, endPt.Y + h)
                Case 5
                    result(i) = New Point(left, endPt.Y + h)
                Case 6
                    result(i) = New Point(left, startPt.Y + h)
                Case 7
                    result(i) = New Point(startPt.X, startPt.Y + h)
            End Select
        Next i
        Return result
    End Function

    Private Sub DrawRangeRect(ByVal painter As IPainter, ByVal range As IRange, ByVal color As Color)
        painter.ForeColor = color
        Dim right As Integer = syntaxEdit1.ClientRect.Right - 1
        Dim Left As Integer = syntaxEdit1.Gutter.Rect.Width + 1
        Dim h As Integer = painter.FontHeight
        Dim startPt As Point = syntaxEdit1.TextToScreen(range.StartPoint.X, range.StartPoint.Y)
        Dim endPt As Point = syntaxEdit1.TextToScreen(range.EndPoint.X, range.EndPoint.Y)
        startPt.X = Math.Max(startPt.X, Left - 1)
        endPt.X = Math.Max(endPt.X, Left - 1)

        If (range.EndPoint.X = Integer.MaxValue) Then
            endPt.X = syntaxEdit1.ClientRect.Right - 1
        End If

        Dim points As Point() = GetPolygon(startPt, endPt, h)
        For i As Integer = 0 To points.Length - 1
            If (i < points.Length - 1) Then
                If ((points(i).X <= points(i + 1).X) And (points(i).Y <= points(i + 1).Y)) Then
                    painter.DrawLine(points(i).X, points(i).Y, points(i + 1).X, points(i + 1).Y)
                Else
                    painter.DrawLine(points(i + 1).X, points(i + 1).Y, points(i).X, points(i).Y)
                End If
            Else
                painter.DrawLine(points(0).X, points(0).Y, points(i).X, points(i).Y)
            End If
        Next i
        Dim rect As Rectangle
        For j As Integer = 0 To points.Length - 1
            If (j < points.Length - 1) Then
                If ((points(j).X <= points(j + 1).X) And (points(j).Y <= points(j + 1).Y)) Then
                    rect = New Rectangle(points(j).X, points(j).Y, Math.Max(1, points(j + 1).X - points(j).X), Math.Max(1, points(j + 1).Y - points(j).Y))
                Else
                    rect = New Rectangle(points(j + 1).X, points(j + 1).Y, Math.Max(1, points(j).X - points(j + 1).X), Math.Max(1, points(j).Y - points(j + 1).Y))
                End If
            Else
                rect = New Rectangle(points(0).X, points(0).Y, Math.Max(1, points(j).X - points(0).X), Math.Max(1, points(j).Y - points(0).Y))
            End If
            painter.ExcludeClipRect(rect)
        Next j
    End Sub
    Private Class RangeComparer
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim pt As Point = CType(x, Point)
            Dim sPt As Point = CType(y, IRange).StartPoint
            Dim ePt As Point = CType(y, IRange).EndPoint
            If ((pt.Y < sPt.Y) Or ((pt.Y = sPt.Y) And (pt.X < sPt.X))) Then
                Return -1
            Else
                If ((pt.Y > ePt.Y) Or ((pt.Y = ePt.Y) And (pt.X >= ePt.X))) Then
                    Return 1
                Else
                    Return 0
                End If
            End If
        End Function
    End Class
    Private comparer As IComparer = New RangeComparer
    Private Function DrawInMethod(ByVal pt As Point) As Boolean
        For Each method As ISyntaxNode In methods
            If (comparer.Compare(pt, method.Range) = 0) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cbMethodBkColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMethodBkColor.SelectedIndexChanged
        syntaxEdit1.Invalidate()
    End Sub

    Private Sub syntaxEdit1_HorizontalScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles syntaxEdit1.HorizontalScroll
        syntaxEdit1.Invalidate()
    End Sub
End Class
