using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MindFusion.Diagramming.WinForms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.Dialogs
{
  public partial class FieldMapEditorDialog : BaseDialog
  {
    public FieldMapEditorDialog()
    {
      InitializeComponent();
      surface.BackColor = Color.White;
      surface.ArrowBrush = new MindFusion.Drawing.SolidBrush(Color.White);
      surface.TableBrush = new MindFusion.Drawing.SolidBrush(SystemColors.Control);
      this.AcceptButton = null;
    }


    public List<KeyValuePair<string, string>> GetFieldMap()
    {
      List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
      List<string> uniqueList = new List<string>();
      foreach (Arrow arrow in surface.Arrows)
      {
        int orig = arrow.OrgnIndex;
        int dest = arrow.DestIndex;


        string origStr = sourceTable[1, orig].Text;
        string destStr = destTable[1, dest].Text;
        string uniqueKey = origStr + "-" + destStr;

        if (!uniqueList.Contains(uniqueKey))
        {
          KeyValuePair<string, string> kvi = new KeyValuePair<string, string>(origStr, destStr);
          list.Add(kvi);
          uniqueList.Add(uniqueKey);
        }
      }

      if (addedSourceColumns != null)
      {
        foreach (string col in addedSourceColumns)
        {
          if (!list.Exists(x => x.Key == col))
            source.Columns.Remove(col);
        }
      }

      if (addedDestColumns != null)
      {
        foreach (string col in addedDestColumns)
        {
          if (!list.Exists(x => x.Value == col))
            destination.Columns.Remove(col);
        }
      }

      return list;
    }

    private DataTable source;
    private DataTable destination;
    private List<string> addedSourceColumns;
    private List<string> addedDestColumns;

    public FieldMapEditorDialog(DataTable _source, DataTable _destination, List<KeyValuePair<string, string>> fieldMap)
      : this()
    {
      if (fieldMap != null)
      {
        foreach (KeyValuePair<string, string> item in fieldMap)
        {
          if (!_source.Columns.Contains(item.Key))
          {
            if (addedSourceColumns == null)
              addedSourceColumns = new List<string>();
            _source.Columns.Add(item.Key);
          }

          if (!_destination.Columns.Contains(item.Value))
          {
            if (addedDestColumns == null)
              addedDestColumns = new List<string>();

            _destination.Columns.Add(item.Value);
          }
        }
      }

      sourceTable = CreateTable(_source, true);
      destTable = CreateTable(_destination, false);
      
      source = _source;
      destination = _destination;

      CreateArrows(fieldMap);
    }

    private void CreateArrows(List<KeyValuePair<string, string>> fieldMap)
    {
      if (fieldMap != null)
      {
        foreach (KeyValuePair<string, string> kvi in fieldMap)
        {
          CreateArrow(kvi);
        }
      }
      surface.Selection.Clear();
    }

    private void CreateArrow(KeyValuePair<string, string> kvi)
    {
      int idxOrigem = GetFieldIndex(sourceTable, kvi.Key);
      int idxDestino = GetFieldIndex(destTable, kvi.Value);
      surface.CreateArrow(sourceTable, idxOrigem, destTable, idxDestino);
    }

    private int GetFieldIndex(Table table, string p)
    {
      for (int i = 0; i < table.Rows.Count; i++)
			{
        if (table[1, i].Text.ToLower() == p.ToLower())
          return i;
      }
      return -1;
    }


    private Table sourceTable;
    private Table destTable;

    private Table CreateTable(DataTable dataTable, bool isSource)
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

      if (isSource)
      {
        table.FillColor = SystemColors.ControlLight;
        x = 40;
      }
      else
      {
        table.FillColor = SystemColors.Control;
        x = surface.Width - table.BoundingRect.Width - 40;
      }
      table.Move(x, y);
      return table;
    }

    private void surface_ArrowCreated(object sender, ArrowEventArgs e)
    {
      Arrow arrow = e.Arrow;
      if (arrow.Origin == destTable)
      {
        int origIdx = arrow.OrgnIndex;
        int destIdx = arrow.DestIndex;
        surface.DeleteObject(arrow);
        arrow = surface.CreateArrow(sourceTable, destIdx, destTable, origIdx);
      }
      
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      ClearArrows();
      if (tabControl1.SelectedTab == tabText)
        txtText.Text = "";
    }

    private void ClearArrows()
    {
      while (surface.Arrows.Count > 0)
        surface.DeleteObject(surface.Arrows[0]);
    }

    private void btnAutoLink_Click(object sender, EventArgs e)
    {
      List<string> campos = new List<string>();
      List<KeyValuePair<string, string>> map = GetFieldMap();
      List<string> uniqueList = new List<string>();
      for (int i = 0; i < map.Count; i++)
      {
        uniqueList.Add(map[i].Key.ToLower() + "-" + map[i].Value.ToLower());
      }

      for (int i = 0; i < source.Columns.Count; i++)
      {
        for (int j = 0; j < destination.Columns.Count; j++)
        {
          string orig = source.Columns[i].ColumnName.ToLower();
          string dest = destination.Columns[j].ColumnName.ToLower();
          string uniqueKey = orig+"-"+dest;
          if (orig == dest) 
          {
            if (!uniqueList.Contains(uniqueKey))
            {
              campos.Add(source.Columns[i].ColumnName);
            }
            break;
          }
        }
      }

      foreach (string fieldName in campos)
      {
        KeyValuePair<string, string> kvi = new KeyValuePair<string, string>(fieldName, fieldName);
        CreateArrow(kvi);
      }

      if (tabControl1.SelectedTab == tabText)
        UpdateText();
    }

    private List<KeyValuePair<string, string>> ParseText()
    {
      string txt = txtText.Text;
      List<KeyValuePair<string, string>> itens = new List<KeyValuePair<string, string>>();

      if (!string.IsNullOrWhiteSpace(txt))
      {
        List<string> lines = txt.Split('\r').ToList();

        foreach (string line in lines)
        {
          string[] lineParts = line.Split(',', ';');
          if (lineParts.Length == 2)
          {
            KeyValuePair<string,string> kvp = new KeyValuePair<string,string>(lineParts[0].Trim(),lineParts[1].Trim());
            itens.Add(kvp);
          }
        }
      }
      return itens;
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (tabControl1.SelectedTab == tabText)
      {
        UpdateText();
      }
      else
      {
        UpdateDiagram();
      }
    }

    private void UpdateText()
    {
      StringBuilder sb = new StringBuilder();
      List<KeyValuePair<string, string>> fieldMap = GetFieldMap();

      foreach (KeyValuePair<string, string> item in fieldMap)
      {
        sb.AppendLine(string.Format("{0};{1}", item.Key, item.Value));
      }
      txtText.Text = sb.ToString();
    }

    private void UpdateDiagram()
    {
      List<KeyValuePair<string, string>> fieldMap = ParseText();
      ClearArrows();
      CreateArrows(fieldMap);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (tabControl1.SelectedTab == tabText)
        UpdateDiagram();
    }
  }
}