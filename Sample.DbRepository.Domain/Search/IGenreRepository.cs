using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> Get(int skip, int take);
        Task<IEnumerable<Genre>> FindByName(string name);
    }
}
