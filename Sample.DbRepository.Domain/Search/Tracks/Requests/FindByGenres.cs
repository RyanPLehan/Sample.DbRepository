using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Requests
{
    public class FindByGenres : IRequest<IEnumerable<AlbumTrack>>
    {
        public IEnumerable<int> GenreIds { get; set; }
    }
}
