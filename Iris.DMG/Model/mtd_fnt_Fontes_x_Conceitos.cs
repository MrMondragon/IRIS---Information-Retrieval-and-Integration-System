namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_fnt_Fontes_x_Conceitos
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string Conceito_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Fonte_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Campo { get; set; }

        public string xCampo1 { get; set; }

        public string xCampo2 { get; set; }

        public virtual mtd_con_Conceitos mtd_con_Conceitos { get; set; }

        public virtual mtd_fnt_Fontes_Campos mtd_fnt_Fontes_Campos { get; set; }
    }
}
