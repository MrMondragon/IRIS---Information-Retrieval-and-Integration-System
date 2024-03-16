using Databridge.Interfaces.BaseEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris.Stilingue
{
  public class ServiceEditor : BaseListEditor<string>
  {
    protected override List<string> GetItems(object obj)
    {
      return new List<string>()
      {
        "metadados",
        "publicacoes",
        "influenciadores",
        "buscaexpress",
        "termos",
        "aaa",
        "estatisticas",
        "estatisticas_termos",
        "sentimento_temas",
        "sentimento_links",
        "sentimento_dominios",
        "sentimento_hashtags",
        "sentimento_tags",
        "sentimento_buscas",
        "sentimento_regioes",
        "sentimento_grupos",
        "linechart",
        "visao_geral",
        "onde",
        "manchetes",
        "temasetopicos",
        "top_influenciadores"
      };
    }
  }
}
