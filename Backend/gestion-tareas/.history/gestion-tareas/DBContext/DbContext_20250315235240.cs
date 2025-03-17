using gestion_tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace gestion_tareas.DBContext
{
    public class TareasDbContext : Microsoft.EntityFrameworkCore.DbContext // Cambiar nombre y heredar
    {
        public TareasDbContext(DbContextOptions<TareasDbContext> options) : base(options)
        {
        }

        // ENTIDADES DEFINIDAS
         public DbSet<Models.Auditoria> Auditoria { get; set; }
         public DbSet<Models.Estado> Estado { get; set; }
        public DbSet<Models.Prioridad> Prioridad { get; set; }
        public DbSet<Models.Tarea> Tarea { get; set; }
        public DbSet<Models.TareaXAuditoria> TareaXAuditoria { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<TareaXAuditoria>()
                .HasOne(ta => ta.Tarea)
                .WithMany()
                .HasForeignKey("TareaId");

            modelBuilder.Entity<TareaXAuditoria>()
                .HasOne(ta => ta.Auditoria)
                .WithMany()
                .HasForeignKey("AuditoriaId");

            modelBuilder.Entity<Models.Estado>().HasData(
                new Models.Estado { Id = 1, nombre = "Pendiente", estado = "A" },
                new Models.Estado { Id = 2, nombre = "En Progreso", estado = "A" },
                new Models.Estado { Id = 3, nombre = "Completada", estado = "A" }
            );

            modelBuilder.Entity<Models.Prioridad>().HasData(
                new Models.Prioridad { Id = 1, nombre = "Alta", estado = "A" },
                new Models.Prioridad { Id = 2, nombre = "Media", estado = "A" },
                new Models.Prioridad { Id = 3, nombre = "Baja", estado = "A" }
            );

            modelBuilder.Entity<Models.Auditoria>().HasData(
            new Models.Auditoria
            {
                Id = 1,
                Accion = "Crear",
                CreateAt = new DateTime(2025, 1, 15, 10, 30, 0),
                CreadoPor = "admin@sistema.com"
            },
            new Models.Auditoria
            {
                Id = 2,
                Accion = "Actualizar",
                CreateAt = new DateTime(2025, 2, 3, 14, 45, 0),
                CreadoPor = "supervisor@sistema.com"
            },
            new Models.Auditoria
            {
                Id = 3,
                Accion = "Eliminar",
                CreateAt = new DateTime(2025, 2, 20, 9, 15, 0),
                CreadoPor = "admin@sistema.com"
            }
            );

            modelBuilder.Entity<Models.Tarea>().HasData(
            new Models.Tarea
            {
                Id = 1,
                titulo = "Implementar autenticación",
                descripcion = "Desarrollar sistema de login con JWT",
                idEstado = 2,
                idPrioridad = 1,
                fechaVencimiento = new DateTime(2025, 4, 15),
                create_at = new DateTime(2025, 3, 1),
                update_at = new DateTime(2025, 3, 10)
            },
            new Models.Tarea
            {
                Id = 2,
                titulo = "Diseñar base de datos",
                descripcion = "Crear diagrama ER y scripts SQL",
                idEstado = 3,
                idPrioridad = 1,
                fechaVencimiento = new DateTime(2025, 3, 25),
                create_at = new DateTime(2025, 3, 5),
                update_at = new DateTime(2025, 3, 15)
            },
            new Models.Tarea
            {
                Id = 3,
                titulo = "Implementar API REST",
                descripcion = "Desarrollar endpoints para CRUD de tareas",
                idEstado = 1,
                idPrioridad = 2,
                fechaVencimiento = new DateTime(2025, 4, 30),
                create_at = new DateTime(2025, 3, 12),
                update_at = null
            }
        );

            modelBuilder.Entity<TareaXAuditoria>().HasData(
            new TareaXAuditoria { 
                Id = 1, 
                Auditoria = null, 
                Tarea = null,
                create_at = DateTime.Now
            }
            );


        }
    }
}
