using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris.Interfaces.Interfaces
{
  public interface ICopyTable
  {
    List<string> ColunasEntrada { get; set; }
    IResultSet Entrada { get; }
  }
}
