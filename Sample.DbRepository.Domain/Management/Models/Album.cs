using System;


namespace Sample.DbRepository.Domain.Management.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public IEnumerable<Track> Tracks { get; set; } = Enumerable.Empty<Track>();
    }
}
