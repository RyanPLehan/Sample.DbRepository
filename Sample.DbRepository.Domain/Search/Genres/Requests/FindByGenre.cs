using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Genres.Requests
{
    public class FindByGenre : IRequest<Genre>
    {
        public int GenreId { get; set; }
    }
}
