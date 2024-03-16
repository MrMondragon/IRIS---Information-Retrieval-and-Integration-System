namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_dwh_Tabfatos
    {
        public mtd_dwh_Tabfatos()
        {
            mtd_dwh_Dimensoes = new HashSet<mtd_dwh_Dimensoes>();
        }

        [Key]
        [StringLength(50)]
        public string Tabfato { get; set; }

        public int Tabfato_Tipo_Cod { get; set; }

        public virtual mtd_dwhTipoTabfato mtd_dwhTipoTabfato { get; set; }

        public virtual ICollection<mtd_dwh_Dimensoes> mtd_dwh_Dimensoes { get; set; }
    }
}
