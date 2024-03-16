using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Databridge.Engine.Criptography;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.ComponentModel;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.DMG
{
  [OperationCategory("DMG", "SurrogateKeyGen")]
  [Serializable]
  public class SurrogateKeyGenerator : ColumnBasedOperation
  {
    public SurrogateKeyGenerator(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      SetOutputs("SurSaída");
    }

    private string stBase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public string Classifier { get; set; }

    protected override Interfaces.IEntity doExecute()
    {
      ResultSet surSaida = GetOutput("SurSaída") as ResultSet;
      if (surSaida.Table == null)
      {
        surSaida.Table = new DataTable(surSaida.Name);

        surSaida.Table.Columns.Add("NaturalKey", typeof(string));
        if (!string.IsNullOrWhiteSpace(Classifier))
          surSaida.Table.Columns.Add("Classifier", typeof(string));
        surSaida.Table.Columns.Add("IntKey", typeof(int));
        surSaida.Table.Columns.Add("SurrogateKey", typeof(string));
      }
      else
      {
        surSaida.Table.AcceptChanges();
      }
      if (!string.IsNullOrWhiteSpace(Classifier))
        surSaida.Table.PrimaryKey = new DataColumn[] { surSaida.Table.Columns["NaturalKey"], surSaida.Table.Columns["Classifier"] };
      else
        surSaida.Table.PrimaryKey = new DataColumn[] { surSaida.Table.Columns["NaturalKey"] };
      surSaida.Table.BeginLoadData();
      foreach (DataRow row in Entrada.Table.Rows)
      {
        DataRow newRow = surSaida.Table.NewRow();
        newRow["NaturalKey"] = Convert.ToString(row[ColunaBase]);

        if(!string.IsNullOrWhiteSpace(Classifier))
          newRow["Classifier"] = Classifier;

        surSaida.Table.LoadDataRow(newRow.ItemArray, LoadOption.Upsert);
      }
      surSaida.Table.EndLoadData();

      foreach (DataRow row in surSaida.Table.Rows)
      {
        if (row.RowState == DataRowState.Modified)
          row.RejectChanges();
      }

      int? maxSK = null;
      DataRow[] oldRows = surSaida.Table.Select("SurrogateKey is not null");
      if (oldRows.Length > 0)
        maxSK = oldRows.Cast<DataRow>().Select(x => Convert.ToInt32(x["IntKey"])).Max();

     Big bigSK = -1;
      if (maxSK.HasValue)
        bigSK = maxSK.Value;

      DataRow[] emptyRows = surSaida.Table.Select("SurrogateKey is null");
 

      for (int i = 0; i < emptyRows.Length; i++)
      {
        bigSK++;
        string sk = Cube.InvertString(Cube.BigToString(bigSK, stBase));

        emptyRows[i]["SurrogateKey"] = sk;
        emptyRows[i]["IntKey"] = bigSK.IntValue;
      }

      return null;
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
