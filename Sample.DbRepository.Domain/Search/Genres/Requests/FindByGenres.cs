using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Genres.Requests
{
    public class FindByGenres : IRequest<IEnumerable<Genre>>
    {
        public IEnumerable<int> GenreIds { get; set; }
    }
}
