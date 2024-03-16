namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_con_SubgrupoConceito
    {
        public mtd_con_SubgrupoConceito()
        {
            mtd_con_Conceitos = new HashSet<mtd_con_Conceitos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Conceito_Subgrupo_Cod { get; set; }

        [StringLength(50)]
        public string Subgrupo { get; set; }

        public int Conceito_Grupo_Cod { get; set; }

        public int? Ordem { get; set; }

        public virtual ICollection<mtd_con_Conceitos> mtd_con_Conceitos { get; set; }

        public virtual mtd_con_GrupoConceito mtd_con_GrupoConceito { get; set; }
    }
}
