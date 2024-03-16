using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Hermes.Model
{
  public class DashBoard
  {
    private string id;

    public string Id
    {
      get { return id; }
      set { id = value; }
    }
    private List<BoardView> views;

    public List<BoardView> Views
    {
      get { return views; }
      set { views = value; }
    }

    private BoardView mainView;

    public BoardView MainView
    {
      get { return mainView; }
      set { mainView = value; }
    }

    private Dictionary<string, string> assemblies;
    public Dictionary<string, string> Assemblies
    {
      get { return assemblies; }
      set { assemblies = value; }
    }
  }
}
