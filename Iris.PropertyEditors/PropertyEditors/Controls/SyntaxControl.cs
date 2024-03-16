using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QWhale.Syntax;
using QWhale.Editor;
using QWhale.Syntax.Parsers;
using Iris.Interfaces;
using QWhale.Editor.Dialogs;
using Databridge.Interfaces;

namespace Iris.PropertyEditors.PropertyEditors.Controls
{
  public partial class SyntaxControl : UserControl
  {
    public SyntaxControl()
    {
      InitializeComponent();
      csParser1.RegisterNamespace("Iris.Runtime.Model.Entities");
      csParser1.RegisterNamespace("Iris.Runtime.Model.BaseObjects");
      csParser1.RegisterNamespace("System.Collections.Generic");
      csParser1.RegisterNamespace("System.Text");
      csParser1.RegisterNamespace("System.Data");
      csParser1.RegisterNamespace("System.Data.Common");
      csParser1.RegisterNamespace("Iris.Runtime.Core.Connections");
      csParser1.RegisterNamespace("Iris.Interfaces");
      csParser1.RegisterNamespace("Iris.Runtime.Model.BaseObjects");
      synCodeEditor.Lines.TabStops = new int[] { 2 };
      synCodeEditor.Lines.UseSpaces = true;
    }

    public new string Text
    {
      get { return synCodeEditor.Text; }
      set { synCodeEditor.Text = value; }
    }

    private object selectedObject;

    public object SelectedObject
    {
      get { return selectedObject; }
      set { selectedObject = value; }
    }

    private IStructure structure;

    public IStructure Structure
    {
      get { return structure; }
      set { structure = value; }
    }

    private SyntaxLanguage language;
    [Browsable(false)]
    public SyntaxLanguage Language
    {
      get { return language; }
      set 
      { 
        language = value;
        if (language == SyntaxLanguage.None)
        {
          synCodeEditor.Text = "";
          synCodeEditor.Lexer = null;
          Enabled = false;
          synCodeEditor.BackColor = Color.Gray;
        }
        else
        {
          Enabled = true;
          synCodeEditor.BackColor = Color.White;

          if (language == SyntaxLanguage.CSharp)
          {
            if (Structure != null)
            {
              ISyntaxParser parser = new CsParser();
              parser.Strings = new SyntaxStrings(); 
              parser.Strings.Text = Structure.GetBaseAccessorCode();
              parser.ReparseText();
              csParser1.CompletionRepository.RegisterSyntaxTree(parser.SyntaxTree);
            }
            synCodeEditor.Lexer = csParser1;
          }
          else if (language == SyntaxLanguage.Sql)
          {
            synCodeEditor.Lexer = sqlParser1;
          }
          else if (language == SyntaxLanguage.Text)
          {
            synCodeEditor.Lexer = null;
          }
        }
      }
    }	

    private void synCodeEditor_NeedCodeCompletion(object sender, QWhale.Syntax.CodeCompletionArgs e)
    {
      if (((SyntaxEdit)sender).Lexer is SqlParser)
      {
        IListMembers p = new ListMembers();
        p.ShowDescriptions = true;
        p.ShowResults = false;
        p.ShowQualifiers = false;
        p.Images = imlCodeCompSQL;

        #region CodeCompletion de SQL
        if (e.CompletionType == CodeCompletionType.CompleteWord)
        {
          string[] keyWords = new string[] { "open", "fill", "accept", "reject", "clear", "apply", "cleardataset", "execute", "getSql", "getFields" };

          for (int i = 0; i < keyWords.Length; i++)
          {
            IListMember m = p.AddMember();
            m.Name = keyWords[i];
            m.ImageIndex = 0;
            m.Qualifier = "KeyWord";
          }

          AddTables(p);

          e.NeedShow = true;
          e.Provider = p;
          e.ToolTip = false;
        }
        else if (e.CompletionType == CodeCompletionType.None)
        {
          if (e.KeyChar == '.')
          {
            string tableName = synCodeEditor.Lines[e.StartPosition.Y];
            tableName = tableName.Substring(0, e.StartPosition.X - 1).Trim();
            string[] words = tableName.Split(' ', ',', '.', '{', '}', '(', ')', '\'', '/', '*', '-', '+', ':',
                                             ';', '=', '@', '%', '&', '<', '>', '?', '#', '"');
            tableName = "";
            int idx = words.Length - 1;
            while ((tableName == "") && (idx > 0))
            {
              tableName = words[idx];
              idx--;
            }

            if (!string.IsNullOrEmpty(tableName))
            {
              List<string> fields = new List<string>();
              if (SelectedObject is IConnectedObject)
              {
                DataTable dFields = ((IConnectedObject)SelectedObject).Connection.GetFields(tableName);
                for (int i = 0; i < dFields.Rows.Count; i++)
                {
                  fields.Add(Convert.ToString(dFields.Rows[i]["Column_Name"]));
                }
              }
              else
              {
                if (Structure.Dataset.Tables.Contains(tableName))
                {
                  DataTable table = Structure.Dataset.Tables[tableName];
                  for (int i = 0; i < table.Columns.Count; i++)
                  {
                    fields.Add(table.Columns[i].ColumnName);
                  }
                }
              }

              for (int i = 0; i < fields.Count; i++)
              {
                IListMember m = p.AddMember();
                m.Name = fields[i];
                m.ImageIndex = 2;
                m.Qualifier = "Campo";
              }

              e.NeedShow = fields.Count > 0;
              e.Provider = p;
              e.ToolTip = false;
            }
          }
          else if (e.KeyChar == ' ')
          {
            AddTables(p);
            e.NeedShow = true;
            e.Provider = p;
            e.ToolTip = false;
          }
        }

        #endregion
      }
    }

    private void AddTables(IListMembers p)
    {
      List<String> tables = new List<string>();
      if (SelectedObject is IConnectedObject)
      {
        DataTable dTables = ((IConnectedObject)SelectedObject).Connection.GetSchema();

        string tableNameField = dTables.Columns.Contains("TABLE_NAME") ? "TABLE_NAME" : "TABLENAME";

        for (int i = 0; i < dTables.Rows.Count; i++)
        {
          tables.Add(Convert.ToString(dTables.Rows[i][tableNameField]));
        }
      }
      else
      {
        for (int i = 0; i < Structure.ResultSets.Length; i++)
        {
          tables.Add(Structure.ResultSets[i].Name);
        }
      }

      for (int i = 0; i < tables.Count; i++)
      {
        IListMember m = p.AddMember();
        m.Name = tables[i];
        m.ImageIndex = 1;
        m.Qualifier = "Tabela";
      }
    }

    public string GetSelectedText()
    {
      string result = "";

      if (!synCodeEditor.Selection.IsEmpty)
        result = synCodeEditor.Selection.SelectedText;
      else
        result = synCodeEditor.Text;      

      return result;
    }
  }

  [Serializable]
  public enum SyntaxLanguage
  {
    CSharp,
    Sql,
    Text,
    None
  }
}
