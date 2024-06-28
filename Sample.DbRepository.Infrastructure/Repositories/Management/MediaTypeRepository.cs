using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Domain.Management;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Infrastructure.Contexts;

namespace Sample.DbRepository.Infrastructure.Repositories.Management
{
    internal sealed class MediaTypeRepository : IMediaTypeRepository
    {
        private const string CACHE_KEY = "MediaTypeRepository";
        private const int DEFAULT_EXPIRATION_TIME_IN_SECONDS = 60 * 15;      // 15 minutes
        private static MemoryCacheEntryOptions DefaultCacheEntryOptions = null;

        private readonly IMemoryCache _cache;
        private readonly IContextFactory<ManagementContext> _contextFactory;

        public MediaTypeRepository(IContextFactory<ManagementContext> contextFactory,
                                   IMemoryCache cache)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));
            ArgumentNullException.ThrowIfNull(cache, nameof(cache));

            _contextFactory = contextFactory;
            _cache = cache;
            if (DefaultCacheEntryOptions == null)
                DefaultCacheEntryOptions = CreateMemoryCacheEntryOptions(DEFAULT_EXPIRATION_TIME_IN_SECONDS);
        }

        public async Task<MediaType> Add(MediaType entity)
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
                var entity = await context.MediaTypes
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

        public async Task<MediaType> Get(int id)
        {
            var entities = await GetAll();      // cached entries
            return entities.Where(x => x.Id == id)
                           .FirstOrDefault();
        }

        public async Task<MediaType> GetForUpdate(int id)
        {
            MediaType? entity = null;
            using (var context = _contextFactory.CreateCommandContext())
            {
                entity = await context.MediaTypes
                                      .Where(x => x.Id == id)
                                      .FirstOrDefaultAsync();
            }

            return entity;
        }


        public async Task<MediaType> Update(MediaType entity)
        {
            using (var context = _contextFactory.CreateCommandContext())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            }

            RemoveCacheEntry(CACHE_KEY);
            return entity;
        }

        private async Task<IEnumerable<MediaType>> GetAll()
        {
            IEnumerable<MediaType> entities = Enumerable.Empty<MediaType>();

            if (!_cache.TryGetValue<IEnumerable<MediaType>>(CACHE_KEY, out entities))
            {
                using (var context = _contextFactory.CreateQueyContext())
                {
                    entities = await context.MediaTypes
                                            .ToArrayAsync();
                }

                _cache.Set<IEnumerable<MediaType>>(CACHE_KEY, entities, DefaultCacheEntryOptions);
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
