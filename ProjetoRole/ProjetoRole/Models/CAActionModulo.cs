namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAActionModulo")]
    public partial class CAActionModulo
    {
        [Key]
        public int pkModuloAction { get; set; }

        public int fkModulo { get; set; }

        public int fkAction { get; set; }

        public virtual CAAction CAAction { get; set; }

        public virtual CAModulo CAModulo { get; set; }
    }
}
