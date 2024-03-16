using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Core.Connections;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;
using Iris.PropertyEditors.PropertyEditors.Controls;
using Databridge.Engine.Parsers;
using Databridge.Engine;
using Databridge.Engine.Parsers.QueryObjects;
using Databridge.Engine.Parsers.MergerObjects;
using Databridge.Engine.Parsers.QueryObjects.Interfaces;
using Databridge.Interfaces;
using System.Diagnostics;

namespace Iris.Designer
{
  public partial class QueryWindow : Form, IConnectedObject
  {
    public QueryWindow()
    {
      InitializeComponent();
      syntaxControl1.Language = SyntaxLanguage.Sql;
      Array array = Enum.GetValues(typeof(QueryType));
      for (int i = 0; i < array.Length; i++)
      {
        cbxCommandType.Items.Add(array.GetValue(i));
      }
      dataGridView1.AutoGenerateColumns = true;
      cbxCommandType.SelectedItem = QueryType.Registros;

      dataGridView1.DataError += dataGridView1_DataError;
    }


    private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      

      DataTable table = null;

      if (bindingSource.DataSource is DataTable)
        table = (DataTable)bindingSource.DataSource;
      else if (bindingSource.DataSource is DataView)
        table = ((DataView)bindingSource.DataSource).Table;

      if (table != null)
      {
        DataColumn col = table.Columns[e.ColumnIndex];

        if ((col.DataType == (typeof(byte[]))) &&
          (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText)))
        {


          byte[] bytes = (byte[])table.Rows[e.RowIndex][col];
          string str = "";

          for (int i = 0; i < bytes.Length; i++)
          {
            str += bytes[i].ToString() + ".";
          }

          str = str.TrimEnd('.');
          str = "{" + str + "}";

          dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = str + "  " + e.Exception.Message;
        }

        e.ThrowException = false;
      }

    }

    public QueryWindow(IStructure _structure)
      : this()
    {
      Structure = (Structure)_structure;
    }

    private Structure structure;

    public Structure Structure
    {
      get { return structure; }
      set
      {
        structure = value;
        syntaxControl1.Structure = value;
        cbxConections.Items.Clear();
        cbxConections.Items.Add("<Dataset>");
        foreach (DynConnection connection in structure.Connections)
        {
          cbxConections.Items.Add(connection.Name);
        }
        cbxConections.SelectedIndex = 0;
      }
    }

    private void cbxConections_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (IsDataset())
      {
        syntaxControl1.SelectedObject = null;
      }
      else
      {
        syntaxControl1.SelectedObject = this;
      }
    }

    private void Execute()
    {
      try
      {
        string commandText = syntaxControl1.GetSelectedText().Trim();

        if (commandText.ToLower().StartsWith("select "))
          cbxCommandType.SelectedItem = QueryType.Registros;
        else
          cbxCommandType.SelectedItem = QueryType.Comando;

        if (commandText.ToLower().StartsWith("open ") || commandText.ToLower().StartsWith("fill ") || commandText.ToLower().StartsWith("accept ")
          || commandText.ToLower().StartsWith("reject ") || commandText.ToLower().StartsWith("clear ") ||
          commandText.ToLower().StartsWith("apply ") || commandText.ToLower().StartsWith("getsql ") || commandText.ToLower().StartsWith("getfields "))
          ExecuteInternalCommand(commandText);
        else if (commandText.ToLower().Trim() == "cleardataset")
          Structure.ClearDataset();
        else if (commandText.ToLower().StartsWith("execute "))
          ExecuteXEval(commandText);
        else
        {
          if (IsDataset())
            ExecuteDataSet();
          else
            ExecuteConnection();
        }
      }
      catch (Exception e)
      {
        AddToLog(e);
      }
    }

    private void ExecuteXEval(string commandText)
    {
      commandText = commandText.Substring(7).Trim();
      object value = XEvalParser.GetParser().Parse(commandText);
      AddToLog(string.Format("Valor retornado: {0}", value));
    }

    private void ExecuteInternalCommand(string commandText)
    {
      string[] tokens = commandText.Split(' ');
      if (tokens.Length != 2)
        throw new Exception("Comando Inválido");

      ResultSet rs = (ResultSet)Structure.GetResultSet(tokens[1]);
      switch (tokens[0].ToLower())
      {
        case "open":
          AddToLog(string.Format("{0} registros carregados", rs.RecCount));
          break;
        case "fill":
          rs.Fill();
          AddToLog(string.Format("{0} registros carregados", rs.RecCount));
          break;
        case "accept":
          rs.Table.AcceptChanges();
          AddToLog("Atualizações aceitas no Resultset");
          break;
        case "reject":
          rs.Table.RejectChanges();
          AddToLog("Atualizações descartadas no Resultset");
          break;
        case "clear":
          rs.Clear();
          AddToLog("Resultset limpo");
          break;
        case "apply":
          rs.Apply(rs.Table.Select());
          AddToLog("Resultset gravado");
          break;
        case "getsql":
          {
            string sql = BuildSqlStatement(rs);
            syntaxControl1.Text += Environment.NewLine;
            syntaxControl1.Text += Environment.NewLine;
            syntaxControl1.Text += sql;
            break;
          }
        case "getfields":
          {
            DataTable rsTable = rs.Table;

            DataTable table = new DataTable(rs.Name);
            table.Columns.Add("ColumnName");
            table.Columns.Add("DataType");
            table.BeginLoadData();
            for (int i = 0; i < rsTable.Columns.Count; i++)
            {
              table.LoadDataRow(new object[] { rsTable.Columns[i].ColumnName, rsTable.Columns[i].DataType.ToString() }, true);
            }
            table.EndLoadData();
            SetDataSource(table);
            return;
          }
        default:
          throw new Exception("Comando Inválido");
      }

      if ((rs != null) && (rs.Table != null))
        SetDataSource(rs.Table);
      else
        SetDataSource(null);

    }

    private string BuildSqlStatement(ResultSet rs)
    {

      if ((!(string.IsNullOrEmpty(rs.Sql.Trim()))) && (!rs.Sql.Contains("*")))
        return rs.Sql;
      else
      {
        StringBuilder builder = new StringBuilder();
        builder.Append("SELECT ");
        for (int i = 0; i < rs.Table.Columns.Count; i++)
        {
          builder.Append(rs.Table.Columns[i].ColumnName);
          builder.Append(", ");
        }

        string sql = builder.ToString().TrimEnd(',', ' ') + " FROM " + rs.Name.ToUpper();
        return sql;
      }
    }

    private string GetCommandText(ExecutionContext context, bool mergeText)
    {
      string sql = syntaxControl1.GetSelectedText();
      //Verifica se será necessário passar o comando pelo pré processador de parâmetros;
      if (sql.Contains("{") || sql.Contains(":"))
      {
        Query query = (Query)QueryParser.GetParser().Parse(sql, context);
        MergingObject mObj = MergerParser.GetParser().Parse(query.ToString());
        if (mergeText)
        {
          sql = mObj.MergedText;
        }
        else
        {
          sql = mObj.ParamText;
          context.Parameters = mObj.Parameters;
        }
      }
      return sql;
    }

    private void ExecuteConnection()
    {
      ExecutionContext context = Structure.GetContext();

      QueryType qType = (QueryType)cbxCommandType.SelectedItem;

      string sql = GetCommandText(context, false);
      DynConnection connection = GetConnection();


      switch (qType)
      {
        case QueryType.Comando:
          {
            object result = connection.ExecuteNonQuery(sql, Structure.GetContext());
            AddToLog(string.Format("{0} registros afetados", result));
            break;
          }
        case QueryType.Registros:
          {
            DataTable result = connection.ExecQuery(sql, Structure.GetContext());
            AddToLog(string.Format("{0} registros carregados", result.Rows.Count));
            SetDataSource(result);
            break;
          }
        case QueryType.Valor_Escalar:
          {
            object result = connection.ExecuteScalar(sql, Structure.GetContext());
            AddToLog(string.Format("Valor retornado: {0}", result));
            break;
          }
      }
    }

    private void ExecuteDataSet()
    {
      ExecutionContext context = Structure.GetContext();
      QueryType qType = (QueryType)cbxCommandType.SelectedItem;
      string sql = GetCommandText(context, true);

      Query query = QueryParser.GetParser().Parse(sql);
      String logString = "";
      Stopwatch sw = new Stopwatch();
      sw.Start();

      switch (qType)
      {
        case QueryType.Comando:
          {
            object result = ((IExecuteNonQuery)query.Statements[0]).ExecuteNonQuery(context);
            logString = string.Format("{0} registros afetados", result);
            break;
          }
        case QueryType.Registros:
          {
            DataView result = ((IExecuteQuery)query.Statements[0]).ExecuteQuery(context);
            logString = string.Format("{0} registros carregados", result.Count);
            SetDataSource(result);
            break;
          }
        case QueryType.Valor_Escalar:
          {
            object value = ((IExecuteScalar)query.Statements[0]).ExecuteScalar(context);
            logString = string.Format("Valor retornado: {0}", value);
            break;
          }
      }

      sw.Stop();
      logString += "  (" + sw.Elapsed.ToString() + ")";
      AddToLog(logString);
    }

    private List<int> errorIndexes;

    private void SetDataSource(object dataSource)
    {
      bindingSource.DataSource = dataSource;

      DataTable table = null;

      if (dataSource is DataTable)
        table = (DataTable)dataSource;
      else if (dataSource is DataView)
        table = ((DataView)dataSource).Table;

      if (table != null)
      {
        table.PrimaryKey = new DataColumn[0];
      }

      errorIndexes = new List<int>();
      for (int i = 0; i < bindingSource.Count; i++)
      {
        DataRow row = ((DataRowView)bindingSource[i]).Row;
        if (row.HasErrors)
        {
          errorIndexes.Add(i);
        }
      }
    }

    private void FindNextError()
    {
      if ((errorIndexes != null) && (errorIndexes.Count > 0))
      {
        int idx = bindingSource.Position;
        int errIdx = -1;
        for (int i = 0; i < errorIndexes.Count; i++)
        {
          if (errorIndexes[i] > idx)
          {
            errIdx = errorIndexes[i];
            break;
          }
        }
        if (errIdx > -1)
          bindingSource.Position = errIdx;
      }
    }

    private void FindPrevError()
    {
      if ((errorIndexes != null) && (errorIndexes.Count > 0))
      {
        int idx = bindingSource.Position;
        int errIdx = -1;
        for (int i = errorIndexes.Count - 1; i >= 0; i--)
        {
          if (errorIndexes[i] < idx)
          {
            errIdx = errorIndexes[i];
            break;
          }
        }
        if (errIdx > -1)
          bindingSource.Position = errIdx;
      }
    }
    private void btnFindNextError_Click(object sender, EventArgs e)
    {
      FindNextError();
    }

    private void btnFindPrevError_Click(object sender, EventArgs e)
    {
      FindPrevError();
    }

    private void CreateListViewItem(string text, int imageIndex)
    {
      ListViewItem lvi = new ListViewItem(text);
      lvi.ImageIndex = imageIndex;
      lvi.Checked = false;
      lvwLog.Items.Add(lvi);

      lvwLog.EnsureVisible(lvwLog.Items.Count - 1);
      lvi.Selected = true;

      lvwLog.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
    }


    #region IConnectedObject Members

    public IDataConnection Connection
    {
      get
      {
        if (IsDataset())
          return null;
        else
          return GetConnection();
      }
      set
      {
      }
    }

    private DynConnection GetConnection()
    {
      return Structure.GetConnection(Convert.ToString(cbxConections.SelectedItem));
    }

    private bool IsDataset()
    {
      return (string.IsNullOrEmpty(Convert.ToString(cbxConections.SelectedItem))) || (Convert.ToString(cbxConections.SelectedItem) == "<Dataset>");
    }

    #endregion

    #region IProccessLog Members

    public void AddToLog(string logEntry)
    {
      Write(logEntry, false);
    }

    private void Write(string logEntry, bool error)
    {
      DateTime time = DateTime.Now;
      string text = string.Format("{0} -> {1}", time.ToString(), logEntry);

      int imageIndex;
      if (error)
        imageIndex = 1;
      else
        imageIndex = 0;
      CreateListViewItem(text, imageIndex);

      if (error)
        stlLastLog.ForeColor = Color.Red;
      else
        stlLastLog.ForeColor = Color.Black;

      stlLastLog.Text = logEntry;
    }

    public void AddToErrorLog(string logEntry)
    {
      Write(logEntry, true);
    }

    public void AddToLog(Exception e)
    {
      string logEntry = "Falha na execução da sentença. Mensagem original: " + GetFullErrorMessage(e);
      Write(logEntry, true);
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

    private void btnRun_Click(object sender, EventArgs e)
    {
      Execute();
    }

    private void ImediateWindow_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 116)
      {
        Execute();
      }
    }

    private void btnClearLog_Click(object sender, EventArgs e)
    {
      lvwLog.Items.Clear();
      stlLastLog.Text = "";
    }

    private void btnAutoSize_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewColumn column in dataGridView1.Columns)
      {
        if (column.AutoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
          column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        else
          column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
      }
    }
  }
}