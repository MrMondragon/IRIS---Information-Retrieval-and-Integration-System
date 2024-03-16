#region Copyright (c) 2004, 2005 Quantum Whale LLC.
/*
	Quantum Whale .NET Component Library
	Editor.NET Library

	Copyright (c) 2004 Quantum Whale LLC.
	ALL RIGHTS RESERVED

	http://www.qwhale.net
	contact@qwhale.net
*/
#endregion Copyright (c) 2004 Quantum Whale LLC.using System;
using System;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;
using QWhale.Common;

[assembly:CLSCompliant(true)]

namespace QWhale.Syntax
{ 
	#region Delegates
	/// <summary>
	/// Represents a method that will handle the <c>CodeCompletionProvider.ClosePopup</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <c>ClosingEventArgs</c> that contains the event data.</param>
	public delegate void ClosePopupEvent(object sender, ClosingEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>CodeCompletionProvider.ShowPopup</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <c>ShowingEventArgs</c> that contains the event data.</param>
	public delegate void ShowPopupEvent(object sender, ShowingEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>ILexer.TextParsed</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <c>TextParsedEventArgs</c> that contains the event data.</param>
	public delegate void TextParsedEvent(object sender, TextParsedEventArgs e);
	/// <summary>
	/// Represents a method intendent to perform lexical analysis.
	/// </summary>
	public delegate int LexerProc();
	/// <summary>
	/// Represents a method that will handle the <c>CodeCompletionRepository.MemberLookup</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <c>MemberLookupEventArgs</c> that contains the event data.</param>
	public delegate void MemberLookupEvent(object sender, MemberLookupEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>CodeCompletionRepository.DescriptionLookup</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <c>DescriptionLookupEventArgs</c> that contains the event data.</param>
	public delegate void DescriptionLookupEvent(object sender, DescriptionLookupEventArgs e);
	#endregion

	#region Event Args
	#region CodeCompletion Args
	/// <summary>
	/// Provides data for the code completion events.
	/// </summary>
	public class CodeCompletionArgs : EventArgs
	{
		/// <summary>
		/// Represents the object that provides data for code completion.
		/// </summary>
		public ICodeCompletionProvider Provider;
		/// <summary>
		/// Represents the character typed in the Edit control.
		/// </summary>
		public char KeyChar;
		/// <summary>
		/// Represents type of code completion window.
		/// </summary>
		public CodeCompletionType CompletionType;
		/// <summary>
		/// Represents the delay, in miliiseconds before displaying code completion window. Set Interval to 0 to make code completion window appearing immediately.
		/// </summary>
		public int Interval;
		/// <summary>
		/// Represents a value indicating whether the CodeCompletion event is handled. If the event is handled, code completion box will not appear.
		/// </summary>
		public bool Handled;
		/// <summary>
		/// Represents a value indicating whether the code completion popup need showing.
		/// </summary>
		public bool NeedShow;
		/// <summary>
		/// Represents a value indicating whether code completion window should popup in the form of the tooltip.
		/// </summary>
		public bool ToolTip;
		/// <summary>
		/// Represents the index specifying the currently selected item of code completion box.
		/// </summary>
		public int SelIndex = - 1;
		/// <summary>
		/// Specifies position within the text where code competion window is valid.
		/// <seealso cref="QWhale.Syntax.CodeCompletionArgs.EndPosition"/>
		/// </summary>
		public Point StartPosition;
		/// <summary>
		/// Specifies position within the text where code competion window is valid.
		/// <seealso cref="QWhale.Syntax.CodeCompletionArgs.StartPosition"/>
		/// </summary>
		public Point EndPosition;
		/// <summary>
		/// Specifies position within the text where code competion window is displayed.
		/// <seealso cref="QWhale.Syntax.CodeCompletionArgs.StartPosition"/>
		/// </summary>
		public Point DisplayPosition;
		/// <summary>
		/// Specifies whether current scope should be reparsed when executing code completion request.
		/// </summary>
		public bool NeedReparse;
		/// <summary>
		/// Initializes <c>CodeCompletionArgs</c> with default values.
		/// </summary>
		public void Init()
		{
			CompletionType = CodeCompletionType.None;
			Provider = null;
			KeyChar = (char)0;
			ToolTip = false;
			Interval = 0;
			StartPosition = new Point(- 1, - 1);
			EndPosition = new Point(-1, - 1);
			DisplayPosition = new Point(- 1, - 1);
			Handled = false;
			NeedShow = false;
			NeedReparse = true;
			SelIndex = - 1;
		}
		/// <summary>
		/// Initializes <c>CodeCompletionArgs</c> with specified parameters.
		/// </summary>
		/// <param name="completionType">Specifies code completion type.</param>
		/// <param name="position">Specifies start position.</param>
		/// <param name="needReparse">Specifies whether current scope should be reparsed when executing code completion request.</param>
		public void Init(CodeCompletionType completionType, Point position, bool needReparse)
		{
			Init();
			this.CompletionType = completionType;
			this.StartPosition = position;
			this.DisplayPosition = position;
			this.NeedReparse = needReparse;
		}
		/// <summary>
		/// Initializes <c>CodeCompletionArgs</c> with specified parameters.
		/// </summary>
		/// <param name="completionType">Specifies code completion type.</param>
		/// <param name="position">Specifies start position.</param>
		public void Init(CodeCompletionType completionType, Point position)
		{
			Init(completionType, position, true);
		}

	}
	#endregion

	#region Showing EventArgs
	/// <summary>
	/// Provides data for the <c>ICodeCompletionProvider.ShowPopup</c> event.
	/// </summary>
	public class ShowingEventArgs : EventArgs
	{
		/// <summary>
		/// Represents the object that provides data for code completion window.
		/// </summary>
		public ICodeCompletionProvider Provider;
		/// <summary>
		/// Represents a value indicating whether the popup window needs showing.
		/// </summary>
		public bool NeedShow;
		/// <summary>
		/// Initializes a new instance of the <c>ShowingEventArgs</c> class with specific provider.
		/// </summary>
		/// <param name="provider">Specifies Provider property for this new instance.</param>
		public ShowingEventArgs(ICodeCompletionProvider provider)
		{
			Provider = provider;
			NeedShow = true;
		}
	}
	#endregion 

	#region Closing EventArgs
	/// <summary>
	/// Provides data for the <c>ICodeCompletionProvider.ClosePopup</c> event.
	/// </summary>
	public class ClosingEventArgs : EventArgs
	{
		/// <summary>
		/// Represents a value indicating whether the value displayed in CodeCompletion window should be accepted.
		/// </summary>
		public bool Accepted;
		/// <summary>
		/// Represents a value indicating whether the multi-line text should be indented when inserting to the edit control.
		/// </summary>
		public bool UseIndent = true;
		/// <summary>
		/// Represents the boolean value indicating whether popup should be closed or not.
		/// </summary>
		public bool Handled;
		/// <summary>
		/// Represents the string value that returned by popup being closed.
		/// </summary>
		public string Text;
		/// <summary>
		/// Represents the object that provides data for code completion.
		/// </summary>
		public ICodeCompletionProvider Provider;
		/// <summary>
		/// Initializes a new instance of the <c>ClosingEventArgs</c> class with the specific parameters.
		/// </summary>
		/// <param name="accepted">The boolean value that specifies whether the popup window input is accepted.</param>
		/// <param name="provider">Specifies the object that provides data for code completion.</param>
		public ClosingEventArgs(bool accepted, ICodeCompletionProvider provider)
		{
			Accepted = accepted;
			Provider = provider;
		}
	}
	#endregion
	
	#region Member Lookup Args
	/// <summary>
	/// Provides data for the <c>ICodeCompletionRepository.MemberLookup</c> event,
	/// used to search for the specified member.
	/// </summary>
	public class MemberLookupEventArgs : EventArgs
	{
		/// <summary>
		/// Represents an object containing members.
		/// </summary>
		public object Member;
		/// <summary>
		/// The String containing the name of the member to get. 
		/// </summary>
		public string Name;
		/// <summary>
		/// An object representing the member with the specified name, if found; otherwise, a null reference.
		/// </summary>
		public object Result;
		/// <summary>
		/// Specifies the search constraints. 
		/// </summary>
		public StaticScope Scope;
		/// <summary>
		/// Initializes a new instance of the <c>MemberLookupEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="member">Specifies Member property of this new instance.</param>
		/// <param name="name">Specifies Name property of this new instance.</param>
		public MemberLookupEventArgs(object member, string name)
		{
			Member = member;
			Name = name;
		}
	}
	#endregion 

	#region Description Lookup Args
	/// <summary>
	/// Provides data for the <c>ICodeCompletionRepository.DescriptionLookup</c> event,
	/// used to search for the description of specified member.
	/// </summary>
	public class DescriptionLookupEventArgs : EventArgs
	{
		/// <summary>
		/// Represents an object to lookup.
		/// </summary>
		public object Member;
		/// <summary>
		/// The String containing the name of the object. 
		/// </summary>
		public string Name;
		/// <summary>
		/// Result string representing description of the member.
		/// </summary>
		public string Description;
		/// <summary>
		/// Initializes a new instance of the <c>DescriptionLookupEventArgs</c> with specified parameters.
		/// </summary>
		/// <param name="member">Specifies Member property of this new instance.</param>
		/// <param name="name">Specifies Name property of this new instance.</param>
		public DescriptionLookupEventArgs(object member, string name)
		{
			Member = member;
			Name = name;
		}
	}
	#endregion 

	#region TextParsed EventArgs
	/// <summary>
	/// Provides data for the <c>ILexer.TextParsed</c> event.
	/// </summary>
	public class TextParsedEventArgs : EventArgs
	{
		/// <summary>
		/// Represents parsed text line.
		/// </summary>
		public string String;
		/// <summary>
		/// Represents color information for the parsed line.
		/// </summary>
		public short[] ColorData;
	}
	#endregion TextParsed EventArgs

	#endregion

	#region Enums
	/// <summary>
	/// Specifies the way in which the search for members and types is conducted by code completion repository.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum StaticScope
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None      = 0x0,
		/// <summary>
		/// Specifies that member to search is a static (belongs to the type itself rather than to a specific object).
		/// </summary>
		Static    = 0x1,
		/// <summary>
		/// Specifies that member is instance (belongs to the object).
		/// </summary>
		Instance  = 0x2,
		/// <summary>
		/// Specifies that member is global (belongs to the global module).
		/// </summary>
		Global    = 0x4,
		/// <summary>
		/// Specifies that member may be protected.
		/// </summary>
		Protected = 0x8,
		/// <summary>
		/// Specifies that member should display type name in code completion window.
		/// </summary>
		TypeName  = 0x10,
		/// <summary>
		/// Specifies that member should display event handler code completion window.
		/// </summary>
		Delegate  = 0x20,
		/// <summary>
		/// Specifies that member represents Reflection MethodBase.
		/// </summary>
		Method    = 0x40,
		/// <summary>
		/// Specifies that member represents Reflection PropertyInfo.
		/// </summary>
		Property  = 0x80, 
		/// <summary>
		/// Specifies that member represents Reflection FieldInfo.
		/// </summary>
		Field     = 0x100,
		/// <summary>
		/// Specifies that member should display type short name in rather full name. 
		/// Appropriate only if TypeName flag is on
		/// </summary>
		ShortType = 0x200,
		/// <summary>
		/// Specifies that member may be private.
		/// </summary>
		Private   = 0x400
 	}

	/// <summary>
	/// Specifies types of code completion window used to complete language elements.
	/// </summary>
	public enum CodeCompletionType
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None,
		/// <summary>
		/// Specifies that code completion window displayed to complete the rest of a variable, command, or function name once you have entered enough characters to disambiguate the term.
		/// </summary>
		CompleteWord,
		/// <summary>
		/// Specifies that code completion window displayed with a list of valid member variables or functions for the appropriate class, struct, union or namespace.
		/// </summary>
		ListMembers,
		/// <summary>
		/// Specifies that code completion window displayed with information about the number, names, and types of parameters required by a function or attribute.
		/// </summary>
		ParameterInfo,
		/// <summary>
		/// Specifies that code completion window displayed with information in a form of short description.
		/// </summary>
		QuickInfo,
		/// <summary>
		/// Specifies that code completion window displayed with a list of templates with commonly used programming statements that can be inserted into the code.
		/// </summary>
		CodeSnippets,
		/// <summary>
		/// Specifies spcial cases for code completion window.
		/// </summary>
		SpecialListMembers
	}

	/// <summary>
	/// Defines reason of updating control's text content.
	/// </summary>
	public enum UpdateReason
	{
		/// <summary>
		/// Specifies that current position in the control's text content changed.
		/// </summary>
		Navigate,
		/// <summary>
		/// Specifies that some text inserted.
		/// </summary>
		Insert,
		/// <summary>
		/// Specifies that some text deleted.
		/// </summary>
		Delete,
		/// <summary>
		/// Specifies that text line was broken into two lines.
		/// </summary>
		Break,
		/// <summary>
		/// Specifies that two lines concatenated.
		/// </summary>
		UnBreak,
		/// <summary>
		/// Specifies that some block of text deleted.
		/// </summary>
		DeleteBlock,
		/// <summary>
		/// Specifies that some block of text inserted.
		/// </summary>
		InsertBlock,
		/// <summary>
		/// Specifies another reason of the control's text content updating.
		/// </summary>
		Other
	}
	/// <summary>
	/// Defines possibilities of formatting Edit control's content.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum SyntaxOptions 
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None           = 0x0,
		/// <summary>
		/// Specifies that information about outline sections within the text is available.
		/// </summary>
		Outline        = 0x1,
		/// <summary>
		/// Specifies that information about indent level of each line in the text is available.
		/// </summary>
		SmartIndent    = 0x2,
		/// <summary>
		/// Specifies that information about code completion for language elements within the text is available.
		/// </summary>
		CodeCompletion = 0x4,
		/// <summary>
		/// Specifies that information about syntax errors within the text is available.
		/// </summary>
		SyntaxErrors   = 0x8,
		/// <summary>
		/// Specifies that text should be reparsed when the current line changes.
		/// </summary>
		ReparseOnLineChange = 0x10,
		/// <summary>
		/// Specifies that text quick info tooltip should be displayed when mouse is moved over control.
		/// </summary>
		QuickInfoTips  = 0x20,
		/// <summary>
		/// Specifies that parser will complete statements if possible.
		/// </summary>
		AutoComplete = 0x40
	}

	/// <summary>
	/// Defines types of lexical token that represents result lexical analysis of each element within the text.
	/// </summary>
	public enum LexToken
	{
		/// <summary>
		/// Specifies that lexical element represents identifier.
		/// </summary>
		Identifier,
		/// <summary>
		/// Specifies that lexical element represents number.
		/// </summary>
		Number,
		/// <summary>
		/// Specifies that lexical element represents key word.
		/// </summary>
		Resword,
		/// <summary>
		/// Specifies that lexical element represents comment.
		/// </summary>
		Comment,
		/// <summary>
		/// Specifies that lexical element represents xml comment.
		/// </summary>
		XmlComment,
		/// <summary>
		/// Specifies that lexical element represents particular symbol.
		/// </summary>
		Symbol,
		/// <summary>
		/// Specifies that lexical element represents blank space between other lexical tokens.
		/// </summary>
		Whitespace,
		/// <summary>
		/// Specifies that lexical element represents string literal.
		/// </summary>
		String,
		/// <summary>
		/// Specifies that lexical element represents directive.
		/// </summary>
		Directive
	}


	/// <summary>
	/// Defines snippet behaviour.
	/// </summary>
	public enum SnippetType
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None,
		/// <summary>
		/// Allows the code snippet to be placed around a selected piece of code
		/// </summary>
		SurroundsWith,
		/// <summary>
		/// Allows the code snippet to be inserted at the cursor.
		/// </summary>
		Expansion,
		/// <summary>
		/// Specifies that the code snippet is used during Visual C# refactoring. Refactoring cannot be used in custom code snippets.
		/// </summary>
		Refactoring
	}
	#endregion
	
	#region ParameterModifier
	/// <summary>
	/// Defines parameter modifiers.
	/// </summary>
	public enum ParameterModifer
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None       = 0x0,
		/// <summary>
		/// Specifies that parameter is optional.
		/// </summary>
		Optional   = 0x1,
		/// <summary>
		/// Specifies that parameter is in.
		/// </summary>
		In         = 0x2,
		/// <summary>
		/// Specifies that parameter is out.
		/// </summary>
		Out        = 0x4,
		/// <summary>
		/// Specifies that parameter is retval.
		/// </summary>
		Retval     = 0x8
	}
	#endregion
	
	#region Code Completion

	#region IOutlineRange
	/// <summary>
	/// Represents individual outlining section that can appear in the Edit control.
	/// </summary>
	public interface IOutlineRange : IRange
	{
		/// <summary>
		/// When implemented by a class, represents text substituting collapsed outline section.
		/// </summary>
		string Text
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents text substituting collapsed outline section if outline buttons are displayed.
		/// </summary>
		string DisplayText
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether outline section is visible (expanded).
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents level of outline nesting for the outline section.
		/// </summary>
		int Level
		{
			get;
			set;
		}
	}
	#endregion IOutlineRange

	#region ICodeCompletionProvider
	/// <summary>
	/// Represents properties and methods to provide data related to Code Completion popup listbox and popup hint controls.
	/// </summary>
	public interface ICodeCompletionProvider : IList
	{
		/// <summary>
		/// When implemented by a class, indicates whether specified column is visible.
		/// </summary>
		/// <param name="column">Specifies index of the column.</param>
		/// <returns>True if visible; otherwise false.</returns>
		bool ColumnVisible(int column);
		/// <summary>
		/// When implemented by a class, returns text from given item in the specified column.
		/// </summary>
		/// <param name="index">Specifies index of item.</param>
		/// <param name="column">Specifies index of column.</param>
		/// <returns>Text representing specified item.</returns>
		string GetColumnText(int index, int column);
		/// <summary>
		/// When implemented by a class, returns string representing default column.
		/// </summary>
		/// <param name="index">Index of item within collection.</param>
		/// <returns>Text representing default column.</returns>
		string GetText(int index);
		/// <summary>
		/// When implemented by a class, returns string reperesenting name of the item.
		/// </summary>
		/// <param name="index">Index of item within collection.</param>
		/// <returns>String representing name of specified item.</returns>
		string GetName(int index);
		/// <summary>
		/// When implemented by a class, returns index of item within collection by it's name.
		/// </summary>
		/// <param name="name">Specifies Name property of item to find.</param>
		/// <param name="caseSensitive">Indicates whether search should be case sensitive.</param>
		/// <returns>Index of found item.</returns>
		int IndexOfName(string name, bool caseSensitive);
		/// <summary>
		/// When implemented by a class, returns code completion provider owning this <c>ICodeCompletionProvider</c> instance.
		/// </summary>
		/// <returns>Parent of the <c>ICodeCompletionProvider</c>.</returns>
		ICodeCompletionProvider GetParent();
		/// <summary>
		/// When implemented by a class, saves content of the snippet to the specific file.
		/// </summary>
		/// <param name="fileName">Name of file to save content.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveFile(string fileName);
		/// <summary>
		/// When implemented by a class, saves content of the snippet to the specified stream.
		/// </summary>
		/// <param name="writer">The TextWriter object to write text to stream.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveStream(TextWriter writer);
		/// <summary>
		/// When implemented by a class, saves content of the snippet to the specified stream.
		/// </summary>
		/// <param name="stream">The Stream object to write the text.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveStream(Stream stream);
		/// <summary>
		/// When implemented by a class, loads the contents of the specified file into the snippet.
		/// </summary>
		/// <param name="fileName">Name of file to load.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadFile(string fileName);
		/// <summary>
		/// When implemented by a class, loads the contents of the specified stream into the snippet.
		/// </summary>
		/// <param name="reader">The TextReader object to read.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadStream(TextReader reader);
		/// <summary>
		/// When implemented by a class, loads the contents of the given stream into the snippet.
		/// </summary>
		/// <param name="Stream">The Stream object to read text.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadStream(Stream stream);
		/// <summary>
		/// When implemented by a class, sorts elements in the list
		/// </summary>
		void Sort();
		/// <summary>
		/// When implemented by a class, sorts elements in the list using the specified comparer.
		/// </summary>
		/// <param name="comparer">The <c>IComparer</c> implementation to use when comparing elements.</param>
		void Sort(IComparer comparer);
		/// <summary>
		/// When implemented by a class, occurs when popup control is closed.
		/// </summary>
		event ClosePopupEvent ClosePopup;
		/// <summary>
		/// When implemented by a class, occurs when popup control is displayed.
		/// </summary>
		event ShowPopupEvent ShowPopup;
		/// <summary>
		/// When implemented by a class, represents number of the columns.
		/// </summary>
		int ColumnCount
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to the text of default column.
		/// </summary>
		string[] Strings
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to the image index of each column.
		/// </summary>
		int[] ImageIndexes
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to the description of each column.
		/// </summary>
		string[] Descriptions
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether provider should display Description part in a form of tooltip near the popup control.
		/// </summary>
		bool ShowDescriptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents the index specifying the currently selected item of the popup control.
		/// </summary>
		int SelIndex
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the ImageList for code completion items.
		/// </summary>
		ImageList Images
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value indicating whether the multi-line text should be indented when inserting to the edit control.
		/// </summary>
		bool UseIndent
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value indicating whether html formatting tags may appear in the text.
		/// </summary>
		bool UseHtmlFormatting
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating editable field of the code completion provider.
		/// </summary>
		string EditField
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating path to the nested code completion provider.
		/// </summary>
		string EditPath
		{
			get;
		}
	}
	#endregion ICodeCompletionProvider

	#region ICodeSnippetHeader
	/// <summary>
	/// Represents properties and methods describing code snippet header.
	/// </summary>
	public interface ICodeSnippetHeader
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>ICodeSnippetHeader</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ICodeSnippetHeader</c> to assign.</param>
		void Assign(ICodeSnippetHeader source);
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies the title of the code snippet. Useful to find necessary item within the snippets collection.
		/// </summary>
		string Title
		{
			get;
			set;
		}
	
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies short description of the code snippet, that can help user to choose snippet from the popup window.
		/// </summary>
		string Description
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies author of the code snippet.
		/// </summary>
		string Author
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies shortut of the code snippet.
		/// This shortuct is replaced by entire snippet when user presses Tab in the editor.
		/// </summary>
		string Shortcut
		{
			get;
			set;
		}
		/// <summary>
		/// Specifies how the code snippet is inserted into the code.
		/// </summary>
		ICodeSnippetTypes Types
		{
			get;
		}
		
	}
	#endregion

	#region ICodeSnippetLiteral
	/// <summary>
	/// Represents properties and methods describing literal that make up the parts of a code snippet that you can edit.
	/// </summary>
	public interface ICodeSnippetLiteral
	{
		/// <summary>
		/// When implemented by a class, specifies the default value of the literal or object for an IntelliSense Code Snippet.
		/// </summary>
		string Default
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies a function to execute when the literal or object receives focus in the Editor.
		/// </summary>
		string Function
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies the unique identifier for the object or literal.
		/// </summary>
		string ID
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, Specifies the type of the object.
		/// </summary>
		string Type
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies the ToolTip description to be associated with the literal in the code snippet.
		/// </summary>
		string ToolTip
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies whether literal is editable or not.
		/// </summary>
		bool Editable
		{
			get;
			set;
		}
	}
	#endregion

	#region ICodeSnippetObject
	/// <summary>
	/// Represents properties and methods describing literal that make up the parts of a code snippet that you can edit.
	/// </summary>
	public interface ICodeSnippetObject : ICodeSnippetLiteral
	{
	}
	#endregion

	#region ICodeSnippetDeclaration
	/// <summary>
	/// Represents properties and methods describing literals and objects that make up the parts of a code snippet that you can edit.
	/// </summary>
	public interface ICodeSnippetDeclaration
	{
		/// <summary>
		/// When implemented by a class, defines the literals of the code snippet that you can edit
		/// </summary>
		ICodeSnippetLiterals Literals
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, defines the objects of the code snippet that you can edit. 
		/// </summary>
		ICodeSnippetObjects Objects
		{
			get;
		}
	}
	#endregion

	#region ICodeSnippetImport
	/// <summary>
	/// Represents imported namespace used by an IntelliSense Code Snippet.
	/// </summary>
	public interface ICodeSnippetImport
	{
		/// <summary>
		/// When inplemented by a class, specifies the namespace used by the code snippet
		/// </summary>
		string Namespace
		{
			get;
			set;
		}
	}
	#endregion

	#region ICodeSnippetReference
	/// <summary>
	/// Contains information about assembly references for the code snippet.
	/// </summary>
	public interface ICodeSnippetReference
	{
		/// <summary>
		/// When inplemented by a class, contains the name of the assembly referenced by the code snippet.
		/// </summary>
		string Assembly
		{
			get;
			set;
		}
		/// <summary>
		/// When inplemented by a class, contains a URL that provides more information about the referenced assembly.
		/// </summary>
		string Url
		{
			get;
			set;
		}
	}
	#endregion

	#region ICodeSnippetCode
	/// <summary>
	/// Specifies the code that you want to insert into a file.
	/// </summary>
	public interface ICodeSnippetCode
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>ICodeSnippetCode</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ICodeSnippetCode</c> to assign.</param>
		void Assign(ICodeSnippetCode source);
		/// <summary>
		/// When inplemented by a class, specifies the delimiter used to describe literals and objects in the code.
		/// </summary>
		string Delimiter
		{
			get;
			set;
		}
		/// <summary>
		/// When inplemented by a class, specifies the kind of code the snippet contains, and thus, where the snippet can be inserted. 
		/// </summary>
		string Kind
		{
			get;
			set;
		}
		/// <summary>
		/// When inplemented by a class, specifies the language of the code snippet.
		/// </summary>
		string Language
		{
			get;
			set;
		}
		/// <summary>
		/// When inplemented by a class, specifies the code that you want to insert into a file.
		/// </summary>
		string Code
		{
			get;
			set;
		}
	}
	#endregion

	#region ICodeSnippetType
	/// <summary>
	/// Specifies how the code snippet is inserted into the code.
	/// </summary>
	public interface ICodeSnippetType
	{
		/// <summary>
		/// When inplemented by a class, specifies how the code snippet is inserted into the code.
		/// </summary>
		SnippetType SnippetType
		{
			get;
			set;
		}
	}
	#endregion

    #region ICodeSnippetLiterals
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ICodeSnippetLiteral</c> objects.
	/// </summary>
	public interface ICodeSnippetLiterals : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ICodeSnippetLiterals</c> collection.
		/// </summary>
		/// <returns><c>ICodeSnippetLiteral</c> that is added.</returns>
		ICodeSnippetLiteral AddLiteral();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ICodeSnippetLiterals</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ICodeSnippetLiteral</c> that is inserted.</returns>
		ICodeSnippetLiteral InsertLiteral(int index);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ICodeSnippetLiteral</c> objects stored in the collection.
		/// </summary>
		new ICodeSnippetLiteral this[int index]
		{
			get;
		}
	}
	#endregion
	
	#region ICodeSnippetTypes
	/// <summary>
	/// Specifies how the code snippet is inserted into the code.
	/// </summary>
	public interface ICodeSnippetTypes : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ICodeSnippetTypes</c> collection.
		/// </summary>
		/// <returns><c>ICodeSnippetType</c> that is added.</returns>
		ICodeSnippetType AddSnippetType();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ICodeSnippetTypes</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ICodeSnippetType</c> that is inserted.</returns>
		ICodeSnippetType InsertSnippetType(int index);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ICodeSnippetType</c> objects stored in the collection.
		/// </summary>
		new ICodeSnippetType this[int index]
		{
			get;
		}
	}
	#endregion

	#region ICodeSnippetObjects
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ICodeSnippetObject</c> objects.
	/// </summary>
	public interface ICodeSnippetObjects : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ICodeSnippetObjects</c> collection.
		/// </summary>
		/// <returns><c>ICodeSnippetObject</c> that is added.</returns>
		ICodeSnippetObject AddObject();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ICodeSnippetObject</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ICodeSnippetObject</c> that is inserted.</returns>
		ICodeSnippetObject InsertObject(int index);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ICodeSnippetObject</c> objects stored in the collection.
		/// </summary>
		new ICodeSnippetObject this[int index]
		{
			get;
		}
	}
	#endregion

	#region ICodeSnippetDeclarations
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ICodeSnippetDeclaration</c> objects.
	/// </summary>
	public interface ICodeSnippetDeclarations : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ICodeSnippetDeclarations</c> collection.
		/// </summary>
		/// <returns><c>ICodeSnippetDeclaration</c> that is added.</returns>
		ICodeSnippetDeclaration AddDeclaration();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ICodeSnippetDeclarations</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ICodeSnippetDeclaration</c> that is inserted.</returns>
		ICodeSnippetDeclaration InsertDeclaration(int index);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ICodeSnippetDeclaration</c> objects stored in the collection.
		/// </summary>
		new ICodeSnippetDeclaration this[int index]
		{
			get;
		}
	}
	#endregion

	#region ICodeSnippetImports
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ICodeSnippetImport</c> objects.
	/// </summary>
	public interface ICodeSnippetImports : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ICodeSnippetImports</c> collection.
		/// </summary>
		/// <returns><c>ICodeSnippetImport</c> that is added.</returns>
		ICodeSnippetImport AddImport();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ICodeSnippetImports</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ICodeSnippetImport</c> that is inserted.</returns>
		ICodeSnippetImport InsertImport(int index);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ICodeSnippetImport</c> objects stored in the collection.
		/// </summary>
		new ICodeSnippetImport this[int index]
		{
			get;
		}
	}
	#endregion

	#region ICodeSnippetReferences
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ICodeSnippetReference</c> objects.
	/// </summary>
	public interface ICodeSnippetReferences : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ICodeSnippetReferences</c> collection.
		/// </summary>
		/// <returns><c>ICodeSnippetReference</c> that is added.</returns>
		ICodeSnippetReference AddReference();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ICodeSnippetReferences</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ICodeSnippetReference</c> that is inserted.</returns>
		ICodeSnippetReference InsertReference(int index);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ICodeSnippetReference</c> objects stored in the collection.
		/// </summary>
		new ICodeSnippetReference this[int index]
		{
			get;
		}
	}
	#endregion
	
	#region ICodeSnippet
	/// <summary>
	/// Represents properties and methods describing particular code snippet in the snippets collection.
	/// </summary>
	public interface ICodeSnippet : IComparable
	{
		/// <summary>
		/// When implemented by a class, gets a header associated with the snippet.
		/// </summary>
		ICodeSnippetHeader Header
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies the literals and objects that make up the parts of a code snippet that you can edit.
		/// </summary>
		ICodeSnippetDeclarations Declarations
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, contains the imported namespaces for the code snippet
		/// </summary>
		ICodeSnippetImports Imports
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, contains information about assembly references for the code snippet
		/// </summary>
		ICodeSnippetReferences References
		{
			get;
		}

		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies code of the template. The code completion control, that holds a templates collection inserts code when user accepts the input.
		/// </summary>
		ICodeSnippetCode Code
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets description of the <c>ICodeSnippet</c>.
		/// </summary>
		string Description
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the index of the image displayed for the template.
		/// </summary>
		int ImageIndex
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an object that can hold a user defined data attached to the template.
		/// </summary>
		object CustomData
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a parent of the <c>ICodeSnippet</c>.
		/// </summary>
		ICodeSnippets Parent
		{
			get;
			set;
		}
	}
	#endregion ICodeSnippet

	#region ICodeSnippetsProvider
	/// <summary>
	/// Represents base interface for code snippets provider.
	/// </summary>
	public interface ICodeSnippetsProvider : ICodeCompletionProvider
	{
		/// <summary>
		/// When implemented by a class, gets a code snippet by its shortcut.
		/// </summary>
		ICodeSnippet FindByShortcut(string shortcut, bool caseSensitive);
	}
	#endregion

	#region ICodeSnippets
	/// <summary>
	/// Represents collection containing list of code snippets.
	/// </summary>
	public interface ICodeSnippets : ICodeSnippetsProvider
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the <c>ICodeSnippets</c> collection.
		/// </summary>
		/// <returns><c>ICodeSnippet</c> that is added.</returns>
		ICodeSnippet AddSnippet();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ICodeSnippets</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ICodeSnippet</c> that is inserted.</returns>
		ICodeSnippet InsertSnippet(int index);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ICodeSnippet</c> objects stored in the collection.
		/// </summary>
		new ICodeSnippet this[int index]
		{
			get;
		}
	}
	#endregion 

	#region ICodeSnippetMember 
	/// <summary>
	/// Represents properties and methods for a particular code snippet member in the data collection of the code completion popups.
	/// </summary>
	public interface ICodeSnippetMember : IComparable
	{
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies the name of the <c>IListMember</c>. Useful to find necessary item within the <c>ICodeSnippetMember</c> collection.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets a string value that specifies the full path of the <c>IListMember</c>. 
		/// </summary>
		string EditPath
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies the path to the file containing source of the <c>ICodeSnippetMember</c>.
		/// </summary>
		string Path
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the index of the image displayed for the <c>ICodeSnippetMember</c>.
		/// </summary>
		int ImageIndex
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to the nested <c>ICodeSnippetMember</c> objects.
		/// </summary>
		ICodeSnippetMembers Members
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to the nested <c>ICodeSnippet</c> objects.
		/// </summary>
		ICodeSnippets Snippets
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to the nested <c>ICodeSnippet</c> and <c>ICodeSnippetMember</c> objects.
		/// </summary>
		ICodeSnippetsProvider SnippetsAndMembers
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a parent of the <c>ICodeSnippetMember</c>.
		/// </summary>
		ICodeSnippetMembers Parent
		{
			get;
			set;
		}
	}
	#endregion

	#region ICodeSnippetMembers
	/// <summary>
	/// Represents collection containing list of code snippets.
	/// </summary>
	public interface ICodeSnippetMembers : ICodeSnippetsProvider
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the <c>ICodeSnippetMembers</c> collection.
		/// </summary>
		/// <returns><c>ICodeSnippetMember</c> that is added.</returns>
		ICodeSnippetMember AddSnippetMember();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ICodeSnippetMembers</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ICodeSnippetMember</c> that is inserted.</returns>
		ICodeSnippetMember InsertSnippetMember(int index);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ICodeSnippetMember</c> objects stored in the collection.
		/// </summary>
		new ICodeSnippetMember this[int index]
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a parent of the <c>ICodeSnippetMembers</c>.
		/// </summary>
		ICodeSnippetMember Parent
		{
			get;
			set;
		}

	}
	#endregion 

	#region IParameterMember
	/// <summary>
	/// Represents properties for a particular parameter member within list member parameters.
	/// </summary>
	public interface IParameterMember
	{
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies name of the <c>IParameterMember</c>.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies datatype of the <c>IParameterMember</c>.
		/// </summary>
		string DataType
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies short description of the <c>IParameterMember</c>.
		/// </summary>
		string Description
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies parameter modifier of the <c>IParameterMember</c>.
		/// </summary>
		string Qualifier
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an string value that specifies text of the <c>IParameterMember</c>.
		/// </summary>
		string Text
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies parameter modifier.
		/// </summary>
		ParameterModifer Modifiers
		{
			get;
			set;
		}
	}
	#endregion IParameterMember

	#region IListMember
	/// <summary>
	/// Represents properties and methods for a particular list member in the data collection of the code completion popups.
	/// </summary>
	public interface IListMember : IComparable
	{
		/// <summary>
		/// When implemented by a class, return member's description.
		/// </summary>
		/// <returns>String value that describes itself.</returns>
		string GetOwnDescription();
		/// <summary>
		/// When implemented by a class, updates Parameter text.
		/// </summary>
		void UpdateParamText();
		/// <summary>
		/// Converts <c>Parameters</c> property to a single string.
		/// </summary>
		/// <param name="useFormatting">Specifies whether to use html formatting.</param>
		/// <returns>Returns <c>Parameters</c> in the form of comma separated text, framed by parens.</returns>
		string GetParamText(bool useFormatting);
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies the name of the <c>IListMember</c>. Useful to find necessary item within the <c>IListMember</c> collection.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value displayed as a "name" part of <c>IListMember</c>.
		/// </summary>
		string DisplayText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies data type of the <c>IListMember</c>.
		/// </summary>
		string DataType
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies short description of the <c>IListMember</c>.
		/// </summary>
		string Description
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies access modifiers of the <c>IListMember</c>.
		/// </summary>
		string Qualifier
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets number of overloading members <c>IListMember</c> in the collection.
		/// </summary>
		int Overloads
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an object that can hold a user defined data attached to the <c>IListMember</c>.
		/// </summary>
		object CustomData
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies comma separated list of parameters of the <c>IListMember</c>.
		/// </summary>
		string ParamText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a collection of parameters of this <c>IListMember</c>.
		/// </summary>
		IParameterMember[] Parameters
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets index of current parameter in the parameters collection.
		/// </summary>
		int CurrentParamIndex
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether <c>IListMember</c> Description property should return GetOwnDescription.
		/// </summary>
		bool OwnDescription
		{
			get;
			set;
		}
        /// <summary>
        /// When implemented by a class, gets or sets a string value that represent default description text for <c>ListMember</c>
        /// </summary>
        string OwnDescriptionText
        {
            get;
            set;
        }
		/// <summary>
		/// When implemented by a class, gets or sets the index of the image displayed for the <c>IListMember</c>.
		/// </summary>
		int ImageIndex
		{
			get;
			set;
		}
		/// <summary>
		/// Wnen implemented by a class, gets IListMembers instance owning the <c>ListMember</c>.
		/// </summary>
		IListMembers Owner
		{
			get;
			set;
		}
	}
	#endregion IListMember

	#region IListMembers
	/// <summary>
	/// Represents data collection related to popup list box controls.
	/// </summary>
	public interface IListMembers : ICodeCompletionProvider
	{
		/// <summary>
		/// Initializes a new instance of the <c>ListMember</c> class with default settings.
		/// </summary>
		/// <returns><c>IListMember</c> that represents this new instance.</returns>
		IListMember CreateListMember();
		/// <summary>
		/// When implemented by a class, adds a new item to the <c>IListMembers</c> collection.
		/// </summary>
		/// <returns><c>IListMember</c> that is added.</returns>
		IListMember AddMember();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>IListMembers</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>IListMember</c> that is inserted.</returns>
		IListMember InsertMember(int index);
		/// <summary>
		/// When implemented by a class, returns item from <c>IListMembers</c> collection by specified Index.
		/// </summary>
		/// <param name="index">Specifies index of <c>IListMember</c> to return.</param>
		/// <returns><c>IListMember</c> at specified index.</returns>
		IListMember GetListMember(int index);
		/// <summary>
		/// When implemented by a class, resets the <c>ShowQualifiers</c> to the default value.
		/// </summary>
		void ResetShowQualifiers();
		/// <summary>
		/// When implemented by a class, resets the <c>ShowResults</c> to the default value.
		/// </summary>
		void ResetShowResults();
		/// <summary>
		/// When implemented by a class, resets the <c>ShowParams</c> to the default value.
		/// </summary>
		void ResetShowParams();
		/// <summary>
		/// When implemented by a class, resets the <c>ShowHints</c> to the default value.
		/// </summary>
		void ResetShowHints();
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>IListMember</c> objects stored in the collection.
		/// </summary>
		new IListMember this[int index]
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the "Qualifiers" column is visible.
		/// </summary>
		bool ShowQualifiers
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the "Results" column is visible.
		/// </summary>
		bool ShowResults
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the "Params" column is visible.
		/// </summary>
		bool ShowParams
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether popup listbox should display additional information for selected list member.
		/// </summary>
		bool ShowHints
		{
			get;
			set;
		}
	}
	#endregion IListMembers

	#region IQuickInfo
	/// <summary>
	/// Represents simple text data related to popup hint.
	/// </summary>
	public interface IQuickInfo : ICodeCompletionProvider
	{
		/// <summary>
		/// When implemented by a class, gets or sets content of the <c>IQuickInfo</c>.
		/// </summary>
		string Text
		{
			get;
			set;
		}
	}
	#endregion IQuickInfo

	#region IParameterInfo
	/// <summary>
	/// Represents Parameter Info data related to popup hint controls.
	/// </summary>
	public interface IParameterInfo : IListMembers
	{
		//
	}
	#endregion IParameterInfo

	#endregion Code Completion

	#region Lexer
	// Lexer
	#region ILexer
	/// <summary>
	/// Represents properties and methods for performing lexical analysis of the specified text.
	/// </summary>
	public interface ILexer
	{
		/// <summary>
		/// When implemented by a class, performs lexical analysis of given text.
		/// </summary>
		/// <param name="state">Specifies start lexical state.</param>
		/// <param name="line">Specifies current line within the text.</param>
		/// <param name="str">Text to analyse.</param>
		/// <param name="colorData">Receives color data representing lexical information of the given text.</param>
		/// <returns>Final lexical state.</returns>
		int ParseText(int state, int line, string str, ref short[] colorData);
		/// <summary>
		/// When implemented by a class, performs lexical analysis of given text.
		/// </summary>
		/// <param name="state">Specifies start lexical state.</param>
		/// <param name="line">Specifies current line within the text.</param>
		/// <param name="str">Text to analyse.</param>
		/// <param name="pos">Starting position.</param>
		/// <param name="len">Integer value to receive length of parsed element.</param>
		/// <param name="style">Retrieves style of text being parsed.</param>
		/// <returns>Final lexical state.</returns>
		int ParseText(int state, int line, string str, ref int pos, ref int len, ref int style);
		/// <summary>
		/// When implemented by a class, saves <c>ILexScheme</c> to the specified file.
		/// </summary>
		/// <param name="fileName">Name of the file to save the scheme.</param>
		void SaveScheme(string fileName);
		/// <summary>
		/// When implemented by a class, loads <c>ILexScheme</c> from the specified file.
		/// </summary>
		/// <param name="fileName">Name of the file to load the scheme.</param>
		void LoadScheme(string fileName);
		/// <summary>
		/// When implemented by a class, saves <c>ILexScheme</c> to the specified destination.
		/// </summary>
		/// <param name="writer">The TextWriter object to write the scheme.</param>
		void SaveScheme(TextWriter writer);
		/// <summary>
		/// When implemented by a class, loads <c>ILexScheme</c> from the specified source.
		/// </summary>
		/// <param name="reader">The TextReader object to read the scheme.</param>
		void LoadScheme(TextReader reader);
		
		/// <summary>
		/// When implemented by a class, resets the <c>DefaultState</c> to the default value.
		/// </summary>
		void ResetDefaultState();
		
		/// <summary>
		/// When implemented by a class, gets or sets list of rules for lexical analysis.
		/// </summary>
		ILexScheme Scheme
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an xml representation of <c>Scheme</c> property.
		/// </summary>
		string XmlScheme
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets default state of the <c>ILexer</c>.
		/// </summary>
		int DefaultState
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when text line is parsed, allowing to modify colors/styles information about the parsed line.
		/// </summary>
		event TextParsedEvent TextParsed;
	}
	#endregion ILexer
	#region IColorThemes
	/// <summary>
	/// Properties and methods that represent a collection of color themes.
	/// </summary>
	public interface IColorThemes : ICloneable
	{
		/// <summary>
		/// When implemented by a class, gets or sets the index of the
		/// active ColorTheme.
		/// </summary>
		int ActiveThemeIndex
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets the active ColorTheme.
		/// </summary>
		IColorTheme ActiveTheme
		{
			get;
			set;
		}
        
		/// <summary>
		/// When implemented by a class, adds a ColorTheme object to the collection.
		/// </summary>
		/// <param name="colorTheme">ColorTheme object.</param>
		void Add(IColorTheme colorTheme);

		/// <summary>
		/// When implemented by a class, removes the ColorTheme object at the specified index.
		/// </summary>
		/// <param name="name">Index of the ColorTheme object to remove.</param>
		/// <returns>true - index parameter was valid and ColorTheme object was removed. false - index parameter was invalid and no ColorTheme object was removed.</returns>
		bool Remove(int index);
		/// <summary>
		/// When implemented by a class, gets or sets an array of objects that implement IColorTheme.
		/// </summary>
		IColorTheme[] Themes
		{
			get;
			set;
		}
		void Clear();
	}
	#endregion IColorThemes

	#region IColorTheme
	/// <summary>
	/// Properties and methods for representing a single color theme.
	/// </summary>
	public interface IColorTheme : ICloneable
	{
		/// <summary>
		/// When implemented by a class, gets or sets the name of the color theme.
		/// </summary>
		string Name
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets a bool value that indicates
		/// whether or not the color theme should be modified.
		/// </summary>
		bool ReadOnly
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets the font used for the color theme.
		/// </summary>
		Font Font
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets the LexStyle array used for the 
		/// color theme.
		/// </summary>
		LexStyle[] LexStyles
		{
			get;
			set;
		}       
		/// <summary>
		/// When implemented by a class, determines whether the LexStyle array contains a specific lex style using the name of the lex style.
		/// </summary>
		/// <param name="lexStyleName">Name of the LexStyle object such as "idents".</param>
		/// <returns>true - array contains the specified LexStyle object, false - array does not contain the specified LexStyle object.</returns>
		bool Contains(string lexStyleName);

		/// <summary>
		/// When implemented by a class, specifies an Item indexer that uses the name of the LexStyle as an index.
		/// </summary>
		/// <param name="lexStyleName">Name of the LexStyle such as "ident".</param>
		/// <returns>LexStyle object that corresponds to the name parameter, or null for an invalid name.</returns>
		ILexStyle this[string lexStyleName]
		{
			get;
			set;
		}
	}
	#endregion IColorTheme

	#region ILexStyle
	/// <summary>
	/// Represents properties and methods for individual lexical style with the collection of lexical styles.
	/// </summary>
	public interface ILexStyle
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>ILexStyle</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ILexStyle</c> to assign.</param>
		void Assign(ILexStyle source);
		
		/// <summary>
		/// When implemented by a class, resets the <c>ForeColor</c> to the default value.
		/// </summary>
		void ResetForeColor();
		/// <summary>
		/// When implemented by a class, resets the <c>BackColor</c> to the default value.
		/// </summary>
		void ResetBackColor();
		/// <summary>
		/// When implemented by a class, resets the <c>FontStyle</c> to the default value.
		/// </summary>
		void ResetFontStyle();
		/// <summary>
		/// When implemented by a class, resets the <c>PlainText</c> to the default value.
		/// </summary>
		void ResetPlainText();
		/// <summary>
		/// When implemented by a class, gets or sets name of the <c>ILexStyle</c>.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a description of the <c>ILexStyle</c>.
		/// </summary>
		string Desc
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a foreground color of the <c>ILexStyle</c>.
		/// </summary>
		Color ForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a background color of the <c>ILexStyle</c>.
		/// </summary>
		Color BackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a font style of the <c>ILexStyle</c>.
		/// </summary>
		FontStyle FontStyle
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a flag that indicates whether the GUI control 
		/// that corresponds to the ForeColor property should be enabled or disabled.
		/// </summary>
		bool ForeColorEnabled
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets a flag that indicates whether the GUI control 
		/// that corresponds to the BackColor property should be enabled or disabled.
		/// </summary>
		bool BackColorEnabled
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets a flag that indicates whether the GUI control 
		/// that corresponds to the Bold property should be enabled or disabled.
		/// </summary>
		bool BoldEnabled
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets a flag that indicates whether the GUI control 
		/// that corresponds to the Italic property should be enabled or disabled.
		/// </summary>
		bool ItalicEnabled
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets a flag that indicates whether the GUI control 
		/// that corresponds to the Underline property should be enabled or disabled.
		/// </summary>
		bool UnderlineEnabled
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets value indicating whether Edit control should use text formatting rules, like checking spelling.
		/// </summary>
		bool PlainText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents index of the <c>ILexStyle</c> within the lexical style collection.
		/// </summary>
		int Index
		{
			get;
		}
	}
	#endregion ILexStyle

	#region ILexStyles
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ILexStyle</c> objects.
	/// </summary>
	public interface ILexStyles : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ILexStyles</c> collection.
		/// </summary>
		/// <returns><c>ILexStyle</c> that is added.</returns>
		ILexStyle AddLexStyle();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ILexStyles</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ILexStyle</c> that is inserted.</returns>
		ILexStyle InsertLexStyle(int index);
		/// <summary>
		/// When implemented by a class, finds <c>ILexStyle</c> by its name.
		/// </summary>
		/// <param name="name">Name of the <c>ILexStyle</c>.</param>
		/// <returns><c>ILexStyle</c> that is found.</returns>
		ILexStyle FindLexStyle(string name);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ILexStyle</c> objects stored in the collection.
		/// </summary>
		new ILexStyle this[int index]
		{
			get;
		}
	}
	#endregion

	#region ILexStates
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ILexState</c> objects.
	/// </summary>
	public interface ILexStates : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ILexStates</c> collection.
		/// </summary>
		/// <returns><c>ILexState</c> that is added.</returns>
		ILexState AddLexState();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ILexStates</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ILexState</c> that is inserted.</returns>
		ILexState InsertLexState(int index);
		/// <summary>
		/// When implemented by a class, finds <c>ILexState</c> by its name.
		/// </summary>
		/// <param name="name">Name of the <c>ILexState</c>.</param>
		/// <returns><c>ILexState</c> that is found.</returns>
		ILexState FindLexState(string name);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ILexState</c> objects stored in the collection.
		/// </summary>
		new ILexState this[int index]
		{
			get;
		}
	}
	#endregion

	#region ILexSyntaxBlocks
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ILexSyntaxBlock</c> objects.
	/// </summary>
	public interface ILexSyntaxBlocks : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ILexReswordSets</c> collection.
		/// </summary>
		/// <returns><c>ILexSyntaxBlock</c> that is added.</returns>
		ILexSyntaxBlock AddLexSyntaxBlock();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ILexSyntaxBlocks</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ILexSyntaxBlock</c> that is inserted.</returns>
		ILexSyntaxBlock InsertLexSyntaxBlock(int index);
		/// <summary>
		/// When implemented by a class, finds <c>ILexSyntaxBlock</c> by its name.
		/// </summary>
		/// <param name="name">Specifis name of the <c>ILexSyntaxBlock</c>.</param>
		/// <returns><c>ILexSyntaxBlock</c> that is found.</returns>
		ILexSyntaxBlock FindSyntaxBlock(string name);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ILexSyntaxBlock</c> objects stored in the collection.
		/// </summary>
		new ILexSyntaxBlock this[int index]
		{
			get;
		}
	}
	#endregion


	#region ILexReswordSets
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>ILexReswordSet</c> objects.
	/// </summary>
	public interface ILexReswordSets : IList
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the specified position within the <c>ILexReswordSets</c> collection.
		/// </summary>
		/// <returns><c>ILexReswordSet</c> that is added.</returns>
		ILexReswordSet AddLexReswordSet();
		/// <summary>
		/// When implemented by a class, inserts a new item to the specified position within the <c>ILexReswordSets</c> collection.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <returns><c>ILexReswordSet</c> that is inserted.</returns>
		ILexReswordSet InsertLexReswordSet(int index);
		/// <summary>
		/// When implemented by a class, locates <c>ILexReswordSet</c> containing given resword.
		/// </summary>
		/// <param name="resword">The resword to search for.</param>
		/// <returns>Index of <c>ILexReswordSet</c> if resword collection contains specified resword; otherwise - 1.</returns>
		int FindResword(string resword);
		/// <summary>
		/// When implemented by a class, provides an indexed access to <c>ILexReswordSet</c> objects stored in the collection.
		/// </summary>
		new ILexReswordSet this[int index]
		{
			get;
		}
	}
	#endregion


	#region ILexScheme
	/// <summary>
	/// Represents properties and methods to specify rules for text lexical analysis.
	/// </summary>
	public interface ILexScheme
	{
		/// <summary>
		/// When implemented by a class, indicates whether <c>ILexScheme</c> is empty , that is does not contain any styles, states, author, copyright, and description information.
		/// </summary>
		/// <returns></returns>
		bool IsEmpty();
		/// <summary>
		/// When implemented by a class, indicates whether <c>PlainText</c> property of lexical style given by its index is true.
		/// </summary>
		/// <param name="style">index of lexical style to check-up.</param>
		/// <returns>True if lexical style <c>PlainText</c> property is true; otherwise false.</returns>
		bool IsPlainText(int style);
		/// <summary>
		/// When implemented by a class, removes all states and styles from this <c>LexScheme</c> and sets other properties to default values.
		/// </summary>
		void ClearScheme();
		/// <summary>
		/// When implemented by a class, gets or sets author of the <c>ILexScheme</c>.
		/// </summary>
		string Author
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets <c>ILexScheme</c> name.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets description of the <c>ILexScheme</c>.
		/// </summary>
		string Desc
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets copyright of the <c>ILexScheme</c>.
		/// </summary>
		string Copyright
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets string value indicating associated file extension of the <c>ILexScheme</c>.
		/// </summary>
		string FileExtension
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets string value indicating associated file type of the <c>ILexScheme</c>.
		/// </summary>
		string FileType
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets version of the <c>ILexScheme</c>.
		/// </summary>
		string Version
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets collection of lexical styles.
		/// </summary>
		ILexStyles LexStyles
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets collection of lexical states.
		/// </summary>
		ILexStates LexStates
		{
			get;
		}
	}
	#endregion ILexScheme

	#region ILexReswordSet
	/// <summary>
	/// Represents properties and methods to specify keywords for <c>ILexSyntaxBlock.LexReswordSets</c> collection.
	/// </summary>
	public interface ILexReswordSet
	{
		/// <summary>
		/// When implemented by a class, adds a new element to the resword collection.
		/// </summary>
		/// <param name="resword">Resword to add.</param>
		/// <returns>Index of added element in the resword collection.</returns>
		int AddResword(string resword);
		/// <summary>
		/// When implemented by a class, locates given resword in Reswords collection.
		/// </summary>
		/// <param name="resword">Resword to locate.</param>
		/// <returns>True if resword presents in the Reswords collection; otherwise false.</returns>
		bool FindResword(string resword);
		/// <summary>
		/// When implemented in a class, removes all items from Reswords collection.
		/// </summary>
		void Clear();
		/// <summary>
		/// When implemented in a class, gets or set name for the <c>ILexReswordSet</c>.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an <c>ILexStyle</c> of resword collection.
		/// </summary>
		ILexStyle ReswordStyle
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a collection of keywords for the <c>ILexReswordSet</c>.
		/// </summary>
		string[] Reswords
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents index of the <c>ILexReswordSet</c> within the reswords collection.
		/// </summary>
		int Index
		{
			get;
		}
	}
	#endregion ILexReswordSet

	#region ILexSyntaxBlock
	/// <summary>
	/// Represents properties and methods for individual syntax block with collection of syntax blocks.
	/// </summary>
	public interface ILexSyntaxBlock
	{
		/// <summary>
		/// Locates <c>LexReswordSet</c> containing given resword.
		/// </summary>
		/// <param name="resword">The resword to search for.</param>
		/// <returns>Index of <c>LexReswordSet</c> if resword collection contains specified resword; otherwise - 1.</returns>
		int FindResword(string resword);
		/// <summary>
		/// When implemented by a class, adds new element to the expression collection.
		/// </summary>
		/// <param name="expression">Regular expression to add.</param>
		/// <returns>Index of added element in the expression collection.</returns>
		int AddExpression(string expression);
		/// <summary>
		/// When implemented by a class, gets or sets name of the <c>ILexSyntaxBlock</c>.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets description of the <c>ILexSyntaxBlock</c>.
		/// </summary>
		string Desc
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an <c>ILexStyle</c> object, applicable for text that matches <c>ILexSyntaxBlock</c> expression.
		/// </summary>
		ILexStyle Style
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets <c>ILexState</c> object that specifies lexical resulting state after lexical analyzer locates text, that matches to the <c>ILexSyntaxBlock.Expression</c>.
		/// </summary>
		ILexState LeaveState
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets collection of the <c>ILexReswordSet</c> object containing reserwed words.
		/// </summary>
		ILexReswordSets LexReswordSets
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets collection of the expressions used by <c>ILexer</c> to parse the text.
		/// </summary>
		string[] Expressions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents a collective regular expression pattern for the <c>ILexSyntaxBlock.Expressions</c>.
		/// </summary>
		string Expression
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents index of the <c>ILexSyntaxBlock</c> within the lexical syntax block collection.
		/// </summary>
		int Index
		{
			get;
		}
	}
	#endregion ILexSyntaxBlock

	#region ILexState
	/// <summary>
	/// Represents properties and methods for individual lexical state with collection of lexical states.
	/// </summary>
	public interface ILexState
	{
		/// <summary>
		/// When implemented by a class, resets the <c>CaseSensitive</c> to the default value.
		/// </summary>
		void ResetCaseSensitive();
		/// <summary>
		/// When implemented by a class, gets or sets name of the <c>ILexState</c>.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets description of the <c>ILexState</c>.
		/// </summary>
		string Desc
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the analizer should perform case sensitive parsing for this <c>ILexState</c>.
		/// </summary>
		bool CaseSensitive
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents a collective regular expression pattern for the <c>ILexState</c>.
		/// </summary>
		string Expression
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a collection of lexical syntax blocks.
		/// </summary>
		ILexSyntaxBlocks LexSyntaxBlocks
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a regular expression that contains <c>Expression</c> as a pattern.
		/// </summary>
		Regex Regex
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents index of the <c>ILexState</c> within the lexical state collection.
		/// </summary>
		int Index
		{
			get;
		}
	}
	#endregion ILexState
	#endregion Lexer
	#region Parser
	

	#region IExport
	/// <summary>
	/// Represents methods to save text content.
	/// </summary>
	public interface IExport
	{
		/// <summary>
		/// When implemented by a class, saves text content to the specific file.
		/// </summary>
		/// <param name="fileName">Name of file to save content.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveFile(string fileName);
		/// <summary>
		/// When implemented by a class, saves text content to the specific file with specific encoding.
		/// </summary>
		/// <param name="fileName">Name of file to save content.</param>
		/// <param name="encoding">Specifies the character encoding to use.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveFile(string fileName, Encoding encoding);
		/// <summary>
		/// When implemented by a class, saves the text content to the specified stream.
		/// </summary>
		/// <param name="writer">The TextWriter object to write text to stream.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveStream(TextWriter writer);
		/// <summary>
		/// When implemented by a class, saves the text content to the specified stream.
		/// </summary>
		/// <param name="stream">The Stream object to write the text.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveStream(Stream stream);
		/// <summary>
		/// When implemented by a class, saves the text content to the specified stream.
		/// </summary>
		/// <param name="stream">The Stream object to write the text.</param>
		/// <param name="encoding">Specifies the character encoding to use.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveStream(Stream stream, Encoding encoding);
	}
	#endregion IExport

	#region IImport
	/// <summary>
	/// Represents methods to load text content.
	/// </summary>
	public interface IImport
	{
		/// <summary>
		/// When implemented by a class, loads the contents of the specified file.
		/// </summary>
		/// <param name="fileName">Name of file to load text.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadFile(string fileName);
		/// <summary>
		/// When implemented by a class, loads the contents of the specified file with specified encoding.
		/// </summary>
		/// <param name="fileName">Name of file to load text.</param>
		/// <param name="encoding">Specifies the character encoding to use.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadFile(string fileName, Encoding encoding);
		/// <summary>
		/// When implemented by a class, loads the contents of the specified stream.
		/// </summary>
		/// <param name="reader">The TextReader object to read text.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadStream(TextReader reader);
		/// <summary>
		/// When implemented by a class, loads the contents of the specified stream.
		/// </summary>
		/// <param name="stream">The Stream object to read text.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadStream(Stream stream);
		/// <summary>
		/// When implemented by a class, loads the contents of the specified stream.
		/// </summary>
		/// <param name="stream">The Stream object to read text.</param>
		/// <param name="encoding">Specifies the character encoding to use.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadStream(Stream stream, Encoding encoding);
	}
	#endregion IImport

	#region IStringList
	/// <summary>
	/// Represents collection containing list of strings.
	/// </summary>
	public interface IStringList : ICollection, IEnumerable, IImport, IExport
	{
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual strings stored in the collection.
		/// </summary>
		string this[int index]
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the strings in the <c>IStringList</c> as a single string with the individual strings delimited by carriage returns.
		/// </summary>
		string Text
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that terminates line.
		/// </summary>
		string LineTerminator
		{
			get;
			set;
		}
	}
	#endregion IStringList

	#region INotify
	/// <summary>
	/// Represents properties and methods to manage notification between objects.
	/// </summary>
	public interface INotify
	{
		/// <summary>
		/// When implemented by a class, prevents object state updating until calling <c>EndUpdate</c> method.
		/// </summary>
		/// <returns>Number of object state updating locks.</returns>
		int BeginUpdate();
		/// <summary>
		/// When implemented by a class, re-enables object state updating, that was turn of by calling <c>BeginUpdate</c> method.
		/// </summary>
		/// <returns>Number of object state updating locks.</returns>
		int EndUpdate();
		/// <summary>
		/// When implemented by a class, adds new handler to respond a notification.
		/// </summary>
		/// <param name="sender">Specifies an object that can respond a notification.</param>
		void AddNotifier(INotifier sender);
		/// <summary>
		/// When implemented by a class, exclude specified handler from notification handlers list.
		/// </summary>
		/// <param name="sender">Specifies an object that can respond a notification.</param>
		void RemoveNotifier(INotifier sender);
		/// <summary>
		/// When implemented by a class, notifies all notifiers about updating object state.
		/// </summary>
		void Notify();
		/// <summary>
		/// When implemented by a class, keeps track of calls to <c>BeginUpdate</c> and <c>EndUpdate</c> so that they can be nested.
		/// </summary>
		int UpdateCount
		{
			get;
		}
	}
	#endregion INotify

	#region INotifier
	/// <summary>
	/// Represents method that informs object about changes in linked objects.
	/// </summary>
	public interface INotifier
	{
		/// <summary>
		/// When implemented by a class, updates control's content according to the parameters of notification.
		/// </summary>
		/// <param name="sender">The source of the notification.</param>
		/// <param name="e">An EventArgs that contains the event data.</param>
		void Notification(object sender, EventArgs e);
	}
	#endregion INotifier

	#region IParser
	/// <summary>
	/// Represents properties and methods for perform lexical analysis of the text.
	/// </summary>
	public interface IParser : ILexer
	{
		/// <summary>
		/// When implemented by a class, resets <c>IParser</c> to the start position.
		/// </summary>
		void Reset(); 
		/// <summary>
		/// When implemented by a class, resets <c>IParser</c> to the specified position.
		/// </summary>
		/// <param name="line">Specifies new line index.</param>
		/// <param name="pos">Specifies new position of character within the line.</param>
		/// <param name="state">Specifies new <c>State</c>.</param>
		void Reset(int line, int pos, int state);
		/// <summary>
		/// When implemented by a class, parses text from current position to the next token and updates <c>TokenPos</c>, <c>CurrentPos</c> and <c>TokenString</c> properties.
		/// </summary>
		/// <returns>Token that corresponds to the next position.</returns>
		int NextToken();
		/// <summary>
		/// When implemented by a class, parses text from current position to the next token and updates <c>TokenPos</c>, <c>CurrentPos</c> and <c>TokenString</c> properties.
		/// </summary>
		/// <param name="str">Retrieves token string for the next token.</param>
		/// <returns>Token that corresponds to the next position.</returns>
		int NextToken(out string str);
		/// <summary>
		/// When implemented by a class, parses next portion of the text, remaning current position unchanged.
		/// </summary>
		/// <returns>Token that corresponds to the next position.</returns>
		int PeekToken();
		/// <summary>
		/// When implemented by a class, parses next portion of the text, remaning current position unchanged.
		/// </summary>
		/// <param name="str">Retrieves token string for the next token.</param>
		/// <returns>Token that corresponds to the next position.</returns>
		int PeekToken(out string str);
		/// <summary>
		/// When implemented by a class, parses to the next valid (non-whitespace, non-comment) portion of the text, remaning current position unchanged.
		/// </summary>
		/// <returns>Next valid token.</returns>
		int PeekValidToken();
		/// <summary>
		/// When implemented by a class, parses to the next valid (non-whitespace, non-comment) portion of the text, remaning current position unchanged.
		/// </summary>
		/// <param name="str">Retrieves token string for the next valid token.</param>
		/// <returns>Next valid token.</returns>
		int PeekValidToken(out string str);
		/// <summary>
		/// When implemented by a class, parses text from current position to the next valid (non-whitespace, non-comment) token and updates <c>TokenPos</c>, <c>CurrentPos</c> and <c>TokenString</c> properties.
		/// </summary>
		/// <returns>Next valid token.</returns>
		int NextValidToken();
		/// <summary>
		/// When implemented by a class, parses text from current position to the next valid (non-whitespace, non-comment) token and updates <c>TokenPos</c>, <c>CurrentPos</c> and <c>TokenString</c> properties.
		/// </summary>
		/// <param name="str">Retrieves token string for the next valid token.</param>
		/// <returns>Next valid token.</returns>
		int NextValidToken(out string str);
		/// <summary>
		/// When implemented by a class, saves current <c>IParser</c> state and position.
		/// </summary>
		void SaveState();
		/// <summary>
		/// When implemented by a class, restores <c>IParser</c> state and position stored by <c>SaveState</c> method.
		/// </summary>
		void RestoreState();
		/// <summary>
		/// hen implemented by a class, restores <c>IParser</c> state and position stored by <c>SaveState</c> method.
		/// </summary>
		/// <param name="restore">Indicates whether <c>IParser</c> should restore it's state to previous position or simply delete information about previously stored state.</param>
		void RestoreState(bool restore);
		/// <summary>
		/// When implemented by a class, represents token (index of style in the class style collection) related to the current position in the parsed text.
		/// </summary>
		int Token
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents current <c>IParser</c> state.
		/// </summary>
		int State
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents text of the current syntax token.
		/// </summary>
		string TokenString
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents start position of the current token.
		/// </summary>
		Point TokenPosition
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents position of current character within the current line.
		/// </summary>
		Point CurrentPosition
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, indicates whether current position is out of the text, signalling that whole text is parsed.
		/// </summary>
		bool Eof
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a list of strings to parse.
		/// </summary>
		IStringList Strings
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a list of string to parse represented as string array.
		/// </summary>
		string[] Lines
		{
			get;
			set;
		}
	}
	#endregion IParser

	#region ISyntaxParser
	/// <summary>
	/// Represents properties and methods to perform syntax analysis of the text.
	/// </summary>
	public interface ISyntaxParser : IParser, IImport
	{
		/// <summary>
		/// When implemented by a class, reparses entire text.
		/// </summary>
		void ReparseText();
		/// <summary>
		/// When implemented by a class, reparses syntax block at specified position.
		/// </summary>
		/// <param name="position">Specifies position to find syntax block.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool ReparseBlock(Point position);
		/// <summary>
		/// Reparses syntax block at specified position.
		/// </summary>
		/// <param name="position">Specifies position to find syntax block.</param>
		/// <param name="node">Returns node corresponding to the block being reparsed</param>
		/// <param name="completionType">Specifies code completion reason.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool ReparseBlock(Point position, out ISyntaxNode node, CodeCompletionType completionType);
		/// <summary>
		/// When implemented by a class, creates outlined sections for parsed text using result of syntax analysis and fills ranges parameter by the collection of the outlined sections.
		/// </summary>
		/// <param name="ranges">Retrieves <c>IOutlineRange</c> collection for outlined sections.</param>
		/// <returns>Number of outlined sections.</returns>
		int Outline(IList ranges);
		/// <summary>
		/// When implemented by a class, returns indentation level of specified line.
		/// </summary>
		/// <param name="index">Specifies index of line to obtain indentation level.</param>
		/// <param name="autoIndent">Indicates whether indentation level should be caculated automatically, or obtained from the previous line.</param>
		/// <returns>Indentation level at line specified by index.</returns>
		int GetSmartIndent(int index, bool autoIndent);
		/// <summary>
		/// When implemented by a class, formats line according to the parser rules.
		/// </summary>
		/// <param name="index">Specifies index of line to format.</param>
		/// <param name="text">specifies string representation of the line</param>
		/// <param name="colorData">specifies data containing color information for the given string</param>
		/// <returns>formatted line.</returns>
		string SmartFormatLine(int index, string text, short[] colorData);
		/// <summary>
		/// When implemented by a class, retrieves all syntax errors that <c>ISyntaxParser</c> found while analysing the text.
		/// </summary>
		/// <param name="errors">Retrieves a collection of syntax error.</param>
		/// <returns>Number of syntax errors that are found.</returns>
		int GetSyntaxErrors(IList errors);
		/// <summary>
		/// When implemented by a class, performs code completion for the specified text representing language element.
		/// </summary>
		/// <param name="text">Specifies source text.</param>
		/// <param name="position">Specifies current position in text.</param>
		/// <param name="e">Contains data for the code completion.</param>
		void CodeCompletion(string text, Point position, CodeCompletionArgs e);
		/// <summary>
		/// Checks whether end-of-block code needs inserting.
		/// </summary>
		/// <param name="position">Specifies current position in text.</param>
		/// <param name="code">output prameter to return code fragment to be insered</param>
		/// <returns>true if autocompletion of end-of-block needed; otherwise false</returns>
		bool ProcessAutoComplete(Point position, out string code);
		/// <summary>
		/// When implemented by a class, gets the string that represents start symbol of single line comment.
		/// </summary>
		/// <returns>Single line comment string.</returns>
		string GetSingleLineComment();
		/// <summary>
		/// When implemented by a class, gets syntax block at specified position.
		/// </summary>
		/// <param name="position">Position to find syntax block.</param>
		/// <param name="blockPt">Retrieves start position of found block.</param>
		/// <returns><c>ISyntaxNode</c> object containing syntax block.</returns>
		ISyntaxNode GetBlock(Point position, out Point blockPt);
		/// <summary>
		/// When implemented by a class, gets <c>ISyntaxNode</c> that corresponds to the specified position.
		/// </summary>
		/// <param name="position">Position to find node.</param>
		/// <returns><c>ISyntaxNode</c> at specified position.</returns>
		ISyntaxNode GetNodeAt(Point position);
		/// <summary>
		/// When implemented by a class, indicates whether specified node represents declaration elements.
		/// </summary>
		/// <param name="node">Specifies node to check-up.</param>
		/// <returns>True if specified node represents declaration element; otherwise false.</returns>
		bool IsDeclaration(ISyntaxNode node);
		/// <summary>
		/// When implemented by a class, finds the declaration node or type at given position.
		/// </summary>
		/// <param name="text">Contains string used to perform search.</param>
		/// <param name="position">Specifies position to find node.</param>
		/// <returns><c>object</c> that is found.</returns>
		object FindDeclaration(string text, Point position);
		/// <summary>
		/// When implemented by a class, locates all references to the node in the text.
		/// </summary>
		/// <param name="node">Specifies <c>ISyntaxNode</c> to find references.</param>
		/// <param name="references">Retrieves references to node.</param>
		/// <returns>Number of found references.</returns>
		int FindReferences(ISyntaxNode node, ISyntaxNodes references);
		/// <summary>
		/// When implemented by a class, resets <c>Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		/// <summary>
		/// When implemented by a class, resets <c>CodeCompletionChars</c> to the default value.
		/// </summary>
		void ResetCodeCompletionChars();
		/// <summary>
		/// When implemented by a class, resets <c>CodeCompletionStopChars</c> to the default value.
		/// </summary>
		void ResetCodeCompletionStopChars();
		/// <summary>
		/// When implemented by a class, resets <c>AutoIndentChars</c> to the default value.
		/// </summary>
		void ResetAutoIndentChars();
		/// <summary>
		/// When implemented by a class, resets <c>SmartFormatChars</c> to the default value.
		/// </summary>
		void ResetSmartFormatChars();
		/// <summary>
		/// When implemented by a class, gets boolean value indicating whether text content is divided at given line.
		/// </summary>
		bool IsContentDivider(int index);
		/// <summary>
		/// When implemented by a class, gets or sets a flags determining syntax parsing and formatting behavior.
		/// </summary>
		SyntaxOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a hierarchical collection of <c>ISyntaxNode</c> elements representing abstract syntax tree of the text being parsed.
		/// </summary>
		ISyntaxTree SyntaxTree
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an <c>ICodeCompletionRepository</c> that holds methods for code completion purposes.
		/// </summary>
		ICodeCompletionRepository CompletionRepository
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, returns code snippets for the given parser.
		/// </summary>
		ICodeSnippetsProvider CodeSnippets
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether <c>ISyntaxParser</c> should perform case-sensitive analysis if its content.
		/// </summary>
		bool CaseSensitive
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether <c>ISyntaxParser</c> should perform lexical analysis based on it's rules rather than using internal method.
		/// </summary>
		bool UseScheme
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a collection of characters that initializes a code completion procedure when typing.
		/// </summary>
		char[] CodeCompletionChars
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a collection of characters that finalizes a code completion procedure when typing.
		/// </summary>
		char[] CodeCompletionStopChars
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a collection of characters that initializes an indentation procedure when typing.
		/// </summary>
		char[] AutoIndentChars
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a collection of characters that initializes a smart formatting procedure when typing.
		/// </summary>
		char[] SmartFormatChars
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when <c>ISyntaxParser</c> text content is fully parsed.
		/// </summary>
		event EventHandler TextReparsed;
	}
	#endregion ISyntaxParser
	

	#region ICodeCompletionRepository
	/// <summary>
	/// Represents properties and methods to perform code completion functionality.
	/// </summary>
	public interface ICodeCompletionRepository
	{
		/// <summary>
		/// When implemented by a class,o btains information type of the <c>SyntaxNode</c>
		/// </summary>
		/// <param name="text">Specifies source text.</param>
		/// <param name="node">Specifies <c>ISyntaxNode</c> representing a current language element.</param>
		/// <param name="position">Specifies starting position to search</param>
		/// <returns>Object represening type of found member.</returns>
		object GetNodeType(string text, ISyntaxNode node, Point position);
		/// <summary>
		/// When implemented by a class, obtains information about some language element to perform code completion related operations.
		/// </summary>
		/// <param name="text">Specifies source text.</param>
		/// <param name="node">Specifies <c>ISyntaxNode</c> representing current language element.</param>
		/// <param name="name">Retrieves name of found language element.</param>
		/// <param name="position">Specifies position of found language element in the code text and updates it if needed.</param>
		/// <param name="endPos">Specifies end position of found language element in the code text and updates it if needed.</param>
		/// <param name="scope">Retrieves information about search constraints for the language element.</param>
		/// <returns>Object representing information about language element to complete.</returns>
		object GetMemberType(string text, ISyntaxNode node, ref string name, 
			ref Point position, ref Point endPos, out StaticScope scope);
		/// <summary>
		/// When implemented by a class, obtains information about some language element to perform code completion related operations in special cases.
		/// </summary>
		/// <param name="text">Specifies source text.</param>
		/// <param name="node">Specifies <c>ISyntaxNode</c> representing current language element.</param>
		/// <param name="name">Retrieves name of found language element.</param>
		/// <param name="position">Specifies position of found language element in the code text and updates it if needed.</param>
		/// <param name="endPos">Specifies end position of found language element in the code text and updates it if needed.</param>
		/// <param name="scope">Retrieves information about search constraints for the language element.</param>
		/// <returns>Object representing information about language element to complete.</returns>
		object GetSpecialMemberType(string text, ISyntaxNode node, ref string name, 
			ref Point position, ref Point endPos, out StaticScope scope);
		/// <summary>
		/// When implemented by a class, obtains information about some method of specified language element.
		/// </summary>
		/// <param name="text">Specifies source text.</param>
		/// <param name="node">Specifies <c>ISyntaxNode</c> represening current language element.</param>
		/// <param name="name">Retrieves name of found method.</param>
		/// <param name="position">Retrieves start positon of the method in the code text.</param>
		/// <param name="endPos">Retrieves end position of the method in the code text.</param>
		/// <param name="paramIndex">Retrieves index of current parameter in the code text.</param>
		/// <param name="paramCount">Retrieves number of the parameters.</param>
		/// <param name="scope">Retrieves information about search constraints for the language element.</param>
		/// <returns>Object representing information about found method.</returns>
		object GetMethodType(string text, ISyntaxNode node, ref string name, 
			ref Point position, ref Point endPos, out int paramIndex, out int paramCount, out StaticScope scope);
		/// <summary>
		/// When implemented by a class, fills list members provider with list of its member, providing available choices for the specified language element.
		/// </summary>
		/// <param name="node">Specifies <c>ISyntaxNode</c> representing current language element.</param>
		/// <param name="position">Specifies position of language element in the text.</param>
		/// <param name="members">Specifies provider to fill with available members.</param>
		/// <param name="member">Specifies language element.</param>
		/// <param name="name">Specifies filter used to fill members.</param>
		/// <param name="scope">Specifies search constraints.</param>
		/// <param name="selIndex">Specifies index of default list member</param>
		void FillMembers(ISyntaxNode node, Point position,
			IListMembers members, object member, string name, StaticScope scope, ref int selIndex);
		/// <summary>
		/// When implemented by a class, obtains information about individual member of specified language element.
		/// </summary>
		/// <param name="members">Specifies provider to fill with available members.</param>
		/// <param name="member">Specifies language element.</param>
		/// <param name="name">Specifies name of member to retrieve.</param>
		/// <param name="paramIndex">Specifies index of current member parameter.</param>
		/// <param name="scope">Specifies search constraints.</param>
		void FillMember(IListMembers members, object member, string name, int paramIndex, StaticScope scope);
		/// <summary>
		/// When implemented by a class, obtains information about a member of some language element.
		/// </summary>
		/// <param name="node">Specifies <c>ISyntaxNode</c> representing a current language element.</param>
		/// <param name="position">Specifies position of language element.</param>
		/// <param name="member">Specifies language element.</param>
		/// <param name="name">Specifies name of the member to locate.</param>
		/// <param name="scope">Retrieves information about search constraints for this language element.</param>
		/// <returns>Object represening information about found member.</returns>
		object GetMemberType(ISyntaxNode node, Point position, object member, string name, out StaticScope scope);
		/// <summary>
		/// When implemented by a class, obtains description of some language element.
		/// </summary>
		/// <param name="members">Specifies ListMembers interface used to get language-specific description.</param>
		/// <param name="node">Specifies <c>ISyntaxNode</c> that representing language element to describe.</param>
		/// <param name="member">Specifies language element to describe.</param>
		/// <param name="name">Specifies name of described language element.</param>
		/// <param name="fullDescription">Specifies whether description should include name and type of the found element.</param>
		/// <returns>String that describes specified language element.</returns>
		string GetDescription(IListMembers members, ISyntaxNode node, object member, string name, bool fullDescription);
		/// <summary>
		/// When implemented by a class, obtains information about where the language element is declared.
		/// </summary>
		/// <param name="text">Specifies the source text.</param>
		/// <param name="node">Specifies <c>ISyntaxNode</c> representing a current language element.</param>
		/// <param name="position">Specifies position of language element.</param>
		/// <returns><c>object</c> representing declaration of the language element.</returns>
		object FindDeclaration(string text, ISyntaxNode node, Point position);
		/// <summary>
		/// When implemented by a class, locates all references to the node in the text.
		/// </summary>
		/// <param name="node">Specifies <c>ISyntaxNode</c> to find references.</param>
		/// <param name="references">Retrieves references to node.</param>
		/// <returns>Number of found references.</returns>
		int FindReferences(ISyntaxNode node, ISyntaxNodes references);
		/// <summary>
		/// When implemented by a class, adds specified tree to the list of syntax trees for code-completion related purposes.
		/// </summary>
		/// <param name="tree">Specifies <c>ISyntaxTree</c> to add.</param>
		void RegisterSyntaxTree(ISyntaxTree tree);
		/// <summary>
		/// When implemented by a class, removes specified tree from the list of syntax trees.
		/// </summary>
		/// <param name="tree">Specifies <c>ISyntaxTree</c> to remove.</param>
		/// <returns>True if succeed (tree is present in the tree list); otherwise false.</returns>
		bool UnregisterSyntaxTree(ISyntaxTree tree);
		/// <summary>
		/// When implemented by a class, registers snippet to be displayed in code completion window
		/// </summary>
		/// <param name="snippet">Specifies name of snippet to be displayed</param>
		/// <param name="isStatement">Specifies whether snippet will have statement image index</param>
		void RegisterSnippet(string snippet, bool isStatement);
		/// <summary>
		/// When implemented by a class, removes specified snippet from the list of snippets.
		/// </summary>
		/// <param name="snippet">Specifies name of snippet to be removed</param>
		/// <returns>True if succeed; otherwise false</returns>
		bool UnregisterSnippet(string snippet);
		/// <summary>
		/// When implemented by a class, returns code snippets for the given language.
		/// </summary>
		/// <param name="language">Represents a language</param>
		/// <returns>ICodeSnippetsProvider instance for a given language.</returns>
		ICodeSnippetsProvider GetCodeSnippets(string language);
		/// <summary>
		/// When implemented by a class, indicates whether members of <c>Object</c> class should be present in the member collection.
		/// </summary>
		bool FillBaseMembers
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, indicates whether searching for language element's members should be case sensitive.
		/// </summary>
		bool CaseSensitive
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a hierarchical collection of <c>ISyntaxNode</c> elements.
		/// </summary>
		ISyntaxTree SyntaxTree
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets list of <c>ISyntaxTree</c> objects attached to this <c>ICodeCompletionRepository</c>.
		/// </summary>
		IList SyntaxTrees
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, occurs while trying to obtain information about some member of language element.
		/// </summary>
		event MemberLookupEvent MemberLookup;
		/// <summary>
		/// When implemented by a class, occurs while trying to obtain description of some language element.
		/// </summary>
		event DescriptionLookupEvent DescriptionLookup;
	}

	#endregion ICodeCompletionRepository

	#endregion Parser

	#region SyntaxTree
	/// <summary>
	/// Defines syntax node behavior.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum SyntaxNodeOptions 
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None            = 0x0,
		/// <summary>
		/// Specifies that syntax node increments indentation level.
		/// </summary>
		Indentation     = 0x1,
		/// <summary>
		/// Specifies that syntax node decrements indentation level.
		/// </summary>
		BackIndentation = 0x2,
		/// <summary>
		/// Specifies that syntax node preserves indentation level.
		/// </summary>
		KeepIndentation = 0x4,
		/// <summary>
		/// Specifies that syntax node can be outlined.
		/// </summary>
		Outlining       = 0x8,
		/// <summary>
		/// Specifies that syntax node supports code completion functionality.
		/// </summary>
		CodeCompletion  = 0x10
	}

	#region ISyntaxNodes
	/// <summary>
	/// Represents collection containing list of syntax nodes.
	/// </summary>
	public interface ISyntaxNodes : IList
	{
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual <c>ISyntaxNode</c> stored in the collection.
		/// </summary>
		new ISyntaxNode this[int index]
		{
			get;
			set;
		}
	}
	#endregion

	#region ISyntaxAttributes
	/// <summary>
	/// Represents collection containing list of syntax attributes.
	/// </summary>
	public interface ISyntaxAttributes : IList
	{
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual <c>ISyntaxAttribute</c> stored in the collection.
		/// </summary>
		new ISyntaxAttribute this[int index]
		{
			get;
			set;
		}
	}
	#endregion
	
	#region ISyntaxErrors
	/// <summary>
	/// Represents collection containing list of syntax errors.
	/// </summary>
	public interface ISyntaxErrors : IList
	{
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual <c>ISyntaxError</c> stored in the collection.
		/// </summary>
		new ISyntaxError this[int index]
		{
			get;
			set;
		}
	}
	#endregion

	#region ISyntaxNode
	/// <summary>
	/// Represents properties and methods to describe a particular language element.
	/// </summary>
	public interface ISyntaxNode
	{
		/// <summary>
		/// When implemented by a class, removes all elements from child nodes, attribute and error collections.
		/// </summary>
		void Clear();
		/// <summary>
		/// When implemented by a class, adds specified node to the child collection.
		/// </summary>
		/// <param name="node">Specifies <c>ISyntaxNode</c> to add.</param>
		/// <returns>Index of added node within the child collection.</returns>
		int AddChild(ISyntaxNode node);
		/// <summary>
		/// When implemented by a class, creates a new <c>ISyntaxNode</c> and adds it to the child collection.
		/// </summary>
		/// <returns><c>ISyntaxNode</c> that is added.</returns>
		ISyntaxNode AddChild();
		/// <summary>
		/// When implemented by a class, inserts specified node to the child collection.
		/// </summary>
		/// <param name="node">Specifies node to insert.</param>
		/// <param name="comparer">Specifies method that compares nodes in the sorted child collection.</param>
		/// <returns>Index of inserted node in the child collection.</returns>
		int InsertChild(ISyntaxNode node, IComparer comparer);
		/// <summary>
		/// When implemented by a class, adds specified nodes to the child collection.
		/// </summary>
		/// <param name="nodes">Specifies list of nodes to add.</param>
		void AddChildren(ISyntaxNodes nodes);
		/// <summary>
		/// When implemented by a class, adds specified attribute to the attribute collection.
		/// </summary>
		/// <param name="attr">Specifies <c>ISyntaxAttribute</c> to add.</param>
		/// <returns>Index of added attribute in the attribute collection.</returns>
		int AddAttribute(ISyntaxAttribute attr);
		/// <summary>
		/// When implemented by a class, creates a new <c>ISyntaxAttribute</c> and adds it to the attribute collection.
		/// </summary>
		/// <returns><c>ISyntaxAttribute</c> that is added.</returns>
		ISyntaxAttribute AddAttribute();
		/// <summary>
		/// When implemented by a class, adds specified attributes to the attribute collection.
		/// </summary>
		/// <param name="attrs">Specifies list of attributes to add.</param>
		void AddAttributes(ISyntaxAttributes attrs);
		/// <summary>
		/// When implemented by a class, adds specified error to the error collection.
		/// </summary>
		/// <param name="err">Specifies <c>ISyntaxError</c> to add.</param>
		/// <returns>Number of added error in the error collection.</returns>
		int AddError(ISyntaxError err);
		/// <summary>
		/// When implemented by a class, creates a new <c>ISyntaxError</c> and add it to the error collection.
		/// </summary>
		/// <returns><c>ISyntaxError</c> that is added.</returns>
		ISyntaxError AddError();
		/// <summary>
		/// When implemented by a class, adds specified errors to the error collection.
		/// </summary>
		/// <param name="errs">Specifies list of errors to add.</param>
		void AddErrors(ISyntaxErrors errs);
		/// <summary>
		/// When implemented by a class, finds child node by its name.
		/// </summary>
		/// <param name="name">Specifies name of node.</param>
		/// <returns>First occurence of <c>ISyntaxNode</c> with specified name.</returns>
		ISyntaxNode FindNode(string name);
		/// <summary>
		/// When implemented by a class, finds child node by its type.
		/// </summary>
		/// <param name="nodeType">Specifies type of node.</param>
		/// <returns>First occurence of <c>ISyntaxNode</c> with specified type.</returns>
		ISyntaxNode FindNode(int nodeType);
		/// <summary>
		/// When implemented by a class, finds specified child node.
		/// </summary>
		/// <param name="obj">Specifies node to locate.</param>
		/// <param name="comparer">Specifies method that compares nodes in the sorted child collection.</param>
		/// <returns><c>ISyntaxNode</c> that is located.</returns>
		ISyntaxNode FindNode(object obj, IComparer comparer);
		/// <summary>
		/// When implemented by a class, finds attribute by its name.
		/// </summary>
		/// <param name="name">Specifies name of attribute</param>
		/// <returns>First occurence of <c>ISyntaxAttribute</c> with specified name.</returns>
		ISyntaxAttribute FindAttribute(string name);
		/// <summary>
		/// When implemented by a class, sorts the <c>ISyntaxNode</c> in the child list using the specified comparer.
		/// </summary>
		/// <param name="comparer">The IComparer implementation to use when comparing nodes.</param>
		/// <remarks>This method is recursive, so if some node in the child collection has childs they are also sorted.</remarks>
		void Sort(IComparer comparer);
		/// <summary>
		/// When implemented by a class, returns indentation level of this syntax node.
		/// </summary>
		/// <param name="index">Specifies line to obtain indentation level.</param>
		/// <param name="indent">Default value of indentation level.</param>
		/// <returns>Indentation level of the node at the specified position.</returns>
		int GetIndent(int index, int indent);
		/// <summary>
		/// When implemented by a class, gets or sets node scope.
		/// </summary>
		IRange Range
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets node position in the code text.
		/// </summary>
		Point Position
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets node dimension.
		/// </summary>
		Size Size
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets node name.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets type of the node.
		/// </summary>
		int NodeType 
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets <c>ISyntaxNode</c> that holds this node in its child list.
		/// </summary>
		ISyntaxNode Parent
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents root level <c>ISyntaxNode</c> in the syntax tree.
		/// </summary>
		ISyntaxNode Root
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets node options that defines its behavior.
		/// </summary>
		SyntaxNodeOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a collection of child nodes in the form of array.
		/// </summary>
		ISyntaxNode[] Childs
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an attribute collection in the form of array.
		/// </summary>
		ISyntaxAttribute[] Attributes
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an error collection in the form of array.
		/// </summary>
		ISyntaxError[] Errors
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets a list of child nodes.
		/// </summary>
		/// <remarks>If there is no child nodes, contains null reference.</remarks>
		ISyntaxNodes ChildList
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets a list of attributes
		/// </summary>
		/// <remarks>If there is no attributes, contains null reference.</remarks>
		ISyntaxAttributes AttributeList
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets a list of syntax errors
		/// </summary>
		/// <remarks>If there is no errors, contains null reference.</remarks>
		ISyntaxErrors ErrorList
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, indicates whether node has children.
		/// </summary>
		bool HasChildren
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, indicates whether node has attributes.
		/// </summary>
		bool HasAttributes
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, indicates whether node has errors.
		/// </summary>
		bool HasErrors
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents node level inside SyntaxTree.
		/// </summary>
		int Level
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents number of children in the child collection.
		/// </summary>
		int ChildCount
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents number of attributes in the attribute collection.
		/// </summary>
		int AttributeCount
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents number of syntax errors in the error collection.
		/// </summary>
		int ErrorCount
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents index of then node within its parent child collection.
		/// </summary>
		int Index
		{
			get;
		}
	}
	#endregion ISyntaxNode

	#region ISyntaxAttribute
	/// <summary>
	/// Represents properties to describe a particular attribute of language element.
	/// </summary>
	public interface ISyntaxAttribute
	{
		/// <summary>
		/// When implemented by a class, get or sets attribute name.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, get or sets value of the attribute.
		/// </summary>
		object Value
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, get or sets attribute position in the code text.
		/// </summary>
		Point Position
		{
			get;
			set;
		}
	}
	#endregion ISyntaxAttribute

	#region ISyntaxError
	/// <summary>
	/// Represents properties to describe a particular syntax error in the code text.
	/// </summary>
	public interface ISyntaxError
	{
		/// <summary>
		/// When implemented by a class, gets or sets error name.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets error description (reason).
		/// </summary>
		string Description
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets error position in the code text.
		/// </summary>
		Point Position
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets error dimension.
		/// </summary>
		Size Size
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets error scope.
		/// </summary>
		IRange Range
		{
			get;
			set;
		}
	}
	#endregion ISyntaxError

	#region ISyntaxTree
	/// <summary>
	/// Represents properties and methods to describe syntax structure of code text.
	/// </summary>
	public interface ISyntaxTree
	{
		/// <summary>
		/// When implemented by a class, removes all nodes from <c>ISyntaxTree</c> node collection.
		/// </summary>
		void Clear();
		/// <summary>
		/// When implemented by a class, adds specified node to the stack of nodes.
		/// </summary>
		/// <param name="node">Specifies <c>ISyntaxNode</c> to add.</param>
		void Push(ISyntaxNode node);
		/// <summary>
		/// When implemented by a class, removes last added node from the stack of nodes.
		/// </summary>
		/// <returns><c>ISyntaxNode</c> that is removed.</returns>
		ISyntaxNode Pop();
		/// <summary>
		/// When implemented by a class, removes all nodes from the node collection which position in the specified rectangle.
		/// </summary>
		/// <param name="rect">Specified rectangle to remove syntax nodes.</param>
		void BlockDeleting(Rectangle rect);
		/// <summary>
		/// When implemented by a class, changes positions of any syntax nodes and its elements located next to the specified position.
		/// </summary>
		/// <param name="x">The X-constituent of the Point value that specifies start position to change.</param>
		/// <param name="y">The Y-constituent of the Point value that specifies start position to change.</param>
		/// <param name="deltaX">Specifies horizontal displacement.</param>
		/// <param name="deltaY">Specifies vertical displacement.</param>
		/// <param name="reason">Specifies the reason of change.</param>
		void PositionChanged(int x, int y, int deltaX, int deltaY, UpdateReason reason);
		/// <summary>
		/// When implemented by a class, finds specified node.
		/// </summary>
		/// <param name="obj">Specifies node to locate.</param>
		/// <param name="comparer">Specifies method that compares nodes in the sorted node collection.</param>
		/// <returns><c>ISyntaxNode</c> that is located.</returns>
		ISyntaxNode FindNode(object obj, IComparer comparer);
		/// <summary>
		/// When implemented by a class, sorts all <c>ISyntaxNode</c> in the node collection using the specified comparer.
		/// </summary>
		/// <param name="comparer">The IComparer implementation to use when comparing nodes.</param>
		void Sort(IComparer comparer);
		/// <summary>
		/// When implemented by a class, represents root level <c>ISyntaxNode</c> in this syntax tree.
		/// </summary>
		ISyntaxNode Root
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents current <c>ISyntaxNode</c> in the node collection.
		/// </summary>
		ISyntaxNode Current
		{
			get;
		}
	}
	#endregion ISyntaxTree
	#endregion
}
