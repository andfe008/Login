using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiUsuario.Models
{
    public partial class CARVAJALContext : DbContext
    {

        public static CARVAJALContext Login { get; } = new CARVAJALContext();
        public static CARVAJALContext winer { get; } = new CARVAJALContext();
        public static CARVAJALContext TipoDocumento { get; } = new CARVAJALContext();

        public CARVAJALContext()
        {
        }

        public CARVAJALContext(DbContextOptions<CARVAJALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<Triqui> Triquis { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PJ8H6RC; Database=CARVAJAL; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("Tipo_Documento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Triqui>(entity =>
            {
                entity.ToTable("Triqui");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.winer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Ganador_Nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_TipoDocumento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK_Usuario_Tipo_Documento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
