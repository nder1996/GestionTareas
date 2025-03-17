using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;

namespace gestion_tareas.Service.Interfaces
{
    public interface IReferenceService
    {
        Task<ApiResponse<List<Prioridad>>> GetAllPrioridadAsync();
        Task<ApiResponse<List<Estado>>> GetAllEstadoAsync();
    }
}
