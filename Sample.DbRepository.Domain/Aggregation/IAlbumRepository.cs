using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation
{
    public interface IAlbumRepository
    {
        Task<int> GetCount();
        Task<int> GetCount(int artistId);
        Task<IDictionary<int, int>> GetCountByArtist();
    }
}
