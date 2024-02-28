using tb = ControleVenda.Infra.Data.Tables;
using dm = ControleVenda.Domain.Entities;


namespace ControleVenda.Infra.Data.Extensions
{
    public static class ClienteExtension
    {

        public static tb.Cliente Map(this dm.Cliente entidade)
        {
            return new tb.Cliente()
            {
                Nome = entidade.Nome,
                TipoPessoa = entidade.TipoPessoa,
                Documento = entidade.Documento,
                TipoLogradouro = entidade.TipoLogradouro,
                Logradouro = entidade.Logradouro,
                Numero = entidade.Numero,
                Complemento = entidade.Complemento,
                Bairro = entidade.Bairro,
                Cidade = entidade.Cidade,
                Uf = entidade.Uf,
                Telefone = entidade.Telefone,
                Email = entidade.Email
            };
        }

        public static dm.Cliente Map(this tb.Cliente tabela)
            => new(tabela.Id)
            {
                Nome = tabela.Nome,
                TipoPessoa = tabela.TipoPessoa,
                Documento = tabela.Documento,
                TipoLogradouro = tabela.TipoLogradouro,
                Logradouro = tabela.Logradouro,
                Numero = tabela.Numero,
                Complemento = tabela.Complemento,
                Bairro = tabela.Bairro,
                Cidade = tabela.Cidade,
                Uf = tabela.Uf,
                Telefone = tabela.Telefone,
                Email = tabela.Email
            };

        public static tb.Cliente Map(this tb.Cliente tabela, dm.Cliente entidade)
        {
            tabela.Nome = entidade.Nome;
            tabela.TipoPessoa = entidade.TipoPessoa;
            tabela.Documento = entidade.Documento;
            tabela.TipoLogradouro = entidade.TipoLogradouro;
            tabela.Logradouro = entidade.Logradouro;
            tabela.Numero = entidade.Numero;
            tabela.Complemento = entidade.Complemento;
            tabela.Bairro = entidade.Bairro;
            tabela.Cidade = entidade.Cidade;
            tabela.Uf = entidade.Uf;
            tabela.Telefone = entidade.Telefone;
            tabela.Email = entidade.Email;

            return tabela;
        }


    }
}
