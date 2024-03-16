using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.DynamicsServices
{
  [Serializable]
  public class CRMPropMapper
  {
    public PropertyType DataType { get; set; }
    public bool Lookup { get; set; }
    public string FieldName { get; set; }
    public string LookupEntity { get; set; }
    public bool Id { get; set; }
    public override string ToString()
    {
      return string.Format("{0}({1})", FieldName, DataType);
    }
  }
}
