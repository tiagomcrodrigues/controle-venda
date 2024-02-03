using ControleVenda.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ControleVenda.Test.Mocks
{
    public class DbVendaTest : DbVenda
    {

        public DbVendaTest() 
        : base
        (
            new DbContextOptionsBuilder<DbVenda>()
              .UseInMemoryDatabase(databaseName: "DbMemoryTest")
              .Options
        )
        {
            
        }

    }
}
