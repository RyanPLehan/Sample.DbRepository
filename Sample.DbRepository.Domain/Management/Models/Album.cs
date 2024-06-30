using System;


namespace Sample.DbRepository.Domain.Management.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }
}
