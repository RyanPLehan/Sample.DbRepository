using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Infrastructure;
using Sample.DbRepository.Domain.Aggregation;
using Sample.DbRepository.Domain.Aggregation.Models;
using Sample.DbRepository.Infrastructure.Contexts.Aggregation;

namespace Sample.DbRepository.Infrastructure.Repositories.Aggregation
{
    internal sealed class ArtistRepository : IArtistRepository
    {
        private readonly IContextFactory<AggregationContext> _contextFactory;

        public ArtistRepository(IContextFactory<AggregationContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }


        public async Task<int> GetCount()
        {
            int value = 0;
            using (var context = _contextFactory.CreateQueyContext())
            {
                value = await context.Artists
                                     .CountAsync();
            }

            return value;
        }

    }
}
