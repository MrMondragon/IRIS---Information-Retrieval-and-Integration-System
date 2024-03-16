using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace Iris.WebOperations.ROMapping
{
  [Serializable]
  public class ParameterMapping
  {
    public ParameterMapping(Type type, string name)
    {
      ChildMappings = new List<ParameterMapping>();
      ParamType = type;
      ParamName = name;

      if (!type.IsPrimitive)
      {
        PropertyInfo[] props = type.GetProperties();
        foreach (PropertyInfo pInfo in props)
        {
          string propName = pInfo.Name;
          Type propType = pInfo.PropertyType;
          ParameterMapping map = new ParameterMapping(propType, propName);
          map.memberInfo = pInfo;
          ChildMappings.Add(map);
        }
      }

      this.Reset();
    }

    public void Reset()
    {
      lambda = null;
      foreach (ParameterMapping childMap in ChildMappings)
      {
        childMap.Reset();
      }
    }

    public string ParamName { get; set; }

    public Type ParamType { get; set; }    

    public string SourceField { get; set; }

    public override string ToString()
    {
      return SourceField;
    }

    [NonSerialized]
    private Func<DataRow, object> lambda;
    [Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

    private MemberInfo memberInfo;

    private Expression GetExpression(ParameterExpression param)
    {
      Expression body;

      if (ParamType.IsPrimitive || (ChildMappings.Count == 0))
      {
        Expression ident = Expression.Constant(SourceField, typeof(string));
        MethodInfo mi = typeof(DataRow).GetMethod("get_Item", new Type[] { typeof(string) });
        body = Expression.Call(param, mi, ident);
        if(body.Type != ParamType)
          body = Expression.Convert(body, ParamType);
      }
      else
      {
        NewExpression newExp = Expression.New(ParamType);

        List<MemberBinding> bindings = new List<MemberBinding>();

        for (int i = 0; i < bindings.Count; i++)
        {
          Expression bindingValue = ChildMappings[i].GetExpression(param);
          MemberInfo mInfo = ChildMappings[i].memberInfo;
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
  }
}
