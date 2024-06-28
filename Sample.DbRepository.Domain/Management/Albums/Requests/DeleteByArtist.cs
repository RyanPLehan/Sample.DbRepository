using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Models;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class DeleteByArtist : IRequest<Unit>
    {
        public int ArtistId { get; set; }
    }
}
