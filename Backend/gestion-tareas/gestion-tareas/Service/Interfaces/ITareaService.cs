using gestion_tareas.DTOs.Request;
using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;

namespace gestion_tareas.Service.Interfaces
{
    public interface ITareaService
    {
        ApiResponse<List<GestionTareasResponse>> getAllGestionTareas();
        ApiResponse<string> inactivateById(int id);
        ApiResponse<string> activateTaskById(int idTarea);
        ApiResponse<string> saveUpdateTask(TareaRequest tareaRequest);

        ApiResponse<List<GestionTareasResponse>> getAllHistorico();

    }
}
