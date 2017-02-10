namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetorole.CAAction")]
    public partial class CAAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAAction()
        {
            CAActionModulo = new HashSet<CAActionModulo>();
            CAAuditoria = new HashSet<CAAuditoria>();
        }

        [Key]
        public int pkAction { get; set; }

        [Required]
        [StringLength(70)]
        public string nomeAction { get; set; }

        [Required]
        [StringLength(50)]
        public string descricaoPagina { get; set; }

        public bool mostrarMenu { get; set; }

        public bool ativo { get; set; }

        [StringLength(150)]
        public string icone { get; set; }

        public int? fkController { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAActionModulo> CAActionModulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAAuditoria> CAAuditoria { get; set; }

        public virtual CAController CAController { get; set; }
    }
}
