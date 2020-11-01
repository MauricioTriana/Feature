using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bussiness.EntityFrameProyecto
{
    public partial class ProyectosContext : DbContext
    {
        public ProyectosContext()
        {
        }

        public ProyectosContext(DbContextOptions<ProyectosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asociacion> Asociacion { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PersonaProyecto> PersonaProyecto { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BOG-4FPBVT2\\SQLEXPRESS;initial catalog=Proyectos;persist security info=False;user id=proyecto;password=Racso8840$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Asociacion>(entity =>
            {
                entity.HasKey(e => e.IdAsociacion);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(150);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasColumnName("nit")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => new { e.IdPersona, e.IdAsociacion });

                entity.HasIndex(e => e.IdPersona)
                    .HasName("UQ__Empleado__2EC8D2ADAA792720")
                    .IsUnique();

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumeroHorasAportadaa).HasColumnName("numeroHorasAportadaa");

                entity.Property(e => e.Profesion)
                    .HasColumnName("profesion")
                    .HasMaxLength(200);

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdAsociacionNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdAsociacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Asociacion");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithOne(p => p.Empleado)
                    .HasForeignKey<Empleado>(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(150);

                entity.Property(e => e.TelContacto).HasColumnName("telContacto");
            });

            modelBuilder.Entity<PersonaProyecto>(entity =>
            {
                entity.HasKey(e => e.IdPerPro);

                entity.Property(e => e.ValorAporta).HasColumnName("valorAporta");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonaProyecto)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaProyecto_Persona");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.PersonaProyecto)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaProyecto_Proyecto");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(150);

                entity.Property(e => e.Objetivo)
                    .IsRequired()
                    .HasColumnName("objetivo")
                    .HasMaxLength(500);

                entity.Property(e => e.PaisDesarrollo)
                    .IsRequired()
                    .HasColumnName("paisDesarrollo")
                    .HasMaxLength(80);

                entity.HasOne(d => d.IdAsociacionNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdAsociacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proyecto_Asociacion");

                entity.HasOne(d => d.IdProyectoPadreNavigation)
                    .WithMany(p => p.InverseIdProyectoPadreNavigation)
                    .HasForeignKey(d => d.IdProyectoPadre)
                    .HasConstraintName("FK_Proyecto_Proyecto");
            });
        }
    }
}
