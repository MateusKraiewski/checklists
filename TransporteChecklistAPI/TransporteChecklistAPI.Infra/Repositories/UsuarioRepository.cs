using Microsoft.EntityFrameworkCore;
using TransporteChecklistAPI.Application.Interfaces;
using TransporteChecklistAPI.Domain.Entities;
using TransporteChecklistAPI.Infra.Data;

namespace TransporteChecklist.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ChecklistDbContext _context;

    public UsuarioRepository(ChecklistDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UsuarioEntity>> ListarTodosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<UsuarioEntity?> ObterPorIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task AdicionarAsync(UsuarioEntity usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }
}
