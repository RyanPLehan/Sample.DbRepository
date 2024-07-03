using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Artists.Requests
{
    public class FindByArtist : IRequest<Artist>
    {
        public int ArtistId { get; set; }
    }
}
