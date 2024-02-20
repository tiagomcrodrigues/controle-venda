using ControleVenda.Application.UseCases.Produtos;

namespace ControleVenda.Test.Application.UseCases.Produtos
{
    public class ProdutoDeleteUseCaseTest : ProdutoUseCaseBaseTest<ProdutoDeleteUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {
            _useCase.Execute(ID_CATETORIA);

        }
    }
}
