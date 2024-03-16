namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_con_GrupoConceito
    {
        public mtd_con_GrupoConceito()
        {
            mtd_con_SubgrupoConceito = new HashSet<mtd_con_SubgrupoConceito>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Conceito_Grupo_Cod { get; set; }

        [StringLength(50)]
        public string Grupo { get; set; }

        public int? Ordem { get; set; }

        public virtual ICollection<mtd_con_SubgrupoConceito> mtd_con_SubgrupoConceito { get; set; }
    }
}
