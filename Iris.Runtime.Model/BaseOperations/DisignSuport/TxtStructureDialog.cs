using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Model;
using Iris.PropertyEditors.Dialogs;
using ImpDialogs;
using Iris.Designer.Dialogs;
using Iris.Runtime.Model.DisignSuport;
using Databridge.Interfaces.BaseEditors;
using System.IO;

namespace Iris.Runtime.Model.DesignuSuport
{
  /// <summary>
  /// Diálogo de edição de propriedades para edição de estrutura de arquivos txt
  /// </summary>
  public partial class TxtStructureDialog : BaseDialog
  {
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="T:TxtStructureDialog"/>.
    /// </summary>
    public TxtStructureDialog()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Executa o diálogo para editar a estrutura da conexão passada como argumento
    /// </summary>
    /// <param name="aConnection">A conexão cuja estrutura será editada.</param>
    /// <returns></returns>
    public DialogResult Execute(TextSchema _file)
    {
      file = _file;
      RefreshTreeView(null);
      return ShowDialog();
    }

    private TextSchema file;


    /// <summary>
    /// Creates the table.
    /// </summary>
    private void CreateTable()
    {
      TextLine line = new TextLine(file);
      RefreshTreeView(line);
    }

    /// <summary>
    /// Re-cria a treeview.
    /// Este método é recursivo e deve receber a tabela raiz como argumetno para iniciar a criação.
    /// </summary>
    /// <param name="tabela">A tabela a partir da qual a treeView será recriada.</param>
    private void RefreshTreeView(TextLine line)
    {
      tvStructure.Nodes.Clear();
      CreateNodes(file.LineTypes, tvStructure.Nodes);
      if (line != null)
      {
        TreeNode node = TreeViewControl.FindObjectNode(line, tvStructure.Nodes);
        TreeViewControl.ExpandNode(node);
        tvStructure.SelectedNode = node;
      }
      prgProperties.SelectedObject = line;
    }

    /// <summary>
    /// Cria nodes na árvore
    /// </summary>
    /// <param name="tabelas">A lista de tabelas.</param>
    /// <param name="Nodes">A coleção de nodes que deve servir de referência.</param>
    private void CreateNodes(List<TextLine> lines, TreeNodeCollection Nodes)
    {
      foreach (TextLine line in lines)
      {
        TreeNode node = new TreeNode(line.Name);
        node.Tag = line;
        Nodes.Add(node);
        CreateNodes(line.Details, node.Nodes);
      }
    }

    /// <summary>
    /// Atualiza o PropertyGrid
    /// </summary>
    private void UpdateGrid()
    {
      if (this.ActiveControl == tvStructure)
      {
        prgProperties.SelectedObject = GetSelectedLine();
      }
      else if (this.ActiveControl == lbxFields)
        prgProperties.SelectedObject = lbxFields.SelectedItem;
    }

    /// <summary>
    /// Determina um treeNode a partir das coordenadas x,y
    /// </summary>
    /// <param name="x">Coordenada x.</param>
    /// <param name="y">Coordenada y.</param>
    /// <returns></returns>
    protected TreeNode FindTreeNode(int x, int y)
    {
      x = x - (grpStruct.Left);
      y = y - tvStructure.Top;
      Point pt = new Point(x, y);
      pt = PointToClient(pt);

      return TreeViewControl.FindTreeNode(pt, tvStructure.Nodes);
    }

    #region Eventos de Drag'n'Drop

    /// <summary>
    /// Node que está sendo arrastado
    /// </summary>
    private TreeNode dragNode;
    /// <summary>
    /// Início da ação de drag
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tvStructure_ItemDrag(object sender, ItemDragEventArgs e)
    {
      if (tvStructure.SelectedNode != null)
      {
        dragNode = tvStructure.SelectedNode;
        DoDragDrop(tvStructure.SelectedNode, DragDropEffects.Move);
      }
    }
    /// <summary>
    /// Validação dos locais onde pode ser feito o drop
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tvStructure_DragOver(object sender, DragEventArgs e)
    {
      TreeNode node = FindTreeNode(e.X, e.Y);

      bool nullNodes = (dragNode == null) || (node == null);
      bool sameTable = false;
      if ((!nullNodes) && ((dragNode.Tag != null) && (node.Tag != null)))
        sameTable = ((TextLine)dragNode.Tag).Name == ((TextLine)node.Tag).Name;

      if ((dragNode == null) || (node == null) || (!(dragNode.Tag is TextLine)) || sameTable)
      {
        e.Effect = DragDropEffects.None;
      }
      else
        e.Effect = DragDropEffects.Move;
    }

    /// <summary>
    /// Ação de drop
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tvStructure_DragDrop(object sender, DragEventArgs e)
    {
      if (e.Effect == DragDropEffects.Move)
      {
        TextLine mestre = (TextLine)FindTreeNode(e.X, e.Y).Tag;
        TextLine detalhe = (TextLine)dragNode.Tag;
        if (CreateLink(mestre, detalhe) == DialogResult.OK)
        {
          RefreshTreeView(detalhe);
        }
      }
      dragNode = null;
    }

    private DialogResult CreateLink(TextLine mestre, TextLine detalhe)
    {
      RelationEditorDialog dlg = new RelationEditorDialog();
      Dictionary<string, string> relation = new Dictionary<string, string>();
      DialogResult result = dlg.CreateRelation(mestre.Name, mestre.GetFieldList(), detalhe.Name, detalhe.GetFieldList(), ref relation);
      if (result == DialogResult.OK)
      {
        detalhe.Link = relation;
        detalhe.Master = mestre;
      }

      return result;
    }
    #endregion

    /// <summary>
    /// Handles the AfterSelect event of the tvStructure control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
    private void tvStructure_AfterSelect(object sender, TreeViewEventArgs e)
    {
      RefreshListView();
      UpdateGrid();
    }

    private void RefreshListView()
    {
      TextLine line = GetSelectedLine();
      string selectedField = lbxFields.Text;
      int idx = -1;
      if (line != null)
      {
        lbxFields.Items.Clear();
        for (int i = 0; i < line.Fields.Count; i++)
        {
          lbxFields.Items.Add(line.Fields[i]);
          if (selectedField == line.Fields[i].Name)
            idx = lbxFields.Items.IndexOf(line.Fields[i]);
        }
        lbxFields.SelectedIndex = idx;
      }
      else
        lbxFields.Items.Clear();
    }

    /// <summary>
    /// Handles the KeyUp event of the tvStructure control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    private void tvStructure_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Delete)
        doRemoveNode();
    }

    /// <summary>
    /// Método interno de remoção de nodes da árvore
    /// </summary>
    private void doRemoveNode()
    {
      if (tvStructure.SelectedNode != null)
      {
        TextLine line = GetSelectedLine();
        if (line != null)
        {
          line.Master = null;
          file.LineTypes.Remove(line);
        }
      }
      RefreshTreeView(null);
      RefreshListView();
      prgProperties.SelectedObject = null;
    }

    /// <summary>
    /// Handles the Click event of the btnExcluir control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void btnExcluir_Click(object sender, EventArgs e)
    {
      doRemoveNode();

    }


    /// <summary>
    /// Handles the PropertyValueChanged event of the prgProperties control.
    /// </summary>
    /// <param name="s">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.Windows.Forms.PropertyValueChangedEventArgs"/> instance containing the event data.</param>
    private void prgProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      if (prgProperties.SelectedObject is TextLine)
      {
        RefreshTreeView((TextLine)prgProperties.SelectedObject);
      }
      else
      {
        RefreshListView();
      }
    }

    /// <summary>
    /// Handles the Click event of the btnCreate control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void btnCreate_Click(object sender, EventArgs e)
    {
      TextLine line = new TextLine(file);
      RefreshTreeView(line);
    }

    /// <summary>
    /// Handles the Click event of the btnClear control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void btnClear_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Confirma a exclusão de todos os tipos de linha?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
      {
        file.LineTypes.Clear();
        RefreshTreeView(null);
        lbxFields.Items.Clear();
      }
    }

    /// <summary>
    /// Handles the Click event of the btnMoveUp control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void btnMoveUp_Click(object sender, EventArgs e)
    {
      MoveLine(-1);
    }

    /// <summary>
    /// Handles the Click event of the btnMoveDown control.
    /// </summary>
    /// <param name="sender">O objeto fonte do evento</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    private void btnMoveDown_Click(object sender, EventArgs e)
    {
      MoveLine(1);
    }

    /// <summary>
    /// Move a tabela selecionada para cima ou para baixo em sua lista
    /// </summary>
    /// <param name="mov">The mov.</param>
    private void MoveLine(int mov)
    {
      TextLine line = GetSelectedLine();
      List<TextLine> lista;
      if (line != null)
      {

        if (line.Master == null)
          lista = file.LineTypes;
        else
          lista = line.Master.Details;

        int idx = lista.IndexOf(line) + mov;
        if ((idx >= 0) && (idx < lista.Count))
        {
          TextLine tab2 = lista[idx];
          lista[idx] = line;
          lista[idx - mov] = tab2;
        }
        RefreshTreeView(line);
      }
    }

    private void MoveField(int mov)
    {
      TextLine line = GetSelectedLine();
      TextField field = GetSelectedField();
      if ((line != null) && (field != null))
      {

        int idx = line.Fields.IndexOf(field) + mov;
        if ((idx >= 0) && (idx < line.Fields.Count))
        {
          TextField field2 = line.Fields[idx];
          line.Fields[idx] = field;
          line.Fields[idx - mov] = field2;
        }
        RefreshListView();
      }
    }

    private TextLine GetSelectedLine()
    {
      if (tvStructure.SelectedNode != null)
      {
        TextLine line = ((TextLine)(tvStructure.SelectedNode.Tag));
        return line;
      }
      else
        return null;
    }


    private void btnNewField_Click(object sender, EventArgs e)
    {
      CreateNewField();
      prgProperties.Focus();
    }

    private TextField CreateNewField()
    {
      TextLine line = GetSelectedLine();
      int idx = lbxFields.SelectedIndex;
      if (line != null)
      {
        TextField field;
        if (idx != -1)
          field = new TextField(line, idx + 1);
        else
          field = new TextField(line);
        RefreshListView();
        this.ActiveControl = lbxFields;
        lbxFields.SelectedItem = field;
        UpdateGrid();
        return field;
      }
      return null;
    }

    private void btnDeleteField_Click(object sender, EventArgs e)
    {
      TextField field = GetSelectedField();
      TextLine line = GetSelectedLine();
      int idx = lbxFields.SelectedIndex;
      if ((line != null) && (field != null))
      {
        line.Fields.Remove(field);
        RefreshListView();
        UpdateGrid();
        if (idx >= lbxFields.Items.Count)
          idx--;
        lbxFields.SelectedIndex = idx;
        lbxFields.Focus();
      }
    }

    private TextField GetSelectedField()
    {
      TextField field = (TextField)lbxFields.SelectedItem;
      return field;
    }



    private void lbxFields_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateGrid();
    }

    private void btnMoveFieldUp_Click(object sender, EventArgs e)
    {
      MoveField(-1);
    }

    private void btnMoveFieldDown_Click(object sender, EventArgs e)
    {
      MoveField(1);
    }

    private void btnClearFields_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Confirma a exclusão de todos os campos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
      {
        if (GetSelectedLine() != null)
        {
          GetSelectedLine().Fields.Clear();
        }

        RefreshListView();
        UpdateGrid();
      }
    }

    private void tvStructure_Enter(object sender, EventArgs e)
    {
      UpdateGrid();
    }

    private void lbxFields_Enter(object sender, EventArgs e)
    {
      if ((lbxFields.SelectedItem == null) && (lbxFields.Items.Count != 0))
        lbxFields.SelectedIndex = 0;
      UpdateGrid();
    }

    private void btnRemoveMaster_Click(object sender, EventArgs e)
    {
      if (GetSelectedLine() != null)
      {
        GetSelectedLine().Master = null;
        GetSelectedLine().Link = new Dictionary<string, string>();
        RefreshTreeView(null);
      }
    }

    private void btnCloneField_Click(object sender, EventArgs e)
    {
      TextField field = GetSelectedField();
      TextLine line = GetSelectedLine();
      int idx = lbxFields.SelectedIndex;
      if ((line != null) && (field != null))
      {
        TextField newField = CloneField(field, line, idx);

        RefreshListView();
        lbxFields.SelectedItem = newField;
        lbxFields.Focus();
      }

    }

    private TextField CloneField(TextField field, TextLine line, int idx)
    {
      TextField newField;

      if (idx != -1)
        newField = new TextField(line, idx + 1);
      else
        newField = new TextField(line);

      newField.AbortOnError = field.AbortOnError;
      newField.Align = field.Align;
      newField.AutoInc = field.AutoInc;
      newField.DataType = field.DataType;
      newField.DefaultValue = field.DefaultValue;
      newField.Description = field.Description;
      newField.Mask = field.Mask;
      newField.Name = field.Name;
      newField.PaddingChar = field.PaddingChar;
      newField.ParentRef = field.ParentRef;
      newField.PrimaryKey = field.PrimaryKey;
      newField.ReadOnly = field.ReadOnly;
      newField.Required = field.Required;
      newField.Size = field.Size;
      newField.TrimEnd = field.TrimEnd;
      newField.TrimStart = field.TrimStart;
      newField.ValidationXpression = field.ValidationXpression;
      newField.AnoRef = field.AnoRef;
      newField.TrimChars = field.TrimChars;

      return newField;
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      SelectSchemasDialog dlg = new SelectSchemasDialog();
      List<TextLine> list = dlg.SelectLines(this.file.Structure.Schemas);
      if (list.Count > 0)
      {
        for (int i = 0; i < list.Count; i++)
        {
          TextLine line = new TextLine(file);
          line.Delimiter = list[i].Delimiter;
          line.Description = list[i].Description;
          line.IgnoreFirst = list[i].IgnoreFirst;
          line.LineType = list[i].LineType;
          line.Name = list[i].Name;
          line.TableName = list[i].TableName;
          line.ValidationXpression = list[i].ValidationXpression;
          for (int j = 0; j < list[i].Fields.Count; j++)
          {
            CloneField(list[i].Fields[j], line, -1);
          }
        }

        RefreshListView();
        RefreshTreeView(null);
      }
    }

    private void btnSort_Click(object sender, EventArgs e)
    {
      TextLine line = GetSelectedLine();
      if (line != null)
      {
        SortFieldsDialog dlg = new SortFieldsDialog();
        dlg.Execute(line);
        RefreshListView();
      }
    }

    private void TxtStructureDialog_Shown(object sender, EventArgs e)
    {
      if (tvStructure.Nodes.Count != 0)
      {
        tvStructure.SelectedNode = tvStructure.Nodes[0];
        RefreshListView();
        tvStructure.Select();
        UpdateGrid();
      }
    }

    private void btnFromModel_Click(object sender, EventArgs e)
    {

      if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        TextLine line = GetSelectedLine();
        if (line.IgnoreFirst == 0)
          line.IgnoreFirst = 1;

        using (StreamReader sr = new StreamReader(openFileDialog.FileName))
        {
          string firstLine = sr.ReadLine();
          if (!String.IsNullOrWhiteSpace(line.TextQualifier))
            firstLine = firstLine.Replace(line.TextQualifier, "");
          string[] fieldNames = firstLine.Split(line.Delimiter);

          for (int i = 0; i < fieldNames.Length; i++)
          {
            TextField field = new TextField(line);
            field.Name = fieldNames[i];
            field.Name = field.Name.Replace('.', '_').Replace(',', '_').Replace(':', '_').Replace(';', '_');
          }
        }
        RefreshListView();
        lbxFields.Focus();
      }

    }

    

    private void TxtStructureDialog_KeyUp(object sender, KeyEventArgs e)
    {
      if (prgProperties.SelectedObject is TextField)
      {
        if (e.KeyCode == Keys.Insert)
        {
          TextField newField = CreateNewField();
          prgProperties.SelectedObject = newField;
          prgProperties.Focus();
        }

      }
    }
  }
}