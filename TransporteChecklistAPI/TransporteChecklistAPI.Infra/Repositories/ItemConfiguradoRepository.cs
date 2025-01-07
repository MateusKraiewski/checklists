using Microsoft.EntityFrameworkCore;
using TransporteChecklistAPI.Application.Interfaces;
using TransporteChecklistAPI.Domain.Entities;
using TransporteChecklistAPI.Infra.Data;

namespace TransporteChecklist.Infra.Repositories;

public class ItemConfiguradoRepository : IItemConfiguradoRepository
{
    private readonly ChecklistDbContext _context;

    public ItemConfiguradoRepository(ChecklistDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemConfiguradoEntity>> ListarTodosAsync()
    {
        return await _context.ItensConfigurados.ToListAsync();
    }

    public async Task<ItemConfiguradoEntity?> ObterPorIdAsync(int id)
    {
        return await _context.ItensConfigurados.FindAsync(id);
    }

    public async Task AdicionarAsync(ItemConfiguradoEntity item)
    {
        _context.ItensConfigurados.Add(item);
        await _context.SaveChangesAsync();
    }
}
