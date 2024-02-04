using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.UseCases.Categorias
{
    public class CategoriaUpdateUseCase : UseCaseBase<ICategoriaService>, ICategoriaUpdateUseCase
    {
        public CategoriaUpdateUseCase(ICategoriaService service) : base(service)
        {
        }

        public IResult<bool> Execute(CategoriaDto dto)
            => _service.Update(dto.Map());


    }
}
