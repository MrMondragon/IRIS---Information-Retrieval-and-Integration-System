using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;


namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  public partial class DecodeEditorDialog : BaseDialog
  {
    public DecodeEditorDialog()
    {
      InitializeComponent();

      this.AcceptButton = null;

    }

    public void HideDefault()
    {
      groupBox1.Hide();
    }

    private void ParseText()
    {
      string txt = txtText.Text;

      if (!string.IsNullOrWhiteSpace(txt))
      {
        List<string> lines = txt.Split('\r').ToList();

        Dictionary<string, string> itens = new Dictionary<string, string>();
        foreach (string line in lines)
        {
          string[] lineParts = line.Split(',', ';');
          if (lineParts.Length == 2)
          {
            itens[lineParts[0].Trim()] = lineParts[1].Trim();
          }          
        }

        if (itens.Count > 0)
        {
          this.Items = itens;
        }
      }
    }

    private void ParseGrid()
    {
      StringBuilder builder = new StringBuilder();
      foreach (KeyValuePair<string,string> item in this.Items)
      {
        builder.AppendLine(string.Format("{0};{1}", item.Key, item.Value));
      }
      txtText.Text = builder.ToString();
           
    }

    public Dictionary<string, string> Items
    {
      set
      {
        dgItems.Rows.Clear();
        foreach (KeyValuePair<string, string> item in value)
        {
          dgItems.Rows.Add(item.Key, item.Value);
        }
      }
      get
      {
        if (tabControl1.SelectedTab == tabText)
          ParseText();

        Dictionary<string, string> items = new Dictionary<string, string>();
        for (int i = 0; i < dgItems.Rows.Count; i++)
        {
          string key = Convert.ToString(dgItems[0, i].Value);
          string value = Convert.ToString(dgItems[1, i].Value);
          if (!(string.IsNullOrEmpty(key) && string.IsNullOrEmpty(value)))
            items[key] = value;
        }
        return items;
      }
    }

    public string DefaultValue 
    {
      get
      {
        return textBox1.Text;
      }

      set
      {
        textBox1.Text = value;
      }
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (tabControl1.SelectedTab == tabText)
        ParseGrid();
      else
        ParseText();
    }

    


  }
}
