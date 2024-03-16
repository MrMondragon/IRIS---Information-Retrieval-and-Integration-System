namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_conConceitos
    {
        public mtd_conConceitos()
        {
            mtd_conConceitos_Dominios = new HashSet<mtd_conConceitos_Dominios>();
            mtd_conConceitos_x_Conjuntos = new HashSet<mtd_conConceitos_x_Conjuntos>();
            mtd_dwh_Dimensoes = new HashSet<mtd_dwh_Dimensoes>();
            mtd_fnt_Fontes_x_Conceitos = new HashSet<mtd_fnt_Fontes_x_Conceitos>();
        }

        [Key]
        [StringLength(2)]
        public string Conceito_Id { get; set; }

        [StringLength(50)]
        public string Conceito { get; set; }

        [StringLength(255)]
        public string Conceito_Descricao { get; set; }

        [StringLength(255)]
        public string Conceito_Nome { get; set; }

        public int? Conceito_Subgrupo_Cod { get; set; }

        [StringLength(50)]
        public string Conceito_Abreviacao { get; set; }

        public int? Ordem { get; set; }

        public int? Conceito_Tipo_Cod { get; set; }

        public virtual ICollection<mtd_conConceitos_Dominios> mtd_conConceitos_Dominios { get; set; }

        public virtual mtd_conSubgrupoConceito mtd_conSubgrupoConceito { get; set; }

        public virtual mtd_conTipoConceito mtd_conTipoConceito { get; set; }

        public virtual ICollection<mtd_conConceitos_x_Conjuntos> mtd_conConceitos_x_Conjuntos { get; set; }

        public virtual ICollection<mtd_dwh_Dimensoes> mtd_dwh_Dimensoes { get; set; }

        public virtual ICollection<mtd_fnt_Fontes_x_Conceitos> mtd_fnt_Fontes_x_Conceitos { get; set; }
    }
}
