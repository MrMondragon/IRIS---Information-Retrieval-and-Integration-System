namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_fntTipoFonte
    {
        public mtd_fntTipoFonte()
        {
            mtd_fnt_Fontes = new HashSet<mtd_fnt_Fontes>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Fonte_Tipo_Cod { get; set; }

        [Required]
        [StringLength(50)]
        public string Fonte_Tipo { get; set; }

        public virtual ICollection<mtd_fnt_Fontes> mtd_fnt_Fontes { get; set; }
    }
}
