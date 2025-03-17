using gestion_tareas.DTOs.Request;
using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;

namespace gestion_tareas.Repository.Interfaces
{
    public interface ITareaRepository
    {
        Task<List<GestionTareasResponse>> GestionTareasAsync();
        Task<List<TareaXAuditoria>> GestionHistoricoTareasAsync();
        Task<List<Tarea>> FindAllAsync();
        Task<Tarea> FindByIdAsync(int id);
        Task<int> InsertAsync(TareaRequest tareaRequest);
        Task<int> UpdateAsync(TareaRequest tareaRequest);
        Task<int> InactivateByIdAsync(int id);
        Task<int> ActivarByIdAsync(int id, int idEstado);
    }
}
