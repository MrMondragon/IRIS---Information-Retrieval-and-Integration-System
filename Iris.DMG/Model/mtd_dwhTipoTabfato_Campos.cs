namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_dwhTipoTabfato_Campos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tabfato_Tipo_Cod { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ordem { get; set; }

        [StringLength(255)]
        public string Campo { get; set; }

        [StringLength(255)]
        public string Tipo { get; set; }

        public int? Tamanho { get; set; }

        [StringLength(50)]
        public string Valor_Default { get; set; }

        public virtual mtd_dwhTipoTabfato mtd_dwhTipoTabfato { get; set; }
    }
}
