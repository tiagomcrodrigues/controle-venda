using AutoFixture;
using dt=ControleVenda.Domain.Entities;
using ControleVenda.Infra.Data.Tables;

namespace ControleVenda.Test.Domain.Entities
{
    public class ProdutoTest
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public void ValidacaoNomeInvalidoProduto()
        {
            var produto = _fixture.Create<dt.Produto>();
            produto.Nome = null;
            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 1);
        }

        [Fact]
        public void ValidacaoNomePequenoProduto()
        {
            var produto = _fixture.Create<dt.Produto>();
            produto.Nome = "q";
            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 1);
        }
        [Fact]
        public void ValidacaoNomeGrandeProduto()
        {
            var porduto = _fixture.Create<dt.Produto>();
            porduto.Nome = new string('w', 110);
            porduto.Validate();
            Assert.False(porduto.IsValid);
            Assert.True(porduto.Notifications.Count() == 1); 
        }

        [Fact]
        public void ErroProdutoCategoria() 
        {
            var produto = _fixture.Create<dt.Produto>();
            produto.Categoria = null;
            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 1);
        }


        [Fact]
        public void ErroProdutoValorUnitario()
        {
            var produto = _fixture.Create<dt.Produto>();

            produto.ValorUnitario = 0;

            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 1);
        }

        [Fact]
        public void ErroProdutoQuantidade()
        {
            var produto = _fixture.Create<dt.Produto>();

            produto.Quntidade = (0);

            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 1);
        }

    }
}
