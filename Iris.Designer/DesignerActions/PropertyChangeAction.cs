using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace Iris.Designer.DesignerActions
{
  public class PropertyChangeAction : BaseDesignerAction
  {
    public PropertyChangeAction(object target, PropertyValueChangedEventArgs evtArgs)
    {
      this.Target = target;
      this.OldValue = evtArgs.OldValue;
      if (evtArgs.ChangedItem != null)
      {
        this.NewValue = evtArgs.ChangedItem.Value;
        this.Property = evtArgs.ChangedItem.PropertyDescriptor;
      }
    }


    public object OldValue { get; set; }
    public object NewValue { get; set; }
    public object Target { get; set; }
    public PropertyDescriptor Property { get; set; }

    public override void Undo()
    {
      Property.SetValue(Target, OldValue);
    }

    public override void Redo()
    {
      Property.SetValue(Target, NewValue);
    }

  }
}
