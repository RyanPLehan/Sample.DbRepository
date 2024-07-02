namespace Sample.DbRepository.Api.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string Artist { get; set; }
        public int Tracks { get; set; } = 0;
        public long PlayTimeInMilliseconds { get; set; }
        public long SizeInBytes { get; set; }
    }
}
