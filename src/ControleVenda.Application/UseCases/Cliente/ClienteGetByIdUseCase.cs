using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Clientes;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Clientes
{
    public class ClienteGetByIdUseCase : UseCaseBase<IClienteService>, IClienteGetByIdUseCase
    {
        public ClienteGetByIdUseCase(IClienteService service) : base(service)
        {
        }

        public ClienteDto? Execute(int id)
            => _service.GetById(id).Map();


    }
}
