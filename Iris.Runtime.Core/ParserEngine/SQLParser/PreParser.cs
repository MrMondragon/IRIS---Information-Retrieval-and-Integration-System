using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Iris.Runtime.Core.ParserEngine
{
  public static class PreParser
  {
    public static string PreParseSQL(string sql, out Dictionary<string, object> parameters, XEvalParser xParser)
    {
      parameters = null;
      return "";
    }

    public static string AddToWhere(string sql, string filter, XEvalParser xParser)
    {
      return "";
    }

    public static string AddTableToFilter(string sql, DataTable table,
      List<KeyValuePair<string, string>> fieldMap, out Dictionary<object, string> parameters)
    {
      parameters = null;
      return "";
    }

    public static string GetMainTable(string sql)
    {
      return "";
    }

  }
}


/*
 * Requisitos:
 * 
 * Deve ser capaz de fazer a mesclagem de parâmetros XEval em consultas sql, 
 *    retornando a consulta modificada e uma coleção de parâmetros tipados.
 *    
 * Deve ser capaz de restaurar a query original (caso ela seja alterada no objeto, e não apenas retornada)
 * 
 * Deve ser capaz de localizar a cláusula Where principal de uma sentença e alterá-la
 *    - Deve ser capaz de gerar filtros de um dataset sobre outro
 *    - Deve ser capaz de acrescentar filtros literais (com ou sem fórmulas XEval)
 *    
 * Deve ser capaz de localizar a cláusula From principal de uma sentença e identificar a tabela principal, 
 *    mesmo em sentenças complexas
 * 
 * Converter entre parâmetros nomeados no padrão :Nome e parâmetros nomeados segundo o padrão da conexão ativa ??
*/