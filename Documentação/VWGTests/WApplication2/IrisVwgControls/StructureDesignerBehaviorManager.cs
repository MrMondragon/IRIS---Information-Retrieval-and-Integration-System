using System;
using System.Collections.Generic;
using System.Text;

namespace IrisVwgControls.FlowChartControl
{
  public class StructureDesignerBehaviorManager: BaseBehaviorManager
  {
    protected override string doArrowClicked(string arrow, string origin, int origIdx, string destination, int destIdx)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doArrowCreated(string arrow, string origin, int origIdx, string destination, int destIdx)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doArrowCreating(string arrow, string origin, int origIdx, string destination, int destIdx)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doArrowDblClicked(string arrow, string origin, int origIdx, string destination, int destIdx)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doArrowDeleted(string arrow, string origin, int origIdx, string destination, int destIdx)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doArrowDeleting(string arrow, string origin, int origIdx, string destination, int destIdx)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doDocClicked(int x, int y)
    {
      return "alert('docClicked');";
    }

    protected override string doDocDblClicked(int x, int y)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doTableClicked(string table)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doTableCreated(string table)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doTableCreating(string table)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doTableDblClicked(string table)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doTableDeleted(string table)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doTableDeleting(string table)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doTableSelected(string table)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    protected override string doTableDeselected(string table)
    {
      throw new Exception("The method or operation is not implemented.");
    }
  }
}
