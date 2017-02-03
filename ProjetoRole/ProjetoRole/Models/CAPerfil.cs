namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAPerfil")]
    public partial class CAPerfil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAPerfil()
        {
            CAModuloPerfil = new HashSet<CAModuloPerfil>();
            CAUsuario = new HashSet<CAUsuario>();
        }

        [Key]
        public int pkPerfil { get; set; }

        [Required]
        [StringLength(50)]
        public string nomePerfil { get; set; }

        public bool ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAModuloPerfil> CAModuloPerfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAUsuario> CAUsuario { get; set; }
    }
}
