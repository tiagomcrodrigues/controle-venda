using AutoFixture;
using ControleVenda.Domain.Ports;
using Moq;

namespace ControleVenda.Test.Application.UseCases.Produtos
{
    public abstract class ProdutoUseCaseBaseTest<TUseCase>
    {
        protected Mock<IProdutoService> _service = new();
        protected TUseCase _useCase;
        protected Fixture _fixture = new();
        protected const int ID_CATETORIA = 1;

        public ProdutoUseCaseBaseTest()
        {
            Setup();
        }

        protected abstract void Setup();

    }
}
