using gestion_tareas.DTOs.Request;
using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;
using gestion_tareas.Repository.Implementations;
using gestion_tareas.Repository.Interfaces;
using gestion_tareas.Service.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gestion_tareas.Service.Implementations
{
    public class TareaService : ITareaService
    {

        private readonly ITareaRepository _tareaRepository;

        private readonly ValidationService _validationService;



        public TareaService(ITareaRepository tareaRepository, ValidationService validationService)
        {
            this._tareaRepository = tareaRepository;
            this._validationService = validationService;
        }

        public ApiResponse<string> inactivateById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ResponseApiBuilderService.ErrorResponse<string>(
                        400,
                        "ID NO VÁLIDO",
                        "ERROR"
                    );
                }

                int result = _tareaRepository.InactivarTask(id);

                if (result < 1)
                {
                    return ResponseApiBuilderService.ErrorResponse<string>(
                        500,
                        "NO_CONTENT",
                        "No hay registros disponibles"
                    );
                }
                else
                {
                    return ResponseApiBuilderService.SuccessResponse<string>(
                        "Tarea inactivada correctamente",
                        "SUCCESS"
                    );
                }
            }
            catch (Exception ex)
            {
                return ResponseApiBuilderService.ErrorResponse<string>(
                    500,
                    "ERROR_INTERNO",
                    $"Ocurrió un error: {ex.Message}"
                );
            }
        }




        public ApiResponse<string> saveUpdateTask(TareaRequest tareaRequest)
        {
            try
            {
                var errores = _validationService.ValidateModel(tareaRequest);
                if (errores.Any())
                {
                    return ResponseApiBuilderService.ErrorResponse<string>(
                        400,
                        "VALIDATION_ERROR",
                        string.Join(", ", errores)
                    );
                }

                var tareaModel = new Tarea()
                {
                    Id = tareaRequest.Id,
                    titulo = tareaRequest.titulo,
                    descripcion = tareaRequest.descripcion,
                    fechaVencimiento = tareaRequest.fechaVencimiento,
                    idEstado = tareaRequest.idEstado,
                    idPrioridad = tareaRequest.idPrioridad,
                    create_at = tareaRequest.create_at,
                    update_at = tareaRequest.update_at,
                    estado = "A"
                };

                if (tareaRequest.Id == null)
                {
                    int idTarea = _tareaRepository.InsertTask(tareaModel);
                    return ResponseApiBuilderService.SuccessResponse<string>(
                        "Tarea creada correctamente con ID: " + idTarea,
                        "TAREA_CREADA"
                    );
                }
                else
                {
                    int idTarea = _tareaRepository.UpdateTask(tareaModel);
                    return ResponseApiBuilderService.SuccessResponse<string>(
                        "Tarea actualizada correctamente con ID: " + idTarea,
                        "TAREA_ACTUALIZADA"
                    );
                }
            }
            catch (Exception ex)
            {
                return ResponseApiBuilderService.ErrorResponse<string>(
                    500,
                    "ERROR_INTERNO",
                    $"Ocurrió un error: {ex.Message}"
                );
            }
        }

        public ApiResponse<List<GestionTareasResponse>> getAllGestionTareas()
        {
            try
            {
                List<GestionTareasResponse> gestion = _tareaRepository.getAllTareas();

                if (gestion != null && gestion.Count > 0)
                {
                    return ResponseApiBuilderService.SuccessResponse(gestion, "SUCCESS");
                }
                else
                {
                    return ResponseApiBuilderService.ErrorResponse<List<GestionTareasResponse>>(
                        204,
                        "NO_CONTENT",
                        "No hay registros disponibles"
                    );
                }
            }
            catch (Exception ex)
            {
                return ResponseApiBuilderService.ErrorResponse<List<GestionTareasResponse>>(
                    500,
                    "ERROR_INTERNO",
                    $"Ocurrió un error: {ex.Message}"
                );
            }
        }

        public ApiResponse<List<GestionTareasResponse>> getAllHistorico()
        {
            try
            {
                List<GestionTareasResponse> gestion = _tareaRepository.getAllHistorico();

                if (gestion != null && gestion.Count > 0)
                {
                    return ResponseApiBuilderService.SuccessResponse(gestion, "SUCCESS");
                }
                else
                {
                    return ResponseApiBuilderService.ErrorResponse<List<GestionTareasResponse>>(
                        204,
                        "NO_CONTENT",
                        "No hay registros disponibles"
                    );
                }
            }
            catch (Exception ex)
            {
                return ResponseApiBuilderService.ErrorResponse<List<GestionTareasResponse>>(
                    500,
                    "ERROR_INTERNO",
                    $"Ocurrió un error: {ex.Message}"
                );
            }
        }


        public ApiResponse<string> activateTaskById(TareaRequest tareaRequest)
        {
            try
            {
                if (tareaRequest != null)
                {
                    return ResponseApiBuilderService.ErrorResponse<string>(
                        400,
                        "ID NO VÁLIDO",
                        "ERROR"
                    );
                }

                int result = _tareaRepository.ActivarTask(tareaRequest);

                if (result < 1)
                {
                    return ResponseApiBuilderService.ErrorResponse<string>(
                        500,
                        "NO_CONTENT",
                        "No hay registros disponibles"
                    );
                }

                return ResponseApiBuilderService.SuccessResponse<string>(
                    "Tarea activada correctamente",
                    "SUCCESS"
                );
            }
            catch (Exception ex)
            {
                return ResponseApiBuilderService.ErrorResponse<string>(
                    500,
                    "ERROR_INTERNO",
                    $"Ocurrió un error: {ex.Message}"
                );
            }
        }

    }
}
