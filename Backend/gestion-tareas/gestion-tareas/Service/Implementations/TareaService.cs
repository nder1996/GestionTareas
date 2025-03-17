using gestion_tareas.DTOs.Request;
using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;
using gestion_tareas.Repository.Implementations;
using gestion_tareas.Repository.Interfaces;
using gestion_tareas.Service.Interfaces;

namespace gestion_tareas.Service.Implementations
{
    public class TareaService : ITareaService
    {

        private readonly ITareaRepository _tareaRepository;
        
        public TareaService(ITareaRepository _tareaRepository)
        {
            this._tareaRepository = _tareaRepository;
        }

        public ApiResponse<string> activeTaskById(int id)
        {
            return ResponseApiBuilderService.ErrorResponse<string>(
                500,
                "NO_CONTENT",
                "No hay registros disponibles"
            );
        }

        public ApiResponse<List<Tarea>> findAll()
        {
            return ResponseApiBuilderService.ErrorResponse<List<Tarea>>(
              500,
              "NO_CONTENT",
              "No hay registros disponibles"
          );
        }

        public ApiResponse<Tarea> findById(int id)
        {
            return ResponseApiBuilderService.ErrorResponse<Tarea>(
             500,
             "NO_CONTENT",
             "No hay registros disponibles"
         );
        }

        public ApiResponse<List<TareaXAuditoria>> gestionHistoricoTareas()
        {
            List<TareaXAuditoria> gestion = _tareaRepository.GestionHistoricoTareasAsync().Result;

            if (gestion != null && gestion.Count > 0)
            {
                return ResponseApiBuilderService.SuccessResponse(gestion, "SUCCESS");
            }
            else
            {
                return ResponseApiBuilderService.ErrorResponse<List<TareaXAuditoria>>(
                    201,
                    "NO_CONTENT",
                    "No hay registros disponibles"
                );
            }
        }

    

        public ApiResponse<string> inactivateById(int id)
        {
            return ResponseApiBuilderService.ErrorResponse<string>(
             500,
             "NO_CONTENT",
             "No hay registros disponibles"
         );
        }

        public void saveAuditoria(int idTarea, int idEstado, int idPrioridad, string tipoAuditoria)
        {
            
        }

        public ApiResponse<string> saveUpdateTask(TareaRequest tareaRequest)
        {
            return ResponseApiBuilderService.ErrorResponse<string>(
              500,
              "NO_CONTENT",
              "No hay registros disponibles"
          );
        }

        public ApiResponse<List<GestionTareasResponse>> getAllGestionTareas()
        {
            List<GestionTareasResponse> gestion = _tareaRepository.GestionTareasAsync().Result;

            if (gestion != null && gestion.Count > 0)
            {
                return ResponseApiBuilderService.SuccessResponse(gestion, "SUCCESS");
            }
            else
            {
                return ResponseApiBuilderService.ErrorResponse<List<GestionTareasResponse>>(
                    201,
                    "NO_CONTENT",
                    "No hay registros disponibles"
                );
            }
        }
    }
}
