using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Domain.Aggregation;
using Sample.DbRepository.Domain.Aggregation.Models;
using Sample.DbRepository.Domain.Helpers;


namespace Sample.DbRepository.Infrastructure.Repositories.Aggregation
{
    internal sealed class TrackRepository : ITrackRepository
    {
        const int MAX_BATCH_SIZE = 250;
        private readonly IContextFactory<AggregationContext> _contextFactory;

        public TrackRepository(IContextFactory<AggregationContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }


        public async Task<IEnumerable<AlbumStatistic>> CalcStatisticByAlbum(IEnumerable<int> albumIds)
        {
            IEnumerable<AlbumStatistic> entities = Enumerable.Empty<AlbumStatistic>();
            var distinctIds = albumIds.Distinct();

            using (var context = _contextFactory.CreateQueyContext())
            {
                // Using a batching routine to make sure that we don't overload the SQL statement's WHERE IN clause
                entities = await BatchHelper.BatchAsync<int, AlbumStatistic>(MAX_BATCH_SIZE, distinctIds, async batchIds =>
                {
                    var query = from t in context.Tracks
                                where batchIds.Contains(t.AlbumId.Value)
                                group t by t.AlbumId into g
                                select new AlbumStatistic
                                {
                                    AlbumId = g.Key.Value,
                                    NumberOfTracks = g.Count(),
                                    PlayTimeInMilliseconds = g.Sum(x => x.Milliseconds),
                                    SizeInBytes = g.Sum(x => x.Bytes.GetValueOrDefault())
                                };
                    return await query.ToArrayAsync();
                });
            }

            return entities;
        }

    }
}
