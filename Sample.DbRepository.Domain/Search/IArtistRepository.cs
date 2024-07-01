using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> Get(int skip, int take);
        Task<IEnumerable<Artist>> FindByName(string name);
    }
}
