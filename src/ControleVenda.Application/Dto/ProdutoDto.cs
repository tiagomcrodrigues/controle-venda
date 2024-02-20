using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.Dto
{
    public class ProdutoDto
    {

        public ProdutoDto() { }

        public ProdutoDto(int id) 
        {
            Id = id;
        }

        public int? Id { get;  set; }
        public string? Nome { get; set; }
        public double ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public CategoriaDto? Categoria { get; set; }

    }
}
