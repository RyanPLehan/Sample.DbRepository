using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Requests
{
    public class FindByArtists : IRequest<IEnumerable<AlbumArtist>>
    {
        public IEnumerable<int> ArtistIds { get; set; }
    }
}
