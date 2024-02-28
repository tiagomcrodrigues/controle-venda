using ControleVenda.Application.Ports.Clientes;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Clientes
{
    public class ClienteDeleteUseCase : UseCaseBase<IClienteService>, IClienteDeleteUseCase
    {

        public ClienteDeleteUseCase(IClienteService ClienteService) : base(ClienteService) { }


        public void Execute(int id)
            => _service.Delete(id);

    }
}
