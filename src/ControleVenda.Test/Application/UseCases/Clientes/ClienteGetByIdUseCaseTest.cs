using AutoFixture;
using ControleVenda.Application.UseCases.Clientes;
using ControleVenda.Domain.Entities;
using Moq;

namespace ControleVenda.Test.Application.UseCases.Clientes
{
    public class ClienteGetByIdUseCaseTest : ClienteUseCaseBaseTest<ClienteGetByIdUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {
            Cliente Cliente = _fixture.Create<Cliente>();
            _service
                .Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(Cliente);

            var result = _useCase.Execute(ID_CATETORIA);

            Assert.NotNull(result);

        }
    }
}
