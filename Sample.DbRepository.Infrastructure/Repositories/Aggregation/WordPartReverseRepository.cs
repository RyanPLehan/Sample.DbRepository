using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Caching.Memory;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Domain.Aggregation;
using Sample.DbRepository.Infrastructure.Contexts.Management;

namespace Sample.DbRepository.Infrastructure.Repositories.Aggregation
{
    internal class WordPartReverseRepository : IWordPartReverseRepository
    {
        private const string CACHE_KEY_PREFIX = "WordPartReverseAggregation";
        private const int DEFAULT_EXPIRATION_TIME_IN_SECONDS = 60 * 15;      // 15 minutes
        private static MemoryCacheEntryOptions DefaultCacheEntryOptions = null;

        private readonly IMemoryCache _cache;
        private readonly IContextFactory<ManagementContext> _contextFactory;

        public WordPartReverseRepository(IMemoryCache cache,
                                         IContextFactory<ManagementContext> contextFactory)
        {
            _cache = cache ??
                throw new ArgumentNullException(nameof(cache));

            _contextFactory = contextFactory ??
                throw new ArgumentNullException(nameof(contextFactory));

            if (DefaultCacheEntryOptions == null)
                DefaultCacheEntryOptions = CreateMemoryCacheEntryOptions(DEFAULT_EXPIRATION_TIME_IN_SECONDS);
        }

        public async Task<IDictionary<char, int>> GetCountByCharacter()
        {
            string cacheKey = CreateCacheKey("CountByCharacter");
            IDictionary<char, int> statistic = new Dictionary<char, int>();

            if (!_cache.TryGetValue<IDictionary<char, int>>(cacheKey, out statistic))
            {
                using (var context = _contextFactory.CreateQueyContext())
                {
                    var query = from w in context.WordPartReverses
                                group w by w.Character into g
                                select new { key = g.Key, value = g.Count() };

                    statistic = await query.ToDictionaryAsync(x => x.key, x => x.value);
                }

                _cache.Set<IDictionary<char, int>>(cacheKey, statistic, DefaultCacheEntryOptions);
            }

            return statistic;
        }

        private MemoryCacheEntryOptions CreateMemoryCacheEntryOptions(int entryExpirationInSeconds)
        {
            return new MemoryCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromSeconds(entryExpirationInSeconds),
            };
        }

        private string CreateCacheKey(string key)
        {
            return string.Format("{0}_{1}", CACHE_KEY_PREFIX, key);
        }
    }
}
