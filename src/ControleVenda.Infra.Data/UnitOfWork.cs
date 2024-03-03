using ControleVenda.CrossCutting.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbVenda _dbVenda;

        public UnitOfWork(DbVenda dbVenda)
        {
            _dbVenda = dbVenda;
        }

        public void BeginTransaction()
            => _dbVenda.Database.BeginTransaction();

        public void Commit()
            => _dbVenda.Database.CommitTransaction();

        public void RollBack()
            => _dbVenda.Database.RollbackTransaction();
    }
}
