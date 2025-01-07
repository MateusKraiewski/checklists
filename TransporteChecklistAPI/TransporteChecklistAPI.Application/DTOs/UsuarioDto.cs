namespace TransporteChecklistAPI.Application.DTOs;

public class UsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = "Executor";  // "Executor" ou "Supervisor"
}