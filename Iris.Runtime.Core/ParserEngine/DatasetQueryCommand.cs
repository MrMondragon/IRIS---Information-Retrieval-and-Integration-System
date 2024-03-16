namespace DatasetQuery
{
  using Microsoft.VisualBasic;
  using Microsoft.VisualBasic.CompilerServices;
  using DatasetQuery.GoldParser;
  using System;
  using System.Data;
  using System.Diagnostics;
  using System.IO;
  using System.Reflection;
  using System.Runtime.CompilerServices;

  public class DatasetQueryCommand
  {
    public static DataView Execute(string CommandText, DataSet ds)
    {
      if (StringType.StrCmp(CommandText.Trim(), "", false) == 0)
      {
        throw new DataException("Execute: CommandText property has not been initialized");
      }
      TimeSpan span1 = new TimeSpan(DateAndTime.Now.Ticks);
      Initialize();
      SQLParser parser1 = new SQLParser(CommandText, DatasetQueryCommand._grammar);
      if (parser1.DoParse(new StringReader(CommandText), true) != ParseMessage.Accept)
      {
        throw new DataException(parser1.Message);
      }
      DataView view1 = ((IEvaluatable)parser1.CurrentReduction.Tag).Execute(ds);
      TimeSpan span2 = new TimeSpan(DateAndTime.Now.Ticks);
      return view1;
    }

    public static void Initialize()
    {
      if (DatasetQueryCommand._grammar == null)
      {
        Stream stream1 = new MemoryStream(Iris.Runtime.Core.Properties.Resources.DsQ);
        DatasetQueryCommand._grammar = new Grammar(new BinaryReader(stream1));
      }
    }

    public static DataView Execute(string CommandText, DataTable dt)
    {
      DataSet set1 = dt.DataSet;
      bool flag1 = false;
      if (set1 == null)
      {
        set1 = new DataSet();
        set1.Tables.Add(dt);
        flag1 = true;
      }
      DataView view1 = DatasetQueryCommand.Execute(CommandText, set1);
      if (flag1)
      {
        set1.Tables.Remove(dt);
        set1.Dispose();
      }
      return view1;
    }

    public static int ExecuteNonQuery(string CommandText, DataSet ds)
    {
      if (StringType.StrCmp(CommandText.Trim(), "", false) == 0)
      {
        throw new DataException("Execute: CommandText property has not been initialized");
      }
      TimeSpan span1 = new TimeSpan(DateAndTime.Now.Ticks);
      Initialize();
      SQLParser parser1 = new SQLParser(CommandText, DatasetQueryCommand._grammar);
      if (parser1.DoParse(new StringReader(CommandText), true) != ParseMessage.Accept)
      {
        throw new DataException(parser1.Message);
      }
      int num1 = ((IEvaluatable)parser1.CurrentReduction.Tag).ExecuteNonQuery(ds);
      TimeSpan span2 = new TimeSpan(DateAndTime.Now.Ticks);
      object[] objArray2 = new object[2];
      PropertyCollection collection1 = ds.ExtendedProperties;
      string text1 = "Trace";
      objArray2[0] = RuntimeHelpers.GetObjectValue(collection1[text1]);
      objArray2[1] = "Took " + span2.Subtract(span1).ToString();
      object[] objArray1 = objArray2;
      bool[] flagArray1 = new bool[] { true, false };
      LateBinding.LateCall(null, typeof(Debug), "WriteLineIf", objArray1, null, flagArray1);
      if (flagArray1[0])
      {
        collection1[text1] = RuntimeHelpers.GetObjectValue(objArray1[0]);
      }
      return num1;
    }

    public static int ExecuteNonQuery(string CommandText, DataTable dt)
    {
      DataSet set1 = dt.DataSet;
      bool flag1 = false;
      if (set1 == null)
      {
        set1 = new DataSet();
        set1.Tables.Add(dt);
        flag1 = true;
      }
      int num1 = DatasetQueryCommand.ExecuteNonQuery(CommandText, set1);
      if (flag1)
      {
        set1.Tables.Remove(dt);
        set1.Dispose();
      }
      return num1;
    }


    private static Grammar _grammar;
    public static void ResetGrammar()
    {
      _grammar = null;
    }
  }
}

