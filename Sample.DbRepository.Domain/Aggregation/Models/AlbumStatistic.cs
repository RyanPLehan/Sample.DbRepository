using System;


namespace Sample.DbRepository.Domain.Aggregation.Models
{
    public class AlbumStatistic
    {
        public int Id { get; set; }
        public int NumberOfTracks { get; set; }
        public long PlayTimeInMilliseconds { get; set; }
        public long SizeInBytes { get; set; }
    }
}
