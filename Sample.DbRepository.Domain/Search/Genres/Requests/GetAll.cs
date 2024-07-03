using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Genres.Requests
{
    public class GetAll : IRequest<IEnumerable<Genre>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
