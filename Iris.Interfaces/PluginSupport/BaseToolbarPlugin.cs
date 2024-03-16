using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Iris.Designer.VisualObjects;

namespace Iris.Designer.PluginSupport
{
  public abstract class BaseToolbarPlugin : BaseBehaviorPlugin
  {
    /// <summary>
    /// Retorna o texto de hint do botão
    /// </summary>
    /// <returns></returns>
    protected abstract string GetHint();

    /// <summary>
    /// Retorna o ícone do botão
    /// </summary>
    /// <returns></returns>
    protected abstract Image GetImage();


    protected virtual bool isHotKey(KeyEventArgs e)
    {
      return false;
    }

    internal void Unload()
    {
      Designer.RemoveToolBarButton(button);
    }

    private void Click(object sender, EventArgs e)
    {
      DoExecute();
    }

    public void TestKey(KeyEventArgs e)
    {
      if (isHotKey(e))
        DoExecute();
    }


    private ToolStripButton button;

    public override void Load(IStructureDesigner _designer)
    {
      button = new ToolStripButton(GetHint(), GetImage(), Click);
      button.DisplayStyle = ToolStripItemDisplayStyle.Image;
      _designer.AddToolBarButton(button);
      base.Load(_designer);
    }

  }
}
