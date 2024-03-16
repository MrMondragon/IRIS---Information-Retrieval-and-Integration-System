namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_fntTipoCampo
    {
        public mtd_fntTipoCampo()
        {
            mtd_fnt_Fontes_Campos = new HashSet<mtd_fnt_Fontes_Campos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Campo_Tipo_Cod { get; set; }

        [Required]
        [StringLength(50)]
        public string Campo_Tipo { get; set; }

        [Required]
        [StringLength(255)]
        public string Campo_Descricao { get; set; }

        public virtual ICollection<mtd_fnt_Fontes_Campos> mtd_fnt_Fontes_Campos { get; set; }
    }
}
