using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using MindFusion.Diagramming.WinForms;
using Iris.Runtime.Model.Operations.SchemaOperations;
using Iris.Interfaces;
using System.Windows.Forms;

namespace Iris.Designer.VisualObjects
{
  [Serializable]
  public class VisualLink
  {

    public VisualLink(Arrow _arrow)
    {
      VisualOperation tabOrigem = (VisualOperation)_arrow.Origin;
      VisualOperation tabDestino = (VisualOperation)_arrow.Destination;
      objOrigem = tabOrigem.Operation;
      objDestino = tabDestino.Operation;

      arrow = _arrow;

      destIdx = _arrow.DestIndex;
      origIdx = _arrow.OrgnIndex;
      origPlug = (PlugType)tabOrigem[3, _arrow.OrgnIndex].Tag;
      destPlug = (PlugType)tabDestino[0, _arrow.DestIndex].Tag;

      FeedInput(objOrigem);
      if (!FeedOutput(objDestino))
      {
        arrow.Parent.DeleteObject(arrow);
        MessageBox.Show("Links de sucesso e falha só podem ser ligados a Operações");
      }

      if(!(objOrigem is IEntity))
        RemovePrevious();
      arrow = null;


    }

    internal int destIdx;
    internal int origIdx;
    private PlugType origPlug;
    private PlugType destPlug;
    internal IOperation objOrigem;
    internal IOperation objDestino;

    [NonSerialized]
    private Arrow arrow;


    internal virtual void FeedInput(IOperation obj)
    {
      try
      {
        if (destIdx != 0)
          ((Operation)objDestino).SetInput(destIdx - 1, obj);
      }
      catch(Exception e)
      {
        arrow.Parent.DeleteObject(arrow);
        MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      
    }

    internal virtual bool FeedOutput(IOperation obj)
    {
      try
      {
        switch (origPlug)
        {
          case PlugType.Success:
            if ((obj == null) || (destPlug == PlugType.Start))
            {
              if ((objOrigem is Operation) && ((obj == null) || (obj is Operation)))
                objOrigem.OnSuccess = obj;
              else
                return false;
            }
            else
              return false;
            break;
          case PlugType.Failure:
            if ((obj == null) || (destPlug == PlugType.Start))
            {
              if (obj is Operation)
                objOrigem.OnFailure = obj;
              else
                return false;
            }
            else
              return false;
            break;
          case PlugType.Output:
            {
              int idx = origIdx - 2;
              if (!(objOrigem is IEntity))
                ((Operation)objOrigem).SetOutput(idx, obj);
            }
            break;
        }
        return true;
      }
      catch (Exception e)
      {
        arrow.Parent.DeleteObject(arrow);
        MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
    }

    private void RemovePrevious()
    {
      List<Arrow> list = new List<Arrow>();
      foreach (Arrow testArrow in arrow.Parent.Arrows)
      {
        //Mesma origem
        bool deleteCondition = (testArrow.Origin == arrow.Origin) && (testArrow.OrgnIndex == arrow.OrgnIndex);
        //Arrow diferente 
        deleteCondition &= (testArrow != arrow);
        //Output ou Sucesso/Falha ligado em Start
        deleteCondition &= (origPlug == PlugType.Output) || (((origPlug == PlugType.Failure) || (origPlug == PlugType.Success))
                                            && ((destPlug == PlugType.Start) && (testArrow.DestIndex == arrow.DestIndex)));
        if (deleteCondition)
          list.Add(testArrow);
      }

      foreach (Arrow testArrow in list)
      {
        arrow.Parent.DeleteObject(testArrow);
      }
    }

    public void Delete()
    {
      FeedInput(null);
      FeedOutput(null);
    }



    public static bool ValidateLink(Arrow arrow)
    {

      return true;
    }
  }
}
