using System;
namespace Iris.Runtime.Model.Entities.Txt
{
  public interface ITextLine
  {
    char Delimiter { get; set; }
    System.Collections.Generic.List<string> GetFieldList();
    int IgnoreFirst { get; set; }
    System.Collections.Generic.Dictionary<string, string> Link { get; set; }
    string RowToLine(System.Data.DataRow row);
    string Name { get; set;}
    ITextLine Master { get;set;}
    System.Data.DataTable Table { get; set; }
    string TableName { get; set; }
    string ToString();
    string ValidationXpression { get; set; }
  }
}
