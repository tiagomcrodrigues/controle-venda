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
        private const int ID_Produto = 1;

        public ProdutoServiceTest()
        {
            _produtoService = new(_repositorio.Object);
        }

        [Fact]
        public void AddSucess()
        {
            _repositorio
                .Setup(p => p.Add(It.IsAny<Produto>()))
                .Returns(ID_Produto);

            var produto = _fixture.Create<Produto>();
            var result = _produtoService.Add(produto);

            Assert.True(result.Success);
            Assert.Equal(ID_Produto, result.Data);
        }

        [Fact]
        public void AddError()
        {
            _repositorio
                .Setup(p => p.Add(It.IsAny<Produto>()))
                .Returns(ID_Produto);

            var produto = new Produto();
            var result = _produtoService.Add(produto);

            Assert.False(result.Success);
            Assert.Equal(1, result.Errors.Count());
        }

    }
}
