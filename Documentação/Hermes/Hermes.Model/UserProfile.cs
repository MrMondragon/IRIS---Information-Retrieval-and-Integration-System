using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Model
{
  public class UserProfile
  {
    private List<BoardView> allowedViews;
    private List<String> userNames;

    public List<BoardView> AllowedViews
    {
      get { return allowedViews; }
      set { allowedViews = value; }
    }
  }
}
