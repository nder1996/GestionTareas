using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;
using gestion_tareas.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gestion_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IReferenceService _referenceService;

        public ReferenceController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        [HttpGet("prioridades")]
        public async Task<ActionResult<ApiResponse<List<Prioridad>>>> GetAllPrioridad()
        {
            ApiResponse<List<Prioridad>> response = await _referenceService.GetAllPrioridadAsync();
            return StatusCode(response.Meta.StatusCode ?? 200, response);
        }

        [HttpGet("estados")]
        public async Task<ActionResult<ApiResponse<List<Estado>>>> GetAllEstados()
        {
            ApiResponse<List<Estado>> response = await _referenceService.GetAllEstadoAsync();
            return StatusCode(response.Meta.StatusCode ?? 200, response);
        }


    }
}
