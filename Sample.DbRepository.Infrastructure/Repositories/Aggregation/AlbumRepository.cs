using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Domain.Aggregation;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Aggregation
{
    internal sealed class AlbumRepository : IAlbumRepository
    {
        private readonly IContextFactory<AggregationContext> _contextFactory;

        public AlbumRepository(IContextFactory<AggregationContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }


        public async Task<int> GetCount()
        {
            int value = 0;
            using (var context = _contextFactory.CreateQueyContext())
            {
                value = await context.Albums
                                     .CountAsync();
            }

            return value;
        }


        public async Task<int> GetCount(int artistId)
        {
            int value = 0;
            using (var context = _contextFactory.CreateQueyContext())
            {
                value = await context.Albums
                                     .Where(x => x.ArtistId == artistId)
                                     .CountAsync();
            }

            return value;
        }

        public async Task<IDictionary<int, int>> GetCountByArtist()
        {
            IDictionary<int, int> value = new Dictionary<int, int>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                var query = context.Albums
                                   .GroupBy(t => t.ArtistId)
                                   .Select(g => new { key = g.Key, value = g.Count() });

                value = await query.ToDictionaryAsync(x => x.key, x => x.value);
            }

            return value;
        }
    }
}
