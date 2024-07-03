using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Aggregation.Models;
using Sample.DbRepository.Domain.Aggregation.Artists.Requests;
using AlbumSearch = Sample.DbRepository.Domain.Search.Albums.Requests;
using AlbumAggregation = Sample.DbRepository.Domain.Aggregation.Albums.Requests;
using ArtistSearch = Sample.DbRepository.Domain.Search.Artists.Requests;
using SearchModels = Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Aggregation.Artists.Handlers
{
    internal class CalcStatisticByArtistsHandler : IRequestHandler<CalcStatisticByArtists, IEnumerable<ArtistStatistic>>
    {
        private readonly IMediator _mediator;

        public CalcStatisticByArtistsHandler(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator, nameof(mediator));

            _mediator = mediator;
        }

        public async Task<IEnumerable<ArtistStatistic>> Handle(CalcStatisticByArtists request, CancellationToken cancellationToken)
        {
            // Get Artist detail info
            var artistRequest = new ArtistSearch.FindByArtists() { ArtistIds = request.ArtistIds };
            var artists = await _mediator.Send(artistRequest);

            if (artists == null || !artists.Any())
                return Enumerable.Empty<ArtistStatistic>();


            // *** Need to build Statistic object from various sources ***

            // Find list of albums by artist id
            var albumRequest = new AlbumSearch.FindByArtists() { ArtistIds = request.ArtistIds };
            var albums = await _mediator.Send(albumRequest);

            // Get Album Statistics for all albums
            var albumStatRequest = new AlbumAggregation.CalcStatisticByAlbums() { AlbumIds = albums.Select(x => x.AlbumId).ToArray() };
            var albumStats = await _mediator.Send(albumStatRequest);


            // Time to build object
            return artists.Select(x => new ArtistStatistic
            {
                ArtistId = x.Id,
                Name = x.Name,
                NumberOfAlbums = CalcNumberOfAlbums(x.Id, albums),
                NumberOfTracks = CalcNumberOfTracks(x.Id, albums, albumStats),
            });
        }

        private int CalcNumberOfAlbums(int artistId, IEnumerable<SearchModels.AlbumArtist> albums)
            => albums.Where(a => a.ArtistId == artistId).Count();

        private int CalcNumberOfTracks(int artistId, IEnumerable<SearchModels.AlbumArtist> albums, IEnumerable<AlbumStatistic> albumStats)
        {
            var albumIds = albums.Where(a => a.ArtistId == artistId).Select(a => a.AlbumId);
            return albumStats.Where(a => albumIds.Contains(a.AlbumId)).Sum(a => a.NumberOfTracks);
        }
    }
}
