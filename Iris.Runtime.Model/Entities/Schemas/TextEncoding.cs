using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Runtime.Model.Entities.Schemas
{
  [Serializable]
  public enum TextEncoding
  {
    Default,
    ASCII,
    BigEndianUnicode,
    Unicode,
    UTF32,
    UTF7,
    UTF8
  }
}
