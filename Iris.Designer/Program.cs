using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Databridge.Engine.Criptography;

namespace Iris.Designer
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      if (Login.TestPWD())
      {
        try
        {
          Application.Run(new StructureDesigner());
        }
        catch (Exception e)
        {
          string st = e.Message;
          while (e != null)
          {
            e = e.InnerException;
            if (e != null)
              st += Environment.NewLine + Environment.NewLine + e.Message;

          }
          MessageBox.Show(st);

        }

      }
      else
      {
        Application.Exit();
      }
    }
  }
}