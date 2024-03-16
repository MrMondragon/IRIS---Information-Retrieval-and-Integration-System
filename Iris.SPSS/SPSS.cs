using Iris.Runtime.Model.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iris.Interfaces;
using Spss;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Drawing;
using Iris.SPSS.Properties;
using Iris.Runtime.Model.Entities;
using System.Data;

namespace Iris.SPSS
{
  [Serializable]
  [OperationCategory("Operações de Controle", "SPSS")]
  public class SPSS : Operation
  {
    public SPSS(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Filename");
      SetOutputs("Perguntas", "PerguntaOpções", "Questionarios");
    }

    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    public string FileName { get; set; }

    protected override IEntity doExecute()
    {
      string filename = FileName;

      if(GetInput("Filename") != null)
      {
        filename = Convert.ToString(GetInput("Filename"));
      }

      ResultSet rsPerguntas = GetOutput("Perguntas") as ResultSet;
      ResultSet rsPO = GetOutput("PerguntaOpções") as ResultSet;
      ResultSet rsQuest = GetOutput("Questionarios") as ResultSet;

      if (rsPerguntas == null)
        throw new Exception("ResultSet de saída Perguntas não atribuído");

      if (rsPO == null)
        throw new Exception("ResultSet de saída PerguntaOpções não atribuído");

      if (rsQuest == null)
        throw new Exception("ResultSet de saída Questionarios não atribuído");

      SpssDataDocument doc = SpssDataDocument.Open(filename, SpssFileAccess.Read);

      DataTable tabPerguntas = new DataTable(rsPerguntas.Name);
      rsPerguntas.Table = tabPerguntas;

      tabPerguntas.Columns.Add("Perg_Cod");
      tabPerguntas.Columns.Add("Pergunta");


      DataTable tabPO = new DataTable(rsPO.Name);
      rsPO.Table = tabPO;

      tabPO.Columns.Add("Perg_Cod");
      tabPO.Columns.Add("Opcao_Valor");
      tabPO.Columns.Add("Opcao_Rotulo");

      DataTable tabQuest = new DataTable(rsQuest.Name);
      rsQuest.Table = tabQuest;


      tabPerguntas.BeginLoadData();
      tabPO.BeginLoadData();
      foreach (SpssVariable sv in doc.Variables)
      {

        tabQuest.Columns.Add(sv.Name);

        DataRow perguntaRow = tabPerguntas.NewRow();
        perguntaRow["Perg_Cod"] = sv.Name;
        perguntaRow["Pergunta"] = sv.Label;

        tabPerguntas.LoadDataRow(perguntaRow.ItemArray, false);

        IEnumerable<KeyValuePair<string, string>> valueLabels = sv.GetValueLabels();
        foreach (KeyValuePair<string,string> item in valueLabels)
        {
          DataRow poRow = tabPO.NewRow();
          poRow["Perg_Cod"] = sv.Name;
          poRow["Opcao_Valor"] = item.Key;
          poRow["Opcao_Rotulo"] = item.Value;
          tabPO.LoadDataRow(poRow.ItemArray, false);
        }
      }

      tabPO.EndLoadData();
      tabPerguntas.EndLoadData();


      tabQuest.BeginLoadData();

      foreach (SpssCase item in doc.Cases)
      {
        DataRow questRow = tabQuest.NewRow();
        foreach (SpssVariable sv in doc.Variables)
        {
          questRow[sv.Name] = Convert.ToString(item.GetDBValue(sv.Name)).Trim();
        }
        tabQuest.LoadDataRow(questRow.ItemArray, false);
      }
      tabQuest.EndLoadData();

      Structure.AddToLog($"{tabPerguntas.Rows.Count} perguntas carregadas com {tabPO.Rows.Count} opções no total", this);
      Structure.AddToLog($"{tabQuest.Rows.Count} questionários carregados", this);

      return null;
    }

    public static Bitmap GetIcon()
    {
      return Resources.SPSS;
    }

    public override bool LargeObject
    {
      get
      {
        return true;
      }
    }

  }
}
