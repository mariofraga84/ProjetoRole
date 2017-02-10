namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetorole.Localidade")]
    public partial class Localidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Localidade()
        {
            CAUsuario = new HashSet<CAUsuario>();
            Role = new HashSet<Role>();
        }

        [Key]
        public int pkLocalidade { get; set; }

        [Required]
        [StringLength(100)]
        public string cidade { get; set; }

        [StringLength(60)]
        public string uf { get; set; }

        [StringLength(40)]
        public string pais { get; set; }

        public long? idFBLocalidade { get; set; }

        [StringLength(200)]
        public string nomeCompletoLocal { get; set; }

        public DbGeography coordenadas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAUsuario> CAUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Role { get; set; }
    }
}
