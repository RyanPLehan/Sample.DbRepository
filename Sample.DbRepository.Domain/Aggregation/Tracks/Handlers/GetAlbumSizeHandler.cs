using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Tracks.Handlers
{
    internal class GetAlbumSizeHandler : IRequestHandler<GetAlbumSize, long>
    {
        private readonly ITrackRepository _repository;

        public GetAlbumSizeHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<long> Handle(GetAlbumSize request, CancellationToken cancellationToken)
        {
            return await _repository.GetSize(request.AlbumId);
        }
    }
}
