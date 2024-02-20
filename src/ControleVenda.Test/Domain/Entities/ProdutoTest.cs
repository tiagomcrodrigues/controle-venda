using AutoFixture;
using dm = ControleVenda.Domain.Entities;

namespace ControleVenda.Test.Domain.Entities
{
    public class ProdutoTest
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public void ValidacaoNomeInvalidoProduto()
        {
            var produto = _fixture.Create<dm.Produto>();
            produto.Nome = null;
            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 2);
        }

        [Fact]
        public void ValidacaoNomePequenoProduto()
        {
            var produto = _fixture.Create<dm.Produto>();
            produto.Nome = "q";
            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 2);
        }
        [Fact]
        public void ValidacaoNomeGrandeProduto()
        {
            var porduto = _fixture.Create<dm.Produto>();
            porduto.Nome = new string('w', 110);
            porduto.Validate();
            Assert.False(porduto.IsValid);
            Assert.True(porduto.Notifications.Count() == 2); 
        }

        [Fact]
        public void ErroProdutoCategoria() 
        {
            var produto = _fixture.Create<dm.Produto>();
            produto.Categoria = null;
            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 1);
        }


        [Fact]
        public void ErroProdutoValorUnitario()
        {
            var produto = _fixture.Create<dm.Produto>();

            produto.ValorUnitario = 0;

            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 2);
        }

        [Fact]
        public void ErroProdutoQuantidade()
        {
            var produto = _fixture.Create<dm.Produto>();

            produto.Quantidade = (0);

            produto.Validate();
            Assert.False(produto.IsValid);
            Assert.True(produto.Notifications.Count() == 2);
        }

    }
}
