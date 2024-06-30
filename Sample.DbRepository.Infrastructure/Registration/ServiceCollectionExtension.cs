using System;
using Microsoft.Extensions.DependencyInjection;
using Sample.DbRepository.Domain.Infrastructure;
using IManagement = Sample.DbRepository.Domain.Management;
using CManagement = Sample.DbRepository.Infrastructure.Repositories.Management;
using ISearch = Sample.DbRepository.Domain.Search;
using CSearch = Sample.DbRepository.Infrastructure.Repositories.Search;
using IAggregation = Sample.DbRepository.Domain.Aggregation;
using CAggregation = Sample.DbRepository.Infrastructure.Repositories.Aggregation;
using Sample.DbRepository.Infrastructure.Contexts.Aggregation;
using Sample.DbRepository.Infrastructure.Contexts.Search;
using Sample.DbRepository.Infrastructure.Contexts.Management;


namespace Sample.DbRepository.Infrastructure.Registration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Caching
            services.AddMemoryCache();

            // Database Context Factory and Repositories
            services.AddSingleton<IContextFactory<ManagementContext>, ManagementContextFactory>();
            services.AddSingleton<IContextFactory<SearchContext>, SearchContextFactory>();
            services.AddSingleton<IContextFactory<AggregationContext>, AggregationContextFactory>();

            // Management
            services.AddSingleton<IManagement.IAlbumRepository, CManagement.AlbumRepository>();
            services.AddSingleton<IManagement.IArtistRepository, CManagement.ArtistRepository>();
            services.AddSingleton<IManagement.IMediaTypeRepository, CManagement.MediaTypeRepository>();
            services.AddSingleton<IManagement.IGenreRepository, CManagement.GenreRepository>();

            // Search
            services.AddSingleton<ISearch.IAlbumRepository, CSearch.AlbumRepository>();

            // Aggregation
            services.AddSingleton<IAggregation.IAlbumRepository, CAggregation.AlbumRepository>();

            return services;
        }
    }
}
