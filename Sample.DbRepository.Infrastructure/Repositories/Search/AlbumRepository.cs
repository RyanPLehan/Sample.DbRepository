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
    internal sealed class AlbumRepository : IAlbumRepository
    {
        private readonly IContextFactory<SearchContext> _contextFactory;

        public AlbumRepository(IContextFactory<SearchContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }



        public async Task<IEnumerable<Album>> Get(int skip, int take)
        {
            IEnumerable<Album> entities = Enumerable.Empty<Album>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Albums
                                        .Skip(skip)
                                        .Take(take)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<Album>> FindByArtist(int artistId)
        {
            IEnumerable<Album> entities = Enumerable.Empty<Album>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Albums
                                        .Where(x => x.ArtistId == artistId)
                                        .ToArrayAsync();
            }

            return entities;
        }


        public async Task<IEnumerable<Album>> FindByTitle(string title)
        {
            IEnumerable<Album> entities = Enumerable.Empty<Album>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Albums
                                        .Where(x => x.Title.Contains(title))
                                        .ToArrayAsync();
            }

            return entities;
        }
    }
}
