#if !LockClient
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Cryptography;
using Iris.Runtime.Core.Connections;
using Iris.Interfaces;
using Iris.Runtime.Core;
using System.IO;
using Iris.Runtime.Core.Conexao;
using System.Windows.Forms;

namespace Iris.Runtime.Model.ClientObjects
{
  [Serializable]
  public class ClientConfig : IProccessLog
  {

    #region Constru��o e serializa��o

    /// <summary>
    /// Cria uma inst�ncia do objeto de configura��o a partir de um nome de arquivo e de uma estrutura IRIS
    /// </summary>
    /// <param name="_structure">The _structure.</param>
    /// <param name="_filename">The _filename.</param>
    /// <returns></returns>
    public static ClientConfig CreateConfig(IStructure _structure, string _filename)
    {
      ClientConfig config;

      if (File.Exists(_filename))
      {
        config = LoadFromFile(_filename, _structure);
      }
      else
      {
        config = new ClientConfig(_structure);
        config.SaveToFile(_filename);
      }
      return config;
    }

    /// <summary>
    /// Atualiza as os par�metros e grava o objeto de configura��o em um arquivo
    /// </summary>
    /// <param name="_fileName">Name of the _file.</param>
    public void SaveToFile(string _fileName)
    {
      PersistenceManager<ClientConfig>.SaveToFile(_fileName, this);
      foreach (KeyValuePair<string, string> assembly in structure.Assemblies)
      {
        AssemblyRefs[assembly.Key] = assembly.Value;
      }

      foreach (IDynConnection connection in structure.Connections)
      {
        SaveConnectionSettings(connection);
      }

      foreach (IScalarVar var in structure.ScalarVars)
      {
        if (var.ExternalParam)
        {
          DynParams[var.Name] = var.RawValue;
        }
      }

      fileName = _fileName;
    }

    string fileName;

    /// <summary>
    /// Recupera as configura��es de um objeto gravado em arquivo e as transfere para a estrutura
    /// </summary>
    /// <param name="_fileName">Name of the _file.</param>
    /// <param name="_structure">The _structure.</param>
    /// <returns></returns>
    private static ClientConfig LoadFromFile(string _fileName, IStructure _structure)
    {
      ClientConfig config = PersistenceManager<ClientConfig>.LoadFromFile(_fileName);

      config.fileName = _fileName;
      foreach (IDynConnection connection in _structure.Connections)
      {
        config.LoadConnectionSettings(connection);
      }

      foreach (IScalarVar var in _structure.ScalarVars)
      {
        if (var.ExternalParam)
        {
          if(config.DynParams.ContainsKey(var.Name))
            var.RawValue = config.DynParams[var.Name];
        }
      }

      foreach (KeyValuePair<string, string> assembly in config.AssemblyRefs)
      {
        _structure.Assemblies[assembly.Key] = assembly.Value;
      }
      config.structure = _structure;
      return config;

    }

    [NonSerialized]
    private IStructure structure;

    /// <summary>
    /// Construtor privado para inicializa��o de cole��es
    /// </summary>
    /// <param name="_structure">The _structure.</param>
    private ClientConfig(IStructure _structure)
    {
      connectionSettings = new Dictionary<string, string>();
      dynParams = new Dictionary<string, object>();
      assemblyRefs = new Dictionary<string, string>();
      logs = new List<ProccessLog>();
      KeepLastNLogs = -1;
      structure = _structure;
    }
    #endregion

    #region Scheduler

    /// <summary>
    /// Runs this instance.
    /// </summary>
    public object Run()
    {
      runningLog = new ProccessLog();
      lastStart = DateTime.Now;
      error = false;
      object result = null;
      if (structure != null)
      {
        try
        {
          ((ILoggable)structure).Log = this;
          structure.Restart();
          result = structure.Execute(false);
        }
        finally
        {
          lastEnd = DateTime.Now;
          lastElapsed = lastEnd - lastStart;

          runningLog.StartTime = LastStart;
          runningLog.EndTime = lastEnd;
          runningLog.Error = error;
          Logs.Add(runningLog);

          if (KeepLastNLogs != -1)
          {
            while (Logs.Count > KeepLastNLogs)
            {
              Logs.RemoveAt(0);
            }
          }

          SaveToFile(fileName);
        }        
      }
      return result;

    }


    private int runEvery;

    /// <summary>
    /// Gets or sets the run every.
    /// </summary>
    /// <value>The run every.</value>
    [DisplayName("Intervalo"), Category("Execu��o"), Description("O intervalo que deve ser respeitado entre duas execu��es")]
    public int RunEvery
    {
      get 
      {
        if (runEvery < 1)
          runEvery = 1;
        return runEvery; 
      }
      set { runEvery = value; }
    }

    private TimeUnit timeUnit;

    /// <summary>
    /// Gets or sets the time unit.
    /// </summary>
    /// <value>The time unit.</value>
    [DisplayName("Unidade"), Category("Execu��o"), Description("A unidade de tempo na qual o intervalo ser� medido")]
    public TimeUnit TimeUnit
    {
      get { return timeUnit; }
      set { timeUnit = value; }
    }

    private DateTime lastStart;
    [DisplayName("�ltima execu��o"), Category("Informa��es"), Description("Data e hor�rio da �ltima execu��o")]
    public DateTime LastStart
    {
      get { return lastStart; }
    }


    private int keepLastNLogs;
    [DisplayName("Manter �ltimos N logs"), Category("Log"), Description("O n�mero de logs que deve ser armazenado para este processo")]
    public int KeepLastNLogs
    {
      //-1 para n�o excluir nunca
      get { return keepLastNLogs; }
      set { keepLastNLogs = value; }
    }
    private List<ProccessLog> logs;
    [Browsable(false)]
    public List<ProccessLog> Logs
    {
      get { return logs; }
      set { logs = value; }
    }

    [DisplayName("Pr�xima execu��o"), Category("Informa��es"), Description("Data e hor�rio da Pr�xima execu��o")]
    public DateTime NextStart
    {
      get
      {
        switch (TimeUnit)
        {
          case TimeUnit.Minutos:
            return LastStart.AddMinutes(RunEvery);
          case TimeUnit.Horas:
            return LastStart.AddHours(RunEvery);
          case TimeUnit.Dias:
            return LastStart.AddDays(RunEvery);
          case TimeUnit.Semanas:
            return LastStart.AddDays(RunEvery * 7);
          case TimeUnit.Meses:
            return LastStart.AddMonths(RunEvery);
          case TimeUnit.Anos:
            return LastStart.AddYears(RunEvery);
          default:
            return LastStart;
        }
      }
    }

    private DateTime lastEnd;
    [DisplayName("�ltimo t�rmino"), Category("Informa��es"), Description("Data e hor�rio do t�rmino �ltima execu��o")]
    public DateTime LastEnd
    {
      get { return lastEnd; }
    }

    private TimeSpan lastElapsed;
    [DisplayName("Dura��o"), Category("Informa��es"), Description("Dura��o da �ltima execu��o")]
    public TimeSpan LastElapsed
    {
      get { return lastElapsed; }
    }

    private bool error;
    [DisplayName("Erro"), Category("Informa��es"), Description("Informa se ocorreu erro na �ltima execu��o")]
    public bool Error
    {
      get { return error; }
    }

    #endregion

    #region Params

    private string password;
    [Browsable(false)]
    public string Password
    {
      get
      {
        if (!string.IsNullOrEmpty(password))
          return CryptImp.UnFixedComplement(password, true);
        else
          return "";
      }
      set
      {
        password = CryptImp.FixedComplement(value, true);
      }
    }

    private Dictionary<string, string> connectionSettings;

    private Dictionary<string, object> dynParams;
    [Browsable(false)]
    public Dictionary<string, object> DynParams
    {
      get { return dynParams; }
    }

    public bool ContainsParam(string paramName)
    {
      return dynParams.ContainsKey(paramName);
    }

    private Dictionary<string, string> assemblyRefs;
    [Browsable(false)]
    public Dictionary<string, string> AssemblyRefs
    {
      get { return assemblyRefs; }
      set { assemblyRefs = value; }
    }


    private void SaveConnectionSettings(IDynConnection connection)
    {
      string conString = CryptImp.FixedComplement(connection.ConnectionString, true);
      string provider = CryptImp.FixedComplement(connection.Provider, true);
      string internalProvider = CryptImp.FixedComplement(connection.InternalProvider, true);
      string settings = provider + "\n" + internalProvider + "\n" + conString;
      connectionSettings[connection.Name] = settings;
    }

    private void LoadConnectionSettings(IDynConnection connection)
    {
      if (connectionSettings.ContainsKey(connection.Name))
      {
        string settings = connectionSettings[connection.Name];
        string[] cSettings = settings.Split('\n');
        connection.InternalProvider = CryptImp.UnFixedComplement(cSettings[1], true);
        connection.Provider = CryptImp.UnFixedComplement(cSettings[0], true);
        connection.ConnectionString = CryptImp.UnFixedComplement(cSettings[2], true);
      }
    }
    #endregion

    #region IProccessLog Members
    [Browsable(false)]
    public string ProcName
    {
      get { return structure.ClassName; }
    }

    private ProccessLog runningLog;
    public void AddToLog(string logEntry, IOperation operation)
    {
      runningLog.Add(new LogItem(logEntry, ProcName));
      SaveToFile(fileName);
    }

    public void AddToLog(string aName, Exception e, IOperation operation)
    {
      error = true;
      runningLog.Add(new LogItem(aName, e, ProcName));
      SaveToFile(fileName);
    }

    public void AddToErrorLog(string logEntry, IOperation operation)
    {
      LogItem item = new LogItem(logEntry, ProcName);
      item.Error = true;
      runningLog.Add(item);
      SaveToFile(fileName);
    }

    #endregion
    
  }
}

#endif