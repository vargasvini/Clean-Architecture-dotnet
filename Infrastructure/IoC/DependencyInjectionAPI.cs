using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Application.Mappings;
using CleanArchitecture.Core.Application.Services;
using CleanArchitecture.Core.Domain.Account;
using CleanArchitecture.Core.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Identity;
using CleanArchitecture.Infra.Data.Repositories;
using IdentityServer4.AccessTokenValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchitecture.Core.Application");

            services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(MainContext).Assembly.FullName))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MainContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "https://localhost:44321/",
                    ValidIssuer = "https://localhost:44321/",
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the key that we will use in encryption")),
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddMediatR(myHandlers);

            services.AddScoped<IRedisClient>(x => 
            new RedisClient(Environment.GetEnvironmentVariable("redisHost"), 
                            int.Parse(Environment.GetEnvironmentVariable("redisPort")), 
                            Environment.GetEnvironmentVariable("redisPassword")));

            SwaggerServices(services);
            //JWTServices(services);

            return services;
        }


        private static void JWTServices(IServiceCollection services )
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "sadsa";
                    options.ApiName = "asdasdsad";
                    options.ApiSecret = "asdasdasd";
                    options.RequireHttpsMetadata = false;
                    options.SupportedTokens = SupportedTokens.Both;
                });
        }

        private static void SwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Para as APIs com autenticacão use o header com token, como nexemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "SSO",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }
    }

}
