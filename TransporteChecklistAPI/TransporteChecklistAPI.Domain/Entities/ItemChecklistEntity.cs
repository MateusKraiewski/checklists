using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteChecklistAPI.Domain.Enum;

namespace TransporteChecklistAPI.Domain.Entities;

public class ItemChecklistEntity
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public int ChecklistId { get; set; }
    public ChecklistEntity Checklist { get; set; } = null!;
    public StatusChecklistEnum Status { get; set; } = StatusChecklistEnum.Pendente;
}

