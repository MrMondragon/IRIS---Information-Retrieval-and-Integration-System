using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Core.PropertyEditors.Controls;

namespace Iris.PropertyEditors.PropertyEditors.Controls
{
  public class ChoiceEditorControl : GenericListEditorControl<ChoiceItem>
  {
    internal void SetList(Dictionary<string, string> dictionary)
    {
      List<ChoiceItem> list = new List<ChoiceItem>();
      foreach (KeyValuePair<string,string> kvp in dictionary)
      {
        ChoiceItem item = new ChoiceItem();
        item.Name = kvp.Key;
        item.Expression = kvp.Value;
        list.Add(item);
      }
      List = list;
    }

    internal Dictionary<string, string> GetDictionary()
    {
      Dictionary<string, string> dic = new Dictionary<string, string>();
      for (int i = 0; i < List.Count; i++)
      {
        dic[List[i].Name] = List[i].Expression;
      }
      return dic;
    }

  }

  [Serializable]
  public class ChoiceItem
  {
    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }
    private string expression;

    public string Expression
    {
      get { return expression; }
      set { expression = value; }
    }

    public override string ToString()
    {
      if (!string.IsNullOrEmpty(Name))
        return Name;
      else
        return "<Indefinido>";
    }
  }

}
