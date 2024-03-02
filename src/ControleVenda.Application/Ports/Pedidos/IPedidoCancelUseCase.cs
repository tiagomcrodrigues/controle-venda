using ControleVenda.Application.Dto;
using ControleVenda.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.Ports.Pedidos
{
    internal interface IPedidoCancelUseCase
    {
        IResult<bool> Execute(int id);
    }
}
