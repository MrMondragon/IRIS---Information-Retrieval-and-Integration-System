using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Drawing.Design;
using Iris.Interfaces;
using Iris.Runtime.Core.ParserEngine.ParserObjects;
using Iris.PropertyEditors;
using Databridge.Engine.Data;
using Databridge.Interfaces.BaseEditors;
using Databridge.Interfaces;


namespace Iris.Runtime.Core.Connections
{
  /// <summary>
  /// Conex�o din�mica
  /// </summary>
  [Serializable]
  public class DynConnection : DataConnection, IDataConnection
  {
    public DynConnection(string name, IStructure structure)
      : base(name)
    {
      this.Structure = structure;
    }

    public DynConnection(DynConnection connection)
      : base(connection.name)
    {
      this.ConnectionString = connection.ConnectionString;
      this.Description = connection.Description;
      this.Disabled = connection.Disabled;
      this.DisplayText = connection.DisplayText;
      this.InternalProvider = connection.InternalProvider;
      this.Notes = connection.Notes;
      this.Provider = connection.Provider;
    }

    /// <summary>
    /// Determina o ConnectionString da inst�ncia
    /// </summary>
    /// <value>ConnectionString da inst�ncia</value>
    [Browsable(true), Category("Conex�o"), DisplayName("String de Conex�o"), Description("String de Conex�o com o banco de dados")]
    [Editor(typeof(ConnectionStringEditor), typeof(UITypeEditor))]
    public override string ConnectionString
    {
      get
      {
        return base.ConnectionString;
      }
      set
      {
        base.ConnectionString = value;
      }
    }
    //ConnectionString

    /// <summary>
    /// Representa��o mais amig�vel do provider armazenado na propriedade InternalProvider
    /// </summary>
    /// <value>Provider da inst�ncia</value>
    [Browsable(true), ReadOnly(false), Category("Conex�o"), DisplayName("Provedor"), Description("Provedor de acesso ao banco de dados")]
    [Editor(typeof(ProviderEditor), typeof(UITypeEditor))]
    public override string Provider
    {
      get
      {
        return base.Provider;
      }
      set
      {
        base.Provider = value;
      }
    }

    [Category("Design")]
    public string DisplayText { get; set; }

    [DisplayName("Descri��o"), Category("Design")]
    public string Description
    {
      get;
      set;
    }

    [Browsable(false)]
    public string Notes { get; set; }

    public IStructure Structure { get; set; }

    protected override void HandleAdapterException(Exception ex)
    {
      base.HandleAdapterException(ex);
      Structure.AddToErrorLog("Falha de acesso na conex�o ["+this.Name+"]: "+ex.Message, null);
    }
  }
}
