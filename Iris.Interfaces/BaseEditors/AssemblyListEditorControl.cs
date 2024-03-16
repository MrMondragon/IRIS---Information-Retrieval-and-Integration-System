using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Reflection;

namespace Iris.PropertyEditors.Controls
{
  public partial class AssemblyListEditorControl : BaseControl
  {
    public AssemblyListEditorControl()
    {
      InitializeComponent();
      assemblies = new List<AssemblyItem>();
    }

    public void SetAssemblies(Dictionary<string, string> _assmblies)
    {
      lbxAssemblies.Items.Clear();
      foreach (KeyValuePair<string, string> kvp in _assmblies)
      {
        lbxAssemblies.Items.Add(new AssemblyItem(kvp.Value));
      }
    }

    public Dictionary<string, string> GetAssemblies()
    {
      Dictionary<string, string> list = new Dictionary<string, string>();
      foreach (object item in lbxAssemblies.Items)
      {
        AssemblyItem assemblyItem = (AssemblyItem)item;
        list[assemblyItem.Name] = assemblyItem.Path;        
      }
      return list;
    }

    private List<AssemblyItem> assemblies;

    class AssemblyItem
    {
      public AssemblyItem(string _path)
      {
        Path = _path;
      }

      public override string ToString()
      {
        return Name;
      }

      [DisplayName("Assembly")]
      public string Name
      {
        get 
        {
          if (string.IsNullOrEmpty(Path))
            return "(Nova)";
          else
          {
            try
            {
              Assembly assembly = Assembly.LoadFile(Path);
              return Convert.ToString(assembly.ManifestModule);
            }
            catch
            {
              return "(Assembly não encontrado: " + Path+")";
            }
          }
        }        
      }

      private string path;
      [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
      public string Path
      {
        get { return path; }
        set { path = value; }
      }

    }

    private void btnNew_Click(object sender, EventArgs e)
    {
      lbxAssemblies.Items.Add(new AssemblyItem(""));
      lbxAssemblies.SelectedIndex = lbxAssemblies.Items.Count - 1;
      OnPropertyChanged();
    }

    private void lbxAssemblies_SelectedIndexChanged(object sender, EventArgs e)
    {
      propertyGrid1.SelectedObject = lbxAssemblies.SelectedItem;
    }

    private void propertyGrid1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
    {
      int idx = lbxAssemblies.SelectedIndex;
      List<AssemblyItem> list = new List<AssemblyItem>();

      while (lbxAssemblies.Items.Count > 0)
      {
        list.Add((AssemblyItem)lbxAssemblies.Items[0]);
        lbxAssemblies.Items.RemoveAt(0);
      }
      for (int i = 0; i < list.Count; i++)
      {
        lbxAssemblies.Items.Add(list[i]);
      }
      lbxAssemblies.SelectedIndex = idx;
      OnPropertyChanged();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if(lbxAssemblies.SelectedIndex != -1)
        lbxAssemblies.Items.RemoveAt(lbxAssemblies.SelectedIndex);
      else
        lbxAssemblies.Items.RemoveAt(0);
      propertyGrid1.SelectedObject = null;
      OnPropertyChanged();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lbxAssemblies.Items.Clear();
      propertyGrid1.SelectedObject = null;
      OnPropertyChanged();
    }
    
  }
}

