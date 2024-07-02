using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Domain.Search;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Search
{
    internal sealed class ArtistRepository : IArtistRepository
    {
        private readonly IContextFactory<SearchContext> _contextFactory;

        public ArtistRepository(IContextFactory<SearchContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }



        public async Task<IEnumerable<Artist>> Get(int skip, int take)
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
