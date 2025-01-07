namespace TransporteChecklistAPI.Domain.Entities;
public class UsuarioEntity
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = "Executor";  // "Executor" ou "Supervisor"
}
