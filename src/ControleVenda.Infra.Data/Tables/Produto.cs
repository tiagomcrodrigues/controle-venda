using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data.Tables
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }
        public int Quntidade { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


    }
}
