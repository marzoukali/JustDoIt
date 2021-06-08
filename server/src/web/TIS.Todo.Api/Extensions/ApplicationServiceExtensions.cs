using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TIS.Todo.Application;
using TIS.Todo.Application.Interfaces;
using TIS.Todo.Application.Interfaces.IRepositories;
using TIS.Todo.Application.UserTodos;
using TIS.Todo.Data;
using TIS.Todo.Data.Repositories;
using TIS.Todo.Domain.Interfaces;
using TIS.Todo.Domain.Interfaces.IRepositories;
using TLS.Todo.Infrastructure.Security;

namespace TIS.Todo.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "TIS.Todo.Api", Version = "v1"});
            });

            services.AddDbContext<DataContext>(opt => { opt.UseInMemoryDatabase("TIS.Todo.Db.InMemory"); });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                    policy =>
                    {
                        policy.AllowAnyMethod().AllowAnyHeader()
                            .WithOrigins(config["CorsOrigins"].Split(','));
                    });
            });

            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IToDosRepository, ToDosRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            return services;
        }
    }
}