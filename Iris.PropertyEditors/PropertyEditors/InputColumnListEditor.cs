using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.FuzzyString;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class InputColumnListEditor : BaseColumnListEditor<IFuzzyMatchScore>
  {

    protected override System.Data.DataTable GetTable(IFuzzyMatchScore Instance)
    {
      return Instance.Entrada.Table;
    }

    protected override void SetValue(IFuzzyMatchScore Instance, List<string> columNames)
    {
      Instance.ColunasEntrada = columNames;
    }

    protected override List<string> GetList(IFuzzyMatchScore Instance)
    {
      return Instance.ColunasEntrada;
    }

    protected override string GetCaption()
    {
      return "Colunas da tabela Origem";
    }
  }
}
