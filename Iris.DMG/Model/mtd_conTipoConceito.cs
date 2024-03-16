namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_conTipoConceito
    {
        public mtd_conTipoConceito()
        {
            mtd_con_Conceitos = new HashSet<mtd_con_Conceitos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Conceito_Tipo_Cod { get; set; }

        [StringLength(20)]
        public string Conceito_Tipo { get; set; }

        public virtual ICollection<mtd_con_Conceitos> mtd_con_Conceitos { get; set; }
    }
}
