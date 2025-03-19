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
         public DbSet<Models.Estado> Estado { get; set; }
        public DbSet<Models.Prioridad> Prioridad { get; set; }
        public DbSet<Models.Tarea> Tarea { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Models.Estado>().HasData(
                new Models.Estado { Id = 1, nombre = "Pendiente", severity = "warning", estado = "A" },
                new Models.Estado { Id = 2, nombre = "En Progreso", severity = "info", estado = "A" },
                new Models.Estado { Id = 3, nombre = "Completada", severity = "success", estado = "A" }
            );

            modelBuilder.Entity<Models.Prioridad>().HasData(
                new Models.Prioridad { Id = 1, nombre = "Alta", severity = "danger", estado = "A" },
                new Models.Prioridad { Id = 2, nombre = "Media", severity = "warning", estado = "A" },
                new Models.Prioridad { Id = 3, nombre = "Baja", severity = "success", estado = "A" }
            );

            modelBuilder.Entity<Models.Tarea>().HasData(
            new Models.Tarea
            {
                Id = 1,
                titulo = "Implementar autenticación",
                descripcion = "Desarrollar sistema de login con JWT",
                estado = "A",
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
                estado = "A",
                idEstado = 2,
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
                estado = "A",
                idEstado = 1,
                idPrioridad = 2,
                fechaVencimiento = new DateTime(2025, 4, 30),
                create_at = new DateTime(2025, 3, 12),
                update_at = null
            },
            new Models.Tarea
            {
                Id = 4,
                titulo = "Implementar API REST",
                descripcion = "Desarrollar endpoints para CRUD de tareas",
                estado = "A",
                idEstado = 3,
                idPrioridad = 3,
                fechaVencimiento = new DateTime(2025, 4, 30),
                create_at = new DateTime(2025, 3, 12),
                update_at = null
            },
            new Models.Tarea
            {
                Id = 5,
                titulo = "Implementar API REST",
                descripcion = "Desarrollar endpoints para CRUD de tareas",
                estado = "I",
                idEstado = 1,
                idPrioridad = 2,
                fechaVencimiento = new DateTime(2025, 4, 30),
                create_at = new DateTime(2025, 3, 12),
                update_at = null
            }

        );


        }
    }
}
