using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model.Entities;


namespace Api.Data
{
    public class ParcialDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=parcial.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .ToTable("Usuario")
            .Property(p => p.Clave).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Usuario>()
            .Property(p => p.User).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Usuario>()
            .Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Tarea>()
            .ToTable("Tarea")
            .Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tarea>()
           .Property(p => p.Titulo).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Tarea>()
           .Property(p => p.Vencimiento);
            modelBuilder.Entity<Tarea>()
           .Property(p => p.Estimacion);
            modelBuilder.Entity<Tarea>()
           .Property(p => p.Estado).HasDefaultValue(false);


            modelBuilder.Entity<Recurso>()
            .ToTable("Recurso")
            .Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Recurso>()
           .Property(p => p.Nombre).HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Detalle>()
            .ToTable("Detalle")
            .Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Detalle>()
            .Property(p => p.Fecha).HasDefaultValue(DateTime.UtcNow).IsRequired();
            modelBuilder.Entity<Detalle>()
            .Property(p => p.Tiempo).HasMaxLength(30).IsRequired();

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Recurso> Recursos { get; set; }

    }
}
