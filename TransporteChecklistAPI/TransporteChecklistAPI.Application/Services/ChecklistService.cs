using TransporteChecklistAPI.Application.Commands;
using TransporteChecklistAPI.Application.Common;
using TransporteChecklistAPI.Application.Interfaces;
using TransporteChecklistAPI.Domain.Entities;

public class ChecklistService : IChecklistService
{
    private readonly IChecklistRepository _checklistRepository;

    public ChecklistService(IChecklistRepository checklistRepository)
    {
        _checklistRepository = checklistRepository;
    }

    public async Task<Resultado> IniciarChecklistAsync(IniciarChecklistCommand command)
    {
        var checklistEmAndamento = await _checklistRepository.ObterChecklistEmAndamentoAsync();
        if (checklistEmAndamento != null)
        {
            return Resultado.Falha("Já existe um checklist em andamento.");
        }

        var checklist = new ChecklistEntity
        {
            DataInicio = DateTime.UtcNow,
            ExecutorId = command.ExecutorId,
            Itens = command.Itens.Select(item => new ItemChecklistEntity
            {
                Nome = item.Nome,
                Observacao = item.Observacao,
                Status = item.Status
            }).ToList()
        };

        await _checklistRepository.AdicionarChecklistAsync(checklist);

        return Resultado.Ok("Checklist iniciado com sucesso", checklist);
    }

    public async Task<Resultado> FinalizarChecklistAsync(int checklistId)
    {
        var checklist = await _checklistRepository.ObterChecklistEmAndamentoAsync();
        if (checklist == null || checklist.Id != checklistId)
        {
            return Resultado.Falha("Checklist não encontrado ou já finalizado.");
        }

        checklist.DataFim = DateTime.UtcNow;
        checklist.Status = "Finalizado";
        await _checklistRepository.AtualizarChecklistAsync(checklist);

        return Resultado.Ok("Checklist finalizado com sucesso");
    }

    public async Task<Resultado> AprovarChecklistAsync(int checklistId, bool aprovado)
    {
        var checklist = await _checklistRepository.ObterChecklistEmAndamentoAsync();
        if (checklist == null || checklist.Id != checklistId)
        {
            return Resultado.Falha("Checklist não encontrado ou já finalizado.");
        }

        checklist.Status = aprovado ? "Aprovado" : "Reprovado";
        await _checklistRepository.AtualizarChecklistAsync(checklist);

        return Resultado.Ok(aprovado ? "Checklist aprovado" : "Checklist reprovado");
    }

    public async Task<IEnumerable<ChecklistEntity>> ListarChecklistsAsync()
    {
        return await _checklistRepository.ListarTodosAsync();
    }

    public async Task<ChecklistEntity?> ObterChecklistAsync(int checklistId)
    {
        return await _checklistRepository.ObterPorIdAsync(checklistId);
    }
}
