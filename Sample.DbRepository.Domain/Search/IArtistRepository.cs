using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAll(int skip, int take);
        Task<Artist> FindByArtist(int artistId);
        Task<IEnumerable<Artist>> FindByArtist(IEnumerable<int> artistId);
        Task<IEnumerable<Artist>> FindByName(string name);
    }
}
