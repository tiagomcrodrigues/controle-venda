using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Pedidos;
using ControleVenda.CrossCutting.Common.Abstractions;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Pedidos
{
    public class PedidoAddUseCase : UseCaseBase<IPedidoService>, IPedidoAddUseCase
    {

        private readonly IUnitOfWork _uow;

        public PedidoAddUseCase(IPedidoService pedidoService, IUnitOfWork uow) : base(pedidoService)
        {
            _uow = uow;
        }

        public IResult<int> Execute(PedidoDto dto)
        {
            try
            {
                _uow.BeginTransaction();
                var resp = _service.Add(dto.Map());
                if (resp.Success)
                    _uow.Commit();
                else
                    _uow.RollBack();
                return resp;
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return new Result<int>(ex);
            }
        }

    }
}
