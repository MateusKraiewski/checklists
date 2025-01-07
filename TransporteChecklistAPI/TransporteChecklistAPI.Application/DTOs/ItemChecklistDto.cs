using TransporteChecklistAPI.Domain.Enum;

namespace TransporteChecklistAPI.Application.DTOs;
public class ItemChecklistDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public StatusChecklistEnum Status { get; set; } 
}
