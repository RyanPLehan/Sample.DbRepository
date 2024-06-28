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
    internal sealed class WordCategoryRepository : IWordCategoryRepository
    {
        private readonly IContextFactory<OrdersContext> _contextFactory;

        public WordCategoryRepository(IContextFactory<OrdersContext> contextFactory)
        {
            _contextFactory = contextFactory ??
                throw new ArgumentNullException(nameof(contextFactory));
        }

        /// <summary>
        /// This one is straight forward such that only choose those Word ids that match
        /// </summary>
        /// <param name="categoryTypeIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<int>> GetByCategoryTypeInclude(IEnumerable<int> categoryTypeIds)
        {
            IEnumerable<int> entities = Enumerable.Empty<int>();
            using (var context = _contextFactory.CreateQueyContext())
            {
                entities = await context.WordCategories
                                        .Where(x => categoryTypeIds.Contains(x.CategoryTypeId))
                                        .Select(x => x.WordId)
                                        .Distinct()
                                        .OrderBy(x => x)
                                        .ToArrayAsync();
            }

            return entities;
        }


        /// <summary>
        /// This one is not straight forward b/c not all Words are categorized.
        /// Therefore, need to do a left join to 
        /// </summary>
        /// <param name="categoryTypeIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<int>> GetByCategoryTypeExclude(IEnumerable<int> categoryTypeIds)
        {
            IEnumerable<int> entities = Enumerable.Empty<int>();
            using (var context = _contextFactory.CreateQueyContext())
            {
                // This query is equvilant to
                // SELECT   id
                // FROM     Words 
                // WHERE    NOT ID IN
                //  (
                //      SELECT  WordID
                //      FROM    WordCategory
                //      WHERE   CategoryTypeID IN (<some number list>)
                //  )
                entities = await (
                            from w in context.Words
                            where !(
                                        from wc in context.WordCategories
                                        where categoryTypeIds.Contains(wc.CategoryTypeId)
                                        select wc.WordId
                                    ).Contains(w.Id)
                            select w.Id
                            )
                            .ToArrayAsync();

                /*
                // This query will work if a word does not have a category or only has a single category
                // But, this query will not work if a word has multiple categories
                // SELECT   w.id
                // FROM     Words w
                // LEFT JOIN WordCategory wc ON
                //      w.Id = wc.WordId
                // WHERE    NOT  wc.CategoryTypeID IN (<some number list>)
                entities = await (
                            from w in context.Words
                            join wc in context.WordCategories on
                                w.Id equals wc.WordId into lj
                            from ljResult in lj.DefaultIfEmpty()
                            where !categoryTypeIds.Contains(ljResult.CategoryTypeId)
                            orderby w.Id
                            select w.Id
                            )
                            .Distinct()
                            .ToArrayAsync();


                // Since not all words have a category, this query does not include them
                entities = await context.WordCategories
                                    .Where(x => !categoryTypeIds.Contains(x.CategoryTypeId))
                                    .Select(x => x.WordId)
                                    .OrderBy(x => x)
                                    .ToArrayAsync();
                */
            }

            return entities;
        }
    }
}
