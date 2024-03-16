using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      Button btn = new Button();
      btn.Width = 5;
      btn.Height = 5;
      button1.Controls.Add(btn);
      btn.Left = 5;
      btn.Top = 5;
    }

    private Control dragBtn;

    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
      dragBtn = (Control)sender;
    }
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
      dragBtn.Refresh();
      dragBtn = null;
    }

    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
        ResizeControl(e);
      else
        MoveControl(e);
    }

    private void ResizeControl(MouseEventArgs e)
    {
      if (dragBtn != null)
      {

        int x = Convert.ToInt32((((float)(e.X + dragBtn.Left) / (float)layoutPanel.Width)) * ((float)layoutPanel.ColumnCount));
        int y = Convert.ToInt32((((float)(e.Y + dragBtn.Top) / (float)layoutPanel.Height)) * ((float)layoutPanel.RowCount));

        TableLayoutPanelCellPosition pos = layoutPanel.GetCellPosition(dragBtn);
        int w = (x - pos.Column);
        int h = (y - pos.Row);

        if (w < 1)
          w = 1;
        if (h < 1)
          h = 1;

        layoutPanel.SetColumnSpan(dragBtn, w);
        layoutPanel.SetRowSpan(dragBtn, h);
      }
    }

    private void MoveControl(MouseEventArgs e)
    {
      if (dragBtn != null)
      {
        int x = Convert.ToInt32(Math.Truncate((((float)(e.X + dragBtn.Left) / (float)layoutPanel.Width)) * ((float)layoutPanel.ColumnCount)));
        int y = Convert.ToInt32(Math.Truncate((((float)(e.Y + dragBtn.Top) / (float)layoutPanel.Height)) * ((float)layoutPanel.RowCount)));

        layoutPanel.SetCellPosition(dragBtn, new TableLayoutPanelCellPosition(x, y));
      }
    }

    private void layoutPanel_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      int x = Convert.ToInt32(Math.Truncate((((float)(e.X) / (float)layoutPanel.Width)) * ((float)layoutPanel.ColumnCount)));
      int y = Convert.ToInt32(Math.Truncate((((float)(e.Y) / (float)layoutPanel.Height)) * ((float)layoutPanel.RowCount)));
      Button btn = new Button();
      layoutPanel.Controls.Add(btn, x, y);
      btn.Dock = System.Windows.Forms.DockStyle.Fill;
      btn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
      btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
      btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
    }    
  }
}