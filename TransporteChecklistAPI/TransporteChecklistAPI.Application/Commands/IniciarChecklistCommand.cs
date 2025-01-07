using TransporteChecklistAPI.Application.DTOs;

namespace TransporteChecklistAPI.Application.Commands
{
    public  class IniciarChecklistCommand
    {
        public int ExecutorId { get; set; }
        public List<ItemChecklistDto> Itens { get; set; } = new List<ItemChecklistDto>();
    }
}
