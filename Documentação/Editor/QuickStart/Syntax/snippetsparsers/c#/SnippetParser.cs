#region Copyright (c) 2004, 2005 Quantum Whale LLC.
/*
	Quantum Whale .NET Component Library
	Editor.NET Syntax Demo

	Copyright (c) 2004 Quantum Whale LLC.
	ALL RIGHTS RESERVED

	http://www.qwhale.net
	contact@qwhale.net
*/
#endregion Copyright (c) 2004 Quantum Whale LLC.

using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.IO;
using System.Xml.Serialization;
using QWhale.Common;
using QWhale.Syntax.Parsers;

namespace QWhale.Syntax
{
	public class CsClassBodyParser : CsParser
	{
		private const string sEmptyClass = "EmptyClass";
		protected override bool SkipToDeclarationStart(int nodeType)
		{
			if (nodeType == (int)NetNodeType.Class)
				return true;
			else
				return SkipTo((int)CsLexerToken.Open_brace);
		}
		protected override bool ParseDeclarationBodyEnd(ISyntaxNode node)
		{
			return (node.Name == sEmptyClass) || Expected(CsLexerToken.Close_brace);
		}
		protected bool ParseEmptyClass()
		{
			bool result = true;
			ISyntaxNode node = new SyntaxNode(TokenPosition, TokenString, (int)NetNodeType.Class, SyntaxNodeOptions.BackIndentation);
			node.Name = sEmptyClass;
			node.Options |= SyntaxNodeOptions.CodeCompletion;
			AddNode(node);

			if (!ParseDeclarationBody(node, (int)NetNodeType.Class))
				result = false;
			
			node.Range.EndPoint = prevPosition;
			return result;
		}
		protected override bool ParseUnit()
		{
			bool result = true;
			ISyntaxNode node =  SyntaxTree.Root;
			node.NodeType = (int)NetNodeType.Unit;
			node.Position = Point.Empty;
			result = ParseEmptyClass();
			SyntaxTree.Root.Range.EndPoint = prevPosition;
			
			if (!ClearStack())
				result = false;
			if (!FixupRegions(SyntaxTree.Current))
				result = false;
			return result;
		}
	}
	public class CsMethodBodyParser : CsParser
	{
		private void AddTestButton() 
		{ 
			SyntaxNode node = new SyntaxNode(TokenPosition, "testButton", (int)NetNodeType.Field, SyntaxNodeOptions.CodeCompletion);
			node.AddAttribute(new SyntaxAttribute(TokenPosition, NetNodeType.Type.ToString(), "Button")); 
			AddNode(node); 
		} 
		private const string sEmptyMethod = "EmptyMethod";
		protected bool ParseEmptyMethod()
		{
			bool result = true;
			ISyntaxNode node = new SyntaxNode(TokenPosition, string.Empty, (int)NetNodeType.Method, SyntaxNodeOptions.BackIndentation);
			node.Name = sEmptyMethod;
			node.Options |= SyntaxNodeOptions.CodeCompletion | SyntaxNodeOptions.Outlining | SyntaxNodeOptions.Indentation;
			AddNode(node);

			SyntaxTree.Push(node);
			try
			{
				AddTestButton();
				if (!ParseMethodBody())
					result = false;
			}
			finally
			{
				SyntaxTree.Pop();
			}
			
			node.Range.EndPoint = prevPosition;
			return result;
		}
		protected override bool ParseMethodBody()
		{
			bool result = true;
			if (!ParseBlockStatement())
				result = false;
			return result;
		}
		protected override bool ParseBlock()
		{
			bool result = true;
			Point pos = TokenPosition;
			bool isExpected = false;
			if (Token == (int)CsLexerToken.Open_brace)
			{
				MoveNext();
				isExpected = true;
			}

			AddAttribute(new SyntaxAttribute(pos, SyntaxConsts.BlockScope, null));
			AddAttribute(new SyntaxAttribute(pos, SyntaxConsts.DefinitionScope, null));

			if (Token != (int)CsLexerToken.Close_brace)
			{
				if (!ParseStatementList())
					result = false;
			}
			if (isExpected)
				if (Expected(CsLexerToken.Close_brace))
					AddAttribute(new SyntaxAttribute(prevPosition, SyntaxConsts.DefinitionScopeEnd, null));
				else
					result = false;
			return result;
		}

		protected override bool ParseUnit()
		{
			bool result = true;
			ISyntaxNode node =  SyntaxTree.Root;
			node.NodeType = (int)NetNodeType.Unit;
			node.Position = Point.Empty;
			result = ParseEmptyMethod();
			SyntaxTree.Root.Range.EndPoint = prevPosition;
			
			if (!ClearStack())
				result = false;
			if (!FixupRegions(SyntaxTree.Current))
				result = false;
			return result;
		}
		public override bool ReparseBlock(Point position)
		{
			ReparseText();
			return true;
		}
	}
}
