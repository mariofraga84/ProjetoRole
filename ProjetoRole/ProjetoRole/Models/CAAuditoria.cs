namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAAuditoria")]
    public partial class CAAuditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pkAuditoria { get; set; }

        public int fkUsuario { get; set; }

        public DateTime dataHora { get; set; }

        public int? fkAction { get; set; }

        [StringLength(150)]
        public string url { get; set; }

        public virtual CAAction CAAction { get; set; }

        public virtual CAUsuario CAUsuario { get; set; }
    }
}
