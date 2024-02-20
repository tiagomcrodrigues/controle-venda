using AutoFixture;
using dm = ControleVenda.Domain.Entities;

namespace ControleVenda.Test.Domain.Entities
{
    public class ClienteTest
    {
        private Fixture _fixture = new Fixture();

        private dm.Cliente _clientes = new dm.Cliente(1);

        private dm.Cliente CriacaoClientesNull()
        => new dm.Cliente(1)
        {
            
            Nome = null,
            TipoDePessoa = null,
            TipoLogradouro = null,
            Documento = null,
            Logradouro = null,
            Numero = null,
            Complemento = "dsf",
            Bairro = null,
            Cidade = null,
            Uf = null,
            Telefone = ("sdd"),
            Email = "sdfsd"
        };

        private dm.Cliente CriacaoClientesPequeno()
        => new dm.Cliente(1)
        {

            Nome = "a",
            TipoDePessoa = "jj",
            Documento = "3",
            TipoLogradouro = "A",
            Logradouro = "A",
            Numero = "1",
            Complemento = "A",
            Bairro = "A",
            Cidade = "A",
            Uf = "a",
            Telefone = ("1"),
            Email = "a"
        };



        [Fact]
        public void ValidacaoClienteNomeErro()
        {
            _clientes = CriacaoClientesNull();
            _clientes.Validate();

            Assert.False(_clientes.IsValid);
            Assert.True(_clientes.Notifications.Count() == 9);
        }


        [Fact]
        public void ValidacaoClienteNomePequeno()
        {
            _clientes = CriacaoClientesPequeno();
            _clientes.Validate();

            Assert.False(_clientes.IsValid);
            Assert.True(_clientes.Notifications.Count() == 12);
        }


    }
}
