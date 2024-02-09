using ControleVenda.Domain.Entities;

namespace ControleVenda.Domain.Ports
{
    public interface IProdutoRepository
    {
        int Add(Produto produto);
        void Delete(int id);
        IEnumerable<Produto> GetAll();
        Produto? GetById(int id);
        void Update(Produto produto);

    }
}
