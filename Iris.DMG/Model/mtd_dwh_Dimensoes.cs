namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_dwh_Dimensoes
    {
        public mtd_dwh_Dimensoes()
        {
            mtd_dwh_Tabfatos = new HashSet<mtd_dwh_Tabfatos>();
        }

        [Key]
        [StringLength(50)]
        public string Dimensao { get; set; }

        public int Dimensao_Tipo_Cod { get; set; }

        [StringLength(50)]
        public string Dimensao_Id { get; set; }

        [StringLength(2)]
        public string Conceito_Id { get; set; }

        public virtual mtd_con_Conceitos mtd_con_Conceitos { get; set; }

        public virtual mtd_dwhTipoDimensao mtd_dwhTipoDimensao { get; set; }

        public virtual ICollection<mtd_dwh_Tabfatos> mtd_dwh_Tabfatos { get; set; }
    }
}
