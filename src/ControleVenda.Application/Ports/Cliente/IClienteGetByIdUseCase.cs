using ControleVenda.Application.Dto;

namespace ControleVenda.Application.Ports.Clientes
{
    public interface IClienteGetByIdUseCase
    {
        ClienteDto? Execute(int id);
    }
}