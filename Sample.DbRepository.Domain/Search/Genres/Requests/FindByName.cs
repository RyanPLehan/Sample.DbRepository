using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Genres.Requests
{
    public class FindByName : IRequest<IEnumerable<Genre>>
    {
        public string Name { get; set; }
    }
}
