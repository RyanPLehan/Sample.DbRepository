using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management
{
    public interface IArtistRepository
    {
        Task<Artist> Add(Artist entity);
        Task Delete(int id);
        Task<Artist> Get(int id);
        Task<Artist> GetForUpdate(int id);
        Task<Artist> Update(Artist entity);
    }
}
