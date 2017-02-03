namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comentario")]
    public partial class Comentario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comentario()
        {
            Comentario11 = new HashSet<Comentario>();
        }

        [Key]
        public int pkCometario { get; set; }

        [StringLength(100)]
        public string tituloComentario { get; set; }

        [Column("comentario")]
        [StringLength(250)]
        public string comentario1 { get; set; }

        public bool? ativo { get; set; }

        public int? fkUsuario { get; set; }

        public int? fkRole { get; set; }

        public int? fkComentario { get; set; }

        public DateTime? dataHora { get; set; }

        public virtual CAUsuario CAUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario11 { get; set; }

        public virtual Comentario Comentario2 { get; set; }

        public virtual Role Role { get; set; }
    }
}