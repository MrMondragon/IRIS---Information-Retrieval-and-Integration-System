using System;
using Iris.Interfaces;
using Iris.Designer.VisualObjects;
using System.Windows.Forms;
namespace Iris.Designer
{
  public interface IStructureDesigner: IProccessLog
  {
    void CreateListViewItem(string text, object tag, int imageIndex, ListView lvw, bool ensureVisible, bool updateGrid);
    string FileName { get; set; }
    IProccessLog Log { get; set; }
    IStructure Structure { get; }
    IVisualOperation[] GetSelectedOperations();
    IVisualOperation GetSelectedOperation();
    void AddToolBarButton(ToolStripButton button);
    void RemoveToolBarButton(ToolStripButton button);
  }
}
