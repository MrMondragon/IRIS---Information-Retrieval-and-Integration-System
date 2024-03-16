using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Iris.Designer.VisualObjects;
using Iris.Interfaces;

namespace Iris.Designer.PluginSupport
{
  public abstract class BaseBehaviorPlugin
  {
    protected void CreateListViewItem(string text, object tag, int imageIndex, ListView lvw, bool ensureVisible, bool updateGrid)
    {
      designer.CreateListViewItem(text, tag, imageIndex, lvw, ensureVisible, updateGrid);
    }

    protected IVisualOperation GetSelectedOperation()
    {
      return Designer.GetSelectedOperation();
    }

    protected IVisualOperation[] GetSelectedOperations()
    {
      return Designer.GetSelectedOperations();
    }

    private IStructureDesigner designer;

    protected IStructureDesigner Designer
    {
      get { return designer; }
    }

    protected IStructure Structure
    {
      get { return Designer.Structure; }
    }

    /// <summary>
    /// Método de execução do plugin
    /// </summary>
    public abstract void DoExecute();

    public virtual void Load(IStructureDesigner _designer)
    {
      designer = _designer;
    }

  }
}
