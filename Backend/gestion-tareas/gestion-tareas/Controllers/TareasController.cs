using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;
using gestion_tareas.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gestion_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {

        private readonly ITareaService _tareaService;

        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }


        [HttpGet("getAllGestionTareas")]
        public async Task<ActionResult<ApiResponse<List<GestionTareasResponse>>>> getAllGestionTareas()
        {
            ApiResponse<List<GestionTareasResponse>> response = _tareaService.getAllGestionTareas();
            return StatusCode(response.Meta.StatusCode ?? 200, response);
        }

        [HttpGet("getAllAuditoria")]
        public async Task<ActionResult<ApiResponse<List<TareaXAuditoria>>>> gestionHistoricoTareas()
        {
            ApiResponse<List<TareaXAuditoria>> response = _tareaService.gestionHistoricoTareas();
            return StatusCode(response.Meta.StatusCode ?? 200, response);
        }




        [HttpGet]
        public ActionResult<string> Get()
        {
            return "¡Hola Mundo!";
        }
    }
}
