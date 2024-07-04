using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Albums.Requests
{
    public class Add : IRequest<Album>
    {
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }
}
