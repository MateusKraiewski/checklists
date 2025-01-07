using Microsoft.EntityFrameworkCore;
using TransporteChecklistAPI.Domain.Entities;

namespace TransporteChecklistAPI.Infra.Data;
public class ChecklistDbContext : DbContext
{
    public DbSet<ChecklistEntity> Checklists { get; set; } = null!;
    public DbSet<ItemChecklistEntity> ItensChecklist { get; set; } = null!;
    public DbSet<UsuarioEntity> Usuarios { get; set; } = null!;
    public DbSet<ItemConfiguradoEntity> ItensConfigurados { get; set; } = null!;
    public ChecklistDbContext(DbContextOptions<ChecklistDbContext> options) : base(options) { }
}