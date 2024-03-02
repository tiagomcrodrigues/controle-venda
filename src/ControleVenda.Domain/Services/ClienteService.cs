using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Domain.Services
{

    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        private Result<TResult> NotificationOrThrowException<TResult>(Exception ex, Cliente cliente)
        {

            if (ex.GetBaseException().Message.Contains($"UK_{nameof(Cliente)}"))
                return new Result<TResult>(new Notification(nameof(Cliente), "Cliente já cadastrado"));
            throw ex;
        }

        public IResult<int> Add(Cliente cliente)
        {
            cliente.Validate();
            if (!cliente.IsValid)
                return new Result<int>(cliente.Notifications);

            try
            {
                var id = _clienteRepository.Add(cliente);
                return new Result<int>(id);
            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<int>(ex, cliente);
            }
        }

        public void Delete(int id)
            => _clienteRepository.Delete(id);

        public IEnumerable<Cliente> GetAll()
            => _clienteRepository.GetAll();

        public Cliente? GetById(int id)
            => _clienteRepository.GetById(id);

        public IResult<bool> Update(Cliente cliente)
        {
            cliente.Validate();


            if (cliente.Id <= 0)
                cliente.AddNotification(nameof(cliente.Id), "Id informado é invalido");

            if (!cliente.IsValid)
                return new Result<bool>(cliente.Notifications);

            try
            {
                _clienteRepository.Update(cliente);
                return new Result<bool>(true);

            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<bool>(ex, cliente);
            }
        }
    }
}
