using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.PropertyEditors.Controls;
using Iris.Interfaces;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.Dialogs
{
  public partial class ScriptEditorDialog : BaseDialog
  {
    public ScriptEditorDialog()
    {
      InitializeComponent();
    }

    public string Script
    {
      get { return syntaxControl1.Text; }
      set { syntaxControl1.Text = value; }
    }

    public object SelectedObject
    {
      get { return syntaxControl1.SelectedObject; }
      set { syntaxControl1.SelectedObject = value; }
    }

    public string language
    {
      set 
      {
        if (value == "SQL")
          syntaxControl1.Language = SyntaxLanguage.Sql;
        else if (value == "C#")
          syntaxControl1.Language = SyntaxLanguage.CSharp;
        else if (value == "Text")
          syntaxControl1.Language = SyntaxLanguage.Text;
        else
          syntaxControl1.Language = SyntaxLanguage.None;
      }
    }

  }
}

