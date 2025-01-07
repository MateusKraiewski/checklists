using Microsoft.AspNetCore.Mvc;
using TransporteChecklistAPI.Application.Commands;
using TransporteChecklistAPI.Application.Interfaces;

namespace TransporteChecklist.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistsController : ControllerBase
    {
        private readonly IChecklistService _checklistService;

        public ChecklistsController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        /// <summary>
        /// Listar todos os checklists
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ListarChecklists()
        {
            var result = await _checklistService.ListarChecklistsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Obter um checklist específico
        /// </summary>
        [HttpGet("{checklistId}")]
        public async Task<IActionResult> ObterChecklist(int checklistId)
        {
            var result = await _checklistService.ObterChecklistAsync(checklistId);
            if (result == null)
                return NotFound("Checklist não encontrado.");

            return Ok(result);
        }

        [HttpPost("iniciar")]
        public async Task<IActionResult> IniciarChecklist([FromBody] IniciarChecklistCommand command)
        {
            var result = await _checklistService.IniciarChecklistAsync(command);
            if (!result.Sucesso)
                return Conflict(result.Mensagem);

            return Ok(result.Data);
        }

        [HttpPost("finalizar/{checklistId}")]
        public async Task<IActionResult> FinalizarChecklist(int checklistId)
        {
            var result = await _checklistService.FinalizarChecklistAsync(checklistId);
            if (!result.Sucesso)
                return NotFound(result.Mensagem);

            return Ok(result.Mensagem);
        }

        [HttpPost("aprovar/{checklistId}")]
        public async Task<IActionResult> AprovarChecklist(int checklistId, [FromQuery] bool aprovado)
        {
            var result = await _checklistService.AprovarChecklistAsync(checklistId, aprovado);
            if (!result.Sucesso)
                return NotFound(result.Mensagem);

            return Ok(result.Mensagem);
        }
    }
}
