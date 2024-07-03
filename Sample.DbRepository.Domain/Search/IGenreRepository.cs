using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAll(int skip, int take);
        Task<Genre> FindByGenre(int genreId);
        Task<IEnumerable<Genre>> FindByGenre(IEnumerable<int> genreIds);
        Task<IEnumerable<Genre>> FindByName(string name);
    }
}
