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
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;

using QWhale.Syntax;
using QWhale.Common;
using QWhale.Editor.Dialogs;

[assembly:CLSCompliant(true)]
[assembly: System.Runtime.InteropServices.ComVisible(false)]

namespace QWhale.Editor
{
	#region Enums

	/// <summary>
	/// Defines undo/redo behaviour.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum UndoOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None            = 0x0,
		/// <summary>
		/// Allows undo/redo operations.
		/// </summary>
		AllowUndo       = 0x1,
		/// <summary>
		/// Specifies that last editing command should be undone together with any subsequent editing commands of the same type.
		/// </summary>
		GroupUndo       = 0x2,
		/// <summary>
		/// Specifies that navigate operations can be undone.
		/// </summary>
		UndoNavigations = 0x4,
		/// <summary>
		/// Allows undo operation after a save.
		/// </summary>
		UndoAfterSave   = 0x8,
		/// <summary>
		/// Specifies whether single break and unbreak operation should be undone rather than subsequent operations.
		/// </summary>
		SingleBreakUndo = 0x10
	}
	/// <summary>
	/// Defines additional flags for undo/redo operation.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum UndoFlags : byte
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None      = 0x0,
		/// <summary>
		/// Indicates first undo operation in the undo sequences.
		/// </summary>
		FirstTime = 0x1,
		/// <summary>
		/// Indicates that undoable operation occured prior to saving editor's content
		/// </summary>
		Saved     = 0x2
	}
	/// <summary>
	/// Defines a type of the operation to undo.
	/// </summary>
	public enum UndoOperation 
	{
		/// <summary>
		/// Specifies operation that inserts some text.
		/// </summary>
		Insert,
		/// <summary>
		/// Specifies operation that deletes some text.
		/// </summary>
		Delete,
		/// <summary>
		/// Specifies operation that breaks text line into two lines.
		/// </summary>
		Break,
		/// <summary>
		/// Specifies operation that concatenates two text lines.
		/// </summary>
		UnBreak,
		/// <summary>
		/// Specifies operation that inserts some block of text.
		/// </summary>
		InsertBlock,
		/// <summary>
		/// Specifies operation that deletes some block of text.
		/// </summary>
		DeleteBlock,
		/// <summary>
		/// Specifies operation that navigates within text content.
		/// </summary>
		Navigate,
		/// <summary>
		/// Specifies operation that navigates within text content. (this operation is always undone, regardless of UndoOptions);
		/// </summary>
		NavigateEx,
		/// <summary>
		/// Specifies that subsequent undo operations will be undone at once.
		/// </summary>
		UndoBlock,
		/// <summary>
		/// Specifies unknown operation.
		/// </summary>
		Unknown
	}
	/// <summary>
	/// Defines braces behaviour.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum BracesOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None            = 0x0,
		/// <summary>
		/// Specifies that matching braces should be highlighted.
		/// </summary>
		Highlight       = 0x1,
		/// <summary>
		/// Specifies that matching braces should be highlighted only if caret is positioned on the brace.
		/// </summary>
		HighlightBounds = 0x2,
		/// <summary>
		/// Specifies that the highlighting will disapear after small delay.
		/// </summary>
		TempHighlight   = 0x4
	}

	/// <summary>
	/// Defines specific options for navigation through the editor's content.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]   
	public enum NavigateOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None              = 0x0,
		/// <summary>
		/// Specifies that user can navigate beyond end of line.
		/// </summary>
		BeyondEol         = 0x1,
		/// <summary>
		/// Specifies that user can navigate beyond end of file.
		/// </summary>
		BeyondEof         = 0x2,
		/// <summary>
		/// Specifies that the curet position should move to the previous line when user click Left key and caret locates at the line begin.
		/// </summary>
		UpAtLineBegin     = 0x4,
		/// <summary>
		/// Specifies that the curet position should move to the next line when user click Right key at the end of the line.
		/// </summary>
		DownAtLineEnd	  = 0x8,
		/// <summary>
		/// Specifies that curent should moves to the mouse pointer when user clicks right mouse button.
		/// </summary>
		MoveOnRightButton = 0x10,
		/// <summary>
		/// Specifies that caret should not move when modifying lines programmaticaly.
		/// </summary>
		LeaveCaretOnStringsChanged = 0x20
	}
	/// <summary>
	/// Defines behaviour of Edit control when user presses Enter to insert new text line.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]   
	public enum IndentOptions
	{
		/// <summary>
		/// No indentation.
		/// </summary>
		None              = 0x0,
		/// <summary>
		/// Positions the cursor under the first nonblank character of the preceding nonblank line when user presses Enter.
		/// </summary>
		AutoIndent        = 0x1,
		/// <summary>
		/// Positions the cursor to the line indentation level, obtained from parser supporting option <c>SyntaxOptions.SmartIndent</c> when user presses Enter.
		/// </summary>
		SmartIndent       = 0x2,
		/// <summary>
		/// Uses spaces and tabs from previous line when indenting the line.
		/// </summary>
		UsePrevIndent	  = 0x4,
		/// <summary>
		/// Jumps to indent position rather than adding tabs or spaces.
		/// </summary>
		JumpToIndent      = 0x8,

	}
	/// <summary>
	/// Represents the last changes to the text stored in the text source.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum NotifyState
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None                     = 0x0,
		/// <summary>
		/// Current position in the text was changed.
		/// </summary>
		PositionChanged          = 0x1,
		/// <summary>
		/// Amount of lines in the text was changed.
		/// </summary>
		CountChanged             = 0x2,
		/// <summary>
		/// Overwrite mode was changed.
		/// </summary>
		OverWriteChanged         = 0x4,
		/// <summary>
		/// Modified state was changed.
		/// </summary>
		ModifiedChanged          = 0x8,
		/// <summary>
		/// Syntax scheme or Lexer was changed.
		/// </summary>
		SyntaxChanged            = 0x10,
		/// <summary>
		/// Readonly state was changed.
		/// </summary>
		ReadonlyChanged          = 0x20,
		/// <summary>
		/// Block of text was changed and needs invalidating.
		/// </summary>
		BlockChanged             = 0x40,
		/// <summary>
		/// Bookmark was set or removed.
		/// </summary>
		BookMarkChanged          = 0x80,
		/// <summary>
		/// Incremental search state was changed.
		/// </summary>
		IncrementalSearchChanged = 0x100,
		/// <summary>
		/// Rectangle that holds last found text was changed.
		/// </summary>
		SearcRectChanged         = 0x200,
		/// <summary>
		/// Undo operation was performed.
		/// </summary>
		Undo                     = 0x400,
		/// <summary>
		/// Text was edited.
		/// </summary>
		Edit                     = 0x800,
		/// <summary>
		/// Modified state was changed.
		/// </summary>
		Modified                 = 0x1000,
		/// <summary>
		/// Outline section was collapsed or expanded.
		/// </summary>
		Outline                  = 0x2000,
		/// <summary>
		/// Lines were wrapped.
		/// </summary>
		WordWrap                 = 0x4000,
		/// <summary>
		/// Position of the text was changed due to moving to the bookmark.
		/// </summary>
		GotoBookMark             = 0x8000,
		/// <summary>
		/// Block of text was selected or unselected.
		/// </summary>
		SelectBlock              = 0x10000,
		/// <summary>
		/// <c>SyntaxEdit.FirstSearch</c> property was changed.
		/// </summary>
		FirstSearchChanged       = 0x20000,
		/// <summary>
		/// <c>SyntaxEdit</c> should center current line if it's not in view
		/// </summary>
		CenterLine               = 0x40000,
		/// <summary>
		/// Text was completely parsed.
		/// </summary>
		TextParsed               = 0x80000,
		/// <summary>
		/// Selection was formatted 
		/// </summary>
		SmartFormat              = 0x100000,
		/// <summary>
		/// Strings was changed programmaticaly
		/// </summary>
		StringsChanged           = 0x200000


	}                                

	/// <summary>
	/// Defines type of the selection.
	/// <seealso cref="QWhale.Editor.AllowedSelectionMode"/>
	/// </summary>
	[Serializable]
	public enum SelectionType
	{
		/// <summary>
		/// Specifies that no text is selected.
		/// </summary>
		None,
		/// <summary>
		/// Specifies that selected text consists of consecutive characters.
		/// </summary>
		Stream,
		/// <summary>
		/// Specifies that selected text represents square block.
		/// </summary>
		Block
	}
	/// <summary>
	/// Defines which types of selection is allowed.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// <seealso cref="QWhale.Editor.SelectionType"/>
	/// </summary>
	[Flags]
	public enum AllowedSelectionMode
	{
		/// <summary>
		/// Specifies that no selection type is allowed.
		/// </summary>
		None   = 0x0,
		/// <summary>
		/// Specifies that only stream selection type is allowed.
		/// </summary>
		Stream = 0x1,
		/// <summary>
		/// Specifies that only block selection type is allowed.
		/// </summary>
		Block  = 0x2
	}

	/// <summary>
	/// Defines state of the selected text.
	/// </summary>
	public enum SelectionState
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None,
		/// <summary>
		/// Specifies that selected text is dragged.
		/// </summary>
		Drag,
		/// <summary>
		/// Specifies that some text part is selected.
		/// </summary>
		Select,
		/// <summary>
		/// Specifies that Edit control tries to select words instead of single characters.
		/// </summary>
		SelectWord,
		/// <summary>
		/// Specifies that Edit control tries to select lines instead of single characters.
		/// </summary>
		SelectLine
	}
	/// <summary>
	/// Defines appearance and behaviour of selected text.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum SelectionOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None                 = 0x0,
		/// <summary>
		/// Disables to select any text.
		/// </summary>
		DisableSelection     = 0x1,
		/// <summary>
		/// Disables dragging the selected text.
		/// </summary>
		DisableDragging      = 0x2,
		/// <summary>
		/// Specifies that selection is drawn beyond end of line.
		/// </summary>
		SelectBeyondEol      = 0x4,
		/// <summary>
		/// Specifies that selection should paint preserving colors of the text fragments.
		/// </summary>
		UseColors            = 0x8, 
		/// <summary>
		/// Specifies that selected text should be draw as unselected text when control lost focus.
		/// </summary>
		HideSelection        = 0x10,
		/// <summary>
		/// Specifies that whole line should be selected instead of single word when user double clicks on some text.
		/// </summary>
		SelectLineOnDblClick = 0x20,
		/// <summary>
		/// Specifies that selection should be unselected when selected text copies to the Clipboard.
		/// </summary>
		DeselectOnCopy       = 0x40,
		/// <summary>
		/// Specifies that selected text should be retained even when the cursor is moved, until a new block is selected.
		/// </summary>
		PersistentBlocks     = 0x80,
		/// <summary>
		/// Specifies that selected text should be replaced of text with whatever is typed next.
		/// </summary>
		OverwriteBlocks      = 0x100,
		/// <summary>
		/// Specifies that selected text should be formatted according to syntax rules when pasting.
		/// </summary>
		SmartFormat          = 0x200,
		/// <summary>
		/// Specifies that Edit control should select words instead of single characters.
		/// </summary>
		WordSelect           = 0x400,
		/// <summary>
		/// Specifies that Edit control should draw border around selection.
		/// </summary>
		DrawBorder           = 0x800,
		/// <summary>
		/// Specifies that whole line should be selected when user triple clicks on some text.
		/// </summary>
		SelectLineOnTripleClick = 0x1000,
		/// <summary>
		/// Specifies that selection should be cleared by dblclick.
		/// </summary>
		DeselectOnDblClick     = 0x2000,
		/// <summary>
		/// Specifies that selection should convert all tabs to spaces in the text being pasted when Lines.UseSpaces is on.
		/// </summary>
		ConvertToSpacesOnPaste = 0x4000,
        /// <summary>
        /// Specifies that selection should copy it's content clipboard in rtf format.
        /// </summary>
        RtfClipboard           = 0x8000,
		/// <summary>
		/// Specifies that selection should be deleted when dragging from external source.
		/// </summary>
		ClearOnDrag            = 0x10000,
		/// <summary>
		/// Specifies that copy and cut operation should process entire line when selection is empty.
		/// </summary>
		CopyLineWhenEmpty      = 0x20000,
		/// <summary>
		/// Specifies that Edit control should not try to find and insert code snippet when tab key is pressed.
		/// </summary>
		DisableCodeSnippetOnTab = 0x40000
    }

	/// <summary>
	/// Defines how errors should be handled.
	/// </summary>
	public enum ErrorBehaviour
	{
		/// <summary>
		/// No action to do.
		/// </summary>
		None,
		/// <summary>
		/// Specifies that error handler should show a message about exception.
		/// </summary>
		Message,
		/// <summary>
		/// Specifies that error handler should throw an exception.
		/// </summary>
		Exception
	}

	/// <summary>
	/// Defines options for search and replace operations.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum SearchOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None               = 0x0,
		/// <summary>
		/// Specifies that search should be case sensitive.
		/// </summary>
		CaseSensitive      = 0x1,
		/// <summary>
		/// Searches only for whole words, rather than matching the text as it occurs within words.
		/// </summary>
		WholeWordsOnly     = 0x2,
		/// <summary>
		/// Specifies that text to find represents notations for patterns of text rather than the literal character.
		/// </summary>
		RegularExpressions = 0x4,
		/// <summary>
		/// Specifies that search should be executed towards the beginning of text.
		/// </summary>
		BackwardSearch     = 0x8,
		/// <summary>
		/// Searches only within the selected text in the currently active document.
		/// </summary>
		SelectionOnly      = 0x10,
		/// <summary>
		/// Specifies that search should start from the beginnig of text.
		/// </summary>
		EntireScope        = 0x20,
		/// <summary>
		/// Specifies that the search includes invisible text, such as an collapsed section.
		/// </summary>
		SearchHiddenText   = 0x40,
		/// <summary>
		/// Specifies that text at the current position of the active document should be used as text to find.
		/// </summary>
		FindTextAtCursor   = 0x80,
		/// <summary>
		/// Specifies that confirm dialog should appear before replacing found text.
		/// </summary>
		PromptOnReplace    = 0x100,
		/// <summary>
		/// Specifies that selected text of the active document should be used as text to find.
		/// </summary>
		FindSelectedText   = 0x200,
		/// <summary>
		/// Search until current position is reached.
		/// </summary>
		CycledSearch       = 0x400,
		/// <summary>
		/// Search until current position is reached.
		/// </summary>
		SilentSearch       = 0x800
	}
	/// <summary>
	/// Defines state of the <c>StrItem</c> object, represening individual line in the Source.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum StrItemState  : byte
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None      = 0x0,
		/// <summary>
		/// Specifies that <c>StrItem</c> object is already parsed.
		/// </summary>
		Parsed    = 0x1,
		/// <summary>
		/// Specifies that <c>StrItem</c> object is read-only.
		/// </summary>
		Readonly  = 0x2
	}
	/// <summary>
	/// Defines additional flags for text fragments.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum ColorFlags
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None           = 0x0,
		/// <summary>
		/// Indicates that text fragment consists of whitespace symbol.
		/// </summary>
		WhiteSpace     = 0x1,
		/// <summary>
		/// Indicates that text fragment consists of tab symbol.
		/// </summary>
		Tabulation     = 0x2,
		/// <summary>
		/// Indicates that text fragment contains outline section.
		/// </summary>
		OutlineSection = 0x4,
		/// <summary>
		/// Indicates that text fragment contains misspelled word.
		/// </summary>
		MisSpelledWord = 0x8,
		/// <summary>
		/// Indicates that text fragment contains hypertext.
		/// </summary>
		HyperText      = 0x10, 
		/// <summary>
		/// Indicates that text fragment contains matching brace.
		/// </summary>
		Brace          = 0x20,
		/// <summary>
		/// Indicates that text fragment contains wave line.
		/// </summary>
		WaveLine       = 0x40,
		/// <summary>
		/// Indicates that text fragment contains code snippet.
		/// </summary>
		CodeSnippet    = 0x80
	}

	/// <summary>
	/// Defines gutter appearance and behaviour displayed at the left size of the Edit control.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum GutterOptions
	{
		/// <summary>
		///	Specifies that no flags are in effect.
		/// </summary>
		None                  = 0x0,
		/// <summary>
		/// Specifies that numbers of lines should be drawn.
		/// </summary>
		PaintLineNumbers      = 0x1,
		/// <summary>
		/// Specifies that numbers of lines should be drawn at the gutter area rather than beyond the gutter.
		/// </summary>
		PaintLinesOnGutter    = 0x2,
		/// <summary>
		/// Specifies that numbers of lines should be drawn beyond end of file.
		/// </summary>
		PaintLinesBeyondEof   = 0x4,
		/// <summary>
		/// Specifies that bookmarks should be drawn.
		/// </summary>
		PaintBookMarks        = 0x8,
		/// <summary>
		/// Specifies that line modificators (color stitch that indicates that the line content is modified, unmodified or saved) should be drawn.
		/// </summary>
		PaintLineModificators = 0x10,
		/// <summary>
		/// Specifies that user margin (allowing to draw additional information) should be drawn.
		/// </summary>
		PaintUserMargin        = 0x20
	}

	/// <summary>
	/// Defines appearance and behaviour of the outline text sections.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum OutlineOptions 
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None         = 0x0,
		/// <summary>
		/// Specifies that control should paint outline images and lines on gutter.
		/// </summary>
		DrawOnGutter = 0x1,
		/// <summary>
		/// Specifies that control should paint lines for expanded outline section.
		/// </summary>
		DrawLines    = 0x2,
		/// <summary>
		/// Specifies that control should paint the outline buttons substituting content of the collapsed section.
		/// </summary>
		DrawButtons  = 0x4,
		/// <summary>
		/// Specifies that control should display text of the collapsed outline section in the popup window when mouse pointer is over the outline button.
		/// </summary>
		ShowHints    = 0x8
	}

	/// <summary>
	/// Defines behaviour of the code completion popup window.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum CodeCompletionFlags
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None              = 0x0,
		/// <summary>
		/// Specifies that code completion popup window should be closed when user presses the ESC key.
		/// </summary>
		CloseOnEscape     = 0x1,
		/// <summary>
		/// Specifies that code completion popup window should accept its result when user presses the ENTER key.
		/// </summary>
		AcceptOnEnter     = 0x2,
		/// <summary>
		/// Specifies that code completion popup window should be closed when mouse pointer leaves the control.
		/// </summary>
		CloseOnMouseLeave = 0x4,
		/// <summary>
		/// Specifies that code completion popup window should be closed when popup window lost focus.
		/// </summary>
		CloseOnLostFocus  = 0x8,
		/// <summary>
		/// Specifies that code completion popup window should accept its result when user clicks the popup.
		/// </summary>
		AcceptOnClick     = 0x10,
		/// <summary>
		/// Specifies that code completion popup window should accept its result when user double clicks the popup.
		/// </summary>
		AcceptOnDblClick  = 0x20,
		/// <summary>
		/// Specifies that code completion popup window should be fitted to screen when popups.
		/// </summary>
		FeetToScreen      = 0x40,
		/// <summary>
		/// Indicates whether hint window remains visible until closed manually.
		/// </summary>
		KeepActive        = 0x80,
		/// <summary>
		/// Specifies that code completion popup window should accept its result when user presses delimiter key.
		/// </summary>
		AcceptOnDelimiter = 0x100,
		/// <summary>
		/// Specifies that code completion popup window should accept its result when user presses tab.
		/// </summary>
		AcceptOnTab       = 0x200,
		/// <summary>
		/// Specifies that code completion popup window should accept its result and suppress the space key when user presses space.
		/// </summary>
		AcceptOnSpace       = 0x400
}

	/// <summary>
	/// Defines appearance of lines with some line style.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum LineStyleOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None         = 0x0,
		/// <summary>
		/// Specifies that line style applicable beyond end of line.
		/// </summary>
		BeyondEol    = 0x1, 
		/// <summary>
		/// Specifies that background and foreground colors should be interchanged.
		/// </summary>
		InvertColors = 0x2
	}

	/// <summary>
	/// Specifies options for highlighting and separating lines within Edit control.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum SeparatorOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None                 = 0x0,
		/// <summary>
		/// Specifies that current line in Edit control should be highlighted.
		/// </summary>
		HighlightCurrentLine = 0x1,
		/// <summary>
		/// Specifies that current line in Edit control should not be highlighted when control looses input focus.
		/// </summary>
		HideHighlighting     = 0x2,
		/// <summary>
		/// Specifies that lines are visualy separated in Edit control.
		/// </summary>
		SeparateLines        = 0x4,
		/// <summary>
		/// Specifies that Line seprator is drawn between lines that are dropped due to word break procedure.
		/// </summary>
		SeparateWrapLines    = 0x8,
		/// <summary>
		/// Specifies that Line seprator is drawn between separate sections of the text, for example between methods.
		/// </summary>
		SeparateContent      = 0x10,
		/// <summary>
		/// Specifies that Line seprator is drawn between lines beyond end of file.
		/// </summary>
		SeparateBeyondEof    = 0x20,
	}

	/// <summary>
	/// Defines scrolling behaviour.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum ScrollingOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None              = 0x0,
		/// <summary>
		/// Specifies that Edit control should reposition immediately while user tracking the thumb.
		/// </summary>
		SmoothScroll      = 0x1,
		/// <summary>
		/// Specifies that control should display hint text in the popup window when user tracking the thumb.
		/// </summary>
		ShowScrollHint    = 0x2,
		/// <summary>
		/// Specifies that horizontal scrolling should scroll client area at the several characters rather than one character when caret is at the right border.
		/// </summary>
		UseScrollDelta    = 0x4,
		/// <summary>
		/// Specifies that Edit control should use system scroll bars rather than scrollbar controls.
		/// </summary>
		SystemScrollbars  = 0x8,
		/// <summary>
		/// Specifies that scroll bars appears in flat style.
		/// </summary>
		FlatScrollbars    = 0x10,
		/// <summary>
		/// Allows user to split Edit control horizontally.
		/// This options works only if <c>SystemScrollBars</c> is off and control has <c>Dock</c> property set to <c>DockStyle.Fill.</c>
		/// </summary>
		AllowSplitHorz    = 0x20,
		/// <summary>
		/// Allows user to split Edit control vertically.
		/// This options works only if <c>SystemScrollBars</c> is off and control has <c>Dock</c> property set to <c>DockStyle.Fill.</c>
		/// </summary>
		AllowSplitVert    = 0x40,
		/// <summary>
		/// Specifies that scroll bars should display a collection of horizontal buttons at the left side of the horizontal scroll bar.
		/// This options works only if <c>SystemScrollBars</c> is off.
		/// </summary>
		HorzButtons       = 0x80,
		/// <summary>
		/// Specifies that scroll bars should display a collection of vertical buttons at the bottom side of vertical scroll bar.
		/// This options works only if <c>SystemScrollBars</c> is off.
		/// </summary>
		VertButtons       = 0x100
	}

	/// <summary>
	/// Defines appearance of the printed page when sending Editor's content to the printer.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum PrintOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None            = 0x0,
		/// <summary>
		/// Specifies that document should print with line numbers.
		/// </summary>
		LineNumbers     = 0x1,
		/// <summary>
		/// Specifies that document should print with page numbers.
		/// </summary>
		PageNumbers     = 0x2,
		/// <summary>
		/// Specifies that document should print with wrapping lines if neccesary.
		/// </summary>
		WordWrap        = 0x4,
		/// <summary>
		/// Specifies that document should print only selected part of the text.
		/// </summary>
		PrintSelection  = 0x8,
		/// <summary>
		/// Specifies that document should print using colors.
		/// </summary>
		UseColors       = 0x10,
		/// <summary>
		/// Specifies that lexical analysis should be used for the document being printed.
		/// </summary>
		UseSyntax       = 0x20,
		/// <summary>
		/// Specifies that document should print with header.
		/// </summary>
		UseHeader       = 0x40,
		/// <summary>
		/// Specifies that document should print with footer.
		/// </summary>
		UseFooter       = 0x80,
		/// <summary>
		/// Specifies that progress of the printing operation should be displayed.
		/// </summary>
		DisplayProgress = 0x100 
	}

	/// <summary>
	/// Defines format for saving/loading Edit control's content.
	/// </summary>
	public enum ExportFormat
	{
		/// <summary>
		/// Specifies that text content should be exported in the standart text format.
		/// </summary>
		Text,
		/// <summary>
		/// Specifies that text content should be exported in the Rtf format.
		/// </summary>
		Rtf,
		/// <summary>
		/// Specifies that text content should be exported in the Html format.
		/// </summary>
		Html,
		/// <summary>
		/// Specifies that text content should be exported in the Xml format.
		/// </summary>
		Xml
	}
	
	/// <summary>
	/// Contains information about a part of the Edit control at a specified coordinate.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum HitTest 
	{
		/// <summary>
		/// No part.
		/// </summary>
		None            = 0x0, 
		/// <summary>
		/// Above the Edit control client area.
		/// </summary>
		Above           = 0x1, 
		/// <summary>
		/// Below the Edit control client area.
		/// </summary>
		Below           = 0x2, 
		/// <summary>
		/// Left to the Edit control client area.
		/// </summary>
		Left            = 0x4,
		/// <summary>
		/// Right to the Edit control client area.
		/// </summary>
		Right           = 0x8, 
		/// <summary>
		/// On the text.
		/// </summary>
		Text            = 0x10, 
		/// <summary>
		/// On the selected text.
		/// </summary>
		Selection       = 0x20,
		/// <summary>
		/// Beyond line end.
		/// </summary>
		BeyondEol       = 0x40,
		/// <summary>
		/// Beyond file end.
		/// </summary>
		BeyondEof       = 0x80,
		/// <summary>
		/// On the gutter area.
		/// </summary>
		Gutter          = 0x100, 
		/// <summary>
		/// On the margin area.
		/// </summary>
		Margin          = 0x200,
		/// <summary>
		/// On the gutter image.
		/// </summary>
		GutterImage     = 0x400,
		/// <summary>
		/// On the bookmark.
		/// </summary>
		BookMark        = 0x800, 
		/// <summary>
		/// On the outline area.
		/// </summary>
		OutlineArea     = 0x1000,
		/// <summary>
		/// On the outline image(plus/minus) button.
		/// </summary>
		OutlineImage    = 0x2000, 
		/// <summary>
		/// On the outline button.
		/// </summary>
		OutlineButton   = 0x4000,
		/// <summary>
		/// On the line modificator area.
		/// </summary>
		LineModificator = 0x8000,
		/// <summary>
		/// On the line numbers area.
		/// </summary>
		LineNumber      = 0x10000,
		/// <summary>
		/// On the hypertext.
		/// </summary>
		HyperText       = 0x20000,
		/// <summary>
		/// On the page.
		/// </summary>
		Page            = 0x40000,
		/// <summary>
		/// On the interval between pages.
		/// </summary>
		PageWhiteSpace  = 0x80000
	};
	/// <summary>
	/// DrawState is used to specify a custom drawing state, including information about elements of the control currently drawn.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum DrawState
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None            = 0x0,
		/// <summary>
		/// Entire control is currently drawing.
		/// </summary>
		Control         = 0x1,
		/// <summary>
		/// Text fragment is currently drawing.
		/// </summary>
		Text            = 0x2,
		/// <summary>
		/// Text currently drawn is selected.
		/// </summary>
		Selection       = 0x4,
		/// <summary>
		/// WhiteSpace is currently drawing.
		/// </summary>
		WhiteSpace      = 0x8,
		/// <summary>
		/// Line highlighter is currently drawing.
		/// </summary>
		LineHighlight   = 0x10,
		/// <summary>
		/// Line separator is currently drawing.
		/// </summary>
		LineSeparator   = 0x20,
		/// <summary>
		/// Line bookmark is currently drawing.
		/// </summary>
		LineBookMark    = 0x40,
		/// <summary>
		/// Brace is currently drawing.
		/// </summary>
		Brace           = 0x80,
		/// <summary>
		/// Space after end of line is currently drawing.
		/// </summary>
		BeyondEol       = 0x100,
		/// <summary>
		/// Space after end of file is currently drawing.
		/// </summary>
		BeyondEof       = 0x200,
		/// <summary>
		/// Gutter area is currently drawing.
		/// </summary>
		Gutter          = 0x400,
		/// <summary>
		/// Gutter bookmark or other gutter image is currently drawing.
		/// </summary>
		GutterImage     = 0x800,
		/// <summary>
		/// Bookmark is currently drawing.
		/// </summary>
		BookMark        = 0x1000,
		/// <summary>
		/// Line number are currently drawing.
		/// </summary>
		LineNumber      = 0x2000,
		/// <summary>
		/// Outline area is currently drawing.
		/// </summary>
		OutlineArea     = 0x4000,
		/// <summary>
		/// Outline image (plus/minus button) is currently drawing.
		/// </summary>
		OutlineImage    = 0x8000,
		/// <summary>
		/// Outline button is currently drawing.
		/// </summary>
		OutlineButton   = 0x10000,
		/// <summary>
		/// Line modificator is currently drawing.
		/// </summary>
		LineModificator = 0x20000,
		/// <summary>
		/// Mispelled wavy line is currently drawing.
		/// </summary>
		Spelling        = 0x40000,
		/// <summary>
		/// Syntax error wavy line is currently drawing.
		/// </summary>
		SyntaxError     = 0x80000,
		/// <summary>
		/// Edit page is currently drawing.
		/// </summary>
		Page            = 0x100000,
		/// <summary>
		/// Page header is currently drawing.
		/// </summary>
		PageHeader      = 0x200000,
		/// <summary>
		/// Page border is currently drawing.
		/// </summary>
		PageBorder      = 0x400000,
		/// <summary>
		/// Line Style is currently drawing.
		/// </summary>
		LineStyle       = 0x800000,
		/// <summary>
		/// Code snippet is currently drawing.
		/// </summary>
		CodeSnippet     = 0x1000000,
		/// <summary>
		/// User margin is currently drawing.
		/// </summary>
		UserMargin      = 0x2000000
	};
	/// <summary>
	/// DrawState is used to specify a stage in the custom drawing process.
	/// </summary>
	public enum DrawStage
	{
		/// <summary>
		/// After painting.
		/// </summary>
		Before,
		/// <summary>
		/// Before painting.
		/// </summary>
		After
	}
	/// <summary>
	/// Specifies the way of viewing Edit control's content.
	/// </summary>
	public enum PageType
	{
		/// <summary>
		/// Specifies normal view.
		/// </summary>
		Normal,
		/// <summary>
		/// Specifies dotted line to be displayed between separate pages.
		/// </summary>
		PageBreaks,
		/// <summary>
		/// Specifies page layout mode, allowing to see how text will be positioned on the printed page.
		/// </summary>
		PageLayout
	}

	/// <summary>
	/// Defines Edit ruler behaviour.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum RulerOptions
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None            = 0x0,
		/// <summary>
		/// Specifies that ruler indents chages its position in discrete steps. 
		/// </summary>
		Discrete        = 0x1, 
		/// <summary>
		/// Allows dragging ruler indentations.
		/// </summary>
		AllowDrag       = 0x2,
		/// <summary>
		/// Specifies dotted line to be displayed while ruler indentation being dragged.
		/// </summary>
		DisplayDragLine = 0x4
	}
	/// <summary>
	/// Specifies appearance of Edit control rulers.
	/// This enumeration has a <c>FlagsAttribute</c> attribute that allows a bitwise combination of its member values.
	/// </summary>
	[Flags]
	public enum EditRulers
	{
		/// <summary>
		/// Specifies that no flags are in effect.
		/// </summary>
		None      = 0x0,
		/// <summary>
		/// Display a horizontal ruler.
		/// </summary>
		Horizonal = 0x1,
		/// <summary>
		/// Display a vertical ruler.
		/// </summary>
		Vertical  = 0x2
	}
	/// <summary>
	/// Defines units for the ruler.
	/// </summary>
	public enum RulerUnits
	{
		/// <summary>
		/// Specifies that ruler marks are measured in milimeters.
		/// </summary>
		Milimeters,
		/// <summary>
		/// Specifies that ruler marks are measured in inches.
		/// </summary>
		Inches,
		/// <summary>
		/// Specifies that ruler marks are measured in pixels.
		/// </summary>
		Pixels,
		/// <summary>
		/// Specifies that ruler marks are measured in characters.
		/// </summary>
		Characters
	}
	#endregion

	#region Delegates
	
	/// <summary>
	/// Represents a method that will handle the key event.
	/// </summary>
	public delegate void KeyEvent();
	/// <summary>
	/// Represents a method that will handle extended key event.
	/// </summary>
	/// <param name="param">Object containing additional event data.</param>
	public delegate void KeyEventEx(object param);
	
	/// <summary>
	/// Represents a method that will handle string replacement event inside <c>Selection</c>
	/// </summary>
	/// <param name="s">String to be replaced.</param>
	public delegate string StringEvent(string s);
	
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.NeedCodeCompletion</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <c>CodeCompletionArgs</c> that contains the event data.</param>
	public delegate void CodeCompletionEvent(object sender, CodeCompletionArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.WordSpell</c>, <c>TextSource.WordSpell</c> or <c>Spelling.WordSpell</c> events.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>WordSpellEventArgs</c> that contains the event data.</param>
	public delegate void WordSpellEvent(object sender, WordSpellEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.CheckHyperText</c>, <c>TextSource.CheckHyperText</c> or <c>HyperTextEx.CheckHyperText</c> events.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>HyperTextEventArgs</c> that contains the event data.</param>
	public delegate void HyperTextEvent(object sender, HyperTextEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.JumpToUrl</c> or <c>HyperTextEx.JumpToUrl</c> events.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>UrlJumpEventArgs</c> that contains the event data.</param>
	public delegate void UrlJumpEvent(object sender, UrlJumpEventArgs e);

	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.SourceStateChanged</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>NotifyEventArgs</c> that contains the event data.</param>	
	public delegate void NotifyEvent(object sender, NotifyEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxPaint.CustomDraw</c>, <c>SyntaxEdit.CustomDraw</c> or <c>CodeCompletionHint.CustomDraw</c> events.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>CustomDrawEventArgs</c> that contains the event data.</param>	
	public delegate void CustomDrawEvent(object sender, CustomDrawEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.AutoCorrect</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>AutoCorrectEventArgs</c> that contains the event data.</param>	
	public delegate void AutoCorrectEvent(object sender, AutoCorrectEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.DrawHeader</c>, <c>EditPages.DrawHeader</c> or <c>CodeCompletionHint.CustomDraw</c> events.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>DrawHeaderEventArgs</c> that contains the event data.</param>	
	public delegate void DrawHeaderEvent(object sender, DrawHeaderEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>Printing.CreatePrintEdit</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>CreatePrintEditEventArgs</c> that contains the event data.</param>	
	public delegate void CreatePrintEditEvent(object sender, CreatePrintEditEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.DrawUserMargin</c>, <c>EditPages.DrawHeader</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>DrawUserMarginArgs</c> that contains the event data.</param>	
	public delegate void DrawUserMarginEvent(object sender, DrawUserMarginEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>SyntaxEdit.DrawUserMargin</c>, <c>FmtImport.ReadFormattedText</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>ReadFormattedTextEventArgs</c> that contains the event data.</param>	
	public delegate void ReadFormattedTextEvent(object sender, ReadFormattedTextEventArgs e);
	/// <summary>
	/// Represents a method that will handle the <c>ICodeCompletionWindow.KeyPreview</c> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A <c>KeyPreviewEventArgs</c> that contains the event data.</param>	
	public delegate void KeyPreviewEvent(object sender, KeyPreviewEventArgs e);

	#endregion

	#region EventArgs

	#region PositionChangedEventArgs
	/// <summary>
	/// Provides data for the event that occurs when the position within the text part of the <c>ITextSource</c> is changed.
	/// </summary>
	public class PositionChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Represents the reason of the position change, such as insert new symbol, delete symbol, navigate and so on.
		/// </summary>
		public UpdateReason Reason;
		/// <summary>
		/// Represents the horizontal displacement of the current position within the text of the <c>ITextSource</c>.
		/// </summary>
		public int DeltaX;
		/// <summary>
		/// Represents the vertical displacement of the current position within the text of the <c>ITextSource</c> control.
		/// </summary>
		public int DeltaY;
		/// <summary>
		/// Initializes a new instance of the <c>PositionChangedEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="reason">Reason of the position change.</param>
		/// <param name="deltaX">Horizontal displacement of the current position.</param>
		/// <param name="deltaY">Vertical displacement of the current position.</param>
		public PositionChangedEventArgs(UpdateReason reason, int deltaX, int deltaY)
		{
			Reason = reason;
			DeltaX = deltaX;
			DeltaY = deltaY;
		}
	}
	#endregion PositionChangedEventArgs

	#region BlockDeletingEventArgs
	/// <summary>
	/// Provides data for the event that occurs when some block of lines within the <c>ITextSource</c> is deleted.
	/// </summary>
	public class BlockDeletingEventArgs : EventArgs
	{
		/// <summary>
		/// Represents the rectangle area of block being deleted by <c>ITextSource</c>.
		/// </summary>
		public Rectangle Rect;
		/// <summary>
		/// Initializes a new instance of the <c>BlockDeletingEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="rect">Rectangulare are of the text being deleted.</param>
		public BlockDeletingEventArgs(Rectangle rect)
		{
			Rect = rect;
		}
	}
	#endregion BlockDeletingEventArgs

	#region NotifyEventArgs
	/// <summary>
	/// Provides data for the <c>NotifyEvent</c> handler.
	/// </summary>
	public class NotifyEventArgs : EventArgs
	{
		/// <summary>
		/// Represents the reason of change.
		/// </summary>
		public NotifyState State;
		/// <summary>
		/// Represents index of the first changed line in the text portion of the control.
		/// </summary>
		public int FirstChanged;
		/// <summary>
		/// Represents index of the last changed line in the text portion of the control.
		/// </summary>
		public int LastChanged;
		/// <summary>
		/// Indicates whether <c>ISyntaxEdit</c> control should update its scroll bars and caret position.
		/// </summary>
		public bool Update;
		/// <summary>
		/// Initializes a new instance of the <c>NotifyEventArgs</c> class with default settings.
		/// </summary>
		public NotifyEventArgs()
		{
			//
		}
		/// <summary>
		/// Initializes a new instance of the <c>NotifyEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="state">State of the new instance.</param>
		/// <param name="first">First changed line of new instance.</param>
		/// <param name="last">Last changed line of new instance.</param>
		/// <param name="update">Specifies Update field of the instance.</param>
		public NotifyEventArgs(NotifyState state, int first, int last, bool update)
		{
			State = state;
			FirstChanged = first;
			LastChanged = last;
			Update = update;
		}
	}
	#endregion NotifyEventArgs

	#region WordSpellEventArgs
	/// <summary>
	/// Provides data for the <c>WordSpellEvent</c> handler.
	/// </summary>
	public class WordSpellEventArgs : EventArgs
	{
		/// <summary>
		/// Represents string to check.
		/// </summary>
		public string Text;
		/// <summary>
		/// Represents a value indicating whether <c>WordSpellEventArgs.Text</c> has correct spelling.
		/// </summary>
		public bool Correct = true;
		/// <summary>
		/// Represents lexical style for <c>WordSpellEventArgs.Text</c>.
		/// This allows to skip checking spelling for keywords, numbers or identifiers.
		/// </summary>
		public int ColorStyle;
		/// <summary>
		/// Initializes a new instance of the <c>WordSpellEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="text">Text to check.</param>
		/// <param name="correct">Specifies whether text spelling is correct.</param>
		/// <param name="colorStyle">Color style for text to check-up.</param>
		public WordSpellEventArgs(string text, bool correct, int colorStyle)
		{
			Text = text;
			Correct = correct;
			ColorStyle = colorStyle;
		}
	}
	#endregion WordSpellEventArgs

	#region HyperTextEventArgs
	/// <summary>
	/// Provides data for the <c>HyperTextEvent</c> handler.
	/// </summary>
	public class HyperTextEventArgs : EventArgs
	{
		/// <summary>
		/// Contains string to check.
		/// </summary>
		public string Text;
		/// <summary>
		/// Returns value indicating whether <c>HyperTextEventArgs.Text</c> represents hypertext.
		/// </summary>
		public bool IsHyperText = false;
		/// <summary>
		/// Initializes a new instance of the <c>HyperTextEventArgs</c> class with specified Text and HyperText values.
		/// </summary>
		/// <param name="text">Specifies text to check.</param>
		/// <param name="isHyperText">Indicates whether given text represents hypertext.</param>
		public HyperTextEventArgs(string text, bool isHyperText)
		{
			Text = text;
			IsHyperText = isHyperText;
		}
	}
	#endregion HyperTextEventArgs

	#region UrlJumpEventArgs
	/// <summary>
	/// Provides data for the <c>UrlJumpEvent</c> handler.
	/// </summary>
	public class UrlJumpEventArgs : EventArgs
	{
		/// <summary>
		/// Represents the Url address.
		/// </summary>
		public string Text;
		/// <summary>
		/// Represents a value indicating whether jump to url event is handled, disabling opening default browser. By default this value is false.
		/// </summary>
		public bool Handled = false;
		/// <summary>
		/// Initializes a new instance of the <c>UrlJumpEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="text">The Url address.</param>
		/// <param name="handled">Specifies whether jump to url event already handled.</param>
		public UrlJumpEventArgs(string text, bool handled)
		{
			Text = text;
			Handled = handled;
		}
	}
	#endregion UrlJumpEventArgs
	
	#region CustomDrawEventArgs
	/// <summary>
	/// Provides data for the <c>CustomDrawEvent</c> handler.
	/// </summary>
	public class CustomDrawEventArgs : EventArgs
	{
		/// <summary>
		/// Represents Painter surface to draw on.
		/// </summary>
		public IPainter Painter;
		/// <summary>
		/// Specify a stage in the custom drawing process.
		/// </summary>
		public DrawStage DrawStage;
		/// <summary>
		/// Specify a custom drawing state, including information about elements of the control currently drawn.
		/// </summary>
		public DrawState DrawState;
		/// <summary>
		/// Specifiying rectangular area where Editor's content is drawn.
		/// </summary>
		public Rectangle Rect;
		/// <summary>
		/// Represents information about drawing text.
		/// </summary>
		public DrawInfo DrawInfo;
		/// <summary>
		/// Specifies whether painting is handled by an event, preventing control from default painting. This parameter is only used when DrawStage is DrawStage.Before.
		/// </summary>
		public bool Handled;
	}
	#endregion CustomDrawEventArgs
	
	#region AutoCorrectEventArgs
	/// <summary>
	/// Provides data for the <c>AutoCorrectEvent</c> handler.
	/// </summary>
	public class AutoCorrectEventArgs : EventArgs
	{	
		/// <summary>
		/// Represents words to correct.
		/// </summary>
		public string Word;
		/// <summary>
		/// Represents corrected word.
		/// </summary>
		public string CorrectWord;
		/// <summary>
		/// Represents a value indicating whether specified word is corrected.
		/// </summary>
		public bool HasCorrection;
	}
	#endregion

	#region DrawHeaderEventArgs
	/// <summary>
	/// Provides data for the <c>DrawHeaderEvent</c> handler.
	/// </summary>
	public class DrawHeaderEventArgs : EventArgs
	{
		/// <summary>
		/// String containing formatting elements used to format <c>DrawHeaderEventArgs.Text</c>.
		/// </summary>
		public string Tag;
		/// <summary>
		/// String to replace formatting tag.
		/// </summary>
		public string Text;
		/// <summary>
		/// Represents a value indicating whether draw header event is handled.
		/// </summary>
		public bool Handled = false;
		/// <summary>
		/// Initializes a new instance of the <c>DrawHeaderEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="tag">String containing formatting element.</param>
		public DrawHeaderEventArgs(string tag)
		{
			Tag = tag;
		}
	}
	#endregion DrawHeaderEventArgs

	#region DrawUserMarginEventArgs
	/// <summary>
	/// Provides data for the <c>DrawUserMarginEvent</c> handler.
	/// </summary>
	public class DrawUserMarginEventArgs : DrawHeaderEventArgs
	{
		/// <summary>
		/// Line number being drawn.
		/// </summary>
		public int Line;
		/// <summary>
		/// Initializes a new instance of the <c>DrawUserMarginEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="tag">String containing formatting element.</param>
		/// <param name="line">Line number being drawn.</param>
		public DrawUserMarginEventArgs(string tag, int line) : base(tag)
		{
			Line = line;
		}
	}
	#endregion DrawUserMarginEventArgs

	#region CreatePrintEditEventArgs
	/// <summary>
	/// Provides data for the <c>CreatePrintEdit</c> handler.
	/// </summary>
	public class CreatePrintEditEventArgs : EventArgs
	{
		/// <summary>
		/// Edit control that is created to be printed.
		/// </summary>
		public SyntaxEdit PrintEdit;
	}
	#endregion CreatePrintEditEventArgs
	
	#region RulerEventArgs
	/// <summary>
	/// Provides data for the <c>EditRuler.Change</c> handler.
	/// </summary>
	public class RulerEventArgs : EventArgs
	{
		/// <summary>
		/// Source of the ruler event.
		/// </summary>
		public object Object;
		/// <summary>
		/// Initializes a new instance of the <c>RulerEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="obj">The source of the event.</param>
		public RulerEventArgs(object obj)
		{
			Object = obj;
		}
	}
	#endregion RulerEventArgs
	
	#region ReadFormattedTextEventArgs
	/// <summary>
	/// Provides data for the <c>FmtImport.ReadFormattedText</c> handler.
	/// </summary>
	public class ReadFormattedTextEventArgs : EventArgs
	{
		/// <summary>
		/// Starting the text fragment.
		/// </summary>
		public string Text;
		/// <summary>
		/// Foreground color of the text fragment.
		/// </summary>
		public Color ForeColor;
		/// <summary>
		/// Background color of the text fragment.
		/// </summary>
		public Color BackColor;
		/// <summary>
		/// FontStyle of the text fragment.
		/// </summary>
		public FontStyle FontStyle;
		/// <summary>
		/// User-defined data.
		/// </summary>
		public object UserData;
	}
	#endregion

	#region KeyPreviewEventArgs
	/// <summary>
	/// Provides data for the <c>ICodeCompletionWindow.KeyPreviewEvent</c> handler.
	/// </summary>
	public class KeyPreviewEventArgs: EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <c>KeyPreviewEventArgs</c> class with specified parameters.
		/// </summary>
		/// <param name="m">Represents key message</param>
		public KeyPreviewEventArgs(Message m)
		{
			Message = m;
		}
		/// <summary>
		/// Key message
		/// </summary>
		public Message Message;
		/// <summary>
		/// Specifies whether painting is handled by an event, preventing further processing of the key message.
		/// </summary>
		public bool Handled;
	}
	#endregion

	
	
	#endregion

	#region Interfaces
	#region DrawInfo
	/// <summary>
	/// Contains full information about text fragment to be drawn.
	/// </summary>
	public struct DrawInfo
	{
		/// <summary>
		/// String to draw.
		/// </summary>
		public string Text;
		/// <summary>
		/// Specifies whether text fragment is selected.
		/// </summary>
		public bool Selection;
		/// <summary>
		/// Represents index of lexical style used to draw this text fragment.
		/// </summary>
		public short Style;
		/// <summary>
		/// Contains <c>ColorFlags</c> information for this text fragment.
		/// </summary>
		public ColorFlags Flags;
		/// <summary>
		/// The starting character of the text fragment.
		/// </summary>
		public int Char;
		/// <summary>
		/// The index of line in the text.
		/// </summary>
		public int Line;
		/// <summary>
		/// Specifies index of the image drawn on the gutter.
		/// </summary>
		public int GutterImage;
		/// <summary>
		/// Specifies index of page containing the text to be drawn.
		/// </summary>
		public int Page;

		/// <summary>
		/// Initializes <c>DrawInfo</c> structure with default values.
		/// </summary>
		public void Init()
		{
			Text = string.Empty;
			Selection = false;
			Style = - 1;
			Flags = ColorFlags.None;
			Char = - 1;
			Line = - 1;
			Page = - 1;
			GutterImage = - 1;
		}
	}
	#endregion DrawInfo

	#region HitTestInfo
	/// <summary>
	/// Contains information about an area of an Edit control.
	/// </summary>
	public struct HitTestInfo
	{
		/// <summary>
		/// Gets the <c>HitTest</c> that represents the area of the Edit control evaluated by the hit-test operation.
		/// </summary>
		public HitTest HitTest;
		/// <summary>
		/// Gets the index of line evaluated by the hit-test operation. Contains index of line if mouse is over text line in Edit control; -1 otherwise.
		/// </summary>
		public int Line;
		/// <summary>
		/// Gets the index of character within the line evaluated by the hit-test operation. Contains index of line if mouse is over some text in Edit control; -1 otherwise.
		/// </summary>
		public int Pos;
		/// <summary>
		/// Gets the <c>IStrItem</c> object evaluated by the hit-test operation. Contains instance of <c>IStrItem</c> object if mouse is over text line in Edit control; null otherwise.
		/// </summary>
		public IStrItem Item;
		/// <summary>
		/// Gets the text string evaluated by the hit-test operation. Contains string if mouse is over text line in Edit control; null otherwise.
		/// </summary>
		public string String;
		/// <summary>
		/// Gets the word evaluated by the hit-test operation. Contains string if mouse is over some word in Edit control; null otherwise.
		/// </summary>
		public string Word;
		/// <summary>
		/// Gets the hypertext string evaluated by the hit-test operation. Contains string if mouse is over hypertext section in Edit control; null otherwise.
		/// </summary>
		public string Url;
		/// <summary>
		/// Gets the <c>Gutter</c> ImageIndex, evaluated by the hit-test operation. Contains index of image if mouse is over the gutter image; - 1 otherwise.
		/// </summary>
		public int GutterImage;
		/// <summary>
		/// Gets the <c>IOutlineRange</c> object evaluated by the hit-test operation. Contains instance of <c>IOutlineRange</c> object if mouse is over outline button; null otherwise.
		/// </summary>
		public IOutlineRange OutlineRange;
		/// <summary> 
		/// Gets the index of page evaluated by the hit-test operation. Contains index of page if mouse is over text page in Edit control; null otherwise.
		/// </summary>
		public int Page;
		/// <summary> 
		/// Gets the index of lexical style evaluated by the hit-test operation. Contains index of lexical style if mouse is over the text; - 1 otherwise.
		/// </summary>
		public int Style;
		/// <summary> 
		/// Gets the set of additional flags for the text fragment evaluated by the hit-test operation.
		/// </summary>
		public ColorFlags ColorFlags;
		/// <summary>
		/// Initializes <c>HitTestInfo</c> object with default values.
		/// </summary>
		public void InitHitTestInfo()
		{
			HitTest = HitTest.None;
			Line = - 1;
			Pos = - 1;
			Item = null;
			String = null;
			Word = null;
			Url = null;
			GutterImage = - 1;
			OutlineRange = null;
			Page = - 1;
			Style = - 1;
			ColorFlags = ColorFlags.None;
		}
	}
	#endregion HitTestInfo

	#region IPageHeader
	/// <summary>
	/// Represents properties and methods for header/footer parts of edit page.
	/// </summary>
	public interface IPageHeader
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>IPageHeader</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IPageHeader</c> to assign.</param>
		void Assign(IPageHeader source);
		/// <summary>
		/// When implemented by a class, prevents header updating until calling <c>IPageHeader.EndUpdate</c> method.
		/// </summary>
		/// <returns>Number of header updating locks.</returns>
		int BeginUpdate();
		/// <summary>
		/// When implemented by a class, re-enables header updating, that was turn of by calling <c>IPageHeader.BeginUpdate</c> method.
		/// </summary>
		/// <returns>Number of header updating locks.</returns>
		int EndUpdate();
		/// <summary>
		/// When implemented by a class, invalidates the header.
		/// </summary>
		void Update();
		/// <summary>
		/// When implemented by a class, resets the <c>IPageHeader.Font</c> to the default value.
		/// </summary>
		void ResetFont();
		/// <summary>
		/// When implemented by a class, resets the <c>IPageHeader.Offset</c> to the default value.
		/// </summary>
		void ResetOffset();
		/// <summary>
		/// When implemented by a class, resets the <c>IPageHeader.FontColor</c> to the default value.
		/// </summary>
		void ResetFontColor();
		/// <summary>
		/// When implemented by a class, resets the <c>IPageHeader.ReverseOnEvenPages</c> to the default value.
		/// </summary>
		void ResetReverseOnEvenPages();
		/// <summary>
		/// When implemented by a class, draws page header/footer on the specified graphic surface.
		/// </summary>
		/// <param name="painter">Represents <c>IPainter</c> surface to draw on.</param>
		/// <param name="rect">Rectangular area of header/footer to draw on.</param>
		/// <param name="pageIndex">Index of page which header/footer is drawing.</param>
		/// <param name="pageCount">Total number of pages.</param>
		/// <param name="pageNumbers">Specifies whether header/footer should draw page number.</param>
		void Paint(IPainter painter, Rectangle rect, int pageIndex, int pageCount, bool pageNumbers);
		/// <summary>
		/// When implemented by a class, gets or sets a string that appears at the left part of the header/footer area.
		/// </summary>
		string LeftText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string that appears at the center of the header/footer area.
		/// </summary>
		string CenterText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string that appears at the right part of the header/footer area.
		/// </summary>
		string RightText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets font used to draw header/footer text.
		/// </summary>
		Font Font
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets font color used to draw header/footer text.
		/// </summary>
		Color FontColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets indentation of the primary text edge.
		/// </summary>
		Point Offset
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the <c>IPageHeader</c> is visible.
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the <c>LeftText</c> and <c>RightText</c> interchanging on even page.
		/// </summary>
		bool ReverseOnEvenPages
		{
			get;
			set;
		}

	}
	#endregion IPageHeader

	#region IPrinting
	/// <summary>
	/// Represents properties and methods for printing and print previewing of Edit control.
	/// </summary>
	public interface IPrinting 
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>IPrinting</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IPrinting</c> to assign.</param>
		void Assign(IPrinting source);
		/// <summary>
		/// When implemented by a class, sends <c>IPrinting.PrintDocument</c> content to the printer.
		/// </summary>
		void Print();
		/// <summary>
		/// When implemented by a class, initializes and runs print preview dialog.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult ExecutePrintPreviewDialog();
		/// <summary>
		/// When implemented by a class, initializes and runs print dialog.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult ExecutePrintDialog();
		/// <summary>
		/// When implemented by a class, initializes and runs page setup dialog.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult ExecutePageSetupDialog();
		/// <summary>
		/// When implemented by a class, initializes and runs print options dialog.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult ExecutePrintOptionsDialog();
		
		/// <summary>
		/// When implemented by a class, resets <c>IPrinting.Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		/// <summary>
		/// When implemented by a class, resets <c>IPrinting.AllowedOptions</c> to the default value.
		/// </summary>
		void ResetAllowedOptions();
		
		/// <summary>
		/// When implemented by a class, represents document to print, print preview or setup.
		/// </summary>
		PrintDocument PrintDocument
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents settings for print document.
		/// </summary>
		PrinterSettings PrinterSettings
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets <c>PrintOptions</c> that determines printing behaviour.
		/// </summary>
		PrintOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets Print Options dialog options, that can be changed by user.
		/// </summary>
		PrintOptions AllowedOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents <c>IPageHeader</c> object to draw header of printing document.
		/// </summary>
		IPageHeader Header
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents <c>IPageHeader</c> object to draw footer of printing document.
		/// </summary>
		IPageHeader Footer
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents a dialog box that allows users to select a printer and choose which portions of the document to print.
		/// </summary>
		PrintDialog PrintDialog
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a dialog box that allows users to manipulate page settings, including margins and paper orientation.
		/// </summary>
		PageSetupDialog PageSetupDialog
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a dialog box that allows user to preview print document.
		/// </summary>
		PrintPreviewDialog PrintPreviewDialog
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides a dialog box that allows users to manipulate print settings.
		/// </summary>
		IPrintOptionsDialog PrintOptionsDialog
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when Edit control to print is about to be created.
		/// </summary>
		event CreatePrintEditEvent CreatePrintEdit;
		/// <summary>
		/// When implemented by a class, occurs when document to print is initialized.
		/// </summary>
		event EventHandler Initialized;
	}
	#endregion IPrinting
	
	#region IStrItem
	/// <summary>
	/// Represents properties and methods of individual line in the Text Source.
	/// </summary>
	public interface IStrItem
	{
		/// <summary>
		/// When implemented by a class, sets color information to <c>IStrItem.ColorData</c>.
		/// </summary>
		/// <param name="start">Specifies the first character in <c>IStrItem.ColorData</c> to set.</param>
		/// <param name="len">Specifies number of characters in <c>IStrItem.ColorData</c> to set.</param>
		/// <param name="flag">Specifies color information to set.</param>
		/// <param name="setFlag">Indicates whether Color information from flag should be set or removed</param>
		void SetColorFlag(int start, int len, ColorFlags flag, bool setFlag);
		/// <summary>
		/// When implemented by a class, retrieves color information from <c>IStrItem.ColorData</c>.
		/// </summary>
		/// <param name="pos">Specifies position in <c>IStrItem.ColorData</c> to obtain color information.</param>
		/// <param name="flag">Receives color information.</param>
		void GetColorFlag(int pos, out ColorFlags flag);
		/// <summary>
		/// When implemented by a class, gets or sets string content of the <c>IStrItem</c>.
		/// </summary>
		string String
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets color information of the <c>IStrItem</c>.
		/// </summary>
		short[] ColorData
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets current state of the <c>IStrItem</c>.
		/// </summary>
		StrItemState State
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets index of lexical state at item end.
		/// </summary>
		int LexState
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets index of lexical state at item start.
		/// </summary>
		int PrevLexState
		{
			get;
			set;
		}
	}
	#endregion

	#region ITabulation
	/// <summary>
	/// Represents properties and methods for handling tabulations within the text.
	/// </summary>
	public interface ITabulation
	{
		/// <summary>
		/// When implemented by a class, resets the <c>ITabulation.TabStops</c> to the default value.
		/// </summary>
		void ResetTabStops();
		/// <summary>
		/// When implemented by a class, resets the <c>ITabulation.UseSpaces</c> to the default value.
		/// </summary>
		void ResetUseSpaces();
		
		/// <summary>
		/// When implemented by a class, gets or sets the character columns that the cursor will move to each time you press Tab.
		/// </summary>
		int[] TabStops
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether indent or TAB operations insert space characters rather than TAB characters.
		/// </summary>
		bool UseSpaces
		{
			get;
			set;
		}
	}
	#endregion ITabulation

	#region ITabulationEx
	/// <summary>
	/// Represents extended methods for handling tabulations within the text.
	/// <seealso cref="QWhale.Editor.ITabulation"/>
	/// </summary>
	public interface ITabulationEx : ITabulation
	{
		/// <summary>
		/// When implemented by a class, converts all tab character to spaces depending on <c>ITabulation.TabStops</c> property.
		/// </summary>
		/// <param name="s">Text to convert.</param>
		/// <returns>Tabbed string.</returns>
		string GetTabString(string s);
		/// <summary>
		/// When implemented by a class, returns number of spaces to the next TabStop at the specified position.
		/// <seealso cref="QWhale.Editor.ITabulationEx.GetPrevTabStop"/>
		/// </summary>
		/// <param name="pos">Position to check.</param>
		/// <returns>Number of spaces.</returns>
		int GetTabStop(int pos);
		/// <summary>
		/// When implemented by a class, returns number of spaces to the previous TabStop.
		/// <seealso cref="QWhale.Editor.ITabulationEx.GetTabStop"/>
		/// </summary>
		/// <param name="pos">Position to check.</param>
		/// <returns>Number of spaces.</returns>
		int GetPrevTabStop(int pos);
		/// <summary>
		/// When implemented by a class, returns indentation string which consist of tabs and spaces.
		/// </summary>
		/// <param name="count">Specifies number of characters in the string.</param>
		/// <param name="pos">Specifies start position of the string.</param>
		/// <returns>Indented string that containing tabs and spaces.</returns>
		string GetIndentString(int count, int pos);
		/// <summary>
		/// When implemented by a class, returns specified position within given string as untabbed position.
		/// </summary>
		/// <param name="s">Specifies string to convert.</param>
		/// <param name="pos">Specifies index of character which position should be converted.</param>
		/// <returns>Untabbed position.</returns>
		int TabPosToPos(string s, int pos);
		/// <summary>
		/// When implemented by a class, returns specified position within given string as tabbed position.
		/// </summary>
		/// <param name="s">Specifies string to check.</param>
		/// <param name="pos">Positon of the character in the string.</param>
		/// <returns>Tabbed position.</returns>
		int PosToTabPos(string s, int pos);
	}
	#endregion ITabulationEx

	#region IExportEx
	/// <summary>
	/// Represents methods to save text content.
	/// </summary>
	public interface IExportEx : IExport
	{
		/// <summary>
		/// When implemented by a class, gets or sets a string value that terminates line.
		/// </summary>
		string LineTerminator
		{
			get;
			set;
		}
	}
	#endregion IExportEx

	#region IFmtExport
	/// <summary>
	/// Represents methods to save text content in the specified format.
	/// </summary>
	public interface IFmtExport : IExport
	{
		/// <summary>
		/// When implemented by a class, saves content to the given file in the specific format.
		/// </summary>
		/// <param name="fileName">Name of file to save content.</param>
		/// <param name="format">Specifies output format.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveFile(string fileName, ExportFormat format);
		/// <summary>
		/// When implemented by a class, saves content to the given file in the specific format with specific encoding.
		/// </summary>
		/// <param name="fileName">Name of file to save content.</param>
		/// <param name="format">Specifies output format.</param>
		/// <param name="encoding">Specifies the character encoding to use.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveFile(string fileName, ExportFormat format, Encoding encoding);
		/// <summary>
		/// When implemented by a class, saves the text content to the given stream in the specific format.
		/// </summary>
		/// <param name="writer">The TextWriter object to write text to stream.</param>
		/// <param name="format">Specifies format of the stream.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveStream(TextWriter writer, ExportFormat format);
		/// <summary>
		/// When implemented by a class, saves the text content to the given stream in the specific format.
		/// </summary>
		/// <param name="stream">The Stream object to write the text.</param>
		/// <param name="format">Specifies format of the stream.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveStream(Stream stream, ExportFormat format);
		/// <summary>
		/// When implemented by a class, saves the text content to the given stream in the specific format.
		/// </summary>
		/// <param name="stream">The Stream object to write the text.</param>
		/// <param name="format">Specifies format of the stream.</param>
		/// <param name="encoding">Specifies the character encoding to use.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool SaveStream(Stream stream, ExportFormat format, Encoding encoding);
	}
	#endregion IFmtExport

	#region IFmtExportEx
	/// <summary>
	/// Represents methods to save text content in the specified format.
	/// </summary>
	public interface IFmtExportEx : IFmtExport
	{
		/// <summary>
		/// When implemented by a class, gets or sets a string value that terminates line.
		/// </summary>
		string LineTerminator
		{
			get;
			set;
		}
	}
	#endregion IFmtExportEx

	#region IFmtImport
	/// <summary>
	/// Represents methods to load text content from the specified format.
	/// </summary>
	public interface IFmtImport : IImport
	{
		/// <summary>
		/// When implemented by a class, loads to string collection text from given file in the specific format.
		/// </summary>
		/// <param name="fileName">Represents name of file from which text must be loaded.</param>
		/// <param name="format">Specifies format to load file content.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadFile(string fileName, ExportFormat format);
		/// <summary>
		/// When implemented by a class, loads text to to string collection from given file in the specific format with specific encoding.
		/// </summary>
		/// <param name="fileName">Represents name of file from which text must be loaded.</param>
		/// <param name="format">Specifies format to load file content.</param>
		/// <param name="encoding">Specifies the character encoding to use.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadFile(string fileName, ExportFormat format, Encoding encoding);
		/// <summary>
		/// When implemented by a class, loads the contents of the given stream with specified format.
		/// </summary>
		/// <param name="reader">The TextReader object to read text.</param>
		/// <param name="format">Specifies format to load the content.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadStream(TextReader reader, ExportFormat format);
		/// <summary>
		/// When implemented by a class, loads the contents of the given stream with specified format.
		/// </summary>
		/// <param name="stream">The Stream object to read text.</param>
		/// <param name="format">Specifies format to load the content.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadStream(Stream stream, ExportFormat format);
		/// <summary>
		/// When implemented by a class, loads the contents of the given stream with specified format.
		/// </summary>
		/// <param name="stream">The Stream object to read text.</param>
		/// <param name="format">Specifies format to load the content.</param>
		/// <param name="encoding">Specifies the character encoding to use.</param>
		/// <returns>True is succeed; otherwise false.</returns>
		bool LoadStream(Stream stream, ExportFormat format, Encoding encoding);

	}
	#endregion IFmtImport

	#region ITextSearch
	/// <summary>
	/// Represents method used to search text within the string collection.
	/// </summary>
	public interface ITextSearch
	{
		/// <summary>
		/// When implemented by a class, searches for given text within the control's text content.
		/// </summary>
		/// <param name="s">The text to locate in the collection.</param>
		/// <param name="options">Specifies parameters of search.</param>
		/// <param name="expression">Represents a regular expression to find text.</param>
		/// <param name="position">Position in strings collection to start search.</param>
		/// <param name="len">Receives length of the found text.</param>
		/// <param name="match">Receives match if regular expression search successfull</param>
		/// <returns>True if search succeed; otherwise false.</returns>
		/// <remarks>If search succeed Position parameter receive location of the found text.</remarks>
		bool Find(string s, SearchOptions options, Regex expression, ref Point position, out int len, out Match match);
	}
	#endregion ITextSearch

	#region ISearch
	/// <summary>
	/// Represents properties and methods used to search and replace control's text content.
	/// </summary>
	public interface ISearch : ITextSearch
	{
		/// <summary>
		/// When implemented by a class, searches for given text within the control's contents.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <returns>True if search succeed; otherwise false.</returns>
		bool Find(string text);
		/// <summary>
		/// When implemented by a class, searches for given text within the control's contents with specified options.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="options">Represents options to search text.</param>
		/// <returns>True if search succeed; otherwise false.</returns>
		bool Find(string text, SearchOptions options);
		/// <summary>
		/// When implemented by a class, searches for given text within the control's contents with specified options using specified regular expression.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="options">Represents options to search text.</param>
		/// <param name="expression">Represents a regular expression to find text.</param>
		/// <returns>True if search succeed; otherwise false.</returns>
		bool Find(string text, SearchOptions options, Regex expression);
		/// <summary>
		/// When implemented by a class, searches for all occurences of given text within the control's contents with specified options using specified regular expression.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="options">Represents options to search text.</param>
		/// <param name="expression">Represents a regular expression to find text.</param>
		/// <param name="searchResults">Represents list of ranges determining search results.</param>
		/// <returns>True if search succeed; otherwise false.</returns>
		bool Find(string text, SearchOptions options, Regex expression, IList ranges);
		/// <summary>
		/// When implemented by a class, searches for the next occurence of the text specified by previous search.
		/// </summary>
		/// <returns>True if search succeed; otherwise false.</returns>
		bool FindNext();
		/// <summary>
		/// When implemented by a class, searches for the previous occurence of the text specified by previous search.
		/// </summary>
		/// <returns>True if search succeed; otherwise false.</returns>
		bool FindPrevious();
		/// <summary>
		/// When implemented by a class, searches for the next occurence of the selected text.
		/// </summary>
		/// <returns>True if search succeed; otherwise false.</returns>
		bool FindNextSelected();
		/// <summary>
		/// When implemented by a class, searches for the previous occurence of the selected text.
		/// </summary>
		/// <returns>True if search succeed; otherwise false.</returns>
		bool FindPreviousSelected();

		/// <summary>
		/// When implemented by a class, indicates whether search engine can find next occurence of the text specified by previous search or it is only first attempt to search.
		/// </summary>
		/// <returns>False if it is the first attempt to search; otherwise true.</returns>
		bool CanFindNext();
		/// <summary>
		/// When implemented by a class, indicates whether search engine can find previous occurence of the text specified to search or it is the first attempt to search.
		/// </summary>
		/// <returns>False if it is the first attempt to search; otherwise true.</returns>
		bool CanFindPrevious();
		/// <summary>
		/// When implemented by a class, indicates whether search engine can find next occurence of the selected text or it is the first attempt to search.
		/// </summary>
		/// <returns>False if it is the first attempt to search or no text selected; otherwise true.</returns>
		bool CanFindNextSelected();
		/// <summary>
		/// When implemented by a class, indicates whether search engine can find previous occurence of the selected text or it is the first attempt to search.
		/// </summary>
		/// <returns>False if it is the first attempt to search or no text selected; otherwise true.</returns>
		bool CanFindPreviousSelected();
		/// <summary>
		/// When implemented by a class, searches for the first occurrence of given text within the text content and if succeed replaces it by specified string.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="replaceWith">Text to replace.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool Replace(string text, string replaceWith);
		/// <summary>
		/// When implemented by a class, searches for first occurrence given text within the text content with specified options and if succeed replaces it by specified string.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="replaceWith">Text to replace.</param>
		/// <param name="options">Represents options to search text.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool Replace(string text, string replaceWith, SearchOptions options);
		/// <summary>
		/// When implemented by a class, searches for first occurrence given text within the text content with specified options using specified regular expression and if succeed replaces it by specified string.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="replaceWith">Text to replace.</param>
		/// <param name="options">Represents options to search text.</param>
		/// <param name="expression">Represents a regular expression to find text.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool Replace(string text, string replaceWith, SearchOptions options, Regex expression);
		/// <summary>
		/// When implemented by a class, replaces all occurrences of given text within class text content by specified replaceWith string.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="replaceWith">Text to replace.</param>
		/// <returns>Number of replaced occurrences.</returns>
		int ReplaceAll(string text, string replaceWith);
		/// <summary>
		/// When implemented by a class, replaces all occurrences of given text within text content by specified replaceWith string.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="replaceWith">Text to replace.</param>
		/// <param name="options">Represents options to search text.</param>
		/// <returns>Number of replaced occurrences.</returns>
		int ReplaceAll(string text, string replaceWith, SearchOptions options);
		/// <summary>
		/// When implemented by a class, replaces all occurrences of given text within class text content by specified replaceWith string.
		/// </summary>
		/// <param name="text">Text to find.</param>
		/// <param name="replaceWith">Text to replace.</param>
		/// <param name="options">Represents options to search text.</param>
		/// <param name="expression">Represents a regular expression to find text.</param>
		/// <returns>Number of replaced occurrences.</returns>
		int ReplaceAll(string text, string replaceWith, SearchOptions options, Regex expression);
		/// <summary>
		/// When implemented by a class, marks all occurrences of specified string in the class text content by unnumbered bookmarks and moves to the last occurrence.
		/// </summary>
		/// <param name="text">Specifies text to mark.</param>
		/// <returns>Number of found occurrences.</returns>
		int MarkAll(string text);
		/// <summary>
		/// When implemented by a class, marks all occurrences of specified string in the class text content by unnumbered bookmarks and moves to the last occurrence.
		/// </summary>
		/// <param name="text">Specifies text to mark.</param>
		/// <param name="options">Specifies parameters of search.</param>
		/// <returns>Number of found occurrences.</returns>
		int MarkAll(string text, SearchOptions options);
		/// <summary>
		/// When implemented by a class, marks all occurrences of specified string in the class text content by unnumbered bookmarks and moves to the last occurrence.
		/// </summary>
		/// <param name="text">Specifies text to mark.</param>
		/// <param name="options">Specifies parameters of search.</param>
		/// <param name="expression">Represents a regular expression to find text.</param>
		/// <returns>Number of found occurrences.</returns>
		int MarkAll(string text, SearchOptions options, Regex expression);
		/// <summary>
		/// When implemented by a class, indicates whether search engine need to replace successfully found and selected text.
		/// </summary>
		/// <param name="match">Receives match if regular expression search successfull</param>
		/// <returns>True if selected text matches search text; otherwise false.</returns>
		bool NeedReplaceCurrent(out Match match);
		/// <summary>
		/// When implemented by a class, replaces currently selected text.
		/// </summary>
		/// <param name="replaceWith">Text to replace.</param>
		/// <param name="options">Specifies parameters of search and replace.</param>
		/// <param name="match">Represents Match object if regular expression search successfull.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool ReplaceCurrent(string replaceWith, SearchOptions options, Match match);
		/// <summary>
		/// When implemented by a class, enters control to the incremental search state.
		/// <seealso cref="QWhale.Editor.ISearch.FinishIncrementalSearch"/>
		/// </summary>
		void StartIncrementalSearch();
		/// <summary>
		/// When implemented by a class, enters control to the incremental search state.
		/// <seealso cref="QWhale.Editor.ISearch.FinishIncrementalSearch"/>
		/// </summary>
		/// <param name="backwardSearch">Indicates that search should be executed towards the beginning of text.</param>
		void StartIncrementalSearch(bool backwardSearch);
		/// <summary>
		/// When implemented by a class, leaves control from the incremental search state.
		/// <seealso cref="QWhale.Editor.ISearch.StartIncrementalSearch"/>
		/// </summary>
		void FinishIncrementalSearch();
		/// <summary>
		/// When implemented by a class, finds given text incrementally.
		/// </summary>
		/// <param name="key">Additional value to seach text.</param>
		/// <param name="deleteLast">Specifies whether search text should be altered by adding Key string.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool IncrementalSearch(string key, bool deleteLast);
		/// <summary>
		/// When implemented by a class, returns word at the cursor position.
		/// </summary>
		/// <returns>Word at the cursor position.</returns>
		string GetTextToSearchAtCursor();
		/// <summary>
		/// When implemented by a class, returns whether search can be performed inside selection.
		/// </summary>
		/// <param name="selectedText">Specifies the text being selected.</param>
		/// <returns>True if selection is not empty; otherwise false</returns>
		bool CanSearchSelection(out string selectedText);
		/// <summary>
		/// When implemented by a class, displays "searched text not found" message box.
		/// </summary>
		/// <param name="caption">Specifies caption of the message dialog.</param>
		void ShowNotFound(string caption);
		/// <summary>
		/// When implemented by a class, indicates whether control is in incremental search state.
		/// </summary>
		bool InIncrementalSearch
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, return text to search if class is in incremental search state; otherwise return empty string.
		/// </summary>
		string IncrementalSearchString
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that represents position of the last found text.
		/// </summary>
		Point SearchPos
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that defines search and replace options.
		/// </summary>
		SearchOptions SearchOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents length of the last found text.
		/// </summary>
		int SearchLen
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether control launches text search at first.
		/// </summary>
		bool FirstSearch
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a dialog box allowing to search for the text or replace it.
		/// </summary>
		ISearchDialog SearchDialog
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a dialog prompting for index of the line you need to locate.
		/// </summary>
		IGotoLineDialog GotoLineDialog
		{
			get;
			set;
		}
	}
	#endregion ISearch

	#region ISyntaxStrings
	/// <summary>
	/// Represents a collection of strings with extended possibilities.
	/// </summary>
    public interface ISyntaxStrings : IStringList, ITextSearch, IExport, IImport, IFmtExport, 
		ITabulationEx, IWordBreak, INotifyEx
	{
		/// <summary>
		/// When implemented by a class, adds a new item to the end of string collection.
		/// </summary>
		/// <param name="value">String to be added to the end of the collection.</param>
		/// <returns>Index of new added item.</returns>
		int Add(string value);
		/// <summary>
		/// When implemented by a class, removes all items from string collection.
		/// </summary>
		void Clear();
		/// <summary>
		/// When implemented by a class, indicates whether string collection contains specified string.
		/// </summary>
		/// <param name="value">string to check.</param>
		/// <returns>True if contains; otherwise false.</returns>
		bool Contains(string value);
		/// <summary>
		/// When implemented by a class, returns the index of the first occurrence of given string in the string collection.
		/// </summary>
		/// <param name="value">The string to locate in string collection.</param>
		/// <returns>The index of the first occurrence of string within the string collection, if found; otherwise -1.</returns>
		int IndexOf(string value);
		/// <summary>
		/// When implemented by a class, inserts value at the specified position.
		/// </summary>
		/// <param name="index">Specifies position to insert.</param>
		/// <param name="value">Specifies string to insert.</param>
		void Insert(int index, string value);
		/// <summary>
		/// When implemented by a class, removes the first occurrence of given string from the string collection.
		/// </summary>
		/// <param name="value">String to remove.</param>
		void Remove(string value);
		/// <summary>
		/// When implemented by a class, removes string item at specified position.
		/// </summary>
		/// <param name="index">Specifies index of item in the string collection to remove.</param>
		void RemoveAt(int index);
		/// <summary>
		/// When implemented by a class, returns the <c>IStrItem</c> object at the given position of the collection.
		/// </summary>
		/// <param name="index">Index of item in the collection.</param>
		/// <returns><c>IStrItem</c> object at specified position.</returns>
		IStrItem GetItem(int index);
		/// <summary>
		/// When implemented by a class, returns length of the string that corresponds to specified item in the collection.
		/// </summary>
		/// <param name="index">Index of item in the collection.</param>
		/// <returns>If collection do not contain specified item method returns 0.</returns>
		int GetLength(int index);
		/// <summary>
		/// When implemented by a class, notifies about string state changing.
		/// </summary>
		/// <param name="index">Index of string to update.</param>
		void Changed(int index);
		/// <summary>
		/// When implemented by a class, notifies about string state changing.
		/// </summary>
		/// <param name="first">Index of the first string to update.</param>
		/// <param name="last">Index of the last string to update.</param>
		void Changed(int first, int last);
		/// <summary>
		/// When implemented by a class, converts string collection to the array list. 
		/// </summary>
		/// <returns>IList representation of the <c>ISyntaxStrings</c> content.</returns>
		IList ToArrayList();
		/// <summary>
		/// When implemented by a class, converts string collection to the array of strings.
		/// </summary>
		/// <returns>Array of strings that represents <c>ISyntaxStrings</c> content.</returns>
		string[] ToStringArray();
		/// <summary>
		/// When implemented by a class, returns character from specified position.
		/// </summary>
		/// <param name="x">Specifies position of character in string.</param>
		/// <param name="y">Specifies index of item in string collection.</param>
		/// <returns>Characted from specified position.</returns>
		char GetCharAt(int x, int y);
		/// <summary>
		/// When implemented by a class, returns character from specified position.
		/// </summary>
		/// <param name="position">Position of character where Y is index of item in string collection and X is index of character in this string.</param>
		/// <returns>Characted from specified position.</returns>
		char GetCharAt(Point position);
		/// <summary>
		/// When implemented by a class, returns lexical style at specified position.
		/// </summary>
		/// <param name="position">Position of style where Y is index of item in string collection and X is index of character in this string.</param>
		/// <returns>Lexical style at specified position.</returns>
		int GetLexStyle(Point position);
		/// <summary>
		/// When implemented by a class, performs additional actions after <c>ISyntaxStrings</c> saves its content to the file.
		/// </summary>
		void AfterSave();
		/// <summary>
		/// When implemented by a class, converts given Point value to the absolute position.
		/// </summary>
		/// <param name="position">Point value where Y-Coordinate represents index of line and X-Coordinate - index of character in this line.</param>
		/// <returns>Absolute position of given point.</returns>
		int TextPointToAbsolutePosition(Point position);
		/// <summary>
		/// When implemented by a class, converts given absolute position to position as Point value.
		/// </summary>
		/// <param name="position">Specifies index of character if the text considered as a single string.</param>
		/// <returns>Point value where Y-Coordinate represents index of line and X-Coordinate - index of character in this line.</returns>
		Point AbsolutePositionToTextPoint(int position);
		/// <summary>
		/// When implemented by a class, gets the text source owning the <c>ISyntaxStrings</c>.
		/// </summary>
		ITextSource Source
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual string stored in the collection.
		/// </summary>
		new string this[int index]
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or set a boolean value thet indicates whether <c>ISyntaxStrings</c> should remove trailing spaces from the end of each its strings.
		/// </summary>
		bool RemoveTrailingSpaces
		{
			get;
			set;
		}
	}
	#endregion ISyntaxStrings

	#region INavigate
	/// <summary>
	/// Represents properties and methods allowing to navigate within the Edit control's text content.
	/// </summary>
	public interface INavigate
	{
		/// <summary>
		/// When implemented by a class, moves current position by the given offset value.
		/// </summary>
		/// <param name="deltaX">Horizontal offset.</param>
		/// <param name="deltaY">Vertical offset.</param>
		void Navigate(int deltaX, int deltaY);
		/// <summary>
		/// When implemented by a class, moves the current position to the given position.
		/// </summary>
		/// <param name="x">Index of character in the line to move to.</param>
		/// <param name="y">Index of line to move to.</param>
		void MoveTo(int x, int y);
		/// <summary>
		/// When implemented by a class, moves the current position to the given position.
		/// </summary>
		/// <param name="position">New location of the current position.</param>
		void MoveTo(Point position);
		/// <summary>
		/// When implemented by a class, moves the current position to the specified character in the current line.
		/// </summary>
		/// <param name="x">Index of character in the current line to move to.</param>
		void MoveToChar(int x);
		/// <summary>
		/// When implemented by a class, moves the current position to the specified line.
		/// </summary>
		/// <param name="y">Index of line to move to.</param>
		void MoveToLine(int y);
		/// <summary>
		/// When implemented by a class, validates given position within control's text content.
		/// </summary>
		/// <param name="position">Position to validate.</param>
		void ValidatePosition(ref Point position);
		/// <summary>
		/// When implemented by a class, stores given position to stored position list.
		/// </summary>
		/// <param name="position">Position to store.</param>
		/// <returns>Index of stored position in list.</returns>
		int StorePosition(Point position);
		/// <summary>
		/// When implemented by a class, restores position from stored position list by given index.
		/// </summary>
		/// <param name="index">Index of position to restore.</param>
		/// <returns>Point value that represents stored position.</returns>
		Point RestorePosition(int index);
		
		/// <summary>
		/// When implemented by a class, resets the <c>NavigateOptions</c> to the default value.
		/// </summary>
		void ResetNavigateOptions();
		
		/// <summary>
		/// When implemented by a class, gets or sets navigating options.
		/// </summary>
		NavigateOptions NavigateOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets current position within the control's text content.
		/// </summary>
		Point Position
		{
			get;
			set;
		}
	}
	#endregion INavigate

	#region INavigateEx
	/// <summary>
	/// Represents additional methods to navigate within the Edit control's text content.
	/// </summary>
	public interface INavigateEx : INavigate
	{
		/// <summary>
		/// When implemented by a class, moves the current position one character to the left.
		/// </summary>
		void MoveCharLeft();
		/// <summary>
		/// When implemented by a class, moves the current position one character to the right.
		/// </summary>
		void MoveCharRight();
		/// <summary>
		/// When implemented by a class, moves the current position one word to the left.
		/// </summary>
		void MoveWordLeft();
		/// <summary>
		/// When implemented by a class, moves the current position one word to the right.
		/// </summary>
		void MoveWordRight();
		/// <summary>
		/// When implemented by a class, moves the current position to the previous line.
		/// </summary>
		void MoveLineUp();
		/// <summary>
		/// When implemented by a class, moves the current position to the next line.
		/// </summary>
		void MoveLineDown();
		/// <summary>
		/// When implemented by a class, moves the current position to the first character of current line.
		/// </summary>
		void MoveLineBegin();
		/// <summary>
		/// When implemented by a class, moves the current position to the last character of current line.
		/// </summary>
		void MoveLineEnd();
		/// <summary>
		/// When implemented by a class, moves the current position to the first not whitespace character/first character of current line.
		/// </summary>
		void MoveLineBeginCycled();
		/// <summary>
		/// When implemented by a class, moves the current position to the last not whitespace character/last character of current line.
		/// </summary>
		void MoveLineEndCycled();
		/// <summary>
		/// When implemented by a class, moves the current position to the first character of the first line.
		/// </summary>
		void MoveFileBegin();
		/// <summary>
		/// When implemented by a class, moves the current position to the last character of the last line.
		/// </summary>
		void MoveFileEnd();
		/// <summary>
		/// When implemented by a class, moves current position to the previous page.
		/// </summary>
		void MovePageUp();
		/// <summary>
		/// When implemented by a class, moves current position to the next page.
		/// </summary>
		void MovePageDown();
		/// <summary>
		/// When implemented by a class, moves the current position to the top of the screen.
		/// </summary>
		void MoveScreenTop();
		/// <summary>
		/// When implemented by a class, moves the current position to the bottom of the screen.
		/// </summary>
		void MoveScreenBottom();
		/// <summary>
		/// When implemented by a class, scrolls text content one line up.
		/// </summary>
		void ScrollLineUp();
		/// <summary>
		/// When implemented by a class, scrolls text content one line down.
		/// </summary>
		void ScrollLineDown();
		/// <summary>
		/// When implemented by a class, moves the current position to the prev open brace in the text content.
		/// </summary>
		void MoveToOpenBrace();
		/// <summary>
		/// When implemented by a class, moves the current position to the next close brace in the text content.
		/// </summary>
		void MoveToCloseBrace();
		/// <summary>
		/// When implemented by a class, moves the current position to the next open or close brace in the text content.
		/// </summary>
		void MoveToBrace();
	}
	#endregion INavigateEx

	#region IEdit
	/// <summary>
	/// Represents properties and methods used for editing the text.
	/// </summary>
	public interface IEdit
	{
		/// <summary>
		/// When implemented by a class, resets the <c>Readonly</c> to the default value.
		/// </summary>
		void ResetReadonly();
		/// <summary>
		/// When implemented by a class, resets the <c>OverWrite</c> to the default value.
		/// </summary>
		void ResetOverWrite();
		/// <summary>
		/// When implemented by a class, resets the <c>Modified</c> to the default value.
		/// </summary>
		void ResetModified();
		/// <summary>
		/// When implemented by a class, resets the <c>IndentOptions</c> to the default value.
		/// </summary>
		void ResetIndentOptions();
		/// <summary>
		/// When implemented by a class, resets the <c>MaxLength</c> to the default value.
		/// </summary>
		void ResetMaxLength();
		/// <summary>
		/// When implemented by a class, resets the <c>SingleLineMode</c> to the default value.
		/// </summary>
		void ResetSingleLineMode();

		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the control's content is read-only.
		/// </summary>
		bool Readonly
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the inserted text overwrites existing text.
		/// </summary>
		bool OverWrite
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the control's text content is modified.
		/// </summary>
		bool Modified
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the control accepts only one line of the text.
		/// </summary>
		bool SingleLineMode
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets <c>QWhale.Editor.IndentOptions</c> for this class, allowing to customize behaior of Edit control when user presses Enter to insert new text line.
		/// </summary>
		IndentOptions IndentOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies the maximum number of characters that can be entered into the edit control.
		/// </summary>
		int MaxLength
		{
			get;
			set;
		}
	}
	#endregion IEdit

	#region IEditEx
	/// <summary>
	/// Represents extended properties and methods used for editing the text.
	/// </summary>
	public interface IEditEx : IEdit
	{
		/// <summary>
		/// When implemeted by a class, inserts the given string at the specified location.
		/// </summary>
		/// <param name="text">The text to insert.</param>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool Insert(string text);
		/// <summary>
		/// When implemented by a class, inserts the file text content at the specified location.
		/// </summary>
		/// <param name="fileName">Name of file to load text from.</param>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool InsertFromFile(string fileName);
		/// <summary>
		/// When implemented by a class, deletes a specified number of characters to the right of the active point.
		/// </summary>
		/// <param name="len">Specifies number of characters to delete.</param>
		/// <returns>True if method succeed; otherwise false.</returns>
		bool DeleteRight(int len);
		/// <summary>
		/// When implemeted by a class, deletes a specified number of characters to the left of the active point.
		/// </summary>
		/// <param name="len">Specifies number of characters to delete.</param>
		/// <returns>True if method succeed; otherwise false.</returns>
		bool DeleteLeft(int len);
		/// <summary>
		/// When implemeted by a class, inserts the given string at the specified location.
		/// </summary>
		/// <param name="text">String to insert.</param>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool InsertBlock(string text);
		/// <summary>
		/// When implmeneted by a class, inserts the given string array at the specified location.
		/// </summary>
		/// <param name="strings">String array to insert.</param>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool InsertBlock(string[] strings);
		/// <summary>
		/// When implemeted by a class, inserts the given string collection at the specified location.
		/// </summary>
		/// <param name="strings">Collection of strings to insert.</param>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool InsertBlock(ISyntaxStrings strings);
		/// <summary>
		/// When implemented by a class, deletes a specified block of characters.
		/// </summary>
		/// <param name="rect">Specifies coordinates of characters block to delete.</param>
		/// <returns>True if method succeed; otherwise false.</returns>
		bool DeleteBlock(Rectangle rect);
		/// <summary>
		/// When implemented by a class, breaks current line into two lines.
		/// </summary>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool BreakLine();
		/// <summary>
		/// When implemented by a class, concatenates lines at current position.
		/// </summary>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool UnBreakLine();
		/// <summary>
		/// When implemeted by a class, inserts a line break at the current position.
		/// </summary>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool NewLine();
		/// <summary>
		/// When implemented by a class, inserts a line break above the current position.
		/// </summary>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool NewLineAbove();
		/// <summary>
		/// When implemented by a class, inserts a line break below the current position.
		/// </summary>
		/// <returns>True if the method succeed; otherwise false.</returns>
		bool NewLineBelow();
		/// <summary>
		/// When implemented by a class, determines whether the given line is readonly.
		/// </summary>
		/// <param name="index">Line index.</param>
		/// <returns>True if the line at given index is readonly; otherwise false.</returns>
		bool IsLineReadonly(int index);
		/// <summary>
		/// When implemented by a class, sets readonly state for the given line.
		/// </summary>
		/// <param name="index">Line index.</param>
		/// <param name="readOnly">Indicates readonly flag should be set or cleared.</param>
		void SetLineReadonly(int index, bool readOnly);
	}
	#endregion IEditEx

	#region ITrackChanges
	/// <summary>
	/// Represents method used to indicate modified state of Edit control's content.
	/// </summary>
	public interface ITrackChanges
	{
		/// <summary>
		/// When implemented by a class, indicates whether specified line already modified.
		/// </summary>
		/// <param name="line">Index of line to check.</param>
		/// <param name="saved">Receives boolean value that indicates whether line was not changed since last saving.</param>
		/// <returns>True is line modified; otherwise false.</returns>
		bool IsLineModified(int line, out bool saved);
	}
	#endregion

	#region IUndo
	/// <summary>
	/// Represents properties and methods to perform undo/redo operation with the text. 
	/// </summary>
	public interface IUndo
	{
		/// <summary>
		/// When implemented by a class, performs the last undo operation.
		/// </summary>
		void Undo();
		/// <summary>
		/// When implemented by a class, performs the single undo operation.
		/// </summary>
		void Undo(UndoData undoData);
		/// <summary>
		/// When implemented by a class, performs the last redo operation.
		/// </summary>
		void Redo();
		/// <summary>
		/// When implemented by a class, indicating whether the undo operation can be performed.
		/// </summary>
		/// <returns></returns>
		bool CanUndo();
		/// <summary>
		/// When implemented by a class, indicating whether the redo operation can be performed.
		/// </summary>
		/// <returns></returns>
		bool CanRedo();
		/// <summary>
		/// When implemented by a class, clears list of undo operations.
		/// </summary>
		void ClearUndo();
		/// <summary>
		/// When implemented by a class, clears list of redo operations.
		/// </summary>
		void ClearRedo();
		/// <summary>
		/// When implemented by a class, disables recording of undo/redo operations.
		/// <seealso cref="QWhale.Editor.IUndo.EnableUndo"/>
		/// </summary>
		/// <returns>Number of undo/redo operations locks.</returns>
		int DisableUndo();
		/// <summary>
		/// When implemented by a class, re-enables recording of undo/redo operations, that was turn of by calling <c>DisableUndo</c> method.
		/// <seealso cref="QWhale.Editor.IUndo.DisableUndo"/>
		/// </summary>
		/// <returns>Number of undo/redo operations locks.</returns>
		int EnableUndo();
		/// <summary>
		/// When implemented by a class, allows to consider number of undo redo operations as single operation, until calling <c>EndUndoUpdate</c> method.
		/// </summary>
		/// <returns>Number of undo updating locks.</returns>
		int BeginUndoUpdate();
		/// <summary>
		/// When implemented by a class, ends undo block, that was started by <c>BeginUndoUpdate</c> method.
		/// </summary>
		/// <returns>Number of undo updating locks.</returns>
		int EndUndoUpdate();

		/// <summary>
		/// When implemented by a class, resets the <c>UndoOptions</c> to the default value.
		/// </summary>
		void ResetUndoOptions();
		/// <summary>
		/// When implemented by a class, resets the <c>UndoLimit</c> to the default value.
		/// </summary>
		void ResetUndoLimit();
		
		/// <summary>
		/// When implemented by a class, gets or sets options for undo and redo operations.
		/// </summary>
		UndoOptions UndoOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that limits number of undo operations.
		/// </summary>
		int UndoLimit
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, keeps track of calls to <c>BeginUndoUpdate</c> and <c>EndUndoUpdate</c> so that they can be nested.
		/// </summary>
		int UndoUpdateCount
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to undo data.
		/// </summary>
		IList UndoList
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to redo data.
		/// </summary>
		IList RedoList
		{
			get;
		}
	}
	#endregion IUndo

	#region INotifyEx
	/// <summary>
	/// Represents extended properties and methods to manage notification between objects.
	/// </summary>
	public interface INotifyEx : INotify
	{
		/// <summary>
		/// When implemented by a class, represents index of the first changed line.
		/// </summary>
		int FirstChanged
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents index of the last changed line.
		/// </summary>
		int LastChanged
		{
			get;
		}
	}
	#endregion INotifyEx

	#region ISourceNotify
	/// <summary>
	/// Represents properties and methods to perform Text Source notification.
	/// </summary>
	public interface ISourceNotify : INotifyEx
	{
		/// <summary>
		/// When implemented by a class, prevents object state updating until calling <c>EndUpdate</c> method.
		/// </summary>
		/// <param name="reason">Reason of the source state updating.</param>
		/// <returns>Number of object state updating locks.</returns>
		int BeginUpdate(UpdateReason reason);
		/// <summary>
		/// When implemented by a class, specifies range of lines that was changed.
		/// </summary>
		/// <param name="first">First changed line.</param>
		/// <param name="last">Last changed line.</param>
		void LinesChanged(int first, int last);
		/// <summary>
		/// When implemented by a class, specifies range of lines that was changed.
		/// </summary>
		/// <param name="first">First changed line.</param>
		/// <param name="last">Last changed line.</param>
		/// <param name="modified">Indicates that content of specified lines is modified.</param>
		void LinesChanged(int first, int last, bool modified);
		/// <summary>
		/// When implemented by a class, gets or sets last changes to the text stored in the text source.
		/// </summary>
		NotifyState State
		{
			get;
			set;
		}
	}
	#endregion ISourceNotify

	#region IWhiteSpace
	/// <summary>
	/// Represents properties of "invisible" characters, such as spaces and tabs, in the control's text content.
	/// </summary>
	public interface IWhiteSpace
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>IWhiteSpace</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IWhiteSpace</c> to assign.</param>
		void Assign(IWhiteSpace source);
		
		/// <summary>
		/// When implemented by a class, resets the <c>Visible</c> to the default value.
		/// </summary>
		void ResetVisible();
		/// <summary>
		/// When implemented by a class, resets the <c>TabSymbol</c> to the default value.
		/// </summary>
		void ResetTabSymbol();
		/// <summary>
		/// When implemented by a class, resets the <c>SpaceSymbol</c> to the default value.
		/// </summary>
		void ResetSpaceSymbol();
		/// <summary>
		/// When implemented by a class, resets the <c>EolSymbol</c> to the default value.
		/// </summary>
		void ResetEolSymbol();
		/// <summary>
		/// When implemented by a class, resets the <c>EofSymbol</c> to the default value.
		/// </summary>
		void ResetEofSymbol();
		/// <summary>
		/// When implemented by a class, resets the <c>WordWrapSymbol</c> to the default value.
		/// </summary>
		void ResetWordWrapSymbol();
		/// <summary>
		/// When implemented by a class, resets the <c>SymbolColor</c> to the default value.
		/// </summary>
		void ResetSymbolColor();
		
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether white space symbols are visible in the contol's text content.
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets character that introduces special symbol to paint instead of the tab character.
		/// </summary>
		char TabSymbol
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets character that introduces special symbol to paint instead of the space character.
		/// </summary>
		char SpaceSymbol
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets character that specifies end of line.
		/// </summary>
		char EolSymbol
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets character that specifies end of file.
		/// </summary>
		char EofSymbol
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets character that specifies wrapped line.
		/// </summary>
		char WordWrapSymbol
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents one character string that introduces special symbol to paint instead of the space character.
		/// </summary>
		string SpaceString
		{ 
			get;
		}
		/// <summary>
		/// When implemented by a class, represents one character string that introduces special symbol to paint instead of the tab character.
		/// </summary>
		string TabString
		{ 
			get;
		}
		/// <summary>
		/// When implemented by a class, represents one character string that specifies end of line.
		/// </summary>
		string EolString
		{ 
			get;
		}
		/// <summary>
		/// When implemented by a class, represents one character string that specifies end of file.
		/// </summary>
		string EofString
		{ 
			get;
		}
		/// <summary>
		/// When implemented by a class, represents one character string that specifies wrapped file.
		/// </summary>
		string WordWrapString
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets color used to paint special symbols.
		/// </summary>
		Color SymbolColor
		{
			get;
			set;
		}
	}
	#endregion IWhiteSpace

	#region ISyntaxPaint
	/// <summary>
	/// Represents properties and methods, used to draw text and graphic primitives.
	/// </summary>
	public interface ISyntaxPaint
	{
		/// <summary>
		/// When implemented by a class, perform syntax painting of the control on the graphic surface.
		/// </summary>
		/// <param name="painter">Specifies <c>IPainter</c> object used to draw text and graphic primitives.</param>
		/// <param name="startLine">Specifies the first line of content to paint.</param>
		/// <param name="endLine">Specifies the last line of content to paint.</param>
		/// <param name="position">The Point value that specifies start position to draw content from.</param>
		/// <param name="rect">Rectangular area of control to draw.</param>
		/// <param name="specialPaint">Reserved for internal use. Used for Print and Print preview.</param>
		void PaintSyntax(IPainter painter, int startLine, int endLine, Point position, Rectangle rect, bool specialPaint);
		/// <summary>
		/// When implemented by a class, draws line given by its index at the specified position.
		/// </summary>
		/// <param name="index">Index of line to draw.</param>
		/// <param name="position">Position to start drawing.</param>
		/// <param name="clipRect">Rectangular area of the control to draw line in.</param>
		void DrawLine(int index, Point position, Rectangle clipRect);
		/// <summary>
		/// When implemented by a class, draws line given by its index at the specified position.
		/// </summary>
		/// <param name="index">Index of line to draw.</param>
		/// <param name="line">Specifies text to draw</param>
		/// <param name="colorData">Specifies array containing color data for given string</param>
		/// <param name="position">Position to start drawing.</param>
		/// <param name="clipRect">Rectangular area of the control to draw line in.</param>
		void DrawLine(int index, string line, short[] colorData, Point position, Rectangle clipRect);
		/// <summary>
		/// When implemented by a class, measures part of the string given at by its Index.
		/// </summary>
		/// <param name="index">Index of line to measure.</param>
		/// <param name="pos">Start character of string to measure.</param>
		/// <param name="len">Number of characters to measure.</param>
		/// <returns>Width of the measured part of the string.</returns>
		int MeasureLine(int index, int pos, int len);
		/// <summary>
		/// When implemented by a class, measures part of the string given by its index.
		/// </summary>
		/// <param name="index">Index of line to measure.</param>
		/// <param name="pos">Start character of string to measure.</param>
		/// <param name="len">Number of characters to measure.</param>
		/// <param name="width">Maximum length of the string.</param>
		/// <param name="chars">Receive real number of measured chars.</param>
		/// <param name="exact">Specifies whether the calculating should be precise.</param>
		/// <returns>Width of the measured part of the string.</returns>
		int MeasureLine(int index, int pos, int len, int width, out int chars, bool exact);
		/// <summary>
		/// When implemented by a class, measures part of given string.
		/// </summary>
		/// <param name="line">Text to measure.</param>
		/// <param name="colorData">Color data attached to the given string.</param>
		/// <param name="pos">Start character of string to measure.</param>
		/// <param name="len">Number of characters to measure.</param>
		/// <returns>Width of the measured part of the string.</returns>
		int MeasureLine(string line, short[] colorData, int pos, int len);
		/// <summary>
		/// When implemented by a class, measures part of given string.
		/// </summary>
		/// <param name="line">Text to measure.</param>
		/// <param name="colorData">Color data attached to the given string.</param>
		/// <param name="pos">Start character of string to measure.</param>
		/// <param name="len">Number of characters to measure.</param>
		/// <param name="width">Maximum length of the string.</param>
		/// <param name="chars">Receive real number of measured chars.</param>
		/// <param name="exact">Specifies whether the calculating should be precise.</param>
		/// <returns>Width of the measured part of the string.</returns>
		int MeasureLine(string line, short[] colorData, int pos, int len, int width, out int chars, bool exact);
	
		/// <summary>
		/// When implemented by a class, raises an <c>CustomDraw</c> event.
		/// </summary>
		/// <param name="painter">Specifies <c>IPainter</c> object used to draw text and graphic primitives.</param>
		/// <param name="rect">Rectangular area of control to draw.</param>
		/// <param name="stage">Specifies whether this method called before or after painting.</param>
		/// <param name="state">Specifies part of control to draw.</param>
		/// <param name="info">Full information about drawing text fragment.</param>
		/// <returns>True if user handles this event; otherwise false.</returns>
		bool OnCustomDraw(IPainter painter, Rectangle rect, DrawStage stage, DrawState state, DrawInfo info);
		/// <summary>
		/// When implemented by a class, resets the <c>DisableColorPaint</c> to the default value.
		/// </summary>
		void ResetDisableColorPaint();
		/// <summary>
		/// When implemented by a class, resets the <c>DisableSyntaxPaint</c> to the default value.
		/// </summary>
		void ResetDisableSyntaxPaint();

		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether control uses colors to paint its content.
		/// </summary>
		bool DisableColorPaint
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether Edit control uses lexical colors/styles to paint its content.
		/// </summary>
		bool DisableSyntaxPaint
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets object that can make lexical analysis for the control's content.
		/// </summary>
		ILexer Lexer
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when control draws its content.
		/// </summary>
		event CustomDrawEvent CustomDraw;	
	}
	#endregion ISyntaxPaint

	#region IScrollingButton
	/// <summary>
	/// Represents properties specifying appearance and behaviour of button displayed on the scroll bar.
	/// </summary>
	public interface IScrollingButton
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>IScrollingButton</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IScrollingButton</c> to assign.</param>
		void Assign(IScrollingButton source);
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies the name of this <c>IScrollingButton</c>.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies short description of this <c>IScrollingButton</c>.
		/// </summary>
		string Description
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the index of the image displayed for this <c>IScrollingButton</c>.
		/// </summary>
		int ImageIndex
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the ImageList for this <c>IScrollingButton</c>.
		/// </summary>
		ImageList Images
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether this <c>IScrollingButton</c> is visible.
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the border style for this <c>IScrollingButton</c>.
		/// </summary>
		EditBorderStyle BorderStyle
		{
			get;
			set;
		}
	}
	#endregion IScrollingButton
	
	#region IScrollingButtons
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>IScrollingButton</c> object.
	/// </summary>
	public interface IScrollingButtons : IList
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>IScrollingButtons</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IScrollingButtons</c> to assign.</param>
		void Assign(IScrollingButtons source);
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual <c>IScrollingButton</c> object stored in the collection.
		/// </summary>
		/// <param name="index">Index of <c>IScrollingButton</c> within the collection.</param>
		/// <returns><c>IScrollingButton</c> object at specified index.</returns>
		IScrollingButton GetScrollingButton(int index);
		/// <summary>
		/// Creates and adds a new <c>IScrollingButton</c> to the collection.
		/// </summary>
		/// <returns>Index of this new <c>IScrollingButton</c> in the collection.</returns>
		int AddScrollingButton();
		/// <summary>
		/// Creates new <c>IScrollingButton</c> with specified parameters and adds it to the collection.
		/// </summary>
		/// <param name="name"><c>Name</c> of this new <c>IScrollingButton</c>.</param>
		/// <param name="description"><c>Description</c> of this new <c>IScrollingButton</c>.</param>
		/// <param name="imageIndex"><c>ImageIndex</c> of this new <c>IScrollingButton</c>.</param>
		/// <returns>Index of this new <c>IScrollingButton</c> in the collection.</returns>
		int AddScrollingButton(string name, string description, int imageIndex);
	}
	#endregion IScrollingButtons

	#region IScrolling
	/// <summary>
	/// Represents properties and methods that describe scrolling behaviour of Edit control.
	/// </summary>
	public interface IScrolling
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>IScrolling</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IScrolling</c> to assign.</param>
		void Assign(IScrolling source);
		
		/// <summary>
		/// When implemented by a class, resets the <c>ScrollBars</c> to the default value.
		/// </summary>
		void ResetScrollBars();
		/// <summary>
		/// When implemented by a class, resets the <c>DefaultHorzScrollSize</c> to the default value.
		/// </summary>
		void ResetDefaultHorzScrollSize();
		/// <summary>
		/// When implemented by a class, resets the <c>Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		
		/// <summary>
		/// When implemented by a class, gets or sets the type of scroll bars displayed in the control.
		/// </summary>
		RichTextBoxScrollBars ScrollBars 
		{
			get; 
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a default size of horizontal scrollbar.
		/// </summary>
		/// <remarks>This property is applicable when control forces showing of the horizontal scroll bar.</remarks>
		int DefaultHorzScrollSize
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a index of the first visible character within the control.
		/// </summary>
		int WindowOriginX
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that represents first visible line within the control.
		/// </summary>
		int WindowOriginY
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets horizontal scroll bar control.
		/// </summary>
		ScrollBar HScrollBar
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets vertical scroll bar control.
		/// </summary>
		ScrollBar VScrollBar
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets boolean value indicating whether control has a horizontal scroll bar control.
		/// </summary>
		bool HasHScrollBar
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets boolean value indicating whether control has a vertical scroll bar control.
		/// </summary>
		bool HasVScrollBar
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a collection of additional buttons displayed on the horizontal scroll bar.
		/// </summary>
		IScrollingButtons HorzButtons
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a collection of additional buttons displayed on the vertical scroll bar.
		/// </summary>
		IScrollingButtons VertButtons
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a <c>ScrollingOptions</c> that determine scrolling behaviour.
		/// </summary>
		ScrollingOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, indicates whether verticall scrollbar is visible
		/// </summary>
		bool VertScrollbarVisible
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, indicates whether horizontal scrollbar is visible
		/// </summary>
		bool HorzScrollbarVisible
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, occurs when control scrolls its content in vertical direction. This can be caused by dragging vertical scroll thumb, or caret moving.
		/// </summary>
		event EventHandler VerticalScroll;
		/// <summary>
		/// When implemented by a class, occurs when control scrolls its content in horizonal direction. This can be caused by dragging horizonal scroll thumb, or caret moving.
		/// </summary>
		event EventHandler HorizontalScroll;
		/// <summary>
		/// When implemented by a class, occurs when some scrolling button is clicked.
		/// </summary>
		event EventHandler ScrollButtonClick;
	}
	#endregion IScrolling

	#region ICaret
	/// <summary>
	/// Represents properties and methods to handle caret within the Edit control.
	/// </summary>
	public interface ICaret
	{
		/// <summary>
		/// When implemented by a class, creates a new shape for the system caret and gets ownership of the caret.
		/// </summary>
		void CreateCaret();
		/// <summary>
		/// When implemented by a class, destroys the caret's current shape, frees the caret from the control, and removes the caret from the screen.
		/// </summary>
		void DestroyCaret();
		/// <summary>
		/// When implemented by a class, moves the caret to the specified coordinates.
		/// </summary>
		/// <param name="x">Specifies the new x-coordinate of the caret.</param>
		/// <param name="y">Specifies the new y-coordinate of the caret.</param>
		void ShowCaret(int x, int y);
		/// <summary>
		/// When implemented by a class, returns size of the caret's current shape at given position.
		/// </summary>
		/// <param name="position">Point at which caret size should be calculated.</param>
		/// <returns>Size of the caret.</returns>
		Size GetCaretSize(Point position);
		/// <summary>
		/// When implemented by a class, displays dragging caret rather than regular caret.
		/// </summary>
		void DisplayDragCaret();
		/// <summary>
		/// When implemented by a class, hides dragging caret.
		/// </summary>
		void HideDragCaret();
		
		/// <summary>
		/// When implemented by a class, resets the <c>HideCaret</c> to the default value.
		/// </summary>
		void ResetHideCaret();
		
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the control should display caret when it has input focus.
		/// </summary>
		bool HideCaret
		{
			get;
			set;
		}
	}
	#endregion ICaret

	#region ICollapsable
	/// <summary>
	/// Represents properties and methods to affects appearance and behaviour of outline sections within Edit control.
	/// </summary>
	public interface ICollapsable
	{
		/// <summary>
		/// When implemented by a class, creates an outlining section based on specific scope at the specific level of outline nesting.
		/// </summary>
		/// <param name="first">Specifies first line of section to outline.</param>
		/// <param name="last">Specifies last line of section to outline.</param>
		/// <param name="level">Specifies level of outline nesting for this section.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange Outline(int first, int last, int level);
		/// <summary>
		/// When implemented by a class, creates an outlining section based on specific scope within current outlined section.
		/// </summary>
		/// <param name="first">Specifies first line of section to outline.</param>
		/// <param name="last">Specifies last line of section to outline.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange Outline(int first, int last);
		/// <summary>
		/// When implemented by a class, creates an outlining section based on specific scope at the specific level of outline nesting.
		/// </summary>
		/// <param name="startPoint">Specifies begin of section to outline.</param>
		/// <param name="endPoint">Specifies end of section to outline.</param>
		/// <param name="level">Specifies level of outline nesting for this section.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange Outline(Point startPoint, Point endPoint, int level);
		/// <summary>
		/// When implemented by a class, creates an outlining section based on specific scope within current outlined section.
		/// </summary>
		/// <param name="startPoint">Specifies begin of section to outline.</param>
		/// <param name="endPoint">Specifies end of section to outline.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange Outline(Point startPoint, Point endPoint);
		/// <summary>
		/// When implemented by a class, creates an outlining section based on specific scope at specific level of outline nesting and with specific text substituting collapsed text.
		/// </summary>
		/// <param name="first">Specifies first line of section to outline.</param>
		/// <param name="last">Specifies last line of section to outline.</param>
		/// <param name="level">Specifies level of outline nesting for this section.</param>
		/// <param name="outlineText">Specifies text substituting collapsed text.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange Outline(int first, int last, int level, string outlineText);
		/// <summary>
		/// When implemented by a class, creates an outlining section based on specific scope within current outlined section and with specific text substituting  collapsed text.
		/// </summary>
		/// <param name="first">Specifies first line of section to outline.</param>
		/// <param name="last">Specifies last line of section to outline.</param>
		/// <param name="outlineText">Specifies first line of section to outline.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange Outline(int first, int last, string outlineText);
		/// <summary>
		/// When implemented by a class, creates an outlining section based on specific scope at specific level of outline nesting and with specific text substituting collapsed text.
		/// </summary>
		/// <param name="startPoint">Specifies begin of section to outline.</param>
		/// <param name="endPoint">Specifies end of section to outline.</param>
		/// <param name="level">Specifies level of outline nesting for this section.</param>
		/// <param name="outlineText">Specifies text to substitute collapsed text.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange Outline(Point startPoint, Point endPoint, int level, string outlineText);
		/// <summary>
		/// When implemented by a class, creates an outlining section based on specific scope within current outlined section and with specific text substituting collapsed text.
		/// </summary>
		/// <param name="startPoint">Specifies begin of section to outline.</param>
		/// <param name="endPoint">Specifies end of section to outline.</param>
		/// <param name="outlineText">Specifies text to substitute collapsed text.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange Outline(Point startPoint, Point endPoint, string outlineText);
		/// <summary>
		/// When implemented by a class, removes outlined section at the specific position.
		/// </summary>
		/// <param name="position">Specifies position in the text.</param>
		void UnOutline(Point position);
		/// <summary>
		/// When implemented by a class, removes all outline sections containing the given line.
		/// </summary>
		/// <param name="index">Specifies line in the text.</param>
		void UnOutline(int index);
		/// <summary>
		/// When implemented by a class, removes all outlined sections from outline collection.
		/// </summary>
		void UnOutline();
		/// <summary>
		/// When implemented by a class, returns outline section, which represents text substituting outlined section and level of outline nesting at the specific position.
		/// </summary>
		/// <param name="position">Specifies position in the text.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange GetOutlineRange(Point position);
		/// <summary>
		/// When implemented by a class, returns outline section, which represents text substituting outlined section and level of outline nesting at the specific line.
		/// </summary>
		/// <param name="index">Index of line in the text.</param>
		/// <returns><c>IOutlineRange</c> object that represents outline section.</returns>
		IOutlineRange GetOutlineRange(int index);
		/// <summary>
		/// When implemented by a class, indicates whether the outlined text at the specified line is expanded.
		/// </summary>
		/// <param name="index">Index of the line to test.</param>
		/// <returns>True if expanded; otherwise false.</returns>
		bool IsExpanded(int index);
		/// <summary>
		/// When implemented by a class, indicates whether the outlined text at the specified line is collapsed.
		/// </summary>
		/// <param name="index">Index of the line to test.</param>
		/// <returns>True if collapsed; otherwise false.</returns>
		bool IsCollapsed(int index);
		/// <summary>
		/// When implemented by a class, indicates whether the text at the specified position is visible, that is there is no collapsed outline section containing given position.
		/// </summary>
		/// <param name="position">The Point value that specifies position in the text.</param>
		/// <returns>True if visible; otherwise false.</returns>
		bool IsVisible(Point position);
		/// <summary>
		/// When implemented by a class, indicates whether the text at the specified line is visible, that is there is no collapsed outline section containing given line.
		/// </summary>
		/// <param name="index">Specifies index of line in the text.</param>
		/// <returns>True if visible; otherwise false.</returns>
		bool IsVisible(int index);
		/// <summary>
		/// When implemented by a class, collapses the specified line.
		/// </summary>
		/// <param name="index">The index of the line to collapse.</param>
		void Collapse(int index);
		/// <summary>
		/// When implemented by a class, expands outline section at the given line.
		/// </summary>
		/// <param name="index">The index of the line to expand.</param>
		void Expand(int index);
		/// <summary>
		/// When implemented by a class, makes all outline sections containing specified line expanded.
		/// </summary>
		/// <param name="index">Specifies position of the line in the text.</param>
		void EnsureExpanded(int index);
		/// <summary>
		/// When implemented by a class, makes all outline sections containing specified position expanded.
		/// </summary>
		/// <param name="position">The Point value that specifies position in the text.</param>
		void EnsureExpanded(Point position);
		/// <summary>
		/// When implemented by a class, expands all outlining sections.
		/// </summary>
		void FullExpand();
		/// <summary>
		/// When implemented by a class, expands all outline sections specified by Ranges parameter.
		/// </summary>
		/// <param name="ranges">Specifies <c>IOutlineRange</c> collection to expand.</param>
		void FullExpand(IList ranges);
		/// <summary>
		/// When implemented by a class, collapses all outlining sections.
		/// </summary>
		void FullCollapse();
		/// <summary>
		/// When implemented by a class, collapses all sections objects specified by Ranges parameter.
		/// </summary>
		/// <param name="ranges">Specifies <c>IOutlineRange</c> collection to collapse.</param>
		void FullCollapse(IList ranges);
		/// <summary>
		/// When implemented by a class, toggles expanded state for all <c>IOutlineRange</c> objects in outline collection.
		/// </summary>
		void ToggleOutlining();
		/// <summary>
		/// When implemented by a class, collapses and expandes some outline section to get a quick overall view of the content.
		/// </summary>
		void CollapseToDefinitions();
		/// <summary>
		/// When implemented by a class, returns string that appears in the hint window when mouse pointer is over the outline button.
		/// </summary>
		/// <param name="range">Specifies the <c>IOutlineRange</c> object holding the hint.</param>
		/// <returns>Hint string.</returns>
		string GetOutlineHint(IOutlineRange range);
		/// <summary>
		/// When implemented by a class, fills list specified by ranges parameter with all outline sections containing specific line.
		/// </summary>
		/// <param name="ranges">Specifles list to fill.</param>
		/// <param name="index">Specifies index of line in text coordinates.</param>
		/// <returns>Number of elements in the ranges collection.</returns>
		int GetOutlineRanges(IList ranges, int index);
		/// <summary>
		/// When implemented by a class, fills list specified by ranges parameter with all outline sections containing specific position.
		/// </summary>
		/// <param name="ranges">Specifies list to fill.</param>
		/// <param name="position">Specifies position in the text.</param>
		/// <returns>Number of elements in the ranges collection.</returns>
		int GetOutlineRanges(IList ranges, Point position);
		/// <summary>
		/// When implemented by a class, fills list specified by ranges parameter with all outline sections containing specific range.
		/// </summary>
		/// <param name="ranges">Specifies list to fill.</param>
		/// <param name="startPoint">Specifies start position in the text.</param>
		/// <param name="endPoint">Specifies end position in the text.</param>
		/// <returns>Number of elements in the ranges collection.</returns>
		int GetOutlineRanges(IList ranges, Point startPoint, Point endPoint);
		/// <summary>
		/// When implemented by a class, fills list specified by ranges parameter with all existing outline sections.
		/// </summary>
		/// <param name="ranges">Specifies list to fill.</param>
		/// <returns>Number of elements in the ranges collection.</returns>
		int GetOutlineRanges(IList ranges);
		/// <summary>
		/// When implemented by a class, updates <c>IOutlineRange</c> collection from given list of ranges. 
		/// </summary>
		/// <param name="ranges">Specifies new <c>IOutlineRange</c> collection to set.</param>
		void SetOutlineRanges(IList ranges);
		/// <summary>
		/// When implemented by a class, updates <c>IOutlineRange</c> collection from given list of ranges. 
		/// </summary>
		/// <param name="ranges">Specifies new <c>IOutlineRange</c> collection to set.</param>
		/// <param name="preserveVisible">Indicates whether new ranges should preserve collapsed state of existing outline sections.</param>
		void SetOutlineRanges(IList ranges, bool preserveVisible);
		/// <summary>
		/// When implemented by a class, prevents outline list updating until calling <c>ICollapsable.EndUpdate</c> method.
		/// </summary>
		/// <returns>Number of outline list updating locks.</returns>
		int BeginUpdate();
		/// <summary>
		/// When implemented by a class, re-enables outline list updating, that was turn of by calling <c>ICollapsable.BeginUpdate</c> method.
		/// </summary>
		/// <returns>Number of outline list updating locks.</returns>
		int EndUpdate();
		/// <summary>
		/// When implemented by a class, resets <c>AllowOutlining</c> to the default value.
		/// </summary>
		void ResetAllowOutlining();
		/// <summary>
		/// When implemented by a class, resets <c>OutlineOptions</c> to the default value.
		/// </summary>
		void ResetOutlineOptions();
		/// <summary>
		/// When implemented by a class, returns number of collapsed sections.
		/// </summary>
		int CollapsedCount
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, keeps track of calls to <c>BeginUndoUpdate</c> and <c>EndUndoUpdate</c> so that they can be nested.
		/// </summary>
		int UpdateCount
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether outlining enabled.
		/// </summary>
		bool AllowOutlining
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets outlining options.
		/// </summary>
		OutlineOptions OutlineOptions
		{
			get;
			set;
		}
	}
	#endregion ICollapsable

	#region IOutlining
	/// <summary>
	/// Represents additional properties and methods that affects appearance and behaviour of outline sections within Edit control.
	/// </summary>
	public interface IOutlining  : ICollapsable
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>IOutlining</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IOutlining</c> to assign.</param>
		void Assign(IOutlining source);
		/// <summary>
		/// When implemented by a class, tries to perform lexical analysis of entire text to create outline sections based on results of this analysis.
		/// </summary>
		void OutlineText();
		/// <summary>
		/// When implemented by a class, removes all outline section from outline collection.
		/// </summary>
		void UnOutlineText();
		/// <summary>
		/// When implemented by a class, resets the <c>OutlineColor</c> to the default value.
		/// </summary>
		void ResetOutlineColor();
		
		/// <summary>
		/// When implemented by a class, gets or sets color that is used to draw outline button.
		/// </summary>
		Color OutlineColor
		{
			get;
			set;
		}
	}
	#endregion IOutlining

	#region ICodeCompletion
	/// <summary>
	/// Represents properties and methods to provide code completion list box/tooltip for the Editor's content.
	/// </summary>
	public interface ICodeCompletion 
	{
		/// <summary>
		/// When implemented by a class, shows code completion popup window with given provider at the current position.
		/// </summary>
		/// <param name="provider">Represents data for code completion popup window.</param>
		void ShowCodeCompletionBox(ICodeCompletionProvider provider);
		/// <summary>
		/// When implemented by a class, shows code completion popup window with given Provider at the specified position.
		/// </summary>
		/// <param name="provider">Represents data for code completion popup window.</param>
		/// <param name="position">Position to show code completion popup window.</param>
		void ShowCodeCompletionBox(ICodeCompletionProvider provider, Point position);
		/// <summary>
		/// When implemented by a class, displays <c>ICodeCompletionHint</c> with given provider at the current position.
		/// </summary>
		/// <param name="provider">Represents data for code completion hint.</param>
		void ShowCodeCompletionHint(ICodeCompletionProvider provider);
		/// <summary>
		/// When implemented by a class, displays <c>ICodeCompletionHint</c> with given provider at the specified position.
		/// </summary>
		/// <param name="provider">Represents data for code completion hint.</param>
		/// <param name="position">Position to display the hint.</param>
		void ShowCodeCompletionHint(ICodeCompletionProvider provider, Point position);
		/// <summary>
		/// When implemented by a class, indicates whether text at the specified position is valid (that is does not contain comments or stirng constants).
		/// </summary>
		/// <param name="position">Position to check.</param>
		/// <returns>True if text is not plain; otherwise false.</returns>
		bool IsValidText(Point position);
		/// <summary>
		/// When implemented by a class, removes all plain (string constants or comments) parst of text from specified line.
		/// </summary>
		/// <param name="line">Index of line to process.</param>
		/// <returns>String without plain parts.</returns>
		string RemovePlainText(int line);
		/// <summary>
		/// When implemented by a class, displays a code completion window that lists members of the current class in the Editor's content and locates single member, if possible.
		/// </summary>
		void CompleteWord();
		/// <summary>
		/// When implemented by a class, displays a code completion window that lists members of the current class in the Editor's content.
		/// </summary>
		void ListMembers();
		/// <summary>
		/// When implemeted by a class, displays a code completion window with simple tooltip information.
		/// </summary>
		void QuickInfo();
		/// <summary>
		/// When implemeted by a class, displays a code completion window containing information for the current method or parameter in the Editor's content.
		/// </summary>
		void ParameterInfo();
		/// <summary>
		/// When implemented by a class, displays a code completion window with list of available code snippets.
		/// </summary>
		void CodeSnippets();
		/// <summary>
		/// When implemented by a class, occurs when code completion window is to be displayed.
		/// </summary>
		event CodeCompletionEvent NeedCodeCompletion;
		/// <summary>
		/// When implemented by a class, represents object that specifies a popup window that contains Code completion information presented in the form of list.
		/// </summary>
		ICodeCompletionBox CodeCompletionBox
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents object that specifies a popup window that contains Code completion information presented in the form of the tooltip.
		/// </summary>
		ICodeCompletionHint CodeCompletionHint
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a collection of characters that initializes a code completion procedure when typing in the editor.
		/// </summary>
		char[] CodeCompletionChars
		{
			get;
			set;
		}
	}
	#endregion ICodeCompletion

	#region IRecordPlayBack
	/// <summary>
	/// Represents properties and methods that allows recording sequences of keyboard commands and play back them later.
	/// </summary>
	public interface IRecordPlayBack
	{
		/// <summary>
		/// When implemented by a class, repeats the stored command sequence.
		/// </summary>
		void PlayBackMacro();
		/// <summary>
		/// When implemented by a class, starts recording the command sequence.
		/// </summary>
		void StartMacroRecording();
		/// <summary>
		/// When implemented by a class, stops recording the command sequence.
		/// </summary>
		void StopMacroRecording();
		/// <summary>
		/// When implemented by a class, suspends recording the command sequence.
		/// </summary>
		void PauseMacroRecording();
		/// <summary>
		/// When implemented by a class, resumes recording the command sequence.
		/// </summary>
		void ResumeMacroRecording();
		/// <summary>
		/// When implemented by a class, toggles recording the command sequence.
		/// </summary>
		void ToggleMacroRecording();
        /// <summary>
        /// When implemented by a class, saves the macro records to the given stream in xml format.
        /// </summary>
        /// <param name="stream">The Stream object to write the text.</param>
        void SaveMacros(Stream stream);
        /// <summary>
        /// When implemented by a class, saves the macro records to the given stream in xml format.
        /// </summary>
        /// <param name="writer">The TextWriter object to write macros to stream.</param>
        void SaveMacros(TextWriter writer);
        /// <summary>
        /// When implemented by a class, saves the macro records to the given file in xml format.
        /// </summary>
        /// <param name="fileName">Name of file to save macros.</param>
        void SaveMacros(string fileName);
        /// <summary>
        /// When implemented by a class, loads the macro records fromt the given stream.
        /// </summary>
        /// <param name="stream">The Stream object to write the text.</param>
        void LoadMacros(Stream stream);
        /// <summary>
        /// When implemented by a class, loads the macro records fromt the given stream.
        /// </summary>
        /// <param name="reader">The TextReader object to read macros from stream.</param>
        void LoadMacros(TextReader reader);
        /// <summary>
        /// When implemented by a class, loads the macro records fromt the given file.
        /// </summary>
        /// <param name="fileName">Name of file to load macros.</param>
        void LoadMacros(string fileName);
        /// <summary>
		/// When implemented by a class, gets or sets a boolean value indicating whether Edit control should record sequence of keyboard commands. 
		/// </summary>
		bool MacroRecording
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value indicating whether recording is suspendend. 
		/// </summary>
		bool MacroSuspendend
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an array containing keyboard commands.
		/// </summary>
		MacroKeyListData[] MacroRecords
		{
			get;
		}
	}
	#endregion IRecordPlayBack
	
	#region IAutoCorrect
	/// <summary>
	/// Represents properties and methods allowing to auto correct words when typing.
	/// </summary>
	public interface IAutoCorrect
	{
		/// <summary>
		/// When implemented by a class, checks whether specified word has correction. 
		/// </summary>
		/// <param name="word">Word that should be corrected.</param>
		/// <param name="correctWord">Receives a corrected word.</param>
		/// <returns>True if word has correction; otherwise false.</returns>
		bool HasAutoCorrection(string word, out string correctWord);
		/// <summary>
		/// When implemented by a class, gets or sets an array of chars that used as word delimiters.
		/// </summary>
		char[] AutoCorrectDelimiters
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value indicating whether to auto correct words being typed.
		/// </summary>
		bool AutoCorrection
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when control tries to auto correct word being typed.
		/// </summary>
		event AutoCorrectEvent AutoCorrect;
	}
	#endregion

	#region IEditColors
	/// <summary>
	/// Represents a collection of colors that are used by Edit control to display it's content in readonly an disabled states.
	/// </summary>
	public interface IEditColors 
	{
		/// <summary>
		/// When implemented by a class, gets or sets foreground color used in the readonly state.
		/// </summary>
		Color ReadonlyForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color used in the readonly state.
		/// </summary>
		Color ReadonlyBackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets foreground color used in the disabled state.
		/// </summary>
		Color DisabledForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color used in the disabled state.
		/// </summary>
		Color DisabledBackColor
		{
			get;
			set;
		}

	}
	#endregion IEditColors

	#region ISplitView 
	/// <summary>
	/// Represents properties and methods allowing Edit control to visually split its content.
	/// </summary>
	public interface ISplitView
	{
		/// <summary>
		/// When implemented by a class, indicates whether control can split its content horizontally.
		/// </summary>
		/// <returns>True if can split horizontally; otherwise false.</returns>
		bool CanSplitHorz();
		/// <summary>
		/// When implemented by a class, indicates whether control can split its content vertically.
		/// </summary>
		/// <returns>True if can split vertically; otherwise false.</returns>
		bool CanSplitVert();
		/// <summary>
		/// When implemented by a class, indicates whether control has horizontal split view.
		/// </summary>
		/// <returns>True if horizontal split view is visible; otherwise false.</returns>
		bool CanUnsplitHorz();
		/// <summary>
		/// When implemented by a class, indicates whether control has vertical split view.
		/// </summary>
		/// <returns>True if vertical split view is visible; otherwise false.</returns>
		bool CanUnsplitVert();
		/// <summary>
		/// When implemented by a class, splits its content horizontally.
		/// </summary>
		void SplitViewHorz();
		/// <summary>
		/// When implemented by a class, splits its content vertically.
		/// </summary>
		void SplitViewVert();
		/// <summary>
		/// When implemented by a class, removes horizontal split view.
		/// </summary>
		void UnsplitViewHorz();
		/// <summary>
		/// When implemented by a class, removes vertical split view.
		/// </summary>
		void UnsplitViewVert();
		/// <summary>
		/// When implemented by a class, represents an vertical split view control.
		/// </summary>
		ISyntaxEdit VertSplitEdit
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents horizontal split view control.
		/// </summary>
		ISyntaxEdit HorzSplitEdit
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a vertical Splitter control allowing to split Edit content vertically.
		/// </summary>
		Splitter VertSplitter
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a horizontal Splitter control allowing to split Edit content horizontally.
		/// </summary>
		Splitter HorzSplitter
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, occurs when user splits Edit control horizontally.
		/// </summary>
		event EventHandler SplitHorz;
		/// <summary>
		/// When implemented by a class, occurs when user splits Edit control vertically.
		/// </summary>
		event EventHandler SplitVert;
		/// <summary>
		/// When implemented by a class, occurs when horizontal split view is removed.
		/// </summary>
		event EventHandler UnsplitHorz;
		/// <summary>
		/// When implemented by a class, occurs when vertical split view is removed.
		/// </summary>
		event EventHandler UnsplitVert;
	}
	#endregion

	#region IEditPage
	/// <summary>
	/// Represents properties and methods to describe and manipulate with a particular page within Edit control content.
	/// </summary>
	public interface IEditPage
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>IEditPage</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IEditPage</c> to assign.</param>
		void Assign(IEditPage source);
		/// <summary>
		/// When implemented by a class, recalculates page bounds and content.
		/// </summary>
		void Update();
		/// <summary>
		/// When implemented by a class, invalidates the page.
		/// </summary>
		void Invalidate();
		/// <summary>
		/// When implemented by a class, prevents page updating until calling <c>IEditPage.EndUpdate</c> method.
		/// </summary>
		/// <returns>Number of page updating locks.</returns>
		int BeginUpdate();
		/// <summary>
		/// When implemented by a class, re-enables page updating, that was turn of by calling <c>IEditPage.BeginUpdate</c> method.
		/// </summary>
		/// <returns>Number of page updating locks.</returns>
		int EndUpdate();
		/// <summary>
		/// When implemented by a class, draws <c>IEditPage</c> object on specified graphic surface.
		/// </summary>
		/// <param name="painter">Specifies <c>IPainter</c> object used to draw text and graphic primitives.</param>
		void Paint(IPainter painter);
		/// <summary>
		/// When implemented by a class, retrieves a bounds of the <c>IEditPage</c>.
		/// </summary>
		/// <param name="includeSpace">Specifies whether to include whitespace area.</param>
		/// <returns>Rectangle that bounded this <c>IEditPage</c>.</returns>
		Rectangle GetBounds(bool includeSpace);
		/// <summary>
		/// When implemented by a class, gets or sets size (width and height) of this <c>IEditPage</c>.
		/// </summary>
		Size PageSize
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets margins specifying offsets of editing area of this <c>IEditPage</c>.
		/// </summary>
		Margins Margins
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets kind of the page specifying standart paper size.
		/// </summary>
		PaperKind PageKind
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets boolean value that indicates the page orientation (landscape or portrait).
		/// </summary>
		bool Landscape
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a horizontal indentation between pages.
		/// </summary>
		int HorzOffset
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a vertical indentation between pages.
		/// </summary>
		int VertOffset
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, indicates whether this page is the first page within the Edit control pages collection.
		/// </summary>
		bool IsFirstPage
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, indicates whether this page is the last page within the Edit control pages collection.
		/// </summary>
		bool IsLastPage
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a previous <c>IEditPage</c> within the Edit control pages collection.
		/// </summary>
		/// <remarks>Returns null if the page represents the first page.</remarks>
		IEditPage PrevPage
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a next <c>IEditPage</c> within the Edit control pages collection.
		/// </summary>
		/// <remarks>Returns null if the page represents the last page.</remarks>
		IEditPage NextPage
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents <c>IPageHeader</c> specifying page header.
		/// </summary>
		IPageHeader Header
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents <c>IPageHeader</c> specifying page footer.
		/// </summary>
		IPageHeader Footer
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents page's absolute screen coordinate of the page within Edit control. 
		/// </summary>
		Point Origin
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a bounding area of the page withing Edit control.
		/// </summary>
		Rectangle BoundsRect
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents a client(editing) area of the page within Edit control.
		/// </summary>
		Rectangle ClientRect
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents starting line of the page within Edit control content in display coordinates.
		/// </summary>
		int StartLine
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents ending line of the page within Edit control content in display coordinates.
		/// </summary>
		int EndLine
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents ordinal number of page within the Edit control pages collection.
		/// </summary>
		int Index
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, get or sets a boolean value that indicates whether control should paint it's number at the bottom of page.
		/// </summary>
		bool PaintNumber
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, get or sets a boolean value that indicates whether control should use printer settings for calcuating page size, margin and orientation.
		/// </summary>
		bool UsePrinterSettings
		{
			get;
			set;
		}
	}
	#endregion IEditPage

	#region IEditPages
	/// <summary>
	/// Represents a collection of pages in the Edit control.
	/// </summary>
	public interface IEditPages : IEnumerable
	{
		/// <summary>
		/// When implemented by a class, prevents pages updating until calling <c>IEditPages.EndUpdate</c> method.
		/// </summary>
		/// <returns>Number of pages updating locks.</returns>
		int BeginUpdate();
		/// <summary>
		/// When implemented by a class, re-enables pages updating, that was turn of by calling <c>IEditPages.BeginUpdate</c> method.
		/// </summary>
		/// <returns>Number of pages updating locks.</returns>
		int EndUpdate();
		/// <summary>
		/// When implemented by a class, recalculates bounds of all pages in the collection.
		/// </summary>
		void Update();
		/// <summary>
		/// When implemented by a class, recalculates bounds of the specified page.
		/// </summary>
		/// <param name="page">Page to update.</param>
		void Update(IEditPage page);
		/// <summary>
		/// When implemented by a class, recalculates bounds and updates content of specified page.
		/// </summary>
		/// <param name="page">Page to update.</param>
		/// <param name="changed">Indicates that page should recalculate it's content.</param>
		void Update(IEditPage page, bool changed);
		/// <summary>
		/// When implemented by a class, adds a new <c>IEditPage</c> to the collection.
		/// </summary>
		/// <returns><c>IEditPage</c> that is added.</returns>
		IEditPage Add();
		/// <summary>
		/// When implemented by a class, adds specified <c>IEditPage</c> to the collection.
		/// </summary>
		/// <param name="page"><c>IEditPage</c> to add.</param>
		/// <returns>Index of <c>IEditPage</c> that is added.</returns>
		int Add(IEditPage page);
		/// <summary>
		/// When implemented by a class, removes specified <c>IEditPage</c> from the collection.
		/// </summary>
		/// <param name="page"><c>IEditPage</c> to remove.</param>
		void Remove(IEditPage page);
		/// <summary>
		/// When implemented by a class, removes all items from the pages collection.
		/// </summary>
		void Clear();

		/// <summary>
		/// When implemented by a class, finds page at specified display position.
		/// </summary>
		/// <param name="position">Position in display coordinates to obtain the page.</param>
		/// <returns>Ordinal number of found page within the collection.</returns>
		int GetPageIndexAt(Point position);
		/// <summary>
		/// When implemented by a class, finds page at specified display position.
		/// </summary>
		/// <param name="x">X-coordinate of the position (in display coordinates) to find the page.</param>
		/// <param name="y">Y-coordinate of the position (in display coordinates) to find the page.</param>
		/// <returns>Ordinal number of found page within the collection.</returns>
		int GetPageIndexAt(int x, int y);
		/// <summary>
		/// When implemented by a class, finds page at specified screen position.
		/// </summary>
		/// <param name="position">Position in screen coordinates to obtain the page.</param>
		/// <returns>Ordinal number of found page within the collection.</returns>
		int GetPageIndexAtPoint(Point position);
		/// <summary>
		/// When implemented by a class, finds page at specified screen position.
		/// </summary>
		/// <param name="x">X-coordinate of the position (in screen coordinates) to find the page.</param>
		/// <param name="y">Y-coordinate of the position (in screen coordinates) to find the page.</param>
		/// <returns>Ordinal number of found page within the collection.</returns>
		int GetPageIndexAtPoint(int x, int y);
		/// <summary>
		/// When implemented by a class, finds page at caret position.
		/// </summary>
		/// <returns>Ordinal number of found page within the collection.</returns>
		int GetPageIndexAtCursor();

		/// <summary>
		/// When implemented by a class, finds page at specified display position.
		/// </summary>
		/// <param name="position">Position in display coordinates to obtain the page.</param>
		/// <returns><c>IEditPage</c> found.</returns>
		IEditPage GetPageAt(Point position);
		/// <summary>
		/// When implemented by a class, finds page at specified display position.
		/// </summary>
		/// <param name="x">X-coordinate of the position (in display coordinates) to find the page.</param>
		/// <param name="y">Y-coordinate of the position (in display coordinates) to find the page.</param>
		/// <returns><c>IEditPage</c> containing specified position.</returns>
		IEditPage GetPageAt(int x, int y);
		/// <summary>
		/// When implemented by a class, finds page at specified screen position.
		/// </summary>
		/// <param name="position">Position in screen coordinates to obtain the page.</param>
		/// <returns><c>IEditPage</c> containing specified position.</returns>
		IEditPage GetPageAtPoint(Point position);
		/// <summary>
		/// When implemented by a class, finds page at specified screen position.
		/// </summary>
		/// <param name="x">X-coordinate of the position (in screen coordinates) to find the page.</param>
		/// <param name="y">Y-coordinate of the position (in screen coordinates) to find the page.</param>
		/// <returns><c>IEditPage</c> containing specified position.</returns>
		IEditPage GetPageAtPoint(int x, int y);
		/// <summary>
		/// When implemented by a class, finds page at caret position.
		/// </summary>
		/// <returns><c>IEditPage</c> containing caret.</returns>
		IEditPage GetPageAtCursor();
		/// <summary>
		/// When implemented by a class, draws pages collection on the graphic surface.
		/// </summary>
		/// <param name="painter">Specifies <c>IPainter</c> object used to draw text and graphic primitives.</param>
		/// <param name="rect">Rectangular area of pages collection to draw on.</param>
		void Paint(IPainter painter, Rectangle rect);
		/// <summary>
		/// When implemented by a class, initializes page settings with default values.
		/// </summary>
		/// <param name="settings">Specifies page settings to initialize.</param>
		void InitDefaultPageSettings(PageSettings settings);
		/// <summary>
		/// When implemented by a class, cancels dragging operation of the page ruler.
		/// </summary>
		void CancelDragging();
		/// <summary>
		/// When implemented by a class, resets <c>PageType</c> to the default value.
		/// </summary>
		void ResetPageType();
		/// <summary>
		/// When implemented by a class, resets <c>BackColor</c> to the default value.
		/// </summary>
		void ResetBackColor();
		/// <summary>
		/// When implemented by a class, resets <c>BorderColor</c> to the default value.
		/// </summary>
		void ResetBorderColor();
		/// <summary>
		/// When implemented by a class, resets <c>DisplayWhiteSpace</c> to the default value.
		/// </summary>
		void ResetDisplayWhiteSpace();
		/// <summary>
		/// When implemented by a class, resets <c>RulerUnits</c> to the default value.
		/// </summary>
		void ResetRulerUnits();
		/// <summary>
		/// When implemented by a class, resets <c>RulerOptions</c> to the default value.
		/// </summary>
		void ResetRulerOptions();
		/// <summary>
		/// When implemented by a class, resets <c>Rulers</c> to the default value.
		/// </summary>
		void ResetRulers();
		/// <summary>
		/// When implemented by a class, resets <c>RulerBackColor</c> to the default value.
		/// </summary>
		void ResetRulerBackColor();
		/// <summary>
		/// When implemented by a class, resets <c>RulerIndentBackColor</c> to the default value.
		/// </summary>
		void ResetRulerIndentBackColor();
		/// <summary>
		/// When implemented by a class, represents a collection of <c>IEditPage</c> objects.
		/// </summary>
		IList Items
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual <c>IEditPage</c> stored in the collection.
		/// </summary>
		IEditPage this[int index]
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets value specifying the way of viewing Edit control's content.
		/// </summary>
		PageType PageType
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets kind of the pages specifying standart paper size.
		/// </summary>
		PaperKind PageKind
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets properties for default <c>IEditPage</c> object in the pages collection.
		/// </summary>
		IEditPage DefaultPage
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a background color of each page in the collection.
		/// </summary>
		Color BackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a border color of each page in the collection.
		/// </summary>
		Color BorderColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether Edit control should draw whitespace area between pages.
		/// </summary>
		bool DisplayWhiteSpace
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents a number of pages in the collection.
		/// </summary>
		int Count
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents total height of all pages in the collection.
		/// </summary>
		int Height 
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents pages width.
		/// </summary>
		int Width
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents <c>IEditRuler</c> object used as a vertical page ruler.
		/// </summary>
		IEditRuler VertRuler
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents <c>IEditRuler</c> object used as a horizontal page ruler.
		/// </summary>
		IEditRuler HorzRuler
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets measurement units of the pages rulers.
		/// </summary>
		RulerUnits RulerUnits
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets options of the pages rulers.
		/// </summary>
		RulerOptions RulerOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the rulers displayed withing Edit control.
		/// </summary>
		EditRulers Rulers
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates that changing of rulers indentation applies to all pages rather than to current page.
		/// </summary>
		bool ApplyRulerToAllPages
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color of the pages rulers.
		/// </summary>
		Color RulerBackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color of the indentations parts of the pages rulers.
		/// </summary>
		Color RulerIndentBackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether Edit control should draw background around the pages.
		/// </summary>
		bool Transparent 
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when header or footer part of each page is drawing.
		/// </summary>
		event DrawHeaderEvent DrawHeader;
	}
	#endregion IEditPages
	
	#region IEditRuler
	/// <summary>
	/// Represents properties and methods of Edit control's ruler.
	/// </summary>
	public interface IEditRuler : IControl
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>IEditRuler</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IEditRuler</c> to assign.</param>
		void Assign(IEditRuler source);
		/// <summary>
		/// When implemented by a class, cancels dragging operation.
		/// </summary>
		void CancelDragging();
		/// <summary>
		/// When implemented by a class, resets the <c>Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		/// <summary>
		/// When implemented by a class, resets the <c>Units</c> to the default value.
		/// </summary>
		void ResetUnits();
		/// <summary>
		/// When implemented by a class, resets the <c>IndentBackColor</c> to the default value.
		/// </summary>
		void ResetIndentBackColor();
		/// <summary>
		/// When implemented by a class, gets or sets background color of indentation parts of the ruler.
		/// </summary>
		Color IndentBackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value indicating whether ruler has vertical or horizontal direction.
		/// </summary>
		bool Vertical
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets beginning of the page part of the ruler.
		/// </summary>
		int PageStart 
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets width, in pixels between left and right indentations indicating width of the page.
		/// </summary>
		int PageWidth
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets position, in pixels, of left indentation specifying start of the page.
		/// </summary>
		int RulerStart
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets ruler width.
		/// </summary>
		int RulerWidth
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets default distance between adjacent marks.
		/// </summary>
		int MarkWidth
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets ruler measurement units.
		/// </summary>
		RulerUnits Units
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets <c>RulerOptions</c> determining ruler behaviour.
		/// </summary>
		RulerOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, indicates whether some of ruler indentation is in dragging state.
		/// </summary>
		bool IsDragging
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, occurs when some of ruler indentations has changed its position due to the dragging operation.
		/// </summary>
		event EventHandler Change;
	}
	#endregion IEditRuler
	
	#region IBookMark
	/// <summary>
	/// Represents properties and methods to store individual boomark within Edit control.
	/// </summary>
	public interface IBookMark
	{
		/// <summary>
		/// When implemented by a class, copies the contents of another <c>IBookMark</c> object.
		/// </summary>
		/// <param name="source"></param>
		void Assign(IBookMark source);
		/// <summary>
		/// When implemented by a class, gets Y-coordinate of the position (index of line) within the Edit control's text.
		/// </summary>
		int Line
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets X-coordinate of the bookmark position (position of character in a line) within the control's text.
		/// </summary>
		int Pos
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets an integer value that specifies ordinal number of the bookmark.
		/// </summary>
		int Index
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets position of the bookmark within the control's text. Y-Coordinate represents index of line and X-Coordinate - index of character in this line.
		/// </summary>
		Point Position
		{
			get;
		}
	}
	#endregion IBookMark

	#region IBookMarkEx
	/// <summary>
	/// Represents a bookmark with extended possibilities.
	/// </summary>
	public interface IBookMarkEx : IBookMark
	{
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies the name of this <c>IBookMarkEx</c>.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a string value that specifies short description of this <c>IBookMarkEx</c>.
		/// </summary>
		string Description
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an Url address of this <c>IBookMarkEx</c>.
		/// </summary>
		string Url
		{
			get;
			set;
		}
	}
	#endregion IBookMarkEx

	#region IBookMarks
	/// <summary>
	/// Represents properties and methods to provide an indexed access to individual <c>IBookMark</c> object.
	/// </summary>
	public interface IBookMarks : IList 
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>IBookMarks</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IBookMarks</c> to assign.</param>
		void Assign(IBookMarks source);
		/// <summary>
		/// When implemented by a class, finds the first item in the bookmark collection located within the specified text line.
		/// </summary>
		/// <param name="line">Index of the text line.</param>
		/// <returns>Index of the found bookmark.</returns>
		int GetBookMark(int line);
		/// <summary>
		/// When implemented by a class, finds the first item in the bookmark collection located within the specified scope.
		/// </summary>
		/// <param name="startPoint">The Point value that specifies start position to search.</param>
		/// <param name="endPoint">The Point value that specifies end position to search.</param>
		/// <returns>Index of the found bookmark.</returns>
		int GetBookMark(Point startPoint, Point endPoint);
		/// <summary>
		/// When implemented by a class, finds all items in the bookmark collection located within the specified scope.
		/// </summary>
		/// <param name="startPoint">The Point value that specifies start position to search.</param>
		/// <param name="endPoint">The Point value that specifies end position to search.</param>
		/// <param name="list">Represents the collection of the bookmarks located within the specified scope.</param>
		/// <returns>Index of the located bookmarks.</returns>
		int GetBookMarks(Point startPoint, Point endPoint, IList list);
		/// <summary>
		/// When implemented by a class, finds the bookmark with specified Index property within bookmark collection.
		/// </summary>
		/// <param name="bookMark">Specifies bookmark Index.</param>
		/// <returns><c>IBookMark</c> object found.</returns>
		IBookMark FindBookMark(int bookMark);
		/// <summary>
		/// When implemented by a class, finds the bookmark with specified Index in a specific line within bookmark collection.
		/// </summary>
		/// <param name="bookMark">Specifies bookmark Index.</param>
		/// <param name="line">Specifies line Index.</param>
		/// <returns><c>index of bookmark within BookMarks collection</c> object found.</returns>
		int FindBookMark(int bookMark, int line);
		/// <summary>
		/// When implemented by a class, finds the bookmark with specified Name property within bookmark collection.
		/// </summary>
		/// <param name="name">Specifies bookmark name.</param>
		/// <returns><c>IBookMark</c> object found.</returns>
		IBookMark FindBookMark(string name);
		/// <summary>
		/// When implemented by a class, sets the bookmark with specified index to the position specifed by Line parameter.
		/// </summary>
		/// <param name="line">The integer value that specifies index of the text line.</param>
		/// <param name="bookMark">The integer value that specifies bookmark index.</param>
		void SetBookMark(int line, int bookMark);
		/// <summary>
		/// When implemented by a class, sets the bookmark with specified index to the specified position.
		/// </summary>
		/// <param name="position">Specifies position of the bookmark.</param>
		/// <param name="bookMark">The integer value that specifies index of the bookmark.</param>
		void SetBookMark(Point position, int bookMark);
		/// <summary>
		/// When implemented by a class, sets bookmark specified by bookMark parameter.
		/// </summary>
		/// <param name="bookMark">Specifies bookmark to set.</param>
		void SetBookMark(IBookMark bookMark);
		/// <summary>
		/// When implemented by a class, sets the bookmark with specified index, name, description and url to the position specified by Point parameter.
		/// </summary>
		/// <param name="position">Specifies position of the <c>BookMark</c>.</param>
		/// <param name="bookMark">The integer value that specifies <c>BookMark</c> index.</param>
		/// <param name="name">The string value that specifies <c>BookMark</c> name.</param>
		/// <param name="description">The string value that specifies <c>BookMark</c> description.</param>
		/// <param name="url">The string value that specifies <c>BookMark</c> url.</param>
		void SetBookMark(Point position, int bookMark, string name, string description, string url);
		/// <summary>
		/// When implemented by a class, finds the bookmark with specified Index property within bookmark collection.
		/// </summary>
		/// <param name="bookMark">Specifies bookmark index.</param>
		/// <param name="position">Receives position(index of character and line) of the found bookmark.</param>
		/// <returns>True if the bookmark successfully found; otherwise false.</returns>
		bool FindBookMark(int bookMark, out Point position);
		/// <summary>
		/// When implemented by a class, toggles (sets or removes) bookmark with specified Index property at the specified line.
		/// </summary>
		/// <param name="line">Index of line to toggle.</param>
		/// <param name="bookMark">Specifies Index property of the bookmark to toggle.</param>
		void ToggleBookMark(int line, int bookMark);
		/// <summary>
		/// When implemented by a class, toggles (sets or removes) bookmark with specified Index property at the specified position.
		/// </summary>
		/// <param name="position">Specifies position of the bookmark (index of character and current line).</param>
		/// <param name="bookMark">Specifies Index property of the bookmark to toggle.</param>
		void ToggleBookMark(Point position, int bookMark);
		/// <summary>
		/// When implemented by a class, toggles (sets or removes) specified bookmark.
		/// </summary>
		/// <param name="bookMark">Specifies bookmark to toggle.</param>
		void ToggleBookMark(IBookMark bookMark);
		/// <summary>
		/// When implemented by a class, toggles (sets or removes) the bookmark with specified index, name, description and url to the position specified by Point parameter.
		/// </summary>
		/// <param name="position">Specifies position of the bookmark to toggle.</param>
		/// <param name="bookMark">Specifies <c>BookMark</c> index.</param>
		/// <param name="name">Specifies <c>BookMark</c> name.</param>
		/// <param name="description">Specifies <c>BookMark</c> description.</param>
		/// <param name="url">Specifies <c>BookMark</c> url.</param>
		void ToggleBookMark(Point position, int bookMark, string name, string description, string url);
		/// <summary>
		/// When implemented by a class, toggles (sets or removes) bookmark with specified Index property at the current line.
		/// </summary>
		/// <param name="bookMark"></param>
		void ToggleBookMark(int bookMark);
		/// <summary>
		/// When implemented by a class, toggles (sets or removes) an unnumbered bookmark on the current line in the control's text.
		/// </summary>
		void ToggleBookMark();
		/// <summary>
		/// When implemented by a class, finds the bookmark by given index and removes its from bookmark collection.
		/// </summary>
		/// <param name="bookMark">Index of the bookmark in the bookmark collection.</param>
		void ClearBookMark(int bookMark);
		/// <summary>
		/// When implemented by a class, finds the bookmark by given index in a given line and removes its from bookmark collection.
		/// </summary>
		/// <param name="line">Index of line in lines collection.</param>
		/// <param name="bookMark">Index of the bookmark in the bookmark collection.</param>
		void ClearBookMark(int line, int bookmark);
		/// <summary>
		/// When implemented by a class, removes all bookmarks from the specified line.
		/// </summary>
		/// <param name="line">The integer value that specifies index of the text line.</param>
		void ClearBookMarks(int line);
		/// <summary>
		/// When implemented by a class, removes all items from the bookmark collection.
		/// </summary>
		void ClearAllBookMarks();
		/// <summary>
		/// When implemented by a class, returns the minimal possible value of the bookmark's Index property of the new bookmark.
		/// </summary>
		/// <returns>Bookmark index.</returns>
		int NextBookMark();
		/// <summary>
		/// When implemented by a class, moves Edit control's caret to the location of the specified bookmark.
		/// </summary>
		/// <param name="bookMark">Specifies Index property of the bookmark.</param>
		void GotoBookMark(int bookMark);
		/// <summary>
		/// When implemented by a class, moves Edit control's caret to the location of the next unnumbered bookmark.
		/// </summary>
		/// <remarks>If the currently selected bookmark is the last bookmark within the bookmarks collection the method moves to the first bookmark.</remarks>
		void GotoNextBookMark();
		/// <summary>
		/// When implemented by a class, moves Edit control's caret to the location of the previous unnumbered bookmark.
		/// </summary>
		/// <remarks>If the currently selected bookmark is the first bookmark within the bookmarks collection the method moves to the last bookmark.</remarks>
		void GotoPrevBookMark();
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual <c>IBookMark</c> stored in the collection.
		/// </summary>
		new IBookMark this[int index]
		{
			get;
		}
	}
	#endregion IBookMarks

	#region ILineStyle
	/// <summary>
	/// Represents properties and methods for a particular style of the line in Edit control.
	/// </summary>
	public interface ILineStyle
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>ILineStyle</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ILineStyle</c> to assign.</param>
		void Assign(ILineStyle source);
		
		/// <summary>
		/// When implemented by a class, resets the <c>ForeColor</c> to the default value.
		/// </summary>
		void ResetForeColor();
		/// <summary>
		/// When implemented by a class, resets the <c>BackColor</c> to the default value.
		/// </summary>
		void ResetBackColor();
		/// <summary>
		/// When implemented by a class, resets the <c>PenColor</c> to the default value.
		/// </summary>
		void ResetPenColor();
		/// <summary>
		/// When implemented by a class, resets the <c>ImageIndex</c> to the default value.
		/// </summary>
		void ResetImageIndex();
		/// <summary>
		/// When implemented by a class, resets the <c>Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		/// <summary>
		/// When implemented by a class, gets or sets name of the <c>ILineStyle</c>.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets foreground color of the <c>ILineStyle</c>.
		/// </summary>
		Color ForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color of the <c>ILineStyle</c>.
		/// </summary>
		Color BackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets pen color of the <c>ILineStyle</c>.
		/// </summary>
		Color PenColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the index of the image displayed for the <c>ILineStyle</c>.
		/// </summary>
		int ImageIndex
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets display options for the <c>ILineStyle</c>.
		/// </summary>
		LineStyleOptions Options
		{
			get;
			set;
		}
	}
	#endregion ILineStyle

	#region ILineStyles
	/// <summary>
	/// Represents properties and methods for a collection that binds line styles to individual lines within Edit control content.
	/// </summary>
	public interface ILineStyles : IList
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>ILineStyles</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ILineStyles</c> to assign.</param>
		void Assign(ILineStyles source);
		/// <summary>
		/// When implemented by a class, removes the first line style at the specified line.
		/// </summary>
		/// <param name="line">Index of the text line.</param>
		void RemoveLineStyle(int line);
		/// <summary>
		/// When implemented by a class, sets or removes line style at the specified line.
		/// </summary>
		/// <param name="line">Index of line to toggle line style.</param>
		/// <param name="style">Index of style.</param>
		void ToggleLineStyle(int line, int style);
		/// <summary>
		/// When implemented by a class, sets or removes line style at the specified line.
		/// </summary>
		/// <param name="line">Index of line to toggle line style.</param>
		/// <param name="priority">Priority of the line style. This parameter is usefull only for line styles having image indexes</param>
		/// <param name="style">Index of style.</param>
		void ToggleLineStyle(int line, int priority, int style);
		/// <summary>
		/// When implemented by a class, finds the first element in the line style collection located at the specified text line.
		/// </summary>
		/// <param name="index">Index of the text line.</param>
		/// <returns>Index of the found line style if the search succeed; otherwise -1.</returns>
		int GetLineStyle(int index);
		/// <summary>
		/// When implemented by a class, finds all linestyles in the <c>ILineStyles</c> collection located inside specified line.
		/// </summary>
		/// <param name="line">The index of the line to find.</param>
		/// <param name="list">Represents the collection of the bookmarks located within the specified range.</param>
		/// <returns>The number of the linestyles located within the specified range.</returns>
		int GetLineStyles(int line, IList list);
		/// <summary>
		/// When implemented by a class, sets given line style to the specified line.
		/// </summary>
		/// <param name="index">Index of the text line.</param>
		/// <param name="style">Index of the line style.</param>
		void SetLineStyle(int index, int style);
		/// <summary>
		/// When implemented by a class, sets given line style to the specified line.
		/// </summary>
		/// <param name="line">Index of the text line.</param>
		/// <param name="priority">Priority of the line style. This parameter is usefull only for line styles having image indexes</param>
		/// <param name="style">Index of the line style.</param>
		void SetLineStyle(int line, int priority, int style);
		/// <summary>
		/// When implemented by a class, sets given line style to the specified line.
		/// </summary>
		/// <param name="position">Position of the line style.</param>
		/// <param name="priority">Priority of the line style. This parameter is usefull only for line styles having image indexes</param>
		/// <param name="style">Index of the line style.</param>
		void SetLineStyle(Point position, int priority, int style);
		/// <summary>
		/// When implemented by a class, sets given line style to the specified line.
		/// </summary>
		/// <param name="range">Range where line style is defined.</param>
		/// <param name="priority">Priority of the line style. This parameter is usefull only for line styles having image indexes</param>
		/// <param name="style">Index of the line style.</param>
		void SetLineStyle(IRange range, int priority, int style);
	}
	#endregion ILineStyles

	#region ILineStylesEx
	/// <summary>
	/// Represents properties and methods for a collection of the <c>ILineStyle</c> objects each one specifying a particular style of the line in Edit control.
	/// </summary>
	public interface ILineStylesEx : IList
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>ILineStylesEx</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ILineStylesEx</c> to assign.</param>
		void Assign(ILineStylesEx source);
		/// <summary>
		/// When implemented by a class, returns the zero-based index of the first occurrence of the specified Name in the line style collection.
		/// </summary>
		/// <param name="name">Name of line style to locate.</param>
		/// <returns>Index of the style found.</returns>
		int IndexOfName(string name);
		/// <summary>
		/// When implemented by a class, adds a new <c>ILineStyle</c> to the collection.
		/// </summary>
		/// <returns>Index of the added element.</returns>
		int AddLineStyle();
		/// <summary>
		/// When implemented by a class, adds a new <c>ILineStyle</c> with specified parameters to the collection.
		/// </summary>
		/// <param name="name">Name of new <c>ILineStyle</c>.</param>
		/// <param name="foreColor">Foreground color of new <c>ILineStyle</c>.</param>
		/// <param name="backColor">Background color of new <c>ILineStyle</c>.</param>
		/// <param name="penColor">Pen color of new <c>ILineStyle</c>.</param>
		/// <param name="imageIndex">Image index of new <c>ILineStyle</c>.</param>
		/// <param name="options">Options of new <c>ILineStyle</c>.</param>
		/// <returns>Index of the added element in the <c>ILineStyle</c> collection.</returns>
		int AddLineStyle(string name, Color foreColor, Color backColor, Color penColor, int imageIndex, LineStyleOptions options);
		/// <summary>
		/// When implemented by a class, returns <c>ILineStyle</c> within the line styles collection by its index.
		/// </summary>
		/// <param name="index">Index of <c>ILineStyle</c>.</param>
		/// <returns><c>ILineStyle</c> with specified Index property.</returns>
		ILineStyle GetLineStyle(int index);
	}
	#endregion ILineStylesEx
	
	#region ILineSeparator
	/// <summary>
	/// Represents properties and methods used to separate lines and highlight current line within the Edit control.
	/// </summary>
	public interface ILineSeparator
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>ILineSeparator</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ILineSeparator</c> to assign.</param>
		void Assign(ILineSeparator source);
		/// <summary>
		/// When implemented by a class, indicates whether Edit control owning the <c>ILineSeparator</c> need to highlight the current line.
		/// </summary>
		/// <returns>True if need; otherwise false.</returns>
		bool NeedHighlight();
		/// <summary>
		/// When implemented by a class, indicates whether Edit control owning the <c>ILineSeparator</c> needs to hide highlighting of the current line when loosing input focus.
		/// </summary>
		/// <returns>True if need; otherwise false.</returns>
		bool NeedHide();
		/// <summary>
		/// When implemented by a class, resets the <c>Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		/// <summary>
		/// When implemented by a class, resets the <c>HighlightForeColor</c> to the default value.
		/// </summary>
		void ResetHighlightForeColor();
		/// <summary>
		/// When implemented by a class, resets the <c>HighlightBackColor</c> to the default value.
		/// </summary>
		void ResetHighlightBackColor();
		/// <summary>
		/// When implemented by a class, resets the <c>LineColor</c> to the default value.
		/// </summary>
		void ResetLineColor();
		/// <summary>
		/// When implemented by a class, resets the <c>ContentDividerColor</c> to the default value.
		/// </summary>
		void ResetContentDividerColor();

		/// <summary>
		/// When implemented by a class, temporary highlights specifies line until Edit control state changed.
		/// </summary>
		/// <param name="index">Index of line to highlight.</param>
		void TempHighlightLine(int index);
		/// <summary>
		/// Removes highlightning from temporary highlighted line.
		/// </summary>
		void TempUnhighlightLine();
		/// <summary>
		/// When implemented by a class, gets or sets a set of flags customizing appearance and behaviour of the <c>ILineSeparator</c>.
		/// </summary>
		SeparatorOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a background color of highlighted line.
		/// </summary>
		Color HighlightBackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a foreground color of highlighted line.
		/// </summary>
		Color HighlightForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets color of horizontal lines between particular lines in the Edit control.
		/// </summary>
		Color LineColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets color of horizontal lines between text sections in the Edit control.
		/// </summary>
		Color ContentDividerColor
		{
			get;
			set;
		}

	}
	#endregion ILineSeparator
	
	#region ISelection
	/// <summary>
	/// Contains properties and methods used to manage selected part of the Edit control's text content.
	/// </summary>
	public interface ISelection
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>ISelection</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ISelection</c> to assign.</param>
		void Assign(ISelection source);
		/// <summary>
		/// When implemented by a class, sets new selection region with specified selection type.
		/// </summary>
		/// <param name="selectionType">New selection type.</param>
		/// <param name="selectionRect">New selected rectangle.</param>
		void SetSelection(SelectionType selectionType, Rectangle selectionRect);
		/// <summary>
		/// When implemented by a class, sets new selection region with specified selection type.
		/// </summary>
		/// <param name="selectionType">New selection type.</param>
		/// <param name="selectionStart">Left-top corner of the selected rectange.</param>
		/// <param name="selectionEnd">Right-bottom corner of the selected rectangle.</param>
		void SetSelection(SelectionType selectionType, Point selectionStart, Point selectionEnd);

		/// <summary>
		/// When implemented by a class, increases selected text to one character at the left side of the selection region.
		/// </summary>
		void SelectCharLeft();
		/// <summary>
		/// When implemented by a class, increases selected text to one character at the left side of the selection region and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectCharLeft(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to one character at the right side of the selection region.
		/// </summary>
		void SelectCharRight();
		/// <summary>
		/// When implemented by a class, increases selected text to one character at the right side of the selection region and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectCharRight(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to the word located at the left side of the current position in the control.
		/// </summary>
		void SelectWordLeft();
		/// <summary>
		/// When implemented by a class, increases selected text to the word located at the left side of the current position in the control and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectWordLeft(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to the word located at the right side of the current position in the control.
		/// </summary>
		void SelectWordRight();
		/// <summary>
		/// When implemented by a class, increases selected text to the word located at the right side of the current position in the control and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectWordRight(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to the preceding line in the control.
		/// </summary>
		void SelectLineUp();
		/// <summary>
		/// When implemented by a class, increases selected text to the preceding line in the control and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectLineUp(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to the following line in the control.
		/// </summary>
		void SelectLineDown();
		/// <summary>
		///  When implemented by a class, increases selected text to the following line in the control and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectLineDown(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to the one page up in the control.
		/// </summary>
		void SelectPageUp();
		/// <summary>
		/// When implemented by a class, increases selected text to the one page up in the control and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectPageUp(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to the one page down in the control.
		/// </summary>
		void SelectPageDown();
		/// <summary>
		/// When implemented by a class, increases selected text to the one page down in the control and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectPageDown(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to the begin of screen.
		/// </summary>
		void SelectScreenTop();
		/// <summary>
		/// When implemented by a class, increases selected text to the begin of the screen and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectScreenTop(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to the end of screen.
		/// </summary>
		void SelectScreenBottom();
		/// <summary>
		/// When implemented by a class, increases selected text to the end of the screen and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectScreenBottom(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, selects from current position to the beginning of current line in the control.
		/// </summary>
		void SelectLineBegin();
		/// <summary>
		/// When implemented by a class, selects from current position to the beginning of current line in the control and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectLineBegin(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, selects from current position to the end of current line in the control.
		/// </summary>
		void SelectLineEnd();
		/// <summary>
		/// When implemented by a class, selects from current position to the end of current line in the control and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectLineEnd(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to beginning of the control's content.
		/// </summary>
		void SelectFileBegin();
		/// <summary>
		/// When implemented by a class, increases selected text to beginning of the control's content and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectFileBegin(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, increases selected text to end of the control's content.
		/// </summary>
		void SelectFileEnd();
		/// <summary>
		/// When implemented by a class, increases selected text to end of the control's content and sets a given selection type.
		/// </summary>
		/// <param name="selectionType">New type of the selection.</param>
		void SelectFileEnd(SelectionType selectionType);
		/// <summary>
		/// When implemented by a class, selects entire line at the current position in the control.
		/// </summary>
		void SelectLine();
		/// <summary>
		/// When implemented by a class, selects word at the current position in the control.
		/// </summary>
		void SelectWord();
		/// <summary>
		/// When implemented by a class, selects all lines in the control's content.
		/// </summary>
		void SelectAll();
		/// <summary>
		/// When implemented by a class, increases selected text to the prev open brace.
		/// </summary>
		void SelectToOpenBrace();
		/// <summary>
		/// When implemented by a class, increases selected text to the next closing brace.
		/// </summary>
		void SelectToCloseBrace();
		/// <summary>
		/// When implemented by a class, increases selected text to the next open or closing brace.
		/// </summary>
		void SelectToBrace();
		/// <summary>
		/// When implemented by a class, marks the selected text as a comment, using the correct comment syntax for the programming language.
		/// </summary>
		void CommentSelection();
		/// <summary>
		/// When implemented by a class, removes the comment syntax from the selected text.
		/// </summary>
		void UncommentSelection();
		/// <summary>
		/// When implemented by a class, formats selected text using indentation obtained from Syntax Parser supporting <c>QWhale.Syntax.SyntaxOptions.SmartIndent</c>.
		/// </summary>
		void SmartFormat();
		/// <summary>
		/// When implemented by a class, formats given line using indentation obtained from Syntax Parser supporting <c>QWhale.Syntax.SyntaxOptions.SmartIndent</c>.
		/// </summary>
		void SmartFormat(int line);
		/// <summary>
		/// When implemented by a class, positions the cursor to the line indentation level, obtained from parser supporting <c>QWhale.Syntax.SyntaxOptions.SmartIndent</c> option when user presses Enter.
		/// </summary>
		void SmartIndent();
		/// <summary>
		/// When implemented by a class, formats current syntax block using indentation obtained from Syntax Parser supporting <c>QWhale.Syntax.SyntaxOptions.SmartIndent</c>.
		/// </summary>
		void SmartFormatBlock();
		/// <summary>
		/// When implemented by a class, formats entire document using indentation obtained from Syntax Parser supporting <c>QWhale.Syntax.SyntaxOptions.SmartIndent</c>.
		/// </summary>
		void SmartFormatDocument();
		/// <summary>
		/// When implemented by a class, converts spaces to tabs in the current string within the selected area according to tab settings.
		/// </summary>
		void Tabify();
		/// <summary>
		/// When implemented by a class, converts tabs to spaces in the current string within the selected area according to tab settings.
		/// </summary>
		void UnTabify();
		/// <summary>
		/// When implemented by a class, indents the selected text by one indentation level, inserting Tab or spaces to the beginning of the line.
		/// </summary>
		void Indent();
		/// <summary>
		/// When implemented by a class, unindents the selected text by one indentation level, deleting Tab or spaces from the beginning of the line.
		/// </summary>
		void UnIndent();
		/// <summary>
		/// When implemented by a class, converts all selected characters to the lower-case.
		/// </summary>
		void LowerCase();
		/// <summary>
		/// When implemented by a class, converts all selected characters to the upper-case.
		/// </summary>
		void UpperCase();
		/// <summary>
		/// When implemented by a class, changes first character of all words in selected text to upper-case and all another characters to lower-case.
		/// </summary>
		void Capitalize();
		/// <summary>
		/// When implemented by a class, removes all space and tab characters from selected text. If no text selected - removes space and tab characters from current line.
		/// </summary>
		void DeleteWhiteSpace();
		/// <summary>
		/// When implemented by a class, toggles expanded state for all <c>IOutlineRange</c> objects in outline collection.
		/// </summary>
		void ToggleOutlining();
		/// <summary>
		/// When implemented by a class, collapses and expandes some outline section to get a quick overall view of the Edit content.
		/// </summary>
		void CollapseToDefinitions();
		/// <summary>
		/// When implemented by a class, change current position from beginning of selection rectangle to the end of selection rectangle or vice versa.
		/// </summary>
		void SwapAnchor();
		/// <summary>
		/// When implemented by a class, indicates whether selected text can be copied to clipboard.
		/// </summary>
		/// <returns>True if the selection is not empty; otherwise false.</returns>
		bool CanCopy();
		/// <summary>
		/// When implemented by a class, indicates whether selected text can be cut to the clipboard.
		/// </summary>
		/// <returns>True if the selection can be cut; otherwise false.</returns>
		bool CanCut();
		/// <summary>
		/// When implemented by a class, indicates whether control can paste some text from the clipboard.
		/// </summary>
		/// <returns>True if the Clipboard has some text or unicode text;</returns>
		bool CanPaste();
		/// <summary>
		/// When implemented by a class, copies <c>SelectedText</c> to the Clipboard.
		/// </summary>
		void Copy();
		/// <summary>
		/// When implemented by a class, cuts <c>SelectedText</c> to the Clipboard.
		/// </summary>
		void Cut();
		/// <summary>
		/// When implemented by a class, pastes content of the Clipboard to the Edit control, replacing selected text if needed.
		/// </summary>
		void Paste();
		/// <summary>
		/// When implemented by a class, deletes selected text from the control.
		/// </summary>
		/// <returns>True if successfull</returns>
		bool Delete();
		/// <summary>
		/// When implemented by a class, makes selection empty, without deleting its content.
		/// </summary>
		void Clear();
		/// <summary>
		/// When implemented by a class, moves or copies selected text to the specified position.
		/// </summary>
		/// <param name="position">Position to move or copy.</param>
		/// <param name="deleteOrigin">Indicates whether method should move or copy selected text.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool Move(Point position, bool deleteOrigin);
		/// <summary>
		/// When implemented by a class, prevents the <c>ISelection</c> updating until the <c>EndUpdate</c> method is called.
		/// <seealso cref="QWhale.Editor.Selection.EndUpdate"/>
		/// </summary>
		/// <returns>Number of update locks.</returns>
		int BeginUpdate();
		/// <summary>
		/// When implemented by a class, re-enables selection updating turned off by calling <c>BeginUpdate</c> method.
		/// <seealso cref="QWhale.Editor.Selection.BeginUpdate"/>
		/// </summary>
		/// <returns>Number of update locks.</returns>
		int EndUpdate();
		/// <summary>
		/// When implemented by a class, deletes one character left to the cursor.
		/// </summary>
		void DeleteLeft();
		/// <summary>
		/// When implemented by a class, deletes one character right to the cursor.
		/// </summary>
		void DeleteRight();
		/// <summary>
		/// When implemented by a class, deletes one word left to the cursor.
		/// </summary>
		void DeleteWordLeft();
		/// <summary>
		/// When implemented by a class, deletes one word right to the cursor.
		/// </summary>
		void DeleteWordRight();
		/// <summary>
		/// When implemented by a class, deletes current line if no text selected; otherwise deletes selected text.
		/// </summary>
		void DeleteLine();
		/// <summary>
		/// When implemented by a class, cuts current line to the clipboard if no text is selected; otherwise cuts selected text.
		/// </summary>
		void CutLine();
		/// <summary>
		/// When implemented by a class, inserts a line break at the current position of the control.
		/// </summary>
		void NewLine();
		/// <summary>
		/// When implemented by a class, inserts a line break above the current position of the control.
		/// </summary>
		void NewLineAbove();
		/// <summary>
		/// When implemented by a class, inserts a line break below the current position of the control.
		/// </summary>
		void NewLineBelow();
		/// <summary>
		/// When implemented by a class, processes escape presure: method deselects selected text.
		/// </summary>
		void ProcessEscape();
		/// <summary>
		/// When implemented by a class, inserts new tab character or spaces if the selected text is empty; otherwise indents selected text.
		/// </summary>
		void ProcessTab();
		/// <summary>
		/// When implemented by a class, moves current position to the previous tab stop if the selected text is empty; otherwise unindents selected text.
		/// </summary>
		void ProcessShiftTab();
		/// <summary>
		/// When implemented by a class, toggles the control's overwrite mode.
		/// </summary>
		void ToggleOverWrite();
		/// <summary>
		/// When implemented by a class, inserts given text to the control's content deleting selected text if needed.
		/// </summary>
		/// <param name="s">Text to insert.</param>
		void InsertString(string s);
		/// <summary>
		/// When implemented by a class, transposes character under the caret with the next character.
		/// </summary>
		void CharTransponse();
		/// <summary>
		/// When implemented by a class, transposes word under the caret with the next word.
		/// </summary>
		void WordTransponse();
		/// <summary>
		/// When implemented by a class, transposes line under the caret with the next line.
		/// </summary>
		void LineTransponse();
		/// <summary>
		/// When implemented by a class, indicates whether control can drag selected text.
		/// </summary>
		/// <param name="position">Specifies destination position of drag operation.</param>
		/// <returns>True if the control can drag selected text; otherwise false.</returns>
		/// <remarks>Control must not be in the read-only state to allow dragging selected text.</remarks>
		bool CanDrag(Point position);
		/// <summary>
		/// When implemented by a class, moves or copies selected text to the specified position.
		/// </summary>
		/// <param name="position">Position to move or copy.</param>
		/// <param name="deleteOrigin">Indicates whether method should move or copy selected text.</param>
		void DragTo(Point position, bool deleteOrigin);
		/// <summary>
		/// When implemented by a class, changes selected text by applying specified event to every line in the selected text.
		/// </summary>
		/// <param name="action">Specifies action to execute.</param>
		void ChangeBlock(StringEvent action);
		/// <summary>
		/// When implemented by a class, changes selected text by applying specified event to every line in the selected text.
		/// </summary>
		/// <param name="action">Specifies action to execute.</param>
		/// <param name="changeIfEmpty">Indicates that action should be performed for current line if selection is empty.</param>
		/// <param name="extendFirstLine">Specifies that action should applied to whole lines in the selested region rather than to the selected portion of the line.</param>
		void ChangeBlock(StringEvent action, bool changeIfEmpty, bool extendFirstLine);
		/// <summary>
		/// When implemented by a class, converts given selection coordinate to the text coordinate.
		/// </summary>
		/// <param name="position">The selection coordinate Point to convert.</param>
		/// <returns>Point that represents the converted position, in text coordinates.</returns>
		Point SelectionToTextPoint(Point position);
		/// <summary>
		/// When implemented by a class, converts given text coordinate to the selection coordinate.
		/// </summary>
		/// <param name="position">The text coordinate Point to convert.</param>
		/// <returns>Point that represents the converted position, in selection coordinates.</returns>
		Point TextToSelectionPoint(Point position);
		/// <summary>
		/// When implemented by a class, indicates whether given position located within the selected region.
		/// </summary>
		/// <param name="position">Position to check.</param>
		/// <returns>True if position in selected region; otherwise false.</returns>
		bool IsPosInSelection(Point position);
		/// <summary>
		/// When implemented by a class, indicates whether given position located within the selected region.
		/// </summary>
		/// <param name="x">Horizontal coordinate of the position to check.</param>
		/// <param name="y">Vertical coordinate of the position to check.</param>
		/// <returns>True if position in selected region; otherwise false.</returns>
		bool IsPosInSelection(int x, int y);
		/// <summary>
		/// When implemented by a class, sets left and right parameter to the first and last selected characters within specified line.
		/// </summary>
		/// <param name="index">Index of line within Edit control content.</param>
		/// <param name="left">Receives index of the first selected character.</param>
		/// <param name="right">Receives index of the last selected character.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool GetSelectionForLine(int index, out int left, out int right);
		/// <summary>
		/// When implemented by a class, returns amount of the lines being selected.
		/// </summary>
		/// <returns>Number of selected lines.</returns>
		int SelectedCount();
		/// <summary>
		/// When implemented by a class, returns selected part of string at specified position.
		/// </summary>
		/// <param name="index">Specifies index of the line.</param>
		/// <returns>Selected part of specified string.</returns>
		/// <remarks>If selection is empty method returns null.</remarks>
		string SelectedString(int index);
		/// <summary>
		/// When implemented by a class, resets the <c>Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		/// <summary>
		/// When implemented by a class, resets the <c>AllowedSelectionMode</c> to the default value.
		/// </summary>
		void ResetAllowedSelectionMode();
		/// <summary>
		/// When implemented by a class, resets the <c>ForeColor</c> to the default value.
		/// </summary>
		void ResetForeColor();
		/// <summary>
		/// When implemented by a class, resets the <c>BackColor</c> to the default value.
		/// </summary>
		void ResetBackColor();
		/// <summary>
		/// When implemented by a class, resets the <c>InActiveForeColor</c> to the default value.
		/// </summary>
		void ResetInActiveForeColor();
		/// <summary>
		/// When implemented by a class, resets the <c>InActiveBackColor</c> to the default value.
		/// </summary>
		void ResetInActiveBackColor();
		/// <summary>
		/// When implemented by a class, resets the <c>BorderColor</c> to the default value.
		/// </summary>
		void ResetBorderColor();
		/// <summary>
		/// When implemented by a class, keeps track of calls to <c>BeginUpdate</c> and <c>EndUpdate</c> so that they can be nested.
		/// </summary>
		int UpdateCount
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, indicates whether nothing is selected.
		/// </summary>
		/// <returns>True if empty; otherwise false.</returns>
		bool IsEmpty
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the position of the first selected character while text considered as a single string.
		/// </summary>
		int SelectionStart
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets length of the <c>SelectedText</c>.
		/// </summary>
		int SelectionLength
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets rectangular area indicating selected text of the control.
		/// </summary>
		Rectangle SelectionRect
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets type of current selection.
		/// <seealso cref="QWhale.Editor.SelectionType"/>
		/// </summary>
		SelectionType SelectionType
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets strings that corresponds to selected part of the control's text content.
		/// </summary>
		string SelectedText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets options determining behaviour or the <c>ISelection</c>.
		/// </summary>
		SelectionOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a foreground color of the <c>SelectedText</c> when owner control has input focus.
		/// </summary>
		Color ForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a background color of the <c>SelectedText</c> when owner control has input focus.
		/// </summary>
		Color BackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a foreground color of the <c>SelectedText</c> when owner control does not have input focus.
		/// </summary>
		Color InActiveForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a color of the selection border.
		/// </summary>
		Color BorderColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a background color of the <c>SelectedText</c> when owner control does not have input focus.
		/// </summary>
		Color InActiveBackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets types of selection allowed to Edit control content.
		/// </summary>
		AllowedSelectionMode AllowedSelectionMode
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when selection bounds are changed.
		/// </summary>
		event EventHandler SelectionChanged;
	}
	#endregion ISelection
	
	#region IWordBreak
	/// <summary>
	/// Represents properties and methods used to separate words within Edit control content.
	/// </summary>
	public interface IWordBreak
	{
		/// <summary>
		/// When implemented by a class, indicates whether the character at the specific position of given string is a delimiter character.
		/// </summary>
		/// <param name="s">The string in which character should be tested.</param>
		/// <param name="pos">The index of character in the given string.</param>
		/// <returns>True if specified character is delimiter; otherwise false.</returns>
		bool IsDelimiter(string s, int pos);
		/// <summary>
		/// When implemented by a class, indicates whether the character at the specific position of the string collection is delimiter character.
		/// </summary>
		/// <param name="index">The index of line in which character should be tested.</param>
		/// <param name="pos">The index of character in the specific string.</param>
		/// <returns>True if specified character is delimiter; otherwise false.</returns>
		bool IsDelimiter(int index, int pos);
		/// <summary>
		/// When implemented by a class, indicates whether the specified character is delimiter character.
		/// </summary>
		/// <param name="ch">The char value that should be tested.</param>
		/// <returns>True if specified character is delimiter; otherwise false.</returns>
		bool IsDelimiter(char ch);
		/// <summary>
		/// When implemented by a class, returns word start and end, if there is word at the specified position.
		/// </summary>
		/// <param name="s">The given string.</param>
		/// <param name="pos">The index of character within the string.</param>
		/// <param name="left">Receives start position of the word.</param>
		/// <param name="right">Receives end position of the word.</param>
		/// <returns>True if any word found; otherwise false.</returns>
		bool GetWord(string s, int pos, out int left, out int right);
		/// <summary>
		/// When implemented by a class, returns word start and end, if there is word at the specified position.
		/// </summary>
		/// <param name="index">The index of line in the text.</param>
		/// <param name="pos">The index of character in the within the string.</param>
		/// <param name="left">Receives start position of the word.</param>
		/// <param name="right">Receives end position of the word.</param>
		/// <returns>True if any word found; otherwise false.</returns>
		bool GetWord(int index, int pos, out int left, out int right);
		/// <summary>
		/// When implemented by a class, returns word at the specific text position.
		/// </summary>
		/// <param name="pos">Specifies index of the line.</param>
		/// <param name="line">Specifies index of character in the text string.</param>
		/// <returns>Word found at the specified position.</returns>
		string GetTextAt(int pos, int line);
		/// <summary>
		/// When implemented by a class, returns word at the specific text position.
		/// </summary>
		/// <param name="position">The Point value that specifies position in the text.</param>
		/// <returns>Word found at the specified position.</returns>
		string GetTextAt(Point position);
		/// <summary>
		/// When implemented by a class, resets the <c>Delimiters</c> to the defalut value.
		/// </summary>
		void ResetDelimiters();
		
		/// <summary>
		/// When implemented by a class, gets or sets an array of characters used as delimiters between words in the text.
		/// </summary>
		char[] Delimiters
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets <c>Delimiters</c> as a single string.
		/// </summary>
		string DelimiterString
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents <c>Delimiters</c>  as a key-and-value pairs collection where each key is a single delimiter character.
		/// </summary>
		Hashtable DelimTable
		{
			get;
		}
	}
	#endregion IWordBreak

	#region IWordWrap
	/// <summary>
	/// Represents properties and methods to wrap Edit control's text content.
	/// </summary>
	public interface IWordWrap
	{
		/// <summary>
		/// When implemented by a class, re-wraps all lines in the text.
		/// </summary>
		/// <returns>True if succeed; otherwise false.</returns>
		bool UpdateWordWrap();
		/// <summary>
		/// When implemented by a class, re-wraps lines in the text within specific scope.
		/// </summary>
		/// <param name="first">Specifies first line to wrap.</param>
		/// <param name="last">Specifies last line to wrap.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool UpdateWordWrap(int first, int last);
		/// <summary>
		/// When implemented by a class, returns position of the wrapping margin.
		/// </summary>
		/// <returns></returns>
		int GetWrapMargin();
		/// <summary>
		/// When implemented by a class, resets the <c>WordWrap</c> to the defalut value.
		/// </summary>
		void ResetWordWrap();
		/// <summary>
		/// When implemented by a class, resets the <c>WrapAtMargin</c> to the defalut value.
		/// </summary>
		void ResetWrapAtMargin();
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether control automatically wraps words to the beginning of the next line when necessary.
		/// </summary>
		bool WordWrap
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether control automatically wraps words at margin position.
		/// </summary>
		bool WrapAtMargin
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets position of the wrapping margin.
		/// </summary>
		int WrapMargin
		{
			get;
		}
	}
	#endregion IWordWrap

	#region IDisplayStrings
	/// <summary>
	/// Represents properties and methods for a collection of visible strings in the Edit control.
	/// </summary>
	public interface IDisplayStrings : IEnumerator, IStringList, ITabulation, IWordWrap, ITextSearch,
		IWordBreak, ICollapsable, IFmtExport, IFmtImport
	{
		/// <summary>
		/// When implemented by a class, converts the specified text coordinates to display coordinates.
		/// </summary>
		/// <param name="x">The X-constituent of the Point value that specifies the text coordinates to be converted.</param>
		/// <param name="y">The Y-constituent of the Point value that specifies the text coordinates to be converted.</param>
		/// <returns>Display coordinates of the specified text point.</returns>
		/// <remarks>Display coordinate represents point in Edit control, it may be different from text coordinate due to tabulations, wordwrap and outlining.</remarks>
		Point PointToDisplayPoint(int x, int y);
		/// <summary>
		/// When implemented by a class, converts the specified text coordinates to display coordinates.
		/// </summary>
		/// <param name="position">The Point value that specifies the text coordinates to be converted.</param>
		/// <returns>Display coordinates of the specified text point.</returns>
		/// <remarks>Display coordinate represents point in Edit control, it may be different from text coordinate due to tabulations, wordwrap and outlining.</remarks>
		Point PointToDisplayPoint(Point position);
		/// <summary>
		/// When implemented by a class, converts the specified display coordinates to text coordinates.
		/// </summary>
		/// <param name="x">The X-constituent of the Point value that specifies the display coordinates to be converted.</param>
		/// <param name="y">The Y-constituent of the Point value that specifies the display coordinates to be converted.</param>
		/// <returns>Text coordinates of specified display point.</returns>
		/// <remarks>Display coordinate represents point in Edit control, it may be different from text coordinate due to tabulations, wordwrap and outlining.</remarks>
		Point DisplayPointToPoint(int x, int y);
		/// <summary>
		/// When implemented by a class, converts the specified display coordinates to the text coordinates.
		/// </summary>
		/// <param name="position">The Point value that specifies the display coordinates to be converted.</param>
		/// <returns>Text coordinates of specified display point.</returns>
		/// <remarks>Display coordinate represents point in Edit control, it may be different from text coordinate due to tabulations, wordwrap and outlining.</remarks>
		Point DisplayPointToPoint(Point position);
		/// <summary>
		/// When implemented by a class, returns number of visible lines.
		/// </summary>
		/// <returns>Number of visible lines.</returns>
		int GetCount();
		/// <summary>
		/// When implemented by a class, returns color information related to the the specified line.
		/// </summary>
		/// <param name="index">The index of line in strings array.</param>
		/// <returns>Color information of specified line.</returns>
		short[] GetColorData(int index);
		/// <summary>
		/// When implemented by a class, returns lexical style related to the specified position.
		/// </summary>
		/// <param name="position">The Point value that specifies position to receive lexical style.</param>
		/// <returns>Lexical style at specified position.</returns>
		int GetLexStyle(Point position);
		/// <summary>
		/// When implemented by a class, gets or sets the collection of underlying "real" collection of text lines.
		/// </summary>
		ISyntaxStrings Lines
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets width of the largest line in the control's text.
		/// </summary>
		int MaxLineWidth
		{
			get;
		}
	}
	#endregion IDisplayStrings
	
	#region IGutter
	/// <summary>
	/// Represents properties and methods to operate with gutter at the left side of the Edit control.
	/// </summary>
	public interface IGutter
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>IGutter</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IGutter</c> to assign.</param>
		void Assign(IGutter source);
		/// <summary>
		/// When implemented by a class, draws gutter on the specified graphic surface.
		/// </summary>
		/// <param name="painter">Represents <c>IPainter</c> surface to draw on.</param>
		/// <param name="rect">Rectangular area of gutter to draw.</param>
		/// <param name="startLine">the first display line to draw</param>
		void Paint(IPainter painter, Rectangle rect, int startLine);
		/// <summary>
		/// When implemented by a class, draws gutter on the specified graphic surface.
		/// </summary>
		/// <param name="painter">Represents <c>IPainter</c> surface to draw on.</param>
		/// <param name="rect">Rectangular area of gutter to draw.</param>
		void Paint(IPainter painter, Rectangle rect);
		/// <summary>
		/// When implemented by a class, raises the <c>Click</c> event.
		/// </summary>
		/// <param name="e">The EventArgs that contains data to this event.</param>
		void OnClick(EventArgs e);
		/// <summary>
		/// When implemented by a class, raises the <c>DoubleClick</c> event.
		/// </summary>
		/// <param name="e">The EventArgs that contains data to this event.</param>
		void OnDoubleClick(EventArgs e);
		/// <summary>
		/// When implemented by a class, resets the <c>Width</c> to the default value.
		/// </summary>
		/// <summary>
		/// When implemented by a class, resets the <c>BrushColor</c> to the default value.
		/// </summary>
		void ResetBrushColor();
		/// <summary>
		/// When implemented by a class, resets the <c>PenColor</c> to the default value.
		/// </summary>
		void ResetPenColor();
		/// <summary>
		/// When implemented by a class, resets the <c>Visible</c> to the default value.
		/// </summary>
		void ResetVisible();
		/// <summary>
		/// When implemented by a class, resets the <c>LineNumbersStart</c> to the default value.
		/// </summary>
		void ResetLineNumbersStart();
		/// <summary>
		/// When implemented by a class, resets the <c>LineNumbersLeftIndent</c> to the default value.
		/// </summary>
		void ResetLineNumbersLeftIndent();
		/// <summary>
		/// When implemented by a class, resets the <c>LineNumbersRightIndent</c> to the default value.
		/// </summary>
		void ResetLineNumbersRightIndent();
		/// <summary>
		/// When implemented by a class, resets the <c>LineNumbersForeColor</c> to the default value.
		/// </summary>
		void ResetLineNumbersForeColor();
		/// <summary>
		/// When implemented by a class, resets the <c>LineNumbersBackColor</c> to the default value.
		/// </summary>
		void ResetLineNumbersBackColor();
		/// <summary>
		/// When implemented by a class, resets the <c>LineNumbersAlignment</c> to the default value.
		/// </summary>
		void ResetLineNumbersAlignment();
		/// <summary>
		/// When implemented by a class, resets the <c>OutliningLeftIndentt</c> to the default value.
		/// </summary>
		void ResetOutliningLeftIndent();
		/// <summary>
		/// When implemented by a class, resets the <c>OutliningRightIndent</c> to the default value.
		/// </summary>
		void ResetOutliningRightIndent();
		/// <summary>
		/// When implemented by a class, resets the <c>Options</c> to the default value.
		/// </summary>
		void ResetOptions();
		/// <summary>
		/// When implemented by a class, resets the <c>BookMarkImageIndex</c> to the default value.
		/// </summary>
		void ResetBookMarkImageIndex();
		/// <summary>
		/// When implemented by a class, resets the <c>WrapImageIndex</c> to the default value.
		/// </summary>
		void ResetWrapImageIndex();
		/// <summary>
		/// When implemented by a class, resets the <c>DrawLineBookmarks</c> to the default value.
		/// </summary>
		void ResetDrawLineBookmarks();
		/// <summary>
		/// When implemented by a class, resets the <c>LineBookmarksColor</c> to the default value.
		/// </summary>
		void ResetLineBookmarksColor();
		/// <summary>
		/// When implemented by a class, resets the <c>ShowBookmarkHints</c> to the default value.
		/// </summary>
		void ResetShowBookmarkHints();
	
		/// <summary>
		/// When implemented by a class, resets the <c>LineModificatorChangedColor</c> to the default value.
		/// </summary>
		void ResetLineModificatorChangedColor();
		/// <summary>
		/// When implemented by a class, resets the <c>LineModificatorSavedColor</c> to the default value.
		/// </summary>
		void ResetLineModificatorSavedColor();

		/// <summary>
		/// When implemented by a class, resets the <c>Width</c> to the default value.
		/// </summary>
		void ResetWidth();
		/// <summary>
		/// When implemented by a class, resets the <c>UserMarginWidth</c> to the default value.
		/// </summary>
		void ResetUserMarginWidth();
		/// <summary>
		/// When implemented by a class, resets the <c>UserMarginForeColor</c> to the default value.
		/// </summary>
		void ResetUserMarginForeColor();
		/// <summary>
		/// When implemented by a class, resets the <c>UserMarginBackColor</c> to the default value.
		/// </summary>
		void ResetUserMarginBackColor();
		/// <summary>
		/// When implemented by a class, resets the <c>UserMarginText</c> to the default value.
		/// </summary>
		void ResetUserMarginText();
		/// <summary>
		/// When implemented by a class, gets or sets the width of the gutter.
		/// </summary>
		int Width
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a Brush object used to paint gutter.
		/// </summary>
		Brush Brush
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a Pen object used to paint gutter line.
		/// </summary>
		Pen Pen
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color of the gutter.
		/// </summary>
		Color BrushColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets color of the gutter line.
		/// </summary>
		Color PenColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the gutter area is visible.
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets the rectangle that represents gutter area.
		/// </summary>
		Rectangle Rect
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets index of the first line being painted on the gutter.
		/// </summary>
		int LineNumbersStart
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets line numbers indentation from the left gutter border.
		/// </summary>
		int LineNumbersLeftIndent
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets line numbers indentation from the right gutter border.
		/// </summary>
		int LineNumbersRightIndent
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets foreground color of the line numbers.
		/// </summary>
		Color LineNumbersForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color of the line numbers.
		/// </summary>
		Color LineNumbersBackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets line numbers alignment information.
		/// </summary>
		StringAlignment LineNumbersAlignment
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets outlining indentation from the left gutter border.
		/// </summary>
		int OutliningLeftIndent
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets outlining indentation from the right gutter border.
		/// </summary>
		int OutliningRightIndent
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a <c>GutterOptions</c> that determine gutter appearance and behaviour.
		/// </summary>
		GutterOptions Options
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an ImageList object that contains collection of images for gutter.
		/// </summary>
		ImageList Images
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that specifies index of item in the image collection used to paint bookmark.
		/// </summary>
		int BookMarkImageIndex
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that specifies index of item in the image collection used to paint special mark indicating the wrapped line.
		/// </summary>
		int WrapImageIndex
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether Edit control should draw triangle at bookmark position inside line.
		/// </summary>
		bool DrawLineBookmarks 
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a color of the line bookmarks.
		/// </summary>
		Color LineBookmarksColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether Edit control should display text describing bookmark in form of tooltip window when mouse pointer is over the gutter bookmark.
		/// </summary>
		bool ShowBookmarkHints
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a color of the line modificators(color stitch that indicates that the line content is unmodified, modified or saved) in the modified state.
		/// </summary>
		Color LineModificatorChangedColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a color of the line modificators(color stitch that indicates that the line content is unmodified, modified or saved) in the saved state.
		/// </summary>
		Color LineModificatorSavedColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the width of the user margin area.
		/// </summary>
		int UserMarginWidth
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets foreground color for the user margin.
		/// </summary>
		Color UserMarginForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color of the user margin.
		/// </summary>
		Color UserMarginBackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets text of the user margin.
		/// </summary>
		string UserMarginText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when the <c>IGutter</c> clicked.
		/// </summary>
		event EventHandler Click;
		/// <summary>
		/// When implemented by a class, occurs when the <c>IGutter</c> double-clicked.
		/// </summary>
		event EventHandler DoubleClick;
		/// <summary>
		/// When implemented by a class, occurs when user margin part of each line is drawing.
		/// </summary>
		event DrawUserMarginEvent DrawUserMargin;
	}
	#endregion IGutter
	
	#region IMargin
	/// <summary>
	/// Represents properties and methods specifying appearance of the margin in Edit control.
	/// </summary>
	public interface IMargin
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>IMargin</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IMargin</c> to assign.</param>
		void Assign(IMargin source);
		/// <summary>
		/// When implemented by a class, draws <c>IMargin</c> object on the specified graphic surface.
		/// </summary>
		/// <param name="painter">Represents <c>IPainter</c> surface to draw on.</param>
		/// <param name="rect">Rectangular area of <c>IMargin</c> to draw.</param>
		void Paint(IPainter painter, Rectangle rect);
		/// <summary>
		/// Draws margin column on the specified graphic surface.
		/// </summary>
		/// <param name="painter">Represents <c>IPainter</c> surface to draw on.</param>
		/// <param name="rect">Rectangular area of <c>Margin</c> to draw.</param>
		void PaintColumn(IPainter painter, Rectangle rect);
		/// <summary>
		/// When implemented by a class, resets the <c>Position</c> to the default value.
		/// </summary>
		void ResetPosition();
		/// <summary>
		/// When implemented by a class, resets the <c>ColumnPositions</c> to the default value.
		/// </summary>
		void ResetColumnPositions();
		/// <summary>
		/// When implemented by a class, resets the <c>PenColor</c> to the default value.
		/// </summary>
		void ResetPenColor();
		/// <summary>
		/// When implemented by a class, resets the <c>Visible</c> to the default value.
		/// </summary>
		void ResetVisible();
		/// <summary>
		/// When implemented by a class, resets the <c>ColumnPenColor</c> to the default value.
		/// </summary>
		void ResetColumnsPenColor();
		/// <summary>
		/// When implemented by a class, resets the <c>ColumnsVisible</c> to the default value.
		/// </summary>
		void ResetColumnsVisible();
		/// <summary>
		/// When implemented by a class, resets the <c>AllowDrag</c> to the default value.
		/// </summary>
		void ResetAllowDrag();
		/// <summary>
		/// When implemented by a class, resets the <c>ShowHints</c> to the default value.
		/// </summary>
		void ResetShowHints();
		/// <summary>
		/// When implemented by a class, cancels dragging the margin.
		/// </summary>
		void CancelDragging();
		/// <summary>
		/// When implemented by a class, indicates whether <c>IMargin</c> area contains given position.
		/// </summary>
		/// <param name="x">The X-constituent of the Point value that specifies the point to check-up.</param>
		/// <param name="y">The Y-constituent of the Point value that specifies the point to check-up.</param>
		/// <returns>True if contains; otherwise false.</returns>
		bool Contains(int x, int y);
		/// <summary>
		/// When implemented by a class, moves <c>IMargin</c> to specified position.
		/// </summary>
		/// <param name="x">The X-constituent of the Point value that specifies position to drag.</param>
		/// <param name="y">The Y-constituent of the Point value that specifies position to drag.</param>
		void DragTo(int x, int y);
		/// <summary>
		/// When implemented by a class, gets or sets value indicating position, in characters, of the vertical line within the text portion of the control.
		/// </summary>
		int Position
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the character columns where additional column margin will be drawn.
		/// </summary>
		int[] ColumnPositions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets Pen object that describes the color and pattern of <c>IMargin</c> line.
		/// </summary>
		Pen Pen
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a color of the margin line.
		/// </summary>
		Color PenColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets Pen object that describes the color and pattern of column margin lines.
		/// </summary>
		Pen ColumnPen
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a color of the column margin line.
		/// </summary>
		Color ColumnPenColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether vertical line should be painted.
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether column margins should be painted.
		/// </summary>
		bool ColumnsVisible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, indicates whether <c>IMargin</c> is in dragging state.
		/// </summary>
		bool IsDragging
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class,  indicates whether drag operation can performed to <c>IMargin</c>.
		/// </summary>
		bool AllowDrag
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether <c>IMargin</c> should display some hint when mouse pointer is over the margin area.
		/// </summary>
		bool ShowHints
		{
			get;
			set;
		}
	}
	#endregion IMargin
	
	#region IHyperText
	/// <summary>
	/// Represetns methods to operate with hypertext sections within the text.
	/// </summary>
	public interface IHyperText
	{
		/// <summary>
		/// When implemented by a class, indicates whether given text represents hypertest.
		/// </summary>
		/// <param name="text">Text to test.</param>
		/// <returns>True if given text represents hypertext; otherwise false.</returns>
		bool IsHyperText(string text);
		/// <summary>
		/// When implemented by a class, resets <c>HighlightUrls</c> to the default value.
		/// </summary>
		void ResetHighlightUrls();
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether hypertext urls in the text should be highlighted.
		/// </summary>
		bool HighlightUrls
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when a control needs checking whether some string represents hypertext.
		/// </summary>
		event HyperTextEvent CheckHyperText;
	}
	#endregion IHyperText

	#region IHyperTextEx
	/// <summary>
	/// Represetns extended properties and methods to operate hypertext section within the text.
	/// <seealso cref="QWhale.Editor.IHyperText"/>
	/// </summary>
	public interface IHyperTextEx : IHyperText
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>IHyperTextEx</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IHyperTextEx</c> to assign.</param>
		void Assign(IHyperTextEx source);
		/// <summary>
		/// When implemented by a class, tries to launch default browser to process specified url.
		/// </summary>
		/// <param name="text">Specifies name of a document or application file to jump to.</param>
		void UrlJump(string text);
		/// <summary>
		/// When implemented by a class, resets the <c>UrlStyle</c> to the default value.
		/// </summary>
		/// <remarks>Use JumpToUrl to suppress launching default browser.</remarks>
		void ResetUrlStyle();
		/// <summary>
		/// When implemented by a class, resets the <c>UrlColor</c> to the default value.
		/// </summary>
		void ResetUrlColor();
		/// <summary>
		/// When implemented by a class, resets the <c>ShowHints</c> to the default value.
		/// </summary>
		void ResetShowHints();
		/// <summary>
		/// When implementing by a class, gets or sets value indicating whether default hint for hypertext section needs displaying when user moves mouse over the hypertext.
		/// </summary>
		bool ShowHints
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets font style of highlighted urls.
		/// </summary>
		FontStyle UrlStyle
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that represents color of highlighted urls.
		/// </summary>
		Color UrlColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when user attempts to jump to url.
		/// </summary>
		event UrlJumpEvent JumpToUrl;
	}
	#endregion IHyperTextEx

	#region ISpelling
	/// <summary>
	/// Represents properties and methods allowing check spelling of the text.
	/// </summary>
	public interface ISpelling
	{
		/// <summary>
		/// When implemented by a class, checks whether spelling for the given word is correct.
		/// </summary>
		/// <param name="text">Specifies text to check-up.</param>
		/// <returns>True if correct; otherwise false.</returns>
		bool IsWordCorrect(string text);

		/// <summary>
		/// When implemented by a class, resets the <c>CheckSpelling</c> to the default value.
		/// </summary>
		void ResetCheckSpelling();

		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the document can check spelling for its content.
		/// </summary>
		bool CheckSpelling
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when spelling of some word within the text needs checking.
		/// </summary>
		event WordSpellEvent WordSpell;
	}
	#endregion ISpelling

	#region ISpellingEx
	/// <summary>
	/// Represents properties and methods to allowing to visually highlight mispelled words in the control.
	/// </summary>
	public interface ISpellingEx : ISpelling
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>ISpellingEx</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>ISpellingEx</c> to assign.</param>
		void Assign(ISpellingEx source);
		/// <summary>
		/// When implemented by a class, resets the <c>SpellColor</c> to the default value.
		/// </summary>
		void ResetSpellColor();
		/// <summary>
		/// When implemented by a class, gets or sets a value representing color to draw wavy underlines under mispelled words.
		/// </summary>
		Color SpellColor
		{
			get;
			set;
		}
	}
	#endregion ISpellingEx
	
	#region IKeyList
	/// <summary>
	/// Represents list of key or its combinations with attached actions.
	/// </summary>
	public interface IKeyList
	{
		/// <summary>
		/// When implemented by a class, adds a new key to key collection with specified parameters.
		/// </summary>
		/// <param name="keyData">Key added to the collection.</param>
		/// <param name="action">Extended action that executes when the key is pressed.</param>
		/// <param name="param">Object passed as a parameter to the extended action.</param>
		/// <param name="state">State of the Edit control when key is pressed.</param>
		/// <param name="leaveState">State of the Edit control after key is pressed.</param>
		void Add(Keys keyData, KeyEventEx action, object param, int state, int leaveState);
		/// <summary>
		/// When implemented by a class, adds a new key to key collection with specified parameters.
		/// </summary>
		/// <param name="keyData">Key added to the collection.</param>
		/// <param name="action">Action that executes when the key is pressed.</param>
		/// <param name="state">State of the Edit control before key is pressed.</param>
		/// <param name="leaveState">State of the Edit control after key is pressed.</param>
		void Add(Keys keyData, KeyEvent action, int state, int leaveState);
		/// <summary>
		/// When implemented by a class, adds a new key to key collection with specified parameters.
		/// </summary>
		/// <param name="keyData">Key added to the collection.</param>
		/// <param name="action">Extended action that executes when the key is pressed.</param>
		/// <param name="param">Object passed as a parameter to the extended action.</param>
		void Add(Keys keyData, KeyEventEx action, object param);
		/// <summary>
		/// When implemented by a class, adds a new key to key collection with specified action.
		/// </summary>
		/// <param name="keyData">Key added to the collection.</param>
		/// <param name="action">Action that executes when the key is pressed.</param>
		void Add(Keys keyData, KeyEvent action);
		/// <summary>
		/// When implemented by a class, adds a new key to key collection with specified parameters and default (normal) state and leave state.
		/// </summary>
		/// <param name="keyData">Key added to the collection.</param>
		/// <param name="action">Extended action that executes when the key is pressed.</param>
		/// <param name="param">Object passed as a parameter to the extended action.</param>
		void AddNormal(Keys keyData, KeyEventEx action, object param);
		/// <summary>
		/// When implemented by a class, adds a new key to key collection with specified parameters and default (normal) state and leave state.
		/// </summary>
		/// <param name="keyData">Key that added to the collection.</param>
		/// <param name="action">Action that executes when the key is pressed.</param>
		void AddNormal(Keys keyData, KeyEvent action);
		/// <summary>
		/// When implemented by a class, removes given key from the key collection.
		/// </summary>
		/// <param name="keyData">Key to remove.</param>
		/// <param name="state">State of the Edit control when the key is pressed.</param>
		void Remove(Keys keyData, int state);
		/// <summary>
		/// When implemented by a class, removes given key from the key collection.
		/// </summary>
		/// <param name="keyData">Key to remove.</param>
		void Remove(Keys keyData);
		/// <summary>
		/// When implemented by a class, removes all elements from the key list.
		/// </summary>
		void Clear();
		/// <summary>
		/// When implemented by a class, executes action or extended action attached to the specified key.
		/// </summary>
		/// <param name="keyData">Key for which action should be executed.</param>
		/// <param name="state">Receive leave state of specified action.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool ExecuteKey(Keys keyData, ref int state);
		/// <summary>
		/// When implemented by a class, indicates whether given key locates within the collection.
		/// </summary>
		/// <param name="keyData">Key to find.</param>
		/// <param name="state">State of the Edit control before the key is pressed.</param>
		/// <returns>True if the specified key exists; otherwise false.</returns>
		bool FindKey(Keys keyData, int state);
		/// <summary>
		/// When implemented by a class, represents an event handlers collection which contains elements that can be used as a particular action attached to key or key combination from the <c>IKeyList</c>.
		/// </summary>
		EventHandlers Handlers
		{
			get;
		}
	}
	#endregion IKeyList
	
	#region ICodeCompletionWindow
	/// <summary>
	/// Represents properties and methods to display a popup window containing Code Completion information.
	/// </summary>
	public interface ICodeCompletionWindow : IControl
	{
		/// <summary>
		/// When implemented by a class, displays popup window at the current mouse position.
		/// </summary>
		void Popup();
		/// <summary>
		/// When implemented by a class, displays popup window at the specified screen position.
		/// </summary>
		/// <param name="x">Horizontal coordinate at which popup window should be displayed.</param>
		/// <param name="y">Vertical coordinate at which popup window should be displayed.</param>
		void PopupAt(int x, int y);
		/// <summary>
		/// When implemented by a class, displays popup window at the specified screen position.
		/// </summary>
		/// <param name="position">The Point object that specifies the coordinates at which popup window should be displayed.</param>
		void PopupAt(Point position);
		/// <summary>
		/// When implemented by a class, closes the popup window.
		/// </summary>
		/// <param name="accept">Indicates whether the result of the popup should be accepted.</param>
		void Close(bool accept);
		/// <summary>
		/// When implemented by a class, closes the popup window with delay.
		/// </summary>
		/// <param name="accept">Indicates whether the result of the popup should be accepted.</param>
		void CloseDelayed(bool accept);
		/// <summary>
		/// When implemented by a class, indicates whether <c>ICodeCompletionWindow</c> or it's child control has an input focus.
		/// </summary>
		/// <returns>True if focused; otherwise false.</returns>
		bool IsFocused();
		/// <summary>
		/// When implemented by a class, updates <c>ICodeCompletionWindow</c> content from its <c>Provider</c>.
		/// </summary>
		void ResetContent();
		/// <summary>
		/// When implemented by a class, resets the <c>Sizeable</c> to the default value.
		/// </summary>
		void ResetSizeable();
		/// <summary>
		/// When implemented by a class, resets the <c>AutoSize</c> to the default value.
		/// </summary>
		void ResetAutoSize();
		/// <summary>
		/// When implemented by a class, resets the <c>CodeCompletions</c> to the default value.
		/// </summary>
		void ResetCodeCompletionFlags();
		/// <summary>
		/// When implemented by a class, gets or sets the object that contains data related to the popup window.
		/// </summary>
		ICodeCompletionProvider Provider
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the border of the popup window is resizable.
		/// </summary>
		bool Sizeable
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether a popup window is automatically resized to fit its contents.
		/// </summary>
		bool AutoSize
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
		/// When implemented by a class, gets or sets collection of attributes that specifies behaviour of the popup window.
		/// </summary>
		CodeCompletionFlags CompletionFlags
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents a control owning the <c>ICodeCompletionWindow</c>.
		/// </summary>
		Control OwnerControl
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies position within the text (as index of line and character) where <c>ICodeCompletionWindow</c> is valid.
		/// </summary>
		Point StartPos
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies position within the text (as index of line and character) where <c>ICodeCompletionWindow</c> is valid.
		/// </summary>
		Point EndPos
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies position within the text (as index of line and character) where <c>ICodeCompletionWindow</c> is displayed.
		/// </summary>
		Point DisplayPos
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when the popup window is closed.
		/// </summary>
		event ClosePopupEvent ClosePopup;
		/// <summary>
		/// When implemented by a class, occurs when the popup window is displayed.
		/// </summary>
		event ShowPopupEvent ShowPopup;
		/// <summary>
		/// When implemented by a class, occurs when the popup window is disposed.
		/// </summary>
		event EventHandler Disposed;
		/// <summary>
		/// Occurs when the popup window receives key message
		/// </summary>
		/// <remarks>The event handler receives an argument of type <c>KeyPreviewEventArgs</c> containing data related to this event.</remarks>
		event KeyPreviewEvent KeyPreviewEvent;

	}
	#endregion ICodeCompletionWindow

	#region ICodeCompletionColumn
	/// <summary>
	/// Represents properties and methods to indentify individual column object within a code completion columns collection.
	/// </summary>
	public interface ICodeCompletionColumn
	{
		/// <summary>
		/// When implemented by a class, resets <c>FontStyle</c> to the default value.
		/// </summary>
		void ResetFontStyle();
		/// <summary>
		/// When implemented by a class, resets <c>ForeColor</c> to the default value.
		/// </summary>
		void ResetForeColor();
		/// <summary>
		/// When implemented by a class, resets <c>Visible</c> to the default value.
		/// </summary>
		void ResetVisible();
		/// <summary>
		/// When implemented by a class, gets or sets the name of the column.
		/// </summary>
		string Name
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets font style of the column.
		/// </summary>
		FontStyle FontStyle
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets foreground color of the column.
		/// </summary>
		Color ForeColor 
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether a column is visible.
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
	}
	#endregion ICodeCompletionColumn

	#region ICodeCompletionColumns
	/// <summary>
	/// Represents properties and methods to provide indexed access to <c>ICodeCompletionColumn</c>object.
	/// </summary>
	public interface ICodeCompletionColumns : IList
	{
		/// <summary>
		/// When implemented by a class, provides an indexed access to individual <c>ICodeCompletionColumn</c> stored in the collection.
		/// </summary>
		new ICodeCompletionColumn this[int index]
		{
			get;
			set;
		}
	}
	#endregion

	#region ICodeCompletionBox
	/// <summary>
	/// Represents properties and methods to display a popup window that can contain Code Completion information presented in the form of list.
	/// </summary>
	public interface ICodeCompletionBox : ICodeCompletionWindow
	{
		/// <summary>
		/// When implemented by a class, removes all columns from the <c>ICodeCompletionBox</c> column collection.
		/// </summary>
		void ClearColumns();
		/// <summary>
		/// When implemented by a class, adds a new column to the <c>ICodeCompletionBox</c> column collection.
		/// </summary>
		/// <returns>New added column.</returns>
		ICodeCompletionColumn AddColumn();
		/// <summary>
		/// When implemented by a class, inserts a new column to the specified position in the column collection.
		/// </summary>
		/// <param name="index">Index of the column in the collection.</param>
		/// <returns>New inserted column.</returns>
		ICodeCompletionColumn InsertColumn(int index);
		/// <summary>
		/// When implemented by a class, removes the column at the specified index of the column collection.
		/// </summary>
		/// <param name="index">Specifies zero-based index of the column to remove.</param>
		void RemoveColumnAt(int index);
		/// <summary>
		/// When implemented by a class, resets the <c>DropDownCount</c> to the default value.
		/// </summary>
		void ResetDropDownCount();
		/// <summary>
		/// When implemented by a class, represents collection of <c>ICodeCompletionColumn</c> objects displayed by Code Completion ListBox.
		/// </summary>
		ICodeCompletionColumn[] Columns
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that specifies maximal visible index of the ListBox items within the popup control.
		/// </summary>
		int DropDownCount
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether <c>ICodeCompletionBox</c> should filter its content using <c>Filer</c> property.
		/// </summary>
		bool Filtered
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets filter string used to filter <c>ICodeCompletionBox</c> content.
		/// </summary>
		string Filter
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the items in the <c>ICodeCompletionBox</c> are sorted alphabetically.
		/// </summary>
		bool Sorted
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when index specifying the currently selected item is changed.
		/// </summary>
		event EventHandler SelectionChanged;
	}
	#endregion ICodeCompletionBox

	#region ICodeCompletionHint
	/// <summary>
	/// Represents properties and methods to display a popup window that can contain Code Completion information presented in the form of tooltip window.
	/// </summary>
	public interface ICodeCompletionHint : ICodeCompletionWindow, ISyntaxPaint
	{
		/// <summary>
		/// When implemented by a class, resets the <c>AutoHide</c> to the default value.
		/// </summary>
		void ResetAutoHide();
		/// <summary>
		/// When implemented by a class, resets the <c>AutoHidePause</c> to the default value.
		/// </summary>
		void ResetAutoHidePause();

		/// <summary>
		/// When implemented by a class, gets or sets a value that indicates whether <c>ICodeCompletionHint</c> should be closed after some period of time.
		/// </summary>
		bool AutoHide
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that specifies delay, in miliseconds, between displaying and hiding popup hint.
		/// </summary>
		int AutoHidePause
		{
			get;
			set;
		}
	}
	#endregion ICodeCompletionHint

	#region ICodeCompletionEdit
	/// <summary>
	/// Represents properties and methods to display a popup window that can contain Code Completion information presented in the form of edit with label.
	/// </summary>
	public interface ICodeCompletionEdit : ICodeCompletionWindow
	{
		/// <summary>
		/// When implemented by a class, gets or sets a value that indicates caption of the Edit label.
		/// </summary>
		string EditField
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that indicates path to the nested data.
		/// </summary>
		string EditPath
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that indicates text of the field being edited.
		/// </summary>
		string EditText
		{
			get;
			set;
		}
	}
	#endregion ICodeCompletionBox

	#region IBraceMatching
	/// <summary>
	/// Represents properties and methods to handle matching braces within the Edit control.
	/// </summary>
	public interface IBraceMatching 
	{
		/// <summary>
		/// When implemented by a class, locates closing brace.
		/// </summary>
		/// <param name="x">Retrieves X-coordinate of the found brace.</param>
		/// <param name="y">Retrieves Y-coordinate of the found brace.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool FindClosingBrace(ref int x, ref int y);
		/// <summary>
		/// When implemented by a class, locates closing brace.
		/// </summary>
		/// <param name="position">Retrieves position of the found brace.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool FindClosingBrace(ref Point position);
		/// <summary>
		/// When implemented by a class, locates open brace.
		/// </summary>
		/// <param name="x">Retrieves X-coordinate of the found brace.</param>
		/// <param name="y">Retrieves Y-coordinate of the found brace.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool FindOpenBrace(ref int x, ref int y);
		/// <summary>
		/// When implemented by a class, locates open brace.
		/// </summary>
		/// <param name="position">Retrieves position of the found brace.</param>
		/// <returns>True if succeed; otherwise false.</returns>
		bool FindOpenBrace(ref Point position);
		/// <summary>
		/// When implemented by a class, temporary highlights all text within the area specified by rects.
		/// <seealso cref="QWhale.Editor.IBraceMatching.TempUnhighlightBraces"/>
		/// </summary>
		/// <param name="rects">Specifies the area to highlight the text.</param>
		void TempHighlightBraces(Rectangle[] rects);
		/// <summary>
		/// When implemented by a class, cancels text highlighting turned on using <c>TempHighlightBraces</c>
		/// <seealso cref="QWhale.Editor.IBraceMatching.TempHighlightBraces"/>
		/// </summary>
		void TempUnhighlightBraces();
		/// <summary>
		/// When implemented by a class, resets the <c>BracesOptions</c> to its default value.
		/// </summary>
		void ResetBracesOptions();
		/// <summary>
		/// When implemented by a class, resets the <c>OpenBraces</c> to its default value.
		/// </summary>
		void ResetOpenBraces();
		/// <summary>
		/// When implemented by a class, resets the <c>ClosingBraces</c> to its default value.
		/// </summary>
		void ResetClosingBraces();
		/// <summary>
		/// When implemented by a class, gets or sets options specifying appearance and behaviour of matching braces within Edit control.
		/// </summary>
		BracesOptions BracesOptions
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an array of characters each one representing an open brace.
		/// </summary>
		char[] OpenBraces
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an array of characters each one representing a closing brace.
		/// </summary>
		char[] ClosingBraces
		{
			get;
			set;
		}
	}
	#endregion IBraceMatching

	#region IBraceMatchingEx
	/// <summary>
	/// Represents extended properties and methods to handle matching braces within the Edit control.
	/// </summary>
	public interface IBraceMatchingEx : IBraceMatching
	{
		/// <summary>
		/// When implemented by a class, copies the contents from another <c>IBraceMatchingEx</c> object.
		/// </summary>
		/// <param name="source">Specifies <c>IBraceMatchingEx</c> to assign.</param>
		void Assign(IBraceMatchingEx source);
		
		/// <summary>
		/// When implemented by a class, resets the <c>ForeColor</c> to the default value.
		/// </summary>
		void ResetForeColor();
		/// <summary>
		/// When implemented by a class, resets the <c>BackColor</c> to the default value.
		/// </summary>
		void ResetBackColor();
		/// <summary>
		/// When implemented by a class, resets the <c>Style</c> to the default value.
		/// </summary>
		void ResetStyle();
		/// <summary>
		/// When implemented by a class, resets the <c>UseRoundRect</c> to the default value.
		/// </summary>
		void ResetUseRoundRect();
		/// <summary>
		/// When implemented by a class, gets or sets a value that represents foreground color to draw matching braces.
		/// </summary>
		Color ForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value that represents background color to draw matching braces.
		/// </summary>
		Color BackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a FontStyle value that is used to draw matching braces.
		/// </summary>
		FontStyle Style
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether Edit control should draw rectangle around matching braces.
		/// </summary>
		bool UseRoundRect
		{
			get;
			set;
		}
	}
	#endregion IBraceMatchingEx

	#region ITextSource
	/// <summary>
	/// Represents properties and methods that provide interface between edited text and Edit control.
	/// </summary>
	public interface ITextSource : IEditEx, INavigate, IUndo, ISourceNotify, INotifier,
		IImport, IExportEx, IHyperText, ISpelling, IBraceMatching, ITrackChanges
	{
		/// <summary>
		/// When implemented by a class, converts given Point value to the absolute position.
		/// </summary>
		/// <param name="position">Point value where Y-Coordinate represents index of line and X-Coordinate - index of character in this line.</param>
		/// <returns>Absolute position of given point.</returns>
		int TextPointToAbsolutePosition(Point position);
		/// <summary>
		/// When implemented by a class, converts given absolute position to position as Point value.
		/// </summary>
		/// <param name="position">Specifies index of character if the text considered as a single string.</param>
		/// <returns>Point value where Y-Coordinate represents index of line and X-Coordinate - index of character in this line.</returns>
		Point AbsolutePositionToTextPoint(int position);
		/// <summary>
		/// When implemented by a class, converts given Point value to the index of character.
		/// </summary>
		/// <param name="position">Point value where Y-Coordinate represents index of line and X-Coordinate - index of character in this line.</param>
		/// <returns>Index of character if the text considered as a single string.</returns>
		int GetCharIndexFromPosition(Point position);
		/// <summary>
		/// When implemented by a class, converts given character index to position as Point value.
		/// </summary>
		/// <param name="charIndex">Specifies index of character if the text considered as a single string.</param>
		/// <returns>Point value where Y-Coordinate represents index of line and X-Coordinate - index of character in this line.</returns>
		Point GetPositionFromCharIndex(int charIndex);

		/// <summary>
		/// When implemented by a class, perform lexical analysis of the specified string.
		/// </summary>
		/// <param name="index">Index of line to parse.</param>
		void ParseString(int index);
		/// <summary>
		/// When implemented by a class, perform lexical analysis specified strings.
		/// </summary>
		/// <param name="first">Index of the first line to parse.</param>
		/// <param name="last">Index of the last line to parse.</param>
		void ParseStrings(int first, int last);
		/// <summary>
		/// When implemented by a class, perform lexical analysis of specified strings.
		/// </summary>
		/// <param name="index">Index of the last string to parse.</param>
		/// <remarks>Method parses string collection from last parsed string to the string specified by Index parameter.</remarks>
		void ParseToString(int index);

		/// <summary>
		/// When implemented by a class, indicates whether syntax parsing can be performed for the text, or some of formatting text elements, such as urls or braces, should be highlighted.
		/// </summary>
		/// <returns>True if need to perform syntax parsing; otherwise false.</returns>
		bool NeedParse();
		/// <summary>
		/// When implemented by a class, tries to format and outline <c>TextSource</c> text using attached <c>Lexer</c>.
		/// </summary>
		void FormatText();
		/// <summary>
		/// When implemented by a class, sets color information to curent <c>IStrItem.ColorData</c>.
		/// </summary>
		/// <param name="pos">Specifies the first item in <c>IStrItem.ColorData</c> to set.</param>
		/// <param name="len">Specifies number of items in <c>IStrItem.ColorData</c> to set.</param>
		/// <param name="flag">Specifies color information to set.</param>
		/// <param name="setFlag">Indicates whether Color information should be set or removed.</param>
		void SetColorFlag(Point pos, int len, ColorFlags flag, bool setFlag);
		/// <summary>
		/// Create a new <c>IStrItem</c> object containing specified text.
		/// </summary>
		/// <param name="s">String that <c>IStrItem</c> contain.</param>
		/// <returns>Created <c>IStrItem</c> object.</returns>
		IStrItem CreateStrItem(string s);

		/// <summary>
		/// When implemented by a class, gets or sets name of file that holds text source content.
		/// </summary>
		string FileName
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents a collection of <c>ISyntaxEdit</c> controls linked to the text source.
		/// </summary>
		IList Edits
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents the object that implements <c>ISyntaxStrings</c> interface containing collection of strings determining text source content.
		/// </summary>
		ISyntaxStrings Lines
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets text source content as a single string with the individual strings delimited by carriage returns.
		/// </summary>
		string Text
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>ILineStyles</c> interface hodling collection of line styles for this document.
		/// </summary>
		ILineStyles LineStyles
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>IBookMarks</c> interface holding collection of <c>IBookMark</c> objects each determening particular bookmark within the text source.
		/// </summary>
		IBookMarks BookMarks
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets an object that represent currently active (focused) <c>ISyntaxEdit</c> control linked to the text source.
		/// </summary>
		ISyntaxEdit ActiveEdit
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets object that can perform lexical analysis of the text source content.
		/// </summary>
		ILexer Lexer 
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented in a class, gets the line currently parsed by the attached Lexer, when text source performs syntax parsing of the text.
		/// </summary>
		int ParserLine
		{
			get;
		}
	}
	#endregion ITextSource

	#region ISyntaxEdit
	/// <summary>
	/// Represents properties and methods for an advanced multi-line Edit control.
	/// </summary>
	public interface ISyntaxEdit : ISyntaxPaint, ISearch, INotifier, ICaret, INavigateEx, IEdit,
		IWordWrap, IFmtExportEx, IFmtImport, ICodeCompletion, IRecordPlayBack, IEditColors, 
		ISplitView, IAutoCorrect, IControl
	{
		/// <summary>
		/// When implemented by a class, converts given screen coordinates to text coordinates (index of line and character).
		/// </summary>
		/// <param name="position">The screen coordinate Point to convert.</param>
		/// <returns>The Point representing text coordinate.</returns>
		Point ScreenToText(Point position);
		/// <summary>
		/// When implemented by a class, converts given text coordinates, index of line and character, to screen coordinates.
		/// </summary>
		/// <param name="position">The text coordinate Point to convert.</param>
		/// <returns>The Point representing screen coordinate</returns>
		Point TextToScreen(Point position);
		/// <summary>
		/// When implemented by a class, converts given screen coordinates to text coordinates (index of line and character).
		/// </summary>
		/// <param name="x">Horizontal screen coordinate to convert.</param>
		/// <param name="y">Vertical screen coordinate to convert.</param>
		/// <returns>The Point representing text coordinate.</returns>
		Point ScreenToText(int x, int y);
		/// <summary>
		/// When implemented by a class, converts given text coordinates, index of line and character, to screen coordinates.
		/// </summary>
		/// <param name="x">Horizontal text coordinate to convert.</param>
		/// <param name="y">Vertical text coordinate to convert.</param>
		/// <returns>The Point representing screen coordinate.</returns>
		Point TextToScreen(int x, int y);
		/// <summary>
		/// When implemented by a class, converts given screen coordinates to display coordinates(index of line and character).
		/// </summary>
		/// <param name="x">Horizontal screen coordinate to convert.</param>
		/// <param name="y">Vertical screen coordinate to convert.</param>
		/// <returns>The Point representing display coordinate.</returns>
		/// <remarks>Display coordinate represents point in Edit control, it may be different from text coordinate due to tabulations, wordwrap and outlining.</remarks>
		Point ScreenToDisplay(int x, int y);
		/// <summary>
		/// When implemented by a class, converts given display coordinates, index of line and character, to screen coordinates.
		/// </summary>
		/// <param name="x">Index of character in the line.</param>
		/// <param name="y">Index of line.</param>
		/// <returns>The Point representing screen coordinate</returns>
		/// <remarks>Display coordinate represents point in Edit control, it may be different from text coordinate due to tabulations, wordwrap and outlining.</remarks>
		Point DisplayToScreen(int x, int y);
		/// <summary>
		/// When implemented by a class, moves caret to the position of drag cursor.
		/// </summary>
		/// <param name="position">Position in the text to make visible.</param>
		void MoveCaretOnDrag();
		/// <summary>
		/// When implemented by a class, scrolls the control's content, if necessary, to ensure a specified text position is in view.
		/// </summary>
		/// <param name="position">Position in the text to make visible.</param>
		void MakeVisible(Point position);
		/// <summary>
		/// When implemented by a class, scrolls the control's content, if necessary, to ensure a specified text position is in view.
		/// </summary>
		/// <param name="position">Position in the text to make visible.</param>
		/// <param name="centerLine">Specifies whether given line must be centered within control's client area.</param>
		void MakeVisible(Point position, bool centerLine);
		/// <summary>
		/// When implemented by a class, displays tooltip indicating destination line when scrolling.
		/// </summary>
		/// <param name="pos">Specifies vertical position (in display coordinates) to obtain hint info.</param>
		void ShowScrollHint(int pos);
		/// <summary>
		/// When implemented by a class, hides scroll hint window if necessary.
		/// </summary>
		void HideScrollHint();
		/// <summary>
		/// When implemented by a class, returns number of characters painted with current font that will fit into control's client area.
		/// </summary>
		/// <returns>Number of characters that can fit in.</returns>
		int CharsInWidth();
		/// <summary>
		/// When implemented by a class, returns number of characters painted with current font that will fit into specified Width.
		/// </summary>
		/// <param name="width">Width to fit charachers.</param>
		/// <returns>Number of characters that can fit in.</returns>
		int CharsInWidth(int width);
		/// <summary>
		/// When implemented by a class, determines how many lines can fit into control's client area.
		/// </summary>
		/// <returns>Number of lines that can fit in.</returns>
		int LinesInHeight();
		/// <summary>
		/// When implemented by a class, determines how many lines can fit into given Height.
		/// </summary>
		/// <param name="height">Height to fit lines.</param>
		/// <returns>Number of lines that can fit in.</returns>
		int LinesInHeight(int height);
		/// <summary>
		/// When implemented by a class, fills hitTestInfo parameter by information about a part of the control at specified coordinate.
		/// </summary>
		/// <param name="position">Specifies coordinate to check.</param>
		/// <param name="hitTestInfo">Retrieves information about part of control.</param>
		void GetHitTest(Point position, ref HitTestInfo hitTestInfo);
		/// <summary>
		/// When implemented by a class, fills hitTestInfo parameter by information about a part of the control at specified coordinate.
		/// </summary>
		/// <param name="x">Specifies horizontal coordinate of position to check.</param>
		/// <param name="y">Specifies vertical coordinate of position to check.</param>
		/// <param name="hitTestInfo">Retrieves information about part of control.</param>
		void GetHitTest(int x, int y, ref HitTestInfo hitTestInfo);
		/// <summary>
		/// When implemented by a class, fills hitTestInfo parameter by information about a part of control at specified text coordinate.
		/// </summary>
		/// <param name="position">Specifies coordinate to check.</param>
		/// <param name="hitTestInfo">Retrieves information about part of control.</param>
		void GetHitTestAtTextPoint(Point position, ref HitTestInfo hitTestInfo);
		/// <summary>
		/// When implemented by a class, retrieves information about part of control at specified text coordinate.
		/// </summary>
		/// <param name="x">Specifies horizontal coordinate of text position to check.</param>
		/// <param name="y">Specifies vertical coordinate of text position to check.</param>
		/// <param name="hitTestInfo">Retrieves information about part of control.</param>
		void GetHitTestAtTextPoint(int x, int y, ref HitTestInfo hitTestInfo);
		/// <summary>
		/// When implemented by a class, returns word at the cursor position.
		/// </summary>
		/// <returns>Word at the cursor position.</returns>
		string GetTextAtCursor();
		/// <summary>
		/// When implemented by a class, initializes and runs a dialog prompting you for index of the line you need to locate.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult DisplayGotoLineDialog();
		/// <summary>
		/// When implemented by a class, initializes and runs a dialog box allowing you to search for some text.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult DisplaySearchDialog();
		/// <summary>
		/// When implemented by a class, initializes and runs a dialog box allowing you to search for text and replace it.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult DisplayReplaceDialog();
		/// <summary>
		/// When implemented by a class, initializes and runs a dialog box allowing you to change Edit control settings.
		/// </summary>
		/// <param name="hiddenTabs">specifies hidden tabs in the syntax settings dialog</param>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult DisplayEditorSettingsDialog(EditorSettingsTab hiddenTabs);
		/// <summary>
		/// When implemented by a class, initializes and runs a dialog box allowing you to change Edit control settings.
		/// </summary>
		/// <returns>DialogResult.OK if the user clicks OK in the dialog box; otherwise, DialogResult.Cancel.</returns>
		DialogResult DisplayEditorSettingsDialog();
		/// <summary>
		/// When implemented by a class, processes key press
		/// </summary>
		/// <param name="keyChar">Tepresents key character to process.</param>
		void ProcessKeyPress(char keyChar);
		/// <summary>
		/// When implemented by a class, resets the <c>AcceptTabs</c> to the default value.
		/// </summary>
		void ResetAcceptTabs();
		/// <summary>
		/// When implemented by a class, resets the <c>AcceptReturns</c> to the default value.
		/// </summary>
		void ResetAcceptReturns();
		/// <summary>
		/// When implemented by a class, resets the <c>BorderStyle</c> to the default value.
		/// </summary>
		void ResetBorderStyle();
		/// <summary>
		/// When implemented by a class, resets the <c>BorderColor</c> to the default value.
		/// </summary>
		void ResetBorderColor();
		/// <summary>
		/// When implemented by a class, resets the <c>SyntaxErrorsHints</c> to the default value.
		/// </summary>
		void ResetSyntaxErrorsHints();
		/// <summary>
		/// When implemented by a class, resets the <c>DrawColumnsIndent</c> to the default value.
		/// </summary>
		void ResetDrawColumnsIndent();
		/// <summary>
		/// When implemented by a class, resets the <c>ColumnsIndentForeColor</c> to the default value.
		/// </summary>
		void ResetColumnsIndentForeColor();
		/// <summary>
		/// When implemented by a class, gets or sets an object that implements <c>ITextSource</c> interface containing an actual string data displayed by the control.
		/// </summary>
		ITextSource Source
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents object that implements <c>ISyntaxStrings</c> interface containing collection of strings determining control's content.
		/// </summary>
		ISyntaxStrings Lines
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents the object that implements <c>IDisplayStrings</c> interface containing collection of lines to be drawn in the control.
		/// </summary>
		IDisplayStrings DisplayLines
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>ISelection</c> interface. This object represents various properties and methods to manipulate text selection, such as copy, paste and drag selected text.
		/// </summary>
		ISelection Selection
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents object that implements <c>IGutter</c> interface containing methods and properties necessary to operate with gutter at the left size of the control.
		/// </summary>
		IGutter Gutter
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>IMargin</c> interface and specifies appearance of vertical line drawn over the text and used to mark some limit, for example, of the maximum string length allowed.
		/// </summary>
		IMargin EditMargin
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>IPainter</c> interface used to draw control's text.
		/// </summary>
		IPainter Painter
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents object that implements <c>IKeyList</c> containing list of keys with attached actions, which executed by key pressure.
		/// </summary>
		IKeyList KeyList
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>ILineStylesEx</c> interface holding collection of <c>ILineStyle</c> objects each of them determines particular style of the line in the control.
		/// </summary>
		ILineStylesEx LineStyles
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>IPrinting</c> interface allowing to perform various printing actions such as print, preview document, and setup print options.
		/// </summary>
		IPrinting Printing
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>IWhiteSpace</c> interface. This object specifies appearance of white space characters, as well as End-of-line and End-of-file marks.
		/// </summary>
		IWhiteSpace WhiteSpace
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>ILineSeparator</c> interface containing methods and properties necessary to separate lines and highlight current line within the control.
		/// </summary>
		ILineSeparator LineSeparator
		{
			get;
			set;
		}
		/// <summary>
		/// When implementing by a class, represents an object that implements <c>IOutlining</c> interface that specifies appearance and behaviour of outline sections within the control.
		/// </summary>
		IOutlining Outlining
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>IBraceMatchingEx</c> interface allowing to change appearance of matching braces within the control.
		/// </summary>
		IBraceMatchingEx Braces
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents object that implements <c>IHyperTextEx</c> interface allowing to customize appearance and behaviour of hypertext sections within the control.
		/// </summary>
		IHyperTextEx HyperText
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents object that implements <c>ISpellingEx</c> interface containing properties and methods to check control's content spelling and highlight mispelled words.
		/// </summary>
		ISpellingEx Spelling
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>IScrolling</c> interface containing properties and methods that describe scrolling behaviour of the control.
		/// </summary>
		IScrolling Scrolling
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents an object that implements <c>IEditPage</c> interface containing properties and methods representing collection of particular pages.
		/// </summary>
		IEditPages Pages
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or set a boolean value that indicates whether TAB key should be accepted by Edit control as input key.
		/// </summary>
		bool AcceptTabs
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or set a boolean value that indicates whether Enter key should be accepted by Edit control as input key.
		/// </summary>
		bool AcceptReturns
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the border style for the Edit control.
		/// </summary>
		EditBorderStyle BorderStyle
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the border color for the Edit control.
		/// </summary>
		Color BorderColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets the rectangle that represents the client area of the Edit control.
		/// </summary>
		Rectangle ClientRect
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether Edit control should draw its background.
		/// </summary>
		bool Transparent 
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value that indicates whether Edit control should display hint over each syntax error in it's content.
		/// </summary>
		bool SyntaxErrorsHints
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, indicates whether edit control should use bultin popup menu.
		/// </summary>
		bool UseDefaultMenu
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, indicates whether edit control should draw columns indentation marks.
		/// </summary>
		bool DrawColumnsIndent
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, specifies columns indentation color.
		/// </summary>
		Color ColumnsIndentForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, occurs when text Source's state is changed, for example when caret position moved, text edited, amount of lines changed, lexer changed, etc.
		/// </summary>
		event NotifyEvent SourceStateChanged;
		/// <summary>
		/// When implemented by a class, occurs when modified state is changed.
		/// </summary>
		event EventHandler ModifiedChanged;
		/// <summary>
		/// When implemented by a class, occurs when Edit control should paint its background in transparent mode.
		/// </summary>
		event PaintEventHandler PaintBackground;
	}
	#endregion ISyntaxEdit
	
	#endregion
}

