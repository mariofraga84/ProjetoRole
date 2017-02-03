namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAModuloPerfil")]
    public partial class CAModuloPerfil
    {
        [Key]
        public int pkModuloPerfil { get; set; }

        public int fkPerfil { get; set; }

        public int fkModulo { get; set; }

        public virtual CAModulo CAModulo { get; set; }

        public virtual CAPerfil CAPerfil { get; set; }
    }
}
