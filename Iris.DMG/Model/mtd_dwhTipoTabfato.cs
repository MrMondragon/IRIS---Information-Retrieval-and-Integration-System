namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_dwhTipoTabfato
    {
        public mtd_dwhTipoTabfato()
        {
            mtd_dwh_Tabfatos = new HashSet<mtd_dwh_Tabfatos>();
            mtd_dwhTipoTabfato_Campos = new HashSet<mtd_dwhTipoTabfato_Campos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tabfato_Tipo_Cod { get; set; }

        [StringLength(20)]
        public string Tabfato_Tipo { get; set; }

        public virtual ICollection<mtd_dwh_Tabfatos> mtd_dwh_Tabfatos { get; set; }

        public virtual ICollection<mtd_dwhTipoTabfato_Campos> mtd_dwhTipoTabfato_Campos { get; set; }
    }
}
