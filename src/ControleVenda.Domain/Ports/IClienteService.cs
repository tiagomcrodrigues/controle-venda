using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Domain.Ports
{
    public interface IClienteService
    {
        IResult<int> Add(Cliente cliente);
        void Delete(int id);
        IEnumerable<Cliente> GetAll();
        Cliente? GetById(int id);
        IResult<bool> Update(Cliente cliente);
    }
}
