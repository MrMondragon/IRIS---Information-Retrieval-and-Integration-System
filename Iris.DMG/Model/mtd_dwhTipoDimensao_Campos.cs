namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_dwhTipoDimensao_Campos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dimensao_Tipo_Cod { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ordem { get; set; }

        [StringLength(255)]
        public string Campo { get; set; }

        [StringLength(255)]
        public string Tipo { get; set; }

        public int? Tamanho { get; set; }

        public virtual mtd_dwhTipoDimensao mtd_dwhTipoDimensao { get; set; }
    }
}
