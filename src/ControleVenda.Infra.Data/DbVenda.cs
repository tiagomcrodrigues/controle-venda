
using ControleVenda.Infra.Data.Configurations;
using ControleVenda.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data
{
    public class DbVenda : DbContext
    {
        public DbVenda(DbContextOptions<DbVenda> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
    }
}
