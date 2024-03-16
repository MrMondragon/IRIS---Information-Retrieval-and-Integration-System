using Iris.Designer.VisualObjects;
using MindFusion.Diagramming.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Designer.DesignerActions
{
  public static class LayoutManager
  {
    public static void DoLayout(FlowChart surface)
    {
      List<VisualOperation> selection = surface.Selection.Tables.Cast<VisualOperation>().ToList();
      selection.Sort();

      //para cada item tirado da fila:
        //Se o item pertence à linha atual
          //Seta top para a linha 
          //Se tiver inputs
            //Coloca os inputs em coluna, na ordem
            
          //Seta left para ultimoItem.right + gap

    }

  }
}
