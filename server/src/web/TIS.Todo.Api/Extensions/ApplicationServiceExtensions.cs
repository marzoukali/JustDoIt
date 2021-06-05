using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TIS.Todo.Application;
using TIS.Todo.Application.UserTodos;
using TIS.Todo.Data;

namespace TIS.Todo.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TIS.Todo.Api", Version = "v1" });
            });

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseInMemoryDatabase(databaseName: "TIS.Todo.Db.InMemory");
            });

             services.AddCors( opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3001");
                });            
            });

            services.AddMediatR(typeof(List.Handler).Assembly);

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}