using Microsoft.AspNetCore.Mvc;
using TransporteChecklistAPI.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ItemConfiguradoController : ControllerBase
{
    private readonly IItemConfiguradoService _service;

    public ItemConfiguradoController(IItemConfiguradoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var itens = await _service.ListarItensAsync();
        return Ok(itens);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var item = await _service.ObterItemPorIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] AtualizarItemConfiguradoCommand command)
    { 
        var result = await _service.AdicionarItemAsync(command);
        if (!result.Sucesso)
            return Conflict(result.Mensagem);

        return Ok(result.Data);
    }
}
