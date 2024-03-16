using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Security.Policy;
using System.Security.Permissions;
using System.Security;
using System.Reflection;
using System.Threading;
using Iris.Runtime.Core.Connections;
using System.Windows.Forms;
using Iris.Interfaces;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Xml;

namespace Runner
{
  /// <summary>
  /// Classe responsável pela execução dinâmica em domínios separados
  /// </summary>
  [Serializable]
  public class IrisCompiler
  {
    private CSharpCodeProvider codeProvider;
    /// <summary>
    /// Gets or sets the code provider.
    /// </summary>
    /// <value>The code provider.</value>
    public CSharpCodeProvider CodeProvider
    {
      get { return codeProvider; }
      set { codeProvider = value; }
    }

    private CompilerParameters param;
    /// <summary>
    /// Gets or sets the compiler params
    /// </summary>
    /// <value>The param.</value>
    public CompilerParameters Param
    {
      get { return param; }
      set { param = value; }
    }

    private object result;
    /// <summary>
    /// Gets the result.
    /// </summary>
    /// <value>The result.</value>
    public object Result
    {
      get { return result; }
    }

    /// <summary>
    /// Runs code in separate domain. (Generic Code)
    /// </summary>
    /// <param name="refAssemblies">The ref assemblies.</param>
    /// <param name="code">The code.</param>
    /// <param name="className">Name of the class.</param>
    /// <param name="mainMethod">The main method.</param>
    /// <returns></returns>
    public static Object RunInSeparateDomain(List<String> refAssemblies,
      string code, string className, object[] ctorParams, string method, object[] methodParams, IStructure structure)
    {
      AppDomain domain = AppDomain.CreateDomain("Scriptorium");
      object result = null;
      try
      {

        //////////////////////////////////////////////////////////////////////////////////
        //IMPORTANTE: RefAssemblys são passadas usando (typeof (TIPO)).Assembly.Location;//
        //////////////////////////////////////////////////////////////////////////////////

        object[] args = new object[] { refAssemblies, code, className, ctorParams, method, methodParams };

        IrisCompiler runner = domain.CreateInstanceAndUnwrap(typeof(IrisCompiler).Assembly.GetName().Name,
        typeof(IrisCompiler).FullName, false, BindingFlags.Default, null, args, null, null, null) as IrisCompiler;

        result = runner.result;
        for (int i = 0; i < runner.messages.Count; i++)
        {
          structure.AddToLog(runner.messages[i], null);
        }

        if (runner.hasErrors)
        {
          throw new Exception(runner.messages[runner.messages.Count - 1]);
        }
      }
      finally
      {
        AppDomain.Unload(domain);
      }

      return result;
    }

    private List<string> messages;
    private bool hasErrors;

    /// <summary>
    /// Construtor usado para execução de código genérico
    /// </summary>
    /// <param name="refAssemblies">The ref assemblies.</param>
    /// <param name="code">The code.</param>
    /// <param name="className">Name of the class.</param>
    /// <param name="mainMethod">The main method.</param>
    public IrisCompiler(List<String> refAssemblies, string code, string className, object[] ctorParams,
      string method, object[] methodParams)
    {
      InitDomain();

      CompilerResults results = CompileCode(new string[] { code }, refAssemblies);
      messages = new List<string>();

      if (results.Errors.HasErrors)
      {
        for (int i = 0; i < results.Errors.Count; i++)
        {
          messages.Add("L:" + results.Errors[i].Line.ToString() + " C:" + results.Errors[i].Column.ToString() + " - " + results.Errors[i].ErrorText);
        }
        messages.Add("Erro de Compilação");
        hasErrors = true;
      }
      else
      {
        hasErrors = false;
        for (int i = 0; i < results.Output.Count; i++)
        {
          messages.Add(results.Output[i]);
        }
        messages.Add("Compilação em memória bem sucedida");
      }

      if (!hasErrors)
      {
        try
        {
          object scriptObject;
          if (ctorParams.Length == 0)
            scriptObject = results.CompiledAssembly.CreateInstance(className);
          else
            scriptObject = results.CompiledAssembly.CreateInstance(className, false,
              BindingFlags.CreateInstance, null, ctorParams, null, null);

          result = scriptObject.GetType().GetMethod(method).Invoke(scriptObject, methodParams);
        }
        catch (Exception err)
        {
          hasErrors = true;
          messages.Add("Erro de Execução. Mensagem original:" + err.Message);
        }
      }
    }



    /// <summary>
    /// Compiles the code.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns></returns>
    private CompilerResults CompileCode(string[] code, List<String> refAssemblies)
    {
      foreach (string assembly in refAssemblies)
      {
        string asm = assembly;

        if ((!asm.ToLower().Contains("windows\\microsoft.net")) && (!asm.ToLower().Contains("gac_msil")))
        {
          asm = Path.GetFileName(asm);
        }

        param.ReferencedAssemblies.Add(asm);
      }
      CompilerResults results = codeProvider.CompileAssemblyFromSource(param, code);
      return results;
    }


    /// <summary>
    /// Inits the domain.
    /// </summary>
    private void InitDomain()
    {
      codeProvider = new CSharpCodeProvider();
      param = new CompilerParameters();
      param.GenerateExecutable = false;
      param.GenerateInMemory = true;
      param.IncludeDebugInformation = false;
      param.TreatWarningsAsErrors = false;

      // set policy
      PolicyLevel level = PolicyLevel.CreateAppDomainLevel();
      PermissionSet permissions = new PermissionSet(PermissionState.None);
      SecurityPermissionFlag permissionFlags = SecurityPermissionFlag.SerializationFormatter
        | SecurityPermissionFlag.Execution | SecurityPermissionFlag.ControlThread | SecurityPermissionFlag.UnmanagedCode;
      permissions.AddPermission(new SecurityPermission(permissionFlags));
      // allow reflection
      permissions.AddPermission(new ReflectionPermission(
      ReflectionPermissionFlag.AllFlags
      ));
      PolicyStatement policy = new PolicyStatement(permissions, PolicyStatementAttribute.Exclusive);
      CodeGroup group = new UnionCodeGroup(new
      AllMembershipCondition(), policy);
      level.RootCodeGroup = group;
      AppDomain.CurrentDomain.SetAppDomainPolicy(level);
    }

    public static CompilerResults CompileAssembly(List<String> refAssemblies, string code, string fileName)
    {
      IrisCompiler runner = new IrisCompiler(fileName);
      return runner.CompileCode(new string[] { code }, refAssemblies);
    }

    public static CompilerResults CompileExecutable(List<string> assemblyRefs, string[] code, string filename, Image icon)
    {

      //"/win32icon:filename"
      IrisCompiler runner = new IrisCompiler(filename);
      runner.Param.GenerateExecutable = true;
      runner.Param.IncludeDebugInformation = true;
      runner.Param.MainClass = "Iris.Runtime.Model.BaseObjects.Program";
      string compilerOptions = "/target:winexe";
      string tempPath = runner.Param.TempFiles.BasePath;

      if (icon != null)
      {
        tempPath = "C:\\" + tempPath.Substring(tempPath.LastIndexOf("\\") + 1) + "\\";
        if (!Directory.Exists(tempPath))
          Directory.CreateDirectory(tempPath);

        Icon appIcon = Icon.FromHandle(((Bitmap)icon).GetHicon());
        string iconFilename = tempPath + "Icon.ico";
        if (!Directory.Exists(tempPath))
          Directory.CreateDirectory(tempPath);


        using (StreamWriter sw = new StreamWriter(iconFilename))
        {
          appIcon.Save(sw.BaseStream);
        }

        compilerOptions += " /win32icon:" + iconFilename;
        runner.Param.TempFiles.AddFile(iconFilename, false);
      }


      runner.Param.CompilerOptions = compilerOptions;
      CompilerResults results = runner.CompileCode(code, assemblyRefs);

      if (Directory.Exists(tempPath))
        Directory.Delete(tempPath, true);

      return results;
    }

    private IrisCompiler(string fileName)
    {
      codeProvider = new CSharpCodeProvider();
      param = new CompilerParameters();
      param.OutputAssembly = fileName;
      param.GenerateExecutable = false;
      param.GenerateInMemory = false;
      param.IncludeDebugInformation = false;
      param.TreatWarningsAsErrors = false;
    }



    /// <summary>
    /// Construtor usado para execução de código genérico
    /// </summary>
    /// <param name="refAssemblies">The ref assemblies.</param>
    /// <param name="code">The code.</param>
    /// <param name="className">Name of the class.</param>
    /// <param name="mainMethod">The main method.</param>
    public static object CreateObject(List<String> refAssemblies, string code, string className, object[] ctorParams,
      out bool hasErrors, out List<string> messages)
    {
      CSharpCodeProvider codeProvider = new CSharpCodeProvider();
      CompilerParameters param = new CompilerParameters();
      param.GenerateExecutable = false;
      param.GenerateInMemory = true;
      param.IncludeDebugInformation = true;
      param.TreatWarningsAsErrors = false;
      
      
      foreach (string assembly in refAssemblies)
      {
        param.ReferencedAssemblies.Add(assembly);
      }

      CompilerResults results = codeProvider.CompileAssemblyFromSource(param, code);

      hasErrors = false;
      messages = new List<string>();

      object scriptObject = null;

      if (results.Errors.HasErrors)
      {
        for (int i = 0; i < results.Errors.Count; i++)
        {
          messages.Add("L:" + results.Errors[i].Line.ToString() + " C:" + results.Errors[i].Column.ToString() + " - " + results.Errors[i].ErrorText);
        }
        messages.Add("Erro de Compilação");
        hasErrors = true;
      }
      else
      {
        hasErrors = false;
        for (int i = 0; i < results.Output.Count; i++)
        {
          messages.Add(results.Output[i]);
        }
        messages.Add("Compilação em memória bem sucedida");
      }

      if (!hasErrors)
      {
        try
        {
          if (ctorParams.Length == 0)
            scriptObject = results.CompiledAssembly.CreateInstance(className);
          else
            scriptObject = results.CompiledAssembly.CreateInstance(className, false,
              BindingFlags.CreateInstance, null, ctorParams, null, null);

          return scriptObject;
        }
        catch (Exception err)
        {
          hasErrors = true;
          messages.Add("Erro de Execução. Mensagem original:" + err.Message);
        }
      }

      return scriptObject;
    }

    public static List<string> GetBasicAssemblyList()
    {
      List<string> assemblies = new List<string>();
      //mscorelib
      assemblies.Add((typeof(List<string>)).Assembly.Location);
      //System
      assemblies.Add((typeof(Component)).Assembly.Location);
      //Data
      assemblies.Add((typeof(DataColumn)).Assembly.Location);
      //XML
      assemblies.Add((typeof(XmlNode)).Assembly.Location);

      return assemblies;
    }


  }




}

