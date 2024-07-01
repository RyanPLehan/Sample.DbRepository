using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Domain.Aggregation;
using Sample.DbRepository.Domain.Aggregation.Models;
using Sample.DbRepository.Infrastructure.Contexts.Aggregation;

namespace Sample.DbRepository.Infrastructure.Repositories.Aggregation
{
    internal sealed class TrackRepository : ITrackRepository
    {
        private readonly IContextFactory<AggregationContext> _contextFactory;

        public TrackRepository(IContextFactory<AggregationContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }


        public async Task<int> GetCount()
        {
            int value = 0;
            using (var context = _contextFactory.CreateQueyContext())
            {
                value = await context.Tracks
                                     .CountAsync();
            }

            return value;
        }


        public async Task<int> GetCount(int albumId)
        {
            int value = 0;
            using (var context = _contextFactory.CreateQueyContext())
            {
                value = await context.Tracks
                                     .Where(x => x.AlbumId == albumId)
                                     .CountAsync();
            }

            return value;
        }

        public async Task<IDictionary<int, int>> GetCountByAlbum()
        {
            IDictionary<int, int> value = new Dictionary<int, int>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                var query = context.Tracks
                                   .Where(t => t.AlbumId != null)
                                   .GroupBy(t => t.AlbumId)
                                   .Select(g => new { key = g.Key, value = g.Count() });

                value = await query.ToDictionaryAsync(x => x.key.Value, x => x.value);
            }

            return value;
        }

        public async Task<IDictionary<int, int>> GetCountByArtist()
        {
            IDictionary<int, int> value = new Dictionary<int, int>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                var query = from t in context.Tracks
                            join a in context.Albums on t.AlbumId equals a.Id
                            join art in context.Artists on a.ArtistId equals art.Id                                
                            where t.AlbumId != null
                            group t by art.Id into g
                            select new { key = g.Key, value = g.Count() };

                value = await query.ToDictionaryAsync(x => x.key, x => x.value);
            }

            return value;
        }

        public async Task<IDictionary<int, int>> GetCountByGenre()
        {
            IDictionary<int, int> value = new Dictionary<int, int>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                var query = context.Tracks
                                   .Where(t => t.GenreId != null)
                                   .GroupBy(t => t.GenreId)
                                   .Select(g => new { key = g.Key, value = g.Count() });

                value = await query.ToDictionaryAsync(x => x.key.Value, x => x.value);
            }

            return value;
        }


        public async Task<long> GetPlayTime(int albumId)
        {
            int value = 0;
            using (var context = _contextFactory.CreateQueyContext())
            {
                value = await context.Tracks
                                     .Where(x => x.AlbumId == albumId)
                                     .SumAsync(x => x.PlayTimeInMilliseconds);
            }

            return value;
        }

        public async Task<IDictionary<int, long>> GetPlayTimeByAlbum()
        {
            IDictionary<int, long> value = new Dictionary<int, long>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                var query = context.Tracks
                                   .Where(t => t.AlbumId != null)
                                   .GroupBy(t => t.AlbumId)
                                   .Select(g => new { key = g.Key, value =g.Sum(s => (long) s.PlayTimeInMilliseconds) });

                value = await query.ToDictionaryAsync(x => x.key.Value, x => x.value);
            }

            return value;
        }


        public async Task<long> GetSize(int albumId)
        {
            int value = 0;
            using (var context = _contextFactory.CreateQueyContext())
            {
                value = await context.Tracks
                                     .Where(x => x.AlbumId == albumId)
                                     .SumAsync(x => x.SizeInBytes);
            }

            return value;
        }

        public async Task<IDictionary<int, long>> GetSizeByAlbum()
        {
            IDictionary<int, long> value = new Dictionary<int, long>();

            using (var context = _contextFactory.CreateQueyContext())
            {
                var query = context.Tracks
                                   .Where(t => t.AlbumId != null)
                                   .GroupBy(t => t.AlbumId)
                                   .Select(g => new { key = g.Key, value = g.Sum(s => (long)s.SizeInBytes) });

                value = await query.ToDictionaryAsync(x => x.key.Value, x => x.value);
            }

            return value;
        }
    }
}
