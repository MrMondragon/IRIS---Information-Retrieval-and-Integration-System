#if !LockClient
using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Model.ClientObjects
{
  [Serializable]
  public enum TimeUnit
  {
    Minutos,
    Horas,
    Dias,
    Semanas,
    Meses,
    Anos,
  }
}
#endif