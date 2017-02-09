namespace ProjetoRole.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BandoDeDados : DbContext
    {
        public BandoDeDados()
            : base("name=BandoDeDados")
        {
        }

        public virtual DbSet<CAAction> CAAction { get; set; }
        public virtual DbSet<CAActionModulo> CAActionModulo { get; set; }
        public virtual DbSet<CAAuditoria> CAAuditoria { get; set; }
        public virtual DbSet<CAController> CAController { get; set; }
        public virtual DbSet<CAInstancia> CAInstancia { get; set; }
        public virtual DbSet<CALogAcesso> CALogAcesso { get; set; }
        public virtual DbSet<CAModulo> CAModulo { get; set; }
        public virtual DbSet<CAModuloPerfil> CAModuloPerfil { get; set; }
        public virtual DbSet<CAPerfil> CAPerfil { get; set; }
        public virtual DbSet<CAUsuario> CAUsuario { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<Localidade> Localidade { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Moto> Moto { get; set; }
        public virtual DbSet<Participamente> Participamente { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoRole> TipoRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAAction>()
                .Property(e => e.nomeAction)
                .IsUnicode(false);

            modelBuilder.Entity<CAAction>()
                .Property(e => e.descricaoPagina)
                .IsUnicode(false);

            modelBuilder.Entity<CAAction>()
                .HasMany(e => e.CAActionModulo)
                .WithRequired(e => e.CAAction)
                .HasForeignKey(e => e.fkAction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAAction>()
                .HasMany(e => e.CAAuditoria)
                .WithOptional(e => e.CAAction)
                .HasForeignKey(e => e.fkAction);

            modelBuilder.Entity<CAController>()
                .HasMany(e => e.CAAction)
                .WithOptional(e => e.CAController)
                .HasForeignKey(e => e.fkController);

            modelBuilder.Entity<CAInstancia>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<CAInstancia>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CAInstancia>()
                .HasMany(e => e.CAUsuario)
                .WithOptional(e => e.CAInstancia)
                .HasForeignKey(e => e.fkInstancia);

            modelBuilder.Entity<CALogAcesso>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<CAModulo>()
                .Property(e => e.nomeModulo)
                .IsUnicode(false);

            modelBuilder.Entity<CAModulo>()
                .HasMany(e => e.CAActionModulo)
                .WithRequired(e => e.CAModulo)
                .HasForeignKey(e => e.fkModulo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAModulo>()
                .HasMany(e => e.CAModuloPerfil)
                .WithRequired(e => e.CAModulo)
                .HasForeignKey(e => e.fkModulo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAPerfil>()
                .Property(e => e.nomePerfil)
                .IsUnicode(false);

            modelBuilder.Entity<CAPerfil>()
                .HasMany(e => e.CAModuloPerfil)
                .WithRequired(e => e.CAPerfil)
                .HasForeignKey(e => e.fkPerfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAPerfil>()
                .HasMany(e => e.CAUsuario)
                .WithRequired(e => e.CAPerfil)
                .HasForeignKey(e => e.fkPerfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAUsuario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<CAUsuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CAUsuario>()
                .Property(e => e.senha)
                .IsFixedLength();

            modelBuilder.Entity<CAUsuario>()
                .Property(e => e.fone)
                .IsUnicode(false);

            modelBuilder.Entity<CAUsuario>()
                .HasMany(e => e.CAAuditoria)
                .WithRequired(e => e.CAUsuario)
                .HasForeignKey(e => e.fkUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAUsuario>()
                .HasMany(e => e.CALogAcesso)
                .WithRequired(e => e.CAUsuario)
                .HasForeignKey(e => e.fkUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAUsuario>()
                .HasMany(e => e.Comentario)
                .WithOptional(e => e.CAUsuario)
                .HasForeignKey(e => e.fkUsuario);

            modelBuilder.Entity<CAUsuario>()
                .HasMany(e => e.Foto1)
                .WithOptional(e => e.CAUsuario)
                .HasForeignKey(e => e.fkUsuario);

            modelBuilder.Entity<CAUsuario>()
                .HasMany(e => e.Participamente)
                .WithOptional(e => e.CAUsuario)
                .HasForeignKey(e => e.fkUsuario);

            modelBuilder.Entity<CAUsuario>()
                .HasMany(e => e.Role)
                .WithRequired(e => e.CAUsuario)
                .HasForeignKey(e => e.fkUsuario)
                .WillCascadeOnDelete(false);

         /*   modelBuilder.Entity<Comentario>()
                .Property(e => e.textoComentario)
                .IsUnicode(false); */

            modelBuilder.Entity<Comentario>()
                .HasMany(e => e.Comentario11)
                .WithOptional(e => e.Comentario2)
                .HasForeignKey(e => e.fkComentario);

            modelBuilder.Entity<Localidade>()
                .HasMany(e => e.CAUsuario)
                .WithOptional(e => e.Localidade)
                .HasForeignKey(e => e.fkLocalidade);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Moto)
                .WithOptional(e => e.Marca)
                .HasForeignKey(e => e.fkMarca);

            modelBuilder.Entity<CAUsuario>()
               .HasMany(e => e.Moto)
               .WithOptional(e => e.CAUsuario)
               .HasForeignKey(e => e.fkUsuario);

            modelBuilder.Entity<Moto>()
                .HasMany(e => e.Participamente)
                .WithOptional(e => e.Moto)
                .HasForeignKey(e => e.fkMoto);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Comentario)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.fkRole);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Foto)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.fkRole);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Participamente)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.fkRole);

            modelBuilder.Entity<TipoRole>()
                .HasMany(e => e.Role)
                .WithRequired(e => e.TipoRole)
                .HasForeignKey(e => e.fkTipoRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Localidade>()
            .HasMany(e => e.Role)
            .WithOptional(e => e.Localidade)
            .HasForeignKey(e => e.fkLocalidade);

        }
    }
}
