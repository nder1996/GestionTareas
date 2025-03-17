using gestion_tareas.DBContext;
using gestion_tareas.Models;
using gestion_tareas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gestion_tareas.Repository.Implementations
{
    public class ReferenceRepository : IReferenceRepository

    {

        private readonly TareasDbContext _context;

        public ReferenceRepository(TareasDbContext context)
        {
            _context = context;
        }


        public async Task<List<Estado>> GetAllActiveEstadosAsync()
        {
            return await _context.Estado
                .Where(e => e.estado == "A")
                .ToListAsync();
        }

        public async  Task<List<Prioridad>> GetAllActivePrioridadesAsync()
        {
            return await _context.Prioridad
               .Where(e => e.estado == "A")
               .ToListAsync();
        }
    }
}
