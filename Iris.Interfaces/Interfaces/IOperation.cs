using System;
using Iris.Interfaces;
namespace Iris.Interfaces
{
  public interface IOperation
  {
    string Description { get; set; }
    string DisplayText { get; set; }
    void Execute();
    bool IgnoreFailure { get; set; }
    string Name { get; set; }
    IOperation OnFailure { get; set; }
    IOperation OnSuccess { get; set; }
    IEntity Result { get; set; }
    IStructure Structure { get; set; }
    string ToString();
    object Value { get; }
    IEntity EntityValue { get; }
    bool ExternalParam { get; set; }

    bool LargeObject { get;  }

    string Notes { get; set; }

    event EventHandler AfterNameChange;

    event EventHandler BeforeNameChange;

    OperationType OperationType { get; }

  }
}
