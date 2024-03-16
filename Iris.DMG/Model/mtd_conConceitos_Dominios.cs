namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_conConceitos_Dominios
    {
        public mtd_conConceitos_Dominios()
        {
            mtd_fnt_Fontes_Valores_x_Dominios = new HashSet<mtd_fnt_Fontes_Valores_x_Dominios>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string Conceito_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dominio_Valor { get; set; }

        [StringLength(255)]
        public string Dominio_Rotulo { get; set; }

        [StringLength(50)]
        public string Dominio_Abreviacao { get; set; }

        public int? Dominio_Ordem { get; set; }

        public virtual mtd_conConceitos mtd_conConceitos { get; set; }

        public virtual ICollection<mtd_fnt_Fontes_Valores_x_Dominios> mtd_fnt_Fontes_Valores_x_Dominios { get; set; }
    }
}
