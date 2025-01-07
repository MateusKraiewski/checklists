using Microsoft.EntityFrameworkCore;
using TransporteChecklistAPI.Application.Interfaces;
using TransporteChecklistAPI.Domain.Entities;
using TransporteChecklistAPI.Infra.Data;

namespace TransporteChecklist.Infra.Repositories;

public class ChecklistRepository : IChecklistRepository
{
    private readonly ChecklistDbContext _context;

    public ChecklistRepository(ChecklistDbContext context)
    {
        _context = context;
    }

    public async Task<ChecklistEntity?> ObterChecklistEmAndamentoAsync()
    {
        return await _context.Checklists
            .Include(c => c.Itens)
            .FirstOrDefaultAsync(c => c.Status == "Em Andamento");
    }

    public async Task AdicionarChecklistAsync(ChecklistEntity checklist)
    {
        _context.Checklists.Add(checklist);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarChecklistAsync(ChecklistEntity checklist)
    {
        _context.Checklists.Update(checklist);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ChecklistEntity>> ListarTodosAsync()
    {
        return await _context.Checklists
            .Include(c => c.Itens)
            .ToListAsync();
    }

    public async Task<ChecklistEntity?> ObterPorIdAsync(int checklistId)
    {
        return await _context.Checklists
            .Include(c => c.Itens)
            .FirstOrDefaultAsync(c => c.Id == checklistId);
    }
}
