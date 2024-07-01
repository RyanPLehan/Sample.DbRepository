using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Requests
{
    public class FindByComposer : IRequest<IEnumerable<Track>>
    {
        public string Composer { get; set; }
    }
}
