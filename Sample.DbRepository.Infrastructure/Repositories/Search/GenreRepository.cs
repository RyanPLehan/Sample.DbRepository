using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Domain.Search;
using Sample.DbRepository.Domain.Search.Models;
using Sample.DbRepository.Infrastructure.Contexts.Search;

namespace Sample.DbRepository.Infrastructure.Repositories.Search
{
    internal sealed class GenreRepository : IGenreRepository
    {
        private const string CACHE_KEY = "Search_GenreRepository";
        private const int DEFAULT_EXPIRATION_TIME_IN_SECONDS = 60 * 15;      // 15 minutes
        private static MemoryCacheEntryOptions DefaultCacheEntryOptions = null;

        private readonly IMemoryCache _cache;
        private readonly IContextFactory<SearchContext> _contextFactory;

        public GenreRepository(IContextFactory<SearchContext> contextFactory,
                               IMemoryCache cache)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));
            ArgumentNullException.ThrowIfNull(cache, nameof(cache));

            _contextFactory = contextFactory;
            _cache = cache;
            if (DefaultCacheEntryOptions == null)
                DefaultCacheEntryOptions = CreateMemoryCacheEntryOptions(DEFAULT_EXPIRATION_TIME_IN_SECONDS);
        }



        public async Task<IEnumerable<Genre>> Get(int skip, int take)
        {
            var entities = await GetAll();      // cached entries
            return entities.Skip(skip)
                           .Take(take)
                           .ToArray();
        }


        public async Task<IEnumerable<Genre>> FindByName(string name)
        {
            var entities = await GetAll();      // cached entries
            return entities.Where(x => x.Name.Contains(name))
                           .ToArray();
        }


        private async Task<IEnumerable<Genre>> GetAll()
        {
            IEnumerable<Genre> entities = Enumerable.Empty<Genre>();

            if (!_cache.TryGetValue<IEnumerable<Genre>>(CACHE_KEY, out entities))
            {
                using (var context = _contextFactory.CreateQueyContext())
                {
                    entities = await context.Genres
                                            .ToArrayAsync();
                }

                _cache.Set<IEnumerable<Genre>>(CACHE_KEY, entities, DefaultCacheEntryOptions);
            }

            return entities;
        }



        private MemoryCacheEntryOptions CreateMemoryCacheEntryOptions(int entryExpirationInSeconds)
        {
            return new MemoryCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromSeconds(entryExpirationInSeconds),
            };
        }

        private void RemoveCacheEntry(string key)
        {
            _cache.Remove(key);
        }
    }
}
