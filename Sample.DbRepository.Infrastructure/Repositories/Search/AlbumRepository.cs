using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Search;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Search
{
    internal sealed class AlbumRepository : IAlbumRepository
    {
        const int MAX_BATCH_SIZE = 250;
        private readonly IContextFactory<SearchContext> _contextFactory;

        public AlbumRepository(IContextFactory<SearchContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }


        public async Task<IEnumerable<AlbumArtist>> GetAll(int skip, int take)
        {
            IEnumerable<AlbumArtist> entities = Enumerable.Empty<AlbumArtist>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Albums
                                        .OrderBy(x => x.AlbumId)
                                        .Skip(skip)
                                        .Take(take)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<AlbumArtist> FindByAlbum(int albumId)
        {
            AlbumArtist entity = null;

            using (var context = _contextFactory.CreateQueyContext())
            {
                entity = await context.Albums
                                      .Where(x => x.ArtistId == albumId)
                                      .FirstOrDefaultAsync();
            }

            return entity;
        }

        public async Task<IEnumerable<AlbumArtist>> FindByAlbum(IEnumerable<int> albumIds)
        {
            IEnumerable<AlbumArtist> entities = Enumerable.Empty<AlbumArtist>();
            var distinctIds = albumIds.Distinct();

            using (var context = _contextFactory.CreateQueyContext())
            {
                // Using a batching routine to make sure that we don't overload the SQL statement's WHERE IN clause
                entities = await BatchHelper.BatchAsync<int, AlbumArtist>(MAX_BATCH_SIZE, distinctIds, async batchIds =>
                {
                    return await context.Albums
                                        .Where(x => batchIds.Contains(x.AlbumId))
                                        .ToArrayAsync();
                });
            }

            return entities;
        }


        public async Task<IEnumerable<AlbumArtist>> FindByAlbumTitle(string title)
        {
            IEnumerable<AlbumArtist> entities = Enumerable.Empty<AlbumArtist>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Albums
                                        .Where(x => x.AlbumTitle.Contains(title))
                                        .ToArrayAsync();
            }

            return entities;
        }


        public async Task<IEnumerable<AlbumArtist>> FindByArtist(int artistId)
        {
            IEnumerable<AlbumArtist> entities = Enumerable.Empty<AlbumArtist>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Albums
                                        .Where(x => x.ArtistId == artistId)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<AlbumArtist>> FindByArtist(IEnumerable<int> artistIds)
        {
            IEnumerable<AlbumArtist> entities = Enumerable.Empty<AlbumArtist>();
            var distinctIds = artistIds.Distinct();

            using (var context = _contextFactory.CreateQueyContext())
            {
                // Using a batching routine to make sure that we don't overload the SQL statement's WHERE IN clause
                entities = await BatchHelper.BatchAsync<int, AlbumArtist>(MAX_BATCH_SIZE, distinctIds, async batchIds =>
                {
                    return await context.Albums
                                        .Where(x => batchIds.Contains(x.ArtistId))
                                        .ToArrayAsync();
                });
            }

            return entities;
        }




        public async Task<IEnumerable<AlbumArtist>> FindByArtistName(string artistName)
        {
            IEnumerable<AlbumArtist> entities = Enumerable.Empty<AlbumArtist>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Albums
                                        .Where(x => x.ArtistName.Contains(artistName))
                                        .ToArrayAsync();
            }

            return entities;
        }

    }
}
