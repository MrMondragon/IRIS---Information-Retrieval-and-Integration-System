using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Interfaces
{
  [Serializable]
  public class MaskItem
  {
    public int Length { get; set; }
    public string Mask { get; set; }

    public override string ToString()
    {
      return string.Format("{0}:{1}", Length, Mask);
    }
  }
}
