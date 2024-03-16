using System;
namespace Iris.Runtime.Model.Entities.Txt
{
  public interface ITextField
  {
    bool AbortOnError { get; set; }
    bool AutoInc { get; set; }
    string ConvertToString(object value);
    object ConvertToType(string value);
    Type DataType { get; set; }
    object DefaultValue { get; set; }
    string Mask { get; set; }
    char PaddingChar { get; set; }
    bool ParentRef { get; set; }
    int PosFinal { get; }
    int PosInicio { get; }
    bool PrimaryKey { get; set; }
    bool ReadOnly { get; set; }
    bool Required { get; set; }
    int Size { get; set; }
    string ToString();
    bool TrimEnd { get; set; }
    bool TrimStart { get; set; }
    string ValidationXpression { get; set; }
  }
}
