using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Tracks.Requests
{
    public class Update : IRequest<Track>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
    }
}
