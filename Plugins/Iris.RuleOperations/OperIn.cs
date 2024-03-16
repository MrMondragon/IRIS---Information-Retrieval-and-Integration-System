using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;

namespace Iris.RuleOperations
{
  [Serializable]
  public class OperIn : BasePredicateRuleOperation
  {
    public OperIn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Valor", "Resultset", "Campo");
    }

    private string fieldName;

    public string FieldName
    {
      get 
      {
        if (GetValue(2) != null)
          return Convert.ToString(GetValue(2));
        return fieldName; 
      }
      set { fieldName = value; }
    }

    protected override IEntity doExecute()
    {
      object valor = GetValue(0);
      ResultSet rs = GetValue(1) as ResultSet;

      if (rs == null)
        throw new Exception("Resultset de entrada não atribuído");

      string fName = FieldName;
      Type dType = rs.Table.Columns[fName].DataType;
      int fieldIndex = rs.Table.Columns.IndexOf(fName);

      bool result = false;

      for (int i = 0; i < rs.RecCount; i++)
      {
        if (Convert.ChangeType(valor, dType) == Convert.ChangeType(rs.Table.Rows[i][fieldIndex], dType))
        {
          result = true;
          break;
        }
      }

      SetValue(2, result);
      ExecResult(result);
      return null;
    }

    protected override string GetExpression()
    {
      return "";
    }
  }
}
