using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;


namespace ControleVenda.Infra.Data
{

    /// <summary>
    /// Entry context factory
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Config class used only for generate migration")]
    public class DbVendaContextFactory : IDesignTimeDbContextFactory<DbVenda>
    {

        ///<inheritdoc/>
        public DbVenda CreateDbContext(string[] args)
        {
            //local
            string connectionString =
                "Server=127.0.0.1;Port=3306;" +
                "Database=dbvenda;" +
                "Uid=root;" +
                "password=1234;";


            //servidor
            //string connectionString =
            //    "Server=192.168.3.1;Port=3306;" +
            //    "Database=dbvenda;" +
            //    "Uid=root;" +
            //    "password=RR.MySqlDev;";

            DbContextOptions < DbVenda> options =
                new DbContextOptionsBuilder<DbVenda>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;

            return new DbVenda(options);

        }
    }
}
