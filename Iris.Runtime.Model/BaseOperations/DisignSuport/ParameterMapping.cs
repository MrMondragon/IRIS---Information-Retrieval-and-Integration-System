using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using Iris.Runtime.NetworkOperations;
using Iris.Interfaces;

namespace Iris.WebOperations.ROMapping
{
  [Serializable]
  public class ParameterMapping : IParameterMapping
  {
    public ParameterMapping(Type type, string name, IBaseWebServiceOperation operation, int level)
    {
      ParamName = name;
      ParamType = type;
      this.Operation = operation;
      this.Level = level;
      InitChildMappings(type, level);
      this.Reset();
    }

    private void InitChildMappings(Type type, int level)
    {
      ChildMappings = new List<ParameterMapping>();
      if (!(type.IsPrimitiveType()))
      {
        PropertyInfo[] props = type.GetProperties();
        if (level < 2)
        {
          foreach (PropertyInfo pInfo in props)
          {
            string propName = pInfo.Name;
            Type propType = pInfo.PropertyType;
            level++;
            ParameterMapping map = new ParameterMapping(propType, propName, Operation, level);
            map.memberName = pInfo.Name;
            ChildMappings.Add(map);
          }
        }
      }
      else
        internalType = type;
    }

    public int Level { get; set; }

    public void Reset()
    {
      lambda = null;
      if (!ParamType.IsPrimitiveType())
        internalType = null;
      foreach (ParameterMapping childMap in ChildMappings)
      {
        childMap.Reset();
      }
    }

    public string ParamName { get; set; }

    private string paramType;

    private Type internalType;

    public Type ParamType
    {
      get
      {
        if (internalType == null)
          internalType = Operation.GetRemoteType(paramType);

        return internalType;
      }
      set
      {
        paramType = value.FullName;
      }
    }

    public string SourceField { get; set; }

    public IBaseWebServiceOperation Operation { get; set; }

    public override string ToString()
    {
      return string.Format("{0}({1}) -> {2}", ParamName, ParamType, SourceField);
    }

    [NonSerialized]
    private Func<DataRow, object> lambda;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Func<DataRow, object> Lambda
    {
      get
      {
        if (lambda == null)
        {
          lambda = GetDelegate();
        }
        return lambda;
      }
    }



    [Browsable(false)]
    public List<ParameterMapping> ChildMappings { get; set; }

    private string memberName;

    private Expression GetExpression(ParameterExpression param)
    {
      Expression body;

      if (ParamType.IsPrimitiveType() || (ChildMappings.Count == 0))
      {
        Expression ident = Expression.Constant(SourceField, typeof(string));
        MethodInfo mi = typeof(DataRow).GetMethod("get_Item", new Type[] { typeof(string) });
        body = Expression.Call(param, mi, ident);
        if (body.Type != ParamType)
        {
          string typeName = ParamType.Name;

          MethodInfo convertMI = typeof(Convert).GetMethod("To" + typeName, new Type[] { body.Type });

          body = Expression.Call(null, convertMI, body);

          if (Level == 0)
            body = Expression.Convert(body, typeof(object));
        }
      }
      else
      {
        NewExpression newExp = Expression.New(ParamType);

        List<MemberBinding> bindings = new List<MemberBinding>(ChildMappings.Count);

        for (int i = 0; i < ChildMappings.Count; i++)
        {
          Expression bindingValue = ChildMappings[i].GetExpression(param);

          MemberInfo mInfo = ParamType.GetProperty(ChildMappings[i].memberName);
          if (mInfo != null)
          {
            bindings.Add(Expression.Bind(mInfo, bindingValue));
          }
        }

        body = Expression.MemberInit(newExp, bindings);
      }
      return body;
    }

    private Func<DataRow, object> GetDelegate()
    {
      ParameterExpression param = Expression.Parameter(typeof(DataRow), "row");

      Expression body = this.GetExpression(param);

      Expression<Func<DataRow, object>> lambda = Expression.Lambda<Func<DataRow, object>>(body, param);

      return lambda.Compile();
    }

    #region IParameterMapping Members

    List<IParameterMapping> IParameterMapping.ChildMappings
    {
      get
      {
        return ChildMappings.Cast<IParameterMapping>().ToList();
      }
      set
      {
        ChildMappings = value.Cast<ParameterMapping>().ToList();
      }
    }
    #endregion
  }
}
