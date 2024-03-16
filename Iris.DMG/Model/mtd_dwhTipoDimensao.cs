namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_dwhTipoDimensao
    {
        public mtd_dwhTipoDimensao()
        {
            mtd_dwh_Dimensoes = new HashSet<mtd_dwh_Dimensoes>();
            mtd_dwhTipoDimensao_Campos = new HashSet<mtd_dwhTipoDimensao_Campos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dimensao_Tipo_Cod { get; set; }

        [StringLength(20)]
        public string Dimensao_Tipo { get; set; }

        public virtual ICollection<mtd_dwh_Dimensoes> mtd_dwh_Dimensoes { get; set; }

        public virtual ICollection<mtd_dwhTipoDimensao_Campos> mtd_dwhTipoDimensao_Campos { get; set; }
    }
}
