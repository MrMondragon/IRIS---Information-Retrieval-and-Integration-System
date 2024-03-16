Imports System
Imports System.Drawing
Imports QWhale.Common
Imports QWhale.Syntax
Imports QWhale.Syntax.Parsers

Public Class VbClassBodyParser
    Inherits VbParser

    Private Const sEmptyClass As String = "EmptyClass"

    Protected Function ParseEmptyClass() As Boolean
        Dim result As Boolean = True
        Dim node As ISyntaxNode = New SyntaxNode(TokenPosition, TokenString, CType(NetNodeType.Class, Integer), SyntaxNodeOptions.BackIndentation)
        node.Name = sEmptyClass
        node.Options = node.Options Or SyntaxNodeOptions.CodeCompletion Or SyntaxNodeOptions.Outlining Or SyntaxNodeOptions.Indentation
        AddNode(node)

        SyntaxTree.Push(node)
        Try
            If (Not ParseClassBody()) Then
                result = False
            End If
        Finally
            SyntaxTree.Pop()
        End Try

        node.Range.EndPoint = prevPosition
        Return result
    End Function

    Protected Overrides Function ParseUnit() As Boolean
        Dim result As Boolean = True
        Dim node As ISyntaxNode = SyntaxTree.Root
        node.NodeType = CType(NetNodeType.Unit, Integer)
        node.Position = Point.Empty
        result = ParseEmptyClass()
        SyntaxTree.Root.Range.EndPoint = prevPosition

        If (Not ClearStack()) Then
            result = False
        End If
        If (Not FixupRegions(SyntaxTree.Current)) Then
            result = False
        End If
        Return result
    End Function

End Class

Public Class VbMethodBodyParser
    Inherits VbParser

    Private Const sEmptyMethod As String = "EmptyMethod"

    Protected Function ParseEmptyMethod() As Boolean
        Dim result As Boolean = True
        Dim node As ISyntaxNode = New SyntaxNode(TokenPosition, TokenString, CType(NetNodeType.Method, Integer), SyntaxNodeOptions.BackIndentation)
        node.Name = sEmptyMethod
        node.Options = node.Options Or SyntaxNodeOptions.CodeCompletion Or SyntaxNodeOptions.Outlining Or SyntaxNodeOptions.Indentation
        AddNode(node)

        SyntaxTree.Push(node)
        Try
            If (Not ParseMethodBody(node, CType(VbLexerToken.Sub, Integer))) Then
                result = False
            End If
        Finally
            SyntaxTree.Pop()
        End Try

        node.Range.EndPoint = prevPosition
        Return result
    End Function

    Public Overloads Function ReparseBlock(ByVal position As Point) As Boolean
        ReparseText()
        Return True
    End Function

    Protected Overrides Function ParseUnit() As Boolean
        Dim result As Boolean = True
        Dim node As ISyntaxNode = SyntaxTree.Root
        node.NodeType = CType(NetNodeType.Unit, Integer)
        node.Position = Point.Empty
        result = ParseEmptyMethod()
        SyntaxTree.Root.Range.EndPoint = prevPosition

        If (Not ClearStack()) Then
            result = False
        End If
        If (Not FixupRegions(SyntaxTree.Current)) Then
            result = False
        End If
        node.Range.EndPoint = prevPosition

        Return result
    End Function
End Class
