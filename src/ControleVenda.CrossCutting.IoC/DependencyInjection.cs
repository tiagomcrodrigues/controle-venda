using ControleVenda.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data.Repositories;
using ControleVenda.Domain.Services;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Application.UseCases.Categorias;
using ControleVenda.Application.UseCases.Produtos;
using ControleVenda.Application.Ports.Produtos;
using ControleVenda.Application.Ports.Clientes;
using ControleVenda.Application.UseCases.Clientes;

namespace ControleVenda.CrossCutting.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegistraServicos(this IServiceCollection service, string connectionString)
        {

            service.AddDbContext<DbVenda>(opt =>
            {
                opt.UseMySql
                (
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                );
            });

            // Repositórios
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<IClienteRepository, ClienteRepository>();

            // Serviços de Domínio
            service.AddScoped<ICategoriaService, CategoriaService>();
            service.AddScoped<IProdutoService, ProdutoService>();
            service.AddScoped<IClienteService, ClienteService>();

            // Casos de Uso
            service.AddScoped<ICategoriaAddUseCase, CategoriaAddUseCase>();
            service.AddScoped<ICategoriaGetByIdUseCase, CategoriaGetByIdUseCase>();
            service.AddScoped<ICategoriaGetAllUseCase, CategoriaGetAllUseCase>();
            service.AddScoped<ICategoriaUpdateUseCase, CategoriaUpdateUseCase>();
            service.AddScoped<ICategoriaDeleteUseCase, CategoriaDeleteUseCase>();

            service.AddScoped<IProdutoAddUseCase, ProdutoAddUseCase>();
            service.AddScoped<IProdutoGetByIdUseCase, ProdutoGetByIdUseCase>();
            service.AddScoped<IProdutoGetAllUseCase, ProdutoGetAllUseCase>();
            service.AddScoped<IProdutoUpdateUseCase, ProdutoUpdateUseCase>();
            service.AddScoped<IProdutoDeleteUseCase, ProdutoDeleteUseCase>();

            service.AddScoped<IClienteAddUseCase, ClienteAddUseCase>();
            service.AddScoped<IClienteGetByIdUseCase, ClienteGetByIdUseCase>();
            service.AddScoped<IClienteGetAllUseCase, ClienteGetAllUseCase>();
            service.AddScoped<IClienteUpdateUseCase, ClienteUpdateUseCase>();
            service.AddScoped<IClienteDeleteUseCase, ClienteDeleteUseCase>();


            return service;

        }

    }
}
