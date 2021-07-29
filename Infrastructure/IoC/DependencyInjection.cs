using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Application.Mappings;
using CleanArchitecture.Core.Application.Services;
using CleanArchitecture.Core.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchitecture.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchitecture.Core.Application");

            services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(MainContext).Assembly.FullName))
            );

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
