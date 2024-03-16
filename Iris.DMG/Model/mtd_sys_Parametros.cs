namespace Iris.DMG.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_sys_Parametros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Linha_Unica { get; set; }

        [StringLength(2000)]
        public string QVS_Path { get; set; }
    }
}
