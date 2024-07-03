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
    internal sealed class ArtistRepository : IArtistRepository
    {
        const int MAX_BATCH_SIZE = 250;
        private readonly IContextFactory<SearchContext> _contextFactory;

        public ArtistRepository(IContextFactory<SearchContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }



        public async Task<IEnumerable<Artist>> GetAll(int skip, int take)
        {
            IEnumerable<Artist> entities = Enumerable.Empty<Artist>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Artists
                                        .OrderBy(x => x.Id)
                                        .Skip(skip)
                                        .Take(take)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<Artist> FindByArtist(int artistId)
        {
            Artist entity = null;

            using (var context = _contextFactory.CreateQueyContext())
            {
                entity = await context.Artists
                                      .Where(x => x.Id == artistId)
                                      .FirstOrDefaultAsync();
            }

            return entity;
        }

        public async Task<IEnumerable<Artist>> FindByArtist(IEnumerable<int> artistIds)
        {
            IEnumerable<Artist> entities = Enumerable.Empty<Artist>();
            var distinctIds = artistIds.Distinct();

            using (var context = _contextFactory.CreateQueyContext())
            {
                // Using a batching routine to make sure that we don't overload the SQL statement's WHERE IN clause
                entities = await BatchHelper.BatchAsync<int, Artist>(MAX_BATCH_SIZE, distinctIds, async batchIds =>
                {
                    return await context.Artists
                                        .Where(x => batchIds.Contains(x.Id))
                                        .ToArrayAsync();
                });
            }

            return entities;
        }


        public async Task<IEnumerable<Artist>> FindByName(string name)
        {
            IEnumerable<Artist> entities = Enumerable.Empty<Artist>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Artists
                                        .Where(x => x.Name.Contains(name))
                                        .ToArrayAsync();
            }

            return entities;
        }
    }
}
