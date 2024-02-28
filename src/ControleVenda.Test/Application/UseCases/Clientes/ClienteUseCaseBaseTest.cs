using AutoFixture;
using ControleVenda.Domain.Ports;
using Moq;

namespace ControleVenda.Test.Application.UseCases.Clientes
{
    public abstract class ClienteUseCaseBaseTest<TUseCase>
    {
        protected Mock<IClienteService> _service = new();
        protected TUseCase _useCase;
        protected Fixture _fixture = new();
        protected const int ID_CATETORIA = 1;

        public ClienteUseCaseBaseTest()
        {
            Setup();
        }

        protected abstract void Setup();

    }
}
