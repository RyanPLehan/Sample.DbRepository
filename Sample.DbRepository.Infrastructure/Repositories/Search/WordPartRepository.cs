using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Domain.Search;
using Sample.DbRepository.Infrastructure.Contexts;

namespace Sample.DbRepository.Infrastructure.Repositories.Search
{
    internal sealed class WordPartRepository : IWordPartRepository
    {
        private readonly IContextFactory<OrdersContext> _contextFactory;

        public WordPartRepository(IContextFactory<OrdersContext> contextFactory)
        {
            _contextFactory = contextFactory ??
                throw new ArgumentNullException(nameof(contextFactory));
        }


        public async Task<IEnumerable<int>> Get(int position, char character)
        {
            IEnumerable<int> entities = Enumerable.Empty<int>();
            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.WordParts
                                        .Where(x => x.Position == position &&
                                                    x.Character == character)
                                        .Select(x => x.WordId)
                                        .OrderBy(x => x)
                                        .Distinct()
                                        .ToArrayAsync();
            }

            return entities;
        }

        public async Task<IEnumerable<int>> GetIntersection(int[] positions, char[] characters)
        {
            IEnumerable<int> entities = Enumerable.Empty<int>();

            string sql = CreateSqlForIntersect(positions, characters);
            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.Database
                                        .SqlQueryRaw<int>(sql)
                                        .ToArrayAsync();
            }

            return entities;
        }

        private string CreateSqlForIntersect(int[] positions, char[] characters)
        {
            StringBuilder sql = new StringBuilder();
            int maxSize = positions.Length;

            for (int i = 0; i < maxSize; i++)
            {
                sql.AppendFormat("SELECT WordId FROM WordPart WHERE Position = {0} AND Character = '{1}'", positions[i], characters[i]);

                if (i < maxSize - 1)
                {
                    sql.AppendLine();
                    sql.Append("INTERSECT");
                    sql.AppendLine();
                }
            }

            return sql.ToString();
        }
    }
}
