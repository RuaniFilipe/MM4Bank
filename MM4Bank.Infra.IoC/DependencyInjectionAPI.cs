﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MM4Bank.Domain.Interfaces;
using MM4Bank.Infra.Data.Context;
using MM4Bank.Infra.Data.Repositories;

namespace MM4Bank.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default Connection"
                ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            //services.AddAutoMapper(typeof(DomainToDTOMappingProfile
            //var myhandlers = AppDomain.CurrentDomain.Load("MM4Bank.Application");
            //services.AddMediatR(myhandlers)

            return services;
        }
    }
}
