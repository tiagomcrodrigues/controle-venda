using AutoFixture;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data;
using ControleVenda.Infra.Data.Repositories;
using tb = ControleVenda.Infra.Data.Tables;
using dm = ControleVenda.Domain.Entities;
using ControleVenda.Test.Mocks;

namespace ControleVenda.Test.Infra.Data
{
    public class ProdutoRepositoryTest
    {
        private IProdutoRepository _repository;
        private Fixture _fixture = new Fixture();
        private DbVenda _context;

        private int _idProduto_1;
        private int _idProduto_2;
        private string _nomeProduto_1 = "produto TEST 1";
        private string _nomeProduto_2 = "produto TEST 2";
        private double _valorUnitario_1 = 11;
        private int _quantidade_1 = 1;
        private double _valorUnitario_2 = 22;
        private int _quantidade_2 = 2;
        private int _idCategoria_1;
        private int _idCategoria_2;
        private string _nomeCategoria_1 = "CATEGORIA TEST 1";
        private string _nomeCategoria_2 = "CATEGORIA TEST 2";

        public ProdutoRepositoryTest()
        {

            // Criando banco de teste/mockado
            _context = new DbVendaTest();
            _repository = new ProdutoRepository(_context);

            // Populando dados para teste
            tb.Categoria categoria1 = new() { Nome = _nomeCategoria_1 };
            _context.Categorias.Add(categoria1);

            tb.Categoria categoria2 = new() { Nome = _nomeCategoria_2 };
            _context.Categorias.Add(categoria2);
            _context.SaveChanges();

            _idCategoria_1 = categoria1.Id;
            _idCategoria_2 = categoria2.Id;

            // Populando dados para teste
            tb.Produto produto = new() 
            { 
                Nome = _nomeProduto_1,
                Quntidade = _quantidade_1 ,
                ValorUnitario = _valorUnitario_1,
                CategoriaId = _idCategoria_1
            };
            _context.Produtos.Add(produto);

            tb.Produto produto2 = new()
            {
                Nome = _nomeProduto_2,
                Quntidade = _quantidade_1,
                ValorUnitario = _valorUnitario_2,
                CategoriaId = _idCategoria_2
            };
            _context.Produtos.Add(produto2);
            _context.SaveChanges();

            _idProduto_1 = produto.Id;
            _idProduto_2 = produto2.Id;

        }

        [Fact]
        public void GetById_RetornaRegistroOk()
        {

            dm.Produto? resp = _repository.GetById(_idProduto_1);
            Assert.NotNull(resp);
            Assert.True(resp.Id == _idProduto_1);

        }

        [Fact]
        public void GetById_RetornaRegistroNull()
        {
            dm.Produto? res = _repository.GetById(55);
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
            var produtoTest = new dm.Produto() 
            { 
                Nome = "ttttt",
                Quantidade =1,
                ValorUnitario =1,
                Categoria = new dm.Categoria(1)
            };
            int id = _repository.Add(produtoTest);
            Assert.True(id > 0);
        }

        [Fact]
        public void Update()
        {

            dm.Produto? produtoEditada = new(_idProduto_2)
            {
                Nome = "Produto EDITADO",
                Quantidade = 13,
                ValorUnitario = 3,
                Categoria = new dm.Categoria(_idCategoria_1)
            };
            _repository.Update(produtoEditada);

            dm.Produto? produtoGravado = _repository.GetById(_idProduto_2);
            Assert.NotNull(produtoGravado);
            Assert.Equal(produtoGravado.Nome, produtoEditada.Nome);
            Assert.Equal(produtoGravado.Quantidade, produtoEditada.Quantidade);

        }

        [Fact(DisplayName = "Deve excluir produto")]
        public void Delete()
        {
            //var produtoTest = new dm.Produto() { Nome = "ttadsttt" };
            dm.Produto? produtoTest = new()
            {
                Nome = "PRODUTO CONDENADO",
                Quantidade = 1,
                ValorUnitario = 1,
                Categoria = new dm.Categoria(2)
            };
            int id = _repository.Add(produtoTest);
            _repository.Delete(id);

            dm.Produto? res = _repository.GetById(id);
            Assert.Null(res);
        }

    }
}
