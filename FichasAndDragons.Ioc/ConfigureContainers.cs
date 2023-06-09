﻿using FichasAndDragons.Aplicacao.Personagens.Profiles;
using FichasAndDragons.Aplicacao.Personagens.Servicos;
using FichasAndDragons.Comum.Configs;
using FichasAndDragons.Comum.Configs.Interfaces;
using FichasAndDragons.Dominio.Personagens.Repositorios;
using FichasAndDragons.Dominio.Personagens.Servicos;
using FichasAndDragons.Infra.Personagens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichasAndDragons.Ioc
{
    public static class ConfigureContainers
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetSection("DatabaseConfig:ConnectionString").Value;
            string databaseName = configuration.GetSection("DatabaseConfig:DatabaseName").Value;

            Console.WriteLine(connectionString);

            services.AddSingleton<IMongoDatabaseConfiguration>(x => MongoDatabaseFluent.Configure().ConfigureClient(connectionString).ConfigureDatabaseName(databaseName));

            services.Scan(scan => scan.FromAssemblyOf<PersonagensAppServico>().AddClasses().AsImplementedInterfaces().WithScopedLifetime());
            services.Scan(scan => scan.FromAssemblyOf<PersonagensServico>().AddClasses().AsImplementedInterfaces().WithScopedLifetime());
            services.Scan(scan => scan.FromAssemblyOf<PersonagensRepositorio>().AddClasses().AsImplementedInterfaces().WithScopedLifetime());

            services.AddAutoMapper(typeof(PersonagensProfile));
        }
    }
}
