using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Tracks.Requests
{
    public class Update : IRequest<Track>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
