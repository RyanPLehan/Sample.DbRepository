using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Sample.DbRepository.Domain.Management;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Management
{
    internal sealed class GenreRepository : IGenreRepository
    {
        private const string CACHE_KEY = "Management_GenreRepository";
        private const int DEFAULT_EXPIRATION_TIME_IN_SECONDS = 60 * 15;      // 15 minutes
        private static MemoryCacheEntryOptions DefaultCacheEntryOptions = null;

        private readonly IMemoryCache _cache;
        private readonly IContextFactory<ManagementContext> _contextFactory;

        public GenreRepository(IContextFactory<ManagementContext> contextFactory,
                               IMemoryCache cache)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));
            ArgumentNullException.ThrowIfNull(cache, nameof(cache));

            _contextFactory = contextFactory;
            _cache = cache;
            if (DefaultCacheEntryOptions == null)
                DefaultCacheEntryOptions = CreateMemoryCacheEntryOptions(DEFAULT_EXPIRATION_TIME_IN_SECONDS);
        }

        public async Task<Genre> Add(Genre entity)
        {
            using (var context = _contextFactory.CreateCommandContext())
            {
                context.Add(entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }


        public async Task Delete(int id)
        {
            using (var context = _contextFactory.CreateCommandContext())
            {
                var entity = await context.Genres
                                          .Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();

                if (entity != null)
                {
                    context.Remove(entity);
                    await context.SaveChangesAsync();
                    RemoveCacheEntry(CACHE_KEY);
                }
            }
        }

        public async Task<Genre> Get(int id)
        {
            var entities = await GetAll();      // cached entries
            return entities.Where(x => x.Id == id)
                           .FirstOrDefault();
        }

        public async Task<Genre> GetForUpdate(int id)
        {
            Genre? entity = null;
            using (var context = _contextFactory.CreateCommandContext())
            {
                entity = await context.Genres
                                      .Where(x => x.Id == id)
                                      .FirstOrDefaultAsync();
            }

            return entity;
        }


        public async Task<Genre> Update(Genre entity)
        {
            using (var context = _contextFactory.CreateCommandContext())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            }

            RemoveCacheEntry(CACHE_KEY);
            return entity;
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
