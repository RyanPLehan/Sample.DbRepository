using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search
{
    public interface ITrackRepository
    {
        Task<IEnumerable<AlbumTrack>> GetAll(int skip, int take);
        Task<AlbumTrack> FindByTrack(int trackId);
        Task<IEnumerable<AlbumTrack>> FindByTrack(IEnumerable<int> trackIds);
        Task<IEnumerable<AlbumTrack>> FindByTrackName(string trackName);
        Task<IEnumerable<AlbumTrack>> FindByAlbum(int albumId);
        Task<IEnumerable<AlbumTrack>> FindByAlbum(IEnumerable<int> albumIds);
        Task<IEnumerable<AlbumTrack>> FindByAlbumTitle(string albumTitle);
        Task<IEnumerable<AlbumTrack>> FindByComposer(string composer);
        Task<IEnumerable<AlbumTrack>> FindByGenre(int genreId);
        Task<IEnumerable<AlbumTrack>> FindByGenre(IEnumerable<int> genreIds);
    }
}
