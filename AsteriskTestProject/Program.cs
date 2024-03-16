using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iris.DMG.Asterisk;

namespace AsteriskTestProject
{
  class Program
  {
    static void Main(string[] args)
    {
      string str = @"[2016-07-18 17:21:02.913] VERBOSE[18774][C-00004043] app_dial.c:     -- SIP/g80-00004042 is making progress passing it to Local/32@dummy-discador-00001903;1";
      AsteriskLogEntry log = new AsteriskLogEntry(str,0);
    }
  }
}
