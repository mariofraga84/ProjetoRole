namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Participamente")]
    public partial class Participamente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pkParticipamento { get; set; }

        public int? fkUsuario { get; set; }

        public int? fkMoto { get; set; }

        public int? fkRole { get; set; }

        public bool? participou { get; set; }

        public virtual CAUsuario CAUsuario { get; set; }

        public virtual Moto Moto { get; set; }

        public virtual Role Role { get; set; }
    }
}