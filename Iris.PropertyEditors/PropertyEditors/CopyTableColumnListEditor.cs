using Iris.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class CopyTableColumnListEditor: BaseColumnListEditor<ICopyTable>
  {
    protected override System.Data.DataTable GetTable(ICopyTable Instance)
    {
      return Instance.Entrada.Table;
    }

    protected override void SetValue(ICopyTable Instance, List<string> columNames)
    {
      Instance.ColunasEntrada = columNames;
    }

    protected override List<string> GetList(ICopyTable Instance)
    {
      return Instance.ColunasEntrada;
    }

    protected override string GetCaption()
    {
      return "Colunas da tabela Origem";
    }
  }
}
