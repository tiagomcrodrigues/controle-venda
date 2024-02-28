using AutoFixture;
using ControleVenda.Application.Dto;
using ControleVenda.Application.UseCases.Clientes;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Test.Application.UseCases.Clientes
{
    public class ClienteAddUseCaseTest : ClienteUseCaseBaseTest<ClienteAddUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {
            _service
                .Setup(p => p.Add(It.IsAny<Cliente>()))
                .Returns(new Result<int>(ID_CATETORIA));

            var dto = _fixture.Create<ClienteDto>();
            var result = _useCase.Execute(dto);

            Assert.True(result.Success);
            Assert.Equal(ID_CATETORIA, result.Data);

        }

       
    }
}
