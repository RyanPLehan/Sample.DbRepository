using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Requests
{
    public class FindByAlbums : IRequest<IEnumerable<AlbumArtist>>
    {
        public IEnumerable<int> AlbumIds { get; set; }
    }
}
