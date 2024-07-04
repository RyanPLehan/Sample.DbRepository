using System;
using Microsoft.Extensions.DependencyInjection;
using IManage = Sample.DbRepository.Domain.Manage;
using CManage = Sample.DbRepository.Infrastructure.Repositories.Manage;
using ISearch = Sample.DbRepository.Domain.Search;
using CSearch = Sample.DbRepository.Infrastructure.Repositories.Search;
using IAggregate = Sample.DbRepository.Domain.Aggregate;
using CAggregate = Sample.DbRepository.Infrastructure.Repositories.Aggregate;
using Sample.DbRepository.Infrastructure.Repositories;
using Sample.DbRepository.Infrastructure.Repositories.Aggregate;
using Sample.DbRepository.Infrastructure.Repositories.Manage;
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
            services.AddSingleton<IContextFactory<ManageContext>, ManageContextFactory>();
            services.AddSingleton<IContextFactory<SearchContext>, SearchContextFactory>();
            services.AddSingleton<IContextFactory<AggregateContext>, AggregateContextFactory>();

            // Manage
            services.AddSingleton<IManage.IAlbumRepository, CManage.AlbumRepository>();
            services.AddSingleton<IManage.IArtistRepository, CManage.ArtistRepository>();
            services.AddSingleton<IManage.IGenreRepository, CManage.GenreRepository>();
            services.AddSingleton<IManage.ITrackRepository, CManage.TrackRepository>();

            // Search
            services.AddSingleton<ISearch.IAlbumRepository, CSearch.AlbumRepository>();
            services.AddSingleton<ISearch.IArtistRepository, CSearch.ArtistRepository>();
            services.AddSingleton<ISearch.IGenreRepository, CSearch.GenreRepository>();
            services.AddSingleton<ISearch.ITrackRepository, CSearch.TrackRepository>();

            // Aggregate
            services.AddSingleton<IAggregate.ITrackRepository, CAggregate.TrackRepository>();

            return services;
        }
    }
}
