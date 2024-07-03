using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<AlbumArtist>> GetAll(int skip, int take);
        Task<AlbumArtist> FindByAlbum(int albumId);
        Task<IEnumerable<AlbumArtist>> FindByAlbum(IEnumerable<int> albumIds);
        Task<IEnumerable<AlbumArtist>> FindByAlbumTitle(string title);
        Task<IEnumerable<AlbumArtist>> FindByArtist(int artistId);
        Task<IEnumerable<AlbumArtist>> FindByArtist(IEnumerable<int> artistId);
        Task<IEnumerable<AlbumArtist>> FindByArtistName(string artistName);
    }
}
