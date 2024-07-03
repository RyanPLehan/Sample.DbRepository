using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Models;
using Sample.DbRepository.Domain.Aggregation.Albums.Requests;

namespace Sample.DbRepository.Domain.Aggregation.Albums.Handlers
{
    internal class CalcStatisticByAlbumsHandler : IRequestHandler<CalcStatisticByAlbums, IEnumerable<AlbumStatistic>>
    {
        private readonly ITrackRepository _repository;

        public CalcStatisticByAlbumsHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumStatistic>> Handle(CalcStatisticByAlbums request, CancellationToken cancellationToken)
        {
            return await _repository.CalcStatisticByAlbum(request.AlbumIds);
        }
    }
}
