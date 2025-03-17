using gestion_tareas.Models;

namespace gestion_tareas.Repository.Interfaces
{
    public interface IReferenceRepository
    {
        Task<List<Prioridad>> GetAllActivePrioridadesAsync();
        Task<List<Estado>> GetAllActiveEstadosAsync();
    }
}
