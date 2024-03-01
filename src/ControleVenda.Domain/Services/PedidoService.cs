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
        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public IResult<int> Add(Pedido pedido)
        {

            // Valida se tem estoque suficiente, se não tiver adicionar notificações
            IList<Produto> produtos = new List<Produto>();
            foreach (var item in pedido.Itens)
            {
                var produto = _produtoRepository.GetById(item.Produto.Id);
                produtos.Add(produto);
                if (produto.Quantidade < item.Quantidade)
                {
                    pedido.AddNotification($"Produto-{produto.Id}", $"Não há estoque suficiente para o produto {produto.Id} = {produto.Nome}");
                }
                else
                {
                    produto.Quantidade -= item.Quantidade;
                    item.ValorUnitario = produto.ValorUnitario;
                }
            }

            pedido.Validate();


            //TODO: Verificar como controlar a gravação em lote (Transação)

            if (!pedido.IsValid)
                return new Result<int>(pedido.Notifications);

            //Baixar estoque dos produtos
            foreach (var item in produtos)
            {
                _produtoRepository.Update(item);
            }

            var id = _pedidoRepository.Add(pedido);
            return new Result<int>(id);
        }

        public void Cancel(Pedido pedido)
        {

            // Verificar se o pedido já não está cancelado
            if (!pedido.Cancelado)
            {

                // Devolver os produtos ao estoque
                foreach (var item in pedido.Itens)
                {
                    var produto = _produtoRepository.GetById(item.Produto.Id);
                    produto.Quantidade += item.Quantidade;
                    _produtoRepository.Update(produto);
                }

                // Cancelar o pedido
                _pedidoRepository.Cancel(pedido);

            }
        }

        public IEnumerable<Pedido> GetAll()
            => _pedidoRepository.GetAll();

        public Pedido? GetById(int id)
            => _pedidoRepository.GetById(id);
    }
}
