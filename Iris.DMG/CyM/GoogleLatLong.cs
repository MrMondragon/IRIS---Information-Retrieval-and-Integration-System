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
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Databridge.Engine.Web;

namespace Iris.DMG.CyM
{

  [Serializable]
  [OperationCategory("CyberMonitor", "Geo Localizador de Endereços")]
  public class GoogleLatLong : ColumnBasedOperation
  {
    public GoogleLatLong(Structure aStructure, string aName) : base(aStructure, aName)
    {
      LatLongSeparator = ";";
    }

    public string ApiKeys { get; set; }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private List<string> apiKeys;

    public string LatLongSeparator { get; set; }


    protected override IEntity doExecute()
    {
      if(!string.IsNullOrWhiteSpace(ApiKeys))
      {
        apiKeys = ApiKeys.Split(';', ' ', '|').ToList();
      }
      else
      {
        apiKeys = new List<string>() { "AIzaSyDB70Ba-zOvqPTvGDFJU8LOj7kZveu1R0Q", "AIzaSyAEe6e-wIpnKZpEo8CyzdN-8ss7NkGqkew" };
      }

      DataTable table = Entrada.Table;

      if (!table.Columns.Contains(ColunaResultante))
        table.Columns.Add(ColunaResultante);

      int ct = 0;

      foreach (DataRow row in table.Rows)
      {
        string endereco = Convert.ToString(row[ColunaBase]);
        string apiKey1 = "AIzaSyDB70Ba-zOvqPTvGDFJU8LOj7kZveu1R0Q";
        string apiKey2 = "AIzaSyAEe6e-wIpnKZpEo8CyzdN-8ss7NkGqkew";

        string apiKey = ct % 2 == 0 ? apiKey1 : apiKey2;
        ct++;
        string resp = WebRequester.ReadRequest($"https://maps.googleapis.com/maps/api/geocode/xml?sensor=false&address={endereco}&key={apiKey}");
        ContentExtractor extractor = new ContentExtractor(resp, true);
        string lat = extractor.Extract("{flat}.location<>.lat<>[1](Html)").Substring(">").Remove("<").Trim('>');
        string lng = extractor.Extract("{flat}.location<>.lng<>[1](Html)").Substring(">").Remove("<").Trim('>');

        Structure.AddToLog($"{ct}   ---   {endereco}  --  {apiKey}", this);

        row[ColunaResultante] = string.Join(LatLongSeparator, lat, lng);
      }


      return null;
    }


  
  }
}
