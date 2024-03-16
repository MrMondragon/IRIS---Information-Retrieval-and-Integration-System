using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Model
{
  public class BoardView
  {
    private List<ControlProperties> items;
    public List<ControlProperties> Items
    {
      get { return items; }
      set { items = value; }
    }
    private int gridSize;
    private BoardView origView;

    public BoardView OrigView
    {
      get { return origView; }
      set { origView = value; }
    }

    public void DrillUp()
    {
      throw new System.NotImplementedException();
    }

    public string Id
    {
      get { return id; }
      set { id = value; }
    }

    private string id;
  }
}
