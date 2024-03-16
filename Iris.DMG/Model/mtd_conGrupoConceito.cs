namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_conGrupoConceito
    {
        public mtd_conGrupoConceito()
        {
            mtd_conSubgrupoConceito = new HashSet<mtd_conSubgrupoConceito>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Conceito_Grupo_Cod { get; set; }

        [StringLength(50)]
        public string Grupo { get; set; }

        public int? Ordem { get; set; }

        public virtual ICollection<mtd_conSubgrupoConceito> mtd_conSubgrupoConceito { get; set; }
    }
}
