using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Iris.Runtime.Model
{
  [Serializable]
  public abstract class TextObject 
  {
    private string description;
    [Category("Design"), DisplayName("Descrição")]
    public string Description
    {
      get { return description; }
      set { description = value; }
    }

    private string name;
    [Category("Design"), DisplayName("Nome")]
    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    private string validationXpression;

    public virtual string ValidationXpression
    {
      get { return validationXpression; }
      set { validationXpression = value; }
    }
  }
}
