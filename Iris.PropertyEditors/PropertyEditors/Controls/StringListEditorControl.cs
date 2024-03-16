using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Core.PropertyEditors.Controls;

namespace Iris.PropertyEditors.PropertyEditors.Controls
{
  public partial class StringListEditorControl : GenericListEditorControl<StringListItem>
  {
    public StringListEditorControl()
    {
      InitializeComponent();
    }

    public List<String> GetStringList()
    {
      List<string> stringList = new List<string>();
      for (int i = 0; i < List.Count; i++)
      {
        stringList.Add(List[i].Val);
      }
      return stringList;
    }

    public void SetStringList(List<String> stringList)
    {
      lbxItems.Items.Clear();      
      for (int i = 0; i < stringList.Count; i++)
      {
        lbxItems.Items.Add(new StringListItem(stringList[i]));
      }
    }
  }


  public class StringListItem
  {

    public StringListItem()
    {
    }

    public StringListItem(string _val)
    {
      val = _val;
    }

    private string val;
    [DisplayName("Valor")]
    public string Val
    {
      get { return val; }
      set { val = value; }
    }

    public override string ToString()
    {
      if (string.IsNullOrEmpty(val))
        return base.ToString();
      else
        return Val;
    }
  }
}
