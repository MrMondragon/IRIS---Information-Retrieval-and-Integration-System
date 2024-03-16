using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using System.ComponentModel;
using System.Linq;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.PropertyEditors;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Iris.Runtime.Model.BaseObjects
{
  [Serializable]
  public abstract class Operation : IOperation
  {
    public Operation(Structure aStructure, string aName)
    {
      structure = aStructure;
      Name = aName;

      outputs = new IOperation[0];
      outputNames = new string[0];
      inputs = new IOperation[0];
      inputNames = new string[0];
      IgnoreOperation = false;

      if (!(this is Entity))
      {
        if (aStructure != null)
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

    #region Inputs

    protected virtual void SetInputs(params string[] names)
    {
      inputs = new IOperation[names.Length];
      inputNames = new string[names.Length];
      for (int i = 0; i < names.Length; i++)
      {
        InputNames[i] = names[i];
      }
    }

    public virtual void SetInput(string name, IOperation input)
    {
      if (inputs != null)
      {
        for (int i = 0; i < inputs.Length; i++)
        {
          if (InputNames[i] == name)
            inputs[i] = input;
        }
      }
    }

    public object GetValue(string name)
    {
      IOperation oper = GetInput(name);
      return GetValueFromOperation(oper);
    }

    public object GetValue(int idx)
    {
      IOperation oper = GetInput(idx);
      return GetValueFromOperation(oper);
    }

    private object GetValueFromOperation(IOperation oper)
    {
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

    public IOperation GetInput(string name)
    {
      if (inputs != null)
      {
        for (int i = 0; i < inputs.Length; i++)
        {
          if (InputNames[i] == name)
            return inputs[i];
        }
      }

      return null;
    }

    public IOperation GetInput(int idx)
    {
      if ((inputs != null) && (idx < inputs.Length))
      {
        return inputs[idx];
      }
      else
        return null;
    }

    public virtual void SetInput(int idx, IOperation input)
    {
      if (inputs != null)
      {
        inputs[idx] = input;
      }
    }

    public string GetInputName(int idx)
    {
      if ((InputNames != null) && (idx < InputNames.Length))
      {
        return InputNames[idx];
      }
      else
        return null;
    }


    private IOperation[] inputs;
    private string[] inputNames;
    [Browsable(false)]
    public string[] InputNames
    {
      get { return inputNames; }
    }

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
    #endregion

    protected virtual void SetOutputs(params string[] names)
    {
      outputs = new IOperation[names.Length];
      outputNames = new string[names.Length];
      for (int i = 0; i < names.Length; i++)
      {
        outputNames[i] = names[i];
      }
    }


    public virtual void SetValue(string name, Object value)
    {
      IScalarVar var = GetOutput(name) as IScalarVar;
      if (var != null)
        var.RawValue = value;
    }

    public virtual void SetValue(int idx, Object value)
    {
      IScalarVar var = GetOutput(idx) as IScalarVar;
      if (var != null)
        var.RawValue = value;
    }

    public virtual void SetOutput(string name, IOperation output)
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

    [Category("Design")]
    public bool IgnoreOperation { get; set; }

    public IOperation GetOutput(string name)
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

    public virtual void SetOutput(int idx, IOperation output)
    {
      if (outputs != null)
      {
        outputs[idx] = output;
      }
    }

    public IOperation GetOutput(int idx)
    {
      if ((outputs != null) && (idx < outputs.Length))
      {
        return outputs[idx];
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


    private IOperation[] outputs;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IOperation[] Outputs
    {
      get
      {
        return outputs;
      }
    }

    private string[] outputNames;
    [Browsable(false)]
    public string[] OutputNames
    {
      get { return outputNames; }
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

    [Browsable(false)]
    public virtual IEntity EntityValue
    {
      get
      {
        return this.Result;
      }
    }

    [NonSerialized]
    private IEntity result;
    [Browsable(false)]
    public IEntity Result
    {
      get { return result; }
      set { result = value; }
    }

    protected virtual bool PrepareInputs()
    {
      bool result = false;
      foreach (IOperation input in inputs)
      {
        if (input != null)
        {
          if ((input is Operation) && (((Operation)input).Status == ExecutionStatus.WaitingExecution))
          {
            ((IOperation)input).Execute();
            result = true;
          }
        }
      }
      return result;
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

    [field: NonSerialized()]
    public event EventHandler StatusChange;

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
        if (value.GetInterface("IIrisRunnable") != null)
          value = typeof(IIrisRunnable);
        dataType = value;
      }
    }

    protected abstract IEntity doExecute();

    protected virtual void doBeforeExecute()
    {
      this.Structure.AddToLog("Início da execução da operação " + DisplayText, this);
      Application.DoEvents();
    }

    protected virtual void doAfterExecute()
    {
      Status = ExecutionStatus.Success;
      if (OnSuccess != null)
      {
        ExecuteObj(OnSuccess);
      }

    }

    public virtual void Execute()
    {
      if (Structure.Stop)
      {
        Structure.ExecuteStop();
      }
      else
      {
        if (this.structure.StartPoint == this)
        {
          this.Structure.RefreshSchemas();
          this.Structure.ApplyBindings();
        }

        result = null;
        Status = ExecutionStatus.PreparingInputs;
        bool inputsToPrepare = PrepareInputs();
        Structure.RunningOper = this;
        if (inputsToPrepare && Structure.InStep)
          return;
        Status = ExecutionStatus.Running;

        doBeforeExecute();

        try
        {
          DateTime t1 = DateTime.Now;
          if (!IgnoreOperation)
            result = doExecute();
          else
            result = null;
          TimeSpan ts = DateTime.Now - t1;
          doAfterExecute();
          this.Structure.AddToLog("Término da execução da operação " + DisplayText + "       Duração:" + ts.ToString(), this);

        }
        catch (Exception ex)
        {
          if (!(ex is ExecutionException))
          {
            this.Structure.AddToErrorLog("Falha da execução da operação " + DisplayText, this);
            this.Structure.AddToLog(DisplayText, ex, this);

            if (ShowErrorStack)
            {
              string[] stack = ex.StackTrace.Split('\r').Select(x => x.Trim()).ToArray();
              for (int i = 0; i < stack.Length; i++)
              {
                Structure.AddToErrorLog("  STACK - " + stack[i], this);
              }
            }

            Status = ExecutionStatus.Failure;
            if (OnFailure != null)
            {
              ExecuteObj(OnFailure);
            }
            else if ((Structure.DefaultExceptionHandler != null) && (!IgnoreFailure) && (!Structure.IsHandlingException))
            {
              Structure.IsHandlingException = true;
              ExecuteObj(Structure.DefaultExceptionHandler);
            }
            else
            {
              if (ignoreFailure)
                ExecuteObj(OnSuccess);
            }
          }
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

    protected void ExecuteObj(IOperation obj)
    {
      if (obj is Operation)
      {
        Operation oper = (Operation)obj;
        if ((oper.Status != ExecutionStatus.Entity) && (oper.status != ExecutionStatus.PreparingInputs))
          oper.status = ExecutionStatus.WaitingExecution;

        if ((!structure.InStep) && (!((BreakPoint) && (structure.Debug))))
        {
          if (oper != null)
            if (oper.Status == ExecutionStatus.WaitingExecution)
              oper.Execute();
        }
        else
          structure.RunningOper = oper;
      }
    }

    private bool ignoreFailure;
    [DisplayName("Ignorar Falhas"), Category("Exception Handling"), Description("Indica se a execução deve prosseguir mesmo em caso de falha na operação")]
    public virtual bool IgnoreFailure
    {
      get { return ignoreFailure; }
      set { ignoreFailure = value; }
    }

    [Category("Exception Handling"), DisplayName("Show Error Stack")]
    public bool ShowErrorStack { get; set; }


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
      if (Structure.StartPoint == this)
        Structure.StartPoint = null;
      if (Structure.OutputPoint == this)
        Structure.OutputPoint = null;
      if (Structure.DefaultExceptionHandler == this)
        Structure.DefaultExceptionHandler = null;
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
        if (string.IsNullOrEmpty(displayText))
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

    [Browsable(false)]
    public string Notes { get; set; }

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
      set
      {
        structure = (Structure)value;
      }
    }


    #endregion

    protected OperationType operationType;
    [Category("Design info"), Browsable(false)]
    public virtual OperationType OperationType
    {
      get
      {
        operationType = OperationType.Operation;
        return OperationType.Operation;
      }
    }

    [Category("Design info"), DisplayName("Tipo")]
    public string OperationName
    {
      get
      {
        OperationCategory att = GetCategoryAttribute();
        if (att != null)
          return att.Name + " - (" + this.GetType().Name + ")";
        else
          return this.GetType().Name;
      }
    }

    private OperationCategory GetCategoryAttribute()
    {
      return System.Attribute.GetCustomAttributes(this.GetType()).Where(x => x is OperationCategory).
          Cast<OperationCategory>().FirstOrDefault();
    }

    [Browsable(false)]
    public virtual bool LargeObject
    {
      get
      {
        return false;
      }
    }

    [Category("Design info"), DisplayName("Categoria")]
    public string OperationCategory
    {
      get
      {
        OperationCategory att = GetCategoryAttribute();
        if (att != null)
          return att.Category;
        else
          return "";
      }
    }

    //Utilizado pelo objeto structure para atribuir valores usando a sintaxe Structure["OpName"] = valor
    //Subclasses devem implementar uma chamada para Structure.AddToLog
    public virtual void AssignObject(Object value)
    {



    }
  }
}
