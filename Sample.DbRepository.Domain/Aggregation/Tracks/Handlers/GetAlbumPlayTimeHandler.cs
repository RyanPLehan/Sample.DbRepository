using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Tracks.Handlers
{
    internal class GetAlbumPlayTimeHandler : IRequestHandler<GetAlbumPlayTime, long>
    {
        private readonly ITrackRepository _repository;

        public GetAlbumPlayTimeHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<long> Handle(GetAlbumPlayTime request, CancellationToken cancellationToken)
        {
            return await _repository.GetPlayTime(request.AlbumId);
        }
    }
}
