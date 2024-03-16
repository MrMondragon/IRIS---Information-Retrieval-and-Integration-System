using Databridge.Engine.Web;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;
using Iris.Stilingue.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Databridge.Engine.Extensions;

namespace Iris.Stilingue
{
  [Serializable]
  [OperationCategory("Databridge", "Stilingue Requester")]
  public class StilingueRequester : Operation
  {
    public StilingueRequester(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Token", "Params");
    }

    private string token = @"5241012520747008";
    public string Token
    {
      get
      {
        IOperation oper = GetInput("Token");

        if ((oper != null) && (oper is IScalarVar))
          return Convert.ToString(((IScalarVar)oper).RawValue);
        else
          return token;
      }
      set
      {
        token = value;
      }
    }
    [Editor(typeof(ServiceEditor), typeof(UITypeEditor))]
    [DisplayName("Serviço")]
    public string Service { get; set; }

    public string MainTable { get; set; }

    private string parameters;
    [DisplayName("Parâmetros")]
    public string Parameters
    {
      get
      {
        IOperation oper = GetInput("Params");

        if ((oper != null) && (oper is IScalarVar))
          return Convert.ToString(((IScalarVar)oper).RawValue);
        else
        {
          parameters = $"last_day={dayOffset}&limit=100&offset={offset}";
          return parameters;
        }
      }
      set
      {
        parameters = value;
      }
    }

    private string GetURL()
    {
      string qs = String.IsNullOrWhiteSpace(Parameters) ? "" : $"?{Parameters}";
      return $@"https://stilingueapi.appspot.com/wrapi/{Service}/{Token}{qs}";
    }


    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private Random rnd;
    public bool CrawlByLimit { get; set; }
    public bool CrawlByLastDay { get; set; }

    public string Prefix { get; set; }

    public int Limit { get; set; }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private int offset;

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private int dayOffset;


    public override void Reset()
    {
      offset = 0;
      dayOffset = 0;
      base.Reset();
    }

    protected override IEntity doExecute()
    {
      offset = 0;
      dayOffset = 0;

      CrawlNext();

      return null;
    }

    private void CrawlNext()
    {
      string url = GetURL();

      string json = WebRequester.ReadRequest(url);
      json = "{\"root\":" + json + "}";

      XDocument xDoc = JsonConvert.DeserializeXNode(json);

      string xml = xDoc.ToString();
      DataSet ds = new DataSet();

      using (TextReader tr = new StringReader(xml))
      {
        ds.ReadXml(tr);
      }

      DataTable[] tables = ds.Tables.Cast<DataTable>().ToArray();

      foreach (DataTable table in tables)
      {
        string tableName = table.TableName;

        if (!string.IsNullOrEmpty(Prefix))
          tableName = Prefix + tableName;

        tableName = tableName.NormalizeText(true).Replace(" ", "_");

        ResultSet rs = Structure.ResultSets.FindByName(tableName);
        if (rs != null)
        {
          LoadDataRows(table, tableName, rs);
        }
        else
        {
          Structure.AddToErrorLog($"Resultset {tableName} não encontrado.", this);
        }
      }


      if (dayOffset < Limit)
      {
        if (ds.Tables.Contains(MainTable))
        {
          offset += 100;

        }
        else
        {
          dayOffset += 1;
          offset = 0;
        }

        if (dayOffset <= Limit)
        {
          if (rnd == null)
            rnd = new Random();
          System.Threading.Thread.Sleep(1000 + rnd.Next(1000));
          CrawlNext();
        }
      }



    }

    private void LoadDataRows(DataTable table, string tableName, ResultSet rs)
    {
      if ((rs.Table == null) || (rs.RecCount == 0))
      {
        rs.Table = new DataTable("tableName");
      }


      foreach (DataColumn col in table.Columns)
      {
        if (!rs.Table.Columns.Contains(col.ColumnName))
        {
          rs.Table.Columns.Add(col.ColumnName, typeof(string));
        }
      }

      foreach (DataRow row in table.Rows)
      {
        DataRow rsRow = rs.Table.NewRow();

        foreach (DataColumn dCol in rs.Table.Columns)
        {
          if (table.Columns.Contains(dCol.ColumnName))
            rsRow[dCol] = row[dCol.ColumnName];
        }

        rs.Table.LoadDataRow(row.ItemArray, LoadOption.Upsert);
      }

      Structure.AddToLog($"{table.Rows.Count} registros lidos para o Resultset {tableName}", this);

    }


    public static Bitmap GetIcon()
    {
      return Resources.Stilingue;
    }
  }
}
