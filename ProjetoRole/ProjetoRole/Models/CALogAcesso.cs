namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CALogAcesso")]
    public partial class CALogAcesso
    {
        [Key]
        public int pkLogAcesso { get; set; }

        public int fkUsuario { get; set; }

        public DateTime dataHora { get; set; }

        [Required]
        [StringLength(15)]
        public string ip { get; set; }

        public virtual CAUsuario CAUsuario { get; set; }
    }
}
