using AutoFixture;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data;
using ControleVenda.Infra.Data.Repositories;
using tb = ControleVenda.Infra.Data.Tables;
using dm = ControleVenda.Domain.Entities;
using ControleVenda.Test.Mocks;

namespace ControleVenda.Test.Infra.Data
{
    public class ClienteRepositoryTest
    {

        private IClienteRepository _repository;
        private Fixture _fixture = new Fixture();
        private DbVenda _context;

        private int _idCliente_1;
        private int _idCliente_2;
        private string _nomeCliente_1 = "CATEGORIA TEST 1";
        private string _nomeCliente_2 = "CATEGORIA TEST 2";

        public ClienteRepositoryTest()
        {

            // Criando banco de teste/mockado
            _context = new DbVendaTest();
            _repository = new ClienteRepository(_context);

            // Populando dados para teste
            tb.Cliente cliente1 = new() 
            {
                Nome = _nomeCliente_1,
                TipoPessoa = "j",
                Documento = "3655",
                TipoLogradouro = "sdvA",
                Logradouro = "Afds",
                Numero = "15646",
                Complemento = "Asdf",
                Bairro = "Adfs",
                Cidade = "Adsf",
                Uf = "adfs",
                Telefone = ("66541"),
                Email = "afdsfvcdsv@"

            };
            _context.Clientes.Add(cliente1);

            tb.Cliente cliente2 = new() 
            {
                Nome = _nomeCliente_2 ,
                TipoPessoa = "j",
                Documento = "366555",
                TipoLogradouro = "sdvA",
                Logradouro = "Afds",
                Numero = "15646",
                Complemento = "Asdf",
                Bairro = "Adfs",
                Cidade = "Adsf",
                Uf = "adfs",
                Telefone = ("668541"),
                Email = "afdsgfdsgcdsv@"
            };
            _context.Clientes.Add(cliente2);
            _context.SaveChanges();

            _idCliente_1 = cliente1.Id;
            _idCliente_2 = cliente2.Id;

        }

        public dm.Cliente Clienteok(int id)
         => new dm.Cliente(id)
         {
             Nome = _nomeCliente_1,
             TipoPessoa = "j",
             Documento = $"{id}3655",
             TipoLogradouro = "sdvA",
             Logradouro = "Afds",
             Numero = "15646",
             Complemento = "Asdf",
             Bairro = "Adfs",
             Cidade = "Adsf",
             Uf = "adfs",
             Telefone = ("66541"),
             Email = "afdsfvcdsv@"

         };

        [Fact]
        public void GetById_RetornaRegistroOk()
        {

            dm.Cliente? resp = _repository.GetById(_idCliente_1);
            Assert.NotNull(resp);
            Assert.True(resp.Id == _idCliente_1);

        }

        [Fact]
        public void GetById_RetornaRegistroNull()
        {
            dm.Cliente? res = _repository.GetById(55);
            Assert.Null(res);
        }

        [Fact]
        public void GetAll()
        {
            var result = _repository.GetAll();

            Assert.True(result.Any());
        }

        [Fact]
        public void Add()
        {
            var clienteTest = Clienteok(55);
            int id = _repository.Add(clienteTest);
            Assert.True(id > 0);
        }

        [Fact]
        public void Update()
        {
            dm.Cliente? clienteEditada = new(_idCliente_2)
            {
                Nome = "CATEGORIA_EDITADA"
            };
            _repository.Update(clienteEditada);

            dm.Cliente? clienteGravada = _repository.GetById(_idCliente_2);
            Assert.NotNull(clienteGravada);
            Assert.Equal(clienteGravada.Nome, clienteEditada.Nome);

        }

        [Fact(DisplayName = "Deve excluir cliente")]
        public void Delete()
        {
            var clienteTest = Clienteok(99);
            int id = _repository.Add(clienteTest);
            _repository.Delete(id);

            dm.Cliente? res = _repository.GetById(id);
            Assert.Null(res);
        }

    }
}
