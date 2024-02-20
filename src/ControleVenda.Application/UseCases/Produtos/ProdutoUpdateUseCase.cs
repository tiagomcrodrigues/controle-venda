using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Produtos;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.UseCases.Produtos
{
    public class ProdutoUpdateUseCase : UseCaseBase<IProdutoService>, IProdutoUpdateUseCase
    {
        public ProdutoUpdateUseCase(IProdutoService service) : base(service)
        {
        }

        public IResult<bool> Execute(ProdutoDto dto)
            =>_service.Update(dto.Map());



    }
}
