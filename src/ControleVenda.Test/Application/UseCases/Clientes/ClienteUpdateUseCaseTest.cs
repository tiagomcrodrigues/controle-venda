using ControleVenda.Application.Dto;
using ControleVenda.Application.UseCases.Clientes;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Test.Application.UseCases.Clientes
{
    public class ClienteUpdateUseCaseTest : ClienteUseCaseBaseTest<ClienteUpdateUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {

            _service
                .Setup(p => p.Update(It.IsAny<Cliente>()))
                .Returns(new Result<bool>(true));

            var Cliente = new ClienteDto(ID_CATETORIA) { Nome = "Cliente TEST" };
            var resut = _useCase.Execute(Cliente);

            Assert.True(resut.Success);

        }
    }
}
