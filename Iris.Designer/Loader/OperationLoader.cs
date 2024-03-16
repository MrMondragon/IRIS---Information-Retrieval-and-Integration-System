using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using System.Windows.Forms;
using System.Drawing;
using Iris.Designer.Properties;
using Iris.Interfaces;

namespace Iris.Designer.Loader
{
  public class OperationLoader
  {
    public OperationLoader(List<Assembly> assemblies)
    {
      derived = new List<Type>();
      typeLookupTable = new Dictionary<string, string>();

      foreach (Assembly assembly in assemblies)
        SetupDerivedTypes(assembly);

      SetupCategories();
    }
    public void SetupComboBox(ComboBox comboBox)
    {
      comboBox.Items.Clear();
      categories.Sort();
      foreach (Category cat in categories)
      {
        comboBox.Items.Add(cat);
      }
    }

    private Dictionary<string, string> typeLookupTable;

    public Dictionary<string, string> TypeLookupTable
    {
      get { return typeLookupTable; }
    }

    public void SetupToolBar(ToolStrip toolBar, Category category, EventHandler clickHandler)
    {
      toolBar.Items.Clear();
      category.Types.Sort(new CompTypes());
      for (int i = category.Types.Count - 1; i >= 0; i--)
      {
        Type t = category.Types[i];

        OperationCategory oc = GetAttribute(t);
        ToolStripButton tsb = new ToolStripButton(oc.Name);
        tsb.ImageAlign = ContentAlignment.MiddleLeft;
        tsb.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
        tsb.CheckOnClick = true;
        tsb.ImageTransparentColor = Color.Magenta;
        tsb.Tag = t;
        tsb.Image = (Bitmap)Resources.ResourceManager.GetObject(t.Name);
        if (tsb.Image == null)
        {
          MethodInfo getIcon = t.GetMethod("GetIcon", BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.Public);
          if (getIcon != null)
          {
            tsb.Image = (Bitmap)getIcon.Invoke(null, null);
          }
        }
        tsb.Click += clickHandler;
        toolBar.Items.Add(tsb);
      }
    }

    internal static OperationCategory GetAttribute(Type type)
    {
      OperationCategory oc = null;
      Attribute[] attrs = System.Attribute.GetCustomAttributes(type);
      for (int i = 0; i < attrs.Length; i++)
      {
        if (attrs[i] is OperationCategory)
        {
          oc = (OperationCategory)attrs[i];
          break;
        }
      }
      return oc;
    }

    /// <summary>
    /// Retorna uma lista de tipos derivados do tipo parametrizado
    /// </summary>
    /// <returns></returns>
    private void SetupDerivedTypes(Assembly assembly)
    {
      foreach (Type t in assembly.GetTypes())
      {
        if ((t.IsSubclassOf(typeof(Operation)) && (!t.IsAbstract)) || (t.IsEnum))
        {
          derived.Add(t);
          typeLookupTable[t.FullName] = assembly.FullName;
        }
      }
    }

    private List<Type> derived;
    private IrisList<Category> categories;

    private void SetupCategories()
    {
      categories = new IrisList<Category>("");

      foreach (Type t in derived)
      {
        Attribute[] attrs = System.Attribute.GetCustomAttributes(t);
        for (int i = 0; i < attrs.Length; i++)
        {
          if (attrs[i] is OperationCategory)
          {
            OperationCategory oc = (OperationCategory)attrs[i];
            Category cat = categories.FindByName(oc.Category);
            if (cat == null)
            {
              cat = new Category(oc.Category);
              categories.Add(cat);
            }
            cat.Types.Add(t);
          }
        }
      }
    }


  }
}
