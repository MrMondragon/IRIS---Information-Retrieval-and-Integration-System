namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_fnt_Fontes_Valores_x_Dominios
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Fonte_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Campo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Fonte_Valor { get; set; }

        [Required]
        [StringLength(2)]
        public string Conceito_Id { get; set; }

        public int Dominio_Valor { get; set; }

        public virtual mtd_con_Conceitos_Dominios mtd_con_Conceitos_Dominios { get; set; }

        public virtual mtd_fnt_Fontes_Campos mtd_fnt_Fontes_Campos { get; set; }
    }
}
