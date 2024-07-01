using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> Get(int skip, int take);
        Task<IEnumerable<Album>> FindByArtist(int artistId);
        Task<IEnumerable<Album>> FindByTitle(string title);
    }
}
