#region Copyright (c) 2004 - 2007 Quantum Whale LLC.
/*
	Quantum Whale .NET Component Library
	Common.NET Library

	Copyright (c) 2004 - 2007 Quantum Whale LLC.
	ALL RIGHTS RESERVED

	http://www.qwhale.net
	contact@qwhale.net
*/
#endregion Copyright (c) 2004 - 2007 Quantum Whale LLC.

using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using QWhale.Syntax;

namespace QWhale.Editor.Dialogs
{
	[Flags]
	public enum EditorSettingsTab
	{
		None           = 0x0,
		General        = 0x1,
		Additional     = 0x2,
		FontsAndColors = 0x4,
		Keymapping     = 0x8
	}

	#region ISearchDialog
	/// <summary>
	/// Represents a dialog box that allows user to search for the text.
	/// </summary>
	public interface ISearchDialog
	{
		/// <summary>
		/// When implemented by a class, initializes and runs a search dialog box.
		/// </summary>
		/// <param name="search">Specifies <c>ISearch</c> interface owning the dialog.</param>
		/// <param name="isModal">Indicates whether search dialog should appear in modal state.</param>
		/// <param name="isReplace">Indicates whether search or replace dialog should be executed.</param>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult Execute(ISearch search, bool isModal, bool isReplace);
		/// <summary>
		/// When implemented by a class, finishes search.
		/// </summary>
		/// <param name="search">Specifies <c>ISearch</c> to finish.</param>
		void DoneSearch(ISearch search);
		/// <summary>
		/// When implemented by a class, ensures that the search dialog box is visible in specified rectangle, moving it if necessary.
		/// </summary>
		/// <param name="rect">The Rectangle to check.</param>
		void EnsureVisible(Rectangle rect);
		/// <summary>
		/// When implemented by a class, toggles searching through hidden text on/off.
		/// </summary>
		void ToggleHiddenText();
		/// <summary>
		/// When implemented by a class, toggles case sensitive searching on/off.
		/// </summary>
		void ToggleMatchCase();
		/// <summary>
		/// When implemented by a class, toggles using regular expressions on/off.
		/// </summary>
		void ToggleRegularExpressions();
		/// <summary>
		/// When implemented by a class, toggles searching direction towards/backwards.
		/// </summary>
		void ToggleSearchUp();
		/// <summary>
		/// When implemented by a class, toggles searching for whole words on/off.
		/// </summary>
		void ToggleWholeWord();
		/// <summary>
		/// When implemented by a class, closes the dialog.
		/// </summary>
		void Close();
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether dialog box is visible.
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets form that owns this dialog.
		/// </summary>
		Form OwnerForm
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets search settings associated with search dialog.
		/// </summary>
		SearchSettings SearchSettings
		{
			get;
		}
	}
	#endregion
	
	#region IGotoLineDialog
	/// <summary>
	/// Represents dialog box that allows moving to a specific line index within Edit control.
	/// </summary>
	public interface IGotoLineDialog
	{
		/// <summary>
		/// When implemented by a class, displays a goto dialog.
		/// </summary>
		/// <param name="sender">Specifies object owning the dialog.</param>
		/// <param name="lines">Number of lines in the control's text content.</param>
		/// <param name="line">Index of the current line. When dialog executes receives index of the new line.</param>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult Execute(object sender, int lines, ref int line);
	}
	#endregion
	
	#region IPrintOptionsDialog
	/// <summary>
	/// Represents properties and methods to manipulate print settings.
	/// </summary>
	public interface IPrintOptionsDialog
	{
		/// <summary>
		/// When implemented by a class, runs a print options dialog box.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult ShowDialog();
		
		/// <summary>
		/// When implemented by a class, resets the <c>Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		/// <summary>
		/// When implemented by a class, resets the <c>AllowedOptions</c> to the default value.
		/// </summary>
		void ResetAllowedOptions();
		
		/// <summary>
		/// When implemented by a class, gets or sets a collection of flags determining print behavior.
		/// </summary>
		PrintOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets print options that can be changed by user.
		/// </summary>
		PrintOptions AllowedOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets name of file to be printed.
		/// </summary>
		string FileName
		{
			get;
			set;
		}
	}
	#endregion

	#region IPersistentSettings
	/// <summary>
	/// Represents methods to save/restore key properties of some object.
	/// </summary>
	public interface IPersistentSettings 
	{
		/// <summary>
		/// When implemented by a class, copies the content from another <c>IPersistentSettings</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IPersistentSettings</c> to assign.</param>
		void Assign(IPersistentSettings source);
		/// <summary>
		/// When implemented by a class, saves <c>IPersistentSettings</c> content to the specified file.
		/// </summary>
		/// <param name="fileName">Name of file to save content.</param>
		void SaveFile(string fileName);
		/// <summary>
		/// When implemented by a class, saves <c>IPersistentSettings</c> content to the specified stream.
		/// </summary>
		/// <param name="writer">The TextWriter object to write content.</param>
		void SaveStream(TextWriter writer);
		/// <summary>
		/// When implemented by a class, loads <c>IPersistentSettings</c> content from the specified file.
		/// </summary>
		/// <param name="fileName">Name of file to load content.</param>
		void LoadFile(string fileName);
		/// <summary>
		/// When implemented by a class, loads <c>IPersistentSettings</c> content from the specified stream.
		/// </summary>
		/// <param name="reader">The TextReader object to read content.</param>
		void LoadStream(TextReader reader);
	}
	#endregion
	
	#region ISyntaxSettings
	/// <summary>
	/// Represents methods to save/restore key properties for Edit control.
	/// </summary>
	public interface ISyntaxSettings : IPersistentSettings
	{
		/// <summary>
		/// When implemented by a class, changes values stored in the <c>ISyntaxSettings</c> accordingly to property values of <c>SyntaxEdit</c> control.
		/// </summary>
		/// <param name="edit">Specifies <c>SyntaxEdit</c> to copy properties from.</param>
		void LoadFromEdit(SyntaxEdit edit);
		/// <summary>
		/// When implemented by a class, assigns key properties of given <c>SyntaxEdit</c> according to values strored in the <c>ISyntaxSettings</c> instance.
		/// </summary>
		/// <param name="edit">Specifies <c>SyntaxEdit</c> to assign settings.</param>
		void ApplyToEdit(SyntaxEdit edit);
		/// <summary>
		/// When implemented by a class, indicates whether description for specified lexical style is enabled.
		/// </summary>
		/// <param name="index">Specifies index of lexical style to check-up.</param>
		/// <returns>True if description is enabled; otherwise false.</returns>
		bool IsDescriptionEnabled(int index);
		/// <summary>
		/// When implemented by a class, indicates whether font style for specified lexical style is enabled.
		/// </summary>
		/// <param name="index">Specifies index of lexical style to check-up.</param>
		/// <returns>True if font style is enabled; otherwise false.</returns>
		bool IsFontStyleEnabled(int index);
		/// <summary>
		/// When implemented by a class, indicates whether background color for specified lexical style is enabled.
		/// </summary>
		/// <param name="index">Specifies index of lexical style to check-up.</param>
		/// <returns>True if background color is enabled; otherwise false.</returns>
		bool IsBackColorEnabled(int index);
		/// <summary>
		/// When implemented by a class, initializes lexical styles according with current culture.
		/// </summary>
		void Localize();
		/// <summary>
		/// When implemented by a class, gets or sets collection of lexical styles for the <c>Lexer</c> components.
		/// </summary>
		LexStyle[] LexStyles
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a ColorThemes object.
		/// </summary>
		IColorThemes ColorThemes
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets Font object for the <c>SyntaxEdit</c> controls.
		/// </summary>
		Font Font
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets options for navigating within <c>SyntaxEdit</c> controls content.
		/// </summary>
		NavigateOptions NavigateOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the type of scroll bars to display in the <c>SyntaxEdit</c> controls.
		/// </summary>
		RichTextBoxScrollBars ScrollBars
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets options determining appearance and behavior of the <c>Selection</c> object in <c>SyntaxEdit</c> controls.
		/// </summary>
		SelectionOptions SelectionOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a gutter options that determines <c>Gutter</c> appearance and behavior for <c>SyntaxEdit</c> controls.
		/// </summary>
		GutterOptions GutterOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets line separator options for SyntaxEdit controls.
		/// </summary>
		SeparatorOptions SeparatorOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets outlining options for <c>SyntaxEdit</c> controls.
		/// </summary>
		OutlineOptions OutlineOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the <c>Margin</c> is visible in <c>SyntaxEdit</c> controls.
		/// </summary>
		bool ShowMargin
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the <c>Gutter</c> is visible in <c>SyntaxEdit</c> controls.
		/// </summary>
		bool ShowGutter
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether urls in the <c>SyntaxEdit</c> controls text should be highlighted.
		/// </summary>
		bool HighlightUrls
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether outlining is enabled for <c>SyntaxEdit</c> controls.
		/// </summary>
		bool AllowOutlining
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether indent operations insert space characters rather than TAB characters in <c>SyntaxEdit</c> controls.
		/// </summary>
		bool UseSpaces
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether <c>SyntaxEdit</c> controls automatically wrap words to the beginning of the next line when necessary.
		/// </summary>
		bool WordWrap
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets a sets a value indicating whether white space is visible.
		/// </summary>
		bool WhiteSpaceVisible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the width of the <c>Gutter</c> for <c>SyntaxEdit</c> controls.
		/// </summary>
		int GutterWidth
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets value indicating position, in characters, of the vertical line within the text portion of the <c>SyntaxEdit</c> controls.
		/// </summary>
		int MarginPos
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the character columns that the cursor will move to each time you press Tab in <c>SyntaxEdit</c> controls.
		/// </summary>
		int[] TabStops
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents names of all available event handlers.
		/// </summary>
		string[] EventNames
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents array of event handlers associated with keys
		/// </summary>
		KeyListData[] EventData 
		{
			get;
			set;
		}
	}
	#endregion
}
