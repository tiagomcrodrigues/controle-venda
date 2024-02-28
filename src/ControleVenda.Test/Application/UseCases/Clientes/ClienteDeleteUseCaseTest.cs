using ControleVenda.Application.UseCases.Clientes;

namespace ControleVenda.Test.Application.UseCases.Clientes
{
    public class ClienteDeleteUseCaseTest : ClienteUseCaseBaseTest<ClienteDeleteUseCase>
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
