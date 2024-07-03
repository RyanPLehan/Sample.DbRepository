using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Artists.Requests
{
    public class CalcStatisticByArtists : IRequest<IEnumerable<ArtistStatistic>>
    {
        public IEnumerable<int> ArtistIds { get; set; }
    }
}
