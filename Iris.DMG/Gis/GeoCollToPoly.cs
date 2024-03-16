using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Databridge.Engine.Extensions;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using Databridge.Engine.Data;
using System.ComponentModel;

namespace Iris.DMG.Gis
{
  [Serializable]

  [OperationCategory("GIS", "GeoCol2Poly")]
  public class GeoCollToPoly : ColumnBasedOperation
  {
    public GeoCollToPoly(Structure aStructure, string aName) : base(aStructure, aName)
    {
    }

    protected override IEntity doExecute()
    {

      if (Entrada == null)
        throw new Exception("Resultset de entrada não atribuído");

      DataTable table = Entrada.Table;
      DataConnection con = (DataConnection)Entrada.Connection;
      IDbCommand cmd = con.Connection.CreateCommand();

      if(con.ConnectionState != ConnectionState.Open)
       con.Open();
      foreach (DataRow row in table.Rows)
      {
        string wkt = Convert.ToString(row[ColunaBase]);
        if (wkt != "GEOMETRYCOLLECTION EMPTY")
        {
          string poly = GetLargestPoly(wkt);

          string commandText = $"update {TableName} set {ColunaBase} = geometry::STGeomFromText('{poly}', {GeoType})   where {ColunaResultante} = {row[ColunaResultante]}";
          cmd.CommandText = commandText;
          cmd.ExecuteNonQuery();
        }




      }
      
      return null;
    }

    [DisplayName("Chave")]
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

    public string TableName { get; set; }
    public string GeoType { get; set; }

    private string GetLargestPoly(string wkt)
    {
      List<string> polys = ExtractPolygons(wkt);
      string result = "";
      int size = 0;
      foreach (string poly in polys)
      {
        int pSize = GetPolySize(poly);
        if(pSize>size)
        {
          size = pSize;
          result = poly;
        }
      }
      return result;
    }

    private int GetPolySize(string poly)
    {
      return poly.MatchAll(",").Count();
    }

    private List<string> ExtractPolygons(string wkt)
    {
      string tmpWkt = wkt.ToUpper();

      List<string> polys = new List<string>();

      while (tmpWkt.Contains("POLYGON"))
      {
        tmpWkt = tmpWkt.Substring("POLYGON").Substring("(");
        int level = 0;

        StringBuilder sb = new StringBuilder();

        sb.Append("POLYGON");
        for (int i = 0; i < tmpWkt.Length; i++)
        {
          if (tmpWkt[i] == '(')
            level++;
          if (tmpWkt[i] == ')')
            level--;

          if (level > 0)
            sb.Append(tmpWkt[i]);
          else
          {
            sb.Append(')');
            break;
          }
        }

        if (level > 0)
        {
          for (int i = 0; i < level; i++)
          {
            sb.Append(')');
          }
        }
        polys.Add(sb.ToString());
      }

      return polys;

    }
  }
}
