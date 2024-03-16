

   using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;

public class csLote
{
  

  #region IIrisRunnable Members

  public Object Execute()
  {
    
    if(!unionTable.Columns.Contains("X"))
      unionTable.Columns.Add("X");
    
    if(!unionTable.Columns.Contains("Y"))
      unionTable.Columns.Add("Y");
  
    foreach (DataRow row in unionTable.Rows)
    {
      string logradouro = Convert.ToString(row["co_logradouro"]);      
      Dictionary<int,string> lotesLog = GetLotesLog(logradouro);
      
      int numero = Convert.ToInt32(row["Numero"]);      
      
      if(lotesLog.ContainsKey(numero))
        SetXY(row, lotesLog[numero]);
      else
        SetXY(row, Approximate(lotesLog, numero));
    }
    
    return null;
  }
  
  private string Approximate(Dictionary<int, string> lotesLog, int numero)
  {
    int[] numerosLog = lotesLog.Select(x=> x.Key).Where(y=> y%2 == numero%2).ToArray();
    
    if(numerosLog.Length == 0)
      return "";
    
    int key = -1;
    
    if(numerosLog.Length == 1)
      key = numerosLog[0];
    else if(numero < numerosLog.Min())
      key = numerosLog.Min();
    else if(numero > numerosLog.Max())
      key = numerosLog.Max();
    else
    {
      int prev = numerosLog.Where(x=> x < numero).Max();
      int next = numerosLog.Where(x=> x > numero).Min();
      
      int d1 = Math.Abs(numero - prev);
      int d2 = Math.Abs(next - numero);
      
      if(d1<d2)
        key = prev;
      else        
        key = next;     
    }
    
    if(key != -1)    
      return lotesLog[key];
    else 
      return "";
  }
  
  private void SetXY(DataRow row, string xy)
  {
    if(!String.IsNullOrEmpty(xy))
    {
      string[] x_y = xy.Split('|');
    
      row["X"] = x_y[0];
      row["Y"] = x_y[1];
    }
  }
  
  private Dictionary<string, Dictionary<int,string>> lotes;
  private DataTable oritb_Lotes;
  private DataTable   unionTable;
  private Dictionary<int,string> GetLotesLog(string numero)
  {
    if(lotes == null)
    {
      lotes = new Dictionary<string, Dictionary<int,string>>();
    }
    
    if(!lotes.ContainsKey(numero))
    {
      DataRow[] rows = oritb_Lotes.Select("CO_LOGRADOURO = '"+numero+"'");
      lotes[numero] = new Dictionary<int, string>();
      for (int i = 0; i < rows.Length; i++)
      {
        lotes[numero][Convert.ToInt32(rows[i]["NU_IMOVEL"])] = Convert.ToString(rows[i]["X_COORDENADA"])+"|"+Convert.ToString(rows[i]["Y_COORDENADA"]);
      }
    }
    return lotes[numero];
  }
  
  #endregion
}


