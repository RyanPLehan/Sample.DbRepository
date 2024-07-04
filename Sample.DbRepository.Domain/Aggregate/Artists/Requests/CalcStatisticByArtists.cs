using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Aggregate.Models;

namespace Sample.DbRepository.Domain.Aggregate.Artists.Requests
{
    public class CalcStatisticByArtists : IRequest<IEnumerable<ArtistStatistic>>
    {
        public IEnumerable<int> ArtistIds { get; set; }
    }
}
