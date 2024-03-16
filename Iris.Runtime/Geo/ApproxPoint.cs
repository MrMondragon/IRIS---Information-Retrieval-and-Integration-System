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
using Iris.FuzzyString;

namespace Iris.Runtime.Geo
{
  [Serializable]
  [OperationCategory("Transformações", "Aproximação de Ponto")]
  public class ApproxPoint : ColumnBasedOperation, IFuzzyMatchScore
  {
    public ApproxPoint(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Alvo");
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

    [DisplayName("Simplificação"), Category("Expressão")]
    public int Simplification { get; set; }
    [DisplayName("Complexificação"), Category("Expressão")]
    public int Complexification { get; set; }

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

    [Editor(typeof(SourceColumnListEditor), typeof(UITypeEditor))]
    [DisplayName("Colunas Alvo"), Category("Expressão"), Description("Colunas da tabela Alvo a serem incluídas no RS gerado")]
    public List<string> ColunasAlvo { get; set; }

    [NonSerialized]
    private List<PolyLine> linhas;

    [NonSerialized]
    private Dictionary<Coordinate, PolyLine> approximates;

    public override void Reset()
    {
      if (linhas != null)
        linhas.Clear();
      if (approximates != null)
        approximates.Clear();
      base.Reset();
    }

    protected override IEntity doExecute()
    {
      Dictionary<Coordinate, DataRow> registrosOrigem = new Dictionary<Coordinate, DataRow>();
      List<Coordinate> pontos = new List<Coordinate>();
      for (int i = 0; i < Entrada.Table.Rows.Count; i++)
      {
        DataRow row = Entrada.Table.Rows[i];
        string stCoord = Convert.ToString(row[ColunaBase]);
        if (!string.IsNullOrEmpty(stCoord))
        {
          Coordinate coord = Coordinate.ParsePoint(stCoord);
          registrosOrigem[coord] = row;
          pontos.Add(coord);
        }
      }

      Dictionary<PolyLine, DataRow> registrosAlvo = new Dictionary<PolyLine, DataRow>();
      linhas = new List<PolyLine>();

      for (int i = 0; i < Alvo.Table.Rows.Count; i++)
      {
        DataRow row = Alvo.Table.Rows[i];
        PolyLine line;

        if (Simplification > Complexification)
          line = PolyLine.ParsePoints(Convert.ToString(row[TargetColumn])).Simplify(Simplification);
        else
          line = PolyLine.ParsePoints(Convert.ToString(row[TargetColumn])).Complexify(Complexification);

        registrosAlvo[line] = row;

        linhas.Add(line);

      }

      approximates = new Dictionary<Coordinate, PolyLine>();

      foreach (Coordinate ponto in pontos)
      {
        TestPointAgainstLines(ponto);
      }

      foreach (string item in ColunasAlvo)
      {
        if ((!Entrada.Table.Columns.Contains(item)) && (Alvo.Table.Columns.Contains(item)))
        {
          DataColumn col = Alvo.Table.Columns[item];
          Entrada.Table.Columns.Add(col.ColumnName, col.DataType, col.Expression);
        }
      }

      Entrada.Table.BeginLoadData();
      foreach (KeyValuePair<Coordinate, DataRow> item in registrosOrigem)
      {
        DataRow rowOrigem = item.Value;
        PolyLine lineKey = approximates[item.Key];
        DataRow rowAlvo = registrosAlvo[lineKey];
        if (ColunasAlvo.Count > 1)
        {
          foreach (string col in ColunasAlvo)
          {
            rowOrigem[col] = rowAlvo[col];
          }
        }
        else
        {
          if (!Entrada.Table.Columns.Contains(ColunaResultante))
            Entrada.Table.Columns.Add(ColunaResultante, this.DataType);

          rowOrigem[ColunaResultante] = rowAlvo[ColunasAlvo.First()];
        }
      }
      Entrada.Table.EndLoadData();

      return null;
    }

    private void TestPointAgainstLines(Coordinate point)
    {
      SpinLock sl0 = new SpinLock();
      bool gotLock = false;
      double minDistance = double.MaxValue;
      PolyLine? line = null;

      foreach (PolyLine linha in linhas)
      {
        double distance = linha.ShortestDistanceToPoint(point);
        if (distance < minDistance)
        {
          sl0.Enter(ref gotLock);
          try
          {
            line = linha;
            minDistance = distance;
          }
          finally
          {
            if (gotLock)
              sl0.Exit();

            gotLock = false;
          }
        }
      }

      SpinLock sl = new SpinLock();
      if (line.HasValue)
      {

        sl.Enter(ref gotLock);
        try
        {
          approximates[point] = line.Value;
        }
        finally
        {
          if (gotLock)
            sl.Exit();
        }
      }
    }


    #region IFuzzyMatchScore Members

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    List<string> IFuzzyMatchScore.ColunasEntrada
    {
      get
      {
        return null;
      }
      set
      {
      }
    }


    #endregion

  }
}
