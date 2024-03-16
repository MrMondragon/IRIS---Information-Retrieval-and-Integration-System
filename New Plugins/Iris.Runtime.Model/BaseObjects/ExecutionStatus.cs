
using System;
namespace Iris.Runtime.Model.BaseObjects
{
  [Serializable]
  public enum ExecutionStatus
  {
    WaitingExecution,
    PreparingInputs,
    Running,
    Success,
    Failure,
    Entity,
  }
}
