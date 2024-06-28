using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Domain.Search;
using Sample.DbRepository.Infrastructure.Contexts;

namespace Sample.DbRepository.Infrastructure.Repositories.Search
{
    internal sealed class WordRepository : IWordRepository
    {
        private readonly IContextFactory<OrdersContext> _contextFactory;

        public WordRepository(IContextFactory<OrdersContext> contextFactory)
        {
            _contextFactory = contextFactory ??
                throw new ArgumentNullException(nameof(contextFactory));
        }



        public async Task<IEnumerable<Word>> Get(IEnumerable<int> ids)
        {
            IEnumerable<Word> entities = Enumerable.Empty<Word>();
            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Words
                                        .Where(x => ids.Contains(x.Id))
                                        .OrderBy(x => x.Id)
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<int>> GetByLength(int length)
        {
            IEnumerable<int> entities = Enumerable.Empty<int>();
            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Words
                                        .Where(x => x.Length == length)
                                        .Select(x => x.Id)
                                        .OrderBy(x => x)
                                        .Distinct()
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<int>> GetByLength(int minLength, int maxLength)
        {
            IEnumerable<int> entities = Enumerable.Empty<int>();
            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Words
                                        .Where(x => x.Length >= minLength &&
                                                    x.Length <= maxLength)
                                        .Select(x => x.Id)
                                        .OrderBy(x => x)
                                        .Distinct()
                                        .ToArrayAsync();
            }

            return entities;
        }
    }
}
