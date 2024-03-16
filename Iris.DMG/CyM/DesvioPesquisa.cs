using Databridge.Engine.Extensions;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace Iris.DMG.CyM
{
  [Serializable]
  [OperationCategory("CyberMonitor", "Devio Pesquisa")]
  public class DesvioPesquisa : Operation
  {
    public DesvioPesquisa(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Entrada", "Targets");
      SetOutputs("Saída");
    }

    private DataTable SetupTable()
    {
      ResultSet rsSaida = (ResultSet)GetOutput("Saída");
      DataTable table = new DataTable(rsSaida.Name);
      table.Columns.Add("Label");
      table.Columns.Add("Colunas");
      table.Columns.Add("FiltroAlvo");
      table.Columns.Add("FiltroNaoALvo");
      table.Columns.Add("Q_i");
      table.Columns.Add("V_i");
      table.Columns.Add("Q_j");
      table.Columns.Add("V_j");
      table.Columns.Add("Q_k");
      table.Columns.Add("V_k");
      table.Columns.Add("PesoAlvo", typeof(double));
      table.Columns.Add("PesoAlvoPercent", typeof(double));
      table.Columns.Add("PesoCluster", typeof(double));
      table.Columns.Add("PesoClusterPercent", typeof(double));
      table.Columns.Add("PesoGlobal", typeof(double));
      table.Columns.Add("Desvio", typeof(double));
      table.Columns.Add("DesvioPub", typeof(double));
      table.Columns.Add("PesoDesvio", typeof(double));
      rsSaida.Table = table;
      return table;
    }

    protected override IEntity doExecute()
    {

      /*
       ColunasAlvo|FiltroAlvo|FiltroNaoAlvo|Label
        Q05;Q01|Q05<>'1' AND Q01<>'1'|Q05='1' OR Q01='1'|Voto Jvx

      formato do arquivo de targets
        Colunas alvo: todas as colunas que compõem os filtros e que não devem ser usadas para cálculo
        Filtro alvo: filtro para seleção do resultset alvo
        FiltroNaoAlvo: filtro inverso do anterior.
        Label: --
       */

      DataTable saida = SetupTable();
      DataTable entrada = ((ResultSet)GetInput("Entrada")).Table;
      DataTable targets = ((ResultSet)GetInput("Targets")).Table;

      saida.BeginLoadData();
      foreach (DataRow targetRow in targets.Rows)
      {
        string[] colunasAlvo = Convert.ToString(targetRow[0]).Split(';');

        List<string> qFields = entrada.Columns.Cast<DataColumn>().Select(x => x.ColumnName).
          Where(x => (!colunasAlvo.Contains(x)) && (x.StartsWith("Q"))).ToList();

        for (int i = 0; i < qFields.Count; i++)
        {
          CalculaDesvio(targetRow, entrada, saida, Convert.ToString(qFields[i]), "", "");

          if ((i + 1) < qFields.Count)
          {
            for (int j = i + 1; j < qFields.Count; j++)
            {
              CalculaDesvio(targetRow, entrada, saida, Convert.ToString(qFields[i]),
                Convert.ToString(qFields[j]), "");

              if ((j + 1) < qFields.Count)
              {
                for (int k = j + 1; k < qFields.Count; k++)
                {
                  CalculaDesvio(targetRow, entrada, saida, Convert.ToString(qFields[i]),
                    Convert.ToString(qFields[j]), Convert.ToString(qFields[k]));
                }
              }
            }
          }
        }
      }
      saida.EndLoadData();
      return null;
    }

    private void CalculaDesvio(DataRow targetRow, DataTable entrada,
      DataTable saida, string qi, string qj, string qk)
    {
      string targetFilter = Convert.ToString(targetRow[1]);
      string nonTargetFilter = Convert.ToString(targetRow[2]);

      string[] targetQ = Convert.ToString(targetRow[0]).Split(';');

      DataTable workTable = CreateWorkTable(entrada, qi, qj, qk, targetQ);

      Dictionary<string, double> pesoCluster = CreateCluster(workTable.Select(), targetQ);

      double pesoGCluster = pesoCluster.Select(x => x.Value).Sum();

      Dictionary<string, double> pesoAlvo = CreateCluster(workTable.Select(targetFilter), targetQ);
      List<string> absentKeys = pesoCluster.Select(x => x.Key).Where(y => !pesoAlvo.ContainsKey(y)).ToList();
      if (absentKeys.Count != 0)
      {
        foreach (string item in absentKeys)
        {
          pesoAlvo[item] = 0;
        }
      }

      double pesoGAlvo = pesoAlvo.Select(x => x.Value).Sum();

      Dictionary<string, double> pesoNaoAlvo = CreateCluster(workTable.Select(nonTargetFilter), targetQ);
      absentKeys = pesoCluster.Select(x => x.Key).Where(y => !pesoNaoAlvo.ContainsKey(y)).ToList();
      if (absentKeys.Count != 0)
      {
        foreach (string item in absentKeys)
        {
          pesoNaoAlvo[item] = 0;
        }
      }
      double pesoGNaoAlvo = pesoNaoAlvo.Select(x => x.Value).Sum();

      Dictionary<string, double> pesoPercCluster = pesoCluster.ToDictionary(x => x.Key, y => y.Value / pesoGCluster);
      Dictionary<string, double> pesoPercAlvo = pesoAlvo.ToDictionary(x => x.Key, y => y.Value / pesoGAlvo);
      Dictionary<string, double> pesoPercNaoAlvo = pesoNaoAlvo.ToDictionary(x => x.Key, y => y.Value / pesoGNaoAlvo);

      Dictionary<string, double> desvioCluster = pesoPercAlvo.ToDictionary(x => x.Key, y => y.Value / pesoPercNaoAlvo[y.Key]);
      Dictionary<string, double> desvioPub = desvioCluster.ToDictionary(x => x.Key, y => y.Value - 1);
      Dictionary<string, double> pesoDesvio = desvioCluster.ToDictionary(x => x.Key, y => (pesoGAlvo / pesoGCluster) * y.Value);

      foreach (KeyValuePair<string, double> item in pesoPercAlvo)
      {
        DataRow newRow = saida.NewRow();
        string[] keyParts = item.Key.Split('|');

        newRow["Label"] = targetRow[3];
        newRow["Colunas"] = targetRow[0];
        newRow["FiltroAlvo"] = targetRow[1];
        newRow["FiltroNaoALvo"] = targetRow[2];
        newRow["Q_i"] = qi;
        newRow["V_i"] = keyParts[0];
        newRow["Q_j"] = qj;
        newRow["V_j"] = keyParts.Length > 1 ? keyParts[1] : "";
        newRow["Q_k"] = qk;
        newRow["V_k"] = keyParts.Length > 2 ? keyParts[2] : "";
        newRow["PesoAlvo"] = pesoAlvo[item.Key];
        newRow["PesoAlvoPercent"] = pesoPercAlvo[item.Key];
        newRow["PesoCluster"] = pesoCluster[item.Key];
        newRow["PesoClusterPercent"] = pesoPercCluster[item.Key];
        newRow["PesoGlobal"] = pesoGCluster;
        newRow["Desvio"] = desvioCluster[item.Key];
        newRow["DesvioPub"] = desvioPub[item.Key];
        newRow["PesoDesvio"] = pesoDesvio[item.Key];

        saida.LoadDataRow(newRow);
      }
    }

    private static DataTable CreateWorkTable(DataTable entrada, string qi, string qj, string qk, string[] targetQ)
    {
      DataTable workTable = entrada.Copy();
      for (int i = workTable.Columns.Count - 1; i >= 0; i--)
      {
        if ((workTable.Columns[i].ColumnName != qi) &&
          (workTable.Columns[i].ColumnName != qj) && (workTable.Columns[i].ColumnName != qk)
          && (workTable.Columns[i].ColumnName != "peso") && (!targetQ.Contains(workTable.Columns[i].ColumnName)))
        {
          workTable.Columns.Remove(workTable.Columns[i]);
        }
      }

      return workTable;
    }

    private Dictionary<string, double> CreateCluster(DataRow[] rows, string[] targetQ)
    {
      Dictionary<string, double> cluster = new Dictionary<string, double>();

      foreach (DataRow row in rows)
      {
        string key = "";
        for (int i = 0; i < row.Table.Columns.Count; i++)
        {
          if ((row.Table.Columns[i].ColumnName.StartsWith("Q")) && (!targetQ.Contains(row.Table.Columns[i].ColumnName)))
          {
            key += Convert.ToString(row[i]) + "|";
          }
        }

        key = key.TrimEnd('|');

        if (cluster.ContainsKey(key))
        {
          cluster[key] += Convert.ToDouble(row["peso"]);
        }
        else
        {
          cluster[key] = Convert.ToDouble(row["peso"]);
        }
      }

      return cluster;
    }


  }


}
