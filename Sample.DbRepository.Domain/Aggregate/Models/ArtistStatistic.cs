using System;


namespace Sample.DbRepository.Domain.Aggregate.Models
{
    public class ArtistStatistic
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int NumberOfAlbums { get; set; }
        public int NumberOfTracks { get; set; }
    }
}
