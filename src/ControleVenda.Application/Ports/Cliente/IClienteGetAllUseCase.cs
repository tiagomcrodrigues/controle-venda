using ControleVenda.Application.Dto;

namespace ControleVenda.Application.Ports.Clientes
{
    public interface IClienteGetAllUseCase
    {
        IEnumerable<ClienteDto?> Execute();
    }
}