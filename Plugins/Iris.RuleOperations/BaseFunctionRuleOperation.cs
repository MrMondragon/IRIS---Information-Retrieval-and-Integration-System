using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.RuleOperations
{
  [Serializable]
  public abstract class BaseFunctionRuleOperation: BaseValueRuleOpearation
  {
    public BaseFunctionRuleOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Resultset", "Campo", "Filtro");
    }

    private bool distinct;

    public virtual bool Distinct
    {
      get { return distinct; }
      set { distinct = value; }
    }

    private string filter;

    public string Filter
    {
      get 
      {
        if (GetValue(2) != null)
          return Convert.ToString(GetValue(2));
        else
          return filter; 
      }
      set { filter = value; }
    }

    private string fieldName;

    protected string FieldName
    {
      get
      {
        if (GetValue(1) != null)
          return Convert.ToString(GetValue(1));
        else
          return fieldName; 
      }
      set { fieldName = value; }
    }

    protected abstract string GetFunction();

    protected override string GetExpression()
    {
      ResultSet rs = GetValue(1) as ResultSet;
      if (rs == null)
        throw new Exception("Resultset de entrada não atribuído");

      string xFilter = "";
      if (!string.IsNullOrEmpty(Filter))
        xFilter = ",\"" + Filter + "\"";

      string xDistinct = "";
      if (Distinct)
        xDistinct = "Distinct";

      string function = GetFunction();

      string expression = String.Format("{0}{1}(#{2},{3}{4}", function, xDistinct, rs.Name, FieldName, xFilter);

      return expression;
    }
  }
}
