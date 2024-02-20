using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Domain.Ports
{
    public interface IClienteRepository
    {
        int Add(Cliente cliente);
        void Delete(int id);
        IEnumerable<Cliente> GetAll();
        Cliente? GetById(int id);
        void Update(Cliente cliente);
    }
}
