using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spss;
using System.IO;

namespace SPSSTest
{
  class Program
  {
    static void Main(string[] args)
    {
      string filename = @"D:\Skydrive\Projetos\IRIS\SPSSTest\PM066_2016_Campo Grande_R01_Idealis.sav";

      SpssDataDocument doc = SpssDataDocument.Open(filename, SpssFileAccess.Read);

      foreach (SpssCase sCase in doc.Cases)
      {
        foreach (SpssVariable variable in doc.Variables)
        {
          object obj = sCase.GetDBValue(variable.Name);
        }
      }


    }
  }
}
