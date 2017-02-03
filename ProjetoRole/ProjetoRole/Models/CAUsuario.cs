namespace ProjetoRole.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAUsuario")]
    public partial class CAUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAUsuario()
        {
            CAAuditoria = new HashSet<CAAuditoria>();
            CALogAcesso = new HashSet<CALogAcesso>();
            Comentario = new HashSet<Comentario>();
            Foto1 = new HashSet<Foto>();
            Participamente = new HashSet<Participamente>();
            Role = new HashSet<Role>();
        }

        [Key]
        public int pkUsuario { get; set; }

        public int fkPerfil { get; set; }

        [Display(Name = "Localidade")]
        public int? fkLocalidade { get; set; }

        public int? fkInstancia { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Seu Nome")]
        public string nome { get; set; }
       

        [StringLength(100)]
        [Display(Name = "Apelido")]
        public string apelido { get; set; }
      

        [StringLength(80)]
        [Display(Name = "Email")]
        public string email { get; set; }
      

        [StringLength(250)]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular")]
        public string fone { get; set; }

        public bool ativo { get; set; }

        [StringLength(50)]
        [Display(Name = "Foto do Perfil")]
        public string foto { get; set; }

        public DbGeography coordenadas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAAuditoria> CAAuditoria { get; set; }

        public virtual CAInstancia CAInstancia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CALogAcesso> CALogAcesso { get; set; }

        public virtual CAPerfil CAPerfil { get; set; }

        public virtual Localidade Localidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto> Foto1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participamente> Participamente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Moto> Moto { get; set; }
    }
}
