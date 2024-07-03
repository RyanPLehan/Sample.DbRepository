using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation
{
    public interface ITrackRepository
    {
        Task<IEnumerable<AlbumStatistic>> CalcStatisticByAlbum(IEnumerable<int> albumIds);
    }
}
