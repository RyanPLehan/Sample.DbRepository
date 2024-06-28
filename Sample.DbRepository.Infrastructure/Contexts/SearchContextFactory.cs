using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Infrastructure.Configurations;

namespace Sample.DbRepository.Infrastructure.Contexts
{
    public sealed class SearchContextFactory : IContextFactory<SearchContext>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly DatabaseSettings _settings;

        public SearchContextFactory(ILoggerFactory loggerFactory,
                                    IOptions<DatabaseSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(loggerFactory, nameof(loggerFactory));
            ArgumentNullException.ThrowIfNull(settings?.Value, nameof(settings));

            _loggerFactory = loggerFactory;
            _settings = settings.Value;
        }

        public SearchContext CreateCommandContext()
        {
            throw new NotImplementedException("Cannot create a command context");
        }

        public SearchContext CreateQueyContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SearchContext>()
                                            .UseLoggerFactory(_loggerFactory)
                                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                                            .UseSqlite(BuildConnectionString(), AddDatabaseOptions);

            return new SearchContext(optionsBuilder.Options);
        }

        /// <summary>
        /// Build Sqlite Connection string
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// See: https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings
        /// See: https://www.sqlite.org/wal.html
        /// </remarks>
        private string BuildConnectionString()
        {
            return new SqliteConnectionStringBuilder()
            {
                Mode = SqliteOpenMode.ReadWrite,
                DataSource = Path.Combine(_settings.Path, _settings.DatabaseName),
                Pooling = true,
                DefaultTimeout = 30,
                Cache = SqliteCacheMode.Shared,         // Do NOT use with Write-Ahead Logging
            }.ToString();
        }

        private void AddDatabaseOptions(SqliteDbContextOptionsBuilder builder)
        {
            builder.CommandTimeout(60)
                   .UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
        }
    }
}
