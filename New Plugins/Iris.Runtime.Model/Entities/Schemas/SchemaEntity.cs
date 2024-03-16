using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.BaseObjects;
using System.Data;
using Iris.Interfaces;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using Iris.Runtime.Core.PropertyEditors.Interfaces;
using Iris.PropertyEditors;

namespace Iris.Runtime.Model
{
  [Serializable]
  public abstract class SchemaEntity : Entity, IScalarVar, ISchemaEntity, IScriptedObject
  {

    public SchemaEntity(string aName, Structure aStructure)
      : base(aName, aStructure)
    {
      Structure.Schemas.Add(this);

      int prefixSize = 3;

      if (Name.Length < 3)
        prefixSize = Name.Length;

      TablePrefix = Name.Substring(0, prefixSize).ToLower();
    }

    private string rawText;

    [Browsable(false)]
    public object RawValue
    {
      get
      {
        return rawText;
      }
      set
      {
        rawText = Convert.ToString(value);
      }
    }

    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    [DisplayName("Texto"), Category("Arquivo"), Description("O texto em memória do schema. Não é utilizado quando se informa um nome de arquivo.")]
    public string RawText
    {
      get
      {
        return rawText;
      }
      set 
      {
        rawText = value; 
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


    private string tablePrefix;
    [DisplayName("Prefixo"), Category("Schema"), Description("O prefixo que será adicionado ao nome das tabelas associadas a este arquivo")]
    public string TablePrefix
    {
      get { return tablePrefix; }
      set 
      {
        tablePrefix = value; 
      }
    }

    [Browsable(false)]
    public override string DisplayText
    {
      get
      {
        return base.DisplayText;
      }
      set
      {
        base.DisplayText = value;
      }
    }

    protected override IEntity doExecute()
    {
      if (GetOutput(0) is ScalarVar)
      {
        ((ScalarVar)GetOutput(0)).RawValue = RawText;
        return (IEntity)GetOutput(0);
      }
      else
        return this;
    }

    public abstract void CreateResultSets();
    public abstract void RefreshResultSets();
    public abstract void RefreshResultSets(ResultSet resultSet);
    public abstract void ReadToTables(IrisList<ResultSet> resultsets);
    public abstract void WriteFromTables(IrisList<ResultSet> resultsets);
    public abstract List<string> GetTableNames();
    public abstract void ClearTables();

    #region IScriptedObject Members
    [Browsable(false)]
    public string Script
    {
      get
      {
        return RawText;
      }
      set
      {
        RawText = value;
      }
    }

    [Browsable(false)]
    public string Language
    {
      get { return "None"; }
    }

    IStructure IScriptedObject.Structure
    {
      get { return Structure; }
    }

    #endregion

  }
}
