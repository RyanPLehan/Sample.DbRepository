using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Aggregate.Models;
using Sample.DbRepository.Domain.Aggregate.Artists.Requests;
using AlbumSearch = Sample.DbRepository.Domain.Search.Albums.Requests;
using AlbumAggregate = Sample.DbRepository.Domain.Aggregate.Albums.Requests;
using ArtistSearch = Sample.DbRepository.Domain.Search.Artists.Requests;
using SearchModels = Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Aggregate.Artists.Handlers
{
    internal class CalcStatisticByArtistHandler : IRequestHandler<CalcStatisticByArtist, ArtistStatistic>
    {
        private readonly IMediator _mediator;

        public CalcStatisticByArtistHandler(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator, nameof(mediator));

            _mediator = mediator;
        }

        public async Task<ArtistStatistic> Handle(CalcStatisticByArtist request, CancellationToken cancellationToken)
        {
            // Get Artist detail info
            var artistRequest = new ArtistSearch.FindByArtist() { ArtistId = request.ArtistId };
            var artist = await _mediator.Send(artistRequest);

            if (artist == null)
                return null;


            // *** Need to build Statistic object from various sources ***

            // Find list of albums by artist id
            var albumRequest = new AlbumSearch.FindByArtist() { ArtistId = request.ArtistId };
            var albums = await _mediator.Send(albumRequest);

            // Get Album Statistics for all albums
            var albumStatRequest = new AlbumAggregate.CalcStatisticByAlbums() { AlbumIds = albums.Select(x => x.AlbumId).ToArray() };
            var albumStats = await _mediator.Send(albumStatRequest);


            // Time to build object
            return new ArtistStatistic()
            {
                ArtistId = artist.Id,
                Name = artist.Name,
                NumberOfAlbums = albums.Count(),
                NumberOfTracks = albumStats.Sum(x => x.NumberOfTracks),
            };
        }
    }
}
