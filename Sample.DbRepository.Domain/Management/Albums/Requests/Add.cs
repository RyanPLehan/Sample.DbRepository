using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Models;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class Add : IRequest<Album>
    {
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }
}
