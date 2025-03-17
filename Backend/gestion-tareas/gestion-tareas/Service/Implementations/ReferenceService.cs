using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;
using gestion_tareas.Repository.Interfaces;
using gestion_tareas.Service.Interfaces;

namespace gestion_tareas.Service.Implementations
{
    public class ReferenceService : IReferenceService
    {
        private readonly IReferenceRepository _referenceRepository;

        public ReferenceService(IReferenceRepository referenceRepository)
        {
            _referenceRepository = referenceRepository;
        }
    
     public async Task<ApiResponse<List<Prioridad>>> GetAllPrioridadAsync()
        {
            try
            {
                List<Prioridad> prioridades = await _referenceRepository.GetAllActivePrioridadesAsync();

                if (prioridades != null && prioridades.Count > 0)
                {
                    return ResponseApiBuilderService.SuccessResponse(prioridades, "PRIORIDAD");
                }
                else
                {
                    return ResponseApiBuilderService.ErrorResponse<List<Prioridad>>(
                        404,
                        "NO_CONTENT",
                        "No hay registros disponibles"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return ResponseApiBuilderService.ErrorResponse<List<Prioridad>>(
                    201,
                    "SERVER_ERROR",
                    "ERROR EN EL SERVIDOR"
                );
            }
        }

        public async Task<ApiResponse<List<Estado>>> GetAllEstadoAsync()
        {
            try
            {
                List<Estado> estados = await _referenceRepository.GetAllActiveEstadosAsync();

                if (estados != null && estados.Count > 0)
                {
                    return ResponseApiBuilderService.SuccessResponse(estados, "ESTADO");
                }
                else
                {
                    return ResponseApiBuilderService.ErrorResponse<List<Estado>>(
                        201,
                        "NO_CONTENT",
                        "No hay registros disponibles"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return ResponseApiBuilderService.ErrorResponse<List<Estado>>(
                    500,
                    "SERVER_ERROR",
                    "ERROR EN EL SERVIDOR"
                );
            }
        }
    }
}
