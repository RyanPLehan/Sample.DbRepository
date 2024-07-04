using System;
using MediatR;

namespace Sample.DbRepository.Domain.Manage.Tracks.Requests
{
    public class DeleteByAlbum : IRequest<Unit>
    {
        public int AlbumId { get; set; }
    }
}
