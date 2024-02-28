using ControleVenda.Application.Dto;
using ControleVenda.CrossCutting.Common.Models;

namespace ControleVenda.Application.Ports.Clientes
{
    public interface IClienteUpdateUseCase
    {
        IResult<bool> Execute(ClienteDto dto);
    }
}