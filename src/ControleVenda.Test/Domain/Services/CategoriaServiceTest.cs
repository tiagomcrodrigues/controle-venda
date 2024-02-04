using AutoFixture;
using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Domain.Services;
using Moq;

namespace ControleVenda.Test.Domain.Services
{
    public class CategoriaServiceTest
    {

        private Mock<ICategoriaRepository> _repositorio = new();
        private CategoriaService _categoriaService;
        private Fixture _fixture = new Fixture();
        private const int ID_CATETORIA = 1;

        public CategoriaServiceTest()
        {
            _categoriaService = new(_repositorio.Object);
        }

        [Fact(DisplayName = "Deve gravar categoria com sucesso")]
        public void AddSucess()
        {
            
            _repositorio
                .Setup(p => p.Add(It.IsAny<Categoria>()))
                .Returns(ID_CATETORIA);

            var categoria = _fixture.Create<Categoria>();
            var result = _categoriaService.Add(categoria);

            Assert.True(result.Success);
            Assert.Equal(ID_CATETORIA, result.Data);

        }

        [Fact(DisplayName = "Inclusao de Categoria deve falhar")]
        public void AddError()
        {

            const int ID_CATETORIA = 1;

            _repositorio
                .Setup(p => p.Add(It.IsAny<Categoria>()))
                .Returns(ID_CATETORIA);

            var categoria = new Categoria();
            var resut = _categoriaService.Add(categoria);

            Assert.False(resut.Success);
            Assert.Equal(1, resut.Errors.Count);

        }

        [Fact]
        public void ListAllOk()
        {
            IEnumerable<Categoria> categorias = _fixture.Create<IEnumerable<Categoria>>();
            _repositorio
                .Setup(p => p.GetAll())
                .Returns(categorias);

            var result = _categoriaService.GetAll();

            Assert.True(result.Any());

        }

        [Fact]
        public void GetIdOk()
        {
            Categoria categoria = _fixture.Create<Categoria>();
            _repositorio
                .Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(categoria);

            var result = _categoriaService.GetById(ID_CATETORIA);

            Assert.NotNull(result);

        }


        [Fact]
        public void UpdateOk()
        {

            _repositorio
                .Setup(p => p.Update(It.IsAny<Categoria>()));

            var categoria = new Categoria(ID_CATETORIA) { Nome = "CATEGORIA TEST" };
            var resut = _categoriaService.Update(categoria);

            Assert.True(resut.Success);

        }


        [Fact]
        public void UpdateError()
        {

            _repositorio
                .Setup(p => p.Update(It.IsAny<Categoria>()));

            var categoria = new Categoria();
            var resut = _categoriaService.Update(categoria);

            Assert.False(resut.Success);

        }

        [Fact]
        public void DeleteOk()
        {
            _categoriaService.Delete(ID_CATETORIA);
        }


    }
}
