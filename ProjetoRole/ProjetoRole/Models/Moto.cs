namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Moto")]
    public partial class Moto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Moto()
        {
            Participamente = new HashSet<Participamente>();
        }

        [Key]
        public int pkMoto { get; set; }

        [StringLength(80)]
        public string nomeMoto { get; set; }

        [StringLength(50)]
        public string modeloMoto { get; set; }

        public int? fkMarca { get; set; }

        public int? fkUsuario { get; set; }

        [StringLength(150)]
        public string foto { get; set; }

        public bool? ativa { get; set; }

        public virtual CAUsuario CAUsuario { get; set; }

        public virtual Marca Marca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participamente> Participamente { get; set; }
    }
}
