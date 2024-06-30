using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Tracks.Requests
{
    public class Fetch : IRequest<Track>
    {
        public int Id { get; set; }
    }
}
