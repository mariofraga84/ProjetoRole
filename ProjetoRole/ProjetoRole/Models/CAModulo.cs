namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetorole.CAModulo")]
    public partial class CAModulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAModulo()
        {
            CAActionModulo = new HashSet<CAActionModulo>();
            CAModuloPerfil = new HashSet<CAModuloPerfil>();
        }

        [Key]
        public int pkModulo { get; set; }

        [Required]
        [StringLength(50)]
        public string nomeModulo { get; set; }

        public bool ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAActionModulo> CAActionModulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAModuloPerfil> CAModuloPerfil { get; set; }
    }
}
