namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_con_Conceitos_x_Conjuntos
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string Conceito_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Conceito_Conjunto_Cod { get; set; }

        public int? Ordem { get; set; }

        public virtual mtd_con_Conceitos mtd_con_Conceitos { get; set; }

        public virtual mtd_con_ConjuntoConceito mtd_con_ConjuntoConceito { get; set; }
    }
}
