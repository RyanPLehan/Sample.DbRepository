using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Sample.DbRepository.Infrastructure.Configurations;
using Sample.DbRepository.Infrastructure.Registration;
using System.Reflection;


namespace Sample.DbRepository.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add in this application specific services
            AppServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

        private static void AppServices(IServiceCollection services)
        {
            // Load selected assemblies
            Assembly[] assemblies = new Assembly[]
                    {
                        typeof(Sample.DbRepository.Api.Program).Assembly,
                        typeof(Sample.DbRepository.Domain.AutoMapper.Profiles.ConvertersMappingProfile).Assembly,
                        typeof(Sample.DbRepository.Infrastructure.Registration.ServiceCollectionExtension).Assembly,

                    };

            services.AddAutoMapper(assemblies);
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(assemblies));

            services.AddOptions<DatabaseSettings>().BindConfiguration(DatabaseSettings.CONFIGURATION_SECTION);
            services.AddInfrastructure();
        }
    }
}
