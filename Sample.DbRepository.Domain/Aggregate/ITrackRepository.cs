using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Aggregate.Models;

namespace Sample.DbRepository.Domain.Aggregate
{
    public interface ITrackRepository
    {
        Task<IEnumerable<AlbumStatistic>> CalcStatisticByAlbum(IEnumerable<int> albumIds);
    }
}
