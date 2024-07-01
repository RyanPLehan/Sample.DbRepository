using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Tracks.Requests
{
    public class Get : IRequest<Track>
    {
        public int Id { get; set; }
    }
}
