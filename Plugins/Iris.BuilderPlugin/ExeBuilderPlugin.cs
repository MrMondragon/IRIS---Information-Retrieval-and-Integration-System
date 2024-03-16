using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Iris.Designer.BuildSupport;
using Iris.BuilderPlugin.Properties;
using System.Drawing;
using System.IO;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using Iris.Runtime.Model;

namespace Iris.BuilderPlugin
{
  public class ExeBuilderPlugin : BaseAssemblyBuilder
  {
    protected override string GetHint()
    {
      return "Compilar Executável";
    }

    protected override Image GetImage()
    {
      return Resources.BuildExe;
    }

    public override void DoExecute()
    {


      string outputFile = BuildAssembly(BuildType.Executable);

      if (!string.IsNullOrEmpty(outputFile))
      {
        outputFile = Path.ChangeExtension(outputFile, ".cfg");
        using (StreamWriter sw = new StreamWriter(outputFile, false, Encoding.Default))
        {
          if (Structure.Connections.Length != 0)
          {
            sw.WriteLine("!!!!!CONEXÕES - Utilize os parâmetros abaixo para alterar os dados de conexão da integração");

            foreach (DynConnection connection in Structure.Connections)
            {
              string connectionName = connection.Name;
              string connectionComment = connectionName;
              if (!string.IsNullOrEmpty(connection.DisplayText))
              {
                connectionComment = connection.DisplayText + " (" + connectionName + ")";
              }
              if (!string.IsNullOrEmpty(connection.Description))
              {
                connectionComment += " - " + connection.Description;
              }

              sw.WriteLine("!");
              sw.WriteLine("!!!!!{0}", connectionComment);
              WriteNotes(sw, connection.Notes);
              sw.WriteLine("!\"{0}=Nova string de conexão\"", connectionName);
              sw.WriteLine("!");
            }
            sw.WriteLine("!");

          }
          if (Structure.ScalarVars.Length != 0)
          {
            sw.WriteLine("!!!!!VARIÁVEIS DE PARÂMETRO - Utilize os parâmetros abaixo para informar valores parametrizados para as variáveis da integração");
            foreach (IScalarVar isVar in Structure.ScalarVars)
            {
              ScalarVar sVar = (ScalarVar)isVar;
              if (sVar.ExternalParam)
                WriteOperation(sw, sVar, "Valor do Parâmetro");
            }
            sw.WriteLine("!");

          }
          if (Structure.Schemas.Length != 0)
          {
            sw.WriteLine("!!!!!SCHEMAS DE LEITURA/GRAVAÇÃO DE ARQUIVOS - Utilize os parâmetros abaixo para configurar a localização/nome dos arquivos da integração");
            foreach (ISchemaEntity schema in Structure.Schemas)
            {
              SchemaEntity se = (SchemaEntity)schema;
              WriteOperation(sw, se, "Caminho/Nome do arquivo de dados");
            }
            sw.WriteLine("!");
          }
          sw.WriteLine("!");
          sw.WriteLine("!");
          sw.WriteLine("!   Para habilitar os parâmetros acima, remova o sinal de comentário (!)");
          sw.WriteLine("!   Para utilizar estes parâmetros como argumentos de linha de comando, utilize a forma NomeParam=Valor");
          sw.WriteLine("!   separando os conjuntos nome=valor com espaços. Caso o valor possua um espaço, utilze aspas duplas em");
          sw.WriteLine("!   torno do conjunto (Ex.: \"NomeParam=Valor do Parametro\") ");

        }

      }

    }

    private void WriteOperation(StreamWriter sw, IOperation iOper, string paramText)
    {
      string opName = iOper.Name;
      string opComment = opName;
      if (!string.IsNullOrEmpty(iOper.DisplayText))
      {
        opComment = iOper.DisplayText + " (" + opName + ")";
      }
      if (!string.IsNullOrEmpty(iOper.Description))
      {
        opComment += " - " + iOper.Description;
      }

      sw.WriteLine("!");
      sw.WriteLine("!!!!!{0}", opComment);
      WriteNotes(sw, iOper.Notes);
      sw.WriteLine("!\"{0}={1}\"", opName, paramText);
      sw.WriteLine("!");
    }

    private void WriteNotes(StreamWriter sw, string notes)
    {
      if (!string.IsNullOrEmpty(notes))
      {
        string[] noteLines = notes.Split('\r').Select(x => x.Trim()).ToArray();

        foreach (string line in noteLines)
        {
          sw.WriteLine("!!!!!   {0}", line);
        }
      }
    }
  }
}
