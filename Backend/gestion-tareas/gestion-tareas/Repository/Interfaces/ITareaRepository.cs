using gestion_tareas.DTOs.Request;
using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;

namespace gestion_tareas.Repository.Interfaces
{
    public interface ITareaRepository
    {
        List<GestionTareasResponse> getAllTareas();
        public List<GestionTareasResponse> getAllHistorico();

        int InsertTask(Tarea tarea);
        int UpdateTask(Tarea tarea);
        int InactivarTask(int id);
        int ActivarTask(int idTarea);
    }
}
