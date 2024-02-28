using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Clientes;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Clientes
{
    public class ClienteAddUseCase  : UseCaseBase<IClienteService>, IClienteAddUseCase
    {

        public ClienteAddUseCase(IClienteService ClienteService) : base(ClienteService) { }
        
        public IResult<int> Execute(ClienteDto dto)
            => _service.Add(dto.Map());

    }
}
