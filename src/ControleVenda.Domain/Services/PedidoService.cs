using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Domain.Services
{

    public class PedidoService : IPedidoService
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IResult<int> Add(Pedido pedido)
        {
            pedido.Validate();
            if (!pedido.IsValid)
                return new Result<int>(pedido.Notifications);

            var id = _pedidoRepository.Add(pedido);
            return new Result<int>(id);
        }

        public void Cancel(int id)
            => _pedidoRepository.Cancel(id);

        public IEnumerable<Pedido> GetAll()
            => _pedidoRepository.GetAll();

        public Pedido? GetById(int id)
            => _pedidoRepository.GetById(id);
    }
}
