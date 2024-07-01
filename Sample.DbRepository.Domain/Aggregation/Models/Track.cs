using System;

namespace Sample.DbRepository.Domain.Aggregation.Models
{
    public class Track
    {
        public int Id { get; set; }
        public int? AlbumId {  get; set; }
        public int? GenreId { get; set; }
        public int PlayTimeInMilliseconds { get; set; }
        public int SizeInBytes { get; set; } = 0;
    }
}
