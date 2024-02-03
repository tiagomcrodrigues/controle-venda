using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly DbVenda _dbVenda;

        public CategoriaRepository(DbVenda dbVenda)
        {
            _dbVenda = dbVenda;
        }

        public int Add(Categoria entidade)
        {
            _dbVenda.Categorias.Add(entidade.Map());
            _dbVenda.SaveChanges();
            return entidade.Id;
        }

        public void Delete(int id)
        {
            Tables.Categoria? categoria = _dbVenda.Categorias.Find(id);
            if (categoria != null)
                _dbVenda.Categorias.Remove(categoria);
        }

        public IEnumerable<Categoria> GetAll()
            => _dbVenda
            .Categorias
            .ToList()
            .Select(c => c.Map());


        public Categoria? GetById(int id)
        {
            Tables.Categoria? categoria = _dbVenda.Categorias.Find(id);
            if (categoria == null)
                return null;
            return categoria.Map();
        }

        public void Update(Categoria entidade)
        {
            Tables.Categoria? tabela = _dbVenda.Categorias.Find(entidade.Id);
            if(tabela != null)
            {
                tabela.Map(entidade);
                _dbVenda.SaveChanges();
            }    
        }
    }
}
