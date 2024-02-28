using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Clientes;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.UseCases.Clientes
{
    public class ClienteUpdateUseCase : UseCaseBase<IClienteService>, IClienteUpdateUseCase
    {
        public ClienteUpdateUseCase(IClienteService service) : base(service)
        {
        }

        public IResult<bool> Execute(ClienteDto dto)
            =>_service.Update(dto.Map());



    }
}
