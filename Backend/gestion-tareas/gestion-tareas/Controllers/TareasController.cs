using gestion_tareas.DTOs.Request;
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

        [HttpGet("getAllHistorico")]
        public IActionResult getAllHistorico()
        {
            var response = _tareaService.getAllHistorico();
            return StatusCode(response.Meta?.StatusCode ?? 200, response);
        }

        [HttpGet("getAllGestionTareas")]
        public IActionResult GetGestionTareas()
        {
            var response = _tareaService.getAllGestionTareas();
            return StatusCode(response.Meta?.StatusCode ?? 200, response);
        }

        [HttpPost("insertUpdate")]
        public  IActionResult saveUpdateTask([FromBody] TareaRequest request)
        {
            ApiResponse<String> response = _tareaService.saveUpdateTask(request);
            return StatusCode(response.Meta.StatusCode ?? 200, response);
        }

        [HttpPut("inactivate/{id}")]
        public IActionResult inactivarTask(int id)
        {
            ApiResponse<String> response = _tareaService.inactivateById(id);
            return StatusCode(response.Meta.StatusCode ?? 200, response);
        }

        [HttpPut("activate/{id}")]
        public IActionResult activateTas(int id)
        {
            ApiResponse<String> response = _tareaService.activateTaskById(id);
            return StatusCode(response.Meta.StatusCode ?? 200, response);
        }



    }
}
