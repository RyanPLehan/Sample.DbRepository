
namespace Sample.DbRepository.Api.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
}
