using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FuzzyString;
using Iris.Interfaces;
using Iris.PropertyEditors.PropertyEditors;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Runtime.Model.PropertyEditors;
using Databridge.Engine.Extensions;



namespace Iris.FuzzyString
{
  [Serializable]
  [OperationCategory("Transformações", "Fuzzy Match")]
  public class FuzzyMatchScore : ColumnBasedOperation, IFuzzyMatchScore
  {
    public FuzzyMatchScore(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Alvo");
      SetOutputs("Saída");
    }


    [Browsable(false)]
    public IResultSet Alvo
    {
      get
      {
        IOperation input = GetInput("Alvo");
        if (input == null)
          throw new Exception("Resultset alvo não atribuído");
        else
          return (IResultSet)input.EntityValue;
      }
    }

    [Browsable(false)]
    public IResultSet Saida
    {
      get
      {
        IOperation output = GetOutput("Saída");
        if (output == null)
          throw new Exception("Resultset saída não atribuído");
        else
          return (IResultSet)output.EntityValue;
      }
    }



    private String targetColumn;
    [Editor(typeof(FuzzyColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Coluna Alvo"), Category("Expressão")]
    public virtual String TargetColumn
    {
      get { return targetColumn; }
      set
      {
        if (targetColumn != value)
        {
          targetColumn = value;
        }
      }
    }



    [Editor(typeof(InputColumnListEditor), typeof(UITypeEditor))]
    [DisplayName("Colunas Entrada"), Category("Expressão"), Description("Colunas da tabela Entrada a serem incluídas no RS gerado")]
    public List<string> ColunasEntrada { get; set; }
    [Editor(typeof(SourceColumnListEditor), typeof(UITypeEditor))]
    [DisplayName("Colunas Alvo"), Category("Expressão"), Description("Colunas da tabela Alvo a serem incluídas no RS gerado")]
    public List<string> ColunasAlvo { get; set; }


    [Category("Fuzzy Logic")]
    public bool UseHammingDistance { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseJaccardDistance { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseJaroDistance { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseJaroWinklerDistance { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseLevenshteinDistance { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseLongestCommonSubsequence { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseLongestCommonSubstring { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseNormalizedLevenshteinDistance { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseOverlapCoefficient { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseRatcliffObershelpSimilarity { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseSorensenDiceDistance { get; set; }
    [Category("Fuzzy Logic")]
    public bool UseTanimotoCoefficient { get; set; }
    [Category("Fuzzy Logic"), DisplayName("Margem de Erro")]
    public decimal Treshold { get; set; }

    private List<FuzzyStringComparisonOptions> GetComparisonOptions()
    {
      List<FuzzyStringComparisonOptions> list = new List<FuzzyStringComparisonOptions>();

      if (UseHammingDistance) list.Add(FuzzyStringComparisonOptions.UseHammingDistance);
      if (UseJaccardDistance) list.Add(FuzzyStringComparisonOptions.UseJaccardDistance);
      //if (UseJaroDistance) list.Add(FuzzyStringComparisonOptions.UseJaroDistance);
      //if (UseJaroWinklerDistance) list.Add(FuzzyStringComparisonOptions.UseJaroWinklerDistance);
      //if (UseLevenshteinDistance) list.Add(FuzzyStringComparisonOptions.UseLevenshteinDistance);
      if (UseLongestCommonSubsequence) list.Add(FuzzyStringComparisonOptions.UseLongestCommonSubsequence);
      if (UseLongestCommonSubstring) list.Add(FuzzyStringComparisonOptions.UseLongestCommonSubstring);
      //if (UseNormalizedLevenshteinDistance) list.Add(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance);
      if (UseOverlapCoefficient) list.Add(FuzzyStringComparisonOptions.UseOverlapCoefficient);
      if (UseRatcliffObershelpSimilarity) list.Add(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity);
      if (UseSorensenDiceDistance) list.Add(FuzzyStringComparisonOptions.UseSorensenDiceDistance);
      if (UseTanimotoCoefficient) list.Add(FuzzyStringComparisonOptions.UseTanimotoCoefficient);
      return list;
    }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private Dictionary<string, DataRow> inputRows;
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private Dictionary<string, DataRow> targetRows;
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private Dictionary<string, List<Match>> matches;



    protected override IEntity doExecute()
    {
      List<FuzzyStringComparisonOptions> options = GetComparisonOptions();
      DataTable table = CreateOutputTable();

      inputRows = new Dictionary<string, DataRow>();
      targetRows = new Dictionary<string, DataRow>();

      matches = new Dictionary<string, List<Match>>();

      GenerateDictionaries(inputRows,  Entrada.Table, Column);
      GenerateDictionaries(targetRows, Alvo.Table, TargetColumn);

      foreach (KeyValuePair<string, DataRow> item in inputRows)
      {
        Decimal currentScore = 1m;

        //Nível H1 - Perfect Match
        MatchLevel_H1(item, ref currentScore);
        if (GetMatchCount(item.Key) == 0) 
        {
          MatchLevel_H2(item, ref currentScore, options);
          if ((GetMatchCount(item.Key) == 0) || (currentScore >= (Treshold))) 
          {
            MatchLevel_H3(item, ref currentScore, options);
            if ((GetMatchCount(item.Key) == 0) || (currentScore >= (Treshold))) 
            {
              MatchLevel_H4(item, ref currentScore, options);
              if ((GetMatchCount(item.Key) == 0) || (currentScore >= (Treshold))) 
              {
                MatchLevel_H5(item, ref currentScore, options);
              }
            }
          }
        }
      }

      Structure.AddToLog("Término da verificação de nomes. Início da criação do Resulset", this);
      decimal foundCt = 0m;

      table.BeginLoadData();
      foreach (KeyValuePair<string, List<Match>> match in matches)
      {

        DataRow origRow = inputRows[match.Key];

        foreach (Match item in match.Value)
        {
          DataRow row = table.NewRow();
          DataRow targetRow = targetRows[item.Text];

          row[Column] = origRow[Column];
          row[ColumnName] = targetRow[TargetColumn];
          row["Score"] = item.Score;
          row["HL"] = item.HL;

          foreach (String col in ColunasEntrada)
          {
            row[col] = origRow[col];
          }

          foreach (String col in ColunasAlvo)
          {
            row[col] = targetRow[col];
          }
          table.Rows.Add(row);
          foundCt += 1;
        }
      }

      IEnumerable<DataRow> notFound = inputRows.Where(x => !matches.ContainsKey(x.Key.NormalizeText())).Select(y => y.Value);

      foreach (DataRow nfRow in notFound)
      {
        DataRow row = table.NewRow();


        row[Column] = nfRow[Column];
        row[ColumnName] = "===[Não Encontrado]===";
        row["Score"] = 0;
        row["HL"] = 0;

        foreach (String col in ColunasEntrada)
        {
          row[col] = nfRow[col];
        }


        table.Rows.Add(row);
      }

      table.EndLoadData();

      foundCt = (decimal)(inputRows.Count - notFound.Count()) / (decimal)inputRows.Count;
      Structure.AddToLog(String.Format("{0}% de correspondência", foundCt*100), this);
      return (ResultSet)Saida;

    }

    private void MatchLevel_H1(KeyValuePair<string, DataRow> item, ref Decimal currentScore)
    {
      //Nível H1 - Perfect Match
      if (targetRows.ContainsKey(item.Key))
      {
        currentScore = 0m;
        AddMatch(item.Key, item.Key, currentScore, 1);
      }
    }


    private void MatchLevel_H2(KeyValuePair<string, DataRow> item, ref Decimal currentScore, List<FuzzyStringComparisonOptions> options)
    {
      //Nível H2 - Primeiras 3 letras e última letra
      string refValue = item.Key;
      string prefix = refValue.Remove(3);
      string suffix = refValue[refValue.Length - 1].ToString();

      IEnumerable<string> searchUniverse = targetRows.Where(x => x.Key.StartsWith(prefix) && x.Key.EndsWith(suffix)).Select(y => y.Key);

      foreach (string target in searchUniverse)
      {
        decimal localScore = refValue.ApproximatelyEquals(target, options);
        if (localScore < Treshold)
        {
          AddMatch(refValue, target, localScore, 2);
          currentScore = localScore < currentScore ? localScore : currentScore;
        }
      }
    }

    private void MatchLevel_H3(KeyValuePair<string, DataRow> item, ref Decimal currentScore, List<FuzzyStringComparisonOptions> options)
    {
      //Nível H3 - Primeiras 3 letras
      string refValue = item.Key;
      string prefix = refValue.Remove(3);

      IEnumerable<string> searchUniverse = targetRows.Where(x => x.Key.StartsWith(prefix)).Select(y => y.Key);

      foreach (string target in searchUniverse)
      {
        decimal localScore = refValue.ApproximatelyEquals(target, options);
        if (localScore < Treshold)
        {
          AddMatch(refValue, target, localScore, 3);
          currentScore = localScore < currentScore ? localScore : currentScore;
        }
      }
    }

    private void MatchLevel_H4(KeyValuePair<string, DataRow> item, ref Decimal currentScore, List<FuzzyStringComparisonOptions> options)
    {
      //Nível H4 - Primeira letra
      string refValue = item.Key;
      string prefix = refValue.Remove(1);

      IEnumerable<string> searchUniverse = targetRows.Where(x => x.Key.StartsWith(prefix)).Select(y => y.Key);

      foreach (string target in searchUniverse)
      {
        decimal localScore = refValue.ApproximatelyEquals(target, options);
        if (localScore < Treshold)
        {
          AddMatch(refValue, target, localScore, 4);
          currentScore = localScore < currentScore ? localScore : currentScore;
        }
      }
    }

    private void MatchLevel_H5(KeyValuePair<string, DataRow> item, ref Decimal currentScore, List<FuzzyStringComparisonOptions> options)
    {
      //Nível H6 - Brute Force
      string refValue = item.Key;

      IEnumerable<string> searchUniverse = targetRows.Select(y => y.Key);

      foreach (string target in searchUniverse)
      {
        decimal localScore = refValue.ApproximatelyEquals(target, options);
        if (localScore < Treshold)
        {
          AddMatch(refValue, target, localScore, 5);
          currentScore = localScore < currentScore ? localScore : currentScore;
        }
      }
    }

    private void AddMatch(string key, string target, Decimal score, int hL)
    {
      if (!matches.ContainsKey(key))
      {
        matches[key] = new List<Match>();
      }

      matches[key].Add(new Match(target, score, hL));
    }

    private int GetMatchCount(string key)
    {
      if (!matches.ContainsKey(key))
      {
        matches[key] = new List<Match>();
      }

      return matches[key].Count;
    }

    private void GenerateDictionaries(Dictionary<string, DataRow> rows, DataTable table, string col)
    {
      for (int i = 0; i < table.Rows.Count; i++)
      {
        DataRow row = table.Rows[i];
        string refValue = Convert.ToString(row[col]);

        rows[refValue.NormalizeText()] = row;        
      }
    }

    private DataTable CreateOutputTable()
    {
      ResultSet saida = (ResultSet)Saida;

      if (saida.Table == null)
        saida.Table = new DataTable(saida.Name);

      DataTable table = saida.Table;

      table.Clear();
      //Coluna Base
      TryCreateColumn(table, Entrada, Column);

      //Coluna Resultante
      TryCreateColumn(table, typeof(string), ColumnName);

      TryCreateColumn(table, typeof(Decimal), "Score");
      TryCreateColumn(table, typeof(int), "HL");


      foreach (String col in ColunasEntrada)
      {
        TryCreateColumn(table, Entrada, col);
      }

      foreach (String col in ColunasAlvo)
      {
        TryCreateColumn(table, Alvo, col);
      }
      return table;
    }

    private void TryCreateColumn(DataTable table, IResultSet refTable, string colName)
    {
      Type dataType = refTable == null ? typeof(string) : refTable.Table.Columns[colName].DataType;
      TryCreateColumn(table, dataType, colName);
    }
    private void TryCreateColumn(DataTable table, Type type, string colName)
    {
      if (table.Columns.Contains(colName))
      {
        table.Columns.Remove(colName);
      }
      table.Columns.Add(colName, type);
    }


    struct Match
    {
      public Match(string text, Decimal score, int hL)
      {
        Text = text;
        Score = (1 - score) * 100;
        HL = hL;
      }
      public Decimal Score;
      public string Text;
      public int HL;
    }
  }

 

}


