using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.ExpressionEditor.Editors;
using System.Drawing.Design;
using Iris.Runtime.Core.Expressions;
using Iris.Runtime.Model.Entities;
using Iris.PropertyEditors;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Core;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  public abstract class BaseFilterOperation : ResultSetOperation, IBaseFilterOperation
  {
    public BaseFilterOperation(Structure aStructure, string aName)
      : base(aStructure,  aName)
    {
      SetInputs("Entrada","Filtro");
    }

    private Expression filtro;
    [Editor(typeof(BaseFilterExpressionEditor), typeof(UITypeEditor))]
    [DisplayName("Exp. Filtro"), Category("Filtro")]
    public Expression Filtro
    {
      get { return filtro; }
      set
      {
        filtro = value;
      }
    }

    private List<KeyValuePair<string, string>> fieldMap;
    [Editor(typeof(BaseFilterFieldMapEditor), typeof(UITypeEditor))]
    [DisplayName("Link Filtro"), Category("Filtro")]
    public List<KeyValuePair<string, string>> FieldMap
    {
      get 
      {
        return fieldMap;       
      }
      set
      {
        fieldMap = value;
      }
    }


    #region IBaseFilterOperation Members


    IExpression IBaseFilterOperation.Filtro
    {
      get
      {
        return Filtro;
      }
      set
      {
        Filtro = (Expression)value;
      }
    }

    [Browsable(false)]
    IEntity IBaseFilterOperation.InputFilter
    {
      get
      {
        Iris.Runtime.Model.BaseObjects.Operation input = GetInput(1);
        if (input == null)
          return null;
        else if (input is IEntity)
          return (IEntity)input;
        else
          return (IEntity)input.EntityValue;
      }
    }




    #endregion
  }
}
