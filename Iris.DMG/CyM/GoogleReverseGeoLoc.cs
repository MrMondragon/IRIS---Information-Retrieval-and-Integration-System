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
  [OperationCategory("CyberMonitor", "Geo Localizador de Coordenadas")]
  public class GoogleReverseGeoLoc : ColumnBasedOperation
  {
    public GoogleReverseGeoLoc(Structure aStructure, string aName) : base(aStructure, aName)
    {
      LatLongSeparator = ",";
    }

    public bool InvertLatLong { get; set; }

    public string ApiKeys { get; set; }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private List<string> apiKeys;

    public string LatLongSeparator { get; set; }


    protected override IEntity doExecute()
    {
      if (!string.IsNullOrWhiteSpace(ApiKeys))
      {
        apiKeys = ApiKeys.Split(';', ' ', '|').ToList();
      }
      else
      {
        apiKeys = new List<string>() { "AIzaSyDB70Ba-zOvqPTvGDFJU8LOj7kZveu1R0Q", "AIzaSyAEe6e-wIpnKZpEo8CyzdN-8ss7NkGqkew" };
      }

      DataTable table = Entrada.Table;


      int ct = 0;

      foreach (DataRow row in table.Rows)
      {
        string latLong = Convert.ToString(row[ColunaBase]);

        if(InvertLatLong)
        {
          string[] latLng = latLong.Split(LatLongSeparator.ToCharArray());
          latLong = latLng[1] + LatLongSeparator + latLng[0];
        }

        string apiKey1 = "AIzaSyDB70Ba-zOvqPTvGDFJU8LOj7kZveu1R0Q";
        string apiKey2 = "AIzaSyAEe6e-wIpnKZpEo8CyzdN-8ss7NkGqkew";

        string apiKey = ct % 2 == 0 ? apiKey1 : apiKey2;
        ct++;
        string resp = WebRequester.ReadRequest($"https://maps.googleapis.com/maps/api/geocode/xml?sensor=false&address={latLong}&key={apiKey}");
        ContentExtractor extractor = new ContentExtractor(resp, true);

        string result = extractor.Extract("{flat}.result<>[1](Html)");
        result = extractor.Extract("{flat}.address_component<>[0](Html)");

        result = result.Extract("<type>political</type>");
        List<string> resultLines = result.Split('\r', '\n').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

        Dictionary<string, string> resultValues = new Dictionary<string, string>();

        string key = "";
        string value = "";

        for (int i = 0; i < resultLines.Count; i++)
        {
          string line = resultLines[i];
          string state = line.Remove(">").Trim('<', ' ');
          switch (state)
          {
            case "long_name":
              {
                value = line.Substring(">").Remove("<").TrimStart('<', '>');
              }
              break;
            case "type":
              {
                string tmpValue = line.Substring(">").Remove("<").Trim('<', '>');
                if (tmpValue.Length > value.Length)
                  key = tmpValue;
              }
              break;
            case "/address_component":
            case "address_component":
              {
                if(!string.IsNullOrEmpty(key))
                  resultValues[key] = value;
                key = "";
                value = "";
              }
              break;
            default:
              break;
          }
        }


        foreach (KeyValuePair<string,string> item in resultValues)
        {
          if (!table.Columns.Contains(item.Key))
          {
            table.Columns.Add(item.Key);
          }

          row[item.Key] = item.Value;
        }




      }


      return null;
    }



  }
}
