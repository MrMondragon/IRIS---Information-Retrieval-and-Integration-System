using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using System.Data;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors
{
  public class TypeSelectorEditor: BaseListEditor<Type>
  {
    protected override List<Type> GetItems(object obj)
    {
      List<Type> list = new List<Type>(new Type[]
        { typeof(String),
          typeof(Int32),
          typeof(DateTime),
          typeof(Decimal),
          typeof(Int16),
          typeof(Int64),
          typeof(UInt16),
          typeof(UInt32),
          typeof(UInt64),
          typeof(Byte),
          typeof(SByte),
          typeof(Double),
          typeof(Single),
          typeof(Boolean), 
          typeof(DataSet), 
          typeof(DataTable), 
          typeof (DataRow), 
          typeof(Guid),
          typeof(Byte[])});
      return list;
    }
  }
}
