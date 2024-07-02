using System;

namespace Sample.DbRepository.Domain.Aggregation.Models
{
    public class Track
    {
        public int Id { get; set; }
        public int? AlbumId {  get; set; }
        public int? GenreId { get; set; }
        public int Milliseconds { get; set; } = 0;
        public int? Bytes { get; set; } = 0;
    }
}
