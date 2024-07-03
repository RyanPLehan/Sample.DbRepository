using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Artists.Requests
{
    public class FindByArtists : IRequest<IEnumerable<Artist>>
    {
        public IEnumerable<int> ArtistIds { get; set; }
    }
}
