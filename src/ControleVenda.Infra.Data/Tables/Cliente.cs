using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data.Tables
{
    public class Cliente : IKeyIdentitication
    {
        public int Id { get; private set; }
        public string? Nome { get; set; }
        public string? TipoPessoa { get; set; }
        public string? Documento { get; set; }
        public string? TipoLogradouro { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public ICollection<Pedido> Pedidos {  get; set; } 
    }
}
