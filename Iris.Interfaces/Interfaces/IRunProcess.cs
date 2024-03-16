using System;
using System.Diagnostics;
namespace Iris.ControlOperations.ProcessOperations
{
  public interface IRunProcess
  {
    string Arguments { get; set; }
    string ProcName { get; set; }
    string ProcVerb { get; set; }
    ProcessStartInfo ProcInfo { get; }
    ProcessWindowStyle WindowStyle { get; set; }
  }
}
