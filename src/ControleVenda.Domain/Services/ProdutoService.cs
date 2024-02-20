using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using Flunt.Notifications;

namespace ControleVenda.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        private Result<TResult> NotificationOrThrowException<TResult>(Exception ex, Produto produto)
        {

            if (ex.GetBaseException().Message.Contains($"UK_{nameof(Produto)}"))
                return new Result<TResult>(new Notification(nameof(Produto), "Produto já cadastrado"));
            if (ex.GetBaseException().Message.Contains($"FK_{nameof(Produto)}_{nameof(Categoria)}_{nameof(Categoria)}{nameof(Categoria.Id)}"))
                return new Result<TResult>(new Notification(nameof(Produto), $"Categoria informada (ID: {produto.Categoria?.Id}) não encontrada"));
            throw ex;
        }

        public IResult<int> Add(Produto produto)
        {
            produto.Validate();
            if (!produto.IsValid)
                return new Result<int>(produto.Notifications);

            try
            {
                var id = _produtoRepository.Add(produto);
                return new Result<int>(id);
            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<int>(ex, produto);
            }
        }


        public IEnumerable<Produto> GetAll()
            => _produtoRepository.GetAll();

        public Produto? GetById(int id)
            => _produtoRepository.GetById(id); 


        public IResult<bool> Update(Produto produto)
        {
            produto.Validate();


            if (produto.Id <= 0)
                produto.AddNotification(nameof(produto.Id), "Id informado é invalido");
            
            if (!produto.IsValid)
                return new Result<bool>(produto.Notifications);

            try
            {
                _produtoRepository.Update(produto);
                return new Result<bool>(true);

            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<bool>(ex, produto);

                // ---------------------------------------------------------------------------------------------------------------------------------------------
                // Deixei aqui porque o TMCR pediu desesperadamente
                // ---------------------------------------------------------------------------------------------------------------------------------------------
                //if (ex.GetBaseException().Message.Contains($"UK_{nameof(Produto)}"))
                //    return new Result<bool>(new Notification(nameof(Produto), "Produto já cadastrado"));
                //if (ex.GetBaseException().Message.Contains($"FK_{nameof(Produto)}_{nameof(Categoria)}_{nameof(Categoria)}{nameof(Categoria.Id)}"))
                //    return new Result<bool>(new Notification(nameof(Produto), $"Categoria informada (ID: {produto.Categoria?.Id}) não encontrada"));
                //throw;
                // ---------------------------------------------------------------------------------------------------------------------------------------------
            }

        }
        public void Delete(int id)
            => _produtoRepository.Delete(id);
    }
}
