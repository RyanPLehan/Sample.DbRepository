using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Requests
{
    public class Get : IRequest<IEnumerable<Album>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
