using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hermes
{
  public partial class Designer : Form
  {
    public Designer()
    {
      InitializeComponent();
    }

    #region controle de layout

    private VisualPart dragPart;

    private void part_MouseDown(object sender, MouseEventArgs e)
    {
      dragPart = (VisualPart)sender;
    }
    private void part_MouseUp(object sender, MouseEventArgs e)
    {
      dragPart = null;
    }

    private void part_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
        ResizeControl(e);
      else
        MoveControl(e);
    }

    private void ResizeControl(MouseEventArgs e)
    {
      if (dragPart != null)
      {

        int x = Convert.ToInt32((((float)(e.X + dragPart.Left) / (float)layoutPanel.Width)) * ((float)layoutPanel.ColumnCount));
        int y = Convert.ToInt32((((float)(e.Y + dragPart.Top) / (float)layoutPanel.Height)) * ((float)layoutPanel.RowCount));

        TableLayoutPanelCellPosition pos = layoutPanel.GetCellPosition(dragPart);
        int w = (x - pos.Column);
        int h = (y - pos.Row);

        if (w < 1)
          w = 1;
        if (h < 1)
          h = 1;

        layoutPanel.SetColumnSpan(dragPart, w);
        layoutPanel.SetRowSpan(dragPart, h);
      }
    }

    private void MoveControl(MouseEventArgs e)
    {
      if (dragPart != null)
      {
        int x = Convert.ToInt32(Math.Truncate((((float)(e.X + dragPart.Left) / (float)layoutPanel.Width)) * ((float)layoutPanel.ColumnCount)));
        int y = Convert.ToInt32(Math.Truncate((((float)(e.Y + dragPart.Top) / (float)layoutPanel.Height)) * ((float)layoutPanel.RowCount)));

        layoutPanel.SetCellPosition(dragPart, new TableLayoutPanelCellPosition(x, y));
      }
    }
    #endregion


  }
}