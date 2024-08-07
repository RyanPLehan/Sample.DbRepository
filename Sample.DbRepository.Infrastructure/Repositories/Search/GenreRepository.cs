﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Sample.DbRepository.Domain.Search;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Search
{
    internal sealed class GenreRepository : IGenreRepository
    {
        private const string CACHE_KEY = "Search_GenreRepository";
        private const int DEFAULT_EXPIRATION_TIME_IN_SECONDS = 60 * 15;      // 15 minutes

        private readonly IMemoryCache _cache;
        private readonly IContextFactory<SearchContext> _contextFactory;

        public GenreRepository(IContextFactory<SearchContext> contextFactory,
                               IMemoryCache cache)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));
            ArgumentNullException.ThrowIfNull(cache, nameof(cache));

            _contextFactory = contextFactory;
            _cache = cache;
        }



        public async Task<IEnumerable<Genre>> GetAll(int skip, int take)
        {
            var entities = await GetFromCache();      // cached entries
            return entities.OrderBy(x => x.Id)
                           .Skip(skip)
                           .Take(take)
                           .ToArray();
        }


        public async Task<Genre> FindByGenre(int genreId)
        {
            var entities = await GetFromCache();      // cached entries
            return entities.Where(x => x.Id == genreId)
                           .FirstOrDefault();
        }

        public async Task<IEnumerable<Genre>> FindByGenre(IEnumerable<int> genreIds)
        {
            var distinctIds = genreIds.Distinct();
            var entities = await GetFromCache();      // cached entries
            return entities.Where(x => distinctIds.Contains(x.Id))
                           .ToArray();
        }


        public async Task<IEnumerable<Genre>> FindByName(string name)
        {
            var entities = await GetFromCache();      // cached entries
            return entities.Where(x => x.Name.Contains(name))
                           .ToArray();
        }


        private async Task<IEnumerable<Genre>> GetFromCache()
        {
            IEnumerable<Genre> entities = Enumerable.Empty<Genre>();

            if (!_cache.TryGetValue<IEnumerable<Genre>>(CACHE_KEY, out entities))
            {
                using (var context = _contextFactory.CreateQueyContext())
                {
                    entities = await context.Genres
                                            .ToArrayAsync();
                }

                _cache.Set<IEnumerable<Genre>>(CACHE_KEY, entities, CreateMemoryCacheEntryOptions(DEFAULT_EXPIRATION_TIME_IN_SECONDS));
            }

            return entities;
        }



        private MemoryCacheEntryOptions CreateMemoryCacheEntryOptions(int entryExpirationInSeconds)
        {
            return new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(entryExpirationInSeconds),
            };
        }

        private void RemoveCacheEntry(string key)
        {
            _cache.Remove(key);
        }
    }
}
