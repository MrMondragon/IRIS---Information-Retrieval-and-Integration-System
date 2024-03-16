using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;

namespace WindowsFormsApplication4
{
  public class CustomPropsDescriptor
  {
    public CustomPropsDescriptor(string name, string description, string category, Type propertyType, Type editorType, params Attribute[] attributes)
    {
      this.name = name;
      this.category = category;
      this.description = description;
      this.propertyType = propertyType;
      this.editorType = editorType;
      this.attributes = attributes;
    }

    public CustomPropsDescriptor(string name, Type propertyType, Type editorType, params Attribute[] attributes)
      : this(name, "", "Propriedades Avançadas", propertyType, editorType, attributes)
    {
    }

    public CustomPropsDescriptor(string name, Type editorType, params Attribute[] attributes)
      : this(name, "", "Propriedades Avançadas", typeof(string),editorType, attributes)
    {
    }

    public CustomPropsDescriptor(string name, params Attribute[] attributes)
      : this(name, "", "Propriedades Avançadas", typeof(string), null, attributes)
    {
    }


    private Type propertyType;

    public Type PropertyType
    {
      get { return propertyType; }
      set { propertyType = value; }
    }

    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    private Type editorType;

    public Type EditorType
    {
      get { return editorType; }
      set { editorType = value; }
    }
    private string description;

    public string Description
    {
      get { return description; }
      set { description = value; }
    }
    private string category;

    public string Category
    {
      get { return category; }
      set { category = value; }
    }


    private Attribute[] attributes;

    public Attribute[] Attributes
    {
      get { return attributes; }
      set { attributes = value; }
    }

    internal Attribute[] GetAttributes()
    {
      bool containsBrowsable = false;
      bool containsDisplayName = false;
      bool containsDescription = false;
      bool containsCategory = false;
      bool containsEditor = false;

      for (int i = 0; i < Attributes.Length; i++)
      {
        containsDisplayName |= Attributes[i] is DisplayNameAttribute;
        containsBrowsable |= Attributes[i] is BrowsableAttribute;
        containsCategory |= Attributes[i] is CategoryAttribute;
        containsDescription |= Attributes[i] is DescriptionAttribute;
        containsEditor |= Attributes[i] is EditorAttribute;
      }

      List<Attribute> list = new List<Attribute>(Attributes);

      if (!containsBrowsable)
        list.Add(new BrowsableAttribute(true));
      if (!containsCategory)
        list.Add(new CategoryAttribute(Category));
      if (!containsDescription)
        list.Add(new DescriptionAttribute(Description));
      if (!containsDisplayName)
        list.Add(new DisplayNameAttribute(Name));
      if ((!containsEditor) && (EditorType != null))
        list.Add(new EditorAttribute(EditorType, typeof(UITypeEditor)));

      return list.ToArray();
    }
  }
}
