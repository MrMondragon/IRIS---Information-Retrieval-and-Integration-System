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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Security;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

[assembly:CLSCompliant(true)]
[assembly:AllowPartiallyTrustedCallers]
[assembly:ComVisible(false)]

namespace QWhale.Common
{
	#region Enums
	/// <summary>
	/// Specifies the border style for Edit control.
	/// </summary>
	public enum EditBorderStyle
	{
		/// <summary>
		/// No border.
		/// </summary>
		None,
		/// <summary>
		/// A three-dimensional border.
		/// </summary>
		Fixed3D,
		/// <summary>
		/// A single-line border.
		/// </summary>
		FixedSingle,
		/// <summary>
		/// A system border.
		/// </summary>
		System
	}

	/// <summary>
	/// Defines types of reaction on error.
	/// </summary>
	public enum ErrorBehavior
	{
		/// <summary>
		/// Message dialog displayed when error occurs.
		/// </summary>
		Message,
		/// <summary>
		/// Exception is thrown when error occurs.
		/// </summary>
		Exception,
		/// <summary>
		/// No reaction.
		/// </summary>
		None
	}

	#endregion

	#region IControl
	/// <summary>
	/// Represents standart control properties and methods.
	/// </summary>
	public interface IControl
	{
		/// <summary>
		/// When implemented by a class, invalidates the entire client area of the control.
		/// </summary>
		void Invalidate();
		/// <summary>
		/// When implemented by a class, invalidates a specific region of the control.
		/// </summary>
		/// <param name="rect">A Rectangle object that represents the region to invalidate.</param>
		void Invalidate(Rectangle rect);
		/// <summary>
		/// When implemented by a class, causes the control to redraw the invalidated regions within its client area.
		/// </summary>
		void Update();
		/// <summary>
		/// When implemented by a class, computes the location of the specified screen point into client coordinates.
		/// </summary>
		/// <param name="p">The screen coordinate Point to convert.</param>
		/// <returns>A Point that represents the converted Point, in client coordinates.</returns>
		Point PointToClient(Point p);
		/// <summary>
		/// When implemented by a class, computes the location of the specified client point into screen coordinates.
		/// </summary>
		/// <param name="p">The client coordinate Point to convert.</param>
		/// <returns>A Point that represents the converted Point, in screen coordinates.</returns>
		Point PointToScreen(Point p);
		/// <summary>
		/// When implemented by a class, sets input focus to the control.
		/// </summary>
		/// <returns>true if the input focus request was successful; otherwise, false.</returns>
		bool Focus();
		/// <summary>
		/// When implemented by a class, returns boolean value indicating whether the control can receive input focus.
		/// </summary>
		bool CanFocus
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the control is displayed.
		/// </summary>
		bool Visible
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the coordinates of the upper-left corner of the control relative to the upper-left corner of its container.
		/// </summary>
		Point Location
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the distance, in pixels, between the left edge of the control and the left edge of its container's client area.
		/// </summary>
		int Left
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the distance, in pixels, between the bottom edge of the control and the top edge of its container's client area.
		/// </summary>
		int Top
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the width of the control.
		/// </summary>
		int Width
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the height of the control.
		/// </summary>
		int Height
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the size and location of the control including its nonclient elements.
		/// </summary>
		Rectangle Bounds
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets the rectangle that represents the client area of the control.
		/// </summary>
		Rectangle ClientRectangle
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the foreground color of the control.
		/// </summary>
		Color ForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the background color for the control.
		/// </summary>
		Color BackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the background image displayed in the control.
		/// </summary>
		Image BackgroundImage
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the font of the text displayed by the control.
		/// </summary>
		Font Font
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a reference to the server control's parent control in the page control hierarchy.
		/// </summary>
		Control Parent
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets a value indicating whether the control has input focus.
		/// </summary>
		bool Focused
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a value indicating whether the control can respond to user interaction.
		/// </summary>
		bool Enabled
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets the window handle that the control is bound to.
		/// </summary>
		IntPtr Handle
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets a value indicating whether the control has a handle associated with it.
		/// </summary>
		bool IsHandleCreated
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, occurs when the control is clicked.
		/// </summary>
		event EventHandler Click;
	}
	#endregion IControl

	#region IRange
	/// <summary>
	/// Represents an pair of two points that defines a scope in a two-dimensional plane.
	/// </summary>
	public interface IRange 
	{
		/// <summary>
		/// When implemented by a class, gets or sets begin of <c>IRange</c> area.
		/// </summary>
		Point StartPoint
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets end of <c>IRange</c> area.
		/// </summary>
		Point EndPoint
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets size of <c>IRange</c> area.
		/// </summary>
		Size Size
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets boolea value indicating whether <c>IRange</c> has zero size.
		/// </summary>
		bool IsEmpty
		{
			get;
		}
	}
	#endregion IRange

	#region IPainter
	/// <summary>
	/// Encapsulates a drawing surface, providing properties and methods used to draw text and graphic primitives.
	/// </summary>
	public interface IPainter
	{
		/// <summary>
		/// When implemented by a class, resets all <c>IPainter</c> properties to the initial state.
		/// </summary>
		void Clear();
		/// <summary>
		/// When implemented by a class, returns width of the given string.
		/// </summary>
		/// <param name="text">The text to calculate width.</param>
		/// <returns>Width of specified string.</returns>
		int StringWidth(string text);
		/// <summary>
		/// When implemented by a class, returns width of the specified part of the given string.
		/// </summary>
		/// <param name="text">The text to calculate width.</param>
		/// <param name="pos">Position of the first character to start calculating.</param>
		/// <param name="len">Length of the part of string to calculate width.</param>
		/// <returns>Width of the part of string.</returns>
		int StringWidth(string text, int pos, int len);
		
		/// <summary>
		/// When implemented by a class, returns width of the given string fitting into the given Width.
		/// </summary>
		/// <param name="text">The text to calculate width.</param>
		/// <param name="width">Maximum layout area for the string.</param>
		/// <param name="count">Receives number of character fitting into specified Width.</param>
		/// <param name="exact">Specifies whether the calculating should be precise.</param>
		/// <returns>Width of the part of string.</returns>
		int StringWidth(string text, int width, out int count, bool exact);
		/// <summary>
		/// When implemented by a class, returns width of the specified part of the given string fitting into the given Width.
		/// </summary>
		/// <param name="text">The text to calculate width.</param>
		/// <param name="pos">Position of the first character to start calculating.</param>
		/// <param name="len">Length of the part of string to calculate width.</param>
		/// <param name="width">Maximum layout area for the string.</param>
		/// <param name="count">Receives number of characters fitting into specified Width.</param>
		/// <returns>Width of the part of string.</returns>
		int StringWidth(string text, int pos, int len, int width, out int count);
		/// <summary>
		/// When implemented by a class, returns width of the specified part of the given string fitting into the given Width.
		/// </summary>
		/// <param name="text">The text to calculate width.</param>
		/// <param name="pos">Position of the first character to start calculating.</param>
		/// <param name="len">Length of the part of string to calculate width.</param>
		/// <param name="width">Maximum layout area for the string.</param>
		/// <param name="count">Receives number of characters fitting into the into the specified Width.</param>
		/// <param name="exact">Specifies whether the calculating should be precise.</param>
		/// <returns>Width of the part of string.</returns>
		int StringWidth(string text, int pos, int len, int width, out int count, bool exact);
		/// <summary>
		/// When implemented by a class, returns width of the given number of specified character.
		/// </summary>
		/// <param name="ch">Character to calculate width.</param>
		/// <param name="count">Number of characters.</param>
		/// <returns>Width of specified characters.</returns>
		int CharWidth(char ch, int count);
		/// <summary>
		/// When implemented by a class, returns width of the such number of the specified characters fitting into the given Width.
		/// </summary>
		/// <param name="ch">Character to calculate width.</param>
		/// <param name="width">The width that should hold a number of the specified character.</param>
		/// <param name="count">Receive number of character that can fit into specified width.</param>
		/// <returns>Width of specified characters.</returns>
		int CharWidth(char ch, int width, out int count);

		/// <summary>
		/// When implemented by a class, prepares the <c>IPainter</c> to paint. Associates new device context from given Graphics object to <c>IPainter</c> and preserves <c>IPainter</c> properties.
		/// <seealso cref="QWhale.Common.IPainter.EndPaint"/>
		/// </summary>
		/// <param name="graphics">The Graphics object to draw on.</param>
		void BeginPaint(Graphics graphics);
		/// <summary>
		/// When implemented by a class, marks the end of painting. Releases device context associated with this <c>IPainter</c> and restores saved <c>IPainter</c> properties.
		/// <seealso cref="QWhale.Common.IPainter.BeginPaint"/>
		/// </summary>
		void EndPaint();
		/// <summary>
		/// When implemented by a class, fills the given rectangle by using the current brush.
		/// </summary>
		/// <param name="rect">The rectangle object to fill.</param>
		void FillRectangle(Rectangle rect);
		/// <summary>
		/// When implemented by a class, fills the given rectangular area by using the current brush.
		/// </summary>
		/// <param name="x">X-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="y">Y-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="width">Width of the rectangle.</param>
		/// <param name="height">Height of the rectangle.</param>
		void FillRectangle(int x, int y, int width, int height);
		/// <summary>
		/// When implemented by a class, fills the given rectangle by using specified color.
		/// </summary>
		/// <param name="color">Specified color to fill rectangle.</param>
		/// <param name="rect">The rectangle object to fill.</param>
		void FillRectangle(Color color, Rectangle rect);
		/// <summary>
		/// When implemented by a class, fills the given rectangle by using specified color.
		/// </summary>
		/// <param name="color">Specified color to fill rectangle.</param>
		/// <param name="x">X-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="y">Y-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="width">Width of the rectangle.</param>
		/// <param name="height">Height of the rectangle.</param>
		void FillRectangle(Color color, int x, int y, int width, int height);
		/// <summary>
		/// When implemented by a class, fills the interior of a polygon defined by an array of points specified by Point structures.
		/// </summary>
		/// <param name="color">Specifies color to fill polygon.</param>
		/// <param name="points">Array of Point structures that represent the vertices of the polygon to fill.</param>
		void FillPolygon(Color color, Point[] points);

		/// <summary>
		/// When implemented by a class, fills the given rectangle with color that smoothly fades from one side to the other.
		/// </summary>
		/// <param name="rect">The rectangle object to fill.</param>
		/// <param name="beginColor">A Color structure that represents the starting color of the linear gradient.</param>
		/// <param name="endColor">A Color structure that represents the ending color of the linear gradient.</param>
		/// <param name="point1">A Point structure that represents the start point of the linear gradient.</param>
		/// <param name="point2">A Point structure that represents the end point of the linear gradient.</param>
		void FillGradient(Rectangle rect, Color beginColor, Color endColor, Point point1, Point point2);
		/// <summary>
		/// When implemented by a class, fills the given rectangle with color that smoothly fades from one side to the other.
		/// </summary>
		/// <param name="x">X-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="y">Y-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="width">Width of the rectangle.</param>
		/// <param name="height">Height of the rectangle.</param>
		/// <param name="beginColor">A Color structure that represents the starting color of the linear gradient.</param>
		/// <param name="endColor">A Color structure that represents the ending color of the linear gradient.</param>
		/// <param name="point1">A Point structure that represents the start point of the linear gradient.</param>
		/// <param name="point2">A Point structure that represents the end point of the linear gradient.</param>
		void FillGradient(int x, int y, int width, int height, Color beginColor, Color endColor,  Point point1, Point point2);
		
		/// <summary>
		/// When implemented by a class, draws the background image defined by the visual style for the specified control part.
		/// </summary>
		/// <param name="handle">Handle to a window's specified theme data.</param>
		/// <param name="partID">Specifies the part to draw.</param>
		/// <param name="stateID">Specifies the state of the part to draw.</param>
		/// <param name="rect">Specifies the rectangle, in logical coordinates, in which the background image is drawn.</param>
		void DrawThemeBackground(IntPtr handle, int partID, int stateID, Rectangle rect);
		
		/// <summary>
		/// When implemented by a class, draws a border around the specified rectangle using current <c>BackColor</c>.
		/// </summary>
		/// <param name="rect">The rectangle object to draw border.</param>
		void DrawRectangle(Rectangle rect);
		/// <summary>
		/// When implemented by a class, draws a border around the specified rectangle using using dot pattern.
		/// </summary>
		/// <param name="x">X-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="y">Y-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="width">Width of the rectangle.</param>
		/// <param name="height">Height of the rectangle.</param>
		/// <param name="color">Color of the frame.</param>
		void DrawFocusRect(int x, int y, int width, int height, Color color);
		/// <summary>
		/// When implemented by a class, draws a border around the specified rectangle using current <c>BackColor</c>.
		/// </summary>
		/// <param name="rect">The rectangle object to draw border.</param>
		/// <param name="color">Color of the frame.</param>
		void DrawFocusRect(Rectangle rect, Color color);
		/// <summary>
		/// When implemented by a class, draws a border around the specified rectangle using dot pattern.
		/// </summary>
		/// <param name="x">X-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="y">Y-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="width">Width of the rectangle.</param>
		/// <param name="height">Height of the rectangle.</param>
		void DrawRectangle(int x, int y, int width, int height);
		/// <summary>
		/// When implemented by a class, draws a rectangle with rounded corners. The rectangle is outlined by using the current pen and filled by using the current brush.
		/// </summary>
		/// <param name="left">Specifies the x-coordinate, in logical coordinates, of the upper-left corner of the rectangle.</param>
		/// <param name="top">Specifies the y-coordinate, in logical coordinates, of the upper-left corner of the rectangle.</param>
		/// <param name="right">Specifies the x-coordinate, in logical coordinates, of the lower-right corner of the rectangle.</param>
		/// <param name="bottom">Specifies the y-coordinate, in logical coordinates, of the lower-right corner of the rectangle.</param>
		/// <param name="width">Specifies the width, in logical coordinates, of the ellipse used to draw the rounded corners.</param>
		/// <param name="height">Specifies the height, in logical coordinates, of the ellipse used to draw the rounded corners.</param>
		void DrawRoundRectangle(int left, int top, int right, int bottom, int width, int height);
		/// <summary>
		/// When implemented by a class, draws a line from the given start position up to, but not including, the specified end point.
		/// </summary>
		/// <param name="x1">X-coordinate of the line's start point.</param>
		/// <param name="y1">Y-coordinate of the line's start point.</param>
		/// <param name="x2">X-coordinate of the line's ending point.</param>
		/// <param name="y2">Y-coordinate of the line's ending point.</param>
		void DrawLine(int x1, int y1, int x2, int y2);
		/// <summary>
		/// When implemented by a class, draws a line from the given start position up to, but not including, the specified end point.
		/// </summary>
		/// <param name="x1">X-coordinate of the line's start point.</param>
		/// <param name="y1">Y-coordinate of the line's start point.</param>
		/// <param name="x2">X-coordinate of the line's ending point.</param>
		/// <param name="y2">Y-coordinate of the line's ending point.</param>
		/// <param name="color">Specifies color of the Pen object to draw line.</param>
		/// <param name="width">Specifies width of the Pen object to draw line.</param>
		/// <param name="penStyle">Specifies style of the Pen object to draw line.</param>
		void DrawLine(int x1, int y1, int x2, int y2, Color color, int width, DashStyle penStyle);
		/// <summary>
		/// When implemented by a class, draws a dotted line from the given start position up to the specified end point.
		/// </summary>
		/// <param name="x1">X-coordinate of the line's start point.</param>
		/// <param name="y1">Y-coordinate of the line's start point.</param>
		/// <param name="x2">X-coordinate of the line's ending point.</param>
		/// <param name="y2">Y-coordinate of the line's ending point.</param>
		/// <param name="color">Specifies line color.</param>
		void DrawDotLine(int x1, int y1, int x2, int y2, Color color);
		/// <summary>
		/// When implemented by a class, draws waved line in the specified rectangular area.
		/// </summary>
		/// <param name="rect">Rectangle that bounds the drawing area for the wave.</param>
		/// <param name="color">Color used to draw wave.</param>
		void DrawWave(Rectangle rect, Color color);
		/// <summary>
		/// When implemented by a class, draws specified image in the specified rectangular area.
		/// </summary>
		/// <param name="images">Image list that contains image to draw.</param>
		/// <param name="index">Index of image to draw within image list.</param>
		/// <param name="rect">Rectangle that bounds the drawing area for the image.</param>
		void DrawImage(ImageList images, int index, Rectangle rect);
		/// <summary>
		/// When implemented by a class, draws specified image in the specified rectangular area.
		/// </summary>
		/// <param name="images">Image list that contains image to draw.</param>
		/// <param name="index">Index of image to draw within image list.</param>
		/// <param name="rect">Rectangle that bounds the drawing area for the image.</param>
		/// <param name="srcX">X-coordinate of the upper-left corner of the portion of the source image to be drawn.</param>
		/// <param name="srcY">Y-coordinate of the upper-left corner of the portion of the source image to be drawn.</param>
		/// <param name="srcWidth">Width of the portion of the source image to be drawn.</param>
		/// <param name="srcHeight">Width of the portion of the source image to be drawn.</param>
		/// <param name="srcUnit">Specifies the unit of measure for the image.</param>
		/// <param name="imageAttr">Specifies the color and size attributes of the image to be drawn.</param>
		void DrawImage(ImageList images, int index, Rectangle rect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit, ImageAttributes imageAttr);
		/// <summary>
		/// When implemented by a class, draws stretched image in the specified rectangular area.
		/// </summary>
		/// <param name="image">Specifies image to draw.</param>
		void StretchDrawImage(Rectangle rect, Rectangle stretchRect, Rectangle imageRect, Bitmap image);
		/// <summary>
		/// When implemented by a class, draws one or more edges of rectangle.
		/// </summary>
		/// <param name="rect">Specifies rectangle which edges should be drawn.</param>
		/// <param name="border">Specifies the style of a three-dimensional border.</param>
		/// <param name="sides">Specifies the sides of a rectangle to draw.</param>
		void DrawEdge(ref Rectangle rect, Border3DStyle border, Border3DSide sides);
		/// <summary>
		/// When implemented by a class, draws one or more edges of rectangle.
		/// </summary>
		/// <param name="rect">Specifies rectangle which edges should be drawn.</param>
		/// <param name="border">Specifies the style of a three-dimensional border.</param>
		/// <param name="sides">Specifies the sides of a rectangle to draw.</param>
		/// <param name="flags">additional flags (used for internal purposes).</param>
		void DrawEdge(ref Rectangle rect, Border3DStyle border, Border3DSide sides, int flags);
		/// <summary>
		/// When implemented by a class, draws a ploygon defined by an array of Point structures.
		/// </summary>
		/// <param name="points">Array of Point structures that represent the vertices of the polygon.</param>
		/// <param name="color">Specifies color of the polygon.</param>
		void DrawPolygon(Point[] points, Color color);

		/// <summary>
		/// When implemented by a class, draws text in the specified location.
		/// </summary>
		/// <param name="text">The text to be drawn.</param>
		/// <param name="len">Specifies the length of the string.</param>
		/// <param name="x">X-coordinate of the start text point.</param>
		/// <param name="y">Y-coordinate of the start text point.</param>
		void TextOut(string text, int len, int x, int y);
		/// <summary>
		/// When implemented by a class, draws text in the specified location.
		/// </summary>
		/// <param name="text">The text to be drawn.</param>
		/// <param name="len">Specifies the length of the string.</param>
		/// <param name="x">X-coordinate of the start text point.</param>
		/// <param name="y">Y-coordinate of the start text point.</param>
		/// <param name="clipped">Specifies that text will be clipped to the rectangle.</param>
		/// <param name="opaque">Specifies that current background color should be used to fill the rectangle.</param>
		void TextOut(string text, int len, int x, int y, bool clipped, bool opaque);
		/// <summary>
		/// When implemented by a class, draws text within the specified rectangle.
		/// </summary>
		/// <param name="text">The text to be drawn.</param>
		/// <param name="len">Specifies the length of the string.</param>
		/// <param name="rect">Specifies the dimensions, in logical coordinates, of a rectangle that is used for clipping, opaquing, or both.</param>
		void TextOut(string text, int len, Rectangle rect);
		/// <summary>
		/// When implemented by a class, draws text within the specified rectangle.
		/// </summary>
		/// <param name="text">The text to be drawn.</param>
		/// <param name="len">Specifies the length of the string.</param>
		/// <param name="rect">Specifies the dimensions, in logical coordinates, of a rectangle that is used for clipping, opaquing, or both.</param>
		/// <param name="clipped">Specifies that text will be clipped to the rectangle.</param>
		/// <param name="opaque">Specifies that current background color should be used to fill the rectangle.</param>
		void TextOut(string text, int len, Rectangle rect, bool clipped, bool opaque);
		/// <summary>
		/// When implemented by a class, draws text within the specified rectangle.
		/// </summary>
		/// <param name="text">The text to be drawn.</param>
		/// <param name="len">Specifies the length of the string.</param>
		/// <param name="rect">Specifies the dimensions, in logical coordinates, of a rectangle that is used for clipping, opaquing, or both.</param>
		/// <param name="x">X-coordinate of the start text point.</param>
		/// <param name="y">Y-coordinate of the start text point.</param>
		/// <param name="clipped">Specifies that text will be clipped to the rectangle.</param>
		/// <param name="opaque">Specifies that current background color should be used to fill the rectangle.</param>
		void TextOut(string text, int len, Rectangle rect, int x, int y, bool clipped, bool opaque);
		/// <summary>
		/// When implemented by a class, draws text within the specified rectangle.
		/// </summary>
		/// <param name="text">The text to be drawn.</param>
		/// <param name="len">Specifies the length of the string.</param>
		/// <param name="rect">Specifies the dimensions, in logical coordinates, of a rectangle that is used for clipping, opaquing, or both.</param>
		/// <param name="x">X-coordinate of the start text point.</param>
		/// <param name="y">Y-coordinate of the start text point.</param>
		/// <param name="clipped">Specifies that text will be clipped to the rectangle.</param>
		/// <param name="opaque">Specifies that current background color should be used to fill the rectangle.</param>
		/// <param name="space">Specifies distance between origins of adjacent character cells.</param>
		void TextOut(string text, int len, Rectangle rect, int x, int y, bool clipped, bool opaque, int space);

		/// <summary>
		/// When implemented by a class, draws text in the specified rectangle using current values of <c>TextColor</c> and <c>BackColor</c>.
		/// </summary>
		/// <param name="text">The text to be draw.</param>
		/// <param name="len">Specifies the length of the string.</param>
		/// <param name="rect">The layout area for drawing text.</param>
		void DrawText(string text, int len, Rectangle rect);

		/// <summary>
		/// When implemented by a class, sets a two-dimensional linear transformation for the specified device context.
		/// </summary>
		/// <param name="x">Horizontal offset of the transformation.</param>
		/// <param name="y">Vertical offset of the transformation.</param>
		/// <param name="scaleX">Horizontal scale of the transformation.</param>
		/// <param name="scaleY">Vertical scale of the transformation.</param>
		void Transform(int x, int y, float scaleX, float scaleY);
		/// <summary>
		/// When implemented by a class, sets default two-dimensional linear transformation for the specified device context.
		/// </summary>
		void EndTransform();

		/// <summary>
		/// When implemented by a class, creates a new clipping region from the intersection of the current clipping region and the specified rectangle.
		/// </summary>
		/// <param name="x">X-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="y">Y-coordinate of the upper-left corner of the rectangle.</param>
		/// <param name="width">Width of the rectangle.</param>
		/// <param name="height">Height of the rectangle.</param>
		void IntersectClipRect(int x, int y, int width, int height);
		/// <summary>
		/// When implemented by a class, creates a new clipping region that consists of the existing clipping region minus the specified rectangle.
		/// </summary>
		/// <param name="x">X-coordinate, of the upper-left corner of the rectangle.</param>
		/// <param name="y">Y-coordinate, of the upper-left corner of the rectangle.</param>
		/// <param name="width">Width of the rectangle.</param>
		/// <param name="height">Height of the rectangle.</param>
		void ExcludeClipRect(int x, int y, int width, int height);
		/// <summary>
		/// When implemented by a class, creates a new clipping region from the intersection of the current clipping region and the specified rectangle.
		/// </summary>
		/// <param name="rect">Rectangle to intersect.</param>
		void IntersectClipRect(Rectangle rect);
		/// <summary>
		/// When implemented by a class, creates a new clipping region that consists of the existing clipping region minus the specified rectangle.
		/// </summary>
		/// <param name="rect">Rectangle to exclude.</param>
		void ExcludeClipRect(Rectangle rect);

		/// <summary>
		/// When implemented by a class, retrieves handle to clipping region saved from specified rectangle.
		/// </summary>
		/// <param name="rect">Rectangle to process.</param>
		/// <returns>Handle to clipping region.</returns>
		IntPtr SaveClip(Rectangle rect);
		/// <summary>
		/// When implemented by a class, restores current clipping region from previously saved region.
		/// </summary>
		/// <param name="rgn">Specifies handle to the previously saved clipping region.</param>
		void RestoreClip(IntPtr rgn);
		/// <summary>
		/// When implemented by a class gets the world transformation for <c>Graphics</c> property.
		/// </summary>
		Matrix Transformation
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents Graphics object used to paint.
		/// </summary>
		Graphics Graphics
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, gets or sets font of the device context currently associated with the <c>IPainter</c>.
		/// </summary>
		Font Font
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets font style of the device context currently associated with the <c>IPainter</c>.
		/// </summary>
		FontStyle FontStyle
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets background color of the device context currently associated with the <c>IPainter</c>.
		/// </summary>
		Color BackColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets foreground color of the device context currently associated with the <c>IPainter</c>.
		/// </summary>
		Color ForeColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets text color of the device context currently associated with the <c>IPainter</c>.
		/// </summary>
		Color TextColor
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, encapsulates text layout information and display manipulations for this <c>IPainter</c>.
		/// </summary>
		StringFormat StringFormat
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets a boolean value indicating that background is filled with the current background color before the text is drawn.
		/// </summary>
		bool Opaque
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, represents a value indicating whether font of the device context currently associated with this <c>IPainter</c> is monospaced, meaning that all characters drawn with this font have the same width.
		/// </summary>
		bool IsMonoSpaced
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents width of the font of the device context currently associated with the <c>IPainter</c>.
		/// </summary>
		int FontWidth
		{
			get;
		}
		/// <summary>
		/// When implemented by a class, represents height of the font of the device context currently associated with the <c>IPainter</c>.
		/// </summary>
		int FontHeight
		{
			get;
		}
	}
	#endregion IPainter
}
