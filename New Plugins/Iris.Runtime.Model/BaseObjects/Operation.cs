using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using System.ComponentModel;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.PropertyEditors;
using System.Drawing.Design;

namespace Iris.Runtime.Model.BaseObjects
{
  [Serializable]
  public abstract class Operation : IOperation
  {
    public Operation(Structure aStructure, string aName)
    {
      structure = aStructure;
      Name = aName;

      outputs = new Operation[0];
      outputNames = new string[0];
      inputs = new Operation[0];
      inputNames = new string[0];

      if (!(this is Entity))
      {
        Structure.Operations.Add(this);
        Status = ExecutionStatus.WaitingExecution;
      }
    }

    #region Alimentação

    private Operation onFailure;
    [Browsable(false)]
    public virtual Operation OnFailure
    {
      get { return onFailure; }
      set { onFailure = value; }
    }

    private Operation onSuccess;
    [Browsable(false)]
    public virtual Operation OnSuccess
    {
      get { return onSuccess; }
      set { onSuccess = value; }
    }

    protected virtual void SetOutputs(params string[] names)
    {
      outputs = new Operation[names.Length];
      outputNames = new string[names.Length];
      for (int i = 0; i < names.Length; i++)
      {
        outputNames[i] = names[i];
      }
    }

    protected virtual void SetInputs(params string[] names)
    {
      inputs = new Operation[names.Length];
      inputNames = new string[names.Length];
      for (int i = 0; i < names.Length; i++)
      {
        inputNames[i] = names[i];
      }
    }

    public virtual void SetInput(string name, Operation input)
    {
      if (inputs != null)
      {
        for (int i = 0; i < inputs.Length; i++)
        {
          if (inputNames[i] == name)
            inputs[i] = input;
        }
      }
    }

    public virtual void SetValue(string name, Object value)
    {
      ScalarVar var = GetOutput(name) as ScalarVar;
      if (var != null)
        var.RawValue = value;
    }

    public virtual void SetValue(int idx, Object value)
    {
      ScalarVar var = outputs[idx] as ScalarVar;
      if (var != null)
        var.RawValue = value;
    }

    public virtual void SetOutput(string name, Operation output)
    {
      if (outputs != null)
      {
        for (int i = 0; i < outputs.Length; i++)
        {
          if (outputNames[i] == name)
            outputs[i] = output;
        }
      }
    }

    public object GetValue(string name)
    {
      Operation oper = GetInput(name);
      if (oper != null)
      {
        if (oper is ScalarVar)
          return ((ScalarVar)oper).RawValue;
        else
          return oper.EntityValue;
      }
      else
        return null;
    }

    public object GetValue(int idx)
    {
      Operation oper = inputs[idx];
      if (oper != null)
      {
        if (oper is ScalarVar)
          return ((ScalarVar)oper).RawValue;
        else
          return oper.EntityValue;
      }
      else 
        return null;
    }


    public Operation GetInput(string name)
    {
      if (inputs != null)
      {
        for (int i = 0; i < inputs.Length; i++)
        {
          if (inputNames[i] == name)
            return inputs[i];
        }
      }

      return null;
    }

    public Operation GetOutput(string name)
    {
      if (outputs != null)
      {
        for (int i = 0; i < outputs.Length; i++)
        {
          if (outputNames[i] == name)
            return outputs[i];
        }
      }
      return null;
    }

    public virtual void SetInput(int idx, Operation input)
    {
      if (inputs != null)
      {
        inputs[idx] = input;
      }
    }

    public virtual void SetOutput(int idx, Operation output)
    {
      if (outputs != null)
      {
        outputs[idx] = output;
      }
    }


    public Operation GetInput(int idx)
    {
      if (inputs != null)
      {
        return inputs[idx];
      }
      else
        return null;
    }

    public Operation GetOutput(int idx)
    {
      if (outputs != null)
      {
        return outputs[idx];
      }
      else 
        return null;
    }

    public string GetInputName(int idx)
    {
      if ((inputNames != null) && (idx < inputNames.Length))
      {
        return inputNames[idx];
      }
      else
        return null;
    }

    public string GetOutputName(int idx)
    {
      if (outputNames != null)
      {
        return outputNames[idx];
      }
      else
        return null;
    }
    

    private Operation[] inputs;
    private string[] inputNames;
    private Operation[] outputs;
    private string[] outputNames;

    [Browsable(false)]
    public int InputCount
    {
      get
      {
        if (inputs == null)
          return 0;
        else
          return inputs.Length;
      }
    }

    [Browsable(false)]
    public int OutputCount
    {
      get
      {
        if (outputs == null)
          return 0;
        else
          return outputs.Length;
      }
    }
    #endregion



    private ExecutionStatus status;
    [Browsable(false)]
    public virtual ExecutionStatus Status
    {
      get { return status; }
      set
      {

        status = value;
        if (StatusChange != null)
          StatusChange(this, new EventArgs());
      }
    }



    private Type dataType;
    [Editor(typeof(TypeSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Tipo"), Category("Design"), Description("Tipo de dado do valor da Operação")]
    public virtual Type DataType
    {
      get
      {
        if (dataType == null)
          dataType = typeof(System.String);

        return dataType;
      }
      set
      {
        if (value.GetInterface("IIrisRunnable")!= null)
          value = typeof(IIrisRunnable);
        dataType = value;
      }
    }

    protected abstract IEntity doExecute();

    public virtual void Execute()
    {
      result = null;
      Status = ExecutionStatus.PreparingInputs;
      bool inputsToPrepare = PrepareInputs();
      Structure.RunningOper = this;
      if (inputsToPrepare && Structure.inStep)
        return;
      Status = ExecutionStatus.Running;
      this.Structure.AddToLog("Início da execução da operação " + DisplayText, this);
      try
      {
        DateTime t1 = DateTime.Now;
        result = doExecute();
        Status = ExecutionStatus.Success;
        TimeSpan ts = DateTime.Now - t1;
        this.Structure.AddToLog("Término da execução da operação " + DisplayText + "       Duração:" + ts.ToString(), this);
        ExecuteObj(OnSuccess);
      }
      catch (Exception e)
      {
        if (!(e is ExecutionException))
        {
          this.Structure.AddToErrorLog("Falha da execução da operação " + DisplayText, this);
          this.Structure.AddToLog(DisplayText, e, this);
          Status = ExecutionStatus.Failure;
          if (OnFailure == null)
          {
            if (ignoreFailure)
              ExecuteObj(OnSuccess);
          }
          else
            ExecuteObj(OnFailure);
        }
      }
    }


    private bool breakPoint;
    [DisplayName("Break Point"), Category("Design")]
    public virtual bool BreakPoint
    {
      get { return breakPoint; }
      set { breakPoint = value; }
    }

    protected void ExecuteObj(Operation obj)
    {
      if ((!structure.inStep) && (!((BreakPoint) && (structure.debug))))
      {
        if (obj != null)
          if (obj.Status == ExecutionStatus.WaitingExecution)
            ((Operation)obj).Execute();
      }
      else
        structure.RunningOper = obj;
    }


    private bool PrepareInputs()
    {
      bool result = false;
      foreach (Operation input in inputs)
      {
        if (input != null)
        {
          if (input.Status == ExecutionStatus.WaitingExecution)
          {
            ((Operation)input).Execute();
            result = true;
          }
        }
      }
      return result;
    }


    [Browsable(false)]
    public virtual IEntity EntityValue
    {
      get
      {
        return this.Result;
      }
    }

    [field: NonSerialized()]
    public event EventHandler StatusChange;

    [NonSerialized]
    private IEntity result;
    [Browsable(false)]
    public IEntity Result
    {
      get { return result; }
      set { result = value; }
    }

    private bool ignoreFailure;
    [DisplayName("Ignorar Falhas"), Category("Design"), Description("Indica se a execução deve prosseguir mesmo em caso de falha na operação")]
    public virtual bool IgnoreFailure
    {
      get { return ignoreFailure; }
      set { ignoreFailure = value; }
    }

    [DisplayName("Nome"), Category("Design")]
    public virtual string Name
    {
      get { return name; }
      set
      {
        if (name != value)
        {
          if (BeforeNameChange != null)
            BeforeNameChange(this, new EventArgs());

          name = Structure.GetValidName(value);

          if (AfterNameChange != null)
            AfterNameChange(this, new EventArgs());
        }
      }
    }

    public virtual void Delete()
    {
    }

    public virtual void Reset()
    {
      Status = ExecutionStatus.WaitingExecution;
    }

    private string name;

    [field: NonSerialized()]
    public event EventHandler AfterNameChange;

    [field: NonSerialized()]
    public event EventHandler BeforeNameChange;

    private Structure structure;

    [Browsable(false)]
    public Structure Structure
    {
      get { return structure; }
      set { structure = value; }
    }

    public override string ToString()
    {
      return Name;
    }

    private string description;
    [DisplayName("Descrição"), Category("Design")]
    public string Description
    {
      get { return description; }
      set { description = value; }
    }

    private string displayText;
    [DisplayName("Texto de Apresentação"), Category("Design")]
    public virtual string DisplayText
    {
      get 
      { 
        if(string.IsNullOrEmpty(displayText))
          return name;
        else
          return displayText; 
      }
      set { displayText = value; }
    }

    #region IEntity Members
    [Browsable(false)]
    public virtual object Value
    {
      get { return result.Value; }
    }

    bool externalParam;
    [DisplayName("Entry Point"), Category("Design")]
    public virtual bool ExternalParam
    {
      get { return externalParam; }
      set { externalParam = value; }
    }



    #endregion

    #region IOperation Members

    IOperation IOperation.OnFailure
    {
      get
      {
        return OnFailure;
      }
      set
      {
        OnFailure = (Operation)value;
      }
    }

    IOperation IOperation.OnSuccess
    {
      get
      {
        return OnSuccess;
      }
      set
      {
        OnSuccess = (Operation)value;
      }
    }


    IStructure IOperation.Structure
    {
      get
      {
        return Structure;
      }
    }


    #endregion
  }
}
