using System;
using Microsoft.Extensions.DependencyInjection;
using IManagement = Sample.DbRepository.Domain.Management;
using CManagement = Sample.DbRepository.Infrastructure.Repositories.Management;
using ISearch = Sample.DbRepository.Domain.Search;
using CSearch = Sample.DbRepository.Infrastructure.Repositories.Search;
using IAggregation = Sample.DbRepository.Domain.Aggregation;
using CAggregation = Sample.DbRepository.Infrastructure.Repositories.Aggregation;
using Sample.DbRepository.Infrastructure.Repositories;
using Sample.DbRepository.Infrastructure.Repositories.Aggregation;
using Sample.DbRepository.Infrastructure.Repositories.Management;
using Sample.DbRepository.Infrastructure.Repositories.Search;


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
            services.AddSingleton<IManagement.IGenreRepository, CManagement.GenreRepository>();
            services.AddSingleton<IManagement.ITrackRepository, CManagement.TrackRepository>();

            // Search
            services.AddSingleton<ISearch.IAlbumRepository, CSearch.AlbumRepository>();
            services.AddSingleton<ISearch.IArtistRepository, CSearch.ArtistRepository>();
            services.AddSingleton<ISearch.IGenreRepository, CSearch.GenreRepository>();
            services.AddSingleton<ISearch.ITrackRepository, CSearch.TrackRepository>();

            // Aggregation
            services.AddSingleton<IAggregation.ITrackRepository, CAggregation.TrackRepository>();

            return services;
        }
    }
}
