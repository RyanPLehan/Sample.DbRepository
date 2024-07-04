using System;
using MediatR;

namespace Sample.DbRepository.Domain.Manage.Albums.Requests
{
    public class DeleteByArtist : IRequest<Unit>
    {
        public int ArtistId { get; set; }
    }
}
