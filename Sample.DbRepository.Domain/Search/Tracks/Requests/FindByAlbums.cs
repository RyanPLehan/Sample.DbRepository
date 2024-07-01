using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Requests
{
    public class FindByAlbums : IRequest<IEnumerable<Track>>
    {
        public IEnumerable<int> AlbumIds { get; set; }
    }
}
