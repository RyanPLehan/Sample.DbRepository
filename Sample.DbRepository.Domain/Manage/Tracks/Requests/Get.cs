using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Tracks.Requests
{
    public class Get : IRequest<Track>
    {
        public int Id { get; set; }
    }
}
