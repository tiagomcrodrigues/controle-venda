using AutoFixture;
using ControleVenda.Application.UseCases.Clientes;
using ControleVenda.Domain.Entities;

namespace ControleVenda.Test.Application.UseCases.Clientes
{
    public class ClienteGetAllUseCaseTest : ClienteUseCaseBaseTest<ClienteGetAllUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }
        [Fact]
        public void ExecuteOk()
        {
            IEnumerable<Cliente> dto = _fixture.Create<IEnumerable<Cliente>>();
            _service
                .Setup(p => p.GetAll())
                .Returns(dto);

            var result = _useCase.Execute();

            Assert.True(result.Any());

        }
    }
}
