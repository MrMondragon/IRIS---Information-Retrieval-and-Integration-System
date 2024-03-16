namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_fnt_Fontes
    {
        public mtd_fnt_Fontes()
        {
            mtd_fnt_Fontes_Campos = new HashSet<mtd_fnt_Fontes_Campos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Fonte_Id { get; set; }

        [StringLength(50)]
        public string Fonte { get; set; }

        [StringLength(255)]
        public string Fonte_Descricao { get; set; }

        public int? Fonte_Tipo_Cod { get; set; }

        [StringLength(255)]
        public string Fonte_Origem { get; set; }

        public DateTime? Fonte_UltimaImportacao { get; set; }

        [StringLength(50)]
        public string Fonte_Grupo { get; set; }

        public virtual ICollection<mtd_fnt_Fontes_Campos> mtd_fnt_Fontes_Campos { get; set; }

        public virtual mtd_fntTipoFonte mtd_fntTipoFonte { get; set; }
    }
}
