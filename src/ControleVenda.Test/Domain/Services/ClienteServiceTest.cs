using AutoFixture;
using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Domain.Services;
using ControleVenda.Test.Domain.Entities;
using Moq;

namespace ControleVenda.Test.Domain.Services
{
    public class ClienteServiceTest
    {
        private Mock<IClienteRepository> _repositorio = new();
        private ClienteService _clienteService;
        private Fixture _fixture = new Fixture();
        private const int ID_PRODUTO = 1;

        public ClienteServiceTest()
        {
            _clienteService = new(_repositorio.Object);
        }

        private static Random random = new Random();

        public static string RandomString(string chars, int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Cliente ClienteCreate(int id)
            => _fixture.Build<Cliente>()
                .FromFactory<int>((x) => new Cliente(id))
                .Create();

        private Cliente CriacaoClientesOk(int id)
        => new Cliente(id)
        {

            Nome = "dasd",
            TipoPessoa = "j",
            Documento = "51166945865",
            TipoLogradouro = "bvsdy",
            Logradouro = "Akjv",
            Numero = "196",
            Complemento = "vA",
            Bairro = "Avxc",
            Cidade = "Amosdfh",
            Uf = "sp",
            Telefone = ("19996544521"),
            Email = "agtsdbvftgghdfy"
        };

        [Fact]
        public void AddSucess()
        {
            _repositorio
                .Setup(p => p.Add(It.IsAny<Cliente>()))
                .Returns(ID_PRODUTO);

            var cliente = CriacaoClientesOk(ID_PRODUTO);


            var result = _clienteService.Add(cliente);

            Assert.True(result.Success);
            Assert.Equal(ID_PRODUTO, result.Data);
        }

        [Fact]
        public void AddError()
        {
            var cliente = new Cliente();
            var result = _clienteService.Add(cliente);

            Assert.False(result.Success);
            Assert.Equal(9, result.Errors.Count());
        }



        [Fact]
        public void AddErrorDuplicate()
        {
            _repositorio
                .Setup(p => p.Add(It.IsAny<Cliente>()))
                .Throws(new Exception($"UK_{nameof(Cliente)}"));

            var cliente = CriacaoClientesOk(ID_PRODUTO);
            var result = _clienteService.Add(cliente);

            Assert.False(result.Success);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void AddErrorThor()
        {
            _repositorio
                .Setup(p => p.Add(It.IsAny<Cliente>()))
                .Throws(new Exception());

            var cliente = CriacaoClientesOk(ID_PRODUTO);

            Assert.Throws<Exception>(() => _clienteService.Add(cliente));
        }

        [Fact]
        public void UpdateSucess()
        {
            _repositorio
                .Setup(p => p.Update(It.IsAny<Cliente>()));

            var cliente = CriacaoClientesOk(ID_PRODUTO);

            var result = _clienteService.Update(cliente);

            Assert.True(result.Success);
        }

        [Fact]
        public void UpdateErrorThrow()
        {
            _repositorio
                .Setup(p => p.Update(It.IsAny<Cliente>()))
                .Throws(new Exception());

            var cliente = CriacaoClientesOk(ID_PRODUTO);


            Assert.Throws<Exception>(() => _clienteService.Update(cliente));
        }

        [Fact]
        public void UpdateError()
        {
            _repositorio
                .Setup(p => p.Update(It.IsAny<Cliente>()))
                .Throws(new Exception($"UK_{nameof(Cliente)}"));

            var cliente = CriacaoClientesOk(ID_PRODUTO);
            var result = _clienteService.Update(cliente);

            Assert.False(result.Success);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void GetAll()
        {
            IEnumerable<Cliente> clientes = _fixture.Create<IEnumerable<Cliente>>();
            _repositorio
               .Setup(p => p.GetAll())
               .Returns(clientes);
            var result = _clienteService.GetAll();

            Assert.True(result.Any());
        }

        [Fact]
        public void GetIdOk()
        {
            Cliente cliente = ClienteCreate(ID_PRODUTO);
            _repositorio
                .Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(cliente);

            var result = _clienteService.GetById(ID_PRODUTO);

            Assert.NotNull(result);

        }

    }
}
