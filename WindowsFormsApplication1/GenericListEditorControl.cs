using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors.Controls;

namespace Iris.Runtime.Core.PropertyEditors.Controls
{
  public partial class GenericListEditorControl<T> : BaseControl where T : new()
  {
    public GenericListEditorControl()
    {
      InitializeComponent();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<T> List
    {
      get
      {
        List<T> list = new List<T>();
        for (int i = 0; i < lbxItems.Items.Count; i++)
        {
          list.Add((T)lbxItems.Items[i]);
        }
        return list;
      }
      set
      {
        lbxItems.Items.Clear();
        for (int i = 0; i < value.Count; i++)
        {
          lbxItems.Items.Add(value[i]);
        }
      }
    }

    public event EventHandler<ListEventArgs<T>> BeforeCreate;
    public event EventHandler<ListEventArgs<T>> AfterCreate;

    public event EventHandler<ListEventArgs<T>> BeforeDelete;
    public event EventHandler<ListEventArgs<T>> AfterDelete;

    public event EventHandler<ListEventArgs<T>> BeforeMove;
    public event EventHandler<ListEventArgs<T>> AfterMove;

    private ListEventArgs<T> CreateArgs(T item, T oldItem)
    {
      return new ListEventArgs<T>(List, item, oldItem);
    }

    private ListEventArgs<T> CreateCurrentArgs()
    {
      T item = GetCurrentItem();
      ListEventArgs<T> args = CreateArgs(item, default(T));
      return args;
    }

    public T GetCurrentItem()
    {
      T item = (T)lbxItems.SelectedItem;
      return item;
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
      ListEventArgs<T> args = CreateArgs(default(T), default(T));

      if (BeforeCreate != null)
        BeforeCreate(this, args);

      args.Item = new T();
      args.List.Add(args.Item);

      if (AfterCreate != null)
        AfterCreate(this, args);

      List = args.List;

      lbxItems.SelectedIndex = lbxItems.Items.Count - 1;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      DeleteItem(CreateCurrentArgs());
    }

    private void DeleteItem(ListEventArgs<T> args)
    {
      if (BeforeDelete != null)
        BeforeDelete(this, args);

      if (args.Item != null)
        args.List.Remove(args.Item);

      if (AfterDelete != null)
        AfterDelete(this, args);

      List = args.List;

      if (lbxItems.Items.Count > 0)
        lbxItems.SelectedIndex = lbxItems.Items.Count - 1;
    }

    private void MoveItem(sbyte direction)
    {
      int idx = lbxItems.SelectedIndex;
      if (idx != -1)
      {
        List<T> list = List;
        int idx2 = idx + direction;
        if ((idx2 > 0) && (idx2 < list.Count))
        {
          T item = list[idx];
          T item2 = list[idx2];

          ListEventArgs<T> args = CreateArgs(item, item2);

          if (BeforeMove != null)
            BeforeMove(this, args);

          list[idx] = item2;
          list[idx2] = item;

          if (AfterMove != null)
            AfterMove(this, args);
        }
        List = list;
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      List<T> list = List;
      foreach (T item in list)
      {
        ListEventArgs<T> args = CreateArgs(item, default(T));
        DeleteItem(args);
      }
      lbxItems.Items.Clear();
    }

    private void btnMoveUp_Click(object sender, EventArgs e)
    {
      MoveItem(-1);
    }

    private void btnMoveDown_Click(object sender, EventArgs e)
    {
      MoveItem(1);
    }

    private void lbxItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      propertyGrid1.SelectedObject = GetCurrentItem();
    }

    private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      OnPropertyChanged();
      List<T> list = List;
      List = list;
    }




  }


}
