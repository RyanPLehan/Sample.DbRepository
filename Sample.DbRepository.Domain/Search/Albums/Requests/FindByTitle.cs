using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Requests
{
    public class FindByName : IRequest<IEnumerable<Album>>
    {
        public string Title { get; set; }
    }
}
