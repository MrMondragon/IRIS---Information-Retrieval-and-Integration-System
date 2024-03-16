using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace WindowsFormsApplication4
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
      DataTable table = new DataTable();
      DataColumn column = new DataColumn("CodColigada", typeof(Int16), "1");
      table.Columns.Add(column);
      table.ExtendedProperties["Teste"] = ConnectionState.Open;
      table.ExtendedProperties["Filename"] = "";

      Dictionary<string, CustomPropsDescriptor> customProps = ExtendedPropsProvider.GetCustomProperties(table, "ExtendedProperties");
      customProps["Filename"].EditorType = typeof(FileNameEditor);

      ExtendedPropsProvider.AddProvider(typeof(DataTable), "ExtendedProperties", customProps);

      //ExtendedPropsProvider.AddProvider(column, "ExtendedProperties");

      propertyGrid1.SelectedObject = table;
    }
  }
}
