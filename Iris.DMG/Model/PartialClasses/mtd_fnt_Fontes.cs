using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris.DMG.Model
{
  public partial class mtd_fnt_Fontes
  {

    private Dictionary<string, Dictionary<string, int>> dominios;

    public int GetValorDominio(string campo, string valorFonte)
    {
      if(dominios == null)
      {
       
        IEnumerable<mtd_fnt_Fontes_Valores_x_Dominios> fvxds =  this.mtd_fnt_Fontes_Campos.SelectMany(x=> x.mtd_fnt_Fontes_Valores_x_Dominios);
        dominios = new Dictionary<string, Dictionary<string, int>>();
        foreach ( mtd_fnt_Fontes_Valores_x_Dominios fvxd in fvxds)
        {
          if (!dominios.ContainsKey(fvxd.Campo))
            dominios[fvxd.Campo] = new Dictionary<string, int>();

          dominios[fvxd.Campo][fvxd.Fonte_Valor] = fvxd.Dominio_Valor;
        }
      }

      if(!dominios.ContainsKey(campo))
        throw new Exception(string.Format("mtd_fnt_Fontes_Campos não encontrado para campo {0} da fonte {1}", campo, Fonte));
      if(!dominios[campo].ContainsKey(valorFonte))
        throw new Exception(string.Format("mtd_fnt_Fontes_Valores_x_Dominios não encontrado para o valor {2} do campo {0} na fonte {1}", campo, Fonte, valorFonte));
      
      return dominios[campo][valorFonte];
    }

  }
}
