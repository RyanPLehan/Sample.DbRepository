using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Tracks.Handlers
{
    internal class GetAlbumStatisticHandler : IRequestHandler<GetAlbumStatistic, AlbumStatistic>
    {
        private readonly ITrackRepository _repository;

        public GetAlbumStatisticHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<AlbumStatistic> Handle(GetAlbumStatistic request, CancellationToken cancellationToken)
        {
            return await _repository.GetAlbumStatistic(request.AlbumId);
        }
    }
}
