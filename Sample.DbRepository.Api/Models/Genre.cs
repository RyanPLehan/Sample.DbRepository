namespace Sample.DbRepository.Api.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Tracks { get; set; } = 0;
    }
}
