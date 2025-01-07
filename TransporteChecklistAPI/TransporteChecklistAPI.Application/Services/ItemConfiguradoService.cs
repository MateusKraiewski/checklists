using TransporteChecklistAPI.Application.Commands;
using TransporteChecklistAPI.Application.Common;
using TransporteChecklistAPI.Application.DTOs;
using TransporteChecklistAPI.Application.Interfaces;
using TransporteChecklistAPI.Domain.Entities;

public class ItemConfiguradoService : IItemConfiguradoService
{
    private readonly IItemConfiguradoRepository _itemRepository;

    public ItemConfiguradoService(IItemConfiguradoRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    //public async Task<IEnumerable<ItemConfiguradoEntity>> ListarItensAsync()
    //{
    //    return await _itemRepository.ListarTodosAsync();
    //}
    public async Task<IEnumerable<ItemConfiguradoDto>> ListarItensAsync()
    {
        var itens = await _itemRepository.ListarTodosAsync();
        return itens.Select(i => new ItemConfiguradoDto
        {
            Id = i.Id,
            Nome = i.Nome,
            Descricao = i.Descricao
        });
    }

    public async Task<ItemConfiguradoEntity?> ObterItemPorIdAsync(int id)
    {
        return await _itemRepository.ObterPorIdAsync(id);
    }

   

    public async Task<Resultado> AdicionarItemAsync(AtualizarItemConfiguradoCommand item)
    {

        var itemConfig = new ItemConfiguradoEntity
        {
            Descricao = item.Descricao,
            Nome = item.Nome,
        };

        await _itemRepository.AdicionarAsync(itemConfig);

        return Resultado.Ok("Checklist iniciado com sucesso", itemConfig);
    }   
}