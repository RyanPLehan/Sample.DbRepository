using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Requests
{
    public class FindByGenre : IRequest<IEnumerable<AlbumTrack>>
    {
        public int GenreId { get; set; }
    }
}
