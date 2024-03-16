using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.ClientObjects;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.Threading.Tasks;
using Databridge.Interfaces;
using System.ComponentModel;
using Iris.PropertyEditors;
using Iris.Runtime.Core.Connections;
using System.Drawing.Design;
using System.Data.Common;
using Iris.DMG.Model;

namespace Iris.DMG
{
  [Serializable]
  [OperationCategory("DMG", "Dimensões")]
  public abstract class BaseDimensionOperation : BaseMetadataOperation
  {
    public BaseDimensionOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected override IEntity doExecute()
    {
      if (!Connection.ConnectionString.Contains("MultipleActiveResultSets"))
        throw new Exception("É necessário incluir a diretiva MultipleActiveResultSets=True na string de conexão");


      foreach (mtd_dwh_Dimensoes dim in MetaModel.mtd_dwh_Dimensoes)
      {
        ProcessDimension(dim);
      }

      return null;
    }

    protected abstract void ProcessDimension(mtd_dwh_Dimensoes dim);
  }
}
