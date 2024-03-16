namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_conConjuntoConceito
    {
        public mtd_conConjuntoConceito()
        {
            mtd_conConceitos_x_Conjuntos = new HashSet<mtd_conConceitos_x_Conjuntos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Conceito_Conjunto_Cod { get; set; }

        [StringLength(50)]
        public string Conceito_Conjunto { get; set; }

        public virtual ICollection<mtd_conConceitos_x_Conjuntos> mtd_conConceitos_x_Conjuntos { get; set; }
    }
}
