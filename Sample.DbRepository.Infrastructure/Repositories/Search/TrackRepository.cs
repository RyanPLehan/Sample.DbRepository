using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Domain.Search;
using Sample.DbRepository.Domain.Search.Models;
using Sample.DbRepository.Infrastructure.Contexts.Search;

namespace Sample.DbRepository.Infrastructure.Repositories.Search
{
    internal sealed class TrackRepository : ITrackRepository
    {
        private readonly IContextFactory<SearchContext> _contextFactory;

        public TrackRepository(IContextFactory<SearchContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }



        public async Task<IEnumerable<Track>> Get(int skip, int take)
        {
            IEnumerable<Track> entities = Enumerable.Empty<Track>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Skip(skip)
                                        .Take(take)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<Track>> FindByAlbum(int albumId)
        {
            IEnumerable<Track> entities = Enumerable.Empty<Track>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.AlbumId == albumId)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<Track>> FindByAlbum(IEnumerable<int> albumIds)
        {
            IEnumerable<Track> entities = Enumerable.Empty<Track>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => albumIds.Contains(x.AlbumId))
                                        .ToArrayAsync();
            }

            return entities;
        }


        public async Task<IEnumerable<Track>> FindByComposer(string composer)
        {
            IEnumerable<Track> entities = Enumerable.Empty<Track>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.Composer.Contains(composer))
                                        .ToArrayAsync();
            }

            return entities;
        }



        public async Task<IEnumerable<Track>> FindByGenre(int genreId)
        {
            IEnumerable<Track> entities = Enumerable.Empty<Track>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.GenreId == genreId)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<Track>> FindByGenre(IEnumerable<int> genreIds)
        {
            IEnumerable<Track> entities = Enumerable.Empty<Track>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => genreIds.Contains(x.GenreId))
                                        .ToArrayAsync();
            }

            return entities;
        }


        public async Task<IEnumerable<Track>> FindByName(string name)
        {
            IEnumerable<Track> entities = Enumerable.Empty<Track>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Tracks
                                        .Where(x => x.Name.Contains(name))
                                        .ToArrayAsync();
            }

            return entities;
        }
    }
}
