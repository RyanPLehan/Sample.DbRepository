using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Aggregate.Models;
using Sample.DbRepository.Domain.Aggregate.Albums.Requests;

namespace Sample.DbRepository.Domain.Aggregate.Albums.Handlers
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
