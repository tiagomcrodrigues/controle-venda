using AutoFixture;
using ControleVenda.Application.UseCases.Categorias;
using ControleVenda.Domain.Entities;

namespace ControleVenda.Test.Application.UseCases.Categorias
{
    public class CategoriaGetAllUseCaseTest : CategoriaUseCaseBaseTest<CategoriaGetAllUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }
        [Fact]
        public void ExecuteOk()
        {
            IEnumerable<Categoria> dto = _fixture.Create<IEnumerable<Categoria>>();
            _service
                .Setup(p => p.GetAll())
                .Returns(dto);

            var result = _useCase.Execute();

            Assert.True(result.Any());

        }
    }
}
