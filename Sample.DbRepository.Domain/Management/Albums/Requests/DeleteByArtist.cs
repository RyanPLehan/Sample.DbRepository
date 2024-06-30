using System;
using MediatR;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class DeleteByArtist : IRequest<Unit>
    {
        public int ArtistId { get; set; }
    }
}
