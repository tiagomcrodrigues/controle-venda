using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;

namespace ControleVenda.Domain.Ports
{
    public interface ICategoriaService
    {
        IResult<int> Add(Categoria categoria);
        void Delete(int id);
        IEnumerable<Categoria> GetAll();
        Categoria? GetById(int id);
        IResult<bool> Update(Categoria categoria);
    }
}