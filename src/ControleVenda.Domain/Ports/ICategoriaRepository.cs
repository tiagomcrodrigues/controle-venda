using ControleVenda.Domain.Entities;

namespace ControleVenda.Domain.Ports
{
    public interface ICategoriaRepository
    {
        int Add(Categoria categoria);
        void Delete(int id);
        IEnumerable<Categoria> GetAll();
        Categoria GetById(int id);
        void Update(Categoria categoria);
    }
}
