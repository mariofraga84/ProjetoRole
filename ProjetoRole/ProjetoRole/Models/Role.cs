namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            Comentario = new HashSet<Comentario>();
            Foto = new HashSet<Foto>();
            Participamente = new HashSet<Participamente>();
        }

        [Key]
        public int pkRole { get; set; }

        public int fkUsuario { get; set; }

        public int fkTipoRole { get; set; }

        public DateTime dataHoraCadastro { get; set; }

        [Required]
        [StringLength(100)]
        public string titulo { get; set; }

        [Required]
        [StringLength(250)]
        public string descricaoRole { get; set; }

        [StringLength(50)]
        public string capa { get; set; }

        public int? totalKM { get; set; }

        [Required]
        [StringLength(150)]
        public string localPartida { get; set; }

        [StringLength(150)]
        public string localDestino { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dataRole { get; set; }

        public TimeSpan horaRole { get; set; }

        public virtual CAUsuario CAUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto> Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participamente> Participamente { get; set; }

        public virtual TipoRole TipoRole { get; set; }


        [Display(Name = "Localidade")]
        public int? fkLocalidade { get; set; }

        public virtual Localidade Localidade { get; set; }

        public bool? ativo { get; set; }

    }
}
