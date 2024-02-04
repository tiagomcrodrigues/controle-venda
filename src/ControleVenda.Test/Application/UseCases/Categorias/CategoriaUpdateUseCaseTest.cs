using ControleVenda.Application.Dto;
using ControleVenda.Application.UseCases.Categorias;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Test.Application.UseCases.Categorias
{
    public class CategoriaUpdateUseCaseTest : CategoriaUseCaseBaseTest<CategoriaUpdateUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {

            _service
                .Setup(p => p.Update(It.IsAny<Categoria>()))
                .Returns(new Result<bool>(true));

            var categoria = new CategoriaDto(ID_CATETORIA) { Nome = "CATEGORIA TEST" };
            var resut = _useCase.Execute(categoria);

            Assert.True(resut.Success);

        }
    }
}
