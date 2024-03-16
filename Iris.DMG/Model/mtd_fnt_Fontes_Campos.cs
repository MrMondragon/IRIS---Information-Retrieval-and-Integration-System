namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_fnt_Fontes_Campos
    {
        public mtd_fnt_Fontes_Campos()
        {
            mtd_fnt_Fontes_Valores_x_Dominios = new HashSet<mtd_fnt_Fontes_Valores_x_Dominios>();
            mtd_fnt_Fontes_x_Conceitos = new HashSet<mtd_fnt_Fontes_x_Conceitos>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Fonte_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Campo { get; set; }

        public int? Campo_Tipo_Cod { get; set; }

        [StringLength(20)]
        public string Fonte_Id_Origem { get; set; }

        public virtual mtd_fnt_Fontes mtd_fnt_Fontes { get; set; }

        public virtual mtd_fntTipoCampo mtd_fntTipoCampo { get; set; }

        public virtual ICollection<mtd_fnt_Fontes_Valores_x_Dominios> mtd_fnt_Fontes_Valores_x_Dominios { get; set; }

        public virtual ICollection<mtd_fnt_Fontes_x_Conceitos> mtd_fnt_Fontes_x_Conceitos { get; set; }
    }
}
