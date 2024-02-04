using ControleVenda.Application.UseCases.Categorias;

namespace ControleVenda.Test.Application.UseCases.Categorias
{
    public class CategoriaDeleteUseCaseTest : CategoriaUseCaseBaseTest<CategoriaDeleteUseCase>
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
