using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Models;

namespace Sample.DbRepository.Domain.Management
{
    public interface IGenreRepository
    {
        Task<Genre> Add(Genre entity);
        Task Delete(int id);
        Task<Genre> Get(int id);
        Task<Genre> GetForUpdate(int id);
        Task<Genre> Update(Genre entity);
    }
}
