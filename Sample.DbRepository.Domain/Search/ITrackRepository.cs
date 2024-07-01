using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> Get(int skip, int take);
        Task<IEnumerable<Track>> FindByAlbum(int albumId);
        Task<IEnumerable<Track>> FindByAlbum(IEnumerable<int> albumIds);
        Task<IEnumerable<Track>> FindByComposer(string composer);
        Task<IEnumerable<Track>> FindByGenre(int genreId);
        Task<IEnumerable<Track>> FindByGenre(IEnumerable<int> genreIds);
        Task<IEnumerable<Track>> FindByName(string name);
    }
}
