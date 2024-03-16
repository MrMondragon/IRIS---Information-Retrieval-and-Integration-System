namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_conConceitos_x_Conjuntos
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

        public virtual mtd_conConceitos mtd_conConceitos { get; set; }

        public virtual mtd_conConjuntoConceito mtd_conConjuntoConceito { get; set; }
    }
}
