namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetorole.CAInstancia")]
    public partial class CAInstancia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAInstancia()
        {
            CAUsuario = new HashSet<CAUsuario>();
        }

        [Key]
        public int pkInstancia { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [StringLength(150)]
        public string descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAUsuario> CAUsuario { get; set; }
    }
}
