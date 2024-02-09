using ControleVenda.Domain.Entities;

namespace ControleVenda.Test.Domain.Entities
{
    public class CategoriaTest
    {

        [Fact]
        public void ValidacaoNomeInvalidoCategoria()
        {
            var categoria = new Categoria();
            categoria.Validate();
            Assert.False(categoria.IsValid);
            Assert.True(categoria.Notifications.Count() == 1);
        }

        [Fact]
        public void ValidacaoNomePequenoCategoria()
        {
            var categoria = new Categoria() { Nome = "q" };
            categoria.Validate();
            Assert.False(categoria.IsValid);
            Assert.True(categoria.Notifications.Count() == 1);
        }
        [Fact]
        public void ValidacaoNomeGrandeCategoria()
        {
            var categoria = new Categoria(2) { Nome = new string('w', 110) };
            categoria.Validate();
            Assert.False(categoria.IsValid);
            Assert.True(categoria.Notifications.Count() == 1);
        }

    }
}
