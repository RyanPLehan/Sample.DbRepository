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
    internal sealed class TrackRepository : ITrackRepository
    {
        const int MAX_BATCH_SIZE = 250;
        private readonly IContextFactory<SearchContext> _contextFactory;

        public TrackRepository(IContextFactory<SearchContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<AlbumTrack>> GetAll(int skip, int take)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .OrderBy(x => x.TrackId)
                                        .Skip(skip)
                                        .Take(take)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<AlbumTrack> FindByTrack(int trackId)
        {
            AlbumTrack entity = null;

            using (var context = _contextFactory.CreateQueyContext())
            {
                entity = await context.Tracks
                                       .Where(x => x.TrackId == trackId)
                                       .FirstOrDefaultAsync();
            }

            return entity;
        }

        public async Task<IEnumerable<AlbumTrack>> FindByTrack(IEnumerable<int> trackIds)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();
            var distinctIds = trackIds.Distinct();

            using (var context = _contextFactory.CreateQueyContext())
            {
                // Using a batching routine to make sure that we don't overload the SQL statement's WHERE IN clause
                entities = await BatchHelper.BatchAsync<int, AlbumTrack>(MAX_BATCH_SIZE, distinctIds, async batchIds =>
                {
                    return await context.Tracks
                                        .Where(x => batchIds.Contains(x.TrackId))
                                        .ToArrayAsync();
                });
            }

            return entities;
        }

        public async Task<IEnumerable<AlbumTrack>> FindByTrackName(string trackName)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.TrackName.Contains(trackName))
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<AlbumTrack>> FindByAlbum(int albumId)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.AlbumId == albumId)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<AlbumTrack>> FindByAlbum(IEnumerable<int> albumIds)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();
            var distinctIds = albumIds.Distinct();

            using (var context = _contextFactory.CreateQueyContext())
            {
                // Using a batching routine to make sure that we don't overload the SQL statement's WHERE IN clause
                entities = await BatchHelper.BatchAsync<int, AlbumTrack>(MAX_BATCH_SIZE, distinctIds, async batchIds =>
                {
                    return await context.Tracks
                                        .Where(x => batchIds.Contains(x.AlbumId))
                                        .ToArrayAsync();
                });
            }

            return entities;
        }

        public async Task<IEnumerable<AlbumTrack>> FindByAlbumTitle(string albumTitle)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.AlbumTitle.Contains(albumTitle))
                                        .ToArrayAsync();
            }

            return entities;
        }


        public async Task<IEnumerable<AlbumTrack>> FindByComposer(string composer)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.Composer.Contains(composer))
                                        .ToArrayAsync();
            }

            return entities;
        }


        public async Task<IEnumerable<AlbumTrack>> FindByGenre(int genreId)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.GenreId == genreId)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<AlbumTrack>> FindByGenre(IEnumerable<int> genreIds)
        {
            IEnumerable<AlbumTrack> entities = Enumerable.Empty<AlbumTrack>();
            var distinctIds = genreIds.Distinct();

            using (var context = _contextFactory.CreateQueyContext())
            {
                // Using a batching routine to make sure that we don't overload the SQL statement's WHERE IN clause
                entities = await BatchHelper.BatchAsync<int, AlbumTrack>(MAX_BATCH_SIZE, distinctIds, async batchIds =>
                {
                    return await context.Tracks
                                        .Where(x => batchIds.Contains(x.GenreId.Value))
                                        .ToArrayAsync();
                });
            }

            return entities;
        }
    }
}
