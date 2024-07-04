using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Aggregate.Models;

namespace Sample.DbRepository.Domain.Aggregate.Artists.Requests
{
    public class CalcStatisticByArtist : IRequest<ArtistStatistic>
    {
        public int ArtistId { get; set; }
    }
}
