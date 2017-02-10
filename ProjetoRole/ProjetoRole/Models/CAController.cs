namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetorole.CAController")]
    public partial class CAController
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAController()
        {
            CAAction = new HashSet<CAAction>();
        }

        [Key]
        public int pkController { get; set; }

        [Required]
        [StringLength(50)]
        public string nomeController { get; set; }

        [StringLength(250)]
        public string descricaoController { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAAction> CAAction { get; set; }
    }
}
