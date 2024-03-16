using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.Entities;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Xml;
using Iris.Interfaces;
using Runner;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Web;
using System.Web.Services;
using Databridge.Engine.Compression;
using Databridge.Engine.Data;
using Databridge.Interfaces;
using System.Linq;
using System.Reflection;

namespace Iris.Runtime.Model.BaseObjects
{
  public static class StructureBuilder
  {
#if !Demo

    /// <summary>
    /// Gera código para a classe principal da estrutura
    /// </summary>
    /// <param name="web">if set to <c>true</c> [web].</param>
    /// <returns></returns>
    public static string GetCode(bool web, Structure structure)
    {
      string code = GetClassHeader(web) + @"
namespace Iris.Runtime.Model.BaseObjects
{";

      if (web)
        code += "  [WebService(Namespace = \"http://IrisProject.com/\")]" + @"
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [ToolboxItem(false)]
  public class " + structure.ClassName + ": WebService";
      else
        code += "public class " + structure.ClassName + @": IIrisRunnable, ILoggable
  {
    private Structure structure;
    [Browsable(false)]
    public IStructure Structure
    {
      get { return structure; }
    }
";
      code += @"

    public " + structure.ClassName + @"()
    {";

      code = GetConstructor(web, structure, code, false);
      code += @"
    [Browsable(false)]
    public IProccessLog Log
    {
      get { return structure.Log; }
      set { structure.Log = value; }
    }

    public Object Execute()
    {
      structure.RunningOper = structure.StartPoint;
      structure.EnableConnections();
      
      if(structure.Log == null)
        structure.Log =  new ProccessLog();
        
      structure.Execute(false);
      Object result = structure.Result;
      if(structure.Result != null)
      {
        if(structure.Result is ScalarVar)
          result = ((ScalarVar)structure.Result).RawValue;
        else if(structure.Result is ResultSet)
          result =  ((ResultSet)structure.Result).Table;
      }

      return result;
    }

";


      string structType = structure.DataType.ToString();

      code += GetMethodHead("ExecProc", structType, web, structure) + @"
      structure.Restart();" + GetMethodTail(structType, web, structure);

      code += GetDynamicMethods(web, structure);

      if (!web)
      {
        code += GetAccessors<DynConnection>(structure.Connections, true) +
        GetAccessors<ScalarVar>(structure.ScalarVars, true) +
        GetAccessors<ResultSet>(structure.ResultSets, true);
      }
      else
      {
        code += @"
    private string GetLogDir()
    {        
      string virtualdirectory =" + "\"~/Log/\";" + @"
      string physicaldirectory = HttpContext.Current.Server.MapPath(virtualdirectory);
      if (!Directory.Exists(physicaldirectory))
        Directory.CreateDirectory(physicaldirectory);
      return physicaldirectory;
    }

    private ClientConfig config;

    private void SetupConfigObj()
    {
      string filename = GetLogDir()+" + "\"log_" + structure.ClassName + "_\"+DateTime.Now.Ticks.ToString()+\".config\"" + @";       
      config = ClientConfig.CreateConfig(structure, filename);
    }
      ";
      }

      code += @"

  }
}";
      return code;
    }


    private static string GetPluginCode(Structure structure)
    {
      string category;
      string displayName;

      if (!string.IsNullOrEmpty(structure.Category))
        category = structure.Category;
      else
        category = "Dynamic Plugins";

      if (!string.IsNullOrEmpty(structure.DisplayName))
        displayName = structure.DisplayName;
      else
        displayName = structure.ClassName;

      string code = @"using Iris.Runtime.Model.DisignSuport;
using Databridge.Engine;
using System.Linq;
" + GetClassHeader(false) + @"
[assembly: OperationPluginAssembly]
namespace Iris.Runtime.Model.BaseObjects
{";


      code += @"
" + String.Format("  [OperationCategory(\"{0}\", \"{1}\"), Serializable]", category, displayName);

      code += @"
  public class " + structure.ClassName + @" : Operation
  {";

      string accessors = GetAccessors<DynConnection>(structure.Connections, true) +
        GetAccessors<ScalarVar>(structure.ScalarVars, true) +
        GetAccessors<ResultSet>(structure.ResultSets, true);

      accessors = accessors.Replace("Structure.", "structure.");

      if (structure.Icon != null)
        code += GetImageCode(structure);

      code += accessors + @"
    private Structure structure;

    public " + structure.ClassName + @"(Structure aStructure, string aName)
      : base(aStructure, aName)
    {";

      code = GetConstructor(false, structure, code, true);
      code = code.Trim().TrimEnd('}');
      code += @"
      

      List<string> inputNames = new List<string>();
      inputNames.AddRange(structure.StartPoint.InputNames);
";

      foreach (ScalarVar sVar in structure.ScalarVars)
      {
        if (sVar.ExternalParam)
        {
          code += "      inputNames.Add(\""+sVar.DisplayText+"\");"+Environment.NewLine;
        }
      }      

      code += @"      SetInputs(inputNames.ToArray());


      
      int outputCount = 0;  
      if(structure.Result != null)
        outputCount += 1;           

      if(structure.OutputPoint != null)
        outputCount += structure.OutputPoint.OutputCount;


      string[] outputList = new string[outputCount];

      if(structure.Result != null)
        outputList[0] = Structure.Result.Name;

      if (structure.OutputPoint != null)
      {
        int firstInput = 0;
        if (structure.Result != null)
          firstInput += 1;

        for (int i = firstInput; i < structure.OutputPoint.OutputCount + firstInput; i++)
        {
          outputList[i] = structure.OutputPoint.OutputNames[i - firstInput];
        }
      }

      SetOutputs(outputList);

    }

    protected override IEntity doExecute()
    {
      structure.Restart();

      for (int i = 0; i < InputCount; i++)
      {
        if (i < structure.StartPoint.InputCount)
          structure.StartPoint.SetInput(i, GetInput(i));
        else
        {
          ScalarVar sv = structure.ScalarVars.Where(x => x.DisplayText == this.InputNames[i]).FirstOrDefault();
          if ((sv != null) && (GetValue(i) != null))
          {
            sv.RawValue = GetValue(i);
          }
        }
      }


      if (structure.OutputPoint != null)
      {
        int firstInput = 0;
        if (structure.Result != null)
          firstInput += 1;

        for (int i = firstInput; i < structure.OutputPoint.OutputCount + firstInput; i++)
        {
          structure.OutputPoint.SetOutput(i-firstInput, GetOutput(i));
        } 
      }

      structure.Execute(false);
      Object result = structure.Result;

      if (structure.Result != null)
        SetValue(0, result);

      return null;
    }
  }
}
";
      return code;
    }

    private static string GetImageCode(Structure structure)
    {
      BinaryFormatter formatter = new BinaryFormatter();
      MemoryStream ms = new MemoryStream();
      formatter.Serialize(ms, structure.Icon);
      ms.Position = 0;
      byte[] buffer = ms.ToArray();
      ms.Close();
      string code = @"
    public static Bitmap GetIcon()
    {
";

      buffer = Compressor.CompressBytes(buffer, "");

      StringBuilder bufferStr = new StringBuilder((buffer.Length * 4) + 100);


      bufferStr.Append(@"   
      byte[] buffer = new byte[]{");
      for (int i = 0; i < buffer.Length; i++)
      {
        bufferStr.Append(Convert.ToString(buffer[i]) + ",");
      }

      bufferStr.Remove(bufferStr.Length - 1, 1);

      bufferStr.Append("};");

      code += bufferStr.ToString() + @"
      buffer = Compressor.DecompressBytes(buffer," + '"' + '"' + @");
      BinaryFormatter formatter = new BinaryFormatter();
      MemoryStream ms = new MemoryStream(buffer);
      Bitmap icon = (Bitmap) formatter.Deserialize(ms);
      ms.Close();
      return icon;
    }
";
      return code;
    }

    private static string GetConstructor(bool web, Structure structure, string code, bool plugin)
    {

      BinaryFormatter formatter = new BinaryFormatter();
      MemoryStream ms = new MemoryStream();
      formatter.Serialize(ms, structure);
      ms.Position = 0;
      byte[] buffer = ms.ToArray();
      ms.Close();

      buffer = Compressor.CompressBytes(buffer, "");

      StringBuilder bufferStr = new StringBuilder((buffer.Length * 4) + 100);


      bufferStr.Append(@"   
      byte[] buffer = new byte[]{");
      for (int i = 0; i < buffer.Length; i++)
      {
        bufferStr.Append(Convert.ToString(buffer[i]) + ",");
      }

      bufferStr.Remove(bufferStr.Length - 1, 1);

      bufferStr.Append("};");

      code += bufferStr.ToString();
      if (!plugin)
      {
        code += @"
      buffer = Compressor.DecompressBytes(buffer," + '"' + '"' + @");
      BinaryFormatter formatter = new BinaryFormatter();
      MemoryStream ms = new MemoryStream(buffer);

      structure = (Structure) formatter.Deserialize(ms);
      ms.Close();
";
        if (web)
          code += " SetupConfigObj();";
      }
      else
      {
        code += @"
      structure = PersistenceManager<Structure>.LoadFromBuffer(buffer, this.Structure.TypeLookupTable, true);
      structure.TypeLookupTable = this.Structure.TypeLookupTable;
";
      }
      code += @"
    }";
      return code;
    }

    private static string GetClassHeader(bool web)
    {
      string code =
@"using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using System.ComponentModel;";

      if (!web)
        code += @"
using System.Drawing.Design;
using System.Drawing;
using Databridge.Interfaces.BaseEditors;
";
      else
        code += @"
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web;";

      code += @"
using Iris.Interfaces;
using Databridge.Engine.Compression;
using Iris.Runtime.Core;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.ClientObjects;
";

      return code;
    }

    /// <summary>
    /// Gera o código dos métodos dinâmicos da estrutura
    /// </summary>
    /// <param name="web">if set to <c>true</c> [web].</param>
    /// <returns></returns>
    private static string GetDynamicMethods(bool web, Structure structure)
    {
      string methods = "";
      foreach (Operation oper in structure.Operations)
      {
        if (oper.ExternalParam)
        {
          string operType = oper.DataType.ToString();
          methods += GetMethodHead(oper.Name, operType, web, structure) + @"
      Structure.RunningOper = (Operation)Structure.GetOperation(" + "\"" + oper.Name + "\");" +
          GetMethodTail(operType, web, structure);
        }
      }
      return methods;
    }

    /// <summary>
    /// Gera a declaração e o início de um método dinâmico
    /// </summary>
    /// <param name="methodName">Name of the method.</param>
    /// <param name="returnType">Type of the return.</param>
    /// <param name="web">if set to <c>true</c> [web].</param>
    /// <returns></returns>
    private static string GetMethodHead(string methodName, string returnType, bool web, Structure structure)
    {
      string method;
      string attribute = "";
      string paramList = GetParamList(structure);

      if (web)
        attribute = "[WebMethod]";

      if (!string.IsNullOrEmpty(paramList))
      {
        method = attribute + @"  
    public " + returnType + " " + methodName + "(" + paramList + @")
    {
" + GetParamAssignmentCode(structure);
      }
      else
      {

        method = attribute + @"
    public " + returnType + " " + methodName + @"()
    {";
      }

      return method;
    }

    /// <summary>
    /// Gera o retorno e o fechamento de métodos dinâmicos
    /// </summary>
    /// <param name="returnType">Type of the return.</param>
    /// <param name="web">if set to <c>true</c> [web].</param>
    /// <returns></returns>
    private static string GetMethodTail(string returnType, bool web, Structure structure)
    {
      string executor;

      if (web)
        executor = "config.Run()";
      else
        executor = "structure.Execute(false).Value";

      string method = @"
      return (" + returnType + ") Convert.ChangeType(" + executor + ", typeof(" + returnType + @"));
    }
";
      return method;
    }

    /// <summary>
    /// Retorna a lista de parâmetros que devem ser passados aos métodos dinâmicos da estrutura
    /// </summary>
    /// <returns></returns>
    private static string GetParamList(Structure structure)
    {
      string paramList = "";

      foreach (ScalarVar var in structure.ScalarVars)
      {
        if (var.ExternalParam)
        {
          string dataType;
          if (var.DataType == null)
            dataType = "object";
          else
            dataType = var.DataType.ToString();
          paramList += dataType + " _" + var.Name + ", ";
        }
      }

      paramList = paramList.Trim().TrimEnd(',');

      return paramList;
    }

    /// <summary>
    /// Retorna o código de atribuição de valor aos parâmetros dos métodos dinâmicos
    /// </summary>
    /// <returns></returns>
    private static string GetParamAssignmentCode(Structure structure)
    {
      string paramCode = "";
      foreach (ScalarVar var in structure.ScalarVars)
      {
        if (var.ExternalParam)
        {
          paramCode += "      Structure.GetScalarVar(\"" + var.Name + "\").RawValue = _" + var.Name + ";\r\n";
        }
      }
      paramCode += "\r\n";
      return paramCode;
    }

    /// <summary>
    /// Gera o código da classe Program de um executável
    /// </summary>
    /// <returns></returns>
    public static string GetProgramCode(Structure structure)
    {
      string code = @"
using System;
using Iris.Interfaces;

namespace Iris.Runtime.Model.BaseObjects
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      ExecutableStructure exS = new ExecutableStructure();
      exS.Execute();
    }

    class ExecutableStructure : BaseExecutableStructure
    {
      public override IIrisRunnable GetStructure()
      {
        return new " + structure.ClassName + @"();
      }
    }
  }
}
";
      return code;
    }

    /// <summary>
    /// Compiles the executable.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <returns></returns>
    public static CompilerResults CompileExecutable(string filename, Structure structure)
    {
      List<String> assemblyRefs = new List<string>();
      AddBaseAssemblies(assemblyRefs, structure);
      //System.Windows.Form
      assemblyRefs.Add((typeof(Form)).Assembly.Location);
      //System.Drawing.Design
      assemblyRefs.Add((typeof(UITypeEditor)).Assembly.Location);

      CopyLocalAssemblies(assemblyRefs, filename, structure);

      string[] code = new string[2];
      code[0] = GetProgramCode(structure);
      code[1] = GetCode(false, structure);
      CompilerResults results = IrisCompiler.CompileExecutable(assemblyRefs, code, filename, structure.Icon);
      return results;
    }

    private static void CopyLocalAssemblies(List<string> assemblyRefs, string fileName, Structure structure)
    {
      List<string> asms = new List<string>();


      for (int i = assemblyRefs.Count - 1; i >= 0; i--)
      {
        string asmRef = assemblyRefs[i];
        string asmName = Path.GetFileName(asmRef);
        if (!asms.Contains(asmName))
        { 
          asms.Add(asmName);
        }
        else
        {
          assemblyRefs.RemoveAt(i);
        }
      }


      string appPath = Application.StartupPath;

      string pluginsPath = Path.Combine(appPath, "Plugins");
      string outputPath = Path.GetDirectoryName(fileName);

      for (int i = 0; i < assemblyRefs.Count; i++)
      {
        string asmName = assemblyRefs[i];
        if (!asmName.ToLower().Contains("microsoft.net"))
        {
          string newAsmName = Path.Combine(outputPath, Path.GetFileName(asmName));

          File.Copy(asmName, newAsmName, true);

          string asmKey = structure.Assemblies.Where(x => x.Value == asmName).FirstOrDefault().Key;
          structure.Assemblies[asmKey] = newAsmName;
          assemblyRefs[i] = newAsmName;
        }
      }

      IEnumerable<string> pluginDependences = Directory.GetFiles(pluginsPath, "*.dll").
        Where(x => !Path.GetFileName(x).StartsWith("Iris."));

      foreach (string asmName in pluginDependences)
      {
        string newAsmName = Path.Combine(outputPath, Path.GetFileName(asmName));

        File.Copy(asmName, newAsmName, true);
        assemblyRefs.Add(newAsmName);
      }

    }

    /// <summary>
    /// Compiles the assembly.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <returns></returns>
    public static CompilerResults CompileAssembly(string filename, Structure structure)
    {
      List<String> assemblyRefs = new List<string>();
      AddBaseAssemblies(assemblyRefs, structure);
      //System.Drawing.Design
      assemblyRefs.Add((typeof(UITypeEditor)).Assembly.Location);

      string code = GetCode(false, structure);
      CompilerResults results = IrisCompiler.CompileAssembly(assemblyRefs, code, filename);
      return results;
    }


    public static CompilerResults CompilePlugin(string filename, Structure structure)
    {
      List<String> assemblyRefs = new List<string>();
      AddBaseAssemblies(assemblyRefs, structure);
      //System.Drawing.Design
      assemblyRefs.Add((typeof(UITypeEditor)).Assembly.Location);
      assemblyRefs.Add((typeof(IQueryable)).Assembly.Location);

      string plugName = filename.Substring(filename.LastIndexOf('\\') + 1);

      if (!plugName.StartsWith("Iris."))
      {
        filename = filename.Substring(0, filename.LastIndexOf('\\') + 1) + "Iris." + plugName;

      }

      CopyLocalAssemblies(assemblyRefs, filename, structure);

      string code = GetPluginCode(structure);
      CompilerResults results = IrisCompiler.CompileAssembly(assemblyRefs, code, filename);
      return results;
    }


    /// <summary>
    /// Compiles the web service.
    /// </summary>
    /// <param name="outputPath">The output path.</param>
    /// <returns></returns>
    public static CompilerResults CompileWebService(string outputPath, Structure structure)
    {
      List<String> assemblyRefs = new List<string>();
      AddBaseAssemblies(assemblyRefs, structure);
      //System.Web
      assemblyRefs.Add((typeof(HttpResponse)).Assembly.Location);
      //System.WebService
      assemblyRefs.Add((typeof(WebService)).Assembly.Location);

      string binPath = outputPath.Substring(0, outputPath.LastIndexOf('\\')) + "\\bin";

      if (!Directory.Exists(binPath))
        Directory.CreateDirectory(binPath);

      string filename = binPath + "\\" + structure.ClassName + ".dll";

      string code = GetCode(true, structure);
      CompilerResults results = IrisCompiler.CompileAssembly(assemblyRefs, code, filename);

      using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.Default))
      {
        writer.WriteLine("<%@ WebService Class=\"Iris.Runtime.Model.BaseObjects." + structure.ClassName + "\" %>");
      }

      return results;

    }





#endif

    /// <summary>
    /// Adiciona as referências de assembly da estrutura à lista que será passada ao compilador dinâmico
    /// </summary>
    /// <param name="assemblyRefs">The assembly refs.</param>
    public static void AddBaseAssemblies(List<string> assemblyRefs, Structure structure)
    {
      //mscorelib
      structure.Assemblies[(typeof(List<string>)).Assembly.ManifestModule.ToString()] = (typeof(List<string>)).Assembly.Location;
      //System
      structure.Assemblies[(typeof(Component)).Assembly.ManifestModule.ToString()] = (typeof(Component)).Assembly.Location;
      //Data
      structure.Assemblies[(typeof(DataColumn)).Assembly.ManifestModule.ToString()] = (typeof(DataColumn)).Assembly.Location;
      //XML
      structure.Assemblies[(typeof(XmlNode)).Assembly.ManifestModule.ToString()] = (typeof(XmlNode)).Assembly.Location;
      //Linq
      structure.Assemblies[(typeof(Enumerable)).Assembly.ManifestModule.ToString()] = (typeof(Enumerable)).Assembly.Location;

      

      //Interfaces
      structure.Assemblies[(typeof(IEntity)).Assembly.ManifestModule.ToString()] = (typeof(IEntity)).Assembly.Location;
      //Core
      structure.Assemblies[(typeof(IrisCompiler)).Assembly.ManifestModule.ToString()] = (typeof(IrisCompiler)).Assembly.Location;
      //Model
      structure.Assemblies[(typeof(ResultSet)).Assembly.ManifestModule.ToString()] = (typeof(ResultSet)).Assembly.Location;

      //Databridge.Engine
      structure.Assemblies[(typeof(DataConnection)).Assembly.ManifestModule.ToString()] = (typeof(DataConnection)).Assembly.Location;
      //Databridge.Interfaces
      structure.Assemblies[(typeof(IDataConnection)).Assembly.ManifestModule.ToString()] = (typeof(IDataConnection)).Assembly.Location;

      string runningPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      string pluginPath = Path.Combine(runningPath, "Plugins");

      List<string> asmKeys = structure.Assemblies.Select(x => x.Key).ToList();
      for (int i = 0; i < asmKeys.Count; i++)
      {

        if (!structure.Assemblies[asmKeys[i]].ToLower().Contains("microsoft.net"))
        {
          if (Path.GetDirectoryName(structure.Assemblies[asmKeys[i]]).TrimEnd('\\').EndsWith("Plugins"))
          {
            structure.Assemblies[asmKeys[i]] = Path.Combine(pluginPath, asmKeys[i]);
          }
          else
            structure.Assemblies[asmKeys[i]] = Path.Combine(runningPath, asmKeys[i]);
        }

        if (!assemblyRefs.Contains(structure.Assemblies[asmKeys[i]]))
          assemblyRefs.Add(structure.Assemblies[asmKeys[i]]);
      }

    }

    /// <summary>
    /// Gera propriedades para acesso aos objetos da estrutura por operações de código C#
    /// </summary>
    /// <returns></returns>
    public static string GetBaseAccessorCode(Structure structure)
    {
      string code = @"
  public class BaseAccessor
  {
    public BaseAccessor(Structure aStructure)
    {
      structure = aStructure;
    }

    protected Structure structure;

    public IStructure Structure
    {
      get { return structure; }
    }          
      ";



      code += GetAccessors<IOperation>(structure.Operations, false);
      code += GetAccessors<DynConnection>(structure.Connections, false);
      code += GetAccessors<ScalarVar>(structure.ScalarVars, false);
      code += GetAccessors<ResultSet>(structure.ResultSets, false);

      code += @"
  }
";

      return code;
    }

    /// <summary>
    /// Gera acessores para os objetos da estruutra
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="external">if set to <c>true</c> [external].</param>
    /// <returns></returns>
    private static string GetAccessors<T>(IrisList<T> list, bool external)
    {
      string code = "";
      T[] tArray = list.ToArray();
      for (int i = 0; i < tArray.Length; i++)
      {
        T obj = tArray[i];
        bool testFlag = true;
        Object tmp = obj;

        if ((external) && (!(obj is DynConnection)))
        {
          if (tmp is Operation)
            testFlag = ((Operation)tmp).ExternalParam;
        }

        if (testFlag)
        {
          string typeName = "";
          string objCode = "";
          string objName = obj.ToString();
          string listName = "\"" + list.Name + "\"";
          string objString = "\"" + objName + "\"";
          string attribute = "";

          if (obj is ScalarVar)
          {
            ScalarVar sVar = (ScalarVar)tmp;
            string displayText = sVar.DisplayText;
            if (string.IsNullOrEmpty(displayText))
              displayText = sVar.Name;


            attribute = "[DisplayName(\"" + displayText + "\"),Description(\"" + sVar.Description + "\"), Category(\"Parâmetros\")]";


            Type type = ((ScalarVar)tmp).DataType;
            if ((type == typeof(Int16)) || (type == typeof(Int32)) || (type == typeof(Int64)) || (type == typeof(UInt16))
              || (type == typeof(UInt32)) || (type == typeof(UInt64)) || (type == typeof(Byte)) || (type == typeof(SByte)) || (type == typeof(Guid))
              || (type == typeof(Decimal)) || (type == typeof(Double)) || (type == typeof(Single)) || (type == typeof(Boolean)) || (type == typeof(DateTime)))
              typeName = "Nullable<" + type.ToString() + ">";
            else
              typeName = type.ToString();

            objCode = @"get
                          { 
                            Object result = ((ScalarVar)Structure.GetObject(" + objString + "," + listName + @")).RawValue;
                            return result as " + typeName + @";
                          }
                         set{ ((ScalarVar)Structure.GetObject(" + objString + "," + listName + @")).RawValue = value;}";
          }
          else if (obj is ResultSet)
          {
            attribute = "[Browsable(false)]";
            typeName = typeof(DataTable).ToString();
            objCode = "get{ return ((ResultSet)Structure.GetObject(" + objString + "," + listName + @")).Table;}
                         set{ ((ResultSet)Structure.GetObject(" + objString + "," + listName + @")).Table = value;}";

          }
          else if (obj is DynConnection)
          {
            DynConnection conn = (DynConnection)tmp;
            string displayText = conn.DisplayText;
            if (string.IsNullOrEmpty(displayText))
              displayText = conn.Name;


            attribute = "    [Browsable(true), Category(\"Conexão\"), DisplayName(\"" + displayText + "\"), Description(\"" + conn.Description + "\")]" + @"
    [Editor(typeof(ConnectionStringEditor), typeof(UITypeEditor))]";


            typeName = typeof(String).ToString();
            objCode = "get{ return ((DynConnection)Structure.GetObject(" + objString + "," + listName + @")).ConnectionString;}
                         set{ ((DynConnection)Structure.GetObject(" + objString + "," + listName + @")).ConnectionString = value;}";
          }


          if (string.IsNullOrEmpty(objCode))
          {
            typeName = obj.GetType().FullName;
            objCode = "get{ return (" + typeName + ")Structure.GetObject(" + objString + "," + listName + ");}";
          }

          if (!external)
            attribute = "";

          code += attribute + @"
          public " + typeName + " " + objName + @"
          {
            " + objCode + @"
          }
          ";
        }
      }

      return code;
    }



    /// <summary>
    /// Circunda o código gerado por uma operação C# em um name-space
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns></returns>
    public static string InsertInNamespace(string code)
    {
      code = @"using Iris.Runtime.Model.BaseObjects;
      namespace Iris.Runtime.Model.BaseObjects
      {
      
      " + code + @"
      }";
      return code;
    }


  }
}
