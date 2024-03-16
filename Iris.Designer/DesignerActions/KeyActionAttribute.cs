using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iris.Designer.DesignerActions
{
  public class KeyActionAttribute : Attribute
  {
    public KeyActionAttribute(Modifiers mod, Keys keycode)
    {
      string str = mod.ToString();
      Alt = str.Contains("Alt");
      Control = str.Contains("Control");
      Shift = str.Contains("Shift");

      KeyCode = keycode;
    }

    public KeyActionAttribute(bool alt, bool control, bool shift, Keys keycode)
    {
      Alt = alt;
      Control = control;
      Shift = shift;
      KeyCode = keycode;
    }


    public KeyActionAttribute(Keys keycode)
    {
      Alt = false;
      Control = false;
      Shift = false;
      KeyCode = keycode;
    }


    public bool Alt { get; set; }
    public bool Control { get; set; }
    public bool Shift { get; set; }
    public Keys KeyCode { get; set; }

    public override int GetHashCode()
    {
      return Alt.GetHashCode() ^ Control.GetHashCode() ^ Shift.GetHashCode() ^ KeyCode.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      KeyActionAttribute attr = (KeyActionAttribute)obj;
      return (KeyCode == attr.KeyCode) && (Alt == attr.Alt) && (Control == attr.Control) && (Shift == attr.Shift);
    }
  }

  public enum Modifiers
  {
    Alt,
    ControlAlt,
    ShiftAlt,
    Control,
    ControlShift,
    Shift
  }
}


