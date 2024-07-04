using System;


namespace Sample.DbRepository.Domain.Aggregate.Models
{
    public class AlbumStatistic
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int NumberOfTracks { get; set; }
        public long PlayTimeInMilliseconds { get; set; }
        public long SizeInBytes { get; set; }
    }
}
