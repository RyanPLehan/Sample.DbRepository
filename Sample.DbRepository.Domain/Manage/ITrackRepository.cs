using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage
{
    public interface ITrackRepository
    {
        Task<Track> Add(Track entity);
        Task Delete(int id);
        Task Delete(IEnumerable<int> ids);
        Task<Track> Get(int id);
        Task<Track> GetForUpdate(int id);
        Task<Track> Update(Track entity);
    }
}
