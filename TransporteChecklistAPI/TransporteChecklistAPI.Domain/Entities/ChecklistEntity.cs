namespace TransporteChecklistAPI.Domain.Entities;
public class ChecklistEntity
{
    public int Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string Status { get; set; } = "Em Andamento";
    public int ExecutorId { get; set; }
    public int? SupervisorId { get; set; }
    public ICollection<ItemChecklistEntity> Itens { get; set; } = new List<ItemChecklistEntity>();
}