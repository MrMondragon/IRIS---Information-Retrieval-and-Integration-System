namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_con_ConjuntoConceito
    {
        public mtd_con_ConjuntoConceito()
        {
            mtd_con_Conceitos_x_Conjuntos = new HashSet<mtd_con_Conceitos_x_Conjuntos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Conceito_Conjunto_Cod { get; set; }

        [StringLength(50)]
        public string Conceito_Conjunto { get; set; }

        [StringLength(10)]
        public string Conceito_Prefixo { get; set; }

        public virtual ICollection<mtd_con_Conceitos_x_Conjuntos> mtd_con_Conceitos_x_Conjuntos { get; set; }
    }
}
