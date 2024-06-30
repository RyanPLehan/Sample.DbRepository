using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Tracks.Requests
{
    public class Add : IRequest<Track>
    {
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }
}
