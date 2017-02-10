namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetorole.Foto")]
    public partial class Foto
    {
        [Key]
        public int pkFoto { get; set; }

        [StringLength(100)]
        public string tituloFoto { get; set; }

        [Column("foto")]
        [StringLength(50)]
        public string foto1 { get; set; }

        public bool? ativo { get; set; }

        public int? fkUsuario { get; set; }

        public int? fkRole { get; set; }

        public DateTime? dataHora { get; set; }

        public virtual CAUsuario CAUsuario { get; set; }

        public virtual Role Role { get; set; }
    }
}
