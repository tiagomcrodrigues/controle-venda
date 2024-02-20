using AutoFixture;
using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Domain.Services;
using Moq;

namespace ControleVenda.Test.Domain.Services
{
    public class ProdutoServiceTest
    {
        private Mock<IProdutoRepository> _repositorio = new();
        private ProdutoService _produtoService;
        private Fixture _fixture = new Fixture();
        private const int ID_PRODUTO = 1;

        public ProdutoServiceTest()
        {
            _produtoService = new(_repositorio.Object);
        }

        private Produto ProdutoCreate(int id)
            => _fixture.Build<Produto>()
                .FromFactory<int>((x) => new Produto(id))
                .Create();

        [Fact]
        public void AddSucess()
        {
            _repositorio
                .Setup(p => p.Add(It.IsAny<Produto>()))
                .Returns(ID_PRODUTO);

            var produto = _fixture.Create<Produto>();
            produto.Categoria = new Categoria(1) { Nome = "CATEGORIA TEST" };
            var result = _produtoService.Add(produto);

            Assert.True(result.Success);
            Assert.Equal(ID_PRODUTO, result.Data);
        }

        [Fact]
        public void AddError()
        {
            var produto = new Produto();
            var result = _produtoService.Add(produto);

            Assert.False(result.Success);
            Assert.Equal(4, result.Errors.Count());
        }



        [Fact]
        public void AddErrorDuplicate()
        {
            _repositorio
                .Setup(p => p.Add(It.IsAny<Produto>()))
                .Throws(new Exception($"UK_{nameof(Produto)}"));

            var produto = _fixture.Create<Produto>();
            produto.Categoria = new Categoria(1) { Nome = "CATEGORIA TEST" };
            var result = _produtoService.Add(produto);

            Assert.False(result.Success);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void AddErrorThor()
        {
            _repositorio
                .Setup(p => p.Add(It.IsAny<Produto>()))
                .Throws(new Exception());

            var produto = _fixture.Create<Produto>();
            produto.Categoria = new Categoria(1) { Nome = "CATEGORIA TEST" };

            Assert.Throws<Exception>(() => _produtoService.Add(produto));
        }

        [Fact]
        public void UpdateSucess()
        {
            _repositorio
                .Setup(p => p.Update(It.IsAny<Produto>()));

            var produto = ProdutoCreate(ID_PRODUTO);

            produto.Categoria = new Categoria(1) { Nome = "CATEGORIA TEST" };
            var result = _produtoService.Update(produto);

            Assert.True(result.Success);
        }

        [Fact]
        public void UpdateErrorThrow()
        {
            _repositorio
                .Setup(p => p.Update(It.IsAny<Produto>()))
                .Throws(new Exception());

            var produto = ProdutoCreate(ID_PRODUTO);

            produto.Categoria = new Categoria(1) { Nome = "CATEGORIA TEST" };

            Assert.Throws<Exception>(() => _produtoService.Update(produto));
        }

        [Fact]
        public void UpdateError()
        {
            _repositorio
                .Setup(p => p.Update(It.IsAny<Produto>()))
                .Throws(new Exception($"UK_{nameof(Produto)}"));

            var produto = _fixture.Create<Produto>();
            produto.Categoria = new Categoria(1) { Nome = "CATEGORIA TEST" };
            var result = _produtoService.Update(produto);

            Assert.False(result.Success);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void GetAll()
        {
            IEnumerable<Produto> produtos = _fixture.Create<IEnumerable<Produto>>();
            _repositorio
               .Setup(p => p.GetAll())
               .Returns(produtos);
            var result = _produtoService.GetAll();

            Assert.True(result.Any());
        }

        [Fact]
        public void GetIdOk()
        {
            Produto produto = ProdutoCreate(ID_PRODUTO);
            _repositorio
                .Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(produto);

            var result = _produtoService.GetById(ID_PRODUTO);

            Assert.NotNull(result);

        }

    }
}
