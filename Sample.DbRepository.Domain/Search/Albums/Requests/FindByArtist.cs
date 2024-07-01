using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Requests
{
    public class FindByArtist : IRequest<IEnumerable<Album>>
    {
        public int ArtistId { get; set; }
    }
}
