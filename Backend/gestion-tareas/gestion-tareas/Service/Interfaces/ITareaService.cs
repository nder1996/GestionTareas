using gestion_tareas.DTOs.Request;
using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;

namespace gestion_tareas.Service.Interfaces
{
    public interface ITareaService
    {
        ApiResponse<List<GestionTareasResponse>> getAllGestionTareas();
        ApiResponse<List<TareaXAuditoria>> gestionHistoricoTareas();
        ApiResponse<List<Tarea>> findAll();
        ApiResponse<Tarea> findById(int id);
        ApiResponse<string> inactivateById(int id);
        ApiResponse<string> activeTaskById(int id);
        ApiResponse<string> saveUpdateTask(TareaRequest tareaRequest);
        void saveAuditoria(int idTarea, int idEstado, int idPrioridad, string tipoAuditoria);
    }
}
