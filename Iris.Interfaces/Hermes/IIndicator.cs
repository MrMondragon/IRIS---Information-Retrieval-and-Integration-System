using System;
namespace Hermes.Engine
{
  public interface IIndicator
  {
    System.Data.DataTable DataView { get; set; }
    string GetDimensionText(string dimensionFieldName, string value, string filter);
    string GetFactText(string factFieldName, string coord, string filter);
    double GetFactValue(string factFieldName, string coord, string filter);
    string GetPrevItemText(string factFieldName, string coord, string filter);
    void InvalidateCache();
    void InvalidateDimension(string field);
    void InvalidateFact(string field);
    void InvalidateFactCache();
    string SortOrder { get; set; }
  }
}
