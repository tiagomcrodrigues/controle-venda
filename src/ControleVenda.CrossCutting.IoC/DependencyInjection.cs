using ControleVenda.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data.Repositories;
using ControleVenda.Domain.Services;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Application.UseCases.Categorias;
using Castle.Core.Configuration;

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

            // Serviços de Domínio
            service.AddScoped<ICategoriaService, CategoriaService>();

            // Casos de Uso
            service.AddScoped<ICategoriaAddUseCase, CategoriaAddUseCase>();
            service.AddScoped<ICategoriaGetByIdUseCase, CategoriaGetByIdUseCase>();
            service.AddScoped<ICategoriaGetAllUseCase, CategoriaGetAllUseCase>();
            service.AddScoped<ICategoriaUpdateUseCase, CategoriaUpdateUseCase>();
            service.AddScoped<ICategoriaDeleteUseCase, CategoriaDeleteUseCase>();

            return service;

        }

    }
}
