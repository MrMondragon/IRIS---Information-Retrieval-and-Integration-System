using System;
namespace Iris.Runtime.Model.ClientObjects
{
  public interface ILogItem
  {
    bool Error { get; set; }
    string Text { get; }
    DateTime Time { get; }
    object[] GetItemArray();
  }
}
