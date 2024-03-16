using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Iris.Runtime.Model.BaseObjects;
using Iris.Designer.VisualObjects;
using Runner;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.Entities;
using MindFusion.Diagramming.WinForms;
using Iris.Designer.Loader;
using System.Reflection;
using System.IO;
using Iris.PropertyEditors.Dialogs;
using Iris.Interfaces;
using Iris.Runtime.Model.PropertyEditors.Interfaces;
using Iris.Runtime.Model;
using Iris.Runtime.Model.DisignSuport;
using Iris.Designer.Plugins;
using Iris.Designer.Dialogs;
using Iris.Designer.PluginSupport;
using Databridge.Engine;
using Databridge.Interfaces;
using Iris.Designer.Properties;
using Iris.Runtime.Model.ClientObjects;
using System.Text;
using Iris.Designer.DesignerActions;


namespace Iris.Designer
{
  public partial class StructureDesigner : Form, ILoggable, IProccessLog, IStructureDesigner
  {

    public StructureDesigner()
    {
      entries = new List<ILogItem>();

      isDirty = false;

      InitializeComponent();


      surface.BackColor = Color.White;
      surface.ArrowFillColor = Color.White;
      opClass = null;
      structure = new Structure();

      InitStructure();
      LoadPlugins();
      surface.Tag = structure;
      outputPath = "";
      cbxZoom.Text = "100%";

      this.FileName = "";

#if Demo
      Text = Text + "    <Versão de Demontração>"; 
#endif

      actionManager = new ActionManager(this);
      cbxZoom.SelectedIndex = 3;

    }

    private ActionManager actionManager;
    private Type opClass;
    internal string outputPath;

    private Structure structure;
    public Structure Structure
    {
      get
      {
        return structure;
      }
      set
      {
        structure = value;
      }
    }

    #region Carga de Plugins

    private OperationLoader loader;
    private List<BaseToolbarPlugin> loadedPlugins;
    internal Dictionary<string, string> typeLookupTable;

    private void LoadPlugins()
    {
      List<Assembly> list = new List<Assembly>();
      list.Add((typeof(ResultSet)).Assembly);

      loadedPlugins = new List<BaseToolbarPlugin>();
      List<string> plugins;
#if Licensed
      plugins = LicensedPluginLoader.GetLicensedPlugins(this.Structure);
#else
      string plugsDir = Application.StartupPath + "\\Plugins\\";
      if (!Directory.Exists(plugsDir))
        Directory.CreateDirectory(plugsDir);

      plugins = LoadPluginFileNames(plugsDir);
#endif

      foreach (string filename in plugins)
      {
        string plugName = filename.Substring(0, filename.LastIndexOf('.'));
        plugName = plugName.Substring(plugName.LastIndexOf('.') + 1);
        Assembly assembly = Assembly.LoadFrom(filename);
        LoadOeprationPlugin(list, filename, plugName, assembly);
        LoadToolBarPlugin(plugName, assembly);
        LoadBehaviorPlugin(plugName, assembly);
      }

      if (list.Count > 0)
      {
        loader = new OperationLoader(list);
        typeLookupTable = loader.TypeLookupTable;
        loader.SetupComboBox(cbxCategories);
        cbxCategories.SelectedIndex = 0;
      }
    }

    private List<string> LoadPluginFileNames(string plugsDir)
    {
      plugsDir = Path.Combine(plugsDir, "Plugins.config");
      List<string> plugins = new List<string>();
      if (File.Exists(plugsDir))
      {
        using (StreamReader sr = new StreamReader(plugsDir, Encoding.Default))
        {
          string line;
          while ((line = sr.ReadLine()) != null)
          {
            line = line.Trim();
            if (!string.IsNullOrEmpty(line))
            {
              string[] lineparts = line.Split('|');
              string fileName = Path.Combine(Application.StartupPath, lineparts[1]);
              if (lineparts[0] == "p")
                plugins.Add(fileName);
              else
              {
                Structure.Assemblies[lineparts[1]] = fileName;
              }
            }
          }
        }
      }
      return plugins;
    }

    private void LoadBehaviorPlugin(string plugName, Assembly assembly)
    {
      if (assembly.GetCustomAttributes(typeof(BehaviorPluginAssembly), false).Length > 0)
      {
        foreach (Type t in assembly.GetTypes())
        {
          if (t.IsSubclassOf(typeof(BaseBehaviorPlugin)) && (!t.IsSubclassOf(typeof(BaseToolbarPlugin))) && (!t.IsAbstract) && (t.GetCustomAttributes(typeof(IgnorePlugin), false).Length == 0))
          {
            BaseBehaviorPlugin behaviorPlugin = (BaseBehaviorPlugin)t.GetConstructor(new Type[] { }).Invoke(new object[] { });
            behaviorPlugin.DoExecute();
            AddToLog("Execução do plugin " + plugName + " V." + GetVersion(assembly), null);
          }
        }
      }
    }

    private void LoadToolBarPlugin(string plugName, Assembly assembly)
    {
      if (assembly.GetCustomAttributes(typeof(ToolBarPluginAssembly), false).Length > 0)
      {
        tbMain.Items.Add(new ToolStripSeparator());
        foreach (Type t in assembly.GetTypes())
        {
          if (t.IsSubclassOf(typeof(BaseToolbarPlugin)) && (!t.IsAbstract) && (t.GetCustomAttributes(typeof(IgnorePlugin), false).Length == 0))
          {
            BaseToolbarPlugin toolbarPlugin = (BaseToolbarPlugin)t.GetConstructor(new Type[] { }).Invoke(new object[] { });
            toolbarPlugin.Load(this);
            loadedPlugins.Add(toolbarPlugin);
            AddToLog("Carga do plugin " + plugName + " V." + GetVersion(assembly), null);
          }
        }
      }
    }

    private string GetVersion(Assembly assembly)
    {
      string fullName = assembly.FullName;
      fullName = fullName.Substring(fullName.IndexOf('=') + 1);
      fullName = fullName.Remove(fullName.IndexOf(','));
      return fullName;
    }

    private Dictionary<string, string> loadedPluginAssemblies;

    private void LoadOeprationPlugin(List<Assembly> list, string filename, string plugName, Assembly assembly)
    {
      if (assembly.GetCustomAttributes(typeof(OperationPluginAssembly), false).Length > 0)
      {
        list.Add(assembly);
        if (loadedPluginAssemblies == null)
        {
          loadedPluginAssemblies = new Dictionary<string, string>();
        }

        structure.Assemblies[assembly.ManifestModule.ToString()] = filename;
        loadedPluginAssemblies[assembly.ManifestModule.ToString()] = filename;

        AddToLog("Carga do plugin " + plugName + " V." + GetVersion(assembly), null);
      }
    }

    #endregion

    #region Métodos e eventos internos


    private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
      loader.SetupToolBar(tsOperations, (Category)cbxCategories.SelectedItem, OperBtn_Click);
    }

    private void RefreshTbcOutput()
    {
      if (tbcOutput.Visible)
        tbcOutput.Invalidate();
    }

    private void StructureDesigner_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsDirty)
      {
        DialogResult result = MessageBox.Show("Deseja gravar antes de sair?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        switch (result)
        {
          case DialogResult.Cancel:
            e.Cancel = true;
            break;
          case DialogResult.Yes:
            Save(false);
            break;
        }
      }
    }

    [KeyAction(Keys.F4)]
    private void ShowProperties()
    {
      btnHideTools.Checked = true;
      SetToolsVisibility();
      tbcTools.SelectedTab = tabProperties;
    }

    [KeyAction(Keys.F8)]
    private void ShowTools()
    {
      btnHideTools.Checked = true;
      SetToolsVisibility();
      tbcTools.SelectedTab = tabOperations;

    }

    [KeyAction(Keys.Delete)]
    private void DeleteAction()
    {
      if (this.ActiveControl == surface)
      {
        while (surface.Selection.Tables.Count > 0)
        {
          VisualOperation table = (VisualOperation)surface.Selection.Tables[0];
          table.Delete();
          surface.Selection.RemoveObject(table);
          surface.DeleteObject(table);
        }
      }
    }

    [KeyAction(Keys.F8)]
    private void ShowVars()
    {
      btnHideVars.Checked = true;
      SetVarsVisibility();
      tbcVars.SelectedIndex = (tbcVars.SelectedIndex + 1) % tbcVars.TabPages.Count;
    }


    private void StructureDesigner_KeyUp(object sender, KeyEventArgs e)
    {
      if (!actionManager.ExecuteKeyAction(e.Alt, e.Control, e.Shift, e.KeyCode))
      {
        for (int i = 0; i < loadedPlugins.Count; i++)
        {
          loadedPlugins[i].TestKey(e);
        }
      }
    }

    [KeyAction(Modifiers.Control, Keys.Z)]
    private void Undo()
    {
      actionManager.Undo();
    }

    [KeyAction(Modifiers.ControlShift, Keys.Z)]
    private void Redo()
    {
      actionManager.Redo();
    }


    [KeyAction(Keys.F9)]
    private void ToggleBreakPoint()
    {
      if (surface.Selection.Tables.Count != 0)
      {
        VisualOperation vo = (VisualOperation)surface.Selection.Tables[0];
        if (vo.Operation is Operation)
          ((Operation)vo.Operation).BreakPoint = !((Operation)vo.Operation).BreakPoint;
      }
      PaintBreakPoints();
    }

    [KeyAction(Modifiers.Control, Keys.F)]
    private void FindOperation()
    {
      FindItemDialog dlg = new FindItemDialog();
      bool found = false;
      string searchText = dlg.Execute().ToLower();
      if (!string.IsNullOrEmpty(searchText))
      {
        ClearLog();

        #region Prepara Lista

        List<IOperation> searchItems = new List<IOperation>();

        for (int i = 0; i < Structure.Operations.Count; i++)
        {
          searchItems.Add(Structure.Operations[i]);
        }
        for (int i = 0; i < structure.ScalarVars.Count; i++)
        {
          searchItems.Add(structure.ScalarVars[i]);
        }
        for (int i = 0; i < structure.ResultSets.Count; i++)
        {
          searchItems.Add(structure.ResultSets[i]);
        }
        for (int i = 0; i < structure.Schemas.Count; i++)
        {
          searchItems.Add(structure.Schemas[i]);
        }

        #endregion

        foreach (IOperation operation in searchItems)
        {
          Type operType = operation.GetType();
          PropertyInfo[] properties = operType.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
          foreach (PropertyInfo propInfo in properties)
          {
            PropertyDescriptor propDesc = TypeDescriptor.GetProperties(operation)[propInfo.Name];
            if ((propDesc != null) && (propDesc.IsBrowsable))
            {
              string displayName = propDesc.DisplayName;
              string value = "";
              try
              {
                value = Convert.ToString(propInfo.GetValue(operation, null));
              }
              catch { }
              if (value.ToLower().Contains(searchText))
              {
                if (value.Length > 40)
                {
                  int pos = value.ToLower().IndexOf(searchText);
                  if (pos > 20)
                    value = value.Substring(pos - 20);

                  int end = value.ToLower().IndexOf(searchText) + searchText.Length + 20;

                  if (value.Length > end)
                    value = value.Substring(0, end);

                  value = "..." + value + "...";
                }

                string text = operation.Name + " -> " + displayName + ": " + value;

                CreateListViewItem(text, operation, 3, lvwLog, true, false);
                found = true;
              }
            }
          }
        }
      }

      if (!found)
      {
        AddToErrorLog(string.Format("Texto {0} não encontrado!", searchText), null);
      }
    }

    [KeyAction(Keys.F2)]
    private void ReRun()
    {
      tbcOutput.SelectedTab = tabOutput;
      SetRunningPoint();
      ResetOp();
      Step();
    }

    [KeyAction(Keys.F11)]
    private void RunToSelection()
    {
      if (surface.Selection.Tables.Count > 0)
      {
        VisualOperation vo = (VisualOperation)surface.Selection.Tables[0];
        if (vo.Operation is Operation)
        {
          bool breakPoint = ((Operation)vo.Operation).BreakPoint;
          ((Operation)vo.Operation).BreakPoint = true;
          Run();
          ((Operation)vo.Operation).BreakPoint = breakPoint;
        }
      }
    }

    private void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
    {
      if (propertyGrid.SelectedObject is IDynamicIOOperation)
      {
        VisualOperation vo = GetVOFromOperation((IOperation)propertyGrid.SelectedObject);
        vo.CreateRows();
      }

      if (propertyGrid.SelectedObject is Operation)
      {
        if ((e.ChangedItem.Label == "Break Point") || (e.ChangedItem.Label == "IgnoreOperation"))
        {
          PaintBreakPoints();
        }
      }

      IsDirty = true;

      actionManager.AddToUndoStack(new PropertyChangeAction(propertyGrid.SelectedObject, e));
    }

    internal void PaintBreakPoints()
    {
      lvwBreakPoints.Items.Clear();
      for (int i = 0; i < structure.Operations.Count; i++)
      {
        Operation oper = structure.Operations[i] as Operation;

        if (oper != null)
        {
          VisualOperation vo = GetVOFromOperation(oper);
          if (vo != null)
          {
            if (oper.BreakPoint)
            {
              vo.SetColor(Color.Maroon);
              CreateListViewItem(oper.Name, oper, 2, lvwBreakPoints, false, false);
            }
            else if (oper.IgnoreOperation)
            {
              vo.SetColor(Color.Silver);
            }
            else
              ((Operation)vo.Operation).Status = ((Operation)vo.Operation).Status;
          }
        }
      }
    }

    internal void ClearAll()
    {
      lvwConnections.Items.Clear();
      lvwResultSets.Items.Clear();
      lvwSchemas.Items.Clear();
      lvwVars.Items.Clear();

      while (surface.Tables.Count > 0)
        surface.Tables.RemoveAt(0);

      while (surface.Arrows.Count > 0)
        surface.Arrows.RemoveAt(0);

      surface.ClearAll();
      txtNotes_Validated(this, EventArgs.Empty);
      propertyGrid.SelectedObject = null;
    }


    private void bkpTimer_Tick(object sender, EventArgs e)
    {
      if (IsDirty)
        SaveSnapshot();
    }


    #endregion

    #region Eventos da estrutura

    internal void InitStructure()
    {
      structure.AfterStartPointChanged += AfterStartPointChanged;
      structure.BeforeStartPointChanged += BeforeStartPointChanged;
      structure.AfterResultPointChanged += AfterEndPointChanged;
      structure.BeforeResultPointChanged += BeforeEndPointChanged;
      structure.AfterOutputPointChanged += AfterOutputPointChanged;
      structure.BeforeOutputPointChanged += BeforeOutputPointChanged;
      structure.BeforeDexChanged += BeforeDexChanged;
      structure.AfterDexChanged += AfterDexChanged;
      if (loadedPluginAssemblies != null)
      {
        foreach (KeyValuePair<string, string> item in loadedPluginAssemblies)
        {
          structure.Assemblies[item.Key] = item.Value;
        }
      }
      structure.Log = this;
    }

    private void BeforeStartPointChanged(object sender, EventArgs e)
    {
      VisualOperation vo = GetVOFromOperation(structure.StartPoint);
      if (vo != null)
        vo.ResetStatus();
    }

    private void AfterStartPointChanged(object sender, EventArgs e)
    {
      VisualOperation vo = GetVOFromOperation(structure.StartPoint);
      if (vo != null)
        vo.SetStartPoint();
    }

    private void BeforeEndPointChanged(object sender, EventArgs e)
    {
      foreach (Table table in surface.Tables)
      {
        VisualOperation vo = (VisualOperation)table;
        if (vo.Operation == structure.Result)
          vo.ResetStatus();
      }
    }

    private void AfterEndPointChanged(object sender, EventArgs e)
    {
      foreach (Table table in surface.Tables)
      {
        VisualOperation vo = (VisualOperation)table;
        if (vo.Operation == structure.Result)
          vo.SetEndPoint();
      }
    }

    private void BeforeOutputPointChanged(object sender, EventArgs e)
    {
      foreach (Table table in surface.Tables)
      {
        VisualOperation vo = (VisualOperation)table;
        if (vo.Operation == structure.OutputPoint)
          vo.ResetStatus();
      }
    }

    private void AfterOutputPointChanged(object sender, EventArgs e)
    {
      foreach (Table table in surface.Tables)
      {
        VisualOperation vo = (VisualOperation)table;
        if (vo.Operation == structure.OutputPoint)
          vo.SetOutputPoint();
      }
    }

    private void BeforeDexChanged(object sender, EventArgs e)
    {
      foreach (Table table in surface.Tables)
      {
        VisualOperation vo = (VisualOperation)table;
        if (vo.Operation == structure.DefaultExceptionHandler)
          vo.ResetStatus();
      }
    }

    internal void AfterDexChanged(object sender, EventArgs e)
    {
      foreach (Table table in surface.Tables)
      {
        VisualOperation vo = (VisualOperation)table;
        if (vo.Operation == structure.DefaultExceptionHandler)
          vo.SetExceptionHandler();
      }
    }
    #endregion

    #region Criação e controle de objetos

    private void OperBtn_Click(object sender, EventArgs e)
    {
      foreach (ToolStripButton btn in tsOperations.Items)
      {
        if (btn != sender)
          btn.Checked = false;
      }
      if (sender != null)
        opClass = (Type)((ToolStripButton)sender).Tag;


      if(MRUList == null)
      {
        MRUList = new List<Type>();
      }

      if(!MRUList.Contains((Type)((ToolStripButton)sender).Tag))
      {
        ToolStripButton senderButton = sender as ToolStripButton;
        ToolStripButton tsb = new ToolStripButton();
        tsb.Text = senderButton.Text;
        tsb.ImageAlign = senderButton.ImageAlign;
        tsb.DisplayStyle = senderButton.DisplayStyle;
        tsb.CheckOnClick = true;
        tsb.ImageTransparentColor = Color.Magenta;
        tsb.Tag = (Type)((ToolStripButton)sender).Tag;
        tsb.Image = senderButton.Image;

        tsb.Click += MRUBtn_Click;

        tsMRU.Items.Add(tsb);

        MRUList.Add((Type)((ToolStripButton)sender).Tag);
      }
    }

    private List<Type> MRUList;

    private void MRUBtn_Click(object sender, EventArgs e)
    {
      foreach (ToolStripButton btn in tsMRU.Items)
      {
        if (btn != sender)
          btn.Checked = false;
      }
      if (sender != null)
        opClass = (Type)((ToolStripButton)sender).Tag;

    }




    private bool TryToCreateVars(float x, float y)
    {
      bool result = false;
      ListViewItem item = null;

      item = CheckLists(lvwVars);
      if (item == null)
        item = CheckLists(lvwResultSets);
      if (item == null)
        item = CheckLists(lvwSchemas);

      if (item != null)
      {
        result = true;
        IOperation var = (IOperation)item.Tag;

        VisualOperation operation = new VisualOperation(surface, var, structure, x, y);
        item.Text = var.Name;
      }

      return result;
    }

    private void VarNameChange(object Sender, EventArgs e)
    {
      IOperation operation = (IOperation)Sender;
      foreach (Table tab in surface.Tables)
      {
        if (((VisualOperation)tab).Operation == operation)
        {
          ((VisualOperation)tab).Caption = operation.Name;
        }
      }

      CheckNames(lvwResultSets, operation);
      CheckNames(lvwVars, operation);
      CheckNames(lvwSchemas, operation);
    }

    private void CheckNames(ListView list, IOperation operation)
    {
      foreach (ListViewItem lvi in list.Items)
      {
        if (lvi.Tag == operation)
        {
          lvi.Text = operation.Name;
          break;
        }
      }
    }


    private ListViewItem CheckLists(ListView list)
    {
      ListViewItem item = null;
      foreach (ListViewItem lvi in list.Items)
      {
        if (lvi.Checked)
        {
          item = lvi;
          break;
        }
      }
      return item;
    }


    private void UnCheckLists(ListView list)
    {
      foreach (ListViewItem lvi in list.Items)
      {
        if (lvi.Checked)
        {
          lvi.Checked = false;
        }
      }
    }

    private string GetNewName()
    {
      string nome = "";
      NameEditorDialog dlg = new NameEditorDialog();
      if (opClass != null)
        dlg.Nome = opClass.Name;


      if (dlg.ShowDialog() == DialogResult.OK)
      {
        if (dlg.Nome == "")
        {
          MessageBox.Show("O nome não pode ser deixado em branco", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
          nome = GetNewName();
        }
        else
        {
          if (!NameValidator.ValidateName(dlg.Nome))
            nome = GetNewName();
          else
          {
            return dlg.Nome;
          }
        }
      }
      return nome;
    }

    private void ResetClassName()
    {
      foreach (ToolStripButton btn in tsOperations.Items)
      {
        btn.Checked = false;
      }

      foreach (ToolStripButton btn in tsMRU.Items)
      {
        btn.Checked = false;
      }

      UnCheckLists(lvwResultSets);
      UnCheckLists(lvwVars);
      UnCheckLists(lvwSchemas);
      opClass = null;
    }


    private VisualOperation GetVOFromOperation(IOperation op)
    {
      VisualOperation result = null;
      foreach (Table table in surface.Tables)
      {
        VisualOperation vo = (VisualOperation)table;
        if (vo.Operation == op)
        {
          result = vo;
          break;
        }
      }
      return result;
    }


    #endregion

    #region Surface Events

    private void Surface_TableClicked(object sender, TableMouseArgs e)
    {
      VisualOperation vo = ((VisualOperation)e.Table);
      UpdateGrid(vo);

    }

    private void UpdateGrid(VisualOperation vo)
    {
      if ((vo != null) && (!loading))
      {
        propertyGrid.SelectedObject = vo.Operation;
      }
      else
        propertyGrid.SelectedObject = null;
    }

    private void Surface_TableDeleted(object sender, TableEventArgs e)
    {
      propertyGrid.SelectedObject = null;
      IsDirty = true;

    }

    private void Surface_ArrowCreating(object sender, AttachConfirmArgs e)
    {

      VisualOperation vo = (VisualOperation)e.Arrow.Origin;
      Color col = Color.Black;
      switch ((PlugType)vo[3, e.Arrow.OrgnIndex].Tag)
      {
        case PlugType.Success:
          col = Color.Green;
          break;
        case PlugType.Failure:
          col = Color.Red;
          break;
        case PlugType.Output:
          col = Color.Gold;
          break;
      }

      e.Arrow.Pen = new MindFusion.Drawing.Pen(col);
      e.Arrow.Brush = new MindFusion.Drawing.SolidBrush(col);
      e.Arrow.ArrowHead = ArrowHead.BowArrow;

    }

    private void Surface_TableDeleting(object sender, TableConfirmArgs e)
    {
      ((VisualOperation)e.Table).Delete();
      IsDirty = true;
    }

    private void Surface_ArrowDeleting(object sender, ArrowConfirmArgs e)
    {
      ((VisualLink)e.Arrow.Tag).Delete();
      IsDirty = true;
    }

    private void Surface_ArrowCreated(object sender, ArrowEventArgs e)
    {
      if (VisualLink.ValidateLink(e.Arrow))
      {
        e.Arrow.Tag = new VisualLink(e.Arrow);
        IsDirty = true;
      }
    }
    private void Surface_DocClicked(object sender, MousePosArgs e)
    {
      {
        if (opClass != null)
        {
          string name = GetNewName();
          if (!string.IsNullOrEmpty(name))
          {
            VisualOperation operation = new VisualOperation(surface, opClass, structure, name, e.X, e.Y);
          }
        }
        else if (!TryToCreateVars(e.X, e.Y))
        {
          propertyGrid.SelectedObject = structure;
        }
      }
      RefreshEntryPoins();
      ResetClassName();

    }

    #endregion

    #region Veriáveis e conexões
    public void CreateListViewItem(string text, object tag, int imageIndex, ListView lvw, bool ensureVisible, bool updateGrid)
    {
      ListViewItem lvi = new ListViewItem(text);
      lvi.ImageIndex = imageIndex;
      lvi.Tag = tag;
      lvi.Checked = false;
      lvw.Items.Add(lvi);
      if (ensureVisible && (!loading))
      {
        lvw.EnsureVisible(lvw.Items.Count - 1);
        lvi.Selected = true;
      }
      if (updateGrid && (!loading))
        propertyGrid.SelectedObject = tag;
      lvw.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
    }


    private void btnNewVar_Click(object sender, EventArgs e)
    {
      string name = GetNewName();
      if (!string.IsNullOrEmpty(name))
      {
        ScalarVar var = new ScalarVar(name, structure);
        CreateVisualVar(var);
      }
    }

    private void btnNewTxtSchema_Click(object sender, EventArgs e)
    {
      string name = GetNewName();
      if (!string.IsNullOrEmpty(name))
      {
        TextSchema schema = new TextSchema(name, structure);
        CreateVisualSchema(schema);
      }
    }

    private void btnNewXMLSchema_Click(object sender, EventArgs e)
    {
      string name = GetNewName();
      if (!string.IsNullOrEmpty(name))
      {
        XMLSchema schema = new XMLSchema(name, structure);
        CreateVisualSchema(schema);
      }
    }


    private void btnKillSchema_Click(object sender, EventArgs e)
    {
      KillObject(lvwSchemas);
    }

    private void btnKillVar_Click(object sender, EventArgs e)
    {
      KillObject(lvwVars);
    }

    private void btnKillResultSet_Click(object sender, EventArgs e)
    {
      KillObject(lvwResultSets);
    }

    private void btnKillConnection_Click(object sender, EventArgs e)
    {
      KillObject(lvwConnections);
    }

    private void KillObject(ListView lvw)
    {
      ListViewItem lvi = null;
      if (lvw.SelectedIndices.Count > 0)
        lvi = lvw.SelectedItems[0];
      else if (lvw.Items.Count > 0)
        lvi = lvw.Items[0];

      if ((lvi != null) && (MessageBox.Show(string.Format("Confirma a exclusão de {0}?", lvi.Text), "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes))
      {
        bool checkBoxes = lvw.CheckBoxes;
        lvw.CheckBoxes = true;

        Object obj = lvi.Tag;
        lvw.Items.Remove(lvi);

        lvw.CheckBoxes = checkBoxes;

        List<VisualOperation> toDelete = new List<VisualOperation>();
        foreach (Table table in surface.Tables)
        {
          VisualOperation vo = (VisualOperation)table;
          if (vo.Operation == obj)
            toDelete.Add(vo);
          if (obj is DynConnection)
          {
            if ((vo.Operation is IConnectedObject) && (((IConnectedObject)vo.Operation).Connection == obj))
              ((IConnectedObject)vo.Operation).Connection = null;
          }
        }

        foreach (VisualOperation vo in toDelete)
        {
          vo.Delete();
          surface.DeleteObject(vo);
        }

        if (obj is ScalarVar)
          structure.ScalarVars.Remove((ScalarVar)obj);
        else if (obj is SchemaEntity)
          structure.Schemas.Remove((SchemaEntity)obj);
        else if (obj is ResultSet)
        {
          structure.ResultSets.Remove((ResultSet)obj);
          DataTable table = null;
          try
          {
            table = ((ResultSet)obj).Table;
          }
          catch (Exception e)
          {
            AddToLog(((ResultSet)obj).Name, e, ((ResultSet)obj));
          }

          if (table != null)
          {
            table.Clear();
            try
            {
              if (structure.Dataset.Tables.Contains(table.TableName))
                structure.Dataset.Tables.Remove(table.TableName);
              table.Dispose();
            }
            catch (Exception e)
            {
              AddToLog(((ResultSet)obj).Name, e, ((ResultSet)obj));
            }
          }

        }
        else if (obj is DynConnection)
          structure.Connections.Remove((DynConnection)obj);

        propertyGrid.SelectedObject = null;
      }
    }

    private void btnNovaConexão_Click(object sender, EventArgs e)
    {
      string newName = GetNewName();
      if (!string.IsNullOrEmpty(newName))
      {
        ConnectionEditorDialog dlg = new ConnectionEditorDialog();
        DynConnection connection = new DynConnection(newName, Structure);
        dlg.Connection = connection;
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          connection = (DynConnection)dlg.Connection;
          structure.Connections.Add(connection);
          CreateVisualConnection(connection);
        }
      }
    }

    internal void CreateVisualConnection(DynConnection connection)
    {
      CreateListViewItem(connection.Name, connection, tabConnections.ImageIndex, lvwConnections, true, true);
      connection.AfterNameChange += ConnectionNameChange;
    }

    private void ConnectionNameChange(object Sender, EventArgs e)
    {
      DynConnection connection = (DynConnection)Sender;
      foreach (ListViewItem lvi in lvwConnections.Items)
      {
        if (lvi.Tag == connection)
        {
          lvi.Text = connection.Name;
          break;
        }
      }
    }

    internal void CreateVisualVar(ScalarVar var)
    {
      CreateListViewItem(var.Name, var, tabVars.ImageIndex, lvwVars, true, true);
      var.AfterNameChange += VarNameChange;
    }

    internal void CreateVisualSchema(SchemaEntity schema)
    {
      int imageIndex;
      if (schema is TextSchema)
        imageIndex = 7;
      else
        imageIndex = 8;

      CreateListViewItem(schema.Name, schema, imageIndex, lvwSchemas, true, true);
      schema.AfterNameChange += VarNameChange;
    }

    private void lvwVars_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      if (e.Item.Checked)
      {
        foreach (ListViewItem lvi in ((ListView)sender).Items)
        {
          if ((lvi != e.Item) && (lvi.Checked))
            lvi.Checked = false;
        }
      }
    }

    private void lvwVars_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ListView)sender).SelectedItems.Count > 0)
      {
        propertyGrid.SelectedObject = ((ListView)sender).SelectedItems[0].Tag;
      }
    }

    private void btnNewResultSet_Click(object sender, EventArgs e)
    {
      string name = GetNewName();
      if (!string.IsNullOrEmpty(name))
      {
        ResultSet var = new ResultSet(name, structure);
        CreateVisualResultSet(var);
      }
    }

    internal void CreateVisualResultSet(ResultSet var)
    {
      CreateListViewItem(var.Name, var, tabResultsets.ImageIndex, lvwResultSets, true, true);
      var.AfterNameChange += VarNameChange;
    }

    private void lvwResultSets_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (e.NewValue == CheckState.Checked)
        ResetClassName();
    }

    private void btnTestConnection_Click(object sender, EventArgs e)
    {
      if (lvwConnections.SelectedItems.Count != 0)
      {
        DynConnection connection = (DynConnection)lvwConnections.SelectedItems[0].Tag;
        connection.Open();
        connection.Close();
        MessageBox.Show("Teste bem sucedido da conexão " + connection.Name);
      }
    }

    private void lvwLog_DoubleClick(object sender, EventArgs e)
    {
      ListView lvw = (ListView)sender;
      if (lvw.SelectedItems.Count > 0)
      {
        ListViewItem lvi = lvw.SelectedItems[0];
        if ((lvi.Tag != null) && (lvi.Tag is IOperation))
        {
          if (lvi.Tag is IEntity)
          {
            ListView lvwTest;
            if (lvi.Tag is ScalarVar)
            {
              lvwTest = lvwVars;
              tbcVars.SelectedTab = tabVars;
            }
            else if (lvi.Tag is ResultSet)
            {
              lvwTest = lvwResultSets;
              tbcVars.SelectedTab = tabResultsets;
            }
            else
            {
              lvwTest = lvwSchemas;
              tbcVars.SelectedTab = tabSchemas;
            }

            for (int i = 0; i < lvwTest.Items.Count; i++)
            {
              if (lvwTest.Items[i].Tag == lvi.Tag)
              {
                lvwTest.Focus();
                lvwTest.EnsureVisible(i);
                lvwTest.Items[i].Selected = true;
                break;
              }
            }
          }
          else
          {
            IOperation oper = (IOperation)lvi.Tag;
            VisualOperation vo = GetVOFromOperation(oper);
            surface.BringIntoView(vo);
            surface.Selection.Clear();
            surface.Selection.AddObject(vo);
            UpdateGrid(vo);
          }
        }
      }
    }

    private void btnCreateResultsets_Click(object sender, EventArgs e)
    {
      if (lvwConnections.Items.Count > 0)
      {
        DynConnection connection;
        if (lvwConnections.SelectedItems.Count != 0)
          connection = (DynConnection)lvwConnections.SelectedItems[0].Tag;
        else
          connection = (DynConnection)lvwConnections.Items[0].Tag;

        CreateTableDialog dlg = new CreateTableDialog();
        if (dlg.Execute(connection, structure) == DialogResult.OK)
        {
          lvwResultSets.Items.Clear();
          for (int i = 0; i < structure.ResultSets.Count; i++)
          {
            CreateVisualResultSet(structure.ResultSets[i]);
          }
          tbcVars.SelectedTab = tabResultsets;
        }
      }
      else
      {
        MessageBox.Show("Não existem conexões no projeto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnCreateSchemaRS_Click(object sender, EventArgs e)
    {
      if (lvwSchemas.SelectedItems.Count != 0)
      {
        SchemaEntity schema = (SchemaEntity)lvwSchemas.SelectedItems[0].Tag;
        DialogResult result = MessageBox.Show("Confirma a criação dos resultsets?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
          schema.CreateResultSets();
          RefreshSchemas();
        }
      }
    }

    private void btnCreateAll_Click(object sender, EventArgs e)
    {
      DialogResult result = MessageBox.Show("Confirma a criação de todos os resultsets?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (result == DialogResult.Yes)
      {
        for (int i = 0; i < Structure.Schemas.Count; i++)
        {
          Structure.Schemas[i].CreateResultSets();
        }
        RefreshSchemas();
      }
    }

    private void RefreshSchemas()
    {
      lvwResultSets.Items.Clear();
      for (int i = 0; i < structure.ResultSets.Count; i++)
      {
        CreateVisualResultSet(structure.ResultSets[i]);
      }
      tbcVars.SelectedTab = tabResultsets;
    }


    private void btnClearBreakpoints_Click(object sender, EventArgs e)
    {
      foreach (Operation oper in structure.Operations)
      {
        oper.BreakPoint = false;
      }
      PaintBreakPoints();
    }

    private void btnDeleteBreakPoint_Click(object sender, EventArgs e)
    {
      if (surface.Selection.Tables.Count != 0)
      {
        VisualOperation vo = (VisualOperation)surface.Selection.Tables[0];
        if (vo.Operation is Operation)
          ((Operation)vo.Operation).BreakPoint = false;
      }
      else
      {
        if ((lvwBreakPoints.SelectedItems.Count == 0) && (lvwBreakPoints.Items.Count > 0))
          lvwBreakPoints.SelectedIndices.Add(0);

        foreach (ListViewItem lvi in lvwBreakPoints.SelectedItems)
        {
          if (lvi.Tag is Operation)
          {
            ((Operation)lvi.Tag).BreakPoint = false;
          }
        }
      }
      PaintBreakPoints();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      FindOperation();
    }


    #endregion

    #region Persistência
#if !Demo
    private void SaveStructure(string fileName)
    {
      PersistenceStructure.SaveStructure(fileName, structure, surface, outputPath);
    }
#endif
    internal bool loading;
    private void LoadStructure(string fileName)
    {
      PersistenceStructure.LoadStructure(fileName, surface, outputPath, this);
    }

    internal void RefreshEntryPoins()
    {
      BeforeEndPointChanged(null, null);
      AfterEndPointChanged(null, null);
      BeforeStartPointChanged(null, null);
      AfterStartPointChanged(null, null);
      BeforeOutputPointChanged(null, null);
      AfterOutputPointChanged(null, null);
    }

    [KeyAction(Modifiers.ControlShift, Keys.S)]
    private void SaveSnapshot()
    {
      IsDirty = false;
      bool backupStatus = AutoBackup;
      AutoBackup = false;
      string tmpFileName = FileName;
      if (!string.IsNullOrEmpty(FileName))
      {
        FileName = Application.StartupPath + "\\Backup\\";
        if (!Directory.Exists(FileName))
          Directory.CreateDirectory(FileName);



        DateTime now = DateTime.Now;
        FileName = Path.Combine(FileName, "Bkp_" + Path.GetFileNameWithoutExtension(tmpFileName));



        string dia = Convert.ToString(now.Day).PadLeft(2, '0');
        string mes = Convert.ToString(now.Month).PadLeft(2, '0');
        string hora = Convert.ToString(now.Hour).PadLeft(2, '0');
        string minuto = Convert.ToString(now.Minute).PadLeft(2, '0');
        string segundo = Convert.ToString(now.Second).PadLeft(2, '0');


        FileName = String.Format("{0} {1}-{2}-{3} {4}{5}{6}.IRIS", new object[] { FileName, now.Year, mes, dia, hora, minuto, segundo });

#if !Demo

        Save(false);
#else
        AddToLog("A gravação de backups automáticos está desabilitada para a versão de demonstração ", null);
#endif
      }
      FileName = tmpFileName;
      AutoBackup = backupStatus;

    }


    #endregion

    #region ToolBar Commands

    private void btnNewProj_Click(object sender, EventArgs e)
    {
      structure = new Structure();
      InitStructure();
      FileName = "";
      ClearAll();
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
      RunAll();
    }

    [KeyAction(Keys.F5)]
    private void RunAll()
    {
      SaveSnapshot();
      Run();
    }

    private void Run()
    {
      bool bkpStatus = AutoBackup;
      tbcOutput.SelectedTab = tabOutput;
      AutoBackup = false;
      ClearLog();
      structure.Execute(true);
      AutoBackup = bkpStatus;
    }

    private void btnStep_Click(object sender, EventArgs e)
    {
      Step();
    }
    [KeyAction(Keys.F10)]
    private void Step()
    {
      bool bkpStatus = AutoBackup;
      AutoBackup = false;

      structure.Step();
      VisualOperation vo = GetVOFromOperation(structure.RunningOper);
      if (vo != null)
      {
        if ((structure.RunningOper.Status != ExecutionStatus.Failure) && (structure.RunningOper.Status != ExecutionStatus.Success))
          vo.SetColor(Color.Gold);
        if (vo.Operation != structure.StartPoint)
          surface.BringIntoView(vo);
      }


      AutoBackup = bkpStatus;

    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      Stop();
    }

    [KeyAction(Keys.Pause)]
    private void Stop()
    {
      Structure.Stop = true;
    }

    private void btnRestart_Click(object sender, EventArgs e)
    {
      Restart();
    }


    private void btnBreakPoint_Click(object sender, EventArgs e)
    {
      ToggleBreakPoint();
    }
    [KeyAction(Keys.F3)]
    private void Restart()
    {
      ClearLog();
      structure.Restart();
      txtNotes_Validated(this, EventArgs.Empty);
      propertyGrid.SelectedObject = null;
      PaintBreakPoints();
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        LoadStructure(openFileDialog.FileName);
        FileName = openFileDialog.FileName;
        structure.Log = this;
        AutoBackup = true;
      }
    }


#if Licensed
    private Manager manager;

    public Manager Manager
    {
      get
      {
        if (manager == null)
          manager = new Manager();
        return manager; 
      }
    }
#endif

    private string fileName;

    public string FileName
    {
      get { return fileName; }
      set
      {
        fileName = value;

        string version = GetVersion(this.GetType().Assembly);
#if Licensed

        if (!string.IsNullOrEmpty(fileName))
        {
          this.Text = String.Format("IRIS V.{1} - ({0})  -  Licenciado para {2}", fileName.Substring(fileName.LastIndexOf('\\') + 1),
            version, Manager.LoadValue("Organização"));
        }
        else
          this.Text = "IRIS - Information  Retrieval and Integration System V." + version+"  -  Licenciado para "+Manager.LoadValue("Organização");

#else
        if (!string.IsNullOrEmpty(fileName))
        {
          this.Text = String.Format("IRIS V.{1} - ({0})", fileName.Substring(fileName.LastIndexOf('\\') + 1), version);
        }
        else
          this.Text = "IRIS - Information  Retrieval and Integration System V." + version;
#endif
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      Save();
    }

    [KeyAction(Modifiers.Control, Keys.S)]
    private void Save()
    {
      Save(false);
    }
    [KeyAction(Modifiers.ControlAlt, Keys.S)]
    private void SaveAs()
    {
      Save(true);
    }

    private void Save(bool saveAs)
    {
      bool bkpStatus = AutoBackup;
      AutoBackup = false;

      if ((string.IsNullOrEmpty(FileName)) || saveAs)
      {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileName = saveFileDialog.FileName;
        }
      }

#if !Demo
      if (!string.IsNullOrEmpty(FileName))
      {
        Restart();
        SaveStructure(FileName);
        AddToLog("Arquivo gravado em: " + FileName, null);
      }
#else
      AddToLog("A gravação de arquivos está desabilitada para a versão de demonstração", null);
#endif
      AutoBackup = bkpStatus;

      IsDirty = false;
    }


    private void btnSaveAs_Click(object sender, EventArgs e)
    {
      Save(true);
    }

    private void btnHideOut_Click(object sender, EventArgs e)
    {
      tbcOutput.Visible = btnHideOut.Checked;
    }

    private void btnHideVars_Click(object sender, EventArgs e)
    {
      SetVarsVisibility();
    }

    private void SetVarsVisibility()
    {
      tbcVars.Visible = btnHideVars.Checked;
      RefreshTbcOutput();
    }

    private void btnHideTools_Click(object sender, EventArgs e)
    {
      SetToolsVisibility();
    }

    private void SetToolsVisibility()
    {
      tbcTools.Visible = btnHideTools.Checked;
      RefreshTbcOutput();
    }


    private void btnResetOperation_Click(object sender, EventArgs e)
    {
      ResetOp();
    }

    [KeyAction(Keys.F6)]
    private void ResetOp()
    {
      if (surface.Selection.Tables.Count > 0)
      {
        VisualOperation vo = (VisualOperation)surface.Selection.Tables[0];
        if (vo.Operation is Operation)
        {
          ((Operation)vo.Operation).Status = ExecutionStatus.WaitingExecution;
        }
      }
      PaintBreakPoints();
    }

    private void btnSetRunningPoint_Click(object sender, EventArgs e)
    {
      SetRunningPoint();
    }
    [KeyAction(Keys.F7)]
    private void SetRunningPoint()
    {
      if (surface.Selection.Tables.Count > 0)
      {
        VisualOperation vo = (VisualOperation)surface.Selection.Tables[0];
        if (vo.Operation is Operation)
          structure.RunningOper = ((Operation)vo.Operation);
      }
    }

    private void cbxZoom_SelectedIndexChanged(object sender, EventArgs e)
    {
      string factor = cbxZoom.Text.TrimEnd('%');
      surface.ZoomFactor = Convert.ToSingle(factor);
      PaintBreakPoints();
    }

    private void btnZoomOut_Click(object sender, EventArgs e)
    {
      int i = cbxZoom.SelectedIndex + 1;
      if (i < cbxZoom.Items.Count)
        cbxZoom.SelectedIndex = i;
    }

    private void btnZoomIn_Click(object sender, EventArgs e)
    {
      int i = cbxZoom.SelectedIndex - 1;
      if (i >= 0)
        cbxZoom.SelectedIndex = i;
    }

    private void btnZoomActual_Click(object sender, EventArgs e)
    {
      cbxZoom.SelectedIndex = 3;
    }

    private void btnRunToSelection_Click(object sender, EventArgs e)
    {
      RunToSelection();
    }

    private void btnReRun_Click(object sender, EventArgs e)
    {
      ReRun();
    }

    #endregion

    #region ILoggable Members

    public IProccessLog Log
    {
      get
      {
        return this;
      }
      set
      {
      }
    }

    #endregion

    #region IProccessLog Members

    private List<ILogItem> entries;

    public void AddToLog(string logEntry, IOperation operation)
    {
      Write(logEntry, false, operation);

      string opName = "";
      if (operation != null)
        opName = operation.Name;

      entries.Add(new LogItem(logEntry, opName));
    }

    private void Write(string logEntry, bool error, IOperation operation)
    {
      DateTime time = DateTime.Now;
      string text = string.Format("{0} -> {1}", time.ToString(), logEntry);
      string fileText = text;


      int imageIndex;
      if (error)
      {
        imageIndex = 1;
        fileText = "X - " + fileText;
      }
      else
      {
        imageIndex = 0;
        fileText = "V - " + fileText;
      }
      CreateListViewItem(text, operation, imageIndex, lvwLog, true, false);

      if (error)
        stlLastLog.ForeColor = Color.Red;
      else
        stlLastLog.ForeColor = Color.Black;

      string statusLog = logEntry;

      if (statusLog.Contains("\r"))
        statusLog = statusLog.Remove(statusLog.IndexOf('\r')).Trim();

      if (structure.StartPoint != null)
        WriteLogToFile(fileText, ((operation == structure.StartPoint) && (lastOperationToLog != operation)));


      lastOperationToLog = operation;

      stlLastLog.Text = statusLog;
      stlLastLog.Invalidate();
    }

    private IOperation lastOperationToLog;

    private void WriteLogToFile(string fileText, bool reset)
    {
      string logFileName = Path.Combine(Application.StartupPath, "Exec_Log", "exec_" + Path.GetFileNameWithoutExtension(FileName) + ".log");

      string logPath = Path.GetDirectoryName(logFileName);
      if (!Directory.Exists(logPath))
        Directory.CreateDirectory(logPath);

      if (reset)
        fileText = "===================== Nova Execução =====================" + Environment.NewLine + fileText;

      using (StreamWriter sw = new StreamWriter(logFileName, true))
      {
        sw.WriteLine(fileText);
      }
    }



    public void AddToErrorLog(string logEntry, IOperation operation)
    {
      Write(logEntry, true, operation);

      string opName = "";
      if (operation != null)
        opName = operation.Name;

      LogItem item = new LogItem(logEntry, opName);
      item.Error = true;
      entries.Add(item);
    }

    public void AddToLog(string aName, Exception e, IOperation operation)
    {
      string logEntry = "Falha na execução de [" + aName + "]. Mensagem original: " + GetFullErrorMessage(e);
      Write(logEntry, true, operation);

      string opName = "";
      if (operation != null)
        opName = operation.Name;

      LogItem item = new LogItem(logEntry, e, opName);
      item.Error = true;
      entries.Add(item);
    }

    public void ClearLog()
    {
      lvwLog.Items.Clear();
      entries = new List<ILogItem>();
      stlLastLog.Text = "";
    }

    public List<ILogItem> GetEntries()
    {
      return entries;
    }

    /// <summary>
    /// Retorna a mensagem de erro completa, incluindo possíveis excessões internas
    /// </summary>
    /// <param name="e">Exception</param>
    /// <returns></returns>
    private string GetFullErrorMessage(Exception e)
    {
      string msg = e.Message;
      if (e.InnerException != null)
        msg += " | " + GetFullErrorMessage(e.InnerException);
      return msg;
    }

    #endregion





    private void btnClearLog_Click(object sender, EventArgs e)
    {
      ClearLog();
    }

    private void btnCreateLineType_Click(object sender, EventArgs e)
    {
      if (lvwSchemas.SelectedItems.Count > 0)
      {
        TextSchema schema = lvwSchemas.SelectedItems[0].Tag as TextSchema;
        if (schema != null)
        {
          CreateLineTypeDialog dlg = new CreateLineTypeDialog();
          dlg.Execute(structure, schema);
        }
      }
    }

    private void btnSaveSchemas_Click(object sender, EventArgs e)
    {
      SelectSchemasDialog dlg = new SelectSchemasDialog();
      List<SchemaEntity> list = dlg.SelectSchemas(Structure.Schemas);
      if (list.Count > 0)
      {
        if (saveSchemaFileDialog.ShowDialog() == DialogResult.OK)
        {
          for (int i = 0; i < list.Count; i++)
          {
            list[i].ClearTables();
          }
          string filename = saveSchemaFileDialog.FileName;
          PersistenceManager<List<SchemaEntity>>.SaveToFile(filename, list);
        }
      }
    }

    private void btnLoadSchemas_Click(object sender, EventArgs e)
    {
      if (openSchemaFileDialog.ShowDialog() == DialogResult.OK)
      {
        string filename = openSchemaFileDialog.FileName;
        List<SchemaEntity> list = PersistenceManager<List<SchemaEntity>>.LoadFromFile(filename, Structure.TypeLookupTable);
        for (int i = 0; i < list.Count; i++)
        {
          list[i].Structure = this.Structure;
          list[i].ClearTables();
          this.Structure.Schemas.Add(list[i]);
        }

        lvwSchemas.Items.Clear();
        for (int i = 0; i < structure.Schemas.Count; i++)
        {
          CreateVisualSchema(structure.Schemas[i]);
        }
      }
    }

    private void btnSaveSnapshot_Click(object sender, EventArgs e)
    {
      SaveSnapshot();
    }

    private void statusStrip1_Click(object sender, EventArgs e)
    {
      stlLastLog.Text = "";
    }

    #region IStructureDesigner Members


    IStructure IStructureDesigner.Structure
    {
      get { return this.Structure; }
    }

    public IVisualOperation[] GetSelectedOperations()
    {
      List<IVisualOperation> list = new List<IVisualOperation>();
      foreach (Table vOp in surface.Selection.Tables)
      {
        if (vOp is VisualOperation)
        {
          list.Add((IVisualOperation)vOp);
        }
      }
      return list.ToArray();
    }

    public IVisualOperation GetSelectedOperation()
    {
      if (surface.Selection.Tables.Count > 0)
      {
        return surface.Selection.Tables[0] as VisualOperation;
      }
      else
        return null;
    }

    public void AddToolBarButton(ToolStripButton button)
    {
      tbMain.Items.Add(button);
    }

    public void RemoveToolBarButton(ToolStripButton button)
    {
      tbMain.Items.Remove(button);
    }


    #endregion


    private void btnToggleSnapshot_Click(object sender, EventArgs e)
    {
      AutoBackup = !btnToggleSnapshot.Checked;
    }

    private bool autoBackup;

    public bool AutoBackup
    {
      get { return autoBackup; }
      set
      {
        autoBackup = value;
        if (autoBackup)
          btnToggleSnapshot.Image = Resources.ToggleSnapshotOn;
        else
          btnToggleSnapshot.Image = Resources.ToggleSnapshotOff;

        bkpTimer.Enabled = autoBackup;
      }
    }

    private void surface_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Middle)
      {
        float y = surface.ClientToDoc(new Point(e.X, e.Y)).Y;

        surface.Selection.Clear();
        for (int i = 0; i < surface.Tables.Count; i++)
        {
          Table table = surface.Tables[i];
          if (table.BoundingRect.Y >= y)
            surface.Selection.AddObject(table);
        }
      }
    }

    private void btnEditConnection_Click(object sender, EventArgs e)
    {
      if (lvwConnections.Items.Count > 0)
      {
        DynConnection connection;
        if (lvwConnections.SelectedItems.Count != 0)
          connection = (DynConnection)lvwConnections.SelectedItems[0].Tag;
        else
          connection = (DynConnection)lvwConnections.Items[0].Tag;
        ConnectionEditorDialog dlg = new ConnectionEditorDialog();
        dlg.Connection = connection;
        dlg.ShowDialog();
      }
      RefreshPropertyGrid();
    }

    private void btnDisableAll_Click(object sender, EventArgs e)
    {
      Structure.DisableConnections();
      AddToLog("Conexões de banco desabilitadas para teste", null);
      RefreshPropertyGrid();
    }

    private void btnEnableAll_Click(object sender, EventArgs e)
    {
      Structure.EnableConnections();
      RefreshPropertyGrid();
    }

    private void RefreshPropertyGrid()
    {
      object selectedObject = propertyGrid.SelectedObject;
      txtNotes_Validated(this, EventArgs.Empty);

      propertyGrid.SelectedObject = null;
      propertyGrid.SelectedObject = selectedObject;
    }

    private void txtNotes_Validated(object sender, EventArgs e)
    {
      if (propertyGrid.SelectedObject is IOperation)
      {
        ((IOperation)propertyGrid.SelectedObject).Notes = txtNotes.Text;
      }
      else if (propertyGrid.SelectedObject is DynConnection)
      {
        ((DynConnection)propertyGrid.SelectedObject).Notes = txtNotes.Text;
      }
      else if (propertyGrid.SelectedObject == Structure)
      {
        Structure.Notes = txtNotes.Text;
      }

    }

    private void propertyGrid_SelectedObjectsChanged(object sender, EventArgs e)
    {
      txtNotes.Enabled = true;
      txtNotes.Text = "";

      if (propertyGrid.SelectedObject is IOperation)
      {
        txtNotes.Text = ((IOperation)propertyGrid.SelectedObject).Notes;
      }
      else if (propertyGrid.SelectedObject is DynConnection)
      {
        txtNotes.Text = ((DynConnection)propertyGrid.SelectedObject).Notes;
      }
      else if (propertyGrid.SelectedObject == Structure)
      {
        txtNotes.Text = Structure.Notes;
      }
      else
      {
        txtNotes.Enabled = false;
      }
    }

    private void btnSaveLog_Click(object sender, EventArgs e)
    {
      if (saveLogDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        List<ILogItem> log = Structure.Log.GetEntries();

        using (StreamWriter sw = new StreamWriter(saveLogDialog.FileName, false, Encoding.Default))
        {
          foreach (LogItem item in log)
          {
            string logMark = item.Error ? "X" : "V";
            string logLine = string.Format("{0} - {1}", logMark, item.Text);
            sw.WriteLine(logLine);
          }
        }

        MessageBox.Show("Log gravado com sucesso.");
      }
    }

    private bool isDirty;

    public bool IsDirty
    {
      get { return isDirty; }
      set
      {
        if (isDirty != value)
        {
          isDirty = value;
          this.Text = this.Text.TrimEnd('*');
          if (isDirty)
            this.Text += "*";
        }
      }
    }

    private void surface_TableCreated(object sender, TableEventArgs e)
    {
      IsDirty = true;

    }


    private void surface_SelectionChanged(object sender, EventArgs e)
    {

      Object[] objs = new object[surface.Selection.Tables.Count];
      for (int i = 0; i < surface.Selection.Tables.Count; i++)
      {
        objs[i] = surface.Selection.Tables[i].Tag;
      }
      FillOldCoords();

      if (!loading)
        propertyGrid.SelectedObjects = objs;
    }

    Dictionary<Table, System.Drawing.PointF> oldCoords;

    private void FillOldCoords()
    {
      oldCoords = new Dictionary<Table, PointF>();

      for (int i = 0; i < surface.Selection.Tables.Count; i++)
      {
        oldCoords[surface.Selection.Tables[i]] = new PointF(surface.Selection.Tables[i].BoundingRect.Left,
          surface.Selection.Tables[i].BoundingRect.Top);
      }
    }

    private void surface_TableModified(object sender, TableMouseArgs e)
    {
      IsDirty = true;
      if (!actionManager.ActionsLocked)
      {
        actionManager.AddToUndoStack(new MovementAction(new Table[] { e.Table }, oldCoords));
        FillOldCoords();
      }
    }

    private void surface_SelectionMoved(object sender, EventArgs e)
    {
      if (!actionManager.ActionsLocked)
      {
        List<Table> tables = new List<Table>();
        for (int i = 0; i < surface.Selection.Tables.Count; i++)
        {
          tables.Add(surface.Selection.Tables[i]);
        }

        actionManager.AddToUndoStack(new MovementAction(tables.ToArray(), oldCoords));
        FillOldCoords();
      }
    }



  }
}