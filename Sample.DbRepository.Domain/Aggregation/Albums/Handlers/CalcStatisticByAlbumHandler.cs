using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Aggregation.Models;
using Sample.DbRepository.Domain.Aggregation.Albums.Requests;
using Sample.DbRepository.Domain.Management.Albums.Requests;

namespace Sample.DbRepository.Domain.Aggregation.Albums.Handlers
{
    internal class CalcStatisticByAlbumHandler : IRequestHandler<CalcStatisticByAlbum, AlbumStatistic>
    {
        private readonly ITrackRepository _repository;

        public CalcStatisticByAlbumHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<AlbumStatistic> Handle(CalcStatisticByAlbum request, CancellationToken cancellationToken)
        {
            var entities = await _repository.CalcStatisticByAlbum(new int[] { request.AlbumId });
            return entities.FirstOrDefault();
        }
    }
}
