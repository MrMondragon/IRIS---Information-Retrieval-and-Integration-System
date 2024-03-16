using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.Designer.DesignerActions
{
  public class ActionManager
  {
    public ActionManager(StructureDesigner designer)
    {
      undoStack = new List<BaseDesignerAction>();
      redoStack = new List<BaseDesignerAction>();
      this.structure = designer.Structure;
      this.Designer = designer;
      MaxStackSize = 255;

      SetupKeyboardActions(designer);
    }

    private void SetupKeyboardActions(StructureDesigner designer)
    {
      MethodInfo[] mis = typeof(StructureDesigner).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.GetCustomAttributes(typeof(KeyActionAttribute), false).Length != 0).ToArray();

      keyboardActions = new Dictionary<KeyActionAttribute, Action>();

      foreach (MethodInfo item in mis)
      {
        Action action = (Action)Delegate.CreateDelegate(typeof(Action), designer, item.Name);

        KeyActionAttribute[] attrs = item.GetCustomAttributes(typeof(KeyActionAttribute), false).Cast<KeyActionAttribute>().ToArray();
        for (int i = 0; i < attrs.Length; i++)
        {
          keyboardActions[attrs[i]] = action;
        }
      }

    }

    public bool ExecuteKeyAction(bool alt, bool control, bool shift, Keys keycode)
    {
      KeyActionAttribute attr = new KeyActionAttribute(alt, control, shift, keycode);
      if (keyboardActions.ContainsKey(attr))
      {
        keyboardActions[attr]();
        return true;
      }
      else
        return false;
    }

    private Dictionary<KeyActionAttribute, Action> keyboardActions;

    public StructureDesigner Designer { get; private set; }


    private Structure structure;
    public Structure Structure
    {
      get { return structure; }
    }
    public int MaxStackSize { get; set; }

    public void AddToUndoStack(BaseDesignerAction action)
    {
      bool allow = true;

      if (undoStack.Count != 0)
        allow = undoStack.Last().AllowNewAction(action);

      if ((!stacksLocked) && allow)
      {
        action.Manager = this;
        undoStack.Add(action);
        while (undoStack.Count > MaxStackSize)
        {
          undoStack.RemoveAt(0);
        }

        redoStack.Clear();
      }
    }

    public bool ActionsLocked { get; set; }
    public void LockActions()
    {
      ActionsLocked = true;
    }
    public void UnlockActions()
    {
      ActionsLocked = false;
    }


    private bool stacksLocked;
    private void LockStacks()
    {
      stacksLocked = true;
    }
    private void UnlockStacks()
    {
      stacksLocked = false;
    }


    public void Undo()
    {
      LockStacks();
      try
      {
        if (undoStack.Count != 0)
        {
          BaseDesignerAction action = undoStack.Last();
          undoStack.Remove(action);
          action.Undo();
          redoStack.Add(action);
        }
      }
      finally
      {
        UnlockStacks();
      }
    }

    public void Redo()
    {
      LockStacks();
      try
      {
        if (redoStack.Count != 0)
        {
          BaseDesignerAction action = redoStack.Last();
          redoStack.Remove(action);
          action.Redo();
          undoStack.Add(action);
        }
      }
      finally
      {
        UnlockStacks();
      }
    }

    private List<BaseDesignerAction> undoStack;
    private List<BaseDesignerAction> redoStack;


  }
}
