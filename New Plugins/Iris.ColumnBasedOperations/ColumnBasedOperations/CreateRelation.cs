using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Data;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Opera��es de Colunas", "Criar Relacionamento")]
  public class CreateRelation : RelationBasedOperation
  {
    public CreateRelation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Mestre");
    }

    private string relationName;
    [DisplayName("Relacionamento"), Category("Express�o"), Description("Nome do Relacionamento que ser� criado pela opera��o.")]
    public string RelationName
    {
      get { return relationName; }
      set { relationName = value; }
    }	

    protected override IEntity doExecute()
    {
      DataTable lookupTable = MasterRS.Table;
      DataTable table = Entrada.Table;

      string rName = RefreshRelation(lookupTable, table);

      if (rName != RelationName)
        relation.RelationName = RelationName;

      return (IEntity)Entrada;
    }
  }
}
