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

namespace Iris.FuzzyString
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Fuzzy Match")]
  public class FuzzyMatchScore : ColumnBasedOperation, IFuzzyMatchScore
  {
    public FuzzyMatchScore(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "FonteComp.");
      SetOutputs("Saída");
    }


    [Browsable(false)]
    public IResultSet Fonte
    {
      get
      {
        IOperation input = GetInput("FonteComp.");
        if (input == null)
          throw new Exception("Resultset de fonte de comparação não atribuído");
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



    private String sourceColumn;
    [Editor(typeof(FuzzyColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Coluna Fonte"), Category("Expressão")]
    public virtual String SourceColumn
    {
      get { return sourceColumn; }
      set
      {
        if (sourceColumn != value)
        {
          sourceColumn = value;
        }
      }
    }



    [Editor(typeof(InputColumnListEditor), typeof(UITypeEditor))]
    [DisplayName("Colunas Entrada"), Category("Expressão"), Description("Colunas da tabela Entrada a serem incluídas no RS gerado")]
    public List<string> ColunasEntrada { get; set; }
    [Editor(typeof(SourceColumnListEditor), typeof(UITypeEditor))]
    [DisplayName("Colunas Fonte"), Category("Expressão"), Description("Colunas da tabela Fonte a serem incluídas no RS gerado")]
    public List<string> ColunasFonte { get; set; }


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
    [Category("Fuzzy Logic")]
    public bool CaseSensitive { get; set; }

    [Category("Fuzzy Logic")]
    public FuzzyStringComparisonTolerance Tolerance { get; set; }

    [Category("Fuzzy Logic")]
    public int LimitMatches { get; set; }

    private List<FuzzyStringComparisonOptions> GetComparisonOptions()
    {
      List<FuzzyStringComparisonOptions> list = new List<FuzzyStringComparisonOptions>();

      if (UseHammingDistance) list.Add(FuzzyStringComparisonOptions.UseHammingDistance);
      if (UseJaccardDistance) list.Add(FuzzyStringComparisonOptions.UseJaccardDistance);
      if (UseJaroDistance) list.Add(FuzzyStringComparisonOptions.UseJaroDistance);
      if (UseJaroWinklerDistance) list.Add(FuzzyStringComparisonOptions.UseJaroWinklerDistance);
      if (UseLevenshteinDistance) list.Add(FuzzyStringComparisonOptions.UseLevenshteinDistance);
      if (UseLongestCommonSubsequence) list.Add(FuzzyStringComparisonOptions.UseLongestCommonSubsequence);
      if (UseLongestCommonSubstring) list.Add(FuzzyStringComparisonOptions.UseLongestCommonSubstring);
      if (UseNormalizedLevenshteinDistance) list.Add(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance);
      if (UseOverlapCoefficient) list.Add(FuzzyStringComparisonOptions.UseOverlapCoefficient);
      if (UseRatcliffObershelpSimilarity) list.Add(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity);
      if (UseSorensenDiceDistance) list.Add(FuzzyStringComparisonOptions.UseSorensenDiceDistance);
      if (UseTanimotoCoefficient) list.Add(FuzzyStringComparisonOptions.UseTanimotoCoefficient);
      if (CaseSensitive) list.Add(FuzzyStringComparisonOptions.CaseSensitive);
      return list;
    }

    protected override IEntity doExecute()
    {


      ResultSet saida = (ResultSet)Saida;

      if (saida.Table == null)
        saida.Table = new DataTable(saida.Name);

      DataTable table = saida.Table;

      table.Clear();
      List<FuzzyStringComparisonOptions> options = GetComparisonOptions();
      //Coluna Base
      TryCreateColumn(table, Entrada, Column);

      //Coluna Resultante
      TryCreateColumn(table, null, ColumnName);

      foreach (String col in ColunasEntrada)
      {
        TryCreateColumn(table, Entrada, col);
      }

      foreach (String col in ColunasFonte)
      {
        TryCreateColumn(table, Fonte, col);
      }

      ConcurrentBag<DataRow> results = new ConcurrentBag<DataRow>();

      Dictionary<string, int> resultCounter = new Dictionary<string, int>();

      SpinLock sl = new SpinLock();

      foreach (DataRow row in Entrada.Table.Rows)
      {
        string refValue = Convert.ToString(row[Column]);

        Parallel.ForEach<DataRow>(Fonte.Table.Rows.Cast<DataRow>(), (sourceRow, state) =>
        {
          bool locked = false;
          string sourceValue = Convert.ToString(sourceRow[SourceColumn]);

          if (!String.IsNullOrEmpty(sourceValue) && !String.IsNullOrEmpty(refValue))
          {
            if (sourceValue.ApproximatelyEquals(refValue, options, Tolerance))
            {
              DataRow resultRow;
              sl.Enter(ref locked);
              try
              {
                resultRow = table.NewRow();
              }
              finally
              {
                if (locked)
                  sl.Exit();
              }

              resultRow[Column] = row[Column];
              resultRow[ColumnName] = sourceValue;

              foreach (String col in ColunasEntrada)
              {
                resultRow[col] = row[col];
              }

              foreach (String col in ColunasFonte)
              {
                resultRow[col] = sourceRow[col];
              }
              results.Add(resultRow);

              if (LimitMatches > 0)
              {
                bool shouldBreak = false;
                sl.Enter(ref locked);
                try
                {
                  if (!resultCounter.ContainsKey(refValue))
                    resultCounter[refValue] = 1;
                  else
                    resultCounter[refValue] += 1;

                  shouldBreak = (resultCounter[refValue] >= LimitMatches);
                }
                finally
                {
                  if (locked)
                    sl.Exit();
                }

                if (shouldBreak)
                  state.Break();
              }
            }
          }
        });
      }


      table.BeginLoadData();
      foreach (DataRow item in results)
      {
        table.Rows.Add(item);
      }
      table.EndLoadData();

      return (ResultSet)Saida;

    }

    private void TryCreateColumn(DataTable table, IResultSet refTable, string colName)
    {
      if (table.Columns.Contains(colName))
      {
        table.Columns.Remove(colName);
      }

      Type dataType = refTable == null ? typeof(string) : refTable.Table.Columns[colName].DataType;

      table.Columns.Add(colName, dataType);
    }
  }
}
