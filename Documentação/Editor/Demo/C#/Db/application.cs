using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DbTest
{
	/// <summary>
	/// Summary description for Application.
	/// </summary>
	public class Application
	{	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Form1 frm = new Form1();

			System.Windows.Forms.Application.Run(frm);
		}
	}
}
