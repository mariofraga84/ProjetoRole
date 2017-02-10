namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetorole.Comentario")]
    public partial class Comentario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comentario()
        {
            Comentario1 = new HashSet<Comentario>();
        }

        [Key]
        public int pkCometario { get; set; }

        [StringLength(100)]
        public string tituloComentario { get; set; }

        [StringLength(250)]
        public string textoComentario { get; set; }

        public bool? ativo { get; set; }

        public int? fkUsuario { get; set; }

        public int? fkRole { get; set; }

        public int? fkComentario { get; set; }

        public DateTime? dataHora { get; set; }

        public virtual CAUsuario CAUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario1 { get; set; }

        public virtual Comentario Comentario2 { get; set; }

        public virtual Role Role { get; set; }
    }
}
