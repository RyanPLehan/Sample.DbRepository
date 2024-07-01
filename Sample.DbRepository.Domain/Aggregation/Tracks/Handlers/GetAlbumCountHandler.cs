using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Tracks.Handlers
{
    internal class GetAlbumCountHandler : IRequestHandler<GetAlbumCount, int>
    {
        private readonly ITrackRepository _repository;

        public GetAlbumCountHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<int> Handle(GetAlbumCount request, CancellationToken cancellationToken)
        {
            return await _repository.GetCount(request.AlbumId);
        }
    }
}
