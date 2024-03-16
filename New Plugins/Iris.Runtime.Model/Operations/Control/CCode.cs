using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Runner;
using Iris.Runtime.Core.Connections;
using System.Data;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.DisignSuport;
using Iris.PropertyEditors;
using Iris.Interfaces;
using Iris.Runtime.Core.PropertyEditors.Interfaces;
using System.CodeDom.Compiler;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Código C#")]
  public class CCode : ControlOperation, IAssemblyUser, IScriptedObject
  {
    public CCode(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      code = @"using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using Iris.Interfaces;

public class Class1: BaseAccessor, IIrisRunnable
{
  public Class1(Structure aStructure): base(aStructure)
  {
  }

  #region IIrisRunnable Members

  public IEntity Execute()
  {
    return new ScalarVar(" + "\"NewVar\""+ @", structure);
  }
  #endregion
}
";

      assemblies = new Dictionary<string, string>();
    }

    private string code;
    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    public string Code
    {
      get { return code; }
      set { code = value; }
    }

    public string ClassName
    {
      get
      {
        int i = code.IndexOf("class ")+6;
        int f = code.IndexOf(": BaseAccessor");

        if (f == -1)
          f = code.IndexOf(":BaseAccessor");

        return code.Substring(i, f - i);
      }
    }

    private Dictionary<string, string> assemblies;
    [Editor(typeof(AssemblyListEditor), typeof(UITypeEditor))]
    public Dictionary<string, string> Assemblies
    {
      get { return assemblies; }
      set { assemblies = value; }
    }

    protected override IEntity doExecute()
    {
      List<string> assemblyRefs = new List<string>();
      foreach (KeyValuePair<string, string> assembly in Assemblies)
        assemblyRefs.Add(assembly.Value);

      Structure.AddBaseAssemblies(assemblyRefs);
      string accessor = Structure.GetBaseAccessorCode();

      accessor += "\r\r" + Code.Substring(Code.IndexOf("public class "));
      accessor = Structure.InsertInNamespace(accessor);
      accessor = Code.Substring(0, Code.IndexOf("public class ")-1) + accessor;

      IEntity entity = (IEntity)CodeRunner.RunInSeparateDomain(assemblyRefs, accessor,
          "Iris.Runtime.Model.BaseObjects." + ClassName, new object[] { Structure },
          "Execute", null, Structure);

      return entity;
    }
    
    #region IScriptedObject Members
    [Browsable(false)]
    public string Script
    {
      get
      {
        return Code;
      }
      set
      {
        Code = value;
      }
    }

    [Browsable(false)]
    public string Language
    {
      get { return "C#"; }
    }

    #endregion
  }
}
