using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sample.DbRepository.Infrastructure.Configurations;

namespace Sample.DbRepository.Infrastructure.Repositories.Manage
{
    public sealed class ManageContextFactory : IContextFactory<ManageContext>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly DatabaseSettings _settings;

        public ManageContextFactory(ILoggerFactory loggerFactory,
                                       IOptions<DatabaseSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(loggerFactory, nameof(loggerFactory));
            ArgumentNullException.ThrowIfNull(settings?.Value, nameof(settings));

            _loggerFactory = loggerFactory;
            _settings = settings.Value;
        }

        public ManageContext CreateCommandContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ManageContext>()
                                            .UseLoggerFactory(_loggerFactory)
                                            .UseSqlite(BuildConnectionString(), AddDatabaseOptions);

            return new ManageContext(optionsBuilder.Options);
        }

        public ManageContext CreateQueyContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ManageContext>()
                                            .UseLoggerFactory(_loggerFactory)
                                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                                            .UseSqlite(BuildConnectionString(), AddDatabaseOptions);

            return new ManageContext(optionsBuilder.Options);
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
