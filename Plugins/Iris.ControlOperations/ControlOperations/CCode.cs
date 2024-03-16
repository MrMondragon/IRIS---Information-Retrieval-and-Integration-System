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
using System.CodeDom.Compiler;
using Databridge.Interfaces;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Código C#")]
  public class CCode : ControlOperation, IAssemblyUser, IScriptedObject
  {
    public CCode(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída", "Cmp Obj");
      SetInputs("Entrada");

      assemblies = new Dictionary<string, string>();
    }

    private string code;
    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    public string Code
    {
      get 
      { 
        if(String.IsNullOrEmpty(code))
          code = @"using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;

public class Class1: BaseAccessor, IIrisRunnable
{
  public Class1(Structure aStructure): base(aStructure)
  {
  }

  #region IIrisRunnable Members

  public Object Execute()
  {
    return null;
  }
  #endregion
}
";
        return code; 
      }
      set 
      {
        if (code != value)
        {
          code = value;
          SetClassName();
          compiledObject = null;
        }
      }
    }

    [Browsable(false)]
    private string ClassName
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

    [NonSerialized]
    private IIrisRunnable compiledObject;
    [Browsable(false), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden)]
    public IIrisRunnable CompiledObject
    {
      get 
      {
        if (compiledObject == null)
          CreateObject();
        return compiledObject; 
      }
    }

    private void CreateObject()
    {
      if (GetInput(0) != null)
      {
        ScalarVar var = GetInput(0).EntityValue as ScalarVar;
        if (var != null)
        {
          compiledObject = var.RawValue as IIrisRunnable;
        }
      }
      else
      {
        List<string> assemblyRefs = new List<string>();
        foreach (KeyValuePair<string, string> assembly in Assemblies)
          assemblyRefs.Add(assembly.Value);

        StructureBuilder.AddBaseAssemblies(assemblyRefs,Structure);
        string accessor = Code + "\r\r" + Structure.GetBaseAccessorCode();

        bool hasErrors;
        List<string> messages;

        compiledObject = (IIrisRunnable)IrisCompiler.CreateObject(assemblyRefs, accessor,
            ClassName, new object[] { Structure }, out hasErrors, out messages);

        for (int i = 0; i < messages.Count; i++)
        {
          Structure.AddToLog(messages[i], this);
        }

        if (hasErrors)
        {
          throw new Exception(messages[messages.Count - 1]);
        }
      }
    }

    protected override IEntity doExecute()
    {
      IEntity saida = GetOutput(0) as IEntity;
      object result = CompiledObject.Execute();

      if (saida is ScalarVar)
        ((ScalarVar)saida).RawValue = result;
      else if(saida is ResultSet) 
      {
        if (result is DataTable)
          ((ResultSet)saida).Table = (DataTable)result;
        else if (result is DataView)
          ((ResultSet)saida).View = (DataView)result;
      }

      ScalarVar var = GetOutput(1) as ScalarVar;
      if (var != null)
        var.RawValue = CompiledObject;

      return saida;
    }

    public override IEntity EntityValue
    {
      get
      {
        return doExecute();
      }
    }

    public override void Reset()
    {
      base.Reset();
      compiledObject = null;
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

    [Browsable(false)]
    IExecutionContext IScriptedObject.Context
    {
      get { return Structure.GetContext(); }
    }
    #endregion


    public override string Name
    {
      get
      {
        return base.Name;
      }
      set
      {
        base.Name = value;
        SetClassName();
      }
    }

    private void SetClassName()
    {
      code = Code.Replace(ClassName, Name);
    }
  }
}
