using System;


namespace Sample.DbRepository.Domain.Search.Models
{
    public class AlbumTrack
    {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int ArtistId { get; set; }


        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int PlayTimeInMilliseconds { get; set; }
        public int? SizeInBytes { get; set; }
    }
}
