using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Clientes;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Clientes
{
    public class ClienteGetAllUseCase : UseCaseBase<IClienteService>, IClienteGetAllUseCase
    {
        public ClienteGetAllUseCase(IClienteService service) : base(service) { }

        public IEnumerable<ClienteDto?> Execute()
            => _service.GetAll().Select(s => s.Map());


    }
}
