using System;
using System.Collections.Generic;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors;
using System.Data.Common;
using Iris.Runtime.Core.Connections;
using System.Linq;

using Iris.Runtime.ResultSetOperations;
using Iris.PropertyEditors.PropertyEditors;
using System.Diagnostics;
using System.Windows.Forms;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Transporte via SP")]
  public class SpTransport : ColumnBasedOperation, ISpTransport
  {
    public SpTransport(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      paramNames = new List<string>();
    }

    private DynConnection connection;

    /// <summary>
    /// Gets the connection.
    /// </summary>
    /// <value>The connection.</value>
    [Editor(typeof(ConnectionSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Conexão"), Category("Transporte")]
    public DynConnection Connection
    {
      get
      {
        return connection;
      }
      set
      {
        connection = value;
      }
    }

    [DisplayName("Stored Procedure"), Category("Transporte"), Description("Nome da Stored Procedure sem parâmetros")]
    public string SpName { get; set; }

    private List<string> paramNames;
    [DisplayName("Parâmetros"), Category("Transporte"), Description("Nomes dos parâmetros da Stored Procedure")]
    [Editor(typeof(SpParamsEditor), typeof(UITypeEditor))]
    public List<string> ParamNames
    {
      get { return paramNames; }
      set { paramNames = value; }
    }

    private List<KeyValuePair<string, string>> corresp;
    [Editor(typeof(SpFieldMapEditor), typeof(UITypeEditor))]
    [DisplayName("Correspondências"), Category("Transporte")]
    public virtual List<KeyValuePair<string, string>> Corresp
    {
      get
      {
        return corresp;
      }
      set
      {
        corresp = value;
      }
    }

    [DisplayName("Timeout"), Category("Transporte"), Description("Timeout em segundos para o comando da Stored Procedure")]
    public int CommandTimeout { get; set; }

    [DisplayName("Lote"), Category("Transporte"), Description("Quantidade de arquivos que serão enviados por lote de execução")]
    public int BatchSize { get; set; }
    [DisplayName("Máximo de erros"), Category("Transporte"), Description("Quantidade de erros permitidos antes de abortar a operação")]
    public int MaxErrors { get; set; }

    [NonSerialized]
    private int sucessCount;
    [NonSerialized]
    private int errorCount;


    public override void Reset()
    {
      base.Reset();

    }



    protected override IEntity doExecute()
    {
      sucessCount = 0;
      errorCount = 0;

      if (string.IsNullOrEmpty(SpName))
        throw new Exception("Nome da stored procedure não atribuído");

      if (Connection == null)
        throw new Exception("Conexão não atribuída");

      Dictionary<string, string> localCorresp = Corresp.ToDictionary(x => x.Value, y => y.Key);


      int batch = 0;
      int batchCount = 0;

      Stopwatch sw = new Stopwatch(); ;
      if (BatchSize != 0)
      {
        sw.Start();
      }

      if (Connection.Connection.State != ConnectionState.Open)
        Connection.Connection.Open();

      for (int i = 0; i < Entrada.View.Count; i++)
      {

        DataRowView row = Entrada.View[i];
        TransportTask(row, localCorresp, Connection.Connection);
        batch++;

        if ((BatchSize != 0) && (batch == BatchSize))
        {
          sw.Stop();
          batchCount++;
          int regs = Entrada.View.Count;
          int batches = Convert.ToInt32(Math.Ceiling((Decimal)regs / (Decimal)BatchSize));

          Structure.AddToLog(String.Format("Lote {0} de {1}. Registros Processados: {3}. Tempo de execução: {2}",
            batchCount, batches, sw.Elapsed, batch), this);

          batch = 0;

          Application.DoEvents();
        }
      }


      Structure.AddToLog(string.Format("{0} Registros enviados com êxito", sucessCount), this);

      if (errorCount > 0)
        Structure.AddToErrorLog(string.Format("Falha no envio de {0} registros", errorCount), this);

      return null;
    }



    private void TransportTask(DataRowView row, Dictionary<string, string> localCorresp, DbConnection localConnection)
    {
      try
      {
        DbCommand cmd = localConnection.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = SpName;

        if (CommandTimeout != 0)
          cmd.CommandTimeout = CommandTimeout;

        for (int i = 0; i < ParamNames.Count; i++)
        {
          if (localCorresp.ContainsKey(ParamNames[i]))
          {
            object value = row[localCorresp[ParamNames[i]]];

            DbParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = ParamNames[i];
            parameter.Value = value;

            cmd.Parameters.Add(parameter);
          }
          else
            cmd.Parameters.Add(DBNull.Value);
        }

        if (!string.IsNullOrEmpty(Column))
        {
          row[Column] = "Sucesso";
        }

        cmd.ExecuteNonQuery();
        sucessCount++;
      }
      catch (Exception ex)
      {
        errorCount++;
        if (errorCount != -1)
        {
          if (errorCount > MaxErrors)
          {
            throw new Exception("Máximo de erros atingido", ex);
          }
        }

        if (!string.IsNullOrEmpty(Column))
        {
          row[Column] = "Erro";
        }
      }
    }

    [Browsable(false)]
    public override string ColumnName
    {
      get
      {
        return base.ColumnName;
      }
      set
      {
        base.ColumnName = value;
      }
    }
  }
}
