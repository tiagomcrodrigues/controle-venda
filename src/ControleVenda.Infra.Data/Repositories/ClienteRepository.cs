﻿using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data.Extensions;

namespace ControleVenda.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente, Tables.Cliente>, IClienteRepository
    {

        private readonly DbVenda _dbVenda;

        public ClienteRepository(DbVenda dbVenda) : base(dbVenda)
        {
            _dbVenda = dbVenda;
        }


        protected override Cliente Map(Tables.Cliente tabela)
            => tabela.Map();

        protected override Tables.Cliente Map(Cliente entidade)
            => entidade.Map();

        protected override Tables.Cliente Map(Cliente entidade, Tables.Cliente tabela)
            => tabela.Map(entidade);
    }
}
