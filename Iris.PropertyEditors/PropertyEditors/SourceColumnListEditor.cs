using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.FuzzyString;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class SourceColumnListEditor : BaseColumnListEditor<IFuzzyMatchScore>
  {
    protected override System.Data.DataTable GetTable(IFuzzyMatchScore Instance)
    {
      return Instance.Alvo.Table;
    }

    protected override void SetValue(IFuzzyMatchScore Instance, List<string> columNames)
    {
      Instance.ColunasAlvo = columNames;
    }

    protected override List<string> GetList(IFuzzyMatchScore Instance)
    {
      return Instance.ColunasAlvo;
    }



    protected override string GetCaption()
    {
      return "Colunas da tabela Alvo";
    }
  }
}
