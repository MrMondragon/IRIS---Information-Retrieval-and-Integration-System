using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.PropertyEditors.Interfaces;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Iris.PropertyEditors;

namespace Iris.Runtime.Model.Operations.SchemaOperations
{
  [Serializable]
  public abstract class BaseSchemaOperation : DynamicLinkOperation
  {
    public BaseSchemaOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Schema", "Filename", "Text");
    }


    private SchemaEntity Schema
    {
      get
      {
        if (GetInput(0) == null)
          return null;
        else
        {
          IEntity schema = GetInput(0).EntityValue;
          if ((schema != null) && (!(schema is SchemaEntity)))
            throw new Exception("O objeto de entrada não é um schema");
          else
            return (SchemaEntity)schema;
        }
      }
    }

    protected string InputFileName
    {
      get 
      {
        if (GetInput(1) == null)
          return null;
        else
        {
          IEntity fileNameEntity = GetInput(1).EntityValue;
          return Convert.ToString(fileNameEntity.Value);
        }
      }
    }

    protected string InputText
    {
      get
      {
        if (GetInput(2) == null)
          return null;
        else
        {
          IEntity textEntity = GetInput(2).EntityValue;
          return Convert.ToString(textEntity.Value);
        }
      }
    }


    protected string[] GetIOList(bool _input)
    {
      List<string> list = new List<string>();
      if (_input)
      {
        list.Add("Schema");
        list.Add("Filename");
        list.Add("Text");
      }
      if (Schema != null)
        list.AddRange(Schema.GetTableNames());
      return list.ToArray();
    }

    protected IrisList<ResultSet> GetRSList(bool input, int firstIndex)
    {
      Operation[] IO;

      if (input)
      {
        IO = new Operation[InputCount];
        for (int i = 0; i < InputCount; i++)
        {
          IO[i] = GetInput(i);
        }
      }
      else
      {
        IO = new Operation[OutputCount];
        for (int i = 0; i < OutputCount; i++)
        {
          IO[i] = GetOutput(i);
        }
      }

      IrisList<ResultSet> list = new IrisList<ResultSet>("");
      for (int i = firstIndex; i < IO.Length; i++)
      {
        Operation oper = IO[i];
        if (oper != null)
        {
          IEntity entity = oper.EntityValue;
          if (entity is ResultSet)
          {
            list.Add((ResultSet)entity);
          }
        }
      }
      return list;
    }

    public override void SetInput(int idx, Operation input)
    {
      Operation oldInput = GetInput(idx);

      base.SetInput(idx, input);

      if ((idx == 0) && (oldInput != input))
      {
        RefreshIO();
      }
    }

    private string fileName;
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("File Name"), Category("Arquivo"), Description("A localização do arquivo em disco")]
    public string FileName
    {
      get
      {
        return fileName;
      }
      set { fileName = value; }
    }

    private string tmpFileName;

    protected override IEntity doExecute()
    {
      if (Schema != null)
      {
        tmpFileName = Schema.FileName;
        if (!string.IsNullOrEmpty(InputFileName))
        {
          Schema.FileName = InputFileName;
        }
        else if (!string.IsNullOrEmpty(FileName))
        {
          Schema.FileName = FileName;
        }
        else if (!string.IsNullOrEmpty(InputText))
        {
          Schema.FileName = "";
          Schema.RawText = InputText;
        }
      }
      return Schema;
    }

    protected void AfterExecute()
    {
      LogOperation();
      Schema.FileName = tmpFileName;
    }

    protected abstract void ConfigOperationLog(out string action, out IrisList<ResultSet> list);

    private void LogOperation()
    {
      string action;
      IrisList<ResultSet> list;

      ConfigOperationLog(out action, out list);

      action += Schema.FileName;
      Structure.AddToLog(action, this);

      for (int i = 0; i < list.Count; i++)
      {
        Structure.AddToLog(string.Format("    {1}: {0} registros", list[i].RecCount, list[i].Name), this);
      }
    }
  }
}
