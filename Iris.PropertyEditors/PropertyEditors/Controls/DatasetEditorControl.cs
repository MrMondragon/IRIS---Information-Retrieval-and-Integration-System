using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MindFusion.Diagramming.WinForms;

namespace Iris.PropertyEditors.PropertyEditors.Controls
{
  public partial class DatasetEditorControl : UserControl
  {
    public DatasetEditorControl()
    {
      InitializeComponent();
      surface.BackColor = Color.White;
      surface.ArrowBrush = new MindFusion.Drawing.SolidBrush(Color.White);
      surface.TableBrush = new MindFusion.Drawing.SolidBrush(SystemColors.Control);

      
    }

    private DataSet dataset;

    public DataSet Dataset
    {
      get 
      {
        dataset.ExtendedProperties["tableCoords"] = tableCoords;
        dataset.ExtendedProperties["linkPoints"] = linkPoints;
        return dataset; 
      }
      set 
      { 
        dataset = value;
        if (dataset != null)
        {
          if(dataset.ExtendedProperties.ContainsKey("tableCoords")) 
            tableCoords = dataset.ExtendedProperties["tableCoords"] as Dictionary<string,Rectangle>;

          if (dataset.ExtendedProperties.ContainsKey("linkPoints"))
            linkPoints = dataset.ExtendedProperties["linkPoints"] as Dictionary<string, List<Point>>;

          DrawDataset();
        }
      }
    }

    private void DrawDataset()
    {
      throw new Exception("The method or operation is not implemented.");
    }

    private Dictionary<string, Rectangle> tableCoords;
    private Dictionary<string, List<Point>> linkPoints;

    private Table CreateTable(DataTable dataTable)
    {

      int tableHeight = (int)((surface.TableCaptionHeight * 2) + ((dataTable.Columns.Count) * surface.TableRowHeight));
      Table table = surface.CreateTable(0, 0, 112, tableHeight);
      table.Caption = dataTable.TableName;

      foreach (DataColumn column in dataTable.Columns)
      {
        int idx = table.AddRow();
        table[1, idx].Brush = new MindFusion.Drawing.SolidBrush(Color.White);
        table[1, idx].Text = column.ColumnName;
        table[0, idx].Text = "  ";
      }

      table.ResizeToFitText(false);

      float y = (surface.Height / 2) - (tableHeight / 2);

      if (y < 10)
        y = 10;

      float x;

      table.FillColor = SystemColors.Control;
      x = surface.Width - table.BoundingRect.Width - 40;

      table.Move(x, y);
      return table;
    }
  }
}
