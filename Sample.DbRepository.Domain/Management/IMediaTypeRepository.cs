using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management
{
    public interface IMediaTypeRepository
    {
        Task<MediaType> Add(MediaType entity);
        Task Delete(int id);
        Task<MediaType> Get(int id);
        Task<MediaType> GetForUpdate(int id);
        Task<MediaType> Update(MediaType entity);
    }
}
