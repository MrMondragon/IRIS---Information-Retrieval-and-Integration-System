using System;
namespace Iris.Designer.VisualObjects
{
  public interface IVisualOperation
  {
    void ResetStatus();
    void SetEndPoint();
    void SetStartPoint();
    string ToString();
  }
}
