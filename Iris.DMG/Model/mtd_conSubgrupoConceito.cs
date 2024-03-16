namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_conSubgrupoConceito
    {
        public mtd_conSubgrupoConceito()
        {
            mtd_conConceitos = new HashSet<mtd_conConceitos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Conceito_Subgrupo_Cod { get; set; }

        [StringLength(50)]
        public string Subgrupo { get; set; }

        public int Conceito_Grupo_Cod { get; set; }

        public int? Ordem { get; set; }

        public virtual ICollection<mtd_conConceitos> mtd_conConceitos { get; set; }

        public virtual mtd_conGrupoConceito mtd_conGrupoConceito { get; set; }
    }
}
