
using System;
using Iris.Interfaces;

namespace Iris.Runtime.Model.BaseObjects
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      ExecutableStructure exS = new ExecutableStructure();
      exS.Execute();

    }

    class ExecutableStructure : BaseExecutableStructure
    {

      public override IIrisRunnable GetStructure()
      {
        return null;
      }
    }
  }
}