using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using System.Data;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.Entities.Schemas;
using Databridge.Engine.Extensions;
using System.Windows.Forms.Design;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System.Threading.Tasks;

namespace Iris.DMG.CyM
{
  [Serializable]
  [OperationCategory("CyberMonitor", "Tokenizador")]
  public class CymTokenizer : ColumnBasedOperation
  {
    public CymTokenizer(Structure aStructure, string aName) : base(aStructure, aName)
    {
      Level = TokenizationLevel.Document;
      SetInputs("Entrada", "StopWords", "NGrams");
      SetOutputs("Saída");
    }

    public override void Reset()
    {
      base.Reset();
      stopWords = null;
      nGrams = null;
    }

    [DisplayName("Coluna Texto")]
    public override string Column
    {
      get
      {
        return base.Column;
      }
      set
      {
        base.Column = value;
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

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private List<string> stopWords;

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private Dictionary<string, List<string>> nGrams;


    [Category("Tokenization")]
    public int MinSize { get; set; }

    [Category("Tokenization")]
    public TokenizationLevel Level { get; set; }

    [Category("Tokenization")]
    public string SpliterComplement { get; set; }

    [Category("Tokenization")]
    public bool CreateID { get; set; }
    [Category("Tokenization")]
    public bool CreateSeq { get; set; }

    [Category("Tokenization")]
    public bool MultiThread { get; set; }

    private List<string> Split(string text)
    {
      char[] splitter = GetSplitter().ToCharArray();

      List<string> splittedText = text.Split(splitter).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

      return splittedText;
    }

    private string GetSplitter()
    {
      switch (Level)
      {
        case TokenizationLevel.Document:
          return "|\r\n§" + SpliterComplement;
        case TokenizationLevel.Sentence:
          return "!?.:;" + SpliterComplement;
        default:
          return " ,()[]{}_\"'" + SpliterComplement;
      }
    }

    private string GetPrefix()
    {
      return Level.ToString().Remove(3) + "_";
    }

    protected override IEntity doExecute()
    {
      ResultSet entradaRS = (ResultSet)GetInput("Entrada").EntityValue;
      DataTable entrada = entradaRS.Table;

      ResultSet sw = (ResultSet)GetInput("StopWords");
      if (sw != null)
      {
        stopWords = sw.Table.Rows.Cast<DataRow>().Select(x => Convert.ToString(x[0])).ToList();
      }

      ResultSet ng = (ResultSet)GetInput("NGrams");
      if (ng != null)
      {
        List<string> keys = ng.Table.Rows.Cast<DataRow>().Select(x => Convert.ToString(x[0]).ToLower().Remove(" ").Trim()).Distinct().ToList();
        nGrams = new Dictionary<string, List<string>>();
        foreach (DataRow row in ng.Table.Rows)
        {
          string key = Convert.ToString(row[0]).ToLower().Remove(" ").Trim();

          string value = Convert.ToString(row[0]).ToLower().Substring(" ").Trim();

          if (!nGrams.ContainsKey(key))
            nGrams[key] = new List<string>();

          nGrams[key].Add(value);
        }
      }

      ResultSet saidaRS = (ResultSet)GetOutput("Saída").EntityValue;
      saidaRS.Clear();
      DataTable saida = new DataTable(saidaRS.Name);
      saidaRS.Table = saida;

      //replica a estrutura da tabela de entrada sem a coluna texto
      foreach (DataColumn column in entrada.Columns)
      {
        if (column.ColumnName != ColunaBase)
          saida.Columns.Add(column.ColumnName, column.DataType, column.Expression);
      }

      if (CreateID)
        saida.Columns.Add(GetPrefix() + "cod", typeof(Guid));
      if (CreateSeq)
        saida.Columns.Add(GetPrefix() + "seq", typeof(int));

      saida.Columns.Add(GetTokenColumnName());

      saida.BeginLoadData();

      if (!MultiThread)
      {
        foreach (DataRowView dataRowView in entradaRS.View)
        {
          TokenizeRow(dataRowView, saida);
        }
      }
      else
      {
        Parallel.ForEach(entradaRS.View.Cast<DataRowView>(), dataRowView =>
        {
          TokenizeRow(dataRowView, saida);
        });
      }

      saida.EndLoadData();

      return null;
    }

    private string GetTokenColumnName()
    {
      return GetPrefix() + Level.ToString();
    }

    private void TokenizeRow(DataRowView row, DataTable saida)
    {
      string text = Convert.ToString(row[ColunaBase]).Trim(GetSplitter().ToCharArray());
      if (!string.IsNullOrWhiteSpace(text))
      {
        List<string> tokens = Split(text);
        int ct = 0;
        for (int i = 0; i < tokens.Count; i++)
        {
          string tokenText = tokens[i].Trim();

          if (nGrams != null)
          {
            if (nGrams.ContainsKey(tokenText.ToLower()))
            {
              List<string> possibleGrams = nGrams[tokenText.ToLower()];

              foreach (string candidate in possibleGrams)
              {
                List<string> grams = candidate.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                bool match = true;

                for (int j = 0; j < grams.Count; j++)
                {
                  if ((i + j + 1) < tokens.Count)
                  {
                    string gPart = grams[j];
                    match &= tokens[i + j + 1].ToLower() == gPart;
                  }
                  else
                    match = false;
                }

                if (match)
                {
                  for (int j = 0; j < grams.Count; j++)
                  {
                    tokenText += " " + tokens[i + j + 1];
                    tokens[i + j + 1] = "";
                  }
                  break;
                }
              }
            }
          }



          if (!string.IsNullOrWhiteSpace(tokenText) && (((MinSize > 0) && (tokenText.Length > MinSize)) || (MinSize == 0)))
          {
            ct++;

            if ((stopWords != null) && (!stopWords.Contains(tokenText.ToLower())) || (stopWords == null))
            {


              DataRow newRow = saida.NewRow();

              foreach (DataColumn column in saida.Columns)
              {
                if (row.DataView.Table.Columns.Contains(column.ColumnName))
                {
                  newRow[column.ColumnName] = row[column.ColumnName];
                }
              }

              if (CreateID)
                newRow[GetPrefix() + "cod"] = Guid.NewGuid();

              if (CreateSeq)
                newRow[GetPrefix() + "seq"] = ct;

              newRow[GetTokenColumnName()] = tokenText;

              lock (saida)
              {
                saida.LoadDataRow(newRow.ItemArray, false);
              }
            }
          }
        }
      }
    }
  }

  public enum TokenizationLevel
  {
    Document,
    Sentence,
    Token
  }
}
