using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation
{
    public interface ITrackRepository
    {
        Task<int> GetCount();
        Task<int> GetCount(int albumId);
        Task<AlbumStatistic> GetAlbumStatistic(int albumId);
        Task<IDictionary<int, int>> GetCountByAlbum();
        Task<IDictionary<int, int>> GetCountByArtist();
        Task<IDictionary<int, int>> GetCountByGenre();
    }
}
