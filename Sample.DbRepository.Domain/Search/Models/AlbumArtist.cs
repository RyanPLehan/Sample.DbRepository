using System;


namespace Sample.DbRepository.Domain.Search.Models
{
    public class AlbumArtist
    {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
}
