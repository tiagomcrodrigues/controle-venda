using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;

namespace ControleVenda.Domain.Ports
{
    internal interface IProdutoService
    {
        IResult<int> Add(Produto produto);
        void Delete(int id);
        IEnumerable<Produto> GetAll();
        Produto? GetById(int id);
        IResult<bool> Update(Produto produto);
    }
}
