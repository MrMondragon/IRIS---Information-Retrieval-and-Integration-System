using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using System.Threading;
using Databridge.Engine.Compression;

namespace Iris.Runtime.Core
{
  public static class PersistenceManager<T>
  {

    public static void SaveToFile(string fileName, T obj)
    {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
      formatter.Serialize(fs, obj);
      fs.Close();
    }

    public static T LoadFromFile(string fileName, Dictionary<string, string> typeLookupTable)
    {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream fs = new FileStream(fileName, FileMode.Open);

      T obj = default(T);
      if (typeLookupTable != null)
      {
        LookupBinder lookupBinder = new LookupBinder(typeLookupTable);
        formatter.Binder = lookupBinder;
      }
      obj = (T)formatter.Deserialize(fs);

      fs.Close();
      return obj;
    }

    public static T LoadFromBuffer(byte[] buffer, Dictionary<string, string> typeLookupTable, bool compressed)
    {
      if (compressed)
        buffer = Compressor.DecompressBytes(buffer, "");
      BinaryFormatter formatter = new BinaryFormatter();
      if (typeLookupTable != null)
      {
        LookupBinder lookupBinder = new LookupBinder(typeLookupTable);
        formatter.Binder = lookupBinder;
      }
      MemoryStream ms = new MemoryStream(buffer);
      T obj = (T)formatter.Deserialize(ms);
      ms.Close();
      return obj;

    }

    public static T LoadFromFile(string fileName)
    {
      return LoadFromFile(fileName, null);
    }

    private class LookupBinder : SerializationBinder
    {
      internal LookupBinder(Dictionary<string, string> _lookupTable)
      {
        lookupTable = _lookupTable;
        Assembly[] loadedAssemblies = Thread.GetDomain().GetAssemblies();

        assemblyDictionary = new Dictionary<string, Assembly>();
        foreach (Assembly asm in loadedAssemblies)
        {
          assemblyDictionary[asm.FullName] = asm;
        }
      }

      private Dictionary<string, string> lookupTable;
      private Dictionary<string, Assembly> assemblyDictionary;

      public override Type BindToType(string assemblyName, string typeName)
      {
        if (lookupTable.ContainsKey(typeName))
        {
          Assembly assembly = assemblyDictionary[lookupTable[typeName]];
          return assembly.GetType(typeName);
        }
        else
        {
          return Type.GetType(typeName);
        }
      }
    }


  }
}
